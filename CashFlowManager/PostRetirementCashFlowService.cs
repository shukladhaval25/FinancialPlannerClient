using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.PlannerInfo;
using FinancialPlannerClient.PlanOptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

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
        double invReturnRate = 0;
        double totalCurrentCorpFund = 0;
        private DataTable _dtRetirementCashFlow;

        public PostRetirementCashFlowService(Planner planner,
            CashFlowService cashFlowService)
        {
            Logger.LogInfo("Post retirement cash flow service constructor call");
            this.planner = planner;         
            this.cashFlowService = cashFlowService;
            loadPlannerAssumption();
            double.TryParse( plannerAssumption.PostRetirementInvestmentReturnRate.ToString(),out invReturnRate);
            Logger.LogInfo("Get cash flow calculation from cash flow service.");
            this.cashFlowCalculation = cashFlowService.GetCashFlowCalculation();
            //generateCashFlowCalculationData();
            this.retirementPlanningYearStartFrom = getRetirementYear();
            Logger.LogInfo("Get retirment year :" + this.retirementPlanningYearStartFrom);
            this.expectedLifeEndYear = getExpectedLifeEndYear();
            Logger.LogInfo("Get expected life end year :" + this.expectedLifeEndYear);
            Logger.LogInfo("Post retirement cash flow service constructor call completed");

            Goals retirementGoal = cashFlowCalculation.LstGoals.First(y => y.Category == "Retirement");
            GoalsValueCalculationInfo goalsValueCalculationInfo = cashFlowService.GoalCalculationMgr.GetGoalValueCalculation(retirementGoal);
            double assetsMappingValue = (goalsValueCalculationInfo != null) ? goalsValueCalculationInfo.FutureValueOfMappedNonFinancialAssets : 0;
            totalCurrentCorpFund  =  cashFlowService.GetCashFlowSurplusAmount() + cashFlowService.GetCurrentStatusAccessFund() + assetsMappingValue;
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
            Logger.LogInfo("Load planner assumption start");
            plannerAssumption = new PlannerAssumptionInfo().GetAll(this.planner.ID);
            if (plannerAssumption.ClientLifeExpectancy == 0 && 
                plannerAssumption.ClientRetirementAge == 0 && 
                plannerAssumption.PostRetirementInflactionRate == 0
                )
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Please check assumption infromation are correct.", "Assumption Information");
                throw new DataMisalignedException();
            }
            Logger.LogInfo("Load planner assumption completed");
        }
        private int getRetirementYear()
        {
            int year = cashFlowCalculation.IslientRetirmentAgeForPrimaryCalculation ?
                 DateTime.Now.Year + ((cashFlowCalculation.ClientRetirementAge ) - cashFlowCalculation.ClientCurrentAge) :
                 DateTime.Now.Year + ((cashFlowCalculation.SpouseRetirementAge ) - cashFlowCalculation.SpouseCurrentAge);
            return year;
        }
        private int getExpectedLifeEndYear()
        {
            int year = (cashFlowCalculation.ClientDateOfBirth < cashFlowCalculation.SpouseDateOfBirth &&  !string.IsNullOrEmpty(cashFlowCalculation.SpouseName)) ?
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
            generateGoalLoans();
            generateLoanColumns();
            
            _dtRetirementCashFlow.Columns.Add("Rem_Corp_Fund", typeof(System.Double));
            _dtRetirementCashFlow.Columns.Add("EstimatedRequireCorpusFund", typeof(System.Double));
           // _dtRetirementCashFlow.Columns.Add("CurrentCorpFund", typeof(System.Double));
        }

        private void generateGoalLoans()
        {

            cashFlowCalculation.LstGoals.OrderBy(x => x.Priority);

            foreach (Goals goal in cashFlowCalculation.LstGoals)
            {
                //DataColumn dcGoal = new DataColumn(string.Format("{0} - {1}", goal.Priority, goal.Name), typeof(System.Double));
                //_dtRetirementCashFlow.Columns.Add(dcGoal);
                //dcGoal.ReadOnly = true;
                
                if (goal.LoanForGoal != null && goal.LoanForGoal.EMI > 0 && 
                    (this.retirementPlanningYearStartFrom <= goal.LoanForGoal.EndYear))
                {
                    DataColumn dtLoanForGoal = new DataColumn(string.Format("(Loan EMI - {0})", goal.Name), typeof(System.Double));
                    _dtRetirementCashFlow.Columns.Add(dtLoanForGoal);
                }
            }
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
            Logger.LogInfo("GetPostRetirementCashFlowData call start");
            createRetiremtnCashFlowTable();
            corpusFundBalance = totalCurrentCorpFund;
            for (int i = retirementPlanningYearStartFrom + 1; i <= expectedLifeEndYear; i++)
            {
                DataRow dr = _dtRetirementCashFlow.NewRow();
                dr["StartYear"] = i;
                dr["EndYear"] = (this.planner.StartDate.Year == this.planner.EndDate.Year ) ? i : i + 1;
                if (cashFlowCalculation.ClientLifeExpected >= (i - cashFlowCalculation.ClientDateOfBirth.Year))
                    dr["ClientCurrentAge"] = (i - cashFlowCalculation.ClientDateOfBirth.Year);
                if (cashFlowCalculation.SpouseLifeExpected >= (i - cashFlowCalculation.SpouseDateOfBirth.Year))
                    dr["SpouseCurrentAge"] = (i - cashFlowCalculation.SpouseDateOfBirth.Year);

              
                addIncomeCalculation(i, dr, cashFlowCalculation.ClientRetirementAge, cashFlowCalculation.SpouseRetirementAge);
                addExpenesCalculation(i, dr);
                //addGoalLoanCalculation(i, dr);
                addLoansCalculation(i, dr);
                //if (i == retirementPlanningYearStartFrom + 1)
                //{
                //    double totalAnnualExp = double.Parse(dr["Total Annual Expenses"].ToString());
                //    double totalAnnualLoan = double.Parse(dr["Total Annual Loans"].ToString());
                //    double totalExpAmount = (
                //            double.Parse(dr["Total Post Tax Income"].ToString()) - (totalAnnualExp + totalAnnualLoan));
                //    //dr["CurrentCorpFund"] = totalCurrentCorpFund - totalExpAmount;
                //}
                //else {
                //    double lastYearCurrentCorpFundValue = double.Parse(_dtRetirementCashFlow.Rows[_dtRetirementCashFlow.Rows.Count - 1]["Rem_Corp_Fund"].ToString());
                //    double totalAnnualExp = double.Parse(_dtRetirementCashFlow.Rows[_dtRetirementCashFlow.Rows.Count  -1]["Total Annual Expenses"].ToString());
                //    double totalAnnualLoan = double.Parse(_dtRetirementCashFlow.Rows[_dtRetirementCashFlow.Rows.Count - 1]["Total Annual Loans"].ToString());
                //    double totalExpAmount = (
                //            double.Parse(_dtRetirementCashFlow.Rows[_dtRetirementCashFlow.Rows.Count - 1]["Total Post Tax Income"].ToString()) - (totalAnnualExp + totalAnnualLoan));
                //   // dr["CurrentCorpFund"] = lastYearCurrentCorpFundValue + ((lastYearCurrentCorpFundValue * invReturnRate) / 100) - totalExpAmount;
                //}
                _dtRetirementCashFlow.Rows.Add(dr);
            }
            calculateEstimatedRequireCorpusFund();
            Logger.LogInfo("GetPostRetirementCashFlowData call end");
            return _dtRetirementCashFlow;
        }

        private void addGoalLoanCalculation(int i, DataRow dr)
        {
            int currentLoanYear = (i - DateTime.Now.Year);
            int previousYearRowIndex = i - 1;
            double totalLoans = 0;
            if (cashFlowCalculation.LstGoals != null)
            {
                foreach (Goals goal in cashFlowCalculation.LstGoals)
                {
                    if (goal.LoanForGoal != null && goal.LoanForGoal.EMI > 0 &&
                   (i >= goal.LoanForGoal.StratYear && 
                   i  <= goal.LoanForGoal.EndYear))
                    {
                        dr[string.Format("(Loan EMI - {0})", goal.Name)] = (goal.LoanForGoal.EMI * 12);
                    }                   
                }
            }
        }

        private void addLoansCalculation(int i, DataRow dr)
        {
            int currentLoanYear = (i - DateTime.Now.Year);
            int previousYearRowIndex = i - 1;
            double totalLoans = 0;

            if (cashFlowCalculation.LstGoals != null)
            {
                foreach (Goals goal in cashFlowCalculation.LstGoals)
                {
                    if (goal.LoanForGoal != null && goal.LoanForGoal.EMI > 0 &&
                   (i >= goal.LoanForGoal.StratYear &&
                   i <= goal.LoanForGoal.EndYear))
                    {
                        dr[string.Format("(Loan EMI - {0})", goal.Name)] = (goal.LoanForGoal.EMI * 12);
                        totalLoans = totalLoans + (goal.LoanForGoal.EMI * 12);
                    }
                }
            }


            if (cashFlowCalculation.LstLoans != null)
            {
                foreach (Loan loan in cashFlowCalculation.LstLoans)
                {
                    decimal totalNoOfYearsForLoan = (Decimal)((Decimal)loan.TermLeftInMonths / 12);
                    if (currentLoanYear <= totalNoOfYearsForLoan || (totalNoOfYearsForLoan > currentLoanYear - 1 && totalNoOfYearsForLoan < currentLoanYear))
                    {
                        double loanAmt = getLoanAmount(previousYearRowIndex, loan);
                        decimal yearsForLoan = totalNoOfYearsForLoan - Math.Truncate(totalNoOfYearsForLoan);
                        decimal period = 12 / (12 * (yearsForLoan > 0 ? yearsForLoan : 1));
                        dr[loan.TypeOfLoan] = (currentLoanYear < totalNoOfYearsForLoan) ? loanAmt :
                            ((loanAmt) / (double)period);
                        loanAmt = (currentLoanYear < totalNoOfYearsForLoan) ? loanAmt :
                            ((loanAmt) / (double)period);
                        totalLoans = totalLoans + loanAmt;
                    }
                }
            }
            dr["Total Annual Loans"] = totalLoans;
            double totalExpenses = 0;
            double.TryParse(dr["Total Annual Expenses"].ToString(), out totalExpenses);
            corpusFundBalance = corpusFundBalance - ((totalExpenses + totalLoans) - double.Parse(dr["Total Post Tax Income" +
            ""].ToString()));
            corpusFundBalance = corpusFundBalance + ((corpusFundBalance * invReturnRate) / 100);
            dr["Rem_Corp_Fund"] = Math.Round(corpusFundBalance, 2);
            //dr["Total Annual Expenses"] = totalExpenses;
            //corpusFundBalance = corpusFundBalance - (totalLoans);
            //corpusFundBalance = corpusFundBalance + ((corpusFundBalance * invReturnRate) / 100);
            //dr["Rem_Corp_Fund"] = Math.Round(corpusFundBalance, 2);
            //Logger.LogInfo("addExpenesCalculation for post retirment cash flow service end");
        }

        private double getLoanAmount(int previousYearRowIndex, Loan loan)
        {
            //return (previousYearRowIndex > 0) ? double.Parse(_dtRetirementCashFlow.Rows[previousYearRowIndex][loan.TypeOfLoan].ToString()) : 0;

            if (_dtRetirementCashFlow.Rows.Count > 0)
            {
                return double.Parse(_dtRetirementCashFlow.Rows[_dtRetirementCashFlow.Rows.Count - 1][loan.TypeOfLoan].ToString());
            }
            else
            {
                DataRow drLastCashFlow = cashFlowService.GetLastIncomeAndExpAtRetirementAge();
                double loanAmount  = 0;
                if (drLastCashFlow != null)
                    loanAmount = long.Parse(drLastCashFlow[loan.TypeOfLoan].ToString());
                return loanAmount;
            }


        }

        //Logger.LogInfo("add loan for post retirment cash flow service start");
        //double totalExpenses = 0;
        //if (cashFlowCalculation.LstGoals != null)
        //{
        //    foreach (Loan loan in cashFlowCalculation.LstGoals)
        //    {
        //        if (loan.TypeOfLoan  || int.Parse(loan.) == years)
        //        {
        //            double retExp = getPostRetirementExpWithInfluationRate(dr, years, goal);
        //            dr[goal.Name] = retExp;
        //            totalExpenses = totalExpenses + retExp;
        //        }
        //    }
        //}
        //dr["Total Annual Expenses"] = totalExpenses;
        //corpusFundBalance = corpusFundBalance - (totalExpenses - double.Parse(dr["Total Post Tax Income" +
        //    ""].ToString()));
        //corpusFundBalance = corpusFundBalance + ((corpusFundBalance * invReturnRate) / 100);
        //dr["Rem_Corp_Fund"] = Math.Round(corpusFundBalance, 2);
        //Logger.LogInfo("addExpenesCalculation for post retirment cash flow service end");
        // }

        public void calculateEstimatedRequireCorpusFund()
        {
            Logger.LogInfo("calculateEstimatedRequireCorpusFund for post retirment cash flow service start");
            for (int i = _dtRetirementCashFlow.Rows.Count - 1; i >= 1; i--)
            {
                double totalAnnualExp = double.Parse(_dtRetirementCashFlow.Rows[i]["Total Annual Expenses"].ToString());
                double totalAnnualLoan = double.Parse(_dtRetirementCashFlow.Rows[i]["Total Annual Loans"].ToString());
                double totalExpAmount = ((totalAnnualExp + totalAnnualLoan) -
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

            proposeEstimatedCorpusFundRequire = (proposeEstimatedCorpusFundRequire * 100) / (100 + invReturnRate); ;


            double totalExpAmountForFirstRow = (double.Parse(_dtRetirementCashFlow.Rows[0]["Total Annual Expenses"].ToString()));
            proposeEstimatedCorpusFundRequire = proposeEstimatedCorpusFundRequire + totalExpAmountForFirstRow;
            Logger.LogInfo("calculateEstimatedRequireCorpusFund for post retirment cash flow service end");
        }
        #region "Income Section"
        private void generateIncomeColumns()
        {
            #region "Income Calculation"
            foreach (Income income in cashFlowCalculation.LstIncomes)
            {
                DataColumn dcIncome = new DataColumn("(" + income.IncomeBy + ") " + income.Source, typeof(System.Double));
                dcIncome.ReadOnly = true;
                if (!_dtRetirementCashFlow.Columns.Contains(dcIncome.Caption))
                    _dtRetirementCashFlow.Columns.Add(dcIncome);

                DataColumn dcIncomeTax = new DataColumn(dcIncome.ColumnName + " - Income Tax", typeof(System.Decimal));
                if (!_dtRetirementCashFlow.Columns.Contains(dcIncomeTax.Caption))
                    _dtRetirementCashFlow.Columns.Add(dcIncomeTax);

                DataColumn postTaxIncome = new DataColumn(dcIncome.ColumnName + " - Post Tax", typeof(System.Double));
                if (!_dtRetirementCashFlow.Columns.Contains(postTaxIncome.Caption))
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
            if ( !string.IsNullOrEmpty(income.StartYear) && !string.IsNullOrEmpty(income.EndYear) &&
               years >= int.Parse(income.StartYear) && years <= int.Parse(income.EndYear))
            {
                return true;
            }
            else
            {
                if((!string.IsNullOrEmpty(income.StartYear) && string.IsNullOrEmpty(income.EndYear)) &&
                      years >= (int.Parse(income.StartYear)))
                {
                    return true;
                }
            }

            if (income.IncomeBy == cashFlowCalculation.ClientName)
                return (clientRetYear >= (years - cashFlowCalculation.ClientDateOfBirth.Year)) ? true : false;
            else if (income.IncomeBy == cashFlowCalculation.SpouseName)
                return (spouseRetYear >= (years - cashFlowCalculation.SpouseDateOfBirth.Year)) ? true : false;
            else
                return true;
        }

        private void addIncomeCalculation(int years, DataRow dr, int clientRetYear, int spouseRetYear)
        {
            Logger.LogInfo("addIncomeCalculation for post retirment cash flow service start");
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
            Logger.LogInfo("addIncomeCalculation for post retirment cash flow service end");
        }

        private long getIncomeAmount(Income income,int year)
        {
            if (_dtRetirementCashFlow.Rows.Count > 0)
            {
                long incomeAmount = long.Parse(_dtRetirementCashFlow.Rows[_dtRetirementCashFlow.Rows.Count - 1]["(" + income.IncomeBy + ") " + income.Source].ToString());
                if (int.Parse(income.StartYear) == year && incomeAmount == 0)
                {
                    incomeAmount = long.Parse(income.Amount.ToString());
                }
                return incomeAmount;
            }
            else
            {
                DataRow drLastCashFlow = cashFlowService.GetLastIncomeAndExpAtRetirementAge();
                long amount = 0;
                if (drLastCashFlow != null)
                    amount = long.Parse(drLastCashFlow["(" + income.IncomeBy + ") " + income.Source].ToString());
                else
                {
                    //int yearDifference = (cashFlowCalculation.ClientCurrentAge > cashFlowCalculation.SpouseCurrentAge) ?
                    //    cashFlowCalculation.ClientCurrentAge - cashFlowCalculation.SpouseCurrentAge :
                    //    cashFlowCalculation.SpouseCurrentAge - cashFlowCalculation.ClientCurrentAge;

                    amount = (long)futureValue(income.Amount, income.ExpectGrowthInPercentage, ((year - 1)  - int.Parse(income.StartYear)));
                }
                return amount;
            }
        }
        #endregion

        #region "Expenses"
        private void generateExpensesColumns()
        {

            #region "Expenses Calculation" 
            if (cashFlowCalculation.LstGoals != null)
            {
                foreach (Goals goal in cashFlowCalculation.LstGoals)
                {
                    if (goal.Category == "Retirement" || int.Parse(goal.StartYear) > this.retirementPlanningYearStartFrom)
                    {
                        DataColumn dcExp = new DataColumn(goal.Name, typeof(System.Double));
                        dcExp.ReadOnly = true;
                        _dtRetirementCashFlow.Columns.Add(dcExp);
                    }
                }
            }
            IList<Expenses> expenses = new ExpensesInfo().GetAll(this.planner.ID);
            foreach (Expenses exp in expenses)
            {
                int expEndYear = string.IsNullOrEmpty(exp.ExpEndYear) ? DateTime.Now.Year + 100 : int.Parse(exp.ExpEndYear);
                int expStartYear = string.IsNullOrEmpty(exp.ExpEndYear) ? this.retirementPlanningYearStartFrom : int.Parse(exp.ExpStartYear);
                if ((expStartYear > this.retirementPlanningYearStartFrom &&
                  expEndYear <= expectedLifeEndYear) ||
                   string.IsNullOrEmpty(exp.ExpStartYear))
                {
                    DataColumn dcExp = new DataColumn(exp.Item, typeof(System.Double));
                    dcExp.ReadOnly = true;
                    _dtRetirementCashFlow.Columns.Add(dcExp);
                }
            }

            _dtRetirementCashFlow.Columns.Add("Total Annual Expenses", typeof(System.Double));
            #endregion
        }
        private void addExpenesCalculation(int years, DataRow dr)
        {
            Logger.LogInfo("addExpenesCalculation for post retirment cash flow service start");
            double totalExpenses = 0;
            if (cashFlowCalculation.LstGoals != null)
            {
                int retirementGoalPriority;
                IEnumerable<Goals> retirementGoal = cashFlowCalculation.LstGoals.Where(i => i.Category == "Retirement");
                retirementGoalPriority = (retirementGoal.Count() > 0) ?  retirementGoal.ElementAt(0).Priority : 0 ;
                foreach (Goals goal in cashFlowCalculation.LstGoals)
                {
                    if (goal.Category == "Retirement" || int.Parse(goal.StartYear) == years)
                    {
                        if (goal.Priority >= retirementGoalPriority)
                        {
                            double retExp = getPostRetirementExpWithInfluationRate(dr, years, goal);
                            dr[goal.Name] = retExp;
                            totalExpenses = totalExpenses + retExp;
                        }
                    }
                }
            }
            IList<Expenses> expenses = new ExpensesInfo().GetAll(this.planner.ID);
            if (expenses != null)
            {
                foreach (Expenses exp in expenses)
                {
                    int expEndYear = string.IsNullOrEmpty(exp.ExpEndYear) ? DateTime.Now.Year + 100 : int.Parse(exp.ExpEndYear);
                    int expStartYear = string.IsNullOrEmpty(exp.ExpEndYear) ? years : int.Parse(exp.ExpStartYear);
                    if ((int.Parse(dr["StartYear"].ToString()) >= expStartYear &&
                       int.Parse(dr["StartYear"].ToString()) <= expEndYear) ||
                       string.IsNullOrEmpty(exp.ExpStartYear))
                    {
                        double expAmt = 0;
                        if (_dtRetirementCashFlow.Rows.Count > 0)
                        {
                            if (!double.TryParse(_dtRetirementCashFlow.Rows[_dtRetirementCashFlow.Rows.Count - 1][exp.Item].ToString(), out expAmt))
                            {
                                expAmt = exp.Amount;
                            }
                        }
                        else
                        {
                            expAmt = exp.Amount;
                        }
                        if (expStartYear == (int.Parse(dr["StartYear"].ToString())))
                        {
                            dr[exp.Item] = System.Math.Round(expAmt, 2);
                            totalExpenses = System.Math.Round(totalExpenses + expAmt, 2);
                        }
                        else
                        {
                            double expInflationRate = exp.InflationRate;
                            double expWithInflaction = expAmt + ((expAmt * expInflationRate) / 100);
                            dr[exp.Item] = System.Math.Round(expWithInflaction, 2);
                            totalExpenses = System.Math.Round(totalExpenses + expWithInflaction, 2);
                        }
                    }
                }
            }
            dr["Total Annual Expenses"] = totalExpenses;
        
            Logger.LogInfo("addExpenesCalculation for post retirment cash flow service end");
        }

        private double getPostRetirementExpWithInfluationRate(DataRow dr, int years, Goals goal)
        {
            double retExp = 0;
            int forYears = years - this.planner.StartDate.Year;
            if (int.Parse(goal.StartYear) == years)
            {
                retExp = futureValue(goal.Amount + goal.OtherAmount, goal.InflationRate, forYears);
            }
            else
            {
                if (_dtRetirementCashFlow.Rows.Count > 0)
                {
                    double previouYearExp = double.Parse(_dtRetirementCashFlow.Rows[_dtRetirementCashFlow.Rows.Count - 1][goal.Name].ToString());
                    retExp = previouYearExp + ((previouYearExp * double.Parse(plannerAssumption.PostRetirementInflactionRate.ToString())) / 100);
                }
            }
            return retExp;
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
