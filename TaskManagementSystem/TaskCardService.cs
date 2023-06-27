using FinancialPlanner.Common;
using FinancialPlanner.Common.Model.TaskManagement;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialPlannerClient.TaskManagementSystem
{
    public class TaskCardService
    {
        private readonly string ADD_TASK_API = "TaskController/Add";
        private readonly string UPDATE_TASK_API = "TaskController/Update";
        private readonly string GET_ALL_TASK = "TaskController/GetAll";
        private readonly string GET_ALL_TAKS_INCLUDING_COMPLETED = "TaskController/GetAllTasks";
        private readonly string GET_ALL_TAKS_INCLUDING_COMPLETED_WITHCOMMENT = "TaskController/GetAllTaskWithCommets";
        private readonly string GET_NOTIFIED_TASK = "TaskController/NotifiedTasks?userId={0}";
        private readonly string GET_ASSIGNTOME_TASK = "TaskController/AssignTo?userId={0}";
        private readonly string GET_USEROVERDUE_TASK = "TaskController/GetOverDueTask?userId={0}";
        private readonly string GET_USER_PERFORMANCE_YEARLY_TASK = "TaskController/GetUserPerformanceForYear?userId={0}";
        private readonly string GET_COMPANY_PERFORMANCE_YEARLY_TASK = "TaskController/GetCompanyTaskPerformanceForYear";
        private const string GET_TASK_BYPROJECTNAME_BYUSERID = "TaskController/?projectName={0}&userId={1}";
        private const string GET_TASK_BYPROJECTNAME = "TaskController/GetAll?projectName={0}";
        private const string GET_TASK_BY_TASKID = "TaskController/GetTaskByTaskId?taskId={0}";


        public IList<TaskCard> GetTasks(TaskView taskView)
        {
            switch(taskView){
                case TaskView.GetAll:
                    return GetAllTasks();
                case TaskView.Notified:
                    return notifiedTasks();
                case TaskView.AssignToMe:
                    return getTasksByAssignToMe();
                case TaskView.MyOverDue:
                    return GetOverDueTask(Program.CurrentUser.Id);
                case TaskView.ProjectWiseAssingToMe:
                    return GetOpenTaskProjectWiseAndUserWise("Mutual Fund", Program.CurrentUser.Id);
                case TaskView.None:
                default:
                    return null;
            }
        }

        private IList<TaskCard> getTasksByAssignToMe()
        {
            IList<TaskCard> tasks = new List<TaskCard>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + (string.Format(GET_ASSIGNTOME_TASK, Program.CurrentUser.Id));

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<TaskCard>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    tasks = jsonSerialization.DeserializeFromString<IList<TaskCard>>(restResult.ToString());
                }
                return tasks;
            }
            catch (System.Net.WebException webException)
            {
                if (webException.Message.Equals("The remote server returned an error: (401) Unauthorized."))
                {
                    MessageBox.Show("You session has been expired. Please Login again.", "Session Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return null;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                return null;
            }
        }

        private IList<TaskCard> notifiedTasks()
        {
            IList<TaskCard> tasks = new List<TaskCard>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + (string.Format(GET_NOTIFIED_TASK,Program.CurrentUser.Id));

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<TaskCard>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    tasks = jsonSerialization.DeserializeFromString<IList<TaskCard>>(restResult.ToString());
                }
                return tasks;
            }
            catch (System.Net.WebException webException)
            {
                if (webException.Message.Equals("The remote server returned an error: (401) Unauthorized."))
                {
                    MessageBox.Show("You session has been expired. Please Login again.", "Session Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return null;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                return null;
            }
        }

        public IList<TaskCard> GetAll()
        {
            IList<TaskCard> tasks = new List<TaskCard>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + (GET_ALL_TASK);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<TaskCard>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    tasks = jsonSerialization.DeserializeFromString<IList<TaskCard>>(restResult.ToString());
                }
                return tasks;
            }
            catch (System.Net.WebException webException)
            {
                if (webException.Message.Equals("The remote server returned an error: (401) Unauthorized."))
                {
                    MessageBox.Show("You session has been expired. Please Login again.", "Session Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return null;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                return null;
            }
        }

        public IList<TaskCard> GetAllTasks()
        {
            IList<TaskCard> tasks = new List<TaskCard>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + (GET_ALL_TAKS_INCLUDING_COMPLETED);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<TaskCard>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    tasks = jsonSerialization.DeserializeFromString<IList<TaskCard>>(restResult.ToString());
                }
                return tasks;
            }
            catch (System.Net.WebException webException)
            {
                if (webException.Message.Equals("The remote server returned an error: (401) Unauthorized."))
                {
                    MessageBox.Show("You session has been expired. Please Login again.", "Session Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return null;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                return null;
            }
        }

        public IList<TaskCardWithComments> GetAllTasksWithComment()
        {
            IList<TaskCardWithComments> tasks = new List<TaskCardWithComments>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + (GET_ALL_TAKS_INCLUDING_COMPLETED_WITHCOMMENT);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                Logger.LogInfo("GetAll task with comment process start");
                var restResult = restApiExecutor.Execute<IList<TaskCardWithComments>>(apiurl, null, "GET");
                Logger.LogInfo("GetAll task with comment process completed");
                if (restResult == null)
                    Logger.LogInfo("Result null");
                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    tasks = jsonSerialization.DeserializeFromString<IList<TaskCardWithComments>>(restResult.ToString());
                }
                return tasks;
            }
            catch (System.Net.WebException webException)
            {
                if (webException.Message.Equals("The remote server returned an error: (401) Unauthorized."))
                {
                    MessageBox.Show("You session has been expired. Please Login again.", "Session Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return null;
            }
            catch (Exception ex)
                {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                Logger.LogInfo(ex.StackTrace);
                LogDebug(currentMethodName.Name, ex);
                return null;
            }
        }

        public IList<TaskCard> GetTaskByTaskId(string TaskId)
        {
            IList<TaskCard> tasks = new List<TaskCard>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + string.Format(GET_TASK_BY_TASKID,TaskId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<TaskCard>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    tasks = jsonSerialization.DeserializeFromString<IList<TaskCard>>(restResult.ToString());
                }
                return tasks;
            }
            catch (System.Net.WebException webException)
            {
                if (webException.Message.Equals("The remote server returned an error: (401) Unauthorized."))
                {
                    MessageBox.Show("You session has been expired. Please Login again.", "Session Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return null;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                return null;
            }
        }


        public int Add(TaskCard taskCard)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + ADD_TASK_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                JSONSerialization jSON = new JSONSerialization();
                string jsonStr = jSON.SerializeToString<TaskCard>(taskCard);
                var restResult = restApiExecutor.Execute<TaskCard>(apiurl, taskCard, "POST");
                return int.Parse(restResult.ToString());
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                return 0;
            }
        }
        public IList<TaskCard> GetOverDueTask(int userId)
        {
            IList<TaskCard> tasks = new List<TaskCard>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + (string.Format(GET_USEROVERDUE_TASK,userId));

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<TaskCard>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    tasks = jsonSerialization.DeserializeFromString<IList<TaskCard>>(restResult.ToString());
                }
                return tasks;
            }
            catch (System.Net.WebException webException)
            {
                if (webException.Message.Equals("The remote server returned an error: (401) Unauthorized."))
                {
                    MessageBox.Show("You session has been expired. Please Login again.", "Session Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return null;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                return null;
            }
        }

        public IList<UserPerformanceOnTask> GetUserPerformanceYearly(int userId)
        {
            IList<UserPerformanceOnTask> tasks = new List<UserPerformanceOnTask>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + (string.Format(GET_USER_PERFORMANCE_YEARLY_TASK, userId));

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<UserPerformanceOnTask>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    tasks = jsonSerialization.DeserializeFromString<IList<UserPerformanceOnTask>>(restResult.ToString());
                }
                return tasks;
            }
            catch (System.Net.WebException webException)
            {
                if (webException.Message.Equals("The remote server returned an error: (401) Unauthorized."))
                {
                    MessageBox.Show("You session has been expired. Please Login again.", "Session Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return null;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                return null;
            }
        }

        public IList<UserPerformanceOnTask> GetCompanyTaskPerformanceYearly()
        {
            IList<UserPerformanceOnTask> tasks = new List<UserPerformanceOnTask>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + GET_COMPANY_PERFORMANCE_YEARLY_TASK;

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<UserPerformanceOnTask>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    tasks = jsonSerialization.DeserializeFromString<IList<UserPerformanceOnTask>>(restResult.ToString());
                }
                return tasks;
            }
            catch (System.Net.WebException webException)
            {
                if (webException.Message.Equals("The remote server returned an error: (401) Unauthorized."))
                {
                    MessageBox.Show("You session has been expired. Please Login again.", "Session Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return null;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                return null;
            }
        }

        public IList<TaskCard> GetOpenTaskProjectWiseAndUserWise(string projectName,int userId)
        {
            IList<TaskCard> tasks = new List<TaskCard>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + (string.Format(GET_TASK_BYPROJECTNAME_BYUSERID,projectName, userId));

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<TaskCard>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    tasks = jsonSerialization.DeserializeFromString<IList<TaskCard>>(restResult.ToString());
                }
                return tasks;
            }
            catch (System.Net.WebException webException)
            {
                if (webException.Message.Equals("The remote server returned an error: (401) Unauthorized."))
                {
                    MessageBox.Show("You session has been expired. Please Login again.", "Session Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                return null;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                return null;
            }
        }

        internal int Update(TaskCard taskCard)
        {
            if (taskCard == null)
            {
                Logger.LogDebug("Null parameter of taskcard.");
                return 0;
            }
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + UPDATE_TASK_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                JSONSerialization jSON = new JSONSerialization();
                string jsonStr = jSON.SerializeToString<TaskCard>(taskCard);
                var restResult = restApiExecutor.Execute<TaskCard>(apiurl, taskCard, "POST");
                return int.Parse(restResult.ToString());
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                return 0;
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
    }
}
