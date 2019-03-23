using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.PlanOptions;
using FinancialPlannerClient.CashFlowManager;
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
                for (int colIndex = surplusColumnIndex + 1; colIndex < _dtcashFlow.Columns.Count - 1; colIndex++)
                {
                    if (rowIndex <= xrTableCashFlowGoals.Rows.Count - 1)
                    {
                        xrTableCashFlowGoals.Rows[rowIndex].Cells[0].Text = _dtcashFlow.Columns[colIndex].Caption;
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

        private void loadTotalIncomeDataAndSetChart()
        {
            int totalIncomeColumnIndex = getTotalIncomeColumnIndex(_dtcashFlow);
            double value = (double.Parse(_dtcashFlow.Rows[0][totalIncomeColumnIndex].ToString()));
            lblTotalIncome.Text = value.ToString("#,###");
            xrChartSurplusForPeriod.Series[0].Points[0].Values = new double[] { value };
        }

        private int getTotalIncomeColumnIndex(DataTable dtcashFlow)
        {
            int colIndex = dtcashFlow.Columns.IndexOf(TOTAL_INCOME_COLUMN);
            return colIndex > 0 ? colIndex : -1;
        }

        private int getTotalExpColumnIndex(int startColumnIndex, DataTable dtcashFlow)
        {
            int colIndex = dtcashFlow.Columns.IndexOf(TOTAL_EXP_COLUMN);
            return colIndex > 0 ? colIndex : -1;
        }
    }
}
