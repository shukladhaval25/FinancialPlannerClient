using FinancialPlanner.Common.Model;
using FinancialPlannerClient.TaskManagementSystem.TransactionOptions.Helper;

namespace FinancialPlannerClient.PlanOptions.Reports.Investment_Recommendation
{
    public partial class InvestmentDetails : DevExpress.XtraReports.UI.XtraReport
    {
        Client client;
        Planner planner;
        public InvestmentDetails(Client client, Planner planner)
        {
            InitializeComponent();
            this.client = client;
            this.planner = planner;
            getAssetAllocationData();
        }

        private void getAssetAllocationData()
        {
            InvestmentRecommedationRatioHelper investmentRecommedationRatioHelper = new InvestmentRecommedationRatioHelper();
            InvestmentRecommendationRatio investmentRecommendationRatio = new InvestmentRecommendationRatio();
            investmentRecommendationRatio = investmentRecommedationRatioHelper.Get(this.planner.ID);
            xrChartAssetAllocation.Series[0].Points[0].Values = new double[] { investmentRecommendationRatio.EquityRatio };
            xrChartAssetAllocation.Series[0].Points[1].Values = new double[] { investmentRecommendationRatio.DebtRatio };
        }

        private void InvestmentDetails_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            InvBreackup invBreackup = new InvBreackup(this.client, this.planner);
            this.subReportInvBreackup.ReportSource = invBreackup;

            SchemeCategoryWiseBreackup schemeCategoryWiseBreackup = new SchemeCategoryWiseBreackup(this.client, this.planner);
            this.subReportSchemeCategoryWise.ReportSource = schemeCategoryWiseBreackup;

            STPDetails stpDetails = new STPDetails(this.client, this.planner);
            this.subReportSTP.ReportSource = stpDetails;

            ChequeInFavourOffDetails chequeInFavourOffDetails = new ChequeInFavourOffDetails(this.client, this.planner);
            this.subReportCheque.ReportSource = chequeInFavourOffDetails;
            //ChequeDetailsReport chequeDetailsReport = new ChequeDetailsReport(this.client, this.planner);
            //this.subReportCheque.ReportSource = chequeDetailsReport;
        }
    }
}
