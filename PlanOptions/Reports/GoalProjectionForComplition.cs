using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.PlannerInfo;
using System.Collections.Generic;
using System.Data;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class GoalProjectionForComplition : DevExpress.XtraReports.UI.XtraReport
    {
        DataTable _dtGoals = new DataTable();
        Client client;
        Planner planner;
        public GoalProjectionForComplition(Planner planner, Client client)
        {
            InitializeComponent();
            this.client = client;
            this.planner = planner;
            this.lblClientName.Text = client.Name;
            GoalsInfo GoalsInfo = new GoalsInfo();
            List<Goals> lstGoal = (List<Goals>)GoalsInfo.GetAll(planner.ID);
            _dtGoals = ListtoDataTable.ToDataTable(lstGoal);

            this.DataSource = _dtGoals;
            this.DataMember = _dtGoals.TableName;

            this.lblGoalID.DataBindings.Add("Text", this.DataSource, "Goals.ID");
            this.lblName.DataBindings.Add("Text", this.DataSource, "Goals.Name");
            this.lblStartYear.DataBindings.Add("Text", this.DataSource, "Goals.StartYear");
            //this.lblEndYear.DataBindings.Add("Text", this.DataSource, "Goals.EndYear");
            //this.lblInflation.DataBindings.Add("Text", this.DataSource, "Goals.InflationRate");
            //this.lblPresentCost.DataBindings.Add("Text", this.DataSource, "Goals.Amount");
            //this.lblPriority.DataBindings.Add("Text", this.DataSource, "Goals.Priority");
            //this.lblFutureCost.DataBindings.Add("Text", this.DataSource, "Goals.FutureValue");
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
    }
}
