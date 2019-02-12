using DevExpress.XtraEditors;
using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace FinancialPlannerClient.PlanOptions
{
    public partial class PlanOptions : DevExpress.XtraEditors.XtraForm
    {
        private const string RISKPROFILE_GETALL = "RiskProfileReturn/GetAll";
        private const string PLANOPTION_GETALL = "PlanOption/GetAll?plannerId={0}";
        private List<RiskProfiledReturnMaster> _riskProfileMasters = new List<RiskProfiledReturnMaster>();
        DataTable _dtPlanOption;

        private int planId;
        Client client;
        Planner planner;

        public PlanOptions()
        {
            InitializeComponent();
        }

        public PlanOptions(Client client, Planner planner)
        {
            InitializeComponent();
            this.client = client;
            this.planId = planner.ID;
            this.planner = planner;
        }

        private void btnClosePlanoptions_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSavePlanoption_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrEmpty(cmbRiskProfile.Text))
            {
                MessageBox.Show("Please select Risk profile value.", "Risk profile require", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            PlanOption planOpt = new PlanOption();
            planOpt.Id = int.Parse(txtOptionName.Tag.ToString());
            planOpt.Pid = int.Parse(lblPlanVal.Tag.ToString());
            planOpt.Name = txtOptionName.Text;
            planOpt.RiskProfileId = int.Parse(cmbRiskProfile.Tag.ToString());
            planOpt.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            planOpt.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            planOpt.UpdatedBy = Program.CurrentUser.Id;
            planOpt.CreatedBy = Program.CurrentUser.Id;
            planOpt.UpdatedByUserName = Program.CurrentUser.UserName;
            planOpt.MachineName = System.Environment.MachineName;

            if (new PlanOptionInfo().Save(planOpt))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                DevExpress.XtraEditors.XtraMessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void PlanOptions_Load(object sender, EventArgs e)
        {
            loadRiskProfileData();
            loadPlanoptions();
            lblclientNameVal.Text = client.Name;
            lblPlanVal.Text = this.planner.Name;
            lblPlanValue.Text = this.planner.Name;
            lblPlanVal.Tag = this.planner.ID;
        }
        private void loadRiskProfileData()
        {
            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
            string apiurl = Program.WebServiceUrl + "/" + RISKPROFILE_GETALL;

            RestAPIExecutor restApiExecutor = new RestAPIExecutor();

            var restResult = restApiExecutor.Execute<List<RiskProfiledReturnMaster>>(apiurl, null, "GET");

            if (jsonSerialization.IsValidJson(restResult.ToString()))
            {
                _riskProfileMasters = jsonSerialization.DeserializeFromString<List<RiskProfiledReturnMaster>>(restResult.ToString());
                foreach (var riskProfile in _riskProfileMasters)
                {
                    cmbRiskProfile.Properties.Items.Add(riskProfile.Name);
                }
            }
            else
                XtraMessageBox.Show(restResult.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //cmbRiskProfile.Text = _riskProfileName;
        }
        private void loadPlanoptions()
        {
            try
            {

                _dtPlanOption = new PlanOptionInfo().GetAll(planId);

                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + string.Format(PLANOPTION_GETALL, planId);

                loadplanoptionlist();
            }
            catch (System.Net.WebException webException)
            {
                if (webException.Message.Equals("The remote server returned an error: (401) Unauthorized."))
                {
                    XtraMessageBox.Show("You session has been expired. Please Login again.", "Session Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
            }
        }

        private void loadplanoptionlist()
        {
            lstPlanOption.Items.Clear();
            foreach (DataRow dr in _dtPlanOption.Rows)
            {
                lstPlanOption.Items.Add(dr["Name"].ToString());
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

        private void cmbRiskProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            RiskProfiledReturnMaster rpm = _riskProfileMasters.Find(i => i.Name == cmbRiskProfile.Text);
            if (rpm != null)
                cmbRiskProfile.Tag = rpm.Id;
        }

        private void lstPlanOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstPlanOption.SelectedItem != null)
            {
                DataRow[] drs = _dtPlanOption.Select("Name  ='" + lstPlanOption.Text + "'");
                if (drs != null)
                {
                    txtOptionName.Tag = drs[0]["ID"];
                    txtOptionName.Text = lstPlanOption.Text;
                    cmbRiskProfile.Tag = drs[0]["RiskProfileID"];
                    cmbRiskProfile.Text = getRiskProfileName(int.Parse(cmbRiskProfile.Tag.ToString()));
                }
                btnDelete.Enabled = true;
            }
            else
                btnDelete.Enabled = false;
        }
        private string getRiskProfileName(int riskProfileId)
        {
            foreach (RiskProfiledReturnMaster riskProfileMaster in _riskProfileMasters)
            {
                if (riskProfileMaster.Id == riskProfileId)
                    return riskProfileMaster.Name;
            }
            return string.Empty;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            grpPlanOption.Enabled = true;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grpPlanOption.Enabled = true;
            txtOptionName.Tag = 0;
            txtOptionName.Text  = "";
            cmbRiskProfile.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lstPlanOption.SelectedItem.ToString()))
            {
                XtraMessageBox.Show("Please select valid plan option.", "Select option", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (XtraMessageBox.Show("Are you sure, you want to delete this record?", "Select option",
                MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                PlanOption planOpt = new PlanOption();
                planOpt.Id = int.Parse(txtOptionName.Tag.ToString());
                planOpt.Pid = int.Parse(lblPlanVal.Tag.ToString());
                planOpt.Name = txtOptionName.Text;
                planOpt.RiskProfileId = int.Parse(cmbRiskProfile.Tag.ToString());
                if (new PlanOptionInfo().Delete(planOpt))
                {
                    XtraMessageBox.Show("Record deleted sucessfully.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DataRow[] drs = _dtPlanOption.Select("ID  ='" + txtOptionName.Tag + "'");
                    drs[0].Delete();
                    lstPlanOption.Items.Remove(lstPlanOption.SelectedItem);
                }
            }
        }
    }
}
