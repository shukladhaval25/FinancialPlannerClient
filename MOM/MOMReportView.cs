using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using FinancialPlannerClient.PlannerInfo;
using FinancialPlanner.Common.Model;
using System.Collections.Generic;
using FinancialPlanner.Common.DataConversion;

namespace FinancialPlannerClient.MOM
{
    public partial class MOMReportView : DevExpress.XtraReports.UI.XtraReport
    {
        private DataTable _dtMOMPoints;
        
        DataSet _ds = new DataSet();
        public MOMReportView(MOMTransaction transaction)
        {
            InitializeComponent();
            
            _dtMOMPoints = ListtoDataTable.ToDataTable(transaction.MOMPoints);
            _dtMOMPoints.TableName = "MOM";
            
            _ds.Tables.Add(_dtMOMPoints);
            
            this.DataSource = _ds;
            this.DataMember = _ds.Tables[0].TableName;

            this.lblDate.Text = transaction.MeetingDate.ToShortDateString();
            this.lblTypeOfMeeting.Text = transaction.MeetingType;
          
            this.lblResponsibility.DataBindings.Add("Text", this.DataSource, "MOM.Responsibility");
            this.lblPointsDiscussed.DataBindings.Add("Text", this.DataSource, "MOM.DiscussedPoint");
            this.lblFutureAction.DataBindings.Add("Text", this.DataSource, "MOM.FutureAction");
        }

    }
}
