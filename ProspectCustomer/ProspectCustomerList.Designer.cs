namespace FinancialPlannerClient.ProspectCustomer
{
    partial class ProspectCustomerList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProspectCustomerList));
            this.grpActionControls = new System.Windows.Forms.GroupBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.imgCollection = new System.Windows.Forms.ImageList(this.components);
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.lblProsCust = new System.Windows.Forms.Label();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.trvList = new System.Windows.Forms.TreeView();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.grpActionControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.grpSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpActionControls
            // 
            this.grpActionControls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grpActionControls.Controls.Add(this.btnDelete);
            this.grpActionControls.Controls.Add(this.btnAdd);
            this.grpActionControls.Controls.Add(this.btnEdit);
            this.grpActionControls.Location = new System.Drawing.Point(75, 448);
            this.grpActionControls.Name = "grpActionControls";
            this.grpActionControls.Size = new System.Drawing.Size(111, 38);
            this.grpActionControls.TabIndex = 6;
            this.grpActionControls.TabStop = false;
            // 
            // btnDelete
            // 
            this.btnDelete.ImageIndex = 1;
            this.btnDelete.ImageList = this.imgCollection;
            this.btnDelete.Location = new System.Drawing.Point(76, 10);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(29, 24);
            this.btnDelete.TabIndex = 4;
            this.toolTip1.SetToolTip(this.btnDelete, "Delete");
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // imgCollection
            // 
            this.imgCollection.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgCollection.ImageStream")));
            this.imgCollection.TransparentColor = System.Drawing.Color.Transparent;
            this.imgCollection.Images.SetKeyName(0, "Add-Action.png");
            this.imgCollection.Images.SetKeyName(1, "delete.png");
            this.imgCollection.Images.SetKeyName(2, "deleteline.png");
            this.imgCollection.Images.SetKeyName(3, "drop-add.gif");
            this.imgCollection.Images.SetKeyName(4, "Edit.png");
            this.imgCollection.Images.SetKeyName(5, "User.png");
            this.imgCollection.Images.SetKeyName(6, "VirtualUser.png");
            this.imgCollection.Images.SetKeyName(7, "icons8-circled-play-16.png");
            this.imgCollection.Images.SetKeyName(8, "icons8-search-16.png");
            this.imgCollection.Images.SetKeyName(9, "icons8-customer-16.png");
            this.imgCollection.Images.SetKeyName(10, "icons8-reception-16 - Copy.png");
            this.imgCollection.Images.SetKeyName(11, "icons8-refresh-16.png");
            // 
            // btnAdd
            // 
            this.btnAdd.ImageIndex = 3;
            this.btnAdd.ImageList = this.imgCollection;
            this.btnAdd.Location = new System.Drawing.Point(6, 10);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(29, 24);
            this.btnAdd.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnAdd, "Add");
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.ImageIndex = 4;
            this.btnEdit.ImageList = this.imgCollection;
            this.btnEdit.Location = new System.Drawing.Point(41, 10);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(29, 24);
            this.btnEdit.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnEdit, "Edit");
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // lblProsCust
            // 
            this.lblProsCust.AutoSize = true;
            this.lblProsCust.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProsCust.Location = new System.Drawing.Point(12, 105);
            this.lblProsCust.Name = "lblProsCust";
            this.lblProsCust.Size = new System.Drawing.Size(170, 17);
            this.lblProsCust.TabIndex = 7;
            this.lblProsCust.Text = "List of Prospect Customer";
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.AutoScroll = true;
            this.splitContainer.Panel1.Controls.Add(this.btnRefresh);
            this.splitContainer.Panel1.Controls.Add(this.btnSearch);
            this.splitContainer.Panel1.Controls.Add(this.trvList);
            this.splitContainer.Panel1.Controls.Add(this.grpSearch);
            this.splitContainer.Panel1.Controls.Add(this.grpActionControls);
            this.splitContainer.Panel1.DataBindings.Add(new System.Windows.Forms.Binding("Padding", global::FinancialPlannerClient.Properties.Settings.Default, "Custom", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.splitContainer.Panel1.DataBindings.Add(new System.Windows.Forms.Binding("Tag", global::FinancialPlannerClient.Properties.Settings.Default, "Custom", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.splitContainer.Panel1.Padding = global::FinancialPlannerClient.Properties.Settings.Default.Custom;
            this.splitContainer.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.splitContainer.Panel1.Tag = global::FinancialPlannerClient.Properties.Settings.Default.Custom;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer.Size = new System.Drawing.Size(945, 492);
            this.splitContainer.SplitterDistance = 194;
            this.splitContainer.TabIndex = 8;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnRefresh.Image = global::FinancialPlannerClient.Properties.Resources.icons8_refresh_16;
            this.btnRefresh.Location = new System.Drawing.Point(7, 458);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(29, 24);
            this.btnRefresh.TabIndex = 7;
            this.toolTip1.SetToolTip(this.btnRefresh, "Refresh Data");
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.ImageKey = "icons8-search-16.png";
            this.btnSearch.ImageList = this.imgCollection;
            this.btnSearch.Location = new System.Drawing.Point(156, 28);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(30, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // trvList
            // 
            this.trvList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trvList.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.trvList.FullRowSelect = true;
            this.trvList.ImageKey = "icons8-reception-16 - Copy.png";
            this.trvList.ImageList = this.imgCollection;
            this.trvList.Location = new System.Drawing.Point(7, 67);
            this.trvList.Name = "trvList";
            this.trvList.SelectedImageIndex = 7;
            this.trvList.ShowNodeToolTips = true;
            this.trvList.Size = new System.Drawing.Size(179, 375);
            this.trvList.StateImageList = this.imgCollection;
            this.trvList.TabIndex = 1;
            this.toolTip1.SetToolTip(this.trvList, "List of the prospect customers");
            this.trvList.DoubleClick += new System.EventHandler(this.trvList_DoubleClick);
            // 
            // grpSearch
            // 
            this.grpSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpSearch.Controls.Add(this.txtSearch);
            this.grpSearch.Location = new System.Drawing.Point(7, 10);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(185, 50);
            this.grpSearch.TabIndex = 0;
            this.grpSearch.TabStop = false;
            this.grpSearch.Tag = "t";
            this.grpSearch.Text = "Search By";
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSearch.Location = new System.Drawing.Point(8, 20);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(139, 20);
            this.txtSearch.TabIndex = 0;
            // 
            // tabControl1
            // 
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.ImageList = this.imgCollection;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(747, 492);
            this.tabControl1.TabIndex = 0;
            // 
            // ProspectCustomerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 492);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.lblProsCust);
            this.Name = "ProspectCustomerList";
            this.Text = "Prospect Customers";
            this.Load += new System.EventHandler(this.ProspectCustomerList_Load);
            this.grpActionControls.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.grpSearch.ResumeLayout(false);
            this.grpSearch.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox grpActionControls;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label lblProsCust;
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TreeView trvList;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.ImageList imgCollection;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}