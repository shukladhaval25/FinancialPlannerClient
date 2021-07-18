using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FinancialPlanner.Common.Model;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class Recomendation : DevExpress.XtraReports.UI.XtraReport
    {
        public Recomendation(Client client,string recomendationNote)
        {
            InitializeComponent();
            this.lblClientName.Text = client.Name;
            this.lblRecomendation.Text = recomendationNote;
        }

    }
}
