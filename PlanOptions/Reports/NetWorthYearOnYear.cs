using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FinancialPlanner.Common.Model;
using System.Data;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class NetWorthYearOnYear : DevExpress.XtraReports.UI.XtraReport
    {
        DataTable dtNetWorth;
        public NetWorthYearOnYear(Client client,DataTable dataTable)
        {
            InitializeComponent();
            this.lblClientName.Text = client.Name;
            this.dtNetWorth = dataTable;
            this.DataSource = dtNetWorth;

            if (dtNetWorth != null)
            {
                this.DataMember = dtNetWorth.TableName;
                this.lblYear.DataBindings.Add("Text", this.DataSource, "NetWorth.Year");
                this.lblNetWorth.DataBindings.Add("Text", this.DataSource, "NetWorth.NetWorthValue");
                this.lblCWI.DataBindings.Add("Text", this.DataSource, "NetWorth.CWI");
            }
            //xrChartNetWorthYear.DataSource = dtNetWorth;           
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
                xrChartNetWorthYear.Series[0].Points.AddPoint(index.ToString(), netWorthValue);                    
            }
             rowIndex++;
            
            return dtPoko;
        }

    }
}
