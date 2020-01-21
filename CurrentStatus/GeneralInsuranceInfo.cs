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
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialPlannerClient.CurrentStatus
{
    internal class GeneralInsuranceInfo
    {
        const string GET_ALL_LIFEINSURANCE_API = "GeneralInsurance/GetAll?plannerId={0}";
        const string GET_ALL_BY_ID_API = "Expenses/GetById?id={0}&plannerId={1}";
        const string ADD_GENERALINSURANCE_API = "GeneralInsurance/Add";
        const string UPDATE_GENERALINSUANCE_API = "GeneralInsurance/Update";
        const string DELETE_GENERALINSURANCE_API = "GeneralInsurance/Delete";
        const string GET_RENEWAL_REMINDER = "PremiumReminder/GetRenewalDueDate?fromDate={0}&toDate={1}";
        DataTable dtGeneralInsurance;
        internal IList<GeneralInsurance> GetAllGeneralInsurances(int planId)
        {
            IList<GeneralInsurance> lifeInsuranceObj = new List<GeneralInsurance>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + string.Format(GET_ALL_LIFEINSURANCE_API, planId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<GeneralInsurance>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    lifeInsuranceObj = jsonSerialization.DeserializeFromString<IList<GeneralInsurance>>(restResult.ToString());
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
            IList<GeneralInsurance> lifeInsuranceObj = new List<GeneralInsurance>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ string.Format(GET_ALL_LIFEINSURANCE_API,plannerId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<GeneralInsurance>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    lifeInsuranceObj = jsonSerialization.DeserializeFromString<IList<GeneralInsurance>>(restResult.ToString());
                }
                if (lifeInsuranceObj != null)
                {
                    dtGeneralInsurance = ListtoDataTable.ToDataTable(lifeInsuranceObj.ToList());
                }
                return dtGeneralInsurance;
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
            //for (int i = 0; i <= dtGrid.Columns.Count - 1; i++)
            //{
            //    dtGrid.Columns[i].Visible = false;
            //}
            //dtGrid.Columns["Applicant"].Visible = true;
            //dtGrid.Columns["PolicyName"].Visible = true;
            //dtGrid.Columns["PolicyNo"].Visible = true;
        }

        internal bool Add(GeneralInsurance generalInsurance)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ ADD_GENERALINSURANCE_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<GeneralInsurance>(apiurl, generalInsurance, "POST");
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

        internal bool Update(GeneralInsurance generalInsurance)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ UPDATE_GENERALINSUANCE_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<GeneralInsurance>(apiurl, generalInsurance, "POST");
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

        internal bool Delete(GeneralInsurance generalInsurance)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+DELETE_GENERALINSURANCE_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<GeneralInsurance>(apiurl, generalInsurance, "POST");
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

        internal IList<GeneralInsuranceRenewalReminder> GetRenewalReminder(DateTime fromDate, DateTime toDate)
        {
            IList<GeneralInsuranceRenewalReminder> generalInsuranceRenewalReminders = new List<GeneralInsuranceRenewalReminder>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + string.Format(GET_RENEWAL_REMINDER, fromDate.ToString("yyyy-MM-dd"), toDate.ToString("yyyy-MM-dd"));

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<GeneralInsuranceRenewalReminder>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    generalInsuranceRenewalReminders = jsonSerialization.DeserializeFromString<IList<GeneralInsuranceRenewalReminder>>(restResult.ToString());
                }

                return generalInsuranceRenewalReminders.ToList();
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
    }
}
