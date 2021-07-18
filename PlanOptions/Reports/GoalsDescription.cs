using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.PlanOptions;
using FinancialPlannerClient.CashFlowManager;
using FinancialPlannerClient.RiskProfile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection;

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
        private DataTable _dtGoals;

        public GoalsDescription()
        {
            InitializeComponent();
        }
        public void SetReportParameter(Client client, Planner planner, Goals goal, int riskProfileId, int optionId)
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
            lblPresentValue.Text = (this.goal.Amount + this.goal.OtherAmount).ToString();
            lblGoalYear.Text = this.goal.StartYear.ToString();
            lblGoalInflation.Text = this.goal.InflationRate.ToString();
            lblGoalFutureValue.Text = futureValue(this.goal.Amount, this.goal.InflationRate, (int.Parse(this.goal.StartYear) - this.planner.StartDate.Year)).ToString();

            RiskProfileInfo riskprofileInfo = new RiskProfileInfo();
            double returnRate = (double)riskprofileInfo.GetRiskProfileReturnRatio(this.riskProfileId,
                    (int.Parse(this.goal.StartYear) - this.planner.StartDate.Year));
            lblTaxReturn.Text = string.Format(lblTaxReturn.Text, returnRate.ToString(), this.planner.StartDate.Year.ToString());
            lblNote.Text = this.goal.Description;
            setImageForGoal(goal);
            goalCalculation(goal);
        }

        private void setImageForGoal(Goals goal)
        {
            if (goal.Category == "Education")
                xrPicGoal.Image = Properties.Resources.EducationGoal1;
            else if (goal.Category.Equals("Vehicale", StringComparison.OrdinalIgnoreCase))
            {
                setImageForVehicaleGoal(goal);
            }
            else if (goal.Category == "Marriage")
                xrPicGoal.Image = Properties.Resources.MarriageGoal;
            else if (goal.Category == "Retirement")
                xrPicGoal.Image = Properties.Resources.RetirementGoal;
            else if (goal.Category == "Asset")
                xrPicGoal.Image = Properties.Resources.HomeGoal1;
            else if (goal.Category == "Others")
                xrPicGoal.Image = Properties.Resources.OthersGoal;
            else if (goal.Category.Equals("Vacation", StringComparison.OrdinalIgnoreCase))
                xrPicGoal.Image = Properties.Resources.HolidayGoal;
            else if (goal.Category.Equals("Medical", StringComparison.OrdinalIgnoreCase))
                xrPicGoal.Image = Properties.Resources.HospitalGoal;

        }

        private void setImageForVehicaleGoal(Goals goal)
        {
            if (goal.Amount >= 1000000)
                xrPicGoal.Image = Properties.Resources.CardGoalAbove10Lakh;
            else if (goal.Amount >= 500000 && goal.Amount < 1000000)
                xrPicGoal.Image = Properties.Resources.CarGoalBetween5To10Lakh;
            else if (goal.Amount < 500000)
                xrPicGoal.Image = Properties.Resources.CarGoalupto5Lakh;
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

        private void lblPresentValue_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblPresentValue.Text))
            {
                lblPresentValue.Text = String.Format("{0:#,###}", double.Parse(lblPresentValue.Text));
                if (this.goal.Category.Equals("Vehicale", StringComparison.OrdinalIgnoreCase))
                {

                }
            }
        }

        private void lblGoalFutureValue_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblGoalFutureValue.Text))
            {
                lblGoalFutureValue.Text = String.Format("{0:#,###}", double.Parse(lblGoalFutureValue.Text));
            }
        }

        private void lblMappedAssets_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblMappedAssets.Text))
            {
                lblMappedAssets.Text = String.Format("{0:#,###}", double.Parse(lblMappedAssets.Text));
            }
        }

        private void lblLoanAmt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblLoanAmt.Text))
            {
                lblLoanAmt.Text = String.Format("{0:#,###}", double.Parse(lblLoanAmt.Text));
            }
        }

        private void lblCurrentSurplus_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblCurrentSurplus.Text))
            {
                lblCurrentSurplus.Text = String.Format("{0:#,###}", double.Parse(lblCurrentSurplus.Text));
            }
        }

        internal void SetReportParameter(Client client, Planner planner, DataTable dtGoals, int riskProfileId, int optionId, List<Goals> goals)
        {
            this.lblClientName.Text = client.Name;
            this._dtGoals = dtGoals;
            this.planner = planner;
            this.riskProfileId = riskProfileId;
            this.optionId = optionId;
            this.client = client;
            this.goal = goals.Find(i => i.Name == _dtGoals.Rows[0]["Name"].ToString());
            bindFields();
        }

        private void bindFields()
        {
            this.DataSource = _dtGoals;
            this.DataMember = _dtGoals.TableName;

            lblGoalName.DataBindings.Add("Text", this.DataSource, "Goals.Name");
            lblGoalSetYear.Text = this.planner.StartDate.Year.ToString();
            lblNameOfGoal.DataBindings.Add("Text", this.DataSource, "Goals.Name");
            lblPresentValue.DataBindings.Add("Text", this.DataSource, "Goals.Amount");
            lblPresentValueSum.DataBindings.Add("Text", this.DataSource, "Goals.Amount");
            lblGoalYear.DataBindings.Add("Text", this.DataSource, "Goals.StartYear");
            lblGoalInflation.DataBindings.Add("Text", this.DataSource, "Goals.InflationRate");
            lblGoalFutureValue.DataBindings.Add("Text", this.DataSource, "Goals.FutureValue");
            //lblRetirementCorpus.DataBindings.Add("Text",this.DataSource,G)

            RiskProfileInfo riskprofileInfo = new RiskProfileInfo();
            //this.goal = new Goals()
            //{
            //    Id = int.Parse(_dtGoals.Rows[0]["Id"].ToString()),
            //    Amount = double.Parse(_dtGoals.Rows[0]["Amount"].ToString()),
            //    Category = _dtGoals.Rows[0]["Category"].ToString(),
            //    EndYear = _dtGoals.Rows[0]["EndYear"].ToString(),
            //    StartYear = _dtGoals.Rows[0]["StartYear"].ToString(),
            //    InflationRate = decimal.Parse(_dtGoals.Rows[0]["InflationRate"].ToString()),
            //    Priority = int.Parse(_dtGoals.Rows[0]["Priority"].ToString())
            //};
            double returnRate = (double)riskprofileInfo.GetRiskProfileReturnRatio(this.riskProfileId,
                    (int.Parse(this.goal.StartYear) - this.planner.StartDate.Year));
            lblTaxReturn.Text = string.Format(lblTaxReturn.Text, returnRate.ToString(), this.planner.StartDate.Year.ToString());
            setImageForGoal(goal);
            goalCalculation(goal);
        }

        private void lblGoalInflation_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblGoalInflation.Text = lblGoalInflation.Text + " %";
        }
    }
}
