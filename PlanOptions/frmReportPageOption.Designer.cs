namespace FinancialPlannerClient.PlanOptions
{
    partial class frmReportPageOption
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
            this.gridControlReport = new DevExpress.XtraGrid.GridControl();
            this.gridViewReport = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.lblContactTitle = new DevExpress.XtraEditors.LabelControl();
            this.btnApply = new DevExpress.XtraEditors.SimpleButton();
            this.gridColumnIsSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPage = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewReport)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlReport
            // 
            this.gridControlReport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlReport.Location = new System.Drawing.Point(3, 27);
            this.gridControlReport.MainView = this.gridViewReport;
            this.gridControlReport.Name = "gridControlReport";
            this.gridControlReport.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControlReport.Size = new System.Drawing.Size(793, 402);
            this.gridControlReport.TabIndex = 4;
            this.gridControlReport.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewReport});
            // 
            // gridViewReport
            // 
            this.gridViewReport.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnIsSelected,
            this.gridColumnPage});
            this.gridViewReport.GridControl = this.gridControlReport;
            this.gridViewReport.Name = "gridViewReport";
            this.gridViewReport.OptionsView.ShowGroupPanel = false;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
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
            this.lblContactTitle.Size = new System.Drawing.Size(799, 21);
            this.lblContactTitle.TabIndex = 6;
            this.lblContactTitle.Text = "Choose the page which you want to include in report generation.";
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(358, 440);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 7;
            this.btnApply.Text = "Apply";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // gridColumnIsSelected
            // 
            this.gridColumnIsSelected.Caption = "Select";
            this.gridColumnIsSelected.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumnIsSelected.FieldName = "IsSelected";
            this.gridColumnIsSelected.Name = "gridColumnIsSelected";
            this.gridColumnIsSelected.Visible = true;
            this.gridColumnIsSelected.VisibleIndex = 0;
            this.gridColumnIsSelected.Width = 57;
            // 
            // gridColumnPage
            // 
            this.gridColumnPage.Caption = "Report Page";
            this.gridColumnPage.FieldName = "Page";
            this.gridColumnPage.Name = "gridColumnPage";
            this.gridColumnPage.OptionsColumn.AllowEdit = false;
            this.gridColumnPage.OptionsColumn.ReadOnly = true;
            this.gridColumnPage.Visible = true;
            this.gridColumnPage.VisibleIndex = 1;
            this.gridColumnPage.Width = 718;
            // 
            // frmReportPageOption
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 475);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.lblContactTitle);
            this.Controls.Add(this.gridControlReport);
            this.Name = "frmReportPageOption";
            this.Text = "Report Page Option";
            this.Load += new System.EventHandler(this.frmReportPageOption_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewReport)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlReport;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewReport;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraEditors.LabelControl lblContactTitle;
        private DevExpress.XtraEditors.SimpleButton btnApply;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnIsSelected;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPage;
    }
}