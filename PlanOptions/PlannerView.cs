using FinancialPlanner.Common;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.Clients;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace FinancialPlannerClient.PlanOptions
{
    public partial class PlannerView : DevExpress.XtraEditors.XtraForm
    {
        PersonalInformation personalInformation;
        private DataTable _dtPlanner;

        private const string GET_PLAN_BY_CLIENTID_API = "Planner/GetByClientId?id={0}";
        private const string ADD_PLAN_API = "Planner/Add";
        private const string UPDATE_PLAN_API = "Planner/Update";
        private const string DELETE_PLAN_API = "Planner/Delete";

        private const string USERAPI = "User";
        DataTable _dtUser;

        public PlannerView(PersonalInformation personalInformation)
        {
            InitializeComponent();
            this.personalInformation = personalInformation;
        }

        private void PlannerView_Load(object sender, EventArgs e)
        {
            _dtPlanner = new DataTable();
            if (this.personalInformation.Client.ID != 0)
            {
                loadUserInformation();
                loadPlanData();
                displayPlanData();   
            }
        }

        private void loadPlanData()
        {
            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
            string apiurl = Program.WebServiceUrl + "/" + string.Format(GET_PLAN_BY_CLIENTID_API, this.personalInformation.Client.ID);

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
        private void displayPlanData()
        {
            lstPlanner.Items.Clear();
            if (_dtPlanner.Rows.Count > 0)
            {
                DataRow[] drs = _dtPlanner.Select("", "StartDate DESC");
                foreach (DataRow dr in drs)
                {
                    lstPlanner.Items.Add(dr.Field<string>("Name"));
                }
                lstPlanner.SelectedIndex = 0;
                pnlPlannerInfo.Enabled = true;
                pnlManager.Enabled = true;
            }
            else
            {
                pnlPlannerInfo.Enabled = false;
                pnlManager.Enabled = false;
            }
        }

        private void lstPlanner_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDelete.Enabled = (lstPlanner.SelectedItems.Count > 0) ? true : false;

            DataRow[] drs = _dtPlanner.Select("Name = '" + lstPlanner.Text.ToString() + "'");
            foreach (DataRow dr in drs)
            {
                txtPlanName.Tag = dr.Field<string>("ID");
                txtPlanName.Text = dr.Field<string>("Name");
                dtStartDate.Text = (dr["StartDate"]).ToString();
                //txtEndDate.Text = (dr["EndDate"]).ToString();
                cmbStartMonth.Text = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(int.Parse(dr["PlannerStartMonth"].ToString()));
                int accountManagedById;
                int.TryParse(dr["AccountManagedBy"].ToString(), out accountManagedById);
                if (_dtUser != null)
                {
                    DataRow[] drUsers = _dtUser.Select("ID ='" + accountManagedById + "'");
                    cmbManagedBy.Text = (drUsers != null && drUsers.Length > 0) ? drUsers[0]["FirstName"].ToString() : string.Empty;
                }
                cmbReviewFrequency.Text = dr.Field<string>("ReviewFrequency");
                memoDescription.Text = dr.Field<string>("Description");
                txtCurrencySymbol.Text = dr.Field<string>("CurrencySymbol");
            }
            pnlPlannerInfo.Enabled = true;
            pnlManager.Enabled = true;
        }

        private void cmbStartMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbStartMonth.SelectedIndex >= 0)
            {
                int endMonthAt = new DateTime(2000, cmbStartMonth.SelectedIndex + 1, 1).AddMonths(-1).Month;
                cmbEndMonth.Text = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(endMonthAt);
            }
            else
                cmbEndMonth.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtPlanName.Tag = 0;
            txtPlanName.Text = "";
            dtStartDate.Text = "";
            txtEndDate.Text = "";
            cmbStartMonth.Text = "";
            cmbEndMonth.Text = "";
            cmbManagedBy.Text = Program.CurrentUser.FirstName;
            cmbReviewFrequency.Text = "";
            memoDescription.Text = "";
            pnlPlannerInfo.Enabled = true;
            pnlManager.Enabled = true;
        }

        private void btnSavePlanoption_Click(object sender, EventArgs e)
        {
            updatePlan();
        }
        private void updatePlan()
        {
            try
            {
                if (cmbManagedBy.Text == "")
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Please select plan manage by value.", "Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = string.Empty;
                int accountManagedById;

                Planner planner = new Planner()
                {
                    Name = txtPlanName.Text,
                    ClientId = this.personalInformation.Client.ID,
                    StartDate = dtStartDate.DateTime,
                    CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")),
                    CreatedBy = Program.CurrentUser.Id,
                    UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")),
                    UpdatedBy = Program.CurrentUser.Id,
                    UpdatedByUserName = Program.CurrentUser.UserName,
                    MachineName = System.Environment.MachineName,
                    PlannerStartMonth = cmbStartMonth.SelectedIndex + 1,
                    Description = memoDescription.Text,
                    ReviewFrequency = cmbReviewFrequency.Text,
                    CurrencySymbol = txtCurrencySymbol.Text 
                };
                if (int.TryParse(cmbManagedBy.Tag.ToString(), out accountManagedById))
                    planner.AccountManagedBy = accountManagedById;

                if (txtPlanName.Tag.ToString() == "0" || txtPlanName.Tag.ToString() == "")
                {
                    apiurl = Program.WebServiceUrl + "/" + ADD_PLAN_API;
                }
                else
                {
                    apiurl = Program.WebServiceUrl + "/" + UPDATE_PLAN_API;
                    planner.ID = int.Parse(txtPlanName.Tag.ToString());
                }

                string DATA = jsonSerialization.SerializeToString<Planner>(planner);

                WebClient webclient = new WebClient();
                webclient.Headers["Content-type"] = "application/json";
                webclient.Encoding = Encoding.UTF8;
                string json = webclient.UploadString(apiurl, "POST", DATA);

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
            catch (Exception)
            {
                MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClosePlanoptions_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtStartDate_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dtStartDate.Text))
                txtEndDate.Text = string.Empty;
            else
            {
                txtEndDate.Text = dtStartDate.DateTime.AddYears(1).AddDays(-1).ToShortDateString();
            }
        }

        private void loadUserInformation()
        {
            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
            string apiurl = Program.WebServiceUrl + "/" + USERAPI;

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(apiurl);
            request.Method = "GET";
            String userResultJson = String.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);
                userResultJson = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
            }
            var userCollection = jsonSerialization.DeserializeFromString<Result<List<User>>>(userResultJson);

            if (userCollection.Value != null)
            {
                _dtUser = ListtoDataTable.ToDataTable(userCollection.Value);
                fillManagedByList();
            }
        }

        private void fillManagedByList()
        {
            cmbManagedBy.Properties.Items.Clear();
            for (int i = 0; i <= _dtUser.Rows.Count - 1; i++)
            {
                cmbManagedBy.Properties.Items.Add(_dtUser.Rows[i]["FirstName"].ToString());
            }
        }

        private void cmbManagedBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbManagedBy.Tag = _dtUser.Select("FirstName ='" + cmbManagedBy.Text + "'")[0]["ID"].ToString();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstPlanner.SelectedItems.Count > 0)
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this client?",
                    "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                    Planner planner = getPlanner();
                    string DATA = jsonSerialization.SerializeToString<Planner>(planner);

                    WebClient webclient = new WebClient();
                    webclient.Headers["Content-type"] = "application/json";
                    webclient.Encoding = Encoding.UTF8;
                    string apiurl = Program.WebServiceUrl + "/" + DELETE_PLAN_API;
                    string json = webclient.UploadString(apiurl, "POST", DATA);

                    if (json != null)
                    {
                        var resultObject = jsonSerialization.DeserializeFromString<Result>(json);
                        if (resultObject.IsSuccess)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("Record deleted scuessfully.", "Deleted");
                            loadPlanData();
                            displayPlanData();
                        }
                    }
                }
            }
        }

        private Planner getPlanner()
        {
            Planner planner = new Planner()
            {
                ID = int.Parse(txtPlanName.Tag.ToString()),
                Name = txtPlanName.Text,
                ClientId = this.personalInformation.Client.ID,
                StartDate = dtStartDate.DateTime,
                CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")),
                CreatedBy = Program.CurrentUser.Id,
                UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")),
                UpdatedBy = Program.CurrentUser.Id,
                UpdatedByUserName = Program.CurrentUser.UserName,
                MachineName = System.Environment.MachineName,
                PlannerStartMonth = cmbStartMonth.SelectedIndex + 1,
                Description = memoDescription.Text
            };
            return planner;
        }

        private void PlannerView_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                Clientdashboard parentForm = (Clientdashboard)this.ParentForm;
                parentForm.LoadPlanData();
                if (this.DialogResult == DialogResult.OK)
                {
                    if (DevExpress.XtraEditors.XtraMessageBox.Show("Do you want to migrate date from previous plan to current plan?",
                      "Data Migration", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        PlannerDataMigration plannerDataMigration = new PlannerDataMigration(parentForm._client, parentForm.planner);
                        plannerDataMigration.Show();
                    }
                }
            }
            catch(Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
            }
        }
        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }
    }
}
