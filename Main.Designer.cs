namespace FinancialPlannerClient
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.auditTrailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.imglist16x16 = new System.Windows.Forms.ImageList(this.components);
            this.imgList30x30 = new System.Windows.Forms.ImageList(this.components);
            this.riskProfileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createNewRsikProfiledToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.picClientMain = new System.Windows.Forms.PictureBox();
            this.prospectedCustomerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picClientMain)).BeginInit();
            this.SuspendLayout();
            // 
            // menuMain
            // 
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.prospectedCustomerToolStripMenuItem,
            this.clientsToolStripMenuItem,
            this.riskProfileToolStripMenuItem,
            this.auditTrailToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Size = new System.Drawing.Size(1022, 24);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuStrip1";
            // 
            // auditTrailToolStripMenuItem
            // 
            this.auditTrailToolStripMenuItem.Name = "auditTrailToolStripMenuItem";
            this.auditTrailToolStripMenuItem.Size = new System.Drawing.Size(74, 20);
            this.auditTrailToolStripMenuItem.Text = "Audit Trail";
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.exitToolStripMenuItem.Text = "Exit";
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.picClientMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 24);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1022, 544);
            this.pnlMain.TabIndex = 2;
            this.pnlMain.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.pnlMain_ControlAdded);
            this.pnlMain.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.pnlMain_ControlRemoved);
            // 
            // imglist16x16
            // 
            this.imglist16x16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglist16x16.ImageStream")));
            this.imglist16x16.TransparentColor = System.Drawing.Color.Transparent;
            this.imglist16x16.Images.SetKeyName(0, "icons8-customer-16.png");
            this.imglist16x16.Images.SetKeyName(1, "icons8-reception-16 - Copy.png");
            // 
            // imgList30x30
            // 
            this.imgList30x30.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgList30x30.ImageStream")));
            this.imgList30x30.TransparentColor = System.Drawing.Color.Transparent;
            this.imgList30x30.Images.SetKeyName(0, "icons8-select-users-30.png");
            // 
            // riskProfileToolStripMenuItem
            // 
            this.riskProfileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createNewRsikProfiledToolStripMenuItem});
            this.riskProfileToolStripMenuItem.Name = "riskProfileToolStripMenuItem";
            this.riskProfileToolStripMenuItem.Size = new System.Drawing.Size(119, 20);
            this.riskProfileToolStripMenuItem.Text = "RiskProfiled Return";
            // 
            // createNewRsikProfiledToolStripMenuItem
            // 
            this.createNewRsikProfiledToolStripMenuItem.Name = "createNewRsikProfiledToolStripMenuItem";
            this.createNewRsikProfiledToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.createNewRsikProfiledToolStripMenuItem.Text = "Manage Rsik Profiled";
            this.createNewRsikProfiledToolStripMenuItem.Click += new System.EventHandler(this.createNewRsikProfiledToolStripMenuItem_Click);
            // 
            // picClientMain
            // 
            this.picClientMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picClientMain.Image = global::FinancialPlannerClient.Properties.Resources.marguerite_daisy_beautiful_beauty;
            this.picClientMain.Location = new System.Drawing.Point(291, 202);
            this.picClientMain.Name = "picClientMain";
            this.picClientMain.Size = new System.Drawing.Size(440, 141);
            this.picClientMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picClientMain.TabIndex = 0;
            this.picClientMain.TabStop = false;
            // 
            // prospectedCustomerToolStripMenuItem
            // 
            this.prospectedCustomerToolStripMenuItem.Image = global::FinancialPlannerClient.Properties.Resources.icons8_reception_30;
            this.prospectedCustomerToolStripMenuItem.Name = "prospectedCustomerToolStripMenuItem";
            this.prospectedCustomerToolStripMenuItem.Size = new System.Drawing.Size(136, 20);
            this.prospectedCustomerToolStripMenuItem.Text = "Prospect Customer";
            this.prospectedCustomerToolStripMenuItem.Click += new System.EventHandler(this.prospectedCustomerToolStripMenuItem_Click);
            // 
            // clientsToolStripMenuItem
            // 
            this.clientsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataGaToolStripMenuItem});
            this.clientsToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("clientsToolStripMenuItem.Image")));
            this.clientsToolStripMenuItem.Name = "clientsToolStripMenuItem";
            this.clientsToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.clientsToolStripMenuItem.Text = "Planner";
            this.clientsToolStripMenuItem.Click += new System.EventHandler(this.clientsToolStripMenuItem_Click);
            // 
            // dataGaToolStripMenuItem
            // 
            this.dataGaToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("dataGaToolStripMenuItem.Image")));
            this.dataGaToolStripMenuItem.Name = "dataGaToolStripMenuItem";
            this.dataGaToolStripMenuItem.Size = new System.Drawing.Size(153, 22);
            this.dataGaToolStripMenuItem.Text = "Data Gathering";
            this.dataGaToolStripMenuItem.Click += new System.EventHandler(this.dataGaToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 568);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.menuMain);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuMain;
            this.Name = "Main";
            this.Text = "Financial Planner Client";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picClientMain)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem prospectedCustomerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem auditTrailToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.PictureBox picClientMain;
        private System.Windows.Forms.ImageList imglist16x16;
        private System.Windows.Forms.ToolStripMenuItem dataGaToolStripMenuItem;
        private System.Windows.Forms.ImageList imgList30x30;
        private System.Windows.Forms.ToolStripMenuItem riskProfileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createNewRsikProfiledToolStripMenuItem;
    }
}