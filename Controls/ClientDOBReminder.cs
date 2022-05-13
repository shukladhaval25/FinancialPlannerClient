using FinancialPlanner.Common;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model.CustomNotifier;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialPlannerClient.Controls
{
    class ClientDOBReminder : ICustomerReminderInfo
    {
        const string GET__API = "CustomNotifier/Client?fromDate={0}&toDate={1}";
        public DataTable GetRecord(DateTime fromDate, DateTime toDate)
        {
            IList<ClientDOB> clientDOBs = GetAll(fromDate, toDate);
            if (clientDOBs.Count > 0)
                return ListtoDataTable.ToDataTable(clientDOBs.ToList());
            else
                return null;
        }

        private IList<ClientDOB> GetAll(DateTime fromDate,DateTime toDate)
        {
            IList<ClientDOB> clientDOBs = new List<ClientDOB>();
            try
            {

                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + string.Format(GET__API, fromDate,toDate);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<ClientDOB>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    clientDOBs = jsonSerialization.DeserializeFromString<IList<ClientDOB>>(restResult.ToString());
                }
                return clientDOBs;
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
    }
}
