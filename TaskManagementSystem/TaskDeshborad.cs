using DevExpress.Utils;
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
        IList<TaskCard> overDueTasks;
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

            loadMyOverDueTaskDetails();
        }

        private  void loadMyOverDueTaskDetails()
        {
            //overDueTasks = await Task.Run(() => taskCardService.GetOverDueTask(Program.CurrentUser.Id));
            overDueTasks =taskCardService.GetOverDueTask(Program.CurrentUser.Id);
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
            //IList<KeyValuePair<string, int>> projects =
            //    await Task.Run(() => taskProjectInfo.GetOpenTaskCountProjectWise(Program.CurrentUser.Id));

            IList<KeyValuePair<string, int>> projects =
               taskProjectInfo.GetOpenTaskCountProjectWise(Program.CurrentUser.Id);

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
            MessageBox.Show(e.Item.Text2);            
        }
    }
}
