using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FinancialPlanner.Common.Model;
using System.Data;
using FinancialPlannerClient.CurrentStatus;
using FinancialPlannerClient.PlannerInfo;
using System.Collections.Generic;
using System.Linq;
using FinancialPlanner.Common.DataConversion;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class ActionPlan : DevExpress.XtraReports.UI.XtraReport
    {
        Client client;
        private DataTable dataTable;

        public ActionPlan(Client client, DataTable dataTable,Planner planner)
        {
            InitializeComponent();
            this.client = client;
            this.dataTable = dataTable;
            lblPeriod.Text = planner.StartDate.ToShortDateString() + " - " + planner.EndDate.ToShortDateString();
            lblEquityRatioWithUS.Text = planner.EquityRatio.ToString() + "%";
            lblDebtRatioWithUS.Text = planner.DebtRatio.ToString() + "%";
            displayExecutionData();
        }

        private void displayExecutionData()
        {
            double totalEquityAmount = dataTable.AsEnumerable().Sum(x => Convert.ToDouble(x["EquityAmount"]));
            double totalDebtAmount = dataTable.AsEnumerable().Sum(x => Convert.ToDouble(x["DebtAmount"]));
            double totalFinalTotalAmount = dataTable.AsEnumerable().Sum(x => Convert.ToDouble(x["FinalTotal"]));
            xrlblEecutionEquityRatio.Text = ((totalEquityAmount / totalFinalTotalAmount) * 100).ToString("N0", PlannerMainReport.Info)+  "%";
            xrlblExeuctionDebtRatio.Text = ((totalDebtAmount / totalFinalTotalAmount) * 100).ToString("N0", PlannerMainReport.Info) + "%";
        }

        private void xrlblEecutionEquityRatio_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
