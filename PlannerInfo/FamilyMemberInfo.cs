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
    public class FamilyMemberInfo
    {
        const string GET_All_FAMAILYMEMBER_API = "FamilyMember/GetAll?clientId={0}";
        const string GET_FAMILYMEMBER_BY_CLIENTID_AND_ID = "FamilyMember/GetById?id={0}&clientId={1}";
        const string ADD_FAMILYMEMBER_API = "FamilyMember/Add";
        const string UPDATE_FAMILYMEMBER_API = "FamilyMember/Update";
        const string DELETE_FAMILYMEMBER_API = "FamilyMember/Delete?id={0}";
        DataTable _dtFamilymember;
        public FamilyMember Get(int id,int clientId)
        {
            FamilyMember employmentObj = new FamilyMember();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ string.Format(GET_FAMILYMEMBER_BY_CLIENTID_AND_ID,id,clientId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<FamilyMember>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    employmentObj = jsonSerialization.DeserializeFromString<FamilyMember>(restResult.ToString());
                }
                return employmentObj;
            }
            catch (Exception ex)
            {
                Logger.LogDebug(ex);
                return null;
            }
        }
        public IList<FamilyMember> Get(int clientId)
        {
            IList<FamilyMember> employmentListObj = new List<FamilyMember>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ string.Format(GET_All_FAMAILYMEMBER_API,clientId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<FamilyMember>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    employmentListObj = jsonSerialization.DeserializeFromString<IList<FamilyMember>>(restResult.ToString());
                }
                return employmentListObj;
            }
            catch (Exception ex)
            {
                Logger.LogDebug(ex);
                return null;
            }
        }
        public void FillFamilyMemberInCombo(int clientId,ComboBox comboboxObj)
        {
            var lstFamily = Get(clientId);
            comboboxObj.Items.Clear();
            foreach (FamilyMember familyMember in lstFamily)
            {
                comboboxObj.Items.Add(familyMember.Name);
            }
        }
        public bool Add(FamilyMember familyMember)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ ADD_FAMILYMEMBER_API;

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<FamilyMember>(apiurl, familyMember, "POST");

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

        public bool Update(FamilyMember familyMember)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ UPDATE_FAMILYMEMBER_API;

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<FamilyMember>(apiurl, familyMember, "POST");
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

        public void setFamilyMemberGridSetting(DataGridView dtGridFamilyMember)
        {
            dtGridFamilyMember.Columns["ID"].Visible = false;
            dtGridFamilyMember.Columns["CID"].Visible = false;
            dtGridFamilyMember.Columns["CreatedOn"].Visible = false;
            dtGridFamilyMember.Columns["CreatedBy"].Visible = false;
            dtGridFamilyMember.Columns["UpdatedOn"].Visible = false;
            dtGridFamilyMember.Columns["UpdatedBy"].Visible = false;
            dtGridFamilyMember.Columns["UpdatedByUserName"].Visible = false;
            dtGridFamilyMember.Columns["MachineName"].Visible = false;

            dtGridFamilyMember.Columns["DOB"].HeaderText = "Date Of Birth";
            dtGridFamilyMember.Columns["IsDependent"].HeaderText = "Dependent";
            dtGridFamilyMember.Columns["ChildrenClass"].HeaderText = "Children Class";

            dtGridFamilyMember.Columns["Name"].Width = 250;
            dtGridFamilyMember.Columns["Relationship"].Width = 150;
            dtGridFamilyMember.Columns["DOB"].Width = 150;
            dtGridFamilyMember.Columns["ChildrenClass"].Width = 100;
            dtGridFamilyMember.Columns["Description"].Width = 200;
        }

        private void LogDebug(string methodName,Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;           
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }

        internal void Delete(FamilyMember familyMember)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ string.Format(DELETE_FAMILYMEMBER_API,familyMember);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<FamilyMember>(apiurl, familyMember, "DELETE");
                MessageBox.Show("Record deleted successfully.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace ();
                StackFrame sf = st.GetFrame (0);
                MethodBase  currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                MessageBox.Show("Unable to delete record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        internal FamilyMember GetFamilyMemberInfo(DataGridView dtGridFamilyMember, DataTable dtFamilyMember)
        {
            _dtFamilymember = dtFamilyMember;
            return convertSelectedRowDataToFamilyMember(dtGridFamilyMember);
        }

        private FamilyMember convertSelectedRowDataToFamilyMember(DataGridView dtGridFamilyMember)
        {

            if (dtGridFamilyMember.SelectedRows.Count > 0)
            {
                FamilyMember fm = new FamilyMember();
                DataRow dr = getSelectedDataRow(dtGridFamilyMember);
                if (dr != null)
                {
                    fm.Id = int.Parse(dr.Field<string>("ID"));
                    fm.Cid = int.Parse(dr.Field<string>("Cid"));
                    fm.Name = dr.Field<string>("Name");
                    fm.Relationship = dr.Field<string>("Relationship");
                    fm.DOB = DateTime.Parse(dr.Field<string>("DOB"));
                    fm.IsDependent = bool.Parse(dr["IsDependent"].ToString());
                    fm.ChildrenClass = dr.Field<string>("ChildrenClass");
                    fm.Description = dr.Field<string>("Description");
                    return fm;
                }
            }
            return null;
        }

        private DataRow getSelectedDataRow(DataGridView dtGridFamilyMember)
        {
            int selectedRowIndex = dtGridFamilyMember.SelectedRows[0].Index;
            if (dtGridFamilyMember.SelectedRows[0].Cells["ID"].Value != System.DBNull.Value)
            {
                    int selectedUserId = int.Parse(dtGridFamilyMember.SelectedRows[0].Cells["ID"].Value.ToString());
                    DataRow[] rows = _dtFamilymember.Select("Id = " + selectedUserId);
                    foreach (DataRow dr in rows)
                    {
                        return dr;
                    }                
            }
            return null;
        }
    }
}
