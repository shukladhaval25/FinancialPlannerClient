namespace FinancialPlannerClient.TaskManagementSystem
{
    partial class NewProject
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewProject));
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
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
            this.grpProject = new DevExpress.XtraEditors.GroupControl();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.gridControlProject = new DevExpress.XtraGrid.GridControl();
            this.gridViewProject = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grpProjectDetails = new DevExpress.XtraEditors.GroupControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtPreFix = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtProjectName = new DevExpress.XtraEditors.TextEdit();
            this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grpProject)).BeginInit();
            this.grpProject.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProject)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpProjectDetails)).BeginInit();
            this.grpProjectDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPreFix.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grpProject
            // 
            this.grpProject.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grpProject.Controls.Add(this.btnDelete);
            this.grpProject.Controls.Add(this.btnEdit);
            this.grpProject.Controls.Add(this.btnAdd);
            this.grpProject.Controls.Add(this.gridControlProject);
            this.grpProject.Location = new System.Drawing.Point(12, 12);
            this.grpProject.Name = "grpProject";
            this.grpProject.Size = new System.Drawing.Size(410, 270);
            this.grpProject.TabIndex = 5;
            this.grpProject.Text = "Projects";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(380, 241);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(25, 23);
            toolTipTitleItem1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            toolTipTitleItem1.Appearance.Options.UseImage = true;
            toolTipTitleItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem1.Image")));
            toolTipTitleItem1.Text = "Delete Client";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "To delete selected client record click here.";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.btnDelete.SuperTip = superToolTip1;
            this.btnDelete.TabIndex = 5;
            this.btnDelete.ToolTip = "Delete Client";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(349, 241);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(25, 23);
            toolTipTitleItem2.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            toolTipTitleItem2.Appearance.Options.UseImage = true;
            toolTipTitleItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem2.Image")));
            toolTipTitleItem2.Text = "Edit Customer";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "To modify selected client information click here.";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.btnEdit.SuperTip = superToolTip2;
            this.btnEdit.TabIndex = 4;
            this.btnEdit.ToolTip = "Edit Client";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(318, 241);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 23);
            toolTipTitleItem3.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            toolTipTitleItem3.Appearance.Options.UseImage = true;
            toolTipTitleItem3.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem3.Image")));
            toolTipTitleItem3.Text = "New Client";
            toolTipItem3.LeftIndent = 6;
            toolTipItem3.Text = "To add new client inforamtion click here.";
            superToolTip3.Items.Add(toolTipTitleItem3);
            superToolTip3.Items.Add(toolTipItem3);
            this.btnAdd.SuperTip = superToolTip3;
            this.btnAdd.TabIndex = 3;
            this.btnAdd.ToolTip = "Add new client";
            this.btnAdd.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Application;
            this.btnAdd.ToolTipTitle = "New Client";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // gridControlProject
            // 
            this.gridControlProject.Location = new System.Drawing.Point(2, 20);
            this.gridControlProject.MainView = this.gridViewProject;
            this.gridControlProject.Name = "gridControlProject";
            this.gridControlProject.Size = new System.Drawing.Size(408, 215);
            this.gridControlProject.TabIndex = 0;
            this.gridControlProject.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewProject});
            // 
            // gridViewProject
            // 
            this.gridViewProject.GridControl = this.gridControlProject;
            this.gridViewProject.Name = "gridViewProject";
            this.gridViewProject.OptionsBehavior.Editable = false;
            this.gridViewProject.OptionsBehavior.ReadOnly = true;
            this.gridViewProject.OptionsView.ShowGroupPanel = false;
            this.gridViewProject.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewProject_RowClick);
            // 
            // grpProjectDetails
            // 
            this.grpProjectDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpProjectDetails.Controls.Add(this.btnClose);
            this.grpProjectDetails.Controls.Add(this.btnSave);
            this.grpProjectDetails.Controls.Add(this.labelControl2);
            this.grpProjectDetails.Controls.Add(this.labelControl1);
            this.grpProjectDetails.Controls.Add(this.txtPreFix);
            this.grpProjectDetails.Controls.Add(this.labelControl3);
            this.grpProjectDetails.Controls.Add(this.txtProjectName);
            this.grpProjectDetails.Controls.Add(this.txtDescription);
            this.grpProjectDetails.Enabled = false;
            this.grpProjectDetails.Location = new System.Drawing.Point(428, 12);
            this.grpProjectDetails.Name = "grpProjectDetails";
            this.grpProjectDetails.Size = new System.Drawing.Size(393, 270);
            this.grpProjectDetails.TabIndex = 6;
            this.grpProjectDetails.Text = "Project Details";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(316, 240);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(62, 23);
            toolTipTitleItem4.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            toolTipTitleItem4.Appearance.Options.UseImage = true;
            toolTipTitleItem4.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem4.Image")));
            toolTipTitleItem4.Text = "Cancel";
            toolTipItem4.LeftIndent = 6;
            toolTipItem4.Text = "To close client information without saving any information click here.";
            superToolTip4.Items.Add(toolTipTitleItem4);
            superToolTip4.Items.Add(toolTipItem4);
            this.btnClose.SuperTip = superToolTip4;
            this.btnClose.TabIndex = 31;
            this.btnClose.Text = "&Close";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(253, 240);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(57, 23);
            toolTipTitleItem5.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image4")));
            toolTipTitleItem5.Appearance.Options.UseImage = true;
            toolTipTitleItem5.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem5.Image")));
            toolTipTitleItem5.Text = "Save";
            toolTipItem5.LeftIndent = 6;
            toolTipItem5.Text = "To save client infroamtion click here.";
            superToolTip5.Items.Add(toolTipTitleItem5);
            superToolTip5.Items.Add(toolTipItem5);
            this.btnSave.SuperTip = superToolTip5;
            this.btnSave.TabIndex = 30;
            this.btnSave.Text = "&Save";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(26, 131);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(52, 13);
            this.labelControl2.TabIndex = 12;
            this.labelControl2.Text = "Decription:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(26, 80);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(179, 13);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Project Number Prefix (Ex. MF /CSS):";
            // 
            // txtPreFix
            // 
            this.txtPreFix.Location = new System.Drawing.Point(26, 102);
            this.txtPreFix.Name = "txtPreFix";
            this.txtPreFix.Properties.MaxLength = 2;
            this.txtPreFix.Size = new System.Drawing.Size(109, 20);
            this.txtPreFix.TabIndex = 11;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(26, 29);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(68, 13);
            this.labelControl3.TabIndex = 8;
            this.labelControl3.Text = "Project Name:";
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(26, 51);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(352, 20);
            this.txtProjectName.TabIndex = 9;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(26, 153);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Properties.MaxLength = 2;
            this.txtDescription.Size = new System.Drawing.Size(352, 76);
            this.txtDescription.TabIndex = 13;
            // 
            // NewProject
            // 
            this.ClientSize = new System.Drawing.Size(833, 294);
            this.Controls.Add(this.grpProjectDetails);
            this.Controls.Add(this.grpProject);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewProject";
            this.Text = "Project Information";
            this.Load += new System.EventHandler(this.NewProject_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpProject)).EndInit();
            this.grpProject.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewProject)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpProjectDetails)).EndInit();
            this.grpProjectDetails.ResumeLayout(false);
            this.grpProjectDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPreFix.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProjectName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpProject;
        private DevExpress.XtraGrid.GridControl gridControlProject;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewProject;
        private DevExpress.XtraEditors.GroupControl grpProjectDetails;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtPreFix;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtProjectName;
        private DevExpress.XtraEditors.MemoEdit txtDescription;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
    }
}

