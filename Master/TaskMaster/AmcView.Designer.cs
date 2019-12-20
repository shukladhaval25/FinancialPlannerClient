namespace FinancialPlannerClient.Master.TaskMaster
{
    partial class AmcView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AmcView));
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
            this.gridControlAMC = new DevExpress.XtraGrid.GridControl();
            this.gridViewAMC = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.grpAmc = new DevExpress.XtraEditors.GroupControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.lblLine = new DevExpress.XtraEditors.LabelControl();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAMC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAMC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpAmc)).BeginInit();
            this.grpAmc.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlAMC
            // 
            this.gridControlAMC.Location = new System.Drawing.Point(12, 12);
            this.gridControlAMC.MainView = this.gridViewAMC;
            this.gridControlAMC.Name = "gridControlAMC";
            this.gridControlAMC.Size = new System.Drawing.Size(444, 181);
            this.gridControlAMC.TabIndex = 9;
            this.gridControlAMC.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewAMC});
            // 
            // gridViewAMC
            // 
            this.gridViewAMC.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colID});
            this.gridViewAMC.GridControl = this.gridControlAMC;
            this.gridViewAMC.Name = "gridViewAMC";
            this.gridViewAMC.OptionsBehavior.Editable = false;
            this.gridViewAMC.OptionsView.ShowGroupPanel = false;
            this.gridViewAMC.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewAMC_FocusedRowChanged);
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 0;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "Id";
            this.colID.Name = "colID";
            // 
            // grpAmc
            // 
            this.grpAmc.Controls.Add(this.btnCancel);
            this.grpAmc.Controls.Add(this.btnSave);
            this.grpAmc.Controls.Add(this.txtName);
            this.grpAmc.Controls.Add(this.labelControl3);
            this.grpAmc.Enabled = false;
            this.grpAmc.Location = new System.Drawing.Point(13, 236);
            this.grpAmc.Name = "grpAmc";
            this.grpAmc.Size = new System.Drawing.Size(443, 98);
            this.grpAmc.TabIndex = 14;
            this.grpAmc.Text = "AMC";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(350, 48);
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
            this.btnCancel.TabIndex = 43;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(287, 48);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(57, 23);
            toolTipTitleItem2.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            toolTipTitleItem2.Appearance.Options.UseImage = true;
            toolTipTitleItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem2.Image")));
            toolTipTitleItem2.Text = "Save";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "To save Scheme infroamtion click here.";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.btnSave.SuperTip = superToolTip2;
            this.btnSave.TabIndex = 42;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(68, 50);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(211, 20);
            this.txtName.TabIndex = 3;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(31, 53);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(31, 13);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Name:";
            // 
            // lblLine
            // 
            this.lblLine.Appearance.BackColor = System.Drawing.Color.Silver;
            this.lblLine.Appearance.Options.UseBackColor = true;
            this.lblLine.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblLine.Location = new System.Drawing.Point(13, 227);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(443, 2);
            this.lblLine.TabIndex = 13;
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(431, 199);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(25, 23);
            toolTipTitleItem3.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            toolTipTitleItem3.Appearance.Options.UseImage = true;
            toolTipTitleItem3.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem3.Image")));
            toolTipTitleItem3.Text = "Delete Client";
            toolTipItem3.LeftIndent = 6;
            toolTipItem3.Text = "To delete selected Scheme record click here.";
            superToolTip3.Items.Add(toolTipTitleItem3);
            superToolTip3.Items.Add(toolTipItem3);
            this.btnDelete.SuperTip = superToolTip3;
            this.btnDelete.TabIndex = 12;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.ToolTip = "Delete Client";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(400, 199);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(25, 23);
            toolTipTitleItem4.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            toolTipTitleItem4.Appearance.Options.UseImage = true;
            toolTipTitleItem4.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem4.Image")));
            toolTipTitleItem4.Text = "Edit Customer";
            toolTipItem4.LeftIndent = 6;
            toolTipItem4.Text = "To modify selected Scheme information click here.";
            superToolTip4.Items.Add(toolTipTitleItem4);
            superToolTip4.Items.Add(toolTipItem4);
            this.btnEdit.SuperTip = superToolTip4;
            this.btnEdit.TabIndex = 11;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.ToolTip = "Edit Client";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(369, 199);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 23);
            toolTipTitleItem5.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image4")));
            toolTipTitleItem5.Appearance.Options.UseImage = true;
            toolTipTitleItem5.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem5.Image")));
            toolTipTitleItem5.Text = "New Client";
            toolTipItem5.LeftIndent = 6;
            toolTipItem5.Text = "To add new Scheme inforamtion click here.";
            superToolTip5.Items.Add(toolTipTitleItem5);
            superToolTip5.Items.Add(toolTipItem5);
            this.btnAdd.SuperTip = superToolTip5;
            this.btnAdd.TabIndex = 10;
            this.btnAdd.Text = "&Add";
            this.btnAdd.ToolTip = "Add new client";
            this.btnAdd.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Application;
            this.btnAdd.ToolTipTitle = "New Client";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // AmcView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 344);
            this.Controls.Add(this.gridControlAMC);
            this.Controls.Add(this.grpAmc);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Name = "AmcView";
            this.Tag = "AMC";
            this.Text = "AmcView";
            this.Load += new System.EventHandler(this.AmcView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlAMC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewAMC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpAmc)).EndInit();
            this.grpAmc.ResumeLayout(false);
            this.grpAmc.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlAMC;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewAMC;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraEditors.GroupControl grpAmc;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl lblLine;
        public DevExpress.XtraEditors.SimpleButton btnDelete;
        public DevExpress.XtraEditors.SimpleButton btnEdit;
        public DevExpress.XtraEditors.SimpleButton btnAdd;
    }
}