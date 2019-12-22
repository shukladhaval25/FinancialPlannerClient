using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FinancialPlanner.Common.Model;

namespace FinancialPlannerClient.PlanOptions.Reports.Investment_Recommendation
{
    public partial class investmentRecommendation : DevExpress.XtraReports.UI.XtraReport
    {
        Client client;
        Planner planner;
        public investmentRecommendation(Client client, Planner planner)
        {
            InitializeComponent();
            this.client = client;
            this.planner = planner;
        }

        private void investmentRecommendation_AfterPrint(object sender, EventArgs e)
        {
            InvestmentDetails investmentDetails = new InvestmentDetails(this.client, this.planner);
            investmentDetails.CreateDocument();

            PrintingSystem.ContinuousPageNumbering = true;
            this.Pages.Add(investmentDetails.Pages.First);
        }
    }
}
