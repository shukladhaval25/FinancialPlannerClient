﻿using FinancialPlanner.Common;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.CurrentStatus;
using FinancialPlanner.Common.Model.PlanOptions;
using FinancialPlannerClient.CashFlowManager;
using FinancialPlannerClient.CurrentStatus;
using FinancialPlannerClient.PlannerInfo;
using FinancialPlannerClient.RiskProfile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class GoalProjectionForComplition : DevExpress.XtraReports.UI.XtraReport
    {
        private readonly string GET_INSTRUMENTMAPPED_TO_GOAL_API = "CurrentStatusInstrument/Get?plannerId={0}&goalId={1}";
        DataTable _dtGoals = new DataTable();
        DataTable dtGroupOfGoals = new DataTable();
        Client client;
        Planner planner;
        List<Goals> lstGoal;
        int riskProfileId, optionId;
        double retirementEstimatedCorpusFund = 0;
        GoalCalculationManager goalCalManager;
        CashFlowService cashFlowService = new CashFlowService();
        IList<FinancialPlanner.Common.Model.PlanOptions.CurrentStatusToGoal> currentStatusToGoals;
        public GoalProjectionForComplition(Planner planner, Client client, int riskProfileID, int optionId,
            double retirementEstimatedCorpus, IList<Goals> goals)
        {
            InitializeComponent();
            this.client = client;
            this.planner = planner;
            this.lblClientName.Text = client.Name;
            this.riskProfileId = riskProfileID;
            this.optionId = optionId;
            this.retirementEstimatedCorpusFund = retirementEstimatedCorpus;
            GoalsInfo GoalsInfo = new GoalsInfo();
            if (goals.Count > 0)
                lstGoal = goals.ToList();

            cashFlowService.GetCashFlow(this.optionId);
            cashFlowService.GenerateCashFlow(this.client.ID, this.planner.ID, this.riskProfileId);
            goalCalManager = cashFlowService.GoalCalculationMgr;
            CashFlow cf = cashFlowService.GetCashFlow(this.optionId);

            CurrentStatusInfo csInfo = new CurrentStatusInfo();
            currentStatusToGoals = csInfo.GetCurrentStatusToGoal(this.optionId, this.planner.ID);

            _dtGoals = ListtoDataTable.ToDataTable(lstGoal);
            _dtGoals.Columns.Add("ProjectionCompleted", typeof(System.Int64));
            _dtGoals.Columns.Add("GoalAchivedTillDate", typeof(System.Double));
            _dtGoals.Columns.Add("MappedFromCurrentStatus", typeof(System.Double));
            _dtGoals.Columns.Add("GoalReached", typeof(System.Int64));

            addFutureValueIntoDataTable();
            groupTogetherRecurrenceGoal();


            this.DataSource = _dtGoals;
            this.DataMember = _dtGoals.TableName;

            this.lblGoalID.DataBindings.Add("Text", this.DataSource, "Goals.ID");
            this.lblName.DataBindings.Add("Text", this.DataSource, "Goals.Name");
            this.lblStartYear.DataBindings.Add("Text", this.DataSource, "Goals.StartYear");
            this.lblProjectionCompleted.DataBindings.Add("Text", this.DataSource, "Goals.ProjectionCompleted");
            this.lblGoalAchiveTillDate.DataBindings.Add("Text", this.DataSource, "Goals.GoalAchivedTillDate");
            this.lblGoalReachedPercentage.DataBindings.Add("Text", this.DataSource, "Goals.GoalReached");

        }

        private void lblStartYear_TextChanged(object sender, System.EventArgs e)
        {
            if (lblStartYear.Text != "")
            {
                int goalStartYear;
                if (int.TryParse(lblStartYear.Text, out goalStartYear))
                {
                    lblYearLeft.Text = (goalStartYear - planner.StartDate.Year).ToString();
                }
            }
        }

        private void groupTogetherRecurrenceGoal()
        {
            List<string> groupOfGoal = new List<string>();

            dtGroupOfGoals = _dtGoals.Clone();
            GoalCalView goalCalView = new GoalCalView(this.planner, this.riskProfileId, this.optionId);
            for (int i = 0; i < _dtGoals.Rows.Count; i++)
            {
                string goalName = (_dtGoals.Rows[i]["Name"].ToString().Length > 4) ? _dtGoals.Rows[i]["Name"].ToString().Substring(0, _dtGoals.Rows[i]["Name"].ToString().Length - 4).Trim() :
              _dtGoals.Rows[i]["Name"].ToString();

                goalName = setGoalNameWithRecurranceValidation(i, goalName);
                if (!groupOfGoal.Contains(goalName))
                {
                    string goalCategory = _dtGoals.Rows[i]["Category"].ToString();
                    double amount = 0;
                    double projectionCompletedPercentage = 0;
                    double futureValue = 0;
                    string endYear = "";
                    double totalCurrentStatusMapValue = 0;
                    double totalOnlyForMappedCurrentStatusValue = 0;
                    int totalGoalReacedPercentage = 0;


                    int goalComplitionPercentage = getGoalComlitionPercentage(i, goalCalView);
                    int goalId = int.Parse(_dtGoals.Rows[i]["Id"].ToString());
                    double currentStatusMapAmount = getCurrentStatusFundForMappedGoal(goalId);
                    _dtGoals.Rows[i]["MappedFromCurrentStatus"] = currentStatusMapAmount;
                    currentStatusMapAmount = currentStatusMapAmount + getNonFinancialAssetMapping(goalId) + getFinancialAssetsMapping(goalId);
                    _dtGoals.Rows[i]["ProjectionCompleted"] = goalComplitionPercentage;
                    _dtGoals.Rows[i]["GoalAchivedTillDate"] = currentStatusMapAmount;
                    _dtGoals.Rows[i]["GoalReached"] = ((currentStatusMapAmount * 100) / double.Parse(_dtGoals.Rows[i]["FutureValue"].ToString()));
                    int recurrence = 0;

                    if (_dtGoals.Rows[i]["Recurrence"] != null & int.Parse(_dtGoals.Rows[i]["Recurrence"].ToString()) >= 1)
                    {
                        if (!groupOfGoal.Contains(goalName))
                        {
                            //DataRow[] drs = _dtGoals.Select("Name like '" + goalName + "%' and Category ='" + goalCategory + "' and Recurrence = '" + _dtGoals.Rows[i]["Recurrence"].ToString() + "'");
                            //foreach (DataRow dataRow in drs)
                            //{
                            //    goalComplitionPercentage = getGoalComlitionPercentage(dataRow["Name"].ToString(), goalCalView);
                            //    currentStatusMapAmount = getCurrentStatusFundForMappedGoal(int.Parse(dataRow["ID"].ToString()));
                            //    _dtGoals.Rows[i]["MappedFromCurrentStatus"] = currentStatusMapAmount;
                            //    totalOnlyForMappedCurrentStatusValue = totalOnlyForMappedCurrentStatusValue + currentStatusMapAmount;

                            //    dataRow["ProjectionCompleted"] = goalComplitionPercentage;

                            //    currentStatusMapAmount = currentStatusMapAmount + getNonFinancialAssetMapping(int.Parse(dataRow["ID"].ToString()));

                            //    dataRow["GoalAchivedTillDate"] = currentStatusMapAmount;
                            //    dataRow["GoalReached"] = ((currentStatusMapAmount * 100) / double.Parse(dataRow["FutureValue"].ToString()));

                            //    amount = amount + double.Parse(dataRow["Amount"].ToString());
                            //    futureValue = (dataRow["Category"].ToString().Trim().Equals("Retirement")) ? retirementEstimatedCorpusFund :
                            //           futureValue + double.Parse(_dtGoals.Rows[i]["FutureValue"].ToString());
                            //    totalCurrentStatusMapValue = totalCurrentStatusMapValue + currentStatusMapAmount;
                            //    totalGoalReacedPercentage = totalGoalReacedPercentage + int.Parse(dataRow["GoalReached"].ToString());
                            //    projectionCompletedPercentage = projectionCompletedPercentage + double.Parse(dataRow["ProjectionCompleted"].ToString());
                            //    endYear = dataRow["StartYear"].ToString();
                            //    recurrence++;
                            //}



                            for (int innerLoopIndex = i; innerLoopIndex < this._dtGoals.Rows.Count; innerLoopIndex++)
                            {
                                if (_dtGoals.Rows[i]["Recurrence"].ToString().Equals(_dtGoals.Rows[innerLoopIndex]["Recurrence"].ToString()) &&
                                    _dtGoals.Rows[innerLoopIndex]["Category"].ToString().Equals(goalCategory) &&
                                    _dtGoals.Rows[innerLoopIndex]["Name"].ToString().Substring(0,
                                     (_dtGoals.Rows[innerLoopIndex]["Name"].ToString().Length > 4) ?
                                    _dtGoals.Rows[innerLoopIndex]["Name"].ToString().Length - 4 :
                                    _dtGoals.Rows[innerLoopIndex]["Name"].ToString().Length).Trim().Equals(goalName))
                                {
                                    goalComplitionPercentage = getGoalComlitionPercentage(innerLoopIndex, goalCalView);
                                    currentStatusMapAmount = getCurrentStatusFundForMappedGoal(int.Parse(_dtGoals.Rows[innerLoopIndex]["ID"].ToString()));
                                    _dtGoals.Rows[i]["MappedFromCurrentStatus"] = currentStatusMapAmount;
                                    totalOnlyForMappedCurrentStatusValue = totalOnlyForMappedCurrentStatusValue + currentStatusMapAmount;

                                    _dtGoals.Rows[innerLoopIndex]["ProjectionCompleted"] = goalComplitionPercentage;

                                    currentStatusMapAmount = currentStatusMapAmount + getNonFinancialAssetMapping(int.Parse(_dtGoals.Rows[innerLoopIndex]["ID"].ToString()));

                                    _dtGoals.Rows[innerLoopIndex]["GoalAchivedTillDate"] = currentStatusMapAmount;
                                    _dtGoals.Rows[innerLoopIndex]["GoalReached"] = ((currentStatusMapAmount * 100) / double.Parse(_dtGoals.Rows[innerLoopIndex]["FutureValue"].ToString()));

                                    amount = amount + double.Parse(_dtGoals.Rows[innerLoopIndex]["Amount"].ToString());
                                    futureValue = futureValue + double.Parse(_dtGoals.Rows[innerLoopIndex]["FutureValue"].ToString());
                                    totalCurrentStatusMapValue = totalCurrentStatusMapValue + currentStatusMapAmount;
                                    totalGoalReacedPercentage = totalGoalReacedPercentage + int.Parse(_dtGoals.Rows[innerLoopIndex]["GoalReached"].ToString());
                                    projectionCompletedPercentage = projectionCompletedPercentage + double.Parse(_dtGoals.Rows[innerLoopIndex]["ProjectionCompleted"].ToString());
                                    //dtGroupOfGoals.Rows.Add(_dtGoals.Rows[innerLoopIndex]);
                                    endYear = _dtGoals.Rows[innerLoopIndex]["StartYear"].ToString();
                                    recurrence++;
                                }
                                else
                                {
                                    if (_dtGoals.Rows[innerLoopIndex]["Name"].ToString().Trim().Equals(goalName.Trim()))
                                    {
                                        amount = amount + double.Parse(_dtGoals.Rows[i]["Amount"].ToString());
                                        futureValue = (_dtGoals.Rows[innerLoopIndex]["Category"].ToString().Trim().Equals("Retirement")) ? retirementEstimatedCorpusFund :
                                            futureValue + double.Parse(_dtGoals.Rows[i]["FutureValue"].ToString());

                                        totalGoalReacedPercentage = totalGoalReacedPercentage + int.Parse(_dtGoals.Rows[i]["GoalReached"].ToString());
                                        projectionCompletedPercentage = projectionCompletedPercentage + double.Parse(_dtGoals.Rows[i]["ProjectionCompleted"].ToString());
                                        //dtGroupOfGoals.Rows.Add(_dtGoals.Rows[innerLoopIndex]);
                                        endYear = _dtGoals.Rows[i]["StartYear"].ToString();
                                        currentStatusMapAmount = getCurrentStatusFundForMappedGoal(int.Parse(_dtGoals.Rows[innerLoopIndex]["ID"].ToString()));
                                        _dtGoals.Rows[i]["MappedFromCurrentStatus"] = currentStatusMapAmount;
                                        totalOnlyForMappedCurrentStatusValue = totalOnlyForMappedCurrentStatusValue + currentStatusMapAmount;

                                        currentStatusMapAmount = currentStatusMapAmount + getNonFinancialAssetMapping(int.Parse(_dtGoals.Rows[innerLoopIndex]["ID"].ToString()));

                                        totalCurrentStatusMapValue = totalCurrentStatusMapValue + currentStatusMapAmount;
                                        recurrence++;
                                        break;
                                    }
                                }
                            }
                        }
                        if (!groupOfGoal.Contains(goalName))
                        {
                            groupOfGoal.Add(goalName);
                            DataRow dr = dtGroupOfGoals.NewRow();
                            dr["Name"] = goalName;
                            dr["Category"] = goalCategory;
                            dr["Amount"] = amount;
                            dr["FutureValue"] = futureValue;
                            dr["ProjectionCompleted"] = (projectionCompletedPercentage > 0) ? (projectionCompletedPercentage / recurrence) : 0;
                            dr["GoalAchivedTillDate"] = totalCurrentStatusMapValue;
                            dr["MappedFromCurrentStatus"] = totalOnlyForMappedCurrentStatusValue;
                            dr["GoalReached"] = (totalCurrentStatusMapValue > 0) ?
                                (totalCurrentStatusMapValue * 100) / futureValue : 0;
                            dr["StartYear"] = _dtGoals.Rows[i]["StartYear"];
                            dr["EndYear"] = endYear;
                            dr["Priority"] = _dtGoals.Rows[i]["Priority"];
                            dr["Recurrence"] = recurrence;
                            dr["InflationRate"] = _dtGoals.Rows[i]["InflationRate"];
                            dtGroupOfGoals.Rows.Add(dr);
                        }
                    }
                }
            }
            _dtGoals.Clear();

            foreach (DataRow dataRow in dtGroupOfGoals.Rows)
            {
                DataRow dr = _dtGoals.NewRow();
                dr["Name"] = dataRow["Name"];
                dr["Category"] = dataRow["Category"];
                dr["Amount"] = dataRow["Amount"];
                dr["FutureValue"] = dataRow["FutureValue"];
                dr["ProjectionCompleted"] = dataRow["ProjectionCompleted"];
                dr["GoalAchivedTillDate"] = dataRow["GoalAchivedTillDate"];
                dr["GoalReached"] = dataRow["GoalReached"];
                dr["StartYear"] = dataRow["StartYear"];
                dr["EndYear"] = dataRow["EndYear"];
                dr["Priority"] = dataRow["Priority"];
                dr["Recurrence"] = dataRow["Recurrence"];
                dr["InflationRate"] = dataRow["InflationRate"];
                dr["GoalReached"] = dataRow["GoalReached"];
                _dtGoals.Rows.Add(dr);
            }
        }

        private double getFinancialAssetsMapping(int goalId)
        {
            //GoalsValueCalculationInfo goalsValueCal;
            Goals goal = lstGoal.First(i => i.Id == goalId);
            //goalsValueCal = goalCalManager.GetGoalValueCalculation(goal);
            //return goalsValueCal.FutureValueOfMappedInstruments;
            
            IList<CurrentStatusInstrument> currentStatusInstrument = GetMappedInstrument(this.planner.ID , goalId);
            return getTotalFinancialInstrumentMappedValue(currentStatusInstrument, goal);

        }
        private double getTotalFinancialInstrumentMappedValue(IList<CurrentStatusInstrument> currentStatusInstrument,Goals goal)
        {
            double totalMappedInstrumentValue = 0;
            if (currentStatusInstrument != null)
            {
                foreach (CurrentStatusInstrument currentStatus in currentStatusInstrument)
                {
                    totalMappedInstrumentValue = totalMappedInstrumentValue +
                        futureValue(currentStatus.Amount, (decimal)currentStatus.Roi, getRemainingYearsFromPlanStartYear(goal, this.planner));
                }
            }
            return totalMappedInstrumentValue;
        }

        private int getRemainingYearsFromPlanStartYear(Goals goal, Planner planner)
        {
            if (goal == null)
            {

            }
            else
            {
                if (int.Parse(goal.StartYear) > planner.StartDate.Year)
                {
                    return int.Parse(goal.StartYear) - planner.StartDate.Year;
                }
            }
            return 0;
        }
        public IList<CurrentStatusInstrument> GetMappedInstrument(int plannerId, int goalId)
        {
            IList<CurrentStatusInstrument> currentStatusInstrument = new List<CurrentStatusInstrument>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + string.Format(GET_INSTRUMENTMAPPED_TO_GOAL_API, plannerId, goalId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<CurrentStatusInstrument>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    currentStatusInstrument = jsonSerialization.DeserializeFromString<IList<CurrentStatusInstrument>>(restResult.ToString());
                }
                return currentStatusInstrument;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                return null;
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

        private double getNonFinancialAssetMapping(int goalId)
        {
            NonFinancialAssetInfo nonFinancialAssetInfo = new NonFinancialAssetInfo();
            IList<NonFinancialAsset> nonFinancialAssets = nonFinancialAssetInfo.GetWithMappedGoal(goalId);
            double sumOfNonFinancialAsset = 0;
            if (nonFinancialAssets != null)
            {
                foreach (NonFinancialAsset nfa in nonFinancialAssets)
                {
                    double primaryHolderShare = (nfa.CurrentValue * nfa.PrimaryholderShare) / 100;
                    double secondaryHolderShare = (nfa.CurrentValue * nfa.SecondaryHolderShare) / 100;
                    double assetsMappingShare = ((primaryHolderShare + secondaryHolderShare) * double.Parse(nfa.AssetMappingShare.ToString())) / 100;

                    //int timePeriod = getRemainingYearsFromPlanStartYear();
                    //decimal inflationRate = nfa.GrowthPercentage;
                    sumOfNonFinancialAsset = sumOfNonFinancialAsset + assetsMappingShare;
                    //futureValue(assetsMappingShare, inflationRate, timePeriod);
                }

            }
            return sumOfNonFinancialAsset;
        }

        internal DataTable GetGoalProjectionTable()
        {
            return dtGroupOfGoals;
        }

        private string setGoalNameWithRecurranceValidation(int i, string goalName)
        {
            string getGoalYearFormName = (_dtGoals.Rows[i]["Name"].ToString().Length > 4) ? _dtGoals.Rows[i]["Name"].ToString().Substring(_dtGoals.Rows[i]["Name"].ToString().Length - 4).Trim() :
                _dtGoals.Rows[i]["Name"].ToString();
            int year = 0;
            if (!int.TryParse(getGoalYearFormName, out year))
            {
                goalName = _dtGoals.Rows[i]["Name"].ToString();
            }

            return goalName;
        }

        private int getGoalComlitionPercentage(int i, GoalCalView goalCalView)
        {
            Goals goal = lstGoal.First(y => y.Name == _dtGoals.Rows[i]["Name"].ToString());

            int goalComplitionPercentage = 0;
            if (goal != null)
            {

                goalCalView.setCashFlowService(cashFlowService);

                goalCalView.displayCalculation(goal);
                goalComplitionPercentage = goalCalView.GetGoalComplitionPercentage(goal);
            }

            return goalComplitionPercentage;
        }
        private int getGoalComlitionPercentage(string goalname, GoalCalView goalCalView)
        {
            Goals goal = lstGoal.First(y => y.Name == goalname.Trim());

            int goalComplitionPercentage = 0;
            if (goal != null)
            {

                goalCalView.setCashFlowService(cashFlowService);

                goalCalView.displayCalculation(goal);
                goalComplitionPercentage = goalCalView.GetGoalComplitionPercentage(goal);
            }

            return goalComplitionPercentage;
        }
        private void addFutureValueIntoDataTable()
        {
            _dtGoals.Columns.Add("FutureValue", typeof(System.Double));
            foreach (DataRow dr in _dtGoals.Rows)
            {
                int years = (!string.IsNullOrEmpty(dr["StartYear"].ToString())) ?
                int.Parse(dr["StartYear"].ToString()) - planner.StartDate.Year : 0;
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

        private void lblGoalReachedPercentage_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblGoalReachedPercentage.Text = lblGoalReachedPercentage.Text + " %";
        }

        private void lblProjectionCompleted_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblProjectionCompleted.Text = lblProjectionCompleted.Text + " %";
        }

        private void lblGoalAchiveTillDate_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblGoalAchiveTillDate.Text) && !lblGoalAchiveTillDate.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                lblGoalAchiveTillDate.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblGoalAchiveTillDate.Text).ToString("N0", PlannerMainReport.Info);
            }
            else if (!string.IsNullOrEmpty(lblGoalAchiveTillDate.Text))
            {
                lblGoalAchiveTillDate.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblGoalAchiveTillDate.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private double getCurrentStatusFundForMappedGoal(int goalId)
        {
            Goals goal = lstGoal.First(i => i.Id == goalId);
            if (goal.Category.Equals("Retirement"))
            {
                GoalStatusView goalStatusView = new GoalStatusView(this.planner, this.riskProfileId, this.optionId);
                return goalStatusView.GetAccessFundValueForRetirementCorpus();
            }

            IEnumerable<FinancialPlanner.Common.Model.PlanOptions.CurrentStatusToGoal> currentStatusToGoalLst = currentStatusToGoals.Where(i => i.GoalId == goalId);
            double mappedFund = 0;
            foreach (FinancialPlanner.Common.Model.PlanOptions.CurrentStatusToGoal toGoal in currentStatusToGoalLst)
            {
                mappedFund = mappedFund + toGoal.FundAllocation;
            }
            mappedFund = mappedFund + getFinancialAssetsMapping(goal.Id);

            return mappedFund;
            //return csInfo.GetFundFromCurrentStatus (this.planner.ID , id);
        }
    }
}
