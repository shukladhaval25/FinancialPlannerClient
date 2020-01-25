using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.PlanOptions.Reports.PPF;

namespace FinancialPlannerClient.PlanOptions.Reports.Insurance
{
    public partial class InsurancePremiumParameters : DevExpress.XtraEditors.XtraForm
    {
        ReportType reportType;
        public InsurancePremiumParameters(ReportType reportType)
        {
            InitializeComponent();
            this.reportType = reportType;
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (!validateDateRange())
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Date range is invalid. Please select proper data range.", "Date Range", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            viewReport();
        }

        private void viewReport()
        {
            // LIC Premium Due
            if (reportType == ReportType.LIC)
            {
                viewLicReport(dateTimeFrom.Value, dateTimeTo.Value);
                return;
            }

            // General Insurance Renewal
            if (reportType == ReportType.GeneralInsurnace)
            {
                viewGeneralInsuranceReport(dateTimeFrom.Value, dateTimeTo.Value);
                return;
            }

            // LIC Maturity
            if (reportType == ReportType.LICPolicyMaturity)
            {
                viewLicPolicyMaturity(dateTimeFrom.Value, dateTimeTo.Value);
                return;
            }

            // PPF Maturity
            if (reportType == ReportType.PPFMaturity)
            {
                viewPPFMaturityReport(dateTimeFrom.Value, dateTimeTo.Value);
            }
        }

        private void viewPPFMaturityReport(DateTime fromDate, DateTime toDate)
        {
            PPFMaturityReport maturityReport = new PPFMaturityReport(fromDate,toDate);
            DevExpress.XtraReports.UI.ReportPrintTool printTool = new DevExpress.XtraReports.UI.ReportPrintTool(maturityReport);
            printTool.ShowRibbonPreview();
            this.Close();
        }

        private void viewLicPolicyMaturity(DateTime from, DateTime to)
        {
            LICPolicyMaturity licPolicyMaturity = new LICPolicyMaturity(from, to);
            DevExpress.XtraReports.UI.ReportPrintTool printTool = new DevExpress.XtraReports.UI.ReportPrintTool(licPolicyMaturity);
            printTool.ShowRibbonPreview();
            this.Close();
        }

        private void viewGeneralInsuranceReport(DateTime from, DateTime to)
        {
            GeneralInsurancePremiumReminder generalInsurancePremiumReminder = new GeneralInsurancePremiumReminder(from, to);
            DevExpress.XtraReports.UI.ReportPrintTool printTool = new DevExpress.XtraReports.UI.ReportPrintTool(generalInsurancePremiumReminder);
            printTool.ShowRibbonPreview();
            this.Close();
        }

        private void viewLicReport(DateTime from, DateTime to)
        {
            LicPremiumDueDate licPremiumDueDate = new LicPremiumDueDate(from, to);
            DevExpress.XtraReports.UI.ReportPrintTool printTool = new DevExpress.XtraReports.UI.ReportPrintTool(licPremiumDueDate);
            printTool.ShowRibbonPreview();
            this.Close();
        }

        private bool validateDateRange()
        {
            return dateTimeFrom.Value < dateTimeTo.Value;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }

    public enum ReportType
    {
        LIC,
        LICPolicyMaturity,
        GeneralInsurnace,
        PPFMaturity
    }
}