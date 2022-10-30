using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.TaskManagement;
using FinancialPlanner.Common.Planning;
using FinancialPlannerClient.ClientProcess;
using FinancialPlannerClient.Clients;
using FinancialPlannerClient.Login;
using FinancialPlannerClient.Master;
using FinancialPlannerClient.TaskManagementSystem.Services;
using FinancialPlannerClient.Users;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;
using Unity;

namespace FinancialPlannerClient.TaskManagementSystem
{
    public partial class ViewTaskCard : DevExpress.XtraEditors.XtraForm
    {
        TaskCard taskCard;
        IList<Project> projects = new List<Project>();
        IList<Client> clients;
        IList<User> users;
        private ITransactionType transactionType;
        IList<TaskComment> taskComments = new List<TaskComment>();
        IList<TaskHistory> taskHistories = new List<TaskHistory>();

        private readonly string MUTUALFUND = "Mutual Fund";
        const string CUSTOMERSUPPORT = "Customer Support";
        const string OTHERS = "Others";
        DataTable dtPoints;
        IList<LinkSubStep> linkSubSteps;
        int linkSubStepNo,PrimaryStepNo;
        bool isMultipleLinkSubStepPointsAvailable = false;
        //public ViewTaskCard()
        //{
        //    InitializeComponent();
        //}
        public ViewTaskCard(TaskCard taskCard)
        {
            InitializeComponent();
            this.taskCard = taskCard;
            setEnableDisableControls();
        }

        private void setEnableDisableControls()
        {
            cmbProject.Enabled = false;
            if (isCardCreatorOrOwner())
            {
                setControls(true);
            }
            else
                setControls(false);
        }

        private void setControls(bool v)
        {
            cmbTransactionType.Enabled = v;
            cmbClient.Enabled = v;
            dtDueDate.Enabled = v;
            cmbOwner.Enabled = v;
        }

        private bool isCardCreatorOrOwner()
        {
            return (Program.CurrentUser.Id == this.taskCard.Owner || Program.CurrentUser.Id == this.taskCard.CreatedBy) ?
                true : false;
        }

        private void ViewTaskCard_Load(object sender, EventArgs e)
        {
            ProcessesInfo processesInfo = new ProcessesInfo();
            linkSubSteps = processesInfo.GetLinkSubStepsByRefTaskId(this.taskCard.TaskId);
            if (linkSubSteps.Count > 0)
            {
                if (linkSubSteps[0].Points.Count > 0)
                {
                    isMultipleLinkSubStepPointsAvailable = true;
                }
                linkSubStepNo = linkSubSteps[0].StepNo;
            }

            fillupProjectCombobox();
            fillupCustomer();
            fillupAssignTo();

            fillupTaskView();

            //dummyTaskComments();
            fillupComments();
            fillupHistory();
        }

        private void fillupHistory()
        {
            taskHistories = new TaskHistoryInfo().GetAll(this.taskCard.Id);
            if (taskHistories != null)
            {
                DataTable dtHistory = new DataTable();
                dtHistory = FinancialPlanner.Common.DataConversion.ListtoDataTable.ToDataTable(taskHistories.ToList());
                gridControlHistory.DataSource = dtHistory;
            }


            //dtHistory.Columns.Add("UserName",Type.GetType("System.String"));
            //dtHistory.Columns.Add("UpdatedOn", Type.GetType("System.DateTime"));
            //dtHistory.Columns.Add("FieldName", Type.GetType("System.String"));
            //dtHistory.Columns.Add("OldValue", Type.GetType("System.String"));
            //dtHistory.Columns.Add("NewValue", Type.GetType("System.String"));

            //DateTime dtNow = DateTime.Now;

            //DataRow dr = dtHistory.NewRow();
            //dr["UserName"] = "Admin";
            //dr["UpdatedOn"] = dtNow;
            //dr["FieldName"] = "Description";
            //dr["OldValue"] = "";
            //dr["NewValue"] = "New value for description";
            //dtHistory.Rows.Add(dr);

            //DataRow dr1 = dtHistory.NewRow();
            //dr1["UserName"] = "Admin1";
            //dr1["UpdatedOn"] = dtNow;
            //dr1["FieldName"] = "Status";
            //dr1["OldValue"] = "Beccklog";
            //dr1["NewValue"] = "In Progress";
            //dtHistory.Rows.Add(dr1);

            //gridControlHistory.DataSource = dtHistory;            
        }

        private void fillupTaskView()
        {
            lblTaskIDTitle.Text = taskCard.TaskId;
            lblTaskIDTitle.Tag = taskCard.Id;
            cmbProject.Text = taskCard.ProjectName;
            cmbCardType.Text = taskCard.Type.ToString() == "0" ? "Query" : "Task";
            cmbClient.Tag = taskCard.CustomerId;
            cmbClient.Text = string.IsNullOrEmpty(taskCard.CustomerName) ? getCustomerName((int)(taskCard.CustomerId)) : taskCard.CustomerName;
            cmbTransactionType.Text = taskCard.TransactionType;

            if (cmbProject.Text.Equals("Others") && cmbTransactionType.Text.Equals(""))
            {
                vGridTransaction.Rows.Clear();
                getLinkSubProcessPoint(this.taskCard.TaskId);
            }

            txtTitle.Text = taskCard.Title;
            txtCreatedBy.Text = getUserName(taskCard.CreatedBy);
            txtCreatedOn.Text = taskCard.CreatedOn.ToShortDateString();
            cmbAssignTo.Text = string.IsNullOrEmpty(taskCard.AssignToName) ? getUserName((int)(taskCard.AssignTo)) : taskCard.AssignToName;
            cmbAssignTo.Tag = taskCard.AssignTo;
            cmbPriority.Text = taskCard.Priority.ToString();
            dtDueDate.EditValue = taskCard.DueDate;
            cmbOwner.Tag = taskCard.Owner.ToString();
            cmbOwner.Text = string.IsNullOrEmpty(taskCard.OwnerName) ? getUserName((int)(taskCard.Owner)) : taskCard.OwnerName;
            cmbTaskStatus.Text = taskCard.TaskStatus.ToString();
            txtOtherName.Text = taskCard.OtherName;
            txtDescription.Text = taskCard.Description;
        }

        private void getLinkSubProcessPoint(string taskId)
        {
            //ClientWithProcesInfo clientWithProcesInfo = new ClientWithProcesInfo();
            //IList<CurrentClientProcess> currentClientProcesses = clientWithProcesInfo.GetClientProcess((int)customerId, null);
            //if (currentClientProcesses.Count > 0)
            //{
            //    CurrentClientProcess clientProcess = currentClientProcesses.FirstOrDefault(i => i.RefTaskId == taskId);



            if (isMultipleLinkSubStepPointsAvailable)
            {
                dtPoints = new DataTable();
                dtPoints.Columns.Add("Point");
                dtPoints.Columns.Add("Status");

                List<TaskLinkSubPointsStatus> taskLinkSubPointsStatuses = new List<TaskLinkSubPointsStatus>();
                if (taskCard.TaskTransactionType != null)
                {
                    FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                    taskLinkSubPointsStatuses = jsonSerialization.DeserializeFromString<List<TaskLinkSubPointsStatus>>(taskCard.TaskTransactionType.ToString());
                }
                for (int index = 0; index < linkSubSteps[0].Points.Count(); index++)
                {
                    DataRow dataRow = dtPoints.NewRow();
                    dataRow["Point"] = linkSubSteps[0].Points[index];
                    if (taskLinkSubPointsStatuses.Count > 0)
                    {
                        TaskLinkSubPointsStatus taskLink = taskLinkSubPointsStatuses.Find(i => i.Point.Equals(dataRow["Point"].ToString()));
                        if (taskLink != null)
                        {
                            dataRow["Status"] = taskLink.Status;
                        }
                    }
                    dtPoints.Rows.Add(dataRow);
                }
                grdPoints.DataSource = dtPoints;
            }
            grdPoints.Visible = true;
            grdPoints.Height = vGridTransaction.Height;
            grdPoints.Width = vGridTransaction.Width;
            grdPoints.Location = vGridTransaction.Location;
            grdPoints.BringToFront();
            vGridTransaction.SendToBack();
            vGridTransaction.Visible = false;
            //int stepId = linkSubSteps[0].Id;
            //return stepId;
            //}
            //else
            //    return false;
        }

        private void fillupAssignTo()
        {
            users = new UserServiceHelper().GetAll();
            cmbAssignTo.Properties.Items.Clear();
            cmbOwner.Properties.Items.Clear();
            cmbOwner.Properties.Items.AddRange(users.Select(i => i.UserName).ToList());
            cmbAssignTo.Properties.Items.AddRange(users.Select(i => i.UserName).ToList());
        }

        private void fillupProjectCombobox()
        {
            TaskProjectInfo taskProjectInfo = new TaskProjectInfo();
            projects = taskProjectInfo.GetAll();
            cmbProject.Properties.Items.Clear();
            cmbProject.Properties.Items.AddRange(projects.Select(i => i.Name).ToList());
        }

        private void fillupComments()
        {
            taskComments = new TaskCommentInfo().GetTaskComments(this.taskCard.Id);
            if (taskComments != null)
            {
                DataTable dtComments = new DataTable();
                dtComments = FinancialPlanner.Common.DataConversion.ListtoDataTable.ToDataTable(taskComments.ToList());
                gridComments.DataSource = dtComments;
            }
        }

        private void fillupCustomer()
        {
            ClientService clientService = new ClientService();
            clients = clientService.GetAll();
            cmbClient.Properties.Items.Clear();
            cmbClient.Properties.Items.AddRange(clients.Select(i => i.Name).ToList());
        }

        

        private void ViewTaskCard_FormClosed(object sender, FormClosedEventArgs e)
        {
            //this.Parent.Controls.Remove(this);
        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbProject.Text))
            {
                Project project = projects.FirstOrDefault(i => i.Name == cmbProject.Text);
                cmbProject.Tag = project.Id;
                fillupTransactionType();
            }
            else
            {
                cmbTransactionType.Properties.Items.Clear();
                lblTaskIDTitle.Text = string.Empty;
                return;
            }

            //showTentiveTransactionID();
        }
        private void fillupTransactionType()
        {
            cmbTransactionType.Properties.Items.Clear();
            if (cmbProject.Text == MUTUALFUND)
            {
                cmbTransactionType.Properties.Items.Add("Additional Purchase");
                cmbTransactionType.Properties.Items.Add("New SIP");

                cmbTransactionType.Properties.Items.Add("Switch");
                cmbTransactionType.Properties.Items.Add("SWP");
                cmbTransactionType.Properties.Items.Add("STP");
                cmbTransactionType.Properties.Items.Add("Redemption");
                cmbTransactionType.Properties.Items.Add("STP Pause");
                cmbTransactionType.Properties.Items.Add("SIP Pause");
                cmbTransactionType.Properties.Items.Add("SWP Pause");

                cmbTransactionType.Properties.Items.Add("STP Cancel");
                cmbTransactionType.Properties.Items.Add("SIP Cancel");
                cmbTransactionType.Properties.Items.Add("Fresh Purchase");
                cmbTransactionType.Properties.Items.Add("Others");


                //cmbTransactionType.Properties.Items.Add("Fresh Purchase");
                //cmbTransactionType.Properties.Items.Add("Additional Purchase");
                //cmbTransactionType.Properties.Items.Add("Redemption");
                //cmbTransactionType.Properties.Items.Add("Switch");
                //cmbTransactionType.Properties.Items.Add("STP");
                //cmbTransactionType.Properties.Items.Add("SIP Fresh");
                //cmbTransactionType.Properties.Items.Add("SIP Old");
                //cmbTransactionType.Properties.Items.Add("SWP");
                //cmbTransactionType.Properties.Items.Add("STP Cancellation");
                //cmbTransactionType.Properties.Items.Add("SIP Cancellation");
                //cmbTransactionType.Properties.Items.Add("Bank Change Request");
                //cmbTransactionType.Properties.Items.Add("Contact Update");
                //cmbTransactionType.Properties.Items.Add("PAN Card Update");
                //cmbTransactionType.Properties.Items.Add("Address Change");
                //cmbTransactionType.Properties.Items.Add("Transmission After Death");
                //cmbTransactionType.Properties.Items.Add("Signature Change");
                //cmbTransactionType.Properties.Items.Add("SIP Bank Change");
                //cmbTransactionType.Properties.Items.Add("Minor To Major");
                //cmbTransactionType.Properties.Items.Add("Change of Name");
                //cmbTransactionType.Properties.Items.Add("Nomination");
            }
            else if (cmbProject.Text == CUSTOMERSUPPORT)
            {
                cmbTransactionType.Properties.Items.Add("Bank Change Request");
                cmbTransactionType.Properties.Items.Add("Contact Update");
                cmbTransactionType.Properties.Items.Add("PAN Card Update");
                cmbTransactionType.Properties.Items.Add("Address Change");
                cmbTransactionType.Properties.Items.Add("Transmission After Death");
                cmbTransactionType.Properties.Items.Add("Signature Change");
                cmbTransactionType.Properties.Items.Add("SIP Bank Change");
                cmbTransactionType.Properties.Items.Add("Minor To Major");
                cmbTransactionType.Properties.Items.Add("Change of Name");
                cmbTransactionType.Properties.Items.Add("Nomination");
                cmbTransactionType.Properties.Items.Add("Others");
            }
            else
            {
                if (!isMultipleLinkSubStepPointsAvailable)
                {
                    hideTransactionTypePanel();
                }
            }
        }

        private void hideTransactionTypePanel()
        {
            this.vGridTransaction.Rows.Clear();
            splitContainerTransOperation.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2;
        }

        private void cmbTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (cmbTransactionType.Text.Equals("Others"))
                {
                    hideTransactionTypePanel();
                }
                else
                {
                    Client client = clients.FirstOrDefault(i => i.Name == cmbClient.Text);
                    transactionType = Program.container.Resolve<ITransactionType>(cmbTransactionType.Text);
                    transactionType.setVGridControl(this.vGridTransaction, client);
                    transactionType.BindDataSource(taskCard.TaskTransactionType);
                    splitContainerTransOperation.Panel1.Height = 400;
                    splitContainerTransOperation.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both;
                }
            }
            catch (Unity.ResolutionFailedException)
            {
                this.vGridTransaction.Rows.Clear();
                splitContainerTransOperation.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2;
            }
        }

        private string getCustomerName(int customerId)
        {
            if (customerId == 0)
                return string.Empty;
            return new ClientService().GetClientById(customerId).Name;
        }

        private string getUserName(int? v)
        {
            if (v == 0)
                return string.Empty;

            return new UserInfo().GetById((int)v).UserName;
        }

        private void btnCloseTask_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveTask_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isValidateAllRequireField() || ((transactionType != null) ? !transactionType.IsAllRequireInputAvailable() : false))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Please enter all require fields.",
                       "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                TaskCard taskCard = getTaskCard();
                if (taskCard.TaskStatus == TaskStatus.Complete && taskCard.AssignTo != Program.CurrentUser.Id)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("You can not complete this card because this card is not assign to you.",
                      "User not match", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (taskCard.TaskStatus == TaskStatus.Close && taskCard.Owner != Program.CurrentUser.Id)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("You can not close this card because you are not a owner of this card.",
                      "User not match", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (taskCard.Owner != Program.CurrentUser.Id && taskCard.AssignTo != Program.CurrentUser.Id)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("You can not assign this task to anyother person.",
                      "User not match", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                validatePermissionToByPassProcess(ref taskCard);
                int taskId = new TaskCardService().Update(taskCard);
                if (taskId > 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Record saved sucessfully. Transaction Id: " + taskCard.TaskId,
                    "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSaveTask.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Error :" + ex.ToString(),
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void validatePermissionToByPassProcess(ref TaskCard taskCard)
        {
            if (taskCard.TaskStatus == TaskStatus.Blocked && isTaskBelongToProcessWithByPassPermission(taskCard.CustomerId, taskCard.TaskId))
            {
                //Open Login Page
                frmXtraLogin login = new frmXtraLogin(true);
                login.ShowDialog();
                if (login.IsAuthenticationPassForApproval)
                {
                    taskCard.ProcessApprovedBy = login.ApprovedBy;
                }
                else
                {
                    throw new Exception("Invalid username or password.");
                }
            }
        }

        private bool isTaskBelongToProcessWithByPassPermission(int? customerId, string taskId)
        {
            ClientWithProcesInfo clientWithProcesInfo = new ClientWithProcesInfo();
            IList<CurrentClientProcess> currentClientProcesses = clientWithProcesInfo.GetClientProcess((int)customerId, null);
            if (currentClientProcesses.Count > 0)
            {
                CurrentClientProcess clientProcess = currentClientProcesses.FirstOrDefault(i => i.RefTaskId == taskId);
                return clientProcess.AllowByPassProcess;
            }
            else
                return false;
        }

        private TaskCard getTaskCard()
        {
            TaskCard taskCard = new TaskCard();
            taskCard.Id = int.Parse(lblTaskIDTitle.Tag.ToString());
            taskCard.TaskId = lblTaskIDTitle.Text;
            taskCard.ProjectId = int.Parse(cmbProject.Tag.ToString());
            taskCard.TransactionType = cmbTransactionType.Text;
            taskCard.Type = (CardType)(cmbCardType.SelectedIndex);
            taskCard.CustomerId = !string.IsNullOrEmpty(cmbClient.Text) ? int.Parse(cmbClient.Tag.ToString()) : 0;
            taskCard.Title = txtTitle.Text;
            taskCard.Owner = int.Parse(cmbOwner.Tag.ToString());
            taskCard.CreatedBy = Program.CurrentUser.Id;
            taskCard.CreatedOn = System.DateTime.Now.Date;
            taskCard.UpdatedBy = taskCard.CreatedBy;
            taskCard.UpdatedByUserName = Program.CurrentUser.UserName;
            taskCard.UpdatedOn = System.DateTime.Now.Date;
            taskCard.AssignTo = (!string.IsNullOrEmpty(cmbAssignTo.Text) ? int.Parse(cmbAssignTo.Tag.ToString()) : 0);
            taskCard.Priority = (Priority)(cmbPriority.SelectedIndex);
            taskCard.TaskStatus = (TaskStatus)(cmbTaskStatus.SelectedIndex);
            taskCard.DueDate = dtDueDate.DateTime;
            taskCard.CompletedPercentage = int.Parse(txtPercentageCompeleted.Text);
            taskCard.Description = txtDescription.Text;
            taskCard.MachineName = System.Environment.MachineName;
            taskCard.OtherName = txtOtherName.Text;
            if ((cmbProject.Text == MUTUALFUND || cmbProject.Text == CUSTOMERSUPPORT) && !cmbTransactionType.Text.Equals("Others"))
                taskCard.TaskTransactionType = getTransactionType();
            if (cmbProject.Text.Equals("Others") && isMultipleLinkSubStepPointsAvailable)
            {
                taskCard.TaskTransactionType = getLinkSubTaskPointObject();
            }
            return taskCard;
        }
        private object getTransactionType()
        {
            return this.transactionType.GetTransactionType();
        }

        private object getLinkSubTaskPointObject()
        {
            List<TaskLinkSubPointsStatus> linkSubTaskPointsStatus = new List<TaskLinkSubPointsStatus>();
            for (int rowCount =0; rowCount < gridViewPoints.RowCount; rowCount++)
            {
                TaskLinkSubPointsStatus taskLinkSubPointsStatus = new TaskLinkSubPointsStatus();
                taskLinkSubPointsStatus.Id = this.taskCard.Id;
                taskLinkSubPointsStatus.Point = gridViewPoints.GetRowCellValue(rowCount, "Point").ToString();
                taskLinkSubPointsStatus.Status = gridViewPoints.GetRowCellValue(rowCount, "Status").ToString();
                linkSubTaskPointsStatus.Add(taskLinkSubPointsStatus);
            }
            return linkSubTaskPointsStatus;

        }
        private bool isValidateAllRequireField()
        {
            if (cmbProject.Text == MUTUALFUND)
            {
                if (!string.IsNullOrEmpty(cmbProject.Text) && !string.IsNullOrEmpty(cmbTransactionType.Text) &&
                    !string.IsNullOrEmpty(cmbCardType.Text))
                {
                    return true;
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(cmbProject.Text) &&
                   !string.IsNullOrEmpty(cmbCardType.Text) && !string.IsNullOrEmpty(txtTitle.Text))
                {
                    return true;
                }
            }
            return false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            TaskCommentView taskCommentView = new TaskCommentView(taskCard.Id);
            if (taskCommentView.ShowDialog() == DialogResult.OK)
            {
                fillupComments();
            }
        }

        private void tileViewComment_ItemClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            //string isEdited = ((System.Data.DataRowView)tileViewComment.GetRow(e.Item.RowHandle)).Row.ItemArray[5].ToString();
            //if (isEdited == "True")
            //{
            //        (((System.Data.DataRowView)tileViewComment.GetRow(e.Item.RowHandle)).Row.
            //}
        }

        private void tileViewComment_ItemDoubleClick(object sender, DevExpress.XtraGrid.Views.Tile.TileViewItemClickEventArgs e)
        {
            try
            {
                openTaskComment(e.Item.RowHandle);
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
            }
        }
        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            try
            {
                if (tileViewComment.SelectedRowsCount > 0)
                {
                    int index = tileViewComment.FocusedRowHandle;
                    openTaskComment(index);
                }
                else
                    DevExpress.XtraEditors.XtraMessageBox.Show("Please select valid row.", "Select row", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                DevExpress.XtraEditors.XtraMessageBox.Show("Error:" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openTaskComment(int index)
        {
            int commentId;
            int.TryParse((
                       (System.Data.DataRowView)tileViewComment.GetRow(index)
                       ).Row.ItemArray[0].ToString(), out commentId);
            TaskComment taskComment = taskComments.FirstOrDefault(i => i.Id == commentId);
            if (taskComment.CommantedBy == Program.CurrentUser.Id)
            {
                TaskCommentView taskCommentView = new TaskCommentView(taskComment, taskCard.Id);
                if (taskCommentView.ShowDialog() == DialogResult.OK)
                    fillupComments();
            }
            else
                DevExpress.XtraEditors.XtraMessageBox.Show("You can not modify others comment", "Comment", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void tileViewComment_CustomRowCellEditForEditing(object sender, DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventArgs e)
        {

        }

        private void tileViewComment_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Caption == "IsEdited" && e.Value.ToString() == "True")
            {
            }
        }

        private void tileViewComment_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Caption == "IsEdited" && e.Value.ToString() == "True")
            {
            }
        }

        private void cmbAssignTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbAssignTo.Text))
            {
                cmbAssignTo.Tag = users.FirstOrDefault(i => i.UserName == cmbAssignTo.Text).Id;
            }
        }

        private void cmbOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbOwner.Text))
            {
                cmbOwner.Tag = users.FirstOrDefault(i => i.UserName == cmbOwner.Text).Id;
            }
        }

        private void tabPaneComment_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {
            if (e.Page.Caption.Equals("Reminder"))
            {
                TaskReminderView taskReminder = new TaskReminderView(this.taskCard.Id);
                taskReminder.TopLevel = false;
                taskReminder.Dock = DockStyle.Fill;
                tabPageReminder.Controls.Add(taskReminder);
                taskReminder.Visible = true;
            }
        }
    }
}
