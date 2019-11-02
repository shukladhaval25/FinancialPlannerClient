using FinancialPlanner.Common;
using FinancialPlanner.Common.Model.Masters;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlannerClient.Master
{
    public class SchemeCategoryInfo
    {
        const string GET_All_API = "SchemeCategory/GetAll";
        const string ADD_Area_API = "SchemeCategory/Add";
        const string DELETE_Area_API = "SchemeCategory/Delete";
        const string GET_SCHEME = "SchemeCategory/Get?id={0}";

        public SchemeCategory Get(int id)
        {
            SchemeCategory schemeCategory = new SchemeCategory();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + string.Format(GET_SCHEME,id);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<SchemeCategory>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    schemeCategory = jsonSerialization.DeserializeFromString<SchemeCategory>(restResult.ToString());
                }
                return schemeCategory;
            }
            catch (Exception ex)
            {
                Logger.LogDebug(ex);
                return null;
            }
        }
        public IList<SchemeCategory> GetAll()
        {
            IList<SchemeCategory> schemeCategoryList = new List<SchemeCategory>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + string.Format(GET_All_API);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<SchemeCategory>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    schemeCategoryList = jsonSerialization.DeserializeFromString<IList<SchemeCategory>>(restResult.ToString());
                }
                return schemeCategoryList;
            }
            catch (Exception ex)
            {
                Logger.LogDebug(ex);
                return null;
            }
        }
        internal bool Delete(SchemeCategory schemeCategory)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + DELETE_Area_API;

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<SchemeCategory>(apiurl, schemeCategory, "DELETE");

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

        internal bool Add(SchemeCategory schemeCategory)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + ADD_Area_API;

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<SchemeCategory>(apiurl, schemeCategory, "POST");

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
