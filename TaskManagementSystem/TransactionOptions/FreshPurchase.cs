using DevExpress.Utils;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Events;
using DevExpress.XtraVerticalGrid.Rows;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.TaskManagement.MFTransactions;
using FinancialPlannerClient.Clients;
using FinancialPlannerClient.Master.TaskMaster;
using System;
using System.Collections.Generic;
using System.Data;

namespace FinancialPlannerClient.TaskManagementSystem.TransactionOptions
{
    public class FreshPurchase : ITransactionType
    {
        IList<ARN> arns;
        IList<Client> clients;
        IList<Scheme> schemes;
        Client currentClient;
        
        readonly string GRID_NAME = "vGridFreshPurchase";
        DevExpress.XtraVerticalGrid.VGridControl vGridTransaction;


        private DevExpress.XtraVerticalGrid.Rows.EditorRow ARN;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow ClientGroup;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow MemberName;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow SecondHolder;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow ThirdHolder;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Nominee;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Guardian;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow ModeOfHolding;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow AMC;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow FolioNumber;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Scheme;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Options;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Amount;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow TransactionDate;
        //private DevExpress.XtraVerticalGrid.Rows.EditorRow AssignedTo;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow ModeOfExecution;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Remark;


        public DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemARN;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxClientGroup;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxMemberName;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxSecondHolder;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxThirdHolder;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditNominee;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditGuardian;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxModeOfHolding;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditAMC;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditFolioNumber;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxScheme;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxOption;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditAmount;
        public DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEditTransactionDate;
        //public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxAssignTo;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxModeOfExecution;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditRemark;



        private void InitializeComponent()
        {
            if (this.vGridTransaction == null)
                return;

            this.ARN = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.ClientGroup = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.MemberName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.SecondHolder = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.ThirdHolder = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Nominee = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Guardian = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.ModeOfHolding = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.AMC = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.FolioNumber = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Scheme = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Options = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Amount = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.TransactionDate = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            //this.AssignedTo = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.ModeOfExecution = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Remark = new DevExpress.XtraVerticalGrid.Rows.EditorRow();

            this.repositoryItemARN = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            loadARNValue();

            this.repositoryItemComboBoxClientGroup = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxClientGroup.EditValueChanged += RepositoryItemComboBoxClientGroup_SelectedValueChanged;
            this.repositoryItemComboBoxClientGroup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            loadClients();

            this.repositoryItemComboBoxMemberName = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxMemberName.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            this.repositoryItemComboBoxSecondHolder = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxSecondHolder.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            this.repositoryItemComboBoxThirdHolder = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxThirdHolder.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            this.repositoryItemTextEditNominee = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEditGuardian = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();

            this.repositoryItemComboBoxModeOfHolding = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxModeOfHolding.Items.AddRange(new string[] { "Joint", "Either or survivor", "Single" });
            this.repositoryItemComboBoxModeOfHolding.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            this.repositoryItemTextEditAMC = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEditFolioNumber = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();

            this.repositoryItemComboBoxScheme = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxScheme.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            loadScheme();

            this.repositoryItemComboBoxOption = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();

            this.repositoryItemComboBoxOption.Items.AddRange(new string[] { "GR","WDR","DD" });
            this.repositoryItemComboBoxOption.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            this.repositoryItemTextEditAmount = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEditAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEditAmount.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEditAmount.Validating += RepositoryItemTextEditAmount_Validating;

            this.repositoryItemDateEditTransactionDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();

            //this.repositoryItemComboBoxAssignTo = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            //this.repositoryItemComboBoxAssignTo.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            this.repositoryItemComboBoxModeOfExecution = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxModeOfExecution.Items.AddRange(new string[] { "BSE", "AMC App","Physical" });
            this.repositoryItemComboBoxModeOfExecution.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            
            this.repositoryItemTextEditRemark = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            // 
            // ARN
            // 
            this.ARN.Name = "ARN";
            this.ARN.Properties.Caption = "ARN";
            this.ARN.Properties.FieldName = "ARN";
            this.ARN.Properties.RowEdit = this.repositoryItemARN;
            //
            // ClientGroup
            //
            this.ClientGroup.Name = "ClientGroup";
            this.ClientGroup.Properties.Caption = "Client Group";
            this.ClientGroup.Properties.FieldName = "ClientGroup";
            this.ClientGroup.Properties.RowEdit = this.repositoryItemComboBoxClientGroup;
            //
            // MemberName
            //
            this.MemberName.Name = "MemberName";
            this.MemberName.Properties.Caption = "Member Name";
            this.MemberName.Properties.FieldName = "MemberName";
            this.MemberName.Properties.RowEdit = this.repositoryItemComboBoxMemberName;
            //
            // SecondHolder
            //
            this.SecondHolder.Name = "SecondHolder";
            this.SecondHolder.Properties.Caption = "Second Holder";
            this.SecondHolder.Properties.FieldName = "SecondHolder";
            this.SecondHolder.Properties.RowEdit = this.repositoryItemComboBoxSecondHolder;
            //
            // ThirdHolder
            //
            this.ThirdHolder.Name = "ThirdHolder";
            this.ThirdHolder.Properties.Caption = "Third Holder";
            this.ThirdHolder.Properties.FieldName = "ThirdHolder";
            this.ThirdHolder.Properties.RowEdit = this.repositoryItemComboBoxThirdHolder;
            //
            // Nominee
            //
            this.Nominee.Name = "Nominee";
            this.Nominee.Properties.Caption = "Nominee";
            this.Nominee.Properties.FieldName = "Nominee";
            this.Nominee.Properties.AllowEdit = true;
            this.Nominee.Properties.Value = string.Empty;
            this.Nominee.Properties.RowEdit = this.repositoryItemTextEditNominee;
            //
            // Guardian
            //
            this.Guardian.Name = "Guardian";
            this.Guardian.Properties.Caption = "Guardian";
            this.Guardian.Properties.FieldName = "Guardian";
            this.Guardian.Properties.RowEdit = this.repositoryItemTextEditGuardian;
            this.Guardian.Properties.Value = string.Empty;
            //
            // ModeOfHolding
            //
            this.ModeOfHolding.Name = "ModeOfHolding";
            this.ModeOfHolding.Properties.Caption = "Mode of Holding";
            this.ModeOfHolding.Properties.FieldName = "ModeOfHolding";
            this.ModeOfHolding.Properties.RowEdit = this.repositoryItemComboBoxModeOfHolding;
            //
            // AMC
            //
            this.AMC.Name = "AMC";
            this.AMC.Properties.Caption = "AMC";
            this.AMC.Properties.FieldName = "AMC";
            this.AMC.Properties.RowEdit = this.repositoryItemTextEditAMC;
            //
            // FolioNumber
            //
            this.FolioNumber.Name = "FolioNumber";
            this.FolioNumber.Properties.Caption = "Folio Number";
            this.FolioNumber.Properties.FieldName = "FolioNumber";
            this.FolioNumber.Properties.RowEdit = this.repositoryItemTextEditFolioNumber;
            //
            // Scheme
            //
            this.Scheme.Name = "Scheme";
            this.Scheme.Properties.Caption = "Scheme";
            this.Scheme.Properties.FieldName = "Scheme";
            this.Scheme.Properties.RowEdit = this.repositoryItemComboBoxScheme;
            //
            // Option
            //
            this.Options.Name = "Option";
            this.Options.Properties.Caption = "Option";
            this.Options.Properties.FieldName = "Option";
            this.Options.Properties.RowEdit = this.repositoryItemComboBoxOption;
            //
            // Amount
            //
            this.Amount.Name = "Amount";
            this.Amount.Properties.Caption = "Amount";
            this.Amount.Properties.FieldName = "Amount";
            this.Amount.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Amount.Properties.RowEdit = this.repositoryItemTextEditAmount;
            //
            // Transaction Date
            //
            this.TransactionDate.Name = "TransactionDate";
            this.TransactionDate.Properties.Caption = "Transaction Date";
            this.TransactionDate.Properties.FieldName = "TransactionDate";
            this.TransactionDate.Properties.Format.FormatString = string.Format("dd/MM/yyyy");
            this.TransactionDate.Properties.RowEdit = this.repositoryItemDateEditTransactionDate;
            //
            // AssignedTo
            //
            //this.AssignedTo.Name = "AssignedTo";
            //this.AssignedTo.Properties.Caption = "Assigned To";
            //this.AssignedTo.Properties.FieldName = "AssignedTo";
            //this.AssignedTo.Properties.RowEdit = this.repositoryItemComboBoxAssignTo;
            //
            // ModeOfExecution
            //
            this.ModeOfExecution.Name = "ModeOfExecution";
            this.ModeOfExecution.Properties.Caption = "Mode Of Execution";
            this.ModeOfExecution.Properties.FieldName = "ModeOfExecution";
            this.ModeOfExecution.Properties.RowEdit = this.repositoryItemComboBoxModeOfExecution;
            //
            // Remark
            //
            this.Remark.Name = "Remark";
            this.Remark.Properties.Caption = "Remark";
            this.Remark.Properties.FieldName = "Remark";
            this.Remark.Properties.RowEdit = this.repositoryItemTextEditRemark;
            this.Remark.Properties.AllowEdit = true;
            //
            // VGridControl
            //
            this.vGridTransaction.Name = GRID_NAME;
            this.vGridTransaction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));

            this.vGridTransaction.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
                this.repositoryItemARN,
                this.repositoryItemComboBoxClientGroup,
                this.repositoryItemComboBoxMemberName,
                this.repositoryItemComboBoxSecondHolder,
                this.repositoryItemComboBoxThirdHolder,
                this.repositoryItemTextEditNominee,
                this.repositoryItemTextEditGuardian,
                this.repositoryItemComboBoxModeOfHolding,
            this.repositoryItemTextEditAMC,
            this.repositoryItemTextEditFolioNumber,
            this.repositoryItemComboBoxScheme,
            this.repositoryItemComboBoxOption,
            this.repositoryItemTextEditAmount,
            this.repositoryItemDateEditTransactionDate,
            //this.repositoryItemComboBoxAssignTo,
            this.repositoryItemComboBoxModeOfExecution,
            this.repositoryItemTextEditRemark
            });

            this.vGridTransaction.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
                this.ARN,
                this.ClientGroup,
                this.MemberName,
                this.SecondHolder,
                this.ThirdHolder,
                this.Nominee,
                this.Guardian,
                this.ModeOfHolding,
            this.AMC,
            this.FolioNumber,
            this.Scheme,
            this.Options,
            this.Amount,
            this.TransactionDate,
            //this.AssignedTo,
            this.ModeOfExecution,
            this.Remark});
        }

        private void loadScheme()
        {
            SchemeInfo schemeInfo = new SchemeInfo();
            schemes = schemeInfo.GetAll();
            repositoryItemComboBoxScheme.Items.Clear();
            foreach (Scheme scheme in schemes)
            {
                repositoryItemComboBoxScheme.Items.Add(scheme.Name);
            }
        }

        private void RepositoryItemTextEditAmount_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DevExpress.XtraEditors.TextEdit textEdit = (DevExpress.XtraEditors.TextEdit) sender;
            e.Cancel = !FinancialPlanner.Common.Validation.IsDecimal(textEdit.Text);
        }

        private void loadMembers()
        {
            if (this.currentClient == null)
                return;

            repositoryItemComboBoxMemberName.Items.Clear();
            repositoryItemComboBoxSecondHolder.Items.Clear();
            repositoryItemComboBoxThirdHolder.Items.Clear();
           
            new PlannerInfo.FamilyMemberInfo().FillFamilyMemberInCombo(this.currentClient.ID, repositoryItemComboBoxMemberName);
            repositoryItemComboBoxSecondHolder.Items.AddRange(repositoryItemComboBoxMemberName.Items);
            repositoryItemComboBoxThirdHolder.Items.AddRange(repositoryItemComboBoxMemberName.Items);
        }

        private void RepositoryItemComboBoxClientGroup_SelectedValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit = (DevExpress.XtraEditors.ComboBoxEdit)sender;
            if (comboBoxEdit.SelectedItem != null)
            {
                this.currentClient = ((List<Client>)clients).Find(i => i.Name == comboBoxEdit.SelectedItem.ToString());
                loadMembers();
            }
        }

        private void loadClients()
        {
            ClientService clientService = new ClientService();
            clients = clientService.GetAll();
            repositoryItemComboBoxClientGroup.Items.Clear();
            foreach(Client client in clients)
            {
                repositoryItemComboBoxClientGroup.Items.Add(client.Name);
            }
        }

        private void loadARNValue()
        {
            ARNInfo arnInfo = new ARNInfo();
            arns = arnInfo.GetAll();
            DataTable dtARN = getARNTable();
            repositoryItemARN.DataSource = dtARN;
            repositoryItemARN.DisplayMember = "ARNNumber";
            repositoryItemARN.ValueMember = "ID";
            repositoryItemARN.NullValuePrompt = "Please select valid value.";           
        }
        private DataTable getARNTable()
        {
            DataTable dtARN = new DataTable();
            dtARN.Columns.Add("ID", typeof(System.Int64));
            dtARN.Columns.Add("ARNNumber", typeof(System.String));
            dtARN.Columns.Add("Name", typeof(System.String));
            foreach (ARN arn in arns)
            {
                DataRow dr = dtARN.NewRow();
                dr["ID"] = arn.Id;
                dr["ARNNumber"] = arn.ArnNumber;
                dr["Name"] = arn.Name;
                dtARN.Rows.Add(dr);
            }
            return dtARN;
        }

        public void BindDataSource(DataTable dataTable)
        {
            this.vGridTransaction.DataSource = dataTable;
        }

        public VGridControl GetGridControl()
        {
            InitializeComponent();
            this.vGridTransaction.RowHeaderWidth = 150;
            for (int rowindex = 0; rowindex < this.vGridTransaction.Rows.Count; rowindex++)
            {
                this.vGridTransaction.Rows[rowindex].Height = 20;
            }
            this.vGridTransaction.Refresh();
            return this.vGridTransaction;
        }

        public void setVGridControl(VGridControl vGrid)
        {
            this.vGridTransaction = vGrid;
            this.vGridTransaction.RepositoryItems.Clear();
            this.vGridTransaction.Rows.Clear();
            InitializeComponent();
            this.vGridTransaction.RowHeaderWidth = 200;
            this.vGridTransaction.RecordWidth = 280;
            for (int rowindex = 0; rowindex < this.vGridTransaction.Rows.Count; rowindex++)
            {
                this.vGridTransaction.Rows[rowindex].Height = 20;
            }
            this.vGridTransaction.Refresh();
        }
    }
}
