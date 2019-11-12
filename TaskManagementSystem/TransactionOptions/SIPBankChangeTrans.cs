using DevExpress.Utils;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Events;
using DevExpress.XtraVerticalGrid.Rows;
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
    public class SIPBankChangeTrans : ITransactionType
    {
        internal IList<ARN> arns;
        internal IList<AMC> amcs;
        internal IList<Client> clients;
        internal IList<Scheme> schemes;
        internal Client currentClient;
        internal int selectedSchemeId;
        internal IList<Bank> banks;
        List<string> optionalFields = new List<string>();
        FinancialPlanner.Common.Model.TaskManagement.MFTransactions.SIPBankChange sipBankChange;


        readonly string GRID_NAME = "vGridSIPBankChange";
        DevExpress.XtraVerticalGrid.VGridControl vGridTransaction;


        private DevExpress.XtraVerticalGrid.Rows.EditorRow ARN;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow ClientGroup;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow MemberName;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow AMC;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow FolioNumber;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Scheme;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Options;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Amount;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow NewBank;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow NewBankAccountNo;
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
        public DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemAMC;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditFolioNumber;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxScheme;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxOption;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditAmount;
        public DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemNewBank;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditNewBankAccountNo;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxModeOfExecution;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditRemark;


        #region "Private"
        private void InitializeComponent()
        {
            if (this.vGridTransaction == null)
                return;

            this.ARN = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.ClientGroup = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.MemberName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.AMC = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.FolioNumber = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Scheme = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Options = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Amount = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.NewBank = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.NewBankAccountNo = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.ModeOfExecution = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Remark = new DevExpress.XtraVerticalGrid.Rows.EditorRow();

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

            this.repositoryItemComboBoxModeOfHolding = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxModeOfHolding.Items.AddRange(new string[] { "Joint", "Either or survivor", "Single" });
            this.repositoryItemComboBoxModeOfHolding.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            
            this.repositoryItemAMC = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemAMC.EditValueChanged += RepositoryItemAMC_EditValueChanged;
            loadAMC();

            this.repositoryItemTextEditFolioNumber = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();

            this.repositoryItemComboBoxScheme = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxScheme.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.repositoryItemComboBoxScheme.EditValueChanged += RepositoryItemComboBoxScheme_EditValueChanged;

            this.repositoryItemComboBoxOption = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();

            this.repositoryItemComboBoxOption.Items.AddRange(new string[] { "GR", "WDR", "DD" });
            this.repositoryItemComboBoxOption.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            this.repositoryItemTextEditAmount = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEditAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEditAmount.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEditAmount.Validating += RepositoryItemTextEditAmount_Validating;

            this.repositoryItemNewBank = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemNewBank.Validating += RepositoryItemNewBank_Validating;
            loadBanks();
            this.repositoryItemTextEditNewBankAccountNo = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();

            this.repositoryItemComboBoxModeOfExecution = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxModeOfExecution.Items.AddRange(new string[] { "BSE", "AMC App", "Physical" });
            this.repositoryItemComboBoxModeOfExecution.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            this.repositoryItemTextEditRemark = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            // 
            // ARN
            // 
            this.ARN.Name = "ARN";
            this.ARN.Properties.Caption = "ARN";
            this.ARN.Properties.FieldName = "ARN";
            this.ARN.Properties.RowEdit = this.repositoryItemARN;
            this.ARN.Properties.ReadOnly = true;
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
            // NewBank
            //
            this.NewBank.Name = "NewBank";
            this.NewBank.Properties.Caption = "New Bank";
            this.NewBank.Properties.FieldName = "NewBankId";
            this.NewBank.Properties.RowEdit = this.repositoryItemNewBank;
            //
            // NewBank Account no
            //
            this.NewBankAccountNo.Name = "NewBankAccountNo";
            this.NewBankAccountNo.Properties.Caption = "New Bank A/c No";
            this.NewBankAccountNo.Properties.FieldName = "NewBankAccountNo";
            this.NewBankAccountNo.Properties.RowEdit = this.repositoryItemTextEditNewBankAccountNo;
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
            this.repositoryItemAMC,
            this.repositoryItemTextEditFolioNumber,
            this.repositoryItemComboBoxScheme,
            this.repositoryItemComboBoxOption,
            this.repositoryItemTextEditAmount,
            this.repositoryItemNewBank,
            this.repositoryItemTextEditNewBankAccountNo,
            this.repositoryItemComboBoxModeOfExecution,
            this.repositoryItemTextEditRemark
            });

            this.vGridTransaction.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
                this.ARN,
                this.ClientGroup,
                this.MemberName,
                this.AMC,
                this.FolioNumber,
                this.Scheme,
                this.Options,
                this.Amount,
                this.NewBank,
                this.NewBankAccountNo,
                this.ModeOfExecution,
                this.Remark});
            prepareOptionalFieldsList();

        }

        private void RepositoryItemNewBank_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit lookUpEdit = (DevExpress.XtraEditors.LookUpEdit)sender;
            e.Cancel = string.IsNullOrEmpty(lookUpEdit.Text);
        }

        private void loadBanks()
        {
            BankInfo bankInfo = new BankInfo();
            banks = bankInfo.GetAll();
            DataTable dtBank = getBankTable();            
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
        private void RepositoryItemAMC_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit  comboBoxEdit = (DevExpress.XtraEditors.LookUpEdit)sender;
            if (comboBoxEdit.SelectedText != null)
            {
                AMC amcobject = ((List<AMC>) amcs).Find(i => i.Name == comboBoxEdit.Text.ToString());
                loadScheme(amcobject.Id);
            }
        }

        private void RepositoryItemComboBoxClientGroup_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit = (DevExpress.XtraEditors.ComboBoxEdit)sender;
            e.Cancel = string.IsNullOrEmpty(comboBoxEdit.Text);
        }

        private void RepositoryItemARN_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit lookUpEdit = (DevExpress.XtraEditors.LookUpEdit)sender;
            e.Cancel = string.IsNullOrEmpty(lookUpEdit.Text);
        }

        private void prepareOptionalFieldsList()
        {
            this.optionalFields.Add(this.Remark.Properties.FieldName);
        }

        private void RepositoryItemComboBoxScheme_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit = (DevExpress.XtraEditors.ComboBoxEdit)sender;
            if (comboBoxEdit.SelectedItem != null)
            {
                Scheme scheme =  ((List<Scheme>) schemes).Find(i => i.Name == comboBoxEdit.SelectedItem.ToString());
                selectedSchemeId = scheme.Id;
            }
        }

        internal void loadScheme(int amcId)
        {
            SchemeInfo schemeInfo = new SchemeInfo();
            schemes = schemeInfo.GetAll(amcId);
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

        internal void loadMembers()
        {
            if (this.currentClient == null)
                return;

            repositoryItemComboBoxMemberName.Items.Clear();
           
            new PlannerInfo.FamilyMemberInfo().FillFamilyMemberInCombo(this.currentClient.ID, repositoryItemComboBoxMemberName);
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

        internal void loadClients()
        {
            ClientService clientService = new ClientService();
            clients = clientService.GetAll();
            repositoryItemComboBoxClientGroup.Items.Clear();
            foreach(Client client in clients)
            {
                repositoryItemComboBoxClientGroup.Items.Add(client.Name);
            }
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
        #endregion

        public void BindDataSource(Object obj)
        {
            if (obj == null)
            {
                LogDebug("SIPBankChange.BindDataSource()", new ArgumentNullException("object value is null"));
                return;
            }

            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();

            sipBankChange = jsonSerialization.DeserializeFromString<FinancialPlanner.Common.Model.TaskManagement.MFTransactions.SIPBankChange>(obj.ToString());
            this.vGridTransaction.Rows["ARN"].Properties.Value = sipBankChange.Arn;

            this.vGridTransaction.Rows["ClientGroup"].Properties.Value = getClientName(sipBankChange.Cid);
            this.currentClient = ((List<Client>)clients).Find(i => i.Name == this.vGridTransaction.Rows["ClientGroup"].Properties.Value.ToString());
            loadMembers();
            this.vGridTransaction.Rows["MemberName"].Properties.Value = sipBankChange.MemberName;

            this.vGridTransaction.Rows["FolioNumber"].Properties.Value = sipBankChange.FolioNumber;
            this.vGridTransaction.Rows["AMC"].Properties.Value = sipBankChange.Amc;
            repositoryItemAMC.GetDisplayValueByKeyValue(sipBankChange.Amc);
            loadScheme(sipBankChange.Amc);
            this.vGridTransaction.Rows["Scheme"].Properties.Value = getSchemeName(sipBankChange.Scheme);
            selectedSchemeId = sipBankChange.Scheme;
            this.vGridTransaction.Rows["Option"].Properties.Value = sipBankChange.Options;
            this.vGridTransaction.Rows["Amount"].Properties.Value = sipBankChange.Amount;
            this.vGridTransaction.Rows["NewBank"].Properties.Value = sipBankChange.NewBankId;
            this.vGridTransaction.Rows["NewBankAccountNo"].Properties.Value = sipBankChange.NewBankAccountNo;
            this.vGridTransaction.Rows["ModeOfExecution"].Properties.Value = sipBankChange.ModeOfExecution;
            this.vGridTransaction.Rows["Remark"].Properties.Value = sipBankChange.Remark;
        }

        private string getClientName(int cid)
        {
            Client client = new Client();
            return (clients.TryGetValue(clients.FindIndex(i => i.ID == cid), out client)) ? client.Name : string.Empty;
        }

        internal string getSchemeName(int schemeId)
        {
            Scheme scheme = new Scheme();
            return (schemes.TryGetValue(schemes.FindIndex(i => i.Id == schemeId), out scheme)) ? scheme.Name : string.Empty;
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

        public object GetTransactionType()
        {
            FinancialPlanner.Common.Model.TaskManagement.MFTransactions.SIPBankChange sIPBankChange = 
                new FinancialPlanner.Common.Model.TaskManagement.MFTransactions.SIPBankChange();
            if (this.vGridTransaction.Rows.Count > 0)
            {
                sIPBankChange.Arn = int.Parse(this.vGridTransaction.Rows["ARN"].Properties.Value.ToString());
                sIPBankChange.Cid = this.currentClient.ID;
                sIPBankChange.ClientGroup = this.vGridTransaction.Rows["ClientGroup"].Properties.Value.ToString();
                sIPBankChange.MemberName = this.vGridTransaction.Rows["MemberName"].Properties.Value.ToString();                
                sIPBankChange.Amc = int.Parse(this.vGridTransaction.Rows["AMC"].Properties.Value.ToString());
                sIPBankChange.FolioNumber = this.vGridTransaction.Rows["FolioNumber"].Properties.Value.ToString();
                sIPBankChange.Scheme = selectedSchemeId;
                sIPBankChange.Options = this.vGridTransaction.Rows["Option"].Properties.Value.ToString();
                sIPBankChange.Amount = double.Parse(this.vGridTransaction.Rows["Amount"].Properties.Value.ToString());
                sIPBankChange.NewBankId = int.Parse(this.vGridTransaction.Rows["NewBank"].Properties.Value.ToString());
                sIPBankChange.NewBankAccountNo = this.vGridTransaction.Rows["NewBankAccountNo"].Properties.Value.ToString();
                sIPBankChange.ModeOfExecution = this.vGridTransaction.Rows["ModeOfExecution"].Properties.Value.ToString();
                sIPBankChange.Remark = (this.vGridTransaction.Rows["Remark"].Properties.Value != null) ?
                    this.vGridTransaction.Rows["Remark"].Properties.Value.ToString() : string.Empty;
            }
            return sIPBankChange;
        }

        public bool IsAllRequireInputAvailable()
        {
            for(int rowIndex = 0; rowIndex < this.vGridTransaction.Rows.Count; rowIndex++)
            {
                if(!optionalFields.Contains(this.vGridTransaction.Rows[rowIndex].Properties.FieldName) && 
                   (this.vGridTransaction.Rows[rowIndex].Properties.Value == null || 
                   this.vGridTransaction.Rows[rowIndex].Properties.Value.ToString() == string.Empty ))
                {
                    return false;
                }
            }
            return true;
        }
        private void LogDebug(string name, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = name;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }

        public void SetARN(int arnNo)
        {
            this.vGridTransaction.Rows["ARN"].Properties.Value = arnNo;
        }
    }
}
