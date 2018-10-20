using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.GoalCalculations;
using FinancialPlannerClient.PlannerInfo;
using FinancialPlannerClient.RiskProfile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        IEnumerable<NonFinancialAsset> _nonFinancialAssets;
        IList<InvestmentInGoal> _investmentInGoal;
        private int _riskprofileId;
        private decimal _growthPercentage;
        private Goals goal;
        private Planner planner;
        private RiskProfileInfo _riskProfileInfo;
        GoalCalculationManager goalCalManager;

        #region "Constructor"
        internal GoalsCalculationInfo()
        {

        }
        //internal GoalsCalculationInfo(int goalId, int plannerId, int riskProfileId,int yearForCalculation)
        //{
        //    _plannerId = plannerId;
        //    _riskprofileId = riskProfileId;
        //    _calculationYear = yearForCalculation;
        //    _goal = _goalsInfo.GetById(goalId, plannerId);
        //    _nonFinancialAssets = new NonFinancialAssetInfo().GetByMappedGoalID(goalId, plannerId);
        //    var plannerInfo = new PlannerInfo.PlannerInfo();
        //    _planner = plannerInfo.GetPlanDataById(plannerId);
        //    _dtCurrentStaus = _csGoal.CurrentStatusToGoalCalculation(plannerId);
        //    loadRiskProfileReturnDetails();
        //}

        //public GoalsCalculationInfo(Goals goal, Planner _planner, decimal growthPercentage, int yearForCalculation)
        //{
        //    this._goal = goal;
        //    this._planner = _planner;
        //    this._plannerId = _planner.ID;
        //    this._growthPercentage = growthPercentage;
        //    this._calculationYear = yearForCalculation;
        //}

        public GoalsCalculationInfo(Goals goal, Planner planner, RiskProfileInfo _riskProfileInfo, int _riskProfileId)
        {
            this.goal = goal;
            this.planner = planner;
            this._riskProfileInfo = _riskProfileInfo;
            _riskprofileId = _riskProfileId;
        }
        #endregion

        internal DataTable GetGoalValue(int goalId, int plannerId, int RiskProfileID)
        {
            //_plannerId = plannerId;
            //_riskprofileId = RiskProfileID;
            _goal = _goalsInfo.GetById(goalId, plannerId);
            var plannerInfo = new PlannerInfo.PlannerInfo();
            _planner = plannerInfo.GetPlanDataById(plannerId);
            goalCalManager  = new GoalCalculationManager(_planner, _riskProfileInfo, _riskprofileId);
            GoalsValueCalculationInfo goalsValueCal =  goalCalManager.GetGoalValueCalculation(_goal);
            goalsValueCal.GetGoalPlanning();
            //setGoalValueTable();
            setGoalValueTable(goalsValueCal);
            return _dtGoalValue;
        }

        private void setGoalValueTable(GoalsValueCalculationInfo goalsValueCal)
        {
            createTableStructure();
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
        private void setGoalValueTable()
        {
            createTableStructure();
            addRowforGoalValue();
        }

        private void addRowforGoalValue()
        {
            DataRow dr = _dtGoalValue.NewRow();
            if (_planner != null)
            {
                dr["Year"] = _planner.StartDate.Year;
                dr["Goal"] = _goal.Name;
                dr["CurrentValue"] = _goal.Amount;
                dr["GoalYear"] = int.Parse(_goal.StartYear);
                dr["Inflation"] = _goal.InflationRate;
                dr["YearLeft"] = getYears(_goal.StartYear);
                dr["GoalValue"] = GetFutureGoalValue();
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

        internal double GetFutureValue()
        {
            if (_planner == null)
            {
                var plannerInfo = new PlannerInfo.PlannerInfo();
                _planner = plannerInfo.GetPlanDataById(_plannerId);
            }
            //FV = PV * (1 + I)T;
            double currentValue = _goal.Amount;
            decimal interest_rate = _goal.InflationRate / 100;
            int years = getYears(_goal.StartYear);
            decimal futureValue =  (decimal) currentValue *
                ((decimal)Math.Pow((double)(1 + interest_rate), (double)years));

            return Math.Round((double)futureValue);
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
            double totalValueForInstrumentMapped = getFutureValueOfMappedInstrument();
            double totalNonFinancialAssetMappedValue = getFutureValueOfMappedNonFinancialAsset();

            decimal returnRatio = getRiskProfileReturnRatio(goalYear - _planner.StartDate.Year);
            double presentRequireValueForInvestment =
                    presentValue(getTotalFundRequireToAchiveGoal(),returnRatio,goalYear - _planner.StartDate.Year);

            GoalsValueCalculationInfo goalValCalInfo = goalCalManager.GetGoalValueCalculation(_goal);
            
            for (int currentYear = _planner.StartDate.Year; currentYear <= goalYear; currentYear++)
            {
                DataRow dr = _dtGoalCalculation.NewRow();
                returnRatio = getRiskProfileReturnRatio(goalYear - currentYear);
                dr["Year Left"] = goalYear - currentYear;
                dr["Loan Instrument"] = 0;
                double freshInvestment = getInvestmentVale(currentYear,_goal.Id);

                dr["Fresh Investment"] = (freshInvestment > presentRequireValueForInvestment) ?
                    presentRequireValueForInvestment : freshInvestment;
                dr["Assets Mapping"] = 0;
                dr["Instrument Mapped"] = 0;
                dr["Portfolio Value"] =
                     calculatePortfoliioValue(freshInvestment, totalNonFinancialAssetMappedValue, totalValueForInstrumentMapped, returnRatio);
                dr["Cash outflow Goal Year"] = (currentYear == goalYear) ? GetFutureGoalValue() : 0;
                dr["Portfolio Return"] = returnRatio;
                _dtGoalCalculation.Rows.Add(dr);
            }
        }

        
        private double calculatePortfoliioValue(double freshInv, double assetsMapping, double instrumentMapped, decimal returnRatio)
        {
            double portfolioValue = 0;
            if (_dtGoalCalculation.Rows.Count > 0)
            {
                portfolioValue = double.Parse(_dtGoalCalculation.Rows[_dtGoalCalculation.Rows.Count - 1]["Portfolio Value"].ToString());
                portfolioValue = portfolioValue + freshInv + assetsMapping + instrumentMapped + ((portfolioValue * (double)returnRatio) / 100);
                //double freshInvestment = double.Parse(_dtGoalCalculation.Rows[_dtGoalCalculation.Rows.Count -1]["Fresh Investment"].ToString());
                //double assetsMapping = double.Parse(_dtGoalCalculation.Rows[_dtGoalCalculation.Rows.Count -1]["Assets Mapping"].ToString());
                //double instrumentMapped = double.Parse(_dtGoalCalculation.Rows[_dtGoalCalculation.Rows.Count -1]["Instrument Mapped"].ToString());
                //double portfolioReturnRatio = double.Parse(_dtGoalCalculation.Rows[_dtGoalCalculation.Rows.Count -1]["Portfolio Return"].ToString());                
                double goalFutureValue = GetGoalFutureValue(_goal);
                if (portfolioValue > goalFutureValue)
                {
                    double excessInvestsmentValue =  portfolioValue - goalFutureValue;
                    //return freshInv - excessInvestsmentValue;
                    return portfolioValue - excessInvestsmentValue;
                }
            }
            else
            {
                portfolioValue = GetProfileValue();
                portfolioValue = portfolioValue + freshInv + assetsMapping + instrumentMapped + ((portfolioValue * (double)returnRatio) / 100);
            }
            return System.Math.Round(portfolioValue);
        }

        private decimal getRiskProfileReturnRatio(int yearRemaining)
        {

            //var drs =  from row in _dtRiskProfileDet.AsEnumerable()
            //           where row.Field<int>("RiskProfileId") ==  _riskprofileId
            //             && row.Field<int>("YearRemaining") == yearRemaining
            //           select row.Field<decimal>("AverageInvestementReturn");

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
            if (_dtCurrentStaus == null || _dtCurrentStaus.Columns.Count == 0)
                _dtCurrentStaus = _csGoal.CurrentStatusToGoalCalculation(_plannerId);

            DataRow[] dr =  _dtCurrentStaus.Select(string.Format("Goal = '{0}'", _goal.Name));
            if (dr != null && dr.Count() > 0)
            {
                return double.Parse(dr[0]["CurrentStatusMappedAmount"].ToString());
            }
            return 0;
        }

        private void setGoalCalculationTableStructure()
        {
            _dtGoalCalculation.Clear();
            _dtGoalCalculation.Columns.Clear();
            DataColumn dcSrNo = new DataColumn("SrNo",typeof(System.Int16));
            dcSrNo.AutoIncrement = true;
            dcSrNo.AutoIncrementSeed = 1;
            dcSrNo.AutoIncrementStep = 1;
            _dtGoalCalculation.Columns.Add(dcSrNo);

            DataColumn dcYear = new DataColumn("Year",typeof(System.Int16));
            dcYear.AutoIncrement = true;
            dcYear.AutoIncrementSeed = _planner.StartDate.Year;
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

        #endregion

        #endregion

        #region "Refactor Code"

        internal void SetInvestmentInGoal(IList<InvestmentInGoal> goalInvestments)
        {
            _investmentInGoal = goalInvestments;
        }


        internal bool IsFundRequireToAchiveGoal()
        {
            double goalValue = GetFutureGoalValue();
            double futureValueOfMappedInstrument = getFutureValueOfMappedInstrument();
            double futureValueOfMappedNonFinanacialAsset = getFutureValueOfMappedNonFinancialAsset();
            double totalPortfolioValue = getTotalInvestmentValue();
            return (goalValue > (futureValueOfMappedInstrument +
                futureValueOfMappedNonFinanacialAsset + totalPortfolioValue));
        }


        internal double getTotalInvestmentValue()
        {
            if (_investmentInGoal != null)
                return _investmentInGoal.Select(x => x.InvestmentAmount).Sum();
            return 0;
        }

        internal double GetFutureGoalValue()
        {
            if (_planner == null)
            {
                var plannerInfo = new PlannerInfo.PlannerInfo();
                _planner = plannerInfo.GetPlanDataById(_goal.Pid);
            }
            double currentValue = _goal.Amount;
            decimal interest_rate = _goal.InflationRate;
            int years = getYears(_goal.StartYear);
            return FutureValue(currentValue, interest_rate, years);
        }

        internal decimal GetAverageGrowthRateFromRiskProfile(int remainingYearForGoal)
        {
            try
            {
                if (_dtRiskProfileDet != null)
                {
                    DataRow[] drs = _dtRiskProfileDet.Select(string.Format("RiskProfileId ='{0}' and YearRemaining = '{1}'", _riskprofileId, remainingYearForGoal));
                    if (drs != null)
                    {
                        foreach (var dr in drs)
                        {
                            return decimal.Parse(dr["AverageInvestemetReturn"].ToString());
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogDebug(ex.ToString());
            }
            return 0;
        }

        private static double FutureValue(double presentValue, decimal interest_rate, int timePeriodInYears)
        {
            //FV = PV * (1 + I)T;
            interest_rate = interest_rate / 100;
            decimal futureValue =  (decimal) presentValue *
                ((decimal)Math.Pow((double)(1 + interest_rate), (double)timePeriodInYears));

            return Math.Round((double)futureValue);
        }
        private double getFutureValueOfMappedInstrument()
        {
            if (_dtCurrentStaus == null || _dtCurrentStaus.Columns.Count == 0)
                _dtCurrentStaus = _csGoal.CurrentStatusToGoalCalculation(_plannerId);

            if (_dtCurrentStaus != null)
            {
                DataRow[] dr =  _dtCurrentStaus.Select(string.Format("Goal = '{0}'", _goal.Name));
                if (dr != null &&  dr.Count() > 0)
                {
                    double presentValueOfInstumentMapped = double.Parse(dr[0]["CurrentStatusMappedAmount"].ToString());
                   
                    int timePeriod = int.Parse(_goal.StartYear) - _planner.StartDate.Year;
                    decimal interestRate = GetAverageGrowthRateFromRiskProfile(timePeriod);
                    double futureValueofMappedInstument =
                        FutureValue(presentValueOfInstumentMapped,interestRate,timePeriod);
                    return futureValueofMappedInstument;
                }
            }
            return 0;
        }
        private double getFutureValueOfMappedNonFinancialAsset()
        {
            double sumOfNonFinancialAsset = 0;

            _nonFinancialAssets = new NonFinancialAssetInfo().GetByMappedGoalID(_goal.Id, _plannerId);

            if (_nonFinancialAssets != null)
            {
                foreach (NonFinancialAsset nfa in _nonFinancialAssets)
                {
                    double primaryHolderShare = (nfa.CurrentValue * nfa.PrimaryholderShare) / 100;
                    double secondaryHolderShare = (nfa.CurrentValue * nfa.SecondaryHolderShare) /100;
                    double assetsMappingShare = ((primaryHolderShare + secondaryHolderShare) * nfa.AssetMappingShare) /100;

                    decimal interestRate = GetAverageGrowthRateFromRiskProfile(_calculationYear);
                    int timePeriod = int.Parse(_goal.StartYear) - _planner.StartDate.Year;

                    sumOfNonFinancialAsset = sumOfNonFinancialAsset +
                         FutureValue(assetsMappingShare, interestRate, timePeriod);
                }
            }
            return sumOfNonFinancialAsset;
        }

        private double getInvestmentVale(int currentYear,int goalId)
        {
            double investmentAmount = 0;
            if (_investmentInGoal != null && _investmentInGoal.Count > 0 )
            {
                InvestmentInGoal investmentInGoal = _investmentInGoal.FirstOrDefault(i => i.InvestmentYear == currentYear && i.GoalId == goalId);
                if (investmentInGoal != null)
                    investmentAmount = investmentInGoal.InvestmentAmount;
            }
            return investmentAmount;
        }

        private double getTotalFundRequireToAchiveGoal()
        {
            double goalFutureValue = GetFutureGoalValue();
            double totalValueOfInstrumentMapped = getFutureValueOfMappedInstrument();
            double totalValueOfMappedNonFinancialAsset = getFutureValueOfMappedNonFinancialAsset();
            return goalFutureValue - (totalValueOfInstrumentMapped + totalValueOfMappedNonFinancialAsset);
        }
       
        private static double presentValue(double futureValue, decimal interest_rate, int timePeriodInYears)
        {
            //PV = FV / (1 + I)T;
            interest_rate = interest_rate / 100;
            decimal presentValue =  (decimal) futureValue /
                ((decimal)Math.Pow((double)(1 + interest_rate), (double)timePeriodInYears));

            return Math.Round((double)presentValue);
        }
        #endregion
    }
}
