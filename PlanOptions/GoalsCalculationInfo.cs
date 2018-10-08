using FinancialPlanner.Common.Model;
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
        GoalsInfo _goalsInfo = new GoalsInfo();
        DataTable _dtGoalValue = new DataTable();
        DataTable _dtGoalCalculation = new DataTable();
        DataTable _dtRiskProfileDet = new DataTable();

        public int _riskprofileId;

        internal DataTable GetGoalValue(int goalId, int plannerId, int RiskProfileID)
        {
            _plannerId = plannerId;
            _riskprofileId = RiskProfileID;
            _goal = _goalsInfo.GetById(goalId, plannerId);
            setGoalValueTable();
            return _dtGoalValue;
        }

        internal DataTable GetGoalCalculation()
        {

            setGoalCalculationTable();
            return _dtGoalCalculation;
        }

        #region "Goal Value"
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

            return Math.Round((double)futureValue);
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
        #endregion

        #region "Goal Calculation"

        private void setGoalCalculationTable()
        {
            loadRislProfileReturnDetails();
            setGoalCalculationTableStructure();
            addRowsInGoalCalculation();
        }

        private void loadRislProfileReturnDetails()
        {
            ReiskProfileInfo _defaultRiskProfile = new ReiskProfileInfo();
            _dtRiskProfileDet = _defaultRiskProfile.GetRiskProfileReturnById(_riskprofileId);
        }

        private void addRowsInGoalCalculation()
        {
            int goalYear = int.Parse(_goal.StartYear);
            for (int currentYear = DateTime.Now.Year; currentYear <= goalYear; currentYear++)
            {
                DataRow dr = _dtGoalCalculation.NewRow();
                decimal returnRatio = getRiskProfileReturnRatio(goalYear - currentYear);
                dr["Year Left"] = goalYear - currentYear;
                dr["Loan Instrument"] = 0;
                dr["Fresh Investment"] = 0;
                dr["Assets Mapping"] = 0;
                dr["Instrument Mapped"] = 0;
                dr["Portfolio Value"] =
                     calculatePortfoliioValue(0,0,0,returnRatio);
                dr["Cash outflow Goal Year"] = (currentYear == goalYear) ? GetFutureValue() : 0;
                dr["Portfolio Return"] = returnRatio;
                _dtGoalCalculation.Rows.Add(dr);
            }
        }

        private double calculatePortfoliioValue(double freshInv,double assetsMapping, double instrumentMapped, decimal returnRatio)
        {
            double portfolioValue = 0;
            if (_dtGoalCalculation.Rows.Count > 0)
            {
                portfolioValue = double.Parse(_dtGoalCalculation.Rows[_dtGoalCalculation.Rows.Count -1]["Portfolio Value"].ToString());
                portfolioValue = portfolioValue + freshInv + assetsMapping + instrumentMapped + (( portfolioValue * (double) returnRatio) / 100);
                //double freshInvestment = double.Parse(_dtGoalCalculation.Rows[_dtGoalCalculation.Rows.Count -1]["Fresh Investment"].ToString());
                //double assetsMapping = double.Parse(_dtGoalCalculation.Rows[_dtGoalCalculation.Rows.Count -1]["Assets Mapping"].ToString());
                //double instrumentMapped = double.Parse(_dtGoalCalculation.Rows[_dtGoalCalculation.Rows.Count -1]["Instrument Mapped"].ToString());
                //double portfolioReturnRatio = double.Parse(_dtGoalCalculation.Rows[_dtGoalCalculation.Rows.Count -1]["Portfolio Return"].ToString());                
            }
            else
            {
                portfolioValue = GetProfileValue();
                portfolioValue = portfolioValue + freshInv + assetsMapping + instrumentMapped + ((portfolioValue * (double)returnRatio) / 100);
            }
            return  System.Math.Round(portfolioValue);
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
            CurrentStatusToGoal csGoal = new CurrentStatusToGoal();
            var dtCS = csGoal.CurrentStatusToGoalCalculation(_plannerId);
            DataRow[] dr =  dtCS.Select(string.Format("Goal = '{0}'", _goal.Name));
            if (dr != null)
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
            dcYear.AutoIncrementSeed = DateTime.Now.Year;
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
    }
}
