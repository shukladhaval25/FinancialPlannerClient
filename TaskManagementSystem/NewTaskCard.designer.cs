﻿namespace FinancialPlannerClient.TaskManagementSystem
{
    partial class NewTaskCard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NewTaskCard));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            this.lblProject = new DevExpress.XtraEditors.LabelControl();
            this.cmbProject = new DevExpress.XtraEditors.ComboBoxEdit();
            this.comboBoxEdit2 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbClient = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEdit4 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtCreatedBy = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtCreatedOn = new DevExpress.XtraEditors.TextEdit();
            this.cmbAssingTo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.cmbPriority = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.labelControl9 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit3 = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit4 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.comboBoxEdit7 = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl12 = new DevExpress.XtraEditors.LabelControl();
            this.textEdit5 = new DevExpress.XtraEditors.TextEdit();
            this.btnAddProject = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.btnCloseClientInfo = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveClient = new DevExpress.XtraEditors.SimpleButton();
            this.vGridTransaction = new DevExpress.XtraVerticalGrid.VGridControl();
            this.cmbTransactionType = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblTransactionTypeTitle = new DevExpress.XtraEditors.LabelControl();
            this.lblTransactionDetails = new DevExpress.XtraEditors.LabelControl();
            this.lblTaskIDTitle = new DevExpress.XtraEditors.LabelControl();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            ((System.ComponentModel.ISupportInitialize)(this.cmbProject.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbClient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedBy.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedOn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAssingTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPriority.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit7.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit5.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridTransaction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTransactionType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProject
            // 
            this.lblProject.Location = new System.Drawing.Point(35, 37);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(38, 13);
            this.lblProject.TabIndex = 0;
            this.lblProject.Text = "Project:";
            // 
            // cmbProject
            // 
            this.cmbProject.Location = new System.Drawing.Point(128, 34);
            this.cmbProject.Name = "cmbProject";
            this.cmbProject.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbProject.Size = new System.Drawing.Size(408, 20);
            this.cmbProject.TabIndex = 1;
            this.cmbProject.SelectedIndexChanged += new System.EventHandler(this.cmbProject_SelectedIndexChanged);
            // 
            // comboBoxEdit2
            // 
            this.comboBoxEdit2.Location = new System.Drawing.Point(128, 88);
            this.comboBoxEdit2.Name = "comboBoxEdit2";
            this.comboBoxEdit2.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit2.Properties.Items.AddRange(new object[] {
            "Query",
            "Task"});
            this.comboBoxEdit2.Size = new System.Drawing.Size(439, 20);
            this.comboBoxEdit2.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(35, 91);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(54, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Card Type:";
            // 
            // cmbClient
            // 
            this.cmbClient.Location = new System.Drawing.Point(128, 114);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbClient.Size = new System.Drawing.Size(408, 20);
            this.cmbClient.TabIndex = 5;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(35, 117);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(50, 13);
            this.labelControl2.TabIndex = 4;
            this.labelControl2.Text = "Customer:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(35, 143);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(24, 13);
            this.labelControl3.TabIndex = 6;
            this.labelControl3.Text = "Title:";
            // 
            // comboBoxEdit4
            // 
            this.comboBoxEdit4.Location = new System.Drawing.Point(128, 140);
            this.comboBoxEdit4.Name = "comboBoxEdit4";
            this.comboBoxEdit4.Size = new System.Drawing.Size(439, 20);
            this.comboBoxEdit4.TabIndex = 7;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(581, 65);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(58, 13);
            this.labelControl4.TabIndex = 8;
            this.labelControl4.Text = "Created By:";
            // 
            // txtCreatedBy
            // 
            this.txtCreatedBy.Enabled = false;
            this.txtCreatedBy.Location = new System.Drawing.Point(581, 88);
            this.txtCreatedBy.Name = "txtCreatedBy";
            this.txtCreatedBy.Properties.ReadOnly = true;
            this.txtCreatedBy.Size = new System.Drawing.Size(326, 20);
            this.txtCreatedBy.TabIndex = 9;
            // 
            // labelControl5
            // 
            this.labelControl5.Location = new System.Drawing.Point(581, 118);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(60, 13);
            this.labelControl5.TabIndex = 10;
            this.labelControl5.Text = "Created On:";
            // 
            // txtCreatedOn
            // 
            this.txtCreatedOn.Enabled = false;
            this.txtCreatedOn.Location = new System.Drawing.Point(581, 141);
            this.txtCreatedOn.Name = "txtCreatedOn";
            this.txtCreatedOn.Properties.ReadOnly = true;
            this.txtCreatedOn.Size = new System.Drawing.Size(326, 20);
            this.txtCreatedOn.TabIndex = 11;
            // 
            // cmbAssingTo
            // 
            this.cmbAssingTo.Location = new System.Drawing.Point(581, 247);
            this.cmbAssingTo.Name = "cmbAssingTo";
            this.cmbAssingTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbAssingTo.Size = new System.Drawing.Size(326, 20);
            this.cmbAssingTo.TabIndex = 13;
            // 
            // labelControl6
            // 
            this.labelControl6.Location = new System.Drawing.Point(581, 224);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(50, 13);
            this.labelControl6.TabIndex = 12;
            this.labelControl6.Text = "Assing To:";
            // 
            // cmbPriority
            // 
            this.cmbPriority.EditValue = "Medium";
            this.cmbPriority.Location = new System.Drawing.Point(581, 300);
            this.cmbPriority.Name = "cmbPriority";
            this.cmbPriority.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPriority.Properties.Items.AddRange(new object[] {
            "Low",
            "Medium",
            "High"});
            this.cmbPriority.Size = new System.Drawing.Size(326, 20);
            this.cmbPriority.TabIndex = 15;
            // 
            // labelControl7
            // 
            this.labelControl7.Location = new System.Drawing.Point(581, 277);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(38, 13);
            this.labelControl7.TabIndex = 14;
            this.labelControl7.Text = "Priority:";
            // 
            // labelControl8
            // 
            this.labelControl8.Location = new System.Drawing.Point(581, 330);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(49, 13);
            this.labelControl8.TabIndex = 16;
            this.labelControl8.Text = "Due Date:";
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(633, 327);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(112, 20);
            this.dateEdit1.TabIndex = 17;
            // 
            // labelControl9
            // 
            this.labelControl9.Location = new System.Drawing.Point(8, 5);
            this.labelControl9.Name = "labelControl9";
            this.labelControl9.Size = new System.Drawing.Size(57, 13);
            this.labelControl9.TabIndex = 18;
            this.labelControl9.Text = "Description:";
            // 
            // textEdit3
            // 
            this.textEdit3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textEdit3.Location = new System.Drawing.Point(8, 24);
            this.textEdit3.Name = "textEdit3";
            this.textEdit3.Size = new System.Drawing.Size(525, 8);
            this.textEdit3.TabIndex = 19;
            // 
            // labelControl10
            // 
            this.labelControl10.Location = new System.Drawing.Point(757, 330);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(73, 13);
            this.labelControl10.TabIndex = 20;
            this.labelControl10.Text = "Completed (%)";
            // 
            // textEdit4
            // 
            this.textEdit4.EditValue = "0";
            this.textEdit4.Enabled = false;
            this.textEdit4.Location = new System.Drawing.Point(838, 327);
            this.textEdit4.Name = "textEdit4";
            this.textEdit4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.textEdit4.Size = new System.Drawing.Size(69, 20);
            this.textEdit4.TabIndex = 21;
            // 
            // labelControl11
            // 
            this.labelControl11.Location = new System.Drawing.Point(581, 353);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(50, 13);
            this.labelControl11.TabIndex = 22;
            this.labelControl11.Text = "Watchers:";
            // 
            // comboBoxEdit7
            // 
            this.comboBoxEdit7.Location = new System.Drawing.Point(581, 372);
            this.comboBoxEdit7.Name = "comboBoxEdit7";
            this.comboBoxEdit7.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboBoxEdit7.Size = new System.Drawing.Size(326, 20);
            this.comboBoxEdit7.TabIndex = 23;
            // 
            // labelControl12
            // 
            this.labelControl12.Location = new System.Drawing.Point(581, 171);
            this.labelControl12.Name = "labelControl12";
            this.labelControl12.Size = new System.Drawing.Size(60, 13);
            this.labelControl12.TabIndex = 24;
            this.labelControl12.Text = "Created On:";
            // 
            // textEdit5
            // 
            this.textEdit5.Enabled = false;
            this.textEdit5.Location = new System.Drawing.Point(581, 194);
            this.textEdit5.Name = "textEdit5";
            this.textEdit5.Properties.ReadOnly = true;
            this.textEdit5.Size = new System.Drawing.Size(326, 20);
            this.textEdit5.TabIndex = 25;
            // 
            // btnAddProject
            // 
            this.btnAddProject.Image = ((System.Drawing.Image)(resources.GetObject("btnAddProject.Image")));
            this.btnAddProject.Location = new System.Drawing.Point(542, 32);
            this.btnAddProject.Name = "btnAddProject";
            this.btnAddProject.Size = new System.Drawing.Size(25, 22);
            this.btnAddProject.TabIndex = 26;
            // 
            // simpleButton1
            // 
            this.simpleButton1.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(542, 114);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(25, 22);
            this.simpleButton1.TabIndex = 27;
            // 
            // btnCloseClientInfo
            // 
            this.btnCloseClientInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCloseClientInfo.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseClientInfo.Image")));
            this.btnCloseClientInfo.Location = new System.Drawing.Point(505, 402);
            this.btnCloseClientInfo.Name = "btnCloseClientInfo";
            this.btnCloseClientInfo.Size = new System.Drawing.Size(62, 23);
            toolTipTitleItem1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            toolTipTitleItem1.Appearance.Options.UseImage = true;
            toolTipTitleItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem1.Image")));
            toolTipTitleItem1.Text = "Cancel";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "To close client information without saving any information click here.";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.btnCloseClientInfo.SuperTip = superToolTip1;
            this.btnCloseClientInfo.TabIndex = 29;
            this.btnCloseClientInfo.Text = "&Close";
            // 
            // btnSaveClient
            // 
            this.btnSaveClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSaveClient.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveClient.Image")));
            this.btnSaveClient.Location = new System.Drawing.Point(442, 402);
            this.btnSaveClient.Name = "btnSaveClient";
            this.btnSaveClient.Size = new System.Drawing.Size(57, 23);
            toolTipTitleItem2.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            toolTipTitleItem2.Appearance.Options.UseImage = true;
            toolTipTitleItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem2.Image")));
            toolTipTitleItem2.Text = "Save";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "To save client infroamtion click here.";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.btnSaveClient.SuperTip = superToolTip2;
            this.btnSaveClient.TabIndex = 28;
            this.btnSaveClient.Text = "&Save";
            // 
            // vGridTransaction
            // 
            this.vGridTransaction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.vGridTransaction.Cursor = System.Windows.Forms.Cursors.Default;
            this.vGridTransaction.Location = new System.Drawing.Point(8, 22);
            this.vGridTransaction.Name = "vGridTransaction";
            this.vGridTransaction.RecordWidth = 343;
            this.vGridTransaction.RowHeaderWidth = 177;
            this.vGridTransaction.Size = new System.Drawing.Size(525, 127);
            this.vGridTransaction.TabIndex = 30;
            // 
            // cmbTransactionType
            // 
            this.cmbTransactionType.Location = new System.Drawing.Point(128, 62);
            this.cmbTransactionType.Name = "cmbTransactionType";
            this.cmbTransactionType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbTransactionType.Size = new System.Drawing.Size(439, 20);
            this.cmbTransactionType.TabIndex = 32;
            this.cmbTransactionType.SelectedIndexChanged += new System.EventHandler(this.cmbTransactionType_SelectedIndexChanged);
            // 
            // lblTransactionTypeTitle
            // 
            this.lblTransactionTypeTitle.Location = new System.Drawing.Point(35, 65);
            this.lblTransactionTypeTitle.Name = "lblTransactionTypeTitle";
            this.lblTransactionTypeTitle.Size = new System.Drawing.Size(87, 13);
            this.lblTransactionTypeTitle.TabIndex = 31;
            this.lblTransactionTypeTitle.Text = "Transaction Type:";
            // 
            // lblTransactionDetails
            // 
            this.lblTransactionDetails.Location = new System.Drawing.Point(3, 3);
            this.lblTransactionDetails.Name = "lblTransactionDetails";
            this.lblTransactionDetails.Size = new System.Drawing.Size(119, 13);
            this.lblTransactionDetails.TabIndex = 33;
            this.lblTransactionDetails.Text = "Transaction Inforamtion:";
            // 
            // lblTaskIDTitle
            // 
            this.lblTaskIDTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTaskIDTitle.Appearance.ForeColor = System.Drawing.Color.RoyalBlue;
            this.lblTaskIDTitle.Appearance.Options.UseFont = true;
            this.lblTaskIDTitle.Appearance.Options.UseForeColor = true;
            this.lblTaskIDTitle.Location = new System.Drawing.Point(128, 10);
            this.lblTaskIDTitle.Name = "lblTaskIDTitle";
            this.lblTaskIDTitle.Size = new System.Drawing.Size(0, 16);
            this.lblTaskIDTitle.TabIndex = 34;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.splitContainerControl1.Horizontal = false;
            this.splitContainerControl1.Location = new System.Drawing.Point(29, 180);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.lblTransactionDetails);
            this.splitContainerControl1.Panel1.Controls.Add(this.vGridTransaction);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.labelControl9);
            this.splitContainerControl1.Panel2.Controls.Add(this.textEdit3);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(538, 212);
            this.splitContainerControl1.SplitterPosition = 160;
            this.splitContainerControl1.TabIndex = 36;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // NewTaskCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(935, 437);
            this.Controls.Add(this.splitContainerControl1);
            this.Controls.Add(this.lblTaskIDTitle);
            this.Controls.Add(this.cmbTransactionType);
            this.Controls.Add(this.lblTransactionTypeTitle);
            this.Controls.Add(this.btnCloseClientInfo);
            this.Controls.Add(this.btnSaveClient);
            this.Controls.Add(this.simpleButton1);
            this.Controls.Add(this.btnAddProject);
            this.Controls.Add(this.labelControl12);
            this.Controls.Add(this.textEdit5);
            this.Controls.Add(this.comboBoxEdit7);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.textEdit4);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.labelControl8);
            this.Controls.Add(this.cmbPriority);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.cmbAssingTo);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.txtCreatedOn);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.txtCreatedBy);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.cmbClient);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.comboBoxEdit2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.cmbProject);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.comboBoxEdit4);
            this.Name = "NewTaskCard";
            this.Text = "New Card";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.NewTaskCard_FormClosed);
            this.Load += new System.EventHandler(this.NewTaskCard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbProject.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbClient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedBy.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCreatedOn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAssingTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPriority.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit4.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboBoxEdit7.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit5.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.vGridTransaction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbTransactionType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblProject;
        private DevExpress.XtraEditors.ComboBoxEdit cmbProject;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cmbClient;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit comboBoxEdit4;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtCreatedBy;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtCreatedOn;
        private DevExpress.XtraEditors.ComboBoxEdit cmbAssingTo;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPriority;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl9;
        private DevExpress.XtraEditors.MemoEdit textEdit3;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.TextEdit textEdit4;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit7;
        private DevExpress.XtraEditors.LabelControl labelControl12;
        private DevExpress.XtraEditors.TextEdit textEdit5;
        private DevExpress.XtraEditors.SimpleButton btnAddProject;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraEditors.SimpleButton btnCloseClientInfo;
        private DevExpress.XtraEditors.SimpleButton btnSaveClient;
        private DevExpress.XtraVerticalGrid.VGridControl vGridTransaction;
        private DevExpress.XtraEditors.ComboBoxEdit cmbTransactionType;
        private DevExpress.XtraEditors.LabelControl lblTransactionTypeTitle;
        private DevExpress.XtraEditors.LabelControl lblTransactionDetails;
        private DevExpress.XtraEditors.LabelControl lblTaskIDTitle;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
    }
}

