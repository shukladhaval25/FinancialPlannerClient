using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.CurrentStatus;
using FinancialPlannerClient.CurrentStatus;
using FinancialPlannerClient.PlannerInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FinancialPlannerClient.Insurance
{
    public partial class InsuranceCalculation : DevExpress.XtraEditors.XtraForm
    {
        Planner planner;
        Client client;
        DataTable dtInsuranceCoverage = new DataTable();
        DataTable dtFinancialAssets = new DataTable();
        public InsuranceCalculation(Client client, Planner planner)
        {
            InitializeComponent();
            this.planner = planner;
            this.client = client;
        }
        private List<Expenses> GetExpenses()
        {
            List<Expenses> expenses = new List<Expenses>();
            ExpensesInfo expensesInfo = new ExpensesInfo();
            expenses = (List<Expenses>)expensesInfo.GetAll(this.planner.ID);
            return expenses;
        }
        private List<Goals> GetGoals()
        {
            List<Goals> goals = new List<Goals>();
            GoalsInfo goalsInfo = new GoalsInfo();
            goals = (List<Goals>) goalsInfo.GetAll(this.planner.ID);
            return goals;         
        }

        private IList<LifeInsurance> GetInsurances()
        {
            LifeInsuranceInfo lifeInsuranceInfo = new LifeInsuranceInfo();
            return lifeInsuranceInfo.GetAllLifeInsurance(this.planner.ID);
        }

        private IList<Loan> getLoans()
        {
            LoanInfo loanInfo = new LoanInfo();
            return (List<Loan>)loanInfo.GetAll(this.planner.ID);
        }

        private void InsuranceCalculation_Load(object sender, EventArgs e)
        {
            createInsuranceCoverateTable();
            createFinancialAssetsTable();
            AddExpenesIntoInsuranceCoverage();
            AddGoalsIntoInsuranceCoverage();
            AddOutStandingLoansIntoInsuranceCoverage();
            AddInsuranceIntoInsuranceCoverage();
            gridInsuranceCoverage.DataSource = dtInsuranceCoverage;
            //gridViewInsuranceCoverage.GroupCount = 0;
            //gridViewInsuranceCoverage.Columns[0].GroupIndex = 1;
            AddFinancialAssetIntoInsuranceCoverage();
            gridControlFinancialAssert.DataSource = dtFinancialAssets;
        }

        private void AddFinancialAssetIntoInsuranceCoverage()
        {
            CurrentStatusCalculation currentStatusCalculation = new CurrentStatusInfo().GetAllCurrestStatus(this.planner.ID);
            double totalCurrentStatusValue = currentStatusCalculation.Total;
            DataRow dataRow = dtFinancialAssets.NewRow();
            dataRow["Category"] = "Financial Assets";
            dataRow["Content"] = "Existing value of Financial Assets";
            dataRow["Amount"] = totalCurrentStatusValue;
            dtFinancialAssets.Rows.Add(dataRow);
        }

        private void AddOutStandingLoansIntoInsuranceCoverage()
        {
            IList<Loan> loans = getLoans();
            foreach (Loan loan in loans)
            {
                DataRow dataRow = dtInsuranceCoverage.NewRow();
                dataRow["Category"] = "Loan";
                dataRow["Content"] = loan.TypeOfLoan;
                dataRow["Amount"] = loan.OutstandingAmt;
                dtInsuranceCoverage.Rows.Add(dataRow);
            }
        }

        private void AddInsuranceIntoInsuranceCoverage()
        {
            IList<LifeInsurance> lifeInsurances = GetInsurances();
            foreach (LifeInsurance insurance in lifeInsurances)
            {
                DataRow dataRow = dtInsuranceCoverage.NewRow();
                dataRow["Category"] = "Insurance";
                dataRow["Content"] = insurance.Company;
                dataRow["Amount"] = insurance.Premium; //Needs to be calculate
                dtInsuranceCoverage.Rows.Add(dataRow);
            }
        }

        private void AddGoalsIntoInsuranceCoverage()
        {
            List<Goals> goals = GetGoals().Where(x => x.EligibleForInsuranceCoverage).ToList();
            foreach (Goals goal in goals)
            {
                DataRow dataRow = dtInsuranceCoverage.NewRow();
                dataRow["Category"] = "Goals";
                dataRow["Content"] = goal.Name;
                dataRow["Amount"] = futureValue(goal.Amount, goal.InflationRate, (int.Parse(goal.StartYear) - DateTime.Now.Year));
                dtInsuranceCoverage.Rows.Add(dataRow);
            }
        }

        private void AddExpenesIntoInsuranceCoverage()
        {
            List<Expenses> expenses = GetExpenses().Where(x => x.EligibleForInsuranceCoverage).ToList();
            foreach(Expenses exp in expenses)
            {
                DataRow dataRow = dtInsuranceCoverage.NewRow();
                dataRow["Category"] = "Expense";
                dataRow["Content"] = exp.Item;
                dataRow["Amount"] =  GetExpensesCoverage(exp); //Needs to be calculate
                dtInsuranceCoverage.Rows.Add(dataRow);
            }
        }

        private double GetExpensesCoverage(Expenses exp)
        {
            Double currentAmount = (exp.OccuranceType == ExpenseType.Yearly) ? exp.Amount : (exp.Amount * 12);
            PlannerAssumptionInfo plannerAssumptionInfo = new PlannerAssumptionInfo();
            PlannerAssumption plannerAssumption = plannerAssumptionInfo.GetAll(this.planner.ID);
            int yearsDiff = (this.client.DOB.Year + plannerAssumption.ClientRetirementAge) - planner.StartDate.Year;
            double fvExp = futureValue(currentAmount, 7, yearsDiff);
            //return fvExp;
            double pvExp = presentValue(fvExp, 8, yearsDiff);
            return pvExp;
        }
       
        private static double presentValue(double futureValue, decimal interest_rate, int timePeriodInYears)
        {
            //PV = FV / (1 + I)T;
            interest_rate = interest_rate / 100;
            decimal presentValue = (decimal)futureValue /
                ((decimal)Math.Pow((double)(1 + interest_rate), (double)timePeriodInYears));

            return Math.Round((double)presentValue);
        }
        private static double futureValue(double presentValue, decimal interest_rate, int timePeriodInYears)
        {
            //FV = PV * (1 + I)T;
            interest_rate = interest_rate / 100;
            double futureValue = presentValue *
                (Math.Pow((double)(1 + interest_rate), (double)timePeriodInYears));

            return Math.Round(futureValue);
        }

        private void createInsuranceCoverateTable()
        {
            dtInsuranceCoverage.Columns.Add("Category", typeof(string));
            dtInsuranceCoverage.Columns.Add("Content", typeof(string));
            dtInsuranceCoverage.Columns.Add("Amount", typeof(Double));
        }
        private void createFinancialAssetsTable()
        {
            dtFinancialAssets.Columns.Add("Category", typeof(string));
            dtFinancialAssets.Columns.Add("Content");
            dtFinancialAssets.Columns.Add("Amount", typeof(Double));
        }
    }
}
