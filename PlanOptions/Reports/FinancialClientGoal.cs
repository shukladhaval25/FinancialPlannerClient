using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.PlanOptions;
using FinancialPlannerClient.CashFlowManager;
using FinancialPlannerClient.PlannerInfo;
using FinancialPlannerClient.RiskProfile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class FinancialClientGoal : DevExpress.XtraReports.UI.XtraReport
    {
        DataTable _dtGoals = new DataTable();
        Planner planner = new Planner();
        int years;
        int maxGoalPriority;
        DataTable dtGroupOfGoals = new DataTable();
        List<Goals> lstGoal;
        int riskProfileId;
        int optionId;
        Client client;
        public FinancialClientGoal()
        {
            InitializeComponent();
        }
        public FinancialClientGoal(Planner planner, Client client, int riskProfileID, int optionId)
        {
            InitializeComponent();
            this.planner = planner;
            this.client = client;
            this.lblClientName.Text = client.Name;
            this.riskProfileId = riskProfileID;
            this.optionId = optionId;

          
        }
        

        private void groupTogetherRecurrenceGoal()
        {
            List<string> groupOfGoal = new List<string>();
        
            dtGroupOfGoals = _dtGoals.Clone();

            for(int i=0;i< _dtGoals.Rows.Count;i++)
            {
                string goalName = (_dtGoals.Rows[i]["Name"].ToString().Length > 4) ? _dtGoals.Rows[i]["Name"].ToString().Substring(0, _dtGoals.Rows[i]["Name"].ToString().Length - 4).Trim() :
                 _dtGoals.Rows[i]["Name"].ToString();

                goalName = setGoalNameWithRecurranceValidation(i, goalName);
                if (!groupOfGoal.Contains(goalName))
                {
                    string goalCategory = _dtGoals.Rows[i]["Category"].ToString();
                    double amount = 0;
                    double futureValue = 0;
                    string endYear = "";
                    int recurrence = 0;

                    if (_dtGoals.Rows[i]["Recurrence"] != null & int.Parse(_dtGoals.Rows[i]["Recurrence"].ToString()) >= 1)
                    {
                        //amount = amount + double.Parse(_dtGoals.Rows[i]["Amount"].ToString());
                        //futureValue = futureValue + double.Parse(_dtGoals.Rows[i]["FutureValue"].ToString());
                        for (int innerLoopIndex = i; innerLoopIndex < this._dtGoals.Rows.Count; innerLoopIndex++)
                        {
                            if (_dtGoals.Rows[i]["Recurrence"].ToString().Equals(_dtGoals.Rows[innerLoopIndex]["Recurrence"].ToString()) &&
                                _dtGoals.Rows[innerLoopIndex]["Category"].ToString().Equals(goalCategory) &&
                                _dtGoals.Rows[innerLoopIndex]["Name"].ToString().Substring(0, 
                                (_dtGoals.Rows[innerLoopIndex]["Name"].ToString().Length > 4)?
                                 _dtGoals.Rows[innerLoopIndex]["Name"].ToString().Length - 4 :
                                 _dtGoals.Rows[innerLoopIndex]["Name"].ToString().Length
                                ).Trim().Equals(goalName))
                            {
                                amount = amount + double.Parse(_dtGoals.Rows[innerLoopIndex]["Amount"].ToString());
                                futureValue = futureValue + double.Parse(_dtGoals.Rows[innerLoopIndex]["FutureValue"].ToString());
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
                                    endYear = _dtGoals.Rows[i]["StartYear"].ToString();
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
                            dr["StartYear"] = _dtGoals.Rows[i]["StartYear"];
                            dr["EndYear"] = endYear;
                            dr["Priority"] = _dtGoals.Rows[i]["Priority"];
                            dr["Recurrence"] = recurrence;  //_dtGoals.Rows[i]["Recurrence"];
                            dr["InflationRate"] = _dtGoals.Rows[i]["InflationRate"];
                            dtGroupOfGoals.Rows.Add(dr);
                        }
                    }
                }
            }
            _dtGoals.Clear();
            //for (int i = _dtGoals.Rows.Count-1; i > 0; i--)
            //{
            //    int recurrenceValue =0;
            //    if (int.TryParse(_dtGoals.Rows[i]["Recurrence"].ToString(),out recurrenceValue )  &&  recurrenceValue >= 1)
            //    {
            //        _dtGoals.Rows.RemoveAt(i);
            //    }
            //}

            foreach(DataRow dataRow in dtGroupOfGoals.Rows)
            {
                DataRow dr =  _dtGoals.NewRow();
                dr["Name"] = dataRow["Name"];
                dr["Category"] = dataRow["Category"];
                dr["Amount"] = dataRow["Amount"];
                dr["FutureValue"] = dataRow["FutureValue"];
                dr["StartYear"] = dataRow["StartYear"];
                dr["EndYear"] = dataRow["EndYear"];
                dr["Priority"] = dataRow["Priority"];
                dr["Recurrence"] = dataRow["Recurrence"];
                dr["InflationRate"] = dataRow["InflationRate"];
                _dtGoals.Rows.Add(dr);
            }
        }

        internal DataTable GetGoalsByGroup()
        {
            return _dtGoals;
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

        private void addFutureValueIntoDataTable()
        {
            _dtGoals.Columns.Add("FutureValue", typeof(System.Double));
            foreach(DataRow dr in _dtGoals.Rows)
            {
               years = (!string.IsNullOrEmpty(dr["StartYear"].ToString())) ?
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

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           
        }

        private void lblRecurrence_TextChanged(object sender, EventArgs e)
        {
        }

        private void lblRecurrence_AfterPrint(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lblRecurrence.Text))
            {
                if (int.Parse(lblRecurrence.Text) > 1)
                {
                    xrGroupTable.Visible = true;
                    this.lblName.DataBindings.Add("Text", this.DataSource, "Goals.Name");
                    string occurance = (lblGoalCategory.Text == "Vehicale") ? lblRecurrence.Text : "" ;
                    string currencySymbol = string.IsNullOrEmpty(PlannerMainReport.planner.CurrencySymbol) ? "Rs." : PlannerMainReport.planner.CurrencySymbol;
                    double presentCost = 0;
                    if (lblPresentCost.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
                    {
                        double.TryParse(lblPresentCost.Text.Substring(PlannerMainReport.planner.CurrencySymbol.Length), out presentCost);
                    }
                    else
                    {
                        double.TryParse(lblPresentCost.Text, out presentCost);
                    }
                    if (lblGoalCategory.Text == "Vehicale")
                    {
                        xrGroupLabel.Text = string.Format("{0} {1} of {2}{3} each", occurance, lblName.Text, currencySymbol,
                        (presentCost / int.Parse(lblRecurrence.Text)).ToString("N0", PlannerMainReport.Info));
                    }
                    else
                    {
                        xrGroupLabel.Text = string.Format("{0} {1} Per Annum For {2} years", currencySymbol, (presentCost / int.Parse(lblRecurrence.Text)).ToString("N0", PlannerMainReport.Info), lblRecurrence.Text);
                    }
                    xrGroupLabel2.Text ="Total fund needed";
                   
                }
                else
                {
                    xrGroupTable.Visible = false;
                }
            }
        }

        private void lblInflation_AfterPrint(object sender, EventArgs e)
        {
            //lblInflation.Text = lblInflation.Text + " %";
           
        }

        private void lblInflation_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblInflation.Text = lblInflation.Text + " %";
            if (lblPriority.Text == maxGoalPriority.ToString())
            {
                lblInflation.Text = "";
            }

        }

        private void lblRecurrence_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }

        private void lblFutureCost_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblFutureCost.Text))
            {
                lblFutureCost.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblFutureCost.Text).ToString("N0", PlannerMainReport.Info);
            }
            if (string.IsNullOrEmpty(lblPriority.Text))
            {
                lblFutureCost.Text = "";
            }
        }

        private void lblPresentCost_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblPresentCost.Text))
            {
                lblPresentCost.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblPresentCost.Text).ToString("N0", PlannerMainReport.Info);
            }
            if (string.IsNullOrEmpty(lblPriority.Text))
            {
                lblPresentCost.Text = "";
            }
        }

        private void xrGroupLabel_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }

        private void lblRetirementPresentCost_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            double retirementPresentCost = 0;
            double.TryParse(lblRetirementPresentCost.Text, out retirementPresentCost);
            lblRetirementPresentCost.Text = PlannerMainReport.planner.CurrencySymbol + retirementPresentCost.ToString("N0", PlannerMainReport.Info);
        }

        private void lblRetirementFutureCost_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            double retirementFutureCost = 0;
            double.TryParse(lblRetirementFutureCost.Text, out retirementFutureCost);
            lblRetirementFutureCost.Text = PlannerMainReport.planner.CurrencySymbol + retirementFutureCost.ToString("N0", PlannerMainReport.Info);
        }

        private void lblFirstYearRetirementExp_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            double firstYearRetirement = 0;
            double.TryParse(lblFirstYearRetirementExp.Text, out firstYearRetirement);
            lblFirstYearRetirementExp.Text = PlannerMainReport.planner.CurrencySymbol + firstYearRetirement.ToString("N0", PlannerMainReport.Info);
        }

        private void FinancialClientGoal_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            GoalsInfo GoalsInfo = new GoalsInfo();
            lstGoal = (List<Goals>)GoalsInfo.GetAll(planner.ID);
            lstGoal = lstGoal.OrderBy(x => x.Priority).ToList();
            maxGoalPriority = lstGoal[lstGoal.Count - 1].Priority;
            maxGoalPriority = maxGoalPriority + 1;
            Goals dummyGoal = new Goals();
            dummyGoal.Name = "";
            dummyGoal.Id = 999999;
            dummyGoal.Recurrence = 1;
            dummyGoal.Category = "";
            dummyGoal.StartYear = "";
            dummyGoal.EndYear = "";
            dummyGoal.Priority = maxGoalPriority;
            lstGoal.Add(dummyGoal);
            _dtGoals = ListtoDataTable.ToDataTable(lstGoal);

            addFutureValueIntoDataTable();

            groupTogetherRecurrenceGoal();
            DataTable dtTable = _dtGoals.Select("Category <> 'Retirement'", "Recurrence DESC").CopyToDataTable();
            DataTable dtCloned = dtTable.Clone();
            dtCloned.Columns["Priority"].DataType = typeof(Int32);
            foreach (DataRow row in dtTable.Rows)
            {
                dtCloned.ImportRow(row);
            }

            dtCloned = dtCloned.Select("", "Priority ASC").CopyToDataTable();

            this.DataSource = dtCloned;
            this.DataMember = dtCloned.TableName;

            this.lblName.DataBindings.Add("Text", this.DataSource, "Goals.Name");
            this.lblStartYear.DataBindings.Add("Text", this.DataSource, "Goals.StartYear");
            this.lblEndYear.DataBindings.Add("Text", this.DataSource, "Goals.EndYear");
            this.lblInflation.DataBindings.Add("Text", this.DataSource, "Goals.InflationRate");
            this.lblPresentCost.DataBindings.Add("Text", this.DataSource, "Goals.Amount");
            this.lblPriority.DataBindings.Add("Text", this.DataSource, "Goals.Priority");
            this.lblFutureCost.DataBindings.Add("Text", this.DataSource, "Goals.FutureValue");
            this.lblRecurrence.DataBindings.Add("Text", this.DataSource, "Goals.Recurrence");
            this.lblGoalCategory.DataBindings.Add("Text", this.DataSource, "Goals.Category");

            DataRow[] drs = _dtGoals.Select("Category = 'Retirement'");
            if (drs.Count() > 0)
            {
                this.xrRetirementGoal.Text = drs[0]["Name"].ToString();
                this.lblRetirementStartYear.Text = drs[0]["StartYear"].ToString();

                this.lblRetirementInflation.Text = drs[0]["InflationRate"].ToString() + " %";

                this.lblRetirementPriority.Text = drs[0]["Priority"].ToString();

                //this.lblFirstYearRetirementExp.Text = drs[0]["FutureValue"].ToString();
                PostRetirementCashFlowService postRetirementCashFlowService;
                CashFlowService cashFlowService = new CashFlowService();
                cashFlowService.GenerateCashFlow(this.client.ID, this.planner.ID, this.riskProfileId);
                Goals retirementGoal = lstGoal.FirstOrDefault(x => x.Category.Equals("Retirement"));
                RiskProfileInfo _riskProfileInfo = new RiskProfileInfo();
                GoalsCalculationInfo _goalCalculationInfo =
                        new GoalsCalculationInfo(retirementGoal, planner, _riskProfileInfo, this.riskProfileId, this.optionId);
                CashFlow cf = cashFlowService.GetCashFlow(this.optionId);
                _goalCalculationInfo.GoalCalManager = cashFlowService.GoalCalculationMgr;

                _goalCalculationInfo.CashFlowService = cashFlowService;
                DataTable dtGoalValue = _goalCalculationInfo.GetGoalValue(int.Parse(retirementGoal.Id.ToString()),
                planner.ID, this.riskProfileId, this.optionId);
                if (dtGoalValue.Rows.Count > 0)
                {
                    this.lblFirstYearRetirementExp.Text = dtGoalValue.Rows[0]["FirstYearExpenseOnRetirementYear"].ToString();

                    postRetirementCashFlowService = new PostRetirementCashFlowService(planner, cashFlowService);
                    postRetirementCashFlowService.GetPostRetirementCashFlowData();
                    postRetirementCashFlowService.calculateEstimatedRequireCorpusFund();
                    double totalEstimatedRetirementCorpusFund = Math.Round(postRetirementCashFlowService.GetProposeEstimatedCorpusFund(), 2);
                    this.lblRetirementFutureCost.Text = totalEstimatedRetirementCorpusFund.ToString(); //dtGoalValue.Rows[0]["GoalValue"].ToString();
                    this.lblRetirementPresentCost.Text = dtGoalValue.Rows[0]["CurrentValue"].ToString();
                    lblTotalCorpusNeeded.Text = string.Format(lblTotalCorpusNeeded.Text, (int.Parse(retirementGoal.EndYear) - int.Parse(retirementGoal.StartYear)));
                    this.lblRetirementEndYear.Text = retirementGoal.EndYear;
                }
            }
        }

        private void lblPriority_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (lblPriority.Text == maxGoalPriority.ToString())
            {
                lblPriority.Text = "";
            }
        }

        private void lblPresentCost_AfterPrint(object sender, EventArgs e)
        {
            
        }

        private void lblFutureCost_AfterPrint(object sender, EventArgs e)
        {
           
        }
    }
}