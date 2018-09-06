namespace FinancialPlannerClient.ProspectCustomer
{
    partial class frmProspectCustomerConversation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmProspectCustomerConversation));
            this.grpConversation = new System.Windows.Forms.GroupBox();
            this.lblName = new System.Windows.Forms.Label();
            this.lblCustNameTitle = new System.Windows.Forms.Label();
            this.txtRemarks = new System.Windows.Forms.TextBox();
            this.lblRemark = new System.Windows.Forms.Label();
            this.txtConversationBy = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtConversation = new System.Windows.Forms.DateTimePicker();
            this.lblDate = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.grpConversation.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpConversation
            // 
            this.grpConversation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpConversation.Controls.Add(this.lblName);
            this.grpConversation.Controls.Add(this.lblCustNameTitle);
            this.grpConversation.Controls.Add(this.txtRemarks);
            this.grpConversation.Controls.Add(this.lblRemark);
            this.grpConversation.Controls.Add(this.txtConversationBy);
            this.grpConversation.Controls.Add(this.label2);
            this.grpConversation.Controls.Add(this.dtConversation);
            this.grpConversation.Controls.Add(this.lblDate);
            this.grpConversation.Location = new System.Drawing.Point(8, 12);
            this.grpConversation.Name = "grpConversation";
            this.grpConversation.Size = new System.Drawing.Size(423, 272);
            this.grpConversation.TabIndex = 0;
            this.grpConversation.TabStop = false;
            this.grpConversation.Text = "Conversation Information";
            // 
            // lblName
            // 
            this.lblName.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.ForeColor = System.Drawing.Color.Chocolate;
            this.lblName.Location = new System.Drawing.Point(119, 47);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(272, 23);
            this.lblName.TabIndex = 7;
            this.lblName.Text = "{Customer Name}";
            // 
            // lblCustNameTitle
            // 
            this.lblCustNameTitle.AutoSize = true;
            this.lblCustNameTitle.Location = new System.Drawing.Point(18, 47);
            this.lblCustNameTitle.Name = "lblCustNameTitle";
            this.lblCustNameTitle.Size = new System.Drawing.Size(38, 13);
            this.lblCustNameTitle.TabIndex = 6;
            this.lblCustNameTitle.Text = "Name:";
            // 
            // txtRemarks
            // 
            this.txtRemarks.Location = new System.Drawing.Point(122, 163);
            this.txtRemarks.Multiline = true;
            this.txtRemarks.Name = "txtRemarks";
            this.txtRemarks.Size = new System.Drawing.Size(269, 91);
            this.txtRemarks.TabIndex = 5;
            // 
            // lblRemark
            // 
            this.lblRemark.AutoSize = true;
            this.lblRemark.Location = new System.Drawing.Point(18, 166);
            this.lblRemark.Name = "lblRemark";
            this.lblRemark.Size = new System.Drawing.Size(47, 13);
            this.lblRemark.TabIndex = 4;
            this.lblRemark.Text = "Remark:";
            // 
            // txtConversationBy
            // 
            this.txtConversationBy.Location = new System.Drawing.Point(122, 124);
            this.txtConversationBy.Name = "txtConversationBy";
            this.txtConversationBy.Size = new System.Drawing.Size(269, 20);
            this.txtConversationBy.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Conversation By:";
            // 
            // dtConversation
            // 
            this.dtConversation.Location = new System.Drawing.Point(122, 85);
            this.dtConversation.Name = "dtConversation";
            this.dtConversation.Size = new System.Drawing.Size(137, 20);
            this.dtConversation.TabIndex = 1;
            // 
            // lblDate
            // 
            this.lblDate.AutoSize = true;
            this.lblDate.Location = new System.Drawing.Point(18, 88);
            this.lblDate.Name = "lblDate";
            this.lblDate.Size = new System.Drawing.Size(98, 13);
            this.lblDate.TabIndex = 0;
            this.lblDate.Text = "Conversation Date:";
            // 
            // btnSave
            // 
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSave.ImageKey = "icons8-save-close-16.png";
            this.btnSave.ImageList = this.imageList1;
            this.btnSave.Location = new System.Drawing.Point(275, 290);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnClose.ImageKey = "icons8-cancel-16.png";
            this.btnClose.ImageList = this.imageList1;
            this.btnClose.Location = new System.Drawing.Point(356, 290);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "icons8-save-close-16.png");
            this.imageList1.Images.SetKeyName(1, "icons8-cancel-16.png");
            // 
            // frmProspectCustomerConversation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(441, 320);
            this.ControlBox = false;
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpConversation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmProspectCustomerConversation";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Conversation Inforamtion";
            this.Load += new System.EventHandler(this.ProspectCustomerConversation_Load);
            this.grpConversation.ResumeLayout(false);
            this.grpConversation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpConversation;
        private System.Windows.Forms.TextBox txtRemarks;
        private System.Windows.Forms.Label lblRemark;
        private System.Windows.Forms.TextBox txtConversationBy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtConversation;
        private System.Windows.Forms.Label lblDate;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblCustNameTitle;
        private System.Windows.Forms.ImageList imageList1;
    }
}