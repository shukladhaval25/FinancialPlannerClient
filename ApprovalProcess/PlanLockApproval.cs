using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialPlanner.Common;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model.Approval;

namespace FinancialPlannerClient.ApprovalProcess
{
    internal class PlanLockApproval : IApproval
    {
        private readonly string ADD_TASK_APPROVAL = "Approval/Add";
        private readonly string GET_APPROVALITEM_BY_ID = "Approval/GetApprovalItemsById?itemId={0}";
        private readonly string GET_APPROVALITEM_BY_USERID_APPROVALTYPE = "Approval/GetAll?approvalType={0}&userId={1}";
        private readonly string APPROVE = "Approval/Approve";
        private readonly string REJECT = "Approval/Reject";
        private readonly string REASSIGN = "Approval/Reassign";

        public ApprovalDTO Add(ApprovalDTO approvalDTO)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + ADD_TASK_APPROVAL;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                JSONSerialization jSON = new JSONSerialization();
                string jsonStr = jSON.SerializeToString<ApprovalDTO>(approvalDTO);
                var restResult = restApiExecutor.Execute<ApprovalDTO>(apiurl, approvalDTO, "POST");
                return jSON.DeserializeFromString<ApprovalDTO>(restResult.ToString());
                //return null;
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

        public bool Approve(ApprovalDTO approvalDTO)
        {
            throw new NotImplementedException();
        }

        internal IList<ApprovalDTO> GetApprovalsItem(int itemId)
        {
            IList<ApprovalDTO> approvals = new List<ApprovalDTO>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + (string.Format(GET_APPROVALITEM_BY_ID, itemId));

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<ApprovalDTO>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    approvals = jsonSerialization.DeserializeFromString<IList<ApprovalDTO>>(restResult.ToString());
                }
                return approvals;
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

        public DataTable GetApprovalItem(int userId)
        {
            return GetApprovalItem(userId, ApprovalType.All);
        }

        public DataTable GetApprovalItem(int userId, ApprovalType approvalType)
        {
            IList<ApprovalDTO> approvals = new List<ApprovalDTO>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + (string.Format(GET_APPROVALITEM_BY_USERID_APPROVALTYPE, approvalType, userId));

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<ApprovalDTO>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    approvals = jsonSerialization.DeserializeFromString<IList<ApprovalDTO>>(restResult.ToString());
                }
                DataTable dtApprovals = new DataTable();
                if (approvals.Count > 0)
                    dtApprovals = ListtoDataTable.ToDataTable(approvals.ToList());
                return dtApprovals;
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

        public bool Reassign(ApprovalDTO approvalDTO)
        {
            throw new NotImplementedException();
        }

        public bool Reject(ApprovalDTO approvalDTO)
        {
            throw new NotImplementedException();
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
