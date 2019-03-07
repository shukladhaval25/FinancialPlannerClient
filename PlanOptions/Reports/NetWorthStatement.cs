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
        const string FD_RD_SAVING = "Fixed Deposit/Savings";
        const string MF = "Mutual Fund";
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
            totalAssetsValue = Double.Parse(dtNetWorth.Compute("Sum(Amount)", string.Empty).ToString());
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
                    drNetWorth["Liability"] = dr["TypeOfLoan"];
                    drNetWorth["LaibilityAmount"] = double.Parse(dr["OutstandingAmt"].ToString());
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
                    drNetWorth["Amount"] = double.Parse(dr["CurrentValue"].ToString());
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
                drNetWorth["Amount"] = totalSharesValue;
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
                drNetWorth["Amount"] = totalSSValue;
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
                drNetWorth["Amount"] = totalBondValue;
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
                drNetWorth["Amount"] = totalPPFValue;
                dtNetWorth.Rows.Add(drNetWorth);
            }
        }
        #endregion

        #region "MF"
        private void getMFBalance()
        {
            MutualFundInfo mutualFundInfo = new MutualFundInfo();
            double totalMFValue = 0;
            DataTable dtMF = mutualFundInfo.GetMutualFundInfo(this.planner.ID);
            if (dtMF != null && dtMF.Rows.Count > 0)
            {
                totalMFValue = dtMF.AsEnumerable().Sum(x => Convert.ToDouble(x["NAV"]) * Convert.ToDouble(x["Units"]));
                //double.Parse(dtMF.Compute("sum(NAV * Units)", string.Empty).ToString());
            }

            if (totalMFValue > 0)
            {
                DataRow drNetWorth = dtNetWorth.NewRow();
                drNetWorth["Group"] = FINANCIAL_ASSETS;
                drNetWorth["Title"] = MF;
                drNetWorth["Amount"] = totalMFValue;
                dtNetWorth.Rows.Add(drNetWorth);
            }
        }
        #endregion

        #region "Bank"
        private void getTotalBankBalance()
        {
            double totalBankAmount = getFDAmount();
            totalBankAmount = totalBankAmount + getRDAmount();
            totalBankAmount = totalBankAmount + getSavingAccountAmount();
            if (totalBankAmount > 0)
            {
                addBankAmountToNetWorth(totalBankAmount);
            }
        }

        private void addBankAmountToNetWorth(double totalBankAmount)
        {
            DataRow drNetWorth = dtNetWorth.NewRow();
            drNetWorth["Group"] = FINANCIAL_ASSETS;
            drNetWorth["Title"] = FD_RD_SAVING;
            drNetWorth["Amount"] = totalBankAmount;
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
