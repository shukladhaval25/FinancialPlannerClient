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
        const string FD = "Fixed Deposit";
        const string RD = "Recurring Deposit";
        const string SA = "Saving Account";
        const string EMF = "Equity Mutual Fund";
        const string DMF = "Dept Mutual Fund";
        const string PPF = "PPF";
        const string BONDS = "Bonds";
        const string SS = "Sukanya Sum. Account";
        const string SHARES = "Shares";

        const string NPS_EQUITY = "NPS Equity";
        const string ULIP_EQUITY = "ULIP Equity";
        const string OTHERS_EQUITY = "Others Equity";

        const string ULIPS_DEBT = "ULIP Dept";
        const string NPS_DEPT = "NPS Dept";
        const string OTHERS_DEBT = "Others Dept";
        const string EPF = "EPF";
        const string NSC = "NSC";
        const string SCSS = "SCSS";

        const string GOLD = "Gold";
        const string OTHERS_GOLD = "Others";
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
                dtNetWorth.Rows[indexRow]["Title"].ToString() == SHARES ||
                dtNetWorth.Rows[indexRow]["Title"].ToString() == NPS_EQUITY  ||
                dtNetWorth.Rows[indexRow]["Title"].ToString() == ULIP_EQUITY ||
                dtNetWorth.Rows[indexRow]["Title"].ToString() == OTHERS_EQUITY )
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
            if (dtNetWorth.Rows[indexRow]["Title"].ToString() ==  FD ||
                dtNetWorth.Rows[indexRow]["Title"].ToString().Trim() == RD.Trim() ||
                dtNetWorth.Rows[indexRow]["Title"].ToString() == SA ||
                dtNetWorth.Rows[indexRow]["Title"].ToString() == BONDS ||
                dtNetWorth.Rows[indexRow]["Title"].ToString() == PPF ||
                dtNetWorth.Rows[indexRow]["Title"].ToString() == DMF ||
                dtNetWorth.Rows[indexRow]["Title"].ToString() == SS ||
                dtNetWorth.Rows[indexRow]["Title"].ToString() == ULIPS_DEBT ||
                dtNetWorth.Rows[indexRow]["Title"].ToString() == NPS_DEPT ||
                dtNetWorth.Rows[indexRow]["Title"].ToString() == OTHERS_DEBT  ||
                dtNetWorth.Rows[indexRow]["Title"].ToString() == EPF ||
                dtNetWorth.Rows[indexRow]["Title"].ToString() == NSC ||
                dtNetWorth.Rows[indexRow]["Title"].ToString() == SCSS)
            {
                xrTableDebt.Rows[rowIndexForDebt].Cells[0].Text = dtNetWorth.Rows[indexRow]["Title"].ToString();
                xrTableDebt.Rows[rowIndexForDebt].Cells[1].Text = dtNetWorth.Rows[indexRow]["Amount"].ToString();
                if ((dtNetWorth.Rows[indexRow]["Amount"].ToString() != null))
                    totalDebtValue = totalDebtValue +
                        double.Parse(dtNetWorth.Rows[indexRow]["Amount"].ToString());
                rowIndexForDebt++;
            }
        }

        private void lblNetWorth_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblNetWorth.Text))
            {
                lblNetWorth.Text = String.Format("{0:#,###}", double.Parse(lblNetWorth.Text));
            }
        }

        private void xrTableCell2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell2.Text))
            {
                xrTableCell2.Text = String.Format("{0:#,###}", double.Parse(xrTableCell2.Text));
            }
        }

        private void xrTableCell4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell4.Text))
            {
                xrTableCell4.Text = String.Format("{0:#,###}", double.Parse(xrTableCell4.Text));
            }
        }

        private void xrTableCell6_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell6.Text))
            {
                xrTableCell6.Text = String.Format("{0:#,###}", double.Parse(xrTableCell6.Text));
            }
        }

        private void xrTableCell8_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell8.Text))
            {
                xrTableCell8.Text = String.Format("{0:#,###}", double.Parse(xrTableCell8.Text));
            }
        }

        private void lblEquityTotal_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblEquityTotal.Text))
            {
                lblEquityTotal.Text = String.Format("{0:#,###}", double.Parse(lblEquityTotal.Text));
            }
        }

        private void xrTableCell14_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell14.Text))
            {
                xrTableCell14.Text = String.Format("{0:#,###}", double.Parse(xrTableCell14.Text));
            }
        }

        private void xrTableCell16_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell16.Text))
            {
                xrTableCell16.Text = String.Format("{0:#,###}", double.Parse(xrTableCell16.Text));
            }
        }

        private void xrTableCell18_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell18.Text))
            {
                xrTableCell18.Text = String.Format("{0:#,###}", double.Parse(xrTableCell18.Text));
            }
        }

        private void xrTableCell20_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell20.Text))
            {
                xrTableCell20.Text = String.Format("{0:#,###}", double.Parse(xrTableCell20.Text));
            }
        }

        private void xrTableCell22_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell22.Text))
            {
                xrTableCell22.Text = String.Format("{0:#,###}", double.Parse(xrTableCell22.Text));
            }
        }

        private void xrTableCell24_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell24.Text))
            {
                xrTableCell24.Text = String.Format("{0:#,###}", double.Parse(xrTableCell24.Text));
            }
        }

        private void xrTableCell26_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell26.Text))
            {
                xrTableCell26.Text = String.Format("{0:#,###}", double.Parse(xrTableCell26.Text));
            }
        }

        private void xrTableCell28_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell28.Text))
            {
                xrTableCell28.Text = String.Format("{0:#,###}", double.Parse(xrTableCell28.Text));
            }
        }

        private void xrTableCell30_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell30.Text))
            {
                xrTableCell30.Text = String.Format("{0:#,###}", double.Parse(xrTableCell30.Text));
            }
        }

        private void lblDebtTotal_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblDebtTotal.Text))
            {
                lblDebtTotal.Text = String.Format("{0:#,###}", double.Parse(lblDebtTotal.Text));
            }
        }

        private void xrTableCell32_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell32.Text))
            {
                xrTableCell32.Text = String.Format("{0:#,###}", double.Parse(xrTableCell32.Text));
            }
        }

        private void xrTableCell34_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell34.Text))
            {
                xrTableCell34.Text = String.Format("{0:#,###}", double.Parse(xrTableCell34.Text));
            }
        }

        private void xrTableCell36_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell36.Text))
            {
                xrTableCell36.Text = String.Format("{0:#,###}", double.Parse(xrTableCell36.Text));
            }
        }

        private void xrTableCell40_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell40.Text))
            {
                xrTableCell40.Text = String.Format("{0:#,###}", double.Parse(xrTableCell40.Text));
            }
        }

        private void xrTableCell38_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell38.Text))
            {
                xrTableCell38.Text = String.Format("{0:#,###}", double.Parse(xrTableCell38.Text));
            }
        }
    }
}
