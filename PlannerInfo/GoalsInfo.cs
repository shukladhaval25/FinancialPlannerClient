﻿using FinancialPlanner.Common;
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
    public class GoalsInfo
    {
        const string GET_ALL_Goals_API = "Goals/GetAll?plannerId={0}";
        const string GET_ALL_BY_ID_API = "Goals/GetById?id={0}&plannerId={1}";
        const string ADD_Goals_API = "Goals/Add";
        const string UPDATE_Goals_API = "Goals/Update";
        const string DELETE_Goals_API = "Goals/Delete";
        const string GET_MAX_PRIORITY = "Goals/GetMaxPriority?plannerId={0}";
        DataTable _dtGoals;

        internal int GetMaxPriority(int plannerId)
        {
            int GoalsObj=0;
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + string.Format(GET_MAX_PRIORITY, plannerId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<Goals>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    GoalsObj = jsonSerialization.DeserializeFromString<int>(restResult.ToString());
                }
                return GoalsObj;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                return 0;
            }
        }
        internal IList<Goals> GetAll(int plannerId)
        {
            IList<Goals> GoalsObj = new List<Goals>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ string.Format(GET_ALL_Goals_API,plannerId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<Goals>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    GoalsObj = jsonSerialization.DeserializeFromString<IList<Goals>>(restResult.ToString());
                }
                return GoalsObj;
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

        internal Goals GetById(int id, int plannerId)
        {
            Goals GoalsObj = new Goals();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ string.Format(GET_ALL_BY_ID_API,id,plannerId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<Goals>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    GoalsObj = jsonSerialization.DeserializeFromString<Goals>(restResult.ToString());
                }
                return GoalsObj;
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
        internal void FillGrid(DataGridView dtGridGoals)
        {
            dtGridGoals.Columns[0].Visible = false;
            dtGridGoals.Columns[1].Visible = false;
            dtGridGoals.Columns[2].HeaderText = "Goal Category";
            dtGridGoals.Columns[3].HeaderText = "Goal Name";
            dtGridGoals.Columns["CreatedOn"].Visible = false;
            dtGridGoals.Columns["CreatedBy"].Visible = false;
            dtGridGoals.Columns["UpdatedOn"].Visible = false;
            dtGridGoals.Columns["UpdatedBy"].Visible = false;
            dtGridGoals.Columns["UpdatedByUserName"].Visible = false;
            dtGridGoals.Columns["MachineName"].Visible = false;
        }
        internal void FillGrid(DevExpress.XtraGrid.Views.Grid.GridView gridViewControl)
        {
            gridViewControl.Columns[0].Visible = false;
            gridViewControl.Columns[1].Visible = false;
            gridViewControl.Columns[2].Caption = "Goal Category";
            gridViewControl.Columns[3].Caption = "Goal Name";
            gridViewControl.Columns["CreatedOn"].Visible = false;
            gridViewControl.Columns["CreatedBy"].Visible = false;
            gridViewControl.Columns["UpdatedOn"].Visible = false;
            gridViewControl.Columns["UpdatedBy"].Visible = false;
            gridViewControl.Columns["UpdatedByUserName"].Visible = false;
            gridViewControl.Columns["MachineName"].Visible = false;
        }
        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }
        internal bool Add(Goals Goals)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ ADD_Goals_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<Goals>(apiurl, Goals, "POST");
                return true;
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Unable to save record." + ex.Message , "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StackTrace st = new StackTrace ();
                StackFrame sf = st.GetFrame (0);
                MethodBase  currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                return false;
            }
        }
        internal bool Update(Goals Goals)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ UPDATE_Goals_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<Goals>(apiurl, Goals, "POST");

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
        internal bool Delete(Goals Goals)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ DELETE_Goals_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<Goals>(apiurl, Goals, "POST");

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
        internal Goals GetGoalsInfo(DataGridView dtGridGoals, DataTable dtGoals)
        {
            _dtGoals = dtGoals;
            return convertSelectedRowDataToGoals(dtGridGoals);
        }
        internal Goals GetGoalsInfo(DevExpress.XtraGrid.Views.Grid.GridView gridViewControl,DataTable dtGoals)
        {
            _dtGoals = dtGoals;
            return convertSelectedRowDataToGoals(gridViewControl);
        }
        private Goals convertSelectedRowDataToGoals(DevExpress.XtraGrid.Views.Grid.GridView gridViewControl)
        {
            if (gridViewControl.GetFocusedDataSourceRowIndex() >= 0)
            {
                int goalId = int.Parse(gridViewControl.GetFocusedRowCellValue("Id").ToString());
                int planId = int.Parse(gridViewControl.GetFocusedRowCellValue("Pid").ToString()); 
                DataRow[] dr = _dtGoals.Select("Id ='" + goalId + "'");
                if (dr != null)
                {
                    Goals Goals = GetById(int.Parse(dr[0].Field<string>("ID")), int.Parse(dr[0].Field<string>("PID")));
                    return Goals;
                }
            }
            return null;
        }
        private Goals convertSelectedRowDataToGoals(DataGridView dtGridGoals)
        {
            if (dtGridGoals.SelectedRows.Count >= 1)
            {
                DataRow dr = getSelectedDataRowForGoals(dtGridGoals);
                if (dr != null)
                {
                    Goals Goals = GetById(int.Parse(dr.Field<string>("ID")),int.Parse(dr.Field<string>("PID")));
                    return Goals;
                }
            }
            return null;
        }
        private DataRow getSelectedDataRowForGoals(DataGridView dtGridGoals)
        {
            if (dtGridGoals.SelectedRows.Count >= 1)
            {
                int selectedRowIndex = dtGridGoals.SelectedRows[0].Index;
                if ((dtGridGoals.SelectedRows[0].Cells["ID"].Value != System.DBNull.Value) &&
                    (dtGridGoals.SelectedRows[0].Cells["ID"].Value != null))
                {
                    int selectedUserId = int.Parse(dtGridGoals.SelectedRows[0].Cells["ID"].Value.ToString());
                    DataRow[] rows = _dtGoals.Select("Id ='" + selectedUserId +"'");
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
