using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FinancialPlanner.Common.Model;
using System.Data;
using System.Collections.Generic;
using FinancialPlannerClient.TaskManagementSystem.TransactionOptions.Helper;
using FinancialPlanner.Common.DataConversion;

namespace FinancialPlannerClient.PlanOptions.Reports.Investment_Recommendation
{
    public partial class STPDetails : DevExpress.XtraReports.UI.XtraReport
    {
        Client client;
        Planner planner;
        DataTable _dtInvestment;
        public STPDetails(Client client, Planner planner)
        {
            InitializeComponent();
            this.client = client;
            this.planner = planner;
            getSTPData();
        }

        private void getSTPData()
        {
            STPInvestmentRecommendationHelper stpInvestmentRecommendationHelper = new STPInvestmentRecommendationHelper();

            List<STPTypeInvestmentRecomendation> lumsumInvestmentRecomendations =
               (List<STPTypeInvestmentRecomendation>)stpInvestmentRecommendationHelper.GetAll(this.planner.ID);

            DataTable dttempLumsumInv = ListtoDataTable.ToDataTable(lumsumInvestmentRecomendations);

            _dtInvestment = dttempLumsumInv.Clone();
            _dtInvestment.Columns["Amount"].DataType = typeof(Double);
            foreach (DataRow row in dttempLumsumInv.Rows)
            {
                _dtInvestment.ImportRow(row);
            }

            this.DataSource = _dtInvestment;
            this.DataMember = _dtInvestment.TableName;

            this.lblFromSchemeName.DataBindings.Add("Text", this.DataSource, "Investment.FromSchemeName");
            this.lblToScheme.DataBindings.Add("Text", this.DataSource, "Investment.schemeName");
            this.lblAmount.DataBindings.Add("Text", this.DataSource, "Investment.Amount");
            this.lblTotalAmount.DataBindings.Add("Text", this.DataSource, "Investment.Amount");
            this.lblFrequency.DataBindings.Add("Text", this.DataSource, "Investment.Frequency");
            this.lblInstallments.DataBindings.Add("Text", this.DataSource, "Investment.Duration");
        }
    }
}
