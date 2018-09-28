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
    internal class SukanyaSamrudhiInfo
    {
        private readonly string GET_ALL = "SukanyaSamrudhi/GetAll?plannerId={0}";
        private DataTable _dtSukanyaSamrudhi;
        private readonly string ADD_SukanyaSamrudhi_API = "SukanyaSamrudhi/Add";
        private readonly string UPDATE_SukanyaSamrudhi_API = "SukanyaSamrudhi/Update";
        private readonly string DELETE_SukanyaSamrudhi_API = "SukanyaSamrudhi/Delete";

        internal DataTable GetSukanyaSamrudhiInfo(int planeId)
        {
            IList<SukanyaSamrudhi> SukanyaSamrudhiObj = new List<SukanyaSamrudhi>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ string.Format(GET_ALL,planeId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<SukanyaSamrudhi>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    SukanyaSamrudhiObj = jsonSerialization.DeserializeFromString<IList<SukanyaSamrudhi>>(restResult.ToString());
                }
                if (SukanyaSamrudhiObj != null)
                {
                    _dtSukanyaSamrudhi = ListtoDataTable.ToDataTable(SukanyaSamrudhiObj.ToList());
                }
                return _dtSukanyaSamrudhi;
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

        internal bool Add(SukanyaSamrudhi SukanyaSamrudhi)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ ADD_SukanyaSamrudhi_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<SukanyaSamrudhi>(apiurl, SukanyaSamrudhi, "POST");
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

        internal bool Update(SukanyaSamrudhi SukanyaSamrudhi)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ UPDATE_SukanyaSamrudhi_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<SukanyaSamrudhi>(apiurl, SukanyaSamrudhi, "POST");
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

        internal bool Delete(SukanyaSamrudhi SukanyaSamrudhi)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+DELETE_SukanyaSamrudhi_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<SukanyaSamrudhi>(apiurl, SukanyaSamrudhi, "POST");
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

        internal void SetGrid(DataGridView dtGridSukanyaSamrudhi)
        {
            dtGridSukanyaSamrudhi.Columns["ID"].Visible = false;
            dtGridSukanyaSamrudhi.Columns["PID"].Visible = false;
            dtGridSukanyaSamrudhi.Columns["InvesterName"].HeaderText = "Investor Name";
            dtGridSukanyaSamrudhi.Columns["AccountNo"].HeaderText = "Account No";
            dtGridSukanyaSamrudhi.Columns["Bank"].HeaderText = "Bank";
            dtGridSukanyaSamrudhi.Columns["GoalId"].HeaderText = "Mapped Goal";
            dtGridSukanyaSamrudhi.Columns["CreatedBy"].Visible = false;
            dtGridSukanyaSamrudhi.Columns["CreatedOn"].Visible = false;
            dtGridSukanyaSamrudhi.Columns["UpdatedBy"].Visible = false;
            dtGridSukanyaSamrudhi.Columns["UpdatedOn"].Visible = false;
            dtGridSukanyaSamrudhi.Columns["UpdatedByUserName"].Visible = false;
            dtGridSukanyaSamrudhi.Columns["MachineName"].Visible = false;
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
