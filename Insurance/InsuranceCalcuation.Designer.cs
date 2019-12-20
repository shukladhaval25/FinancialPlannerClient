namespace FinancialPlannerClient.Insurance
{
    partial class InsuranceCalculation
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblContactTitle = new DevExpress.XtraEditors.LabelControl();
            this.gridInsuranceCoverage = new DevExpress.XtraGrid.GridControl();
            this.gridViewInsuranceCoverage = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnContent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControlFinancialAssert = new DevExpress.XtraGrid.GridControl();
            this.gridViewFinancialAsset = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridInsuranceCoverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInsuranceCoverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFinancialAssert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFinancialAsset)).BeginInit();
            this.SuspendLayout();
            // 
            // lblContactTitle
            // 
            this.lblContactTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblContactTitle.Appearance.Options.UseFont = true;
            this.lblContactTitle.Appearance.Options.UseForeColor = true;
            this.lblContactTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblContactTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblContactTitle.Location = new System.Drawing.Point(0, 0);
            this.lblContactTitle.Name = "lblContactTitle";
            this.lblContactTitle.Size = new System.Drawing.Size(961, 21);
            this.lblContactTitle.TabIndex = 7;
            this.lblContactTitle.Text = "Life Insurance Require Analysis";
            // 
            // gridInsuranceCoverage
            // 
            this.gridInsuranceCoverage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridInsuranceCoverage.Location = new System.Drawing.Point(12, 47);
            this.gridInsuranceCoverage.MainView = this.gridViewInsuranceCoverage;
            this.gridInsuranceCoverage.Name = "gridInsuranceCoverage";
            this.gridInsuranceCoverage.Size = new System.Drawing.Size(937, 223);
            this.gridInsuranceCoverage.TabIndex = 8;
            this.gridInsuranceCoverage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewInsuranceCoverage});
            // 
            // gridViewInsuranceCoverage
            // 
            this.gridViewInsuranceCoverage.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnCategory,
            this.gridColumnContent,
            this.gridColumnAmount});
            this.gridViewInsuranceCoverage.GridControl = this.gridInsuranceCoverage;
            this.gridViewInsuranceCoverage.GroupCount = 1;
            this.gridViewInsuranceCoverage.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", this.gridColumnAmount, "Group Total ={0:0.##}")});
            this.gridViewInsuranceCoverage.Name = "gridViewInsuranceCoverage";
            this.gridViewInsuranceCoverage.OptionsBehavior.ReadOnly = true;
            this.gridViewInsuranceCoverage.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gridViewInsuranceCoverage.OptionsView.ShowFooter = true;
            this.gridViewInsuranceCoverage.OptionsView.ShowGroupedColumns = true;
            this.gridViewInsuranceCoverage.OptionsView.ShowGroupPanel = false;
            this.gridViewInsuranceCoverage.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumnCategory, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumnCategory
            // 
            this.gridColumnCategory.Caption = "Category";
            this.gridColumnCategory.FieldName = "Category";
            this.gridColumnCategory.Name = "gridColumnCategory";
            this.gridColumnCategory.Visible = true;
            this.gridColumnCategory.VisibleIndex = 0;
            // 
            // gridColumnContent
            // 
            this.gridColumnContent.Caption = "Content";
            this.gridColumnContent.FieldName = "Content";
            this.gridColumnContent.Name = "gridColumnContent";
            this.gridColumnContent.Visible = true;
            this.gridColumnContent.VisibleIndex = 1;
            // 
            // gridColumnAmount
            // 
            this.gridColumnAmount.Caption = "Amount";
            this.gridColumnAmount.FieldName = "Amount";
            this.gridColumnAmount.Name = "gridColumnAmount";
            this.gridColumnAmount.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "Grand Total={0:0.##}")});
            this.gridColumnAmount.Visible = true;
            this.gridColumnAmount.VisibleIndex = 2;
            // 
            // gridControlFinancialAssert
            // 
            this.gridControlFinancialAssert.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlFinancialAssert.Location = new System.Drawing.Point(12, 276);
            this.gridControlFinancialAssert.MainView = this.gridViewFinancialAsset;
            this.gridControlFinancialAssert.Name = "gridControlFinancialAssert";
            this.gridControlFinancialAssert.Size = new System.Drawing.Size(937, 174);
            this.gridControlFinancialAssert.TabIndex = 9;
            this.gridControlFinancialAssert.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewFinancialAsset});
            // 
            // gridViewFinancialAsset
            // 
            this.gridViewFinancialAsset.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridViewFinancialAsset.GridControl = this.gridControlFinancialAssert;
            this.gridViewFinancialAsset.GroupCount = 1;
            this.gridViewFinancialAsset.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", this.gridColumn3, "Group Total ={0:0.##}")});
            this.gridViewFinancialAsset.Name = "gridViewFinancialAsset";
            this.gridViewFinancialAsset.OptionsBehavior.ReadOnly = true;
            this.gridViewFinancialAsset.OptionsView.GroupFooterShowMode = DevExpress.XtraGrid.Views.Grid.GroupFooterShowMode.VisibleAlways;
            this.gridViewFinancialAsset.OptionsView.ShowFooter = true;
            this.gridViewFinancialAsset.OptionsView.ShowGroupedColumns = true;
            this.gridViewFinancialAsset.OptionsView.ShowGroupPanel = false;
            this.gridViewFinancialAsset.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumn1, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Category";
            this.gridColumn1.FieldName = "Category";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Content";
            this.gridColumn2.FieldName = "Content";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Amount";
            this.gridColumn3.FieldName = "Amount";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Amount", "Grand Total={0:0.##}")});
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // InsuranceCalculation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 462);
            this.Controls.Add(this.gridControlFinancialAssert);
            this.Controls.Add(this.gridInsuranceCoverage);
            this.Controls.Add(this.lblContactTitle);
            this.Name = "InsuranceCalculation";
            this.Text = "Insurance";
            this.Load += new System.EventHandler(this.InsuranceCalculation_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridInsuranceCoverage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInsuranceCoverage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFinancialAssert)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFinancialAsset)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblContactTitle;
        private DevExpress.XtraGrid.GridControl gridInsuranceCoverage;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewInsuranceCoverage;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCategory;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnContent;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAmount;
        private DevExpress.XtraGrid.GridControl gridControlFinancialAssert;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewFinancialAsset;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
    }
}

