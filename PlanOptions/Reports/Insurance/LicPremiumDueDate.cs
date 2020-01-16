using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace FinancialPlannerClient.PlanOptions.Reports.Insurance
{
    public partial class LicPremiumDueDate : DevExpress.XtraReports.UI.XtraReport
    {
        DateTime fromDate;
        DateTime toDate;
        public LicPremiumDueDate(DateTime fromDate,DateTime toDate)
        {
            InitializeComponent();
            this.fromDate = fromDate;
            this.toDate = toDate;
        }

    }
}
