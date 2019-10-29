using FinancialPlanner.Common;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model.Masters;
using FinancialPlanner.Common.Model.TaskManagement.MFTransactions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace FinancialPlannerClient.Master.TaskMaster
{
    public partial class SchemeView : DevExpress.XtraEditors.XtraForm
    {
        DataTable dtScheme = new DataTable();
        IList<AMC> aMCs;
        IList<SchemeCategory> schemeCategories;
        public SchemeView()
        {
            InitializeComponent();
        }

        private void SchemeView_Load(object sender, EventArgs e)
        {            
            loadAMC();
            loadSchmeCategory();
            fillupScheme();
        }

        private void loadSchmeCategory()
        {
            try
            {
                SchemeCategoryInfo schemeCategoryInfo = new SchemeCategoryInfo();
                schemeCategories = schemeCategoryInfo.GetAll();
                DataTable dtSchemeCategory = convertSchemeCategoriesToDataTable(schemeCategories);

                if (schemeCategories != null)
                {
                    lookupCategory.Properties.DataSource = dtSchemeCategory;
                    lookupCategory.Properties.DisplayMember = "Name";
                    lookupCategory.Properties.ValueMember = "Id";
                    lookupCategory.Properties.NullValuePrompt = "Please select valid value.";                  
                }                   
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                DevExpress.XtraEditors.XtraMessageBox.Show("Error occured during load of AMC value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private DataTable convertSchemeCategoriesToDataTable(IList<SchemeCategory> schemeCategories)
        {
            DataTable dtCategory = new DataTable();
            dtCategory.Columns.Add("Id", Type.GetType("System.Int16"));
            dtCategory.Columns.Add("Name", Type.GetType("System.String"));
            foreach(SchemeCategory schemeCategory in schemeCategories)
            {
                DataRow dr = dtCategory.NewRow();
                dr["Id"] = schemeCategory.Id;
                dr["Name"] = schemeCategory.Name;
                dtCategory.Rows.Add(dr);
            }
            return dtCategory;
        }

        private void loadAMC()
        {
            try
            {
                AMCInfo aMCInfo = new AMCInfo();
                aMCs = aMCInfo.GetAll();
                if (aMCs != null)
                cmbAMC.Properties.Items.AddRange(aMCs.Select(i => i.Name).ToArray());
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                DevExpress.XtraEditors.XtraMessageBox.Show("Error occured during load of AMC value.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void LogDebug(string name, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = name;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }
        private void fillupScheme()
        {
            SchemeInfo SchemeInfo = new SchemeInfo();
            IList<Scheme> SchemeDetails = SchemeInfo.GetAll();
            if (SchemeDetails != null && SchemeDetails.Count > 0)
            {
                dtScheme = ListtoDataTable.ToDataTable(SchemeDetails.ToList());
                gridControlScheme.DataSource = dtScheme;
            }
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
            if (string.IsNullOrEmpty(txtName.Text) && string.IsNullOrEmpty(cmbAMC.Text))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Please enter Scheme Name and AMC.",
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
            Scheme.AmcName = cmbAMC.Text;
            Scheme.Name = txtName.Text;
            Scheme.AmcId = (string.IsNullOrEmpty(cmbAMC.Tag.ToString()) ? 0 : (int)cmbAMC.Tag);
            Scheme.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            Scheme.CreatedBy = Program.CurrentUser.Id;
            Scheme.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            Scheme.UpdatedBy = Program.CurrentUser.Id;
            Scheme.UpdatedByUserName = Program.CurrentUser.UserName;
            Scheme.MachineName = Environment.MachineName;
            Scheme.CategoryId = int.Parse(lookupCategory.EditValue.ToString());
            return Scheme;
        }

        private void gridViewScheme_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {

        }

        private void gridViewScheme_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridViewScheme.FocusedRowHandle >= 0)
            {
                cmbAMC.Tag = gridViewScheme.GetFocusedRowCellValue(gridViewScheme.Columns[2]).ToString();
                cmbAMC.Text = gridViewScheme.GetFocusedRowCellValue(gridViewScheme.Columns[3]).ToString();
                txtName.Text = gridViewScheme.GetFocusedRowCellValue(gridViewScheme.Columns[0]).ToString();
                txtName.Tag = gridViewScheme.GetFocusedRowCellValue(gridViewScheme.Columns[1]).ToString();
                int id = int.Parse(gridViewScheme.GetFocusedRowCellValue(gridViewScheme.Columns[4]).ToString());
                lookupCategory.Text = (id > 0) ? schemeCategories.First(i => i.Id == id).Name : "";
                lookupCategory.EditValue = id;
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

        private void grpSchemeDetails_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbAMC_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach(AMC amc in aMCs)
            {
                if (amc.Name == cmbAMC.Text)
                {
                    cmbAMC.Tag = amc.Id;
                    return;
                }
            }            
        }
    }
}