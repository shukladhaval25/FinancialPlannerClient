using DevExpress.XtraVerticalGrid;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.TaskManagement.MFTransactions;
using FinancialPlannerClient.Clients;
using FinancialPlannerClient.Master.TaskMaster;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlannerClient.TaskManagementSystem.TransactionOptions
{
    public class STP : ITransactionType
    {
        IList<ARN> arns;
        IList<AMC> amcs;
        IList<Client> clients;
        Client currentClient;
        IList<Scheme> schemes;

        readonly string GRID_NAME = "vGridSwitch";
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
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Duration;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Frequency;
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
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditDuration;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxFrequency;
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
            this.Duration = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Frequency = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
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

            this.repositoryItemComboBoxFromOption = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxFromOption.Items.AddRange(new string[] { "GR", "WDR", "DD" });
            this.repositoryItemComboBoxFromOption.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            this.repositoryItemComboBoxToScheme = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxToScheme.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            this.repositoryItemComboBoxToOption = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxToOption.Items.AddRange(new string[] { "GR", "WDR", "DD" });
            this.repositoryItemComboBoxToOption.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            loadScheme();

            this.repositoryItemTextEditAmount = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEditAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEditAmount.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEditAmount.Validating += RepositoryItemTextEditAmount_Validating;

            this.repositoryItemTextEditDuration = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemComboBoxFrequency = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxFrequency.Items.AddRange(new string[] { "Weekly", "Monthly", "Quarterly" });
            this.repositoryItemComboBoxFrequency.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

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
            this.Duration.Name = "Duration";
            this.Duration.Properties.Caption = "Duration";
            this.Duration.Properties.FieldName = "Duration";
            this.Duration.Properties.RowEdit = this.repositoryItemTextEditDuration;
            //
            // Frequency
            //
            this.Frequency.Name = "Frequency";
            this.Frequency.Properties.Caption = "Frequency";
            this.Frequency.Properties.FieldName = "Frequency";
            this.Frequency.Properties.RowEdit = this.repositoryItemComboBoxFrequency;
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
                this.repositoryItemTextEditDuration,
                this.repositoryItemComboBoxFrequency,
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
                this.Duration,
                this.Frequency,
                this.ModeOfExecution,
                this.Remark});
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

        public VGridControl GetGridControl()
        {
            throw new NotImplementedException();
        }

        public void BindDataSource(Object obj)
        {
            //throw new NotImplementedException();
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

        private void RepositoryItemAMC_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit comboBoxEdit = (DevExpress.XtraEditors.LookUpEdit)sender;
            if (comboBoxEdit.SelectedText != null)
            {
                AMC amcobject = ((List<AMC>)amcs).Find(i => i.Name == comboBoxEdit.Text.ToString());
                //loadScheme();
            }
        }

        public object GetTransactionType()
        {
            throw new NotImplementedException();
        }

        public bool IsAllRequireInputAvailable()
        {
            throw new NotImplementedException();
        }
    }
}
