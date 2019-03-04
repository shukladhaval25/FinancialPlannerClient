using System;
using System.Drawing;
using FinancialPlanner.Common.Model.PlanOptions;
using System.Data;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.CashFlowManager;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class SpendingSavingRatioReport : DevExpress.XtraReports.UI.XtraReport
    {
        DataTable _dtcashFlow;
        CashFlowService cashFlowService = new CashFlowService();
        int clientID, planID, riskProfileID, optionID;
        const string TOTAL_INCOME_COLUMN = "Total Income";
        const string TOTAL_EXP_COLUMN = "Total Annual Expenses";
        const string TOTAL_ANNAUL_LOAN_COLUMN = "Total Annual Loans";
        private const string TOTAL_POST_TAX_INCOME = "Total Post Tax Income";
        private const string SURPLUS_AMOUNT = "Surplus Amount";

        public SpendingSavingRatioReport(Client client, int planId, int riskProfileId, int optionId)
        {
            InitializeComponent();
            this.clientID = client.ID;
            this.planID = planId;
            this.riskProfileID = riskProfileId;
            this.optionID = optionId;
            this.lblClientName.Text = client.Name;
            CashFlow cf = cashFlowService.GetCashFlow(optionID);
            _dtcashFlow = cashFlowService.GenerateCashFlow(this.clientID, this.planID, this.riskProfileID);
            chartSpendingSavingRatio.Series[0].Points.Clear();

            int totalIncomeColumnIndex = getTotalIncomeColumnIndex(_dtcashFlow);
            int totalExpColumnIndex = getTotalExpColumnIndex(totalIncomeColumnIndex, _dtcashFlow);
            int totalLoanAmountColumnIndex = getTotalLoanAmountColumnIndex(totalExpColumnIndex, _dtcashFlow);
            if (totalIncomeColumnIndex > 0)
            {
                for (int columnIndex = totalIncomeColumnIndex; columnIndex <= totalExpColumnIndex - 1; columnIndex++)
                {
                    if (_dtcashFlow.Columns[columnIndex].Caption == TOTAL_POST_TAX_INCOME)
                        continue;

                    addPointsToChart(totalIncomeColumnIndex, columnIndex);
                }
                for (int columnIndex = totalExpColumnIndex + 1; columnIndex <= totalLoanAmountColumnIndex -1; columnIndex++)
                {
                    addPointsToChart(totalExpColumnIndex, columnIndex);
                }               

                int val = (int)(double.Parse(_dtcashFlow.Rows[0][SURPLUS_AMOUNT].ToString()) * 100 /
                    double.Parse(_dtcashFlow.Rows[0][totalIncomeColumnIndex].ToString()));
                chartSpendingSavingRatio.Series[0].Points.AddPoint(_dtcashFlow.Columns[SURPLUS_AMOUNT].Caption, val);               
            }

            loadIncomeExpSavingRatio(totalIncomeColumnIndex, totalExpColumnIndex, totalLoanAmountColumnIndex);
            loadDebtRatio(totalIncomeColumnIndex, totalLoanAmountColumnIndex);
        }

        private void loadDebtRatio(int totalIncomeColumnIndex, int totalLoanAmountColumnIndex)
        {
            charDebtIncome.Series[0].Points.Clear();
            int value = (int)(double.Parse(_dtcashFlow.Rows[0][totalIncomeColumnIndex].ToString()) * 100 /
            double.Parse(_dtcashFlow.Rows[0][totalIncomeColumnIndex].ToString()));
            lblDebtIncome.Text = value.ToString();
            charDebtIncome.Series[0].Points.AddPoint(_dtcashFlow.Columns[totalIncomeColumnIndex].Caption, value);

            value = (int)(double.Parse(_dtcashFlow.Rows[0][totalLoanAmountColumnIndex].ToString()) * 100 /
            double.Parse(_dtcashFlow.Rows[0][totalIncomeColumnIndex].ToString()));
            lblDebtEMI.Text = value.ToString();
            charDebtIncome.Series[0].Points.AddPoint(_dtcashFlow.Columns[totalLoanAmountColumnIndex].Caption, value);
        }

        private void addPointsToChart(int totalIncomeColumnIndex, int columnIndex)
        {
            int value = (int)(double.Parse(_dtcashFlow.Rows[0][columnIndex].ToString()) * 100 /
            double.Parse(_dtcashFlow.Rows[0][totalIncomeColumnIndex].ToString()));
            chartSpendingSavingRatio.Series[0].Points.AddPoint(_dtcashFlow.Columns[columnIndex].Caption, value);

            Random randomGen = new Random();
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            KnownColor randomColorName = names[randomGen.Next(names.Length)];
            Color randomColor = Color.FromKnownColor(randomColorName);
            chartSpendingSavingRatio.Series[0].Points[chartSpendingSavingRatio.Series[0].Points.Count - 1].Color = randomColor;
        }

        private int getTotalLoanAmountColumnIndex(int startColumnIndex, DataTable dtcashFlow)
        {
            for (int index = startColumnIndex; index <= dtcashFlow.Columns.Count - 1; index++)
            {
                if (dtcashFlow.Columns[index].Caption == TOTAL_ANNAUL_LOAN_COLUMN)
                    return index;
            }
            return -1;
        }

        private int getTotalExpColumnIndex(int startColumnIndex, DataTable dtcashFlow)
        {
            for (int index = startColumnIndex; index <= dtcashFlow.Columns.Count - 1; index++)
            {
                if (dtcashFlow.Columns[index].Caption == TOTAL_EXP_COLUMN)
                    return index;
            }
            return -1;
        }

        private int getTotalIncomeColumnIndex(DataTable dtcashFlow)
        {
            for(int index =0; index <= dtcashFlow.Columns.Count -1; index++)
            {
                if (dtcashFlow.Columns[index].Caption == TOTAL_INCOME_COLUMN)
                    return index;
            }
            return -1;
        }
        private void loadIncomeExpSavingRatio(int totalIncomeColumnIndex,int totalExpColumnIndex, 
            int totalLoanColumnIndex)
        {
            chartTotalRatio.Series[0].Points.Clear();
            int value = (int)(double.Parse(_dtcashFlow.Rows[0][totalIncomeColumnIndex].ToString()) * 100 /
            double.Parse(_dtcashFlow.Rows[0][totalIncomeColumnIndex].ToString()));

            lblAmount0.Text = value.ToString();
            chartTotalRatio.Series[0].Points.AddPoint("Total Income", value);

            value = (int)(
                (double.Parse(_dtcashFlow.Rows[0][totalExpColumnIndex].ToString())  + 
                double.Parse(_dtcashFlow.Rows[0][totalLoanColumnIndex].ToString())) * 100 /
            double.Parse(_dtcashFlow.Rows[0][totalIncomeColumnIndex].ToString()));
            lblAmount1.Text = value.ToString();
            chartTotalRatio.Series[0].Points.AddPoint("Total Expense", value);

            int val = (int)(double.Parse(_dtcashFlow.Rows[0][SURPLUS_AMOUNT].ToString()) * 100 /
                    double.Parse(_dtcashFlow.Rows[0][totalIncomeColumnIndex].ToString()));
            lblAmount2.Text = val.ToString();
            chartTotalRatio.Series[0].Points.AddPoint(_dtcashFlow.Columns[SURPLUS_AMOUNT].Caption, val);
        }

    }
}
