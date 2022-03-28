namespace FinancialPlannerClient.PlanOptions
{
    partial class ReportParams
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
            this.grpParams = new DevExpress.XtraEditors.GroupControl();
            this.btnReportPage = new DevExpress.XtraEditors.SimpleButton();
            this.btnSendFinancialPlannerReport = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.cmbPlanOption = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtRecomendation = new DevExpress.XtraEditors.RichTextEdit();
            this.grpNetWorthDetails = new DevExpress.XtraEditors.GroupControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtModelPortfolioNote = new DevExpress.XtraEditors.RichTextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cmbRiskProfile = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grpParams)).BeginInit();
            this.grpParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPlanOption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRecomendation.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpNetWorthDetails)).BeginInit();
            this.grpNetWorthDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtModelPortfolioNote.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRiskProfile.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grpParams
            // 
            this.grpParams.Controls.Add(this.groupControl1);
            this.grpParams.Controls.Add(this.grpNetWorthDetails);
            this.grpParams.Controls.Add(this.btnReportPage);
            this.grpParams.Controls.Add(this.btnSendFinancialPlannerReport);
            this.grpParams.Controls.Add(this.btnOk);
            this.grpParams.Location = new System.Drawing.Point(6, 12);
            this.grpParams.Name = "grpParams";
            this.grpParams.Size = new System.Drawing.Size(744, 266);
            this.grpParams.TabIndex = 0;
            // 
            // btnReportPage
            // 
            this.btnReportPage.ImageUri.Uri = "CustomizeGrid;Size16x16";
            this.btnReportPage.Location = new System.Drawing.Point(84, 236);
            this.btnReportPage.Name = "btnReportPage";
            this.btnReportPage.Size = new System.Drawing.Size(94, 23);
            this.btnReportPage.TabIndex = 36;
            this.btnReportPage.Text = "Page Setting";
            this.btnReportPage.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // btnSendFinancialPlannerReport
            // 
            this.btnSendFinancialPlannerReport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSendFinancialPlannerReport.ImageUri.Uri = "SendPDF;Size16x16";
            this.btnSendFinancialPlannerReport.Location = new System.Drawing.Point(648, 234);
            this.btnSendFinancialPlannerReport.Name = "btnSendFinancialPlannerReport";
            this.btnSendFinancialPlannerReport.Size = new System.Drawing.Size(88, 23);
            this.btnSendFinancialPlannerReport.TabIndex = 35;
            this.btnSendFinancialPlannerReport.Text = "Send Email";
            this.btnSendFinancialPlannerReport.Click += new System.EventHandler(this.btnSendFinancialPlannerReport_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(5, 58);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(74, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Recomendation";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(3, 236);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cmbPlanOption
            // 
            this.cmbPlanOption.Location = new System.Drawing.Point(79, 27);
            this.cmbPlanOption.Name = "cmbPlanOption";
            this.cmbPlanOption.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPlanOption.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbPlanOption.Size = new System.Drawing.Size(279, 20);
            this.cmbPlanOption.TabIndex = 1;
            this.cmbPlanOption.SelectedIndexChanged += new System.EventHandler(this.cmbPlanOption_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(5, 30);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Plan Option:";
            // 
            // txtRecomendation
            // 
            this.txtRecomendation.Location = new System.Drawing.Point(5, 77);
            this.txtRecomendation.Name = "txtRecomendation";
            this.txtRecomendation.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecomendation.Properties.Appearance.Options.UseFont = true;
            this.txtRecomendation.Size = new System.Drawing.Size(353, 111);
            this.txtRecomendation.TabIndex = 30;
            this.txtRecomendation.TextChanged += new System.EventHandler(this.txtRecomendation_TextChanged);
            // 
            // grpNetWorthDetails
            // 
            this.grpNetWorthDetails.Controls.Add(this.txtRecomendation);
            this.grpNetWorthDetails.Controls.Add(this.labelControl1);
            this.grpNetWorthDetails.Controls.Add(this.cmbPlanOption);
            this.grpNetWorthDetails.Controls.Add(this.labelControl2);
            this.grpNetWorthDetails.Location = new System.Drawing.Point(5, 23);
            this.grpNetWorthDetails.Name = "grpNetWorthDetails";
            this.grpNetWorthDetails.Size = new System.Drawing.Size(364, 196);
            this.grpNetWorthDetails.TabIndex = 37;
            this.grpNetWorthDetails.Text = "Main Report Parameters";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtModelPortfolioNote);
            this.groupControl1.Controls.Add(this.labelControl3);
            this.groupControl1.Controls.Add(this.cmbRiskProfile);
            this.groupControl1.Controls.Add(this.labelControl4);
            this.groupControl1.Location = new System.Drawing.Point(375, 23);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(364, 196);
            this.groupControl1.TabIndex = 38;
            this.groupControl1.Text = "Model Portfolio Parameters";
            // 
            // txtModelPortfolioNote
            // 
            this.txtModelPortfolioNote.Location = new System.Drawing.Point(5, 77);
            this.txtModelPortfolioNote.Name = "txtModelPortfolioNote";
            this.txtModelPortfolioNote.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtModelPortfolioNote.Properties.Appearance.Options.UseFont = true;
            this.txtModelPortfolioNote.Size = new System.Drawing.Size(353, 111);
            this.txtModelPortfolioNote.TabIndex = 30;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(5, 30);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(52, 13);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "Risk Profile";
            // 
            // cmbRiskProfile
            // 
            this.cmbRiskProfile.Location = new System.Drawing.Point(79, 27);
            this.cmbRiskProfile.Name = "cmbRiskProfile";
            this.cmbRiskProfile.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbRiskProfile.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbRiskProfile.Size = new System.Drawing.Size(279, 20);
            this.cmbRiskProfile.TabIndex = 1;
            this.cmbRiskProfile.SelectedIndexChanged += new System.EventHandler(this.cmbRiskProfile_SelectedIndexChanged);
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(5, 58);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(27, 13);
            this.labelControl4.TabIndex = 3;
            this.labelControl4.Text = "Note:";
            // 
            // ReportParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(754, 281);
            this.Controls.Add(this.grpParams);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReportParams";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report Parameters";
            this.Load += new System.EventHandler(this.ReportParams_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpParams)).EndInit();
            this.grpParams.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbPlanOption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtRecomendation.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpNetWorthDetails)).EndInit();
            this.grpNetWorthDetails.ResumeLayout(false);
            this.grpNetWorthDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtModelPortfolioNote.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbRiskProfile.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpParams;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        internal DevExpress.XtraEditors.RichTextEdit txtRecomendation;
        private DevExpress.XtraEditors.SimpleButton btnSendFinancialPlannerReport;
        internal DevExpress.XtraEditors.ComboBoxEdit cmbPlanOption;
        private DevExpress.XtraEditors.SimpleButton btnReportPage;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        internal DevExpress.XtraEditors.RichTextEdit txtModelPortfolioNote;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        internal DevExpress.XtraEditors.ComboBoxEdit cmbRiskProfile;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.GroupControl grpNetWorthDetails;
    }
}

