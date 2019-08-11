using DevExpress.Utils;
using DevExpress.XtraEditors;
using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.PlanOptions;
using FinancialPlannerClient.CashFlowManager;
using System;
using System.Data;
using System.Diagnostics;
using System.Reflection;

namespace FinancialPlannerClient.PlanOptions
{
    public partial class PostRetirementCashFlow : DevExpress.XtraEditors.XtraForm
    {
        PostRetirementCashFlowService postRetirementCashFlowService;
        CashFlowCalculation cashFlowCalculation;
        public PostRetirementCashFlow(Planner planner,CashFlowService cashFlowService)
        {
            try
            {

                InitializeComponent();
                postRetirementCashFlowService = new PostRetirementCashFlowService(planner, cashFlowService);
                cashFlowCalculation = postRetirementCashFlowService.GetCashFlowCalculationData();
                displayClientAndSpouseInfo(cashFlowService);
                postRetirementCashFlowService.SetCorpusFund(double.Parse(lblCorpFundAmt.Text));
            }
            catch(Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                XtraMessageBox.Show("Error:" + ex.ToString(), "Error");
            }
        }
        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
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

            lblCashSurplusAmt.Text = Math.Round(cashFlowService.GetCashFlowSurplusAmount(), 2).ToString("##,###.00"); ;
            lblCurrentStatusAmt.Text = Math.Round(cashFlowService.GetCurrentStatusAccessFund(), 2).ToString("##,###.00"); ;
            double cashSurplusAmt = 0;
            if (double.TryParse(lblCashSurplusAmt.Text, out cashSurplusAmt))
                lblCorpFundAmt.Text = (cashSurplusAmt + (string.IsNullOrEmpty(lblCurrentStatusAmt.Text) ? 0 :
                   double.Parse(lblCurrentStatusAmt.Text))).ToString("##,###.00"); ;
        }
       
        private void fillPostRetirementCashFlowData()
        {
            grdSplitCashFlow.DataSource = postRetirementCashFlowService.GetPostRetirementCashFlowData();
            gridSplitContainerViewCashFlow.Columns["StartYear"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gridSplitContainerViewCashFlow.Columns["EstimatedRequireCorpusFund"].DisplayFormat.FormatString = "##,###.##";
        }


        private void PostRetirementCashFlow_Load(object sender, EventArgs e)
        {
            try
            {
                fillPostRetirementCashFlowData();
                lblEstimatedCorpusFundValue.Text = postRetirementCashFlowService.GetProposeEstimatedCorpusFund().ToString("##,###.00");
                lblEstimatedCorpusFundValue.Refresh();
                setGoalCompletionPercentage();
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                XtraMessageBox.Show("Error:" + ex.ToString(), "Error");
            }
        }

        private void setGoalCompletionPercentage()
        {
            double totalAvailableCorpFund = 0;
            double estitmatedCorpFund = 0;
            double.TryParse(lblCorpFundAmt.Text, out totalAvailableCorpFund);
            double.TryParse(lblEstimatedCorpusFundValue.Text, out estitmatedCorpFund);
            if (totalAvailableCorpFund >= estitmatedCorpFund)
                progressBarRetGoalCompletion.Text = "100";
            else
                progressBarRetGoalCompletion.Text = Math.Round(((100 * totalAvailableCorpFund) / estitmatedCorpFund)).ToString();

        }
    }
}
