namespace FinancialPlannerClient.Clients
{
    partial class ClientWithPlanner
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientWithPlanner));
            this.grpClient = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.imgCollection = new System.Windows.Forms.ImageList(this.components);
            this.btnSave = new System.Windows.Forms.Button();
            this.grpMaritalStatus = new System.Windows.Forms.GroupBox();
            this.rdoMaritalStatusNo = new System.Windows.Forms.RadioButton();
            this.rdoMaritalStatusYes = new System.Windows.Forms.RadioButton();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtPan = new System.Windows.Forms.TextBox();
            this.dtMarriageAnniversary = new System.Windows.Forms.DateTimePicker();
            this.txtName = new System.Windows.Forms.TextBox();
            this.dtDOB = new System.Windows.Forms.DateTimePicker();
            this.cmbGender = new System.Windows.Forms.ComboBox();
            this.txtAadhar = new System.Windows.Forms.TextBox();
            this.txtPlaceOfBirth = new System.Windows.Forms.TextBox();
            this.txtFatherName = new System.Windows.Forms.TextBox();
            this.txtMotherName = new System.Windows.Forms.TextBox();
            this.txtOccupation = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.grpPlanner = new System.Windows.Forms.GroupBox();
            this.lblPlanEndDateValue = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblPlanStartDateVal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnViewEditPlan = new System.Windows.Forms.Button();
            this.btnCreateNewPlan = new System.Windows.Forms.Button();
            this.cmbPlan = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtPlanStartDate = new System.Windows.Forms.DateTimePicker();
            this.btnCancelPlan = new System.Windows.Forms.Button();
            this.btnSavePlan = new System.Windows.Forms.Button();
            this.grpClient.SuspendLayout();
            this.grpMaritalStatus.SuspendLayout();
            this.grpPlanner.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpClient
            // 
            this.grpClient.Controls.Add(this.btnCancel);
            this.grpClient.Controls.Add(this.btnSave);
            this.grpClient.Controls.Add(this.grpMaritalStatus);
            this.grpClient.Controls.Add(this.label4);
            this.grpClient.Controls.Add(this.label1);
            this.grpClient.Controls.Add(this.txtPan);
            this.grpClient.Controls.Add(this.dtMarriageAnniversary);
            this.grpClient.Controls.Add(this.txtName);
            this.grpClient.Controls.Add(this.dtDOB);
            this.grpClient.Controls.Add(this.cmbGender);
            this.grpClient.Controls.Add(this.txtAadhar);
            this.grpClient.Controls.Add(this.txtPlaceOfBirth);
            this.grpClient.Controls.Add(this.txtFatherName);
            this.grpClient.Controls.Add(this.txtMotherName);
            this.grpClient.Controls.Add(this.txtOccupation);
            this.grpClient.Controls.Add(this.label26);
            this.grpClient.Controls.Add(this.label20);
            this.grpClient.Controls.Add(this.label24);
            this.grpClient.Controls.Add(this.label23);
            this.grpClient.Controls.Add(this.label25);
            this.grpClient.Controls.Add(this.label21);
            this.grpClient.Controls.Add(this.label27);
            this.grpClient.Controls.Add(this.label28);
            this.grpClient.Controls.Add(this.label29);
            this.grpClient.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpClient.Location = new System.Drawing.Point(12, 12);
            this.grpClient.Name = "grpClient";
            this.grpClient.Size = new System.Drawing.Size(982, 255);
            this.grpClient.TabIndex = 0;
            this.grpClient.TabStop = false;
            this.grpClient.Text = "Client Info";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.ImageKey = "icons8-cancel-16.png";
            this.btnCancel.ImageList = this.imgCollection;
            this.btnCancel.Location = new System.Drawing.Point(861, 211);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 26);
            this.btnCancel.TabIndex = 55;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
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
            this.btnSave.Location = new System.Drawing.Point(769, 211);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 26);
            this.btnSave.TabIndex = 54;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpMaritalStatus
            // 
            this.grpMaritalStatus.Controls.Add(this.rdoMaritalStatusNo);
            this.grpMaritalStatus.Controls.Add(this.rdoMaritalStatusYes);
            this.grpMaritalStatus.Location = new System.Drawing.Point(206, 115);
            this.grpMaritalStatus.Name = "grpMaritalStatus";
            this.grpMaritalStatus.Size = new System.Drawing.Size(275, 37);
            this.grpMaritalStatus.TabIndex = 4;
            this.grpMaritalStatus.TabStop = false;
            // 
            // rdoMaritalStatusNo
            // 
            this.rdoMaritalStatusNo.AutoSize = true;
            this.rdoMaritalStatusNo.Checked = true;
            this.rdoMaritalStatusNo.Location = new System.Drawing.Point(80, 12);
            this.rdoMaritalStatusNo.Name = "rdoMaritalStatusNo";
            this.rdoMaritalStatusNo.Size = new System.Drawing.Size(41, 19);
            this.rdoMaritalStatusNo.TabIndex = 1;
            this.rdoMaritalStatusNo.TabStop = true;
            this.rdoMaritalStatusNo.Text = "No";
            this.rdoMaritalStatusNo.UseVisualStyleBackColor = true;
            this.rdoMaritalStatusNo.CheckedChanged += new System.EventHandler(this.rdoMaritalStatusNo_CheckedChanged);
            // 
            // rdoMaritalStatusYes
            // 
            this.rdoMaritalStatusYes.AutoSize = true;
            this.rdoMaritalStatusYes.Location = new System.Drawing.Point(6, 12);
            this.rdoMaritalStatusYes.Name = "rdoMaritalStatusYes";
            this.rdoMaritalStatusYes.Size = new System.Drawing.Size(45, 19);
            this.rdoMaritalStatusYes.TabIndex = 0;
            this.rdoMaritalStatusYes.Text = "Yes";
            this.rdoMaritalStatusYes.UseVisualStyleBackColor = true;
            this.rdoMaritalStatusYes.CheckedChanged += new System.EventHandler(this.rdoMaritalStatusYes_CheckedChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(59, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(140, 20);
            this.label4.TabIndex = 53;
            this.label4.Text = "Marital Staus:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(539, 171);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 20);
            this.label1.TabIndex = 52;
            this.label1.Text = "Occupation:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPan
            // 
            this.txtPan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPan.Location = new System.Drawing.Point(672, 31);
            this.txtPan.Name = "txtPan";
            this.txtPan.Size = new System.Drawing.Size(275, 21);
            this.txtPan.TabIndex = 5;
            // 
            // dtMarriageAnniversary
            // 
            this.dtMarriageAnniversary.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtMarriageAnniversary.Checked = false;
            this.dtMarriageAnniversary.Location = new System.Drawing.Point(206, 161);
            this.dtMarriageAnniversary.Name = "dtMarriageAnniversary";
            this.dtMarriageAnniversary.ShowCheckBox = true;
            this.dtMarriageAnniversary.Size = new System.Drawing.Size(275, 21);
            this.dtMarriageAnniversary.TabIndex = 4;
            // 
            // txtName
            // 
            this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtName.Location = new System.Drawing.Point(206, 31);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(275, 21);
            this.txtName.TabIndex = 1;
            // 
            // dtDOB
            // 
            this.dtDOB.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtDOB.Location = new System.Drawing.Point(206, 59);
            this.dtDOB.Name = "dtDOB";
            this.dtDOB.Size = new System.Drawing.Size(275, 21);
            this.dtDOB.TabIndex = 2;
            // 
            // cmbGender
            // 
            this.cmbGender.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbGender.FormattingEnabled = true;
            this.cmbGender.Items.AddRange(new object[] {
            "Male",
            "Female"});
            this.cmbGender.Location = new System.Drawing.Point(206, 88);
            this.cmbGender.Name = "cmbGender";
            this.cmbGender.Size = new System.Drawing.Size(275, 23);
            this.cmbGender.TabIndex = 3;
            // 
            // txtAadhar
            // 
            this.txtAadhar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAadhar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAadhar.Location = new System.Drawing.Point(672, 58);
            this.txtAadhar.Name = "txtAadhar";
            this.txtAadhar.Size = new System.Drawing.Size(275, 21);
            this.txtAadhar.TabIndex = 6;
            // 
            // txtPlaceOfBirth
            // 
            this.txtPlaceOfBirth.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPlaceOfBirth.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPlaceOfBirth.Location = new System.Drawing.Point(672, 85);
            this.txtPlaceOfBirth.Name = "txtPlaceOfBirth";
            this.txtPlaceOfBirth.Size = new System.Drawing.Size(275, 21);
            this.txtPlaceOfBirth.TabIndex = 7;
            // 
            // txtFatherName
            // 
            this.txtFatherName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFatherName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFatherName.Location = new System.Drawing.Point(672, 114);
            this.txtFatherName.Name = "txtFatherName";
            this.txtFatherName.Size = new System.Drawing.Size(275, 21);
            this.txtFatherName.TabIndex = 8;
            // 
            // txtMotherName
            // 
            this.txtMotherName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMotherName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotherName.Location = new System.Drawing.Point(672, 143);
            this.txtMotherName.Name = "txtMotherName";
            this.txtMotherName.Size = new System.Drawing.Size(275, 21);
            this.txtMotherName.TabIndex = 9;
            // 
            // txtOccupation
            // 
            this.txtOccupation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOccupation.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOccupation.Location = new System.Drawing.Point(672, 170);
            this.txtOccupation.Name = "txtOccupation";
            this.txtOccupation.Size = new System.Drawing.Size(275, 21);
            this.txtOccupation.TabIndex = 10;
            // 
            // label26
            // 
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.Location = new System.Drawing.Point(539, 59);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(116, 20);
            this.label26.TabIndex = 38;
            this.label26.Text = "Aadhar Card No:";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(59, 161);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(140, 20);
            this.label20.TabIndex = 36;
            this.label20.Text = "Marriage Anniversary:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(59, 59);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(105, 20);
            this.label24.TabIndex = 34;
            this.label24.Text = "Date of Birth:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(59, 31);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(105, 20);
            this.label23.TabIndex = 33;
            this.label23.Text = "Name:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(59, 89);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(105, 20);
            this.label25.TabIndex = 35;
            this.label25.Text = "Gender:";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.Location = new System.Drawing.Point(539, 32);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(116, 20);
            this.label21.TabIndex = 37;
            this.label21.Text = "Pancard No:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(539, 86);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(116, 20);
            this.label27.TabIndex = 39;
            this.label27.Text = "Place of Birth:";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.Location = new System.Drawing.Point(539, 115);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(116, 20);
            this.label28.TabIndex = 40;
            this.label28.Text = "Father\'s Name:";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.Location = new System.Drawing.Point(539, 144);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(116, 20);
            this.label29.TabIndex = 41;
            this.label29.Text = "Mother\'s Name:";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpPlanner
            // 
            this.grpPlanner.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.grpPlanner.Controls.Add(this.lblPlanEndDateValue);
            this.grpPlanner.Controls.Add(this.label5);
            this.grpPlanner.Controls.Add(this.lblPlanStartDateVal);
            this.grpPlanner.Controls.Add(this.label3);
            this.grpPlanner.Controls.Add(this.btnViewEditPlan);
            this.grpPlanner.Controls.Add(this.btnCreateNewPlan);
            this.grpPlanner.Controls.Add(this.cmbPlan);
            this.grpPlanner.Controls.Add(this.label2);
            this.grpPlanner.Controls.Add(this.dtPlanStartDate);
            this.grpPlanner.Controls.Add(this.btnCancelPlan);
            this.grpPlanner.Controls.Add(this.btnSavePlan);
            this.grpPlanner.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPlanner.Location = new System.Drawing.Point(330, 273);
            this.grpPlanner.Name = "grpPlanner";
            this.grpPlanner.Size = new System.Drawing.Size(417, 186);
            this.grpPlanner.TabIndex = 1;
            this.grpPlanner.TabStop = false;
            this.grpPlanner.Text = "Plan Detail";
            // 
            // lblPlanEndDateValue
            // 
            this.lblPlanEndDateValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanEndDateValue.Location = new System.Drawing.Point(135, 113);
            this.lblPlanEndDateValue.Name = "lblPlanEndDateValue";
            this.lblPlanEndDateValue.Size = new System.Drawing.Size(265, 20);
            this.lblPlanEndDateValue.TabIndex = 60;
            this.lblPlanEndDateValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(24, 113);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 20);
            this.label5.TabIndex = 59;
            this.label5.Text = "Plan End Date:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblPlanStartDateVal
            // 
            this.lblPlanStartDateVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanStartDateVal.Location = new System.Drawing.Point(135, 74);
            this.lblPlanStartDateVal.Name = "lblPlanStartDateVal";
            this.lblPlanStartDateVal.Size = new System.Drawing.Size(265, 20);
            this.lblPlanStartDateVal.TabIndex = 58;
            this.lblPlanStartDateVal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblPlanStartDateVal.TextChanged += new System.EventHandler(this.lblPlanStartDateVal_TextChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(24, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 20);
            this.label3.TabIndex = 57;
            this.label3.Text = "Plan Start Date:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnViewEditPlan
            // 
            this.btnViewEditPlan.Location = new System.Drawing.Point(277, 152);
            this.btnViewEditPlan.Name = "btnViewEditPlan";
            this.btnViewEditPlan.Size = new System.Drawing.Size(123, 23);
            this.btnViewEditPlan.TabIndex = 56;
            this.btnViewEditPlan.Text = "View / Edit Plan";
            this.btnViewEditPlan.UseVisualStyleBackColor = true;
            this.btnViewEditPlan.Click += new System.EventHandler(this.btnviewEditPlan_Click);
            // 
            // btnCreateNewPlan
            // 
            this.btnCreateNewPlan.Location = new System.Drawing.Point(147, 152);
            this.btnCreateNewPlan.Name = "btnCreateNewPlan";
            this.btnCreateNewPlan.Size = new System.Drawing.Size(124, 23);
            this.btnCreateNewPlan.TabIndex = 55;
            this.btnCreateNewPlan.Text = "Create New Plan";
            this.btnCreateNewPlan.UseVisualStyleBackColor = true;
            this.btnCreateNewPlan.Click += new System.EventHandler(this.btnCreateNewPlan_Click);
            // 
            // cmbPlan
            // 
            this.cmbPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlan.FormattingEnabled = true;
            this.cmbPlan.Location = new System.Drawing.Point(138, 29);
            this.cmbPlan.Name = "cmbPlan";
            this.cmbPlan.Size = new System.Drawing.Size(262, 23);
            this.cmbPlan.TabIndex = 54;
            this.cmbPlan.SelectedIndexChanged += new System.EventHandler(this.cmbPlan_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(24, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 53;
            this.label2.Text = "Select Plan:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dtPlanStartDate
            // 
            this.dtPlanStartDate.Location = new System.Drawing.Point(138, 74);
            this.dtPlanStartDate.Name = "dtPlanStartDate";
            this.dtPlanStartDate.Size = new System.Drawing.Size(262, 21);
            this.dtPlanStartDate.TabIndex = 61;
            this.dtPlanStartDate.Visible = false;
            this.dtPlanStartDate.ValueChanged += new System.EventHandler(this.dtPlanStartDate_ValueChanged);
            // 
            // btnCancelPlan
            // 
            this.btnCancelPlan.Location = new System.Drawing.Point(277, 152);
            this.btnCancelPlan.Name = "btnCancelPlan";
            this.btnCancelPlan.Size = new System.Drawing.Size(123, 23);
            this.btnCancelPlan.TabIndex = 63;
            this.btnCancelPlan.Text = "Cancel";
            this.btnCancelPlan.UseVisualStyleBackColor = true;
            this.btnCancelPlan.Click += new System.EventHandler(this.btnCancelPlan_Click);
            // 
            // btnSavePlan
            // 
            this.btnSavePlan.Location = new System.Drawing.Point(147, 151);
            this.btnSavePlan.Name = "btnSavePlan";
            this.btnSavePlan.Size = new System.Drawing.Size(124, 23);
            this.btnSavePlan.TabIndex = 62;
            this.btnSavePlan.Text = "Save Plan";
            this.btnSavePlan.UseVisualStyleBackColor = true;
            this.btnSavePlan.Click += new System.EventHandler(this.btnSavePlan_Click);
            // 
            // ClientWithPlanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 602);
            this.Controls.Add(this.grpPlanner);
            this.Controls.Add(this.grpClient);
            this.Name = "ClientWithPlanner";
            this.Text = "Client";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ClientWithPlanner_Load);
            this.grpClient.ResumeLayout(false);
            this.grpClient.PerformLayout();
            this.grpMaritalStatus.ResumeLayout(false);
            this.grpMaritalStatus.PerformLayout();
            this.grpPlanner.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpClient;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.TextBox txtPan;
        private System.Windows.Forms.DateTimePicker dtMarriageAnniversary;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.DateTimePicker dtDOB;
        private System.Windows.Forms.ComboBox cmbGender;
        private System.Windows.Forms.TextBox txtAadhar;
        private System.Windows.Forms.TextBox txtPlaceOfBirth;
        private System.Windows.Forms.TextBox txtFatherName;
        private System.Windows.Forms.TextBox txtMotherName;
        private System.Windows.Forms.TextBox txtOccupation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpPlanner;
        private System.Windows.Forms.DateTimePicker dtPlanStartDate;
        private System.Windows.Forms.Label lblPlanEndDateValue;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblPlanStartDateVal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnViewEditPlan;
        private System.Windows.Forms.Button btnCreateNewPlan;
        private System.Windows.Forms.ComboBox cmbPlan;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSavePlan;
        private System.Windows.Forms.Button btnCancelPlan;
        private System.Windows.Forms.GroupBox grpMaritalStatus;
        private System.Windows.Forms.RadioButton rdoMaritalStatusYes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rdoMaritalStatusNo;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.ImageList imgCollection;
    }
}