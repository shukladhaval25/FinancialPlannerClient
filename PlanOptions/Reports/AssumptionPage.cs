using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FinancialPlanner.Common.Model;

namespace FinancialPlannerClient.PlanOptions
{
    public partial class AssumptionPage : DevExpress.XtraReports.UI.XtraReport
    {
        public AssumptionPage(PersonalInformation personalInformation)
        {
            InitializeComponent();
            this.lblClientName.Text = personalInformation.Client.Name;
            this.lblClientNameForRet.Text = lblClientName.Text;
            this.lblSpouseNameForRet.Text = personalInformation.Spouse.Name;
            this.lblClientNameLifeExp.Text = lblClientName.Text;
            this.lblSpouseLifeExp.Text = personalInformation.Spouse.Name;
        }

    }
}
