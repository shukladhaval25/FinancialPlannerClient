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
    public partial class InvBreackup : DevExpress.XtraReports.UI.XtraReport
    {
        Client client;
        Planner planner;
        DataTable _dtInvestment;
        public InvBreackup(Client client, Planner planner)
        {
            InitializeComponent();
            this.client = client;
            this.planner = planner;
            getInvestmentBreakupData();
        }

        private void getInvestmentBreakupData()
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

            this.DataSource = _dtInvestment;
            this.DataMember = _dtInvestment.TableName;

            this.lblSchemeName.DataBindings.Add("Text", this.DataSource, "Investment.SchemeName");
            this.lblCategory.DataBindings.Add("Text", this.DataSource, "Investment.Category");
            this.lblAmount.DataBindings.Add("Text", this.DataSource, "Investment.Amount");
            this.lblTotalAmount.DataBindings.Add("Text", this.DataSource, "Investment.Amount");
            this.lblFirstHolder.DataBindings.Add("Text", this.DataSource, "Investment.FirstHolder");
            this.lblSecondHolder.DataBindings.Add("Text", this.DataSource, "Investment.SecondHolder");
            this.lblThirdHolder.DataBindings.Add("Text", this.DataSource, "Investment.ThirdHolder");
            this.lblNominee.DataBindings.Add("Text", this.DataSource, "Investment.Nominee");
        }
    }
}
