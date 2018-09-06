using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialPlannerClient.PlannerInfo
{
    public class PlannerAssumptionInfo
    {
        const string GET_ALL_PlannerAssumption_API = "PlannerAssumption/GetAll?plannerId={0}";
        const string UPDATE_PlannerAssumption_API = "PlannerAssumption/Update";
        DataTable _dtPlannerAssumption;

        internal PlannerAssumption GetAll(int plannerId)
        {
            PlannerAssumption PlannerAssumptionObj = new PlannerAssumption();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ string.Format(GET_ALL_PlannerAssumption_API,plannerId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<PlannerAssumption>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    PlannerAssumptionObj = jsonSerialization.DeserializeFromString<PlannerAssumption>(restResult.ToString());
                }
                return PlannerAssumptionObj;
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
                StackTrace st = new StackTrace ();
                StackFrame sf = st.GetFrame (0);
                MethodBase  currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                return null;
            }
        }

        internal bool Update(PlannerAssumption PlannerAssumption)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ UPDATE_PlannerAssumption_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<PlannerAssumption>(apiurl, PlannerAssumption, "POST");

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
