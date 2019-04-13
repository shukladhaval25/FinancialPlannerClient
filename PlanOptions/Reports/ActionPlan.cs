using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FinancialPlanner.Common.Model;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class ActionPlan : DevExpress.XtraReports.UI.XtraReport
    {
        public ActionPlan(Client client,Planner planner)
        {
            InitializeComponent();
            this.lblClientName.Text = client.Name;
            lblPeriod.Text = planner.StartDate.ToShortDateString() + " - " + planner.EndDate.ToShortDateString();
        }
    }
}
