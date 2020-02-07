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
    public class TaskReminderInfo
    {
        private readonly string GET_TASK_REMINDER = "TaskReminder/Reminders?userId={0}";
        private readonly string ADD_TASK_REMINDER = "TaskReminder/AddReminder";
        private readonly string UPDATE_TASK_REMINDER = "TaskReminder/UpdateReminder";
        private readonly string GET_TASK_REMINDER_BY_TASK_ID = "TaskReminder/TaskReminder?taskId={0}";
        public async Task<IList<TaskReminder>> GetAllAsync(int userId)
        {
            IList<TaskReminder> taskReminders = new List<TaskReminder>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + (string.Format(GET_TASK_REMINDER, userId));

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<TaskReminder>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    taskReminders = await Task.Run(() => jsonSerialization.DeserializeFromString<IList<TaskReminder>>(restResult.ToString()));
                }
                return taskReminders;
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

        internal async void Update(TaskReminder taskReminder)
        {
            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
            string apiurl = Program.WebServiceUrl + "/" + UPDATE_TASK_REMINDER;
            RestAPIExecutor restApiExecutor = new RestAPIExecutor();
            JSONSerialization jSON = new JSONSerialization();
            string jsonStr = jSON.SerializeToString<TaskReminder>(taskReminder);
            var restResult = await (Task.Run(() => restApiExecutor.Execute<TaskReminder>(apiurl, taskReminder, "POST")));
        }

        public IList<TaskReminder> GetTaskReminders(int taskId)
        {
            IList<TaskReminder> taskReminders = new List<TaskReminder>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + (string.Format(GET_TASK_REMINDER_BY_TASK_ID, taskId));

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<TaskReminder>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    taskReminders = jsonSerialization.DeserializeFromString<IList<TaskReminder>>(restResult.ToString());
                }
                return taskReminders;
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

        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }

        public bool Add(TaskReminder taskReminder)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + ADD_TASK_REMINDER;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                JSONSerialization jSON = new JSONSerialization();
                string jsonStr = jSON.SerializeToString<TaskReminder>(taskReminder);
                var restResult = restApiExecutor.Execute<TaskReminder>(apiurl, taskReminder, "POST");
                return true;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                return false;
            }
        }
    }
}
