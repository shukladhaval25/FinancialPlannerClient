using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialPlannerClient.PlannerInfo
{
    public class ExpensesInfo
    {
        const string GET_ALL_Expenses_API = "Expenses/GetAll?plannerId={0}";
        const string GET_ALL_BY_ID_API = "Expenses/GetById?id={0}&plannerId={1}";
        const string ADD_Expenses_API = "Expenses/Add";
        const string UPDATE_Expenses_API = "Expenses/Update";
        const string DELETE_Expenses_API = "Expenses/Delete";
        DataTable _dtExpenses;
        internal IList<Expenses> GetAll(int plannerId)
        {
            IList<Expenses> ExpensesObj = new List<Expenses>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ string.Format(GET_ALL_Expenses_API,plannerId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<Expenses>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    ExpensesObj = jsonSerialization.DeserializeFromString<IList<Expenses>>(restResult.ToString());
                }
                return ExpensesObj;
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

        internal Expenses GetById(int id, int plannerId)
        {
            Expenses ExpensesObj = new Expenses();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ string.Format(GET_ALL_BY_ID_API,id,plannerId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<Expenses>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    ExpensesObj = jsonSerialization.DeserializeFromString<Expenses>(restResult.ToString());
                }
                return ExpensesObj;
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
        internal void FillGrid(DataGridView dtGridExpenses)
        {
            dtGridExpenses.Columns[0].Visible = false;
            dtGridExpenses.Columns[1].Visible = false;
            dtGridExpenses.Columns[2].HeaderText = "Expense Category";
            dtGridExpenses.Columns[3].HeaderText = "Item";
            dtGridExpenses.Columns["CreatedOn"].Visible = false;
            dtGridExpenses.Columns["CreatedBy"].Visible = false;
            dtGridExpenses.Columns["UpdatedOn"].Visible = false;
            dtGridExpenses.Columns["UpdatedBy"].Visible = false;
            dtGridExpenses.Columns["UpdatedByUserName"].Visible = false;
            dtGridExpenses.Columns["MachineName"].Visible = false;
        }
        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }
        internal bool Add(Expenses Expenses)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ ADD_Expenses_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<Expenses>(apiurl, Expenses, "POST");
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
        internal bool Update(Expenses Expenses)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ UPDATE_Expenses_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<Expenses>(apiurl, Expenses, "POST");

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
        internal bool Delete(Expenses Expenses)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ DELETE_Expenses_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<Expenses>(apiurl, Expenses, "POST");

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
        internal Expenses GetExpensesInfo(DataGridView dtGridExpenses, DataTable dtExpenses)
        {
            _dtExpenses = dtExpenses;
            return convertSelectedRowDataToExpenses(dtGridExpenses);
        }
        private Expenses convertSelectedRowDataToExpenses(DataGridView dtGridExpenses)
        {
            if (dtGridExpenses.SelectedRows.Count >= 1)
            {
                DataRow dr = getSelectedDataRowForExpenses(dtGridExpenses);
                if (dr != null)
                {
                    Expenses Expenses = GetById(int.Parse(dr.Field<string>("ID")),int.Parse(dr.Field<string>("PID")));
                    return Expenses;
                }
            }
            return null;
        }
        private DataRow getSelectedDataRowForExpenses(DataGridView dtGridExpenses)
        {
            if (dtGridExpenses.SelectedRows.Count >= 1)
            {
                int selectedRowIndex = dtGridExpenses.SelectedRows[0].Index;
                if (dtGridExpenses.SelectedRows[0].Cells["ID"].Value != System.DBNull.Value)
                {
                    int selectedUserId = int.Parse(dtGridExpenses.SelectedRows[0].Cells["ID"].Value.ToString());
                    DataRow[] rows = _dtExpenses.Select("Id ='" + selectedUserId +"'");
                    foreach (DataRow dr in rows)
                    {
                        return dr;
                    }
                }
            }
            return null;
        }
    }
}
