using DevExpress.XtraVerticalGrid.Rows;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.TaskManagement;
using FinancialPlannerClient.Clients;
using FinancialPlannerClient.Master;
using FinancialPlannerClient.TaskManagementSystem.Services;
using FinancialPlannerClient.TaskManagementSystem.TransactionOptions;
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
    public partial class NewTaskCard : DevExpress.XtraEditors.XtraForm
    {
        IList<Project> projects = new List<Project>();
        IList<Client> clients;
        IList<User> users;
        public NewTaskCard()
        {
            InitializeComponent();
        }

        private void NewTaskCard_Load(object sender, EventArgs e)
        {
            fillupProjectCombobox();
            fillupCustomer();
            fillupAssingTo();
            txtCreatedBy.Text = Program.CurrentUser.UserName;
            txtCreatedOn.Text = DateTime.Now.ToString();
        }

        private void fillupAssingTo()
        {
            users =  new UserServiceHelper().GetAll();
            cmbAssingTo.Properties.Items.Clear();
            cmbAssingTo.Properties.Items.AddRange(users.Select(i => i.UserName).ToList());
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
            if (string.IsNullOrEmpty(cmbProject.Text))
            {
                cmbTransactionType.Properties.Items.Clear();
                lblTaskIDTitle.Text = string.Empty;
                return;
            }

            showTentiveTransactionID();
        }

        private void showTentiveTransactionID()
        {
            string tentiveTransactionID = string.Empty;
            Project project = projects.First(i => i.Name == cmbProject.Text);
            if (project != null)
            {
                lblTaskIDTitle.Text = string.Format("{0}-{1}", project.InitialId, 11);
                fillupTransactionType();
            }
        }

        private void fillupTransactionType()
        {
            cmbTransactionType.Properties.Items.Clear();
            cmbTransactionType.Properties.Items.Add("Fresh Purchase");
            cmbTransactionType.Properties.Items.Add("Additional Purchase");
            cmbTransactionType.Properties.Items.Add("Switch");
            cmbTransactionType.Properties.Items.Add("STP");
            cmbTransactionType.Properties.Items.Add("SIP-Fresh Folio");
        }

        private void cmbTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var transactionType = Program.container.Resolve<ITransactionType>(cmbTransactionType.Text);
                transactionType.setVGridControl(this.vGridTransaction);
                splitContainerTransOperation.Panel1.Height = 400;
                splitContainerTransOperation.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Both;
            }
            catch (Unity.ResolutionFailedException unityException)
            {
                this.vGridTransaction.Rows.Clear();
                splitContainerTransOperation.PanelVisibility = DevExpress.XtraEditors.SplitPanelVisibility.Panel2;
            }
        }

        private void btnSaveTask_Click(object sender, EventArgs e)
        {
            new Testing().ShowDialog();
        }

        private void splitContainerTransOperation_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
