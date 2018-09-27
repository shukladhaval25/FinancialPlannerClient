using FinancialPlanner.Common;
using FinancialPlanner.Common.DataConversion;
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

namespace FinancialPlannerClient.CurrentStatus
{
    internal class RDInfo
    {
        private readonly string GET_ALL = "RecurringDeposit/GetAll?plannerId={0}";
        private DataTable _dtRecurringDeposit;
        private readonly string ADD_RecurringDeposit_API = "RecurringDeposit/Add";
        private readonly string UPDATE_RecurringDeposit_API = "RecurringDeposit/Update";
        private readonly string DELETE_RecurringDeposit_API = "RecurringDeposit/Delete";

        internal DataTable GetRecurringDepositInfo(int planeId)
        {
            IList<RecurringDeposit> RecurringDepositObj = new List<RecurringDeposit>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ string.Format(GET_ALL,planeId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<RecurringDeposit>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    RecurringDepositObj = jsonSerialization.DeserializeFromString<IList<RecurringDeposit>>(restResult.ToString());
                }
                if (RecurringDepositObj != null)
                {
                    _dtRecurringDeposit = ListtoDataTable.ToDataTable(RecurringDepositObj.ToList());
                }
                return _dtRecurringDeposit;
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

        internal bool Add(RecurringDeposit RecurringDeposit)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ ADD_RecurringDeposit_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<RecurringDeposit>(apiurl, RecurringDeposit, "POST");
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

        internal bool Update(RecurringDeposit RecurringDeposit)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ UPDATE_RecurringDeposit_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<RecurringDeposit>(apiurl, RecurringDeposit, "POST");
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

        internal bool Delete(RecurringDeposit RecurringDeposit)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+DELETE_RecurringDeposit_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<RecurringDeposit>(apiurl, RecurringDeposit, "POST");
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

        internal void SetGrid(DataGridView dtGridRecurringDeposit)
        {
            dtGridRecurringDeposit.Columns["ID"].Visible = false;
            dtGridRecurringDeposit.Columns["PID"].Visible = false;
            dtGridRecurringDeposit.Columns["InvesterName"].HeaderText = "Investor Name";
            dtGridRecurringDeposit.Columns["AccountNo"].HeaderText = "Account No";
            dtGridRecurringDeposit.Columns["BankName"].HeaderText = "Bank";
            dtGridRecurringDeposit.Columns["IntRate"].HeaderText = "ROI (%)";
            dtGridRecurringDeposit.Columns["GoalId"].HeaderText = "Mapped Goal";
            dtGridRecurringDeposit.Columns["CreatedBy"].Visible = false;
            dtGridRecurringDeposit.Columns["CreatedOn"].Visible = false;
            dtGridRecurringDeposit.Columns["UpdatedBy"].Visible = false;
            dtGridRecurringDeposit.Columns["UpdatedOn"].Visible = false;
            dtGridRecurringDeposit.Columns["UpdatedByUserName"].Visible = false;
            dtGridRecurringDeposit.Columns["MachineName"].Visible = false;
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

