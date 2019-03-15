using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.RiskProfile;
using System.Data;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class RiskProfilingAssetAllocation : DevExpress.XtraReports.UI.XtraReport
    {
        public RiskProfilingAssetAllocation(Client client, int riskprofileId)
        {
            const int MAXYEARSCOUNT = 5;
            InitializeComponent();
            this.lblClientName.Text = client.Name;
            RiskProfileInfo riskProfile = new RiskProfileInfo();
            DataTable dtRiskProfileReturn =  riskProfile.GetRiskProfileReturnById(riskprofileId);
            if (dtRiskProfileReturn != null)
            {
                int rowIndex = 0;
                for(int year = 0; year <= MAXYEARSCOUNT; year++)
                {
                    if (year == 4)
                        continue;

                    DataRow[] dataRows = dtRiskProfileReturn.Select("YearRemaining ='" + year + "'");
                    if (dataRows.Length  >0)
                    {
                        xrTableRiskProfileAssetAllocation.Rows[rowIndex].Cells[2].Text = dataRows[0]["EquityInvestementRatio"].ToString() + "%";
                        xrTableRiskProfileAssetAllocation.Rows[rowIndex].Cells[3].Text = dataRows[0]["DebtInvestementRatio"].ToString() + "%";
                        xrTableRiskProfileAssetAllocation.Rows[rowIndex].Cells[4].Text = dataRows[0]["AverageInvestemetReturn"].ToString() + "%";
                        rowIndex++;
                    }
                }
            }
        }
    }
}
