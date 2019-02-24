namespace FinancialPlannerClient.AuditTrail
{
    partial class AuditTrailView
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
            this.lblAuditTrail = new System.Windows.Forms.Label();
            this.gridSplitContainer1 = new DevExpress.XtraGrid.GridSplitContainer();
            this.grdsplitAuditTrail = new DevExpress.XtraGrid.GridControl();
            this.grdSplitAuditTrailView = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainer1)).BeginInit();
            this.gridSplitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdsplitAuditTrail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSplitAuditTrailView)).BeginInit();
            this.SuspendLayout();
            // 
            // lblAuditTrail
            // 
            this.lblAuditTrail.AutoSize = true;
            this.lblAuditTrail.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAuditTrail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblAuditTrail.Location = new System.Drawing.Point(12, 9);
            this.lblAuditTrail.Name = "lblAuditTrail";
            this.lblAuditTrail.Size = new System.Drawing.Size(110, 17);
            this.lblAuditTrail.TabIndex = 3;
            this.lblAuditTrail.Text = "Activities Details";
            // 
            // gridSplitContainer1
            // 
            this.gridSplitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridSplitContainer1.Grid = this.grdsplitAuditTrail;
            this.gridSplitContainer1.Location = new System.Drawing.Point(12, 40);
            this.gridSplitContainer1.Name = "gridSplitContainer1";
            this.gridSplitContainer1.Panel1.Controls.Add(this.grdsplitAuditTrail);
            this.gridSplitContainer1.Panel1.Text = "Panel1";
            this.gridSplitContainer1.Panel2.Text = "Panel2";
            this.gridSplitContainer1.Size = new System.Drawing.Size(914, 362);
            this.gridSplitContainer1.TabIndex = 4;
            this.gridSplitContainer1.Text = "gridSplitContainer1";
            // 
            // grdsplitAuditTrail
            // 
            this.grdsplitAuditTrail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdsplitAuditTrail.Location = new System.Drawing.Point(0, 0);
            this.grdsplitAuditTrail.MainView = this.grdSplitAuditTrailView;
            this.grdsplitAuditTrail.Name = "grdsplitAuditTrail";
            this.grdsplitAuditTrail.Size = new System.Drawing.Size(914, 362);
            this.grdsplitAuditTrail.TabIndex = 0;
            this.grdsplitAuditTrail.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdSplitAuditTrailView});
            // 
            // grdSplitAuditTrailView
            // 
            this.grdSplitAuditTrailView.GridControl = this.grdsplitAuditTrail;
            this.grdSplitAuditTrailView.Name = "grdSplitAuditTrailView";
            // 
            // AuditTrailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(938, 414);
            this.Controls.Add(this.gridSplitContainer1);
            this.Controls.Add(this.lblAuditTrail);
            this.Name = "AuditTrailView";
            this.Text = "Activities Details";
            this.Load += new System.EventHandler(this.AuditTrailView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainer1)).EndInit();
            this.gridSplitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdsplitAuditTrail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSplitAuditTrailView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblAuditTrail;
        private DevExpress.XtraGrid.GridSplitContainer gridSplitContainer1;
        private DevExpress.XtraGrid.GridControl grdsplitAuditTrail;
        private DevExpress.XtraGrid.Views.Grid.GridView grdSplitAuditTrailView;
    }
}

