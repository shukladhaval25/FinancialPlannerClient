using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlannerClient.PlannerInfo
{
    internal class ClientCRMGroupinfo
    {
        const string ADD_CLIENTFESTIVAL_API = "ClientCRMGroup/Add";
        const string GETALL_CLIENTFESTIVAL_API = "ClientCRMGroup/GetAll?clientId={0}";

        internal IList<ClientCRMGroup> Get(int clientId)
        {
            IList<ClientCRMGroup> ClientCRMGroupObj = new List<ClientCRMGroup>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ string.Format(GETALL_CLIENTFESTIVAL_API,clientId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<ClientCRMGroup>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    ClientCRMGroupObj = jsonSerialization.DeserializeFromString<IList<ClientCRMGroup>>(restResult.ToString());
                }
                return ClientCRMGroupObj;
            }
            catch (Exception ex)
            {
                Logger.LogDebug(ex);
                return null;
            }
        }

        internal bool Save(IList<ClientCRMGroup> festivals)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ ADD_CLIENTFESTIVAL_API;

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<ClientCRMGroup>>(apiurl, festivals, "POST");

                return true;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace ();
                StackFrame sf = st.GetFrame (0);
                MethodBase  currentMethodName = sf.GetMethod();
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
