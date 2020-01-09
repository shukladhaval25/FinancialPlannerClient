using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlannerClient.Review
{
    public class QuarterlyReviewTemplateInfo
    {
        const string GET_All_API = "QuarterlyReviewTemplate/GetAll?clientId={0}";
        const string ADD_QUARTERLY_REVIEW_TEMPLATE_API = "QuarterlyReviewTemplate/Add";

        public IList<QuarterlyReviewTemplate> GetAll(int clientId)
        {
            IList<QuarterlyReviewTemplate> quarterlyReviewTemplates = new List<QuarterlyReviewTemplate>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + string.Format(GET_All_API,clientId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<QuarterlyReviewTemplate>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    quarterlyReviewTemplates = jsonSerialization.DeserializeFromString<IList<QuarterlyReviewTemplate>>(restResult.ToString());
                }
                return quarterlyReviewTemplates;
            }
            catch (Exception ex)
            {
                Logger.LogDebug(ex);
                return null;
            }
        }

        public bool Add(IList<QuarterlyReviewTemplate> quarterlyReviewTemplates)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + ADD_QUARTERLY_REVIEW_TEMPLATE_API;

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<QuarterlyReviewTemplate>>(apiurl, quarterlyReviewTemplates, "POST");

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
