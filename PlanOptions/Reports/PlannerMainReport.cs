using System;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.PlanOptions.Reports;


namespace FinancialPlannerClient.PlanOptions
{
    public partial class PlannerMainReport : DevExpress.XtraReports.UI.XtraReport
    {
        Client client;
        Planner planner;
       
        public PlannerMainReport(Client client, Planner planner)
        {
            InitializeComponent();
            this.client = client;
            this.planner = planner;
            this.lblClientName.Text = this.client.Name;
            this.lblPreparedFor.Text = this.client.Name;
            this.lblPreparedOn.Text = this.planner.StartDate.ToShortDateString();
        }

        private void Detail_AfterPrint(object sender, EventArgs e)
        {
           
            //this.lblPreparedBy.Text = this.planner.p
        }

        private void PlannerMainReport_AfterPrint(object sender, EventArgs e)
        {
            TableOfContent tableOfContent = new TableOfContent(client);
            tableOfContent.CreateDocument();

            // Enable this property to maintain continuous page numbering 
            PrintingSystem.ContinuousPageNumbering = true;

            // Add all pages of the 2nd report to the end of the 1st report. 
            
            this.Pages.Add(tableOfContent.Pages[0]);

        }
    }
}
