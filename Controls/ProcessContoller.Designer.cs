namespace FinancialPlannerClient.Controls
{
    partial class ProcessContoller
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProcessContoller));
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            this.pnlProcess = new System.Windows.Forms.Panel();
            this.btnInformation = new DevExpress.XtraEditors.SimpleButton();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblProcessNo = new System.Windows.Forms.Label();
            this.picNextStep = new System.Windows.Forms.PictureBox();
            this.picSubStep = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pnlProcess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNextStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSubStep)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlProcess
            // 
            this.pnlProcess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProcess.Controls.Add(this.btnInformation);
            this.pnlProcess.Controls.Add(this.lblTitle);
            this.pnlProcess.Controls.Add(this.lblProcessNo);
            this.pnlProcess.Location = new System.Drawing.Point(3, 3);
            this.pnlProcess.Name = "pnlProcess";
            this.pnlProcess.Size = new System.Drawing.Size(289, 53);
            this.pnlProcess.TabIndex = 3;
            // 
            // btnInformation
            // 
            this.btnInformation.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnInformation.Appearance.Options.UseBackColor = true;
            this.btnInformation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnInformation.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnInformation.Image = ((System.Drawing.Image)(resources.GetObject("btnInformation.Image")));
            this.btnInformation.Location = new System.Drawing.Point(266, 0);
            this.btnInformation.Name = "btnInformation";
            this.btnInformation.Size = new System.Drawing.Size(27, 51);
            toolTipTitleItem3.Text = "Information";
            toolTipItem3.LeftIndent = 6;
            toolTipItem3.Text = "To get more infomration about process assign and  status click here.";
            superToolTip3.Items.Add(toolTipTitleItem3);
            superToolTip3.Items.Add(toolTipItem3);
            this.btnInformation.SuperTip = superToolTip3;
            this.btnInformation.TabIndex = 38;
            // 
            // lblTitle
            // 
            this.lblTitle.AutoEllipsis = true;
            this.lblTitle.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.lblTitle.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(42, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(224, 51);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "Text";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblProcessNo
            // 
            this.lblProcessNo.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lblProcessNo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblProcessNo.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblProcessNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcessNo.Location = new System.Drawing.Point(0, 0);
            this.lblProcessNo.Name = "lblProcessNo";
            this.lblProcessNo.Size = new System.Drawing.Size(42, 51);
            this.lblProcessNo.TabIndex = 1;
            this.lblProcessNo.Text = "#";
            this.lblProcessNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picNextStep
            // 
            this.picNextStep.Image = global::FinancialPlannerClient.Properties.Resources.Right_Arrow;
            this.picNextStep.Location = new System.Drawing.Point(294, 12);
            this.picNextStep.Name = "picNextStep";
            this.picNextStep.Size = new System.Drawing.Size(37, 37);
            this.picNextStep.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNextStep.TabIndex = 4;
            this.picNextStep.TabStop = false;
            this.picNextStep.Visible = false;
            // 
            // picSubStep
            // 
            this.picSubStep.Image = global::FinancialPlannerClient.Properties.Resources.Down_Arrow;
            this.picSubStep.Location = new System.Drawing.Point(142, 56);
            this.picSubStep.Name = "picSubStep";
            this.picSubStep.Size = new System.Drawing.Size(37, 37);
            this.picSubStep.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSubStep.TabIndex = 5;
            this.picSubStep.TabStop = false;
            this.picSubStep.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ProcessContoller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.picSubStep);
            this.Controls.Add(this.picNextStep);
            this.Controls.Add(this.pnlProcess);
            this.Name = "ProcessContoller";
            this.Size = new System.Drawing.Size(295, 57);
            this.Load += new System.EventHandler(this.ProcessContoller_Load);
            this.pnlProcess.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picNextStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSubStep)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Panel pnlProcess;
        public System.Windows.Forms.Label lblTitle;
        public System.Windows.Forms.Label lblProcessNo;
        private System.Windows.Forms.PictureBox picNextStep;
        private System.Windows.Forms.PictureBox picSubStep;
        public DevExpress.XtraEditors.SimpleButton btnInformation;
        private System.Windows.Forms.Timer timer1;
    }
}
