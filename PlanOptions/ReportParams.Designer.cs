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
            this.txtRecomendation = new System.Windows.Forms.TextBox();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.btnOk = new DevExpress.XtraEditors.SimpleButton();
            this.cmbPlanOption = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grpParams)).BeginInit();
            this.grpParams.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPlanOption.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grpParams
            // 
            this.grpParams.Controls.Add(this.txtRecomendation);
            this.grpParams.Controls.Add(this.labelControl2);
            this.grpParams.Controls.Add(this.btnOk);
            this.grpParams.Controls.Add(this.cmbPlanOption);
            this.grpParams.Controls.Add(this.labelControl1);
            this.grpParams.Location = new System.Drawing.Point(12, 12);
            this.grpParams.Name = "grpParams";
            this.grpParams.Size = new System.Drawing.Size(390, 243);
            this.grpParams.TabIndex = 0;
            // 
            // txtRecomendation
            // 
            this.txtRecomendation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRecomendation.Location = new System.Drawing.Point(16, 92);
            this.txtRecomendation.MaxLength = 500;
            this.txtRecomendation.Multiline = true;
            this.txtRecomendation.Name = "txtRecomendation";
            this.txtRecomendation.Size = new System.Drawing.Size(353, 108);
            this.txtRecomendation.TabIndex = 30;
            this.txtRecomendation.TextChanged += new System.EventHandler(this.txtRecomendation_TextChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(16, 73);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(74, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Recomendation";
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(153, 209);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "Ok";
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // cmbPlanOption
            // 
            this.cmbPlanOption.Location = new System.Drawing.Point(90, 42);
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
            this.labelControl1.Location = new System.Drawing.Point(16, 45);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(59, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Plan Option:";
            // 
            // ReportParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(414, 267);
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
            this.grpParams.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPlanOption.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpParams;
        private DevExpress.XtraEditors.SimpleButton btnOk;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPlanOption;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        internal System.Windows.Forms.TextBox txtRecomendation;
    }
}

