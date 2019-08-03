using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model.TaskManagement.MFTransactions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FinancialPlannerClient.Master.TaskMaster
{
    public partial class ARNView : DevExpress.XtraEditors.XtraForm
    {
        DataTable dtARN = new DataTable();
        public ARNView()
        {
            InitializeComponent();
        }

        private void ARNView_Load(object sender, EventArgs e)
        {
            fillupARN();
        }
        private void fillupARN()
        {
            ARNInfo arnInfo = new ARNInfo();
            IList<ARN> arnDetails = arnInfo.GetAll();
            if (arnDetails != null && arnDetails.Count > 0)
            {
                dtARN = ListtoDataTable.ToDataTable(arnDetails.ToList());
                gridControlARN.DataSource = dtARN;
                //setgridViewDisplay();
            }
        }

        private void setgridViewDisplay()
        {
            gridViewARN.Columns["ID"].Visible = false;
            gridViewARN.Columns["CreatedOn"].Visible = false;
            gridViewARN.Columns["CreatedBy"].Visible = false;
            gridViewARN.Columns["UpdatedOn"].Visible = false;
            gridViewARN.Columns["UpdatedBy"].Visible = false;
            gridViewARN.Columns["UpdatedByUserName"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grpARNDetails.Enabled = true;
            txtARNNumber.Text = string.Empty;
            txtARNNumber.Tag = "0";
            txtName.Text = string.Empty;
        }

        private void txtARNNumber_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = string.IsNullOrEmpty(txtARNNumber.Text);
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = string.IsNullOrEmpty(txtName.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtARNNumber.Text) || string.IsNullOrEmpty(txtName.Text))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Please enter ARN Number and Name.",
                    "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ARN arn = getARN();
            bool isSaved = false;

            if (arn != null && arn.Id == 0)
                isSaved = new ARNInfo().Add(arn);
            else
                isSaved = new ARNInfo().Update(arn);

            if (isSaved)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Record save successfully.",
                   "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fillupARN();
                grpARNDetails.Enabled = false;
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Unable to save record.",
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private ARN getARN()
        {
            ARN arn = new ARN();
            arn.Id = int.Parse(txtARNNumber.Tag.ToString());
            arn.ArnNumber = txtARNNumber.Text;
            arn.Name = txtName.Text;
            arn.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            arn.CreatedBy = Program.CurrentUser.Id;
            arn.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            arn.UpdatedBy = Program.CurrentUser.Id;
            arn.UpdatedByUserName = Program.CurrentUser.UserName;
            arn.MachineName = Environment.MachineName;
            return arn;
        }

        private void gridViewARN_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {

        }

        private void gridViewARN_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridViewARN.FocusedRowHandle >= 0)
            {
                txtName.Text = gridViewARN.GetFocusedRowCellValue(gridViewARN.Columns[1]).ToString();
                txtARNNumber.Text = gridViewARN.GetFocusedRowCellValue(gridViewARN.Columns[0]).ToString();
                txtARNNumber.Tag = gridViewARN.GetFocusedRowCellValue(gridViewARN.Columns[2]).ToString();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridViewARN.FocusedRowHandle >= 0)
            {
                grpARNDetails.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            grpARNDetails.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridViewARN.FocusedRowHandle >= 0)
            {
                if ((DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this record?",
                  "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    ARN arn = getARN();
                    if (!new ARNInfo().Delete(arn))
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Unable to delete this record.",
                            "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        fillupARN();
                }
            }
        }
    }
}