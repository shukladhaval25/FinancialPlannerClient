using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model.TaskManagement;
using FinancialPlannerClient.TaskManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace FinancialPlannerClient.TaskManagementSystem
{
    public partial class NewProject : DevExpress.XtraEditors.XtraForm
    {
        DataTable _dtProject = new DataTable();
        public NewProject()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grpProjectDetails.Enabled = true;
        }

        private void NewProject_Load(object sender, EventArgs e)
        {
            fillupProjectInfo();
        }

        private void fillupProjectInfo()
        {
            TaskProjectInfo taskProjectInfo = new TaskProjectInfo();
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
                project.Id =int.Parse(dr.Field<string>("Id"));
                project.Name = dr.Field<string>("NAME");
                project.InitialId = dr.Field<string>("INITIALID");
                project.Description = dr.Field<string>("Description");
                project.IsCustomType = bool.Parse(dr.Field<string>("IsCustomType"));
                project.UpdatedBy = int.Parse(dr.Field<string>("UpdatedBy"));
                project.UpdatedOn = DateTime.Parse(dr.Field<string>("UpdatedOn"));
                return project;
            }
            catch(Exception ex)
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
                    DevExpress.XtraEditors.XtraMessageBox.Show("You can not edit system created project.", "Edit");
                    return;
                }
                
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
                    DevExpress.XtraEditors.XtraMessageBox.Show("You can not delete system created project.", "Delete");
                    return;
                }
            }
        }
    }
}
