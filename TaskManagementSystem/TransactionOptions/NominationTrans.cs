using DevExpress.XtraVerticalGrid;
using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.Masters;
using FinancialPlanner.Common.Model.TaskManagement.MFTransactions;
using FinancialPlannerClient.Clients;
using FinancialPlannerClient.Master.TaskMaster;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;

namespace FinancialPlannerClient.TaskManagementSystem.TransactionOptions
{
    internal class NominationTrans : ITransactionType
    {
        internal IList<ARN> arns;
        internal IList<AMC> amcs;
        internal IList<Client> clients;
        internal Client currentClient;

        private DevExpress.XtraVerticalGrid.Rows.EditorRow ARN;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow ClientGroup;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow MemberName;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow AMC;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow FolioNumber;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Nominee1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow Nominee2;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow AllocationForNominee1;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow AllocationForNominee2;       
        private DevExpress.XtraVerticalGrid.Rows.EditorRow ModeOfExecution;

        readonly string GRID_NAME = "vGridNominationRequest";
        DevExpress.XtraVerticalGrid.VGridControl vGridTransaction;
        Nomination nomination;
        
        public DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemARN;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxClientGroup;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxMemberName;
        public DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemAMC;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditFolioNumber;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboNominee1;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboNominee2;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditAllocationForNominee1;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditAllocationForNominee2;        
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxModeOfExecution;

        private void InitializeComponent()
        {
            if (this.vGridTransaction == null)
                return;

            this.ARN = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.ClientGroup = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.MemberName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Nominee1 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Nominee2 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.AllocationForNominee1 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.AllocationForNominee2 = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.AMC = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.FolioNumber = new DevExpress.XtraVerticalGrid.Rows.EditorRow();            
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

            this.repositoryItemComboNominee1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboNominee1.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.repositoryItemComboNominee1.Validating += RepositoryItemComboBoxClientGroup_Validating;

            this.repositoryItemComboNominee2 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboNominee2.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            this.repositoryItemTextEditAllocationForNominee1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();           
            this.repositoryItemTextEditAllocationForNominee1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEditAllocationForNominee1.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEditAllocationForNominee1.Validating += RepositoryItemTextEditAllocationForNominee1_Validating;

            this.repositoryItemTextEditAllocationForNominee2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEditAllocationForNominee2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEditAllocationForNominee2.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEditAllocationForNominee2.NullText = "0";
            this.repositoryItemTextEditAllocationForNominee2.Validating += RepositoryItemTextEditAllocationForNominee2_Validating;

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
            // Member Name
            //
            this.MemberName.Name = "MemberName";
            this.MemberName.Properties.Caption = "MemberName";
            this.MemberName.Properties.FieldName = "MemberName";
            this.MemberName.Properties.RowEdit = this.repositoryItemComboBoxMemberName;
            //
            // Nominee1
            //
            this.Nominee1.Name = "Nominee1";
            this.Nominee1.Properties.Caption = "Nominee1";
            this.Nominee1.Properties.FieldName = "Nominee1";
            this.Nominee1.Properties.RowEdit = this.repositoryItemComboNominee1;
            //
            // Nominee2
            //
            this.Nominee2.Name = "Nominee2";
            this.Nominee2.Properties.Caption = "Nominee2";
            this.Nominee2.Properties.FieldName = "Nominee2";
            this.Nominee2.Properties.RowEdit = this.repositoryItemComboNominee2;
            //
            // Allocation for Nominee1
            //
            this.AllocationForNominee1.Name = "AllocationForNominee1";
            this.AllocationForNominee1.Properties.Caption = "AllocationForNominee1";
            this.AllocationForNominee1.Properties.FieldName = "AllocationForNominee1";
            this.AllocationForNominee1.Properties.RowEdit = this.repositoryItemTextEditAllocationForNominee1;
            //
            // Allocation for Nominee2
            //
            this.AllocationForNominee2.Name = "AllocationForNominee2";
            this.AllocationForNominee2.Properties.Caption = "AllocationForNominee2";
            this.AllocationForNominee2.Properties.FieldName = "AllocationForNominee2";
            this.AllocationForNominee2.Properties.RowEdit = this.repositoryItemTextEditAllocationForNominee2;
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
                this.repositoryItemComboNominee1,
                this.repositoryItemComboNominee2,
                this.repositoryItemTextEditAllocationForNominee1,
                this.repositoryItemTextEditAllocationForNominee2,
                this.repositoryItemComboBoxModeOfExecution
            });

            this.vGridTransaction.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
                this.ARN,
                this.ClientGroup,
                this.MemberName,                
                this.AMC,
                this.FolioNumber,
                this.Nominee1,
                this.Nominee2,
                this.AllocationForNominee1,
                this.AllocationForNominee2,
                this.ModeOfExecution});
            prepareOptionalFieldsList();
        }       

        private void RepositoryItemTextEditAllocationForNominee2_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.TextEdit textEdit = (DevExpress.XtraEditors.TextEdit)sender;
            if ((this.vGridTransaction.Rows["Nominee2"].Properties.Value != null) &&
                string.IsNullOrEmpty(textEdit.Text))
            {
                e.Cancel = true;
            }
            if (!string.IsNullOrEmpty(textEdit.Text))
            {
                e.Cancel = !FinancialPlanner.Common.Validation.IsDecimal(textEdit.Text);
            }           
        }

        private void RepositoryItemTextEditAllocationForNominee1_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            DevExpress.XtraEditors.TextEdit textEdit = (DevExpress.XtraEditors.TextEdit)sender;
            double currentRatio;
            if (double.TryParse(textEdit.Text,out currentRatio))
            {
                if (currentRatio > 100)
                {                    
                    e.Cancel = true;
                }
                else if (this.vGridTransaction.Rows["Nominee2"].Properties.Value != null)
                {
                    this.vGridTransaction.Rows["AllocationForNominee2"].Properties.Value = (100 - currentRatio).ToString();
                }
                else if (currentRatio < 100)
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void prepareOptionalFieldsList()
        {            
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
            repositoryItemComboNominee1.Items.Clear();
            repositoryItemComboNominee2.Items.Clear();
            new PlannerInfo.FamilyMemberInfo().FillFamilyMemberInCombo(this.currentClient.ID, repositoryItemComboBoxMemberName);
            this.repositoryItemComboNominee1.Items.AddRange(repositoryItemComboBoxMemberName.Items);
            this.repositoryItemComboNominee2.Items.AddRange(repositoryItemComboBoxMemberName.Items);
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
                LogDebug("Nomination.BindDataSource()", new ArgumentNullException("object value is null"));
                return;
            }

            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();

            nomination = jsonSerialization.DeserializeFromString<Nomination>(obj.ToString());
            this.vGridTransaction.Rows["ARN"].Properties.Value = nomination.Arn;

            this.vGridTransaction.Rows["ClientGroup"].Properties.Value = this.currentClient.Name;
            this.currentClient = ((List<Client>)clients).Find(i => i.Name == this.vGridTransaction.Rows["ClientGroup"].Properties.Value.ToString());
            loadMembers();
            this.vGridTransaction.Rows["MemberName"].Properties.Value = nomination.MemberName;

            this.vGridTransaction.Rows["Nominee1"].Properties.Value = nomination.Nominee1;
            this.vGridTransaction.Rows["Nominee2"].Properties.Value = nomination.Nominee2;

            this.vGridTransaction.Rows["AllocationForNominee1"].Properties.Value = nomination.AllocationForNominee1;
            this.vGridTransaction.Rows["AllocationForNominee2"].Properties.Value = nomination.AllocationForNominee2;

            this.vGridTransaction.Rows["FolioNumber"].Properties.Value = nomination.FolioNumber;
            this.vGridTransaction.Rows["AMC"].Properties.Value = nomination.Amc;
            repositoryItemAMC.GetDisplayValueByKeyValue(nomination.Amc);
            this.vGridTransaction.Rows["ModeOfExecution"].Properties.Value = nomination.ModeOfExecution;
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
            Nomination nomination = new Nomination();
            if (this.vGridTransaction.Rows.Count > 0)
            {
                nomination.Arn = int.Parse(this.vGridTransaction.Rows["ARN"].Properties.Value.ToString());
                nomination.Cid = this.currentClient.ID;
                nomination.ClientGroup = this.vGridTransaction.Rows["ClientGroup"].Properties.Value.ToString();
                nomination.MemberName = this.vGridTransaction.Rows["MemberName"].Properties.Value.ToString();
                nomination.Amc = int.Parse(this.vGridTransaction.Rows["AMC"].Properties.Value.ToString());
                nomination.FolioNumber = this.vGridTransaction.Rows["FolioNumber"].Properties.Value.ToString();
                nomination.Nominee1 = this.vGridTransaction.Rows["Nominee1"].Properties.Value.ToString();
                nomination.Nominee2 = (this.vGridTransaction.Rows["Nominee2"].Properties.Value != null) ?
                    this.vGridTransaction.Rows["Nominee2"].Properties.Value.ToString(): "";
                nomination.AllocationForNominee1 = double.Parse(this.vGridTransaction.Rows["AllocationForNominee1"].Properties.Value.ToString());
                nomination.AllocationForNominee2 = (this.vGridTransaction.Rows["AllocationForNominee2"].Properties.Value != null)?
                    double.Parse(this.vGridTransaction.Rows["AllocationForNominee2"].Properties.Value.ToString()) : 0;                     
                nomination.ModeOfExecution = this.vGridTransaction.Rows["ModeOfExecution"].Properties.Value.ToString();
            }
            return nomination;
        }

        public bool IsAllRequireInputAvailable()
        {            
            return true;
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
