using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FinancialPlannerClient.PlannerInfo;
using System.Collections.Generic;
using FinancialPlanner.Common.Model;
using System.Data;
using FinancialPlanner.Common.DataConversion;
using DevExpress.XtraCharts;
using static DevExpress.XtraExport.Helpers.TableCellCss;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class PostRetirementExpChart : DevExpress.XtraReports.UI.XtraReport
    {       
        DataTable _dtExpenses;
        Planner planner;
        public PostRetirementExpChart(DataTable expenseTable, Planner planner)
        {
            InitializeComponent();           
            this._dtExpenses = expenseTable;
            this.planner = planner;
            getExpenseData();
        }
        private void getExpenseData()
        {
            //this._dtExpenses = CreateChartData();

            xrChart1.DataSource = this._dtExpenses;

            xrChart1.Series[0].ArgumentDataMember = "StartYear";
            xrChart1.Series[1].ArgumentDataMember = "StartYear";
            xrChart1.Series[0].ValueDataMembers.AddRange(new string[] { "Total Annual Expenses" });
            xrChart1.Series[1].ValueDataMembers.AddRange(new string[] { "Rem_Corp_Fund" });
        }
        private DataTable CreateChartData()
        {
            // Create an empty table.
            DataTable table = new DataTable("Table1");

            // Add three columns to the table.
            table.Columns.Add("Month", typeof(String));
            table.Columns.Add("Section", typeof(String));
            table.Columns.Add("Value", typeof(Int32));
            table.Columns.Add("Value1", typeof(Int32));

            // Add data rows to the table.
            table.Rows.Add(new object[] { "2000", "Section1", 100,1000 });
            table.Rows.Add(new object[] { "2001", "Section2", 150,900, });
            table.Rows.Add(new object[] { "2002", "Section1", 200,750 });
            table.Rows.Add(new object[] { "2003", "Section2", 250,550});
            table.Rows.Add(new object[] { "2004", "Section1", 300,400 });
            table.Rows.Add(new object[] { "2005", "Section2", 350,300 });
            table.Rows.Add(new object[] { "2006", "Section2", 450, 250 });
            table.Rows.Add(new object[] { "2007", "Section2", 550, 200 });
            table.Rows.Add(new object[] { "2008", "Section2", 600, 150 });
            table.Rows.Add(new object[] { "2009", "Section2", 650, 100 });
            table.Rows.Add(new object[] { "2010", "Section2", 700, 50 });
            table.Rows.Add(new object[] { "2011", "Section2", 800, 0 });
            table.Rows.Add(new object[] { "2012", "Section2", 850, -100 });

            return table;


            //PostRetirementCashFlowService postRetirementCashFlowService = new PostRetirementCashFlowService(this.planner, this.cashFlowService);

            //DataTable dataTable = postRetirementCashFlowService.GetPostRetirementCashFlowData();



        }
    }
}
