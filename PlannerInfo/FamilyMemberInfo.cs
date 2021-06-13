﻿using DevExpress.XtraEditors.Repository;
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

        const string GET_ALL_BANKS_BY_ACCOUNTHOLDER = "FamilyMemberBank/GetAll?accountHolderId={0}";
        const string ADD_FAMILYMEMBER_BANK = "FamilyMemberBank/Add";
        const string UPDATE_FAMILYMEMBER_BANK = "FamilyMemberBank/Update";
        const string DELETE_FAMILYMEMBER_BANK = "FamilyMemberBank/Delete?id={0}";


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
            IList<FamilyMember> familyMemberObj = new List<FamilyMember>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ string.Format(GET_All_FAMAILYMEMBER_API,clientId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<FamilyMember>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    familyMemberObj = jsonSerialization.DeserializeFromString<IList<FamilyMember>>(restResult.ToString());
                }
                return familyMemberObj;
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
            ClientPersonalInfo clientPersonalInfo = new ClientPersonalInfo();
            PersonalInformation personalInfo = clientPersonalInfo.Get(clientId);
            comboboxObj.Items.Add(personalInfo.Client.Name);
            if (personalInfo.Spouse.Name != null)
                comboboxObj.Items.Add(personalInfo.Spouse.Name);
        }

        public void FillFamilyMemberInCombo(int clientId, DevExpress.XtraEditors.ComboBoxEdit comboboxObj)
        {
            var lstFamily = Get(clientId);
            comboboxObj.Properties.Items.Clear();
            foreach (FamilyMember familyMember in lstFamily)
            {
                comboboxObj.Properties.Items.Add(familyMember.Name);
            }
            ClientPersonalInfo clientPersonalInfo = new ClientPersonalInfo();
            PersonalInformation personalInfo = clientPersonalInfo.Get(clientId);
            comboboxObj.Properties.Items.Add(personalInfo.Client.Name);
            if (personalInfo.Spouse.Name != null)
                comboboxObj.Properties.Items.Add(personalInfo.Spouse.Name);
        }

        public void FillFamilyMemberInCombo(int clientId, RepositoryItemComboBox repositoryItemCombo)
        {
            var lstFamily = Get(clientId);
            repositoryItemCombo.Items.Clear();
            foreach (FamilyMember familyMember in lstFamily)
            {
                repositoryItemCombo.Items.Add(familyMember.Name);
            }
            ClientPersonalInfo clientPersonalInfo = new ClientPersonalInfo();
            PersonalInformation personalInfo = clientPersonalInfo.Get(clientId);
            repositoryItemCombo.Items.Add(personalInfo.Client.Name);
            if (personalInfo.Spouse.Name != null)
                repositoryItemCombo.Items.Add(personalInfo.Spouse.Name);
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
                    if (dr["DOB"] != DBNull.Value)
                        fm.DOB = DateTime.Parse(dr.Field<string>("DOB"));
                    fm.IsDependent = bool.Parse(dr["IsDependent"].ToString());
                    fm.ChildrenClass = dr.Field<string>("ChildrenClass");
                    fm.Description = dr.Field<string>("Description");
                    fm.Pancard = dr.Field<string>("PanCard");
                    fm.AadharCard = dr.Field<string>("AadharCard");
                    fm.Occupation = dr.Field<string>("Occupation");
                    fm.IsHuf = bool.Parse(dr["IsHuf"].ToString());
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
                    DataRow[] rows = _dtFamilymember.Select("Id = '" + selectedUserId +"'");
                    foreach (DataRow dr in rows)
                    {
                        return dr;
                    }                
            }
            return null;
        }

        #region "Family Member Bank"
        public IList<FamilyMemberBank> GetFamilyMemberBank(int accountHolderId)
        {
            IList<FamilyMemberBank> familyMemberObj = new List<FamilyMemberBank>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + string.Format(GET_ALL_BANKS_BY_ACCOUNTHOLDER, accountHolderId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<FamilyMemberBank>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    familyMemberObj = jsonSerialization.DeserializeFromString<IList<FamilyMemberBank>>(restResult.ToString());
                }
                return familyMemberObj;
            }
            catch (Exception ex)
            {
                Logger.LogDebug(ex);
                return null;
            }
        }
        public bool Add(FamilyMemberBank familyMemberBank)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + ADD_FAMILYMEMBER_BANK;

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<FamilyMemberBank>(apiurl, familyMemberBank, "POST");

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
        public bool Update(FamilyMemberBank familyMemberBank)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + UPDATE_FAMILYMEMBER_BANK;

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<FamilyMemberBank>(apiurl, familyMemberBank, "POST");
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
        internal void Delete(FamilyMemberBank familyMemberBank)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + string.Format(DELETE_FAMILYMEMBER_BANK, familyMemberBank);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<FamilyMemberBank>(apiurl, familyMemberBank, "DELETE");
                MessageBox.Show("Record deleted successfully.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                MessageBox.Show("Unable to delete record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        #endregion
    }
}
