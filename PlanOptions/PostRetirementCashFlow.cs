using DevExpress.Utils;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.PlanOptions;
using FinancialPlannerClient.CashFlowManager;
using System;
using System.Data;

namespace FinancialPlannerClient.PlanOptions
{
    public partial class PostRetirementCashFlow : DevExpress.XtraEditors.XtraForm
    {
        PostRetirementCashFlowService postRetirementCashFlowService;
        CashFlowCalculation cashFlowCalculation;
        public PostRetirementCashFlow(Planner planner,CashFlowService cashFlowService)
        {
            InitializeComponent();
            postRetirementCashFlowService = new PostRetirementCashFlowService(planner,cashFlowService);
            cashFlowCalculation = postRetirementCashFlowService.GetCashFlowCalculationData();
            displayClientAndSpouseInfo(cashFlowService);
            postRetirementCashFlowService.SetCorpusFund(double.Parse(lblCorpFundAmt.Text));
        }
        private void displayClientAndSpouseInfo(CashFlowService cashFlowService)
        {
            lblClient.Text = cashFlowCalculation.ClientName;
            lblClientDOB.Text = cashFlowCalculation.ClientDateOfBirth.ToShortDateString();
            lblClientRetirementAge.Text = string.Format("{0} Years", cashFlowCalculation.ClientRetirementAge.ToString());
            lblClientExpLife.Text = string.Format("{0} Years", cashFlowCalculation.ClientLifeExpected.ToString());
            lblClientCurrentAge.Text  = string.Format("{0} Years", cashFlowCalculation.ClientCurrentAge.ToString());
            

            lblSpouse.Text = cashFlowCalculation.SpouseName;
            lblSpouseDOB.Text = cashFlowCalculation.SpouseDateOfBirth.ToShortDateString();
            lblSpouseRetirementAge.Text = string.Format("{0} Years", cashFlowCalculation.SpouseRetirementAge.ToString());
            lblSpouseLifeExp.Text = string.Format("{0} Years", cashFlowCalculation.SpouseLifeExpected.ToString());
            lblSpouseCurrentAge.Text = string.Format("{0} Years", cashFlowCalculation.SpouseCurrentAge.ToString());

            lblCashSurplusAmt.Text = cashFlowService.GetCashFlowSurplusAmount().ToString("#,###.##");
            double cashSurplusAmt = 0;
            if (double.TryParse(lblCashSurplusAmt.Text,out cashSurplusAmt))
                lblCorpFundAmt.Text = (cashSurplusAmt  + double.Parse(lblCurrentStatusAmt.Text)).ToString("#,###.##");
        }
       
        private void fillPostRetirementCashFlowData()
        {
            grdSplitCashFlow.DataSource = postRetirementCashFlowService.GetPostRetirementCashFlowData();
            gridSplitContainerViewCashFlow.Columns["StartYear"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gridSplitContainerViewCashFlow.Columns["EstimatedRequireCorpusFund"].DisplayFormat.FormatString = "#,###.##";
        }


        private void PostRetirementCashFlow_Load(object sender, EventArgs e)
        {
            fillPostRetirementCashFlowData();
            lblEstimatedCorpusFundValue.Text = postRetirementCashFlowService.GetProposeEstimatedCorpusFund().ToString("##,###.##");
            lblEstimatedCorpusFundValue.Refresh();
        }
    }
}
