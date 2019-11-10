using DevExpress.XtraVerticalGrid;
using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.TaskManagement.MFTransactions;
using FinancialPlannerClient.Master.TaskMaster;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlannerClient.TaskManagementSystem.TransactionOptions
{
    public class STPTypeRecomendation : ITransactionType
    {
        readonly string GRID_NAME = "vGridSTPTypeRecomendation";
        int clientId;
        double lumsumInvestmentAmount = 0;
        IList<Scheme> schemes = new List<Scheme>();
        DevExpress.XtraVerticalGrid.VGridControl vGridTransaction;
        DevExpress.XtraVerticalGrid.Rows.EditorRow FromSchemeName;
        DevExpress.XtraVerticalGrid.Rows.EditorRow SchemeName;
        DevExpress.XtraVerticalGrid.Rows.EditorRow Amount;
        DevExpress.XtraVerticalGrid.Rows.EditorRow Duration;
        DevExpress.XtraVerticalGrid.Rows.EditorRow Frequency;
        

        public DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemFromSchemeName;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditSchemeName;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditAmount;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditDuration;
        public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxFrequency;


        private void InitializeComponent()
        {
            if (this.vGridTransaction == null)
                return;

            this.FromSchemeName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.SchemeName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Amount = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Duration = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Frequency = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            
            this.repositoryItemFromSchemeName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            loadSchemes();

            
            this.repositoryItemTextEditSchemeName = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();

            this.repositoryItemTextEditDuration = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEditDuration.Validating += RepositoryItemTextEditAmount_Validating;
            this.repositoryItemTextEditDuration.Leave += RepositoryItemTextEditDuration_EditValueChanged;

            this.repositoryItemComboBoxFrequency = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemComboBoxFrequency.Items.AddRange(new string[] { "Weekly", "Monthly", "Quarterly" });
            this.repositoryItemComboBoxFrequency.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;

            this.repositoryItemTextEditAmount = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEditAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEditAmount.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.repositoryItemTextEditAmount.Validating += RepositoryItemTextEditAmount_Validating;


            // 
            // From Scheme Name
            // 
            this.FromSchemeName.Name = "FromSchemeName";
            this.FromSchemeName.Properties.Caption = "From Scheme";
            this.FromSchemeName.Properties.FieldName = "FromSchemeName";
            this.FromSchemeName.Properties.RowEdit = this.repositoryItemFromSchemeName;
            this.FromSchemeName.Properties.AllowEdit = true;
            // 
            // Scheme Name
            // 
            this.SchemeName.Name = "SchemeName";
            this.SchemeName.Properties.Caption = "To Scheme";
            this.SchemeName.Properties.FieldName = "SchemeName";
            this.SchemeName.Properties.RowEdit = this.repositoryItemTextEditSchemeName;
            this.SchemeName.Properties.AllowEdit = false;
            //
            // Amount
            //
            this.Amount.Name = "Amount";
            this.Amount.Properties.Caption = "STP Amount";
            this.Amount.Properties.FieldName = "Amount";
            this.Amount.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Amount.Properties.RowEdit = this.repositoryItemTextEditAmount;
            //this.Amount.Properties.AllowEdit = false;
            // 
            // Duration
            // 
            this.Duration.Name = "Duration";
            this.Duration.Properties.Caption = "Duration";
            this.Duration.Properties.FieldName = "Duration";
            this.Duration.Properties.RowEdit = this.repositoryItemTextEditDuration;
            this.Duration.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
   
            //
            // Frequency
            //
            this.Frequency.Name = "Frequency";
            this.Frequency.Properties.Caption = "Frequency";
            this.Frequency.Properties.FieldName = "Frequency";
            this.Frequency.Properties.RowEdit = this.repositoryItemComboBoxFrequency;
         
            //
            // VGridControl
            //
            this.vGridTransaction.Name = GRID_NAME;
            this.vGridTransaction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));

            this.vGridTransaction.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
                this.repositoryItemFromSchemeName,
                this.repositoryItemTextEditSchemeName,
                this.repositoryItemComboBoxFrequency,
                this.repositoryItemTextEditDuration,                
                this.repositoryItemTextEditAmount,
            });

            this.vGridTransaction.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
                this.FromSchemeName,
                this.SchemeName,
                 this.Frequency,
                this.Duration,               
                this.Amount
              });
            prepareOptionalFieldsList();

        }

        private void RepositoryItemTextEditDuration_EditValueChanged(object sender, EventArgs e)
        {
            this.vGridTransaction.Rows["Amount"].Properties.Value = Math.Round(lumsumInvestmentAmount / int.Parse(((DevExpress.XtraEditors.BaseEdit)sender).Text.ToString()));
        }

        private void loadSchemes()
        {
            SchemeInfo schemeInfo = new SchemeInfo();
            schemes = schemeInfo.GetAll();
            DataTable dtScheme = getSchemeTable(schemes);
            repositoryItemFromSchemeName.DataSource = dtScheme;
            repositoryItemFromSchemeName.DisplayMember = "Name";
            repositoryItemFromSchemeName.ValueMember = "ID";
            repositoryItemFromSchemeName.NullValuePrompt = "Please select valid value.";
        }

        private DataTable getSchemeTable(IList<Scheme> schemes)
        {
            DataTable dtScheme = new DataTable();
            dtScheme.Columns.Add("ID", typeof(System.Int64));
            dtScheme.Columns.Add("Name", typeof(System.String));
            foreach (Scheme scheme in schemes)
            {
                DataRow dr = dtScheme.NewRow();
                dr["ID"] = scheme.Id;
                dr["Name"] = scheme.Name;
                dtScheme.Rows.Add(dr);
            }
            return dtScheme;
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
            STPTypeInvestmentRecomendation stpInvestmentRecomendation = jsonSerialization.DeserializeFromString<FinancialPlanner.Common.Model.STPTypeInvestmentRecomendation>(obj.ToString());
            this.vGridTransaction.Rows["SchemeName"].Properties.Value = stpInvestmentRecomendation.SchemeName;
            this.vGridTransaction.Rows["Duration"].Properties.Value = stpInvestmentRecomendation.Duration;
            this.vGridTransaction.Rows["Amount"].Properties.Value = stpInvestmentRecomendation.Amount;
            this.clientId = stpInvestmentRecomendation.Cid;
            this.lumsumInvestmentAmount = stpInvestmentRecomendation.LumsumAmount;
        }

        public VGridControl GetGridControl()
        {
            throw new NotImplementedException();
        }

        public object GetTransactionType()
        {
            STPTypeInvestmentRecomendation stpTypeInvestmentRecomendation = new STPTypeInvestmentRecomendation();
            if (this.vGridTransaction.Rows.Count > 0)
            {
                stpTypeInvestmentRecomendation.Cid = this.clientId;
                stpTypeInvestmentRecomendation.FromSchemeId =  (this.vGridTransaction.Rows["FromSchemeName"].Properties.Value != null) ?
                   int.Parse( this.vGridTransaction.Rows["FromSchemeName"].Properties.Value.ToString()) : 0;

                stpTypeInvestmentRecomendation.FromSchemeName = getSelectedScheme(stpTypeInvestmentRecomendation.FromSchemeId).Name;               
                stpTypeInvestmentRecomendation.Amount = double.Parse(this.vGridTransaction.Rows["Amount"].Properties.Value.ToString());
                stpTypeInvestmentRecomendation.Duration = int.Parse(this.vGridTransaction.Rows["Duration"].Properties.Value.ToString());
                stpTypeInvestmentRecomendation.Frequency = (this.vGridTransaction.Rows["Frequency"].Properties.Value != null) ?
                   this.vGridTransaction.Rows["Frequency"].Properties.Value.ToString() : string.Empty;
            }
            return stpTypeInvestmentRecomendation;
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
        private Scheme getSelectedScheme(int id)
        {
            foreach (Scheme scheme in schemes)
            {
                if (scheme.Id == id)
                {
                    return scheme;
                }
            }
            return new Scheme();
        }

        public void SetARN(int arnNo)
        {
            this.vGridTransaction.Rows["ARN"].Properties.Value = arnNo;
        }
    }
}
