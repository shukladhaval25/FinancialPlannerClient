using System;
using System.ComponentModel;
using DevExpress.XtraVerticalGrid;
using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.PlanOptions;

namespace FinancialPlannerClient.TaskManagementSystem.TransactionOptions
{
    public class LumsumInvestmentType : ITransactionType
    {
        readonly string GRID_NAME = "vGridLumsumTransaction";
        int clientId;
        DevExpress.XtraVerticalGrid.VGridControl vGridTransaction;

        DevExpress.XtraVerticalGrid.Rows.EditorRow SchemeName;
        DevExpress.XtraVerticalGrid.Rows.EditorRow Amount;
        DevExpress.XtraVerticalGrid.Rows.EditorRow Category;
        DevExpress.XtraVerticalGrid.Rows.EditorRow ChequeInFavourOff;
        DevExpress.XtraVerticalGrid.Rows.EditorRow FirstHolder;
        DevExpress.XtraVerticalGrid.Rows.EditorRow SecondHolder;
        DevExpress.XtraVerticalGrid.Rows.EditorRow ThirdHolder;
        DevExpress.XtraVerticalGrid.Rows.EditorRow Nominee;

        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditSchemeName;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditAmount;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditCategory;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditChequeInFavourOff;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxSecondHolder;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxFirstHolder;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxThirdHolder;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditNominee;

        private void InitializeComponent()
        {
            if (this.vGridTransaction == null)
                return;

            this.SchemeName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Amount = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Category = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.ChequeInFavourOff = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.SecondHolder = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.FirstHolder = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.ThirdHolder = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Nominee = new DevExpress.XtraVerticalGrid.Rows.EditorRow();

            this.repositoryItemComboBoxSecondHolder = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxSecondHolder.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            this.repositoryItemComboBoxFirstHolder = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxFirstHolder.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            this.repositoryItemComboBoxThirdHolder = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxThirdHolder.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            this.repositoryItemTextEditSchemeName = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEditCategory = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEditChequeInFavourOff = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();

            this.repositoryItemTextEditAmount = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEditAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEditAmount.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEditAmount.Validating += RepositoryItemTextEditAmount_Validating;
            this.repositoryItemTextEditAmount.EditValueChanged += RepositoryItemTextEditAmount_EditValueChanged;

            this.repositoryItemTextEditNominee = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();

            // 
            // Scheme Name
            // 
            this.SchemeName.Name = "SchemeName";
            this.SchemeName.Properties.Caption = "Scheme";
            this.SchemeName.Properties.FieldName = "SchemeName";
            this.SchemeName.Properties.RowEdit = this.repositoryItemTextEditSchemeName;
            this.SchemeName.Properties.AllowEdit = false;
            //
            // Amount
            //
            this.Amount.Name = "Amount";
            this.Amount.Properties.Caption = "Amount";
            this.Amount.Properties.FieldName = "Amount";
            this.Amount.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Amount.Properties.RowEdit = this.repositoryItemTextEditAmount;
            // 
            // Category
            // 
            this.Category.Name = "Category";
            this.Category.Properties.Caption = "Category";
            this.Category.Properties.FieldName = "Category";
            this.Category.Properties.RowEdit = this.repositoryItemTextEditSchemeName;
            this.Category.Properties.AllowEdit = false;
            //
            // Cheque in favour off
            //
            this.ChequeInFavourOff.Name = "ChequeInFavourOff";
            this.ChequeInFavourOff.Properties.Caption = "Cheque In Favour Off";
            this.ChequeInFavourOff.Properties.FieldName = "Remark";
            this.ChequeInFavourOff.Properties.RowEdit = this.repositoryItemTextEditChequeInFavourOff;
            this.ChequeInFavourOff.Properties.AllowEdit = true;

            //
            // FirstHolder
            //
            this.FirstHolder.Name = "FirstHolder";
            this.FirstHolder.Properties.Caption = "First Holder";
            this.FirstHolder.Properties.FieldName = "FirstHolder";
            this.FirstHolder.Properties.RowEdit = this.repositoryItemComboBoxFirstHolder;

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
            this.Nominee.Properties.RowEdit = this.repositoryItemTextEditNominee;

            //
            // VGridControl
            //
            this.vGridTransaction.Name = GRID_NAME;
            this.vGridTransaction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));

            this.vGridTransaction.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
                this.repositoryItemTextEditSchemeName,
                this.repositoryItemTextEditAmount,
                this.repositoryItemTextEditCategory,
                this.repositoryItemTextEditChequeInFavourOff,
                this.repositoryItemComboBoxFirstHolder,
                this.repositoryItemComboBoxSecondHolder,
                this.repositoryItemComboBoxThirdHolder,
                this.repositoryItemTextEditNominee
            });

            this.vGridTransaction.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
                this.SchemeName,
                this.Amount,
                this.Category,
                this.ChequeInFavourOff,
                this.FirstHolder,
                this.SecondHolder,
                this.ThirdHolder,
                this.Nominee});
            prepareOptionalFieldsList();

        }

        private void RepositoryItemTextEditAmount_EditValueChanged(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void prepareOptionalFieldsList()
        {
            //throw new NotImplementedException();
        }

        private void RepositoryItemTextEditAmount_Validating(object sender, CancelEventArgs e)
        {
            DevExpress.XtraEditors.TextEdit textEdit = (DevExpress.XtraEditors.TextEdit)sender;
            e.Cancel = !FinancialPlanner.Common.Validation.IsDecimal(textEdit.Text);
        }

        private void LogDebug(string name, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = name;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }

        public void BindDataSource(object obj)
        {
            if (obj == null)
            {
                LogDebug("Lumsum.BindDataSource()", new ArgumentNullException("object value is null"));
                return;
            }

            
            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
            LumsumInvestmentRecomendation investmentRecomendation = jsonSerialization.DeserializeFromString<FinancialPlanner.Common.Model.LumsumInvestmentRecomendation>(obj.ToString());
            this.vGridTransaction.Rows["SchemeName"].Properties.Value = investmentRecomendation.SchemeName;
            this.vGridTransaction.Rows["Category"].Properties.Value = investmentRecomendation.Category;
            this.vGridTransaction.Rows["Amount"].Properties.Value = investmentRecomendation.Amount;
            this.vGridTransaction.Rows["ChequeInFavourOff"].Properties.Value = investmentRecomendation.ChequeInFavourOff;
            this.clientId = investmentRecomendation.Cid;
            this.vGridTransaction.Rows["Nominee"].Properties.Value = investmentRecomendation.Nominee;
            loadMembers();
        }

        public VGridControl GetGridControl()
        {
            throw new NotImplementedException();
        }

        public object GetTransactionType()
        {
            LumsumInvestmentRecomendation investmentRecomendation = new LumsumInvestmentRecomendation();
            if (this.vGridTransaction.Rows.Count > 0)
            {
                investmentRecomendation.Cid = this.clientId;
                investmentRecomendation.FirstHolder = (this.vGridTransaction.Rows["FirstHolder"].Properties.Value != null) ?
                    this.vGridTransaction.Rows["FirstHolder"].Properties.Value.ToString() : string.Empty;
                investmentRecomendation.SecondHolder = (this.vGridTransaction.Rows["SecondHolder"].Properties.Value != null) ?
                    this.vGridTransaction.Rows["SecondHolder"].Properties.Value.ToString() : string.Empty;
                investmentRecomendation.ThirdHolder = (this.vGridTransaction.Rows["ThirdHolder"].Properties.Value != null) ?
                    this.vGridTransaction.Rows["ThirdHolder"].Properties.Value.ToString() : string.Empty;

                investmentRecomendation.ChequeInFavourOff = (this.vGridTransaction.Rows["ChequeInFavourOff"].Properties.Value != null) ?
                    this.vGridTransaction.Rows["ChequeInFavourOff"].Properties.Value.ToString() : string.Empty;

                investmentRecomendation.Amount = double.Parse(this.vGridTransaction.Rows["Amount"].Properties.Value.ToString());
                investmentRecomendation.Nominee = (this.vGridTransaction.Rows["Nominee"].Properties.Value != null) ? this.vGridTransaction.Rows["Nominee"].Properties.Value.ToString() : string.Empty;
            }
            return investmentRecomendation;
        }

        public bool IsAllRequireInputAvailable()
        {
            throw new NotImplementedException();
        }

        public void setVGridControl(VGridControl vGrid)
        {
            this.vGridTransaction = vGrid;
            this.vGridTransaction.RepositoryItems.Clear();
            this.vGridTransaction.Rows.Clear();
            InitializeComponent();
            this.vGridTransaction.RowHeaderWidth = 120;
            this.vGridTransaction.RecordWidth = 120;
            for (int rowindex = 0; rowindex < this.vGridTransaction.Rows.Count; rowindex++)
            {
                this.vGridTransaction.Rows[rowindex].Height = 20;
            }
            this.vGridTransaction.Refresh();
        }
        internal void loadMembers()
        {
            repositoryItemComboBoxFirstHolder.Items.Clear();
            repositoryItemComboBoxSecondHolder.Items.Clear();

            new PlannerInfo.FamilyMemberInfo().FillFamilyMemberInCombo(this.clientId, repositoryItemComboBoxFirstHolder);
            repositoryItemComboBoxSecondHolder.Items.AddRange(repositoryItemComboBoxFirstHolder.Items);
            repositoryItemComboBoxThirdHolder.Items.AddRange(repositoryItemComboBoxFirstHolder.Items);
        }

        public void SetARN(int arnNo)
        {
            this.vGridTransaction.Rows["ARN"].Properties.Value = arnNo;
        }
    }
}
