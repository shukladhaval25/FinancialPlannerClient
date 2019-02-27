using System;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.PlanOptions.Reports;


namespace FinancialPlannerClient.PlanOptions
{
    public partial class PlannerMainReport : DevExpress.XtraReports.UI.XtraReport
    {
        Client client;
        Planner planner;
        PersonalInformation personalInformation;
       
        public PlannerMainReport(PersonalInformation personalInformation, Planner planner)
        {
            InitializeComponent();
            this.personalInformation = personalInformation;
            this.client = personalInformation.Client;
            this.planner = planner;
            this.lblClientName.Text = this.client.Name;
            this.lblPreparedFor.Text = this.client.Name;
            this.lblPreparedOn.Text = this.planner.StartDate.ToShortDateString();
        }

        private void Detail_AfterPrint(object sender, EventArgs e)
        {
           
            //this.lblPreparedBy.Text = this.planner.p
        }

        private void PlannerMainReport_AfterPrint(object sender, EventArgs e)
        {
            TableOfContent tableOfContent = new TableOfContent(client);
            tableOfContent.CreateDocument();

            Introduction introduction = new Introduction(client);
            introduction.CreateDocument();

            WhatIsPlan whatIsPlan = new WhatIsPlan(client);
            whatIsPlan.CreateDocument();

            ScopeOfPlancs scopeOfPlancs = new ScopeOfPlancs(client);
            scopeOfPlancs.CreateDocument();

            AssumptionPage assumptionPage = new AssumptionPage(personalInformation,planner.ID);
            assumptionPage.CreateDocument();

            FamilyInfoPage familyInfo = new FamilyInfoPage(personalInformation.Client);
            familyInfo.CreateDocument();

            FinancialGoalIntro financialGoalIntro = new FinancialGoalIntro(client);
            financialGoalIntro.CreateDocument();

            FinancialClientGoal financialClientGoal = new FinancialClientGoal(this.planner,this.client);
            financialClientGoal.CreateDocument();

            GoalProjectionForComplition goalProjectionForComplition = new GoalProjectionForComplition(this.planner, this.client);
            goalProjectionForComplition.CreateDocument();

            IncomeExpenseAnalysis incomeExpenseAnalysis = new IncomeExpenseAnalysis(this.client, this.planner);
            incomeExpenseAnalysis.CreateDocument();

            // Enable this property to maintain continuous page numbering 
            PrintingSystem.ContinuousPageNumbering = true;

            // Add all pages of the 2nd report to the end of the 1st report.             
            this.Pages.Add(tableOfContent.Pages.First);
            this.Pages.Add(introduction.Pages.First);
            this.Pages.Add(whatIsPlan.Pages.First);
            this.Pages.Add(scopeOfPlancs.Pages.First);
            this.Pages.Add(assumptionPage.Pages.First);
            this.Pages.Add(familyInfo.Pages.First);
            this.Pages.Add(financialGoalIntro.Pages.First);
            this.Pages.Add(financialClientGoal.Pages.First);
            this.Pages.Add(goalProjectionForComplition.Pages.First);
            this.Pages.Add(incomeExpenseAnalysis.Pages.First);
        }
    }
}
