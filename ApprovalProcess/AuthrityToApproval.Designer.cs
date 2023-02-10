namespace FinancialPlannerClient.ApprovalProcess
{
    partial class AuthrityToApproval
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
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AuthrityToApproval));
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            this.grpApproval = new DevExpress.XtraEditors.GroupControl();
            this.cmbReassignTo = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblReassignTo = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.grpApproval)).BeginInit();
            this.grpApproval.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbReassignTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpApproval
            // 
            this.grpApproval.Controls.Add(this.cmbReassignTo);
            this.grpApproval.Controls.Add(this.lblReassignTo);
            this.grpApproval.Controls.Add(this.labelControl1);
            this.grpApproval.Controls.Add(this.btnCancel);
            this.grpApproval.Controls.Add(this.btnOK);
            this.grpApproval.Controls.Add(this.txtPassword);
            this.grpApproval.Controls.Add(this.labelControl3);
            this.grpApproval.Controls.Add(this.txtDescription);
            this.grpApproval.Location = new System.Drawing.Point(12, 12);
            this.grpApproval.Name = "grpApproval";
            this.grpApproval.Size = new System.Drawing.Size(360, 202);
            this.grpApproval.TabIndex = 15;
            this.grpApproval.Text = "Approval Inforemation";
            // 
            // cmbReassignTo
            // 
            this.cmbReassignTo.Location = new System.Drawing.Point(128, 22);
            this.cmbReassignTo.Name = "cmbReassignTo";
            this.cmbReassignTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbReassignTo.Properties.Items.AddRange(new object[] {
            "All",
            "Task Bypass",
            "Process Lock"});
            this.cmbReassignTo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbReassignTo.Size = new System.Drawing.Size(211, 20);
            this.cmbReassignTo.TabIndex = 0;
            this.cmbReassignTo.SelectedIndexChanged += new System.EventHandler(this.cmbReassignTo_SelectedIndexChanged);
            // 
            // lblReassignTo
            // 
            this.lblReassignTo.Location = new System.Drawing.Point(18, 25);
            this.lblReassignTo.Name = "lblReassignTo";
            this.lblReassignTo.Size = new System.Drawing.Size(62, 13);
            this.lblReassignTo.TabIndex = 46;
            this.lblReassignTo.Text = "Reassign To:";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(18, 76);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(57, 13);
            this.labelControl1.TabIndex = 44;
            this.labelControl1.Text = "Description:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnCancel.Location = new System.Drawing.Point(190, 170);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(62, 23);
            toolTipTitleItem1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            toolTipTitleItem1.Appearance.Options.UseImage = true;
            toolTipTitleItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem1.Image")));
            toolTipTitleItem1.Text = "Cancel";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "To close Scheme information without saving any information click here.";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.btnCancel.SuperTip = superToolTip1;
            this.btnCancel.TabIndex = 43;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnOK.Location = new System.Drawing.Point(127, 170);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(57, 23);
            this.btnOK.TabIndex = 42;
            this.btnOK.Text = "&Ok";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(128, 48);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(211, 20);
            this.txtPassword.TabIndex = 1;
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(18, 51);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(104, 13);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "Enter your password:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(18, 95);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDescription.Properties.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.txtDescription.Size = new System.Drawing.Size(321, 62);
            this.txtDescription.TabIndex = 2;
            // 
            // AuthrityToApproval
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(385, 226);
            this.ControlBox = false;
            this.Controls.Add(this.grpApproval);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AuthrityToApproval";
            this.ShowInTaskbar = false;
            this.Text = "Approval Process";
            this.Load += new System.EventHandler(this.AuthrityToApproval_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpApproval)).EndInit();
            this.grpApproval.ResumeLayout(false);
            this.grpApproval.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbReassignTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpApproval;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.TextEdit txtPassword;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.MemoEdit txtDescription;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraEditors.LabelControl lblReassignTo;
        private DevExpress.XtraEditors.ComboBoxEdit cmbReassignTo;
    }
}