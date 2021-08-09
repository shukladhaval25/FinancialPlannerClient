﻿namespace FinancialPlannerClient.Insurance
{
    partial class EstimatedInsuranceCoverageView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EstimatedInsuranceCoverageView));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtEstimatedIsurnceCoverage = new DevExpress.XtraEditors.TextEdit();
            this.gridInsuranceCalculation = new DevExpress.XtraGrid.GridControl();
            this.gridViewInsuranceCalculation = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            this.gridInsuranceCoverage = new DevExpress.XtraGrid.GridControl();
            this.gridViewInsuranceCoverage = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnCategory = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnContent = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.txtEstimatedIsurnceCoverage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInsuranceCalculation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInsuranceCalculation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInsuranceCoverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInsuranceCoverage)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(192, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Estimated Insurance Coverage Amount:";
            // 
            // txtEstimatedIsurnceCoverage
            // 
            this.txtEstimatedIsurnceCoverage.EditValue = "";
            this.txtEstimatedIsurnceCoverage.Location = new System.Drawing.Point(212, 13);
            this.txtEstimatedIsurnceCoverage.Name = "txtEstimatedIsurnceCoverage";
            this.txtEstimatedIsurnceCoverage.Properties.Appearance.Options.UseTextOptions = true;
            this.txtEstimatedIsurnceCoverage.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtEstimatedIsurnceCoverage.Properties.ReadOnly = true;
            this.txtEstimatedIsurnceCoverage.Size = new System.Drawing.Size(145, 20);
            this.txtEstimatedIsurnceCoverage.TabIndex = 1;
            // 
            // gridInsuranceCalculation
            // 
            this.gridInsuranceCalculation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridInsuranceCalculation.Location = new System.Drawing.Point(13, 43);
            this.gridInsuranceCalculation.MainView = this.gridViewInsuranceCalculation;
            this.gridInsuranceCalculation.Name = "gridInsuranceCalculation";
            this.gridInsuranceCalculation.Size = new System.Drawing.Size(930, 45);
            this.gridInsuranceCalculation.TabIndex = 2;
            this.gridInsuranceCalculation.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewInsuranceCalculation});
            this.gridInsuranceCalculation.Visible = false;
            // 
            // gridViewInsuranceCalculation
            // 
            this.gridViewInsuranceCalculation.GridControl = this.gridInsuranceCalculation;
            this.gridViewInsuranceCalculation.Name = "gridViewInsuranceCalculation";
            // 
            // progressPanel1
            // 
            this.progressPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel1.Appearance.Options.UseBackColor = true;
            this.progressPanel1.BarAnimationElementThickness = 2;
            this.progressPanel1.Location = new System.Drawing.Point(357, 218);
            this.progressPanel1.Name = "progressPanel1";
            this.progressPanel1.Size = new System.Drawing.Size(246, 48);
            this.progressPanel1.TabIndex = 3;
            this.progressPanel1.Text = "progressPanel1";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Location = new System.Drawing.Point(907, 49);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(23, 23);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export To Excel";
            this.btnExport.ToolTip = "Export to excel";
            this.btnExport.ToolTipTitle = "Export";
            this.btnExport.Visible = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // gridInsuranceCoverage
            // 
            this.gridInsuranceCoverage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridInsuranceCoverage.Location = new System.Drawing.Point(12, 49);
            this.gridInsuranceCoverage.MainView = this.gridViewInsuranceCoverage;
            this.gridInsuranceCoverage.Name = "gridInsuranceCoverage";
            this.gridInsuranceCoverage.Size = new System.Drawing.Size(931, 422);
            this.gridInsuranceCoverage.TabIndex = 9;
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
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumnCategory, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.gridColumnContent, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // gridColumnCategory
            // 
            this.gridColumnCategory.Caption = "Category";
            this.gridColumnCategory.FieldName = "Category";
            this.gridColumnCategory.Name = "gridColumnCategory";
            this.gridColumnCategory.OptionsEditForm.Visible = DevExpress.Utils.DefaultBoolean.False;
            // 
            // gridColumnContent
            // 
            this.gridColumnContent.Caption = "Content";
            this.gridColumnContent.FieldName = "Item";
            this.gridColumnContent.Name = "gridColumnContent";
            this.gridColumnContent.Visible = true;
            this.gridColumnContent.VisibleIndex = 0;
            // 
            // gridColumnAmount
            // 
            this.gridColumnAmount.Caption = "Amount";
            this.gridColumnAmount.FieldName = "Amount";
            this.gridColumnAmount.Name = "gridColumnAmount";
            this.gridColumnAmount.Visible = true;
            this.gridColumnAmount.VisibleIndex = 1;
            // 
            // EstimatedInsuranceCoverageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 483);
            this.Controls.Add(this.progressPanel1);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.gridInsuranceCalculation);
            this.Controls.Add(this.txtEstimatedIsurnceCoverage);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.gridInsuranceCoverage);
            this.Name = "EstimatedInsuranceCoverageView";
            this.Text = "aa";
            this.Load += new System.EventHandler(this.EstimatedInsuranceCoverageView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtEstimatedIsurnceCoverage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInsuranceCalculation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInsuranceCalculation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInsuranceCoverage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInsuranceCoverage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtEstimatedIsurnceCoverage;
        private DevExpress.XtraGrid.GridControl gridInsuranceCalculation;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewInsuranceCalculation;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;
        private DevExpress.XtraEditors.SimpleButton btnExport;
        private DevExpress.XtraGrid.GridControl gridInsuranceCoverage;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewInsuranceCoverage;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnCategory;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnContent;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnAmount;
    }
}