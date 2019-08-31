using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model.TaskManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialPlannerClient.TaskManagementSystem
{
    public partial class AllTask : Form
    {
        DataTable dtTaskCard = new DataTable();
        TaskCardService taskCardService = new TaskCardService();
        public AllTask()
        {
            InitializeComponent();
        }

        private void AllTask_Load(object sender, EventArgs e)
        {
            fillupTasks();
        }

        private void fillupTasks()
        {
            IList<TaskCard> tasks = taskCardService.GetAll();
            if (tasks != null)
            {
                dtTaskCard = ListtoDataTable.ToDataTable(tasks.ToList());
                grdTasks.DataSource = dtTaskCard;
                addAdditionalImageColumnToGrid();

                setgridViewColumnDisplay();
            }
        }

        private void addAdditionalImageColumnToGrid()
        {
            DevExpress.XtraGrid.Columns.GridColumn gridColumnPriority =
                new DevExpress.XtraGrid.Columns.GridColumn();
        }

        private void setgridViewColumnDisplay()
        {
            gridViewTasks.Columns["Id"].Visible = false;
            gridViewTasks.Columns["ProjectId"].Visible = false;
            gridViewTasks.Columns["Description"].Visible = false;
            gridViewTasks.Columns["ActualCompletedDate"].Visible = false;
            gridViewTasks.Columns["CreatedBy"].Visible = false;
            gridViewTasks.Columns["CreatedOn"].Visible = false;
            gridViewTasks.Columns["UpdatedBy"].Visible = false;
            gridViewTasks.Columns["MachineName"].Visible = false;
            gridViewTasks.Columns["UpdatedByUserName"].Visible = false;
            gridViewTasks.Columns["TaskTransactionType"].Visible = false;
            gridViewTasks.Columns["Watchers"].Visible = false;
            gridViewTasks.Columns["Owner"].Visible = false;
            gridViewTasks.Columns["AssignTo"].Visible = false;
            gridViewTasks.Columns["CustomerId"].Visible = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
