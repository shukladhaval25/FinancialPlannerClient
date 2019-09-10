using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.TaskManagement;
using FinancialPlannerClient.Clients;
using FinancialPlannerClient.Master;
using FinancialPlannerClient.TaskManagementSystem.Services;
using FinancialPlannerClient.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
        List<TaskComment> taskComments = new List<TaskComment>();
        private readonly string MUTUALFUND = "Mutual Fund";

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
            if (isCardCreatorOrOwner()) {
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
            fillupProjectCombobox();
            fillupCustomer();
            fillupAssingTo();

            fillupTaskView();

            dummyTaskComments();
            fillupComments();
        }

        private void fillupTaskView()
        {
            lblTaskIDTitle.Text = taskCard.TaskId;
            lblTaskIDTitle.Tag = taskCard.Id;
            cmbProject.Text = taskCard.ProjectName;
            cmbTransactionType.Text = taskCard.TransactionType;
            cmbCardType.Text =  taskCard.Type.ToString() == "0" ? "Query" : "Task";
            cmbClient.Text = string.IsNullOrEmpty(taskCard.CustomerName) ? getCustomerName((int)(taskCard.CustomerId)) : taskCard.CustomerName;
            txtTitle.Text = taskCard.Title;
            txtCreatedBy.Text = getUserName(taskCard.CreatedBy);
            txtCreatedOn.Text = taskCard.CreatedOn.ToShortDateString();
            cmbAssignTo.Text = string.IsNullOrEmpty(taskCard.AssignToName) ? getUserName((int)(taskCard.AssignTo)) : taskCard.AssignToName;
            cmbPriority.Text = taskCard.Priority.ToString();
            dtDueDate.EditValue = taskCard.DueDate;
            cmbOwner.Tag = taskCard.Owner.ToString();
            cmbOwner.Text = string.IsNullOrEmpty(taskCard.OwnerName) ? getUserName((int)(taskCard.Owner)): taskCard.OwnerName;
            cmbTaskStatus.Text = taskCard.TaskStatus.ToString();

        }

        private void fillupAssingTo()
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
            DataTable dtComments = new DataTable();
            dtComments = FinancialPlanner.Common.DataConversion.ListtoDataTable.ToDataTable(taskComments);
            gridControl1.DataSource = dtComments;
        }

        private void fillupCustomer()
        {
            ClientService clientService = new ClientService();
            clients = clientService.GetAll();
            cmbClient.Properties.Items.Clear();
            cmbClient.Properties.Items.AddRange(clients.Select(i => i.Name).ToList());
        }

        private void dummyTaskComments()
        {
            TaskComment taskComment = new TaskComment();
            taskComment.Id = 1;
            taskComment.TaskId = "PF-001";
            taskComment.CommantedBy = "Admin";
            taskComment.CommentedOn = new DateTime(2019, 02, 06);
            taskComment.To = new List<string>() { "Amit Shah" };
            taskComment.Comment = "This work is not going to complete unless and untill you provide client contact inforamtion";
            taskComments.Add(taskComment);

            TaskComment taskComment1 = new TaskComment();
            taskComment1.Id = 2;
            taskComment1.TaskId = "PF-001";
            taskComment1.CommantedBy = "Amit Shah";
            taskComment1.CommentedOn = new DateTime(2019, 02, 06);
            taskComment1.To = new List<string>() { "Admin" };
            taskComment1.Comment = "Client contact information is as below: Mobile 9869544585";
            taskComments.Add(taskComment1);

            TaskComment taskComment2 = new TaskComment();
            taskComment2.Id = 3;
            taskComment2.TaskId = "MF-15";
            taskComment2.CommantedBy = "Amit Shah";
            taskComment2.CommentedOn = new DateTime(2019, 02, 06);
            taskComment2.To = new List<string>() { "Admin" };
            taskComment2.Comment = "Fresh purchse of ICICI Long term fund.";
            taskComments.Add(taskComment2);

            TaskComment taskComment3 = new TaskComment();
            taskComment3.Id = 3;
            taskComment3.TaskId = "MF-16";
            taskComment3.CommantedBy = "Dhaval Shah";
            taskComment3.CommentedOn = new DateTime(2019, 02, 06);
            taskComment3.To = new List<string>() { "Admin" };
            taskComment3.Comment = "Additional purchse of ICICI Long term fund.";
            taskComments.Add(taskComment3);

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
                cmbTransactionType.Properties.Items.Add("Fresh Purchase");
                cmbTransactionType.Properties.Items.Add("Additional Purchase");
                cmbTransactionType.Properties.Items.Add("Switch");
                cmbTransactionType.Properties.Items.Add("STP");
                cmbTransactionType.Properties.Items.Add("SIP Fresh");
                cmbTransactionType.Properties.Items.Add("SIP Old");
            }
        }

        private void cmbTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                transactionType = Program.container.Resolve<ITransactionType>(cmbTransactionType.Text);
                transactionType.setVGridControl(this.vGridTransaction);
                transactionType.BindDataSource(taskCard.TaskTransactionType);
                splitContainerTransOperation.Panel1.Height = 400;
                splitContainerTransOperation.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both;
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
            MessageBox.Show("Currently this functionality is not working. Work in progress...");
        }
    }
}
