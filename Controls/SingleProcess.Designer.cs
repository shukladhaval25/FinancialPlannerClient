namespace FinancialPlannerClient.Controls
{
    partial class SingleProcess
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SingleProcess));
            this.ImgCloase = new DevExpress.XtraEditors.PictureEdit();
            this.ImgProcess = new DevExpress.XtraEditors.PictureEdit();
            this.lblAction = new DevExpress.XtraEditors.LabelControl();
            this.lblStep = new DevExpress.XtraEditors.LabelControl();
            this.ImgInformation = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgCloase.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgProcess.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgInformation.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // ImgCloase
            // 
            this.ImgCloase.Cursor = System.Windows.Forms.Cursors.Default;
            this.ImgCloase.EditValue = ((object)(resources.GetObject("ImgCloase.EditValue")));
            this.ImgCloase.Location = new System.Drawing.Point(130, -1);
            this.ImgCloase.Name = "ImgCloase";
            this.ImgCloase.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.ImgCloase.Properties.Appearance.Options.UseBackColor = true;
            this.ImgCloase.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.ImgCloase.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.ImgCloase.Properties.ZoomAccelerationFactor = 1D;
            this.ImgCloase.Size = new System.Drawing.Size(20, 20);
            this.ImgCloase.TabIndex = 0;
            this.ImgCloase.Click += new System.EventHandler(this.ImgCloase_Click);
            // 
            // ImgProcess
            // 
            this.ImgProcess.Cursor = System.Windows.Forms.Cursors.Default;
            this.ImgProcess.EditValue = ((object)(resources.GetObject("ImgProcess.EditValue")));
            this.ImgProcess.Location = new System.Drawing.Point(3, 19);
            this.ImgProcess.Name = "ImgProcess";
            this.ImgProcess.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.ImgProcess.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.ImgProcess.Properties.ZoomAccelerationFactor = 1D;
            this.ImgProcess.Size = new System.Drawing.Size(144, 93);
            this.ImgProcess.TabIndex = 1;
            this.ImgProcess.Click += new System.EventHandler(this.ImgProcess_Click);
            // 
            // lblAction
            // 
            this.lblAction.Appearance.Options.UseTextOptions = true;
            this.lblAction.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblAction.AutoEllipsis = true;
            this.lblAction.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblAction.Location = new System.Drawing.Point(3, 117);
            this.lblAction.Name = "lblAction";
            this.lblAction.Size = new System.Drawing.Size(143, 20);
            this.lblAction.TabIndex = 2;
            this.lblAction.Text = "Action";
            // 
            // lblStep
            // 
            this.lblStep.Appearance.Options.UseTextOptions = true;
            this.lblStep.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblStep.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblStep.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblStep.Location = new System.Drawing.Point(3, 141);
            this.lblStep.Name = "lblStep";
            this.lblStep.Size = new System.Drawing.Size(143, 20);
            this.lblStep.TabIndex = 3;
            this.lblStep.Text = "Step";
            this.lblStep.Click += new System.EventHandler(this.lblStep_Click);
            // 
            // ImgInformation
            // 
            this.ImgInformation.Cursor = System.Windows.Forms.Cursors.Default;
            this.ImgInformation.EditValue = ((object)(resources.GetObject("ImgInformation.EditValue")));
            this.ImgInformation.Location = new System.Drawing.Point(2, 2);
            this.ImgInformation.Name = "ImgInformation";
            this.ImgInformation.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.ImgInformation.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.ImgInformation.Properties.ZoomAccelerationFactor = 1D;
            this.ImgInformation.Size = new System.Drawing.Size(16, 17);
            this.ImgInformation.TabIndex = 4;
            // 
            // SingleProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.ImgInformation);
            this.Controls.Add(this.lblStep);
            this.Controls.Add(this.lblAction);
            this.Controls.Add(this.ImgProcess);
            this.Controls.Add(this.ImgCloase);
            this.Name = "SingleProcess";
            this.Size = new System.Drawing.Size(148, 162);
            ((System.ComponentModel.ISupportInitialize)(this.ImgCloase.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgProcess.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ImgInformation.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PictureEdit ImgCloase;
        private DevExpress.XtraEditors.PictureEdit ImgProcess;
        private DevExpress.XtraEditors.LabelControl lblAction;
        private DevExpress.XtraEditors.LabelControl lblStep;
        private DevExpress.XtraEditors.PictureEdit ImgInformation;
    }
}
