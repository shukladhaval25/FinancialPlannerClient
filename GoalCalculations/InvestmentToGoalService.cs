using FinancialPlannerClient.PlannerInfo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlannerClient.GoalCalculations
{
    public class InvestmentToGoalService
    {
        IList<InvestmentInGoal> _investmentsInGoal = new List<InvestmentInGoal>();
        public IList<InvestmentInGoal> GetInvestments()
        {
            return _investmentsInGoal;
        }

        public void AddInvestment(InvestmentInGoal investment)
        {
            if (investment != null)
                _investmentsInGoal.Add(investment);
        }
        public void DeleteInvestment(InvestmentInGoal investment)
        {
            if (investment != null)
                _investmentsInGoal.Remove(investment);
        }
        public double GetTotalInvestmentValue()
        {
            if (_investmentsInGoal == null)
                return 0;

            double totalInvestmentValue = 0;
            var val = _investmentsInGoal.OrderBy(i => i.InvestmentYear);
            foreach(InvestmentInGoal investment in _investmentsInGoal)
            {
               var value =  totalInvestmentValue + 
                    ((totalInvestmentValue * (double) investment.GrowthPercentage) / 100);
                totalInvestmentValue = value + investment.InvestmentAmount;            
            }
            return totalInvestmentValue;
        }
    }
}
