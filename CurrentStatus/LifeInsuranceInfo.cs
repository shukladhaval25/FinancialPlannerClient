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
        const string GET_ALL_BY_ID_API = "Expenses/GetById?id={0}&plannerId={1}";
        const string ADD_Expenses_API = "Expenses/Add";
        const string UPDATE_Expenses_API = "Expenses/Update";
        const string DELETE_Expenses_API = "Expenses/Delete";

        DataTable dtLifeInsurance;
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
            dtGrid.Columns["Applicant"].Visible = true;
            dtGrid.Columns["PolicyName"].Visible = true;
            dtGrid.Columns["PolicyNo"].Visible = true;          
        }

        internal bool Add(LifeInsurance lifeInsurance)
        {
            throw new NotImplementedException();
        }

        internal bool Update(LifeInsurance lifeInsurance)
        {
            throw new NotImplementedException();
        }
    }
}
