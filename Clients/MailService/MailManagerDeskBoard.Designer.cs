namespace FinancialPlannerClient.Clients.MailService
{
    partial class MailManagerDeskBoard
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
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement1 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement2 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement3 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            this.tileViewColumnSubject = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumnFrom = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumnDate = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.pnlEmailView = new DevExpress.XtraEditors.PanelControl();
            this.panelMailDetails = new DevExpress.XtraEditors.PanelControl();
            this.webBrowserEmailBody = new System.Windows.Forms.WebBrowser();
            this.lblSubjectValue = new DevExpress.XtraEditors.LabelControl();
            this.lblSubjectlabel = new DevExpress.XtraEditors.LabelControl();
            this.lblEmailDate = new DevExpress.XtraEditors.LabelControl();
            this.lblFromValue = new DevExpress.XtraEditors.LabelControl();
            this.lblFromlabel = new DevExpress.XtraEditors.LabelControl();
            this.gridControlMailList = new DevExpress.XtraGrid.GridControl();
            this.tileViewMailList = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.repositoryItemPictureEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit();
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.splMailList = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.pnlEmailView)).BeginInit();
            this.pnlEmailView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelMailDetails)).BeginInit();
            this.panelMailDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMailList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileViewMailList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splMailList)).BeginInit();
            this.splMailList.Panel1.SuspendLayout();
            this.splMailList.Panel2.SuspendLayout();
            this.splMailList.SuspendLayout();
            this.SuspendLayout();
            // 
            // tileViewColumnSubject
            // 
            this.tileViewColumnSubject.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.tileViewColumnSubject.AppearanceCell.Options.UseForeColor = true;
            this.tileViewColumnSubject.Caption = "Subject";
            this.tileViewColumnSubject.FieldName = "Subject";
            this.tileViewColumnSubject.Name = "tileViewColumnSubject";
            this.tileViewColumnSubject.OptionsColumn.ReadOnly = true;
            this.tileViewColumnSubject.Visible = true;
            this.tileViewColumnSubject.VisibleIndex = 0;
            // 
            // tileViewColumnFrom
            // 
            this.tileViewColumnFrom.Caption = "From";
            this.tileViewColumnFrom.FieldName = "From";
            this.tileViewColumnFrom.Name = "tileViewColumnFrom";
            this.tileViewColumnFrom.Visible = true;
            this.tileViewColumnFrom.VisibleIndex = 1;
            // 
            // tileViewColumnDate
            // 
            this.tileViewColumnDate.Caption = "Date";
            this.tileViewColumnDate.FieldName = "LocalDateStr";
            this.tileViewColumnDate.Name = "tileViewColumnDate";
            this.tileViewColumnDate.Visible = true;
            this.tileViewColumnDate.VisibleIndex = 2;
            // 
            // pnlEmailView
            // 
            this.pnlEmailView.Controls.Add(this.splMailList);
            this.pnlEmailView.Controls.Add(this.treeList1);
            this.pnlEmailView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlEmailView.Location = new System.Drawing.Point(0, 0);
            this.pnlEmailView.Name = "pnlEmailView";
            this.pnlEmailView.Size = new System.Drawing.Size(1110, 661);
            this.pnlEmailView.TabIndex = 7;
            // 
            // panelMailDetails
            // 
            this.panelMailDetails.Controls.Add(this.webBrowserEmailBody);
            this.panelMailDetails.Controls.Add(this.lblSubjectValue);
            this.panelMailDetails.Controls.Add(this.lblSubjectlabel);
            this.panelMailDetails.Controls.Add(this.lblEmailDate);
            this.panelMailDetails.Controls.Add(this.lblFromValue);
            this.panelMailDetails.Controls.Add(this.lblFromlabel);
            this.panelMailDetails.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMailDetails.Location = new System.Drawing.Point(0, 0);
            this.panelMailDetails.Name = "panelMailDetails";
            this.panelMailDetails.Size = new System.Drawing.Size(604, 657);
            this.panelMailDetails.TabIndex = 5;
            // 
            // webBrowserEmailBody
            // 
            this.webBrowserEmailBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowserEmailBody.Location = new System.Drawing.Point(9, 69);
            this.webBrowserEmailBody.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserEmailBody.Name = "webBrowserEmailBody";
            this.webBrowserEmailBody.ScriptErrorsSuppressed = true;
            this.webBrowserEmailBody.Size = new System.Drawing.Size(589, 583);
            this.webBrowserEmailBody.TabIndex = 6;
            // 
            // lblSubjectValue
            // 
            this.lblSubjectValue.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblSubjectValue.Location = new System.Drawing.Point(53, 25);
            this.lblSubjectValue.Name = "lblSubjectValue";
            this.lblSubjectValue.Size = new System.Drawing.Size(405, 13);
            this.lblSubjectValue.TabIndex = 4;
            this.lblSubjectValue.Text = "SubjectValue";
            // 
            // lblSubjectlabel
            // 
            this.lblSubjectlabel.Location = new System.Drawing.Point(9, 24);
            this.lblSubjectlabel.Name = "lblSubjectlabel";
            this.lblSubjectlabel.Size = new System.Drawing.Size(40, 13);
            this.lblSubjectlabel.TabIndex = 3;
            this.lblSubjectlabel.Text = "Subject:";
            // 
            // lblEmailDate
            // 
            this.lblEmailDate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblEmailDate.Location = new System.Drawing.Point(9, 43);
            this.lblEmailDate.Name = "lblEmailDate";
            this.lblEmailDate.Size = new System.Drawing.Size(199, 13);
            this.lblEmailDate.TabIndex = 2;
            this.lblEmailDate.Text = "Date:";
            // 
            // lblFromValue
            // 
            this.lblFromValue.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblFromValue.Location = new System.Drawing.Point(43, 5);
            this.lblFromValue.Name = "lblFromValue";
            this.lblFromValue.Size = new System.Drawing.Size(214, 13);
            this.lblFromValue.TabIndex = 1;
            this.lblFromValue.Text = "From:";
            // 
            // lblFromlabel
            // 
            this.lblFromlabel.Location = new System.Drawing.Point(9, 5);
            this.lblFromlabel.Name = "lblFromlabel";
            this.lblFromlabel.Size = new System.Drawing.Size(28, 13);
            this.lblFromlabel.TabIndex = 0;
            this.lblFromlabel.Text = "From:";
            // 
            // gridControlMailList
            // 
            this.gridControlMailList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlMailList.EmbeddedNavigator.UseWaitCursor = true;
            this.gridControlMailList.Location = new System.Drawing.Point(3, 0);
            this.gridControlMailList.MainView = this.tileViewMailList;
            this.gridControlMailList.Margin = new System.Windows.Forms.Padding(0);
            this.gridControlMailList.Name = "gridControlMailList";
            this.gridControlMailList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemPictureEdit1});
            this.gridControlMailList.Size = new System.Drawing.Size(331, 655);
            this.gridControlMailList.TabIndex = 4;
            this.gridControlMailList.UseWaitCursor = true;
            this.gridControlMailList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tileViewMailList});
            this.gridControlMailList.Click += new System.EventHandler(this.gridControlMailList_Click);
            // 
            // tileViewMailList
            // 
            this.tileViewMailList.Appearance.EmptySpace.BackColor = System.Drawing.Color.Transparent;
            this.tileViewMailList.Appearance.EmptySpace.Options.UseBackColor = true;
            this.tileViewMailList.Appearance.ItemNormal.BackColor = System.Drawing.Color.White;
            this.tileViewMailList.Appearance.ItemNormal.BackColor2 = System.Drawing.Color.White;
            this.tileViewMailList.Appearance.ItemNormal.Options.UseBackColor = true;
            this.tileViewMailList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.tileViewColumnSubject,
            this.tileViewColumnFrom,
            this.tileViewColumnDate});
            this.tileViewMailList.GridControl = this.gridControlMailList;
            this.tileViewMailList.Name = "tileViewMailList";
            this.tileViewMailList.OptionsBehavior.ReadOnly = true;
            this.tileViewMailList.OptionsEditForm.PopupEditFormWidth = 200;
            this.tileViewMailList.OptionsTiles.AllowItemHover = true;
            this.tileViewMailList.OptionsTiles.IndentBetweenGroups = 10;
            this.tileViewMailList.OptionsTiles.IndentBetweenItems = 2;
            this.tileViewMailList.OptionsTiles.ItemPadding = new System.Windows.Forms.Padding(5);
            this.tileViewMailList.OptionsTiles.ItemSize = new System.Drawing.Size(400, 70);
            this.tileViewMailList.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tileViewMailList.OptionsTiles.Padding = new System.Windows.Forms.Padding(5);
            this.tileViewMailList.OptionsTiles.ScrollMode = DevExpress.XtraEditors.TileControlScrollMode.ScrollBar;
            this.tileViewMailList.OptionsTiles.ShowGroupText = false;
            this.tileViewMailList.OptionsTiles.VerticalContentAlignment = DevExpress.Utils.VertAlignment.Top;
            tileViewItemElement1.Appearance.Hovered.BackColor = System.Drawing.Color.Navy;
            tileViewItemElement1.Appearance.Hovered.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            tileViewItemElement1.Appearance.Hovered.Options.UseBackColor = true;
            tileViewItemElement1.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement1.Appearance.Normal.ForeColor = System.Drawing.Color.Navy;
            tileViewItemElement1.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement1.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement1.Appearance.Pressed.BackColor = System.Drawing.Color.White;
            tileViewItemElement1.Appearance.Pressed.BackColor2 = System.Drawing.Color.White;
            tileViewItemElement1.Appearance.Pressed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement1.Appearance.Pressed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            tileViewItemElement1.Appearance.Pressed.Options.UseBackColor = true;
            tileViewItemElement1.Appearance.Pressed.Options.UseFont = true;
            tileViewItemElement1.Appearance.Pressed.Options.UseForeColor = true;
            tileViewItemElement1.Column = this.tileViewColumnSubject;
            tileViewItemElement1.Text = "tileViewColumnSubject";
            tileViewItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            tileViewItemElement1.TextLocation = new System.Drawing.Point(20, 20);
            tileViewItemElement2.Appearance.Pressed.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement2.Appearance.Pressed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(192)))));
            tileViewItemElement2.Appearance.Pressed.Options.UseFont = true;
            tileViewItemElement2.Appearance.Pressed.Options.UseForeColor = true;
            tileViewItemElement2.Column = this.tileViewColumnFrom;
            tileViewItemElement2.Text = "tileViewColumnFrom";
            tileViewItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            tileViewItemElement2.TextLocation = new System.Drawing.Point(0, 5);
            tileViewItemElement3.Column = this.tileViewColumnDate;
            tileViewItemElement3.Text = "tileViewColumnDate";
            tileViewItemElement3.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            tileViewItemElement3.TextLocation = new System.Drawing.Point(0, 45);
            this.tileViewMailList.TileTemplate.Add(tileViewItemElement1);
            this.tileViewMailList.TileTemplate.Add(tileViewItemElement2);
            this.tileViewMailList.TileTemplate.Add(tileViewItemElement3);
            // 
            // repositoryItemPictureEdit1
            // 
            this.repositoryItemPictureEdit1.Name = "repositoryItemPictureEdit1";
            this.repositoryItemPictureEdit1.ZoomAccelerationFactor = 1D;
            // 
            // treeList1
            // 
            this.treeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2});
            this.treeList1.Cursor = System.Windows.Forms.Cursors.Default;
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Left;
            this.treeList1.Location = new System.Drawing.Point(2, 2);
            this.treeList1.Name = "treeList1";
            this.treeList1.BeginUnboundLoad();
            this.treeList1.AppendNode(new object[] {
            "my@gmail.com",
            null}, -1);
            this.treeList1.AppendNode(new object[] {
            "Inbox",
            null}, 0);
            this.treeList1.AppendNode(new object[] {
            "Outbox",
            null}, 0);
            this.treeList1.EndUnboundLoad();
            this.treeList1.OptionsBehavior.PopulateServiceColumns = true;
            this.treeList1.Size = new System.Drawing.Size(164, 657);
            this.treeList1.TabIndex = 3;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "Email";
            this.treeListColumn1.FieldName = "treeListColumn1";
            this.treeListColumn1.MinWidth = 52;
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "treeListColumn2";
            this.treeListColumn2.FieldName = "treeListColumn2";
            this.treeListColumn2.Name = "treeListColumn2";
            // 
            // splMailList
            // 
            this.splMailList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splMailList.Location = new System.Drawing.Point(166, 2);
            this.splMailList.Name = "splMailList";
            // 
            // splMailList.Panel1
            // 
            this.splMailList.Panel1.Controls.Add(this.gridControlMailList);
            this.splMailList.Panel1.UseWaitCursor = true;
            // 
            // splMailList.Panel2
            // 
            this.splMailList.Panel2.Controls.Add(this.panelMailDetails);
            this.splMailList.Size = new System.Drawing.Size(942, 657);
            this.splMailList.SplitterDistance = 334;
            this.splMailList.TabIndex = 6;
            // 
            // MailManagerDeskBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 661);
            this.Controls.Add(this.pnlEmailView);
            this.Name = "MailManagerDeskBoard";
            this.Text = "Mail Manger";
            this.Load += new System.EventHandler(this.MailManagerDeskBoard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlEmailView)).EndInit();
            this.pnlEmailView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelMailDetails)).EndInit();
            this.panelMailDetails.ResumeLayout(false);
            this.panelMailDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMailList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileViewMailList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemPictureEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.splMailList.Panel1.ResumeLayout(false);
            this.splMailList.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splMailList)).EndInit();
            this.splMailList.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlEmailView;
        private DevExpress.XtraEditors.PanelControl panelMailDetails;
        private System.Windows.Forms.WebBrowser webBrowserEmailBody;
        private DevExpress.XtraEditors.LabelControl lblSubjectValue;
        private DevExpress.XtraEditors.LabelControl lblSubjectlabel;
        private DevExpress.XtraEditors.LabelControl lblEmailDate;
        private DevExpress.XtraEditors.LabelControl lblFromValue;
        private DevExpress.XtraEditors.LabelControl lblFromlabel;
        private DevExpress.XtraGrid.GridControl gridControlMailList;
        private DevExpress.XtraGrid.Views.Tile.TileView tileViewMailList;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumnSubject;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumnFrom;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumnDate;
        private DevExpress.XtraEditors.Repository.RepositoryItemPictureEdit repositoryItemPictureEdit1;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private System.Windows.Forms.SplitContainer splMailList;
    }
}