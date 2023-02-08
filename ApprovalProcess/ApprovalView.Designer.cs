namespace FinancialPlannerClient.ApprovalProcess
{
    partial class ApprovalView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ApprovalView));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            this.grdApprovals = new DevExpress.XtraGrid.GridControl();
            this.gridViewApprovals = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupApprovals = new DevExpress.XtraEditors.GroupControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnReassign = new DevExpress.XtraEditors.SimpleButton();
            this.btnReject = new DevExpress.XtraEditors.SimpleButton();
            this.btnApprove = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.cmbApprovalType = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grdApprovals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewApprovals)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupApprovals)).BeginInit();
            this.groupApprovals.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbApprovalType.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grdApprovals
            // 
            this.grdApprovals.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdApprovals.Location = new System.Drawing.Point(5, 92);
            this.grdApprovals.MainView = this.gridViewApprovals;
            this.grdApprovals.Name = "grdApprovals";
            this.grdApprovals.Size = new System.Drawing.Size(789, 301);
            this.grdApprovals.TabIndex = 10;
            this.grdApprovals.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewApprovals});
            // 
            // gridViewApprovals
            // 
            this.gridViewApprovals.GridControl = this.grdApprovals;
            this.gridViewApprovals.Name = "gridViewApprovals";
            this.gridViewApprovals.OptionsBehavior.Editable = false;
            this.gridViewApprovals.OptionsSelection.MultiSelect = true;
            this.gridViewApprovals.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            // 
            // groupApprovals
            // 
            this.groupApprovals.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupApprovals.Controls.Add(this.btnCancel);
            this.groupApprovals.Controls.Add(this.btnReassign);
            this.groupApprovals.Controls.Add(this.btnReject);
            this.groupApprovals.Controls.Add(this.btnApprove);
            this.groupApprovals.Controls.Add(this.labelControl3);
            this.groupApprovals.Controls.Add(this.grdApprovals);
            this.groupApprovals.Controls.Add(this.cmbApprovalType);
            this.groupApprovals.Location = new System.Drawing.Point(4, 12);
            this.groupApprovals.Name = "groupApprovals";
            this.groupApprovals.Size = new System.Drawing.Size(799, 435);
            this.groupApprovals.TabIndex = 15;
            this.groupApprovals.Text = "Approval Items";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(728, 403);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(62, 23);
            toolTipTitleItem1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            toolTipTitleItem1.Appearance.Options.UseImage = true;
            toolTipTitleItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem1.Image")));
            toolTipTitleItem1.Text = "Cancel";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "To close Scheme information without saving any information click here.";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.btnCancel.SuperTip = superToolTip1;
            this.btnCancel.TabIndex = 44;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnReassign
            // 
            this.btnReassign.Image = ((System.Drawing.Image)(resources.GetObject("btnReassign.Image")));
            this.btnReassign.Location = new System.Drawing.Point(165, 63);
            this.btnReassign.Name = "btnReassign";
            this.btnReassign.Size = new System.Drawing.Size(71, 23);
            toolTipTitleItem2.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            toolTipTitleItem2.Appearance.Options.UseImage = true;
            toolTipTitleItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem2.Image")));
            toolTipTitleItem2.Text = "Reassign";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "Reassign approval options to other user for selected item.";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.btnReassign.SuperTip = superToolTip2;
            this.btnReassign.TabIndex = 13;
            this.btnReassign.Text = "Reassign";
            this.btnReassign.ToolTip = "Reassign selected items to other user";
            this.btnReassign.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Application;
            this.btnReassign.ToolTipTitle = "New Client";
            this.btnReassign.Click += new System.EventHandler(this.btnReassign_Click);
            // 
            // btnReject
            // 
            this.btnReject.Image = ((System.Drawing.Image)(resources.GetObject("btnReject.Image")));
            this.btnReject.Location = new System.Drawing.Point(88, 63);
            this.btnReject.Name = "btnReject";
            this.btnReject.Size = new System.Drawing.Size(71, 23);
            toolTipTitleItem3.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            toolTipTitleItem3.Appearance.Options.UseImage = true;
            toolTipTitleItem3.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem3.Image")));
            toolTipTitleItem3.Text = "New Client";
            toolTipItem3.LeftIndent = 6;
            toolTipItem3.Text = "To add new Scheme inforamtion click here.";
            superToolTip3.Items.Add(toolTipTitleItem3);
            superToolTip3.Items.Add(toolTipItem3);
            this.btnReject.SuperTip = superToolTip3;
            this.btnReject.TabIndex = 12;
            this.btnReject.Text = "&Reject";
            this.btnReject.ToolTip = "Add new client";
            this.btnReject.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Application;
            this.btnReject.ToolTipTitle = "New Client";
            this.btnReject.Click += new System.EventHandler(this.btnReject_Click);
            // 
            // btnApprove
            // 
            this.btnApprove.Image = ((System.Drawing.Image)(resources.GetObject("btnApprove.Image")));
            this.btnApprove.Location = new System.Drawing.Point(11, 63);
            this.btnApprove.Name = "btnApprove";
            this.btnApprove.Size = new System.Drawing.Size(71, 23);
            toolTipTitleItem4.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            toolTipTitleItem4.Appearance.Options.UseImage = true;
            toolTipTitleItem4.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem4.Image")));
            toolTipTitleItem4.Text = "New Client";
            toolTipItem4.LeftIndent = 6;
            toolTipItem4.Text = "To add new Scheme inforamtion click here.";
            superToolTip4.Items.Add(toolTipTitleItem4);
            superToolTip4.Items.Add(toolTipItem4);
            this.btnApprove.SuperTip = superToolTip4;
            this.btnApprove.TabIndex = 11;
            this.btnApprove.Text = "&Approve";
            this.btnApprove.ToolTip = "Approve selected item.";
            this.btnApprove.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Application;
            this.btnApprove.ToolTipTitle = "New Client";
            this.btnApprove.Click += new System.EventHandler(this.btnApprove_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(11, 33);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(74, 13);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Approval Type:";
            // 
            // cmbApprovalType
            // 
            this.cmbApprovalType.Location = new System.Drawing.Point(91, 30);
            this.cmbApprovalType.Name = "cmbApprovalType";
            this.cmbApprovalType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbApprovalType.Properties.Items.AddRange(new object[] {
            "All",
            "Task Bypass",
            "Process Lock"});
            this.cmbApprovalType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbApprovalType.Size = new System.Drawing.Size(211, 20);
            this.cmbApprovalType.TabIndex = 3;
            this.cmbApprovalType.SelectedIndexChanged += new System.EventHandler(this.cmbApprovalType_SelectedIndexChanged);
            // 
            // ApprovalView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(806, 450);
            this.Controls.Add(this.groupApprovals);
            this.Name = "ApprovalView";
            this.Text = "Approvals";
            this.Load += new System.EventHandler(this.ApprovalView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdApprovals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewApprovals)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupApprovals)).EndInit();
            this.groupApprovals.ResumeLayout(false);
            this.groupApprovals.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbApprovalType.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdApprovals;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewApprovals;
        private DevExpress.XtraEditors.GroupControl groupApprovals;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.ComboBoxEdit cmbApprovalType;
        public DevExpress.XtraEditors.SimpleButton btnReassign;
        public DevExpress.XtraEditors.SimpleButton btnReject;
        public DevExpress.XtraEditors.SimpleButton btnApprove;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
    }
}