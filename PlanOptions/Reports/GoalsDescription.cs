using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.RiskProfile;
using FinancialPlanner.Common.Model.PlanOptions;
using FinancialPlannerClient.CashFlowManager;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using FinancialPlanner.Common;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class GoalsDescription : DevExpress.XtraReports.UI.XtraReport
    {
        Goals goal;
        Client client;
        Planner planner;
        int riskProfileId;
        int optionId;
        private DataTable _dtGoalProfile;
        private DataTable _dtcashFlow;

        public GoalsDescription()
        {
            InitializeComponent();            
        }
        public void SetReportParameter(Client client, Planner planner, Goals goal,int riskProfileId, int optionId)
        {
            this.lblClientName.Text = client.Name;
            this.goal = goal;
            this.planner = planner;
            this.riskProfileId = riskProfileId;
            this.optionId = optionId;
            this.client = client;
            showGoals();
        }

        private void showGoals()
        {
            lblGoalName.Text = this.goal.Name;
            lblGoalSetYear.Text = this.planner.StartDate.Year.ToString();
            lblNameOfGoal.Text = this.goal.Name;
            lblPresentValue.Text = this.goal.Amount.ToString();
            lblGoalYear.Text = this.goal.StartYear.ToString();
            lblGoalInflation.Text = this.goal.InflationRate.ToString();
            lblGoalFutureValue.Text = futureValue(this.goal.Amount, this.goal.InflationRate, (int.Parse( this.goal.StartYear) - this.planner.StartDate.Year)).ToString();

            RiskProfileInfo riskprofileInfo = new RiskProfileInfo();
            double returnRate = (double)riskprofileInfo.GetRiskProfileReturnRatio(this.riskProfileId,
                    (int.Parse(this.goal.StartYear) - this.planner.StartDate.Year));
            lblTaxReturn.Text = string.Format(lblTaxReturn.Text, returnRate.ToString(), this.planner.StartDate.Year.ToString());
            setImageForGoal(goal);
            goalCalculation(goal);
        }

        private void setImageForGoal(Goals goal)
        {
            if (goal.Category == "Education")
                xrPicGoal.Image = Properties.Resources.EducationGoal;
            else if (goal.Category == "Vehicale")
                xrPicGoal.Image = Properties.Resources.Vehicles;
            else if (goal.Category == "Marriage")
                xrPicGoal.Image = Properties.Resources.Marriage;
            else if (goal.Category == "Retirement")
                xrPicGoal.Image = Properties.Resources.Retirement;
        }

        private static double futureValue(double presentValue, decimal interest_rate, int timePeriodInYears)
        {
            //FV = PV * (1 + I)T;
            interest_rate = interest_rate / 100;
            double futureValue = presentValue *
                (Math.Pow((double)(1 + interest_rate), (double)timePeriodInYears));

            return Math.Round(futureValue);
        }

        private void goalCalculation(Goals goal)
        {       
            try
            {
                RiskProfileInfo _riskProfileInfo = new RiskProfileInfo();
                CashFlowService cashFlowService = new CashFlowService();
                GoalsCalculationInfo _goalCalculationInfo = 
                        new GoalsCalculationInfo(goal, planner, _riskProfileInfo, riskProfileId, this.optionId);

                CashFlow cf = cashFlowService.GetCashFlow(optionId);
                _dtcashFlow = cashFlowService.GenerateCashFlow(this.client.ID, this.planner.ID, riskProfileId);
                _goalCalculationInfo.GoalCalManager = cashFlowService.GoalCalculationMgr;
                
                _dtGoalProfile = _goalCalculationInfo.GetGoalValue(goal.Id,
                planner.ID, riskProfileId, optionId);
                if (_dtGoalProfile != null && _dtGoalProfile.Rows.Count > 0)
                {
                    lblLoanAmt.Text = _dtGoalProfile.Rows[0]["Loan Amount"].ToString();
                    DataTable _dtGoalValue = _goalCalculationInfo.GetGoalCalculation();
                    lblMappedAssets.Text = _dtGoalValue.Rows[_dtGoalValue.Rows.Count - 1]["Assets Mapping"].ToString();
                    DataRow[] drs = _dtGoalValue.Select("Year ='" + this.planner.StartDate.Year + "'");
                    lblCurrentSurplus.Text = drs[0]["Fresh Investment"].ToString();
                }
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);                
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
    }
}
