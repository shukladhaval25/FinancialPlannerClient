namespace FinancialPlannerClient.Insurance
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
            this.vGridScoreRange = new DevExpress.XtraVerticalGrid.VGridControl();
            this.repositoryItemComboBox1 = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEstimatedIsurnceCoverage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInsuranceCalculation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInsuranceCalculation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridScoreRange)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
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
            this.gridInsuranceCalculation.Size = new System.Drawing.Size(930, 118);
            this.gridInsuranceCalculation.TabIndex = 2;
            this.gridInsuranceCalculation.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewInsuranceCalculation});
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
            this.progressPanel1.Location = new System.Drawing.Point(351, 147);
            this.progressPanel1.Name = "progressPanel1";
            this.progressPanel1.Size = new System.Drawing.Size(246, 66);
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
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // vGridScoreRange
            // 
            this.vGridScoreRange.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vGridScoreRange.Appearance.Category.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(153)))), ((int)(((byte)(177)))));
            this.vGridScoreRange.Appearance.Category.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(153)))), ((int)(((byte)(177)))));
            this.vGridScoreRange.Appearance.Category.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.vGridScoreRange.Appearance.Category.ForeColor = System.Drawing.Color.Black;
            this.vGridScoreRange.Appearance.Category.Options.UseBackColor = true;
            this.vGridScoreRange.Appearance.Category.Options.UseBorderColor = true;
            this.vGridScoreRange.Appearance.Category.Options.UseFont = true;
            this.vGridScoreRange.Appearance.Category.Options.UseForeColor = true;
            this.vGridScoreRange.Appearance.CategoryExpandButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.vGridScoreRange.Appearance.CategoryExpandButton.Options.UseBackColor = true;
            this.vGridScoreRange.Appearance.DisabledRecordValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(179)))), ((int)(((byte)(197)))));
            this.vGridScoreRange.Appearance.DisabledRecordValue.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(163)))), ((int)(((byte)(179)))), ((int)(((byte)(197)))));
            this.vGridScoreRange.Appearance.DisabledRecordValue.ForeColor = System.Drawing.Color.Black;
            this.vGridScoreRange.Appearance.DisabledRecordValue.Options.UseBackColor = true;
            this.vGridScoreRange.Appearance.DisabledRecordValue.Options.UseBorderColor = true;
            this.vGridScoreRange.Appearance.DisabledRecordValue.Options.UseForeColor = true;
            this.vGridScoreRange.Appearance.DisabledRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(153)))), ((int)(((byte)(177)))));
            this.vGridScoreRange.Appearance.DisabledRow.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(153)))), ((int)(((byte)(177)))));
            this.vGridScoreRange.Appearance.DisabledRow.ForeColor = System.Drawing.Color.Black;
            this.vGridScoreRange.Appearance.DisabledRow.Options.UseBackColor = true;
            this.vGridScoreRange.Appearance.DisabledRow.Options.UseBorderColor = true;
            this.vGridScoreRange.Appearance.DisabledRow.Options.UseForeColor = true;
            this.vGridScoreRange.Appearance.ExpandButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(151)))), ((int)(((byte)(175)))));
            this.vGridScoreRange.Appearance.ExpandButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(101)))), ((int)(((byte)(125)))));
            this.vGridScoreRange.Appearance.ExpandButton.ForeColor = System.Drawing.Color.White;
            this.vGridScoreRange.Appearance.ExpandButton.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.vGridScoreRange.Appearance.ExpandButton.Options.UseBackColor = true;
            this.vGridScoreRange.Appearance.ExpandButton.Options.UseForeColor = true;
            this.vGridScoreRange.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.Gray;
            this.vGridScoreRange.Appearance.HideSelectionRow.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(212)))), ((int)(((byte)(208)))), ((int)(((byte)(200)))));
            this.vGridScoreRange.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.vGridScoreRange.Appearance.HideSelectionRow.Options.UseForeColor = true;
            this.vGridScoreRange.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(153)))), ((int)(((byte)(177)))));
            this.vGridScoreRange.Appearance.HorzLine.Options.UseBackColor = true;
            this.vGridScoreRange.Appearance.ReadOnlyRecordValue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(151)))), ((int)(((byte)(173)))), ((int)(((byte)(197)))));
            this.vGridScoreRange.Appearance.ReadOnlyRecordValue.Options.UseBackColor = true;
            this.vGridScoreRange.Appearance.RecordValue.BackColor = System.Drawing.Color.White;
            this.vGridScoreRange.Appearance.RecordValue.ForeColor = System.Drawing.Color.Black;
            this.vGridScoreRange.Appearance.RecordValue.Options.UseBackColor = true;
            this.vGridScoreRange.Appearance.RecordValue.Options.UseForeColor = true;
            this.vGridScoreRange.Appearance.RowHeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(79)))), ((int)(((byte)(101)))), ((int)(((byte)(125)))));
            this.vGridScoreRange.Appearance.RowHeaderPanel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(193)))), ((int)(((byte)(204)))), ((int)(((byte)(217)))));
            this.vGridScoreRange.Appearance.RowHeaderPanel.Options.UseBackColor = true;
            this.vGridScoreRange.Appearance.RowHeaderPanel.Options.UseForeColor = true;
            this.vGridScoreRange.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(131)))), ((int)(((byte)(153)))), ((int)(((byte)(177)))));
            this.vGridScoreRange.Appearance.VertLine.Options.UseBackColor = true;
            this.vGridScoreRange.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.vGridScoreRange.Location = new System.Drawing.Point(12, 167);
            this.vGridScoreRange.Name = "vGridScoreRange";
            this.vGridScoreRange.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBox1,
            this.repositoryItemTextEdit1,
            this.repositoryItemDateEdit1});
            this.vGridScoreRange.RowHeaderWidth = 114;
            this.vGridScoreRange.Size = new System.Drawing.Size(931, 182);
            this.vGridScoreRange.TabIndex = 31;
            // 
            // repositoryItemComboBox1
            // 
            this.repositoryItemComboBox1.AutoHeight = false;
            this.repositoryItemComboBox1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBox1.Items.AddRange(new object[] {
            "Apple",
            "Orange",
            "Mango"});
            this.repositoryItemComboBox1.Name = "repositoryItemComboBox1";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            // 
            // EstimatedInsuranceCoverageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 361);
            this.Controls.Add(this.vGridScoreRange);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.progressPanel1);
            this.Controls.Add(this.gridInsuranceCalculation);
            this.Controls.Add(this.txtEstimatedIsurnceCoverage);
            this.Controls.Add(this.labelControl1);
            this.Name = "EstimatedInsuranceCoverageView";
            this.Text = "EstimatedInsuranceCoverageView";
            this.Load += new System.EventHandler(this.EstimatedInsuranceCoverageView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtEstimatedIsurnceCoverage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInsuranceCalculation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInsuranceCalculation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridScoreRange)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
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
        private DevExpress.XtraVerticalGrid.VGridControl vGridScoreRange;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBox1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
    }
}