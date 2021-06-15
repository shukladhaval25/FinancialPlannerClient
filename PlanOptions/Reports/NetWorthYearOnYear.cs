using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FinancialPlanner.Common.Model;
using System.Data;
using System.Collections.Generic;
using FinancialPlanner.Common.DataConversion;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class NetWorthYearOnYear : DevExpress.XtraReports.UI.XtraReport
    {
        DataTable dtNetWorth;
        public NetWorthYearOnYear(Client client,DataTable dataTable)
        {
            InitializeComponent();
            List<NetWorth> networths;
            this.lblClientName.Text = client.Name;
            NetWorthInfo netWorthInfo = new NetWorthInfo();
            networths = (List<NetWorth>) netWorthInfo.Get(client.ID);
            this.dtNetWorth = ListtoDataTable.ToDataTable(networths);
            dtNetWorth.Columns.Add("CWI", typeof(System.Int16));
            double baseCWIAmout = 0;
            for(int rowCount = 0; rowCount <= dtNetWorth.Rows.Count - 1; rowCount++)
            {
                if (rowCount == 0)
                {
                    dtNetWorth.Rows[rowCount]["CWI"] = 100;
                    baseCWIAmout = double.Parse(dtNetWorth.Rows[rowCount]["Amount"].ToString());
                }
                else
                {
                    double currentNetWothAmount = double.Parse(dtNetWorth.Rows[rowCount]["Amount"].ToString());
                    dtNetWorth.Rows[rowCount]["CWI"] = (currentNetWothAmount * 100) / baseCWIAmout;
                }
            }
            this.DataSource = dtNetWorth;
            xChartNetWorth.DataSource = dtNetWorth;
            if (dtNetWorth != null)
            {
                this.DataMember = dtNetWorth.TableName;
                this.lblYear.DataBindings.Add("Text", this.DataSource, "NetWorth.Year");
                this.lblNetWorth.DataBindings.Add("Text", this.DataSource, "NetWorth.Amount");
                this.lblCWI.DataBindings.Add("Text", this.DataSource, "NetWorth.CWI");
            }
            //xrChartNetWorthYear.DataSource = dtNetWorth;      

            xChartNetWorth.SeriesDataMember = "Amount";
            xChartNetWorth.SeriesTemplate.ArgumentDataMember = "Year";
            xChartNetWorth.SeriesTemplate.ValueDataMembers.AddRange(new string[] { "CWI" });


            xChartNetWorth.SeriesTemplate.View = new DevExpress.XtraCharts.StackedBarSeriesView();
        }

        private DataTable getPokoDataTable()
        {
            DataTable dtPoko = new DataTable();
            dtPoko.Columns.Add("Year", typeof(System.Int16));
            dtPoko.Columns.Add("NetWorthValue", typeof(System.Double));
            dtPoko.Columns.Add("CWI", typeof(System.Int16));

            int year = DateTime.Now.Year;
            double netWorthValue = 200000;
            int rowIndex = 0;
            for (int index = year; index <= 2030; index++)
            {
                DataRow dr = dtPoko.NewRow();
                dr["Year"] = index;
                dr["NetWorthValue"] = netWorthValue + (netWorthValue * 10) / 100;
                netWorthValue = netWorthValue + (netWorthValue * 10) / 100;
                dtPoko.Rows.Add(dr);
                xChartNetWorth.Series[0].Points.AddPoint(index.ToString(), netWorthValue);                    
            }
             rowIndex++;
            
            return dtPoko;
        }

        private void lblNetWorth_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblNetWorth.Text))
            {
                lblNetWorth.Text = String.Format("{0:#,###}", double.Parse(lblNetWorth.Text));
            }
        }
    }
}
