using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FinancialPlanner.Common.Model;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class Introduction : DevExpress.XtraReports.UI.XtraReport
    {
        public Introduction(Client client)
        {
            InitializeComponent();
            this.lblClientName.Text = client.Name;
        }

    }
}
