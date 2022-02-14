namespace FinancialPlannerClient.ClientProcess
{
    partial class SingleClientProcess
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
            this.lblSubProcessStepTitle = new System.Windows.Forms.Label();
            this.pnlSubStepProcess = new System.Windows.Forms.Panel();
            this.lblProcessTitle = new System.Windows.Forms.Label();
            this.pnlProcessControl = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.cardView1 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.pnlSubStepProcess.SuspendLayout();
            this.pnlProcessControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblSubProcessStepTitle
            // 
            this.lblSubProcessStepTitle.BackColor = System.Drawing.Color.Khaki;
            this.lblSubProcessStepTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSubProcessStepTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSubProcessStepTitle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubProcessStepTitle.Location = new System.Drawing.Point(0, 0);
            this.lblSubProcessStepTitle.Name = "lblSubProcessStepTitle";
            this.lblSubProcessStepTitle.Size = new System.Drawing.Size(332, 31);
            this.lblSubProcessStepTitle.TabIndex = 0;
            this.lblSubProcessStepTitle.Text = "Sub Process Step";
            this.lblSubProcessStepTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSubStepProcess
            // 
            this.pnlSubStepProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlSubStepProcess.AutoScroll = true;
            this.pnlSubStepProcess.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.pnlSubStepProcess.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlSubStepProcess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSubStepProcess.Controls.Add(this.lblSubProcessStepTitle);
            this.pnlSubStepProcess.Location = new System.Drawing.Point(350, 12);
            this.pnlSubStepProcess.Name = "pnlSubStepProcess";
            this.pnlSubStepProcess.Size = new System.Drawing.Size(334, 458);
            this.pnlSubStepProcess.TabIndex = 11;
            // 
            // lblProcessTitle
            // 
            this.lblProcessTitle.BackColor = System.Drawing.Color.Khaki;
            this.lblProcessTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProcessTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProcessTitle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcessTitle.Location = new System.Drawing.Point(0, 0);
            this.lblProcessTitle.Name = "lblProcessTitle";
            this.lblProcessTitle.Size = new System.Drawing.Size(337, 31);
            this.lblProcessTitle.TabIndex = 0;
            this.lblProcessTitle.Text = "Primary Process Steps";
            this.lblProcessTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlProcessControl
            // 
            this.pnlProcessControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlProcessControl.AutoScroll = true;
            this.pnlProcessControl.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.pnlProcessControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlProcessControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProcessControl.Controls.Add(this.lblProcessTitle);
            this.pnlProcessControl.Location = new System.Drawing.Point(5, 12);
            this.pnlProcessControl.Name = "pnlProcessControl";
            this.pnlProcessControl.Size = new System.Drawing.Size(339, 458);
            this.pnlProcessControl.TabIndex = 10;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControl1.Location = new System.Drawing.Point(689, 12);
            this.gridControl1.MainView = this.cardView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(417, 458);
            this.gridControl1.TabIndex = 12;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.cardView1});
            // 
            // cardView1
            // 
            this.cardView1.CardWidth = 395;
            this.cardView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9});
            this.cardView1.FocusedCardTopFieldIndex = 0;
            this.cardView1.GridControl = this.gridControl1;
            this.cardView1.Name = "cardView1";
            this.cardView1.OptionsBehavior.AutoHorzWidth = true;
            this.cardView1.OptionsBehavior.ReadOnly = true;
            this.cardView1.OptionsView.ShowQuickCustomizeButton = false;
            this.cardView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Client Id";
            this.gridColumn1.FieldName = "ClientId";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Client Name";
            this.gridColumn2.FieldName = "ClientName";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Status";
            this.gridColumn3.FieldName = "ProcessStatus";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Primary Step No";
            this.gridColumn4.FieldName = "PrimaryStepNo";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Linksub Step No";
            this.gridColumn5.FieldName = "LinkSubStepNo";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Task Id";
            this.gridColumn6.FieldName = "RefTaskId";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Assign To";
            this.gridColumn7.FieldName = "UserName";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Expected Completion Date";
            this.gridColumn8.FieldName = "ExpectedCompletionDate";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Actual Completion Date";
            this.gridColumn9.FieldName = "ActualCompletionDate";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 8;
            // 
            // SingleClientProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 485);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.pnlSubStepProcess);
            this.Controls.Add(this.pnlProcessControl);
            this.Name = "SingleClientProcess";
            this.Text = "Client Process";
            this.Load += new System.EventHandler(this.SingleClientProcess_Load);
            this.pnlSubStepProcess.ResumeLayout(false);
            this.pnlProcessControl.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label lblSubProcessStepTitle;
        private System.Windows.Forms.Panel pnlSubStepProcess;
        private System.Windows.Forms.Label lblProcessTitle;
        private System.Windows.Forms.Panel pnlProcessControl;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Card.CardView cardView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
    }
}