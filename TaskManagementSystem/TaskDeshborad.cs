using DevExpress.Utils;
using DevExpress.XtraCharts;
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
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialPlannerClient.TaskManagementSystem
{
    public partial class TaskDeshborad : UserControl
    {
        List<FinancialPlanner.Common.Model.TaskManagement.TaskCard> taskCards =
            new List<FinancialPlanner.Common.Model.TaskManagement.TaskCard>();

        DataTable dtProject = new DataTable();
        DataTable dtTasks = new DataTable();
              

        public TaskDeshborad()
        {
            InitializeComponent();           
        }

        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }

        //private void displayResultONScreen()
        //{
        //    dtTasks = FinancialPlanner.Common.DataConversion.ListtoDataTable.ToDataTable(taskCards);

        //    delegeteProjectWiseData projectWiseData = 
        //        new delegeteProjectWiseData(fillProjectWiseGrid);
        //    this.BeginInvoke(projectWiseData);

        //    delegateChartWiseData chartWiseData =  new delegateChartWiseData(fillChartStatusWise);
        //    this.BeginInvoke(chartWiseData);

        //    delegateMyOverDueData myOverDueData = new delegateMyOverDueData(fillMyOverDueGrid);
        //    BeginInvoke(myOverDueData);

        //    delegateMyWorkStatus myWorkStatusData = new delegateMyWorkStatus(fillMyWorkStatusChart);
        //    BeginInvoke(myWorkStatusData);

        //}

        /*private void fillMyWorkStatusChart()
        {
            
        }

        private void fillMyOverDueGrid()
        {
            DataRow[] dataRows = dtTasks.Select("AssignTo ='" + Program.CurrentUser.UserName + "' and DueDate >'" + DateTime.Now.Date.ToShortDateString() + "'");
            if (dataRows.Count() > 0)
            {
                DataTable dtOverDue = dataRows.CopyToDataTable();
                gridControlMyOverDue.DataSource = dtOverDue;
            }
            else
                gridControlMyOverDue.DataSource = null;
            grpMyOverDueTask.Text = string.Format("My Overdue Tasks ({0})", dataRows.Count());
        }

        private void fillChartStatusWise()
        {
            var query = from row in dtTasks.AsEnumerable()
                        group row by row.Field<string>("TaskStatus") into ProjectTasks
                        where ProjectTasks.Key != "Completed" && ProjectTasks.Key != "Rejected"
                        orderby ProjectTasks.Key
                        select new
                        {
                            TaskStatus = ProjectTasks.Key,
                            TotalCount = ProjectTasks.Count()
                        };

            DataTable dtProjectTask = new DataTable();
            dtProjectTask.Columns.Add("TaskStatus", typeof(System.String));
            dtProjectTask.Columns.Add("TotalCount", typeof(System.Int16));

            foreach (var result in query)
            {
                DataRow dr = dtProjectTask.NewRow();
                dr["TaskStatus"] = result.TaskStatus;
                dr["TotalCount"] = result.TotalCount;
                dtProjectTask.Rows.Add(dr);
            }
            chartStatusWise.DataSource = dtProjectTask;

            // Create an empty Bar series and add it to the chart. 
            Series series = new Series("Series1", ViewType.Bar);
            chartStatusWise.Series.Add(series);

            // Generate a data table and bind the series to it. 
            series.DataSource = dtProjectTask;

            // Specify data members to bind the series. 
            series.ArgumentScaleType = ScaleType.Qualitative;
            series.ArgumentDataMember = "TaskStatus";
            series.ValueScaleType = ScaleType.Numerical;
            series.ValueDataMembers.AddRange(new string[] { "TotalCount" });
           
            // Set some properties to get a nice-looking chart. 
            ((SideBySideBarSeriesView)series.View).ColorEach = true;
            ((XYDiagram)chartStatusWise.Diagram).AxisX.Visibility = DevExpress.Utils.DefaultBoolean.True;
            ((XYDiagram)chartStatusWise.Diagram).AxisY.Visibility = DevExpress.Utils.DefaultBoolean.True;
            chartStatusWise.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;

            // Dock the chart into its parent and add it to the current form. 
            //chartStatusWise.Dock = DockStyle.Fill;
        }

        private void fillProjectWiseGrid()
        {         
            var query = from row in dtTasks.AsEnumerable()
                        group row by row.Field<string>("ProjectId") into ProjectTasks                        
                        orderby ProjectTasks.Key           
                        select new
                        {
                            ProjectName = ProjectTasks.Key,
                            TotalCount = ProjectTasks.Count()
                        };

            DataTable dtProjectTask = new DataTable();
            dtProjectTask.Columns.Add("ProjectName", typeof(System.String));
            dtProjectTask.Columns.Add("TotalCount", typeof(System.Int16));

            foreach(var result in query)
            {
                DataRow dr = dtProjectTask.NewRow();
                dr["ProjectName"] = result.ProjectName;
                dr["TotalCount"] = result.TotalCount;
                dtProjectTask.Rows.Add(dr);
            }
            grdProjectWiseTask.DataSource = dtProjectTask;           
        }

        private void setDummyData()
        {
            setDummyTaskForFP_Project();
            setDummyTaskForPF_Project();
            setDummyTaskForGN_Project();
            setDummyTaskForSession_Project();
            setDummyTaskForManagement_Project();
        }

        private void setDummyTaskForManagement_Project()
        {
            TaskCard taskCard = new TaskCard();
            taskCard.Id = "MN-0001";
            taskCard.Owner = "Admin";
            taskCard.Priority = Priority.Medium;
            taskCard.ProjectId = "MN1";
            taskCard.TaskStatus = FinancialPlanner.Common.Model.TaskManagement.TaskStatus.Backlog;
            taskCard.Title = "Remind to client that they have to submit their investment proof copy.";
            taskCard.Type = CardType.Task;
            taskCard.UpdatedDate = DateTime.Now.Date;
            taskCard.Watchers = new List<string>() { "a@a.com", "b@b.com" };
            taskCard.AssignTo = "Admin";
            taskCard.CompletedPercentage = 0;
            taskCard.CreatedDate = DateTime.Now.Date;
            taskCard.CustomerId = 1;
            taskCard.Description = "This is testing purpose";
            taskCard.DueDate = DateTime.Now.Date.AddDays(5);
            taskCards.Add(taskCard);

            TaskCard taskCard2 = new TaskCard();
            taskCard2.Id = "MN-0002";
            taskCard2.Owner = "Admin";
            taskCard2.Priority = Priority.Medium;
            taskCard2.ProjectId = "MN1";
            taskCard2.TaskStatus = FinancialPlanner.Common.Model.TaskManagement.TaskStatus.InProgress;
            taskCard2.Title = "Switch amount of Rs.50000/- from HDFC MF A/C to ICICI MF A/C.";
            taskCard2.Type = CardType.Task;
            taskCard2.UpdatedDate = DateTime.Now.Date;
            taskCard2.Watchers = new List<string>() { "a@a.com", "b@b.com" };
            taskCard2.AssignTo = "Admin";
            taskCard2.CompletedPercentage = 30;
            taskCard2.CreatedDate = DateTime.Now.Date;
            taskCard2.CustomerId = 2;
            taskCard2.Description = "This is testing purpose";
            taskCard2.DueDate = DateTime.Now.Date.AddDays(5);
            taskCards.Add(taskCard2);

            TaskCard taskCard3 = new TaskCard();
            taskCard3.Id = "MN-0003";
            taskCard3.Owner = "Admin";
            taskCard3.Priority = Priority.Medium;
            taskCard3.ProjectId = "MN1";
            taskCard3.TaskStatus = FinancialPlanner.Common.Model.TaskManagement.TaskStatus.InProgress;
            taskCard3.Title = "Prepare planner report and needs to be discuss with client.If client agree with plan details" +
                " then make an aggrement and received aggrement fees. Based on that confirmation next action will be taken.";
            taskCard3.Type = CardType.Task;
            taskCard3.UpdatedDate = DateTime.Now.Date;
            taskCard3.Watchers = new List<string>() { "a@a.com", "b@b.com" };
            taskCard3.AssignTo = "ProjectManager1";
            taskCard3.CompletedPercentage = 60;
            taskCard3.CreatedDate = DateTime.Now.Date;
            taskCard3.CustomerId = 2;
            taskCard3.Description = "This is testing purpose";
            taskCard3.DueDate = DateTime.Now.Date.AddDays(5);
            taskCards.Add(taskCard3);
        }

        private void setDummyTaskForSession_Project()
        {
            TaskCard taskCard = new TaskCard();
            taskCard.Id = "SE-0001";
            taskCard.Owner = "Admin";
            taskCard.Priority = Priority.Medium;
            taskCard.ProjectId = "SE1";
            taskCard.TaskStatus = FinancialPlanner.Common.Model.TaskManagement.TaskStatus.Backlog;
            taskCard.Title = "Get client documents";
            taskCard.Type = CardType.Task;
            taskCard.UpdatedDate = DateTime.Now.Date;
            taskCard.Watchers = new List<string>() { "a@a.com", "b@b.com" };
            taskCard.AssignTo = "Admin";
            taskCard.CompletedPercentage = 0;
            taskCard.CreatedDate = DateTime.Now.Date;
            taskCard.CustomerId = 1;
            taskCard.Description = "This is testing purpose";
            taskCard.DueDate = DateTime.Now.Date.AddDays(5);
            taskCards.Add(taskCard);

            TaskCard taskCard2 = new TaskCard();
            taskCard2.Id = "SE-0002";
            taskCard2.Owner = "Admin";
            taskCard2.Priority = Priority.Medium;
            taskCard2.ProjectId = "SE1";
            taskCard2.TaskStatus = FinancialPlanner.Common.Model.TaskManagement.TaskStatus.InProgress;
            taskCard2.Title = "Get client documents";
            taskCard2.Type = CardType.Task;
            taskCard2.UpdatedDate = DateTime.Now.Date;
            taskCard2.Watchers = new List<string>() { "a@a.com", "b@b.com" };
            taskCard2.AssignTo = "Admin";
            taskCard2.CompletedPercentage = 30;
            taskCard2.CreatedDate = DateTime.Now.Date;
            taskCard2.CustomerId = 2;
            taskCard2.Description = "This is testing purpose";
            taskCard2.DueDate = DateTime.Now.Date.AddDays(5);
            taskCards.Add(taskCard2);

            TaskCard taskCard3 = new TaskCard();
            taskCard3.Id = "SE-0003";
            taskCard3.Owner = "Admin";
            taskCard3.Priority = Priority.Medium;
            taskCard3.ProjectId = "SE1";
            taskCard3.TaskStatus = FinancialPlanner.Common.Model.TaskManagement.TaskStatus.InProgress;
            taskCard3.Title = "Get client documents";
            taskCard3.Type = CardType.Task;
            taskCard3.UpdatedDate = DateTime.Now.Date;
            taskCard3.Watchers = new List<string>() { "a@a.com", "b@b.com" };
            taskCard3.AssignTo = "ProjectManager1";
            taskCard3.CompletedPercentage = 60;
            taskCard3.CreatedDate = DateTime.Now.Date;
            taskCard3.CustomerId = 2;
            taskCard3.Description = "This is testing purpose";
            taskCard3.DueDate = DateTime.Now.Date.AddDays(5);
            taskCards.Add(taskCard3);
        }

        private void setDummyTaskForFP_Project()
        {
            TaskCard taskCard = new TaskCard();
            taskCard.Id = "FP-0001";
            taskCard.Owner = "Admin";
            taskCard.Priority = Priority.Medium;
            taskCard.ProjectId = "FP1";
            taskCard.TaskStatus = FinancialPlanner.Common.Model.TaskManagement.TaskStatus.Backlog;
            taskCard.Title = "Get client documents";
            taskCard.Type = CardType.Task;
            taskCard.UpdatedDate = DateTime.Now.Date;
            taskCard.Watchers = new List<string>() { "a@a.com", "b@b.com" };
            taskCard.AssignTo = "Admin";
            taskCard.CompletedPercentage = 0;
            taskCard.CreatedDate = DateTime.Now.Date;
            taskCard.CustomerId = 1;
            taskCard.Description = "This is testing purpose";
            taskCard.DueDate = DateTime.Now.Date.AddDays(5);
            taskCards.Add(taskCard);

            TaskCard taskCard2 = new TaskCard();
            taskCard2.Id = "FP-0002";
            taskCard2.Owner = "Admin";
            taskCard2.Priority = Priority.Medium;
            taskCard2.ProjectId = "FP1";
            taskCard2.TaskStatus = FinancialPlanner.Common.Model.TaskManagement.TaskStatus.InProgress;
            taskCard2.Title = "Get client documents";
            taskCard2.Type = CardType.Task;
            taskCard2.UpdatedDate = DateTime.Now.Date;
            taskCard2.Watchers = new List<string>() { "a@a.com", "b@b.com" };
            taskCard2.AssignTo = "Admin";
            taskCard2.CompletedPercentage = 30;
            taskCard2.CreatedDate = DateTime.Now.Date;
            taskCard2.CustomerId = 2;
            taskCard2.Description = "This is testing purpose";
            taskCard2.DueDate = DateTime.Now.Date.AddDays(5);
            taskCards.Add(taskCard2);

            TaskCard taskCard3= new TaskCard();
            taskCard3.Id = "FP-0003";
            taskCard3.Owner = "Admin";
            taskCard3.Priority = Priority.Medium;
            taskCard3.ProjectId = "FP1";
            taskCard3.TaskStatus = FinancialPlanner.Common.Model.TaskManagement.TaskStatus.InProgress;
            taskCard3.Title = "Get client documents";
            taskCard3.Type = CardType.Task;
            taskCard3.UpdatedDate = DateTime.Now.Date;
            taskCard3.Watchers = new List<string>() { "a@a.com", "b@b.com" };
            taskCard3.AssignTo = "ProjectManager1";
            taskCard3.CompletedPercentage = 60;
            taskCard3.CreatedDate = DateTime.Now.Date;
            taskCard3.CustomerId = 2;
            taskCard3.Description = "This is testing purpose";
            taskCard3.DueDate = DateTime.Now.Date.AddDays(5);
            taskCards.Add(taskCard3);

        }
        private void setDummyTaskForPF_Project()
        {
            TaskCard taskCard = new TaskCard();
            taskCard.Id = "PF-0001";
            taskCard.Owner = "Admin";
            taskCard.Priority = Priority.Medium;
            taskCard.ProjectId = "PF1";
            taskCard.TaskStatus = FinancialPlanner.Common.Model.TaskManagement.TaskStatus.Backlog;
            taskCard.Title = "Get client documents";
            taskCard.Type = CardType.Task;
            taskCard.UpdatedDate = DateTime.Now.Date;
            taskCard.Watchers = new List<string>() { "a@a.com", "b@b.com" };
            taskCard.AssignTo = "Admin";
            taskCard.CompletedPercentage = 0;
            taskCard.CreatedDate = DateTime.Now.Date;
            taskCard.CustomerId = 1;
            taskCard.Description = "This is testing purpose";
            taskCard.DueDate = DateTime.Now.Date.AddDays(5);
            taskCards.Add(taskCard);

            TaskCard taskCard2 = new TaskCard();
            taskCard2.Id = "PF-0002";
            taskCard2.Owner = "Admin";
            taskCard2.Priority = Priority.Medium;
            taskCard2.ProjectId = "PF1";
            taskCard2.TaskStatus = FinancialPlanner.Common.Model.TaskManagement.TaskStatus.InProgress;
            taskCard2.Title = "Get client documents";
            taskCard2.Type = CardType.Task;
            taskCard2.UpdatedDate = DateTime.Now.Date;
            taskCard2.Watchers = new List<string>() { "a@a.com", "b@b.com" };
            taskCard2.AssignTo = "Admin";
            taskCard2.CompletedPercentage = 30;
            taskCard2.CreatedDate = DateTime.Now.Date;
            taskCard2.CustomerId = 2;
            taskCard2.Description = "This is testing purpose";
            taskCard2.DueDate = DateTime.Now.Date.AddDays(5);
            taskCards.Add(taskCard2);

            TaskCard taskCard3 = new TaskCard();
            taskCard3.Id = "PF-0003";
            taskCard3.Owner = "Admin";
            taskCard3.Priority = Priority.Medium;
            taskCard3.ProjectId = "PF1";
            taskCard3.TaskStatus = FinancialPlanner.Common.Model.TaskManagement.TaskStatus.InProgress;
            taskCard3.Title = "Get client documents";
            taskCard3.Type = CardType.Task;
            taskCard3.UpdatedDate = DateTime.Now.Date;
            taskCard3.Watchers = new List<string>() { "a@a.com", "b@b.com" };
            taskCard3.AssignTo = "ProjectManager1";
            taskCard3.CompletedPercentage = 60;
            taskCard3.CreatedDate = DateTime.Now.Date;
            taskCard3.CustomerId = 2;
            taskCard3.Description = "This is testing purpose";
            taskCard3.DueDate = DateTime.Now.Date.AddDays(5);
            taskCards.Add(taskCard3);

        }
        private void setDummyTaskForGN_Project()
        {
            TaskCard taskCard = new TaskCard();
            taskCard.Id = "GN-0001";
            taskCard.Owner = "Admin";
            taskCard.Priority = Priority.Medium;
            taskCard.ProjectId = "GN1";
            taskCard.TaskStatus = FinancialPlanner.Common.Model.TaskManagement.TaskStatus.Backlog;
            taskCard.Title = "Get client documents";
            taskCard.Type = CardType.Task;
            taskCard.UpdatedDate = DateTime.Now.Date;
            taskCard.Watchers = new List<string>() { "a@a.com", "b@b.com" };
            taskCard.AssignTo = "Admin";
            taskCard.CompletedPercentage = 0;
            taskCard.CreatedDate = DateTime.Now.Date;
            taskCard.CustomerId = 1;
            taskCard.Description = "This is testing purpose";
            taskCard.DueDate = DateTime.Now.Date.AddDays(5);
            taskCards.Add(taskCard);

            TaskCard taskCard2 = new TaskCard();
            taskCard2.Id = "GN-0002";
            taskCard2.Owner = "Admin";
            taskCard2.Priority = Priority.Medium;
            taskCard2.ProjectId = "GN1";
            taskCard2.TaskStatus = FinancialPlanner.Common.Model.TaskManagement.TaskStatus.Blocked;
            taskCard2.Title = "Get client documents";
            taskCard2.Type = CardType.Task;
            taskCard2.UpdatedDate = DateTime.Now.Date;
            taskCard2.Watchers = new List<string>() { "a@a.com", "b@b.com" };
            taskCard2.AssignTo = "Admin";
            taskCard2.CompletedPercentage = 30;
            taskCard2.CreatedDate = DateTime.Now.Date;
            taskCard2.CustomerId = 2;
            taskCard2.Description = "This is testing purpose";
            taskCard2.DueDate = DateTime.Now.Date.AddDays(5);
            taskCards.Add(taskCard2);

            TaskCard taskCard3 = new TaskCard();
            taskCard3.Id = "GN-0003";
            taskCard3.Owner = "Admin";
            taskCard3.Priority = Priority.Medium;
            taskCard3.ProjectId = "GN1";
            taskCard3.TaskStatus = FinancialPlanner.Common.Model.TaskManagement.TaskStatus.Completed;
            taskCard3.Title = "Get client documents";
            taskCard3.Type = CardType.Task;
            taskCard3.UpdatedDate = DateTime.Now.Date;
            taskCard3.Watchers = new List<string>() { "a@a.com", "b@b.com" };
            taskCard3.AssignTo = "ProjectManager1";
            taskCard3.CompletedPercentage = 100;
            taskCard3.CreatedDate = DateTime.Now.Date;
            taskCard3.CustomerId = 2;
            taskCard3.Description = "This is testing purpose";
            taskCard3.DueDate = DateTime.Now.Date.AddDays(5);
            taskCard3.ActualCompletedDate = DateTime.Now.Date.AddDays(7);
            taskCards.Add(taskCard3);

        }*/

        private void TaskDeshborad_Load(object sender, EventArgs e)
        {
            WaitDialogForm waitdlg = new WaitDialogForm("Loading Data...");
            try
            {
                loadDashBorad();
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
            }
            finally
            {
                waitdlg.Close();
            }
        }

        private void loadDashBorad()
        {
            loadProjectsDetails();
        }

        private async void loadProjectsDetails()
        {
            TaskProjectInfo taskProjectInfo = new TaskProjectInfo();
            Task<IList<Project>> task = new Task<IList<Project>>(taskProjectInfo.GetAll);
            task.Start();

            IList<Project> projects = await (task);
            dtProject = ListtoDataTable.ToDataTable(projects.ToList());
            grdProjectWiseTask.DataSource = dtProject;
        }

        private void tileViewMyOverView_DoubleClick(object sender, EventArgs e)
        {
            if (tileViewMyOverView.FocusedRowHandle >= 0)
            {
                int rowIndex = tileViewMyOverView.FocusedRowHandle;
                string taskId = tileViewMyOverView.GetFocusedRowCellValue("Id").ToString();
                ViewTaskCard viewTaskCard = new ViewTaskCard();
                Control[] controls = this.Parent.Controls.Find(this.Name, true); // .Controls.Clear();
                if (controls.Count() > 0)
                {
                    controls[0].Controls.Clear();
                    NewTaskCard newTaskCard = new NewTaskCard();
                    viewTaskCard.TopLevel = false;
                    viewTaskCard.Visible = true;
                    viewTaskCard.Dock = DockStyle.Fill;
                    controls[0].Name = viewTaskCard.Name;
                    controls[0].Controls.Add(viewTaskCard);
                    //showNavigationPage(viewTaskCard.Name);
                }
            }
        }

        private void tileViewProjectWise_ItemClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            MessageBox.Show(e.Item.Text2);
        }
    }
}
