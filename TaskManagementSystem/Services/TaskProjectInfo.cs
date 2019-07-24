using FinancialPlanner.Common;
using FinancialPlanner.Common.Model.TaskManagement;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialPlannerClient.TaskManagementSystem.Services
{
    public class TaskProjectInfo
    {
        const string GET_ALL_PROJECT_API = "TaskProjectController/GetAll";
        const string GET_ALL_BY_ID_API = "TaskProjectController/Get?id={0}";
        const string ADD_PROJECT_API = "BankAccount/Add";
        const string UPDATE_BankAccount_API = "BankAccount/Update";
        const string DELETE_BankAccount_API = "BankAccount/Delete";
        DataTable _dtProjects;
        internal IList<Project> GetAll()
        {
            IList<Project> projects = new List<Project>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + (GET_ALL_PROJECT_API);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<Project>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    projects = jsonSerialization.DeserializeFromString<IList<Project>>(restResult.ToString());
                }
                return projects;
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
        /*
        internal BankAccountDetail GetById(int id, int clientId)
        {
            BankAccountDetail BankAccountObj = new BankAccountDetail();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + string.Format(GET_ALL_BY_ID_API, id, clientId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<BankAccountDetail>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    BankAccountObj = jsonSerialization.DeserializeFromString<BankAccountDetail>(restResult.ToString());
                }
                return BankAccountObj;
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

        internal void setGrid(DataGridView dtGridBankAccount)
        {
            dtGridBankAccount.Columns[0].Visible = false;
            dtGridBankAccount.Columns[1].Visible = false;
            dtGridBankAccount.Columns[2].Visible = false;

            dtGridBankAccount.Columns[3].HeaderText = "Bank Name";
            dtGridBankAccount.Columns[4].HeaderText = "Account Type";
            dtGridBankAccount.Columns[5].HeaderText = "Account No";
            dtGridBankAccount.Columns[6].HeaderText = "Branch";
            dtGridBankAccount.Columns[7].HeaderText = "ContactNo";
            dtGridBankAccount.Columns[8].Visible = false;
            dtGridBankAccount.Columns[9].Visible = false;
            dtGridBankAccount.Columns[10].HeaderText = "Minimum Require Balance";
            dtGridBankAccount.Columns["CreatedOn"].Visible = false;
            dtGridBankAccount.Columns["CreatedBy"].Visible = false;
            dtGridBankAccount.Columns["UpdatedOn"].Visible = false;
            dtGridBankAccount.Columns["UpdatedBy"].Visible = false;
            dtGridBankAccount.Columns["UpdatedByUserName"].Visible = false;
            dtGridBankAccount.Columns["MachineName"].Visible = false;
        }
        internal BankAccountDetail GetBankAccountInfo(DataGridView dtGridBankAccount, DataTable dtBankAccount)
        {
            _dtBankAccount = dtBankAccount;
            return convertSelectedRowDataToBankAccount(dtGridBankAccount);
        }
        */
        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }

        /*
        internal bool Add(BankAccountDetail BankAccount)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + ADD_BankAccount_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<BankAccountDetail>(apiurl, BankAccount, "POST");
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
        internal bool Update(BankAccountDetail BankAccount)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + UPDATE_BankAccount_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<BankAccountDetail>(apiurl, BankAccount, "POST");

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
        internal bool Delete(BankAccountDetail BankAccount)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + DELETE_BankAccount_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<BankAccountDetail>(apiurl, BankAccount, "DELETE");

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
        private BankAccountDetail convertSelectedRowDataToBankAccount(DataGridView dtGridBankAccount)
        {
            if (dtGridBankAccount.SelectedRows.Count >= 1)
            {
                BankAccountDetail BankAccount = new BankAccountDetail();
                DataRow dr = getSelectedDataRowForBankAccount(dtGridBankAccount);
                if (dr != null)
                {
                    BankAccount.Id = int.Parse(dr.Field<string>("ID"));
                    BankAccount.Cid = int.Parse(dr.Field<string>("CID"));
                    BankAccount.BankName = dr.Field<string>("BankName");
                    BankAccount.AccountNo = dr.Field<string>("AccountNo");
                    BankAccount.AccountType = dr.Field<string>("AccountType");
                    BankAccount.Address = dr.Field<string>("Address");
                    BankAccount.ContactNo = dr.Field<string>("ContactNo");
                    BankAccount.IsJoinAccount = bool.Parse(dr.Field<string>("IsJoinAccount"));
                    BankAccount.JoinHolderName = dr.Field<string>("JoinHolderName");
                    BankAccount.MinRequireBalance = Double.Parse(dr.Field<string>("MinRequireBalance"));
                    return BankAccount;
                }
            }
            return null;
        }

        private DataRow getSelectedDataRowForBankAccount(DataGridView dtGridBankAccount)
        {
            if (dtGridBankAccount.SelectedRows.Count >= 1)
            {
                int selectedRowIndex = dtGridBankAccount.SelectedRows[0].Index;
                if (dtGridBankAccount.SelectedRows[0].Cells["ID"].Value != System.DBNull.Value)
                {
                    int selectedUserId = int.Parse(dtGridBankAccount.SelectedRows[0].Cells["ID"].Value.ToString());
                    DataRow[] rows = _dtBankAccount.Select("Id ='" + selectedUserId + "'");
                    foreach (DataRow dr in rows)
                    {
                        return dr;
                    }
                }
            }
            return null;
        }*/
    }
}
