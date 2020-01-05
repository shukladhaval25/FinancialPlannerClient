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
using System.Linq;

namespace FinancialPlannerClient.PlanOptions.Reports.Investment_Recommendation
{
    public partial class ChequeInFavourOffDetails : DevExpress.XtraReports.UI.XtraReport
    {
        Client client;
        Planner planner;
        DataTable _dtInvestment;
        public ChequeInFavourOffDetails(Client client, Planner planner)
        {
            InitializeComponent();
            this.client = client;
            this.planner = planner;
            getChequeData();
        }
        private void getChequeData()
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
            if (_dtInvestment.Rows.Count > 0)
            {
                _dtInvestment = _dtInvestment.AsEnumerable()
                              .GroupBy(r => r.Field<string>("ChequeInFavourOff"))
                              .Select(g =>
                              {
                                  var row = _dtInvestment.NewRow();
                                  row["ChequeInFavourOff"] = g.Key;
                                  row["Amount"] = g.Sum(r => r.Field<double>("Amount"));
                                  return row;
                              }).CopyToDataTable();
            }

            _dtInvestment.TableName = "Investment";
            this.DataSource = _dtInvestment;
            this.DataMember = _dtInvestment.TableName;

            this.lblChequeName.DataBindings.Add("Text", this.DataSource, "Investment.ChequeInFavourOff");
            this.lblAmount.DataBindings.Add("Text", this.DataSource, "Investment.Amount");
            this.lblTotalAmount.DataBindings.Add("Text", this.DataSource, "Investment.Amount");
        }
    }
}
