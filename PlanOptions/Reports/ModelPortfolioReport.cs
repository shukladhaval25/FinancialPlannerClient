using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.PlanOptions;
using FinancialPlanner.Common.Model.RiskProfile;
using FinancialPlannerClient.CashFlowManager;
using FinancialPlannerClient.CurrentStatus;
using FinancialPlannerClient.PlannerInfo;
using FinancialPlannerClient.RiskProfile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class ModelPortfolioReport : DevExpress.XtraReports.UI.XtraReport
    {
        DataTable _dtModelProfile = new DataTable();
        DataTable dtGroupOfGoals = new DataTable();
        Client client;
        Planner planner;
        int riskProfileId;
        string note;
         
        public ModelPortfolioReport(Planner planner, Client client, int riskProfileID,string note)
        {
            InitializeComponent();
            this.client = client;
            this.planner = planner;
            this.lblClientName.Text = client.Name;
            this.riskProfileId = riskProfileID;
            this.note = note;

            InvestmentByfercationInfo investmentByfercation = new InvestmentByfercationInfo();
            IList<ModelPortfolio> modelPortfolios = investmentByfercation.GetModelPortfolio(riskProfileID);
            _dtModelProfile = FinancialPlanner.Common.DataConversion.ListtoDataTable.ToDataTable(modelPortfolios.ToList());

            this.DataSource = _dtModelProfile;
            this.DataMember = _dtModelProfile.TableName;

            this.lblInvestmentType.DataBindings.Add("Text", this.DataSource, "InvestmentType");
            this.lblSegmentType.DataBindings.Add("Text", this.DataSource, "SegmentName");
            this.lblSegmentRatio.DataBindings.Add("Text", this.DataSource, "SegmentRatio");
            this.lblSchemeName.DataBindings.Add("Text", this.DataSource, "SchemeName");
            this.GroupHeader2.GroupFields[0].FieldName = "InvestmentType";
            this.GroupHeader1.GroupFields[0].FieldName = "SegmentName";
            this.lblNote.Rtf = this.note;
        }

        private void lblSegmentRatio_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!lblSegmentRatio.Text.EndsWith("%") &&  !string.IsNullOrEmpty(lblSegmentRatio.Text))
                lblSegmentRatio.Text = lblSegmentRatio.Text + " %";
        }
    }
}
