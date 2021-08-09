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

        private void ReportParams_Load(object sender, EventArgs e)
        {
            fillOptionData();
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
    }

    public enum ReportOption
    {
        Preview,
        SendMail
    }
}
