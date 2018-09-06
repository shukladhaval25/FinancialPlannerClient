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
            this.grpRiskProfileReturnDeteails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridRiskProfileDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // grpRiskProfileReturnDeteails
            // 
            this.grpRiskProfileReturnDeteails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpRiskProfileReturnDeteails.Controls.Add(this.dtGridRiskProfileDetails);
            this.grpRiskProfileReturnDeteails.Location = new System.Drawing.Point(13, 120);
            this.grpRiskProfileReturnDeteails.Name = "grpRiskProfileReturnDeteails";
            this.grpRiskProfileReturnDeteails.Size = new System.Drawing.Size(923, 304);
            this.grpRiskProfileReturnDeteails.TabIndex = 1;
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
            this.dtGridRiskProfileDetails.Size = new System.Drawing.Size(910, 278);
            this.dtGridRiskProfileDetails.TabIndex = 0;
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
            this.label1.Location = new System.Drawing.Point(33, 58);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 63;
            this.label1.Text = "Name :";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(500, 28);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(421, 75);
            this.txtDescription.TabIndex = 62;
            // 
            // lblRiskProfileDescription
            // 
            this.lblRiskProfileDescription.AutoSize = true;
            this.lblRiskProfileDescription.Location = new System.Drawing.Point(428, 58);
            this.lblRiskProfileDescription.Name = "lblRiskProfileDescription";
            this.lblRiskProfileDescription.Size = new System.Drawing.Size(66, 13);
            this.lblRiskProfileDescription.TabIndex = 61;
            this.lblRiskProfileDescription.Text = "Description :";
            // 
            // txtRiskProfileName
            // 
            this.txtRiskProfileName.Location = new System.Drawing.Point(85, 55);
            this.txtRiskProfileName.Name = "txtRiskProfileName";
            this.txtRiskProfileName.Size = new System.Drawing.Size(307, 20);
            this.txtRiskProfileName.TabIndex = 60;
            // 
            // frmRiskProfileReturn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 477);
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
    }
}