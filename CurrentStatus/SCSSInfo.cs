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
    internal class SCSSInfo
    {
        private readonly string GET_ALL = "SCSS/GetAll?plannerId={0}";
        private DataTable _dtSCSS;
        private readonly string ADD_SCSS_API = "SCSS/Add";
        private readonly string UPDATE_SCSS_API = "SCSS/Update";
        private readonly string DELETE_SCSS_API = "SCSS/Delete";

        internal DataTable GetSCSSInfo(int planeId)
        {
            IList<SCSS> SCSSObj = new List<SCSS>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ string.Format(GET_ALL,planeId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<SCSS>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    SCSSObj = jsonSerialization.DeserializeFromString<IList<SCSS>>(restResult.ToString());
                }
                if (SCSSObj != null)
                {
                    _dtSCSS = ListtoDataTable.ToDataTable(SCSSObj.ToList());
                }
                return _dtSCSS;
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

        internal bool Add(SCSS SCSS)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ ADD_SCSS_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<SCSS>(apiurl, SCSS, "POST");
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

        internal bool Update(SCSS SCSS)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ UPDATE_SCSS_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<SCSS>(apiurl, SCSS, "POST");
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

        internal bool Delete(SCSS SCSS)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+DELETE_SCSS_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<SCSS>(apiurl, SCSS, "POST");
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

        internal void SetGrid(DataGridView dtGridSCSS)
        {
            dtGridSCSS.Columns["ID"].Visible = false;
            dtGridSCSS.Columns["PID"].Visible = false;
            dtGridSCSS.Columns["InvesterName"].HeaderText = "Investor Name";
            dtGridSCSS.Columns["AccountNo"].HeaderText = "Account No";
            dtGridSCSS.Columns["Bank"].HeaderText = "Bank";
            dtGridSCSS.Columns["GoalId"].HeaderText = "Mapped Goal";
            dtGridSCSS.Columns["CreatedBy"].Visible = false;
            dtGridSCSS.Columns["CreatedOn"].Visible = false;
            dtGridSCSS.Columns["UpdatedBy"].Visible = false;
            dtGridSCSS.Columns["UpdatedOn"].Visible = false;
            dtGridSCSS.Columns["UpdatedByUserName"].Visible = false;
            dtGridSCSS.Columns["MachineName"].Visible = false;
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
