using FinancialPlanner.Common;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.CurrentStatus;
using FinancialPlanner.Common.Model.PlanOptions;
using FinancialPlannerClient.CurrentStatus;
using FinancialPlannerClient.PlannerInfo;
using FinancialPlannerClient.PlanOptions;
using FinancialPlannerClient.RiskProfile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows.Forms;
using CurrentStatusToGoal = FinancialPlannerClient.PlanOptions.CurrentStatusToGoal;
//using CurrentStatusToGoal = FinancialPlanner.Common.Model.PlanOptions.CurrentStatusToGoal;

namespace FinancialPlannerClient.CashFlowManager
{
    public class CashFlowService
    {
        private CashFlowCalculation _cashFlowCalculation = new CashFlowCalculation();
        private int _clientId, _planId, _riskProfileId, _optionId;
        DataTable _dtCashFlow;
        private readonly string GETALL_API = "CashFlow/Get?optionId={0}";
        private readonly string ADD_CASHFLOW_API = "cashflow/Add";
        private readonly string UPDATE_CASHFLOW_API = "cashflow/update";
        private Planner _planner;
        public GoalCalculationManager GoalCalculationMgr;
        private RiskProfileInfo _riskProfileInfo;
        PersonalInformation personalInfo;

        public CashFlowCalculation GetCashFlowData(int clientId, int planId, int riskProfileId)
        {
            _clientId = clientId;
            _planId = planId;
            _riskProfileId = riskProfileId;

            ClientPersonalInfo clientPersonalInfo = new ClientPersonalInfo();

            Logger.LogInfo("GetCashFlowData>>Get personal information for client id" + clientId);
            personalInfo = clientPersonalInfo.Get(clientId);

            Logger.LogInfo("GetCashFlowData>>fill personal information for client id" + clientId);
            fillPersonalData(personalInfo);

            _riskProfileInfo = new RiskProfileInfo();

            Logger.LogInfo("GetCashFlowData>>Get planner assumption for plan id" + _planId);
            PlannerAssumption plannerAssumption = new PlannerAssumptionInfo().GetAll(_planId);
            if (plannerAssumption != null)
            {
                fillCashFlowFromPlannerAssumption(plannerAssumption);
            }
            else
            {
                Logger.LogInfo("GetCashFlowData>>Planner assumption is null plan id" + _planId);
            }
            IList<Income> incomes = new IncomeInfo().GetAll(_planId);
            IList<Expenses> expenses = new ExpensesInfo().GetAll(_planId);
            IList<LifeInsurance> lifeInsurances = new LifeInsuranceInfo().GetAllLifeInsurance(_planId);
            IList<GeneralInsurance> generalInsurances = new GeneralInsuranceInfo().GetAllGeneralInsurances(_planId);
            IList<Loan> loans = new LoanInfo().GetAll(_planId);
            IList<Goals> goals = new GoalsInfo().GetAll(_planId);

            fillCashFlowFromIncomes(incomes);
            fillCashFlowFromExpenses(expenses);
            fillLifeInsurance(lifeInsurances);
            fillGeneranceInsurance(generalInsurances);
            fillCashFlowFromLoans(loans);
            fillCashFlowFromGoals(goals);
            return _cashFlowCalculation;
        }

        internal double GetCurrentStatusAccessFund()
        {
            double totalAccessCurrentStatusValue = 0;
            CurrentStatusToGoal csGoal = new CurrentStatusToGoal();
            DataTable dtCurrentStatustoGoals = csGoal.CurrentStatusToGoalCalculation(_planId);
            IList<FinancialPlanner.Common.Model.PlanOptions.CurrentStatusToGoal> currentStatusToGoal = new CurrentStatusInfo().GetCurrentStatusToGoal(_optionId, _planId);

            if (currentStatusToGoal != null)
            {

                DataTable dtGoalMapped = ListtoDataTable.ToDataTable(currentStatusToGoal.ToList());
                double totalCurrentStatusFund = getTotalCurrentSatusSurplusValue(dtCurrentStatustoGoals);
                double mappedValueFromCurrentStatusFundByManager = getTotalFundAllocationValue(dtCurrentStatustoGoals, dtGoalMapped);
                //TODO: Add Contingency  fund logic
                double contingency = new CurrentStatusInfo().GetContingencyFund(this._optionId, this._planId).Amount;
                totalAccessCurrentStatusValue = totalCurrentStatusFund - (mappedValueFromCurrentStatusFundByManager + contingency);
            }
            
            for (int rowIndex = 0; rowIndex <= _dtCashFlow.Rows.Count; rowIndex++)
            {
                double returnRate = (double)_riskProfileInfo.GetRiskProfileReturnRatio(this._riskProfileId,
                    ((_dtCashFlow.Rows.Count) - rowIndex));

                totalAccessCurrentStatusValue = totalAccessCurrentStatusValue + (totalAccessCurrentStatusValue * (returnRate / 100 ));
            }
            return totalAccessCurrentStatusValue;
        }

        private double getTotalFundAllocationValue(DataTable dtCurrentStatustoGoals,DataTable dtGoalMapped)
        {
            double alredyMappedValue = dtCurrentStatustoGoals.AsEnumerable().Sum(x => Convert.ToDouble(x["CurrentStatusMappedAmount"]));
            double mappedByProjetManager = dtGoalMapped.AsEnumerable().Sum(x => Convert.ToDouble(x["FundAllocation"]));
            return alredyMappedValue + mappedByProjetManager;
        }

        private double getTotalCurrentSatusSurplusValue(DataTable dtCurrentStatustoGoals)
        {
            double totalCurrentStatusValue = 0;
            if (dtCurrentStatustoGoals.Rows.Count > 0)
            {
                totalCurrentStatusValue = string.IsNullOrEmpty(dtCurrentStatustoGoals.Rows[0]["ExcessFund"].ToString()) ? 0 :
                double.Parse(dtCurrentStatustoGoals.Rows[0]["ExcessFund"].ToString());
                double alreadyMappedValue = dtCurrentStatustoGoals.AsEnumerable().Sum(x => Convert.ToDouble(x["CurrentStatusMappedAmount"]));
                totalCurrentStatusValue = totalCurrentStatusValue + alreadyMappedValue;
            }
            return Math.Round(totalCurrentStatusValue, 2);
        }

        private void fillLifeInsurance(IList<LifeInsurance> lifeInsurances)
        {
            _cashFlowCalculation.LstLifeInsurances = lifeInsurances;
        }

        private void fillGeneranceInsurance(IList<GeneralInsurance> generalInsurances)
        {
            _cashFlowCalculation.LstGeneralInsurances = generalInsurances;
        }

        private void fillCashFlowFromGoals(IList<Goals> goals)
        {
            _cashFlowCalculation.LstGoals = goals;
        }

        public CashFlow GetCashFlow(int optionId)
        {
            Logger.LogInfo("Send request for get cash flow with option id:" + optionId);
            _optionId = optionId;
            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
            string apiurl = Program.WebServiceUrl + "/" + string.Format(GETALL_API, optionId);

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
                Logger.LogInfo("Get response for get cash flow with option id:" + optionId);
                return cashFlowResult.Value;
            }
            Logger.LogInfo("Get response for get cash flow with option id:" + optionId + " is Null");
            return null;
        }

        public DataTable GenerateCashFlow(int clientId, int planId, int riskProfileId)
        {
            _dtCashFlow = new DataTable();
            var plannerInfo = new PlannerInfo.PlannerInfo();
            _planId = planId;
            _planner = plannerInfo.GetPlanDataById(planId);
            _riskProfileInfo = new RiskProfileInfo();
            GoalCalculationMgr = new GoalCalculationManager(_planner, _riskProfileInfo, riskProfileId);
            CashFlowCalculation cashFlow = GetCashFlowData(clientId, planId, riskProfileId);
            if (cashFlow != null)
            {
                createTableCashFlowStructure();
                generateCashFlowData();
            }
            return _dtCashFlow;
        }

        public DataTable GetCashFlowTable()
        {
            return _dtCashFlow;
        }

        public CashFlowCalculation GetCashFlowCalculation()
        {
            return _cashFlowCalculation;
        }
        public PersonalInformation GetPersonalInformation()
        {
            return this.personalInfo;
        }
        public double GetCashFlowSurplusAmount()
        {
            double surplusCashFund = 0;
            try
            {
                if (_dtCashFlow != null && _dtCashFlow.Rows.Count > 0)
                {

                    surplusCashFund = string.IsNullOrEmpty(_dtCashFlow.Rows[_dtCashFlow.Rows.Count - 1]["Cumulative Corpus Fund"].ToString()) ? 0 :
                        double.Parse(_dtCashFlow.Rows[_dtCashFlow.Rows.Count - 1]["Cumulative Corpus Fund"].ToString());
                }
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                MessageBox.Show(ex.ToString());
            }
            return Math.Round(surplusCashFund, 2);
        }
        public DataRow GetLastIncomeAndExpAtRetirementAge()
        {
            DataRow dr = null;
            if (_dtCashFlow != null && _dtCashFlow.Rows.Count > 0)
            {
                dr = _dtCashFlow.Rows[_dtCashFlow.Rows.Count - 1];
            }
            return dr;
        }

        private void generateCashFlowData()
        {
            try
            {
                int rowId = 1;
                addFirstRowData(rowId);
                if (_dtCashFlow.Rows.Count == 1)
                {
                    addRowsBasedOnCalculation();
                }
            }
            catch (Exception ex)
            {
                Logger.LogDebug(ex.ToString());
                MessageBox.Show(ex.ToString());
            }
        }

        private void addRowsBasedOnCalculation()
        {
            int noOfYearsForClient = (_cashFlowCalculation.ClientRetirementAge)- _cashFlowCalculation.ClientCurrentAge;
            int noOfYearsForSpouse = (_cashFlowCalculation.SpouseRetirementAge) - _cashFlowCalculation.SpouseCurrentAge;
            //int noOfYearsForCalculation = (noOfYearsForClient >= noOfYearsForSpouse) ? noOfYearsForClient : noOfYearsForSpouse;
            int noOfYearsForCalculation = (_cashFlowCalculation.IslientRetirmentAgeForPrimaryCalculation) ? noOfYearsForClient : noOfYearsForSpouse;
            for (int years = 1; years <= noOfYearsForCalculation; years++)
            {

                DataRow dr = _dtCashFlow.NewRow();
                addIncomeCalculation(years, dr, noOfYearsForClient, noOfYearsForSpouse);
                addExpenesCalculation(years, dr);
                addLoansCalculation(years, dr);
                addGoalsCalculation(years, dr);
                setSurplusAmount(dr);
                //validateSurplusAmount(years,dr);
                setComulativeCorpusFundIfSurplusAmountIsNegative(years, dr);
                setComulativeCorpusFund(years, dr, noOfYearsForCalculation);
                _dtCashFlow.Rows.Add(dr);
            }
        }

        private void setComulativeCorpusFundIfSurplusAmountIsNegative(int years, DataRow dr)
        {
            double currentYearSurplusAmount = 0;
            int calculationYear = int.Parse(dr["StartYear"].ToString());
            double.TryParse(dr["Surplus Amount"].ToString(), out currentYearSurplusAmount);
            double totalGoalLoanEMIs = 0;

            if (currentYearSurplusAmount > 0)
            {
                foreach (Goals goal in _cashFlowCalculation.LstGoals)
                {
                    if (goal.LoanForGoal != null)
                    {
                        if (calculationYear >= goal.LoanForGoal.StratYear &&
                            calculationYear < goal.LoanForGoal.EndYear)
                        {
                            double emiAmt = 0;
                            dr[string.Format("(Loan EMI - {0})", goal.Name)] = (goal.LoanForGoal.EMI * 12);
                            emiAmt = (goal.LoanForGoal.EMI * 12);
                            totalGoalLoanEMIs = totalGoalLoanEMIs + emiAmt;
                        }
                    }
                }
                currentYearSurplusAmount = currentYearSurplusAmount - totalGoalLoanEMIs;
            }

            if (currentYearSurplusAmount < 0)
            {
                for(int index = _dtCashFlow.Rows.Count -1; index >= 0; index--)
                {
                    double previousYearCorpusFund = 0;
                    double.TryParse(_dtCashFlow.Rows[index]["Cumulative Corpus Fund"].ToString(),out previousYearCorpusFund);
                    if (previousYearCorpusFund > 0 && (previousYearCorpusFund - System.Math.Abs(currentYearSurplusAmount)) > 0)
                    {
                        _dtCashFlow.Rows[index]["Cumulative Corpus Fund"] = previousYearCorpusFund - System.Math.Abs(currentYearSurplusAmount);
                        double previousYearAdjustedAmount = 0;
                        double.TryParse(_dtCashFlow.Rows[index]["Adjusted Amount"].ToString(), out previousYearAdjustedAmount);
                        _dtCashFlow.Rows[index]["Adjusted Amount"] = previousYearAdjustedAmount + System.Math.Abs(currentYearSurplusAmount);
                        break;
                    }
                    else
                    {
                        dr["Corpus Fund"] = currentYearSurplusAmount;
                        if (_dtCashFlow.Rows.Count == 1)
                        {
                            dr["Cumulative Corpus Fund"] = currentYearSurplusAmount + double.Parse(_dtCashFlow.Rows[_dtCashFlow.Rows.Count - 1]["Corpus Fund"].ToString());
                            break;
                        }
                    }
                }
            }
        }

        private void validateSurplusAmount(int years,DataRow dr)
        {
            double currentYearSurplusAmount = 0;
            int calculationYear = int.Parse(dr["StartYear"].ToString());
            double.TryParse(dr["Surplus Amount"].ToString(),out currentYearSurplusAmount);
            double totalGoalLoanEMIs = 0;
            foreach (Goals goal in _cashFlowCalculation.LstGoals)
            {
                if (goal.LoanForGoal != null)
                {
                    if (calculationYear >= goal.LoanForGoal.StratYear &&
                        calculationYear < goal.LoanForGoal.EndYear)
                    {
                        double emiAmt = 0;
                        dr[string.Format("(Loan EMI - {0})", goal.Name)] = (goal.LoanForGoal.EMI * 12);
                        emiAmt = (goal.LoanForGoal.EMI * 12);
                        totalGoalLoanEMIs = totalGoalLoanEMIs + emiAmt;
                    }
                }
            }

            currentYearSurplusAmount = currentYearSurplusAmount - totalGoalLoanEMIs;


            if (currentYearSurplusAmount < 0)
            {
                double previousYearSurplusAmount = 0;
                double.TryParse(_dtCashFlow.Rows[years - 1]["Surplus Amount"].ToString(), out previousYearSurplusAmount);
                if (previousYearSurplusAmount > 0)
                {
                    currentYearSurplusAmount = System.Math.Abs(currentYearSurplusAmount);
                    if (previousYearSurplusAmount >= currentYearSurplusAmount)
                    {

                        if (_cashFlowCalculation.LstGoals != null)
                        {
                            var orderByDescendingResult = from s in _cashFlowCalculation.LstGoals
                                                          orderby s.Priority descending
                                                          select s;
                            double totalAmountSettleFromPreviousYear = 0;
                            foreach (Goals goal in orderByDescendingResult)
                            {
                                double previousYearFundAllocatedAmount = 0;
                                if (_dtCashFlow.Columns.Contains(string.Format("{0} - {1}", goal.Priority, goal.Name)))
                                {
                                    double.TryParse(_dtCashFlow.Rows[years - 1][string.Format("{0} - {1}", goal.Priority, goal.Name)].ToString(), out previousYearFundAllocatedAmount);
                                    if (previousYearFundAllocatedAmount > 0)
                                    {
                                        if (previousYearFundAllocatedAmount > currentYearSurplusAmount)
                                        {
                                            totalAmountSettleFromPreviousYear = totalAmountSettleFromPreviousYear + previousYearFundAllocatedAmount;
                                            _dtCashFlow.Rows[years - 1][string.Format("{0} - {1}", goal.Priority, goal.Name)] =
                                                totalAmountSettleFromPreviousYear - currentYearSurplusAmount;

                                            GoalsValueCalculationInfo  goalsValueCalculationInfo  =  GoalCalculationMgr.GetGoalValueCalculation(goal);

                                            int calculationyear = int.Parse(_dtCashFlow.Rows[years - 1]["StartYear"].ToString());
                                            GoalPlanning goalPlanning =   goalsValueCalculationInfo.GetGoalPlanning(calculationyear);
                                            GoalPlanning updatedGoalPlanning = goalPlanning;
                                            updatedGoalPlanning.ActualFreshInvestment = totalAmountSettleFromPreviousYear - currentYearSurplusAmount;


                                            goalsValueCalculationInfo.UpdateGoalPlanning(goalPlanning,updatedGoalPlanning); 
                                            break;
                                        }
                                        else
                                        {
                                            if (totalAmountSettleFromPreviousYear + previousYearFundAllocatedAmount <= currentYearSurplusAmount)
                                            {
                                                _dtCashFlow.Rows[years - 1][string.Format("{0} - {1}", goal.Priority, goal.Name)] = 0;
                                                totalAmountSettleFromPreviousYear = totalAmountSettleFromPreviousYear + previousYearFundAllocatedAmount;
                                            }
                                            else
                                            {
                                                //50000             //  48000        //52000
                                                previousYearFundAllocatedAmount = previousYearFundAllocatedAmount -(currentYearSurplusAmount - totalAmountSettleFromPreviousYear);
                                                _dtCashFlow.Rows[years - 1][string.Format("{0} - {1}", goal.Priority, goal.Name)] = previousYearFundAllocatedAmount;

                                            }
                                        }
                                    }
                                }
                            }
                        }
                        
                        // actualSurplusAmount = previousYearSurplusAmount - currentYearSurplusAmount;
                        //_dtCashFlow.Rows[years - 1]["Surplus Amount"] = actualSurplusAmount;
                        // dr["Surplus Amount"] = 0;
                         dr["Adjusted Amount"] = currentYearSurplusAmount;

                    }
                }
            }
        }

        private void setComulativeCorpusFund(int years, DataRow dr, int noOfYearsForCalculation)
        {
            if (_dtCashFlow.Rows.Count > 0)
            {
                double previousYearCumulativeCorpusFund = string.IsNullOrEmpty(_dtCashFlow.Rows[_dtCashFlow.Rows.Count - 1]["Cumulative Corpus Fund"].ToString()) ? 0 :
                    double.Parse(_dtCashFlow.Rows[_dtCashFlow.Rows.Count - 1]["Cumulative Corpus Fund"].ToString());
                double returnRate = (double)_riskProfileInfo.GetRiskProfileReturnRatio(this._riskProfileId, noOfYearsForCalculation - (years - 1));
                double currentYearCorpusFund = (string.IsNullOrEmpty(dr["Corpus Fund"].ToString()) ? 0 : double.Parse(dr["Corpus Fund"].ToString()));
                double cumulativeCorpusFund = 0;
                cumulativeCorpusFund = ((currentYearCorpusFund + previousYearCumulativeCorpusFund) > 0) ?
                currentYearCorpusFund + previousYearCumulativeCorpusFund + ((previousYearCumulativeCorpusFund * returnRate) / (100)) : (currentYearCorpusFund + previousYearCumulativeCorpusFund);
                dr["Cumulative Corpus Fund"] = Math.Round(cumulativeCorpusFund, 2);
            }
        }

        private void addGoalsCalculation(int years, DataRow dr)
        {
            double totalLoanEmi = 0;
            int calculationYear = int.Parse(dr["StartYear"].ToString());
            double surplusAmount = getSurplusAmount(dr);
            if (_cashFlowCalculation.LstGoals != null)
            {
                foreach (Goals goal in _cashFlowCalculation.LstGoals)
                {
                    if (goal.LoanForGoal != null)
                    {
                        if (calculationYear >= goal.LoanForGoal.StratYear &&
                            calculationYear <= goal.LoanForGoal.EndYear)
                        {
                            dr[string.Format("(Loan EMI - {0})", goal.Name)] = (goal.LoanForGoal.EMI * 12);
                            totalLoanEmi = totalLoanEmi + (goal.LoanForGoal.EMI * 12);
                            surplusAmount = surplusAmount - (goal.LoanForGoal.EMI * 12);
                        }
                    }
                   
                    if (surplusAmount > 0 &&
                         (calculationYear < int.Parse(goal.StartYear)))
                    {

                        GoalsValueCalculationInfo goalValCalInfo = GoalCalculationMgr.GetGoalValueCalculation(goal);
                        if (goalValCalInfo == null)
                        {
                            goalValCalInfo = new GoalsValueCalculationInfo(goal, _planner, _riskProfileInfo, _riskProfileId, this._optionId, this);
                            GoalCalculationMgr.AddGoalValueCalculation(goalValCalInfo);
                        }
                        GoalsCalculationInfo goalcalInfo = new GoalsCalculationInfo(goal, _planner, _riskProfileInfo, _riskProfileId, _optionId);
                        goalValCalInfo.SetPortfolioValue(goalcalInfo.GetProfileValue());
                        double surplusAmountAfterInvestment = goalValCalInfo.SetInvestmentToAchiveGoal(calculationYear, surplusAmount);
                        dr[string.Format("{0} - {1}", goal.Priority, goal.Name)] = Math.Round(surplusAmount - surplusAmountAfterInvestment, 2,
                                                 MidpointRounding.ToEven);
                        surplusAmount = surplusAmountAfterInvestment;

                    }
                    if (goal.Category == "Retirement")
                    {
                        dr["Corpus Fund"] = string.IsNullOrEmpty(dr[string.Format("{0} - {1}", goal.Priority, goal.Name)].ToString()) ? 0 :
                            double.Parse(dr[string.Format("{0} - {1}", goal.Priority, goal.Name)].ToString());
                    }
                }
            }
            dr["Corpus Fund"] = string.IsNullOrEmpty(dr["Corpus Fund"].ToString()) ?
                ((surplusAmount > 0) ? Math.Round(surplusAmount, 2) : 0) :
                double.Parse(dr["Corpus Fund"].ToString()) + ((surplusAmount > 0) ? Math.Round(surplusAmount, 2) : 0);
        }
        private void setSurplusAmount(DataRow dr)
        {
            double totalPostTaxIncome = double.Parse(dr["Total Post Tax Income"].ToString());
            double totalExpAmount = double.Parse(dr["Total Annual Expenses"].ToString());
            double totalLoanAmount = double.Parse(dr["Total Annual Loans"].ToString());
            double totalGoalLoanEMIs = 0;
            //if (_cashFlowCalculation.LstGoals != null)
            //{
            //    foreach (Goals goal in _cashFlowCalculation.LstGoals)
            //    {
            //        if (goal.LoanForGoal != null)
            //        {
            //            double emiAmt = 0;
            //            double.TryParse(dr[string.Format("(Loan EMI - {0})", goal.Name)].ToString(), out emiAmt);
            //            totalGoalLoanEMIs = totalGoalLoanEMIs + emiAmt;
            //        }
            //    }
            //}
            
            dr["Surplus Amount"] = totalPostTaxIncome - (totalExpAmount + totalLoanAmount + totalGoalLoanEMIs);
        }
        private double getSurplusAmount(DataRow dr)
        {
            int calculationYear = int.Parse(dr["StartYear"].ToString());
            double totalPostTaxIncome = double.Parse(dr["Total Post Tax Income"].ToString());
            double totalExpAmount = double.Parse(dr["Total Annual Expenses"].ToString());
            double totalLoanAmount = double.Parse(dr["Total Annual Loans"].ToString());
            double totalGoalLoanEMIs = 0;
            double totalInvestmentInGoals = 0;
            if (_cashFlowCalculation.LstGoals != null)
            {
                foreach (Goals goal in _cashFlowCalculation.LstGoals)
                {
                    //if (goal.LoanForGoal != null)
                    //{
                    //    if (calculationYear >= goal.LoanForGoal.StratYear &&
                    //        calculationYear < goal.LoanForGoal.EndYear)
                    //    {
                    //        double emiAmt = 0;
                    //        dr[string.Format("(Loan EMI - {0})", goal.Name)] = (goal.LoanForGoal.EMI * 12);
                    //        emiAmt = (goal.LoanForGoal.EMI * 12);
                    //        totalGoalLoanEMIs = totalGoalLoanEMIs + emiAmt;
                    //    }
                    //}

                    double investmentAmt = 0;
                    double.TryParse(dr[string.Format("{0} - {1}", goal.Priority, goal.Name)].ToString(), out investmentAmt);
                    totalInvestmentInGoals = totalInvestmentInGoals + investmentAmt;

                }
            }
            return totalPostTaxIncome - (totalExpAmount + totalLoanAmount + totalGoalLoanEMIs + totalInvestmentInGoals);
        }
        private void addIncomeCalculation(int years, DataRow dr, int clientRetYear, int spouseRetYear)
        {
            long totalIncome = 0;
            int incomeEndYear = 0;
            long totalTaxAmt = 0;
            long totalPostTaxIncome = 0;
            if (_cashFlowCalculation.LstIncomes != null)
            {
                foreach (Income income in _cashFlowCalculation.LstIncomes)
                {
                    incomeEndYear = string.IsNullOrEmpty(income.EndYear) ? DateTime.Now.Year + 100 : int.Parse(income.EndYear);
                    if (int.Parse(dr["StartYear"].ToString()) >= int.Parse(income.StartYear) &&
                        int.Parse(dr["StartYear"].ToString()) <= incomeEndYear)
                    {
                        if (isIncomeValidaForYear(income, years, clientRetYear, spouseRetYear))
                        {
                            try
                            {
                                long amount = 0;
                                long.TryParse(_dtCashFlow.Rows[years - 1]["(" + income.IncomeBy + ") " + income.Source].ToString(), out amount);
                                if (amount == 0 && income.StartYear == dr["StartYear"].ToString())
                                    long.TryParse(income.Amount.ToString(), out amount);
                                else
                                {
                                    if (income.ExpectedGrowthType.Equals("P"))
                                    {
                                        amount = amount + (long)((amount * float.Parse(income.ExpectGrowthInPercentage.ToString()) / 100));
                                       
                                    }
                                    else
                                    {
                                        amount = amount + (long)income.ExpectedGrwothInAmount;
                                    }
                                }
                                dr["(" + income.IncomeBy + ") " + income.Source] = amount;
                                totalIncome = totalIncome + amount;

                                dr["(" + income.IncomeBy + ") " + income.Source + " - Income Tax"] = income.IncomeTax;
                                var incomeTaxPercentage = (income.IncomeTax / 100);
                                long incomeTaxAmt = (long)(amount * incomeTaxPercentage);
                                totalTaxAmt = totalTaxAmt + incomeTaxAmt;

                                long postTaxAmt = (amount - incomeTaxAmt);
                                dr["(" + income.IncomeBy + ") " + income.Source + " - Post Tax"] = postTaxAmt;
                                totalPostTaxIncome = totalPostTaxIncome + long.Parse(postTaxAmt.ToString());
                            }
                            catch (Exception ex)
                            {
                                LogDebug("AddRowOnCalculation", ex);
                                MessageBox.Show(ex.ToString());
                            }
                        }
                        else
                        {
                            dr["(" + income.IncomeBy + ") " + income.Source] =
                                (dr["(" + income.IncomeBy + ") " + income.Source]) == null ? 0 :
                                dr["(" + income.IncomeBy + ") " + income.Source];
                        }
                    }
                    else
                    {
                        dr["(" + income.IncomeBy + ") " + income.Source] =
                              (dr["(" + income.IncomeBy + ") " + income.Source]) == null ? 0 :
                              dr["(" + income.IncomeBy + ") " + income.Source];
                    }
                }
            }
            dr["Total Income"] = totalIncome;
            dr["Total Tax Deduction"] = totalTaxAmt;
            dr["Total Post Tax Income"] = totalPostTaxIncome;
        }

        private bool isIncomeValidaForYear(Income income, int year, int clientRetYear, int spouseRetYear)
        {
            if (income.IncomeBy == _cashFlowCalculation.ClientName)
                return (clientRetYear >= year) ? true : false;
            else
                return true;
        }

        private void addExpenesCalculation(int years, DataRow dr)
        {
            double totalExpenses = 0;
            if (_cashFlowCalculation.LstExpenses != null)
            {
                foreach (Expenses exp in _cashFlowCalculation.LstExpenses)
                {
                    int expEndYear = string.IsNullOrEmpty(exp.ExpEndYear) ? DateTime.Now.Year + 100 : int.Parse(exp.ExpEndYear);
                    int expStartYear = string.IsNullOrEmpty(exp.ExpEndYear) ? years : int.Parse(exp.ExpStartYear);
                    if ((int.Parse(dr["StartYear"].ToString()) >= expStartYear &&
                       int.Parse(dr["StartYear"].ToString()) <= expEndYear) ||
                       string.IsNullOrEmpty(exp.ExpStartYear))
                    {
                        double expAmt = 0;
                        if (!double.TryParse(_dtCashFlow.Rows[years - 1][exp.Item].ToString(), out expAmt))
                        {
                            expAmt = exp.Amount;
                        }
                        if (expStartYear == (int.Parse(dr["StartYear"].ToString())))
                        {
                            dr[exp.Item] = System.Math.Round(expAmt, 2);
                            totalExpenses = System.Math.Round(totalExpenses + expAmt, 2);
                        }
                        else {
                            double expInflationRate = exp.InflationRate;
                            double expWithInflaction = expAmt + ((expAmt * expInflationRate) / 100);
                            dr[exp.Item] = System.Math.Round(expWithInflaction, 2);
                            totalExpenses = System.Math.Round(totalExpenses + expWithInflaction, 2);
                        }
                    }
                }
            }
            if (_cashFlowCalculation.LstLifeInsurances != null)
            {
                foreach (LifeInsurance lifeInsurance in _cashFlowCalculation.LstLifeInsurances)
                {
                    if (int.Parse(dr["StartYear"].ToString()) >= lifeInsurance.DateOfIssue.Year &&
                        int.Parse(dr["StartYear"].ToString()) < lifeInsurance.DateOfIssue.AddYears(lifeInsurance.Terms).Year)
                    {
                        dr[lifeInsurance.PolicyName] = lifeInsurance.Premium;
                        totalExpenses = totalExpenses + lifeInsurance.Premium;
                    }
                }
            }

            //General Insurance
            if (_cashFlowCalculation.LstGeneralInsurances != null)
            {
                foreach (GeneralInsurance generalInsurance in _cashFlowCalculation.LstGeneralInsurances)
                {
                    if (int.Parse(dr["StartYear"].ToString()) >= generalInsurance.IssueDate.Value.Year)
                    {
                        dr[generalInsurance.Company] = System.Math.Round(generalInsurance.Premium, 2);
                        totalExpenses = totalExpenses + generalInsurance.Premium;
                    }
                }
            }
            dr["Total Annual Expenses"] = System.Math.Round(totalExpenses, 2);
        }

        private void addLoansCalculation(int years, DataRow dr)
        {
            double totalLoans = 0;
            int previousYearRowIndex = years - 1;
            int currentLoanYear = years + 1;
            if (_cashFlowCalculation.LstLoans != null)
            {
                foreach (Loan loan in _cashFlowCalculation.LstLoans)
                {
                    decimal totalNoOfYearsForLoan = (Decimal)((Decimal)loan.TermLeftInMonths / 12);
                    if (currentLoanYear <= totalNoOfYearsForLoan || (totalNoOfYearsForLoan > currentLoanYear - 1 && totalNoOfYearsForLoan < currentLoanYear))
                    {
                        double loanAmt = double.Parse(_dtCashFlow.Rows[previousYearRowIndex][loan.TypeOfLoan].ToString());
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
            dr["Total Annual Loans"] = System.Math.Round(totalLoans, 2);
        }

        private void addFirstRowData(int rowId)
        {
            try
            {
                DataRow dr = _dtCashFlow.NewRow();
                dr["ID"] = rowId;
                dr["StartYear"] = _planner.StartDate.Year;

                double totalpostTaxIncome = addIncomes(dr);
                double totalExpenses = addExpenses(dr);
                double totalLoan = addLoans(dr);
                double totalLoanEmi = addGoals(dr, totalpostTaxIncome, totalExpenses, totalLoan);

                dr["Surplus Amount"] = totalpostTaxIncome - (totalExpenses + totalLoan + totalLoanEmi);
                dr["Corpus Fund"] = totalpostTaxIncome - (totalExpenses + totalLoan + totalLoanEmi);
                dr["Cumulative Corpus Fund"] = totalpostTaxIncome - (totalExpenses + totalLoan + totalLoanEmi);
                _dtCashFlow.Rows.Add(dr);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private double addExpenses(DataRow dr)
        {
            #region "Add Expenses"

            double totalExpenses = 0;
            if (_cashFlowCalculation.LstExpenses != null)
            {
                foreach (Expenses exp in _cashFlowCalculation.LstExpenses)
                {
                    if (!string.IsNullOrEmpty(exp.ExpStartYear) && !string.IsNullOrEmpty(exp.ExpEndYear))
                    {
                        if (_planner.StartDate.Year >= int.Parse(exp.ExpStartYear) &&
                            _planner.StartDate.Year <= int.Parse(exp.ExpEndYear))
                        {
                            double expAmt = (exp.OccuranceType == ExpenseType.Monthly) ? exp.Amount * 12 : exp.Amount;
                            dr[exp.Item] = expAmt;
                            totalExpenses = totalExpenses + expAmt;
                        }
                    }
                    else
                    {
                        double expAmt = (exp.OccuranceType == ExpenseType.Monthly) ? exp.Amount * 12 : exp.Amount;
                        dr[exp.Item] = expAmt;
                        totalExpenses = totalExpenses + expAmt;
                    }
                }
            }
            //Life Insurance
            if (_cashFlowCalculation.LstLifeInsurances != null)
            {
                foreach (LifeInsurance lifeInsurance in _cashFlowCalculation.LstLifeInsurances)
                {
                    if (_planner.StartDate.Year >= lifeInsurance.DateOfIssue.Year &&
                        _planner.StartDate.Year <= lifeInsurance.DateOfIssue.AddYears(lifeInsurance.Terms).Year)
                    {
                        dr[lifeInsurance.PolicyName] = lifeInsurance.Premium;
                        totalExpenses = totalExpenses + lifeInsurance.Premium;
                    }
                }
            }

            //General Insurance
            if (_cashFlowCalculation.LstGeneralInsurances != null)
            {
                foreach (GeneralInsurance generalInsurance in _cashFlowCalculation.LstGeneralInsurances)
                {
                    if ((generalInsurance.IssueDate >= _planner.StartDate &&
                         generalInsurance.IssueDate <= _planner.EndDate) ||
                         (_planner.StartDate >= generalInsurance.IssueDate &&
                         _planner.EndDate <= generalInsurance.RenewalDate) ||
                         (generalInsurance.IssueDate <= _planner.StartDate))
                    {
                        dr[generalInsurance.Company] = generalInsurance.Premium;
                        totalExpenses = totalExpenses + generalInsurance.Premium;
                    }
                }
            }
            dr["Total Annual Expenses"] = totalExpenses;

            #endregion
            return totalExpenses;
        }

        private double addIncomes(DataRow dr)
        {
            #region "Add Incomes"
            double totalIncome = 0;
            double totalpostTaxIncome = 0;
            double totalTaxAmt = 0;
            if (_cashFlowCalculation.LstIncomes != null)
            {
                foreach (Income income in _cashFlowCalculation.LstIncomes)
                {
                    if (income.StartYear == _planner.StartDate.Year.ToString())
                    {
                        dr["(" + income.IncomeBy + ") " + income.Source] = income.Amount;
                        totalIncome = totalIncome + income.Amount;
                        dr["(" + income.IncomeBy + ") " + income.Source + " - Income Tax"] = income.IncomeTax;
                        double taxAmt = (income.Amount * income.IncomeTax) / 100;
                        totalTaxAmt = totalTaxAmt + taxAmt;
                        dr["(" + income.IncomeBy + ") " + income.Source + " - Post Tax"] = income.Amount - taxAmt;
                        totalpostTaxIncome = totalpostTaxIncome + (income.Amount - taxAmt);
                    }
                }
            }
            dr["Total Income"] = totalIncome;
            dr["Total Tax Deduction"] = totalTaxAmt;
            dr["Total Post Tax Income"] = totalpostTaxIncome;
            #endregion
            return totalpostTaxIncome;
        }

        private double addLoans(DataRow dr)
        {
            #region "Add Loans"

            double totalLoan = 0;
            if (_cashFlowCalculation.LstLoans != null)
            {
                foreach (Loan loan in _cashFlowCalculation.LstLoans)
                {
                    double loanAmt = loan.Emis * 12;
                    dr[loan.TypeOfLoan] = loanAmt;
                    totalLoan = totalLoan + loanAmt;
                }
            }
            dr["Total Annual Loans"] = totalLoan;

            #endregion
            return totalLoan;
        }

        private double addGoals(DataRow dr, double totalpostTaxIncome, double totalExpenses, double totalLoan)
        {
            #region "Add Goals"

            double totalLoanEmi = 0;
            double surplusCashFund = (totalpostTaxIncome - (totalExpenses + totalLoan + totalLoanEmi));
            if (_cashFlowCalculation.LstGoals != null)
            {
                foreach (Goals goal in _cashFlowCalculation.LstGoals)
                {
                    //1 Loan for Goal
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
                    //2 Cash Flow and fund allocation to goal
                    if (surplusCashFund > 0)
                    {
                        _riskProfileInfo = new RiskProfileInfo();

                        GoalsValueCalculationInfo goalValCalInfo = new GoalsValueCalculationInfo(goal, _planner, _riskProfileInfo, _riskProfileId, this._optionId, this);
                        GoalsCalculationInfo goalcalInfo = new GoalsCalculationInfo(goal, _planner, _riskProfileInfo, _riskProfileId, _optionId);
                        goalValCalInfo.SetPortfolioValue(goalcalInfo.GetProfileValue());
                        GoalCalculationMgr.AddGoalValueCalculation(goalValCalInfo);

                        double surplusAmountAfterInvestment = goalValCalInfo.SetInvestmentToAchiveGoal(_planner.StartDate.Year, surplusCashFund);
                        dr[string.Format("{0} - {1}", goal.Priority, goal.Name)] = Math.Round(surplusCashFund - surplusAmountAfterInvestment, 2,
                                                 MidpointRounding.ToEven);
                        surplusCashFund = surplusAmountAfterInvestment;
                    }
                    else
                    {
                        _riskProfileInfo = new RiskProfileInfo();

                        GoalsValueCalculationInfo goalValCalInfo = new GoalsValueCalculationInfo(goal, _planner, _riskProfileInfo, _riskProfileId, this._optionId, this);
                        GoalsCalculationInfo goalcalInfo = new GoalsCalculationInfo(goal, _planner, _riskProfileInfo, _riskProfileId, _optionId);
                        goalValCalInfo.SetPortfolioValue(goalcalInfo.GetProfileValue());
                        GoalCalculationMgr.AddGoalValueCalculation(goalValCalInfo);
                    }

                    if (goal.Category == "Retirement")
                    {
                        dr["Corpus Fund"] = string.IsNullOrEmpty(dr[string.Format("{0} - {1}", goal.Priority, goal.Name)].ToString()) ? 0 :
                            double.Parse(dr[string.Format("{0} - {1}", goal.Priority, goal.Name)].ToString());
                    }

                    dr["Corpus Fund"] = ((surplusCashFund > 0) ? Math.Round(surplusCashFund, 2) : 0);
                    dr["Cumulative Corpus Fund"] = ((surplusCashFund > 0) ? Math.Round(surplusCashFund, 2) : 0);
                }
            }
            #endregion
            return totalLoanEmi;
        }

        private void fillCashFlowFromIncomes(IList<Income> incomes)
        {
            _cashFlowCalculation.LstIncomes = incomes;
        }

        private void fillCashFlowFromExpenses(IList<Expenses> expenses)
        {
            _cashFlowCalculation.LstExpenses = expenses;
        }

        private void fillCashFlowFromLoans(IList<Loan> loans)
        {
            _cashFlowCalculation.LstLoans = loans;
        }

        private void fillCashFlowFromPlannerAssumption(PlannerAssumption plannerAssumption)
        {
            _cashFlowCalculation.ClientLifeExpected = plannerAssumption.ClientLifeExpectancy;
            _cashFlowCalculation.ClientRetirementAge = plannerAssumption.ClientRetirementAge;
            _cashFlowCalculation.SpouseLifeExpected = plannerAssumption.SpouseLifeExpectancy;
            _cashFlowCalculation.SpouseRetirementAge = plannerAssumption.SpouseRetirementAge;
            _cashFlowCalculation.IslientRetirmentAgeForPrimaryCalculation = plannerAssumption.IsClientRetirmentAgeIsPrimary;
        }

        private void fillPersonalData(PersonalInformation personalInfo)
        {
            _cashFlowCalculation.Pid = _planId;
            _cashFlowCalculation.Cid = personalInfo.Client.ID;
            _cashFlowCalculation.ClientName = personalInfo.Client.Name;
            _cashFlowCalculation.ClientDateOfBirth = personalInfo.Client.DOB;

            if (personalInfo.Spouse != null)
            {
                _cashFlowCalculation.Sid = personalInfo.Spouse.ID;
                _cashFlowCalculation.SpouseName = personalInfo.Spouse.Name;
                _cashFlowCalculation.SpouseDateOfBirth = personalInfo.Spouse.DOB;
            }
        }

        private void createTableCashFlowStructure()
        {
            DataColumn dcId = new DataColumn("Id", typeof(System.Int16));
            dcId.AutoIncrement = true;
            dcId.ReadOnly = true;
            _dtCashFlow.Columns.Add(dcId);


            DataColumn dcYear = new DataColumn("StartYear", typeof(System.Int16));
            dcYear.AutoIncrement = true;
            dcYear.ReadOnly = true;
            _dtCashFlow.Columns.Add(dcYear);

            DataColumn dcEndYear = new DataColumn("EndYear", typeof(System.Int16), (_planner.StartDate.Year == _planner.EndDate.Year)? "StartYear" : "StartYear + 1");
            dcEndYear.ReadOnly = true;
            _dtCashFlow.Columns.Add(dcEndYear);

            AddIncomeColumnToDataTable();
            AddExpensesColumnToDataTable();
            AddLoanColumnToDataTable();

            _dtCashFlow.Columns.Add("Surplus Amount", typeof(System.Double));

            AddGoalColumnToDataTable();

            _dtCashFlow.Columns.Add("Corpus Fund", typeof(System.Double));
            _dtCashFlow.Columns.Add("Cumulative Corpus Fund", typeof(System.Double));
            _dtCashFlow.Columns.Add("Adjusted Amount", typeof(System.Double));
        }

        private void AddExpensesColumnToDataTable()
        {
            #region "Expenses Calculation"
            if (_cashFlowCalculation.LstExpenses != null)
            {
                foreach (Expenses exp in _cashFlowCalculation.LstExpenses)
                {
                    DataColumn dcExp = new DataColumn(exp.Item, typeof(System.Double));
                    dcExp.ReadOnly = true;
                    _dtCashFlow.Columns.Add(dcExp);
                }
            }

            #region "Life Insurance"
            if (_cashFlowCalculation.LstLifeInsurances != null)
            {
                foreach (LifeInsurance lifeInsurance in _cashFlowCalculation.LstLifeInsurances)
                {
                    DataColumn dcLifeInsurance = new DataColumn(lifeInsurance.PolicyName, typeof(System.Double));
                    dcLifeInsurance.ReadOnly = true;
                    _dtCashFlow.Columns.Add(dcLifeInsurance);
                }
            }
            #endregion

            #region "General Insurance"
            if (_cashFlowCalculation.LstGeneralInsurances != null)
            {
                foreach (GeneralInsurance generalInsurance in _cashFlowCalculation.LstGeneralInsurances)
                {
                    DataColumn dcInsurance = new DataColumn(generalInsurance.Company, typeof(System.Double));
                    dcInsurance.ReadOnly = true;
                    _dtCashFlow.Columns.Add(dcInsurance);
                }
            }
            #endregion

            _dtCashFlow.Columns.Add("Total Annual Expenses", typeof(System.Double));
            #endregion
        }

        private void AddIncomeColumnToDataTable()
        {
            #region "Income Calculation"
            if (_cashFlowCalculation.LstIncomes != null)
            {
                foreach (Income income in _cashFlowCalculation.LstIncomes)
                {
                    DataColumn dcIncome = new DataColumn("(" + income.IncomeBy + ") " + income.Source, typeof(System.Double));
                    dcIncome.ReadOnly = true;
                    if (!_dtCashFlow.Columns.Contains(dcIncome.Caption))
                        _dtCashFlow.Columns.Add(dcIncome);

                    DataColumn dcIncomeTax = new DataColumn(dcIncome.ColumnName + " - Income Tax", typeof(System.Decimal));
                    if (!_dtCashFlow.Columns.Contains(dcIncomeTax.Caption))
                        _dtCashFlow.Columns.Add(dcIncomeTax);

                    DataColumn postTaxIncome = new DataColumn(dcIncome.ColumnName + " - Post Tax", typeof(System.Double));
                    if (!_dtCashFlow.Columns.Contains(postTaxIncome.Caption))
                        _dtCashFlow.Columns.Add(postTaxIncome);
                }
            }
            DataColumn dcTotal = new DataColumn("Total Income", typeof(System.Double));
            dcTotal.ReadOnly = true;
            _dtCashFlow.Columns.Add(dcTotal);

            _dtCashFlow.Columns.Add("Total Tax Deduction", typeof(System.Double));
            _dtCashFlow.Columns.Add("Total Post Tax Income", typeof(System.Double));
            #endregion
        }

        private void AddLoanColumnToDataTable()
        {
            #region "Loan Calculation"
            if (_cashFlowCalculation.LstLoans != null)
            {
                foreach (Loan loan in _cashFlowCalculation.LstLoans)
                {
                    DataColumn dcloan = new DataColumn(loan.TypeOfLoan, typeof(System.Double));
                    dcloan.ReadOnly = true;
                    _dtCashFlow.Columns.Add(dcloan);
                }
                _dtCashFlow.Columns.Add("Total Annual Loans", typeof(System.Double));
            }
            #endregion
        }

        private void AddGoalColumnToDataTable()
        {
            #region"Goals
            if (_cashFlowCalculation.LstGoals == null)
                return;
            _cashFlowCalculation.LstGoals.OrderBy(x => x.Priority);
            foreach (Goals goal in _cashFlowCalculation.LstGoals)
            {
                DataColumn dcGoal = new DataColumn(string.Format("{0} - {1}", goal.Priority, goal.Name), typeof(System.Double));
                _dtCashFlow.Columns.Add(dcGoal);

                if (goal.LoanForGoal != null && goal.LoanForGoal.EMI > 0)
                {
                    DataColumn dtLoanForGoal = new DataColumn(string.Format("(Loan EMI - {0})", goal.Name), typeof(System.Double));
                    _dtCashFlow.Columns.Add(dtLoanForGoal);
                }
            }
            #endregion
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