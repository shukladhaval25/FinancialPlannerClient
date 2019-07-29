using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraVerticalGrid;

namespace FinancialPlannerClient.TaskManagementSystem.TransactionOptions
{
    public class FreshPurchase : ITransactionType
    {
        readonly string GRIDNAME = "vGridFreshPurchase";
        DevExpress.XtraVerticalGrid.VGridControl vGridTransaction;

        private DevExpress.XtraVerticalGrid.Rows.EditorRow ARN;
        private DevExpress.XtraVerticalGrid.Rows.EditorRow ClientGroup;
        private List<DevExpress.XtraVerticalGrid.Rows.EditorRow> editorRows;

        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemARN;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxClientGroup;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox2;
        public FreshPurchase()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            vGridTransaction = new DevExpress.XtraVerticalGrid.VGridControl();
            this.ARN = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.ClientGroup = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            this.repositoryItemARN = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemComboBoxClientGroup = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.editorRows = new List<DevExpress.XtraVerticalGrid.Rows.EditorRow>();
            // 
            // ARN
            // 
            this.ARN.Name = "ARN";
            this.ARN.Properties.FieldName = "ARN";
            this.ARN.Properties.RowEdit = this.repositoryItemARN;
            //
            // ClientGroup
            //
            this.ClientGroup.Name = "ClientGroup";
            this.ClientGroup.Properties.FieldName = "ClientGroup";
            this.ClientGroup.Properties.RowEdit = this.repositoryItemComboBoxClientGroup;
            //
            // VGridControl
            //
            this.vGridTransaction.Name = GRIDNAME;
            this.vGridTransaction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                | System.Windows.Forms.AnchorStyles.Left)
                | System.Windows.Forms.AnchorStyles.Right)));
            this.vGridTransaction.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemARN,this.repositoryItemComboBoxClientGroup});
            this.vGridTransaction.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            this.ARN,
            this.ClientGroup});

            this.editorRows.Add(this.ARN);
            this.editorRows.Add(this.ClientGroup);

        }

        public void BindDataSource(DataTable dataTable)
        {
            this.vGridTransaction.DataSource = dataTable;
        }

        public DevExpress.XtraVerticalGrid.Rows.BaseRow[] GetBaseRows()
        {
            return new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
                 this.ARN,this.ClientGroup};
        }
        public DevExpress.XtraEditors.Repository.RepositoryItem[] GetRepositoryItems()
        {
            return new DevExpress.XtraEditors.Repository.RepositoryItem[]
            {
                this.repositoryItemARN,this.repositoryItemComboBoxClientGroup
            };
        }

        public VGridControl GetGridControl()
        {
            return this.vGridTransaction;
        }

        public void HideGridControl()
        {
            this.vGridTransaction.Height = 0;
            this.vGridTransaction.Width = 0;
            this.vGridTransaction.Visible = false;
        }
    }
}
