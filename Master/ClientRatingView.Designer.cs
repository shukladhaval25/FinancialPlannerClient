namespace FinancialPlannerClient.Master
{
    partial class ClientRatingView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientRatingView));
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
            this.lstRating = new DevExpress.XtraEditors.ListBoxControl();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.grpRatingDetail = new DevExpress.XtraEditors.GroupControl();
            this.txtRating = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnCloseClientInfo = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.lstRating)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpRatingDetail)).BeginInit();
            this.grpRatingDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRating.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // lstRating
            // 
            this.lstRating.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstRating.Location = new System.Drawing.Point(12, 28);
            this.lstRating.Name = "lstRating";
            this.lstRating.Size = new System.Drawing.Size(206, 247);
            this.lstRating.TabIndex = 0;
            this.lstRating.SelectedIndexChanged += new System.EventHandler(this.lstRating_SelectedIndexChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(114, 281);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(25, 23);
            toolTipTitleItem1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            toolTipTitleItem1.Appearance.Options.UseImage = true;
            toolTipTitleItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem1.Image")));
            toolTipTitleItem1.Text = "Delete Client";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "To delete selected client rating record click here.";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.btnDelete.SuperTip = superToolTip1;
            this.btnDelete.TabIndex = 6;
            this.btnDelete.ToolTip = "Delete Client";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(83, 281);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 23);
            toolTipTitleItem2.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            toolTipTitleItem2.Appearance.Options.UseImage = true;
            toolTipTitleItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem2.Image")));
            toolTipTitleItem2.Text = "New Client";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "To add new client rating click here.";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.btnAdd.SuperTip = superToolTip2;
            this.btnAdd.TabIndex = 4;
            this.btnAdd.ToolTip = "Add new client";
            this.btnAdd.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Application;
            this.btnAdd.ToolTipTitle = "New Client";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grpRatingDetail
            // 
            this.grpRatingDetail.Controls.Add(this.txtRating);
            this.grpRatingDetail.Controls.Add(this.labelControl1);
            this.grpRatingDetail.Controls.Add(this.btnCloseClientInfo);
            this.grpRatingDetail.Controls.Add(this.btnSave);
            this.grpRatingDetail.Location = new System.Drawing.Point(224, 28);
            this.grpRatingDetail.Name = "grpRatingDetail";
            this.grpRatingDetail.Size = new System.Drawing.Size(370, 247);
            this.grpRatingDetail.TabIndex = 7;
            this.grpRatingDetail.Text = "Client Rating Details";
            // 
            // txtRating
            // 
            this.txtRating.Location = new System.Drawing.Point(126, 80);
            this.txtRating.Name = "txtRating";
            this.txtRating.Size = new System.Drawing.Size(214, 20);
            this.txtRating.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(44, 83);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(65, 13);
            this.labelControl1.TabIndex = 25;
            this.labelControl1.Text = "Client Rating:";
            // 
            // btnCloseClientInfo
            // 
            this.btnCloseClientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseClientInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseClientInfo.Image")));
            this.btnCloseClientInfo.Location = new System.Drawing.Point(278, 106);
            this.btnCloseClientInfo.Name = "btnCloseClientInfo";
            this.btnCloseClientInfo.Size = new System.Drawing.Size(62, 23);
            toolTipTitleItem3.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            toolTipTitleItem3.Appearance.Options.UseImage = true;
            toolTipTitleItem3.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem3.Image")));
            toolTipTitleItem3.Text = "Cancel";
            toolTipItem3.LeftIndent = 6;
            toolTipItem3.Text = "To close client rating without saving any information click here.";
            superToolTip3.Items.Add(toolTipTitleItem3);
            superToolTip3.Items.Add(toolTipItem3);
            this.btnCloseClientInfo.SuperTip = superToolTip3;
            this.btnCloseClientInfo.TabIndex = 3;
            this.btnCloseClientInfo.Text = "Close";
            this.btnCloseClientInfo.Click += new System.EventHandler(this.btnCloseClientInfo_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(215, 106);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(57, 23);
            toolTipTitleItem4.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            toolTipTitleItem4.Appearance.Options.UseImage = true;
            toolTipTitleItem4.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem4.Image")));
            toolTipTitleItem4.Text = "Save";
            toolTipItem4.LeftIndent = 6;
            toolTipItem4.Text = "To save client rating click here.";
            superToolTip4.Items.Add(toolTipTitleItem4);
            superToolTip4.Items.Add(toolTipItem4);
            this.btnSave.SuperTip = superToolTip4;
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSaveClient_Click);
            // 
            // ClientRatingView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 312);
            this.Controls.Add(this.grpRatingDetail);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.lstRating);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientRatingView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Rating";
            this.Load += new System.EventHandler(this.ClientRatingView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lstRating)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpRatingDetail)).EndInit();
            this.grpRatingDetail.ResumeLayout(false);
            this.grpRatingDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRating.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.ListBoxControl lstRating;
        public DevExpress.XtraEditors.SimpleButton btnDelete;
        public DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.GroupControl grpRatingDetail;
        private DevExpress.XtraEditors.TextEdit txtRating;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCloseClientInfo;
        public DevExpress.XtraEditors.SimpleButton btnSave;
    }
}

