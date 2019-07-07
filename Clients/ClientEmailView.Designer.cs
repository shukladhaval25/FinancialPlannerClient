namespace FinancialPlannerClient.Clients
{
    partial class ClientEmailView
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
            this.pnlMainEmailContainer = new DevExpress.XtraEditors.PanelControl();
            this.splitEmailContainer = new DevExpress.XtraEditors.SplitContainerControl();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.ClientEmailID = new DevExpress.XtraTreeList.Columns.TreeListBand();
            this.treeListBand1 = new DevExpress.XtraTreeList.Columns.TreeListBand();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.splitEmailDetailContainer = new DevExpress.XtraEditors.SplitContainerControl();
            this.gridEmailListControl = new DevExpress.XtraGrid.GridControl();
            this.grdEmailListView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.pnlActualEmailView = new DevExpress.XtraEditors.PanelControl();
            this.gridEmailViewControl = new DevExpress.XtraGrid.GridControl();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMainEmailContainer)).BeginInit();
            this.pnlMainEmailContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitEmailContainer)).BeginInit();
            this.splitEmailContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitEmailDetailContainer)).BeginInit();
            this.splitEmailDetailContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmailListControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmailListView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlActualEmailView)).BeginInit();
            this.pnlActualEmailView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmailViewControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMainEmailContainer
            // 
            this.pnlMainEmailContainer.Controls.Add(this.splitEmailContainer);
            this.pnlMainEmailContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMainEmailContainer.Location = new System.Drawing.Point(0, 0);
            this.pnlMainEmailContainer.Name = "pnlMainEmailContainer";
            this.pnlMainEmailContainer.Size = new System.Drawing.Size(867, 359);
            this.pnlMainEmailContainer.TabIndex = 0;
            // 
            // splitEmailContainer
            // 
            this.splitEmailContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitEmailContainer.Location = new System.Drawing.Point(2, 2);
            this.splitEmailContainer.Name = "splitEmailContainer";
            this.splitEmailContainer.Panel1.Controls.Add(this.treeList1);
            this.splitEmailContainer.Panel1.Text = "Panel1";
            this.splitEmailContainer.Panel2.Controls.Add(this.splitEmailDetailContainer);
            this.splitEmailContainer.Panel2.Text = "Panel2";
            this.splitEmailContainer.Size = new System.Drawing.Size(863, 355);
            this.splitEmailContainer.SplitterPosition = 124;
            this.splitEmailContainer.TabIndex = 0;
            this.splitEmailContainer.Text = "splitContainerControl1";
            // 
            // treeList1
            // 
            this.treeList1.Bands.AddRange(new DevExpress.XtraTreeList.Columns.TreeListBand[] {
            this.ClientEmailID,
            this.treeListBand1});
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
            this.treeList1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.Location = new System.Drawing.Point(0, 0);
            this.treeList1.Name = "treeList1";
            this.treeList1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2});
            this.treeList1.Size = new System.Drawing.Size(124, 355);
            this.treeList1.TabIndex = 0;
            // 
            // ClientEmailID
            // 
            this.ClientEmailID.Caption = "ClientEmail";
            this.ClientEmailID.Name = "ClientEmailID";
            this.ClientEmailID.Visible = false;
            // 
            // treeListBand1
            // 
            this.treeListBand1.Caption = "treeListBand1";
            this.treeListBand1.Name = "treeListBand1";
            this.treeListBand1.Visible = false;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "treeListColumn1";
            this.treeListColumn1.FieldName = "treeListColumn1";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "treeListColumn2";
            this.treeListColumn2.FieldName = "treeListColumn2";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 0;
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            this.repositoryItemTextEdit1.NullText = "Text1";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // splitEmailDetailContainer
            // 
            this.splitEmailDetailContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitEmailDetailContainer.Location = new System.Drawing.Point(0, 0);
            this.splitEmailDetailContainer.Name = "splitEmailDetailContainer";
            this.splitEmailDetailContainer.Panel1.Controls.Add(this.gridEmailListControl);
            this.splitEmailDetailContainer.Panel1.Text = "Panel1";
            this.splitEmailDetailContainer.Panel2.Controls.Add(this.pnlActualEmailView);
            this.splitEmailDetailContainer.Panel2.Text = "Panel2";
            this.splitEmailDetailContainer.Size = new System.Drawing.Size(734, 355);
            this.splitEmailDetailContainer.SplitterPosition = 183;
            this.splitEmailDetailContainer.TabIndex = 0;
            this.splitEmailDetailContainer.Text = "splitContainerControl1";
            // 
            // gridEmailListControl
            // 
            this.gridEmailListControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEmailListControl.Location = new System.Drawing.Point(0, 0);
            this.gridEmailListControl.MainView = this.grdEmailListView;
            this.gridEmailListControl.Name = "gridEmailListControl";
            this.gridEmailListControl.Size = new System.Drawing.Size(183, 355);
            this.gridEmailListControl.TabIndex = 0;
            this.gridEmailListControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdEmailListView});
            // 
            // grdEmailListView
            // 
            this.grdEmailListView.GridControl = this.gridEmailListControl;
            this.grdEmailListView.Name = "grdEmailListView";
            // 
            // pnlActualEmailView
            // 
            this.pnlActualEmailView.Controls.Add(this.gridEmailViewControl);
            this.pnlActualEmailView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlActualEmailView.Location = new System.Drawing.Point(0, 0);
            this.pnlActualEmailView.Name = "pnlActualEmailView";
            this.pnlActualEmailView.Size = new System.Drawing.Size(546, 355);
            this.pnlActualEmailView.TabIndex = 0;
            // 
            // gridEmailViewControl
            // 
            this.gridEmailViewControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridEmailViewControl.Location = new System.Drawing.Point(2, 2);
            this.gridEmailViewControl.MainView = this.gridView2;
            this.gridEmailViewControl.Name = "gridEmailViewControl";
            this.gridEmailViewControl.Size = new System.Drawing.Size(542, 351);
            this.gridEmailViewControl.TabIndex = 1;
            this.gridEmailViewControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView2});
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridEmailViewControl;
            this.gridView2.Name = "gridView2";
            // 
            // ClientEmailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMainEmailContainer);
            this.Name = "ClientEmailView";
            this.Size = new System.Drawing.Size(867, 359);
            this.Load += new System.EventHandler(this.ClientEmailView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMainEmailContainer)).EndInit();
            this.pnlMainEmailContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitEmailContainer)).EndInit();
            this.splitEmailContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitEmailDetailContainer)).EndInit();
            this.splitEmailDetailContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEmailListControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdEmailListView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlActualEmailView)).EndInit();
            this.pnlActualEmailView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridEmailViewControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlMainEmailContainer;
        private DevExpress.XtraEditors.SplitContainerControl splitEmailContainer;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraEditors.SplitContainerControl splitEmailDetailContainer;
        private DevExpress.XtraGrid.GridControl gridEmailListControl;
        private DevExpress.XtraGrid.Views.Grid.GridView grdEmailListView;
        private DevExpress.XtraEditors.PanelControl pnlActualEmailView;
        private DevExpress.XtraGrid.GridControl gridEmailViewControl;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraTreeList.Columns.TreeListBand ClientEmailID;
        private DevExpress.XtraTreeList.Columns.TreeListBand treeListBand1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
    }
}
