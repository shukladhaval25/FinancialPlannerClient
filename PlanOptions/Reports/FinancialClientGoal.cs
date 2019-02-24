using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.PlannerInfo;
using System;
using System.Collections.Generic;
using System.Data;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class FinancialClientGoal : DevExpress.XtraReports.UI.XtraReport
    {
        DataTable _dtGoals = new DataTable();
        Planner planner = new Planner();
        int years;
        decimal inflationRate;
        public FinancialClientGoal(Planner planner,Client client)
        {
            InitializeComponent();
            this.planner = planner;
            this.lblClientName.Text = client.Name;
            GoalsInfo GoalsInfo = new GoalsInfo();
            List<Goals> lstGoal = (List<Goals>)GoalsInfo.GetAll(planner.ID);
            _dtGoals = ListtoDataTable.ToDataTable(lstGoal);
            addFutureValueIntoDataTable();
            this.DataSource = _dtGoals;
            this.DataMember = _dtGoals.TableName;

            this.lblName.DataBindings.Add("Text", this.DataSource, "Goals.Name");
            this.lblStartYear.DataBindings.Add("Text", this.DataSource, "Goals.StartYear");
            this.lblEndYear.DataBindings.Add("Text", this.DataSource, "Goals.EndYear");
            this.lblInflation.DataBindings.Add("Text", this.DataSource, "Goals.InflationRate");
            this.lblPresentCost.DataBindings.Add("Text", this.DataSource, "Goals.Amount");
            this.lblPriority.DataBindings.Add("Text", this.DataSource, "Goals.Priority");
            this.lblFutureCost.DataBindings.Add("Text", this.DataSource, "Goals.FutureValue");
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
    }
}
