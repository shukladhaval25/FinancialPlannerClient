using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model.TaskManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialPlannerClient.TaskManagementSystem
{
    public partial class AllTask : Form
    {
        DataTable dtTaskCard = new DataTable();
        TaskCardService taskCardService = new TaskCardService();
        TaskView taskView;
        public AllTask(TaskView taskView)
        {
            InitializeComponent();
            this.taskView = taskView;
        }

        private void AllTask_Load(object sender, EventArgs e)
        {
            fillupTasks();
        }

        private async void fillupTasks()
        {
            IList<TaskCard> tasks = await Task.Run(() => taskCardService.GetTasks(this.taskView));
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
            //DevExpress.XtraGrid.Columns.GridColumn gridColumnPriority =
            //    new DevExpress.XtraGrid.Columns.GridColumn();
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

        private void gridViewTasks_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (gridViewTasks.FocusedRowHandle >= 0)
                {
                    int rowIndex = gridViewTasks.FocusedRowHandle;
                    int taskId = int.Parse(gridViewTasks.GetFocusedRowCellValue("Id").ToString());
                    DataRow[] drTask = dtTaskCard.Select("Id='" + taskId + "'");
                    if (drTask != null && drTask.Count() > 0)
                    {
                        TaskCard taskCard = convertToTaskCard(drTask[0]);
                        Control[] controls = this.Parent.Controls.Find(this.Name, true); // .Controls.Clear();
                        if (controls.Count() > 0)
                        {
                            ViewTaskCard viewTaskCard = new ViewTaskCard(taskCard);
                            viewTaskCard.Show();
                            //controls[0].Controls.Clear();
                            //viewTaskCard.TopLevel = false;
                            //viewTaskCard.Visible = true;
                            //viewTaskCard.Dock = DockStyle.Fill;
                            //controls[0].Name = viewTaskCard.Name;
                            //controls[0].Controls.Add(viewTaskCard);
                            ////showNavigationPage(viewTaskCard.Name);
                        }
                    }
                    //this.DialogResult = System.Windows.Forms.DialogResult.OK;
                    //this.Close();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private TaskCard convertToTaskCard(DataRow dr)
        {
            TaskCard taskCard = new TaskCard();
            taskCard.Id = int.Parse(dr.Field<string>("Id"));
            taskCard.TaskId = dr.Field<string>("TaskId");
            taskCard.ProjectId = int.Parse(dr.Field<string>("ProjectId"));
            taskCard.TransactionType = dr.Field<string>("TransactionType");
            taskCard.TaskTransactionType = dr.Field<string>("TaskTransactionType");
            //taskCard.Type = (CardType) int.Parse(dr.Field<string>("CardType"));
            taskCard.CustomerId = int.Parse(dr.Field<string>("Customerid"));
            taskCard.CustomerName = dr.Field<string>("CustomerName");
            taskCard.Title = dr.Field<string>("Title");
            taskCard.Description = dr.Field<string>("Description");
            taskCard.Priority = convertToPriorityEnum(dr.Field<string>("Priority"));
            taskCard.TaskStatus = convertToTaskStatusEnum(dr.Field<string>("TaskStatus"));
            taskCard.Owner = int.Parse(dr.Field<string>("Owner"));
            taskCard.OwnerName = dr.Field<string>("OwnerName");
            taskCard.AssignTo = !string.IsNullOrEmpty(dr.Field<string>("AssignTo")) ?
                int.Parse(dr.Field<string>("AssignTo")) : 0;
            taskCard.CreatedBy = int.Parse(dr.Field<string>("CreatedBy"));
            taskCard.CreatedOn = DateTime.Parse(dr.Field<string>("CreatedOn"));
            taskCard.UpdatedOn = DateTime.Parse(dr.Field<string>("UpdatedOn"));
            //taskCard.ActualCompletedDate = dr.Field<DateTime>("ActualCompletedDate");
            taskCard.DueDate = DateTime.Parse(dr.Field<string>("DueDate"));
            taskCard.ProjectName = dr.Field<string>("ProjectName");
            taskCard.OwnerName = dr.Field<string>("OwnerName");
            taskCard.OtherName = dr.Field<string>("OtherName");
            //taskCard.AssignToName = getAssignTo(dr.Field<int?>("AssignTo"));
            //taskCard.CustomerName = getCustomerName(taskCard.CustomerId);
            return taskCard;
        }

        private FinancialPlanner.Common.Model.TaskManagement.TaskStatus convertToTaskStatusEnum(string v)
        {
            switch (v)
            {
                case "Backlog":
                    return FinancialPlanner.Common.Model.TaskManagement.TaskStatus.Backlog;
                case "InProgress":
                    return FinancialPlanner.Common.Model.TaskManagement.TaskStatus.InProgress;
                case "Blocked":
                    return FinancialPlanner.Common.Model.TaskManagement.TaskStatus.Blocked;
                case "Complet":
                    return FinancialPlanner.Common.Model.TaskManagement.TaskStatus.Complete;
                case "Discard":
                    return FinancialPlanner.Common.Model.TaskManagement.TaskStatus.Discard;
                default:
                    return FinancialPlanner.Common.Model.TaskManagement.TaskStatus.Close;
            }
        }

        private Priority convertToPriorityEnum(string v)
        {
            switch (v)
            {
                case "Low":
                    return Priority.Low;
                case "Medium":
                    return Priority.Medium;
                case "High":
                    return Priority.High;
                default:
                    return Priority.Low;
            }
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            gridViewTasks_DoubleClick(sender, e);
        }
    }

    public enum TaskView
    {
        None,
        GetAll,
        Notified,
        MyOverDue,
        AssignToMe,
        ProjectWiseAssingToMe
    }
}
