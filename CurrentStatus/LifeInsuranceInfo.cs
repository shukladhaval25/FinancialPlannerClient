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
    internal class LifeInsuranceInfo
    {
        const string GET_ALL_LIFEINSURANCE_API = "LifeInsurance/GetAll?plannerId={0}";
        const string GET_ALL_BY_ID_API = "LifeInsurance/GetById?id={0}&plannerId={1}";
        const string ADD_LIFEINSURANCE_API = "LifeInsurance/Add";
        const string UPDATE_LIFEINSURANCE_API = "LifeInsurance/Update";
        const string DELETE_LIFEINSURANCE_API = "LifeInsurance/Delete";

        DataTable dtLifeInsurance;
        internal IList<LifeInsurance> GetAllLifeInsurance(int planId)
        {
            IList<LifeInsurance> lifeInsuranceObj = new List<LifeInsurance>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + string.Format(GET_ALL_LIFEINSURANCE_API, planId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<LifeInsurance>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    lifeInsuranceObj = jsonSerialization.DeserializeFromString<IList<LifeInsurance>>(restResult.ToString());
                }
               
                return lifeInsuranceObj.ToList();
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
        internal DataTable GetLifeInsuranceInfo(int plannerId)
        {
            IList<LifeInsurance> lifeInsuranceObj = new List<LifeInsurance>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ string.Format(GET_ALL_LIFEINSURANCE_API,plannerId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<LifeInsurance>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    lifeInsuranceObj = jsonSerialization.DeserializeFromString<IList<LifeInsurance>>(restResult.ToString());
                }
                if (lifeInsuranceObj != null)
                {
                    dtLifeInsurance = ListtoDataTable.ToDataTable(lifeInsuranceObj.ToList());
                }
                return dtLifeInsurance;
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
        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }
        internal void SetGridColumn(DataGridView dtGrid)
        {
            for (int i = 0; i <= dtGrid.Columns.Count-1;i++)
            {
                dtGrid.Columns[i].Visible = false;
            }
            if (dtGrid.ColumnCount > 0)
            {
                dtGrid.Columns["Applicant"].Visible = true;
                dtGrid.Columns["PolicyName"].Visible = true;
                dtGrid.Columns["PolicyNo"].Visible = true;
            }
        }

        internal bool Add(LifeInsurance lifeInsurance)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ ADD_LIFEINSURANCE_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<LifeInsurance>(apiurl, lifeInsurance, "POST");
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

        internal bool Update(LifeInsurance lifeInsurance)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ UPDATE_LIFEINSURANCE_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<LifeInsurance>(apiurl, lifeInsurance, "POST");
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
        internal bool Delete(LifeInsurance lifeInsurance)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ DELETE_LIFEINSURANCE_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<LifeInsurance>(apiurl, lifeInsurance, "POST");
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
