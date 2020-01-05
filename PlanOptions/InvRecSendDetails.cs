using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.PlanOptions;
using System.IO;

namespace FinancialPlannerClient.PlanOptions
{
    public partial class InvRecSendDetails : DevExpress.XtraEditors.XtraForm
    {
        Client client;
        Planner planner;
        public InvRecSendDetails(Client currentClient, Planner planner)
        {
            InitializeComponent();
            this.client = currentClient;
            this.planner = planner;
        }

        private void InvRecSendDetails_Load(object sender, EventArgs e)
        {
            lblClientVal.Text = this.client.Name;
            lblPlannerVal.Text = this.planner.Name;
            InvRecSendInfo invRecSendInfo = new InvRecSendInfo();
            IList<InvRecommendationSend> invRecommendationSends = invRecSendInfo.Get(this.planner.ID);
            gridControlInvRec.DataSource = invRecommendationSends;
            gridViewInvRec.Columns["Pid"].Visible = false;
            gridViewInvRec.Columns["ClientId"].Visible = false;
        }

        private void gridViewInvRec_DoubleClick(object sender, EventArgs e)
        {
            viewReport();
        }

        private void viewReport()
        {
            if (gridViewInvRec.SelectedRowsCount > 0)
            {
                string filePath = gridViewInvRec.GetFocusedRowCellValue("ReportDataPath").ToString();
                string fileData = new InvRecSendInfo().GetFileString(filePath);
                byte[] arrBytes = Convert.FromBase64String(fileData);
                File.WriteAllBytes(Path.Combine(System.IO.Path.GetTempPath(), System.IO.Path.GetFileName(filePath)), arrBytes);
                pdfViewer.DocumentFilePath = Path.Combine(System.IO.Path.GetTempPath(), System.IO.Path.GetFileName(filePath));
                pdfViewer.LoadDocument(pdfViewer.DocumentFilePath);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            viewReport();
        }
    }
}