using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace FinancialPlannerClient.AuditTrail
{
    public partial class AuditTrailView : DevExpress.XtraEditors.XtraForm
    {
        private const string AUDITLOGCONTROLLER = "Activities";
        private const string AUDITLOGCONTROLLER_BY_USER = "ActivitiesController/GetByUserName?userName={0}";
        DataTable _dtAuditTrail;

        public AuditTrailView()
        {
            InitializeComponent();
        }
        
        private void AuditTrailView_Load(object sender, EventArgs e)
        {
            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
            string apiurl = Program.WebServiceUrl + "/" + string.Format(AUDITLOGCONTROLLER_BY_USER, Program.CurrentUser.UserName);

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(apiurl);
            request.Method = "GET";
            String auditTrailJson = String.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);
                auditTrailJson = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
            }
            var auditTrailCollection = jsonSerialization.DeserializeFromString<Result<List<Activities>>>(auditTrailJson);

            if (auditTrailCollection.Value != null)
            {
                _dtAuditTrail = ListtoDataTable.ToDataTable(auditTrailCollection.Value);
                grdsplitAuditTrail.DataSource = _dtAuditTrail;
                gridDisplaySetting();
            }
        }

        private void gridDisplaySetting()
        {
            grdSplitAuditTrailView.Columns["Id"].Visible = false;
            grdSplitAuditTrailView.Columns["EntryType"].Visible = false;

            setGridColumnsHeader();
            setGridcolumnWidth();
        }
        private void setGridcolumnWidth()
        {
            grdSplitAuditTrailView.Columns["ActivityTypeValue"].Width = 200;
            grdSplitAuditTrailView.Columns["EventDescription"].Width = 400;
            grdSplitAuditTrailView.Columns["HostName"].Width = 150;
            grdSplitAuditTrailView.Columns["UserName"].Width = 100;
            grdSplitAuditTrailView.Columns["ActivityAt"].Width = 150;
            //grdSplitAuditTrailView.Columns["TypeImg"].VisibleIndex = 0;
            //grdSplitAuditTrailView.Columns["StatusImg"].VisibleIndex = 6;
        }

        private void setGridColumnsHeader()
        {
            grdSplitAuditTrailView.Columns["ActivityTypeValue"].Caption = "Type";
            grdSplitAuditTrailView.Columns["EventDescription"].Caption = "Description";
            grdSplitAuditTrailView.Columns["HostName"].Caption = "Computer";
            grdSplitAuditTrailView.Columns["UserName"].Caption = "User";
            grdSplitAuditTrailView.Columns["ActivityAt"].Caption = "Date and Time";
            grdSplitAuditTrailView.Columns["SourceType"].Caption = "Source";
        }

        private void grdSplitAuditTrailView_CalcRowHeight(object sender, DevExpress.XtraGrid.Views.Grid.RowHeightEventArgs e)
        {

        }
    }
}
