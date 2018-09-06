using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace FinancialPlannerClient.PlannerInfo
{
    public class IncomeInfo
    {
        const string GET_ALL_Income_API = "Income/GetAll?plannerId={0}";
        const string GET_ALL_BY_ID_API = "Income/GetById?id={0}&plannerId={1}";
        const string ADD_Income_API = "Income/Add";
        const string UPDATE_Income_API = "Income/Update";
        const string DELETE_Income_API = "Income/Delete";
        DataTable _dtIncome;
        internal IList<Income> GetAll(int plannerId)
        {
            IList<Income> IncomeObj = new List<Income>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ string.Format(GET_ALL_Income_API,plannerId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<Income>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    IncomeObj = jsonSerialization.DeserializeFromString<IList<Income>>(restResult.ToString());
                }
                return IncomeObj;
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

        internal Income GetById(int id, int plannerId)
        {
            Income IncomeObj = new Income();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ string.Format(GET_ALL_BY_ID_API,id,plannerId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<Income>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    IncomeObj = jsonSerialization.DeserializeFromString<Income>(restResult.ToString());
                }
                return IncomeObj;
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
        internal void FillGrid(DataGridView dtGridIncome)
        {
            dtGridIncome.Columns[0].Visible = false;
            dtGridIncome.Columns[1].Visible = false;
            dtGridIncome.Columns[2].HeaderText = "Source";
            dtGridIncome.Columns[3].HeaderText = "Income By";
            dtGridIncome.Columns[5].HeaderText = "Expected Growth (%)";
            dtGridIncome.Columns[6].HeaderText = "Start Year";
            dtGridIncome.Columns[7].HeaderText = "End Year";
            dtGridIncome.Columns[8].HeaderText = "Description";
            dtGridIncome.Columns["CreatedOn"].Visible = false;
            dtGridIncome.Columns["CreatedBy"].Visible = false;
            dtGridIncome.Columns["UpdatedOn"].Visible = false;
            dtGridIncome.Columns["UpdatedBy"].Visible = false;
            dtGridIncome.Columns["UpdatedByUserName"].Visible = false;
            dtGridIncome.Columns["MachineName"].Visible = false;
            dtGridIncome.Columns["SalaryDetail"].Visible = false;

        }
        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }
        internal bool Add(Income Income)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ ADD_Income_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<Income>(apiurl, Income, "POST");
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
        internal bool Update(Income Income)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ UPDATE_Income_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<Income>(apiurl, Income, "POST");

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
        internal bool Delete(Income Income)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ DELETE_Income_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<Income>(apiurl, Income, "POST");

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
        internal Income GetIncomeInfo(DataGridView dtGridIncome,DataTable dtIncome)
        {
            _dtIncome = dtIncome;
            return convertSelectedRowDataToIncome(dtGridIncome);
        }
        private Income convertSelectedRowDataToIncome(DataGridView dtGridIncome)
        {
            if (dtGridIncome.SelectedRows.Count >= 1)
            {
                DataRow dr = getSelectedDataRowForIncome(dtGridIncome);
                if (dr != null)
                {
                    Income income = GetById(int.Parse(dr.Field<string>("ID")),int.Parse(dr.Field<string>("PID")));
                    return income;
                }                             
            }
            return null;
        }
        private DataRow getSelectedDataRowForIncome(DataGridView dtGridIncome)
        {
            if (dtGridIncome.SelectedRows.Count >= 1)
            {
                int selectedRowIndex = dtGridIncome.SelectedRows[0].Index;
                if (dtGridIncome.SelectedRows[0].Cells["ID"].Value != System.DBNull.Value)
                {
                    int selectedUserId = int.Parse(dtGridIncome.SelectedRows[0].Cells["ID"].Value.ToString());
                    DataRow[] rows = _dtIncome.Select("Id ='" + selectedUserId +"'");
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
