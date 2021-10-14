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
using System.Text;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class RiskProfilingAssetAllocation : DevExpress.XtraReports.UI.XtraReport
    {

        private const string RISKPROFILE_GETALL = "RiskProfileReturn/GetAll";
        DataTable _dtRiskProfile;
        public RiskProfilingAssetAllocation(Client client, int riskprofileId)
        {
            const int MAXYEARSCOUNT = 6;
            InitializeComponent();
            this.lblClientName.Text = client.Name;
            loadRiskProfileReturnList();
            RiskProfileInfo riskProfile = new RiskProfileInfo();
            DataTable dtRiskProfileReturn =  riskProfile.GetRiskProfileReturnById(riskprofileId);
            
            if (dtRiskProfileReturn != null)
            {
                int rowIndex = 0;
                for(int year = 1; year < MAXYEARSCOUNT; year++)
                {
                    int currentYear =  year;                 
                    
                    DataRow[] dataRows = dtRiskProfileReturn.Select("YearRemaining ='" + currentYear + "'");
                    if (dataRows.Length  >0)
                    {
                        xrTableRiskProfileAssetAllocation.Rows[rowIndex].Cells[2].Text = dataRows[0]["EquityInvestementRatio"].ToString() + "%";
                        xrTableRiskProfileAssetAllocation.Rows[rowIndex].Cells[3].Text = dataRows[0]["DebtInvestementRatio"].ToString() + "%";
                        xrTableRiskProfileAssetAllocation.Rows[rowIndex].Cells[4].Text = dataRows[0]["AverageInvestemetReturn"].ToString() + "%";
                        rowIndex++;
                    }
                }

                DataRow[] drs = _dtRiskProfile.Select("ID ='" + riskprofileId + "'");
             
                System.Windows.Forms.RichTextBox richTextBox = new System.Windows.Forms.RichTextBox();
                richTextBox.Font = new System.Drawing.Font("Calibri", 11.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                richTextBox.SelectedText = "* Looking at your current circumstances we have profiled you as ";
                richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Bold);
                richTextBox.SelectedText = drs[0]["Name"].ToString();
                richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Regular);
                richTextBox.SelectedText = " investor so we " + string.Format("suggestholding {0} of investments in Equity and {1} in Debt.", xrTableRiskProfileAssetAllocation.Rows[4].Cells[2].Text,
                  xrTableRiskProfileAssetAllocation.Rows[4].Cells[3].Text)  +  Environment.NewLine + Environment.NewLine;
                richTextBox.SelectedText = "* To reduce the risk in equity we have adopted strategic asset allocation and value averaging." + Environment.NewLine + Environment.NewLine + "* As the goal comes closer we will be also reducing our equity expose as under:";

                //richTextBox.SelectionFont = new Font(richTextBox.Font, FontStyle.Bold);
                //richTextBox.SelectedText = xrTableRiskProfileAssetAllocation.Rows[4].Cells[3].Text;
                ((XRRichText)this.FindControl("lblRichTxtContent", true)).Rtf = richTextBox.Rtf;


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
