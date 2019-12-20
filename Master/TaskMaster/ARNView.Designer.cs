namespace FinancialPlannerClient.Master.TaskMaster
{
    partial class ARNView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ARNView));
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
            this.gridControlARN = new DevExpress.XtraGrid.GridControl();
            this.gridViewARN = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.lblLine = new DevExpress.XtraEditors.LabelControl();
            this.grpARNDetails = new DevExpress.XtraEditors.GroupControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtARNNumber = new DevExpress.XtraEditors.TextEdit();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.colARNNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlARN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewARN)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpARNDetails)).BeginInit();
            this.grpARNDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtARNNumber.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControlARN
            // 
            this.gridControlARN.Location = new System.Drawing.Point(12, 9);
            this.gridControlARN.MainView = this.gridViewARN;
            this.gridControlARN.Name = "gridControlARN";
            this.gridControlARN.Size = new System.Drawing.Size(444, 181);
            this.gridControlARN.TabIndex = 0;
            this.gridControlARN.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewARN});
            // 
            // gridViewARN
            // 
            this.gridViewARN.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colARNNo,
            this.colName,
            this.colID});
            this.gridViewARN.GridControl = this.gridControlARN;
            this.gridViewARN.Name = "gridViewARN";
            this.gridViewARN.OptionsBehavior.Editable = false;
            this.gridViewARN.OptionsView.ShowGroupPanel = false;
            this.gridViewARN.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridViewARN_SelectionChanged);
            this.gridViewARN.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewARN_FocusedRowChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(431, 196);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(25, 23);
            toolTipTitleItem1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            toolTipTitleItem1.Appearance.Options.UseImage = true;
            toolTipTitleItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem1.Image")));
            toolTipTitleItem1.Text = "Delete Client";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "To delete selected ARN record click here.";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.btnDelete.SuperTip = superToolTip1;
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
            toolTipTitleItem2.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            toolTipTitleItem2.Appearance.Options.UseImage = true;
            toolTipTitleItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem2.Image")));
            toolTipTitleItem2.Text = "Edit Customer";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "To modify selected ARN information click here.";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.btnEdit.SuperTip = superToolTip2;
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
            toolTipTitleItem3.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            toolTipTitleItem3.Appearance.Options.UseImage = true;
            toolTipTitleItem3.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem3.Image")));
            toolTipTitleItem3.Text = "New Client";
            toolTipItem3.LeftIndent = 6;
            toolTipItem3.Text = "To add new ARN inforamtion click here.";
            superToolTip3.Items.Add(toolTipTitleItem3);
            superToolTip3.Items.Add(toolTipItem3);
            this.btnAdd.SuperTip = superToolTip3;
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
            // grpARNDetails
            // 
            this.grpARNDetails.Controls.Add(this.btnCancel);
            this.grpARNDetails.Controls.Add(this.btnSave);
            this.grpARNDetails.Controls.Add(this.txtName);
            this.grpARNDetails.Controls.Add(this.txtARNNumber);
            this.grpARNDetails.Controls.Add(this.labelControl3);
            this.grpARNDetails.Controls.Add(this.labelControl2);
            this.grpARNDetails.Enabled = false;
            this.grpARNDetails.Location = new System.Drawing.Point(13, 233);
            this.grpARNDetails.Name = "grpARNDetails";
            this.grpARNDetails.Size = new System.Drawing.Size(443, 98);
            this.grpARNDetails.TabIndex = 8;
            this.grpARNDetails.Text = "ARN Details";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(14, 37);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(65, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "ARN Number:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(14, 63);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(31, 13);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Name:";
            // 
            // txtARNNumber
            // 
            this.txtARNNumber.Location = new System.Drawing.Point(85, 34);
            this.txtARNNumber.Name = "txtARNNumber";
            this.txtARNNumber.Size = new System.Drawing.Size(211, 20);
            this.txtARNNumber.TabIndex = 2;
            this.txtARNNumber.Validating += new System.ComponentModel.CancelEventHandler(this.txtARNNumber_Validating);
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(85, 60);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(211, 20);
            this.txtName.TabIndex = 3;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(367, 58);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(62, 23);
            toolTipTitleItem4.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            toolTipTitleItem4.Appearance.Options.UseImage = true;
            toolTipTitleItem4.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem4.Image")));
            toolTipTitleItem4.Text = "Cancel";
            toolTipItem4.LeftIndent = 6;
            toolTipItem4.Text = "To close ARN information without saving any information click here.";
            superToolTip4.Items.Add(toolTipTitleItem4);
            superToolTip4.Items.Add(toolTipItem4);
            this.btnCancel.SuperTip = superToolTip4;
            this.btnCancel.TabIndex = 43;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(304, 58);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(57, 23);
            toolTipTitleItem5.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image4")));
            toolTipTitleItem5.Appearance.Options.UseImage = true;
            toolTipTitleItem5.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem5.Image")));
            toolTipTitleItem5.Text = "Save";
            toolTipItem5.LeftIndent = 6;
            toolTipItem5.Text = "To save ARN infroamtion click here.";
            superToolTip5.Items.Add(toolTipTitleItem5);
            superToolTip5.Items.Add(toolTipItem5);
            this.btnSave.SuperTip = superToolTip5;
            this.btnSave.TabIndex = 42;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // colARNNo
            // 
            this.colARNNo.Caption = "ARN Number";
            this.colARNNo.FieldName = "ArnNumber";
            this.colARNNo.Name = "colARNNo";
            this.colARNNo.Visible = true;
            this.colARNNo.VisibleIndex = 0;
            // 
            // colName
            // 
            this.colName.Caption = "Name";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            this.colName.Visible = true;
            this.colName.VisibleIndex = 1;
            // 
            // colID
            // 
            this.colID.Caption = "ID";
            this.colID.FieldName = "Id";
            this.colID.Name = "colID";
            // 
            // ARNView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(468, 335);
            this.Controls.Add(this.grpARNDetails);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.gridControlARN);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ARNView";
            this.Text = "ARN";
            this.Load += new System.EventHandler(this.ARNView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlARN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewARN)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpARNDetails)).EndInit();
            this.grpARNDetails.ResumeLayout(false);
            this.grpARNDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtARNNumber.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControlARN;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewARN;
        public DevExpress.XtraEditors.SimpleButton btnDelete;
        public DevExpress.XtraEditors.SimpleButton btnEdit;
        public DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.LabelControl lblLine;
        private DevExpress.XtraEditors.GroupControl grpARNDetails;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.TextEdit txtARNNumber;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraGrid.Columns.GridColumn colARNNo;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
    }
}