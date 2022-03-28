using DevExpress.XtraEditors;
using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace FinancialPlannerClient.PlanOptions
{
    public partial class ReportParams : DevExpress.XtraEditors.XtraForm
    {
        DataTable _dtOption = new DataTable();
        private const string UPDATE_PLAN_API = "Planner/Update";
        private const string RISKPROFILE_GETALL = "RiskProfileReturn/GetAll";
        private List<RiskProfiledReturnMaster> _riskProfileMasters = new List<RiskProfiledReturnMaster>();
        internal frmReportPageOption frmReportPage;
        //int planId;
        int optionId;
        int riskProfileId;
        public ReportOption Option { get; set; }
        //string recommendation;
        Planner planner;
        public ReportParams(Planner planner)
        {
            InitializeComponent();
            this.planner = planner;
            if (string.IsNullOrEmpty(this.planner.Recommendation))
            {
                txtRecomendation.Text = "* We recommended maintaining Rs.6 lakhs as contingency fund." + System.Environment.NewLine + System.Environment.NewLine + "* Your annual Investment considering your income and expenses will be RS. 7.60 Lakhs for next 1 Year.";
                this.planner.Recommendation = txtRecomendation.Text;
            }
            else
            {
                txtRecomendation.Text = this.planner.Recommendation;
            }
        }
        public int GetOptionId()
        {
            return this.optionId;
        }
        public int GetRiskProfileId()
        {
            return this.riskProfileId;
        }

        public int GetModelPortfolioRiskProfileId()
        {
            if (cmbRiskProfile.Tag == null)
                return 0;
            else
                return int.Parse(cmbRiskProfile.Tag.ToString());
        }

        private void fillOptionData()
        {
            cmbPlanOption.Properties.Items.Clear();
            _dtOption = new PlanOptionInfo().GetAll(this.planner.ID);
            if (_dtOption != null)
            {
                if (_dtOption.Rows.Count > 0)
                {
                    DataRow[] drs = _dtOption.Select("", "Name ASC");
                    foreach (DataRow dr in drs)
                    {
                        cmbPlanOption.Properties.Items.Add(dr.Field<string>("Name"));
                    }
                    cmbPlanOption.SelectedIndex = 0;
                }
            }
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

        private void ReportParams_Load(object sender, EventArgs e)
        {
            fillOptionData();
            loadRiskProfileData();
        }

        private void cmbPlanOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            var val = _dtOption.Select("NAME ='" + cmbPlanOption.Text + "'");
            if (val != null)
            {
                cmbPlanOption.Tag = int.Parse(val[0][0].ToString());
                this.optionId = int.Parse(val[0][0].ToString());
                this.riskProfileId = int.Parse(val[0]["RiskProfileID"].ToString());
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbPlanOption.Text))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Please select option.", "Invalid Option", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (frmReportPage == null)
            {
                frmReportPage = new frmReportPageOption();
                frmReportPage.GetAndDisplayReportPageSeting();
                frmReportPage.btnApply_Click(sender, e);
                frmReportPage.Close();
            }
          
            if (frmReportPage.blnModelPortfolio && string.IsNullOrEmpty(cmbRiskProfile.Text))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Please select risk profile for model portfolio.", "Invalid Option", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
           string apiurl = Program.WebServiceUrl + "/" + UPDATE_PLAN_API;
            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
            planner.Recommendation = txtRecomendation.Text;
            planner.UpdatedBy = Program.CurrentUser.Id;
            planner.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
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
                    //MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //this.DialogResult = DialogResult.OK;
                    //this.Close();
                    this.Option = ReportOption.Preview;
                    this.DialogResult = DialogResult.OK;
                }
            }
        }

        private void txtRecomendation_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSendFinancialPlannerReport_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbPlanOption.Text))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Please select option.", "Invalid Option", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.Option = ReportOption.SendMail;
            this.DialogResult = DialogResult.OK;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            frmReportPage = new frmReportPageOption();
            frmReportPage.ShowDialog();
        }

        private void cmbRiskProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            RiskProfiledReturnMaster riskProfiledReturnMaster = _riskProfileMasters.First(i => i.Name.Equals(cmbRiskProfile.Text));
            if (riskProfiledReturnMaster != null)
                cmbRiskProfile.Tag = riskProfiledReturnMaster.Id;
            else
            {
                cmbRiskProfile.Tag = 0;
            }
        }
    }

    public enum ReportOption
    {
        Preview,
        SendMail
    }
}
