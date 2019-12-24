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
            this.btnShowCalculation = new DevExpress.XtraEditors.SimpleButton();
            this.grpEstimatedInsCoverage = new DevExpress.XtraEditors.GroupControl();
            this.txtEstimatedIsurnceCoverage = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridInsuranceCoverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInsuranceCoverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlFinancialAssert)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFinancialAsset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpEstimatedInsCoverage)).BeginInit();
            this.grpEstimatedInsCoverage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEstimatedIsurnceCoverage.Properties)).BeginInit();
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
            this.gridInsuranceCoverage.Location = new System.Drawing.Point(12, 27);
            this.gridInsuranceCoverage.MainView = this.gridViewInsuranceCoverage;
            this.gridInsuranceCoverage.Name = "gridInsuranceCoverage";
            this.gridInsuranceCoverage.Size = new System.Drawing.Size(679, 322);
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
            this.gridControlFinancialAssert.Location = new System.Drawing.Point(12, 355);
            this.gridControlFinancialAssert.MainView = this.gridViewFinancialAsset;
            this.gridControlFinancialAssert.Name = "gridControlFinancialAssert";
            this.gridControlFinancialAssert.Size = new System.Drawing.Size(679, 174);
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
            // btnShowCalculation
            // 
            this.btnShowCalculation.Location = new System.Drawing.Point(78, 77);
            this.btnShowCalculation.Name = "btnShowCalculation";
            this.btnShowCalculation.Size = new System.Drawing.Size(102, 23);
            this.btnShowCalculation.TabIndex = 10;
            this.btnShowCalculation.Text = "Show Calculation";
            this.btnShowCalculation.Click += new System.EventHandler(this.btnShowCalculation_Click);
            // 
            // grpEstimatedInsCoverage
            // 
            this.grpEstimatedInsCoverage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpEstimatedInsCoverage.Controls.Add(this.txtEstimatedIsurnceCoverage);
            this.grpEstimatedInsCoverage.Controls.Add(this.btnShowCalculation);
            this.grpEstimatedInsCoverage.Controls.Add(this.labelControl1);
            this.grpEstimatedInsCoverage.Location = new System.Drawing.Point(698, 27);
            this.grpEstimatedInsCoverage.Name = "grpEstimatedInsCoverage";
            this.grpEstimatedInsCoverage.Size = new System.Drawing.Size(252, 107);
            this.grpEstimatedInsCoverage.TabIndex = 11;
            this.grpEstimatedInsCoverage.Text = "Insurance";
            // 
            // txtEstimatedIsurnceCoverage
            // 
            this.txtEstimatedIsurnceCoverage.EditValue = "";
            this.txtEstimatedIsurnceCoverage.Location = new System.Drawing.Point(5, 51);
            this.txtEstimatedIsurnceCoverage.Name = "txtEstimatedIsurnceCoverage";
            this.txtEstimatedIsurnceCoverage.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEstimatedIsurnceCoverage.Properties.Appearance.Options.UseFont = true;
            this.txtEstimatedIsurnceCoverage.Properties.Appearance.Options.UseTextOptions = true;
            this.txtEstimatedIsurnceCoverage.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtEstimatedIsurnceCoverage.Properties.ReadOnly = true;
            this.txtEstimatedIsurnceCoverage.Size = new System.Drawing.Size(239, 20);
            this.txtEstimatedIsurnceCoverage.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(29, 32);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(192, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Estimated Insurance Coverage Amount:";
            // 
            // InsuranceCalculation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(961, 541);
            this.Controls.Add(this.grpEstimatedInsCoverage);
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
            ((System.ComponentModel.ISupportInitialize)(this.grpEstimatedInsCoverage)).EndInit();
            this.grpEstimatedInsCoverage.ResumeLayout(false);
            this.grpEstimatedInsCoverage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtEstimatedIsurnceCoverage.Properties)).EndInit();
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
        private DevExpress.XtraEditors.SimpleButton btnShowCalculation;
        private DevExpress.XtraEditors.GroupControl grpEstimatedInsCoverage;
        private DevExpress.XtraEditors.TextEdit txtEstimatedIsurnceCoverage;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}

