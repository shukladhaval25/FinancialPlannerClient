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
            if (reportType == ReportType.LIC)
            {
                viewLicReport(dateTimeFrom.Value, dateTimeTo.Value);
                return;
            }

            if (reportType == ReportType.GeneralInsurnace)
            {
                viewGeneralInsuranceReport(dateTimeFrom.Value, dateTimeTo.Value);
                return;
            }
        }

        private void viewGeneralInsuranceReport(DateTime from, DateTime to)
        {
            
        }

        private void viewLicReport(DateTime from, DateTime to)
        {
            LicPremiumDueDate licPremiumDueDate = new LicPremiumDueDate(from, to);
            DevExpress.XtraReports.UI.ReportPrintTool printTool = new DevExpress.XtraReports.UI.ReportPrintTool(licPremiumDueDate);
            printTool.ShowRibbonPreview();
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
        GeneralInsurnace
    }
}