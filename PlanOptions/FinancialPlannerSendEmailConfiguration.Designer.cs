namespace FinancialPlannerClient.PlanOptions
{
    partial class FinancialPlannerSendEmailConfiguration
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FinancialPlannerSendEmailConfiguration));
            this.grpParams = new DevExpress.XtraEditors.GroupControl();
            this.grpAttachments = new DevExpress.XtraEditors.GroupControl();
            this.picProcessing = new DevExpress.XtraEditors.PictureEdit();
            this.grdAttachment = new DevExpress.XtraGrid.GridControl();
            this.gridViewAttachment = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnImg = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.gridColumnFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnFilePath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtSubject = new DevExpress.XtraEditors.TextEdit();
            this.btnSendFinancialPlannerReport = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtToEmail = new DevExpress.XtraEditors.TextEdit();
            this.txtEmaiBody = new DevExpress.XtraEditors.MemoEdit();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtCC = new DevExpress.XtraEditors.TextEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grpParams)).BeginInit();
            this.grpParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpAttachments)).BeginInit();
            this.grpAttachments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picProcessing.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAttachment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAttachment)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmaiBody.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCC.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grpParams
            // 
            this.grpParams.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpParams.Controls.Add(this.labelControl4);
            this.grpParams.Controls.Add(this.txtCC);
            this.grpParams.Controls.Add(this.grpAttachments);
            this.grpParams.Controls.Add(this.labelControl3);
            this.grpParams.Controls.Add(this.txtSubject);
            this.grpParams.Controls.Add(this.btnSendFinancialPlannerReport);
            this.grpParams.Controls.Add(this.labelControl2);
            this.grpParams.Controls.Add(this.labelControl1);
            this.grpParams.Controls.Add(this.txtToEmail);
            this.grpParams.Controls.Add(this.txtEmaiBody);
            this.grpParams.Location = new System.Drawing.Point(12, 12);
            this.grpParams.Name = "grpParams";
            this.grpParams.Size = new System.Drawing.Size(796, 559);
            this.grpParams.TabIndex = 1;
            // 
            // grpAttachments
            // 
            this.grpAttachments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAttachments.Controls.Add(this.picProcessing);
            this.grpAttachments.Controls.Add(this.grdAttachment);
            this.grpAttachments.Location = new System.Drawing.Point(16, 437);
            this.grpAttachments.Name = "grpAttachments";
            this.grpAttachments.Size = new System.Drawing.Size(764, 86);
            this.grpAttachments.TabIndex = 41;
            this.grpAttachments.Text = "Attachments";
            // 
            // picProcessing
            // 
            this.picProcessing.Cursor = System.Windows.Forms.Cursors.Default;
            this.picProcessing.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picProcessing.EditValue = global::FinancialPlannerClient.Properties.Resources.processing_gif_image_14;
            this.picProcessing.Location = new System.Drawing.Point(2, 20);
            this.picProcessing.Name = "picProcessing";
            this.picProcessing.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picProcessing.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.picProcessing.Properties.ZoomAccelerationFactor = 1D;
            this.picProcessing.Size = new System.Drawing.Size(760, 64);
            this.picProcessing.TabIndex = 12;
            // 
            // grdAttachment
            // 
            this.grdAttachment.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdAttachment.Location = new System.Drawing.Point(5, 23);
            this.grdAttachment.MainView = this.gridViewAttachment;
            this.grdAttachment.Name = "grdAttachment";
            this.grdAttachment.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemImageEdit1,
            this.repositoryItemImageEdit2});
            this.grdAttachment.Size = new System.Drawing.Size(754, 58);
            this.grdAttachment.TabIndex = 1;
            this.grdAttachment.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewAttachment});
            // 
            // gridViewAttachment
            // 
            this.gridViewAttachment.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnImg,
            this.gridColumnFileName,
            this.gridColumnFilePath});
            this.gridViewAttachment.GridControl = this.grdAttachment;
            this.gridViewAttachment.Name = "gridViewAttachment";
            this.gridViewAttachment.OptionsBehavior.Editable = false;
            this.gridViewAttachment.OptionsView.ShowGroupPanel = false;
            this.gridViewAttachment.CustomRowCellEdit += new DevExpress.XtraGrid.Views.Grid.CustomRowCellEditEventHandler(this.gridViewAttachment_CustomRowCellEdit);
            // 
            // gridColumnImg
            // 
            this.gridColumnImg.Caption = "Img";
            this.gridColumnImg.ColumnEdit = this.repositoryItemImageEdit1;
            this.gridColumnImg.Name = "gridColumnImg";
            this.gridColumnImg.OptionsColumn.ShowCaption = false;
            this.gridColumnImg.Visible = true;
            this.gridColumnImg.VisibleIndex = 0;
            this.gridColumnImg.Width = 23;
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            // 
            // gridColumnFileName
            // 
            this.gridColumnFileName.Caption = "gridColumn2";
            this.gridColumnFileName.FieldName = "FileName";
            this.gridColumnFileName.Name = "gridColumnFileName";
            this.gridColumnFileName.OptionsColumn.AllowEdit = false;
            this.gridColumnFileName.OptionsColumn.ReadOnly = true;
            this.gridColumnFileName.OptionsColumn.ShowCaption = false;
            this.gridColumnFileName.Visible = true;
            this.gridColumnFileName.VisibleIndex = 1;
            this.gridColumnFileName.Width = 713;
            // 
            // gridColumnFilePath
            // 
            this.gridColumnFilePath.Caption = "gridColumn3";
            this.gridColumnFilePath.FieldName = "FilePath";
            this.gridColumnFilePath.Name = "gridColumnFilePath";
            this.gridColumnFilePath.OptionsColumn.AllowEdit = false;
            this.gridColumnFilePath.OptionsColumn.ReadOnly = true;
            this.gridColumnFilePath.OptionsColumn.ShowCaption = false;
            // 
            // repositoryItemImageEdit2
            // 
            this.repositoryItemImageEdit2.AutoHeight = false;
            this.repositoryItemImageEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit2.Name = "repositoryItemImageEdit2";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(16, 107);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(39, 13);
            this.labelControl3.TabIndex = 38;
            this.labelControl3.Text = "Content";
            // 
            // txtSubject
            // 
            this.txtSubject.Location = new System.Drawing.Point(109, 68);
            this.txtSubject.Name = "txtSubject";
            this.txtSubject.Size = new System.Drawing.Size(671, 20);
            this.txtSubject.TabIndex = 37;
            // 
            // btnSendFinancialPlannerReport
            // 
            this.btnSendFinancialPlannerReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSendFinancialPlannerReport.Enabled = false;
            this.btnSendFinancialPlannerReport.ImageUri.Uri = "SendPDF;Size16x16";
            this.btnSendFinancialPlannerReport.Location = new System.Drawing.Point(354, 529);
            this.btnSendFinancialPlannerReport.Name = "btnSendFinancialPlannerReport";
            this.btnSendFinancialPlannerReport.Size = new System.Drawing.Size(88, 23);
            this.btnSendFinancialPlannerReport.TabIndex = 35;
            this.btnSendFinancialPlannerReport.Text = "Send Email";
            this.btnSendFinancialPlannerReport.Click += new System.EventHandler(this.btnSendFinancialPlannerReport_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(16, 73);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(40, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Subject:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(16, 45);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(16, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "To:";
            // 
            // txtToEmail
            // 
            this.txtToEmail.Location = new System.Drawing.Point(109, 42);
            this.txtToEmail.Name = "txtToEmail";
            this.txtToEmail.Properties.ReadOnly = true;
            this.txtToEmail.Size = new System.Drawing.Size(324, 20);
            this.txtToEmail.TabIndex = 36;
            // 
            // txtEmaiBody
            // 
            this.txtEmaiBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtEmaiBody.Location = new System.Drawing.Point(11, 130);
            this.txtEmaiBody.Name = "txtEmaiBody";
            this.txtEmaiBody.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEmaiBody.Properties.Appearance.Options.UseFont = true;
            this.txtEmaiBody.Size = new System.Drawing.Size(764, 301);
            this.txtEmaiBody.TabIndex = 39;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "pdfIcon32x32.png");
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(439, 45);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(18, 13);
            this.labelControl4.TabIndex = 42;
            this.labelControl4.Text = "CC:";
            // 
            // txtCC
            // 
            this.txtCC.Location = new System.Drawing.Point(463, 42);
            this.txtCC.Name = "txtCC";
            this.txtCC.Properties.ReadOnly = true;
            this.txtCC.Size = new System.Drawing.Size(317, 20);
            this.txtCC.TabIndex = 43;
            // 
            // FinancialPlannerSendEmailConfiguration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(820, 573);
            this.Controls.Add(this.grpParams);
            this.Name = "FinancialPlannerSendEmailConfiguration";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Financial Planner Email";
            this.Load += new System.EventHandler(this.FinancialPlannerSendEmailConfiguration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpParams)).EndInit();
            this.grpParams.ResumeLayout(false);
            this.grpParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpAttachments)).EndInit();
            this.grpAttachments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picProcessing.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdAttachment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAttachment)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSubject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtToEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEmaiBody.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCC.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpParams;
        private DevExpress.XtraEditors.SimpleButton btnSendFinancialPlannerReport;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtSubject;
        private DevExpress.XtraEditors.TextEdit txtToEmail;
        private DevExpress.XtraEditors.GroupControl grpAttachments;
        private System.Windows.Forms.ImageList imageList1;
        private DevExpress.XtraGrid.GridControl grdAttachment;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewAttachment;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnImg;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnFileName;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnFilePath;
        private DevExpress.XtraEditors.PictureEdit picProcessing;
        private DevExpress.XtraEditors.MemoEdit txtEmaiBody;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtCC;
    }
}