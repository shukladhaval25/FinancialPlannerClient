using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.CurrentStatus;
using FinancialPlannerClient.CurrentStatus;
using FinancialPlannerClient.PlannerInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinancialPlannerClient.Insurance
{
    public partial class InsuranceCalculation : DevExpress.XtraEditors.XtraForm
    {
        Planner planner;
        Client client;
        DataTable dtInsuranceCoverage = new DataTable();
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

        private void InsuranceCalculation_Load(object sender, EventArgs e)
        {
            createInsuranceCoverateTable();
            AddExpenesIntoInsuranceCoverage();
            AddGoalsIntoInsuranceCoverage();
            AddInsuranceIntoInsuranceCoverage();
            gridInsuranceCoverage.DataSource = dtInsuranceCoverage;
            gridViewInsuranceCoverage.GroupCount = 0;
            gridViewInsuranceCoverage.Columns[0].GroupIndex = 1;
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
                dataRow["Category"] = "Expense";
                dataRow["Content"] = goal.Name;
                dataRow["Amount"] = goal.Amount;
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
            PlannerAssumptionInfo plannerAssumptionInfo = new PlannerAssumptionInfo();
            PlannerAssumption plannerAssumption = plannerAssumptionInfo.GetAll(this.planner.ID);
            int yearsDiff = (this.client.DOB.Year + plannerAssumption.ClientRetirementAge) - planner.StartDate.Year;
            double fvExp = futureValue(exp.Amount, plannerAssumption.PreRetirementInflactionRate, yearsDiff);
            double pvExp = presentValue(fvExp, plannerAssumption.PreRetirementInflactionRate, yearsDiff);
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
    }
}
