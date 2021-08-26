using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.PlanOptions;
using FinancialPlannerClient.CashFlowManager;
using System;
using System.Data;
using System.Drawing;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class SurplusPeriod : DevExpress.XtraReports.UI.XtraReport
    {
        DataTable _dtcashFlow;
        CashFlowService cashFlowService = new CashFlowService();
        int clientID, planID, riskProfileID, optionID;
        const string TOTAL_INCOME_COLUMN = "Total Income";
        const string TOTAL_EXP_COLUMN = "Total Annual Expenses";
        const string TOTAL_ANNAUL_LOAN_COLUMN = "Total Annual Loans";
        private const string TOTAL_POST_TAX_INCOME = "Total Post Tax Income";
        private const string SURPLUS_AMOUNT = "Surplus Amount";
        public SurplusPeriod(Client client, int planId, int riskProfileId, int optionId)
        {
            InitializeComponent();
            this.clientID = client.ID;
            this.planID = planId;
            this.riskProfileID = riskProfileId;
            this.optionID = optionId;
            this.lblClientName.Text = client.Name;
            CashFlow cf = cashFlowService.GetCashFlow(optionID);
            _dtcashFlow = cashFlowService.GenerateCashFlow(this.clientID, this.planID, this.riskProfileID);

            loadTotalIncomeDataAndSetChart();
            loadTotalExpAndSetChart();
            loadSurplusAndSetChart();
            loadCashFlowAllocationForGoals();
        }

        private void loadCashFlowAllocationForGoals()
        {
            int surplusColumnIndex = _dtcashFlow.Columns.IndexOf(SURPLUS_AMOUNT);
            double totalCashFlowAllocation = 0;
            if (surplusColumnIndex > 0)
            {
                int rowIndex = 0;
                for (int colIndex = surplusColumnIndex + 1; colIndex < _dtcashFlow.Columns.Count - 3; colIndex++)
                {
                    if (rowIndex <= xrTableCashFlowGoals.Rows.Count - 1)
                    {                      
                        double amount = 0;
                        double.TryParse(_dtcashFlow.Rows[0][colIndex].ToString(), out amount);
                        if (!string.IsNullOrEmpty(_dtcashFlow.Rows[0][colIndex].ToString()) && amount > 0)
                        {
                            xrTableCashFlowGoals.Rows[rowIndex].Cells[0].Text = _dtcashFlow.Columns[colIndex].Caption.Substring(_dtcashFlow.Columns[colIndex].Caption.IndexOf("-") + 1);

                            xrTableCashFlowGoals.Rows[rowIndex].Cells[1].Text = System.Math.Round(double.Parse(_dtcashFlow.Rows[0][colIndex].ToString())).ToString();
                            totalCashFlowAllocation = totalCashFlowAllocation + double.Parse(_dtcashFlow.Rows[0][colIndex].ToString());
                            rowIndex++;
                        }
                        
                    }
                }
                lblTotalSurplusForGoals.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(totalCashFlowAllocation.ToString("N2", PlannerMainReport.Info)); 
                lblTotalSurplusForGoals.ForeColor = Color.White;
            }
        }

        private void loadSurplusAndSetChart()
        {
            double val = (double.Parse(_dtcashFlow.Rows[0][SURPLUS_AMOUNT].ToString()));
            lblTotalSurplus.Text = val.ToString("#,###");
            lblTotalSurplus.ForeColor = Color.White;
            xrChartSurplusForPeriod.Series[0].Points[2].Values = new double[] { val };
        }

        private void loadTotalExpAndSetChart()
        {
            double value;
            int totalExpColumnIndex = getTotalExpColumnIndex(0, _dtcashFlow);
            int totalLoanAmountColumnIndex = getTotalLoanAmountColumnIndex(totalExpColumnIndex, _dtcashFlow);

            value = (double.Parse(_dtcashFlow.Rows[0][totalExpColumnIndex].ToString()));
            if (totalLoanAmountColumnIndex > 0)
                value = value + (double.Parse(_dtcashFlow.Rows[0][totalLoanAmountColumnIndex].ToString()));

            lblTotalExp.Text = value.ToString();
            xrChartSurplusForPeriod.Series[0].Points[1].Values = new double[] { value };
        }

        private int getTotalLoanAmountColumnIndex(int startColumnIndex, DataTable dtcashFlow)
        {
            int colIndex = dtcashFlow.Columns.IndexOf(TOTAL_ANNAUL_LOAN_COLUMN);
            return colIndex > 0 ? colIndex : -1;
        }

        private void lblCashFlowForGoal1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblCashFlowForGoal1.Text) && !lblCashFlowForGoal1.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                lblCashFlowForGoal1.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblCashFlowForGoal1.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void lblCashFlowForGoal2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblCashFlowForGoal2.Text) && !lblCashFlowForGoal2.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                lblCashFlowForGoal2.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblCashFlowForGoal2.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void lblCashFlowForGoal3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblCashFlowForGoal3.Text) && !lblCashFlowForGoal3.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                lblCashFlowForGoal3.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblCashFlowForGoal3.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void lblCashFlowForGoal4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblCashFlowForGoal4.Text) && !lblCashFlowForGoal4.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                lblCashFlowForGoal4.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblCashFlowForGoal4.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void lblCashFlowForGoal5_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblCashFlowForGoal5.Text) && !lblCashFlowForGoal5.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                lblCashFlowForGoal5.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblCashFlowForGoal5.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void lblCashFlowForGoal6_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //if (!string.IsNullOrEmpty(lblCashFlowForGoal3.Text))
            //{
            //    lblCashFlowForGoal6.Text = String.Format("{0:#,###}", double.Parse(lblCashFlowForGoal6.Text));
            //}
        }

        private void lblCashFlowForGoal7_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblCashFlowForGoal7.Text) && !lblCashFlowForGoal7.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                lblCashFlowForGoal7.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblCashFlowForGoal7.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void lblCashFlowForGoal8_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblCashFlowForGoal8.Text) && !lblCashFlowForGoal8.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                lblCashFlowForGoal8.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblCashFlowForGoal8.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void xrTableCell14_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell14.Text) && !xrTableCell14.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell14.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell14.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void xrTableCell18_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell18.Text) && !xrTableCell18.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell18.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell18.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void xrTableCell16_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell16.Text) && !xrTableCell16.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell16.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell16.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void xrTableCell9_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell9.Text) && !xrTableCell9.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell9.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell9.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void xrTableCell11_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell11.Text) && !xrTableCell11.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell11.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell11.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void lblTotalSurplusForGoals_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblTotalSurplusForGoals.Text) && !lblTotalSurplusForGoals.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                lblTotalSurplusForGoals.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblTotalSurplusForGoals.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void lblTotalIncome_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblTotalIncome.Text) && !lblTotalIncome.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                lblTotalIncome.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblTotalIncome.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void lblTotalExp_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblTotalExp.Text) && !lblTotalExp.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                lblTotalExp.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblTotalExp.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void loadTotalIncomeDataAndSetChart()
        {
            int totalIncomeColumnIndex = getTotalIncomeColumnIndex(_dtcashFlow);
            double value = (double.Parse(_dtcashFlow.Rows[0][totalIncomeColumnIndex].ToString()));
            lblTotalIncome.Text = value.ToString();
            xrChartSurplusForPeriod.Series[0].Points[0].Values = new double[] { value };
        }

        private int getTotalIncomeColumnIndex(DataTable dtcashFlow)
        {
            int colIndex = dtcashFlow.Columns.IndexOf(TOTAL_POST_TAX_INCOME);
            return colIndex > 0 ? colIndex : -1;
        }

        private int getTotalExpColumnIndex(int startColumnIndex, DataTable dtcashFlow)
        {
            int colIndex = dtcashFlow.Columns.IndexOf(TOTAL_EXP_COLUMN);
            return colIndex > 0 ? colIndex : -1;
        }
    }
}
