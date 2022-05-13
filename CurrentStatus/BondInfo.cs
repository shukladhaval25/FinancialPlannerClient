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
    internal class BondInfo
    {

        private readonly string GET_ALL = "Bonds/GetAll?plannerId={0}";
        private DataTable _dtBonds;
        private readonly string ADD_Bonds_API = "Bonds/Add";
        private readonly string UPDATE_Bonds_API = "Bonds/Update";
        private readonly string DELETE_Bonds_API = "Bonds/Delete";
        private readonly string BOND_MATURITY = "Bonds/GetMaturity?from={0}&to={1}";

        internal DataTable GetBondsInfo(int planeId)
        {
            IList<Bonds> BondsObj = new List<Bonds>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ string.Format(GET_ALL,planeId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<Bonds>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    BondsObj = jsonSerialization.DeserializeFromString<IList<Bonds>>(restResult.ToString());
                }
                if (BondsObj != null)
                {
                    _dtBonds = ListtoDataTable.ToDataTable(BondsObj.ToList());
                }
                return _dtBonds;
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

        internal IList<Bonds> GetAllBonds(int planeId)
        {
            IList<Bonds> BondsObj = new List<Bonds>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + string.Format(GET_ALL, planeId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<Bonds>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    BondsObj = jsonSerialization.DeserializeFromString<IList<Bonds>>(restResult.ToString());
                }
             
                return BondsObj;
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

        internal IList<Bonds> GetMaturity(DateTime fromDate, DateTime toDate)
        {
            IList<Bonds> bonds = new List<Bonds>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + string.Format(BOND_MATURITY, fromDate, toDate);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<Bonds>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    bonds = jsonSerialization.DeserializeFromString<IList<Bonds>>(restResult.ToString());
                }

                return bonds;
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

        internal bool Add(Bonds Bonds)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ ADD_Bonds_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<Bonds>(apiurl, Bonds, "POST");
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

        internal bool Update(Bonds Bonds)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ UPDATE_Bonds_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<Bonds>(apiurl, Bonds, "POST");
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

        internal bool Delete(Bonds Bonds)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+DELETE_Bonds_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<Bonds>(apiurl, Bonds, "POST");
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

        internal void SetGrid(DataGridView dtGridBonds)
        {
            dtGridBonds.Columns["ID"].Visible = false;
            dtGridBonds.Columns["PID"].Visible = false;
            dtGridBonds.Columns["InvesterName"].HeaderText = "Investor Name";
            dtGridBonds.Columns["CompanyName"].HeaderText = "Company Name";
            dtGridBonds.Columns["MaturityDate"].HeaderText = "Maturity Date";
            dtGridBonds.Columns["CurrentValue"].HeaderText = "Current Value";
            dtGridBonds.Columns["GoalId"].Visible = false;
            dtGridBonds.Columns["NoOfBond"].HeaderText = "No. of Bond";
            dtGridBonds.Columns["CreatedBy"].Visible = false;
            dtGridBonds.Columns["CreatedOn"].Visible = false;
            dtGridBonds.Columns["UpdatedBy"].Visible = false;
            dtGridBonds.Columns["UpdatedOn"].Visible = false;
            dtGridBonds.Columns["UpdatedByUserName"].Visible = false;
            dtGridBonds.Columns["MachineName"].Visible = false;
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
