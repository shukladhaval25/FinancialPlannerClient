using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Utils;
using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.PlannerInfo;
using FinancialPlannerClient.PlanOptions.Reports;


namespace FinancialPlannerClient.PlanOptions
{
    public partial class PlannerMainReport : DevExpress.XtraReports.UI.XtraReport
    {
        Client client;
        Planner planner;
        PersonalInformation personalInformation;
        int riskprofileId, optionId;
        IList<Goals> goals;
       
        public PlannerMainReport(PersonalInformation personalInformation, Planner planner,int riskProfileId,int optionId)
        {
            InitializeComponent();
            this.personalInformation = personalInformation;
            this.client = personalInformation.Client;
            this.planner = planner;
            this.riskprofileId = riskProfileId;
            this.optionId = optionId;
            this.lblClientName.Text = this.client.Name;
            this.lblPreparedFor.Text = this.client.Name;
            this.lblPreparedOn.Text = this.planner.StartDate.ToShortDateString();
            fillGoals(planner);
        }

        private void fillGoals(Planner planner)
        {
            GoalsInfo goalsInfo = new GoalsInfo();
            goals = goalsInfo.GetAll(planner.ID);
        }

        private void Detail_AfterPrint(object sender, EventArgs e)
        {
           
            //this.lblPreparedBy.Text = this.planner.p
        }

        private void PlannerMainReport_AfterPrint(object sender, EventArgs e)
        {
            WaitDialogForm waitdlg = new WaitDialogForm("Loading Report...");
            try
            {
                //TableOfContent tableOfContent = new TableOfContent(client);
                //tableOfContent.CreateDocument();

                //Introduction introduction = new Introduction(client);
                //introduction.CreateDocument();

                //WhatIsPlan whatIsPlan = new WhatIsPlan(client);
                //whatIsPlan.CreateDocument();

                //ScopeOfPlancs scopeOfPlancs = new ScopeOfPlancs(client);
                //scopeOfPlancs.CreateDocument();

                //AssumptionPage assumptionPage = new AssumptionPage(personalInformation, planner.ID);
                ////assumptionPage.LoadLayout("C:\\Application Softwares\\FinancialPlannerClient\\bin\\Debug\\AssumptionPage.repx");
                //assumptionPage.CreateDocument();

                //FamilyInfoPage familyInfo = new FamilyInfoPage(personalInformation);
                //familyInfo.CreateDocument();

                //FinancialGoalIntro financialGoalIntro = new FinancialGoalIntro(client);
                //financialGoalIntro.CreateDocument();

                FinancialClientGoal financialClientGoal = new FinancialClientGoal(this.planner, this.client, this.riskprofileId, this.optionId);
                financialClientGoal.CreateDocument();

                GoalProjectionForComplition goalProjectionForComplition = new GoalProjectionForComplition(this.planner, this.client, this.riskprofileId, this.optionId,double.Parse(financialClientGoal.lblRetirementFutureCost.Text));
                goalProjectionForComplition.CreateDocument();

                //IncomeExpenseAnalysis incomeExpenseAnalysis = new IncomeExpenseAnalysis(this.client, this.planner);
                //incomeExpenseAnalysis.CreateDocument();

                //SpendingSavingRatioReport spendingSavingRatioReport = new SpendingSavingRatioReport(this.client, this.planner.ID, this.riskprofileId, this.optionId);
                //spendingSavingRatioReport.CreateDocument();

                //SurplusPeriod surplusPeriod = new SurplusPeriod(this.client, this.planner.ID, this.riskprofileId, this.optionId);
                //surplusPeriod.CreateDocument();

                //NetWorthAnalysis netWorthAnalysis = new NetWorthAnalysis(this.client);
                //netWorthAnalysis.CreateDocument();

                //NetWorthStatement netWorthStatement = new NetWorthStatement(this.client, this.planner);
                //netWorthStatement.CreateDocument();

                //ToTotalAssetRatio toTotalAssetRatio = new ToTotalAssetRatio(this.client, netWorthStatement.GetNetWorth());
                //toTotalAssetRatio.CreateDocument();

                //NetWorthYearOnYear netWorthYearOnYear = new NetWorthYearOnYear(this.client, null);
                //netWorthYearOnYear.CreateDocument();

                //CurrentFinancialStatus currentFinancialStatus = new CurrentFinancialStatus(this.client, netWorthStatement.GetNetWorth());
                //currentFinancialStatus.CreateDocument();

                //RiskProfiling riskProfiling = new RiskProfiling(this.client);
                //riskProfiling.CreateDocument();

                ////RiskTolanceScore riskTolanceScore = new RiskTolanceScore(personalInformation);
                ////riskTolanceScore.CreateDocument();

                ////Skip some pages here. 

                //RiskProfilingAssetAllocation riskProfilingAssetAllocation = new RiskProfilingAssetAllocation(this.client, this.riskprofileId);
                //riskProfilingAssetAllocation.CreateDocument();

                //CurrentFinancialAssetAllocation currentFinancialAssetAllocation =
                //    new CurrentFinancialAssetAllocation(this.client, netWorthStatement.GetNetWorth());
                //currentFinancialAssetAllocation.CreateDocument();

                //StrategicAssetsCollection strategicAssetsCollection = new StrategicAssetsCollection(this.client, this.riskprofileId);
                //strategicAssetsCollection.CreateDocument();

                //SmartGoal smartGoal = new SmartGoal(this.client);
                //smartGoal.CreateDocument();

                //CurrentStatusReport currentStatus = new CurrentStatusReport(netWorthStatement.GetNetWorth());
                //currentStatus.CreateDocument();

                //GoalsDescription[] goalsDescriptions = null;
                //if (this.goals != null && this.goals.Count > 0)
                //{
                //    goalsDescriptions = new GoalsDescription[goals.Count];
                //    int goalCountIndex = 0;
                //    foreach (Goals goal in goals)
                //    {
                //        goalsDescriptions[goalCountIndex] = new GoalsDescription();
                //        goalsDescriptions[goalCountIndex].SetReportParameter(this.client, this.planner, goal,
                //            this.riskprofileId, this.optionId);
                //        goalsDescriptions[goalCountIndex].CreateDocument();
                //        goalCountIndex++;
                //    }
                //}

                //AssetAllocationTitle assetAllocationTitle = new AssetAllocationTitle(this.client);
                //assetAllocationTitle.CreateDocument();

                //ActionPlan actionPlan = new ActionPlan(this.client, this.planner);
                //actionPlan.CreateDocument();

                // Enable this property to maintain continuous page numbering 
                PrintingSystem.ContinuousPageNumbering = true;

                // Add all pages of the 2nd report to the end of the 1st report.             
                //this.Pages.Add(tableOfContent.Pages.First);
                //this.Pages.Add(introduction.Pages.First);
                //this.Pages.Add(whatIsPlan.Pages.First);
                //this.Pages.Add(scopeOfPlancs.Pages.First);
                //this.Pages.Add(assumptionPage.Pages.First);
                //this.Pages.Add(familyInfo.Pages.First);
                //this.Pages.Add(financialGoalIntro.Pages.First);
                //this.Pages.Add(financialClientGoal.Pages.First);
                this.Pages.Add(goalProjectionForComplition.Pages.First);
                //this.Pages.Add(incomeExpenseAnalysis.Pages.First);
                //this.Pages.Add(spendingSavingRatioReport.Pages.First);
                //this.Pages.Add(surplusPeriod.Pages.First);
                //this.Pages.Add(netWorthAnalysis.Pages.First);
                //this.Pages.Add(netWorthStatement.Pages.First);
                //this.Pages.Add(toTotalAssetRatio.Pages.First);
                //this.Pages.Add(netWorthYearOnYear.Pages.First);
                //this.Pages.Add(currentFinancialStatus.Pages.First);
                //this.Pages.Add(riskProfiling.Pages.First);
                ////this.Pages.Add(riskTolanceScore.Pages.First);
                ////Some page skip here.
                //this.Pages.Add(riskProfilingAssetAllocation.Pages.First);
                //this.Pages.Add(currentFinancialAssetAllocation.Pages.First);
                //this.Pages.Add(strategicAssetsCollection.Pages.First);
                //this.Pages.Add(smartGoal.Pages.First);

                //int goalCount = 0;
                //foreach (Goals goal in goals)
                //{
                //    this.Pages.Add(goalsDescriptions[goalCount].Pages.First);
                //    goalCount++;
                //}

                //this.Pages.Add(assetAllocationTitle.Pages.First);
                //this.Pages.Add(actionPlan.Pages.First);
                //this.Pages.Add(currentStatus.Pages.First);

                waitdlg.Close();
            }
            catch (Exception ex)
            {
                waitdlg.Close();
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                MessageBox.Show("Error occured while generating report." + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
