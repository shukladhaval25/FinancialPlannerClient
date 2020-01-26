using System;
using System.Collections.Generic;
using System.Data;
using DevExpress.XtraVerticalGrid;
using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.Masters;
using FinancialPlanner.Common.Model.TaskManagement.MFTransactions;
using FinancialPlannerClient.Clients;
using FinancialPlannerClient.Master.TaskMaster;

namespace FinancialPlannerClient.TaskManagementSystem.TransactionOptions
{
    class SIPCancellationTrans : ITransactionType
    {
        IList<ARN> arns;
        IList<Bank> banks;
        internal IList<Client> clients;
        internal IList<AMC> amcs;
        internal IList<Scheme> schemes;
        internal Client currentClient;
        internal int selectedSchemeId;
        List<string> optionalFields = new List<string>();
        readonly string GRID_NAME = "vGridSIPCancellation";
        SIPCancellation sipCancellation;
        DevExpress.XtraVerticalGrid.VGridControl vGridTransaction;

        private DevExpress.XtraVerticalGrid.Rows.EditorRow ARN;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow ClientGroup;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow MemberName;        
        private DevExpress.XtraVerticalGrid.Rows.EditorRow AMC;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow FolioNumber;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Scheme;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Options;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Amount;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow SIPStartDate;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow SIPEndDate;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow SIPDate;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow BankName;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow AccountNo;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow ModeOfExecution;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Remark;

        public DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemARN;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxClientGroup;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxMemberName;
        public DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemAMC;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditFolioNumber;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxScheme;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxOption;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditAmount;
        public DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEditSIPStartDate;
        public DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEditSIPEndDate;
        public DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEditSIPDate;
        public DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemComboBoxBankName;        
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditAccountNumber;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxModeOfExecution;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditRemark;


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
            this.SIPStartDate = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.SIPEndDate = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.SIPDate = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.BankName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.AccountNo = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
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

            this.repositoryItemAMC = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemAMC.EditValueChanged += RepositoryItemAMC_EditValueChanged; ;
            loadAMC();

            this.repositoryItemTextEditFolioNumber = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();

            this.repositoryItemComboBoxScheme = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxScheme.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.repositoryItemComboBoxScheme.EditValueChanged += RepositoryItemComboBoxScheme_EditValueChanged;
            loadScheme();

            this.repositoryItemComboBoxOption = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxOption.Items.AddRange(new string[] { "GR", "WDR", "DD" });
            this.repositoryItemComboBoxOption.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            this.repositoryItemTextEditAmount = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEditAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEditAmount.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEditAmount.Validating += RepositoryItemTextEditAmount_Validating;


            this.repositoryItemDateEditSIPStartDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryItemDateEditSIPEndDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();

            this.repositoryItemSpinEditSIPDate = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.repositoryItemSpinEditSIPDate.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;

            //this.repositoryItemComboBoxAccountType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            //this.repositoryItemComboBoxAccountType.Items.AddRange(new string[] { "Saving Account", "Current Account" });
            //this.repositoryItemComboBoxAccountType.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                       
            this.repositoryItemSpinEditSIPDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemSpinEditSIPDate.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemSpinEditSIPDate.Mask.EditMask = "N00";
            this.repositoryItemSpinEditSIPDate.MaxValue = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.repositoryItemSpinEditSIPDate.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.repositoryItemSpinEditSIPDate.Name = "repositoryItemSpinEdit1";
            this.repositoryItemSpinEditSIPDate.ValidateOnEnterKey = true;

            this.repositoryItemComboBoxBankName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemComboBoxBankName.EditValueChanged += repositoryItemComboBoxBankName_EditValueChanged; ;
            loadBank();

            this.repositoryItemTextEditAccountNumber = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
           
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
            // SIP Start Date
            //
            this.SIPStartDate.Name = "SIPStartDate";
            this.SIPStartDate.Properties.Caption = "SIP Start Date";
            this.SIPStartDate.Properties.FieldName = "SIPStartDate";
            this.SIPStartDate.Properties.Format.FormatString = string.Format("dd/MM/yyyy");
            this.SIPStartDate.Properties.RowEdit = this.repositoryItemDateEditSIPStartDate;
            //
            // SIP End Date
            //
            this.SIPEndDate.Name = "SIPEndDate";
            this.SIPEndDate.Properties.Caption = "SIP EndDate";
            this.SIPEndDate.Properties.FieldName = "SIPEndDate";
            this.SIPEndDate.Properties.Format.FormatString = string.Format("dd/MM/yyyy");
            this.SIPEndDate.Properties.RowEdit = this.repositoryItemDateEditSIPEndDate;
            //
            // SIP Date
            //
            this.SIPDate.Name = "SIPDate";
            this.SIPDate.Properties.Caption = "SIP Date";
            this.SIPDate.Properties.FieldName = "SIPDate";
            this.SIPDate.Properties.RowEdit = this.repositoryItemSpinEditSIPDate;
            //
            // Bank
            //
            this.BankName.Name = "Bank";
            this.BankName.Properties.Caption = "Bank";
            this.BankName.Properties.FieldName = "BankName";
            this.BankName.Properties.RowEdit = this.repositoryItemComboBoxBankName;
            //
            // Account Number
            //
            this.AccountNo.Name = "AccountNumber";
            this.AccountNo.Properties.Caption = "AccountNo";
            this.AccountNo.Properties.FieldName = "AccountNo";
            this.AccountNo.Properties.RowEdit = this.repositoryItemTextEditAccountNumber;
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
                this.repositoryItemAMC,
                this.repositoryItemTextEditFolioNumber,
                this.repositoryItemComboBoxScheme,
                this.repositoryItemComboBoxOption,
                this.repositoryItemTextEditAmount,
                this.repositoryItemDateEditSIPStartDate,
                this.repositoryItemDateEditSIPEndDate,
                this.repositoryItemSpinEditSIPDate,
                this.repositoryItemComboBoxBankName,
                this.repositoryItemTextEditAccountNumber,                
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
                this.SIPStartDate,
                this.SIPEndDate,
                this.SIPDate,
                this.BankName,
                this.AccountNo,
                this.ModeOfExecution,
                this.Remark});
            prepareOptionalFieldsList();
        }

        private void loadBank()
        {
            BankInfo bankInfo = new BankInfo();
            banks = bankInfo.GetAll();
            DataTable dtBank = getBankTable();
            repositoryItemComboBoxBankName.DataSource = dtBank;
            repositoryItemComboBoxBankName.DisplayMember = "Name";
            repositoryItemComboBoxBankName.ValueMember = "ID";
            repositoryItemComboBoxBankName.NullValuePrompt = "Please select valid value.";
        }

        private void repositoryItemComboBoxBankName_EditValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void loadAMC()
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

        private void prepareOptionalFieldsList()
        {            
            this.optionalFields.Add(this.Remark.Properties.FieldName);
        }

        internal void loadScheme()
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
            DevExpress.XtraEditors.TextEdit textEdit = (DevExpress.XtraEditors.TextEdit)sender;
            e.Cancel = !FinancialPlanner.Common.Validation.IsDecimal(textEdit.Text);
        }

        internal void loadMembers()
        {
            if (this.currentClient == null)
                return;

            repositoryItemComboBoxMemberName.Items.Clear();            
            new PlannerInfo.FamilyMemberInfo().FillFamilyMemberInCombo(this.currentClient.ID, repositoryItemComboBoxMemberName);            
        }

        private void loadClients()
        {
            ClientService clientService = new ClientService();
            clients = clientService.GetAll();
            repositoryItemComboBoxClientGroup.Items.Clear();
            foreach (Client client in clients)
            {
                repositoryItemComboBoxClientGroup.Items.Add(client.Name);
            }
        }

        public void BindDataSource(Object obj)
        {
            if (obj == null)
            {
                LogDebug("SIPFresh.BindDataSource()", new ArgumentNullException("object value is null"));
                return;
            }

            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();

            sipCancellation = jsonSerialization.DeserializeFromString<SIPCancellation>(obj.ToString());

            this.vGridTransaction.Rows["ARN"].Properties.Value = sipCancellation.Arn;
            this.vGridTransaction.Rows["ClientGroup"].Properties.Value = this.currentClient.Name;
            this.currentClient = ((List<Client>)clients).Find(i => i.Name == this.vGridTransaction.Rows["ClientGroup"].Properties.Value.ToString());
            loadMembers();

            this.vGridTransaction.Rows["MemberName"].Properties.Value = sipCancellation.MemberName;           

            this.vGridTransaction.Rows["FolioNumber"].Properties.Value = sipCancellation.FolioNumber;
            this.vGridTransaction.Rows["AMC"].Properties.Value = sipCancellation.Amc;
            repositoryItemAMC.GetDisplayValueByKeyValue(sipCancellation.Amc);
            loadScheme(sipCancellation.Amc);
            this.vGridTransaction.Rows["Scheme"].Properties.Value = getSchemeName(sipCancellation.SchemeId);
            selectedSchemeId = sipCancellation.SchemeId;
            this.vGridTransaction.Rows["SIPDate"].Properties.Value = sipCancellation.SipDate;
            this.vGridTransaction.Rows["SIPStartDate"].Properties.Value = sipCancellation.SipStartDate;
            this.vGridTransaction.Rows["SIPEndDate"].Properties.Value = sipCancellation.SipEndDate;
            this.vGridTransaction.Rows["Option"].Properties.Value = sipCancellation.Options;
            this.vGridTransaction.Rows["Amount"].Properties.Value = sipCancellation.Amount;
            this.vGridTransaction.Rows["Bank"].Properties.Value = sipCancellation.BankId;
            this.vGridTransaction.Rows["AccountNumber"].Properties.Value = sipCancellation.AccountNo;
            this.vGridTransaction.Rows["ModeOfExecution"].Properties.Value = sipCancellation.ModeOfExecution;
            this.vGridTransaction.Rows["Remark"].Properties.Value = sipCancellation.Remark;
        }


        internal string getSchemeName(int schemeId)
        {
            Scheme scheme = new Scheme();
            return (schemes.TryGetValue(schemes.FindIndex(i => i.Id == schemeId), out scheme)) ? scheme.Name : string.Empty;
        }

        public VGridControl GetGridControl()
        {
            throw new NotImplementedException();
        }

        public void setVGridControl(VGridControl vGrid,Client client)
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
            this.currentClient = client;
            this.vGridTransaction.Rows["ClientGroup"].Properties.Value = this.currentClient.Name;            
            this.vGridTransaction.Refresh();
            loadMembers();
        }

        public object GetTransactionType()
        {
            sipCancellation = new SIPCancellation();
            if (this.vGridTransaction.Rows.Count > 0)
            {
                sipCancellation.Cid = this.currentClient.ID;
                sipCancellation.MemberName = this.vGridTransaction.Rows["MemberName"].Properties.Value.ToString();

                sipCancellation.Arn = int.Parse(this.vGridTransaction.Rows["ARN"].Properties.Value.ToString());
                sipCancellation.Amc = int.Parse(this.vGridTransaction.Rows["AMC"].Properties.Value.ToString());
                sipCancellation.FolioNumber = this.vGridTransaction.Rows["FolioNumber"].Properties.Value.ToString();
                sipCancellation.SchemeId = selectedSchemeId;
                sipCancellation.Options = this.vGridTransaction.Rows["Option"].Properties.Value.ToString();
                sipCancellation.Amount = double.Parse(this.vGridTransaction.Rows["Amount"].Properties.Value.ToString());
                
                sipCancellation.SipStartDate = (DateTime)this.vGridTransaction.Rows["SIPStartDate"].Properties.Value;
                sipCancellation.SipEndDate = (DateTime)this.vGridTransaction.Rows["SIPEndDate"].Properties.Value;
                sipCancellation.SipDate = int.Parse(this.vGridTransaction.Rows["SIPDate"].Properties.Value.ToString());
                try
                {
                    sipCancellation.BankId = int.Parse(this.vGridTransaction.Rows["Bank"].Properties.Value.ToString());
                    sipCancellation.AccountNo = this.vGridTransaction.Rows["AccountNumber"].Properties.Value.ToString();
                }
                catch (Exception ex)
                {
                    Logger.LogDebug(ex.ToString());
                }
                sipCancellation.ModeOfExecution = this.vGridTransaction.Rows["ModeOfExecution"].Properties.Value.ToString();
                sipCancellation.Remark = (this.vGridTransaction.Rows["Remark"].Properties.Value != null) ?
                    this.vGridTransaction.Rows["Remark"].Properties.Value.ToString() : string.Empty;
            }
            return sipCancellation;
        }

        private void RepositoryItemComboBoxScheme_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit = (DevExpress.XtraEditors.ComboBoxEdit)sender;
            if (comboBoxEdit.SelectedItem != null)
            {
                Scheme scheme = ((List<Scheme>)schemes).Find(i => i.Name == comboBoxEdit.SelectedItem.ToString());
                selectedSchemeId = scheme.Id;
            }
        }

        public bool IsAllRequireInputAvailable()
        {
            for (int rowIndex = 0; rowIndex < this.vGridTransaction.Rows.Count; rowIndex++)
            {
                if (!optionalFields.Contains(this.vGridTransaction.Rows[rowIndex].Properties.FieldName) &&
                   this.vGridTransaction.Rows[rowIndex].Properties.Value == null)
                {
                    return false;
                }
            }
            return true;
        }
        private void RepositoryItemAMC_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit comboBoxEdit = (DevExpress.XtraEditors.LookUpEdit)sender;
            if (comboBoxEdit.SelectedText != null)
            {
                AMC amcobject = ((List<AMC>)amcs).Find(i => i.Name == comboBoxEdit.Text.ToString());
                loadScheme(amcobject.Id);
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
        private void LogDebug(string name, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = name;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
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

        private DataTable getBankTable()
        {
            DataTable dtBank = new DataTable();
            dtBank.Columns.Add("ID", typeof(System.Int64));
            dtBank.Columns.Add("Name", typeof(System.String));
            dtBank.Columns.Add("Branch", typeof(System.String));
            foreach (Bank bank in banks)
            {
                DataRow dr = dtBank.NewRow();
                dr["ID"] = bank.Id;
                dr["Name"] = bank.Name;
                dr["Branch"] = bank.Branch;
                dtBank.Rows.Add(dr);
            }
            return dtBank;
        }

        public void SetARN(int arnNo)
        {
            this.vGridTransaction.Rows["ARN"].Properties.Value = arnNo;
        }
    }
}
