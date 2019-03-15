using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class RiskTolanceScore : DevExpress.XtraReports.UI.XtraReport
    {
        public RiskTolanceScore(FinancialPlanner.Common.Model.PersonalInformation personalInformation)
        {
            InitializeComponent();
            this.lblClient.Name = personalInformation.Client.Name;
        }

    }
}
