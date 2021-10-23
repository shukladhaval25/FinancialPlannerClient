namespace FinancialPlannerClient.Master
{
    partial class Other
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Other));
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem6 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem6 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip7 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem7 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem7 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip8 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem8 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem8 = new DevExpress.Utils.ToolTipItem();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.grpItem = new DevExpress.XtraEditors.GroupControl();
            this.txtReligion = new DevExpress.XtraEditors.TextEdit();
            this.lblReligion = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlOthers = new DevExpress.XtraGrid.GridControl();
            this.gridViewOthers = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.grpItem)).BeginInit();
            this.grpItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReligion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOthers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOthers)).BeginInit();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(114, 281);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(25, 23);
            toolTipTitleItem5.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            toolTipTitleItem5.Appearance.Options.UseImage = true;
            toolTipTitleItem5.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem5.Image")));
            toolTipTitleItem5.Text = "Delete Client";
            toolTipItem5.LeftIndent = 6;
            toolTipItem5.Text = "To delete selected client rating record click here.";
            superToolTip5.Items.Add(toolTipTitleItem5);
            superToolTip5.Items.Add(toolTipItem5);
            this.btnDelete.SuperTip = superToolTip5;
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
            toolTipTitleItem6.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            toolTipTitleItem6.Appearance.Options.UseImage = true;
            toolTipTitleItem6.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem6.Image")));
            toolTipTitleItem6.Text = "New Client";
            toolTipItem6.LeftIndent = 6;
            toolTipItem6.Text = "To add new client rating click here.";
            superToolTip6.Items.Add(toolTipTitleItem6);
            superToolTip6.Items.Add(toolTipItem6);
            this.btnAdd.SuperTip = superToolTip6;
            this.btnAdd.TabIndex = 4;
            this.btnAdd.ToolTip = "Add new client";
            this.btnAdd.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Application;
            this.btnAdd.ToolTipTitle = "New Client";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // grpItem
            // 
            this.grpItem.Controls.Add(this.txtReligion);
            this.grpItem.Controls.Add(this.lblReligion);
            this.grpItem.Controls.Add(this.txtName);
            this.grpItem.Controls.Add(this.labelControl1);
            this.grpItem.Controls.Add(this.btnClose);
            this.grpItem.Controls.Add(this.btnSave);
            this.grpItem.Location = new System.Drawing.Point(224, 28);
            this.grpItem.Name = "grpItem";
            this.grpItem.Size = new System.Drawing.Size(370, 247);
            this.grpItem.TabIndex = 7;
            // 
            // txtReligion
            // 
            this.txtReligion.Location = new System.Drawing.Point(126, 70);
            this.txtReligion.Name = "txtReligion";
            this.txtReligion.Size = new System.Drawing.Size(214, 20);
            this.txtReligion.TabIndex = 2;
            // 
            // lblReligion
            // 
            this.lblReligion.Location = new System.Drawing.Point(44, 73);
            this.lblReligion.Name = "lblReligion";
            this.lblReligion.Size = new System.Drawing.Size(41, 13);
            this.lblReligion.TabIndex = 27;
            this.lblReligion.Text = "Religion:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(126, 44);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(214, 20);
            this.txtName.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(44, 47);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(31, 13);
            this.labelControl1.TabIndex = 25;
            this.labelControl1.Text = "Name:";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(278, 106);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(62, 23);
            toolTipTitleItem7.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            toolTipTitleItem7.Appearance.Options.UseImage = true;
            toolTipTitleItem7.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem7.Image")));
            toolTipTitleItem7.Text = "Cancel";
            toolTipItem7.LeftIndent = 6;
            toolTipItem7.Text = "To close client rating without saving any information click here.";
            superToolTip7.Items.Add(toolTipTitleItem7);
            superToolTip7.Items.Add(toolTipItem7);
            this.btnClose.SuperTip = superToolTip7;
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnCloseClientInfo_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(215, 106);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(57, 23);
            toolTipTitleItem8.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            toolTipTitleItem8.Appearance.Options.UseImage = true;
            toolTipTitleItem8.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem8.Image")));
            toolTipTitleItem8.Text = "Save";
            toolTipItem8.LeftIndent = 6;
            toolTipItem8.Text = "To save record click here.";
            superToolTip8.Items.Add(toolTipTitleItem8);
            superToolTip8.Items.Add(toolTipItem8);
            this.btnSave.SuperTip = superToolTip8;
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.btnSave.Click += new System.EventHandler(this.btnSaveClient_Click);
            // 
            // gridControlOthers
            // 
            this.gridControlOthers.Location = new System.Drawing.Point(12, 28);
            this.gridControlOthers.MainView = this.gridViewOthers;
            this.gridControlOthers.Name = "gridControlOthers";
            this.gridControlOthers.Size = new System.Drawing.Size(206, 247);
            this.gridControlOthers.TabIndex = 8;
            this.gridControlOthers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewOthers});
            // 
            // gridViewOthers
            // 
            this.gridViewOthers.GridControl = this.gridControlOthers;
            this.gridViewOthers.Name = "gridViewOthers";
            this.gridViewOthers.OptionsBehavior.Editable = false;
            this.gridViewOthers.OptionsBehavior.ReadOnly = true;
            this.gridViewOthers.OptionsView.ShowGroupPanel = false;
            this.gridViewOthers.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridViewOthers_SelectionChanged);
            this.gridViewOthers.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewOthers_FocusedRowChanged);
            // 
            // Other
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 312);
            this.Controls.Add(this.gridControlOthers);
            this.Controls.Add(this.grpItem);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Other";
            this.Text = "Others";
            this.Load += new System.EventHandler(this.Other_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpItem)).EndInit();
            this.grpItem.ResumeLayout(false);
            this.grpItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReligion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOthers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOthers)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.GroupControl grpItem;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.GridControl gridControlOthers;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewOthers;
        private DevExpress.XtraEditors.TextEdit txtReligion;
        private DevExpress.XtraEditors.LabelControl lblReligion;
    }
}

