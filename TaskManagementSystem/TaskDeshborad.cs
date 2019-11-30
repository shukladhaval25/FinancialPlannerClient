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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialPlannerClient.TaskManagementSystem
{
    public partial class TaskDeshborad : UserControl
    {
        DataTable dtProject = new DataTable();
        DataTable dtOverDueTasks = new DataTable();
        DataTable dtUserPerformance = new DataTable();
        DataTable dtCompanyTaskPerformance = new DataTable();
        IList<TaskCard> overDueTasks;
        IList<UserPerformanceOnTask> userPerformanceOnTasks;
        IList<UserPerformanceOnTask> companyPerformanceOnTasks;
        TaskCardService taskCardService = new TaskCardService();


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
            loadCurrentUserOverDueTaskDetails();
            loadCurrentUserTaskPerformanceData();
            loadCompanyTaskPerformanceData();
        }

        private void loadCompanyTaskPerformanceData()
        {
            try
            {
                companyPerformanceOnTasks = taskCardService.GetCompanyTaskPerformanceYearly();

                generatPerformanceDataTable(dtCompanyTaskPerformance);
                

                if (companyPerformanceOnTasks != null)
                {
                    fillupDataIntoUserPerformanceTable(dtCompanyTaskPerformance, companyPerformanceOnTasks);
                    chartControlCompanyTaskPerformance.DataSource = dtCompanyTaskPerformance;
                    chartControlCompanyTaskPerformance.Series[0].ArgumentDataMember = "Period";
                    chartControlCompanyTaskPerformance.Series[0].ValueDataMembers.AddRange(new string[] { "CompletedTaskCount" });
                    chartControlCompanyTaskPerformance.Series[0].ValueScaleType = ScaleType.Numerical;
                    chartControlCompanyTaskPerformance.Series[0].LegendText = "Complete Task";

                    chartControlCompanyTaskPerformance.Series[1].ArgumentDataMember = "Period";
                    chartControlCompanyTaskPerformance.Series[1].ValueDataMembers.AddRange(new string[] { "OverDueTaskCount" });
                    chartControlCompanyTaskPerformance.Series[1].ValueScaleType = ScaleType.Numerical;
                    chartControlCompanyTaskPerformance.Series[1].LegendText = "Overdue Task";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private  void loadCurrentUserTaskPerformanceData()
        {
            try
            {
                userPerformanceOnTasks = taskCardService.GetUserPerformanceYearly(Program.CurrentUser.Id);

                generatPerformanceDataTable(dtUserPerformance);
                

                if (userPerformanceOnTasks != null)
                {
                    fillupDataIntoUserPerformanceTable(dtUserPerformance, userPerformanceOnTasks);

                    chartUserPerformance.DataSource = dtUserPerformance;                
                    chartUserPerformance.Series[0].ArgumentDataMember = "Period";
                    chartUserPerformance.Series[0].ValueDataMembers.AddRange(new string[] { "CompletedTaskCount" });
                    chartUserPerformance.Series[0].ValueScaleType = ScaleType.Numerical;
                    chartUserPerformance.Series[0].LegendText = "Complete Task";

                    chartUserPerformance.Series[1].ArgumentDataMember = "Period";
                    chartUserPerformance.Series[1].ValueDataMembers.AddRange(new string[] { "OverDueTaskCount" });
                    chartUserPerformance.Series[1].ValueScaleType = ScaleType.Numerical;
                    chartUserPerformance.Series[1].LegendText = "Overdue Task";

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void fillupDataIntoUserPerformanceTable(DataTable dataTable,IList<UserPerformanceOnTask> userPerformances)
        {
            foreach (UserPerformanceOnTask userPerformanceOnTask in userPerformances)
            {
                DataRow dr = dataTable.NewRow();
                dr["UserId"] = userPerformanceOnTask.UserId;
                dr["Period"] = userPerformanceOnTask.Period;
                dr["CompletedTaskCount"] = userPerformanceOnTask.CompletedTaskCount;
                dr["OverdueTaskCount"] = userPerformanceOnTask.OverDueTaskCount;
                dataTable.Rows.Add(dr);
            }
        }

        private void generatPerformanceDataTable(DataTable dataTable)
        {
            if (dataTable.Columns.Count == 0)
            {
                dataTable.Columns.Add("UserId", Type.GetType("System.Int16"));
                dataTable.Columns.Add("Period", Type.GetType("System.String"));
                dataTable.Columns.Add("CompletedTaskCount", Type.GetType("System.Int16"));
                dataTable.Columns.Add("OverdueTaskCount", Type.GetType("System.Int16"));
            }
        }

        private void loadCurrentUserOverDueTaskDetails()
        {
            //overDueTasks = await Task.Run(() => taskCardService.GetOverDueTask(Program.CurrentUser.Id));
            overDueTasks = taskCardService.GetOverDueTask(Program.CurrentUser.Id);
            if (overDueTasks != null)
            {
                dtOverDueTasks = ListtoDataTable.ToDataTable(overDueTasks.ToList());
                //Application.DoEvents();
                gridControlMyOverDue.DataSource = dtOverDueTasks;
            }

        }

        private void loadProjectsDetails()
        {
            TaskProjectInfo taskProjectInfo = new TaskProjectInfo();

            IList<KeyValuePair<string, int>> projects = taskProjectInfo.GetOpenTaskCountProjectWise(Program.CurrentUser.Id);

            if (projects != null)
            {
                dtProject = ListtoDataTable.ToDataTable(projects.ToList());
                //Application.DoEvents();
                grdProjectWiseTask.DataSource = dtProject;
            }
        }

        private void tileViewMyOverView_DoubleClick(object sender, EventArgs e)
        {
            if (tileViewMyOverView.FocusedRowHandle >= 0)
            {
                int rowIndex = tileViewMyOverView.FocusedRowHandle;
                int taskId = int.Parse( tileViewMyOverView.GetFocusedRowCellValue("Id").ToString());
                TaskCard taskCard = overDueTasks.DefaultIfEmpty<TaskCard>().First(i => i.Id == taskId);
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
                    //showNavigationPage(viewTaskCard.Name);
                }
            }
        }

        private void tileViewProjectWise_ItemClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            //MessageBox.Show(this.Parent.Parent.Parent.Name);
            //if (this.Parent.Parent.Parent.Name.Equals("TaskMainPage"))
            //{
            //    ((TaskMainPage)(this.Parent.Parent.Parent)).OpenProjectWiseUserTask();
            //}
        }
    }
}
