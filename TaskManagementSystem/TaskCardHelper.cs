using FinancialPlanner.Common;
using FinancialPlanner.Common.Model.TaskManagement;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlannerClient.TaskManagementSystem
{
    public class TaskCardHelper
    {
        private readonly string ADD_TASK_API = "TaskController/Add";

        public bool Add(TaskCard taskCard)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + ADD_TASK_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                JSONSerialization jSON = new JSONSerialization();
                string jsonStr = jSON.SerializeToString<TaskCard>(taskCard);
                var restResult = restApiExecutor.Execute<TaskCard>(apiurl, taskCard, "POST");
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
