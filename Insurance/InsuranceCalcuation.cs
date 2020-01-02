using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.CurrentStatus;
using FinancialPlannerClient.CurrentStatus;
using FinancialPlannerClient.PlannerInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace FinancialPlannerClient.Insurance
{
    public partial class InsuranceCalculation : DevExpress.XtraEditors.XtraForm
    {
        Planner planner;
        Client client;
        PlannerAssumption plannerAssumption;
        DataTable dtInsuranceCoverage = new DataTable();
        DataTable dtFinancialAssets = new DataTable();
        DataTable dtInsuranceCoverageRequire = new DataTable();
        double totalAmountRequireInFuture = 0;
        int clientCurrentAge;
        int clientRetirementYear;
        public InsuranceCalculation(Client client, Planner planner)
        {
            InitializeComponent();
            this.planner = planner;
            this.client = client;
            PlannerAssumptionInfo plannerAssumptionInfo = new PlannerAssumptionInfo();
            plannerAssumption = plannerAssumptionInfo.GetAll(this.planner.ID);
            clientCurrentAge = (planner.StartDate.Year - client.DOB.Year);
            clientRetirementYear = planner.StartDate.Year +  (plannerAssumption.ClientRetirementAge - clientCurrentAge);
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

        private  void InsuranceCalculation_Load(object sender, EventArgs e)
        {
            createTableStructureForInsuranceCoverageRequire();
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
            AddNonFinancialAssetIntoInsuranceCoverage();
            gridControlFinancialAssert.DataSource = dtFinancialAssets;
            displayEsitmatedInsuranceCoverageRequired();
        }

        private async void displayEsitmatedInsuranceCoverageRequired()
        {
            InsuranceCoverageService insuranceCoverageService = new InsuranceCoverageService(client, planner);
            await Task.Run(() => insuranceCoverageService.CalculateInsuranceCoverNeed());
            picProcessing.Visible = false;
            txtEstimatedIsurnceCoverage.Text = Math.Round(insuranceCoverageService.GetEstimatedInsurnceAmount(), 2).ToString();
        }

        private void AddNonFinancialAssetIntoInsuranceCoverage()
        {
            IList<NonFinancialAsset> nonFinancialAssets = new NonFinancialAssetInfo().GetAll(this.planner.ID);
            if (nonFinancialAssets.Count > 0)
            {
                nonFinancialAssets = nonFinancialAssets.ToList().FindAll(i => i.EligibleForInsuranceCover == true);
                double totalNonFinancialAsset = 0;
                foreach (NonFinancialAsset nonFinancialAsset in nonFinancialAssets)
                {
                    totalNonFinancialAsset = totalNonFinancialAsset + nonFinancialAsset.CurrentValue;
                }
                DataRow dataRow = dtFinancialAssets.NewRow();
                dataRow["Category"] = "Assets";
                dataRow["Content"] = "Existing value of Non-Financial Assets";
                dataRow["Amount"] = totalNonFinancialAsset;
                dtFinancialAssets.Rows.Add(dataRow);
            }
        }

        private void createTableStructureForInsuranceCoverageRequire()
        {
            DataColumn dcYear = new DataColumn("Year", typeof(System.Int16));
            dtInsuranceCoverageRequire.Columns.Add(dcYear);
            for(int year = clientCurrentAge; year <= clientRetirementYear;year++)
            {
                DataRow dr =  dtInsuranceCoverageRequire.NewRow();
                dr["Year"] = year;
                dtInsuranceCoverageRequire.Rows.Add(dr);
            }
        }

        private void AddFinancialAssetIntoInsuranceCoverage()
        {
            CurrentStatusCalculation currentStatusCalculation = new CurrentStatusInfo().GetAllCurrestStatus(this.planner.ID);
            double totalCurrentStatusValue = currentStatusCalculation.Total;
            DataRow dataRow = dtFinancialAssets.NewRow();
            dataRow["Category"] = "Assets";
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
                //TODO:
                //Confirm about loan amount. After primary person
                //expire loan should be immediately complete from insurance amount?
                //or insurance amount should calculate emis.

                totalAmountRequireInFuture = totalAmountRequireInFuture + loan.OutstandingAmt;
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
                //TODO:
                //Get insurance covered for whome (If its for other then client then add primium amount into total amount require for insurance.
                //If its for client then deduct sum assured amount from total amount require.

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
                dataRow["Amount"] = goal.Amount;
                double futureValueOfGoal = futureValue(goal.Amount, goal.InflationRate, (int.Parse(goal.StartYear) - DateTime.Now.Year));
                totalAmountRequireInFuture = totalAmountRequireInFuture + futureValueOfGoal;
                //addGoalCoverageCalculation(goal, futureValueOfGoal);
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
           
            int yearsDiff = (this.client.DOB.Year + plannerAssumption.ClientRetirementAge) - planner.StartDate.Year;
            double fvExp = futureValue(currentAmount, plannerAssumption.PreRetirementInflactionRate, yearsDiff);
            totalAmountRequireInFuture = totalAmountRequireInFuture + fvExp;
            //addExpCoverageCalculation(exp, fvExp);
            //return fvExp;
            double pvExp = presentValue(fvExp, plannerAssumption.PreRetirementInflactionRate, yearsDiff);
            return pvExp;
        }

        private void addExpCoverageCalculation(Expenses exp, double fvExp)
        {
            DataColumn dcExp = new DataColumn(exp.Item, typeof(System.Double));
            DataColumn dcExpInflationRate = new DataColumn(exp.Item + "-Inflation", typeof(System.Double));
            dtInsuranceCoverageRequire.Columns.Add(dcExp);
            dtInsuranceCoverageRequire.Columns.Add(dcExpInflationRate);
            int rowCount = 0;
            foreach(DataRow dr in dtInsuranceCoverageRequire.Rows)
            {
                //exp.ExpStartYear;
                //exp.ExpEndYear
                //if (int.par( dr["Year"])
                if (rowCount == 0)
                    dr[exp.Item] = exp.Amount;
                else
                {
                    double previousYearExp = double.Parse(dtInsuranceCoverageRequire.Rows[rowCount - 1][exp.Item].ToString());
                    dr[exp.Item] = previousYearExp + ((previousYearExp * exp.InflationRate) / 100);
                }
                dr[exp.Item + "-Inflation"] = exp.InflationRate;
            }
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

        private void btnShowCalculation_Click(object sender, EventArgs e)
        {
            EstimatedInsuranceCoverageView estimatedInsuranceCoverageView = new EstimatedInsuranceCoverageView(this.client,this.planner);
            estimatedInsuranceCoverageView.Show();
        }
    }
}
