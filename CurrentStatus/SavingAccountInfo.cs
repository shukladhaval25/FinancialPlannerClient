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
    public class SavingAccountInfo
    {

        private readonly string GET_ALL = "SavingAccount/GetAll?plannerId={0}";
        private DataTable _dtSavingAccount;
        private readonly string ADD_SavingAccount_API = "SavingAccount/Add";
        private readonly string UPDATE_SavingAccount_API = "SavingAccount/Update";
        private readonly string DELETE_SavingAccount_API = "SavingAccount/Delete";

        internal DataTable GetSavingAccountInfo(int planeId)
        {
            IList<SavingAccount> SavingAccountObj = new List<SavingAccount>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ string.Format(GET_ALL,planeId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<SavingAccount>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    SavingAccountObj = jsonSerialization.DeserializeFromString<IList<SavingAccount>>(restResult.ToString());
                }
                if (SavingAccountObj != null)
                {
                    _dtSavingAccount = ListtoDataTable.ToDataTable(SavingAccountObj.ToList());
                }
                return _dtSavingAccount;
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

        internal IList<SavingAccount> GetSavingAccounts(int planeId)
        {
            IList<SavingAccount> SavingAccountObj = new List<SavingAccount>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + string.Format(GET_ALL, planeId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<SavingAccount>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    SavingAccountObj = jsonSerialization.DeserializeFromString<IList<SavingAccount>>(restResult.ToString());
                }
               
                return SavingAccountObj;
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


        internal bool Add(SavingAccount SavingAccount)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ ADD_SavingAccount_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<SavingAccount>(apiurl, SavingAccount, "POST");
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

        internal bool Update(SavingAccount SavingAccount)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ UPDATE_SavingAccount_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<SavingAccount>(apiurl, SavingAccount, "POST");
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

        internal bool Delete(SavingAccount SavingAccount)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+DELETE_SavingAccount_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<SavingAccount>(apiurl, SavingAccount, "POST");
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

        internal void SetGrid(DataGridView dtGridSavingAccount)
        {
            dtGridSavingAccount.Columns["ID"].Visible = false;
            dtGridSavingAccount.Columns["PID"].Visible = false;
            dtGridSavingAccount.Columns["InvesterName"].HeaderText = "Investor Name";
            dtGridSavingAccount.Columns["AccountNo"].HeaderText = "Account No";
            dtGridSavingAccount.Columns["BankName"].HeaderText = "Bank";
            dtGridSavingAccount.Columns["IntRate"].HeaderText = "ROI (%)";
            dtGridSavingAccount.Columns["GoalId"].HeaderText  = "Mapped Goal";
            dtGridSavingAccount.Columns["CreatedBy"].Visible = false;
            dtGridSavingAccount.Columns["CreatedOn"].Visible = false;
            dtGridSavingAccount.Columns["UpdatedBy"].Visible = false;
            dtGridSavingAccount.Columns["UpdatedOn"].Visible = false;
            dtGridSavingAccount.Columns["UpdatedByUserName"].Visible = false;
            dtGridSavingAccount.Columns["MachineName"].Visible = false;
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
