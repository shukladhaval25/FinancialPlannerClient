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

namespace FinancialPlannerClient.TaskManagementSystem.TransactionOptions.Helper
{
    public class InvestmentRecommedationRatioHelper
    {
        const string ADD_INVSTMENTRECOMMENDATION_API = "InvestmentRecommendationController/AddRatio";
        const string GET_ALL_API = "InvestmentRecommendationController/Get?plannerId={0}";

        internal InvestmentRecommendationRatio Get(int plannerId)
        {
            InvestmentRecommendationRatio lumsumInvestmentRecomendations = new InvestmentRecommendationRatio();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + string.Format(GET_ALL_API, plannerId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<InvestmentRecommendationRatio>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    lumsumInvestmentRecomendations = jsonSerialization.DeserializeFromString<InvestmentRecommendationRatio>(restResult.ToString());
                }
                return lumsumInvestmentRecomendations;
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
        public bool Save(InvestmentRecommendationRatio investmentRecommendationRatio)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = "";
                apiurl = Program.WebServiceUrl + "/" + ADD_INVSTMENTRECOMMENDATION_API;

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<InvestmentRecommendationRatio>(apiurl, investmentRecommendationRatio, "POST");
                return true;
            }
            catch (Exception ex)
            {
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
