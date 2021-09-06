using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using DevExpress.Utils;
using FinancialPlanner.Common;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.PlannerInfo;
using FinancialPlannerClient.PlanOptions.Reports;


namespace FinancialPlannerClient.PlanOptions
{
    public partial class PlannerMainReport : DevExpress.XtraReports.UI.XtraReport
    {
        Client client;
        public static Planner planner;
        PersonalInformation personalInformation;
        int riskprofileId, optionId;
        IList<Goals> goals;
        string recomendationNote;
        public static System.Globalization.CultureInfo Info;
        public PlannerMainReport(PersonalInformation personalInformation, Planner plannerObj,int riskProfileId,int optionId,string recomendation="")
        {
            InitializeComponent();
            Info = System.Globalization.CultureInfo.GetCultureInfo("en-IN");
            this.personalInformation = personalInformation;
            this.client = personalInformation.Client;
            planner = plannerObj;
            this.riskprofileId = riskProfileId;
            this.optionId = optionId;
            this.lblClientName.Text = this.client.Name;
            this.lblPreparedFor.Text = this.client.Name;
            this.lblPreparedOn.Text = planner.StartDate.ToString("dd-MMM-yyyy");
            this.recomendationNote = recomendation;
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
                TableOfContent tableOfContent = new TableOfContent(client);
                tableOfContent.CreateDocument();

                Introduction introduction = new Introduction(client);
                introduction.CreateDocument();

                WhatIsPlan whatIsPlan = new WhatIsPlan(client);
                whatIsPlan.CreateDocument();

                ScopeOfPlancs scopeOfPlancs = new ScopeOfPlancs(client);
                scopeOfPlancs.CreateDocument();

                AssumptionPage assumptionPage = new AssumptionPage(personalInformation, planner.ID);
                //assumptionPage.LoadLayout("C:\\Application Softwares\\FinancialPlannerClient\\bin\\Debug\\AssumptionPage.repx");
                assumptionPage.CreateDocument();

                FamilyInfoPage familyInfo = new FamilyInfoPage(personalInformation);
                familyInfo.CreateDocument();

                FinancialGoalIntro financialGoalIntro = new FinancialGoalIntro(client);
                financialGoalIntro.CreateDocument();

                FinancialClientGoal financialClientGoal = new FinancialClientGoal(planner, this.client, this.riskprofileId, this.optionId);
                financialClientGoal.CreateDocument();

                double retirementFutureCost = 0;
                if (financialClientGoal.lblRetirementFutureCost.Text.StartsWith(planner.CurrencySymbol))
                {
                    double.TryParse(financialClientGoal.lblRetirementFutureCost.Text.Substring(planner.CurrencySymbol.Length),out retirementFutureCost);
                }
                else
                {
                    double.TryParse(financialClientGoal.lblRetirementFutureCost.Text, out retirementFutureCost);
                }
                
                GoalProjectionForComplition goalProjectionForComplition = new GoalProjectionForComplition(planner, this.client, this.riskprofileId, this.optionId, retirementFutureCost);
                goalProjectionForComplition.CreateDocument();

                IncomeExpenseAnalysis incomeExpenseAnalysis = new IncomeExpenseAnalysis(this.client, planner);
                incomeExpenseAnalysis.CreateDocument();

                SpendingSavingRatioReport spendingSavingRatioReport = new SpendingSavingRatioReport(this.client, planner.ID, this.riskprofileId, this.optionId);
                spendingSavingRatioReport.CreateDocument();

                SurplusPeriod surplusPeriod = new SurplusPeriod(this.client, planner.ID, this.riskprofileId, this.optionId);
                surplusPeriod.CreateDocument();

                NetWorthAnalysis netWorthAnalysis = new NetWorthAnalysis(this.client);
                netWorthAnalysis.CreateDocument();

                NetWorthStatement netWorthStatement = new NetWorthStatement(this.client, planner);
                netWorthStatement.CreateDocument();

                ToTotalAssetRatio toTotalAssetRatio = new ToTotalAssetRatio(this.client, netWorthStatement.GetNetWorth());
                toTotalAssetRatio.CreateDocument();

                NetWorthYearOnYear netWorthYearOnYear = new NetWorthYearOnYear(this.client, null);
                netWorthYearOnYear.CreateDocument();

                CurrentFinancialStatus currentFinancialStatus = new CurrentFinancialStatus(this.client, netWorthStatement.GetNetWorth());
                currentFinancialStatus.CreateDocument();

                RiskProfiling riskProfiling = new RiskProfiling(this.client);
                riskProfiling.CreateDocument();

                //RiskTolanceScore riskTolanceScore = new RiskTolanceScore(personalInformation);
                //riskTolanceScore.CreateDocument();

                //Skip some pages here. 

                RiskProfilingAssetAllocation riskProfilingAssetAllocation = new RiskProfilingAssetAllocation(this.client, this.riskprofileId);
                riskProfilingAssetAllocation.CreateDocument();

                CurrentFinancialAssetAllocation currentFinancialAssetAllocation =
                    new CurrentFinancialAssetAllocation(this.client, netWorthStatement.GetNetWorth(), currentFinancialStatus);
                currentFinancialAssetAllocation.CreateDocument();

                StrategicAssetsCollection strategicAssetsCollection = new StrategicAssetsCollection(this.client, this.riskprofileId);
                strategicAssetsCollection.CreateDocument();

                SmartGoal smartGoal = new SmartGoal(this.client);
                smartGoal.CreateDocument();

                CurrentStatusReport currentStatus = new CurrentStatusReport(netWorthStatement.GetNetWorth());
                currentStatus.CreateDocument();
               
                DataTable dtGroupByGoals =  financialClientGoal.GetGoalsByGroup();
                GoalsDescription[] goalsDescriptions = null;
                if (dtGroupByGoals.Rows.Count > 0)
                {

                    DataTable dtTempGoal = ListtoDataTable.ToDataTable(this.goals.ToList());

                    addFutureValueIntoDataTable(dtTempGoal);


                    goalsDescriptions = new GoalsDescription[dtGroupByGoals.Rows.Count];
                    int goalCountIndex = 0;
                    try
                    {
                        for (int index = 0; index <= dtGroupByGoals.Rows.Count - 1; index++)
                        {
                            DataTable _dtGoals;
                            DataRow[] dataRows = dtTempGoal.Select("Name like '" +
                               dtGroupByGoals.Rows[index]["Name"].ToString() + "%' and" +
                               " LEN(TRIM(Name))  = " + dtGroupByGoals.Rows[index]["Name"].ToString().Length + " and  Recurrence <> '0' and Category ='" + dtGroupByGoals.Rows[index]["Category"] + "'");
                            if (dataRows.Count() == 0)
                            {
                                _dtGoals = dtTempGoal.Select("Name like '" +
                              dtGroupByGoals.Rows[index]["Name"].ToString().Trim() + "%'").CopyToDataTable();
                            }
                            else
                            {
                                _dtGoals = dtTempGoal.Select("Name like '" +
                              dtGroupByGoals.Rows[index]["Name"].ToString().Trim() + "%'  and" +
                              " LEN(TRIM(Name))  = " + dtGroupByGoals.Rows[index]["Name"].ToString().Length + " and Recurrence <> '0' and Category ='" + dtGroupByGoals.Rows[index]["Category"] + "'").CopyToDataTable();
                            }
                            //    ListtoDataTable.ToDataTable(
                            //goals.Where(x => x.Name.StartsWith(dtGroupByGoals.Rows[index]["Name"].ToString())).ToList());
                            goalsDescriptions[goalCountIndex] = new GoalsDescription();
                            DataTable dtGoalProjectComplition = goalProjectionForComplition.GetGoalProjectionTable();
                            goalsDescriptions[goalCountIndex].SetReportParameter(this.client, planner, _dtGoals,
                               this.riskprofileId, this.optionId, this.goals.ToList(),dtGoalProjectComplition);
                            goalsDescriptions[goalCountIndex].CreateDocument();
                            goalCountIndex++;
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }


                    //foreach (Goals goal in goals)
                    //{
                    //    goalsDescriptions[goalCountIndex] = new GoalsDescription();
                    //    goalsDescriptions[goalCountIndex].SetReportParameter(this.client, this.planner, goal,
                    //        this.riskprofileId, this.optionId);
                    //    goalsDescriptions[goalCountIndex].CreateDocument();
                    //    goalCountIndex++;
                    //}
                }

                AssetAllocationTitle assetAllocationTitle = new AssetAllocationTitle(this.client);
                assetAllocationTitle.CreateDocument();

                ActionPlan actionPlan = new ActionPlan(this.client, planner);
                actionPlan.CreateDocument();

                Recomendation recomendation = new Recomendation(this.client,this.recomendationNote);
                recomendation.CreateDocument();

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
                
                this.Pages.Add(surplusPeriod.Pages.First);
                this.Pages.Add(spendingSavingRatioReport.Pages.First);

                this.Pages.Add(toTotalAssetRatio.Pages.First);
                this.Pages.Add(netWorthAnalysis.Pages.First);
                this.Pages.Add(netWorthStatement.Pages.First);
               
                this.Pages.Add(netWorthYearOnYear.Pages.First);
                this.Pages.Add(currentFinancialStatus.Pages.First);
                this.Pages.Add(riskProfiling.Pages.First);
                //this.Pages.Add(riskTolanceScore.Pages.First);
                //Some page skip here.
                this.Pages.Add(riskProfilingAssetAllocation.Pages.First);
                this.Pages.Add(currentFinancialAssetAllocation.Pages.First);
                this.Pages.Add(strategicAssetsCollection.Pages.First);
                this.Pages.Add(smartGoal.Pages.First);

                for (int index = 0; index <= dtGroupByGoals.Rows.Count - 1; index++)
                {
                    this.Pages.Add(goalsDescriptions[index].Pages.First);
                }

                this.Pages.Add(assetAllocationTitle.Pages.First);
                this.Pages.Add(actionPlan.Pages.First);
                this.Pages.Add(recomendation.Pages.First);
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

        private void addFutureValueIntoDataTable(DataTable _dtGoals)
        {
            _dtGoals.Columns.Add("FutureValue", typeof(System.Double));
            foreach (DataRow dr in _dtGoals.Rows)
            {
                int years = (!string.IsNullOrEmpty(dr["StartYear"].ToString())) ?
                int.Parse(dr["StartYear"].ToString()) - planner.StartDate.Year : 0;
                dr["Amount"] = double.Parse(dr["Amount"].ToString()) + double.Parse(dr["OtherAmount"].ToString());
                dr["FutureValue"] = futureValue(double.Parse(dr["Amount"].ToString()),
                    decimal.Parse(dr["InflationRate"].ToString()), years);
            }
        }

        private static double futureValue(double presentValue, decimal interest_rate, int timePeriodInYears)
        {
            //FV = PV * (1 + I)T;
            interest_rate = interest_rate / 100;
            decimal futureValue = (decimal)presentValue *
                ((decimal)Math.Pow((double)(1 + interest_rate), (double)timePeriodInYears));

            return Math.Round((double)futureValue);
        }
    }
}
