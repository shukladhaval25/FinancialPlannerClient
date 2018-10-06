namespace FinancialPlannerClient.CurrentStatus
{
    partial class MFTransactionsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MFTransactionsForm));
            this.label1 = new System.Windows.Forms.Label();
            this.lblMFNameValue = new System.Windows.Forms.Label();
            this.dtGridMFTrans = new System.Windows.Forms.DataGridView();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnDeleteMF = new System.Windows.Forms.Button();
            this.imgCollection = new System.Windows.Forms.ImageList(this.components);
            this.btnAddMF = new System.Windows.Forms.Button();
            this.btnEditMF = new System.Windows.Forms.Button();
            this.grpMFTransaction = new System.Windows.Forms.GroupBox();
            this.btnCancelMFTrans = new System.Windows.Forms.Button();
            this.btnSaveMFTrans = new System.Windows.Forms.Button();
            this.txtCurrentValue = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtUnits = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtNav = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtTransDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.cmbTransType = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.lblSchemenameVal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblFolioNoVal = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridMFTrans)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.grpMFTransaction.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Green;
            this.label1.Location = new System.Drawing.Point(13, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(152, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Transaction Details for";
            // 
            // lblMFNameValue
            // 
            this.lblMFNameValue.AutoSize = true;
            this.lblMFNameValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMFNameValue.ForeColor = System.Drawing.Color.Purple;
            this.lblMFNameValue.Location = new System.Drawing.Point(171, 16);
            this.lblMFNameValue.Name = "lblMFNameValue";
            this.lblMFNameValue.Size = new System.Drawing.Size(0, 15);
            this.lblMFNameValue.TabIndex = 1;
            // 
            // dtGridMFTrans
            // 
            this.dtGridMFTrans.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridMFTrans.Location = new System.Drawing.Point(12, 48);
            this.dtGridMFTrans.Name = "dtGridMFTrans";
            this.dtGridMFTrans.Size = new System.Drawing.Size(778, 315);
            this.dtGridMFTrans.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.btnDeleteMF);
            this.groupBox4.Controls.Add(this.btnAddMF);
            this.groupBox4.Controls.Add(this.btnEditMF);
            this.groupBox4.Location = new System.Drawing.Point(679, 369);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(111, 38);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            // 
            // btnDeleteMF
            // 
            this.btnDeleteMF.ImageIndex = 1;
            this.btnDeleteMF.ImageList = this.imgCollection;
            this.btnDeleteMF.Location = new System.Drawing.Point(76, 10);
            this.btnDeleteMF.Name = "btnDeleteMF";
            this.btnDeleteMF.Size = new System.Drawing.Size(29, 24);
            this.btnDeleteMF.TabIndex = 4;
            this.btnDeleteMF.UseVisualStyleBackColor = true;
            this.btnDeleteMF.Click += new System.EventHandler(this.btnDeleteMF_Click);
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
            this.imgCollection.Images.SetKeyName(7, "icons8-cash-in-hand-16.png");
            this.imgCollection.Images.SetKeyName(8, "icons8-umbrella-16.png");
            this.imgCollection.Images.SetKeyName(9, "icons8-treatment-16.png");
            // 
            // btnAddMF
            // 
            this.btnAddMF.ImageIndex = 3;
            this.btnAddMF.ImageList = this.imgCollection;
            this.btnAddMF.Location = new System.Drawing.Point(6, 10);
            this.btnAddMF.Name = "btnAddMF";
            this.btnAddMF.Size = new System.Drawing.Size(29, 24);
            this.btnAddMF.TabIndex = 2;
            this.btnAddMF.UseVisualStyleBackColor = true;
            this.btnAddMF.Click += new System.EventHandler(this.btnAddMF_Click);
            // 
            // btnEditMF
            // 
            this.btnEditMF.ImageIndex = 4;
            this.btnEditMF.ImageList = this.imgCollection;
            this.btnEditMF.Location = new System.Drawing.Point(41, 10);
            this.btnEditMF.Name = "btnEditMF";
            this.btnEditMF.Size = new System.Drawing.Size(29, 24);
            this.btnEditMF.TabIndex = 3;
            this.btnEditMF.UseVisualStyleBackColor = true;
            // 
            // grpMFTransaction
            // 
            this.grpMFTransaction.Controls.Add(this.btnCancelMFTrans);
            this.grpMFTransaction.Controls.Add(this.btnSaveMFTrans);
            this.grpMFTransaction.Controls.Add(this.txtCurrentValue);
            this.grpMFTransaction.Controls.Add(this.label8);
            this.grpMFTransaction.Controls.Add(this.txtUnits);
            this.grpMFTransaction.Controls.Add(this.label7);
            this.grpMFTransaction.Controls.Add(this.txtNav);
            this.grpMFTransaction.Controls.Add(this.label6);
            this.grpMFTransaction.Controls.Add(this.dtTransDate);
            this.grpMFTransaction.Controls.Add(this.label5);
            this.grpMFTransaction.Controls.Add(this.cmbTransType);
            this.grpMFTransaction.Controls.Add(this.label4);
            this.grpMFTransaction.Controls.Add(this.lblSchemenameVal);
            this.grpMFTransaction.Controls.Add(this.label3);
            this.grpMFTransaction.Enabled = false;
            this.grpMFTransaction.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpMFTransaction.Location = new System.Drawing.Point(12, 413);
            this.grpMFTransaction.Name = "grpMFTransaction";
            this.grpMFTransaction.Size = new System.Drawing.Size(778, 198);
            this.grpMFTransaction.TabIndex = 16;
            this.grpMFTransaction.TabStop = false;
            this.grpMFTransaction.Text = "Transaction Info";
            // 
            // btnCancelMFTrans
            // 
            this.btnCancelMFTrans.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancelMFTrans.ImageKey = "icons8-cancel-16.png";
            this.btnCancelMFTrans.ImageList = this.imgCollection;
            this.btnCancelMFTrans.Location = new System.Drawing.Point(594, 112);
            this.btnCancelMFTrans.Name = "btnCancelMFTrans";
            this.btnCancelMFTrans.Size = new System.Drawing.Size(86, 26);
            this.btnCancelMFTrans.TabIndex = 20;
            this.btnCancelMFTrans.Text = "Cancel";
            this.btnCancelMFTrans.UseVisualStyleBackColor = true;
            this.btnCancelMFTrans.Click += new System.EventHandler(this.btnCancelMFTrans_Click);
            // 
            // btnSaveMFTrans
            // 
            this.btnSaveMFTrans.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSaveMFTrans.ImageKey = "icons8-save-close-16.png";
            this.btnSaveMFTrans.ImageList = this.imgCollection;
            this.btnSaveMFTrans.Location = new System.Drawing.Point(502, 112);
            this.btnSaveMFTrans.Name = "btnSaveMFTrans";
            this.btnSaveMFTrans.Size = new System.Drawing.Size(86, 26);
            this.btnSaveMFTrans.TabIndex = 19;
            this.btnSaveMFTrans.Text = "Save";
            this.btnSaveMFTrans.UseVisualStyleBackColor = true;
            this.btnSaveMFTrans.Click += new System.EventHandler(this.btnSaveMFTrans_Click);
            // 
            // txtCurrentValue
            // 
            this.txtCurrentValue.Location = new System.Drawing.Point(123, 115);
            this.txtCurrentValue.Name = "txtCurrentValue";
            this.txtCurrentValue.ReadOnly = true;
            this.txtCurrentValue.Size = new System.Drawing.Size(176, 21);
            this.txtCurrentValue.TabIndex = 11;
            this.txtCurrentValue.Text = "0";
            this.txtCurrentValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 118);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 15);
            this.label8.TabIndex = 10;
            this.label8.Text = "Current Value:";
            // 
            // txtUnits
            // 
            this.txtUnits.Location = new System.Drawing.Point(504, 85);
            this.txtUnits.Name = "txtUnits";
            this.txtUnits.Size = new System.Drawing.Size(176, 21);
            this.txtUnits.TabIndex = 9;
            this.txtUnits.Text = "0";
            this.txtUnits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUnits.Leave += new System.EventHandler(this.txtUnits_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(397, 88);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 15);
            this.label7.TabIndex = 8;
            this.label7.Text = "Units:";
            // 
            // txtNav
            // 
            this.txtNav.Location = new System.Drawing.Point(123, 88);
            this.txtNav.Name = "txtNav";
            this.txtNav.Size = new System.Drawing.Size(176, 21);
            this.txtNav.TabIndex = 7;
            this.txtNav.Text = "0";
            this.txtNav.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtNav.Leave += new System.EventHandler(this.txtNav_Leave);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "NAV:";
            // 
            // dtTransDate
            // 
            this.dtTransDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtTransDate.Location = new System.Drawing.Point(504, 58);
            this.dtTransDate.Name = "dtTransDate";
            this.dtTransDate.Size = new System.Drawing.Size(176, 21);
            this.dtTransDate.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(397, 63);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Transaction Type :";
            // 
            // cmbTransType
            // 
            this.cmbTransType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransType.FormattingEnabled = true;
            this.cmbTransType.Items.AddRange(new object[] {
            "Purchase",
            "Sell"});
            this.cmbTransType.Location = new System.Drawing.Point(123, 59);
            this.cmbTransType.Name = "cmbTransType";
            this.cmbTransType.Size = new System.Drawing.Size(173, 23);
            this.cmbTransType.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(11, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Transaction Type :";
            // 
            // lblSchemenameVal
            // 
            this.lblSchemenameVal.AutoSize = true;
            this.lblSchemenameVal.Location = new System.Drawing.Point(120, 32);
            this.lblSchemenameVal.Name = "lblSchemenameVal";
            this.lblSchemenameVal.Size = new System.Drawing.Size(115, 15);
            this.lblSchemenameVal.TabIndex = 1;
            this.lblSchemenameVal.Text = "lblSchemenameVal";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 32);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "Scheme Name :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Green;
            this.label2.Location = new System.Drawing.Point(556, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 15);
            this.label2.TabIndex = 17;
            this.label2.Text = "Folio No:";
            // 
            // lblFolioNoVal
            // 
            this.lblFolioNoVal.AutoSize = true;
            this.lblFolioNoVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFolioNoVal.ForeColor = System.Drawing.Color.Purple;
            this.lblFolioNoVal.Location = new System.Drawing.Point(627, 16);
            this.lblFolioNoVal.Name = "lblFolioNoVal";
            this.lblFolioNoVal.Size = new System.Drawing.Size(0, 15);
            this.lblFolioNoVal.TabIndex = 18;
            // 
            // MFTransactionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 623);
            this.Controls.Add(this.lblFolioNoVal);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.grpMFTransaction);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.dtGridMFTrans);
            this.Controls.Add(this.lblMFNameValue);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MFTransactionsForm";
            this.Text = "Mutual Fund Transaction Details";
            this.Load += new System.EventHandler(this.MFTransactions_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridMFTrans)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.grpMFTransaction.ResumeLayout(false);
            this.grpMFTransaction.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblMFNameValue;
        private System.Windows.Forms.DataGridView dtGridMFTrans;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnDeleteMF;
        private System.Windows.Forms.Button btnAddMF;
        private System.Windows.Forms.Button btnEditMF;
        private System.Windows.Forms.ImageList imgCollection;
        private System.Windows.Forms.GroupBox grpMFTransaction;
        private System.Windows.Forms.TextBox txtCurrentValue;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtUnits;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtNav;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtTransDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbTransType;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblSchemenameVal;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnCancelMFTrans;
        private System.Windows.Forms.Button btnSaveMFTrans;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblFolioNoVal;
    }
}