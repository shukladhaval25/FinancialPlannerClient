using DevExpress.XtraEditors;
using FinancialPlanner.Common;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.PlannerInfo;
using FinancialPlannerClient.PlanOptions;
using System;
using System.Collections.Generic;
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
    public partial class Clientdashboard : DevExpress.XtraEditors.XtraForm
    {
        private enum NavigateTo
        {
            Dashborad = 0,
            ContactInfo = 1,
            EmployeeInfo = 2,
            Client = 3,
        }


        #region "ClientInfo variables"
        private Client _client;
        private DataTable _dtBankAccount;
        private const string UPDATE_CLIENT_API = "Client/Update";
        PersonalInformation personalInformation;


        #endregion

        #region "Planner Variables"
        private readonly string GET_PLAN_BY_CLIENTID_API = "Planner/GetByClientId?id={0}";
        private List<Planner> _planners = new List<Planner>();
        private Planner planner;
        #endregion

        public Clientdashboard(Client client)
        {
            if (client == null)
                throw new InvalidOperationException("Fail to perform operation due to invalid object.");

            getPersonalDetails(client.ID);
            InitializeComponent();
            displayClientInfo();
            loadPlanData();
            DashboardNavFrame.SelectedPageIndex = (int)NavigateTo.Dashborad;
        }
        private void getPersonalDetails(int clientId)
        {
            ClientPersonalInfo clientPersonalInfo = new ClientPersonalInfo();
            personalInformation = clientPersonalInfo.Get(clientId);
            if (personalInformation != null && personalInformation.Client != null)
            {
                this._client = personalInformation.Client;
            }
        }
        private void displayClientInfo()
        {
            lblName.Text = this._client.Name;
            lblClientID.Text = this._client.ID.ToString();
            clientImage.Image = (this._client.ImageData == null) ?
                Properties.Resources.icons8_customer_30 :
                converToImageFromBase64String(this._client.ImageData);

        }

        private Image converToImageFromBase64String(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }

        private void ContactInfo_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Contact clientContact = new Contact(this._client);
            clientContact.TopLevel = false;
            clientContact.Visible = true;
            navigationPageContactInfo.Name = clientContact.Name;
            navigationPageContactInfo.Controls.Add(clientContact);
            showNavigationPage(clientContact.Name);
        }

        private void btnShowDashborad_Click(object sender, EventArgs e)
        {
            redirectToDashboardPage();
        }

        private void redirectToDashboardPage()
        {
            DashboardNavFrame.SelectedPageIndex = (int)NavigateTo.Dashborad;
        }

        private void EmployeeInfo_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            EmploymentDetails employmentDetails = new EmploymentDetails(this._client);
            employmentDetails.TopLevel = false;
            employmentDetails.Visible = true;
            navigationPageEmployee.Name = employmentDetails.Name;
            navigationPageEmployee.Controls.Add(employmentDetails);
            showNavigationPage(employmentDetails.Name);
        }

        private void btnViewClientInfo_Click(object sender, EventArgs e)
        {
            ClientDetails clientDetails = new ClientDetails(this._client);
            clientDetails.TopLevel = false;
            clientDetails.Visible = true;
            navigationPageClient.Name = clientDetails.Name;
            navigationPageClient.Controls.Clear();
            navigationPageClient.Controls.Add(clientDetails);
            showNavigationPage(clientDetails.Name);
        }

        #region "Client Info"
        private void showClientInfo()
        {
            ClientImageInfo.Image = clientImage.Image;
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

        private void showBankDetails()
        {
            BankAccountInfo bankAccountInfo = new BankAccountInfo();
            IList<BankAccountDetail> bankAcDetails = bankAccountInfo.GetAll(_client.ID);
            if (bankAcDetails != null)
            {
                _dtBankAccount = ListtoDataTable.ToDataTable(bankAcDetails.ToList());
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
            redirectToDashboardPage();
        }

        private void btnSaveClient_Click(object sender, EventArgs e)
        {
            updateClient();
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

                apiurl = Program.WebServiceUrl + "/" + UPDATE_CLIENT_API;

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
                        redirectToDashboardPage();
                        displayClientInfo();
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

        #endregion

        #region "Plan Information"
        private void loadPlanData()
        {
            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
            string apiurl = Program.WebServiceUrl + "/" + string.Format(GET_PLAN_BY_CLIENTID_API, this._client.ID);

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(apiurl);
            request.Method = "GET";
            String planerResultJson = String.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);
                planerResultJson = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
            }
            var plannerCollection = jsonSerialization.DeserializeFromString<Result<List<Planner>>>(planerResultJson);

            if (plannerCollection.IsSuccess && plannerCollection.Value.Count > 0)
            {
                //var newList  // ToList optional
                this._planners = plannerCollection.Value.OrderByDescending(x => x.StartDate).ToList();
                fillupPlannerCombobox();
            }
        }

        private void fillupPlannerCombobox()
        {
            cmbPlanner.Properties.Items.Clear();
            if (this._planners.Count > 0)
            {
                foreach (Planner planner in _planners)
                {
                    cmbPlanner.Properties.Items.Add(planner.Name);
                }
                cmbPlanner.SelectedIndex = 0;
            }
        }
        private void cmbPlanner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this._planners.Count > 0)
            {
                foreach (Planner planner in _planners)
                {
                    if (planner.Name == cmbPlanner.Text)
                    {
                        this.planner = planner;
                        break;
                    }
                }
            }
        }
        #endregion

        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }

        private void Clientdashboard_Load(object sender, EventArgs e)
        {

        }

        private void navBarItemFamily_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

        }
        private bool addNewNavigationPage(string pagename, DevExpress.XtraEditors.XtraForm xtraForm)
        {
            bool result = false;
            if (string.IsNullOrEmpty(pagename))
                throw new ArgumentNullException("Cotrol name should not be null.");

            if (xtraForm == null)
                throw new ArgumentNullException("Control should not be null");

            int nameMatchCount = DashboardNavFrame.Pages.Where(i => i.Name == pagename).Count();
            if (nameMatchCount == 0)
            {
                DevExpress.XtraBars.Navigation.NavigationPageBase navigationPageBase = new DevExpress.XtraBars.Navigation.NavigationPageBase
                {
                    Name = pagename
                };
                navigationPageBase.Controls.Add(xtraForm);
                DashboardNavFrame.Pages.Add(navigationPageBase);
                result = true;
            }
            return result;
        }

        private void showNavigationPage(string pageName)
        {
            for (int index = 0; index <= DashboardNavFrame.Pages.Count; index++)
            {
                if (DashboardNavFrame.Pages[index].Name == pageName)
                {
                    DashboardNavFrame.SelectedPageIndex = index;
                    break;
                }
            }
        }

        private void navigationPageClient_ControlRemoved(object sender, ControlEventArgs e)
        {
            redirectToDashboardPage();
        }
        private void navBarItemAssumptions_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            string spouseName = (personalInformation.Spouse != null) ?
                personalInformation.Spouse.Name : string.Empty;
            Assumption assumption = new Assumption(this._client, planner, spouseName);
            assumption.TopLevel = false;
            assumption.Visible = true;
            navigationPageOther.Name = assumption.Name;
            navigationPageOther.Controls.Clear();
            navigationPageOther.Controls.Add(assumption);
            showNavigationPage(assumption.Name);
        }

        private void navBarItemEstimatedPlan_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //EstimatedPlan estimatedPlan = new EstimatedPlan(this._client.ID, planner);
            EstimatedPlanOptionList estimatedPlan = new EstimatedPlanOptionList(this._client);
            estimatedPlan.TopLevel = false;
            estimatedPlan.Visible = true;
            navigationPageOther.Name = estimatedPlan.Name;
            navigationPageOther.Controls.Clear();
            navigationPageOther.Controls.Add(estimatedPlan);
            showNavigationPage(estimatedPlan.Name);
        }

        private void navBarItemReport_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {

            PlannerMainReport plannerMainReport = new PlannerMainReport(this.personalInformation,planner);
            DevExpress.XtraReports.UI.ReportPrintTool printTool = new DevExpress.XtraReports.UI.ReportPrintTool(plannerMainReport);
            printTool.ShowRibbonPreviewDialog();

        }

        private void navBarItemOtherInformation_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ClientInfo clientInfo = new ClientInfo(planner.ID, this._client,true);
            clientInfo.TopLevel = false;
            clientInfo.Visible = true;
            navigationPageOther.Name = clientInfo.Name;
            navigationPageOther.Controls.Clear();
            navigationPageOther.Controls.Add(clientInfo);
            showNavigationPage(clientInfo.Name);
        }
    }
}
