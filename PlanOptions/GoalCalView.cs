using DevExpress.XtraEditors;
using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.PlanOptions;
using FinancialPlannerClient.CashFlowManager;
using FinancialPlannerClient.PlannerInfo;
using FinancialPlannerClient.RiskProfile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace FinancialPlannerClient.PlanOptions
{
    public partial class GoalCalView : DevExpress.XtraEditors.XtraForm
    {
        Planner planner;
        private IList<Goals> goals;
        int _riskProfileId;
        int _planOptionId;

        GoalsCalculationInfo _goalCalculationInfo;
        CashFlowService cashFlowService = new CashFlowService();
        private DataTable _dtGoalValue;
        private DataTable _dtGoalProfile;

        public GoalCalView(Planner planner,int riskProfileId,int planOptionId)
        {
            InitializeComponent();
            this.planner = planner;
            this._riskProfileId = riskProfileId;
            this._planOptionId = planOptionId;
        }

        private void GoalCalView_Load(object sender, EventArgs e)
        {
            goals = new GoalsInfo().GetAll(this.planner.ID);
            getGoals();
        }
        private void getGoals()
        {
            cmbGoals.Properties.Items.Clear();
            if (this.goals != null)
            {
                foreach (var goal in this.goals)
                {
                    cmbGoals.Properties.Items.Add(goal.Name);
                }
            }
        }

        private void cmbGoals_SelectedValueChanged(object sender, EventArgs e)
        {
            Goals goal = goals.First(i => i.Name == cmbGoals.Text);
            if (goal != null)
            {
                cmbGoals.Tag = goal.Id;
                lblPriorityNo.Text = goal.Priority.ToString();
                lblGoalPeriodValue.Text = goal.StartYear;
                displayCalculation(goal);
            }
            else
                cmbGoals.Tag = 0;
        }
        public double WithCashFlowAllocationGetGoalComplitionPercentage(Goals goal)
        {
            if (goal != null)
            {
                cmbGoals.Tag = goal.Id;
                lblPriorityNo.Text = goal.Priority.ToString();
                lblGoalPeriodValue.Text = goal.StartYear;
                displayCalculation(goal);
            }
            else
                cmbGoals.Tag = 0;

            return getGoalComplitionPercentage();
        }
        private void displayCalculation(Goals goal)
        {
            try
            {
                RiskProfileInfo _riskProfileInfo = new RiskProfileInfo();
                if (_goalCalculationInfo == null)
                {
                    _goalCalculationInfo =
                        new GoalsCalculationInfo(goal, planner, _riskProfileInfo, _riskProfileId, this._planOptionId);
                    CashFlow cf = cashFlowService.GetCashFlow(this._planOptionId);
                    _goalCalculationInfo.GoalCalManager = cashFlowService.GoalCalculationMgr;
                }
                _goalCalculationInfo.CashFlowService = cashFlowService;
                _dtGoalProfile = _goalCalculationInfo.GetGoalValue(int.Parse(cmbGoals.Tag.ToString()),
                planner.ID, _riskProfileId,_planOptionId);
                if (_dtGoalProfile != null && _dtGoalProfile.Rows.Count > 0)
                {
                    lblGoalPeriodValue.Text = _dtGoalProfile.Rows[0]["GoalYear"].ToString();
                    lblPortfolioValue.Text = _goalCalculationInfo.GetProfileValue().ToString();

                    setGoalProfileGrid(goal);
                    _dtGoalValue = _goalCalculationInfo.GetGoalCalculation();
                    dtGridGoalValue.DataSource = _dtGoalValue;
                    int goalComplitionPercentage = (goal.Category.Equals("Retirement", StringComparison.OrdinalIgnoreCase)) ?
                        getGoalComplitionPercentageWithCurrentStatusAccessFund()
                        : getGoalComplitionPercentage();
                    if (goalComplitionPercentage > 100)
                        progGoalComplition.Properties.Maximum = goalComplitionPercentage;
                    else
                        progGoalComplition.Properties.Maximum = 100;

                    progGoalComplition.EditValue = goalComplitionPercentage;
                    progGoalComplition.Text  = goalComplitionPercentage.ToString();
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

        private int getGoalComplitionPercentageWithCurrentStatusAccessFund()
        {
            if (_dtGoalProfile != null && _dtGoalValue.Rows.Count > 0)
            {
                double portfolioValue = double.Parse(_dtGoalValue.Rows[_dtGoalValue.Rows.Count - 1]["Portfolio value"].ToString());
                double cashOutFlowValue = double.Parse(_dtGoalValue.Rows[_dtGoalValue.Rows.Count - 1]["Cash outflow Goal Year"].ToString());
                double assetsMappingValue = double.Parse(_dtGoalValue.Rows[_dtGoalValue.Rows.Count - 1]["Assets Mapping"].ToString());
                double instrumentValue = double.Parse(_dtGoalValue.Rows[_dtGoalValue.Rows.Count - 1]["Instrument Mapped"].ToString());
                double loanAmountValue = _dtGoalProfile.Rows[0]["Loan Amount"].ToString() == "" ? 0 : double.Parse(_dtGoalProfile.Rows[0]["Loan Amount"].ToString());
                double currentStatusAccessFund = Math.Round(cashFlowService.GetCurrentStatusAccessFund(), 2);
                return int.Parse(Math.Round((portfolioValue + loanAmountValue + currentStatusAccessFund) * 100 / cashOutFlowValue).ToString());
            }
            return 0;
        }

        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }

        private void setGoalProfileGrid(Goals goal)
        {
            grdGoalProfile.DataSource = _dtGoalProfile;
            gridViewGoalProfile.Columns["CurrentValue"].Caption = "Current Value";
            gridViewGoalProfile.Columns["CurrentValue"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            gridViewGoalProfile.Columns["CurrentValue"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridViewGoalProfile.Columns["CurrentValue"].DisplayFormat.FormatString = "#,###.00";

            gridViewGoalProfile.Columns["Inflation"].Caption = "Inflation (%)";
            gridViewGoalProfile.Columns["Inflation"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            gridViewGoalProfile.Columns["Inflation"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.None;
            gridViewGoalProfile.Columns["Inflation"].DisplayFormat.FormatString = "# %";

            gridViewGoalProfile.Columns["GoalValue"].Caption = "Goal Value";
            gridViewGoalProfile.Columns["GoalValue"].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            gridViewGoalProfile.Columns["GoalValue"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            gridViewGoalProfile.Columns["GoalValue"].DisplayFormat.FormatString = "#,###.00";

            if (goal.Category == "Retirement")
            {
                gridViewGoalProfile.Columns["FirstYearExpenseOnRetirementYear"].Visible = true;
                gridViewGoalProfile.Columns["FirstYearExpenseOnRetirementYear"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                gridViewGoalProfile.Columns["FirstYearExpenseOnRetirementYear"].DisplayFormat.FormatString = "#,###.00";
            }
            else
                gridViewGoalProfile.Columns["FirstYearExpenseOnRetirementYear"].Visible = false;
        }

        private int getGoalComplitionPercentage()
        {
            if (_dtGoalProfile != null && _dtGoalValue.Rows.Count > 0)
            {
                double portfolioValue = double.Parse(_dtGoalValue.Rows[_dtGoalValue.Rows.Count - 1]["Portfolio value"].ToString());
                double cashOutFlowValue = double.Parse(_dtGoalValue.Rows[_dtGoalValue.Rows.Count - 1]["Cash outflow Goal Year"].ToString());
                double assetsMappingValue = double.Parse(_dtGoalValue.Rows[_dtGoalValue.Rows.Count - 1]["Assets Mapping"].ToString());
                double instrumentValue = double.Parse(_dtGoalValue.Rows[_dtGoalValue.Rows.Count - 1]["Instrument Mapped"].ToString());
                double loanAmountValue = _dtGoalProfile.Rows[0]["Loan Amount"].ToString() == "" ? 0 : double.Parse(_dtGoalProfile.Rows[0]["Loan Amount"].ToString());
             
                return int.Parse(Math.Round((portfolioValue + loanAmountValue ) * 100 / cashOutFlowValue).ToString());
            }
            return 0;
        }

        internal void setCashFlowService(CashFlowService cashFlowService)
        {
            this.cashFlowService = cashFlowService;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = System.IO.Path.GetTempPath() + "/" + "GoalCalculation" + DateTime.Now.Ticks.ToString() + ".xls";
                gridViewGoalValue.ExportToXls(filePath);
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
    }
}
