using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class AssetAllocationTitle : DevExpress.XtraReports.UI.XtraReport
    {
        public AssetAllocationTitle(FinancialPlanner.Common.Model.Client client)
        {
            InitializeComponent();
            this.lblClientName.Text = client.Name;
        }
    }
}
