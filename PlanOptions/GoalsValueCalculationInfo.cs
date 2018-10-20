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
        IList<GoalPlanning> goalPlannings = new List<GoalPlanning>();

        double _futureValueOfGoal;
        double _currentValueOfGoal;
        double _futureValueOfMappedInstruments;
        double _futureValueOfMappedNonFinancialAssets;
        double _estimatedYearlyFreshInvestment;

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

        public double EstimatedYearlyFreshInvestment
        {
            get
            {
                return _estimatedYearlyFreshInvestment;
            }

            set
            {
                _estimatedYearlyFreshInvestment = value;
            }
        }

        public GoalsValueCalculationInfo(Goals goal, Planner planner, RiskProfileInfo riskProfileInfo,int riskprorfileId)
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
        }

        public IList<GoalPlanning> GetGoalPlanning()
        {
            double estimatedOneTimeInvestment = getEstimatedFreshInvestment();
            double estimatedYearlyFreshInvestment = Math.Round((estimatedOneTimeInvestment / getRemainingYearsFromPlanStartYear()));
            EstimatedYearlyFreshInvestment = estimatedYearlyFreshInvestment;

            for (int currentYear = _planner.StartDate.Year; currentYear <= int.Parse(_goal.StartYear); currentYear++)
            {
                GoalPlanning goalplanning = new GoalPlanning(_goal);
                goalplanning.Year = currentYear;
                goalplanning.EstimatedFreshInvestment = estimatedYearlyFreshInvestment;
                goalplanning.GrowthPercentage = _riskProfileInfo.GetRiskProfileReturnRatio(_riskProfileId, getRemainingYearBy(currentYear));
                goalPlannings.Add(goalplanning);
            }
            return goalPlannings;
        }

        public GoalPlanning GetGoalPlanning(int calculationYear)
        {
            double estimatedOneTimeInvestment = getEstimatedFreshInvestment();
            double estimatedYearlyFreshInvestment = Math.Round((estimatedOneTimeInvestment / getRemainingYearsFromPlanStartYear()));
            EstimatedYearlyFreshInvestment = estimatedYearlyFreshInvestment;
            for (int currentYear = _planner.StartDate.Year; currentYear <= int.Parse(_goal.StartYear); currentYear++)
            {
                GoalPlanning goalplanning = new GoalPlanning(_goal);
                goalplanning.Year = currentYear;
                goalplanning.EstimatedFreshInvestment = estimatedYearlyFreshInvestment;
                goalPlannings.Add(goalplanning);
                if (currentYear == calculationYear)
                    return goalplanning;
            }
            return null;          
        }

        private double getEstimatedFreshInvestment()
        {
            double shortFallValueInfFuture = _futureValueOfGoal - (_futureValueOfMappedInstruments + _futureValueOfMappedNonFinancialAssets );
            decimal averagegrowthPercentage = 6;
            double presentValueOfShortFall = presentValue(shortFallValueInfFuture,averagegrowthPercentage,getRemainingYearsFromPlanStartYear());
            return presentValueOfShortFall;
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
            
            return futureValue(instumentMappedCurrentValue,10, getRemainingYearsFromPlanStartYear());
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
                        
                    sumOfNonFinancialAsset = sumOfNonFinancialAsset +
                         futureValue(assetsMappingShare, growthPercentage, timePeriod);
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
        private static double presentValue(double futureValue,decimal interest_rate,int timePeriodInYears)
        {
            //PV = FV / (1 + I)T;
            interest_rate = interest_rate / 100;
            decimal presentValue =  (decimal) futureValue  /
                ((decimal)Math.Pow((double)(1 + interest_rate), (double)timePeriodInYears));

            return Math.Round((double)presentValue);
        }
    }
}