using FinancialPlanner.Common;
using FinancialPlanner.Common.Model.Approval;
using System;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace FinancialPlannerClient.ApprovalProcess
{
    public partial class ApprovalView : DevExpress.XtraEditors.XtraForm
    {
        DataTable dtApprovals;
        public ApprovalView()
        {
            InitializeComponent();
        }
        public ApprovalView(DataTable dataTable)
        {
            InitializeComponent();
            this.dtApprovals = dataTable;
        }

        private void ApprovalView_Load(object sender, EventArgs e)
        {
            if (dtApprovals == null)
            {
                TaskApproval taskApproval = new TaskApproval();
                dtApprovals = taskApproval.GetApprovalItem(Program.CurrentUser.Id);
            }
            grdApprovals.DataSource = dtApprovals;
            cmbApprovalType.Text = "All";
            setApprovalGridColumn();
        }

        private void setApprovalGridColumn()
        {
            gridViewApprovals.Columns["Id"].Visible = false;

            gridViewApprovals.Columns["AuthorisedUsersToApprove"].Visible = false;
            gridViewApprovals.Columns["ActionTakenBy"].Visible = false;
            gridViewApprovals.Columns["LinkedId"].Visible = false;

            gridViewApprovals.Columns["RequestRaisedBy"].Visible = false;
            gridViewApprovals.Columns["ItemId"].VisibleIndex = 0;
            gridViewApprovals.Columns["RequestedBy"].VisibleIndex = 1;
            gridViewApprovals.Columns["RequestedOn"].VisibleIndex = 2;
            gridViewApprovals.Columns["Status"].VisibleIndex = 3;
            gridViewApprovals.Columns["ActionBy"].VisibleIndex = 4;
            gridViewApprovals.Columns["ActionTakenOn"].VisibleIndex = 5;
            gridViewApprovals.Columns["Description"].VisibleIndex = 6;
            gridViewApprovals.Columns["ApprovalType"].VisibleIndex = 7;
        }

        private void cmbApprovalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cmbApprovalType.Text)
            {
                case "All":
                    grdApprovals.DataSource = dtApprovals;
                    break;
                case "Task Bypass":
                    DataRow[] dataRowsTasks = dtApprovals.Select("ApprovalType = 'TaskByPass'");
                    if (dataRowsTasks.Count() > 0)
                    {
                        DataTable taskByPasTable = dataRowsTasks.CopyToDataTable();
                        grdApprovals.DataSource = taskByPasTable;
                    }
                    else
                    {
                        DataTable taskByPasTable = new DataTable();
                        grdApprovals.DataSource = taskByPasTable;
                    }
                    break;
                case "Process Lock":
                    DataRow[] dataRows = dtApprovals.Select("ApprovalType = 'PlanLock'");
                    if (dataRows.Count() > 0)
                    {
                        DataTable processTable = dataRows.CopyToDataTable();
                        grdApprovals.DataSource = processTable;
                    }
                    else
                    {
                        DataTable processTable = new DataTable();
                        grdApprovals.DataSource = processTable;
                    }
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            approvalAction(btnApprove.Text);
        }

        private void approvalAction(string action)
        {
            try
            {
                if (gridViewApprovals.SelectedRowsCount == 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Please select proper approval item to process.", "Select Item", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                AuthrityToApproval authrityToApproval = (action.Equals("Reassign")) ? new AuthrityToApproval(true) : new AuthrityToApproval();
                authrityToApproval.ShowDialog();
                if (authrityToApproval.DialogResult == DialogResult.Cancel)
                {
                    return;
                }

                foreach (int rowIndex in gridViewApprovals.GetSelectedRows())
                {
                    int itemId;
                    int id;
                    int.TryParse(gridViewApprovals.GetRowCellValue(rowIndex, "Id").ToString(), out id);
                    int.TryParse(gridViewApprovals.GetRowCellValue(rowIndex, "LinkedId").ToString(), out itemId);

                    IApproval approvalObj = getApprovalObject(rowIndex);

                    ApprovalDTO approvalDTO = new ApprovalDTO();
                    approvalDTO.Id = id;
                    approvalDTO.ActionTakenBy = Program.CurrentUser.Id;
                    approvalDTO.ActionTakenOn = DateTime.Now.Date;
                    approvalDTO.Description = authrityToApproval.GetDescription();
                    approvalDTO.ApprovalType = (ApprovalType)Enum.Parse(typeof(ApprovalType), gridViewApprovals.GetRowCellValue(rowIndex, "ApprovalType").ToString());
                    if (action.Equals("&Approve"))
                        approvalObj.Approve(approvalDTO);
                    else if (action.Equals("&Reject"))
                        approvalObj.Reject(approvalDTO);
                    else if (action.Equals("Reassign"))
                    {
                        approvalDTO.AuthorisedUsersToApprove = authrityToApproval.GetReassignUserId();
                        approvalObj.Reassign(approvalDTO);
                    }
                }
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
            }
        }

        private ApprovalType getApprovalType(int rowIndex)
        {
            //if (gridViewApprovals.GetRowCellValue(rowIndex, "ApprovalType").ToString() == "TaskByPass")
            //{

            //}
            return ApprovalType.TaskByPass;
        }

        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }

        private IApproval getApprovalObject(int rowIndex)
        {
            if (gridViewApprovals.GetRowCellValue(rowIndex, "ApprovalType").ToString() == "TaskByPass")
            {
                return new TaskApproval();
            }
            else if (gridViewApprovals.GetRowCellValue(rowIndex, "ApprovalType").ToString() == "Reassign")
            {
                return null;
            }
            else if (gridViewApprovals.GetRowCellValue(rowIndex, "ApprovalType").ToString() == "PlanLock")
            {
                return null;
            }
            return null;
        }

        private void btnReassign_Click(object sender, EventArgs e)
        {
            approvalAction(btnReassign.Text);
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            approvalAction(btnReject.Text);
        }
    }
}
