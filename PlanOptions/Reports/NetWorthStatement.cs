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
        const string DMF = "Debt Mutual Fund";
        const string PPF = "PPF";
        const string BONDS = "Bonds";
        const string SS = "Sukanya Sum. Account";
        const string SHARES = "Shares";
        const string REAL_ESTATE = "Real Estate";
        const string LIABILITY = "LIABILITY";

        const string NPS_EQUITY = "NPS Equity";
        const string ULIP_EQUITY = "ULIP Equity";
        const string OTHERS_EQUITY = "Others Equity";

        const string ULIPS_DEBT = "ULIP Debt";
        const string NPS_DEPT = "NPS Debt";
        const string OTHERS_DEBT = "Others Debt";
        const string EPF = "EPF";
        const string NSC = "NSC";
        const string SCSS = "SCSS";

        const string GOLD = "Gold";
        const string OTHERS_GOLD = "Others";


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
            dtNetWorth.Columns.Add("Description", typeof(System.String));
        }

        private void generateReport()
        {
            getTotalBankBalance();
            getMFBalance();
            getPPFBalance();
            getBondsBalance();
            getSSSBalance();
            getSharesBalance();
           
            

            getNPSBalance();
            getULIPBalance();
            getOthersBalance();
            getEPFBalance();
            getNSCBalance();
            getSCSSBalance();
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
                double.Parse(dtNetWorth.Compute("Sum(LaibilityAmount)", string.Empty).ToString()) : 0;
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
                    if (dr["Title"].ToString().Equals(OTHERS_EQUITY) || dr["Title"].ToString().Equals(OTHERS_DEBT) ||
                        dr["Title"].ToString().Equals(OTHERS_GOLD))
                    {
                        xrTableNetWorth.Rows[rowIndex].Cells[0].Text = dr["Description"].ToString();
                    }
                    else
                    {
                        xrTableNetWorth.Rows[rowIndex].Cells[0].Text = dr[1].ToString();
                    }
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
                //foreach (DataRow dr in dtMF.Rows)
                //{
                //    totalMFValue =  ((Convert.ToDouble(dr["CurrentValue"]) * Convert.ToDouble(dr["EquityRatio"])) / 100);

                //    totalDMFValue = ((Convert.ToDouble(dr["CurrentValue"]) * Convert.ToDouble(dr["DebtRatio"])) / 100);

                //    if (totalMFValue > 0)
                //    {
                //        DataRow drNetWorth = dtNetWorth.NewRow();
                //        drNetWorth["Group"] = FINANCIAL_ASSETS;
                //        drNetWorth["Title"] = EMF;
                //        drNetWorth["Amount"] = Math.Round(totalMFValue);
                //        drNetWorth["Description"] = dr[""]
                //        dtNetWorth.Rows.Add(drNetWorth);
                //    }

                //}
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
                addBankAmountToNetWorth(FD, fdAmount);
            }
            if (rdAmount > 0)
            {
                addBankAmountToNetWorth(RD, rdAmount);
            }
            if (saAmount > 0)
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
            if (!string.IsNullOrEmpty(lblAmount0.Text) && !lblAmount0.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                lblAmount0.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblAmount0.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void lblAmount1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblAmount1.Text) && !lblAmount1.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                lblAmount1.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblAmount1.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void lblAmount2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblAmount2.Text) && !lblAmount2.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                lblAmount2.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblAmount2.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void xrTableCell10_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell10.Text) && !xrTableCell10.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell10.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell10.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void xrTableCell16_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell16.Text) && !xrTableCell16.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell16.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell16.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void xrTableCell20_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell20.Text) && !xrTableCell20.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell20.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell20.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void xrTableCell24_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell24.Text) && !xrTableCell24.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell24.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell24.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void xrTableCell28_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell28.Text) && !xrTableCell28.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell28.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell28.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void xrTableCell32_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell32.Text) && !xrTableCell32.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell32.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell32.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void xrTableCell36_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell36.Text) && !xrTableCell36.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell36.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell36.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void xrTableCell40_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell40.Text) && !xrTableCell40.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell40.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell40.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void xrTableCell52_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell52.Text) && !xrTableCell52.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell52.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell52.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void xrTableCell44_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell44.Text) && !xrTableCell44.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell44.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell44.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void xrTableCell48_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell48.Text) && !xrTableCell48.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell48.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell48.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void lblTotalAssets_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblTotalAssets.Text) && !lblTotalAssets.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                lblTotalAssets.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblTotalAssets.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void lblTotalLiabilities_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblTotalLiabilities.Text) && !lblTotalLiabilities.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                lblTotalLiabilities.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblTotalLiabilities.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void xrTableCell50_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell50.Text) && !xrTableCell50.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell50.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell50.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void xrTableCell46_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell46.Text) && !xrTableCell46.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell46.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell46.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void xrTableCell54_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell54.Text) && !xrTableCell54.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell54.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell54.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void xrTableCell42_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell42.Text) && !xrTableCell54.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell42.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell42.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void xrTableCell38_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell38.Text) && !xrTableCell38.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell38.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell38.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void xrTableCell34_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell34.Text) && !xrTableCell34.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell34.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell34.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void xrTableCell30_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell30.Text) && !xrTableCell30.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell30.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell30.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void xrTableCell26_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell26.Text) && !xrTableCell26.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell26.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell26.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void xrTableCell22_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell22.Text) && !xrTableCell22.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell22.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell22.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void xrTableCell18_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell18.Text) && !xrTableCell18.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell18.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell18.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void xrTableCell14_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell14.Text) && !xrTableCell14.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell14.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell14.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void xrTableCell6_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell6.Text) && !xrTableCell6.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell6.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell6.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void xrTableCell5_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell5.Text) && !xrTableCell5.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell5.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell5.Text).ToString("N2", PlannerMainReport.Info);
            }
        }

        private void xrTableCell4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell4.Text)  && !xrTableCell4.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell4.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell4.Text).ToString("N2", PlannerMainReport.Info);
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

        #region "NPS"
        private void getNPSBalance()
        {            
            NPSInfo npsInfo = new NPSInfo();
            double totalNPSEquityValue = 0;
            double totalNPSDebValue = 0;
            DataTable dtNPS = npsInfo.GetNPSInfo(this.planner.ID);
            if (dtNPS != null && dtNPS.Rows.Count > 0)
            {
                totalNPSEquityValue = dtNPS.AsEnumerable().Sum(x => (Convert.ToDouble(x["CurrentValue"]) * Convert.ToDouble(x["EquityRatio"])) / 100);
            }

            if (totalNPSEquityValue > 0)
            {
                DataRow drNetWorth = dtNetWorth.NewRow();
                drNetWorth["Group"] = FINANCIAL_ASSETS;
                drNetWorth["Title"] = NPS_EQUITY;
                drNetWorth["Amount"] = Math.Round(totalNPSEquityValue);
                dtNetWorth.Rows.Add(drNetWorth);
            }

            if (dtNPS != null && dtNPS.Rows.Count > 0)
            {
                totalNPSDebValue = dtNPS.AsEnumerable().Sum(x => (Convert.ToDouble(x["CurrentValue"]) * Convert.ToDouble(x["DebtRatio"])) / 100);
            }
            if (totalNPSDebValue > 0)
            {
                DataRow drNetWorth = dtNetWorth.NewRow();
                drNetWorth["Group"] = FINANCIAL_ASSETS;
                drNetWorth["Title"] = NPS_DEPT;
;
                drNetWorth["Amount"] = Math.Round(totalNPSDebValue);
                dtNetWorth.Rows.Add(drNetWorth);
            }
        }
        #endregion

        #region "ULIP"
        private void getULIPBalance()
        {
            ULIPInfo ulipInfo = new ULIPInfo();
            double totalUlipEquityValue = 0;
            double totalUlipDebValue = 0;
            DataTable dtUlip = ulipInfo.GetULIPInfo(this.planner.ID);
            if (dtUlip != null && dtUlip.Rows.Count > 0)
            {
                totalUlipEquityValue = dtUlip.AsEnumerable().Sum(x => ((Convert.ToDouble(x["NAV"]) * Convert.ToDouble(x["Units"])) * Convert.ToDouble(x["EquityRatio"])) / 100);
                //Convert.ToDouble(x["NAV"]) * Convert.ToDouble(x["Units"]));
                //double.Parse(dtMF.Compute("sum(NAV * Units)", string.Empty).ToString());
            }

            if (totalUlipEquityValue > 0)
            {
                DataRow drNetWorth = dtNetWorth.NewRow();
                drNetWorth["Group"] = FINANCIAL_ASSETS;
                drNetWorth["Title"] = ULIP_EQUITY ;
                drNetWorth["Amount"] = Math.Round(totalUlipEquityValue);
                dtNetWorth.Rows.Add(drNetWorth);
            }

            if (dtUlip != null && dtUlip.Rows.Count > 0)
            {
                totalUlipDebValue = dtUlip.AsEnumerable().Sum(x => ((Convert.ToDouble(x["NAV"]) * Convert.ToDouble(x["Units"])) * Convert.ToDouble(x["DebtRatio"])) / 100);
                //Convert.ToDouble(x["NAV"]) * Convert.ToDouble(x["Units"]));
                //double.Parse(dtMF.Compute("sum(NAV * Units)", string.Empty).ToString());
            }
            if (totalUlipDebValue > 0)
            {
                DataRow drNetWorth = dtNetWorth.NewRow();
                drNetWorth["Group"] = FINANCIAL_ASSETS;
                drNetWorth["Title"] = ULIPS_DEBT
;
                drNetWorth["Amount"] = Math.Round(totalUlipDebValue);
                dtNetWorth.Rows.Add(drNetWorth);
            }

        }
        #endregion

        #region "Ohers"
        private void getOthersBalance()
        {
            OthersInfo  othersInfo = new OthersInfo();
            double totalOthersEquityValue = 0;
            double totalOthersDebValue = 0;
            double totalOthersGold = 0;
            DataTable dtOthers = othersInfo.GetOthersInfo(this.planner.ID);
            foreach(DataRow dr in dtOthers.Rows)
            {
                if (dr["TransactionType"].ToString().Equals("Equity"))
                {
                    totalOthersEquityValue = Convert.ToDouble(dr["Amount"].ToString());
                    if (totalOthersEquityValue > 0)
                    {
                        DataRow drNetWorth = dtNetWorth.NewRow();
                        drNetWorth["Group"] = FINANCIAL_ASSETS;
                        drNetWorth["Title"] = OTHERS_EQUITY;
                        drNetWorth["Amount"] = Math.Round(totalOthersEquityValue);
                        drNetWorth["Description"] = dr["Particular"].ToString();
                        dtNetWorth.Rows.Add(drNetWorth);
                    }
                }
                else if (dr["TransactionType"].ToString().Equals("Debt"))
                {
                    totalOthersDebValue = Convert.ToDouble(dr["Amount"].ToString());
                    if (totalOthersDebValue > 0)
                    {
                        DataRow drNetWorth = dtNetWorth.NewRow();
                        drNetWorth["Group"] = FINANCIAL_ASSETS;
                        drNetWorth["Title"] = OTHERS_DEBT;
                        ;
                        drNetWorth["Amount"] = Math.Round(totalOthersDebValue);
                        drNetWorth["Description"] = dr["Particular"].ToString();
                        dtNetWorth.Rows.Add(drNetWorth);
                    }
                }
                else if (dr["TransactionType"].ToString().Equals("Gold"))
                {
                    totalOthersGold = Convert.ToDouble(dr["Amount"].ToString());
                    if (totalOthersGold > 0)
                    {
                        DataRow drNetWorth = dtNetWorth.NewRow();
                        drNetWorth["Group"] = FINANCIAL_ASSETS;
                        drNetWorth["Title"] = OTHERS_GOLD;
                        ;
                        drNetWorth["Amount"] = Math.Round(totalOthersGold);
                        drNetWorth["Description"] = dr["Particular"].ToString();
                        dtNetWorth.Rows.Add(drNetWorth);
                    }
                }

            }
//            if (dtOthers != null && dtOthers.Rows.Count > 0)
//            {
//                //totalOthersEquityValue
//                totalOthersEquityValue = dtOthers.Select("TransactionType = 'Equity'").Sum(x => Convert.ToDouble(x["Amount"]));
//            }

//            if (totalOthersEquityValue > 0)
//            {
//                DataRow drNetWorth = dtNetWorth.NewRow();
//                drNetWorth["Group"] = FINANCIAL_ASSETS;
//                drNetWorth["Title"] = OTHERS_EQUITY;
//                drNetWorth["Amount"] = Math.Round(totalOthersEquityValue);
//                dtNetWorth.Rows.Add(drNetWorth);
//            }

//            if (dtOthers != null && dtOthers.Rows.Count > 0)
//            {
//                totalOthersDebValue = dtOthers.Select("TransactionType = 'Debt'").Sum(x => Convert.ToDouble(x["Amount"]));
//            }
//            if (totalOthersDebValue > 0)
//            {
//                DataRow drNetWorth = dtNetWorth.NewRow();
//                drNetWorth["Group"] = FINANCIAL_ASSETS;
//                drNetWorth["Title"] = OTHERS_DEBT;
//;
//                drNetWorth["Amount"] = Math.Round(totalOthersDebValue);
//                dtNetWorth.Rows.Add(drNetWorth);
//            }

//            if (dtOthers != null && dtOthers.Rows.Count > 0)
//            {
//                totalOthersGold = dtOthers.Select("TransactionType = 'Gold'").Sum(x => Convert.ToDouble(x["Amount"]));
//            }
//            if (totalOthersGold > 0)
//            {
//                DataRow drNetWorth = dtNetWorth.NewRow();
//                drNetWorth["Group"] = FINANCIAL_ASSETS;
//                drNetWorth["Title"] = OTHERS_GOLD;
//;
//                drNetWorth["Amount"] = Math.Round(totalOthersGold);
//                dtNetWorth.Rows.Add(drNetWorth);
//            }

        }
        #endregion

        #region "EPF"
        private void getEPFBalance()
        {
            EPFInfo npsInfo = new EPFInfo();
            double totalEPFValue = 0;
            DataTable dtEPF = npsInfo.GetEPFInfo(this.planner.ID);
            if (dtEPF != null && dtEPF.Rows.Count > 0)
            {
                totalEPFValue = dtEPF.AsEnumerable().Sum(x => Convert.ToDouble(x["Amount"]));
            }

            if (totalEPFValue > 0)
            {
                DataRow drNetWorth = dtNetWorth.NewRow();
                drNetWorth["Group"] = FINANCIAL_ASSETS;
                drNetWorth["Title"] = EPF;
                drNetWorth["Amount"] = Math.Round(totalEPFValue);
                dtNetWorth.Rows.Add(drNetWorth);
            }
        }
        #endregion

        #region "NSC"
        private void getNSCBalance()
        {
            NSCInfo npsInfo = new NSCInfo();
            double totalNSCValue = 0;
            DataTable dtNSC = npsInfo.GetNSCInfo(this.planner.ID);
            if (dtNSC != null && dtNSC.Rows.Count > 0)
            {
                totalNSCValue = dtNSC.AsEnumerable().Sum(x => Convert.ToDouble(x["CurrentValue"]));
            }

            if (totalNSCValue > 0)
            {
                DataRow drNetWorth = dtNetWorth.NewRow();
                drNetWorth["Group"] = FINANCIAL_ASSETS;
                drNetWorth["Title"] = NSC;
                drNetWorth["Amount"] = Math.Round(totalNSCValue);
                dtNetWorth.Rows.Add(drNetWorth);
            }
        }

        private void xrTableCell60_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell60.Text))
            {
                xrTableCell60.Text = String.Format("{0:#,###}", double.Parse(xrTableCell60.Text));
            }
        }

        private void xrTableCell58_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell58.Text))
            {
                xrTableCell58.Text = String.Format("{0:#,###}", double.Parse(xrTableCell58.Text));
            }
        }

        private void xrTableCell62_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell62.Text))
            {
                xrTableCell62.Text = String.Format("{0:#,###}", double.Parse(xrTableCell62.Text));
            }
        }

        private void xrTableCell70_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell70.Text))
            {
                xrTableCell70.Text = String.Format("{0:#,###}", double.Parse(xrTableCell70.Text));
            }
        }

        private void xrTableCell66_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell66.Text))
            {
                xrTableCell66.Text = String.Format("{0:#,###}", double.Parse(xrTableCell66.Text));
            }
        }

        private void xrTableCell64_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell64.Text))
            {
                xrTableCell64.Text = String.Format("{0:#,###}", double.Parse(xrTableCell64.Text));
            }
        }

        private void xrTableCell72_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell72.Text))
            {
                xrTableCell72.Text = String.Format("{0:#,###}", double.Parse(xrTableCell72.Text));
            }
        }

        private void xrTableCell68_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell68.Text))
            {
                xrTableCell68.Text = String.Format("{0:#,###}", double.Parse(xrTableCell68.Text));
            }
        }
        #endregion

        #region "SCSS"
        private void getSCSSBalance()
        {
            SCSSInfo npsInfo = new SCSSInfo();
            double totalSCSSValue = 0;
            DataTable dtSCSS = npsInfo.GetSCSSInfo(this.planner.ID);
            if (dtSCSS != null && dtSCSS.Rows.Count > 0)
            {
                totalSCSSValue = dtSCSS.AsEnumerable().Sum(x => Convert.ToDouble(x["CurrentValue"]));
            }

            if (totalSCSSValue > 0)
            {
                DataRow drNetWorth = dtNetWorth.NewRow();
                drNetWorth["Group"] = FINANCIAL_ASSETS;
                drNetWorth["Title"] = SCSS;
                drNetWorth["Amount"] = Math.Round(totalSCSSValue);
                dtNetWorth.Rows.Add(drNetWorth);
            }
        }
        #endregion
    }
}
