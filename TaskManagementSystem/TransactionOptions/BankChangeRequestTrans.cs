using DevExpress.XtraVerticalGrid;
using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.Masters;
using FinancialPlanner.Common.Model.TaskManagement.MFTransactions;
using FinancialPlannerClient.Clients;
using FinancialPlannerClient.Master.TaskMaster;
using System;
using System.Collections.Generic;
using System.Data;

namespace FinancialPlannerClient.TaskManagementSystem.TransactionOptions
{
    internal class BankChangeRequestTrans : ITransactionType
    {
        internal IList<ARN> arns;
        internal IList<AMC> amcs;
        internal IList<Client> clients;
        internal IList<Bank> banks;
        internal Client currentClient;

        private DevExpress.XtraVerticalGrid.Rows.EditorRow ARN;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow ClientGroup;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow MemberName;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow AMC;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow FolioNumber;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow OldBankName;

        private DevExpress.XtraVerticalGrid.Rows.EditorRow OldBankAccountNumber;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow NewBankName;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow NewBankAccountNumber;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow ModeOfExecution;

        readonly string GRID_NAME = "vGridBankChangeRequest";
        DevExpress.XtraVerticalGrid.VGridControl vGridTransaction;
        BankChangeRequest freshPurchase;


        public DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemARN;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxClientGroup;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxMemberName;
        public DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemAMC;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditFolioNumber;
        public DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemOldBank;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditOldBankNumber;
        public DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemNewBank;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditNewBankNumber;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxModeOfExecution;

        private void InitializeComponent()
        {
            if (this.vGridTransaction == null)
                return;

            this.ARN = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.ClientGroup = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.MemberName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.AMC = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.FolioNumber = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.OldBankName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.OldBankAccountNumber = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.NewBankName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.NewBankAccountNumber = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.ModeOfExecution = new DevExpress.XtraVerticalGrid.Rows.EditorRow();


            this.repositoryItemARN = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            loadARNValue();
            this.repositoryItemARN.Validating += RepositoryItemARN_Validating;


            this.repositoryItemComboBoxClientGroup = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxClientGroup.EditValueChanged += RepositoryItemComboBoxClientGroup_SelectedValueChanged;
            this.repositoryItemComboBoxClientGroup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            loadClients();
            this.repositoryItemComboBoxClientGroup.Validating += RepositoryItemComboBoxClientGroup_Validating;

            this.repositoryItemComboBoxMemberName = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxMemberName.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.repositoryItemComboBoxMemberName.Validating += RepositoryItemComboBoxClientGroup_Validating;

            this.repositoryItemAMC = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemAMC.EditValueChanged += RepositoryItemAMC_EditValueChanged; ;
            loadAMC();

            this.repositoryItemTextEditFolioNumber = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();

            this.repositoryItemOldBank = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemTextEditOldBankNumber = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemNewBank = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemTextEditNewBankNumber = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            loadBanks();

            this.repositoryItemComboBoxModeOfExecution = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxModeOfExecution.Items.AddRange(new string[] { "BSE", "AMC App", "Physical" });
            this.repositoryItemComboBoxModeOfExecution.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

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
            // AMC
            //
            this.AMC.Name = "AMC";
            this.AMC.Properties.Caption = "AMC";
            this.AMC.Properties.FieldName = "AMC";
            this.AMC.Properties.RowEdit = this.repositoryItemAMC;
            //
            // FolioNumber
            //
            this.FolioNumber.Name = "FolioNumber";
            this.FolioNumber.Properties.Caption = "Folio Number";
            this.FolioNumber.Properties.FieldName = "FolioNumber";
            this.FolioNumber.Properties.RowEdit = this.repositoryItemTextEditFolioNumber;
            //
            // Old Bank Name
            //
            this.OldBankName.Name = "OldBank";
            this.OldBankName.Properties.Caption = "Old Bank Name";
            this.OldBankName.Properties.FieldName = "OldBank";
            this.OldBankName.Properties.RowEdit = this.repositoryItemOldBank;
            //
            // Old Bank Number
            //
            this.OldBankAccountNumber.Name = "OldBankAccountNo";
            this.OldBankAccountNumber.Properties.Caption = "Old Bank A/C No";
            this.OldBankAccountNumber.Properties.FieldName = "OldBankAccountNo";
            this.OldBankAccountNumber.Properties.RowEdit = this.repositoryItemTextEditOldBankNumber;
            //
            // New Bank Name
            //
            this.NewBankName.Name = "NewBank";
            this.NewBankName.Properties.Caption = "New Bank Name";
            this.NewBankName.Properties.FieldName = "NewBank";
            this.NewBankName.Properties.RowEdit = this.repositoryItemNewBank;
            //
            // New Bank Number
            //
            this.NewBankAccountNumber.Name = "NewBankAccountNo";
            this.NewBankAccountNumber.Properties.Caption = "New Bank A/C No";
            this.NewBankAccountNumber.Properties.FieldName = "NewBankAccountNo";
            this.NewBankAccountNumber.Properties.RowEdit = this.repositoryItemTextEditNewBankNumber;
            //
            // ModeOfExecution
            //
            this.ModeOfExecution.Name = "ModeOfExecution";
            this.ModeOfExecution.Properties.Caption = "Mode Of Execution";
            this.ModeOfExecution.Properties.FieldName = "ModeOfExecution";
            this.ModeOfExecution.Properties.RowEdit = this.repositoryItemComboBoxModeOfExecution;
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
                this.repositoryItemAMC,
                this.repositoryItemTextEditFolioNumber,
                this.repositoryItemOldBank,
                this.repositoryItemTextEditOldBankNumber,
                this.repositoryItemNewBank,
                this.repositoryItemTextEditNewBankNumber,
                this.repositoryItemComboBoxModeOfExecution
            });

            this.vGridTransaction.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
                this.ARN,
                this.ClientGroup,
                this.MemberName,               
                this.AMC,
                this.FolioNumber,
                this.OldBankName,
                this.OldBankAccountNumber,
                this.NewBankName,
                this.NewBankAccountNumber,
                this.ModeOfExecution});
            prepareOptionalFieldsList();
        }

        private void prepareOptionalFieldsList()
        {            
        }

        private void loadBanks()
        {
            BankInfo bankInfo = new BankInfo();
            banks = bankInfo.GetAll();
            DataTable dtBank = getBankTable();
            repositoryItemOldBank.DataSource = dtBank;
            repositoryItemOldBank.DisplayMember = "Name";
            repositoryItemOldBank.ValueMember = "Id";
            repositoryItemOldBank.NullValuePrompt = "Please select valid value.";
            //repositoryItemOldBank.Columns["Id"].Visible = false;

            repositoryItemNewBank.DataSource = dtBank;
            repositoryItemNewBank.DisplayMember = "Name";
            repositoryItemNewBank.ValueMember = "Id";
            repositoryItemNewBank.NullValuePrompt = "Please select valid value.";
        }

        private DataTable getBankTable()
        {
            DataTable dtBank = new DataTable();
            dtBank.Columns.Add("Id", typeof(System.Int64));
            dtBank.Columns.Add("Name", typeof(System.String));
            dtBank.Columns.Add("Branch", typeof(System.String));
            dtBank.Columns.Add("IFSC", typeof(System.String));
            dtBank.Columns.Add("MICR", typeof(System.String));
            foreach (Bank bank in banks)
            {
                DataRow dr = dtBank.NewRow();
                dr["Id"] = bank.Id;
                dr["Name"] = bank.Name;
                dr["Branch"] = bank.Branch;
                dr["IFSC"] = bank.IFSC;
                dr["MICR"] = bank.MICR;
                dtBank.Rows.Add(dr);
            }
            return dtBank;
        }

        internal void loadClients()
        {
            ClientService clientService = new ClientService();
            clients = clientService.GetAll();
            repositoryItemComboBoxClientGroup.Items.Clear();
            foreach (Client client in clients)
            {
                repositoryItemComboBoxClientGroup.Items.Add(client.Name);
            }
        }

        private void RepositoryItemAMC_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit comboBoxEdit = (DevExpress.XtraEditors.LookUpEdit)sender;
            if (comboBoxEdit.SelectedText != null)
            {
                AMC amcobject = ((List<AMC>)amcs).Find(i => i.Name == comboBoxEdit.Text.ToString());
                //loadScheme(amcobject.Id);
            }
        }
        private void RepositoryItemComboBoxClientGroup_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit = (DevExpress.XtraEditors.ComboBoxEdit)sender;
            e.Cancel = string.IsNullOrEmpty(comboBoxEdit.Text);
        }
        
        internal void loadMembers()
        {
            if (this.currentClient == null)
                return;

            repositoryItemComboBoxMemberName.Items.Clear();
            new PlannerInfo.FamilyMemberInfo().FillFamilyMemberInCombo(this.currentClient.ID, repositoryItemComboBoxMemberName);
        }

        internal void loadAMC()
        {
            AMCInfo aMCInfo = new AMCInfo();
            amcs = aMCInfo.GetAll();
            DataTable dtAMC = getAMCTable();
            repositoryItemAMC.DataSource = dtAMC;
            repositoryItemAMC.DisplayMember = "Name";
            repositoryItemAMC.ValueMember = "Id";
            repositoryItemAMC.NullValuePrompt = "Please select valid value.";
        }
        private DataTable getAMCTable()
        {
            DataTable dtAMC = new DataTable();
            dtAMC.Columns.Add("Id", typeof(System.Int64));
            dtAMC.Columns.Add("Name", typeof(System.String));
            foreach (AMC amc in amcs)
            {
                DataRow dr = dtAMC.NewRow();
                dr["Id"] = amc.Id;
                dr["Name"] = amc.Name;
                dtAMC.Rows.Add(dr);
            }
            return dtAMC;
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

        private void RepositoryItemARN_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit lookUpEdit = (DevExpress.XtraEditors.LookUpEdit)sender;
            e.Cancel = string.IsNullOrEmpty(lookUpEdit.Text);
        }

        internal void loadARNValue()
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

        public void BindDataSource(object obj)
        {
            if (obj == null)
            {
                LogDebug("BankChangeRequest.BindDataSource()", new ArgumentNullException("object value is null"));
                return;
            }

            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();

            freshPurchase = jsonSerialization.DeserializeFromString<BankChangeRequest>(obj.ToString());
            this.vGridTransaction.Rows["ARN"].Properties.Value = freshPurchase.Arn;

            this.vGridTransaction.Rows["ClientGroup"].Properties.Value = getClientName(freshPurchase.Cid);
            this.currentClient = ((List<Client>)clients).Find(i => i.Name == this.vGridTransaction.Rows["ClientGroup"].Properties.Value.ToString());
            loadMembers();
            this.vGridTransaction.Rows["MemberName"].Properties.Value = freshPurchase.MemberName;            
            this.vGridTransaction.Rows["FolioNumber"].Properties.Value = freshPurchase.FolioNumber;
            this.vGridTransaction.Rows["AMC"].Properties.Value = freshPurchase.Amc;
            repositoryItemAMC.GetDisplayValueByKeyValue(freshPurchase.Amc);

            this.vGridTransaction.Rows["OldBank"].Properties.Value = freshPurchase.OldBankId;
            this.vGridTransaction.Rows["OldBankAccountNo"].Properties.Value = freshPurchase.OldBankAcNo;

            this.vGridTransaction.Rows["NewBank"].Properties.Value = freshPurchase.NewBankId;
            this.vGridTransaction.Rows["NewBankAccountNo"].Properties.Value = freshPurchase.NewBankAcNo;

            this.vGridTransaction.Rows["ModeOfExecution"].Properties.Value = freshPurchase.ModeOfExecution;
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

        public object GetTransactionType()
        {
            BankChangeRequest bankChangeRequest = new BankChangeRequest();
            if (this.vGridTransaction.Rows.Count > 0)
            {
                bankChangeRequest.Arn = int.Parse(this.vGridTransaction.Rows["ARN"].Properties.Value.ToString());
                bankChangeRequest.Cid = this.currentClient.ID;
                bankChangeRequest.ClientGroup = this.vGridTransaction.Rows["ClientGroup"].Properties.Value.ToString();
                bankChangeRequest.MemberName = this.vGridTransaction.Rows["MemberName"].Properties.Value.ToString();
                
                bankChangeRequest.Amc = int.Parse(this.vGridTransaction.Rows["AMC"].Properties.Value.ToString());
                bankChangeRequest.FolioNumber = this.vGridTransaction.Rows["FolioNumber"].Properties.Value.ToString();

                bankChangeRequest.OldBankId = int.Parse(this.vGridTransaction.Rows["OldBank"].Properties.Value.ToString());
                bankChangeRequest.OldBankAcNo = this.vGridTransaction.Rows["OldBankAccountNo"].Properties.Value.ToString();

                bankChangeRequest.NewBankId = int.Parse(this.vGridTransaction.Rows["NewBank"].Properties.Value.ToString());
                bankChangeRequest.NewBankAcNo = this.vGridTransaction.Rows["NewBankAccountNo"].Properties.Value.ToString();
                bankChangeRequest.ModeOfExecution = this.vGridTransaction.Rows["ModeOfExecution"].Properties.Value.ToString();

            }
            return bankChangeRequest;
        }

        public bool IsAllRequireInputAvailable()
        {            
            return true;
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
        private void LogDebug(string name, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = name;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }

        private string getClientName(int cid)
        {
            Client client = new Client();
            return (clients.TryGetValue(clients.FindIndex(i => i.ID == cid), out client)) ? client.Name : string.Empty;
        }

        public void SetARN(int arnNo)
        {
            //this.vGridTransaction.Rows["ARN"].Properties.Value = arnNo;
        }
    }
}
