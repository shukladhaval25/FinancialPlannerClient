using DevExpress.XtraEditors;
using FinancialPlanner.Common;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.PlannerInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace FinancialPlannerClient.Clients
{
    public partial class ClientDetails : DevExpress.XtraEditors.XtraForm
    {
        Client _client;
        PersonalInformation personalInformation;
        IEnumerable<BankAccountDetail> allBankAcDetails;

        private DataTable _dtBankAccount;
        private DataTable _dtSpouseBankAcInfo;
        private const string UPDATE_CLIENT_API = "Client/Update";
        private const string ADD_CLIENT_API = "Client/Add";

        public ClientDetails(Client client)
        {
            InitializeComponent();
            _client = client;
        }

        private void ClientDetails_Load(object sender, EventArgs e)
        {
            if (this._client != null)
            {
                getClientAndSpousePersonalDetails();
                showBankDetails();

                fillSpousePersonalDetails(personalInformation.Spouse);
                showSpouseBankDetails();
            }
            dtMarriageAnniversary.Enabled = chkMarrried.Checked;
            //this.DialogResult = DialogResult.Ignore;
        }



        #region "Clinet Details"
        
        private void getClientAndSpousePersonalDetails()
        {
            ClientPersonalInfo clientPersonalInfo = new ClientPersonalInfo();
            personalInformation = clientPersonalInfo.Get(_client.ID);
            if (personalInformation != null && personalInformation.Client != null)
            {
                this._client = personalInformation.Client;
                showClientInfo();
            }
        }
        private void showClientInfo()
        {
            ClientImageInfo.Image = (this._client.ImageData == null) ?
               Properties.Resources.icons8_customer_30 :
               converToImageFromBase64String(this._client.ImageData);
            txtName.Text = this._client.Name;
            txtName.Tag = this._client.ID;
            txtFatherName.Text = this._client.FatherName;
            txtMotherName.Text = this._client.MotherName;
            cmbGender.Text = this._client.Gender;
            dtDOB.Text = this._client.DOB.ToShortDateString();
            chkMarrried.Checked = this._client.IsMarried;
            dtMarriageAnniversary.Text = this._client.MarriageAnniversary.HasValue ?
                this._client.MarriageAnniversary.Value.ToShortDateString() :
                string.Empty;
            txtPAN.Text = this._client.PAN;
            txtAadharCard.Text = this._client.Aadhar;
            txtPlaceOfBirth.Text = this._client.PlaceOfBirth;
            txtClientOccupation.Text = this._client.Occupation;
        }

        private Image converToImageFromBase64String(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }

        private void showBankDetails()
        {
            BankAccountInfo bankAccountInfo = new BankAccountInfo();
            allBankAcDetails = bankAccountInfo.GetAll(_client.ID);
            if (allBankAcDetails != null)
            {
                IEnumerable<BankAccountDetail> clientBankAccountDetails = allBankAcDetails.Where(i => i.AccountHolderID == _client.ID);
                _dtBankAccount = ListtoDataTable.ToDataTable(clientBankAccountDetails.ToList());
                grdBank.DataSource = _dtBankAccount;
            }
        }
        private void btnChangeImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtImagePath.Text = openFileDialog1.FileName;
                ClientImageInfo.Image = Image.FromFile(openFileDialog1.FileName);
                _client.ImageData = getStringfromFile(txtImagePath.Text);
                _client.ImagePath = _client.Name + System.IO.Path.GetExtension(txtImagePath.Text);
            }
        }
        private void btnCloseClientInfo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnSaveClient_Click(object sender, EventArgs e)
        {
            //updateClient
            if (string.IsNullOrEmpty(txtName.Text))
            {
                XtraMessageBox.Show("Please enter client name.", "Invalid Data", System.Windows.Forms.MessageBoxButtons.OK);
                return;
            }
            PersonalInformation personalInfo = new PersonalInformation();
            personalInfo.Client = getClientData();
            personalInfo.Spouse = getClientSpouseData();
            ClientPersonalInfo clientPersonalInfo = new ClientPersonalInfo();
            clientPersonalInfo.Update(personalInfo);
        }

        private void updateClient()
        {
            try
            {
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    XtraMessageBox.Show("Please enter client name.", "Invalid Data", System.Windows.Forms.MessageBoxButtons.OK);
                    return;
                }

                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = string.Empty;

                Client client = new Client()
                {
                    ID = _client.ID,
                    Name = txtName.Text,
                    FatherName = txtFatherName.Text,
                    MotherName = txtMotherName.Text,
                    DOB = dtDOB.DateTime,
                    PlaceOfBirth = txtPlaceOfBirth.Text,
                    Gender = cmbGender.Text,
                    IsMarried = chkMarrried.Checked,
                    MarriageAnniversary = dtMarriageAnniversary.DateTime,
                    PAN = txtPAN.Text,
                    Aadhar = txtAadharCard.Text,
                    Occupation = txtClientOccupation.Text,
                    CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")),
                    CreatedBy = Program.CurrentUser.Id,
                    UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")),
                    UpdatedBy = Program.CurrentUser.Id,
                    UpdatedByUserName = Program.CurrentUser.UserName,
                    MachineName = System.Environment.MachineName,
                    ImageData = _client.ImageData,
                    ImagePath = _client.ImagePath
                };

                _client = client;

                if (_client.ID == 0)
                {
                    apiurl = Program.WebServiceUrl + "/" + ADD_CLIENT_API;
                }
                else
                {
                    apiurl = Program.WebServiceUrl + "/" + UPDATE_CLIENT_API;                   
                }

                string DATA = jsonSerialization.SerializeToString<Client>(client);

                WebClient webclient = new WebClient();
                webclient.Headers["Content-type"] = "application/json";
                webclient.Encoding = Encoding.UTF8;
                string json = webclient.UploadString(apiurl, "POST", DATA);

                if (json != null)
                {
                    var resultObject = jsonSerialization.DeserializeFromString<Result>(json);
                    if (resultObject.IsSuccess)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Record save successfully.", "Record Saved", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                    }
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
            }
        }
        private void chkMarrried_CheckedChanged(object sender, EventArgs e)
        {
        //    if (chkMarrried.Checked == false)
        //        dtMarriageAnniversary.Text = "";

            dtMarriageAnniversary.Enabled = chkMarrried.Checked;
            grpSpouse.Enabled = chkMarrried.Checked;
        }


        private ClientSpouse getClientSpouseData()
        {
            ClientSpouse spouse = new ClientSpouse();
            spouse.Name = txtSpouseName.Text;
            spouse.ClientId = _client.ID;
            spouse.DOB = dtSpouseDOB.DateTime;
            spouse.IsMarried = chkMarrried.Checked;
            spouse.FatherName = txtSpouseFatherName.Text;
            spouse.MotherName = txtSpouseMotherName.Text;
            spouse.PAN = txtSpousePAN.Text;
            spouse.Aadhar = txtSpouseAadhar.Text;
            spouse.PlaceOfBirth = txtSpousePlaceOfBirth.Text;
            spouse.Occupation = txtSpouseOccupation.Text;
            spouse.Gender = cmbSpouseGender.Text;
            spouse.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            spouse.UpdatedBy = Program.CurrentUser.Id;
            spouse.UpdatedByUserName = Program.CurrentUser.UserName;
            spouse.MachineName = System.Environment.MachineName;
            return spouse;
        }

        private Client getClientData()
        {
            Client client = new Client()
            {
                ID = _client.ID,
                Name = txtName.Text,
                FatherName = txtFatherName.Text,
                MotherName = txtMotherName.Text,
                DOB = dtDOB.DateTime,
                PlaceOfBirth = txtPlaceOfBirth.Text,
                Gender = cmbGender.Text,
                IsMarried = chkMarrried.Checked,
                MarriageAnniversary = dtMarriageAnniversary.DateTime,
                PAN = txtPAN.Text,
                Aadhar = txtAadharCard.Text,
                Occupation = txtClientOccupation.Text,
                CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")),
                CreatedBy = Program.CurrentUser.Id,
                UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")),
                UpdatedBy = Program.CurrentUser.Id,
                UpdatedByUserName = Program.CurrentUser.UserName,
                MachineName = System.Environment.MachineName,
                ImageData = _client.ImageData,
                ImagePath = _client.ImagePath
            };
            return client;
        }

        #endregion

        #region "Spouse"
        private void fillSpousePersonalDetails(ClientSpouse spouse)
        {
            if (spouse != null)
            {
                txtSpouseName.Text = spouse.Name;
                if (spouse.DOB != DateTime.MinValue)
                    dtSpouseDOB.DateTime = spouse.DOB;
                //dtSpouseMarriageAnniversary.Checked = spouse.IsMarried;
                txtSpouseFatherName.Text = spouse.FatherName;
                txtSpouseMotherName.Text = spouse.MotherName;
                txtSpousePAN.Text = spouse.PAN;
                txtSpouseAadhar.Text = spouse.Aadhar;
                txtSpousePlaceOfBirth.Text = spouse.PlaceOfBirth;
                txtSpouseOccupation.Text = spouse.Occupation;
                cmbSpouseGender.Text = spouse.Gender;
            }
        }

        private void showSpouseBankDetails()
        {
            if (allBankAcDetails != null)
            {
                IEnumerable<BankAccountDetail> clientBankAccountDetails = 
                    allBankAcDetails.Where(i => i.AccountHolderID == personalInformation.Spouse.ID);
                _dtSpouseBankAcInfo = ListtoDataTable.ToDataTable(clientBankAccountDetails.ToList());
                grdSpouseBank.DataSource = _dtSpouseBankAcInfo;
            }
        }

        #endregion

        private string getStringfromFile(string filePath)
        {
            try
            {
                if (!string.IsNullOrEmpty(filePath))
                {
                    if (System.IO.File.Exists(filePath))
                    {
                        FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                        byte[] filebytes = new byte[fs.Length];
                        fs.Read(filebytes, 0, Convert.ToInt32(fs.Length));
                        return Convert.ToBase64String(filebytes,
                                                      Base64FormattingOptions.InsertLineBreaks);
                    }
                }
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
            }
            return null;
        }
        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }

        private void ClientDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Parent != null && this.Parent.Name == "navigationPageClient")
            this.Parent.Controls.Remove(this);
        }

    }
}
