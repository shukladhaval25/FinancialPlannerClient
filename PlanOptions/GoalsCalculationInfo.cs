using FinancialPlanner.Common;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.CashFlowManager;
using FinancialPlannerClient.CurrentStatus;
using FinancialPlannerClient.GoalCalculations;
using FinancialPlannerClient.PlannerInfo;
using FinancialPlannerClient.RiskProfile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FinancialPlannerClient.PlanOptions
{
    internal class GoalsCalculationInfo
    {
        Goals _goal = new Goals();
        int _plannerId;
        Planner _planner;
        int _calculationYear;
        CurrentStatusToGoal _csGoal = new CurrentStatusToGoal();
        GoalsInfo _goalsInfo = new GoalsInfo();
        DataTable _dtGoalValue = new DataTable();
        DataTable _dtGoalCalculation = new DataTable();
        DataTable _dtRiskProfileDet = new DataTable();
        DataTable _dtCurrentStaus = new DataTable();
        DataTable _dtcurrentStatusToGoal = new DataTable();
        IEnumerable<NonFinancialAsset> _nonFinancialAssets;
        IList<InvestmentInGoal> _investmentInGoal;
        private int _riskprofileId;
        private decimal _growthPercentage;
        private Planner planner;
        private RiskProfileInfo _riskProfileInfo;
        public GoalCalculationManager GoalCalManager;
        private  GoalsValueCalculationInfo _goalsValueCal;
        private int _optionId;
        double mappedCurrentStatusValue = 0;
        public CashFlowService CashFlowService { get; set; }
        #region "Constructor"
        public GoalsCalculationInfo(Goals goal, Planner planner, 
            RiskProfileInfo riskProfileInfo, int riskProfileId,int optionId)
        {
            this._goal = goal;
            this.planner = planner;
            this._plannerId = planner.ID;
            this._riskProfileInfo = riskProfileInfo;
            _riskprofileId = riskProfileId;
            this._optionId = optionId;
        }
        #endregion

        internal DataTable GetGoalValue(int goalId, int plannerId, int RiskProfileID,int planOptionId)
        {
            _goal = _goalsInfo.GetById(goalId, plannerId);
            var plannerInfo = new PlannerInfo.PlannerInfo();
            _planner = plannerInfo.GetPlanDataById(plannerId);
            _goalsValueCal = GoalCalManager.GetGoalValueCalculation(_goal);

            setGoalValueTable(_goalsValueCal);
            return _dtGoalValue;
        }

        private void setGoalValueTable(GoalsValueCalculationInfo goalsValueCal)
        {
            createTableStructure();
            if (goalsValueCal != null)
                addRowforGoalValue(goalsValueCal);
        }

        private void addRowforGoalValue(GoalsValueCalculationInfo goalsValueCal)
        {
            DataRow dr = _dtGoalValue.NewRow();
            if (_planner != null)
            {
                dr["Year"] = _planner.StartDate.Year;
                dr["Goal"] = _goal.Name;
                dr["CurrentValue"] = goalsValueCal.CurrentValueOfGoal;
                dr["GoalYear"] = int.Parse(_goal.StartYear);
                dr["Inflation"] = _goal.InflationRate;
                dr["YearLeft"] = getYears(_goal.StartYear);
                dr["FirstYearExpenseOnRetirementYear"] = goalsValueCal.FirstYearExpenseOnRetirementYear;
                dr["GoalValue"] = goalsValueCal.FutureValueOfGoal;
                if (_goal.LoanForGoal != null)
                {
                    dr["Loan Amount"] = _goal.LoanForGoal.LoanAmount;
                    dr["Loan Years"] = _goal.LoanForGoal.LoanYears;
                    dr["Loan ROI"] = _goal.LoanForGoal.ROI;
                    dr["Loan EMI"] = _goal.LoanForGoal.EMI;
                    dr["Start Year"] = _goal.LoanForGoal.StratYear;
                    dr["Loan End Year"] = _goal.LoanForGoal.EndYear;
                }
                _dtGoalValue.Rows.Add(dr);
            }
        }

        internal DataTable GetGoalCalculation()
        {           
            setGoalCalculationTable();
            return _dtGoalCalculation;
        }

        #region "Code which require to refactor"

        #region "Goal Value"
      
        private void createTableStructure()
        {
            if (_dtGoalValue != null)
            {
                _dtGoalValue.Clear();
                _dtGoalValue.Columns.Clear();
            }
            DataColumn dcYear = new DataColumn("Year",typeof(System.Int16));
            _dtGoalValue.Columns.Add(dcYear);

            DataColumn dcGoalName = new DataColumn("Goal",typeof(System.String));
            _dtGoalValue.Columns.Add(dcGoalName);

            DataColumn dcCurrentValue = new DataColumn("CurrentValue",typeof(System.Double));
            _dtGoalValue.Columns.Add(dcCurrentValue);

           

            DataColumn dcGoalYear = new DataColumn("GoalYear",typeof(System.Int16));
            _dtGoalValue.Columns.Add(dcGoalYear);

            DataColumn dcInflation = new DataColumn("Inflation",typeof(System.Decimal));
            _dtGoalValue.Columns.Add(dcInflation);

            DataColumn dcYearLeft = new DataColumn("YearLeft",typeof(System.Int16));
            _dtGoalValue.Columns.Add(dcYearLeft);

            DataColumn dcFirstYearExp = new DataColumn("FirstYearExpenseOnRetirementYear", typeof(System.Double));
            _dtGoalValue.Columns.Add(dcFirstYearExp);

            DataColumn dcGoalValue = new DataColumn("GoalValue",typeof(System.Double));
            _dtGoalValue.Columns.Add(dcGoalValue);

            DataColumn dcGoalLoanAmount = new DataColumn("Loan Amount",typeof(System.Double));
            _dtGoalValue.Columns.Add(dcGoalLoanAmount);

            DataColumn dcGoalLoanEMI = new DataColumn("Loan EMI",typeof(System.Double));
            _dtGoalValue.Columns.Add(dcGoalLoanEMI);

            DataColumn dcGoalLoanROI = new DataColumn("Loan ROI",typeof(System.Double));
            _dtGoalValue.Columns.Add(dcGoalLoanROI);

            DataColumn dcGoalLoanYears = new DataColumn("Loan Years",typeof(System.Double));
            _dtGoalValue.Columns.Add(dcGoalLoanYears);

            DataColumn dcGoalLoanStartYear = new DataColumn("Start Year",typeof(System.Double));
            _dtGoalValue.Columns.Add(dcGoalLoanStartYear);

            DataColumn dcGoalLoanEndYear = new DataColumn("Loan End Year",typeof(System.Double));
            _dtGoalValue.Columns.Add(dcGoalLoanEndYear);

        }

        internal double GetGoalFutureValue(Goals goal)
        {
            if (_planner == null)
            {
                var plannerInfo = new PlannerInfo.PlannerInfo();
                _planner = plannerInfo.GetPlanDataById(goal.Pid);
            }
            //FV = PV * (1 + I)T;
            double currentValue = goal.Amount;
            decimal interest_rate = goal.InflationRate / 100;
            int years = getYears(goal.StartYear);
            decimal futureValue =  (decimal) currentValue *
                ((decimal)Math.Pow((double)(1 + interest_rate), (double)years));

            return Math.Round((double)futureValue);
        }

        private int getYears(string startYear)
        {
            if (string.IsNullOrEmpty(startYear))
                return 0;
            else
            {
                if (int.Parse(startYear) > _planner.StartDate.Year)
                {
                    return int.Parse(startYear) - _planner.StartDate.Year;
                }
            }
            return 0;
        }
        #endregion

        #region "Goal Calculation"

        private void setGoalCalculationTable()
        {
            loadRiskProfileReturnDetails();
            setGoalCalculationTableStructure();
            addRowsInGoalCalculation();
        }

        private void loadRiskProfileReturnDetails()
        {
            RiskProfileInfo _defaultRiskProfile = new RiskProfileInfo();
            _dtRiskProfileDet = _defaultRiskProfile.GetRiskProfileReturnById(_riskprofileId);
        }

        private void addRowsInGoalCalculation()
        {
            int goalYear = int.Parse(_goal.StartYear);
            decimal returnRatio = getRiskProfileReturnRatio(goalYear - _planner.StartDate.Year);
           
            GoalsValueCalculationInfo goalsValueCal = GoalCalManager.GetGoalValueCalculation(_goal);
            goalsValueCal.SetPortfolioValue(GetProfileValue());
            addMappedCurrentStatusValue(goalsValueCal);
            for (int currentYear = _planner.StartDate.Year; currentYear <= goalYear; currentYear++)
            {
                GoalPlanning goalPlanning =  goalsValueCal.GetGoalPlanning(currentYear);
                if (goalPlanning == null)
                {
                    goalPlanning = new GoalPlanning(_goal);
                    goalPlanning.Year = currentYear;
                    goalPlanning.GrowthPercentage = _riskProfileInfo.GetRiskProfileReturnRatio(_riskprofileId, goalPlanning.YearLeft);
                    goalPlanning.ActualFreshInvestment = 0;
                    
                }
                DataRow dr = _dtGoalCalculation.NewRow();
                returnRatio = goalPlanning.GrowthPercentage;

                dr["Calculation Year"] = string.Format("{0} - {1}", currentYear, currentYear + 1);

                dr["Year Left"] = goalPlanning.YearLeft;
                dr["Loan Instrument"] = 0;
                double freshInvestment = goalPlanning.ActualFreshInvestment;

                dr["Fresh Investment"] = Math.Round( freshInvestment);
                if (currentYear == goalYear)
                {
                    dr["Assets Mapping"] = goalsValueCal.FutureValueOfMappedNonFinancialAssets;
                    if (_goal.Category.Equals("Retirement", StringComparison.OrdinalIgnoreCase))
                    {
                        dr["Currest Status Fund"] = 
                            Math.Round(CashFlowService.GetCurrentStatusAccessFund(), 2);
                    }
                    
                     dr["Instrument Mapped"] = goalsValueCal.FutureValueOfMappedInstruments;
                   
                }
                dr["Portfolio Value"] =
                     calculatePortfoliioValue(freshInvestment,returnRatio);
                dr["Cash outflow Goal Year"] = (currentYear == goalYear) ? goalsValueCal.FutureValueOfGoal : 0;
                dr["Portfolio Return"] = returnRatio;
                _dtGoalCalculation.Rows.Add(dr);
            }
        }

        private void addMappedCurrentStatusValue(GoalsValueCalculationInfo goalsValueCal)
        {
            
            if (mappedCurrentStatusValue > 0)
            {
                DataRow dr = _dtGoalCalculation.NewRow();
                dr["Calculation Year"] = string.Format("{0} - {1}", _planner.StartDate.Year - 1, _planner.StartDate.Year);
                _dtGoalCalculation.Columns["Year"].AutoIncrementSeed = _planner.StartDate.Year - 1;
                dr["Portfolio Value"] = mappedCurrentStatusValue;

                int currentYear = _planner.StartDate.Year;
                GoalPlanning goalPlanning = goalsValueCal.GetGoalPlanning(currentYear);
                if (goalPlanning == null)
                {
                    goalPlanning = new GoalPlanning(_goal);
                    goalPlanning.Year = currentYear;
                    goalPlanning.GrowthPercentage = _riskProfileInfo.GetRiskProfileReturnRatio(_riskprofileId, goalPlanning.YearLeft);
                    goalPlanning.ActualFreshInvestment = 0;
                }
                decimal returnRatio = goalPlanning.GrowthPercentage;
                dr["Portfolio Return"] = returnRatio;
                _dtGoalCalculation.Rows.Add(dr);
            }

        }

        private double calculatePortfoliioValue(double freshInv, decimal returnRatio)
        {
            double portfolioValue = 0;
            if (_dtGoalCalculation.Rows.Count > 0)
            {
                portfolioValue = double.Parse(_dtGoalCalculation.Rows[_dtGoalCalculation.Rows.Count - 1]["Portfolio Value"].ToString());
                portfolioValue = portfolioValue + freshInv + ((portfolioValue * (double)returnRatio) / 100);
                double goalFutureValue = GetGoalFutureValue(_goal);                
            }
            else
            {
                portfolioValue = GetProfileValue();
                portfolioValue = portfolioValue + freshInv + ((portfolioValue * (double)returnRatio) / 100);
            }
            return System.Math.Round(portfolioValue);
        }

        private decimal getRiskProfileReturnRatio(int yearRemaining)
        {
          
            DataRow[] drs = _dtRiskProfileDet.Select(string.Format("RiskProfileId ='{0}' and YearRemaining = '{1}'", _riskprofileId, yearRemaining));
            if (drs != null)
            {
                foreach (var dr in drs)
                {
                    return decimal.Parse(dr["AverageInvestemetReturn"].ToString());
                }
            }
            return 0;
        }

        internal double GetProfileValue()
        {
            IList<FinancialPlanner.Common.Model.PlanOptions.CurrentStatusToGoal> currentStatusToGoals
                = new CurrentStatusInfo().GetCurrentStatusToGoal(_optionId,this.planner.ID);
            _dtcurrentStatusToGoal = ListtoDataTable.ToDataTable(currentStatusToGoals.ToList());

            DataRow[] dr =  _dtcurrentStatusToGoal.Select(string.Format("GoalName = '{0}'", _goal.Name));
            if (dr != null && dr.Count() > 0)
            {
                return (string.IsNullOrEmpty(dr[0]["FundAllocation"].ToString())) ?
                    0  : double.Parse(dr[0]["FundAllocation"].ToString());
            }
            return 0;
        }

        private void setGoalCalculationTableStructure()
        {
            mappedCurrentStatusValue =  GetProfileValue();
            _dtGoalCalculation.Clear();
            _dtGoalCalculation.Columns.Clear();
            DataColumn dcSrNo = new DataColumn("SrNo",typeof(System.Int16));
            dcSrNo.AutoIncrement = true;
            dcSrNo.AutoIncrementSeed = 1;
            dcSrNo.AutoIncrementStep = 1;
            _dtGoalCalculation.Columns.Add(dcSrNo);


            DataColumn dcDisplayYear = new DataColumn("Calculation Year", typeof(System.String));
            _dtGoalCalculation.Columns.Add(dcDisplayYear);

            DataColumn dcYear = new DataColumn("Year",typeof(System.Int16));
            dcYear.AutoIncrement = true;
            dcYear.AutoIncrementSeed = (mappedCurrentStatusValue == 0) ? _planner.StartDate.Year : _planner.StartDate.Year - 1;
            dcYear.AutoIncrementStep = 1;
            _dtGoalCalculation.Columns.Add(dcYear);

            DataColumn dcYearLeft = new DataColumn("Year Left",typeof(System.Int16));
            _dtGoalCalculation.Columns.Add(dcYearLeft);

            DataColumn dcLoanIns = new DataColumn("Loan Instrument",typeof(System.Double));
            _dtGoalCalculation.Columns.Add(dcLoanIns);

            DataColumn dcFreshInv = new DataColumn("Fresh Investment",typeof(System.Double));
            _dtGoalCalculation.Columns.Add(dcFreshInv);

            DataColumn dcPortfilioValue = new DataColumn("Portfolio Value",typeof(System.Double));
            _dtGoalCalculation.Columns.Add(dcPortfilioValue);

            DataColumn dcCashFlowGoalYear = new DataColumn("Cash outflow Goal Year",typeof(System.Double));
            _dtGoalCalculation.Columns.Add(dcCashFlowGoalYear);

            DataColumn dcAssetsMapping = new DataColumn("Assets Mapping",typeof(System.Double));
            _dtGoalCalculation.Columns.Add(dcAssetsMapping);

            DataColumn dcInstrumentMapped = new DataColumn("Instrument Mapped",typeof(System.Double));
            _dtGoalCalculation.Columns.Add(dcInstrumentMapped);

            if (_goal.Category.Equals("Retirement",StringComparison.OrdinalIgnoreCase))
            {
                DataColumn dcCurrentStatusFund= new DataColumn("Currest Status Fund", typeof(System.Double));
                _dtGoalCalculation.Columns.Add(dcCurrentStatusFund);
            }

            DataColumn dcPortfolioReturn = new DataColumn("Portfolio Return",typeof(System.Decimal));
            _dtGoalCalculation.Columns.Add(dcPortfolioReturn);

        }

        internal double ReCalculatePortFolioValue(double portfilioValue,
            double freshInvestment, double assetsMapping,
            double instrumentMapped, decimal returnRatio)
        {
            double reCalValue =  portfilioValue + freshInvestment + assetsMapping +
                instrumentMapped + ((portfilioValue * (double)returnRatio) / 100);
            return reCalValue;
        }

        internal void SetGoalProfilevalue(double v)
        {
            if (_dtCurrentStaus == null || _dtCurrentStaus.Columns.Count == 0)
                _dtCurrentStaus = _csGoal.CurrentStatusToGoalCalculation(_plannerId);

            if (_dtCurrentStaus != null)
            {
                DataRow[] dr =  _dtCurrentStaus.Select(string.Format("Goal = '{0}'", _goal.Name));
                if (dr != null && dr.Count() > 0)
                {
                    dr[0]["CurrentStatusMappedAmount"] = v;
                }
            }
        }

        #endregion

        #endregion
    }
}
