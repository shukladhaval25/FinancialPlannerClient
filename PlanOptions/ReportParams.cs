using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinancialPlannerClient.PlanOptions
{
    public partial class ReportParams : DevExpress.XtraEditors.XtraForm
    {
        DataTable _dtOption = new DataTable();
        int planId;
        int optionId;
        int riskProfileId;
        public ReportParams(int planId)
        {
            InitializeComponent();
            this.planId = planId;
            txtRecomendation.Text = "* We recommended maintaining Rs.6 lakhs as contingency fund." + System.Environment.NewLine + System.Environment.NewLine + "* Your annual Investment considering your income and expenses will be RS. 7.60 Lakhs for next 1 Year.";
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
            _dtOption = new PlanOptionInfo().GetAll(this.planId);
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
            this.DialogResult = DialogResult.OK;
        }

        private void txtRecomendation_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
