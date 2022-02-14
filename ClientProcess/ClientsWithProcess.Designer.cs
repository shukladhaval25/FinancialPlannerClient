namespace FinancialPlannerClient.ClientProcess
{
    partial class ClientsWithProcess
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
            this.gridClientWithProcess = new DevExpress.XtraGrid.GridControl();
            this.gridViewClientWithProcess = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.rdoViewOption = new DevExpress.XtraEditors.RadioGroup();
            this.pnlClientWiseProcess = new System.Windows.Forms.Panel();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.pnlProcessWiseClient = new System.Windows.Forms.Panel();
            this.gridClientProcess = new DevExpress.XtraGrid.GridControl();
            this.grdViewClientProcess = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.cardView1 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.pnlSubStepProcess = new System.Windows.Forms.Panel();
            this.lblSubProcessStepTitle = new System.Windows.Forms.Label();
            this.pnlProcessControl = new System.Windows.Forms.Panel();
            this.lblProcessTitle = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridClientWithProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewClientWithProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoViewOption.Properties)).BeginInit();
            this.pnlClientWiseProcess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.pnlProcessWiseClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridClientProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewClientProcess)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).BeginInit();
            this.pnlSubStepProcess.SuspendLayout();
            this.pnlProcessControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridClientWithProcess
            // 
            this.gridClientWithProcess.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridClientWithProcess.Location = new System.Drawing.Point(0, 0);
            this.gridClientWithProcess.MainView = this.gridViewClientWithProcess;
            this.gridClientWithProcess.Name = "gridClientWithProcess";
            this.gridClientWithProcess.Size = new System.Drawing.Size(1098, 513);
            this.gridClientWithProcess.TabIndex = 1;
            this.gridClientWithProcess.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewClientWithProcess});
            // 
            // gridViewClientWithProcess
            // 
            this.gridViewClientWithProcess.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridViewClientWithProcess.GridControl = this.gridClientWithProcess;
            this.gridViewClientWithProcess.Name = "gridViewClientWithProcess";
            this.gridViewClientWithProcess.OptionsBehavior.Editable = false;
            this.gridViewClientWithProcess.OptionsBehavior.ReadOnly = true;
            this.gridViewClientWithProcess.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grdViewClientProcess_RowStyle);
            this.gridViewClientWithProcess.DoubleClick += new System.EventHandler(this.gridViewClientWithProcess_DoubleClick);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(12, 567);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // rdoViewOption
            // 
            this.rdoViewOption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rdoViewOption.Location = new System.Drawing.Point(12, 12);
            this.rdoViewOption.Name = "rdoViewOption";
            this.rdoViewOption.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Customer Wise Process"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem(false, "Process Wise Customer")});
            this.rdoViewOption.Size = new System.Drawing.Size(1098, 30);
            this.rdoViewOption.TabIndex = 3;
            this.rdoViewOption.ToolTip = "Based on selection of client or spouse retirement calculation should be taken in " +
    "calculation. \r\nPost retirement plan and other calcualtin is also based on this s" +
    "elction.";
            this.rdoViewOption.ToolTipTitle = "Primary Retirement";
            this.rdoViewOption.SelectedIndexChanged += new System.EventHandler(this.rdoViewOption_SelectedIndexChanged);
            // 
            // pnlClientWiseProcess
            // 
            this.pnlClientWiseProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlClientWiseProcess.Controls.Add(this.gridClientWithProcess);
            this.pnlClientWiseProcess.Location = new System.Drawing.Point(12, 48);
            this.pnlClientWiseProcess.Name = "pnlClientWiseProcess";
            this.pnlClientWiseProcess.Size = new System.Drawing.Size(1098, 513);
            this.pnlClientWiseProcess.TabIndex = 4;
            // 
            // pnlProcessWiseClient
            // 
            this.pnlProcessWiseClient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlProcessWiseClient.Controls.Add(this.gridClientProcess);
            this.pnlProcessWiseClient.Controls.Add(this.pnlSubStepProcess);
            this.pnlProcessWiseClient.Controls.Add(this.pnlProcessControl);
            this.pnlProcessWiseClient.Location = new System.Drawing.Point(12, 48);
            this.pnlProcessWiseClient.Name = "pnlProcessWiseClient";
            this.pnlProcessWiseClient.Size = new System.Drawing.Size(1098, 514);
            this.pnlProcessWiseClient.TabIndex = 5;
            // 
            // gridClientProcess
            // 
            this.gridClientProcess.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridClientProcess.Location = new System.Drawing.Point(681, 5);
            this.gridClientProcess.MainView = this.grdViewClientProcess;
            this.gridClientProcess.Name = "gridClientProcess";
            this.gridClientProcess.Size = new System.Drawing.Size(414, 506);
            this.gridClientProcess.TabIndex = 10;
            this.gridClientProcess.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdViewClientProcess,
            this.cardView1});
            // 
            // grdViewClientProcess
            // 
            this.grdViewClientProcess.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.grdViewClientProcess.GridControl = this.gridClientProcess;
            this.grdViewClientProcess.Name = "grdViewClientProcess";
            this.grdViewClientProcess.OptionsBehavior.Editable = false;
            this.grdViewClientProcess.OptionsBehavior.ReadOnly = true;
            this.grdViewClientProcess.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.grdViewClientProcess_RowStyle);
            this.grdViewClientProcess.DoubleClick += new System.EventHandler(this.grdViewClientProcess_DoubleClick);
            // 
            // cardView1
            // 
            this.cardView1.FocusedCardTopFieldIndex = 0;
            this.cardView1.GridControl = this.gridClientProcess;
            this.cardView1.Name = "cardView1";
            this.cardView1.OptionsBehavior.ReadOnly = true;
            this.cardView1.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
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
            this.pnlSubStepProcess.Location = new System.Drawing.Point(341, 4);
            this.pnlSubStepProcess.Name = "pnlSubStepProcess";
            this.pnlSubStepProcess.Size = new System.Drawing.Size(334, 507);
            this.pnlSubStepProcess.TabIndex = 9;
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
            // pnlProcessControl
            // 
            this.pnlProcessControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlProcessControl.AutoScroll = true;
            this.pnlProcessControl.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.pnlProcessControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlProcessControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProcessControl.Controls.Add(this.lblProcessTitle);
            this.pnlProcessControl.Location = new System.Drawing.Point(3, 3);
            this.pnlProcessControl.Name = "pnlProcessControl";
            this.pnlProcessControl.Size = new System.Drawing.Size(332, 508);
            this.pnlProcessControl.TabIndex = 8;
            // 
            // lblProcessTitle
            // 
            this.lblProcessTitle.BackColor = System.Drawing.Color.Khaki;
            this.lblProcessTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProcessTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProcessTitle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcessTitle.Location = new System.Drawing.Point(0, 0);
            this.lblProcessTitle.Name = "lblProcessTitle";
            this.lblProcessTitle.Size = new System.Drawing.Size(330, 31);
            this.lblProcessTitle.TabIndex = 0;
            this.lblProcessTitle.Text = "Primary Process Steps";
            this.lblProcessTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ClientsWithProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 593);
            this.Controls.Add(this.pnlProcessWiseClient);
            this.Controls.Add(this.pnlClientWiseProcess);
            this.Controls.Add(this.rdoViewOption);
            this.Controls.Add(this.btnClose);
            this.Name = "ClientsWithProcess";
            this.Text = "ClientsWithProcess";
            this.Load += new System.EventHandler(this.ClientsWithProcess_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridClientWithProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewClientWithProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoViewOption.Properties)).EndInit();
            this.pnlClientWiseProcess.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.pnlProcessWiseClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridClientProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewClientProcess)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).EndInit();
            this.pnlSubStepProcess.ResumeLayout(false);
            this.pnlProcessControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridClientWithProcess;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewClientWithProcess;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.RadioGroup rdoViewOption;
        private System.Windows.Forms.Panel pnlClientWiseProcess;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Panel pnlProcessWiseClient;
        private System.Windows.Forms.Panel pnlSubStepProcess;
        private System.Windows.Forms.Label lblSubProcessStepTitle;
        private System.Windows.Forms.Panel pnlProcessControl;
        private System.Windows.Forms.Label lblProcessTitle;
        private DevExpress.XtraGrid.GridControl gridClientProcess;
        private DevExpress.XtraGrid.Views.Grid.GridView grdViewClientProcess;
        private DevExpress.XtraGrid.Views.Card.CardView cardView1;
    }
}