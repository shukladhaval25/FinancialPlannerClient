using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlannerClient.GoalCalculations
{
    public class InvestmentInGoal
    {
        internal int GoalId;
        internal int PlanId;
        internal int InvestmentYear;
        internal double InvestmentAmount;
        internal double PortfolioValue;
        internal decimal GrowthPercentage;
    }
}
