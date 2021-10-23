using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FinancialPlanner.Common.Model;
using System.Data;
using FinancialPlannerClient.CurrentStatus;
using FinancialPlannerClient.PlannerInfo;
using System.Collections.Generic;
using System.Linq;
using FinancialPlanner.Common.DataConversion;
using FinancialPlannerClient.RiskProfile;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class TermInsurancePage : DevExpress.XtraReports.UI.XtraReport
    {
        Client client;
        private DataTable dataTable;
        int riskprofileId;

        public TermInsurancePage(Client client, DataTable dataTable,Planner planner,int riskProfileId)
        {
            InitializeComponent();
            this.client = client;
            this.dataTable = dataTable;
            this.riskprofileId = riskProfileId;
            lblPeriod.Text = planner.StartDate.ToShortDateString() + " - " + planner.EndDate.ToShortDateString();
            lblEquityRatioWithUS.Text = planner.EquityRatio.ToString() + "%";
            lblDebtRatioWithUS.Text = planner.DebtRatio.ToString() + "%";
            displayRiskProfileRatio();
            displayExecutionData();
        }

        private void displayRiskProfileRatio()
        {
            RiskProfileInfo riskProfile = new RiskProfileInfo();
            DataTable dtRiskProfileReturn = riskProfile.GetRiskProfileReturnById(riskprofileId);
            int currentYear = 5;

            DataRow[] dataRows = dtRiskProfileReturn.Select("YearRemaining ='" + currentYear + "'");
            if (dataRows.Length > 0)
            {
                lblequityValue.Text = dataRows[0]["EquityInvestementRatio"].ToString() + "%";
                lblDebtValue.Text = dataRows[0]["DebtInvestementRatio"].ToString() + "%";
            }
        }

        private void displayExecutionData()
        {
            double totalEquityAmount = dataTable.AsEnumerable().Sum(x => Convert.ToDouble(x["EquityAmount"]));
            double totalDebtAmount = dataTable.AsEnumerable().Sum(x => Convert.ToDouble(x["DebtAmount"]));
            double totalFinalTotalAmount = dataTable.AsEnumerable().Sum(x => Convert.ToDouble(x["FinalTotal"]));
            xrlblEecutionEquityRatio.Text = ((totalEquityAmount / totalFinalTotalAmount) * 100).ToString("N0", PlannerMainReport.Info)+  "%";
            xrlblExeuctionDebtRatio.Text = ((totalDebtAmount / totalFinalTotalAmount) * 100).ToString("N0", PlannerMainReport.Info) + "%";
        }

        private void xrlblEecutionEquityRatio_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

        }
    }
}
