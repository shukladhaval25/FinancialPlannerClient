using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FinancialPlanner.Common.Model;
using System.Data;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class CurrentFinancialStatus : DevExpress.XtraReports.UI.XtraReport
    {
        DataTable dtNetWorth;
        const string FD_RD_SAVING = "Fixed Deposit/Savings";
        const string EMF = "Equity Mutual Fund";
        const string DMF = "Dept Mutual Fund";
        const string PPF = "PPF";
        const string BONDS = "Bonds";
        const string SS = "Sukanya Sum. Account";
        const string SHARES = "Shares";
        public CurrentFinancialStatus(Client client,DataTable dataTable)
        {
            InitializeComponent();
            this.lblClientName.Text = client.Name;
            this.dtNetWorth = dataTable;
            setReportData();
        }

        private void setReportData()
        {
            int rowIndexForEquity = 1;
            int rowIndexForDebt = 1;
            double totalEquityValue = 0;
            double totalDebtValue = 0;
            for(int indexRow =0; indexRow <= dtNetWorth.Rows.Count -1; indexRow++)
            {
                setEquityData(ref rowIndexForEquity, ref totalEquityValue, indexRow);
                setDebtData(ref rowIndexForDebt, ref totalDebtValue, indexRow);
            }
            lblEquityTotal.Text = totalEquityValue.ToString();
            lblDebtTotal.Text = totalDebtValue.ToString();
            xrChartCurrentStatus.Series[0].Points[0].Values = new double[] { totalEquityValue };
            xrChartCurrentStatus.Series[0].Points[1].Values = new double[] { totalDebtValue };
        }

        private void setEquityData(ref int rowIndexForEquity, ref double totalEquityValue, int indexRow)
        {
            if (dtNetWorth.Rows[indexRow]["Title"].ToString() == EMF ||
                dtNetWorth.Rows[indexRow]["Title"].ToString() == SHARES)
            {
                xrTableEquity.Rows[rowIndexForEquity].Cells[0].Text = dtNetWorth.Rows[indexRow]["Title"].ToString();
                xrTableEquity.Rows[rowIndexForEquity].Cells[1].Text = dtNetWorth.Rows[indexRow]["Amount"].ToString();
                if ((dtNetWorth.Rows[indexRow]["Amount"].ToString() != null))
                    totalEquityValue = totalEquityValue +
                        double.Parse(dtNetWorth.Rows[indexRow]["Amount"].ToString());
                rowIndexForEquity++;
            }
        }
        private void setDebtData(ref int rowIndexForDebt, ref double totalDebtValue, int indexRow)
        {
            if (dtNetWorth.Rows[indexRow]["Title"].ToString() ==  FD_RD_SAVING ||
                dtNetWorth.Rows[indexRow]["Title"].ToString() == BONDS ||
                dtNetWorth.Rows[indexRow]["Title"].ToString() == PPF ||
                dtNetWorth.Rows[indexRow]["Title"].ToString() == DMF ||
                dtNetWorth.Rows[indexRow]["Title"].ToString() == SS)
            {
                xrTableDebt.Rows[rowIndexForDebt].Cells[0].Text = dtNetWorth.Rows[indexRow]["Title"].ToString();
                xrTableDebt.Rows[rowIndexForDebt].Cells[1].Text = dtNetWorth.Rows[indexRow]["Amount"].ToString();
                if ((dtNetWorth.Rows[indexRow]["Amount"].ToString() != null))
                    totalDebtValue = totalDebtValue +
                        double.Parse(dtNetWorth.Rows[indexRow]["Amount"].ToString());
                rowIndexForDebt++;
            }
        }
    }
}
