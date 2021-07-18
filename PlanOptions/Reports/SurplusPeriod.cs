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
                        xrTableCashFlowGoals.Rows[rowIndex].Cells[0].Text = _dtcashFlow.Columns[colIndex].Caption.Substring(_dtcashFlow.Columns[colIndex].Caption.IndexOf("-") +  1 );
                        if (!string.IsNullOrEmpty(_dtcashFlow.Rows[0][colIndex].ToString()))
                        {
                            xrTableCashFlowGoals.Rows[rowIndex].Cells[1].Text = System.Math.Round(double.Parse(_dtcashFlow.Rows[0][colIndex].ToString())).ToString();
                            totalCashFlowAllocation = totalCashFlowAllocation + double.Parse(_dtcashFlow.Rows[0][colIndex].ToString());
                        }
                    }
                    rowIndex++;
                }
                lblTotalSurplusForGoals.Text = totalCashFlowAllocation.ToString("#,###");
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

            lblTotalExp.Text = value.ToString("#,###");
            xrChartSurplusForPeriod.Series[0].Points[1].Values = new double[] { value };
        }

        private int getTotalLoanAmountColumnIndex(int startColumnIndex, DataTable dtcashFlow)
        {
            int colIndex = dtcashFlow.Columns.IndexOf(TOTAL_ANNAUL_LOAN_COLUMN);
            return colIndex > 0 ? colIndex : -1;
        }

        private void lblCashFlowForGoal1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblCashFlowForGoal1.Text))
            {
                lblCashFlowForGoal1.Text = String.Format("{0:#,###}", double.Parse(lblCashFlowForGoal1.Text));
            }
        }

        private void lblCashFlowForGoal2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblCashFlowForGoal2.Text))
            {
                lblCashFlowForGoal2.Text = String.Format("{0:#,###}", double.Parse(lblCashFlowForGoal2.Text));
            }
        }

        private void lblCashFlowForGoal3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblCashFlowForGoal3.Text))
            {
                lblCashFlowForGoal3.Text = String.Format("{0:#,###}", double.Parse(lblCashFlowForGoal3.Text));
            }
        }

        private void lblCashFlowForGoal4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblCashFlowForGoal4.Text))
            {
                lblCashFlowForGoal4.Text = String.Format("{0:#,###}", double.Parse(lblCashFlowForGoal4.Text));
            }
        }

        private void lblCashFlowForGoal5_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblCashFlowForGoal5.Text))
            {
                lblCashFlowForGoal5.Text = String.Format("{0:#,###}", double.Parse(lblCashFlowForGoal5.Text));
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
            if (!string.IsNullOrEmpty(lblCashFlowForGoal7.Text))
            {
                lblCashFlowForGoal7.Text = String.Format("{0:#,###}", double.Parse(lblCashFlowForGoal7.Text));
            }
        }

        private void lblCashFlowForGoal8_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblCashFlowForGoal8.Text))
            {
                lblCashFlowForGoal8.Text = String.Format("{0:#,###}", double.Parse(lblCashFlowForGoal8.Text));
            }
        }

        private void xrTableCell14_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell14.Text))
            {
                xrTableCell14.Text = String.Format("{0:#,###}", double.Parse(xrTableCell14.Text));
            }
        }

        private void xrTableCell18_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell18.Text))
            {
                xrTableCell18.Text = String.Format("{0:#,###}", double.Parse(xrTableCell18.Text));
            }
        }

        private void xrTableCell16_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell16.Text))
            {
                xrTableCell16.Text = String.Format("{0:#,###}", double.Parse(xrTableCell16.Text));
            }
        }

        private void xrTableCell9_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell9.Text))
            {
                xrTableCell9.Text = String.Format("{0:#,###}", double.Parse(xrTableCell9.Text));
            }
        }

        private void xrTableCell11_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell11.Text))
            {
                xrTableCell11.Text = String.Format("{0:#,###}", double.Parse(xrTableCell11.Text));
            }
        }

        private void lblTotalSurplusForGoals_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblTotalSurplusForGoals.Text))
            {
                lblTotalSurplusForGoals.Text = String.Format("{0:#,###}", double.Parse(lblTotalSurplusForGoals.Text));
            }
        }

        private void loadTotalIncomeDataAndSetChart()
        {
            int totalIncomeColumnIndex = getTotalIncomeColumnIndex(_dtcashFlow);
            double value = (double.Parse(_dtcashFlow.Rows[0][totalIncomeColumnIndex].ToString()));
            lblTotalIncome.Text = value.ToString("#,###");
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
