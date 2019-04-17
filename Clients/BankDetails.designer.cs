﻿namespace FinancialPlannerClient.Clients
{
    partial class BankDetails
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BankDetails));
            DevExpress.Utils.SuperToolTip superToolTip16 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem16 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem16 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip17 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem17 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem17 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip18 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem18 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem18 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip19 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem19 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem19 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip20 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem20 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem20 = new DevExpress.Utils.ToolTipItem();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.gridBankAccount = new DevExpress.XtraGrid.GridControl();
            this.gridViewBankAccount = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grpBankAccountDetails = new DevExpress.XtraEditors.GroupControl();
            this.cmbAccountHolder = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnCancelBankAccount = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveBankAccount = new DevExpress.XtraEditors.SimpleButton();
            this.label143 = new System.Windows.Forms.Label();
            this.txtMinReqBalance = new System.Windows.Forms.TextBox();
            this.label139 = new System.Windows.Forms.Label();
            this.grpJoinAccountInfo = new System.Windows.Forms.GroupBox();
            this.txtJoinHolderName = new System.Windows.Forms.TextBox();
            this.label138 = new System.Windows.Forms.Label();
            this.rdoNoJoinAC = new System.Windows.Forms.RadioButton();
            this.rdoYesJoinAC = new System.Windows.Forms.RadioButton();
            this.txtBranchContactNo = new System.Windows.Forms.TextBox();
            this.cmbAccountType = new System.Windows.Forms.ComboBox();
            this.label136 = new System.Windows.Forms.Label();
            this.label137 = new System.Windows.Forms.Label();
            this.txtBranchAddress = new System.Windows.Forms.TextBox();
            this.txtAccountNo = new System.Windows.Forms.TextBox();
            this.label140 = new System.Windows.Forms.Label();
            this.label141 = new System.Windows.Forms.Label();
            this.txtBankName = new System.Windows.Forms.TextBox();
            this.label142 = new System.Windows.Forms.Label();
            this.lblContactTitle = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridBankAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBankAccount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpBankAccountDetails)).BeginInit();
            this.grpBankAccountDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAccountHolder.Properties)).BeginInit();
            this.grpJoinAccountInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.btnDelete);
            this.groupControl1.Controls.Add(this.btnEdit);
            this.groupControl1.Controls.Add(this.btnAdd);
            this.groupControl1.Controls.Add(this.gridBankAccount);
            this.groupControl1.Location = new System.Drawing.Point(10, 38);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(995, 206);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Bank Accounts";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(965, 175);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(25, 23);
            toolTipTitleItem16.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            toolTipTitleItem16.Appearance.Options.UseImage = true;
            toolTipTitleItem16.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem16.Image")));
            toolTipTitleItem16.Text = "Delete Client";
            toolTipItem16.LeftIndent = 6;
            toolTipItem16.Text = "To delete selected client record click here.";
            superToolTip16.Items.Add(toolTipTitleItem16);
            superToolTip16.Items.Add(toolTipItem16);
            this.btnDelete.SuperTip = superToolTip16;
            this.btnDelete.TabIndex = 6;
            this.btnDelete.ToolTip = "Delete Client";
            this.btnDelete.Click += new System.EventHandler(this.btnDeleteBankAcc_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(934, 175);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(25, 23);
            toolTipTitleItem17.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            toolTipTitleItem17.Appearance.Options.UseImage = true;
            toolTipTitleItem17.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem17.Image")));
            toolTipTitleItem17.Text = "Edit Customer";
            toolTipItem17.LeftIndent = 6;
            toolTipItem17.Text = "To modify selected client information click here.";
            superToolTip17.Items.Add(toolTipTitleItem17);
            superToolTip17.Items.Add(toolTipItem17);
            this.btnEdit.SuperTip = superToolTip17;
            this.btnEdit.TabIndex = 5;
            this.btnEdit.ToolTip = "Edit Client";
            this.btnEdit.Click += new System.EventHandler(this.btnEditBankAcc_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(903, 175);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 23);
            toolTipTitleItem18.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            toolTipTitleItem18.Appearance.Options.UseImage = true;
            toolTipTitleItem18.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem18.Image")));
            toolTipTitleItem18.Text = "New Client";
            toolTipItem18.LeftIndent = 6;
            toolTipItem18.Text = "To add new client inforamtion click here.";
            superToolTip18.Items.Add(toolTipTitleItem18);
            superToolTip18.Items.Add(toolTipItem18);
            this.btnAdd.SuperTip = superToolTip18;
            this.btnAdd.TabIndex = 4;
            this.btnAdd.ToolTip = "Add new client";
            this.btnAdd.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Application;
            this.btnAdd.ToolTipTitle = "New Client";
            this.btnAdd.Click += new System.EventHandler(this.btnAddBankAcc_Click);
            // 
            // gridBankAccount
            // 
            this.gridBankAccount.Location = new System.Drawing.Point(5, 23);
            this.gridBankAccount.MainView = this.gridViewBankAccount;
            this.gridBankAccount.Name = "gridBankAccount";
            this.gridBankAccount.Size = new System.Drawing.Size(985, 146);
            this.gridBankAccount.TabIndex = 0;
            this.gridBankAccount.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewBankAccount});
            // 
            // gridViewBankAccount
            // 
            this.gridViewBankAccount.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridViewBankAccount.GridControl = this.gridBankAccount;
            this.gridViewBankAccount.Name = "gridViewBankAccount";
            this.gridViewBankAccount.OptionsView.ShowGroupPanel = false;
            this.gridViewBankAccount.RowClick += new DevExpress.XtraGrid.Views.Grid.RowClickEventHandler(this.gridViewBankAccount_RowClick);
            this.gridViewBankAccount.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridViewBankAccount_SelectionChanged);
            // 
            // grpBankAccountDetails
            // 
            this.grpBankAccountDetails.Controls.Add(this.cmbAccountHolder);
            this.grpBankAccountDetails.Controls.Add(this.btnCancelBankAccount);
            this.grpBankAccountDetails.Controls.Add(this.btnSaveBankAccount);
            this.grpBankAccountDetails.Controls.Add(this.label143);
            this.grpBankAccountDetails.Controls.Add(this.txtMinReqBalance);
            this.grpBankAccountDetails.Controls.Add(this.label139);
            this.grpBankAccountDetails.Controls.Add(this.grpJoinAccountInfo);
            this.grpBankAccountDetails.Controls.Add(this.txtBranchContactNo);
            this.grpBankAccountDetails.Controls.Add(this.cmbAccountType);
            this.grpBankAccountDetails.Controls.Add(this.label136);
            this.grpBankAccountDetails.Controls.Add(this.label137);
            this.grpBankAccountDetails.Controls.Add(this.txtBranchAddress);
            this.grpBankAccountDetails.Controls.Add(this.txtAccountNo);
            this.grpBankAccountDetails.Controls.Add(this.label140);
            this.grpBankAccountDetails.Controls.Add(this.label141);
            this.grpBankAccountDetails.Controls.Add(this.txtBankName);
            this.grpBankAccountDetails.Controls.Add(this.label142);
            this.grpBankAccountDetails.Enabled = false;
            this.grpBankAccountDetails.Location = new System.Drawing.Point(11, 251);
            this.grpBankAccountDetails.Name = "grpBankAccountDetails";
            this.grpBankAccountDetails.Size = new System.Drawing.Size(994, 265);
            this.grpBankAccountDetails.TabIndex = 1;
            this.grpBankAccountDetails.Text = "Bank Account Details";
            // 
            // cmbAccountHolder
            // 
            this.cmbAccountHolder.Location = new System.Drawing.Point(153, 39);
            this.cmbAccountHolder.Name = "cmbAccountHolder";
            this.cmbAccountHolder.Properties.Appearance.Font = new System.Drawing.Font("Microsoft Tai Le", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAccountHolder.Properties.Appearance.Options.UseFont = true;
            this.cmbAccountHolder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbAccountHolder.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbAccountHolder.Size = new System.Drawing.Size(351, 22);
            this.cmbAccountHolder.TabIndex = 0;
            this.cmbAccountHolder.SelectedValueChanged += new System.EventHandler(this.cmbAccountHolder_SelectedValueChanged);
            // 
            // btnCancelBankAccount
            // 
            this.btnCancelBankAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelBankAccount.Image = ((System.Drawing.Image)(resources.GetObject("btnCancelBankAccount.Image")));
            this.btnCancelBankAccount.Location = new System.Drawing.Point(779, 181);
            this.btnCancelBankAccount.Name = "btnCancelBankAccount";
            this.btnCancelBankAccount.Size = new System.Drawing.Size(62, 23);
            toolTipTitleItem19.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            toolTipTitleItem19.Appearance.Options.UseImage = true;
            toolTipTitleItem19.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem19.Image")));
            toolTipTitleItem19.Text = "Cancel";
            toolTipItem19.LeftIndent = 6;
            toolTipItem19.Text = "To close client bank information without saving any information click here.";
            superToolTip19.Items.Add(toolTipTitleItem19);
            superToolTip19.Items.Add(toolTipItem19);
            this.btnCancelBankAccount.SuperTip = superToolTip19;
            this.btnCancelBankAccount.TabIndex = 41;
            this.btnCancelBankAccount.Text = "Close";
            this.btnCancelBankAccount.Click += new System.EventHandler(this.btnCancelBankAccount_Click);
            // 
            // btnSaveBankAccount
            // 
            this.btnSaveBankAccount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSaveBankAccount.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveBankAccount.Image")));
            this.btnSaveBankAccount.Location = new System.Drawing.Point(716, 181);
            this.btnSaveBankAccount.Name = "btnSaveBankAccount";
            this.btnSaveBankAccount.Size = new System.Drawing.Size(57, 23);
            toolTipTitleItem20.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image4")));
            toolTipTitleItem20.Appearance.Options.UseImage = true;
            toolTipTitleItem20.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem20.Image")));
            toolTipTitleItem20.Text = "Save";
            toolTipItem20.LeftIndent = 6;
            toolTipItem20.Text = "To save client bank infroamtion click here.";
            superToolTip20.Items.Add(toolTipTitleItem20);
            superToolTip20.Items.Add(toolTipItem20);
            this.btnSaveBankAccount.SuperTip = superToolTip20;
            this.btnSaveBankAccount.TabIndex = 40;
            this.btnSaveBankAccount.Text = "Save";
            this.btnSaveBankAccount.Click += new System.EventHandler(this.btnSaveBankAccount_Click);
            // 
            // label143
            // 
            this.label143.AutoSize = true;
            this.label143.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label143.Location = new System.Drawing.Point(22, 40);
            this.label143.Name = "label143";
            this.label143.Size = new System.Drawing.Size(106, 16);
            this.label143.TabIndex = 39;
            this.label143.Text = "Account Holder :";
            // 
            // txtMinReqBalance
            // 
            this.txtMinReqBalance.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMinReqBalance.Location = new System.Drawing.Point(668, 153);
            this.txtMinReqBalance.MaxLength = 6;
            this.txtMinReqBalance.Name = "txtMinReqBalance";
            this.txtMinReqBalance.Size = new System.Drawing.Size(173, 22);
            this.txtMinReqBalance.TabIndex = 33;
            this.txtMinReqBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtMinReqBalance.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtMinReqBalance_KeyPress);
            this.txtMinReqBalance.Validating += new System.ComponentModel.CancelEventHandler(this.txtMinReqBalance_Validating);
            // 
            // label139
            // 
            this.label139.AutoSize = true;
            this.label139.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label139.Location = new System.Drawing.Point(523, 156);
            this.label139.Name = "label139";
            this.label139.Size = new System.Drawing.Size(139, 16);
            this.label139.TabIndex = 38;
            this.label139.Text = "Min. Require Balance:";
            // 
            // grpJoinAccountInfo
            // 
            this.grpJoinAccountInfo.Controls.Add(this.txtJoinHolderName);
            this.grpJoinAccountInfo.Controls.Add(this.label138);
            this.grpJoinAccountInfo.Controls.Add(this.rdoNoJoinAC);
            this.grpJoinAccountInfo.Controls.Add(this.rdoYesJoinAC);
            this.grpJoinAccountInfo.Location = new System.Drawing.Point(522, 40);
            this.grpJoinAccountInfo.Name = "grpJoinAccountInfo";
            this.grpJoinAccountInfo.Size = new System.Drawing.Size(319, 101);
            this.grpJoinAccountInfo.TabIndex = 32;
            this.grpJoinAccountInfo.TabStop = false;
            this.grpJoinAccountInfo.Text = "Join Account";
            // 
            // txtJoinHolderName
            // 
            this.txtJoinHolderName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtJoinHolderName.Location = new System.Drawing.Point(17, 67);
            this.txtJoinHolderName.MaxLength = 100;
            this.txtJoinHolderName.Name = "txtJoinHolderName";
            this.txtJoinHolderName.Size = new System.Drawing.Size(271, 22);
            this.txtJoinHolderName.TabIndex = 2;
            // 
            // label138
            // 
            this.label138.AutoSize = true;
            this.label138.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label138.Location = new System.Drawing.Point(14, 48);
            this.label138.Name = "label138";
            this.label138.Size = new System.Drawing.Size(117, 16);
            this.label138.TabIndex = 2;
            this.label138.Text = "Join Holder Name";
            // 
            // rdoNoJoinAC
            // 
            this.rdoNoJoinAC.AutoSize = true;
            this.rdoNoJoinAC.Checked = true;
            this.rdoNoJoinAC.Location = new System.Drawing.Point(119, 21);
            this.rdoNoJoinAC.Name = "rdoNoJoinAC";
            this.rdoNoJoinAC.Size = new System.Drawing.Size(38, 17);
            this.rdoNoJoinAC.TabIndex = 1;
            this.rdoNoJoinAC.TabStop = true;
            this.rdoNoJoinAC.Text = "No";
            this.rdoNoJoinAC.UseVisualStyleBackColor = true;
            // 
            // rdoYesJoinAC
            // 
            this.rdoYesJoinAC.AutoSize = true;
            this.rdoYesJoinAC.Location = new System.Drawing.Point(17, 21);
            this.rdoYesJoinAC.Name = "rdoYesJoinAC";
            this.rdoYesJoinAC.Size = new System.Drawing.Size(42, 17);
            this.rdoYesJoinAC.TabIndex = 0;
            this.rdoYesJoinAC.Text = "Yes";
            this.rdoYesJoinAC.UseVisualStyleBackColor = true;
            // 
            // txtBranchContactNo
            // 
            this.txtBranchContactNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranchContactNo.Location = new System.Drawing.Point(153, 180);
            this.txtBranchContactNo.MaxLength = 15;
            this.txtBranchContactNo.Name = "txtBranchContactNo";
            this.txtBranchContactNo.Size = new System.Drawing.Size(351, 22);
            this.txtBranchContactNo.TabIndex = 31;
            // 
            // cmbAccountType
            // 
            this.cmbAccountType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAccountType.FormattingEnabled = true;
            this.cmbAccountType.Items.AddRange(new object[] {
            "SA",
            "CA"});
            this.cmbAccountType.Location = new System.Drawing.Point(153, 125);
            this.cmbAccountType.Name = "cmbAccountType";
            this.cmbAccountType.Size = new System.Drawing.Size(144, 21);
            this.cmbAccountType.TabIndex = 28;
            // 
            // label136
            // 
            this.label136.AutoSize = true;
            this.label136.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label136.Location = new System.Drawing.Point(22, 183);
            this.label136.Name = "label136";
            this.label136.Size = new System.Drawing.Size(122, 16);
            this.label136.TabIndex = 37;
            this.label136.Text = "Branch Contact No:";
            // 
            // label137
            // 
            this.label137.AutoSize = true;
            this.label137.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label137.Location = new System.Drawing.Point(22, 154);
            this.label137.Name = "label137";
            this.label137.Size = new System.Drawing.Size(107, 16);
            this.label137.TabIndex = 36;
            this.label137.Text = "Branch Address:";
            // 
            // txtBranchAddress
            // 
            this.txtBranchAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBranchAddress.Location = new System.Drawing.Point(153, 152);
            this.txtBranchAddress.MaxLength = 500;
            this.txtBranchAddress.Name = "txtBranchAddress";
            this.txtBranchAddress.Size = new System.Drawing.Size(351, 22);
            this.txtBranchAddress.TabIndex = 29;
            // 
            // txtAccountNo
            // 
            this.txtAccountNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAccountNo.Location = new System.Drawing.Point(153, 97);
            this.txtAccountNo.MaxLength = 15;
            this.txtAccountNo.Name = "txtAccountNo";
            this.txtAccountNo.Size = new System.Drawing.Size(351, 22);
            this.txtAccountNo.TabIndex = 26;
            // 
            // label140
            // 
            this.label140.AutoSize = true;
            this.label140.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label140.Location = new System.Drawing.Point(22, 125);
            this.label140.Name = "label140";
            this.label140.Size = new System.Drawing.Size(94, 16);
            this.label140.TabIndex = 30;
            this.label140.Text = "Account Type:";
            // 
            // label141
            // 
            this.label141.AutoSize = true;
            this.label141.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label141.Location = new System.Drawing.Point(22, 94);
            this.label141.Name = "label141";
            this.label141.Size = new System.Drawing.Size(80, 16);
            this.label141.TabIndex = 27;
            this.label141.Text = "Account No:";
            // 
            // txtBankName
            // 
            this.txtBankName.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBankName.Location = new System.Drawing.Point(153, 67);
            this.txtBankName.MaxLength = 50;
            this.txtBankName.Name = "txtBankName";
            this.txtBankName.Size = new System.Drawing.Size(351, 24);
            this.txtBankName.TabIndex = 25;
            // 
            // label142
            // 
            this.label142.AutoSize = true;
            this.label142.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label142.Location = new System.Drawing.Point(22, 67);
            this.label142.Name = "label142";
            this.label142.Size = new System.Drawing.Size(82, 16);
            this.label142.TabIndex = 24;
            this.label142.Text = "Bank Name:";
            // 
            // lblContactTitle
            // 
            this.lblContactTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblContactTitle.Appearance.Options.UseFont = true;
            this.lblContactTitle.Appearance.Options.UseForeColor = true;
            this.lblContactTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblContactTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblContactTitle.Location = new System.Drawing.Point(0, 0);
            this.lblContactTitle.Name = "lblContactTitle";
            this.lblContactTitle.Size = new System.Drawing.Size(1019, 21);
            this.lblContactTitle.TabIndex = 6;
            this.lblContactTitle.Text = "Bank Details";
            // 
            // BankDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1019, 528);
            this.Controls.Add(this.lblContactTitle);
            this.Controls.Add(this.grpBankAccountDetails);
            this.Controls.Add(this.groupControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "BankDetails";
            this.Text = "Bank Details";
            this.Load += new System.EventHandler(this.BankDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridBankAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBankAccount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpBankAccountDetails)).EndInit();
            this.grpBankAccountDetails.ResumeLayout(false);
            this.grpBankAccountDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbAccountHolder.Properties)).EndInit();
            this.grpJoinAccountInfo.ResumeLayout(false);
            this.grpJoinAccountInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridBankAccount;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewBankAccount;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.GroupControl grpBankAccountDetails;
        private System.Windows.Forms.Label label143;
        private System.Windows.Forms.TextBox txtMinReqBalance;
        private System.Windows.Forms.Label label139;
        private System.Windows.Forms.GroupBox grpJoinAccountInfo;
        private System.Windows.Forms.TextBox txtJoinHolderName;
        private System.Windows.Forms.Label label138;
        private System.Windows.Forms.RadioButton rdoNoJoinAC;
        private System.Windows.Forms.RadioButton rdoYesJoinAC;
        private System.Windows.Forms.TextBox txtBranchContactNo;
        private System.Windows.Forms.ComboBox cmbAccountType;
        private System.Windows.Forms.Label label136;
        private System.Windows.Forms.Label label137;
        private System.Windows.Forms.TextBox txtBranchAddress;
        private System.Windows.Forms.TextBox txtAccountNo;
        private System.Windows.Forms.Label label140;
        private System.Windows.Forms.Label label141;
        private System.Windows.Forms.TextBox txtBankName;
        private System.Windows.Forms.Label label142;
        private DevExpress.XtraEditors.SimpleButton btnCancelBankAccount;
        private DevExpress.XtraEditors.SimpleButton btnSaveBankAccount;
        private DevExpress.XtraEditors.ComboBoxEdit cmbAccountHolder;
        private DevExpress.XtraEditors.LabelControl lblContactTitle;
    }
}
