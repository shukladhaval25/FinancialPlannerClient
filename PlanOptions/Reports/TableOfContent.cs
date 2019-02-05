using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FinancialPlanner.Common.Model;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class TableOfContent : DevExpress.XtraReports.UI.XtraReport
    {
        Client client;
        public TableOfContent(Client client)
        {
            InitializeComponent();
            this.client = client;
            this.lblClientName.Text = this.client.Name;
        }

    }
}
