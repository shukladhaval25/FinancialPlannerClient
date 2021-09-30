﻿namespace FinancialPlannerClient.Master.TaskMaster
{
    partial class SchemeView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SchemeView));
            DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem6 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem6 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip7 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem7 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem7 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip8 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem8 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem8 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip9 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem9 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem9 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip10 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem10 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem10 = new DevExpress.Utils.ToolTipItem();
            this.gridControlScheme = new DevExpress.XtraGrid.GridControl();
            this.gridViewScheme = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAMCId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAMCName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCategoryId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colChequeInFavourOff = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.lblLine = new DevExpress.XtraEditors.LabelControl();
            this.grpSchemeDetails = new DevExpress.XtraEditors.GroupControl();
            this.cmbType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtChequeInFavourOff = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lookupCategory = new DevExpress.XtraEditors.LookUpEdit();
            this.cmbAMC = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlScheme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewScheme)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpSchemeDetails)).BeginInit();
            this.grpSchemeDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChequeInFavourOff.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupCategory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAMC.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlScheme
            // 
            this.gridControlScheme.Location = new System.Drawing.Point(12, 9);
            this.gridControlScheme.MainView = this.gridViewScheme;
            this.gridControlScheme.Name = "gridControlScheme";
            this.gridControlScheme.Size = new System.Drawing.Size(444, 181);
            this.gridControlScheme.TabIndex = 0;
            this.gridControlScheme.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewScheme});
            // 
            // gridViewScheme
            // 
            this.gridViewScheme.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colName,
            this.colID,
            this.colAMCId,
            this.colAMCName,
            this.colCategoryId,
            this.colChequeInFavourOff,
            this.colType});
            this.gridViewScheme.GridControl = this.gridControlScheme;
            this.gridViewScheme.Name = "gridViewScheme";
            this.gridViewScheme.OptionsBehavior.Editable = false;
            this.gridViewScheme.OptionsView.ShowGroupPanel = false;
            this.gridViewScheme.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridViewScheme_SelectionChanged);
            this.gridViewScheme.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewScheme_FocusedRowChanged);
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
            // colAMCId
            // 
            this.colAMCId.Caption = "AMCId";
            this.colAMCId.FieldName = "AmcId";
            this.colAMCId.Name = "colAMCId";
            // 
            // colAMCName
            // 
            this.colAMCName.Caption = "AMC Name";
            this.colAMCName.FieldName = "AmcName";
            this.colAMCName.Name = "colAMCName";
            this.colAMCName.Visible = true;
            this.colAMCName.VisibleIndex = 1;
            // 
            // colCategoryId
            // 
            this.colCategoryId.Caption = "CategoryId";
            this.colCategoryId.FieldName = "CategoryId";
            this.colCategoryId.Name = "colCategoryId";
            // 
            // colChequeInFavourOff
            // 
            this.colChequeInFavourOff.Caption = "Cheque in favour off";
            this.colChequeInFavourOff.FieldName = "ChequeInFavourOff";
            this.colChequeInFavourOff.Name = "colChequeInFavourOff";
            // 
            // colType
            // 
            this.colType.Caption = "Type";
            this.colType.FieldName = "Type";
            this.colType.Name = "colType";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(431, 196);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(25, 23);
            toolTipTitleItem6.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            toolTipTitleItem6.Appearance.Options.UseImage = true;
            toolTipTitleItem6.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem6.Image")));
            toolTipTitleItem6.Text = "Delete Client";
            toolTipItem6.LeftIndent = 6;
            toolTipItem6.Text = "To delete selected Scheme record click here.";
            superToolTip6.Items.Add(toolTipTitleItem6);
            superToolTip6.Items.Add(toolTipItem6);
            this.btnDelete.SuperTip = superToolTip6;
            this.btnDelete.TabIndex = 6;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.ToolTip = "Delete Client";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(400, 196);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(25, 23);
            toolTipTitleItem7.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            toolTipTitleItem7.Appearance.Options.UseImage = true;
            toolTipTitleItem7.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem7.Image")));
            toolTipTitleItem7.Text = "Edit Customer";
            toolTipItem7.LeftIndent = 6;
            toolTipItem7.Text = "To modify selected Scheme information click here.";
            superToolTip7.Items.Add(toolTipTitleItem7);
            superToolTip7.Items.Add(toolTipItem7);
            this.btnEdit.SuperTip = superToolTip7;
            this.btnEdit.TabIndex = 5;
            this.btnEdit.Text = "&Edit";
            this.btnEdit.ToolTip = "Edit Client";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(369, 196);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 23);
            toolTipTitleItem8.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            toolTipTitleItem8.Appearance.Options.UseImage = true;
            toolTipTitleItem8.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem8.Image")));
            toolTipTitleItem8.Text = "New Client";
            toolTipItem8.LeftIndent = 6;
            toolTipItem8.Text = "To add new Scheme inforamtion click here.";
            superToolTip8.Items.Add(toolTipTitleItem8);
            superToolTip8.Items.Add(toolTipItem8);
            this.btnAdd.SuperTip = superToolTip8;
            this.btnAdd.TabIndex = 4;
            this.btnAdd.Text = "&Add";
            this.btnAdd.ToolTip = "Add new client";
            this.btnAdd.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Application;
            this.btnAdd.ToolTipTitle = "New Client";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblLine
            // 
            this.lblLine.Appearance.BackColor = System.Drawing.Color.Silver;
            this.lblLine.Appearance.Options.UseBackColor = true;
            this.lblLine.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblLine.Location = new System.Drawing.Point(13, 224);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(443, 2);
            this.lblLine.TabIndex = 7;
            // 
            // grpSchemeDetails
            // 
            this.grpSchemeDetails.Controls.Add(this.cmbType);
            this.grpSchemeDetails.Controls.Add(this.labelControl5);
            this.grpSchemeDetails.Controls.Add(this.txtChequeInFavourOff);
            this.grpSchemeDetails.Controls.Add(this.labelControl4);
            this.grpSchemeDetails.Controls.Add(this.labelControl2);
            this.grpSchemeDetails.Controls.Add(this.lookupCategory);
            this.grpSchemeDetails.Controls.Add(this.cmbAMC);
            this.grpSchemeDetails.Controls.Add(this.labelControl1);
            this.grpSchemeDetails.Controls.Add(this.btnCancel);
            this.grpSchemeDetails.Controls.Add(this.btnSave);
            this.grpSchemeDetails.Controls.Add(this.txtName);
            this.grpSchemeDetails.Controls.Add(this.labelControl3);
            this.grpSchemeDetails.Enabled = false;
            this.grpSchemeDetails.Location = new System.Drawing.Point(13, 233);
            this.grpSchemeDetails.Name = "grpSchemeDetails";
            this.grpSchemeDetails.Size = new System.Drawing.Size(443, 166);
            this.grpSchemeDetails.TabIndex = 8;
            this.grpSchemeDetails.Text = "Scheme Details";
            this.grpSchemeDetails.Paint += new System.Windows.Forms.PaintEventHandler(this.grpSchemeDetails_Paint);
            // 
            // cmbType
            // 
            this.cmbType.Location = new System.Drawing.Point(129, 139);
            this.cmbType.Name = "cmbType";
            this.cmbType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbType.Properties.Items.AddRange(new object[] {
            "Equity",
            "Debt",
            "Hybrid",
            "Gold"});
            this.cmbType.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbType.Size = new System.Drawing.Size(238, 20);
            this.cmbType.TabIndex = 50;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(18, 142);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(28, 13);
            this.labelControl5.TabIndex = 51;
            this.labelControl5.Text = "Type:";
            // 
            // txtChequeInFavourOff
            // 
            this.txtChequeInFavourOff.Location = new System.Drawing.Point(129, 113);
            this.txtChequeInFavourOff.Name = "txtChequeInFavourOff";
            this.txtChequeInFavourOff.Size = new System.Drawing.Size(238, 20);
            this.txtChequeInFavourOff.TabIndex = 3;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(18, 116);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(104, 13);
            this.labelControl4.TabIndex = 49;
            this.labelControl4.Text = "Cheque in favour off:";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(18, 90);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(49, 13);
            this.labelControl2.TabIndex = 48;
            this.labelControl2.Text = "Category:";
            // 
            // lookupCategory
            // 
            this.lookupCategory.Location = new System.Drawing.Point(129, 87);
            this.lookupCategory.Name = "lookupCategory";
            this.lookupCategory.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookupCategory.Properties.NullText = "";
            this.lookupCategory.Size = new System.Drawing.Size(238, 20);
            this.lookupCategory.TabIndex = 2;
            // 
            // cmbAMC
            // 
            this.cmbAMC.Location = new System.Drawing.Point(129, 34);
            this.cmbAMC.Name = "cmbAMC";
            this.cmbAMC.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbAMC.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbAMC.Size = new System.Drawing.Size(238, 20);
            this.cmbAMC.TabIndex = 0;
            this.cmbAMC.SelectedIndexChanged += new System.EventHandler(this.cmbAMC_SelectedIndexChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(18, 37);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(26, 13);
            this.labelControl1.TabIndex = 46;
            this.labelControl1.Text = "AMC:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(376, 135);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(62, 23);
            toolTipTitleItem9.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            toolTipTitleItem9.Appearance.Options.UseImage = true;
            toolTipTitleItem9.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem9.Image")));
            toolTipTitleItem9.Text = "Cancel";
            toolTipItem9.LeftIndent = 6;
            toolTipItem9.Text = "To close Scheme information without saving any information click here.";
            superToolTip9.Items.Add(toolTipTitleItem9);
            superToolTip9.Items.Add(toolTipItem9);
            this.btnCancel.SuperTip = superToolTip9;
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(376, 109);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(62, 23);
            toolTipTitleItem10.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image4")));
            toolTipTitleItem10.Appearance.Options.UseImage = true;
            toolTipTitleItem10.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem10.Image")));
            toolTipTitleItem10.Text = "Save";
            toolTipItem10.LeftIndent = 6;
            toolTipItem10.Text = "To save Scheme infroamtion click here.";
            superToolTip10.Items.Add(toolTipTitleItem10);
            superToolTip10.Items.Add(toolTipItem10);
            this.btnSave.SuperTip = superToolTip10;
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(129, 60);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(238, 20);
            this.txtName.TabIndex = 1;
            this.txtName.Leave += new System.EventHandler(this.txtName_Leave);
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(18, 63);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(31, 13);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Name:";
            // 
            // SchemeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 411);
            this.Controls.Add(this.grpSchemeDetails);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gridControlScheme);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SchemeView";
            this.Tag = "MF Scheme";
            this.Text = "Scheme";
            this.Load += new System.EventHandler(this.SchemeView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlScheme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewScheme)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpSchemeDetails)).EndInit();
            this.grpSchemeDetails.ResumeLayout(false);
            this.grpSchemeDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtChequeInFavourOff.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookupCategory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAMC.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlScheme;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewScheme;
        public DevExpress.XtraEditors.SimpleButton btnDelete;
        public DevExpress.XtraEditors.SimpleButton btnEdit;
        public DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.LabelControl lblLine;
        private DevExpress.XtraEditors.GroupControl grpSchemeDetails;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraEditors.ComboBoxEdit cmbAMC;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colAMCId;
        private DevExpress.XtraGrid.Columns.GridColumn colAMCName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit lookupCategory;
        private DevExpress.XtraGrid.Columns.GridColumn colCategoryId;
        private DevExpress.XtraEditors.TextEdit txtChequeInFavourOff;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraGrid.Columns.GridColumn colChequeInFavourOff;
        private DevExpress.XtraEditors.ComboBoxEdit cmbType;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraGrid.Columns.GridColumn colType;
    }
}