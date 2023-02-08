using FinancialPlanner.Common.Model.Approval;
using System.Data;

namespace FinancialPlannerClient.ApprovalProcess
{
    internal interface IApproval
    {
         bool Approve(ApprovalDTO approvalDTO);
         bool Reject(ApprovalDTO approvalDTO);
         bool Reassign(ApprovalDTO approvalDTO);
         ApprovalDTO Add(ApprovalDTO approvalDTO);
         DataTable GetApprovalItem(int userId);
         DataTable GetApprovalItem(int userId, ApprovalType approvalType);
    }
}
