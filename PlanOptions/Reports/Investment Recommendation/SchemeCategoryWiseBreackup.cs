using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.TaskManagementSystem.TransactionOptions.Helper;
using System.Data;
using System.Collections.Generic;
using FinancialPlanner.Common.DataConversion;
using System.Linq;

namespace FinancialPlannerClient.PlanOptions.Reports.Investment_Recommendation
{
    public partial class SchemeCategoryWiseBreackup : DevExpress.XtraReports.UI.XtraReport
    {
        Client client;
        Planner planner;
        DataTable _dtInvestment;
        double totalAmount;
        public SchemeCategoryWiseBreackup(Client client, Planner planner)
        {
            InitializeComponent();
            this.client = client;
            this.planner = planner;
            getInvestmentSchmeCategoryWiseBreakupData();
        }

        private void getInvestmentSchmeCategoryWiseBreakupData()
        {
            LumsumInvestmentRecomendationHelper lumsumInvestmentRecomendationHelper = new LumsumInvestmentRecomendationHelper();

            List<LumsumInvestmentRecomendation> lumsumInvestmentRecomendations =
                (List<LumsumInvestmentRecomendation>)lumsumInvestmentRecomendationHelper.GetAll(this.planner.ID);
            DataTable dttempLumsumInv = ListtoDataTable.ToDataTable(lumsumInvestmentRecomendations);

            _dtInvestment = dttempLumsumInv.Clone();
            _dtInvestment.Columns["Amount"].DataType = typeof(Double);
            foreach (DataRow row in dttempLumsumInv.Rows)
            {
                _dtInvestment.ImportRow(row);
            }

           _dtInvestment = _dtInvestment.AsEnumerable()
                         .GroupBy(r => r.Field<string>("Category"))
                         .Select(g =>
                         {
                             var row = _dtInvestment.NewRow();
                             row["Category"] = g.Key;
                             row["Amount"] = g.Sum(r => r.Field<double>("Amount"));
                             return row;
                         }).CopyToDataTable();

            totalAmount = _dtInvestment.AsEnumerable().Sum(x => Convert.ToDouble(x["Amount"]));

            this.DataSource = _dtInvestment;
            this.DataMember = _dtInvestment.TableName;

            this.lblSchemeCategory.DataBindings.Add("Text", this.DataSource, "Investment.Category");
            this.lblAmount.DataBindings.Add("Text", this.DataSource, "Investment.Amount");
            this.lblTotalAmount.DataBindings.Add("Text", this.DataSource, "Investment.Amount");
        }

        private void lblAmount_TextChanged(object sender, EventArgs e)
        {
            lblPercentage.Text = ((double.Parse(lblAmount.Text) * 100) / totalAmount).ToString("#.##") + "%";
        }
    }
}
