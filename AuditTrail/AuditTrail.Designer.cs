namespace FinancialPlannerClient.AuditTrail
{
    partial class AuditTrail
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dtGridAuditTrail = new System.Windows.Forms.DataGridView();
            this.TypeImg = new System.Windows.Forms.DataGridViewImageColumn();
            this.StatusImg = new System.Windows.Forms.DataGridViewImageColumn();
            this.lblAuditTrail = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridAuditTrail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dtGridAuditTrail
            // 
            this.dtGridAuditTrail.AllowUserToAddRows = false;
            this.dtGridAuditTrail.AllowUserToDeleteRows = false;
            this.dtGridAuditTrail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGridAuditTrail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dtGridAuditTrail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridAuditTrail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TypeImg,
            this.StatusImg});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dtGridAuditTrail.DefaultCellStyle = dataGridViewCellStyle5;
            this.dtGridAuditTrail.Location = new System.Drawing.Point(12, 52);
            this.dtGridAuditTrail.MultiSelect = false;
            this.dtGridAuditTrail.Name = "dtGridAuditTrail";
            this.dtGridAuditTrail.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtGridAuditTrail.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dtGridAuditTrail.RowHeadersVisible = false;
            this.dtGridAuditTrail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGridAuditTrail.Size = new System.Drawing.Size(1069, 338);
            this.dtGridAuditTrail.TabIndex = 3;
            this.dtGridAuditTrail.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtGridAuditTrail_CellFormatting);
            // 
            // TypeImg
            // 
            this.TypeImg.HeaderText = "";
            this.TypeImg.Name = "TypeImg";
            this.TypeImg.ReadOnly = true;
            this.TypeImg.Width = 30;
            // 
            // StatusImg
            // 
            this.StatusImg.HeaderText = "";
            this.StatusImg.Name = "StatusImg";
            this.StatusImg.ReadOnly = true;
            this.StatusImg.Width = 30;
            // 
            // lblAuditTrail
            // 
            this.lblAuditTrail.AutoSize = true;
            this.lblAuditTrail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuditTrail.Location = new System.Drawing.Point(50, 20);
            this.lblAuditTrail.Name = "lblAuditTrail";
            this.lblAuditTrail.Size = new System.Drawing.Size(110, 17);
            this.lblAuditTrail.TabIndex = 2;
            this.lblAuditTrail.Text = "Activities Details";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::FinancialPlannerClient.Properties.Resources.AuditTrail_301;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 34);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // AuditTrail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 402);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.dtGridAuditTrail);
            this.Controls.Add(this.lblAuditTrail);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AuditTrail";
            this.ShowInTaskbar = false;
            this.Text = "Audit Trail";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AuditTrail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridAuditTrail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dtGridAuditTrail;
        private System.Windows.Forms.Label lblAuditTrail;
        private System.Windows.Forms.DataGridViewImageColumn TypeImg;
        private System.Windows.Forms.DataGridViewImageColumn StatusImg;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}