using FinancialPlanner.Common.Model;
using System;
using System.Data;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class ToTotalAssetRatio : DevExpress.XtraReports.UI.XtraReport
    {
        DataTable dtNetWorth;
        double totalRealEstate = 0;
        double totalAsset = 0;
        const string FD_RD_SAVING = "Fixed Deposit/Savings";
        const string REAL_ESTATE = "Real Estate";
        const string MF = "Mutual Fund";
        const string PPF = "PPF";
        const string BONDS = "Bonds";
        const string SS = "Sukanya Sum. Account";
        const string SHARES = "Shares";
        public ToTotalAssetRatio(Client client, DataTable dataTable)
        {
            InitializeComponent();
            this.lblClientName.Text = client.Name;
            this.dtNetWorth = dataTable;
            setTotalAsset();
            setRealEstate();
            setEquityDebtData();
        }

        private void setEquityDebtData()
        {
            double totalEquityValue = 0;
            double totalDebtValue = 0;

            //Equity
            if (dtNetWorth.Select(string.Format("Title = '{0}' or Title ='{1}'", SHARES, MF)).Length > 0)
            {
                totalEquityValue = double.Parse(dtNetWorth.Compute("Sum(Amount)", string.Format("Title = '{0}' or Title ='{1}'", SHARES, MF)).ToString());
            }
            xrChartEquityDebtRealEstate.Series[0].Points[0].Values = new double[] { ((totalEquityValue * 100) / totalAsset) };

            //Debt
            if (dtNetWorth.Select(string.Format("Title = '{0}' or Title = '{1}' or Title ='{2}'" +
                " or Title ='{3}'", FD_RD_SAVING, PPF, BONDS, SS)).Length > 0)
            {
                totalDebtValue = double.Parse(dtNetWorth.Compute("Sum(Amount)",
                    string.Format("Title = '{0}' or Title = '{1}' or Title ='{2}'" +
                " or Title ='{3}'", FD_RD_SAVING, PPF, BONDS, SS)).ToString());
            }
            xrChartEquityDebtRealEstate.Series[0].Points[1].Values = new double[] { ((totalDebtValue * 100) / totalAsset) };

            //Real Estate
            xrChartEquityDebtRealEstate.Series[0].Points[2].Values = new double[] { ((totalRealEstate * 100) / totalAsset) };
        }

        private void setRealEstate()
        {
            if (dtNetWorth != null)
            {
                if (dtNetWorth.Select(string.Format("Group = '{0}'", REAL_ESTATE)).Length > 0)
                    totalRealEstate = double.Parse(dtNetWorth.Compute("Sum(Amount)", string.Format("Group = '{0}'", REAL_ESTATE)).ToString());

                lblTotalAssetRatio.Text = string.Format("{0} %", ((totalAsset * 100) / totalAsset).ToString("###"));
                lblRealEstate.Text = string.Format("{0} %", ((totalRealEstate * 100) / totalAsset).ToString("##.##"));
                xrChartRealEstateToTotalAsset.Series[0].Points[0].Values = new double[] { ((totalAsset * 100) / totalAsset) };
                xrChartRealEstateToTotalAsset.Series[0].Points[1].Values = new double[] { ((totalRealEstate * 100) / totalAsset) };
            }
        }

        private void setTotalAsset()
        {
            if (dtNetWorth != null)
            {
                double totalOfSumAmount = 0;
                double.TryParse(dtNetWorth.Compute("Sum(Amount)", string.Empty).ToString(), out totalOfSumAmount);
                totalAsset = totalOfSumAmount;

                double totalLiability = dtNetWorth.Compute("Sum(LaibilityAmount)", string.Empty) != DBNull.Value ?
                    double.Parse(dtNetWorth.Compute("Sum(LaibilityAmount)", string.Empty).ToString()) : 0;
                lblTotalAsset.Text = string.Format("{0} %", ((totalAsset * 100) / totalAsset).ToString("###"));
                lblTotalLiability.Text = string.Format("{0} %", ((totalLiability * 100) / totalAsset).ToString("##.##"));
                chartLiabilityToAsset.Series[0].Points[0].Values = new double[] { ((totalAsset * 100) / totalAsset) };
                chartLiabilityToAsset.Series[0].Points[1].Values = new double[] { ((totalLiability * 100) / totalAsset) };
            }
        }
    }
}