using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.RiskProfile;
using System.Data;
using FinancialPlanner.Common;
using System.Collections.Generic;
using FinancialPlanner.Common.DataConversion;
using System.Windows.Forms;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class RiskProfilingAssetAllocation : DevExpress.XtraReports.UI.XtraReport
    {

        private const string RISKPROFILE_GETALL = "RiskProfileReturn/GetAll";
        DataTable _dtRiskProfile;
        public RiskProfilingAssetAllocation(Client client, int riskprofileId)
        {
            const int MAXYEARSCOUNT = 5;
            InitializeComponent();
            this.lblClientName.Text = client.Name;
            loadRiskProfileReturnList();
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

                DataRow[] drs = _dtRiskProfile.Select("ID ='" + riskprofileId + "'");
                lblRichTxtContent.Text = string.Format(lblRichTxtContent.Text, drs[0]["Name"].ToString(),
                    xrTableRiskProfileAssetAllocation.Rows[4].Cells[2].Text,
                    xrTableRiskProfileAssetAllocation.Rows[4].Cells[3].Text);
            }
        }
        private void loadRiskProfileReturnList()
        {
            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
            string apiurl = Program.WebServiceUrl + "/" + RISKPROFILE_GETALL;

            RestAPIExecutor restApiExecutor = new RestAPIExecutor();

            var restResult = restApiExecutor.Execute<List<RiskProfiledReturnMaster>>(apiurl, null, "GET");

            if (jsonSerialization.IsValidJson(restResult.ToString()))
            {
                var riskProfileColleection = jsonSerialization.DeserializeFromString<List<RiskProfiledReturnMaster>>(restResult.ToString());
                _dtRiskProfile = ListtoDataTable.ToDataTable(riskProfileColleection);
            }
            else
                MessageBox.Show(restResult.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
