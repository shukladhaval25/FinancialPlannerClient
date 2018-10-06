using FinancialPlanner.Common.Model;
using FinancialPlannerClient.PlannerInfo;
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
        GoalsInfo _goalsInfo = new GoalsInfo();
        DataTable _dtGoalValue = new DataTable();

        internal DataTable GetGoalValue(int goalId,int plannerId)
        {
            _goal = _goalsInfo.GetById(goalId, plannerId);
            setGoalValueTable();
            return _dtGoalValue;
        }

        private void setGoalValueTable()
        {
            createTableStructure();
            addRowforGoalValue();
        }

        private void addRowforGoalValue()
        {
            DataRow dr = _dtGoalValue.NewRow();
            dr["Year"] = DateTime.Now.Year;
            dr["Goal"] = _goal.Name;
            dr["CurrentValue"] = _goal.Amount;
            dr["GoalYear"] = int.Parse(_goal.StartYear);
            dr["Inflation"] = _goal.InflationRate;
            dr["YearLeft"] = getYears(_goal.StartYear);
            dr["GoalValue"] = GetFutureValue();
            _dtGoalValue.Rows.Add(dr);

        }

        private void createTableStructure()
        {
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

        }

        internal double GetFutureValue()
        {
            //FV = PV * (1 + I)T;
            double currentValue = _goal.Amount;
            decimal interest_rate = _goal.InflationRate / 100;
            int years = getYears(_goal.StartYear);
            decimal futureValue =  (decimal) currentValue *
                ((decimal)Math.Pow((double)(1 + interest_rate), (double)years));

            return Math.Round((double) futureValue);
        }

        private int getYears(string startYear)
        {
            if (string.IsNullOrEmpty(startYear))
                return 0;
            else
            {
                if (int.Parse(startYear) > DateTime.Now.Year)
                {
                    return int.Parse(startYear) - DateTime.Now.Year;
                }
            }
            return 0;
        }
    }
}
