namespace FinancialPlannerClient.Review
{
    partial class QuarterlyReviewTemplateView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuarterlyReviewTemplateView));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            this.grpOptions = new DevExpress.XtraEditors.GroupControl();
            this.chkLoan = new DevExpress.XtraEditors.CheckEdit();
            this.gridQuarterlyReview = new DevExpress.XtraGrid.GridControl();
            this.gridViewQuarterlyReview = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.IsSelected = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.TypeOfInvestment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnCloseClientInfo = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveAssumption = new DevExpress.XtraEditors.SimpleButton();
            this.btnSendInvestmentReport = new DevExpress.XtraEditors.SimpleButton();
            this.btnViewReport = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grpOptions)).BeginInit();
            this.grpOptions.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkLoan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridQuarterlyReview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewQuarterlyReview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpOptions
            // 
            this.grpOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpOptions.Controls.Add(this.chkLoan);
            this.grpOptions.Controls.Add(this.gridQuarterlyReview);
            this.grpOptions.Location = new System.Drawing.Point(13, 13);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(838, 357);
            this.grpOptions.TabIndex = 0;
            this.grpOptions.Text = "Select option to send email before quaterly review";
            // 
            // chkLoan
            // 
            this.chkLoan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkLoan.Location = new System.Drawing.Point(6, 328);
            this.chkLoan.Name = "chkLoan";
            this.chkLoan.Properties.Caption = "Send Loan Details";
            this.chkLoan.Size = new System.Drawing.Size(116, 19);
            this.chkLoan.TabIndex = 1;
            // 
            // gridQuarterlyReview
            // 
            this.gridQuarterlyReview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridQuarterlyReview.Location = new System.Drawing.Point(6, 24);
            this.gridQuarterlyReview.MainView = this.gridViewQuarterlyReview;
            this.gridQuarterlyReview.Name = "gridQuarterlyReview";
            this.gridQuarterlyReview.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridQuarterlyReview.Size = new System.Drawing.Size(827, 298);
            this.gridQuarterlyReview.TabIndex = 0;
            this.gridQuarterlyReview.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewQuarterlyReview});
            // 
            // gridViewQuarterlyReview
            // 
            this.gridViewQuarterlyReview.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.IsSelected,
            this.TypeOfInvestment});
            this.gridViewQuarterlyReview.GridControl = this.gridQuarterlyReview;
            this.gridViewQuarterlyReview.Name = "gridViewQuarterlyReview";
            this.gridViewQuarterlyReview.OptionsView.ShowGroupPanel = false;
            // 
            // IsSelected
            // 
            this.IsSelected.Caption = "Select";
            this.IsSelected.ColumnEdit = this.repositoryItemCheckEdit1;
            this.IsSelected.FieldName = "IsSelected";
            this.IsSelected.Name = "IsSelected";
            this.IsSelected.Visible = true;
            this.IsSelected.VisibleIndex = 0;
            this.IsSelected.Width = 62;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // TypeOfInvestment
            // 
            this.TypeOfInvestment.Caption = "Type of Investment";
            this.TypeOfInvestment.FieldName = "TypeOfInvestment";
            this.TypeOfInvestment.Name = "TypeOfInvestment";
            this.TypeOfInvestment.OptionsColumn.AllowEdit = false;
            this.TypeOfInvestment.Visible = true;
            this.TypeOfInvestment.VisibleIndex = 1;
            this.TypeOfInvestment.Width = 747;
            // 
            // btnCloseClientInfo
            // 
            this.btnCloseClientInfo.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCloseClientInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseClientInfo.Image")));
            this.btnCloseClientInfo.Location = new System.Drawing.Point(73, 376);
            this.btnCloseClientInfo.Name = "btnCloseClientInfo";
            this.btnCloseClientInfo.Size = new System.Drawing.Size(62, 23);
            this.btnCloseClientInfo.TabIndex = 25;
            this.btnCloseClientInfo.Text = "Close";
            this.btnCloseClientInfo.Click += new System.EventHandler(this.btnCloseClientInfo_Click);
            // 
            // btnSaveAssumption
            // 
            this.btnSaveAssumption.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnSaveAssumption.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAssumption.Image")));
            this.btnSaveAssumption.Location = new System.Drawing.Point(10, 376);
            this.btnSaveAssumption.Name = "btnSaveAssumption";
            this.btnSaveAssumption.Size = new System.Drawing.Size(57, 23);
            toolTipTitleItem1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            toolTipTitleItem1.Appearance.Options.UseImage = true;
            toolTipTitleItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem1.Image")));
            toolTipTitleItem1.Text = "Save";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "To save client contact infroamtion click here.";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.btnSaveAssumption.SuperTip = superToolTip1;
            this.btnSaveAssumption.TabIndex = 24;
            this.btnSaveAssumption.Text = "Save";
            this.btnSaveAssumption.Click += new System.EventHandler(this.btnSaveAssumption_Click);
            // 
            // btnSendInvestmentReport
            // 
            this.btnSendInvestmentReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSendInvestmentReport.ImageUri.Uri = "SendPDF;Size16x16";
            this.btnSendInvestmentReport.Location = new System.Drawing.Point(141, 376);
            this.btnSendInvestmentReport.Name = "btnSendInvestmentReport";
            this.btnSendInvestmentReport.Size = new System.Drawing.Size(87, 23);
            this.btnSendInvestmentReport.TabIndex = 35;
            this.btnSendInvestmentReport.Text = "Send Email";
            this.btnSendInvestmentReport.Click += new System.EventHandler(this.btnSendInvestmentReport_Click);
            // 
            // btnViewReport
            // 
            this.btnViewReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnViewReport.ImageUri.Uri = "Preview;Size16x16";
            this.btnViewReport.Location = new System.Drawing.Point(234, 376);
            this.btnViewReport.Name = "btnViewReport";
            this.btnViewReport.Size = new System.Drawing.Size(87, 23);
            this.btnViewReport.TabIndex = 36;
            this.btnViewReport.Text = "View Report";
            this.btnViewReport.Click += new System.EventHandler(this.btnViewReport_Click);
            // 
            // QuarterlyReviewTemplateView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 411);
            this.Controls.Add(this.btnViewReport);
            this.Controls.Add(this.btnSendInvestmentReport);
            this.Controls.Add(this.btnCloseClientInfo);
            this.Controls.Add(this.btnSaveAssumption);
            this.Controls.Add(this.grpOptions);
            this.Name = "QuarterlyReviewTemplateView";
            this.Text = "Quarterly Reivew Setting";
            this.Load += new System.EventHandler(this.QuarterlyReviewSendSetting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpOptions)).EndInit();
            this.grpOptions.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chkLoan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridQuarterlyReview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewQuarterlyReview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpOptions;
        private DevExpress.XtraGrid.GridControl gridQuarterlyReview;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewQuarterlyReview;
        private DevExpress.XtraGrid.Columns.GridColumn IsSelected;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn TypeOfInvestment;
        private DevExpress.XtraEditors.CheckEdit chkLoan;
        private DevExpress.XtraEditors.SimpleButton btnCloseClientInfo;
        private DevExpress.XtraEditors.SimpleButton btnSaveAssumption;
        private DevExpress.XtraEditors.SimpleButton btnSendInvestmentReport;
        private DevExpress.XtraEditors.SimpleButton btnViewReport;
    }
}