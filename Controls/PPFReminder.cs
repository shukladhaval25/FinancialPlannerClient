using FinancialPlanner.Common;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.CurrentStatus;
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
    public class PPFReminder : ICustomerReminderInfo
    {
        private readonly string PPF_MATURITY = "PPF/GetMaturity?from={0}&to={1}";

        public DataTable GetRecord(DateTime fromDate, DateTime toDate)
        {
            IList<PPFMaturity> clientDOBs = GetPPFMaturity(fromDate, toDate);
            if (clientDOBs.Count > 0)
                return ListtoDataTable.ToDataTable(clientDOBs.ToList());
            else
                return null;
        }

        private IList<PPF> GetAll(DateTime fromDate, DateTime toDate)
        {
            throw new NotImplementedException();
        }

        public IList<PPFMaturity> GetPPFMaturity(DateTime from, DateTime to)
        {
            IList<PPFMaturity> PPFObj = new List<PPFMaturity>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + string.Format(PPF_MATURITY, from.ToString("yyyy-MM-dd"), to.ToString("yyyy-MM-dd"));

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<PPFMaturity>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    PPFObj = jsonSerialization.DeserializeFromString<IList<PPFMaturity>>(restResult.ToString());
                }
                return PPFObj;
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
