using DevExpress.Utils;
using DevExpress.XtraVerticalGrid;
using DevExpress.XtraVerticalGrid.Events;
using DevExpress.XtraVerticalGrid.Rows;
using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.TaskManagement.MFTransactions;
using FinancialPlannerClient.Clients;
using FinancialPlannerClient.Master.TaskMaster;
using System;
using System.Collections.Generic;
using System.Data;

namespace FinancialPlannerClient.TaskManagementSystem.TransactionOptions
{
    public class FreshPurchaseTrans : ITransactionType
    {
        internal IList<ARN> arns;
        internal IList<AMC> amcs;
        internal IList<Client> clients;
        internal IList<Scheme> schemes;
        internal Client currentClient;
        internal int selectedSchemeId;
        List<string> optionalFields = new List<string>();
        FinancialPlanner.Common.Model.TaskManagement.MFTransactions.FreshPurchase freshPurchase;


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
        public DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemAMC;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditFolioNumber;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxScheme;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxOption;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditAmount;
        public DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEditTransactionDate;
        //public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxAssignTo;
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
            this.ModeOfExecution = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Remark = new DevExpress.XtraVerticalGrid.Rows.EditorRow();

            this.repositoryItemARN = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            loadARNValue();
            this.repositoryItemARN.EditValueChanged += RepositoryItemARN_EditValueChanged;
            this.repositoryItemARN.Validating += RepositoryItemARN_Validating;  


            this.repositoryItemComboBoxClientGroup = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxClientGroup.EditValueChanged += RepositoryItemComboBoxClientGroup_SelectedValueChanged;
            this.repositoryItemComboBoxClientGroup.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            loadClients();
            this.repositoryItemComboBoxClientGroup.Validating += RepositoryItemComboBoxClientGroup_Validating;

            this.repositoryItemComboBoxMemberName = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxMemberName.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.repositoryItemComboBoxMemberName.Validating += RepositoryItemComboBoxClientGroup_Validating;

            this.repositoryItemComboBoxSecondHolder = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxSecondHolder.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            this.repositoryItemComboBoxThirdHolder = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxThirdHolder.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            this.repositoryItemTextEditNominee = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEditGuardian = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();

            this.repositoryItemComboBoxModeOfHolding = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxModeOfHolding.Items.AddRange(new string[] { "Joint", "Either or survivor", "Single" });
            this.repositoryItemComboBoxModeOfHolding.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            
            this.repositoryItemAMC = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.repositoryItemAMC.EditValueChanged += RepositoryItemAMC_EditValueChanged; ;
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

            this.repositoryItemDateEditTransactionDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();

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
            // Transaction Date
            //
            this.TransactionDate.Name = "TransactionDate";
            this.TransactionDate.Properties.Caption = "Transaction Date";
            this.TransactionDate.Properties.FieldName = "TransactionDate";
            this.TransactionDate.Properties.Format.FormatString = string.Format("dd/MM/yyyy");
            this.TransactionDate.Properties.RowEdit = this.repositoryItemDateEditTransactionDate;
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
            this.repositoryItemDateEditTransactionDate,
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
            this.ModeOfExecution,
            this.Remark});
            prepareOptionalFieldsList();

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
            this.optionalFields.Add(this.SecondHolder.Properties.FieldName);
            this.optionalFields.Add(this.ThirdHolder.Properties.FieldName);
            this.optionalFields.Add(this.Nominee.Properties.FieldName);
            this.optionalFields.Add(this.Guardian.Properties.FieldName);
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

        private void RepositoryItemARN_EditValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
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
                LogDebug("FreshPurchase.BindDataSource()", new ArgumentNullException("object value is null"));
                return;
            }

            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();

            freshPurchase = jsonSerialization.DeserializeFromString<FinancialPlanner.Common.Model.TaskManagement.MFTransactions.FreshPurchase>(obj.ToString());
            this.vGridTransaction.Rows["ARN"].Properties.Value = freshPurchase.Arn;

            this.vGridTransaction.Rows["ClientGroup"].Properties.Value = getClientName(freshPurchase.Cid);
            this.currentClient = ((List<Client>)clients).Find(i => i.Name == this.vGridTransaction.Rows["ClientGroup"].Properties.Value.ToString());
            loadMembers();
            this.vGridTransaction.Rows["MemberName"].Properties.Value = freshPurchase.MemberName;
            this.vGridTransaction.Rows["SecondHolder"].Properties.Value = freshPurchase.SecondHolder;
            this.vGridTransaction.Rows["ThirdHolder"].Properties.Value = freshPurchase.ThirdHolder;
            this.vGridTransaction.Rows["Nominee"].Properties.Value = freshPurchase.Nominee;
            this.vGridTransaction.Rows["Guardian"].Properties.Value = freshPurchase.Guardian;

            this.vGridTransaction.Rows["FolioNumber"].Properties.Value = freshPurchase.FolioNumber;
            this.vGridTransaction.Rows["AMC"].Properties.Value = freshPurchase.Amc;
            repositoryItemAMC.GetDisplayValueByKeyValue(freshPurchase.Amc);
            loadScheme(freshPurchase.Amc);
            this.vGridTransaction.Rows["Scheme"].Properties.Value = getSchemeName(freshPurchase.Scheme);
            this.vGridTransaction.Rows["ModeOfHolding"].Properties.Value = freshPurchase.ModeOfHolding;
            this.vGridTransaction.Rows["Option"].Properties.Value = freshPurchase.Options;
            this.vGridTransaction.Rows["Amount"].Properties.Value = freshPurchase.Amount;
            this.vGridTransaction.Rows["TransactionDate"].Properties.Value = freshPurchase.TransactionDate;
            this.vGridTransaction.Rows["ModeOfExecution"].Properties.Value = freshPurchase.ModeOfExecution;
            this.vGridTransaction.Rows["Remark"].Properties.Value = freshPurchase.Remark;
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
            FinancialPlanner.Common.Model.TaskManagement.MFTransactions.FreshPurchase freshPurchase = 
                new FinancialPlanner.Common.Model.TaskManagement.MFTransactions.FreshPurchase();
            if (this.vGridTransaction.Rows.Count > 0)
            {
                freshPurchase.Arn = int.Parse(this.vGridTransaction.Rows["ARN"].Properties.Value.ToString());
                freshPurchase.Cid = this.currentClient.ID;
                freshPurchase.ClientGroup = this.vGridTransaction.Rows["ClientGroup"].Properties.Value.ToString();
                freshPurchase.MemberName = this.vGridTransaction.Rows["MemberName"].Properties.Value.ToString();
                freshPurchase.SecondHolder = (this.vGridTransaction.Rows["SecondHolder"].Properties.Value != null) ?
                    this.vGridTransaction.Rows["SecondHolder"].Properties.Value.ToString() : string.Empty;

                freshPurchase.ThirdHolder = (this.vGridTransaction.Rows["ThirdHolder"].Properties.Value != null) ? 
                    this.vGridTransaction.Rows["ThirdHolder"].Properties.Value.ToString() : string.Empty;

                freshPurchase.Nominee = (this.vGridTransaction.Rows["Nominee"].Properties.Value != null) ?
                    this.vGridTransaction.Rows["Nominee"].Properties.Value.ToString() : string.Empty;

                freshPurchase.Guardian = (this.vGridTransaction.Rows["Guardian"].Properties.Value != null)?
                this.vGridTransaction.Rows["Guardian"].Properties.Value.ToString() : string.Empty;

                freshPurchase.ModeOfHolding = this.vGridTransaction.Rows["ModeOfHolding"].Properties.Value.ToString();
                freshPurchase.Amc = int.Parse(this.vGridTransaction.Rows["AMC"].Properties.Value.ToString());
                freshPurchase.FolioNumber = this.vGridTransaction.Rows["FolioNumber"].Properties.Value.ToString();
                freshPurchase.Scheme = selectedSchemeId;
                freshPurchase.Options = this.vGridTransaction.Rows["Option"].Properties.Value.ToString();
                freshPurchase.Amount = double.Parse(this.vGridTransaction.Rows["Amount"].Properties.Value.ToString());
                freshPurchase.TransactionDate = (DateTime) this.vGridTransaction.Rows["TransactionDate"].Properties.Value;
                freshPurchase.ModeOfExecution = this.vGridTransaction.Rows["ModeOfExecution"].Properties.Value.ToString();
                freshPurchase.Remark = (this.vGridTransaction.Rows["Remark"].Properties.Value != null) ?
                    this.vGridTransaction.Rows["Remark"].Properties.Value.ToString() : string.Empty;
            }
            return freshPurchase;
        }

        public bool IsAllRequireInputAvailable()
        {
            for(int rowIndex = 0; rowIndex < this.vGridTransaction.Rows.Count; rowIndex++)
            {
                if(!optionalFields.Contains(this.vGridTransaction.Rows[rowIndex].Properties.FieldName) && 
                   this.vGridTransaction.Rows[rowIndex].Properties.Value == null)
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
    }
}
