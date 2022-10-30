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
            
            DataRow[] dataRows = this._dtExpenses.Select("Rem_Corp_Fund<='0'","StartYear Asc");
            if (dataRows.Length > 0)
            {
                string startyear = dataRows[0][0].ToString();
                string endyear = dataRows[0][1].ToString();
                string clientage = dataRows[0][2].ToString();
                string spouseage = dataRows[0][3].ToString();
                lblClientAgeValue.Text = clientage.ToString();
                lblSpouseAgeVal.Text = spouseage.ToString();
                lblStartYearValue.Text = startyear.ToString();
                lblEndYearValue.Text = endyear.ToString();
            }
            else
            {
                lblInfo.Visible = false;
                xrTableInfo.Visible = false;
            }
        }

        private void getExpenseData()
        {
            xrChart1.DataSource = this._dtExpenses;

            xrChart1.Series[0].ArgumentDataMember = "StartYear";
            xrChart1.Series[1].ArgumentDataMember = "StartYear";
            xrChart1.Series[0].ValueDataMembers.AddRange(new string[] { "Total Annual Expenses" });
            xrChart1.Series[1].ValueDataMembers.AddRange(new string[] { "Rem_Corp_Fund" });
        }
    }
}
