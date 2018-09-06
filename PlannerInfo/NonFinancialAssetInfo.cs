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
    public class NonFinancialAssetInfo
    {
        const string GET_ALL_NON_FINANCIAL_ASSET_API = "NonFinancialAsset/GetAll?plannerId={0}";
        const string GET_ALL_BY_ID_API = "NonFinancialAsset/GetById?id={0},plannerId={1}";
        const string ADD_NON_FINANCIAL_API = "NonFinancialAsset/Add";
        const string UPDATE_NON_FINANCIAL_API = "NonFinancialAsset/Update";
        const string DELETE_NON_FINANCIAL_API = "NonFinancialAsset/Delete";
        DataTable _dtNonFinancialAsset;
        public IList<NonFinancialAsset> GetAlll(int plannerId)
        {
            IList<NonFinancialAsset> nonFinancialAssetObj = new List<NonFinancialAsset>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ string.Format(GET_ALL_NON_FINANCIAL_ASSET_API,plannerId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<NonFinancialAsset>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    nonFinancialAssetObj = jsonSerialization.DeserializeFromString<IList<NonFinancialAsset>>(restResult.ToString());
                }
                return nonFinancialAssetObj;
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
        public NonFinancialAsset GetById(int id, int plannerId)
        {
            NonFinancialAsset nonFinancialAssetObj = new NonFinancialAsset();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ string.Format(GET_ALL_BY_ID_API,id,plannerId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<NonFinancialAsset>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    nonFinancialAssetObj = jsonSerialization.DeserializeFromString<NonFinancialAsset>(restResult.ToString());
                }
                return nonFinancialAssetObj;
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

        internal void FillGrid(DataGridView dtGridNonFinancialAssets)
        {
            dtGridNonFinancialAssets.Columns[0].Visible = false;
            dtGridNonFinancialAssets.Columns[1].Visible = false;
            dtGridNonFinancialAssets.Columns[2].Visible = false;
            dtGridNonFinancialAssets.Columns["Name"].HeaderText = "Name";
            dtGridNonFinancialAssets.Columns[12].HeaderText = "Current Value";
            dtGridNonFinancialAssets.Columns[12].DisplayIndex = 2;
            dtGridNonFinancialAssets.Columns[4].HeaderText = "Primary Share";
            dtGridNonFinancialAssets.Columns[5].HeaderText = "Secondary Share";
            dtGridNonFinancialAssets.Columns[6].HeaderText = "Other Holder";
            dtGridNonFinancialAssets.Columns[7].HeaderText = "Other Holder Share";
            dtGridNonFinancialAssets.Columns[8].HeaderText = "Mapped Goal";
            dtGridNonFinancialAssets.Columns[9].HeaderText = "Goal Share";
            dtGridNonFinancialAssets.Columns["CreatedOn"].Visible = false;
            dtGridNonFinancialAssets.Columns["CreatedBy"].Visible = false;
            dtGridNonFinancialAssets.Columns["UpdatedOn"].Visible = false;
            dtGridNonFinancialAssets.Columns["UpdatedBy"].Visible = false;
            dtGridNonFinancialAssets.Columns["UpdatedByUserName"].Visible = false;
            dtGridNonFinancialAssets.Columns["MachineName"].Visible = false;
            //throw new NotImplementedException();
        }

        public bool Add(NonFinancialAsset nonFinancialAsset)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ ADD_NON_FINANCIAL_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<NonFinancialAsset>(apiurl, nonFinancialAsset, "POST");
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
        public bool Update(NonFinancialAsset nonFinancialAsset)
        {

            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ UPDATE_NON_FINANCIAL_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<NonFinancialAsset>(apiurl, nonFinancialAsset, "POST");

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

        public void Delete(NonFinancialAsset nonFinancialAsset)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ DELETE_NON_FINANCIAL_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<NonFinancialAsset>(apiurl, nonFinancialAsset, "POST");
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

        internal NonFinancialAsset GetNonFinancialAssetInfo(DataGridView dtGridNonFinancialAssets,DataTable dtNonFinancialAsset)
        {
            _dtNonFinancialAsset = dtNonFinancialAsset;
            return convertSelectedRowDataToNonFinancialAsset(dtGridNonFinancialAssets);
        }

        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }
        
        private NonFinancialAsset convertSelectedRowDataToNonFinancialAsset(DataGridView dtGridNonFinancialAssets)
        {
            if (dtGridNonFinancialAssets.SelectedRows.Count > 0)
            {
                NonFinancialAsset nonFinancialAsset = new NonFinancialAsset();
                DataRow dr = getSelectedDataRowForNonFinancialAsset(dtGridNonFinancialAssets);
                if (dr != null)
                {
                    nonFinancialAsset.Id = int.Parse(dr.Field<string>("ID"));
                    nonFinancialAsset.Pid = int.Parse(dr.Field<string>("PID"));
                    nonFinancialAsset.Name = dr.Field<string>("NAME");
                    nonFinancialAsset.CurrentValue = double.Parse(dr.Field<string>("CurrentValue"));
                    nonFinancialAsset.PrimaryholderShare = int.Parse(dr.Field<string>("Primaryholdershare"));
                    nonFinancialAsset.SecondaryHolderShare = int.Parse(dr.Field<string>("SecondaryHoldershare"));
                    nonFinancialAsset.OtherHolderName = dr.Field<string>("OtherHolderName");
                    nonFinancialAsset.OtherHolderShare = int.Parse(dr.Field<string>("OtherHolderShare"));
                    nonFinancialAsset.MappedGoalId = int.Parse(dr.Field<string>("MappedGoalId"));
                    nonFinancialAsset.AssetMappingShare = int.Parse(dr.Field<string>("AssetMappingShare"));
                    nonFinancialAsset.AssetRealisationYear = dr.Field<string>("AssetRealisationYear");
                    nonFinancialAsset.Description = dr.Field<string>("Description");
                    return nonFinancialAsset;
                }
            }
            return null;
        }
        private DataRow getSelectedDataRowForNonFinancialAsset(DataGridView dtGridNonFinancialAssets)
        {
            int selectedRowIndex = dtGridNonFinancialAssets.SelectedRows[0].Index;
            if (dtGridNonFinancialAssets.SelectedRows[0].Cells["ID"].Value != System.DBNull.Value)
            {
                int selectedUserId = int.Parse(dtGridNonFinancialAssets.SelectedRows[0].Cells["ID"].Value.ToString());
                DataRow[] rows = _dtNonFinancialAsset.Select("Id = " + selectedUserId);
                foreach (DataRow dr in rows)
                {
                    return dr;
                }
            }
            return null;
        }
    }
}
