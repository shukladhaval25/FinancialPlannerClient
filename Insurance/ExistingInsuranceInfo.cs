using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialPlannerClient.Insurance
{
    public class ExistingInsuranceInfo
    {
        const string GET__API = "ExistingInsurance/Get?id={0}";
        const string UPDATE_API = "ExistingInsurance/Update";

        internal ExistingInsurance GetAll(int planId)
        {
            ExistingInsurance existingInsurance = new ExistingInsurance();
            try
            {
                
                    FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                    string apiurl = Program.WebServiceUrl + "/" + string.Format(GET__API, planId);

                    RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                    var restResult = restApiExecutor.Execute<ExistingInsurance>(apiurl, null, "GET");

                    if (jsonSerialization.IsValidJson(restResult.ToString()))
                    {
                    existingInsurance = jsonSerialization.DeserializeFromString<ExistingInsurance>(restResult.ToString());
                    }
                    return existingInsurance;
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

        internal bool Update(ExistingInsurance existingInsurance)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + UPDATE_API;

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<ExistingInsurance>(apiurl, existingInsurance, "POST");

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
