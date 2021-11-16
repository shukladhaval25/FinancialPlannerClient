using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FinancialPlannerClient.CurrentStatus;
using System.Collections.Generic;
using FinancialPlanner.Common.Model;

namespace FinancialPlannerClient.PlanOptions.Reports.Insurance
{
    public partial class GeneralInsurancePremiumReminder : DevExpress.XtraReports.UI.XtraReport
    {
        DateTime fromDate;
        DateTime toDate;
        public GeneralInsurancePremiumReminder(DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            this.fromDate = fromDate;
            this.toDate = toDate;
            xrLabelTitle.Text = string.Format(xrLabelTitle.Text, fromDate.ToShortDateString(), toDate.ToShortDateString());
            loadReport();
        }

        private void loadReport()
        {
            GeneralInsuranceInfo generalInsuranceInfo = new GeneralInsuranceInfo();  
            IList<GeneralInsuranceRenewalReminder> generalInsuranceRenewalReminders = generalInsuranceInfo.GetRenewalReminder(fromDate, toDate);
            this.DataSource = generalInsuranceRenewalReminders;
            this.lblApplicant.DataBindings.Add("Text", this.DataSource, "Applicant");
            this.lblClient.DataBindings.Add("Text", this.DataSource, "ClientName");
            this.lblInsCompany.DataBindings.Add("Text", this.DataSource, "Company");
            this.lblPolicyName.DataBindings.Add("Text", this.DataSource, "PolicyName");
            this.lblPolicyNumber.DataBindings.Add("Text", this.DataSource, "PolicyNo");
            this.lblPremiumDate.DataBindings.Add("Text", this.DataSource, "RenewalDate");
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
