namespace FinancialPlannerClient.PlanOptions.Reports.Insurance
{
    partial class InsurancePremiumParameters
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
            this.groupPeriod = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.dateTimeFrom = new System.Windows.Forms.DateTimePicker();
            this.dateTimeTo = new System.Windows.Forms.DateTimePicker();
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupPeriod)).BeginInit();
            this.groupPeriod.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupPeriod
            // 
            this.groupPeriod.Controls.Add(this.btnCancel);
            this.groupPeriod.Controls.Add(this.btnView);
            this.groupPeriod.Controls.Add(this.dateTimeTo);
            this.groupPeriod.Controls.Add(this.dateTimeFrom);
            this.groupPeriod.Controls.Add(this.labelControl3);
            this.groupPeriod.Controls.Add(this.labelControl2);
            this.groupPeriod.Controls.Add(this.labelControl1);
            this.groupPeriod.Location = new System.Drawing.Point(12, 12);
            this.groupPeriod.Name = "groupPeriod";
            this.groupPeriod.Size = new System.Drawing.Size(370, 120);
            this.groupPeriod.TabIndex = 0;
            this.groupPeriod.Text = "Select Period";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(14, 33);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(329, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Select period for which you view insurance premium due information.";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 63);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(28, 13);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "From:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(210, 63);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(16, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "To:";
            // 
            // dateTimeFrom
            // 
            this.dateTimeFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeFrom.Location = new System.Drawing.Point(58, 60);
            this.dateTimeFrom.Name = "dateTimeFrom";
            this.dateTimeFrom.Size = new System.Drawing.Size(106, 21);
            this.dateTimeFrom.TabIndex = 3;
            // 
            // dateTimeTo
            // 
            this.dateTimeTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeTo.Location = new System.Drawing.Point(232, 60);
            this.dateTimeTo.Name = "dateTimeTo";
            this.dateTimeTo.Size = new System.Drawing.Size(106, 21);
            this.dateTimeTo.TabIndex = 4;
            // 
            // btnView
            // 
            this.btnView.Location = new System.Drawing.Point(112, 92);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(75, 23);
            this.btnView.TabIndex = 5;
            this.btnView.Text = "&View";
            this.btnView.Click += new System.EventHandler(this.btnView_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(193, 92);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // InsurancePremiumParameters
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(390, 144);
            this.Controls.Add(this.groupPeriod);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "InsurancePremiumParameters";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Insurance Premium Parameters";
            ((System.ComponentModel.ISupportInitialize)(this.groupPeriod)).EndInit();
            this.groupPeriod.ResumeLayout(false);
            this.groupPeriod.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupPeriod;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private System.Windows.Forms.DateTimePicker dateTimeTo;
        private System.Windows.Forms.DateTimePicker dateTimeFrom;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}