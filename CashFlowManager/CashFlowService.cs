using FinancialPlanner.Common.Model;
using FinancialPlannerClient.PlannerInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlannerClient.CashFlowManager
{
    public class CashFlowService
    {
        private CashFlow _cashFlow = new CashFlow();
        private int _clientId, _planId;
        DataTable  _dtCashFlow;

        public CashFlow GetCashFlowData(int clientId, int planId)
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

        public DataTable GenerateCashFlow(int clientId, int planId, float incomeTax)
        {
            _dtCashFlow = new DataTable();
            CashFlow cashFlow = GetCashFlowData(clientId,planId);
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
                foreach (Income income in _cashFlow.LstIncomes)
                {
                    incomeEndYear = string.IsNullOrEmpty(income.EndYear) ? DateTime.Now.Year + 100 : int.Parse(income.EndYear);
                    if (int.Parse(dr["StartYear"].ToString()) >=  int.Parse(income.StartYear) &&
                        int.Parse(dr["StartYear"].ToString()) <= incomeEndYear)
                    {
                        long amount = long.Parse(_dtCashFlow.Rows[years - 1]["(" + income.IncomeBy + ") " + income.Source].ToString());
                        amount = amount + (long)((amount * float.Parse(income.ExpectGrowthInPercentage.ToString()) / 100));
                        dr["(" + income.IncomeBy + ") " + income.Source] = amount;
                        totalIncome = totalIncome + amount;
                    }
                    else
                    {
                        dr["(" + income.IncomeBy + ") " + income.Source] = 0;
                    }
                }
                dr["Total"] = totalIncome;              
                _dtCashFlow.Rows.Add(dr);
            }
        }

        private void addFirstRowData(float incomeTax, int rowId)
        {
            DataRow dr = _dtCashFlow.NewRow();
            dr["ID"] = rowId;
            dr["StartYear"] = DateTime.Now.Year + 1;
            double totalIncome = 0;
            foreach (Income income in _cashFlow.LstIncomes)
            {
                dr["(" + income.IncomeBy + ") " + income.Source] = income.Amount;
                totalIncome = totalIncome + income.Amount;
            }
            dr["Total"] = totalIncome;     
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
            }

            DataColumn dcTotal = new DataColumn("Total",typeof(System.Double));
            dcTotal.ReadOnly = true;
            _dtCashFlow.Columns.Add(dcTotal);

            _dtCashFlow.Columns.Add("Tax", typeof(System.Double), "(Total * " + incomeTax +") / 100");
            _dtCashFlow.Columns.Add("Post Tax Income", typeof(System.Double), "Total - Tax");            
        }
    }
}