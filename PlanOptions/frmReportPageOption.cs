using FinancialPlanner.Common.Model.Masters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialPlannerClient.PlanOptions
{
    public partial class frmReportPageOption : DevExpress.XtraEditors.XtraForm
    {
        DataTable dtReportPages;
        public bool blnTableOfContent { get; set; }
        public bool blnIntroduction { get; set; }
        public bool blnWhatIsPlan { get; set; }
        public bool blnScopeOfPlan { get; set; }
        public bool blnAssumption { get; set; }
        public bool blnFamilyIntroduction { get; set; }
        public bool blnFinancialGoalIntroduction { get; set; }
        public bool blnClientFinancialGoals { get; set; }
        public bool blnGoalProjectionComplition { get; set; }
        public bool blnIncomeExpAnalysis { get; set; }
        public bool blnSpendingSavingRatio { get; set; }
        public bool blnSurplusPeriod { get; set; }
        public bool blnNetWorthAnalysis { get; set; }
        public bool blnNetWorthStatemet { get; set; }
        public bool blnTotalAssetRatio { get; set; }
        public bool blnNetWortYearOnYear { get; set; }
        public bool blnCurrentFinancialStatus { get; set; }
        public bool blnRiskProfilling { get; set; }
        public bool blnRiskProfillingAssetAllocatin{ get; set; }
        public bool blnCurrentFinancialAssetAllocation { get; set; }
        public bool blnStrategicAssetAllocation { get; set; }
        public bool blnSmartGoal { get; set; }
        public bool blnCurrentStatusReport { get; set; }
        public bool blnGoalDescription { get; set; }
        public bool blnAssetAllocationTitle { get; set; }
        public bool blnActionPlan { get; set; }
        public bool blnRecomendation { get; set; }
        ReportPageSettingInfo reportPageSettingInfo;
        IList<ReportPageSetting> reportPageSettings;
        public bool blnExecutionSheet { get; set; }
        public frmReportPageOption()
        {
            InitializeComponent();
        }

        private void frmReportPageOption_Load(object sender, EventArgs e)
        {
            reportPageSettingInfo = new ReportPageSettingInfo();
            reportPageSettings = reportPageSettingInfo.GetAll();
            dtReportPages = new DataTable();
            generateReportPages();
            bindDataTable();

        }

        private void bindDataTable()
        {
            gridControlReport.DataSource = dtReportPages;
            gridViewReport.Columns[1].OptionsColumn.AllowEdit = false;
        }

        private void generateReportPages()
        {
            dtReportPages.Columns.Add("IsSelected", Type.GetType("System.Boolean"));
            dtReportPages.Columns.Add("Page");

            string[] pages = new string[] {
                "Table Of Content",
                "Introduction",
                "What Is Plan (Introduction)",
                "Scope of Plan",
                "Assumptions",
                "Family Information",
                "Financial Goal Introduction",
                "Client Financial Goals",
                "Goal Projection Complition",
                "Income Expense Analysis",
                "Spending Saving Ratio",
                "Surplus Period",
                "NetWorth Analysis",
                "NetWorth Statement",
                "Total Asset Ratio",
                "NetWorth Year On Year",
                "Current Financial Status",
                "Risk Profiling",
                "Risk Profiling Asset Allocation",
                "Current Financial Asset Allocation",
                "Strategic Assets Collection",
                "Smart Goal (Introduction)",
                "Current Status Report",
                "Goal Description",
                "Asset Allocation Title",
                "ActionPlan",
                "Recomendation",
                "ExecutionSheet"
            };

            foreach(string page in pages)
            {
                DataRow dr = dtReportPages.NewRow();
                ReportPageSetting report = reportPageSettings.First(x => x.ReportPageName.Equals(page.Trim()));
                dr["IsSelected"] = (report != null) ? report.IsSelected : true;
                dr["Page"] = page.ToString();
                dtReportPages.Rows.Add(dr);
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            try
            {
                for (int index = 0; index <= gridViewReport.RowCount - 1; index++)
                {
                    bool IsSelected = bool.Parse(gridViewReport.GetRowCellValue(index, "IsSelected").ToString());
                    setPropertyBasedOnSelection(gridViewReport.GetRowCellValue(index, "Page").ToString(), IsSelected);
                }
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void setPropertyBasedOnSelection(string value, bool isSelected)
        {
            switch (value)
            {
                case "Table Of Content":
                    blnTableOfContent = isSelected;
                    break;
                case "Introduction":
                    blnIntroduction = isSelected;
                    break;
                case "What Is Plan (Introduction)":
                    blnWhatIsPlan = isSelected;
                    break;
                case "Scope of Plan":
                    blnScopeOfPlan = isSelected;
                    break;
                case "Assumptions":
                    blnAssumption = isSelected;
                    break;
                case "Family Information":
                    blnFamilyIntroduction = isSelected;
                    break;
                case "Financial Goal Introduction":
                    blnFinancialGoalIntroduction = isSelected;
                    break;
                case "Client Financial Goals":
                    blnClientFinancialGoals = isSelected;
                    break;
                case "Goal Projection Complition":
                    blnGoalProjectionComplition = isSelected;
                    break;
                case "Income Expense Analysis":
                    blnIncomeExpAnalysis = isSelected;
                    break;
                case "Spending Saving Ratio":
                    blnSpendingSavingRatio = isSelected;
                    break;
                case "Surplus Period":
                    blnSurplusPeriod = isSelected;
                    break;
                case "NetWorth Analysis":
                    blnNetWorthAnalysis = isSelected;
                    break;
                case "NetWorth Statement":
                    blnNetWorthStatemet = isSelected;
                    break;
                case "Total Asset Ratio":
                    blnTotalAssetRatio = isSelected;
                    break;
                case "NetWorth Year On Year":
                    blnNetWortYearOnYear = isSelected;
                    break;
                case "Current Financial Status":
                    blnCurrentFinancialStatus = isSelected;
                    break;
                case "Risk Profiling":
                    blnRiskProfilling = isSelected;
                    break;
                case "Risk Profiling Asset Allocation":
                    blnRiskProfillingAssetAllocatin = isSelected;
                    break;
                case "Current Financial Asset Allocation":
                    blnCurrentFinancialAssetAllocation = isSelected;
                    break;
                case "Strategic Assets Collection":
                    blnStrategicAssetAllocation = isSelected;
                    break;
                case "Smart Goal(Introduction)":
                    blnSmartGoal = isSelected;
                    break;
                case "Current Status Report":
                    blnCurrentStatusReport = isSelected;
                    break;
                case "Goal Description":
                    blnGoalDescription = isSelected;
                    break;
                case "Asset Allocation Title":
                    blnAssetAllocationTitle = isSelected;
                    break;
                case "ActionPlan":
                    blnActionPlan = isSelected;
                    break;
                case "Recomendation":
                    blnRecomendation = isSelected;
                    break;
                case "ExecutionSheet":
                    blnExecutionSheet = isSelected;
                    break;
            }
            if (chkRememberSetting.Checked)
            {
                
                ReportPageSetting reportSetting = new ReportPageSetting() { ReportPageName = value,IsSelected = isSelected };
                reportPageSettingInfo.Update(reportSetting);
            }

        }
    }
}