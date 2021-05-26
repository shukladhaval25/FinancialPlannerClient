using DevExpress.Utils;
using DevExpress.XtraEditors;
using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.PlanOptions;
using FinancialPlannerClient.CashFlowManager;
using FinancialPlannerClient.PlannerInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialPlannerClient.PlanOptions
{
    public partial class PostRetirementCashFlow : DevExpress.XtraEditors.XtraForm
    {
        PostRetirementCashFlowService postRetirementCashFlowService;
        CashFlowCalculation cashFlowCalculation;
        double assetsMappingValue = 0;
        public PostRetirementCashFlow(Planner planner,CashFlowService cashFlowService)
        {
            try
            {

                InitializeComponent();
                postRetirementCashFlowService = new PostRetirementCashFlowService(planner, cashFlowService);
                cashFlowCalculation = postRetirementCashFlowService.GetCashFlowCalculationData();
                displayClientAndSpouseInfo(cashFlowService);
                postRetirementCashFlowService.SetCorpusFund(double.Parse(lblCorpFundAmt.Text));
                IList<Goals> goals = new GoalsInfo().GetAll(planner.ID);
                Goals goal = new Goals();
                if (goals == null)
                {
                    goals = new GoalsInfo().GetAll(planner.ID);
                }

                if (goals != null)
                {
                    foreach (Goals singleGoal in goals)
                    {
                        if (singleGoal.Category.Equals("Retirement", StringComparison.OrdinalIgnoreCase))
                        {
                            goal = singleGoal;
                        }
                    }
                    GoalsValueCalculationInfo goalsValueCalculationInfo = cashFlowService.GoalCalculationMgr.GetGoalValueCalculation(goal);
                    assetsMappingValue = (goalsValueCalculationInfo != null)? goalsValueCalculationInfo.FutureValueOfMappedNonFinancialAssets:0;
                    lblAssetMapping.Text = assetsMappingValue.ToString("##,###.00");
                }
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

            lblCashSurplusAmt.Text = Math.Round(cashFlowService.GetCashFlowSurplusAmount(), 2).ToString("##,###.00");

            lblCurrentStatusAmt.Text = Math.Round(cashFlowService.GetCurrentStatusAccessFund(), 2).ToString("##,###.00");
            double cashSurplusAmt = 0;
            if (double.TryParse(lblCashSurplusAmt.Text, out cashSurplusAmt))
                lblCorpFundAmt.Text = (cashSurplusAmt + (string.IsNullOrEmpty(lblCurrentStatusAmt.Text) ? 0 :
                   double.Parse(lblCurrentStatusAmt.Text))).ToString("##,###.00"); ;
        }
       
        private async void fillPostRetirementCashFlowData()
        {
            grdPostRetirementCashFlow.DataSource = await Task.Run(() => postRetirementCashFlowService.GetPostRetirementCashFlowData());
            picProcessing.Visible = false;
            gridSplitContainerViewCashFlow.Columns["StartYear"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            gridSplitContainerViewCashFlow.Columns["EstimatedRequireCorpusFund"].DisplayFormat.FormatString = "##,###.##";

            lblEstimatedCorpusFundValue.Text = postRetirementCashFlowService.GetProposeEstimatedCorpusFund().ToString("##,###.00");
            lblEstimatedCorpusFundValue.Refresh();
            setGoalCompletionPercentage();
        }


        private void PostRetirementCashFlow_Load(object sender, EventArgs e)
        {
            try
            {
                fillPostRetirementCashFlowData();
                
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
            //if (totalAvailableCorpFund >= estitmatedCorpFund)
            //    progressBarRetGoalCompletion.Text = "100";
            //else
            if (estitmatedCorpFund > 0 && totalAvailableCorpFund != 0)
            {
                
                double goalComplitionPercentage = Math.Round(((100 * (totalAvailableCorpFund + assetsMappingValue)) / estitmatedCorpFund));
                progressBarRetGoalCompletion.Properties.Maximum = (goalComplitionPercentage > 100) ? int.Parse(goalComplitionPercentage.ToString()) : 100;

                progressBarRetGoalCompletion.EditValue = goalComplitionPercentage.ToString();
                progressBarRetGoalCompletion.Text = goalComplitionPercentage.ToString();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = System.IO.Path.GetTempPath() + "/" + "PostRetirementCashFlow" + DateTime.Now.Ticks.ToString() + ".xls";
                grdPostRetirementCashFlow.ExportToXls(filePath);
                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.StackTrace.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                System.Windows.Forms.MessageBox.Show("Exception:" + ex.ToString());
            }
        }

        private void lblCurrentStatusAmt_TextChanged(object sender, EventArgs e)
        {
            setGoalCompletionPercentage();
        }

        private void lblCorpFundAmt_TextChanged(object sender, EventArgs e)
        {
            setGoalCompletionPercentage();
        }

        private void gridSplitContainerViewCashFlow_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {

            if (e.Column.ToString() == "Rem_Corp_Fund")
            {
                double corpusFund = 0;
                double.TryParse(e.CellValue.ToString(), out corpusFund);
                if (corpusFund < 0)
                {
                    e.Appearance.ForeColor = Color.DarkRed;
                }
            }
        }
    }
}
