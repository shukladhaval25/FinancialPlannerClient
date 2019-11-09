namespace FinancialPlannerClient.TaskManagementSystem
{
    partial class AllTask
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllTask));
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.imgTaskGrid = new DevExpress.Utils.ImageCollection(this.components);
            this.grdTasks = new DevExpress.XtraGrid.GridControl();
            this.gridViewTasks = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.imgTaskGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTasks)).BeginInit();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClose.Location = new System.Drawing.Point(12, 479);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // imgTaskGrid
            // 
            this.imgTaskGrid.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imgTaskGrid.ImageStream")));
            this.imgTaskGrid.InsertGalleryImage("next_16x16.png", "images/navigation/next_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/navigation/next_16x16.png"), 0);
            this.imgTaskGrid.Images.SetKeyName(0, "next_16x16.png");
            this.imgTaskGrid.InsertGalleryImage("previous_16x16.png", "images/navigation/previous_16x16.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/navigation/previous_16x16.png"), 1);
            this.imgTaskGrid.Images.SetKeyName(1, "previous_16x16.png");
            // 
            // grdTasks
            // 
            this.grdTasks.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdTasks.Location = new System.Drawing.Point(13, 13);
            this.grdTasks.MainView = this.gridViewTasks;
            this.grdTasks.Name = "grdTasks";
            this.grdTasks.Size = new System.Drawing.Size(1114, 460);
            this.grdTasks.TabIndex = 29;
            this.grdTasks.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewTasks});
            // 
            // gridViewTasks
            // 
            this.gridViewTasks.GridControl = this.grdTasks;
            this.gridViewTasks.Name = "gridViewTasks";
            this.gridViewTasks.OptionsBehavior.Editable = true;
            // 
            // AllTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 514);
            this.Controls.Add(this.grdTasks);
            this.Controls.Add(this.btnClose);
            this.Name = "AllTask";
            this.Text = "AllTask";
            this.Load += new System.EventHandler(this.AllTask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imgTaskGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewTasks)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.Utils.ImageCollection imgTaskGrid;
        private DevExpress.XtraGrid.GridControl grdTasks;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewTasks;
    }
}