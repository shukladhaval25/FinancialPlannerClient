using System;
using FinancialPlannerClient.CurrentStatus;
using FinancialPlanner.Common.Model;
using System.Collections.Generic;

namespace FinancialPlannerClient.PlanOptions.Reports.Insurance
{
    public partial class LICPolicyMaturity : DevExpress.XtraReports.UI.XtraReport
    {
        DateTime fromDate;
        DateTime toDate;
        public LICPolicyMaturity(DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            this.fromDate = fromDate;
            this.toDate = toDate;
            xrLabelTitle.Text = string.Format(xrLabelTitle.Text, fromDate.ToShortDateString(), toDate.ToShortDateString());
            loadReport();
        }
        private void loadReport()
        {
            LifeInsuranceInfo lifeInsuranceInfo = new LifeInsuranceInfo();
            IList<LicPremiumReminder> licPremiumReminders = lifeInsuranceInfo.GetLicPolicyMaturity(fromDate, toDate);
            this.DataSource = licPremiumReminders;
            this.lblApplicant.DataBindings.Add("Text", this.DataSource, "Applicant");
            this.lblClient.DataBindings.Add("Text", this.DataSource, "ClientName");
            this.lblInsCompany.DataBindings.Add("Text", this.DataSource, "Company");
            this.lblPolicyName.DataBindings.Add("Text", this.DataSource, "PolicyName");
            this.lblPolicyNumber.DataBindings.Add("Text", this.DataSource, "PolicyNo");
            this.lblMaturityDate.DataBindings.Add("Text", this.DataSource, "PremiumDate");
            this.lblPremiumAmount.DataBindings.Add("Text", this.DataSource, "PremiumAmount");
        }

        private void lblPremiumAmount_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblPremiumAmount.Text))
            {
                lblPremiumAmount.Text = double.Parse(lblPremiumAmount.Text).ToString("N0", PlannerMainReport.Info);
            }
        }
    }
}
