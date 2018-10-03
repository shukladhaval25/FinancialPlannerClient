using FinancialPlanner.Common;
using FinancialPlanner.Common.DataConversion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialPlannerClient.CurrentStatus
{
    internal class MFTransInfo
    {
        private readonly string GET_ALL = "MFTransactions/GetAll?plannerId={0}";
        DataTable dtMFTrans;
        private readonly string DELETE_MFTransactions_API = "MFTRansactions/Delete";
        private readonly string UPDATE_MFTransactions_API ="MFTransactions/Update";
        private readonly string ADD_MFTransactions_API = "MFTransactions/Add";


        internal DataTable GetMFTransactionsInfo(int plannerId)
        {
            IList<MFTransactionsForm> MFTransactionsObj = new List<MFTransactionsForm>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ string.Format(GET_ALL,plannerId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<MFTransactionsForm>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    MFTransactionsObj = jsonSerialization.DeserializeFromString<IList<MFTransactionsForm>>(restResult.ToString());
                }
                if (MFTransactionsObj != null)
                {
                    if (MFTransactionsObj.Count > 0)
                        dtMFTrans = ListtoDataTable.ToDataTable(MFTransactionsObj.ToList());
                    else
                        return defaultTableStructure();
                }
                return dtMFTrans;
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

        private DataTable defaultTableStructure()
        {
            dtMFTrans = new DataTable();
            DataColumn dcId = new DataColumn("Id", typeof(System.Int16));
            dtMFTrans.Columns.Add(dcId);

            DataColumn dcMFId = new DataColumn("MFId", typeof(System.Int16));
            dtMFTrans.Columns.Add(dcMFId);

            DataColumn dcNav = new DataColumn("NAV", typeof(System.Double));
            dtMFTrans.Columns.Add(dcNav);
            DataColumn dcUnits = new DataColumn("Units", typeof(System.Int16));
            dtMFTrans.Columns.Add(dcUnits);
            DataColumn dcCurrentValue = new DataColumn("CurrentValue", typeof(System.Double));
            dtMFTrans.Columns.Add(dcCurrentValue);

            DataColumn dcBalanceUnits = new DataColumn("BalanceUnits", typeof(System.Double));
            dtMFTrans.Columns.Add(dcBalanceUnits);


            DataColumn dcTransType = new DataColumn("TransactionType", typeof(System.String));
            dtMFTrans.Columns.Add(dcTransType);
            DataColumn dcTransDate = new DataColumn("TransactionDate", typeof(System.DateTime));
            dtMFTrans.Columns.Add(dcTransDate);
            return dtMFTrans;

        }

        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }

        internal bool Add(MFTransactionsForm MFTransactions)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ ADD_MFTransactions_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<MFTransactionsForm>(apiurl, MFTransactions, "POST");
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

        internal bool Update(MFTransactionsForm MFTransactions)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ UPDATE_MFTransactions_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<MFTransactionsForm>(apiurl, MFTransactions, "POST");
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

        internal bool Delete(MFTransactionsForm MFTransactions)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+DELETE_MFTransactions_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<MFTransactionsForm>(apiurl, MFTransactions, "POST");
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

    }
}
