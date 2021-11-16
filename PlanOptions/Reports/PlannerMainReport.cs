using DevExpress.Utils;
using FinancialPlanner.Common;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.PlannerInfo;
using FinancialPlannerClient.PlanOptions.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;


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
        public bool blnTableOfContent = true;
        public bool blnIntroduction = true;
        public bool blnWhatIsPlan = true;
        public bool blnScopeOfPlan = true;
        public bool blnAssumption = true;
        public bool blnFamilyIntroduction = true;
        public bool blnFinancialGoalIntroduction = true;
        public bool blnClientFinancialGoals = true;
        public bool blnGoalProjectionComplition = true;
        public bool blnIncomeExpAnalysis = true;
        public bool blnSpendingSavingRatio = true;
        public bool blnSurplusPeriod = true;
        public bool blnNetWorthAnalysis = true;
        public bool blnNetWorthStatemet = true;
        public bool blnTotalAssetRatio = true;
        public bool blnNetWortYearOnYear = true;
        public bool blnCurrentFinancialStatus = true;
        public bool blnRiskProfilling = true;
        public bool blnRiskProfillingAssetAllocatin = true;
        public bool blnCurrentFinancialAssetAllocation = true;
        public bool blnStrategicAssetAllocation = true;
        public bool blnSmartGoal = true;
        public bool blnCurrentStatusReport = true;
        public bool blnGoalDescription = true;
        public bool blnAssetAllocationTitle = true;
        public bool blnActionPlan = true;
        public bool blnRecomendation = true;
        public bool blnExecutionSheet = true;
        public bool blnOtherRecommendation = true;
        ReportParams reportParams;

        public PlannerMainReport(PersonalInformation personalInformation, Planner plannerObj, int riskProfileId, int optionId, string recomendation = "", ReportParams reportParameters = null)
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
            this.reportParams = reportParameters;
            setDisplayParamaters();
            fillGoals(planner);

        }

        private void setDisplayParamaters()
        {
            if (this.reportParams.frmReportPage != null)
            {
                blnTableOfContent = this.reportParams.frmReportPage.blnTableOfContent;
                blnIntroduction = this.reportParams.frmReportPage.blnIntroduction;
                blnWhatIsPlan = this.reportParams.frmReportPage.blnWhatIsPlan;
                blnScopeOfPlan = this.reportParams.frmReportPage.blnScopeOfPlan;
                blnAssumption = this.reportParams.frmReportPage.blnAssumption;
                blnFamilyIntroduction = this.reportParams.frmReportPage.blnFamilyIntroduction;
                blnFinancialGoalIntroduction = this.reportParams.frmReportPage.blnFinancialGoalIntroduction;
                blnClientFinancialGoals = this.reportParams.frmReportPage.blnClientFinancialGoals;
                blnGoalProjectionComplition = this.reportParams.frmReportPage.blnGoalProjectionComplition;
                blnIncomeExpAnalysis = this.reportParams.frmReportPage.blnIncomeExpAnalysis;
                blnSpendingSavingRatio = this.reportParams.frmReportPage.blnSpendingSavingRatio;
                blnSurplusPeriod = this.reportParams.frmReportPage.blnSurplusPeriod;
                blnNetWorthAnalysis = this.reportParams.frmReportPage.blnNetWorthAnalysis;
                blnNetWorthStatemet = this.reportParams.frmReportPage.blnNetWorthStatemet;
                blnTotalAssetRatio = this.reportParams.frmReportPage.blnTotalAssetRatio;
                blnNetWortYearOnYear = this.reportParams.frmReportPage.blnNetWortYearOnYear;
                blnCurrentFinancialStatus = this.reportParams.frmReportPage.blnCurrentFinancialStatus;
                blnRiskProfilling = this.reportParams.frmReportPage.blnRiskProfilling;
                blnRiskProfillingAssetAllocatin = this.reportParams.frmReportPage.blnRiskProfillingAssetAllocatin;
                blnCurrentFinancialAssetAllocation = this.reportParams.frmReportPage.blnCurrentFinancialAssetAllocation;
                blnStrategicAssetAllocation = this.reportParams.frmReportPage.blnStrategicAssetAllocation;
                blnSmartGoal = this.reportParams.frmReportPage.blnSmartGoal;
                blnCurrentStatusReport = this.reportParams.frmReportPage.blnCurrentStatusReport;
                blnGoalDescription = this.reportParams.frmReportPage.blnGoalDescription;
                blnAssetAllocationTitle = this.reportParams.frmReportPage.blnAssetAllocationTitle;
                blnActionPlan = this.reportParams.frmReportPage.blnActionPlan;
                blnRecomendation = this.reportParams.frmReportPage.blnRecomendation;
                blnExecutionSheet = this.reportParams.frmReportPage.blnExecutionSheet;
                blnOtherRecommendation = this.reportParams.frmReportPage.blnOtherRecommendation;
            }
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
            CurrentFinancialAssetAllocation currentFinancialAssetAllocation;
            CurrentStatusReport currentStatus;
            NetWorthStatement netWorthStatement;
            CurrentFinancialStatus currentFinancialStatus;
            ExecutionSheetInfo executionSheetInfo = new ExecutionSheetInfo();
            try
            {
                if (blnTableOfContent)
                {
                    TableOfContent tableOfContent = new TableOfContent(client);
                    tableOfContent.CreateDocument();
                    this.Pages.AddRange(tableOfContent.Pages);
                }

                if (blnIntroduction)
                {
                    Introduction introduction = new Introduction(client);
                    introduction.CreateDocument();
                    this.Pages.AddRange(introduction.Pages);
                }

                if (blnWhatIsPlan)
                {
                    WhatIsPlan whatIsPlan = new WhatIsPlan(client);
                    whatIsPlan.CreateDocument();
                    this.Pages.AddRange(whatIsPlan.Pages);
                }

                if (blnScopeOfPlan)
                {
                    ScopeOfPlancs scopeOfPlancs = new ScopeOfPlancs(client);
                    scopeOfPlancs.CreateDocument();
                    this.Pages.AddRange(scopeOfPlancs.Pages);
                }

                if (blnAssumption)
                {
                    AssumptionPage assumptionPage = new AssumptionPage(personalInformation, planner.ID);
                    //assumptionPage.LoadLayout("C:\\Application Softwares\\FinancialPlannerClient\\bin\\Debug\\AssumptionPage.repx");
                    assumptionPage.CreateDocument();
                    this.Pages.AddRange(assumptionPage.Pages);
                }

                if (blnFamilyIntroduction)
                {
                    FamilyInfoPage familyInfo = new FamilyInfoPage(personalInformation);
                    familyInfo.CreateDocument();
                    this.Pages.AddRange(familyInfo.Pages);
                }

                if (blnFinancialGoalIntroduction)
                {
                    FinancialGoalIntro financialGoalIntro = new FinancialGoalIntro(client);
                    financialGoalIntro.CreateDocument();
                    this.Pages.AddRange(financialGoalIntro.Pages);
                }

                FinancialClientGoal financialClientGoal = new FinancialClientGoal(planner, this.client, this.riskprofileId, this.optionId);
                financialClientGoal.CreateDocument();
                if (blnClientFinancialGoals)
                {
                    this.Pages.AddRange(financialClientGoal.Pages);
                }

                double retirementFutureCost = 0;
                if (financialClientGoal.lblRetirementFutureCost.Text.StartsWith(planner.CurrencySymbol))
                {
                    double.TryParse(financialClientGoal.lblRetirementFutureCost.Text.Substring(planner.CurrencySymbol.Length), out retirementFutureCost);
                }
                else
                {
                    double.TryParse(financialClientGoal.lblRetirementFutureCost.Text, out retirementFutureCost);
                }


                GoalProjectionForComplition goalProjectionForComplition = new GoalProjectionForComplition(planner, this.client, this.riskprofileId, this.optionId, retirementFutureCost);
                goalProjectionForComplition.CreateDocument();
                if (blnGoalProjectionComplition)
                {
                    this.Pages.AddRange(goalProjectionForComplition.Pages);
                }


                if (blnIncomeExpAnalysis)
                {
                    IncomeExpenseAnalysis incomeExpenseAnalysis = new IncomeExpenseAnalysis(this.client, planner);
                    incomeExpenseAnalysis.CreateDocument();
                    this.Pages.AddRange(incomeExpenseAnalysis.Pages);
                }

                if (blnSurplusPeriod)
                {
                    SurplusPeriod surplusPeriod = new SurplusPeriod(this.client, planner.ID, this.riskprofileId, this.optionId);
                    surplusPeriod.CreateDocument();
                    this.Pages.AddRange(surplusPeriod.Pages);
                }


                if (blnSpendingSavingRatio)
                {
                    SpendingSavingRatioReport spendingSavingRatioReport = new SpendingSavingRatioReport(this.client, planner.ID, this.riskprofileId, this.optionId);
                    spendingSavingRatioReport.CreateDocument();
                    this.Pages.AddRange(spendingSavingRatioReport.Pages);
                }



                netWorthStatement = new NetWorthStatement(this.client, planner);
                netWorthStatement.CreateDocument();
                if (blnTotalAssetRatio)
                {
                    ToTotalAssetRatio toTotalAssetRatio = new ToTotalAssetRatio(this.client, netWorthStatement.GetNetWorth());
                    toTotalAssetRatio.CreateDocument();
                    this.Pages.AddRange(toTotalAssetRatio.Pages);
                }

                if (blnNetWorthAnalysis)
                {
                    NetWorthAnalysis netWorthAnalysis = new NetWorthAnalysis(this.client);
                    netWorthAnalysis.CreateDocument();
                    this.Pages.AddRange(netWorthAnalysis.Pages);
                }

                if (blnNetWorthStatemet)
                {
                    this.Pages.AddRange(netWorthStatement.Pages);
                }

                if (blnNetWortYearOnYear)
                {
                    NetWorthYearOnYear netWorthYearOnYear = new NetWorthYearOnYear(this.client, null);
                    netWorthYearOnYear.CreateDocument();
                    this.Pages.AddRange(netWorthYearOnYear.Pages);
                }

                currentFinancialStatus = new CurrentFinancialStatus(this.client, netWorthStatement.GetNetWorth());
                currentFinancialStatus.CreateDocument();
                if (blnCurrentFinancialStatus)
                {
                    this.Pages.AddRange(currentFinancialStatus.Pages);
                }


                if (blnRiskProfilling)
                {
                    RiskProfiling riskProfiling = new RiskProfiling(this.client);
                    riskProfiling.CreateDocument();
                    this.Pages.AddRange(riskProfiling.Pages);
                }

                if (blnRiskProfillingAssetAllocatin)
                {
                    RiskProfilingAssetAllocation riskProfilingAssetAllocation = new RiskProfilingAssetAllocation(this.client, this.riskprofileId);
                    riskProfilingAssetAllocation.CreateDocument();
                    this.Pages.AddRange(riskProfilingAssetAllocation.Pages);
                }

                if (blnCurrentFinancialAssetAllocation)
                {
                    currentFinancialAssetAllocation =
                    new CurrentFinancialAssetAllocation(this.client, netWorthStatement.GetNetWorth(), currentFinancialStatus,this.riskprofileId);
                    currentFinancialAssetAllocation.CreateDocument();
                    this.Pages.AddRange(currentFinancialAssetAllocation.Pages);
                }

                if (blnStrategicAssetAllocation)
                {
                    StrategicAssetsCollection strategicAssetsCollection = new StrategicAssetsCollection(this.client, this.riskprofileId);
                    strategicAssetsCollection.CreateDocument();
                    this.Pages.AddRange(strategicAssetsCollection.Pages);
                }
                
                if (blnSmartGoal)
                {
                    SmartGoal smartGoal = new SmartGoal(this.client);
                    smartGoal.CreateDocument();
                    this.Pages.AddRange(smartGoal.Pages);
                }

                DataTable dtGroupByGoals = financialClientGoal.GetGoalsByGroup();
                GoalsDescription[] goalsDescriptions = null;
                if (dtGroupByGoals.Rows.Count > 0 && blnGoalDescription)
                {

                    DataTable dtTempGoal = ListtoDataTable.ToDataTable(this.goals.ToList());

                    addFutureValueIntoDataTable(dtTempGoal);


                    goalsDescriptions = new GoalsDescription[dtGroupByGoals.Rows.Count];
                    int goalCountIndex = 0;
                    try
                    {
                        for (int index = 0; index <= dtGroupByGoals.Rows.Count - 1; index++)
                        {
                            if (!string.IsNullOrEmpty(dtGroupByGoals.Rows[index]["Name"].ToString()))
                            {
                                DataTable _dtGoals;
                                DataRow[] dataRows = dtTempGoal.Select("Name like '" +
                                   dtGroupByGoals.Rows[index]["Name"].ToString() + "%' and" +
                                   " LEN(TRIM(Name))  = " + dtGroupByGoals.Rows[index]["Name"].ToString().Length + " and  Recurrence <> '0' and Category ='" + dtGroupByGoals.Rows[index]["Category"] + "'");
                                if (dataRows.Count() == 0)
                                {
                                    _dtGoals = setDataBasedOnSearchCriteria(dtGroupByGoals, dtTempGoal, index);
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
                                   this.riskprofileId, this.optionId, this.goals.ToList(), dtGoalProjectComplition);
                                goalsDescriptions[goalCountIndex].CreateDocument();
                                this.Pages.AddRange(goalsDescriptions[goalCountIndex].Pages);
                                goalCountIndex++;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }

                if (blnAssetAllocationTitle)
                {
                    //TermInsurancePage assetAllocationTitle = new TermInsurancePage(this.client);
                    //assetAllocationTitle.CreateDocument();
                    //this.Pages.AddRange(assetAllocationTitle.Pages);
                }

                if (blnActionPlan || blnExecutionSheet)
                {
                    executionSheetInfo = new ExecutionSheetInfo(this.client, planner, this.optionId, this.riskprofileId);                    
                }

                if (blnActionPlan)
                {
                    TermInsurancePage actionPlan = new TermInsurancePage(this.client,executionSheetInfo.GetExeuctionSheetTable(),planner,this.riskprofileId);
                    actionPlan.CreateDocument();
                    this.Pages.AddRange(actionPlan.Pages);
                }

                if (blnRecomendation)
                {
                    Recomendation recomendation = new Recomendation(this.client, this.recomendationNote);
                    recomendation.CreateDocument();
                    this.Pages.AddRange(recomendation.Pages);
                }

                if (blnExecutionSheet)
                {
                    ExecutionSheetTable executionSheetTable = new ExecutionSheetTable(this.client, executionSheetInfo.GetExeuctionSheetTable(), planner);
                    executionSheetTable.CreateDocument();
                    this.Pages.AddRange(executionSheetTable.Pages);
                }


                ////if (blnCurrentStatusReport)
                ////{
                ////    currentStatus = new CurrentStatusReport(netWorthStatement.GetNetWorth());
                ////    currentStatus.CreateDocument();
                ////}

                if (blnOtherRecommendation)
                {
                    OtherRecommendation otherRecommendation = new OtherRecommendation(this.client, planner);
                    otherRecommendation.CreateDocument();
                    this.Pages.AddRange(otherRecommendation.Pages);
                }


                // Enable this property to maintain continuous page numbering 
                PrintingSystem.ContinuousPageNumbering = true;

                // Add all pages of the 2nd report to the end of the 1st report.             




















                //this.Pages.Add(riskTolanceScore.Pages.First);
                //Some page skip here.

                
                
               

                

             
               
                
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

        private static DataTable setDataBasedOnSearchCriteria(DataTable dtGroupByGoals, DataTable dtTempGoal, int index)
        {
            DataTable _dtGoals;
            int length = dtGroupByGoals.Rows[index]["Name"].ToString().Trim().Length + 5;
            DataRow[] drs = dtTempGoal.Select("Name like '" +
             dtGroupByGoals.Rows[index]["Name"].ToString().Trim() + "%'  AND LEN(TRIM(NAME)) = " + length);
            if (drs.Length > 0)
            {
                _dtGoals = drs.CopyToDataTable();
            }
            else
            {
                _dtGoals = dtTempGoal.Select("Name like '" + dtGroupByGoals.Rows[index]["Name"].ToString().Trim() + "%'").CopyToDataTable();
            }

            return _dtGoals;
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
