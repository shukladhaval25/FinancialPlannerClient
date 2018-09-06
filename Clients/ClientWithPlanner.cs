using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialPlannerClient.Clients
{
    public partial class ClientWithPlanner : Form
    {
        private Client _client;

        private const string ADD_CLIENT_API = "Client/Add";
        private const string UPDATE_CLIENT_API = "Client/Update";

        private const string GET_PLAN_BY_CLIENTID_API = "Planner/GetByClientId?id={0}";
        private const string ADD_PLAN_API ="Planner/Add";
        private const string UPDATE_PLAN_API ="Planner/Update";

        private DataTable _dtPlanner;


        public int ClientId
        {
            get
            {
                if (_client != null)
                    return _client.ID;
                else
                    return 0;
            }
        }

        public ClientWithPlanner()
        {
            InitializeComponent();
        }
        public ClientWithPlanner(Client client)
        {
            InitializeComponent();
            _client = client;
        }

        private void btnviewEditPlan_Click(object sender, EventArgs e)
        {
            if (cmbPlan.Tag.ToString() != "0")
            {

                ClientInfo frmClient = new ClientInfo(int.Parse(cmbPlan.Tag.ToString()), _client);
                frmClient.TopLevel = false;
                this.ParentForm.Controls[0].Controls[1].Controls.Add(frmClient);
                frmClient.Dock = DockStyle.Fill;
                frmClient.Show();
                this.Close();
            }
            else
                MessageBox.Show("Please select valid plan.", "Invalid Plan", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCreateNewPlan_Click(object sender, EventArgs e)
        {
            setPlanButtonVisibility(false);

            cmbPlan.Tag = 0;
            cmbPlan.DropDownStyle = ComboBoxStyle.DropDown;
            lblPlanStartDateVal.Visible = false;
            dtPlanStartDate.Visible = true;
            dtPlanStartDate.Value = DateTime.Now.Date;
            dtPlanStartDate.BringToFront();
        }

        private void dtPlanStartDate_ValueChanged(object sender, EventArgs e)
        {
            lblPlanStartDateVal.Text = dtPlanStartDate.Value.ToShortDateString();
        }

        private void lblPlanStartDateVal_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblPlanStartDateVal.Text))
                lblPlanEndDateValue.Text = string.Empty;
            else
            {
                DateTime dateTimeObj;
                if (DateTime.TryParse(lblPlanStartDateVal.Text, out dateTimeObj))
                    lblPlanEndDateValue.Text = dateTimeObj.AddYears(1).ToShortDateString();
            }
        }

        private void btnSavePlan_Click(object sender, EventArgs e)
        {
            updatePlan();
            setPlanButtonVisibility(true);
        }

        private void updatePlan()
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = string.Empty;

                Planner planner = new Planner()
                {
                    Name = cmbPlan.Text,
                    ClientId = ClientId,
                    StartDate = dtPlanStartDate.Value,
                    CreatedOn = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")),
                    CreatedBy = Program.CurrentUser.Id,
                    UpdatedOn =  DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")),
                    UpdatedBy = Program.CurrentUser.Id,
                    UpdatedByUserName = Program.CurrentUser.UserName,
                    MachineName = System.Environment.MachineName
                };

                if (cmbPlan.Tag.ToString() == "0" || cmbPlan.Tag.ToString() == "")
                {
                    apiurl = Program.WebServiceUrl + "/" + ADD_PLAN_API;
                }
                else
                {
                    apiurl = Program.WebServiceUrl + "/" + UPDATE_PLAN_API;
                    planner.ID = int.Parse(cmbPlan.Tag.ToString());
                }

                string DATA =  jsonSerialization.SerializeToString<Planner>(planner);

                WebClient webclient = new WebClient();
                webclient.Headers["Content-type"] = "application/json";
                webclient.Encoding = Encoding.UTF8;
                string json = webclient.UploadString(apiurl,"POST", DATA);

                if (json != null)
                {
                    var resultObject = jsonSerialization.DeserializeFromString<Result>(json);
                    if (resultObject.IsSuccess)
                    {
                        MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void setPlanButtonVisibility(bool isInViewMode)
        {
            btnSavePlan.Visible = !isInViewMode;
            btnCancelPlan.Visible = !isInViewMode;
            btnCreateNewPlan.Visible = isInViewMode;
            btnViewEditPlan.Visible = isInViewMode;

            if (!isInViewMode)
            {
                cmbPlan.DropDownStyle = ComboBoxStyle.DropDown;
                lblPlanStartDateVal.Visible = false;
                dtPlanStartDate.Visible = true;
                dtPlanStartDate.Value = DateTime.Now.Date;
                dtPlanStartDate.BringToFront();
            }
            else
            {
                cmbPlan.DropDownStyle = ComboBoxStyle.DropDownList;
                lblPlanStartDateVal.Visible = true;
                dtPlanStartDate.Visible = false;
                lblPlanStartDateVal.BringToFront();
            }
        }

        private void btnCancelPlan_Click(object sender, EventArgs e)
        {
            setPlanButtonVisibility(true);
        }

        private void ClientWithPlanner_Load(object sender, EventArgs e)
        {
            _dtPlanner = new DataTable();
            if (ClientId != 0)
            {
                displayClientInfo();
                loadPlanData();
                displayPlanData();
            }
            else
            {
                grpPlanner.Visible = false;
            }
        }

        private void displayPlanData()
        {
            cmbPlan.Items.Clear();
            if (_dtPlanner.Rows.Count > 0)
            {
                DataRow[] drs = _dtPlanner.Select("", "StartDate DESC");
                foreach(DataRow dr in drs)
                {
                    cmbPlan.Items.Add(dr.Field<string>("Name"));
                }
                cmbPlan.SelectedIndex = 0;
            }
        }

        private void loadPlanData()
        {
            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
            string apiurl = Program.WebServiceUrl +"/"+ string.Format(GET_PLAN_BY_CLIENTID_API,ClientId);

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

            if (plannerCollection.Value != null)
            {
                _dtPlanner = ListtoDataTable.ToDataTable(plannerCollection.Value);
            }
        }

        private void displayClientInfo()
        {
            if (_client != null)
            {
                txtName.Tag = _client.ID;
                txtName.Text = _client.Name;
                dtDOB.Value = _client.DOB;
                cmbGender.Text = _client.Gender;
                rdoMaritalStatusYes.Checked = _client.IsMarried;
                txtPan.Text = _client.PAN;
                txtAadhar.Text = _client.Aadhar;
                txtFatherName.Text = _client.FatherName;
                txtMotherName.Text = _client.MotherName;
                txtOccupation.Text = _client.Occupation;
                txtPlaceOfBirth.Text = _client.PlaceOfBirth;
                dtMarriageAnniversary.Checked = rdoMaritalStatusYes.Checked;
                dtMarriageAnniversary.Text = (_client.MarriageAnniversary == null) ? string.Empty : 
                     _client.MarriageAnniversary.ToString();
            }
        }
        
        private void rdoMaritalStatusNo_CheckedChanged(object sender, EventArgs e)
        {
            dtMarriageAnniversary.Checked = !rdoMaritalStatusNo.Checked;
        }

        private void rdoMaritalStatusYes_CheckedChanged(object sender, EventArgs e)
        {
            dtMarriageAnniversary.Checked = rdoMaritalStatusYes.Checked;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            updateClient();
        }
        private void updateClient()
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = string.Empty;

                Client client = new Client()
                {
                    Name = txtName.Text,
                    FatherName = txtFatherName.Text,
                    MotherName = txtMotherName.Text,
                    DOB = dtDOB.Value,
                    PlaceOfBirth = txtPlaceOfBirth.Text,
                    IsMarried = rdoMaritalStatusYes.Checked,
                    MarriageAnniversary =  dtMarriageAnniversary.Value,
                    PAN = txtPan.Text,
                    Aadhar = txtAadhar.Text,                    
                    Occupation = txtOccupation.Text ,             
                    CreatedOn = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")),
                    CreatedBy = Program.CurrentUser.Id,
                    UpdatedOn =  DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")),
                    UpdatedBy = Program.CurrentUser.Id,
                    UpdatedByUserName = Program.CurrentUser.UserName,
                    MachineName = System.Environment.MachineName
                };

                if (ClientId == 0)
                {
                    apiurl = Program.WebServiceUrl + "/" + ADD_CLIENT_API;
                }
                else
                {
                    apiurl = Program.WebServiceUrl + "/" + UPDATE_CLIENT_API;
                    client.ID = ClientId;
                }

                string DATA =  jsonSerialization.SerializeToString<Client>(client);

                WebClient webclient = new WebClient();
                webclient.Headers["Content-type"] = "application/json";
                webclient.Encoding = Encoding.UTF8;
                string json = webclient.UploadString(apiurl,"POST", DATA);

                if (json != null)
                {
                    var resultObject = jsonSerialization.DeserializeFromString<Result>(json);
                    if (resultObject.IsSuccess)
                    {
                        MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
           DataRow[] drs = _dtPlanner.Select("Name = '" + cmbPlan.Text + "'");
            foreach (DataRow dr in drs)
            {
                cmbPlan.Tag = dr.Field<string>("ID");
                lblPlanStartDateVal.Text = (dr["StartDate"]).ToString();
                lblPlanEndDateValue.Text = (dr["EndDate"]).ToString();
            }
        }
    }
}
