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
    public partial class IncomeInflowChart : DevExpress.XtraReports.UI.XtraReport
    {
        Client client;
        Planner planner;
        DataTable _dtIncome;
        public IncomeInflowChart(Client client, Planner planner)
        {
            InitializeComponent();
            this.client = client;
            this.planner = planner;
            getIncomeData();
        }
        private void getIncomeData()
        {
            IncomeInfo incomeInfo = new IncomeInfo();
            List<Income> lstIncome = (List<Income>)incomeInfo.GetAll(this.planner.ID);
            _dtIncome = ListtoDataTable.ToDataTable(lstIncome);
            _dtIncome = _dtIncome.Select("StartYear ='" + DateTime.Now.Year.ToString() + "'").CopyToDataTable();
            this.DataSource = _dtIncome;
            this.DataMember = _dtIncome.TableName;
            xrChart1.DataSource = this.DataSource;
            xrChart1.DataMember = this.DataMember;

            xrChart1.Series[0].Points.Clear();
            xrChart1.Legend.CustomItems.Clear();
            int index = 0;
            foreach (DataRow dr in _dtIncome.Rows)
            {
                SeriesPoint seriesPoint = new SeriesPoint(dr["IncomeBy"].ToString(), new double[] { double.Parse(dr["Amount"].ToString())});
                seriesPoint.Color = (index == 0) ? System.Drawing.Color.Blue : (index == 1) ? System.Drawing.Color.OrangeRed :
                    (index == 2) ? System.Drawing.Color.Green : (index == 3) ? System.Drawing.Color.Indigo :
                    (index == 4) ? System.Drawing.Color.LightSkyBlue : (index == 5) ? System.Drawing.Color.Magenta :
                    (index == 6) ? System.Drawing.Color.MediumSlateBlue : System.Drawing.Color.Red ;
                xrChart1.Series[0].Points.Add(seriesPoint);
                xrChart1.Legend.CustomItems.Insert(index, new CustomLegendItem(dr["IncomeBy"].ToString()));
                xrChart1.Legend.CustomItems[index].MarkerColor = seriesPoint.Color; // xrChart1.Series[0].Points[index].Color;
                
                xrChart1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
                
                index = index + 1;
            }
        }
    }
}
