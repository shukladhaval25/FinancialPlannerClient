using FinancialPlanner.Common;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.PlanOptions;
using FinancialPlannerClient.PlannerInfo;
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
        private readonly string GETALL_API= "CashFlow/Get?optionId={0}";
        private readonly string ADD_CASHFLOW_API = "cashflow/Add";
        private readonly string UPDATE_CASHFLOW_API = "cashflow/update";

        public CashFlowCalculation GetCashFlowData(int clientId, int planId)
        {
            _clientId = clientId;
            _planId = planId;

            ClientPersonalInfo clientPersonalInfo = new ClientPersonalInfo();
            PersonalInformation  personalInfo =  clientPersonalInfo.Get(clientId);
            fillPersonalData(personalInfo);

            PlannerAssumption plannerAssumption =  new PlannerAssumptionInfo().GetAll(_planId);
            if (plannerAssumption != null)
                fillCashFlowFromPlannerAssumption(plannerAssumption);

            IList<Income> incomes = new IncomeInfo().GetAll(_planId);
            fillCashFlowFromIncomes(incomes);

            return _cashFlow;
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

        public DataTable GenerateCashFlow(int clientId, int planId, float incomeTax)
        {
            _dtCashFlow = new DataTable();
            CashFlowCalculation cashFlow = GetCashFlowData(clientId,planId);
            if (cashFlow != null)
            {
                createTableCashFlowStructure(incomeTax);
                generateCashFlowData(incomeTax);
            }
            return _dtCashFlow;
        }

        private void generateCashFlowData(float incomeTax)
        {
            int rowId = 1;
            addFirstRowData(incomeTax, rowId);
            if (_dtCashFlow.Rows.Count == 1)
            {
                addRowsBasedOnCalculation(incomeTax);
            }
        }

        private void addRowsBasedOnCalculation(float incomeTax)
        {
            int noOfYearsForClient = _cashFlow.ClientRetirementAge - _cashFlow.ClientCurrentAge;
            int noOfYearsForSpouse = _cashFlow.SpouseRetirementAge - _cashFlow.SpouseCurrentAge;
            int noOfYearsForCalculation = (noOfYearsForClient >= noOfYearsForSpouse) ? noOfYearsForClient : noOfYearsForSpouse;
            for (int years = 1; years <= noOfYearsForCalculation; years++)
            {
             
                DataRow dr = _dtCashFlow.NewRow();              
                long totalIncome = 0;
                int incomeEndYear = 0;
                long totalTaxAmt = 0;
                long totalPostTaxIncome = 0;
                foreach (Income income in _cashFlow.LstIncomes)
                {
                    incomeEndYear = string.IsNullOrEmpty(income.EndYear) ? DateTime.Now.Year + 100 : int.Parse(income.EndYear);
                    if (int.Parse(dr["StartYear"].ToString()) >=  int.Parse(income.StartYear) &&
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
                        catch(Exception ex)
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
                _dtCashFlow.Rows.Add(dr);
            }
        }

        private void addFirstRowData(float incomeTax, int rowId)
        {
            DataRow dr = _dtCashFlow.NewRow();
            dr["ID"] = rowId;
            dr["StartYear"] = DateTime.Now.Year + 1;
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
            _dtCashFlow.Rows.Add(dr);
        }

        private void fillCashFlowFromIncomes(IList<Income> incomes)
        {
            _cashFlow.LstIncomes = incomes;
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

        private void createTableCashFlowStructure(float incomeTax)
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
            
            //_dtCashFlow.Columns.Add("IncomeTax",typeof(System.Decimal));

            _dtCashFlow.Columns.Add("Total Tax Deduction", typeof(System.Double));
            //_dtCashFlow.Columns["Tax"].ReadOnly = true;
            _dtCashFlow.Columns.Add("Total Post Tax Income", typeof(System.Double));
           // _dtCashFlow.Columns["Post Tax Income"].ReadOnly = true;
            //_dtCashFlow.Columns.Add("Tax", typeof(System.Double), "(Total * IncomeTax) / 100");
            //_dtCashFlow.Columns.Add("Post Tax Income", typeof(System.Double), "Total - Tax");            
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