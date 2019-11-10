namespace FinancialPlannerClient.Clients
{
    partial class ClientARNView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientARNView));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            this.grpClientARN = new DevExpress.XtraEditors.GroupControl();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.txtARNName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.lookUpARN = new DevExpress.XtraEditors.LookUpEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.grpClientARN)).BeginInit();
            this.grpClientARN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtARNName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpARN.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grpClientARN
            // 
            this.grpClientARN.Controls.Add(this.btnDelete);
            this.grpClientARN.Controls.Add(this.btnCancel);
            this.grpClientARN.Controls.Add(this.btnSave);
            this.grpClientARN.Controls.Add(this.txtARNName);
            this.grpClientARN.Controls.Add(this.labelControl2);
            this.grpClientARN.Controls.Add(this.lookUpARN);
            this.grpClientARN.Controls.Add(this.labelControl1);
            this.grpClientARN.Location = new System.Drawing.Point(12, 12);
            this.grpClientARN.Name = "grpClientARN";
            this.grpClientARN.Size = new System.Drawing.Size(293, 121);
            this.grpClientARN.TabIndex = 0;
            this.grpClientARN.Text = "ARN Information";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(79, 88);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(65, 23);
            toolTipTitleItem1.Text = "Delete";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "To delete record click here.";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.btnDelete.SuperTip = superToolTip1;
            this.btnDelete.TabIndex = 46;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.ToolTip = "Delete Client";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(213, 88);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(62, 23);
            toolTipTitleItem2.Text = "Cancel";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "To close without saving any information click here.";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.btnCancel.SuperTip = superToolTip2;
            this.btnCancel.TabIndex = 45;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(150, 88);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(57, 23);
            toolTipTitleItem3.Text = "Save";
            toolTipItem3.LeftIndent = 6;
            toolTipItem3.Text = "To save infroamtion click here.";
            superToolTip3.Items.Add(toolTipTitleItem3);
            superToolTip3.Items.Add(toolTipItem3);
            this.btnSave.SuperTip = superToolTip3;
            this.btnSave.TabIndex = 44;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtARNName
            // 
            this.txtARNName.Enabled = false;
            this.txtARNName.Location = new System.Drawing.Point(79, 62);
            this.txtARNName.Name = "txtARNName";
            this.txtARNName.Size = new System.Drawing.Size(196, 20);
            this.txtARNName.TabIndex = 3;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(39, 65);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(31, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "Name:";
            // 
            // lookUpARN
            // 
            this.lookUpARN.Location = new System.Drawing.Point(79, 31);
            this.lookUpARN.Name = "lookUpARN";
            this.lookUpARN.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lookUpARN.Properties.Columns.AddRange(new DevExpress.XtraEditors.Controls.LookUpColumnInfo[] {
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ID", "Id", 20, DevExpress.Utils.FormatType.None, "", false, DevExpress.Utils.HorzAlignment.Default),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("ARNNumber", "ARN Number"),
            new DevExpress.XtraEditors.Controls.LookUpColumnInfo("Name", "Name")});
            this.lookUpARN.Properties.DisplayMember = "ARNNumber";
            this.lookUpARN.Properties.ValueMember = "ID";
            this.lookUpARN.Size = new System.Drawing.Size(196, 20);
            this.lookUpARN.TabIndex = 1;
            this.lookUpARN.EditValueChanged += new System.EventHandler(this.lookUpARN_EditValueChanged);
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(39, 34);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(25, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "ARN:";
            // 
            // ClientARNView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(309, 142);
            this.Controls.Add(this.grpClientARN);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ClientARNView";
            this.Text = "Client ARN Details";
            this.Load += new System.EventHandler(this.ClientARN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpClientARN)).EndInit();
            this.grpClientARN.ResumeLayout(false);
            this.grpClientARN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtARNName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lookUpARN.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpClientARN;
        private DevExpress.XtraEditors.TextEdit txtARNName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit lookUpARN;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
    }
}