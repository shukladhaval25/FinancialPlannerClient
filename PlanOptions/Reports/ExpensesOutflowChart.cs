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
    public partial class ExpenseOutFlowChart : DevExpress.XtraReports.UI.XtraReport
    {       
        DataTable _dtExpenses;
        public ExpenseOutFlowChart(DataTable expenseTable)
        {
            InitializeComponent();           
            this._dtExpenses = expenseTable;
            getExpenseData();
        }
        private void getExpenseData()
        {            
            this.DataSource = _dtExpenses;
            this.DataMember = _dtExpenses.TableName;
            xrChart1.DataSource = this.DataSource;
            xrChart1.DataMember = this.DataMember;

            xrChart1.Series[0].Points.Clear();
            xrChart1.Legend.CustomItems.Clear();
            int index = 0;
            foreach (DataRow dr in _dtExpenses.Rows)
            {
                SeriesPoint seriesPoint = new SeriesPoint(dr["Item"].ToString(), new double[] { double.Parse(dr["Amount"].ToString()) });
                xrChart1.Series[0].Points.Add(seriesPoint);
                xrChart1.Legend.CustomItems.Insert(index, new CustomLegendItem(dr["Item"].ToString()));
                xrChart1.Legend.CustomItems[index].MarkerColor = xrChart1.Series[0].Points[index].Color;
                xrChart1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
                
                index = index + 1;
            }
        }
    }
}
