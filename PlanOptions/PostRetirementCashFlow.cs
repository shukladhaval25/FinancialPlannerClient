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
        public PostRetirementCashFlow(PersonalInformation personalInformation, Planner planner)
        {
            InitializeComponent();
            postRetirementCashFlowService = new PostRetirementCashFlowService(personalInformation,planner);
            cashFlowCalculation = postRetirementCashFlowService.GetCashFlowCalculationData();
            displayClientAndSpouseInfo();
            fillPostRetirementCashFlowData();
        }
        private void displayClientAndSpouseInfo()
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
        }
       
        private void fillPostRetirementCashFlowData()
        {
            grdSplitCashFlow.DataSource = postRetirementCashFlowService.GetPostRetirementCashFlowData();
        }
    }
}
