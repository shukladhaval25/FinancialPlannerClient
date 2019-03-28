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
    public class EPFInfo
    {
        private readonly string GET_ALL = "EPF/GetAll?plannerId={0}";
        private DataTable _dtEPF;
        private readonly string ADD_EPF_API = "EPF/Add";
        private readonly string UPDATE_EPF_API = "EPF/Update";
        private readonly string DELETE_EPF_API = "EPF/Delete";

        internal DataTable GetEPFInfo(int planeId)
        {
            IList<EPF> EPFObj = new List<EPF>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + string.Format(GET_ALL, planeId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<EPF>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    EPFObj = jsonSerialization.DeserializeFromString<IList<EPF>>(restResult.ToString());
                }
                if (EPFObj != null)
                {
                    _dtEPF = ListtoDataTable.ToDataTable(EPFObj.ToList());
                }
                return _dtEPF;
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

        internal bool Add(EPF EPF)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + ADD_EPF_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<EPF>(apiurl, EPF, "POST");
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

        internal bool Update(EPF EPF)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + UPDATE_EPF_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<EPF>(apiurl, EPF, "POST");
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

        internal bool Delete(EPF EPF)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + DELETE_EPF_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<EPF>(apiurl, EPF, "POST");
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

        internal void SetGrid(DataGridView dtGridEPF)
        {
            dtGridEPF.Columns["ID"].Visible = false;
            dtGridEPF.Columns["PID"].Visible = false;
            dtGridEPF.Columns["InvesterName"].HeaderText = "Investor Name";
            dtGridEPF.Columns["AccountNo"].HeaderText = "Account No";
            dtGridEPF.Columns["Particular"].HeaderText = "Particular";
            dtGridEPF.Columns["Amount"].HeaderText = "Amount";
            dtGridEPF.Columns["GoalId"].HeaderText = "Mapped Goal";
            dtGridEPF.Columns["CreatedBy"].Visible = false;
            dtGridEPF.Columns["CreatedOn"].Visible = false;
            dtGridEPF.Columns["UpdatedBy"].Visible = false;
            dtGridEPF.Columns["UpdatedOn"].Visible = false;
            dtGridEPF.Columns["UpdatedByUserName"].Visible = false;
            dtGridEPF.Columns["MachineName"].Visible = false;
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
