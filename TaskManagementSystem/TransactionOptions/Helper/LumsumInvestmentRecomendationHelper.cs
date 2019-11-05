using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace FinancialPlannerClient.TaskManagementSystem.TransactionOptions.Helper
{
    internal class LumsumInvestmentRecomendationHelper
    {
        const string ADD_LUMSUMINVESTMENT_API = "LumsumInvRecController/Add";
        const string GET_ALL_API = "LumsumInvRecController/GetAll?plannerId={0}";
        const string DELETE_API = "LumsumInvRecController/Delete";

        public bool Save(LumsumInvestmentRecomendation lumsumInvestmentRecomendation)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = "";
                apiurl = Program.WebServiceUrl + "/" + ADD_LUMSUMINVESTMENT_API;
                   
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<LumsumInvestmentRecomendation>(apiurl, lumsumInvestmentRecomendation, "POST");
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }

        internal IList<LumsumInvestmentRecomendation> GetAll(int plannerId)
        {
            IList<LumsumInvestmentRecomendation> lumsumInvestmentRecomendations = new List<LumsumInvestmentRecomendation>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + string.Format(GET_ALL_API, plannerId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<LumsumInvestmentRecomendation>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    lumsumInvestmentRecomendations = jsonSerialization.DeserializeFromString<IList<LumsumInvestmentRecomendation>>(restResult.ToString());
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
        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }

        internal bool Delete(LumsumInvestmentRecomendation investmentRecomendation)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + DELETE_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<LumsumInvestmentRecomendation>(apiurl, investmentRecomendation, "POST");
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
