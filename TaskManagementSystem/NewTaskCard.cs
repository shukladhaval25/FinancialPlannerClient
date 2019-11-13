using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.TaskManagement;
using FinancialPlanner.Common.Model.TaskManagement.MFTransactions;
using FinancialPlannerClient.Clients;
using FinancialPlannerClient.Master;
using FinancialPlannerClient.TaskManagementSystem.Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Unity;

namespace FinancialPlannerClient.TaskManagementSystem
{
    public partial class NewTaskCard : DevExpress.XtraEditors.XtraForm
    {
        IList<Project> projects = new List<Project>();
        IList<Client> clients;
        IList<User> users;
        ClientARN clientARN;
        private ITransactionType transactionType;
        const string MUTUALFUND = "Mutual Fund";
        public NewTaskCard()
        {
            InitializeComponent();
        }

        private void NewTaskCard_Load(object sender, EventArgs e)
        {
            fillupProjectCombobox();
            fillupCustomer();
            fillupAssignTo();        
            txtCreatedBy.Text = Program.CurrentUser.UserName;
            txtCreatedOn.Text = DateTime.Now.ToString();
        }

        private void fillupAssignTo()
        {
            users = new UserServiceHelper().GetAll();
            cmbAssignTo.Properties.Items.Clear();
            cmbOwner.Properties.Items.Clear();
            cmbOwner.Properties.Items.AddRange(users.Select(i => i.UserName).ToList());
            cmbAssignTo.Properties.Items.AddRange(users.Select(i => i.UserName).ToList());
        }

        private void fillupCustomer()
        {
            ClientService clientService = new ClientService();
            clients = clientService.GetAll();
            cmbClient.Properties.Items.Clear();
            cmbClient.Properties.Items.AddRange(clients.Select(i => i.Name).ToList());
        }

        private void fillupProjectCombobox()
        {
            TaskProjectInfo taskProjectInfo = new TaskProjectInfo();
            projects = taskProjectInfo.GetAll();
            cmbProject.Properties.Items.Clear();
            cmbProject.Properties.Items.AddRange(projects.Select(i => i.Name).ToList());
        }

        private void NewTaskCard_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void cmbProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbProject.Text))
            {
                Project project = projects.FirstOrDefault(i => i.Name == cmbProject.Text);
                cmbProject.Tag = project.Id;
                lblTaskIDTitle.Text = project.InitialId;
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

        private void showTentiveTransactionID()
        {
            string tentiveTransactionID = string.Empty;
            Project project = projects.First(i => i.Name == cmbProject.Text);
            if (project != null)
            {
                lblTaskIDTitle.Text = string.Format("{0}", project.InitialId);
               
            }
        }

        private void fillupTransactionType()
        {
            cmbTransactionType.Properties.Items.Clear();
            if (cmbProject.Text == MUTUALFUND)
            {
                cmbTransactionType.Properties.Items.Add("Fresh Purchase");
                cmbTransactionType.Properties.Items.Add("Additional Purchase");
                cmbTransactionType.Properties.Items.Add("Switch");
                cmbTransactionType.Properties.Items.Add("STP");
                cmbTransactionType.Properties.Items.Add("SIP Fresh");
                cmbTransactionType.Properties.Items.Add("SIP Old");
                cmbTransactionType.Properties.Items.Add("SWP");
                cmbTransactionType.Properties.Items.Add("STP Cancellation");
                cmbTransactionType.Properties.Items.Add("SIP Cancellation");
                cmbTransactionType.Properties.Items.Add("Bank Change Request");
                cmbTransactionType.Properties.Items.Add("Contact Update");
                cmbTransactionType.Properties.Items.Add("PAN Card Update");
                cmbTransactionType.Properties.Items.Add("Address Change");
                cmbTransactionType.Properties.Items.Add("Transmission After Death");
                cmbTransactionType.Properties.Items.Add("Signature Change");
                cmbTransactionType.Properties.Items.Add("SIP Bank Change");
                cmbTransactionType.Properties.Items.Add("Minor To Major");
                cmbTransactionType.Properties.Items.Add("Change of Name");
            }
            else
            {
                hideTransactionTypePanel();
            }
        }

        private void cmbTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                transactionType = Program.container.Resolve<ITransactionType>(cmbTransactionType.Text);                
                transactionType.setVGridControl(this.vGridTransaction);
                transactionType.SetARN(clientARN.ARNId);
                splitContainerTransOperation.Panel1.Height = 400;
                splitContainerTransOperation.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both;
            }
            catch (Unity.ResolutionFailedException)
            {
                hideTransactionTypePanel();
            }
        }

        private void hideTransactionTypePanel()
        {
            this.vGridTransaction.Rows.Clear();
            splitContainerTransOperation.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2;
        }

        private void btnSaveTask_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isValidateAllRequireField() || ( transactionType != null && !transactionType.IsAllRequireInputAvailable()))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Please enter all require fields.",
                       "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                TaskCard taskCard = getTaskCard();
                int taskId = new TaskCardService().Add(taskCard);
                if (taskId > 0)
                {
                    lblTaskIDTitle.Text = taskCard.TaskId + "-" + taskId;
                    DevExpress.XtraEditors.XtraMessageBox.Show("Record saved sucessfully. Transaction Id: " + taskCard.TaskId + "-" + taskId,
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

        private TaskCard getTaskCard()
        {
            TaskCard taskCard = new TaskCard();
            taskCard.TaskId = lblTaskIDTitle.Text;
            taskCard.ProjectId = int.Parse(cmbProject.Tag.ToString());
            taskCard.TransactionType = cmbTransactionType.Text;
            taskCard.Type = (CardType)(cmbCardType.SelectedIndex);
            taskCard.CustomerId =  !string.IsNullOrEmpty(cmbClient.Text) ?  int.Parse(cmbClient.Tag.ToString()): 0;
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
            taskCard.CompletedPercentage = int.Parse(txtCompletedPercentage.Text);
            taskCard.Description = txtDescription.Text;
            taskCard.MachineName = System.Environment.MachineName;
            if (cmbProject.Text == MUTUALFUND)
                taskCard.TaskTransactionType = getTransactionType();
            return taskCard;
        }

        private object getTransactionType()
        {
            return this.transactionType.GetTransactionType();
        }

        private bool isValidateAllRequireField()
        {
            if (cmbProject.Text == MUTUALFUND)
            {
                if (!string.IsNullOrEmpty(cmbProject.Text) && !string.IsNullOrEmpty(cmbTransactionType.Text) &&
                    !string.IsNullOrEmpty(cmbCardType.Text) && !string.IsNullOrEmpty(txtTitle.Text) &&
                    !string.IsNullOrEmpty(cmbClient.Text))
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

        private void splitContainerTransOperation_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cmbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbClient.Text))
            {
                cmbClient.Tag = clients.FirstOrDefault(i => i.Name == cmbClient.Text).ID;
                ClientARNInfo clientARNInfo = new ClientARNInfo();
                clientARN = clientARNInfo.Get(int.Parse(cmbClient.Tag.ToString()));
            }
        }

        private void cmbOwner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbOwner.Text))
            {
                cmbOwner.Tag = users.FirstOrDefault(i => i.UserName == cmbOwner.Text).Id;
            }
        }

        private void cmbAssingTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbAssignTo.Text))
            {
                cmbAssignTo.Tag = users.FirstOrDefault(i => i.UserName == cmbAssignTo.Text).Id;
            }
        }

        private void btnCloseTask_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
