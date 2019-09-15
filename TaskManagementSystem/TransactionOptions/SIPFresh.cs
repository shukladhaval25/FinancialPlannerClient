using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraVerticalGrid;
using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.TaskManagement.MFTransactions;
using FinancialPlannerClient.Clients;
using FinancialPlannerClient.Master.TaskMaster;

namespace FinancialPlannerClient.TaskManagementSystem.TransactionOptions
{
    public class SIPFresh : ITransactionType
    {
        internal IList<Client> clients;
        internal IList<AMC> amcs;
        internal IList<Scheme> schemes;
        internal Client currentClient;
        internal int selectedSchemeId;
        List<string> optionalFields = new List<string>();
        readonly string GRID_NAME = "vGridSIPFresh";
        SIP sip;
        DevExpress.XtraVerticalGrid.VGridControl vGridTransaction;


        private DevExpress.XtraVerticalGrid.Rows.EditorRow ClientGroup;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow MemberName;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow SecondHolder;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow ThirdHolder;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Nominee;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Guardian;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow AMC;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow FolioNumber;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Scheme;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Options;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Amount;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow AccountType;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow SIPDate;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow TransactionDate;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow SIPStartDate;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow SIPEndDate;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow ModeOfExecution;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Remark;


        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxClientGroup;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxMemberName;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxSecondHolder;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxThirdHolder;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditNominee;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditGuardian;
        public DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemAMC;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditFolioNumber;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxScheme;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxOption;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditAmount;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxAccountType;
        public DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit repositoryItemSpinEditSIPDate;
        public DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEditTransactionDate;
        public DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEditSIPStartDate;
        public DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEditSIPEndDate;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxModeOfExecution;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditRemark;



        private void InitializeComponent()
        {
            if (this.vGridTransaction == null)
                return;

            this.ClientGroup = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.MemberName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.SecondHolder = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.ThirdHolder = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Nominee = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Guardian = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.AMC = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.FolioNumber = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Scheme = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Options = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Amount = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.AccountType = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.SIPDate = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.TransactionDate = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.SIPStartDate = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.SIPEndDate = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.ModeOfExecution = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Remark = new DevExpress.XtraVerticalGrid.Rows.EditorRow();

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

            this.repositoryItemComboBoxAccountType = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxAccountType.Items.AddRange(new string[] { "Saving Account", "Current Account"});
            this.repositoryItemComboBoxAccountType.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            this.repositoryItemSpinEditSIPDate = new DevExpress.XtraEditors.Repository.RepositoryItemSpinEdit();
            this.repositoryItemSpinEditSIPDate.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.Standard;


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

            this.repositoryItemDateEditTransactionDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryItemDateEditSIPStartDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repositoryItemDateEditSIPEndDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();

            //this.repositoryItemComboBoxAssignTo = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            //this.repositoryItemComboBoxAssignTo.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            this.repositoryItemComboBoxModeOfExecution = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxModeOfExecution.Items.AddRange(new string[] { "BSE", "AMC App", "Physical" });
            this.repositoryItemComboBoxModeOfExecution.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            this.repositoryItemTextEditRemark = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
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
            // Account Type
            //
            this.AccountType.Name = "AccountType";
            this.AccountType.Properties.Caption = "Account Type";
            this.AccountType.Properties.FieldName = "AccountType";
            this.AccountType.Properties.RowEdit = this.repositoryItemComboBoxAccountType;
            //
            // SIP Date
            //
            this.SIPDate.Name = "SIPDate";
            this.SIPDate.Properties.Caption = "SIP Date";
            this.SIPDate.Properties.FieldName = "SIPDate";            
            this.SIPDate.Properties.RowEdit = this.repositoryItemSpinEditSIPDate;
            //
            // Transaction Date
            //
            this.TransactionDate.Name = "TransactionDate";
            this.TransactionDate.Properties.Caption = "Transaction Date";
            this.TransactionDate.Properties.FieldName = "TransactionDate";
            this.TransactionDate.Properties.Format.FormatString = string.Format("dd/MM/yyyy");
            this.TransactionDate.Properties.RowEdit = this.repositoryItemDateEditTransactionDate;
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
                this.repositoryItemComboBoxClientGroup,
                this.repositoryItemComboBoxMemberName,
                this.repositoryItemComboBoxSecondHolder,
                this.repositoryItemComboBoxThirdHolder,
                this.repositoryItemTextEditNominee,
                this.repositoryItemTextEditGuardian,
                this.repositoryItemAMC,
                this.repositoryItemTextEditFolioNumber,
                this.repositoryItemComboBoxScheme,
                this.repositoryItemComboBoxOption,
                this.repositoryItemTextEditAmount,
                this.repositoryItemComboBoxAccountType,
                this.repositoryItemSpinEditSIPDate,
                this.repositoryItemDateEditTransactionDate,
                this.repositoryItemDateEditSIPStartDate,
                this.repositoryItemDateEditSIPEndDate,
                this.repositoryItemComboBoxModeOfExecution,
                this.repositoryItemTextEditRemark
                });

            this.vGridTransaction.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
                this.ClientGroup,
                this.MemberName,
                this.SecondHolder,
                this.ThirdHolder,
                this.Nominee,
                this.Guardian,
                this.AMC,
                this.FolioNumber,
                this.Scheme,
                this.Options,
                this.Amount,
                this.AccountType,
                this.SIPDate,
                this.TransactionDate,
                this.SIPStartDate,
                this.SIPEndDate,
                this.ModeOfExecution,
                this.Remark});
            prepareOptionalFieldsList();
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
            this.optionalFields.Add(this.SecondHolder.Properties.FieldName);
            this.optionalFields.Add(this.ThirdHolder.Properties.FieldName);
            this.optionalFields.Add(this.Nominee.Properties.FieldName);
            this.optionalFields.Add(this.Guardian.Properties.FieldName);
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
            repositoryItemComboBoxSecondHolder.Items.Clear();
            repositoryItemComboBoxThirdHolder.Items.Clear();

            new PlannerInfo.FamilyMemberInfo().FillFamilyMemberInCombo(this.currentClient.ID, repositoryItemComboBoxMemberName);
            repositoryItemComboBoxSecondHolder.Items.AddRange(repositoryItemComboBoxMemberName.Items);
            repositoryItemComboBoxThirdHolder.Items.AddRange(repositoryItemComboBoxMemberName.Items);
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

            sip  = jsonSerialization.DeserializeFromString<SIP>(obj.ToString());
            this.vGridTransaction.Rows["AccountType"].Properties.Value = sip.AccounType;
            this.vGridTransaction.Rows["ClientGroup"].Properties.Value = getClientName(sip.CID); this.currentClient = ((List<Client>)clients).Find(i => i.Name == this.vGridTransaction.Rows["ClientGroup"].Properties.Value.ToString());
            loadMembers();

            this.vGridTransaction.Rows["MemberName"].Properties.Value = sip.MemberName;
            this.vGridTransaction.Rows["SecondHolder"].Properties.Value = sip.SecondHolder;
            this.vGridTransaction.Rows["ThirdHolder"].Properties.Value = sip.ThirdHolder;
            this.vGridTransaction.Rows["Nominee"].Properties.Value = sip.Nominee;
            this.vGridTransaction.Rows["Guardian"].Properties.Value = sip.Guardian;

            this.vGridTransaction.Rows["FolioNumber"].Properties.Value = sip.FolioNo;
            this.vGridTransaction.Rows["AMC"].Properties.Value = sip.AMC;
            repositoryItemAMC.GetDisplayValueByKeyValue(sip.AMC);
            loadScheme(sip.AMC);
            this.vGridTransaction.Rows["Scheme"].Properties.Value = getSchemeName(sip.SchemeId);
            selectedSchemeId = sip.SchemeId;
            this.vGridTransaction.Rows["SIPDate"].Properties.Value = sip.SIPDayOn;
            this.vGridTransaction.Rows["SIPStartDate"].Properties.Value = sip.SIPStartDate;
            this.vGridTransaction.Rows["SIPEndDate"].Properties.Value = sip.SIPEndDate;
            this.vGridTransaction.Rows["Option"].Properties.Value = sip.Option;
            this.vGridTransaction.Rows["Amount"].Properties.Value = sip.Amount;
            this.vGridTransaction.Rows["TransactionDate"].Properties.Value = sip.TransactionDate;
            this.vGridTransaction.Rows["ModeOfExecution"].Properties.Value = sip.ModeOfExecution;
            this.vGridTransaction.Rows["Remark"].Properties.Value = sip.Remark;
        }

        internal string getClientName(int cid)
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
            throw new NotImplementedException();
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
            sip = new  SIP();
            if (this.vGridTransaction.Rows.Count > 0)
            {
                sip.CID = this.currentClient.ID;
                sip.MemberName = this.vGridTransaction.Rows["MemberName"].Properties.Value.ToString();
                sip.SecondHolder = (this.vGridTransaction.Rows["SecondHolder"].Properties.Value != null) ?
                    this.vGridTransaction.Rows["SecondHolder"].Properties.Value.ToString() : string.Empty;

                sip.ThirdHolder = (this.vGridTransaction.Rows["ThirdHolder"].Properties.Value != null) ?
                    this.vGridTransaction.Rows["ThirdHolder"].Properties.Value.ToString() : string.Empty;

                sip.Nominee = (this.vGridTransaction.Rows["Nominee"].Properties.Value != null) ?
                    this.vGridTransaction.Rows["Nominee"].Properties.Value.ToString() : string.Empty;

                sip.Guardian = (this.vGridTransaction.Rows["Guardian"].Properties.Value != null) ?
                this.vGridTransaction.Rows["Guardian"].Properties.Value.ToString() : string.Empty;

                sip.AMC = int.Parse(this.vGridTransaction.Rows["AMC"].Properties.Value.ToString());
                sip.FolioNo = this.vGridTransaction.Rows["FolioNumber"].Properties.Value.ToString();
                sip.SchemeId = selectedSchemeId;
                sip.Option = this.vGridTransaction.Rows["Option"].Properties.Value.ToString();
                sip.Amount = double.Parse(this.vGridTransaction.Rows["Amount"].Properties.Value.ToString());
                sip.AccounType = this.vGridTransaction.Rows["AccountType"].Properties.Value.ToString();
                sip.SIPDayOn = int.Parse(this.vGridTransaction.Rows["SIPDate"].Properties.Value.ToString());
                sip.TransactionDate = (DateTime)this.vGridTransaction.Rows["TransactionDate"].Properties.Value;
                sip.SIPStartDate = (DateTime)this.vGridTransaction.Rows["SIPStartDate"].Properties.Value;
                sip.SIPEndDate = (DateTime)this.vGridTransaction.Rows["SIPEndDate"].Properties.Value;
                sip.ModeOfExecution = this.vGridTransaction.Rows["ModeOfExecution"].Properties.Value.ToString();
                sip.Remark = (this.vGridTransaction.Rows["Remark"].Properties.Value != null) ?
                    this.vGridTransaction.Rows["Remark"].Properties.Value.ToString() : string.Empty;
            }
            return sip;
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
    }
}
