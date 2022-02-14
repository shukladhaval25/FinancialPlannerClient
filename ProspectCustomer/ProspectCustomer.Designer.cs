﻿namespace FinancialPlannerClient.ProspectCustomer
{
    partial class ProspectCustomer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProspectCustomer));
            this.grpProspectCustomer = new System.Windows.Forms.GroupBox();
            this.pnlClient = new System.Windows.Forms.Panel();
            this.cmbClientAssignTo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.chkStopSendingEmail = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.chkIsConvertedToCustomer = new System.Windows.Forms.CheckBox();
            this.cmbClient = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.dtIntroductionCompletdOn = new System.Windows.Forms.DateTimePicker();
            this.txtRemark = new System.Windows.Forms.TextBox();
            this.chkIntroductionCompleted = new System.Windows.Forms.CheckBox();
            this.txtRefBy = new System.Windows.Forms.TextBox();
            this.lblRefBy = new System.Windows.Forms.Label();
            this.dtEventDate = new System.Windows.Forms.DateTimePicker();
            this.lblEventDate = new System.Windows.Forms.Label();
            this.txtEvent = new System.Windows.Forms.TextBox();
            this.lblEvent = new System.Windows.Forms.Label();
            this.txtOccupation = new System.Windows.Forms.TextBox();
            this.lblOccupation = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblLastName = new System.Windows.Forms.Label();
            this.lblPhoneNo = new System.Windows.Forms.Label();
            this.lblName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.imgCollection = new System.Windows.Forms.ImageList(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.grpConverstion = new System.Windows.Forms.GroupBox();
            this.grpActionControls = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEditConversation = new System.Windows.Forms.Button();
            this.dataGridConversation = new System.Windows.Forms.DataGridView();
            this.btnAddConversation = new System.Windows.Forms.Button();
            this.btnShowConversation = new System.Windows.Forms.Button();
            this.btnHideConversation = new System.Windows.Forms.Button();
            this.toolTipProspeectClient = new System.Windows.Forms.ToolTip(this.components);
            this.btnConvertToClient = new System.Windows.Forms.Button();
            this.tbProspCustomer = new System.Windows.Forms.TabControl();
            this.tbpageProspectCustomer = new System.Windows.Forms.TabPage();
            this.tpageEmailSendHistory = new System.Windows.Forms.TabPage();
            this.imageList30x30 = new System.Windows.Forms.ImageList(this.components);
            this.grpProspectCustomer.SuspendLayout();
            this.pnlClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbClientAssignTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbClient.Properties)).BeginInit();
            this.grpConverstion.SuspendLayout();
            this.grpActionControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridConversation)).BeginInit();
            this.tbProspCustomer.SuspendLayout();
            this.tbpageProspectCustomer.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpProspectCustomer
            // 
            this.grpProspectCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpProspectCustomer.BackColor = System.Drawing.Color.Transparent;
            this.grpProspectCustomer.Controls.Add(this.pnlClient);
            this.grpProspectCustomer.Controls.Add(this.txtRefBy);
            this.grpProspectCustomer.Controls.Add(this.lblRefBy);
            this.grpProspectCustomer.Controls.Add(this.dtEventDate);
            this.grpProspectCustomer.Controls.Add(this.lblEventDate);
            this.grpProspectCustomer.Controls.Add(this.txtEvent);
            this.grpProspectCustomer.Controls.Add(this.lblEvent);
            this.grpProspectCustomer.Controls.Add(this.txtOccupation);
            this.grpProspectCustomer.Controls.Add(this.lblOccupation);
            this.grpProspectCustomer.Controls.Add(this.txtEmail);
            this.grpProspectCustomer.Controls.Add(this.txtPhoneNo);
            this.grpProspectCustomer.Controls.Add(this.txtName);
            this.grpProspectCustomer.Controls.Add(this.lblLastName);
            this.grpProspectCustomer.Controls.Add(this.lblPhoneNo);
            this.grpProspectCustomer.Controls.Add(this.lblName);
            this.grpProspectCustomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpProspectCustomer.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.grpProspectCustomer.Location = new System.Drawing.Point(3, 10);
            this.grpProspectCustomer.Name = "grpProspectCustomer";
            this.grpProspectCustomer.Size = new System.Drawing.Size(707, 223);
            this.grpProspectCustomer.TabIndex = 0;
            this.grpProspectCustomer.TabStop = false;
            this.grpProspectCustomer.Text = "Propsect Customer Information";
            this.toolTipProspeectClient.SetToolTip(this.grpProspectCustomer, "Information about propsect customer");
            this.grpProspectCustomer.Enter += new System.EventHandler(this.grpProspectCustomer_Enter);
            // 
            // pnlClient
            // 
            this.pnlClient.Controls.Add(this.cmbClientAssignTo);
            this.pnlClient.Controls.Add(this.label3);
            this.pnlClient.Controls.Add(this.chkStopSendingEmail);
            this.pnlClient.Controls.Add(this.label2);
            this.pnlClient.Controls.Add(this.chkIsConvertedToCustomer);
            this.pnlClient.Controls.Add(this.cmbClient);
            this.pnlClient.Controls.Add(this.label1);
            this.pnlClient.Controls.Add(this.dtIntroductionCompletdOn);
            this.pnlClient.Controls.Add(this.txtRemark);
            this.pnlClient.Controls.Add(this.chkIntroductionCompleted);
            this.pnlClient.Location = new System.Drawing.Point(368, 26);
            this.pnlClient.Name = "pnlClient";
            this.pnlClient.Size = new System.Drawing.Size(333, 193);
            this.pnlClient.TabIndex = 30;
            this.pnlClient.Visible = false;
            // 
            // cmbClientAssignTo
            // 
            this.cmbClientAssignTo.Location = new System.Drawing.Point(110, 82);
            this.cmbClientAssignTo.Name = "cmbClientAssignTo";
            this.cmbClientAssignTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbClientAssignTo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbClientAssignTo.Size = new System.Drawing.Size(171, 20);
            this.cmbClientAssignTo.TabIndex = 32;
            this.cmbClientAssignTo.SelectedIndexChanged += new System.EventHandler(this.cmbClientAssignTo_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 31;
            this.label3.Text = "Client Assign To:";
            // 
            // chkStopSendingEmail
            // 
            this.chkStopSendingEmail.AutoSize = true;
            this.chkStopSendingEmail.Location = new System.Drawing.Point(10, 8);
            this.chkStopSendingEmail.Name = "chkStopSendingEmail";
            this.chkStopSendingEmail.Size = new System.Drawing.Size(188, 19);
            this.chkStopSendingEmail.TabIndex = 21;
            this.chkStopSendingEmail.Text = "Stop sending email by system";
            this.chkStopSendingEmail.UseVisualStyleBackColor = true;
            this.chkStopSendingEmail.CheckedChanged += new System.EventHandler(this.chkStopSendingEmail_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(199, 15);
            this.label2.TabIndex = 29;
            this.label2.Text = "Select name of client from client list";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // chkIsConvertedToCustomer
            // 
            this.chkIsConvertedToCustomer.AutoSize = true;
            this.chkIsConvertedToCustomer.Location = new System.Drawing.Point(201, 8);
            this.chkIsConvertedToCustomer.Name = "chkIsConvertedToCustomer";
            this.chkIsConvertedToCustomer.Size = new System.Drawing.Size(126, 19);
            this.chkIsConvertedToCustomer.TabIndex = 22;
            this.chkIsConvertedToCustomer.Text = "Converted to client";
            this.chkIsConvertedToCustomer.UseVisualStyleBackColor = true;
            this.chkIsConvertedToCustomer.CheckedChanged += new System.EventHandler(this.chkIsConvertedToCustomer_CheckedChanged);
            // 
            // cmbClient
            // 
            this.cmbClient.Location = new System.Drawing.Point(10, 55);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbClient.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbClient.Size = new System.Drawing.Size(271, 20);
            this.cmbClient.TabIndex = 23;
            this.cmbClient.SelectedIndexChanged += new System.EventHandler(this.cmbClient_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 103);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 15);
            this.label1.TabIndex = 23;
            this.label1.Text = "Remark:";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dtIntroductionCompletdOn
            // 
            this.dtIntroductionCompletdOn.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtIntroductionCompletdOn.Location = new System.Drawing.Point(171, 163);
            this.dtIntroductionCompletdOn.MinDate = new System.DateTime(2000, 1, 1, 0, 0, 0, 0);
            this.dtIntroductionCompletdOn.Name = "dtIntroductionCompletdOn";
            this.dtIntroductionCompletdOn.Size = new System.Drawing.Size(109, 21);
            this.dtIntroductionCompletdOn.TabIndex = 27;
            this.dtIntroductionCompletdOn.Visible = false;
            this.dtIntroductionCompletdOn.ValueChanged += new System.EventHandler(this.dtIntroductionCompletdOn_ValueChanged);
            // 
            // txtRemark
            // 
            this.txtRemark.Location = new System.Drawing.Point(7, 122);
            this.txtRemark.Multiline = true;
            this.txtRemark.Name = "txtRemark";
            this.txtRemark.Size = new System.Drawing.Size(273, 35);
            this.txtRemark.TabIndex = 24;
            this.txtRemark.TextChanged += new System.EventHandler(this.txtRemark_TextChanged);
            // 
            // chkIntroductionCompleted
            // 
            this.chkIntroductionCompleted.AutoSize = true;
            this.chkIntroductionCompleted.Location = new System.Drawing.Point(7, 163);
            this.chkIntroductionCompleted.Name = "chkIntroductionCompleted";
            this.chkIntroductionCompleted.Size = new System.Drawing.Size(153, 19);
            this.chkIntroductionCompleted.TabIndex = 25;
            this.chkIntroductionCompleted.Text = "Introduction Completed";
            this.chkIntroductionCompleted.UseVisualStyleBackColor = true;
            this.chkIntroductionCompleted.CheckedChanged += new System.EventHandler(this.chkIntroductionCompleted_CheckedChanged);
            // 
            // txtRefBy
            // 
            this.txtRefBy.Location = new System.Drawing.Point(120, 193);
            this.txtRefBy.Name = "txtRefBy";
            this.txtRefBy.Size = new System.Drawing.Size(158, 21);
            this.txtRefBy.TabIndex = 20;
            this.txtRefBy.TextChanged += new System.EventHandler(this.txtRefBy_TextChanged);
            // 
            // lblRefBy
            // 
            this.lblRefBy.AutoSize = true;
            this.lblRefBy.Location = new System.Drawing.Point(16, 195);
            this.lblRefBy.Name = "lblRefBy";
            this.lblRefBy.Size = new System.Drawing.Size(90, 15);
            this.lblRefBy.TabIndex = 19;
            this.lblRefBy.Text = "Referenced By:";
            this.lblRefBy.Click += new System.EventHandler(this.lblRefBy_Click);
            // 
            // dtEventDate
            // 
            this.dtEventDate.Location = new System.Drawing.Point(120, 163);
            this.dtEventDate.Name = "dtEventDate";
            this.dtEventDate.Size = new System.Drawing.Size(242, 21);
            this.dtEventDate.TabIndex = 18;
            // 
            // lblEventDate
            // 
            this.lblEventDate.AutoSize = true;
            this.lblEventDate.Location = new System.Drawing.Point(16, 169);
            this.lblEventDate.Name = "lblEventDate";
            this.lblEventDate.Size = new System.Drawing.Size(69, 15);
            this.lblEventDate.TabIndex = 17;
            this.lblEventDate.Text = "Event Date:";
            // 
            // txtEvent
            // 
            this.txtEvent.Location = new System.Drawing.Point(120, 137);
            this.txtEvent.Name = "txtEvent";
            this.txtEvent.Size = new System.Drawing.Size(242, 21);
            this.txtEvent.TabIndex = 16;
            // 
            // lblEvent
            // 
            this.lblEvent.AutoSize = true;
            this.lblEvent.Location = new System.Drawing.Point(16, 140);
            this.lblEvent.Name = "lblEvent";
            this.lblEvent.Size = new System.Drawing.Size(105, 15);
            this.lblEvent.TabIndex = 15;
            this.lblEvent.Text = "Event Information:";
            // 
            // txtOccupation
            // 
            this.txtOccupation.Location = new System.Drawing.Point(120, 110);
            this.txtOccupation.Name = "txtOccupation";
            this.txtOccupation.Size = new System.Drawing.Size(242, 21);
            this.txtOccupation.TabIndex = 14;
            // 
            // lblOccupation
            // 
            this.lblOccupation.AutoSize = true;
            this.lblOccupation.Location = new System.Drawing.Point(16, 113);
            this.lblOccupation.Name = "lblOccupation";
            this.lblOccupation.Size = new System.Drawing.Size(72, 15);
            this.lblOccupation.TabIndex = 13;
            this.lblOccupation.Text = "Occupation:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(120, 84);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(242, 21);
            this.txtEmail.TabIndex = 12;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Location = new System.Drawing.Point(120, 58);
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(242, 21);
            this.txtPhoneNo.TabIndex = 11;
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(120, 32);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(242, 21);
            this.txtName.TabIndex = 10;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            // 
            // lblLastName
            // 
            this.lblLastName.AutoSize = true;
            this.lblLastName.Location = new System.Drawing.Point(16, 84);
            this.lblLastName.Name = "lblLastName";
            this.lblLastName.Size = new System.Drawing.Size(42, 15);
            this.lblLastName.TabIndex = 9;
            this.lblLastName.Text = "Email:";
            // 
            // lblPhoneNo
            // 
            this.lblPhoneNo.AutoSize = true;
            this.lblPhoneNo.Location = new System.Drawing.Point(16, 58);
            this.lblPhoneNo.Name = "lblPhoneNo";
            this.lblPhoneNo.Size = new System.Drawing.Size(65, 15);
            this.lblPhoneNo.TabIndex = 8;
            this.lblPhoneNo.Text = "Phone No:";
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(16, 32);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(44, 15);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "Name:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.ImageKey = "icons8-cancel-16.png";
            this.btnCancel.ImageList = this.imgCollection;
            this.btnCancel.Location = new System.Drawing.Point(650, 291);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 26);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.toolTipProspeectClient.SetToolTip(this.btnCancel, "Cancel and close.");
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // imgCollection
            // 
            this.imgCollection.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgCollection.ImageStream")));
            this.imgCollection.TransparentColor = System.Drawing.Color.Transparent;
            this.imgCollection.Images.SetKeyName(0, "Add-Action.png");
            this.imgCollection.Images.SetKeyName(1, "delete.png");
            this.imgCollection.Images.SetKeyName(2, "deleteline.png");
            this.imgCollection.Images.SetKeyName(3, "drop-add.gif");
            this.imgCollection.Images.SetKeyName(4, "Edit.png");
            this.imgCollection.Images.SetKeyName(5, "icons8-cancel-16.png");
            this.imgCollection.Images.SetKeyName(6, "icons8-save-close-16.png");
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.ImageKey = "icons8-save-close-16.png";
            this.btnSave.ImageList = this.imgCollection;
            this.btnSave.Location = new System.Drawing.Point(569, 291);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 26);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            this.toolTipProspeectClient.SetToolTip(this.btnSave, "Save prospect client data.");
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpConverstion
            // 
            this.grpConverstion.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpConverstion.Controls.Add(this.grpActionControls);
            this.grpConverstion.Controls.Add(this.dataGridConversation);
            this.grpConverstion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpConverstion.Location = new System.Drawing.Point(8, 319);
            this.grpConverstion.Name = "grpConverstion";
            this.grpConverstion.Size = new System.Drawing.Size(720, 283);
            this.grpConverstion.TabIndex = 6;
            this.grpConverstion.TabStop = false;
            this.grpConverstion.Text = "Conversation Details";
            this.grpConverstion.Visible = false;
            // 
            // grpActionControls
            // 
            this.grpActionControls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grpActionControls.Controls.Add(this.btnDelete);
            this.grpActionControls.Controls.Add(this.btnAdd);
            this.grpActionControls.Controls.Add(this.btnEditConversation);
            this.grpActionControls.Location = new System.Drawing.Point(606, 245);
            this.grpActionControls.Name = "grpActionControls";
            this.grpActionControls.Size = new System.Drawing.Size(111, 38);
            this.grpActionControls.TabIndex = 7;
            this.grpActionControls.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.ImageIndex = 1;
            this.btnDelete.ImageList = this.imgCollection;
            this.btnDelete.Location = new System.Drawing.Point(76, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(29, 24);
            this.btnDelete.TabIndex = 4;
            this.toolTipProspeectClient.SetToolTip(this.btnDelete, "Remove conversation detail.");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.ImageIndex = 3;
            this.btnAdd.ImageList = this.imgCollection;
            this.btnAdd.Location = new System.Drawing.Point(6, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(29, 24);
            this.btnAdd.TabIndex = 2;
            this.toolTipProspeectClient.SetToolTip(this.btnAdd, "Add conversation details");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAddConversation_Click);
            // 
            // btnEditConversation
            // 
            this.btnEditConversation.ImageIndex = 4;
            this.btnEditConversation.ImageList = this.imgCollection;
            this.btnEditConversation.Location = new System.Drawing.Point(41, 10);
            this.btnEditConversation.Name = "btnEditConversation";
            this.btnEditConversation.Size = new System.Drawing.Size(29, 24);
            this.btnEditConversation.TabIndex = 3;
            this.toolTipProspeectClient.SetToolTip(this.btnEditConversation, "Edit conversation details");
            this.btnEditConversation.UseVisualStyleBackColor = true;
            this.btnEditConversation.Click += new System.EventHandler(this.btnEditConversation_Click);
            // 
            // dataGridConversation
            // 
            this.dataGridConversation.AllowUserToAddRows = false;
            this.dataGridConversation.AllowUserToDeleteRows = false;
            this.dataGridConversation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridConversation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridConversation.Location = new System.Drawing.Point(3, 18);
            this.dataGridConversation.MultiSelect = false;
            this.dataGridConversation.Name = "dataGridConversation";
            this.dataGridConversation.ReadOnly = true;
            this.dataGridConversation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridConversation.Size = new System.Drawing.Size(714, 225);
            this.dataGridConversation.TabIndex = 0;
            // 
            // btnAddConversation
            // 
            this.btnAddConversation.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnAddConversation.ImageKey = "icons8-chat-16.png";
            this.btnAddConversation.Location = new System.Drawing.Point(162, 291);
            this.btnAddConversation.Name = "btnAddConversation";
            this.btnAddConversation.Size = new System.Drawing.Size(147, 26);
            this.btnAddConversation.TabIndex = 8;
            this.btnAddConversation.Text = "Add Conversation";
            this.toolTipProspeectClient.SetToolTip(this.btnAddConversation, "Add conversation detail.");
            this.btnAddConversation.UseVisualStyleBackColor = true;
            this.btnAddConversation.Click += new System.EventHandler(this.btnAddConversation_Click);
            // 
            // btnShowConversation
            // 
            this.btnShowConversation.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnShowConversation.ImageKey = "icons8-double-down-16.png";
            this.btnShowConversation.Location = new System.Drawing.Point(11, 291);
            this.btnShowConversation.Name = "btnShowConversation";
            this.btnShowConversation.Size = new System.Drawing.Size(147, 26);
            this.btnShowConversation.TabIndex = 5;
            this.btnShowConversation.Text = "Show Conversation";
            this.toolTipProspeectClient.SetToolTip(this.btnShowConversation, "Show conversation details");
            this.btnShowConversation.UseVisualStyleBackColor = true;
            this.btnShowConversation.Click += new System.EventHandler(this.btnShowConversation_Click);
            // 
            // btnHideConversation
            // 
            this.btnHideConversation.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnHideConversation.ImageKey = "icons8-double-up-16.png";
            this.btnHideConversation.Location = new System.Drawing.Point(11, 291);
            this.btnHideConversation.Name = "btnHideConversation";
            this.btnHideConversation.Size = new System.Drawing.Size(147, 26);
            this.btnHideConversation.TabIndex = 7;
            this.btnHideConversation.Text = "Hide Conversation";
            this.btnHideConversation.UseVisualStyleBackColor = true;
            this.btnHideConversation.Click += new System.EventHandler(this.btnHideConversation_Click);
            // 
            // toolTipProspeectClient
            // 
            this.toolTipProspeectClient.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            // 
            // btnConvertToClient
            // 
            this.btnConvertToClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConvertToClient.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnConvertToClient.ImageKey = "icons8-chat-16.png";
            this.btnConvertToClient.Location = new System.Drawing.Point(449, 291);
            this.btnConvertToClient.Name = "btnConvertToClient";
            this.btnConvertToClient.Size = new System.Drawing.Size(114, 26);
            this.btnConvertToClient.TabIndex = 10;
            this.btnConvertToClient.Text = "Convert To Client";
            this.toolTipProspeectClient.SetToolTip(this.btnConvertToClient, "Convert prospect customer to client");
            this.btnConvertToClient.UseVisualStyleBackColor = true;
            this.btnConvertToClient.Click += new System.EventHandler(this.btnConvertToClient_Click);
            // 
            // tbProspCustomer
            // 
            this.tbProspCustomer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbProspCustomer.Controls.Add(this.tbpageProspectCustomer);
            this.tbProspCustomer.Controls.Add(this.tpageEmailSendHistory);
            this.tbProspCustomer.ImageList = this.imageList30x30;
            this.tbProspCustomer.Location = new System.Drawing.Point(8, 11);
            this.tbProspCustomer.Name = "tbProspCustomer";
            this.tbProspCustomer.SelectedIndex = 0;
            this.tbProspCustomer.Size = new System.Drawing.Size(724, 274);
            this.tbProspCustomer.TabIndex = 9;
            // 
            // tbpageProspectCustomer
            // 
            this.tbpageProspectCustomer.Controls.Add(this.grpProspectCustomer);
            this.tbpageProspectCustomer.ImageKey = "icons8-reception-30.png";
            this.tbpageProspectCustomer.Location = new System.Drawing.Point(4, 37);
            this.tbpageProspectCustomer.Name = "tbpageProspectCustomer";
            this.tbpageProspectCustomer.Padding = new System.Windows.Forms.Padding(3);
            this.tbpageProspectCustomer.Size = new System.Drawing.Size(716, 233);
            this.tbpageProspectCustomer.TabIndex = 0;
            this.tbpageProspectCustomer.Text = "Prospect Customer";
            this.tbpageProspectCustomer.ToolTipText = "Prospect Customer";
            this.tbpageProspectCustomer.UseVisualStyleBackColor = true;
            // 
            // tpageEmailSendHistory
            // 
            this.tpageEmailSendHistory.ImageKey = "icons8-group-message-30.png";
            this.tpageEmailSendHistory.Location = new System.Drawing.Point(4, 37);
            this.tpageEmailSendHistory.Name = "tpageEmailSendHistory";
            this.tpageEmailSendHistory.Padding = new System.Windows.Forms.Padding(3);
            this.tpageEmailSendHistory.Size = new System.Drawing.Size(716, 233);
            this.tpageEmailSendHistory.TabIndex = 1;
            this.tpageEmailSendHistory.Text = "Email Send History";
            this.tpageEmailSendHistory.ToolTipText = "List of emails send to customer.";
            this.tpageEmailSendHistory.UseVisualStyleBackColor = true;
            // 
            // imageList30x30
            // 
            this.imageList30x30.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList30x30.ImageStream")));
            this.imageList30x30.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList30x30.Images.SetKeyName(0, "icons8-reception-30.png");
            this.imageList30x30.Images.SetKeyName(1, "icons8-group-message-30.png");
            // 
            // ProspectCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 606);
            this.Controls.Add(this.btnConvertToClient);
            this.Controls.Add(this.tbProspCustomer);
            this.Controls.Add(this.btnAddConversation);
            this.Controls.Add(this.grpConverstion);
            this.Controls.Add(this.btnShowConversation);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnHideConversation);
            this.Name = "ProspectCustomer";
            this.Text = "Prospect Customer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProspectCustomer_FormClosing);
            this.Load += new System.EventHandler(this.ProspectCustomer_Load);
            this.grpProspectCustomer.ResumeLayout(false);
            this.grpProspectCustomer.PerformLayout();
            this.pnlClient.ResumeLayout(false);
            this.pnlClient.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbClientAssignTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbClient.Properties)).EndInit();
            this.grpConverstion.ResumeLayout(false);
            this.grpActionControls.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridConversation)).EndInit();
            this.tbProspCustomer.ResumeLayout(false);
            this.tbpageProspectCustomer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpProspectCustomer;
        private System.Windows.Forms.DateTimePicker dtEventDate;
        private System.Windows.Forms.Label lblEventDate;
        private System.Windows.Forms.TextBox txtEvent;
        private System.Windows.Forms.Label lblEvent;
        private System.Windows.Forms.TextBox txtOccupation;
        private System.Windows.Forms.Label lblOccupation;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhoneNo;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label lblLastName;
        private System.Windows.Forms.Label lblPhoneNo;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnShowConversation;
        private System.Windows.Forms.GroupBox grpConverstion;
        private System.Windows.Forms.DataGridView dataGridConversation;
        private System.Windows.Forms.Button btnHideConversation;
        private System.Windows.Forms.CheckBox chkStopSendingEmail;
        private System.Windows.Forms.TextBox txtRefBy;
        private System.Windows.Forms.Label lblRefBy;
        private System.Windows.Forms.TextBox txtRemark;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkIsConvertedToCustomer;
        private System.Windows.Forms.Button btnAddConversation;
        private System.Windows.Forms.GroupBox grpActionControls;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEditConversation;
        private System.Windows.Forms.ImageList imgCollection;
        private System.Windows.Forms.ToolTip toolTipProspeectClient;
        private System.Windows.Forms.TabControl tbProspCustomer;
        private System.Windows.Forms.TabPage tbpageProspectCustomer;
        private System.Windows.Forms.TabPage tpageEmailSendHistory;
        private System.Windows.Forms.ImageList imageList30x30;
        private System.Windows.Forms.DateTimePicker dtIntroductionCompletdOn;
        private System.Windows.Forms.CheckBox chkIntroductionCompleted;
        private DevExpress.XtraEditors.ComboBoxEdit cmbClient;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel pnlClient;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.ComboBoxEdit cmbClientAssignTo;
        private System.Windows.Forms.Button btnConvertToClient;
    }
}