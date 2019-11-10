using DevExpress.XtraVerticalGrid;
using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using System;
using System.ComponentModel;

namespace FinancialPlannerClient.TaskManagementSystem.TransactionOptions
{
    public class SIPInvestmentRecomendation : ITransactionType
    {
        readonly string GRID_NAME = "vGridSIPInvestmentRecomendationTransaction";
        int clientId;
        DevExpress.XtraVerticalGrid.VGridControl vGridTransaction;

        DevExpress.XtraVerticalGrid.Rows.EditorRow SchemeName;
        DevExpress.XtraVerticalGrid.Rows.EditorRow Amount;
        DevExpress.XtraVerticalGrid.Rows.EditorRow Category;
        DevExpress.XtraVerticalGrid.Rows.EditorRow ChequeInFavourOff;
        DevExpress.XtraVerticalGrid.Rows.EditorRow FirstHolder;
        DevExpress.XtraVerticalGrid.Rows.EditorRow SecondHolder;

        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditSchemeName;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditAmount;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditCategory;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditChequeInFavourOff;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxSecondHolder;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxFirstHolder;

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

            this.repositoryItemComboBoxSecondHolder = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxSecondHolder.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            this.repositoryItemComboBoxFirstHolder = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxFirstHolder.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            this.repositoryItemTextEditSchemeName = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEditCategory = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEditChequeInFavourOff = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();

            this.repositoryItemTextEditAmount = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEditAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEditAmount.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEditAmount.Validating += RepositoryItemTextEditAmount_Validating;


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
                this.repositoryItemComboBoxSecondHolder
            });

            this.vGridTransaction.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
                this.SchemeName,
                this.Amount,
                this.Category,
                this.ChequeInFavourOff,
                this.FirstHolder,
                this.SecondHolder});
            prepareOptionalFieldsList();

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
            SIPTypeInvestmentRecomendation sipInvestmentRecomendation = jsonSerialization.DeserializeFromString<SIPTypeInvestmentRecomendation>(obj.ToString());
            this.vGridTransaction.Rows["SchemeName"].Properties.Value = sipInvestmentRecomendation.SchemeName;
            this.vGridTransaction.Rows["Category"].Properties.Value = sipInvestmentRecomendation.Category;
            this.vGridTransaction.Rows["Amount"].Properties.Value = sipInvestmentRecomendation.Amount;
            this.clientId = sipInvestmentRecomendation.Cid;
            loadMembers();           
        }

        public VGridControl GetGridControl()
        {
            throw new NotImplementedException();
        }

        public object GetTransactionType()
        {
            SIPTypeInvestmentRecomendation sipTypeInvestmentRecomendation = new SIPTypeInvestmentRecomendation();
            if (this.vGridTransaction.Rows.Count > 0)
            {
                sipTypeInvestmentRecomendation.Cid = this.clientId;
                sipTypeInvestmentRecomendation.FirstHolder = (this.vGridTransaction.Rows["FirstHolder"].Properties.Value != null) ?
                    this.vGridTransaction.Rows["FirstHolder"].Properties.Value.ToString() : string.Empty;
                sipTypeInvestmentRecomendation.SecondHolder = (this.vGridTransaction.Rows["SecondHolder"].Properties.Value != null) ?
                    this.vGridTransaction.Rows["SecondHolder"].Properties.Value.ToString() : string.Empty;

                sipTypeInvestmentRecomendation.ChequeInFavourOff = (this.vGridTransaction.Rows["ChequeInFavourOff"].Properties.Value != null) ?
                    this.vGridTransaction.Rows["ChequeInFavourOff"].Properties.Value.ToString() : string.Empty;

                sipTypeInvestmentRecomendation.Amount = double.Parse(this.vGridTransaction.Rows["Amount"].Properties.Value.ToString());
            }
            return sipTypeInvestmentRecomendation;
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
        }

        public void SetARN(int arnNo)
        {
            this.vGridTransaction.Rows["ARN"].Properties.Value = arnNo;
        }
    }
}
