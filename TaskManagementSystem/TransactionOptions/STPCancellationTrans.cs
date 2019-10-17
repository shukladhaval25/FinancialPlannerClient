using DevExpress.XtraVerticalGrid;
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
    class STPCancellationTrans : ITransactionType
    {
        IList<ARN> arns;
        internal IList<AMC> amcs;
        IList<Client> clients;
        Client currentClient;
        IList<Scheme> schemes;
        internal int fromSchemeId;
        internal int selectedSchemeId;
        List<string> optionalFields = new List<string>();
        STPCancellation stpCancellation;

        readonly string GRID_NAME = "vGridSTPCancellation";
        DevExpress.XtraVerticalGrid.VGridControl vGridTransaction;

        private DevExpress.XtraVerticalGrid.Rows.EditorRow ARN;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow ClientGroup;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow MemberName;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow AMC;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow FolioNumber;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow FromScheme;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow FromOptions;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow ToScheme;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow ToOptions;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Amount;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow STPDate;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow TransactionDate;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow ModeOfExecution;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Remark;

        public DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemARN;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxClientGroup;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxMemberName;
        public DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemAMC;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditFolioNumber;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxFromScheme;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxFromOption;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxToScheme;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxToOption;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditAmount;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditSTPDate;
        public DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEditTransactionDate;
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
            this.FromScheme = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.FromOptions = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.ToScheme = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.ToOptions = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Amount = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.STPDate = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.TransactionDate = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
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
            this.repositoryItemComboBoxFromScheme = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxFromScheme.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.repositoryItemComboBoxFromScheme.EditValueChanged += repositoryItemComboBoxFromScheme_EditValueChanged;

            this.repositoryItemComboBoxFromOption = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxFromOption.Items.AddRange(new string[] { "GR", "WDR", "DD" });
            this.repositoryItemComboBoxFromOption.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            this.repositoryItemComboBoxToScheme = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxToScheme.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.repositoryItemComboBoxToScheme.EditValueChanged += repositoryItemComboBoxToScheme_EditValueChanged;

            this.repositoryItemComboBoxToOption = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxToOption.Items.AddRange(new string[] { "GR", "WDR", "DD" });
            this.repositoryItemComboBoxToOption.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            loadScheme();

            this.repositoryItemTextEditAmount = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEditAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEditAmount.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEditAmount.Validating += RepositoryItemTextEditAmount_Validating;

            this.repositoryItemTextEditSTPDate = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEditSTPDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEditSTPDate.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEditSTPDate.Validating += RepositoryItemTextEditAmount_Validating;

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
            // From Scheme
            //
            this.FromScheme.Name = "FromScheme";
            this.FromScheme.Properties.Caption = "From Scheme";
            this.FromScheme.Properties.FieldName = "FromScheme";
            this.FromScheme.Properties.RowEdit = this.repositoryItemComboBoxFromScheme;
            //
            // From Option
            //
            this.FromOptions.Name = "FromOption";
            this.FromOptions.Properties.Caption = "Option";
            this.FromOptions.Properties.FieldName = "FromOption";
            this.FromOptions.Properties.RowEdit = this.repositoryItemComboBoxFromOption;
            //
            // To Scheme
            //
            this.ToScheme.Name = "ToScheme";
            this.ToScheme.Properties.Caption = "To Scheme";
            this.ToScheme.Properties.FieldName = "ToScheme";
            this.ToScheme.Properties.RowEdit = this.repositoryItemComboBoxToScheme;
            //
            // To Option
            //
            this.ToOptions.Name = "ToOption";
            this.ToOptions.Properties.Caption = "Option";
            this.ToOptions.Properties.FieldName = "ToOption";
            this.ToOptions.Properties.RowEdit = this.repositoryItemComboBoxToOption;
            //
            // Amount
            //
            this.Amount.Name = "Amount";
            this.Amount.Properties.Caption = "Amount";
            this.Amount.Properties.FieldName = "Amount";
            this.Amount.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Amount.Properties.RowEdit = this.repositoryItemTextEditAmount;
            //
            // Duration
            //
            this.STPDate.Name = "STPDate";
            this.STPDate.Properties.Caption = "STP Date";
            this.STPDate.Properties.FieldName = "STPDate";
            this.STPDate.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.STPDate.Properties.RowEdit = this.repositoryItemTextEditAmount;
            //
            // Frequency
            //
            this.TransactionDate.Name = "TransactionDate";
            this.TransactionDate.Properties.Caption = "Transaction Date";
            this.TransactionDate.Properties.FieldName = "TransactionDate";
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
                this.repositoryItemAMC,
                this.repositoryItemTextEditFolioNumber,
                this.repositoryItemComboBoxFromScheme,
                this.repositoryItemComboBoxFromOption,
                this.repositoryItemComboBoxToScheme,
                this.repositoryItemComboBoxToOption,
                this.repositoryItemTextEditAmount,
                this.repositoryItemTextEditSTPDate,
                this.repositoryItemDateEditTransactionDate,
                this.repositoryItemComboBoxModeOfExecution,
                this.repositoryItemTextEditRemark
            });

            this.vGridTransaction.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
                this.ARN,
                this.ClientGroup,
                this.MemberName,
                this.AMC,
                this.FolioNumber,
                this.FromScheme,
                this.FromOptions,
                this.ToScheme,
                this.ToOptions,
                this.Amount,
                this.STPDate,
                this.TransactionDate,
                this.ModeOfExecution,
                this.Remark});
            prepareOptionalFieldsList();
        }

        private void repositoryItemComboBoxToScheme_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit = (DevExpress.XtraEditors.ComboBoxEdit)sender;
            if (comboBoxEdit.SelectedItem != null)
            {
                Scheme scheme = ((List<Scheme>)schemes).Find(i => i.Name == comboBoxEdit.SelectedItem.ToString());
                selectedSchemeId = scheme.Id;
            }
        }

        private void repositoryItemComboBoxFromScheme_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit = (DevExpress.XtraEditors.ComboBoxEdit)sender;
            if (comboBoxEdit.SelectedItem != null)
            {
                Scheme scheme = ((List<Scheme>)schemes).Find(i => i.Name == comboBoxEdit.SelectedItem.ToString());
                fromSchemeId = scheme.Id;
            }
        }

        private void prepareOptionalFieldsList()
        {
            this.optionalFields.Add(this.Remark.Properties.FieldName);
        }

        private void loadScheme()
        {
            SchemeInfo schemeInfo = new SchemeInfo();
            schemes = schemeInfo.GetAll();

            repositoryItemComboBoxFromScheme.Items.Clear();
            repositoryItemComboBoxToScheme.Items.Clear();
            foreach (Scheme scheme in schemes)
            {
                repositoryItemComboBoxFromScheme.Items.Add(scheme.Name);
                repositoryItemComboBoxToScheme.Items.Add(scheme.Name);
            }
        }

        public void BindDataSource(Object obj)
        {
            if (obj == null)
            {
                LogDebug("STPCancellation.BindDataSource()", new ArgumentNullException("object value is null"));
                return;
            }

            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();

            stpCancellation = jsonSerialization.DeserializeFromString<FinancialPlanner.Common.Model.TaskManagement.MFTransactions.STPCancellation>(obj.ToString());
            this.vGridTransaction.Rows["ARN"].Properties.Value = stpCancellation.Arn;

            this.vGridTransaction.Rows["ClientGroup"].Properties.Value = getClientName(stpCancellation.Cid);
            this.currentClient = ((List<Client>)clients).Find(i => i.Name == this.vGridTransaction.Rows["ClientGroup"].Properties.Value.ToString());
            loadMembers();
            this.vGridTransaction.Rows["MemberName"].Properties.Value = stpCancellation.MemberName;

            this.vGridTransaction.Rows["FolioNumber"].Properties.Value = stpCancellation.FolioNumber;
            this.vGridTransaction.Rows["AMC"].Properties.Value = stpCancellation.Amc;
            repositoryItemAMC.GetDisplayValueByKeyValue(stpCancellation.Amc);
            loadScheme(stpCancellation.Amc);
            this.vGridTransaction.Rows["ToScheme"].Properties.Value = getSchemeName(stpCancellation.Scheme);
            selectedSchemeId = stpCancellation.Scheme;
            //this.vGridTransaction.Rows["ModeOfHolding"].Properties.Value = switchOpt.ModeOfHolding;
            this.vGridTransaction.Rows["ToOption"].Properties.Value = stpCancellation.Options;
            this.vGridTransaction.Rows["FromScheme"].Properties.Value = getSchemeName(stpCancellation.FromSchemeId);
            fromSchemeId = stpCancellation.FromSchemeId;
            this.vGridTransaction.Rows["FromOption"].Properties.Value = stpCancellation.FromOptions;
            this.vGridTransaction.Rows["Amount"].Properties.Value = stpCancellation.Amount;
            this.vGridTransaction.Rows["STPDate"].Properties.Value = stpCancellation.StpDate;
            this.vGridTransaction.Rows["TransactionDate"].Properties.Value = stpCancellation.TransactionDate;
            this.vGridTransaction.Rows["ModeOfExecution"].Properties.Value = stpCancellation.ModeOfExecution;
            this.vGridTransaction.Rows["Remark"].Properties.Value = stpCancellation.Remark;
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

        private void LogDebug(string name, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = name;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }

        private void RepositoryItemTextEditAmount_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DevExpress.XtraEditors.TextEdit textEdit = (DevExpress.XtraEditors.TextEdit)sender;
            e.Cancel = !FinancialPlanner.Common.Validation.IsDecimal(textEdit.Text);
        }

        private void loadMembers()
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

        public object GetTransactionType()
        {
            stpCancellation = new STPCancellation();
            if (this.vGridTransaction.Rows.Count > 0)
            {
                stpCancellation.Cid = this.currentClient.ID;
                stpCancellation.Arn = int.Parse(this.vGridTransaction.Rows["ARN"].Properties.Value.ToString());
                stpCancellation.MemberName = this.vGridTransaction.Rows["MemberName"].Properties.Value.ToString();

                stpCancellation.Amc = int.Parse(this.vGridTransaction.Rows["AMC"].Properties.Value.ToString());
                stpCancellation.FolioNumber = this.vGridTransaction.Rows["FolioNumber"].Properties.Value.ToString();

                stpCancellation.FromOptions = this.vGridTransaction.Rows["FromOption"].Properties.Value.ToString();
                stpCancellation.FromSchemeId = fromSchemeId;

                stpCancellation.Scheme = selectedSchemeId;
                stpCancellation.Options = this.vGridTransaction.Rows["ToOption"].Properties.Value.ToString();
                stpCancellation.Amount = double.Parse(this.vGridTransaction.Rows["Amount"].Properties.Value.ToString());

                stpCancellation.StpDate = int.Parse(this.vGridTransaction.Rows["STPDate"].Properties.Value.ToString());
                stpCancellation.TransactionDate = (DateTime)this.vGridTransaction.Rows["TransactionDate"].Properties.Value;
                stpCancellation.ModeOfExecution = this.vGridTransaction.Rows["ModeOfExecution"].Properties.Value.ToString();
                stpCancellation.Remark = (this.vGridTransaction.Rows["Remark"].Properties.Value != null) ?
                    this.vGridTransaction.Rows["Remark"].Properties.Value.ToString() : string.Empty;
            }
            return stpCancellation;
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
            if (schemes == null)
                schemes = schemeInfo.GetAll(amcId);

            repositoryItemComboBoxFromScheme.Items.Clear();
            foreach (Scheme scheme in schemes)
            {
                repositoryItemComboBoxFromScheme.Items.Add(scheme.Name);
            }
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

        private string getClientName(int cid)
        {
            Client client = new Client();
            return (clients.TryGetValue(clients.FindIndex(i => i.ID == cid), out client)) ? client.Name : string.Empty;
        }
    }
}
