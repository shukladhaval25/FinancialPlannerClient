using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.TaskManagement;
using FinancialPlannerClient.Clients;
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
            //throw new NotImplementedException();
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
            cmbTransactionType.Properties.Items.Add("SIP-Fresh Folio");
        }

        private void cmbTransactionType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //this.vGridTransaction.Rows.Clear();
            //freshPurchaseTypeTransaction();

            
            var transactionType = Program.container.Resolve<ITransactionType>(cmbTransactionType.Text);
            transactionType.setVGridControl(this.vGridTransaction);

            //this.vGridTransaction.RepositoryItems.AddRange(freshPurchase.GetRepositoryItems());
            //this.vGridTransaction.Rows.AddRange(freshPurchase.GetBaseRows());


            //this.vGridTransaction.Update();
            //this.vGridTransaction.Refresh();
            //DataTable dtTransaction = new DataTable();
            //dtTransaction.Columns.Add("ARN");
            //dtTransaction.Columns.Add("ClientGroup");
            //dtTransaction.Columns.Add("Member name");
            //dtTransaction.Columns.Add("Second Holder");
            //dtTransaction.Columns.Add("Third Holder");
            //dtTransaction.Columns.Add("Amount");

            //DataRow dr = dtTransaction.NewRow();
            //dr["ARN"] = "16699/113059/138434";
            //dr["ClientGroup"] = "PRAKASH H LOHANA";
            //dr["Member name"] = "PRAKASH H LOHANA";
            //dr["Amount"] = "50000";
            //dtTransaction.Rows.Add(dr);
            //vGridTransaction.DataSource = dtTransaction;
            //vGridTransaction.CreateRow(1);
            //vGridTransaction.AddNewRecord();
        }

        private void freshPurchaseTypeTransaction()
        {
            DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemARN = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxClientGroup = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxMemberName = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();

            repositoryItemARN.Items.Add("10211/25/2565");
            repositoryItemARN.Items.Add("36560/25/2345");
            repositoryItemARN.Items.Add("2334/25/2346");

            repositoryItemComboBoxClientGroup.Items.AddRange(this.clients.Select(i => i.Name).ToList());
            repositoryItemComboBoxMemberName.Items.AddRange(this.clients.Select(i => i.Name).ToList());

            DevExpress.XtraVerticalGrid.Rows.EditorRow ARN = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            ARN.Name = "ARN";
            ARN.Properties.FieldName = "ARN";
            ARN.Properties.Caption = "ARN";
            ARN.Properties.RowEdit = repositoryItemARN;

            DevExpress.XtraVerticalGrid.Rows.EditorRow ClientGroup = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            ClientGroup.Name = "ClientGroup";
            ClientGroup.Properties.FieldName = "ClientGroup";
            ClientGroup.Properties.Caption = "ClientGroup";
            ClientGroup.Properties.RowEdit = repositoryItemComboBoxClientGroup;

            DevExpress.XtraVerticalGrid.Rows.EditorRow memberName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            memberName.Name = "MemberName";
            memberName.Properties.FieldName = "MemberName";
            memberName.Properties.Caption = "MemberName";
            memberName.Properties.RowEdit = repositoryItemComboBoxMemberName;

            this.vGridTransaction.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] { repositoryItemARN,
                repositoryItemComboBoxClientGroup,
                repositoryItemComboBoxMemberName});

            this.vGridTransaction.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] { ARN,
                ClientGroup,
                memberName});
        }
    }
}
