using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FinancialPlanner.Common.Model;
using System.Data;
using FinancialPlannerClient.TaskManagementSystem.TransactionOptions.Helper;
using System.Collections.Generic;
using FinancialPlanner.Common.DataConversion;

namespace FinancialPlannerClient.PlanOptions.Reports.Investment_Recommendation
{
    public partial class SwitchDetails : DevExpress.XtraReports.UI.XtraReport
    {
        Client client;
        Planner planner;
        DataTable _dtInvestment;
        public SwitchDetails(Client client, Planner planner)
        {
            InitializeComponent();
            this.client = client;
            this.planner = planner;
            getSwitchData();
        }

        private void getSwitchData()
        {
            SwitchTypeInvestmentRecommendationHelper switchTypeInvestmentRecommendationHelper = new SwitchTypeInvestmentRecommendationHelper();

            List<SwitchTypeInvestmentRecommendation> switchTypeInvestmentRecommendations =
               (List<SwitchTypeInvestmentRecommendation>)switchTypeInvestmentRecommendationHelper.GetAll(this.planner.ID);

            DataTable dttempLumsumInv = ListtoDataTable.ToDataTable(switchTypeInvestmentRecommendations);

            _dtInvestment = dttempLumsumInv.Clone();
            _dtInvestment.Columns["Amount"].DataType = typeof(Double);
            foreach (DataRow row in dttempLumsumInv.Rows)
            {
                _dtInvestment.ImportRow(row);
            }

            this.DataSource = _dtInvestment;
            this.DataMember = _dtInvestment.TableName;

            this.lblFromSchemeName.DataBindings.Add("Text", this.DataSource, "Investment.FromSchemeName");
            this.lblToScheme.DataBindings.Add("Text", this.DataSource, "Investment.ToSchemeName");
            this.lblAmount.DataBindings.Add("Text", this.DataSource, "Investment.Amount");
            this.lblTotalAmount.DataBindings.Add("Text", this.DataSource, "Investment.Amount");
        }
    }
}
