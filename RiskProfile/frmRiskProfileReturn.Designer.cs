namespace FinancialPlannerClient.RiskProfile
{
    partial class frmRiskProfileReturn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRiskProfileReturn));
            this.grpRiskProfileReturnDeteails = new System.Windows.Forms.GroupBox();
            this.dtGridRiskProfileDetails = new System.Windows.Forms.DataGridView();
            this.btnCancel = new System.Windows.Forms.Button();
            this.imageList16x16 = new System.Windows.Forms.ImageList(this.components);
            this.btnRiskProfileSaved = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblRiskProfileDescription = new System.Windows.Forms.Label();
            this.txtRiskProfileName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.numThresholdYear = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtPreForeignInvRation = new System.Windows.Forms.TextBox();
            this.txtPreEquityInvRatio = new System.Windows.Forms.TextBox();
            this.txtPreDebtInvRatio = new System.Windows.Forms.TextBox();
            this.txtPostForeingInvRatio = new System.Windows.Forms.TextBox();
            this.txtPostEquityInvRatio = new System.Windows.Forms.TextBox();
            this.txtPostDebtInvRatio = new System.Windows.Forms.TextBox();
            this.txtForeingReturn = new System.Windows.Forms.TextBox();
            this.txtEquityInvReturn = new System.Windows.Forms.TextBox();
            this.txtDebtInvReturn = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.numMaxYear = new System.Windows.Forms.NumericUpDown();
            this.btnShowCalculation = new System.Windows.Forms.Button();
            this.grpRiskProfileReturnDeteails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridRiskProfileDetails)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThresholdYear)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxYear)).BeginInit();
            this.SuspendLayout();
            // 
            // grpRiskProfileReturnDeteails
            // 
            this.grpRiskProfileReturnDeteails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRiskProfileReturnDeteails.Controls.Add(this.dtGridRiskProfileDetails);
            this.grpRiskProfileReturnDeteails.Location = new System.Drawing.Point(13, 153);
            this.grpRiskProfileReturnDeteails.Name = "grpRiskProfileReturnDeteails";
            this.grpRiskProfileReturnDeteails.Size = new System.Drawing.Size(923, 271);
            this.grpRiskProfileReturnDeteails.TabIndex = 16;
            this.grpRiskProfileReturnDeteails.TabStop = false;
            this.grpRiskProfileReturnDeteails.Text = "Risk Profile Return Details";
            // 
            // dtGridRiskProfileDetails
            // 
            this.dtGridRiskProfileDetails.AllowUserToAddRows = false;
            this.dtGridRiskProfileDetails.AllowUserToDeleteRows = false;
            this.dtGridRiskProfileDetails.AllowUserToOrderColumns = true;
            this.dtGridRiskProfileDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGridRiskProfileDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridRiskProfileDetails.Location = new System.Drawing.Point(7, 20);
            this.dtGridRiskProfileDetails.Name = "dtGridRiskProfileDetails";
            this.dtGridRiskProfileDetails.Size = new System.Drawing.Size(910, 245);
            this.dtGridRiskProfileDetails.TabIndex = 0;
            this.dtGridRiskProfileDetails.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridRiskProfileDetails_CellEndEdit);
            this.dtGridRiskProfileDetails.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dtGridRiskProfileDetails_CellFormatting);
            this.dtGridRiskProfileDetails.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtGridRiskProfileDetails_CellValidating);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.ImageKey = "icons8-cancel-16.png";
            this.btnCancel.ImageList = this.imageList16x16;
            this.btnCancel.Location = new System.Drawing.Point(850, 439);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(86, 26);
            this.btnCancel.TabIndex = 59;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // imageList16x16
            // 
            this.imageList16x16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList16x16.ImageStream")));
            this.imageList16x16.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList16x16.Images.SetKeyName(0, "icons8-contact-details-16-2.png");
            this.imageList16x16.Images.SetKeyName(1, "icons8-resume-16.png");
            this.imageList16x16.Images.SetKeyName(2, "icons8-customer-16.png");
            this.imageList16x16.Images.SetKeyName(3, "icons8-cancel-16.png");
            this.imageList16x16.Images.SetKeyName(4, "icons8-save-close-16.png");
            // 
            // btnRiskProfileSaved
            // 
            this.btnRiskProfileSaved.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRiskProfileSaved.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRiskProfileSaved.ImageKey = "icons8-save-close-16.png";
            this.btnRiskProfileSaved.ImageList = this.imageList16x16;
            this.btnRiskProfileSaved.Location = new System.Drawing.Point(758, 439);
            this.btnRiskProfileSaved.Name = "btnRiskProfileSaved";
            this.btnRiskProfileSaved.Size = new System.Drawing.Size(86, 26);
            this.btnRiskProfileSaved.TabIndex = 58;
            this.btnRiskProfileSaved.Text = "Save";
            this.btnRiskProfileSaved.UseVisualStyleBackColor = true;
            this.btnRiskProfileSaved.Click += new System.EventHandler(this.btnPersonalDetailSave_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "Name :";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(92, 54);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(207, 72);
            this.txtDescription.TabIndex = 2;
            // 
            // lblRiskProfileDescription
            // 
            this.lblRiskProfileDescription.AutoSize = true;
            this.lblRiskProfileDescription.Location = new System.Drawing.Point(20, 70);
            this.lblRiskProfileDescription.Name = "lblRiskProfileDescription";
            this.lblRiskProfileDescription.Size = new System.Drawing.Size(66, 13);
            this.lblRiskProfileDescription.TabIndex = 61;
            this.lblRiskProfileDescription.Text = "Description :";
            // 
            // txtRiskProfileName
            // 
            this.txtRiskProfileName.Location = new System.Drawing.Point(92, 28);
            this.txtRiskProfileName.Name = "txtRiskProfileName";
            this.txtRiskProfileName.Size = new System.Drawing.Size(207, 20);
            this.txtRiskProfileName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(308, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 13);
            this.label2.TabIndex = 64;
            this.label2.Text = "Risk Threshold Year:";
            // 
            // numThresholdYear
            // 
            this.numThresholdYear.Location = new System.Drawing.Point(420, 41);
            this.numThresholdYear.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numThresholdYear.Name = "numThresholdYear";
            this.numThresholdYear.Size = new System.Drawing.Size(59, 20);
            this.numThresholdYear.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(308, 69);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 68;
            this.label4.Text = "Calculate upto (Years):";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.BackColor = System.Drawing.Color.Gainsboro;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 61.57407F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 38.42593F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 93F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 94F));
            this.tableLayoutPanel1.Controls.Add(this.label6, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtPreForeignInvRation, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtPreEquityInvRatio, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtPreDebtInvRatio, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtPostForeingInvRatio, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtPostEquityInvRatio, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtPostDebtInvRatio, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.txtForeingReturn, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtEquityInvReturn, 2, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtDebtInvReturn, 3, 3);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(487, 11);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(449, 113);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(164, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(94, 33);
            this.label6.TabIndex = 70;
            this.label6.Text = "Foreing Investment (%)";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(264, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 33);
            this.label7.TabIndex = 71;
            this.label7.Text = "Equity Investment (%)";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(357, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 33);
            this.label8.TabIndex = 72;
            this.label8.Text = "Debt Investment (%)";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(3, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(155, 22);
            this.label5.TabIndex = 69;
            this.label5.Text = "Value under threshold years:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(3, 59);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(155, 23);
            this.label10.TabIndex = 74;
            this.label10.Text = "Value above threshold years:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtPreForeignInvRation
            // 
            this.txtPreForeignInvRation.Location = new System.Drawing.Point(164, 36);
            this.txtPreForeignInvRation.Name = "txtPreForeignInvRation";
            this.txtPreForeignInvRation.Size = new System.Drawing.Size(94, 20);
            this.txtPreForeignInvRation.TabIndex = 6;
            // 
            // txtPreEquityInvRatio
            // 
            this.txtPreEquityInvRatio.Location = new System.Drawing.Point(264, 36);
            this.txtPreEquityInvRatio.Name = "txtPreEquityInvRatio";
            this.txtPreEquityInvRatio.Size = new System.Drawing.Size(87, 20);
            this.txtPreEquityInvRatio.TabIndex = 7;
            // 
            // txtPreDebtInvRatio
            // 
            this.txtPreDebtInvRatio.Location = new System.Drawing.Point(357, 36);
            this.txtPreDebtInvRatio.Name = "txtPreDebtInvRatio";
            this.txtPreDebtInvRatio.Size = new System.Drawing.Size(88, 20);
            this.txtPreDebtInvRatio.TabIndex = 8;
            // 
            // txtPostForeingInvRatio
            // 
            this.txtPostForeingInvRatio.Location = new System.Drawing.Point(164, 62);
            this.txtPostForeingInvRatio.Name = "txtPostForeingInvRatio";
            this.txtPostForeingInvRatio.Size = new System.Drawing.Size(94, 20);
            this.txtPostForeingInvRatio.TabIndex = 9;
            // 
            // txtPostEquityInvRatio
            // 
            this.txtPostEquityInvRatio.Location = new System.Drawing.Point(264, 62);
            this.txtPostEquityInvRatio.Name = "txtPostEquityInvRatio";
            this.txtPostEquityInvRatio.Size = new System.Drawing.Size(87, 20);
            this.txtPostEquityInvRatio.TabIndex = 10;
            // 
            // txtPostDebtInvRatio
            // 
            this.txtPostDebtInvRatio.Location = new System.Drawing.Point(357, 62);
            this.txtPostDebtInvRatio.Name = "txtPostDebtInvRatio";
            this.txtPostDebtInvRatio.Size = new System.Drawing.Size(88, 20);
            this.txtPostDebtInvRatio.TabIndex = 11;
            // 
            // txtForeingReturn
            // 
            this.txtForeingReturn.Location = new System.Drawing.Point(164, 88);
            this.txtForeingReturn.Name = "txtForeingReturn";
            this.txtForeingReturn.Size = new System.Drawing.Size(94, 20);
            this.txtForeingReturn.TabIndex = 12;
            // 
            // txtEquityInvReturn
            // 
            this.txtEquityInvReturn.Location = new System.Drawing.Point(264, 88);
            this.txtEquityInvReturn.Name = "txtEquityInvReturn";
            this.txtEquityInvReturn.Size = new System.Drawing.Size(87, 20);
            this.txtEquityInvReturn.TabIndex = 13;
            // 
            // txtDebtInvReturn
            // 
            this.txtDebtInvReturn.Location = new System.Drawing.Point(357, 88);
            this.txtDebtInvReturn.Name = "txtDebtInvReturn";
            this.txtDebtInvReturn.Size = new System.Drawing.Size(88, 20);
            this.txtDebtInvReturn.TabIndex = 14;
            // 
            // label9
            // 
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(3, 85);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(155, 23);
            this.label9.TabIndex = 73;
            this.label9.Text = "Investment Return (%)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numMaxYear
            // 
            this.numMaxYear.Location = new System.Drawing.Point(420, 67);
            this.numMaxYear.Name = "numMaxYear";
            this.numMaxYear.Size = new System.Drawing.Size(59, 20);
            this.numMaxYear.TabIndex = 4;
            // 
            // btnShowCalculation
            // 
            this.btnShowCalculation.Location = new System.Drawing.Point(832, 130);
            this.btnShowCalculation.Name = "btnShowCalculation";
            this.btnShowCalculation.Size = new System.Drawing.Size(104, 23);
            this.btnShowCalculation.TabIndex = 15;
            this.btnShowCalculation.Text = "Show Calculation";
            this.btnShowCalculation.UseVisualStyleBackColor = true;
            this.btnShowCalculation.Click += new System.EventHandler(this.btnShowCalculation_Click);
            // 
            // frmRiskProfileReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 477);
            this.Controls.Add(this.btnShowCalculation);
            this.Controls.Add(this.numMaxYear);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.numThresholdYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblRiskProfileDescription);
            this.Controls.Add(this.txtRiskProfileName);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnRiskProfileSaved);
            this.Controls.Add(this.grpRiskProfileReturnDeteails);
            this.Name = "frmRiskProfileReturn";
            this.Text = "Risk Profile Return Details";
            this.Load += new System.EventHandler(this.frmRiskProfileReturn_Load);
            this.grpRiskProfileReturnDeteails.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridRiskProfileDetails)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numThresholdYear)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMaxYear)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grpRiskProfileReturnDeteails;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnRiskProfileSaved;
        private System.Windows.Forms.ImageList imageList16x16;
        private System.Windows.Forms.DataGridView dtGridRiskProfileDetails;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblRiskProfileDescription;
        private System.Windows.Forms.TextBox txtRiskProfileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numThresholdYear;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtPreForeignInvRation;
        private System.Windows.Forms.TextBox txtPreEquityInvRatio;
        private System.Windows.Forms.TextBox txtPreDebtInvRatio;
        private System.Windows.Forms.TextBox txtPostForeingInvRatio;
        private System.Windows.Forms.TextBox txtPostEquityInvRatio;
        private System.Windows.Forms.TextBox txtPostDebtInvRatio;
        private System.Windows.Forms.TextBox txtForeingReturn;
        private System.Windows.Forms.TextBox txtEquityInvReturn;
        private System.Windows.Forms.TextBox txtDebtInvReturn;
        private System.Windows.Forms.NumericUpDown numMaxYear;
        private System.Windows.Forms.Button btnShowCalculation;
    }
}