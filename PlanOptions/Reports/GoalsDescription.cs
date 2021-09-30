using DevExpress.XtraReports.UI;
using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.PlanOptions;
using FinancialPlannerClient.CashFlowManager;
using FinancialPlannerClient.RiskProfile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
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
        private DataTable _dtGoalProjectionComplition;
        double equityRation, debtRatio = 0;

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
                lblPresentValue.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblPresentValue.Text).ToString("N0", PlannerMainReport.Info);
                if (this.goal.Category.Equals("Vehicale", StringComparison.OrdinalIgnoreCase))
                {

                }
            }
        }

        private void lblGoalFutureValue_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblGoalFutureValue.Text))
            {
                lblGoalFutureValue.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblGoalFutureValue.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void lblMappedAssets_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblMappedAssets.Text))
            {
                if (lblMappedAssets.Text == "0" || lblMappedAssets.Text == "NIL")
                {
                    lblMappedAssets.Text = "NIL";
                }
                else
                {
                    lblMappedAssets.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblMappedAssets.Text).ToString("N0", PlannerMainReport.Info);
                }
            }
        }

        private void lblLoanAmt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (lblLoanAmt.Text == "0" || lblLoanAmt.Text == "NIL")
            {
                lblLoanAmt.Text = "NIL";
                return;
            }

            if (!string.IsNullOrEmpty(lblLoanAmt.Text) && !lblLoanAmt.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                lblLoanAmt.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblLoanAmt.Text).ToString("N0", PlannerMainReport.Info);
            }
            else if (!string.IsNullOrEmpty(lblLoanAmt.Text) && string.IsNullOrEmpty((PlannerMainReport.planner.CurrencySymbol)))
            {
                lblLoanAmt.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblLoanAmt.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void lblCurrentSurplus_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (lblCurrentSurplus.Text == "0" || lblCurrentSurplus.Text == "NIL")
            {
                lblCurrentSurplus.Text = "NIL";
                return;
            }

            if (!string.IsNullOrEmpty(lblCurrentSurplus.Text) && !lblCurrentSurplus.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                lblCurrentSurplus.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblCurrentSurplus.Text).ToString("N0", PlannerMainReport.Info);
            }
            else if (!string.IsNullOrEmpty(lblCurrentSurplus.Text) && string.IsNullOrEmpty((PlannerMainReport.planner.CurrencySymbol)))
            {
                lblCurrentSurplus.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblCurrentSurplus.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        internal void SetReportParameter(Client client, Planner planner, DataTable dtGoals, int riskProfileId, int optionId, List<Goals> goals, DataTable dtGoalProjectionComplition)
        {
            this.lblClientName.Text = client.Name;
            this._dtGoals = dtGoals;
            this.planner = planner;
            this.riskProfileId = riskProfileId;
            this.optionId = optionId;
            this.client = client;
            this.goal = goals.Find(i => i.Name == _dtGoals.Rows[0]["Name"].ToString());
            this._dtGoalProjectionComplition = dtGoalProjectionComplition;
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
            lblGoalFutureValueSum.DataBindings.Add("Text", this.DataSource, "Goals.FutureValue");
            if (this.goal.Category.Equals("Retirement"))
            {
                lblRetirementCorpus.Visible = true;
                lblRetirementCorpusValue.Visible = true;
                lblRetirementCorpusSum.Visible = true;
                PostRetirementCashFlowService postRetirementCashFlowService;
                CashFlowService cashFlowService = new CashFlowService();
                cashFlowService.GenerateCashFlow(client.ID, planner.ID, riskProfileId);
                postRetirementCashFlowService = new PostRetirementCashFlowService(planner, cashFlowService);
                postRetirementCashFlowService.GetPostRetirementCashFlowData();
                postRetirementCashFlowService.calculateEstimatedRequireCorpusFund();
                double totalEstimatedRetirementCorpusFund = Math.Round(postRetirementCashFlowService.GetProposeEstimatedCorpusFund(), 2);
                lblRetirementCorpusValue.Text = totalEstimatedRetirementCorpusFund.ToString();
                lblRetirementCorpusSum.Text = totalEstimatedRetirementCorpusFund.ToString();
                //lblRetirementCorpus.DataBindings.Add("Text", this.DataSource, G)
            }
            if (_dtGoals.Rows.Count == 1)
            {
                xrTableTotal.Visible = false;
            }

            RiskProfileInfo riskprofileInfo = new RiskProfileInfo();

            RiskProfiledReturn riskProfiledReturn = riskprofileInfo.GetResikProfile(this.riskProfileId,
                    (int.Parse(this.goal.StartYear) - this.planner.StartDate.Year));
            double returnRate = double.Parse(riskProfiledReturn.AverageInvestemetReturn.ToString());

            lblTaxReturn.Text = string.Format(lblTaxReturn.Text, returnRate.ToString(), this.planner.StartDate.Year.ToString());
            equityRation = double.Parse(riskProfiledReturn.EquityInvestementRatio.ToString());
            debtRatio = double.Parse(riskProfiledReturn.DebtInvestementRatio.ToString());
            lblNote.Text = this.goal.Description;
            setImageForGoal(goal);
            goalCalculation(goal);
            setChart();

            setGoalProjectionComplitionNote();
            setCurrentStatusFundAllocationValue();
            setFreshInvestmentInGoal();
        }

        private void setFreshInvestmentInGoal()
        {
            DataRow[] drs = _dtcashFlow.Select("StartYear ='" + this.planner.StartDate.Year + "'");
            double value = 0;
            double totalValue = 0;
            if (drs.Count() > 0)
            {
                for (int rowcount = 0; rowcount < _dtGoals.Rows.Count; rowcount++)
                {
                    for (int colCount = 0; colCount < _dtcashFlow.Columns.Count; colCount++)
                    {
                        if (_dtcashFlow.Columns[colCount].ToString().Contains(_dtGoals.Rows[rowcount]["Name"].ToString()))
                        {
                            double.TryParse(drs[0][colCount].ToString(), out value);
                            totalValue = totalValue + value;
                        }
                    }
                }
            }
            lblCurrentSurplus.Text = PlannerMainReport.planner.CurrencySymbol + totalValue.ToString("N0", PlannerMainReport.Info);
        }

        private void setCurrentStatusFundAllocationValue()
        {
            //IList<FinancialPlanner.Common.Model.PlanOptions.CurrentStatusToGoal> _currentStatusToGoal = new CurrentStatusInfo().GetCurrentStatusToGoal(this.optionId, this.planner.ID);
            //if (_currentStatusToGoal != null)
            //{
            //    DataTable _dtGoalMapped = ListtoDataTable.ToDataTable(_currentStatusToGoal.ToList());
            //    DataRow[] drs = _dtGoalMapped.Select("GoalName = '" + goal.Name + "'");
            //    if (drs.Length > 0)
            //    {
            //        lblMappedAssets.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(drs[0]["FundAllocation"].ToString()).ToString("N0", PlannerMainReport.Info);
            //    }
            //}
            string goalName = (goal.Name.Length > 4) ? goal.Name.Substring(0, goal.Name.Length - 4) : goal.Name;
            DataRow[] drs = _dtGoalProjectionComplition.Select("Name like '" + goalName.Trim() + "%'");
            if (drs.Length > 0)
            {
                if (drs[0]["GoalAchivedTillDate"] != DBNull.Value)
                {
                    lblMappedAssets.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(drs[0]["GoalAchivedTillDate"].ToString()).ToString("N0", PlannerMainReport.Info);
                }
            }
        }

        private void setGoalProjectionComplitionNote()
        {
            string goalName = (goal.Name.Length > 4) ? goal.Name.Substring(0, goal.Name.Length - 4) : goal.Name;
            DataRow[] drs = _dtGoalProjectionComplition.Select("Name like '" + goalName.Trim() + "%'");
            if (drs.Length > 0)
            {
                if (drs[0]["ProjectionCompleted"] != DBNull.Value)
                {
                    double projectionCompltion = 0;
                    double.TryParse(drs[0]["ProjectionCompleted"].ToString(), out projectionCompltion);
                    if (projectionCompltion == 0)
                    {
                        lblNote.Text = "Note: We are not able to complete this goal due to insufficient resources.";
                    }
                    else if (lblNote.Text.Length == 0)
                    {
                        lblNote.Text = "";
                    }
                }
            }
            else if (lblNote.Text.Length == 0)
            {
                lblNote.Text = "";
            }
        }

        private void setChart()
        {
            //throw new NotImplementedException();
            xrChartAssetAllocation.Series[0].Points[0].Values = new double[] { equityRation };
            xrChartAssetAllocation.Series[0].Points[1].Values = new double[] { debtRatio };
        }

        private void lblGoalInflation_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblGoalInflation.Text = lblGoalInflation.Text + " %";
        }

        private void lblRetirementCorpusSum_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblRetirementCorpusSum.Text) && !lblRetirementCorpusSum.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                lblRetirementCorpusSum.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblRetirementCorpusSum.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void lblRetirementCorpusValue_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblRetirementCorpusValue.Text) && !lblRetirementCorpusValue.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                lblRetirementCorpusValue.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblRetirementCorpusValue.Text).ToString("N0", PlannerMainReport.Info);
            }
            else if (!string.IsNullOrEmpty(lblRetirementCorpusValue.Text) && string.IsNullOrEmpty(PlannerMainReport.planner.CurrencySymbol))
            {
                lblRetirementCorpusValue.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblRetirementCorpusValue.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void lblEquity_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblEquity.Text = equityRation + " %";
        }

        private void lblPresentValueSum_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblPresentValueSum.Text) && !lblPresentValueSum.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                lblPresentValueSum.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblPresentValueSum.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void lblGoalFutureValueSum_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblGoalFutureValueSum.Text) && !lblGoalFutureValueSum.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                lblGoalFutureValueSum.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblGoalFutureValueSum.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //xrPanelDetail.HeightF = this.Detail.HeightF - 50;
        }

        private void GoalsDescription_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            XRCrossBandBox cbBox = new XRCrossBandBox() { BorderWidth =1,BorderColor = Color.Black };
            cbBox.StartBand = this.TopMargin;
            cbBox.EndBand = this.BottomMargin;
            cbBox.StartPointF = new PointF(0, 0);
            cbBox.EndPointF = new PointF(0, this.BottomMargin.HeightF);
            cbBox.WidthF = this.PageWidth - 75;
            this.CrossBandControls.Add(cbBox);
        }

        private void lblDebt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblDebt.Text = debtRatio + " %";
        }
    }
}
