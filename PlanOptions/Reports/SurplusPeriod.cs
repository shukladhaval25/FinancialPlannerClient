using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FinancialPlanner.Common.Model;
using System.Data;
using FinancialPlannerClient.CashFlowManager;
using FinancialPlanner.Common.Model.PlanOptions;

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

            int totalIncomeColumnIndex = loadTotalIncomeDataAndSetChart();
            loadTotalExpAndSetChart(totalIncomeColumnIndex);


            loadSurplusAndSetChart(totalIncomeColumnIndex);
        }

        private void loadSurplusAndSetChart(int totalIncomeColumnIndex)
        {
            double val = (double.Parse(_dtcashFlow.Rows[0][SURPLUS_AMOUNT].ToString()));
            lblTotalSurplus.Text = val.ToString("#,###");
            lblTotalSurplus.ForeColor = Color.White;
            xrChartSurplusForPeriod.Series[0].Points[2].Values = new double[] { val };
        }

        private void loadTotalExpAndSetChart(int totalIncomeColumnIndex)
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
            for (int index = startColumnIndex; index <= dtcashFlow.Columns.Count - 1; index++)
            {
                if (dtcashFlow.Columns[index].Caption == TOTAL_ANNAUL_LOAN_COLUMN)
                    return index;
            }
            return -1;
        }
        private int loadTotalIncomeDataAndSetChart()
        {
            int totalIncomeColumnIndex = getTotalIncomeColumnIndex(_dtcashFlow);
            double value = (double.Parse(_dtcashFlow.Rows[0][totalIncomeColumnIndex].ToString()));
            lblTotalIncome.Text = value.ToString("#,###");
            xrChartSurplusForPeriod.Series[0].Points[0].Values = new double[] { value };
            return totalIncomeColumnIndex;
        }

        private int getTotalIncomeColumnIndex(DataTable dtcashFlow)
        {
            for (int index = 0; index <= dtcashFlow.Columns.Count - 1; index++)
            {
                if (dtcashFlow.Columns[index].Caption == TOTAL_INCOME_COLUMN)
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
    }
}
