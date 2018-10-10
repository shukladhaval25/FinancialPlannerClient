using FinancialPlanner.Common;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.PlanOptions;
using FinancialPlannerClient.PlannerInfo;
using FinancialPlannerClient.PlanOptions;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlannerClient.CashFlowManager
{
    public class CashFlowService
    {
        private CashFlowCalculation _cashFlow = new CashFlowCalculation();
        private int _clientId, _planId;
        DataTable  _dtCashFlow;
        DataTable _dtCurrentStatusToGoal;
        private readonly string GETALL_API= "CashFlow/Get?optionId={0}";
        private readonly string ADD_CASHFLOW_API = "cashflow/Add";
        private readonly string UPDATE_CASHFLOW_API = "cashflow/update";
        private double _inflactionRatePercentage = 10;
        private Planner _planner;

        public CashFlowCalculation GetCashFlowData(int clientId, int planId)
        {
            _clientId = clientId;
            _planId = planId;

            ClientPersonalInfo clientPersonalInfo = new ClientPersonalInfo();
            PersonalInformation  personalInfo =  clientPersonalInfo.Get(clientId);
            var plannerInfo = new PlannerInfo.PlannerInfo();
            _planner = plannerInfo.GetPlanDataById(_planId);
            fillPersonalData(personalInfo);

            PlannerAssumption plannerAssumption =  new PlannerAssumptionInfo().GetAll(_planId);
            if (plannerAssumption != null)
                fillCashFlowFromPlannerAssumption(plannerAssumption);

            IList<Income> incomes = new IncomeInfo().GetAll(_planId);
            IList<Expenses> expenses = new ExpensesInfo().GetAll(_planId);
            IList<Loan> loans = new LoanInfo().GetAll(_planId);
            IList<Goals> goals = new GoalsInfo().GetAll(_planId);
            fillCashFlowFromIncomes(incomes);
            fillCashFlowFromExpenses(expenses);
            fillCashFlowFromLoans(loans);
            fillCashFlowFromGoals(goals);
            return _cashFlow;
        }

        private void fillCashFlowFromGoals(IList<Goals> goals)
        {
            _cashFlow.LstGoals = goals;
        }

        public CashFlow GetCashFlow(int optionId)
        {
            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
            string apiurl = Program.WebServiceUrl +"/"+ string.Format(GETALL_API,optionId);

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(apiurl);
            request.Method = "GET";
            String cashFlowJson = String.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);
                cashFlowJson = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
            }
            var cashFlowResult = jsonSerialization.DeserializeFromString<Result<CashFlow>>(cashFlowJson);

            if (cashFlowResult.Value != null)
            {
                return cashFlowResult.Value;
            }
            return null;
        }

        public DataTable GenerateCashFlow(int clientId, int planId)
        {
            _dtCashFlow = new DataTable();
            CashFlowCalculation cashFlow = GetCashFlowData(clientId,planId);
            if (cashFlow != null)
            {
                _dtCurrentStatusToGoal = new CurrentStatusToGoal().CurrentStatusToGoalCalculation(_planId);
                createTableCashFlowStructure();
                generateCashFlowData();
            }
            return _dtCashFlow;
        }

        private void generateCashFlowData()
        {
            int rowId = 1;
            addFirstRowData(rowId);
            if (_dtCashFlow.Rows.Count == 1)
            {
                addRowsBasedOnCalculation();
            }
        }

        private void addRowsBasedOnCalculation()
        {
            int noOfYearsForClient = _cashFlow.ClientRetirementAge - _cashFlow.ClientCurrentAge;
            int noOfYearsForSpouse = _cashFlow.SpouseRetirementAge - _cashFlow.SpouseCurrentAge;
            int noOfYearsForCalculation = (noOfYearsForClient >= noOfYearsForSpouse) ? noOfYearsForClient : noOfYearsForSpouse;
            for (int years = 1; years <= noOfYearsForCalculation; years++)
            {

                DataRow dr = _dtCashFlow.NewRow();
                addIncomeCalculation(years, dr);
                addExpenesCalculation(years, dr);
                addLoansCalculation(years, dr);
                addGoalsCalculation(years, dr);
                serSurplusAmount(dr);
                _dtCashFlow.Rows.Add(dr);
            }
        }

        private void addGoalsCalculation(int years, DataRow dr)
        {
            double totalLoanEmi = 0;
            foreach (Goals goal in _cashFlow.LstGoals)
            {
                //Get Future value of Goal
                GoalsCalculationInfo   goalCal = new GoalsCalculationInfo();
                double goalValue = goalCal.GetGoalFutureValue(goal);
                //1 Instrument Mapped
                double instrumentMappedAmount = 0;
                if (_dtCurrentStatusToGoal != null & _dtCurrentStatusToGoal.Rows.Count > 0)
                {
                    instrumentMappedAmount = double.Parse(_dtCurrentStatusToGoal.Select("GoalId = " + goal.Id)[0]["CurrentStatusMappedAmount"].ToString());
                }
                //2 Loan for Goal
                double loanForGoalValue = 0;
                double emi = 0;
                if (goal.LoanForGoal != null)
                {
                    loanForGoalValue = goal.LoanForGoal.LoanAmount;
                    if (years >= goal.LoanForGoal.StratYear)
                    {
                        dr[string.Format("(Loan EMI - {0})", goal.Name)] = goal.LoanForGoal.EMI;
                        totalLoanEmi = totalLoanEmi + goal.LoanForGoal.EMI;
                        emi = goal.LoanForGoal.EMI;
                    }
                }
               
                double totalPostTaxIncome = double.Parse(dr["Total Post Tax Income"].ToString());
                double totalExpAmount = double.Parse(dr["Total Annual Expenses"].ToString());
                double totalLoan = double.Parse(dr["Total Annual Loans"].ToString());
                //3 Cash Flow
                if ((totalPostTaxIncome - (totalExpAmount + totalLoan + totalLoanEmi)) > 0)
                {
                    dr[string.Format("{0} - {1}", goal.Priority, goal.Name)] = (totalPostTaxIncome - (totalExpAmount + totalLoan + totalLoanEmi));
                }
                //4 Current Assets
            }
        }
        private void serSurplusAmount(DataRow dr)
        {
            double totalPostTaxIncome = double.Parse(dr["Total Post Tax Income"].ToString());
            double totalExpAmount = double.Parse(dr["Total Annual Expenses"].ToString());
            double totalLoanAmount = double.Parse(dr["Total Annual Loans"].ToString());
            dr["Surplus Amount"] = totalPostTaxIncome - (totalExpAmount + totalLoanAmount);
        }

        private void addIncomeCalculation(int years, DataRow dr)
        {
            long totalIncome = 0;
            int incomeEndYear = 0;
            long totalTaxAmt = 0;
            long totalPostTaxIncome = 0;
            foreach (Income income in _cashFlow.LstIncomes)
            {
                incomeEndYear = string.IsNullOrEmpty(income.EndYear) ? DateTime.Now.Year + 100 : int.Parse(income.EndYear);
                if (int.Parse(dr["StartYear"].ToString()) >= int.Parse(income.StartYear) &&
                    int.Parse(dr["StartYear"].ToString()) <= incomeEndYear)
                {
                    try
                    {
                        long amount = long.Parse(_dtCashFlow.Rows[years - 1]["(" + income.IncomeBy + ") " + income.Source].ToString());
                        amount = amount + (long)((amount * float.Parse(income.ExpectGrowthInPercentage.ToString()) / 100));
                        dr["(" + income.IncomeBy + ") " + income.Source] = amount;
                        totalIncome = totalIncome + amount;

                        dr["(" + income.IncomeBy + ") " + income.Source + " - Income Tax"] = income.IncomeTax;
                        long incomeTaxAmt = ((amount *  long.Parse(income.IncomeTax.ToString()) / 100));
                        totalTaxAmt = totalTaxAmt + incomeTaxAmt;

                        long postTaxAmt =(amount - incomeTaxAmt);
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
            dr["Total Income"] = totalIncome;
            dr["Total Tax Deduction"] = totalTaxAmt;
            dr["Total Post Tax Income"] = totalPostTaxIncome;
        }

        private void addExpenesCalculation(int years, DataRow dr)
        {
            double totalExpenses = 0;
            foreach (Expenses exp in _cashFlow.LstExpenses)
            {
                double expAmt = double.Parse(_dtCashFlow.Rows[years - 1][exp.Item].ToString());
                double expWithInflaction =  expAmt + ((expAmt * _inflactionRatePercentage)/100);
                dr[exp.Item] = expWithInflaction;
                totalExpenses = totalExpenses + expWithInflaction;
            }
            dr["Total Annual Expenses"] = totalExpenses;
        }

        private void addLoansCalculation(int years, DataRow dr)
        {
            double totalLoans = 0;
            foreach (Loan loan in _cashFlow.LstLoans)
            {
                if (int.Parse(dr["StartYear"].ToString()) <=
                   int.Parse(_dtCashFlow.Rows[0]["StartYear"].ToString()) + (loan.TermLeftInMonths / 12))
                {
                    double loanAmt = double.Parse(_dtCashFlow.Rows[years - 1][loan.TypeOfLoan].ToString());
                    dr[loan.TypeOfLoan] = loanAmt;
                    totalLoans = totalLoans + loanAmt;
                }
            }
            dr["Total Annual Loans"] = totalLoans;
        }

        private void addFirstRowData(int rowId)
        {
            DataRow dr = _dtCashFlow.NewRow();
            dr["ID"] = rowId;
            dr["StartYear"] = _planner.StartDate.Year;

            #region "Add Incomes"
            double totalIncome = 0;
            double totalpostTaxIncome  = 0;
            double totalTaxAmt = 0;
            foreach (Income income in _cashFlow.LstIncomes)
            {
                dr["(" + income.IncomeBy + ") " + income.Source] = income.Amount;
                totalIncome = totalIncome + income.Amount;
                dr["(" + income.IncomeBy + ") " + income.Source + " - Income Tax"] = income.IncomeTax;
                double taxAmt = (income.Amount * income.IncomeTax) / 100;
                totalTaxAmt = totalTaxAmt + taxAmt;
                dr["(" + income.IncomeBy + ") " + income.Source + " - Post Tax"] = income.Amount - taxAmt;
                totalpostTaxIncome = totalpostTaxIncome + (income.Amount - taxAmt);
            }
            dr["Total Income"] = totalIncome;
            dr["Total Tax Deduction"] = totalTaxAmt;
            dr["Total Post Tax Income"] = totalpostTaxIncome;
            #endregion

            #region "Add Expenses"

            double totalExpenses = 0;
            foreach (Expenses exp in _cashFlow.LstExpenses)
            {

                double expAmt = (exp.OccuranceType == ExpenseType.Monthly) ? exp.Amount * 12 : exp.Amount;
                dr[exp.Item] = expAmt;
                totalExpenses = totalExpenses + expAmt;
            }
            dr["Total Annual Expenses"] = totalExpenses;

            #endregion

            #region "Add Loans"

            double totalLoan = 0;
            foreach (Loan loan in _cashFlow.LstLoans)
            {
                double loanAmt = loan.Emis * 12;
                dr[loan.TypeOfLoan] = loanAmt;
                totalLoan = totalLoan + loanAmt;
            }
            dr["Total Annual Loans"] = totalLoan;

            #endregion

            #region "Add Goals"
          
            double totalLoanEmi = 0;
            foreach (Goals goal in _cashFlow.LstGoals)
            {
                //Get Future value of Goal
                GoalsCalculationInfo   goalCal = new GoalsCalculationInfo();
                double goalValue = goalCal.GetGoalFutureValue(goal);
                //1 Instrument Mapped
                double instrumentMappedAmount = 0;
                if (_dtCurrentStatusToGoal != null & _dtCurrentStatusToGoal.Rows.Count > 0)
                {
                    instrumentMappedAmount = double.Parse(_dtCurrentStatusToGoal.Select("GoalId = " + goal.Id)[0]["CurrentStatusMappedAmount"].ToString());
                }
                //2 Loan for Goal
                double loanForGoalValue = 0;
                double emi = 0;
                if (goal.LoanForGoal != null)
                {
                    loanForGoalValue = goal.LoanForGoal.LoanAmount;
                    if (_planner.StartDate.Year >= goal.LoanForGoal.StratYear)
                    {
                        dr[string.Format("(Loan EMI - {0})", goal.Name)] = goal.LoanForGoal.EMI;
                        totalLoanEmi = totalLoanEmi + goal.LoanForGoal.EMI;
                        emi = goal.LoanForGoal.EMI;
                    }
                }
                //3 Cash Flow
                if ((totalpostTaxIncome - (totalExpenses + totalLoan + totalLoanEmi)) > 0)
                {
                    dr[string.Format("{0} - {1}", goal.Priority, goal.Name)] = (totalpostTaxIncome - (totalExpenses + totalLoan + totalLoanEmi));
                }
                //4 Current Assets
            }
            #endregion
            dr["Surplus Amount"] = totalpostTaxIncome - (totalExpenses + totalLoan +  totalLoanEmi);
            _dtCashFlow.Rows.Add(dr);
        }

        private void fillCashFlowFromIncomes(IList<Income> incomes)
        {
            _cashFlow.LstIncomes = incomes;
        }

        private void fillCashFlowFromExpenses(IList<Expenses> expenses)
        {
            _cashFlow.LstExpenses = expenses;
        }

        private void fillCashFlowFromLoans(IList<Loan> loans)
        {
            _cashFlow.LstLoans = loans;
        }

        private void fillCashFlowFromPlannerAssumption(PlannerAssumption plannerAssumption)
        {
            _cashFlow.ClientLifeExpected = plannerAssumption.ClientLifeExpectancy;
            _cashFlow.ClientRetirementAge = plannerAssumption.ClientRetirementAge;
            _cashFlow.SpouseLifeExpected = plannerAssumption.SpouseLifeExpectancy;
            _cashFlow.SpouseRetirementAge = plannerAssumption.SpouseRetirementAge;
        }

        private void fillPersonalData(PersonalInformation personalInfo)
        {
            _cashFlow.Pid = _planId;
            _cashFlow.Cid = personalInfo.Client.ID;
            _cashFlow.ClientName = personalInfo.Client.Name;
            _cashFlow.ClientDateOfBirth = personalInfo.Client.DOB;

            if (personalInfo.Spouse != null)
            {
                _cashFlow.Sid = personalInfo.Spouse.ID;
                _cashFlow.SpouseName = personalInfo.Spouse.Name;
                _cashFlow.SpouseDateOfBirth = personalInfo.Spouse.DOB;
            }
        }

        private void createTableCashFlowStructure()
        {
            DataColumn dcId = new DataColumn("Id",typeof(System.Int16));
            dcId.AutoIncrement = true;
            dcId.ReadOnly = true;
            _dtCashFlow.Columns.Add(dcId);


            DataColumn dcYear = new DataColumn("StartYear",typeof(System.Int16));
            dcYear.AutoIncrement = true;
            dcYear.ReadOnly = true;
            _dtCashFlow.Columns.Add(dcYear);

            DataColumn dcEndYear = new DataColumn("EndYear",typeof(System.Int16),"StartYear + 1");
            dcEndYear.ReadOnly = true;
            _dtCashFlow.Columns.Add(dcEndYear);

            #region "Income Calculation"
            foreach (Income income in _cashFlow.LstIncomes)
            {
                DataColumn dcIncome = new DataColumn("("+ income.IncomeBy + ") " + income.Source,typeof(System.Double));
                dcIncome.ReadOnly = true;
                _dtCashFlow.Columns.Add(dcIncome);
                DataColumn dcIncomeTax = new DataColumn(dcIncome.ColumnName + " - Income Tax",typeof (System.Decimal));
                _dtCashFlow.Columns.Add(dcIncomeTax);
                DataColumn postTaxIncome = new DataColumn(dcIncome.ColumnName + " - Post Tax" ,typeof(System.Double));
                _dtCashFlow.Columns.Add(postTaxIncome);
            }

            DataColumn dcTotal = new DataColumn("Total Income",typeof(System.Double));
            dcTotal.ReadOnly = true;
            _dtCashFlow.Columns.Add(dcTotal);

            _dtCashFlow.Columns.Add("Total Tax Deduction", typeof(System.Double));
            _dtCashFlow.Columns.Add("Total Post Tax Income", typeof(System.Double));
            #endregion 

            #region "Expenses Calculation" 
            foreach (Expenses exp in _cashFlow.LstExpenses)
            {
                DataColumn dcExp = new DataColumn(exp.Item ,typeof(System.Double));
                dcExp.ReadOnly = true;
                _dtCashFlow.Columns.Add(dcExp);
            }
            _dtCashFlow.Columns.Add("Total Annual Expenses", typeof(System.Double));
            #endregion

            #region "Loan Calculation"
            foreach (Loan loan in _cashFlow.LstLoans)
            {
                DataColumn dcloan = new DataColumn( loan.TypeOfLoan,typeof(System.Double));
                dcloan.ReadOnly = true;
                _dtCashFlow.Columns.Add(dcloan);
            }
            _dtCashFlow.Columns.Add("Total Annual Loans", typeof(System.Double));
            #endregion

            _dtCashFlow.Columns.Add("Surplus Amount", typeof(System.Double));

            #region"Goals
            _cashFlow.LstGoals.OrderBy(x => x.Priority);
            foreach (Goals goal in _cashFlow.LstGoals)
            {
                DataColumn dcGoal = new DataColumn(string.Format("{0} - {1}",goal.Priority, goal.Name),typeof(System.Double));
                _dtCashFlow.Columns.Add(dcGoal);

                if (goal.LoanForGoal != null && goal.LoanForGoal.EMI > 0)
                {
                    DataColumn dtLoanForGoal = new DataColumn(string.Format("(Loan EMI - {0})",goal.Name),typeof(System.Double));
                    _dtCashFlow.Columns.Add(dtLoanForGoal);
                }
            }

            #endregion

            _dtCashFlow.Columns.Add("Additional Amount", typeof(System.Double));
        }

        internal bool Save(CashFlow cf)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = "";
                apiurl = (cf.Id == 0) ? Program.WebServiceUrl + "/" + ADD_CASHFLOW_API :
                    Program.WebServiceUrl + "/" + UPDATE_CASHFLOW_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<CashFlow>(apiurl, cf, "POST");
                return true;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace ();
                StackFrame sf = st.GetFrame (0);
                MethodBase  currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                return false;
            }
        }

        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }
    }
}