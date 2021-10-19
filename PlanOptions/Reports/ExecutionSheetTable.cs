using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FinancialPlanner.Common.Model;
using System.Data;
using System.Collections.Generic;
using FinancialPlanner.Common.DataConversion;
using System.Linq;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class ExecutionSheetTable : DevExpress.XtraReports.UI.XtraReport
    {
        Planner planner;
        int optionId;
        int riskProfileId;
        Client client;
        DataTable dtExeuctionTable;
        DataSet ds = new DataSet();
        public ExecutionSheetTable(Client client,DataTable dataTable )
        {
            InitializeComponent();
            this.lblClientName.Text = client.Name;
            this.client = client;
            this.dtExeuctionTable = dataTable;

            displayExecutionData();
        }

        private void displayExecutionData()
        {
            //ExecutionSheetInfo executionSheetInfo = new ExecutionSheetInfo(this.client, this.planner, this.optionId, this.riskProfileId);
            //dtExeuctionTable = executionSheetInfo.GetExeuctionSheetTable();
            dtExeuctionTable.TableName = "ExecutionSheet";
            ds.Tables.Add(dtExeuctionTable);
            this.DataSource = ds;
            this.DataMember = ds.Tables[0].TableName;

            this.lblGoalName.DataBindings.Add("Text", this.DataSource, "ExecutionSheet.GoalName");
            this.lblTotalAmount.DataBindings.Add("Text", this.DataSource, "ExecutionSheet.TotalAmount");
            this.lblEquityRatio.DataBindings.Add("Text", this.DataSource, "ExecutionSheet.EquityPercentage");
            this.lblEquityAmount.DataBindings.Add("Text", this.DataSource, "ExecutionSheet.EquityAmount");
            this.lblDebtRatio.DataBindings.Add("Text", this.DataSource, "ExecutionSheet.DebtPercentage");
            this.lblDebtAmount.DataBindings.Add("Text", this.DataSource, "ExecutionSheet.DebtAmount");

            double totalEquityAmount = dtExeuctionTable.AsEnumerable().Sum(x => Convert.ToDouble(x["EquityAmount"]));
            double totalDebtAmount = dtExeuctionTable.AsEnumerable().Sum(x => Convert.ToDouble(x["DebtAmount"]));
            double totalFinalTotalAmount = dtExeuctionTable.AsEnumerable().Sum(x => Convert.ToDouble(x["FinalTotal"]));
            lblFinalEquityRatio.Text = ((totalEquityAmount / totalFinalTotalAmount) * 100).ToString("N0", PlannerMainReport.Info) + "%";
            lblFinalDebtRatio.Text = ((totalDebtAmount / totalFinalTotalAmount) * 100).ToString("N0", PlannerMainReport.Info) + "%";

            lblTotalEquityAmount.Text = PlannerMainReport.planner.CurrencySymbol + totalEquityAmount.ToString("N0", PlannerMainReport.Info);

            lblTotalDebtAmount.Text = PlannerMainReport.planner.CurrencySymbol + totalDebtAmount.ToString("N0", PlannerMainReport.Info);

            lblGrandFinalTotal.Text = PlannerMainReport.planner.CurrencySymbol + totalFinalTotalAmount.ToString("N0", PlannerMainReport.Info);
        }
        private void lblTotalAmount_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblTotalAmount.Text) && !lblTotalAmount.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                lblTotalAmount.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblTotalAmount.Text).ToString("N0", PlannerMainReport.Info);
            }
            else if (!string.IsNullOrEmpty(lblTotalAmount.Text) && string.IsNullOrEmpty((PlannerMainReport.planner.CurrencySymbol)))
            {
                lblTotalAmount.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblTotalAmount.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void lblFinalTotal_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            double equityAmount = 0;
            double debtAmount = 0;
            double.TryParse(lblEquityAmount.Text, out equityAmount);
            double.TryParse(lblDebtAmount.Text, out debtAmount);
            lblFinalTotal.Text =  PlannerMainReport.planner.CurrencySymbol + (equityAmount + debtAmount).ToString("N0", PlannerMainReport.Info);
        }

        private void lblDebtAmount_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblDebtAmount.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblDebtAmount.Text).ToString("N0", PlannerMainReport.Info);
        }

        private void lblDebtRatio_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblDebtRatio.Text = lblDebtRatio.Text + "%";
        }

        private void lblEquityRatio_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblEquityRatio.Text = lblEquityRatio.Text + "%";
        }

        private void lblEquityAmount_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblEquityAmount.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblEquityAmount.Text).ToString("N0", PlannerMainReport.Info);
        }
    }
}
