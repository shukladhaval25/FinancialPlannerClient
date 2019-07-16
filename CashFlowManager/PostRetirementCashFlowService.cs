using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.PlannerInfo;
using System;
using System.Data;

namespace FinancialPlannerClient.CashFlowManager
{
    public class PostRetirementCashFlowService
    {
        PlannerAssumption plannerAssumption;
        CashFlowCalculation cashFlowCalculation;
        CashFlowService cashFlowService;
        Planner planner;

        int retirementPlanningYearStartFrom;
        int expectedLifeEndYear;
        double totlaCorpusFund = 0;
        double corpusFundBalance;
        double proposeEstimatedCorpusFundRequire = 0;
        double invReturnRate = 6;
        private DataTable _dtRetirementCashFlow;

        public PostRetirementCashFlowService(Planner planner,
            CashFlowService cashFlowService)
        {
            this.planner = planner;         
            this.cashFlowService = cashFlowService;
            loadPlannerAssumption();
            this.cashFlowCalculation = cashFlowService.GetCashFlowCalculation();
            //generateCashFlowCalculationData();
            this.retirementPlanningYearStartFrom = getRetirementYear();
            this.expectedLifeEndYear = getExpectedLifeEndYear();
        }
        public CashFlowCalculation GetCashFlowCalculationData()
        {
            return this.cashFlowCalculation;
        }
        public double GetProposeEstimatedCorpusFund()
        {
            return Math.Round(this.proposeEstimatedCorpusFundRequire);
        }
        public void SetCorpusFund(double corpusFund)
        {
            this.totlaCorpusFund = corpusFund;
            this.corpusFundBalance = corpusFund;
        }
        private void loadPlannerAssumption()
        {
            plannerAssumption = new PlannerAssumptionInfo().GetAll(this.planner.ID);
        }
        private int getRetirementYear()
        {
            int year = cashFlowCalculation.IslientRetirmentAgeForPrimaryCalculation ?
                 DateTime.Now.Year + (cashFlowCalculation.ClientRetirementAge - cashFlowCalculation.ClientCurrentAge) :
                 DateTime.Now.Year + (cashFlowCalculation.SpouseRetirementAge - cashFlowCalculation.SpouseCurrentAge);
            return year;
        }
        private int getExpectedLifeEndYear()
        {
            int year = (cashFlowCalculation.ClientDateOfBirth < cashFlowCalculation.SpouseDateOfBirth) ?
                DateTime.Now.Year + (cashFlowCalculation.SpouseLifeExpected - cashFlowCalculation.SpouseCurrentAge) :
            DateTime.Now.Year + (cashFlowCalculation.ClientLifeExpected - cashFlowCalculation.ClientCurrentAge);
                
            return year;
        }
        private void createRetiremtnCashFlowTable()
        {
            _dtRetirementCashFlow = new DataTable();
            _dtRetirementCashFlow.Columns.Add("StartYear", typeof(System.Int16));
            _dtRetirementCashFlow.Columns.Add("EndYear", typeof(System.Int16));
            _dtRetirementCashFlow.Columns.Add("ClientCurrentAge", typeof(System.Int16));
            _dtRetirementCashFlow.Columns.Add("SpouseCurrentAge", typeof(System.Int16));

            generateIncomeColumns();
            generateExpensesColumns();
            generateLoanColumns();
            _dtRetirementCashFlow.Columns.Add("Rem_Corp_Fund", typeof(System.Double));
            _dtRetirementCashFlow.Columns.Add("EstimatedRequireCorpusFund", typeof(System.Double));
        }
               
        private void generateLoanColumns()
        {
            #region "Loan Calculation"
            foreach (Loan loan in cashFlowCalculation.LstLoans)
            {
                DataColumn dcloan = new DataColumn(loan.TypeOfLoan, typeof(System.Double));
                dcloan.ReadOnly = true;
                _dtRetirementCashFlow.Columns.Add(dcloan);
            }
            _dtRetirementCashFlow.Columns.Add("Total Annual Loans", typeof(System.Double));
            #endregion
        }

        public DataTable GetPostRetirementCashFlowData()
        {
            createRetiremtnCashFlowTable();
            for (int i = retirementPlanningYearStartFrom + 1; i <= expectedLifeEndYear; i++)
            {
                DataRow dr = _dtRetirementCashFlow.NewRow();
                dr["StartYear"] = i;
                dr["EndYear"] = i + 1;
                if (cashFlowCalculation.ClientLifeExpected >= (i - cashFlowCalculation.ClientDateOfBirth.Year))
                    dr["ClientCurrentAge"] = (i - cashFlowCalculation.ClientDateOfBirth.Year);
                if (cashFlowCalculation.SpouseLifeExpected >= (i - cashFlowCalculation.SpouseDateOfBirth.Year))
                    dr["SpouseCurrentAge"] = (i - cashFlowCalculation.SpouseDateOfBirth.Year);

                addIncomeCalculation(i, dr, cashFlowCalculation.ClientRetirementAge, cashFlowCalculation.SpouseRetirementAge);
                addExpenesCalculation(i, dr);
                _dtRetirementCashFlow.Rows.Add(dr);
            }
            calculateEstimatedRequireCorpusFund();
            return _dtRetirementCashFlow;
        }
        public void calculateEstimatedRequireCorpusFund()
        {
            for (int i = _dtRetirementCashFlow.Rows.Count - 1; i >= 1; i--)
            {
                double totalExpAmount = (double.Parse(_dtRetirementCashFlow.Rows[i]["Total Annual Expenses"].ToString()) -
                        double.Parse(_dtRetirementCashFlow.Rows[i]["Total Post Tax Income"].ToString()));
                //double estimatedCorpusFundValue = getEstimatedCorpusFundWithReturnCalculation(totalExpAmount);
                if (i == _dtRetirementCashFlow.Rows.Count - 1)
                    _dtRetirementCashFlow.Rows[i]["EstimatedRequireCorpusFund"] = 0;
                _dtRetirementCashFlow.Rows[i - 1]["EstimatedRequireCorpusFund"] = Math.Round(totalExpAmount +
                    getEstimatedCorpusFundWithReturnCalculation(
                        double.Parse(_dtRetirementCashFlow.Rows[i]["EstimatedRequireCorpusFund"].ToString())
                    ),2);
            }
            proposeEstimatedCorpusFundRequire = System.Math.Round(
                double.Parse(_dtRetirementCashFlow.Rows[0]["EstimatedRequireCorpusFund"].ToString()),2);

            proposeEstimatedCorpusFundRequire = proposeEstimatedCorpusFundRequire -
                double.Parse(_dtRetirementCashFlow.Rows[0]["Total Post Tax Income"].ToString());

            proposeEstimatedCorpusFundRequire = (proposeEstimatedCorpusFundRequire * 100) / 106;


            double totalExpAmountForFirstRow = (double.Parse(_dtRetirementCashFlow.Rows[0]["Total Annual Expenses"].ToString()));
            proposeEstimatedCorpusFundRequire = proposeEstimatedCorpusFundRequire + totalExpAmountForFirstRow;           
        }
        #region "Income Section"
        private void generateIncomeColumns()
        {
            #region "Income Calculation"
            foreach (Income income in cashFlowCalculation.LstIncomes)
            {
                DataColumn dcIncome = new DataColumn("(" + income.IncomeBy + ") " + income.Source, typeof(System.Double));
                dcIncome.ReadOnly = true;
                _dtRetirementCashFlow.Columns.Add(dcIncome);
                DataColumn dcIncomeTax = new DataColumn(dcIncome.ColumnName + " - Income Tax", typeof(System.Decimal));
                _dtRetirementCashFlow.Columns.Add(dcIncomeTax);
                DataColumn postTaxIncome = new DataColumn(dcIncome.ColumnName + " - Post Tax", typeof(System.Double));
                _dtRetirementCashFlow.Columns.Add(postTaxIncome);
            }

            DataColumn dcTotal = new DataColumn("Total Income", typeof(System.Double));
            dcTotal.ReadOnly = true;
            _dtRetirementCashFlow.Columns.Add(dcTotal);
            _dtRetirementCashFlow.Columns.Add("Total Tax Deduction", typeof(System.Double));
            _dtRetirementCashFlow.Columns.Add("Total Post Tax Income", typeof(System.Double));
            #endregion
        }
        private bool isIncomeValidaForYear(Income income, int years, int clientRetYear, int spouseRetYear)
        {
            if (income.IncomeBy == cashFlowCalculation.ClientName)
                return (clientRetYear >= (years - cashFlowCalculation.ClientDateOfBirth.Year)) ? true : false;
            else if (income.IncomeBy == cashFlowCalculation.SpouseName)
                return (spouseRetYear >= (years - cashFlowCalculation.SpouseDateOfBirth.Year)) ? true : false;
            else
                return true;
        }

        private void addIncomeCalculation(int years, DataRow dr, int clientRetYear, int spouseRetYear)
        {
            long totalIncome = 0;
            int incomeEndYear = 0;
            long totalTaxAmt = 0;
            long totalPostTaxIncome = 0;
            foreach (Income income in cashFlowCalculation.LstIncomes)
            {
                incomeEndYear = string.IsNullOrEmpty(income.EndYear) ? DateTime.Now.Year + 100 : int.Parse(income.EndYear);
                if (int.Parse(dr["StartYear"].ToString()) >= int.Parse(income.StartYear) &&
                    int.Parse(dr["StartYear"].ToString()) <= incomeEndYear)
                {
                    if (isIncomeValidaForYear(income, years, clientRetYear, spouseRetYear))
                    {
                        try
                        {
                            long amount = getIncomeAmount(income,years);
                            amount = amount + (long)((amount * float.Parse(income.ExpectGrowthInPercentage.ToString()) / 100));
                            dr["(" + income.IncomeBy + ") " + income.Source] = amount;
                            totalIncome = totalIncome + amount;

                            dr["(" + income.IncomeBy + ") " + income.Source + " - Income Tax"] = income.IncomeTax;
                            long incomeTaxAmt = ((amount * long.Parse(income.IncomeTax.ToString()) / 100));
                            totalTaxAmt = totalTaxAmt + incomeTaxAmt;

                            long postTaxAmt = (amount - incomeTaxAmt);
                            dr["(" + income.IncomeBy + ") " + income.Source + " - Post Tax"] = postTaxAmt;
                            totalPostTaxIncome = totalPostTaxIncome + long.Parse(postTaxAmt.ToString());
                        }
                        catch (Exception ex)
                        {
                            LogDebug("AddRowOnCalculation", ex);
                        }
                    }
                    else
                    {
                        dr["(" + income.IncomeBy + ") " + income.Source] = 0;
                    }
                }
                else
                {
                    dr["(" + income.IncomeBy + ") " + income.Source] = 0;
                }
            }
            dr["Total Income"] = totalIncome;
            dr["Total Tax Deduction"] = totalTaxAmt;
            dr["Total Post Tax Income"] = totalPostTaxIncome;
        }

        private long getIncomeAmount(Income income,int year)
        {
            if (_dtRetirementCashFlow.Rows.Count > 0)
                return long.Parse(_dtRetirementCashFlow.Rows[_dtRetirementCashFlow.Rows.Count - 1]["(" + income.IncomeBy + ") " + income.Source].ToString());
            else
            {
                DataRow drLastCashFlow = cashFlowService.GetLastIncomeAndExpAtRetirementAge();
                long amount = 0;
                if (drLastCashFlow != null)
                    amount = long.Parse(drLastCashFlow["(" + income.IncomeBy + ") " + income.Source].ToString());
                else
                {
                    int yearDifference = (cashFlowCalculation.ClientCurrentAge > cashFlowCalculation.SpouseCurrentAge) ?
                        cashFlowCalculation.ClientCurrentAge - cashFlowCalculation.SpouseCurrentAge :
                        cashFlowCalculation.SpouseCurrentAge - cashFlowCalculation.ClientCurrentAge;

                    amount = (long)futureValue(income.Amount, income.ExpectGrowthInPercentage, ((year - yearDifference) - this.planner.StartDate.Year));
                }
                return amount;
            }
        }
        #endregion

        #region "Expenses"
        private void generateExpensesColumns()
        {
            
            #region "Expenses Calculation" 
            foreach (Goals goal in cashFlowCalculation.LstGoals)
            {
                if (goal.Category == "Retirement" || int.Parse(goal.StartYear) > this.retirementPlanningYearStartFrom)
                {
                    DataColumn dcExp = new DataColumn(goal.Name, typeof(System.Double));
                    dcExp.ReadOnly = true;
                    _dtRetirementCashFlow.Columns.Add(dcExp);
                }
            }
            _dtRetirementCashFlow.Columns.Add("Total Annual Expenses", typeof(System.Double));
            #endregion
        }
        private void addExpenesCalculation(int years, DataRow dr)
        {
           
            double totalExpenses = 0;
            foreach (Goals  goal in cashFlowCalculation.LstGoals)
            {
                if (goal.Category == "Retirement" || int.Parse(goal.StartYear) == years)
                {
                    int forYears = years - this.planner.StartDate.Year;
                    double retExp = futureValue(goal.Amount + goal.OtherAmount, goal.InflationRate, forYears);
                    dr[goal.Name] = retExp;
                    totalExpenses = totalExpenses + retExp;                    
                }               
            }
            dr["Total Annual Expenses"] = totalExpenses;
            corpusFundBalance = corpusFundBalance - (totalExpenses - double.Parse(dr["Total Post Tax Income" +
                ""].ToString()) );
            corpusFundBalance = corpusFundBalance + ((corpusFundBalance * invReturnRate) / 100);
            dr["Rem_Corp_Fund"] = Math.Round(corpusFundBalance, 2) ;
        }
        #endregion

        private static double futureValue(double presentValue, decimal interest_rate, int timePeriodInYears)
        {
            //FV = PV * (1 + I)T;
            interest_rate = interest_rate / 100;
            double futureValue = presentValue *
                (Math.Pow((double)(1 + interest_rate), (double)timePeriodInYears));

            return Math.Round(futureValue);
        }
        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }

        private double getEstimatedCorpusFundWithReturnCalculation(double value)
        {                
            return (value * 100) / (100 + invReturnRate);
        }
    }
}
