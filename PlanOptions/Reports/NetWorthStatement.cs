using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.CurrentStatus;
using FinancialPlannerClient.PlannerInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class NetWorthStatement : DevExpress.XtraReports.UI.XtraReport
    {
        Planner planner;
        DataTable dtNetWorth = new DataTable();
        const string FINANCIAL_ASSETS = "Financial Assets";
        const string FD = "Fixed Deposit";
        const string RD = "Recurring Deposit";
        const string SA = "Saving Account";
        const string EMF = "Equity Mutual Fund";
        const string DMF = "Dept Mutual Fund";
        const string PPF = "PPF";
        const string BONDS = "Bonds";
        const string SS = "Sukanya Sum. Account";
        const string SHARES = "Shares";
        const string REAL_ESTATE = "Real Estate";
        const string LIABILITY = "LIABILITY";
        double totalAssetsValue, totalLiabilitiesValue;
        public NetWorthStatement(Client client, Planner planner)
        {
            InitializeComponent();
            this.lblClientName.Text = client.Name;
            this.planner = planner;
            createNetWorthTableStructure();
            generateReport();
        }

        public DataTable GetNetWorth()
        {
            return dtNetWorth;
        }

        private void createNetWorthTableStructure()
        {
            dtNetWorth.Columns.Add("Group", typeof(System.String));
            dtNetWorth.Columns.Add("Title", typeof(System.String));
            dtNetWorth.Columns.Add("Amount", typeof(System.Double));
            dtNetWorth.Columns.Add("Liability", typeof(System.String));
            dtNetWorth.Columns.Add("LaibilityAmount", typeof(System.Double));
        }

        private void generateReport()
        {
            getTotalBankBalance();
            getMFBalance();
            getPPFBalance();
            getBondsBalance();
            getSSSBalance();
            getSharesBalance();
            getFixedAssetsBalance();
            getLiabilitiesValue();
            setDataForReport();
            setTotal();
            setGraph();
        }

        private void setGraph()
        {
            xrChartNetWorth.Series[0].Points[0].Values = new double[] { totalAssetsValue };
            xrChartNetWorth.Series[0].Points[1].Values = new double[] { totalLiabilitiesValue };
            xrChartNetWorth.Series[0].Points[2].Values = new double[] { totalAssetsValue - totalLiabilitiesValue };
        }

        private void setTotal()
        {
            double totalOfSumAmount = 0;
            double.TryParse(dtNetWorth.Compute("Sum(Amount)", string.Empty).ToString(), out totalOfSumAmount);
            totalAssetsValue = totalOfSumAmount;
            totalLiabilitiesValue = dtNetWorth.Compute("Sum(LaibilityAmount)", string.Empty) != DBNull.Value ?
                double.Parse(dtNetWorth.Compute("Sum(LaibilityAmount)",string.Empty).ToString()) : 0;
            lblTotalAssets.Text = totalAssetsValue.ToString("#,###");
            lblTotalLiabilities.Text = totalLiabilitiesValue.ToString("#,###");
        }

        private void setDataForReport()
        {
            int rowIndex = 0;
            string groupTitle = string.Empty;
            foreach (DataRow dr in dtNetWorth.Rows)
            {
                if (groupTitle != dr[0].ToString())
                {
                    groupTitle = dr[0].ToString();
                    if (groupTitle != LIABILITY)
                    {
                        xrTableNetWorth.Rows[rowIndex].Cells[0].Text = groupTitle;
                        xrTableNetWorth.Rows[rowIndex].Cells[0].ForeColor = Color.RoyalBlue;
                    }
                    else
                    {
                        rowIndex = 0;
                    }
                    rowIndex++;
                }
                if (groupTitle != LIABILITY)
                {
                    xrTableNetWorth.Rows[rowIndex].Cells[0].Text = dr[1].ToString();
                    xrTableNetWorth.Rows[rowIndex].Cells[1].Text = dr[2].ToString();
                }
                else
                {
                    xrTableNetWorth.Rows[rowIndex].Cells[2].Text = dr[3].ToString();
                    xrTableNetWorth.Rows[rowIndex].Cells[3].Text = dr[4].ToString();
                }
                rowIndex++;
            }
        }

        #region "Liabilities"
        private void getLiabilitiesValue()
        {
            LoanInfo loanInfo = new LoanInfo();
            List<Loan> loanInfos = (List<Loan>)loanInfo.GetAll(this.planner.ID);
            DataTable dtLoans = ListtoDataTable.ToDataTable(loanInfos);
            if (dtLoans != null && dtLoans.Rows.Count > 0)
            {
                foreach (DataRow dr in dtLoans.Rows)
                {
                    DataRow drNetWorth = dtNetWorth.NewRow();
                    drNetWorth["Group"] = LIABILITY;
                    drNetWorth["Amount"] = 0;
                    drNetWorth["Liability"] = dr["TypeOfLoan"];
                    drNetWorth["LaibilityAmount"] = Math.Round(double.Parse(dr["OutstandingAmt"].ToString()));
                    dtNetWorth.Rows.Add(drNetWorth);
                }
            }
        }
        #endregion

        #region "FixedAssets"
        private void getFixedAssetsBalance()
        {
            NonFinancialAssetInfo nonFinancialAssetInfo = new NonFinancialAssetInfo();
            List<NonFinancialAsset> lstNonFinancialAsset = (List<NonFinancialAsset>)nonFinancialAssetInfo.GetAll(this.planner.ID);
            DataTable dtNonFinancialAsset = ListtoDataTable.ToDataTable(lstNonFinancialAsset);
            if (dtNonFinancialAsset != null && dtNonFinancialAsset.Rows.Count > 0)
            {
                foreach (DataRow dr in dtNonFinancialAsset.Rows)
                {
                    DataRow drNetWorth = dtNetWorth.NewRow();
                    drNetWorth["Group"] = REAL_ESTATE;
                    drNetWorth["Title"] = dr["Name"];
                    drNetWorth["Amount"] = Math.Round(double.Parse(dr["CurrentValue"].ToString()));
                    dtNetWorth.Rows.Add(drNetWorth);
                }
            }

        }
        #endregion

        #region "Shares"
        private void getSharesBalance()
        {
            SharesInfo sharesInfo = new SharesInfo();
            double totalSharesValue = 0;
            DataTable dtSS = sharesInfo.GetSharesInfo(this.planner.ID);
            if (dtSS != null && dtSS.Rows.Count > 0)
            {
                totalSharesValue = dtSS.AsEnumerable().Sum(x => Convert.ToDouble(x["CurrentValue"]));
            }
            if (totalSharesValue > 0)
            {
                DataRow drNetWorth = dtNetWorth.NewRow();
                drNetWorth["Group"] = FINANCIAL_ASSETS;
                drNetWorth["Title"] = SHARES;
                drNetWorth["Amount"] = Math.Round(totalSharesValue);
                dtNetWorth.Rows.Add(drNetWorth);
            }
        }
        #endregion

        #region "Sukanya Sum. Account"
        private void getSSSBalance()
        {
            SukanyaSamrudhiInfo ssInfo = new SukanyaSamrudhiInfo();
            double totalSSValue = 0;
            DataTable dtSS = ssInfo.GetSukanyaSamrudhiInfo(this.planner.ID);
            if (dtSS != null && dtSS.Rows.Count > 0)
            {
                totalSSValue = dtSS.AsEnumerable().Sum(x => Convert.ToDouble(x["CurrentValue"]));
            }

            if (totalSSValue > 0)
            {
                DataRow drNetWorth = dtNetWorth.NewRow();
                drNetWorth["Group"] = FINANCIAL_ASSETS;
                drNetWorth["Title"] = SS;
                drNetWorth["Amount"] = Math.Round(totalSSValue);
                dtNetWorth.Rows.Add(drNetWorth);
            }
        }
        #endregion

        #region "Bonds"
        private void getBondsBalance()
        {
            BondInfo bondInfo = new BondInfo();
            double totalBondValue = 0;
            DataTable dtBond = bondInfo.GetBondsInfo(this.planner.ID);
            if (dtBond != null && dtBond.Rows.Count > 0)
            {
                totalBondValue = dtBond.AsEnumerable().Sum(x => Convert.ToDouble(x["CurrentValue"]));
            }

            if (totalBondValue > 0)
            {
                DataRow drNetWorth = dtNetWorth.NewRow();
                drNetWorth["Group"] = FINANCIAL_ASSETS;
                drNetWorth["Title"] = BONDS;
                drNetWorth["Amount"] = Math.Round(totalBondValue);
                dtNetWorth.Rows.Add(drNetWorth);
            }
        }
        #endregion

        #region "PPF"
        private void getPPFBalance()
        {
            PPFInfo ppfInfo = new PPFInfo();
            double totalPPFValue = 0;
            DataTable dtPPF = ppfInfo.GetPPFInfo(this.planner.ID);
            if (dtPPF != null && dtPPF.Rows.Count > 0)
            {
                totalPPFValue = dtPPF.AsEnumerable().Sum(x => Convert.ToDouble(x["CurrentValue"]));
            }

            if (totalPPFValue > 0)
            {
                DataRow drNetWorth = dtNetWorth.NewRow();
                drNetWorth["Group"] = FINANCIAL_ASSETS;
                drNetWorth["Title"] = PPF;
                drNetWorth["Amount"] = Math.Round(totalPPFValue);
                dtNetWorth.Rows.Add(drNetWorth);
            }
        }
        #endregion

        #region "MF"
        private void getMFBalance()
        {
            MutualFundInfo mutualFundInfo = new MutualFundInfo();
            double totalMFValue = 0;
            double totalDMFValue = 0;
            DataTable dtMF = mutualFundInfo.GetMutualFundInfo(this.planner.ID);
            if (dtMF != null && dtMF.Rows.Count > 0)
            {
                totalMFValue = dtMF.AsEnumerable().Sum(x => (Convert.ToDouble(x["CurrentValue"]) * Convert.ToDouble(x["EquityRatio"])) / 100);
                //Convert.ToDouble(x["NAV"]) * Convert.ToDouble(x["Units"]));
                //double.Parse(dtMF.Compute("sum(NAV * Units)", string.Empty).ToString());
            }

            if (totalMFValue > 0)
            {
                DataRow drNetWorth = dtNetWorth.NewRow();
                drNetWorth["Group"] = FINANCIAL_ASSETS;
                drNetWorth["Title"] = EMF;
                drNetWorth["Amount"] = Math.Round(totalMFValue);
                dtNetWorth.Rows.Add(drNetWorth);
            }

            if (dtMF != null && dtMF.Rows.Count > 0)
            {
                totalDMFValue = dtMF.AsEnumerable().Sum(x => (Convert.ToDouble(x["CurrentValue"]) * Convert.ToDouble(x["DebtRatio"])) / 100);
                //Convert.ToDouble(x["NAV"]) * Convert.ToDouble(x["Units"]));
                //double.Parse(dtMF.Compute("sum(NAV * Units)", string.Empty).ToString());
            }
            if (totalDMFValue > 0)
            {
                DataRow drNetWorth = dtNetWorth.NewRow();
                drNetWorth["Group"] = FINANCIAL_ASSETS;
                drNetWorth["Title"] = DMF;
                drNetWorth["Amount"] = Math.Round(totalDMFValue);
                dtNetWorth.Rows.Add(drNetWorth);
            }

        }
        #endregion

        #region "Bank"
        private void getTotalBankBalance()
        {
            double fdAmount = getFDAmount();
            double rdAmount = getRDAmount();
            double saAmount = getSavingAccountAmount();
            if (fdAmount > 0)
            {
                addBankAmountToNetWorth(FD,fdAmount);
            }
            if (rdAmount > 0)
            {
                addBankAmountToNetWorth(RD, rdAmount);
            }
            if (saAmount  > 0)
            {
                addBankAmountToNetWorth(SA, saAmount);
            }
        }

        private void addBankAmountToNetWorth(string accountType, double totalBankAmount)
        {
            DataRow drNetWorth = dtNetWorth.NewRow();
            drNetWorth["Group"] = FINANCIAL_ASSETS;
            drNetWorth["Title"] = accountType;
            drNetWorth["Amount"] = Math.Round(totalBankAmount);
            dtNetWorth.Rows.Add(drNetWorth);
        }

        private double getSavingAccountAmount()
        {
            SavingAccountInfo savingAccountInfo = new SavingAccountInfo();
            double totalSAValue = 0;
            DataTable dtSA = savingAccountInfo.GetSavingAccountInfo(this.planner.ID);
            if (dtSA != null && dtSA.Rows.Count > 0)
            {
                totalSAValue = dtSA.AsEnumerable().Sum(x => Convert.ToDouble(x["Balance"]));
            }
            return totalSAValue;
        }

        private double getRDAmount()
        {
            RDInfo fdInfo = new RDInfo();
            double totalRDValue = 0;
            DataTable dtRD = fdInfo.GetRecurringDepositInfo(this.planner.ID);
            if (dtRD != null && dtRD.Rows.Count > 0)
            {
                totalRDValue = dtRD.AsEnumerable().Sum(x => Convert.ToDouble(x["Balance"]));
            }
            return totalRDValue;
        }

        private void lblAmount0_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblAmount0.Text))
            {
                lblAmount0.Text = String.Format("{0:#,###}", double.Parse(lblAmount0.Text));
            }
        }

        private void lblAmount1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblAmount1.Text))
            {
                lblAmount1.Text = String.Format("{0:#,###}", double.Parse(lblAmount1.Text));
            }
        }

        private void lblAmount2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblAmount2.Text))
            {
                lblAmount2.Text = String.Format("{0:#,###}", double.Parse(lblAmount2.Text));
            }
        }

        private void xrTableCell10_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell10.Text))
            {
                xrTableCell10.Text = String.Format("{0:#,###}", double.Parse(xrTableCell10.Text));
            }
        }

        private void xrTableCell16_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell16.Text))
            {
                xrTableCell16.Text = String.Format("{0:#,###}", double.Parse(xrTableCell16.Text));
            }
        }

        private void xrTableCell20_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell20.Text))
            {
                xrTableCell20.Text = String.Format("{0:#,###}", double.Parse(xrTableCell20.Text));
            }
        }

        private void xrTableCell24_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell24.Text))
            {
                xrTableCell24.Text = String.Format("{0:#,###}", double.Parse(xrTableCell24.Text));
            }
        }

        private void xrTableCell28_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell28.Text))
            {
                xrTableCell28.Text = String.Format("{0:#,###}", double.Parse(xrTableCell28.Text));
            }
        }

        private void xrTableCell32_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell32.Text))
            {
                xrTableCell32.Text = String.Format("{0:#,###}", double.Parse(xrTableCell32.Text));
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

        private void xrTableCell52_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell52.Text))
            {
                xrTableCell52.Text = String.Format("{0:#,###}", double.Parse(xrTableCell52.Text));
            }
        }

        private void xrTableCell44_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell44.Text))
            {
                xrTableCell44.Text = String.Format("{0:#,###}", double.Parse(xrTableCell44.Text));
            }
        }

        private void xrTableCell48_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell48.Text))
            {
                xrTableCell48.Text = String.Format("{0:#,###}", double.Parse(xrTableCell48.Text));
            }
        }

        private void lblTotalAssets_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblTotalAssets.Text))
            {
                lblTotalAssets.Text = String.Format("{0:#,###}", double.Parse(lblTotalAssets.Text));
            }
        }

        private void lblTotalLiabilities_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblTotalLiabilities.Text))
            {
                lblTotalLiabilities.Text = String.Format("{0:#,###}", double.Parse(lblTotalLiabilities.Text));
            }
        }

        private void xrTableCell50_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell50.Text))
            {
                xrTableCell50.Text = String.Format("{0:#,###}", double.Parse(xrTableCell50.Text));
            }
        }

        private void xrTableCell46_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell46.Text))
            {
                xrTableCell46.Text = String.Format("{0:#,###}", double.Parse(xrTableCell46.Text));
            }
        }

        private void xrTableCell54_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell54.Text))
            {
                xrTableCell54.Text = String.Format("{0:#,###}", double.Parse(xrTableCell54.Text));
            }
        }

        private void xrTableCell42_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell42.Text))
            {
                xrTableCell42.Text = String.Format("{0:#,###}", double.Parse(xrTableCell42.Text));
            }
        }

        private void xrTableCell38_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell38.Text))
            {
                xrTableCell38.Text = String.Format("{0:#,###}", double.Parse(xrTableCell38.Text));
            }
        }

        private void xrTableCell34_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell34.Text))
            {
                xrTableCell34.Text = String.Format("{0:#,###}", double.Parse(xrTableCell34.Text));
            }
        }

        private void xrTableCell30_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell30.Text))
            {
                xrTableCell30.Text = String.Format("{0:#,###}", double.Parse(xrTableCell30.Text));
            }
        }

        private void xrTableCell26_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell26.Text))
            {
                xrTableCell26.Text = String.Format("{0:#,###}", double.Parse(xrTableCell26.Text));
            }
        }

        private void xrTableCell22_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell22.Text))
            {
                xrTableCell22.Text = String.Format("{0:#,###}", double.Parse(xrTableCell22.Text));
            }
        }

        private void xrTableCell18_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell18.Text))
            {
                xrTableCell18.Text = String.Format("{0:#,###}", double.Parse(xrTableCell18.Text));
            }
        }

        private void xrTableCell14_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell14.Text))
            {
                xrTableCell14.Text = String.Format("{0:#,###}", double.Parse(xrTableCell14.Text));
            }
        }

        private void xrTableCell6_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell6.Text))
            {
                xrTableCell6.Text = String.Format("{0:#,###}", double.Parse(xrTableCell6.Text));
            }
        }

        private void xrTableCell5_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell5.Text))
            {
                xrTableCell5.Text = String.Format("{0:#,###}", double.Parse(xrTableCell5.Text));
            }
        }

        private void xrTableCell4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell4.Text))
            {
                xrTableCell4.Text = String.Format("{0:#,###}", double.Parse(xrTableCell4.Text));
            }
        }

        private double getFDAmount()
        {
            FDInfo fdInfo = new FDInfo();
            double totalFDValue = 0;
            DataTable dtFD = fdInfo.GetFixedDepositInfo(this.planner.ID);
            if (dtFD != null && dtFD.Rows.Count > 0)
            {
                totalFDValue = dtFD.AsEnumerable().Sum(x => Convert.ToDouble(x["Balance"]));
            }
            return totalFDValue;
        }
        #endregion

    }
}
