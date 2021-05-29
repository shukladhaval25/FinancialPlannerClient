using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.PlanOptions;
using FinancialPlannerClient.CashFlowManager;
using FinancialPlannerClient.CurrentStatus;
using FinancialPlannerClient.PlannerInfo;
using FinancialPlannerClient.RiskProfile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class GoalProjectionForComplition : DevExpress.XtraReports.UI.XtraReport
    {
        DataTable _dtGoals = new DataTable();
        DataTable dtGroupOfGoals = new DataTable();
        Client client;
        Planner planner;
        List<Goals> lstGoal;
        int riskProfileId,optionId;
        double retirementEstimatedCorpusFund = 0;
        public GoalProjectionForComplition(Planner planner, Client client, int riskProfileID,int optionId,double retirementEstimatedCorpus)
        {
            InitializeComponent();
            this.client = client;
            this.planner = planner;
            this.lblClientName.Text = client.Name;
            this.riskProfileId = riskProfileID;
            this.optionId = optionId;
            this.retirementEstimatedCorpusFund = retirementEstimatedCorpus;
            GoalsInfo GoalsInfo = new GoalsInfo();
            lstGoal = (List<Goals>)GoalsInfo.GetAll(planner.ID);
            _dtGoals = ListtoDataTable.ToDataTable(lstGoal);
            _dtGoals.Columns.Add("ProjectionCompleted", typeof(System.Int64));
            _dtGoals.Columns.Add("GoalAchivedTillDate", typeof(System.Double));
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
                    int totalGoalReacedPercentage = 0;
                    GoalCalView goalCalView = new GoalCalView(this.planner, this.riskProfileId, this.optionId);

                    int goalComplitionPercentage = getGoalComlitionPercentage(i, goalCalView);
                    double currentStatusMapAmount = getCurrentStatusFundForMappedGoal(int.Parse(_dtGoals.Rows[i]["Id"].ToString()));
                    _dtGoals.Rows[i]["ProjectionCompleted"] = goalComplitionPercentage;
                    _dtGoals.Rows[i]["GoalAchivedTillDate"] = currentStatusMapAmount;
                    _dtGoals.Rows[i]["GoalReached"] = ((currentStatusMapAmount * 100) / double.Parse(_dtGoals.Rows[i]["FutureValue"].ToString()));
                    int recurrence = 0;

                    if (_dtGoals.Rows[i]["Recurrence"] != null & int.Parse(_dtGoals.Rows[i]["Recurrence"].ToString()) >= 1)
                    {
                        if (!groupOfGoal.Contains(goalName))
                        {
                            for (int innerLoopIndex = i; innerLoopIndex < this._dtGoals.Rows.Count; innerLoopIndex++)
                            {
                                if (_dtGoals.Rows[i]["Recurrence"].ToString().Equals(_dtGoals.Rows[innerLoopIndex]["Recurrence"].ToString()) &&
                                    _dtGoals.Rows[innerLoopIndex]["Category"].ToString().Equals(goalCategory) &&
                                    _dtGoals.Rows[innerLoopIndex]["Name"].ToString().Substring(0, _dtGoals.Rows[innerLoopIndex]["Name"].ToString().Length - 4).Trim().Equals(goalName))
                                {
                                    goalComplitionPercentage = getGoalComlitionPercentage(innerLoopIndex, goalCalView);
                                    currentStatusMapAmount = getCurrentStatusFundForMappedGoal(int.Parse(_dtGoals.Rows[innerLoopIndex]["ID"].ToString()));
                                    _dtGoals.Rows[innerLoopIndex]["ProjectionCompleted"] = goalComplitionPercentage;
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
                                        futureValue = futureValue + double.Parse(_dtGoals.Rows[i]["FutureValue"].ToString());
                                        totalGoalReacedPercentage = totalGoalReacedPercentage + int.Parse(_dtGoals.Rows[i]["GoalReached"].ToString());
                                        projectionCompletedPercentage = projectionCompletedPercentage + double.Parse(_dtGoals.Rows[i]["ProjectionCompleted"].ToString());
                                        //dtGroupOfGoals.Rows.Add(_dtGoals.Rows[innerLoopIndex]);
                                        endYear = _dtGoals.Rows[i]["StartYear"].ToString();
                                        currentStatusMapAmount = getCurrentStatusFundForMappedGoal(int.Parse(_dtGoals.Rows[innerLoopIndex]["ID"].ToString()));
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
            //for (int i = _dtGoals.Rows.Count - 1; i > 0; i--)
            //{
            //    int recurrenceValue = 0;
            //    if (int.TryParse(_dtGoals.Rows[i]["Recurrence"].ToString(), out recurrenceValue) && recurrenceValue > 1)
            //    {
            //        _dtGoals.Rows.RemoveAt(i);
            //    }
            //}

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
                CashFlowService cashFlowService = new CashFlowService();
                cashFlowService.GenerateCashFlow(this.client.ID, this.planner.ID, this.riskProfileId);
                CashFlow cf = cashFlowService.GetCashFlow(this.optionId);

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
            lblGoalAchiveTillDate.Text = String.Format("{0:#,###}", double.Parse(lblGoalAchiveTillDate.Text));
        }

        private double getCurrentStatusFundForMappedGoal(int goalId)
        {
            Goals goal =  lstGoal.First(i => i.Id == goalId);
            //if (goal.Category.Equals("Retirement"))
            //{
            //    return this.retirementEstimatedCorpusFund;
            //}
            CurrentStatusInfo csInfo = new CurrentStatusInfo();
            IList<FinancialPlanner.Common.Model.PlanOptions.CurrentStatusToGoal>  currentStatusToGoals =  csInfo.GetCurrentStatusToGoal(this.optionId, this.planner.ID);
           IEnumerable<FinancialPlanner.Common.Model.PlanOptions.CurrentStatusToGoal> currentStatusToGoalLst = currentStatusToGoals.Where(i => i.GoalId == goalId);
            double mappedFund = 0;
            foreach(FinancialPlanner.Common.Model.PlanOptions.CurrentStatusToGoal toGoal in currentStatusToGoalLst)
            {
                mappedFund = mappedFund + toGoal.FundAllocation;
            }
            return mappedFund;
            //return csInfo.GetFundFromCurrentStatus (this.planner.ID , id);
        }
    }
}
