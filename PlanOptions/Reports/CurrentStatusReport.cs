using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class CurrentStatusReport : DevExpress.XtraReports.UI.XtraReport
    {
        public CurrentStatusReport(DataTable dataTable)
        {
            InitializeComponent();
            CurrentStatusDetails currentStatusDet = new CurrentStatusDetails(dataTable);
            currentStatusDet.CreateDocument();
            this.xrSubreportCurrentStatus.ReportSource = currentStatusDet;
        }

    }
}
