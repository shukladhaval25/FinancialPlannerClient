using FinancialPlanner.Common.Model;
using FinancialPlannerClient.CurrentStatus;
using FinancialPlannerClient.PlannerInfo;
using FinancialPlannerClient.RiskProfile;
using System;
using System.Collections.Generic;

namespace FinancialPlannerClient.PlanOptions
{
    public class GoalsValueCalculationInfo
    {
        Goals _goal;
        Planner _planner;
        int _planStartYear;
        int _riskProfileId;
        decimal growthPercentage;
        CurrentStatusInfo csInfo = new CurrentStatusInfo();
        RiskProfileInfo _riskProfileInfo;
        IList<GoalPlanning> _goalPlannings = new List<GoalPlanning>();
        IList<GoalPlanning> _LIFO_GoalPlannings = new List<GoalPlanning>();

        double _futureValueOfGoal;
        double _currentValueOfGoal;
        double _futureValueOfMappedInstruments;
        double _futureValueOfMappedNonFinancialAssets;
        double _estimatedYearlyFreshInvestment;
        double _portfolioValue;
        double _currentPortfolioValue;

        public double FutureValueOfGoal
        {
            get
            {
                return _futureValueOfGoal;
            }
        }

        public double CurrentValueOfGoal
        {
            get
            {
                return _currentValueOfGoal;
            }
        }

        public double FutureValueOfMappedInstruments
        {
            get
            {
                return _futureValueOfMappedInstruments;
            }
        }

        public double FutureValueOfMappedNonFinancialAssets
        {
            get
            {
                return _futureValueOfMappedNonFinancialAssets;
            }
        }

        public double GetCurrentPortfolioValue()
        {
            double totalCashInvestmentUptoNow = 0;
            double currentPortFoliovalue = _portfolioValue;
            for (int currentYear = _planner.StartDate.Year; currentYear <= int.Parse(_goal.StartYear); currentYear++)
            {
                GoalPlanning goalPlanning = GetGoalPlanning(currentYear);
                //GoalPlanning previousYearGoalPlanning = GetGoalPlanning(currentYear-1);
                GoalPlanning lifoGoalPlanningObj = GetLIFOGoalPlanning(currentYear);
                if (goalPlanning != null)
                {
                    //currentPortFoliovalue = currentPortFoliovalue + goalPlanning.ActualFreshInvestment;
                    double interestRate = (lifoGoalPlanningObj.GrowthPercentage != null) ?
                        (double) lifoGoalPlanningObj.GrowthPercentage : 0;

                    currentPortFoliovalue = currentPortFoliovalue +
                        ((currentPortFoliovalue * interestRate) / 100) +
                        goalPlanning.ActualFreshInvestment;
                }
                else
                {
                    double interestRate = (lifoGoalPlanningObj.GrowthPercentage != null) ?
                        (double) lifoGoalPlanningObj.GrowthPercentage : 0;

                    currentPortFoliovalue = currentPortFoliovalue +
                         ((currentPortFoliovalue * interestRate) / 100);
                    if (_goalPlannings.Count > 0  && (currentYear > _goalPlannings[0].Year))
                            break;                    
                }                    
            }
            _currentPortfolioValue = currentPortFoliovalue;
            return _currentPortfolioValue;
        }

        public GoalsValueCalculationInfo(Goals goal, Planner planner, RiskProfileInfo riskProfileInfo, int riskprorfileId)
        {
            _goal = goal;
            _planner = planner;
            _planStartYear = _planner.StartDate.Year;
            _riskProfileInfo = riskProfileInfo;
            _riskProfileId = riskprorfileId;
            growthPercentage = _riskProfileInfo.GetRiskProfileReturnRatio(_riskProfileId, getRemainingYearsFromPlanStartYear());
            _futureValueOfGoal = getGoalFutureValue();
            _currentValueOfGoal = getGoalCurrentValue();
            _futureValueOfMappedInstruments = getTotalMappedInstrumentValue();
            _futureValueOfMappedNonFinancialAssets = getFutureValueOfMappedNonFinancialAsset();
            setLIFOPlanning();
        }

        public void SetPortfolioValue(double portFolioValue)
        {
            _portfolioValue = portFolioValue;
        }

        private void setLIFOPlanning()
        {
            double futureInvestmentRequireValueForGoal = _futureValueOfGoal - (_futureValueOfMappedInstruments +
                _futureValueOfMappedNonFinancialAssets + getLoanAmount());
            double investmentAmount = futureInvestmentRequireValueForGoal;
            for (int calculationYear = int.Parse(_goal.StartYear); calculationYear >= _planner.StartDate.Year;
                calculationYear--)
            {
                GoalPlanning goalPlanning = new GoalPlanning(_goal);
                goalPlanning.Year = calculationYear;
                goalPlanning.GoalFutureValue = futureInvestmentRequireValueForGoal;
                goalPlanning.ActualFreshInvestment = (investmentAmount * 100) / (100 + (double)GetGrowthPercentage(goalPlanning.Year));
                goalPlanning.GoalId = _goal.Id;
                goalPlanning.GrowthPercentage = GetGrowthPercentage(goalPlanning.Year);
                _LIFO_GoalPlannings.Add(goalPlanning);
                investmentAmount = goalPlanning.ActualFreshInvestment;
            }
        }

        public Goals Goal()
        {
            return _goal;
        }

        public GoalPlanning GetGoalPlanning(int calculationYear)
        {
            if (_goalPlannings != null)
            {
                foreach (GoalPlanning goalplanning in _goalPlannings)
                {
                    if (goalplanning.Year == calculationYear)
                        return goalplanning;
                }
            }
            return null;
        }

        public GoalPlanning GetLIFOGoalPlanning(int calculationYear)
        {
            if (_LIFO_GoalPlannings != null)
            {
                foreach (GoalPlanning goalplanning in _LIFO_GoalPlannings)
                {
                    if (goalplanning.Year == calculationYear)
                        return goalplanning;
                }
            }
            return null;
        }

        public double SetInvestmentToAchiveGoal(int investmentYear, double investmentAmount)
        {
            double futureInvestmentRequireValueForGoal = _futureValueOfGoal - (_futureValueOfMappedInstruments +
                _futureValueOfMappedNonFinancialAssets + getLoanAmount());

            GoalPlanning lifoGoalPlanningObj = GetLIFOGoalPlanning(investmentYear + 1);
            double currentProfileValue = GetCurrentPortfolioValue();
            if (Math.Round(currentProfileValue) == Math.Round(lifoGoalPlanningObj.ActualFreshInvestment))
            {
                GoalPlanning goalPlanning = new GoalPlanning(_goal);
                goalPlanning.GoalId = _goal.Id;
                goalPlanning.Year = investmentYear;
                goalPlanning.GoalFutureValue = _futureValueOfGoal;
                goalPlanning.ActualFreshInvestment = 0;
                goalPlanning.GrowthPercentage = GetGrowthPercentage(investmentYear);

                AddGoalPlanning(goalPlanning);
                return investmentAmount - goalPlanning.ActualFreshInvestment;                
            }

            double profileValue = (currentProfileValue + investmentAmount);
                //+ ((currentProfileValue + investmentAmount) * (double)GetGrowthPercentage(investmentYear)) / 100;

            if (profileValue < lifoGoalPlanningObj.ActualFreshInvestment)
            {                               
                GoalPlanning goalPlanning = new GoalPlanning(_goal);
                goalPlanning.GoalId = _goal.Id;
                goalPlanning.Year = investmentYear;
                goalPlanning.GoalFutureValue = _futureValueOfGoal;
                goalPlanning.ActualFreshInvestment = investmentAmount;
                goalPlanning.GrowthPercentage = GetGrowthPercentage(investmentYear);

                AddGoalPlanning(goalPlanning);
                return investmentAmount - goalPlanning.ActualFreshInvestment;
            }
            else
            {

                double currentInvestmentRequire = (lifoGoalPlanningObj.ActualFreshInvestment - currentProfileValue);
                if (System.Math.Round(currentInvestmentRequire) > 0 && ((currentProfileValue + currentInvestmentRequire) <= lifoGoalPlanningObj.ActualFreshInvestment))
                {
                    GoalPlanning goalPlanning = new GoalPlanning(_goal);
                    goalPlanning.GoalId = _goal.Id;
                    goalPlanning.Year = investmentYear;
                    goalPlanning.GoalFutureValue = _futureValueOfGoal;
                    goalPlanning.ActualFreshInvestment = currentInvestmentRequire;
                    goalPlanning.GrowthPercentage = GetGrowthPercentage(investmentYear);

                    AddGoalPlanning(goalPlanning);
                    return investmentAmount - goalPlanning.ActualFreshInvestment;
                }
                else
                {
                    GoalPlanning goalPlanning = new GoalPlanning(_goal);
                    goalPlanning.GoalId = _goal.Id;
                    goalPlanning.Year = investmentYear;
                    goalPlanning.GoalFutureValue = _futureValueOfGoal;
                    goalPlanning.ActualFreshInvestment = 0;
                    goalPlanning.GrowthPercentage = GetGrowthPercentage(investmentYear);

                    AddGoalPlanning(goalPlanning);
                    return investmentAmount - goalPlanning.ActualFreshInvestment;
                }
            }
            //double investmentReturnValueOnGoalYear = getInvestmentReturnValueAtGoalYear(investmentYear, investmentAmount);
            //if (futureInvestmentRequireValueForGoal >= investmentReturnValueOnGoalYear)
            //{
            //    GoalPlanning goalPlanning = new GoalPlanning(_goal);
            //    goalPlanning.GoalId = _goal.Id;
            //    goalPlanning.Year = investmentYear;
            //    goalPlanning.GoalFutureValue = _futureValueOfGoal;
            //    goalPlanning.ActualFreshInvestment = investmentAmount;
            //    goalPlanning.GrowthPercentage = GetGrowthPercentage(investmentYear - 1);
            //    AddGoalPlanning(goalPlanning);
            //    return investmentAmount - goalPlanning.ActualFreshInvestment;
            //}
            //else   // Case: Investment Amount return will cross goal future value and over access fund get allocated.
            //{
            //    GoalPlanning lifoGoalPlanningObj = GetLIFOGoalPlanning(investmentYear + 1);
            //    double currentProfileValue = GetCurrentPortfolioValue();

            //    double estimatedDiffAmount = (lifoGoalPlanningObj.ActualFreshInvestment  - currentProfileValue);

            //    estimatedDiffAmount = estimatedDiffAmount +
            //        ((estimatedDiffAmount * (double)GetGrowthPercentage(investmentYear)) / 100);

            //    if (estimatedDiffAmount < investmentAmount)
            //    {
            //        GoalPlanning goalPlanning = new GoalPlanning(_goal);
            //        goalPlanning.GoalId = _goal.Id;
            //        goalPlanning.Year = investmentYear;
            //        goalPlanning.GoalFutureValue = _futureValueOfGoal;
            //        goalPlanning.ActualFreshInvestment = (estimatedDiffAmount > 0) ? estimatedDiffAmount : 0;
            //        goalPlanning.GrowthPercentage = GetGrowthPercentage(investmentYear -1);

            //        AddGoalPlanning(goalPlanning);
            //        return investmentAmount - goalPlanning.ActualFreshInvestment;
            //    }
            //    else
            //    {
            //        GoalPlanning goalPlanning = new GoalPlanning(_goal);
            //        goalPlanning.GoalId = _goal.Id;
            //        goalPlanning.Year = investmentYear;
            //        goalPlanning.GoalFutureValue = _futureValueOfGoal;
            //        goalPlanning.ActualFreshInvestment = investmentAmount;
            //        goalPlanning.GrowthPercentage = GetGrowthPercentage(investmentYear - 1);

            //        AddGoalPlanning(goalPlanning);
            //        return investmentAmount - investmentAmount;
            //    }
            //}

        }

        public void AddGoalPlanning(GoalPlanning goalPlanning)
        {
            if (goalPlanning != null)
                _goalPlannings.Add(goalPlanning);
        }

        public decimal GetGrowthPercentage(int calculationYear)
        {
            return _riskProfileInfo.GetRiskProfileReturnRatio(_riskProfileId, getRemainingYearBy(calculationYear));
        }

        private double getInvestmentReturnValueAtGoalYear(int investmentYear, double investmentAmount)
        {
            double currentPortFoliovalue = GetCurrentPortfolioValue() + investmentAmount;
            for (int currentYear = investmentYear + 1; currentYear < int.Parse(_goal.StartYear); currentYear++)
            {
                double interestRate = (currentYear == _planStartYear) ? 0 : (double)GetGrowthPercentage(currentYear - 1);
                currentPortFoliovalue = currentPortFoliovalue +
                    ((currentPortFoliovalue * interestRate / 100));
            }
            return currentPortFoliovalue;
        }

        private double getLoanAmount()
        {
            if (_goal.LoanForGoal == null)
                return 0;
            return _goal.LoanForGoal.LoanAmount;
        }

        private double getGoalCurrentValue()
        {
            if (_goal != null)
                return _goal.Amount;

            return 0;
        }

        private double getGoalFutureValue()
        {
            double futureValueOfGoal = 0;
            if (_goal != null)
            {
                int years = getRemainingYearsFromPlanStartYear();
                futureValueOfGoal = futureValue(_goal.Amount, _goal.InflationRate, years);
            }
            return futureValueOfGoal;
        }

        private double getTotalMappedInstrumentValue()
        {
            double instumentMappedCurrentValue =  csInfo.GetFundFromCurrentStatus(_planner.ID, _goal.Id);

            return futureValue(instumentMappedCurrentValue, 10, getRemainingYearsFromPlanStartYear());
        }

        private double getFutureValueOfMappedNonFinancialAsset()
        {
            double sumOfNonFinancialAsset = 0;

            var _nonFinancialAssets = new NonFinancialAssetInfo().GetByMappedGoalID(_goal.Id, _planner.ID);

            if (_nonFinancialAssets != null)
            {
                foreach (NonFinancialAsset nfa in _nonFinancialAssets)
                {
                    double primaryHolderShare = (nfa.CurrentValue * nfa.PrimaryholderShare) / 100;
                    double secondaryHolderShare = (nfa.CurrentValue * nfa.SecondaryHolderShare) /100;
                    double assetsMappingShare = ((primaryHolderShare + secondaryHolderShare) * nfa.AssetMappingShare) /100;

                    int timePeriod = getRemainingYearsFromPlanStartYear();
                    decimal inflationRate = nfa.GrowthPercentage;
                    sumOfNonFinancialAsset = sumOfNonFinancialAsset +
                         futureValue(assetsMappingShare, inflationRate, timePeriod);
                }
            }
            return sumOfNonFinancialAsset;
        }

        private int getRemainingYearsFromPlanStartYear()
        {
            if (int.Parse(_goal.StartYear) > _planStartYear)
            {
                return int.Parse(_goal.StartYear) - _planStartYear;
            }
            return 0;
        }

        private int getRemainingYearBy(int calculationYear)
        {
            if (int.Parse(_goal.StartYear) > calculationYear)
            {
                return int.Parse(_goal.StartYear) - calculationYear;
            }
            return 0;
        }

        private static double futureValue(double presentValue, decimal interest_rate, int timePeriodInYears)
        {
            //FV = PV * (1 + I)T;
            interest_rate = interest_rate / 100;
            decimal futureValue =  (decimal) presentValue *
                ((decimal)Math.Pow((double)(1 + interest_rate), (double)timePeriodInYears));

            return Math.Round((double)futureValue);
        }
        private static double presentValue(double futureValue, decimal interest_rate, int timePeriodInYears)
        {
            //PV = FV / (1 + I)T;
            interest_rate = interest_rate / 100;
            decimal presentValue =  (decimal) futureValue  /
                ((decimal)Math.Pow((double)(1 + interest_rate), (double)timePeriodInYears));

            return Math.Round((double)presentValue);
        }
    }
}