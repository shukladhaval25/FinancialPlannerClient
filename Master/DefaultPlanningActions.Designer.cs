using FinancialPlannerClient.Controls;

namespace FinancialPlannerClient.Master
{
    partial class DefaultPlanningActions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DefaultPlanningActions));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            this.ProcessController = new ProcessContoller();
            this.grpPlanningAction = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.label3 = new System.Windows.Forms.Label();
            this.btnChangeImage = new DevExpress.XtraEditors.SimpleButton();
            this.ImgAction = new DevExpress.XtraEditors.PictureEdit();
            this.chkVerifiedBySenior = new DevExpress.XtraEditors.CheckEdit();
            this.chkIsDelay = new DevExpress.XtraEditors.CheckEdit();
            this.label2 = new System.Windows.Forms.Label();
            this.txtProcessName = new DevExpress.XtraEditors.TextEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDaysRequireToComplete = new DevExpress.XtraEditors.SpinEdit();
            this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
            this.txtImgActionPath = new DevExpress.XtraEditors.TextEdit();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.grpPlanningAction)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgAction.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVerifiedBySenior.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsDelay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcessName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDaysRequireToComplete.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImgActionPath.Properties)).BeginInit();
            this.SuspendLayout();
            //
            // ProcessController
            //
            this.ProcessController.Visible = true;
            this.ProcessController.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // grpPlanningAction
            //
            this.grpPlanningAction.Controls.Add(this.ProcessController);
            this.grpPlanningAction.Location = new System.Drawing.Point(13, 13);
            this.grpPlanningAction.Name = "grpPlanningAction";
            this.grpPlanningAction.Size = new System.Drawing.Size(1120, 243);
            this.grpPlanningAction.TabIndex = 0;
            this.grpPlanningAction.Text = "Action Flow Process";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.btnClose);
            this.groupControl2.Controls.Add(this.btnSave);
            this.groupControl2.Controls.Add(this.label3);
            this.groupControl2.Controls.Add(this.btnChangeImage);
            this.groupControl2.Controls.Add(this.ImgAction);
            this.groupControl2.Controls.Add(this.chkVerifiedBySenior);
            this.groupControl2.Controls.Add(this.chkIsDelay);
            this.groupControl2.Controls.Add(this.label2);
            this.groupControl2.Controls.Add(this.txtProcessName);
            this.groupControl2.Controls.Add(this.label1);
            this.groupControl2.Controls.Add(this.txtDaysRequireToComplete);
            this.groupControl2.Controls.Add(this.txtDescription);
            this.groupControl2.Controls.Add(this.txtImgActionPath);
            this.groupControl2.Location = new System.Drawing.Point(13, 262);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1120, 210);
            this.groupControl2.TabIndex = 1;
            this.groupControl2.Text = "Processs Detail";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(850, 137);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(62, 23);
            toolTipTitleItem1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            toolTipTitleItem1.Appearance.Options.UseImage = true;
            toolTipTitleItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem1.Image")));
            toolTipTitleItem1.Text = "Cancel";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "To close client information without saving any information click here.";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.btnClose.SuperTip = superToolTip1;
            this.btnClose.TabIndex = 24;
            this.btnClose.Text = "&Close";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(787, 137);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(57, 23);
            toolTipTitleItem2.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            toolTipTitleItem2.Appearance.Options.UseImage = true;
            toolTipTitleItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem2.Image")));
            toolTipTitleItem2.Text = "Save";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "To save client infroamtion click here.";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.btnSave.SuperTip = superToolTip2;
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "&Save";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(514, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Process Name:";
            // 
            // btnChangeImage
            // 
            this.btnChangeImage.Image = ((System.Drawing.Image)(resources.GetObject("btnChangeImage.Image")));
            this.btnChangeImage.Location = new System.Drawing.Point(382, 139);
            this.btnChangeImage.Name = "btnChangeImage";
            this.btnChangeImage.Size = new System.Drawing.Size(124, 21);
            toolTipTitleItem3.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            toolTipTitleItem3.Appearance.Options.UseImage = true;
            toolTipTitleItem3.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem3.Image")));
            toolTipTitleItem3.Text = "Change Image";
            toolTipItem3.LeftIndent = 6;
            toolTipItem3.Text = "To change client image click here.";
            superToolTip3.Items.Add(toolTipTitleItem3);
            superToolTip3.Items.Add(toolTipItem3);
            this.btnChangeImage.SuperTip = superToolTip3;
            this.btnChangeImage.TabIndex = 20;
            this.btnChangeImage.Text = "Change";
            this.btnChangeImage.Click += new System.EventHandler(this.btnChangeImage_Click);
            // 
            // ImgAction
            // 
            this.ImgAction.Cursor = System.Windows.Forms.Cursors.Default;
            this.ImgAction.Location = new System.Drawing.Point(382, 36);
            this.ImgAction.Name = "ImgAction";
            this.ImgAction.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.ImgAction.Properties.ZoomAccelerationFactor = 1D;
            this.ImgAction.Size = new System.Drawing.Size(124, 96);
            this.ImgAction.TabIndex = 6;
            // 
            // chkVerifiedBySenior
            // 
            this.chkVerifiedBySenior.Location = new System.Drawing.Point(24, 113);
            this.chkVerifiedBySenior.Name = "chkVerifiedBySenior";
            this.chkVerifiedBySenior.Properties.Caption = "To complete process senior verification require.";
            this.chkVerifiedBySenior.Size = new System.Drawing.Size(259, 19);
            this.chkVerifiedBySenior.TabIndex = 5;
            // 
            // chkIsDelay
            // 
            this.chkIsDelay.Location = new System.Drawing.Point(24, 88);
            this.chkIsDelay.Name = "chkIsDelay";
            this.chkIsDelay.Properties.Caption = "Show nofication on delay in process.";
            this.chkIsDelay.Size = new System.Drawing.Size(222, 19);
            this.chkIsDelay.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(174, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Days Require to complete process:";
            // 
            // txtProcessName
            // 
            this.txtProcessName.Location = new System.Drawing.Point(105, 33);
            this.txtProcessName.Name = "txtProcessName";
            this.txtProcessName.Size = new System.Drawing.Size(222, 20);
            this.txtProcessName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Process Name:";
            // 
            // txtDaysRequireToComplete
            // 
            this.txtDaysRequireToComplete.EditValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtDaysRequireToComplete.Location = new System.Drawing.Point(201, 60);
            this.txtDaysRequireToComplete.Name = "txtDaysRequireToComplete";
            this.txtDaysRequireToComplete.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.False;
            this.txtDaysRequireToComplete.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtDaysRequireToComplete.Properties.EditValueChangedFiringMode = DevExpress.XtraEditors.Controls.EditValueChangedFiringMode.Default;
            this.txtDaysRequireToComplete.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.None;
            this.txtDaysRequireToComplete.Properties.MaxLength = 3;
            this.txtDaysRequireToComplete.Properties.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.txtDaysRequireToComplete.Properties.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txtDaysRequireToComplete.Size = new System.Drawing.Size(75, 20);
            this.txtDaysRequireToComplete.TabIndex = 3;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(517, 59);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(395, 73);
            this.txtDescription.TabIndex = 22;
            // 
            // txtImgActionPath
            // 
            this.txtImgActionPath.Location = new System.Drawing.Point(382, 140);
            this.txtImgActionPath.Name = "txtImgActionPath";
            this.txtImgActionPath.Size = new System.Drawing.Size(124, 20);
            this.txtImgActionPath.TabIndex = 25;
            this.txtImgActionPath.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // DefaultPlanningActions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 484);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.grpPlanningAction);
            this.Name = "DefaultPlanningActions";
            this.Text = "Planning Actions";
            ((System.ComponentModel.ISupportInitialize)(this.grpPlanningAction)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImgAction.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkVerifiedBySenior.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkIsDelay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProcessName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDaysRequireToComplete.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtImgActionPath.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ProcessContoller ProcessController;
        private DevExpress.XtraEditors.GroupControl grpPlanningAction;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.PictureEdit ImgAction;
        private DevExpress.XtraEditors.CheckEdit chkVerifiedBySenior;
        private DevExpress.XtraEditors.CheckEdit chkIsDelay;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TextEdit txtProcessName;
        private DevExpress.XtraEditors.SpinEdit txtDaysRequireToComplete;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnChangeImage;
        private DevExpress.XtraEditors.MemoEdit txtDescription;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraEditors.TextEdit txtImgActionPath;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

