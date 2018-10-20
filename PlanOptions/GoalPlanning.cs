using FinancialPlanner.Common.Model;

namespace FinancialPlannerClient.PlanOptions
{
    public class GoalPlanning
    {
        int _goalId;
        int _year;
        int _yearLeft;       
        double _goalFutureValue;
        double _estimatedFreshInvestment;
        double _actualFreshInvestment;
        double _mappedInstrumentFutureValue;
        double _mappedNonFincialAssetsFutureValue;
        double _totalActualInvestmentValue;
        double _shortFallForGoalValue;
        decimal _growthPercentage;
        decimal _goalComplitionPercentage;

        Goals _goal;

        public GoalPlanning(Goals goal)
        {
            _goal = goal;
        }

        public int GoalId
        {
            get
            {
                return _goalId;
            }

            set
            {
                _goalId = value;
            }
        }

        public int Year
        {
            get
            {
                return _year;
            }

            set
            {
                _year = value;
            }
        }

        public int YearLeft
        {
            get
            {
                _yearLeft =   int.Parse( _goal.StartYear) - _year;
                return _yearLeft;
            }
        }

        public double GoalFutureValue
        {
            get
            {
                return _goalFutureValue;
            }

            set
            {
                _goalFutureValue = value;
            }
        }

        public double EstimatedFreshInvestment
        {
            get
            {
                return _estimatedFreshInvestment;
            }

            set
            {
                _estimatedFreshInvestment = value;
            }
        }

        public double ActualFreshInvestment
        {
            get
            {
                return _actualFreshInvestment;
            }

            set
            {
                _actualFreshInvestment = value;
            }
        }

        public double MappedInstrumentFutureValue
        {
            get
            {
                return _mappedInstrumentFutureValue;
            }

            set
            {
                _mappedInstrumentFutureValue = value;
            }
        }

        public double MappedNonFincialAssetsFutureValue
        {
            get
            {
                return _mappedNonFincialAssetsFutureValue;
            }

            set
            {
                _mappedNonFincialAssetsFutureValue = value;
            }
        }

        public double TotalActualInvestmentValue
        {
            get
            {
                return _totalActualInvestmentValue;
            }

            set
            {
                _totalActualInvestmentValue = value;
            }
        }

        public double ShortFallForGoalValue
        {
            get
            {
                _shortFallForGoalValue = _goalFutureValue - (_totalActualInvestmentValue +
                    _mappedInstrumentFutureValue + _mappedNonFincialAssetsFutureValue);
                return _shortFallForGoalValue;
            }
        }

        public decimal GrowthPercentage
        {
            get
            {
                return _growthPercentage;
            }

            set
            {
                _growthPercentage = value;
            }
        }

        public decimal GoalComplitionPercentage
        {
            get
            {
                return _goalComplitionPercentage;
            }
        }
    }
}