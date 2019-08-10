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
    public partial class SchemeView : DevExpress.XtraEditors.XtraForm
    {
        DataTable dtScheme = new DataTable();
        public SchemeView()
        {
            InitializeComponent();
        }

        private void SchemeView_Load(object sender, EventArgs e)
        {
            fillupScheme();
        }
        private void fillupScheme()
        {
            SchemeInfo SchemeInfo = new SchemeInfo();
            IList<Scheme> SchemeDetails = SchemeInfo.GetAll();
            if (SchemeDetails != null && SchemeDetails.Count > 0)
            {
                dtScheme = ListtoDataTable.ToDataTable(SchemeDetails.ToList());
                gridControlScheme.DataSource = dtScheme;
                //setgridViewDisplay();
            }
        }

        private void setgridViewDisplay()
        {
            gridViewScheme.Columns["ID"].Visible = false;
            gridViewScheme.Columns["CreatedOn"].Visible = false;
            gridViewScheme.Columns["CreatedBy"].Visible = false;
            gridViewScheme.Columns["UpdatedOn"].Visible = false;
            gridViewScheme.Columns["UpdatedBy"].Visible = false;
            gridViewScheme.Columns["UpdatedByUserName"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grpSchemeDetails.Enabled = true;
            txtName.Tag = "0";
            txtName.Text = string.Empty;
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = string.IsNullOrEmpty(txtName.Text);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Please enter Scheme Name.",
                    "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            Scheme Scheme = getScheme();
            bool isSaved = false;

            if (Scheme != null && Scheme.Id == 0)
                isSaved = new SchemeInfo().Add(Scheme);
            else
                isSaved = new SchemeInfo().Update(Scheme);

            if (isSaved)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Record save successfully.",
                   "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fillupScheme();
                grpSchemeDetails.Enabled = false;
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Unable to save record.",
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private Scheme getScheme()
        {
            Scheme Scheme = new Scheme();
            Scheme.Id = int.Parse(txtName.Tag.ToString());
            Scheme.Name = txtName.Text;
            Scheme.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            Scheme.CreatedBy = Program.CurrentUser.Id;
            Scheme.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            Scheme.UpdatedBy = Program.CurrentUser.Id;
            Scheme.UpdatedByUserName = Program.CurrentUser.UserName;
            Scheme.MachineName = Environment.MachineName;
            return Scheme;
        }

        private void gridViewScheme_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {

        }

        private void gridViewScheme_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridViewScheme.FocusedRowHandle >= 0)
            {
                txtName.Text = gridViewScheme.GetFocusedRowCellValue(gridViewScheme.Columns[0]).ToString();
                txtName.Tag = gridViewScheme.GetFocusedRowCellValue(gridViewScheme.Columns[1]).ToString();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridViewScheme.FocusedRowHandle >= 0)
            {
                grpSchemeDetails.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            grpSchemeDetails.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridViewScheme.FocusedRowHandle >= 0)
            {
                if ((DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this record?",
                  "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    Scheme Scheme = getScheme();
                    if (!new SchemeInfo().Delete(Scheme))
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Unable to delete this record.",
                            "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        fillupScheme();
                }
            }
        }
    }
}