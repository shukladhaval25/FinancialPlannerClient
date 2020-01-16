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
    public class SwitchTypeInvRecommendationView : ITransactionType
    {
        readonly string GRID_NAME = "vGridSwitchTypeRecomendation";
        int clientId;
        IList<Scheme> schemes = new List<Scheme>();
        DevExpress.XtraVerticalGrid.VGridControl vGridTransaction;
        DevExpress.XtraVerticalGrid.Rows.EditorRow FromSchemeName;
        DevExpress.XtraVerticalGrid.Rows.EditorRow ToSchemeName;
        DevExpress.XtraVerticalGrid.Rows.EditorRow Amount;
        //DevExpress.XtraVerticalGrid.Rows.EditorRow Duration;
        //DevExpress.XtraVerticalGrid.Rows.EditorRow Frequency;
        

        public DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemFromSchemeName;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditToSchemeName;
        public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditAmount;
        //public DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditDuration;
        //public DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxFrequency;
        private int amcId;

        public SwitchTypeInvRecommendationView(int amcId)
        {
            this.amcId = amcId;
        }

        private void InitializeComponent()
        {
            if (this.vGridTransaction == null)
                return;

            this.FromSchemeName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.ToSchemeName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.Amount = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            
            this.repositoryItemFromSchemeName = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            loadSchemes();

            
            this.repositoryItemTextEditToSchemeName = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();

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
            this.ToSchemeName.Name = "SchemeName";
            this.ToSchemeName.Properties.Caption = "To Scheme";
            this.ToSchemeName.Properties.FieldName = "SchemeName";
            this.ToSchemeName.Properties.RowEdit = this.repositoryItemTextEditToSchemeName;
            this.ToSchemeName.Properties.AllowEdit = false;
            //
            // Amount
            //
            this.Amount.Name = "Amount";
            this.Amount.Properties.Caption = "Amount";
            this.Amount.Properties.FieldName = "Amount";
            this.Amount.Properties.Format.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.Amount.Properties.RowEdit = this.repositoryItemTextEditAmount;            
            //
            // VGridControl
            //
            this.vGridTransaction.Name = GRID_NAME;
            this.vGridTransaction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));

            this.vGridTransaction.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
                this.repositoryItemFromSchemeName,
                this.repositoryItemTextEditToSchemeName,             
                this.repositoryItemTextEditAmount
            });

            this.vGridTransaction.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
                this.FromSchemeName,
                this.ToSchemeName,                              
                this.Amount
              });
            prepareOptionalFieldsList();

        }

        private void loadSchemes()
        {
            SchemeInfo schemeInfo = new SchemeInfo();
            schemes = schemeInfo.GetAll(amcId);
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
                LogDebug("SwitchTypeInvRecommendation.BindDataSource()", new ArgumentNullException("object value is null"));
                return;
            }


            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
            SwitchTypeInvestmentRecommendation switchTypeInvestment = jsonSerialization.DeserializeFromString<FinancialPlanner.Common.Model.SwitchTypeInvestmentRecommendation>(obj.ToString());
            this.vGridTransaction.Rows["SchemeName"].Properties.Value = switchTypeInvestment.ToSchemeName;
            this.vGridTransaction.Rows["Amount"].Properties.Value = switchTypeInvestment.Amount;
            this.clientId = switchTypeInvestment.Cid;
        }

        public VGridControl GetGridControl()
        {
            throw new NotImplementedException();
        }

        public object GetTransactionType()
        {
            SwitchTypeInvestmentRecommendation switchTypeInvestment = new SwitchTypeInvestmentRecommendation();
            if (this.vGridTransaction.Rows.Count > 0)
            {
                switchTypeInvestment.Cid = this.clientId;
                switchTypeInvestment.FromSchemeId =  (this.vGridTransaction.Rows["FromSchemeName"].Properties.Value != null) ?
                   int.Parse( this.vGridTransaction.Rows["FromSchemeName"].Properties.Value.ToString()) : 0;

                switchTypeInvestment.FromSchemeName = getSelectedScheme(switchTypeInvestment.FromSchemeId).Name;               
                switchTypeInvestment.Amount = double.Parse(this.vGridTransaction.Rows["Amount"].Properties.Value.ToString());             
            }
            return switchTypeInvestment;
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
