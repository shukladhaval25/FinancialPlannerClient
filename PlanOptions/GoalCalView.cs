﻿using DevExpress.XtraEditors;
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

            foreach (var goal in this.goals)
            {
                cmbGoals.Properties.Items.Add(goal.Name);
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
                method(goal);
            }
            else
                cmbGoals.Tag = 0;
        }
        private void method(Goals goal)
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

                _dtGoalProfile = _goalCalculationInfo.GetGoalValue(int.Parse(cmbGoals.Tag.ToString()),
                planner.ID, _riskProfileId);
                if (_dtGoalProfile != null && _dtGoalProfile.Rows.Count > 0)
                {
                    lblGoalPeriodValue.Text = _dtGoalProfile.Rows[0]["GoalYear"].ToString();
                    lblPortfolioValue.Text = _goalCalculationInfo.GetProfileValue().ToString();

                    setGoalProfileGrid();
                    _dtGoalValue = _goalCalculationInfo.GetGoalCalculation();
                    dtGridGoalValue.DataSource = _dtGoalValue;
                    int goalComplitionPercentage = getGoalComplitionPercentage();
                    progGoalComplition.EditValue = (goalComplitionPercentage > 100) ? 100 : goalComplitionPercentage;
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

        private void setGoalProfileGrid()
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
                return int.Parse(Math.Round((portfolioValue + assetsMappingValue + instrumentValue + loanAmountValue) * 100 / cashOutFlowValue).ToString());
            }
            return 0;
        }

        internal void setCashFlowService(CashFlowService cashFlowService)
        {
            this.cashFlowService = cashFlowService;
        }
    }
}