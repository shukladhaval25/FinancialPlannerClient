using FinancialPlanner.Common;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model.TaskManagement;
using FinancialPlannerClient.TaskManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace FinancialPlannerClient.TaskManagementSystem
{
    public partial class NewProject : DevExpress.XtraEditors.XtraForm
    {
        DataTable _dtProject = new DataTable();
        TaskProjectInfo taskProjectInfo = new TaskProjectInfo();
        public NewProject()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grpProjectDetails.Enabled = true;
            setDefaultValue();
        }

        private void setDefaultValue()
        {
            txtProjectName.Tag = "0";
            txtProjectName.Text = string.Empty;
            txtPreFix.Text = string.Empty;
            txtDescription.Text = string.Empty;
        }

        private void NewProject_Load(object sender, EventArgs e)
        {
            fillupProjectInfo();
        }

        private void fillupProjectInfo()
        {

            IList<Project> projects = taskProjectInfo.GetAll();
            if (projects != null)
            {
                _dtProject = ListtoDataTable.ToDataTable(projects.ToList());
                gridControlProject.DataSource = _dtProject;
                setgridViewDisplay();
            }
        }

        private void setgridViewDisplay()
        {
            gridViewProject.Columns["Id"].Visible = false;

            gridViewProject.Columns[1].Caption = "Project Name";
            gridViewProject.Columns[2].Caption = "Project Initial ID";
            gridViewProject.Columns[3].Caption = "Description";

            gridViewProject.Columns["IsCustomType"].Visible = false;
            gridViewProject.Columns["CreatedOn"].Visible = false;
            gridViewProject.Columns["CreatedBy"].Visible = false;
            gridViewProject.Columns["UpdatedOn"].Visible = false;
            gridViewProject.Columns["UpdatedBy"].Visible = false;
            gridViewProject.Columns["UpdatedByUserName"].Visible = false;
            gridViewProject.Columns["MachineName"].Visible = false;
        }

        private void gridViewProject_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridViewProject.FocusedRowHandle >= 0)
            {
                Project project = getProjectByFocusedRow();
                displayProjectData(project);
            }
        }

        private void displayProjectData(Project project)
        {
            if (project != null)
            {
                txtProjectName.Tag = project.Id.ToString();
                txtProjectName.Text = project.Name;
                txtPreFix.Text = project.InitialId;
                txtDescription.Text = project.Description;
            }
        }

        private Project getProjectByFocusedRow()
        {
            int rowIndex = gridViewProject.FocusedRowHandle;
            int bankID = int.Parse(gridViewProject.GetFocusedRowCellValue("Id").ToString());
            DataRow[] drs = _dtProject.Select("ID ='" + bankID + "'");
            Project project = new Project();
            return (drs != null) ? convertToProject(drs[0]) : null;
        }

        private Project convertToProject(DataRow dr)
        {
            try
            {
                Project project = new Project();
                project.Id = int.Parse(dr.Field<string>("Id"));
                project.Name = dr.Field<string>("NAME");
                project.InitialId = dr.Field<string>("INITIALID");
                project.Description = dr.Field<string>("Description");
                project.IsCustomType = bool.Parse(dr.Field<string>("IsCustomType"));
                project.UpdatedBy = int.Parse(dr.Field<string>("UpdatedBy"));
                project.UpdatedOn = DateTime.Parse(dr.Field<string>("UpdatedOn"));
                return project;
            }
            catch (Exception)
            {
                return null;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridViewProject.FocusedRowHandle >= 0)
            {
                int rowIndex = gridViewProject.FocusedRowHandle;
                int projectId = int.Parse(gridViewProject.GetFocusedRowCellValue("Id").ToString());
                bool isCustomType = bool.Parse(gridViewProject.GetFocusedRowCellValue("IsCustomType").ToString());
                if (!isCustomType)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("You can not edit system created project.", "Edit", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                    grpProjectDetails.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridViewProject.FocusedRowHandle >= 0)
            {
                int rowIndex = gridViewProject.FocusedRowHandle;
                int projectId = int.Parse(gridViewProject.GetFocusedRowCellValue("Id").ToString());
                bool isCustomType = bool.Parse(gridViewProject.GetFocusedRowCellValue("IsCustomType").ToString());
                if (!isCustomType)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("You can not delete system created project.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else
                {
                    if (DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete selected record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        Project project = getProject();
                        if (project != null && project.Id != 0 && taskProjectInfo.Delete(project))
                            DevExpress.XtraEditors.XtraMessageBox.Show("Record delete sucessfully.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        fillupProjectInfo();
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                bool isSaved = false;
                Project project = getProject();
                if (project != null && project.Id == 0)
                    isSaved = taskProjectInfo.Add(project);
                else
                    isSaved = taskProjectInfo.Update(project);
                
                if (isSaved)
                {
                    grpProjectDetails.Enabled = false;
                    DevExpress.XtraEditors.XtraMessageBox.Show("Record saved sucessfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillupProjectInfo();
                }
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
            }
        }
        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }


        private Project getProject()
        {
            Project project = new Project();
            project.Id = int.Parse(txtProjectName.Tag.ToString());
            project.Name = txtProjectName.Text;
            project.InitialId = txtPreFix.Text;
            project.Description = txtDescription.Text;
            project.CreatedBy = Program.CurrentUser.Id;
            project.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            project.UpdatedBy = Program.CurrentUser.Id;
            project.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            project.MachineName = System.Environment.MachineName;
            return project;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            grpProjectDetails.Enabled = false;
        }
    }
}
