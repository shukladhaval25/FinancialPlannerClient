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
     internal class FDInfo
    {
        private readonly string GET_ALL = "FixedDeposit/GetAll?plannerId={0}";
        private DataTable _dtFixedDeposit;
        private readonly string ADD_FixedDeposit_API = "FixedDeposit/Add";
        private readonly string UPDATE_FixedDeposit_API = "FixedDeposit/Update";
        private readonly string DELETE_FixedDeposit_API = "FixedDeposit/Delete";

        internal DataTable GetFixedDepositInfo(int planeId)
        {
            IList<FixedDeposit> FixedDepositObj = new List<FixedDeposit>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ string.Format(GET_ALL,planeId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<FixedDeposit>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    FixedDepositObj = jsonSerialization.DeserializeFromString<IList<FixedDeposit>>(restResult.ToString());
                }
                if (FixedDepositObj != null)
                {
                    _dtFixedDeposit = ListtoDataTable.ToDataTable(FixedDepositObj.ToList());
                }
                return _dtFixedDeposit;
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

        internal IList<FixedDeposit> GetFixedDeposits(int planeId)
        {
            IList<FixedDeposit> FixedDepositObj = new List<FixedDeposit>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + string.Format(GET_ALL, planeId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<FixedDeposit>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    FixedDepositObj = jsonSerialization.DeserializeFromString<IList<FixedDeposit>>(restResult.ToString());
                }
               
                return FixedDepositObj;
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

        internal bool Add(FixedDeposit FixedDeposit)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ ADD_FixedDeposit_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<FixedDeposit>(apiurl, FixedDeposit, "POST");
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

        internal bool Update(FixedDeposit FixedDeposit)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ UPDATE_FixedDeposit_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<FixedDeposit>(apiurl, FixedDeposit, "POST");
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

        internal bool Delete(FixedDeposit FixedDeposit)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+DELETE_FixedDeposit_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<FixedDeposit>(apiurl, FixedDeposit, "POST");
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

        internal void SetGrid(DataGridView dtGridFixedDeposit)
        {
            dtGridFixedDeposit.Columns["ID"].Visible = false;
            dtGridFixedDeposit.Columns["PID"].Visible = false;
            dtGridFixedDeposit.Columns["InvesterName"].HeaderText = "Investor Name";
            dtGridFixedDeposit.Columns["AccountNo"].HeaderText = "Account No";
            dtGridFixedDeposit.Columns["BankName"].HeaderText = "Bank";
            dtGridFixedDeposit.Columns["IntRate"].HeaderText = "ROI (%)";
            dtGridFixedDeposit.Columns["GoalId"].HeaderText = "Mapped Goal";
            dtGridFixedDeposit.Columns["CreatedBy"].Visible = false;
            dtGridFixedDeposit.Columns["CreatedOn"].Visible = false;
            dtGridFixedDeposit.Columns["UpdatedBy"].Visible = false;
            dtGridFixedDeposit.Columns["UpdatedOn"].Visible = false;
            dtGridFixedDeposit.Columns["UpdatedByUserName"].Visible = false;
            dtGridFixedDeposit.Columns["MachineName"].Visible = false;
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
