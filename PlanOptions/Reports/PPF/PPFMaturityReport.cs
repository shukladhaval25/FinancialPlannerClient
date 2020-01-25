using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.CurrentStatus;
using System.Collections.Generic;

namespace FinancialPlannerClient.PlanOptions.Reports.PPF
{
    public partial class PPFMaturityReport : DevExpress.XtraReports.UI.XtraReport
    {
        DateTime fromDate;
        DateTime toDate;
        public PPFMaturityReport(DateTime fromDate, DateTime toDate)
        {
            InitializeComponent();
            this.fromDate = fromDate;
            this.toDate = toDate;
            xrLabelTitle.Text = string.Format(xrLabelTitle.Text, fromDate.ToShortDateString(), toDate.ToShortDateString());
            loadReport();
        }

        private void loadReport()
        {
            PPFInfo ppfInfo = new PPFInfo();
            IList<PPFMaturity> licPremiumReminders = ppfInfo.GetPPFMaturity(fromDate, toDate);
            this.DataSource = licPremiumReminders;
            this.lblApplicant.DataBindings.Add("Text", this.DataSource, "InvesterName");
            this.lblClient.DataBindings.Add("Text", this.DataSource, "ClientName");
            this.lblBank.DataBindings.Add("Text", this.DataSource, "Bank");
            this.lblAccountNo.DataBindings.Add("Text", this.DataSource, "AccountNo");           
            this.lblMaturityDate.DataBindings.Add("Text", this.DataSource, "MaturityDate");  
        }
    }
}
