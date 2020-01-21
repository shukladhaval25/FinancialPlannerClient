using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FinancialPlannerClient.CurrentStatus;
using FinancialPlanner.Common.Model;
using System.Collections.Generic;

namespace FinancialPlannerClient.PlanOptions.Reports.Insurance
{
    public partial class LicPremiumDueDate : DevExpress.XtraReports.UI.XtraReport
    {
        DateTime fromDate;
        DateTime toDate;
        public LicPremiumDueDate(DateTime fromDate,DateTime toDate)
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
            IList<LicPremiumReminder> licPremiumReminders = lifeInsuranceInfo.GetLicPremiumReminder(fromDate, toDate);
            this.DataSource = licPremiumReminders;
            this.lblApplicant.DataBindings.Add("Text", this.DataSource, "Applicant");
            this.lblClient.DataBindings.Add("Text", this.DataSource, "ClientName");
            this.lblInsCompany.DataBindings.Add("Text", this.DataSource, "Company");
            this.lblPolicyName.DataBindings.Add("Text", this.DataSource, "PolicyName");
            this.lblPolicyNumber.DataBindings.Add("Text", this.DataSource, "PolicyNo");
            this.lblPremiumDate.DataBindings.Add("Text", this.DataSource, "PremiumDate");            
            this.lblPremiumAmount.DataBindings.Add("Text", this.DataSource, "PremiumAmount");
        }
    }
}
