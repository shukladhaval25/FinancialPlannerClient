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
using System.Windows.Forms;

namespace FinancialPlannerClient.CurrentStatus
{
    public class PPFInfo
    {
        private readonly string GET_ALL = "PPF/GetAll?plannerId={0}";
        private DataTable _dtPPF;
        private readonly string ADD_PPF_API = "PPF/Add";
        private readonly string UPDATE_PPF_API = "PPF/Update";
        private readonly string DELETE_PPF_API = "PPF/Delete";
        private readonly string PPF_MATURITY = "PPF/GetMaturity?from={0}&to={1}";

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
        internal DataTable GetPPFInfo(int planeId)
        {
            IList<PPF> PPFObj = new List<PPF>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + string.Format(GET_ALL, planeId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<PPF>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    PPFObj = jsonSerialization.DeserializeFromString<IList<PPF>>(restResult.ToString());
                }
                if (PPFObj != null)
                {
                    _dtPPF = ListtoDataTable.ToDataTable(PPFObj.ToList());
                }
                return _dtPPF;
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

        internal bool Add(PPF PPF)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + ADD_PPF_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<PPF>(apiurl, PPF, "POST");
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

        internal bool Update(PPF PPF)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + UPDATE_PPF_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<PPF>(apiurl, PPF, "POST");
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

        internal bool Delete(PPF PPF)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + DELETE_PPF_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<PPF>(apiurl, PPF, "POST");
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

        internal void SetGrid(DataGridView dtGridPPF)
        {
            if (dtGridPPF.Rows.Count > 0)
            {
                dtGridPPF.Columns["ID"].Visible = false;
                dtGridPPF.Columns["PID"].Visible = false;
                dtGridPPF.Columns["InvesterName"].HeaderText = "Investor Name";
                dtGridPPF.Columns["AccountNo"].HeaderText = "Account No";
                dtGridPPF.Columns["Bank"].HeaderText = "Bank";
                dtGridPPF.Columns["GoalId"].HeaderText = "Mapped Goal";
                dtGridPPF.Columns["CreatedBy"].Visible = false;
                dtGridPPF.Columns["CreatedOn"].Visible = false;
                dtGridPPF.Columns["UpdatedBy"].Visible = false;
                dtGridPPF.Columns["UpdatedOn"].Visible = false;
                dtGridPPF.Columns["UpdatedByUserName"].Visible = false;
                dtGridPPF.Columns["MachineName"].Visible = false;
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
