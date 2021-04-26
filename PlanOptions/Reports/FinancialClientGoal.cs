using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.PlannerInfo;
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
        DataTable dtGroupOfGoals = new DataTable();
        List<Goals> lstGoal;
        int riskProfileId;
        public FinancialClientGoal(Planner planner,Client client,int riskProfileID)
        {
            InitializeComponent();
            this.planner = planner;
            this.lblClientName.Text = client.Name;
            this.riskProfileId = riskProfileID;
          
            GoalsInfo GoalsInfo = new GoalsInfo();
            lstGoal = (List<Goals>)GoalsInfo.GetAll(planner.ID);
            _dtGoals = ListtoDataTable.ToDataTable(lstGoal);
        
            addFutureValueIntoDataTable();

            groupTogetherRecurrenceGoal();


            this.DataSource = _dtGoals;
            this.DataMember = _dtGoals.TableName;

            this.lblName.DataBindings.Add("Text", this.DataSource, "Goals.Name");
            this.lblStartYear.DataBindings.Add("Text", this.DataSource, "Goals.StartYear");
            this.lblEndYear.DataBindings.Add("Text", this.DataSource, "Goals.EndYear");
            this.lblInflation.DataBindings.Add("Text", this.DataSource, "Goals.InflationRate");
            this.lblPresentCost.DataBindings.Add("Text", this.DataSource, "Goals.Amount");
            this.lblPriority.DataBindings.Add("Text", this.DataSource, "Goals.Priority");
            this.lblFutureCost.DataBindings.Add("Text", this.DataSource, "Goals.FutureValue");
            this.lblRecurrence.DataBindings.Add("Text", this.DataSource, "Goals.Recurrence");

        }

        private void groupTogetherRecurrenceGoal()
        {
            List<string> groupOfGoal = new List<string>();
        
            dtGroupOfGoals = _dtGoals.Clone();

            for(int i=0;i< _dtGoals.Rows.Count;i++)
            {
                string goalName = (_dtGoals.Rows[i]["Name"].ToString().Length >4) ? _dtGoals.Rows[i]["Name"].ToString().Substring(0, _dtGoals.Rows[i]["Name"].ToString().Length - 4).Trim():
                 _dtGoals.Rows[i]["Name"].ToString();
                string goalCategory = _dtGoals.Rows[i]["Category"].ToString();
                double amount = 0;
                double futureValue = 0;
                string endYear = "";

                if (_dtGoals.Rows[i]["Recurrence"] != null & int.Parse(_dtGoals.Rows[i]["Recurrence"].ToString()) > 1 )
                {
                    //amount = amount + double.Parse(_dtGoals.Rows[i]["Amount"].ToString());
                    //futureValue = futureValue + double.Parse(_dtGoals.Rows[i]["FutureValue"].ToString());
                    for (int innerLoopIndex = i; innerLoopIndex < this._dtGoals.Rows.Count; innerLoopIndex++)
                    {
                        if (_dtGoals.Rows[i]["Recurrence"].ToString().Equals(_dtGoals.Rows[innerLoopIndex]["Recurrence"].ToString()) &&
                            _dtGoals.Rows[innerLoopIndex]["Category"].ToString().Equals(goalCategory) &&
                            _dtGoals.Rows[innerLoopIndex]["Name"].ToString().Substring(0, _dtGoals.Rows[innerLoopIndex]["Name"].ToString().Length - 4).Trim().Equals(goalName))
                        {
                            amount = amount + double.Parse(_dtGoals.Rows[innerLoopIndex]["Amount"].ToString());
                            futureValue = futureValue + double.Parse(_dtGoals.Rows[innerLoopIndex]["FutureValue"].ToString());
                            //dtGroupOfGoals.Rows.Add(_dtGoals.Rows[innerLoopIndex]);
                            endYear = _dtGoals.Rows[innerLoopIndex]["StartYear"].ToString();
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
                        dr["Recurrence"] = _dtGoals.Rows[i]["Recurrence"];
                        dr["InflationRate"] = _dtGoals.Rows[i]["InflationRate"];
                        dtGroupOfGoals.Rows.Add(dr);
                    }
                }
            }
            for (int i = _dtGoals.Rows.Count-1; i > 0; i--)
            {
                int recurrenceValue =0;
                if (int.TryParse(_dtGoals.Rows[i]["Recurrence"].ToString(),out recurrenceValue )  &&  recurrenceValue > 1)
                {
                    _dtGoals.Rows.RemoveAt(i);
                }
            }

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
                    xrGroupLabel.Text = string.Format("{0} {1} or Rs.{2} each", lblRecurrence.Text, lblName.Text,(double.Parse(lblPresentCost.Text) / int.Parse(lblRecurrence.Text)));
                    xrGroupLabel2.Text = string.Format("Total fund need for {0} {1}", lblRecurrence.Text, lblName.Text);
                    xrGroupTable.HeightF = 25;
                }
                else
                {
                    xrGroupTable.Visible = false;
                    xrGroupTable.HeightF = 0;
                }
            }
        }
    }
}
