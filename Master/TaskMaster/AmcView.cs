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
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model.TaskManagement.MFTransactions;

namespace FinancialPlannerClient.Master.TaskMaster
{
    
    public partial class AmcView : DevExpress.XtraEditors.XtraForm
    {
        private DataTable dtAMC = new DataTable();
        public AmcView()
        {
            InitializeComponent();
        }

        private void fillupAMC()
        {
            AMCInfo amcInfo = new AMCInfo();
            IList<AMC> AMCDetails = amcInfo.GetAll();
            if (AMCDetails != null && AMCDetails.Count > 0)
            {
                dtAMC = ListtoDataTable.ToDataTable(AMCDetails.ToList());
                gridControlAMC.DataSource = dtAMC;
                //setgridViewDisplay();
            }
        }

        private void setgridViewDisplay()
        {
            gridViewAMC.Columns["ID"].Visible = false;
            gridViewAMC.Columns["CreatedOn"].Visible = false;
            gridViewAMC.Columns["CreatedBy"].Visible = false;
            gridViewAMC.Columns["UpdatedOn"].Visible = false;
            gridViewAMC.Columns["UpdatedBy"].Visible = false;
            gridViewAMC.Columns["UpdatedByUserName"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grpAmc.Enabled = true;
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
                DevExpress.XtraEditors.XtraMessageBox.Show("Please enter AMC Name.",
                    "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            AMC AMC = getAMC();
            bool isSaved = false;

            if (AMC != null && AMC.Id == 0)
                isSaved = new AMCInfo().Add(AMC);
            else
                isSaved = new AMCInfo().Update(AMC);

            if (isSaved)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Record save successfully.",
                   "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fillupAMC();
                grpAmc.Enabled = false;
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Unable to save record.",
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private AMC getAMC()
        {
            AMC AMC = new AMC();
            AMC.Id = int.Parse(txtName.Tag.ToString());
            AMC.Name = txtName.Text;
            AMC.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            AMC.CreatedBy = Program.CurrentUser.Id;
            AMC.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            AMC.UpdatedBy = Program.CurrentUser.Id;
            AMC.UpdatedByUserName = Program.CurrentUser.UserName;
            AMC.MachineName = Environment.MachineName;
            return AMC;
        }

        private void gridViewAMC_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {

        }

        private void gridViewAMC_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridViewAMC.FocusedRowHandle >= 0)
            {
                txtName.Text = gridViewAMC.GetFocusedRowCellValue(gridViewAMC.Columns[0]).ToString();
                txtName.Tag = gridViewAMC.GetFocusedRowCellValue(gridViewAMC.Columns[1]).ToString();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridViewAMC.FocusedRowHandle >= 0)
            {
                grpAmc.Enabled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            grpAmc.Enabled = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridViewAMC.FocusedRowHandle >= 0)
            {
                if (isContainReferenceRecord(int.Parse(txtName.Tag.ToString())))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("You can not delete this record. It contains some relative record in MF Scheme.",
                           "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if ((DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this record?",
                  "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {
                    AMC AMC = getAMC();
                    if (!new AMCInfo().Delete(AMC))
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Unable to delete this record.",
                            "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        fillupAMC();
                }
            }
        }

        private bool isContainReferenceRecord(int v)
        {
            return new SchemeInfo().GetCountByAMC(v) > 0;
        }

        private void AmcView_Load(object sender, EventArgs e)
        {
            fillupAMC();
        }
    }
}