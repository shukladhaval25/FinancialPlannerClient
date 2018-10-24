using FinancialPlanner.Common.Model;

namespace FinancialPlannerClient.PlanOptions
{
    public class GoalPlanning
    {
        int _goalId;
        int _year;
        int _yearLeft;       
        double _goalFutureValue;
        double _actualFreshInvestment;
        decimal _growthPercentage;
       
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
    }
}