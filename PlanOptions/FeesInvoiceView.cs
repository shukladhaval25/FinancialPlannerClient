using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using FinancialPlanner.Common;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.PlanOptions;

namespace FinancialPlannerClient.PlannerInfo
{
    public partial class FeesInvoiceView : DevExpress.XtraEditors.XtraForm
    {
        private Client client;
        private Planner planner;
        DataTable dtInvoice = new DataTable();
        DataTable dtInvoiceDetails;
        FeesInvoiceInfo feesInvoiceInfo;
        List<FeesInvoiceTransacation> feesInvoiceTransacations;
        public FeesInvoiceView()
        {
            InitializeComponent();
        }

        public FeesInvoiceView(Client client,Planner planner)
        {
            InitializeComponent();
            this.client = client;
            this.planner = planner;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int currentYear = DateTime.Now.Year;
            int currentMonth = DateTime.Now.Month;
            if (currentMonth == 1 || currentMonth == 2 || currentMonth == 3)
            {
                currentYear = currentYear - 1;
            }
            dtInvoiceDate.Text = DateTime.Now.ToShortDateString();
            string invoiceNo = feesInvoiceInfo.GetMaxId(string.Format("{0}-{1}", currentYear, (currentYear + 1).ToString().Substring(2)));
            txtInvoiceNo.Text = invoiceNo;
            txtInvoiceNo.Tag = 0;
            if (dtInvoiceDetails == null)
            {
                FeesInvoiceTransacation feesInvoiceTransacation = new FeesInvoiceTransacation();
                feesInvoiceTransacation.feesInvoiceDetails = new List<FeesInvoiceDetail>();
                dtInvoiceDetails = ListtoDataTable.ToDataTable(feesInvoiceTransacation.feesInvoiceDetails.ToList());
                gridInvoiceDetails.DataSource = dtInvoiceDetails;
            }
            dtInvoiceDetails.Rows.Clear();
        }

        private void FeesInvoiceView_Load(object sender, EventArgs e)
        {
            if (this.client == null)
            {
                throw new Exception("Invalid client");
            }
            fillFeesInvoice();
        }

        private void fillFeesInvoice()
        {
            feesInvoiceInfo = new FeesInvoiceInfo();
            var obj = feesInvoiceInfo.GetAll(this.client.ID);
            if (obj != null)
            {
                feesInvoiceTransacations = obj.ToList();
                dtInvoice = ListtoDataTable.ToDataTable(obj.ToList());
                gridInvoice.DataSource = dtInvoice;
            }
        }

        private void gridViewInvoice_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridViewInvoice.FocusedRowHandle >= 0)
            {
                if (gridViewInvoice.GetFocusedRowCellValue(gridViewInvoice.Columns["InvoiceDate"]) != null)
                {
                    dtInvoiceDate.Value =  DateTime.Parse(gridViewInvoice.GetFocusedRowCellValue(gridViewInvoice.Columns["InvoiceDate"]).ToString());
                }
                else
                {
                    dtInvoiceDate.Text = "";
                }

                txtInvoiceNo.Text =  (gridViewInvoice.GetFocusedRowCellValue(gridViewInvoice.Columns["InvoiceNo"]) == null) ? "" :
                    gridViewInvoice.GetFocusedRowCellValue(gridViewInvoice.Columns["InvoiceNo"]).ToString();
                txtInvoiceNo.Tag = txtInvoiceNo.Text;

                FeesInvoiceTransacation transaction = feesInvoiceTransacations.FirstOrDefault(i => i.InvoiceNo == txtInvoiceNo.Text);
                if (transaction != null)
                {
                    dtInvoiceDetails = ListtoDataTable.ToDataTable(transaction.feesInvoiceDetails.ToList());
                    gridInvoiceDetails.DataSource = dtInvoiceDetails;
                }
                //gridViewMOMPoints.Columns["Id"].Visible = false;
                //gridViewMOMPoints.Columns["MId"].Visible = false;
                //gridViewMOMPoints.Columns["FeatureAction"].Visible = false;

            }
        }

        private void btnAddParticulras_Click(object sender, EventArgs e)
        {
            gridViewInvoiceDetails.AddNewRow();
        }

        private void btnRemoveParticulars_Click(object sender, EventArgs e)
        {
            try
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete selected record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = 0;
                    int.TryParse(gridViewInvoiceDetails.GetRowCellValue(gridViewInvoiceDetails.FocusedRowHandle, "Id").ToString(), out id);
                    bool isDelete = false;
                    if (id > 0)
                    {
                        isDelete = feesInvoiceInfo.DeleteFeesInvoiceDetailsById(id);
                    }
                    else
                    {
                        isDelete = true;
                    }

                    if (isDelete)
                    {
                        gridViewInvoiceDetails.DeleteRow(gridViewInvoiceDetails.FocusedRowHandle);
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Unable to delete this record. Please try again.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception ex)
            {

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isValidateRecord())
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Please enter all require fields.",
                          "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                FeesInvoiceTransacation feesInvoiceTransacation = geFeesInvoiceTransction();
                bool isSucess;
                if (txtInvoiceNo.Tag.ToString() == "0")
                {
                    isSucess = feesInvoiceInfo.Add(feesInvoiceTransacation);
                }
                else
                {
                    isSucess = feesInvoiceInfo.Update(feesInvoiceTransacation);
                }

                if (isSucess)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Record saved sucessfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillFeesInvoice();
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Unable to saved this record.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Error :" + ex.ToString(),
               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private FeesInvoiceTransacation geFeesInvoiceTransction()
        {
            FeesInvoiceTransacation  feesInvoiceTransacation = new FeesInvoiceTransacation();
            feesInvoiceTransacation.CId = this.client.ID;
            feesInvoiceTransacation.InvoiceDate = dtInvoiceDate.Value;
            feesInvoiceTransacation.InvoiceNo = txtInvoiceNo.Text;
            
            feesInvoiceTransacation.feesInvoiceDetails = new List<FeesInvoiceDetail>();
            for (int rowIndex = 0; rowIndex <= gridViewInvoiceDetails.RowCount - 1; rowIndex++)
            {
                FeesInvoiceDetail point = new FeesInvoiceDetail();
                int id, EmpId = 0;
                int.TryParse(gridViewInvoiceDetails.GetRowCellValue(rowIndex, "Id").ToString(), out id);
                point.Id = id;
                point.InvoiceNo = txtInvoiceNo.Text;
                point.Particulars = gridViewInvoiceDetails.GetRowCellValue(rowIndex, "Particulars").ToString();
                double amount = 0;
                double.TryParse(gridViewInvoiceDetails.GetRowCellValue(rowIndex, "Amount").ToString(), out amount);
                point.Amount = amount;
                feesInvoiceTransacation.feesInvoiceDetails.Add(point);
            }
            return feesInvoiceTransacation;
        }

        private bool isValidateRecord()
        {
            if ((dtInvoiceDate.Value != null) && !string.IsNullOrEmpty(txtInvoiceNo.Text))
            {
                return true;
            }
            return false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridViewInvoice.FocusedRowHandle >= 0)
            {
                if ((DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this record?",
                  "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {

                    string invoiceId = gridViewInvoice.GetRowCellValue(gridViewInvoice.FocusedRowHandle, "InvoiceNo").ToString();

                    if (!feesInvoiceInfo.Delete(invoiceId))
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Unable to delete this record.",
                            "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        fillFeesInvoice();
                }
            }

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridViewInvoiceDetails_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;
            string defaultValue = "Suitability Analysis, Insurance Analysis &Succession Planning" + System.Environment.NewLine + string.Format("({0} to {1})", this.planner.StartDate.ToShortDateString(), this.planner.EndDate.ToShortDateString());
            view.SetRowCellValue(e.RowHandle, view.Columns["Particulars"], defaultValue);
        }

        private void btnPreviewInvoice_Click(object sender, EventArgs e)
        {
          if (!string.IsNullOrEmpty(txtInvoiceNo.Text))
            {
                FeesInvoiceTransacation transaction =  feesInvoiceTransacations.First(x => x.InvoiceNo == txtInvoiceNo.Text);
                FeesInvoiceReportView momReportView = new FeesInvoiceReportView(transaction,this.client);
                DevExpress.XtraReports.UI.ReportPrintTool printTool = new DevExpress.XtraReports.UI.ReportPrintTool(momReportView);
                printTool.ShowRibbonPreview();
            }
        }

        private void btnSendInvoiceReport_Click(object sender, EventArgs e)
        {
               if (!string.IsNullOrEmpty(txtInvoiceNo.Text))
            {
                FeesInvoiceTransacation transaction = feesInvoiceTransacations.First(x => x.InvoiceNo == txtInvoiceNo.Text);
                FeesInvoiceReportView feesInvoiceReport = new FeesInvoiceReportView(transaction, this.client);
                DevExpress.XtraReports.UI.ReportPrintTool printTool = new DevExpress.XtraReports.UI.ReportPrintTool(feesInvoiceReport);
                //printTool.ShowRibbonPreview();
                FinancialPlannerSendEmailConfiguration financialPlannerSendEmailConfiguration = new FinancialPlannerSendEmailConfiguration(feesInvoiceReport, this.client);
                financialPlannerSendEmailConfiguration.Show();
            }
        }
    }
}
