using DevExpress.Utils;
using DevExpress.XtraEditors;
using FinancialPlanner.Common;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.PlannerInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace FinancialPlannerClient.Clients
{
    public class ClientSearch : XtraForm
    {

        private const string CLIENTS_GETALL = "Client/Get";
        private const string CLIENTS_GETBYID = "Client/GetById?id={0}";
        private const string DELETE_CLIENT_API = "Client/Delete";
        private DataTable _dtClient;
        private int _clientId;

        private PanelControl pnlClientSearch;
        private PanelControl panelHeader;
        private SimpleButton btnBack;
        private PanelControl pnlOperationControls;
        private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
        private DevExpress.XtraGrid.GridControl gridControlClients;
        private DevExpress.XtraGrid.Views.Tile.TileView tileViewClients;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumnClientId;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumnName;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumnImage;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumnGender;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumnDOB;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumnPANCARD;
        private SimpleButton btnDelete;
        private SimpleButton btnEdit;
        private SimpleButton btnAdd;
        private SimpleButton btnSelect;
        private SimpleButton btnRefresh;
        private System.ComponentModel.IContainer components;

        public ClientSearch()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientSearch));
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement1 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement2 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement3 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement4 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement5 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement6 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement7 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement8 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.XtraGrid.Views.Tile.TileViewItemElement tileViewItemElement9 = new DevExpress.XtraGrid.Views.Tile.TileViewItemElement();
            DevExpress.DataAccess.Sql.SelectQuery selectQuery1 = new DevExpress.DataAccess.Sql.SelectQuery();
            DevExpress.DataAccess.Sql.Column column1 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression1 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Table table1 = new DevExpress.DataAccess.Sql.Table();
            DevExpress.DataAccess.Sql.Column column2 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression2 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column3 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression3 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column4 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression4 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column5 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression5 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.DataAccess.Sql.Column column6 = new DevExpress.DataAccess.Sql.Column();
            DevExpress.DataAccess.Sql.ColumnExpression columnExpression6 = new DevExpress.DataAccess.Sql.ColumnExpression();
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
            this.tileViewColumnClientId = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumnName = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumnImage = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumnGender = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumnPANCARD = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumnDOB = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.pnlClientSearch = new DevExpress.XtraEditors.PanelControl();
            this.gridControlClients = new DevExpress.XtraGrid.GridControl();
            this.tileViewClients = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
            this.panelHeader = new DevExpress.XtraEditors.PanelControl();
            this.btnBack = new DevExpress.XtraEditors.SimpleButton();
            this.pnlOperationControls = new DevExpress.XtraEditors.PanelControl();
            this.btnRefresh = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelect = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClientSearch)).BeginInit();
            this.pnlClientSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlClients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileViewClients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).BeginInit();
            this.panelHeader.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlOperationControls)).BeginInit();
            this.pnlOperationControls.SuspendLayout();
            this.SuspendLayout();
            // 
            // tileViewColumnClientId
            // 
            this.tileViewColumnClientId.Caption = "Id";
            this.tileViewColumnClientId.FieldName = "ID";
            this.tileViewColumnClientId.Name = "tileViewColumnClientId";
            this.tileViewColumnClientId.Visible = true;
            this.tileViewColumnClientId.VisibleIndex = 0;
            // 
            // tileViewColumnName
            // 
            this.tileViewColumnName.Caption = "Name";
            this.tileViewColumnName.FieldName = "Name";
            this.tileViewColumnName.Name = "tileViewColumnName";
            this.tileViewColumnName.Visible = true;
            this.tileViewColumnName.VisibleIndex = 1;
            // 
            // tileViewColumnImage
            // 
            this.tileViewColumnImage.Caption = "tileViewColumnImage";
            this.tileViewColumnImage.FieldName = "Image";
            this.tileViewColumnImage.Image = ((System.Drawing.Image)(resources.GetObject("tileViewColumnImage.Image")));
            this.tileViewColumnImage.Name = "tileViewColumnImage";
            this.tileViewColumnImage.Visible = true;
            this.tileViewColumnImage.VisibleIndex = 2;
            // 
            // tileViewColumnGender
            // 
            this.tileViewColumnGender.Caption = "Gender";
            this.tileViewColumnGender.FieldName = "Gender";
            this.tileViewColumnGender.Name = "tileViewColumnGender";
            this.tileViewColumnGender.Visible = true;
            this.tileViewColumnGender.VisibleIndex = 3;
            // 
            // tileViewColumnPANCARD
            // 
            this.tileViewColumnPANCARD.Caption = "PANCARD";
            this.tileViewColumnPANCARD.FieldName = "PAN";
            this.tileViewColumnPANCARD.Name = "tileViewColumnPANCARD";
            this.tileViewColumnPANCARD.Visible = true;
            this.tileViewColumnPANCARD.VisibleIndex = 5;
            // 
            // tileViewColumnDOB
            // 
            this.tileViewColumnDOB.Caption = "Date of Birth";
            this.tileViewColumnDOB.DisplayFormat.FormatString = "dd/MM/yyyy";
            this.tileViewColumnDOB.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.tileViewColumnDOB.FieldName = "DOB";
            this.tileViewColumnDOB.Name = "tileViewColumnDOB";
            this.tileViewColumnDOB.OptionsColumn.AllowSize = false;
            this.tileViewColumnDOB.UnboundType = DevExpress.Data.UnboundColumnType.String;
            this.tileViewColumnDOB.Visible = true;
            this.tileViewColumnDOB.VisibleIndex = 4;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AllowFocused = false;
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // pnlClientSearch
            // 
            this.pnlClientSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlClientSearch.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlClientSearch.Controls.Add(this.gridControlClients);
            this.pnlClientSearch.Location = new System.Drawing.Point(0, 56);
            this.pnlClientSearch.Name = "pnlClientSearch";
            this.pnlClientSearch.Size = new System.Drawing.Size(704, 298);
            this.pnlClientSearch.TabIndex = 0;
            // 
            // gridControlClients
            // 
            this.gridControlClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControlClients.Location = new System.Drawing.Point(2, 2);
            this.gridControlClients.MainView = this.tileViewClients;
            this.gridControlClients.Name = "gridControlClients";
            this.gridControlClients.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControlClients.Size = new System.Drawing.Size(700, 294);
            this.gridControlClients.TabIndex = 0;
            this.gridControlClients.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tileViewClients});
            // 
            // tileViewClients
            // 
            this.tileViewClients.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.tileViewColumnClientId,
            this.tileViewColumnName,
            this.tileViewColumnImage,
            this.tileViewColumnGender,
            this.tileViewColumnDOB,
            this.tileViewColumnPANCARD});
            this.tileViewClients.GridControl = this.gridControlClients;
            this.tileViewClients.Name = "tileViewClients";
            this.tileViewClients.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical;
            tileViewItemElement1.Column = this.tileViewColumnClientId;
            tileViewItemElement1.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopCenter;
            tileViewItemElement1.ImageBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            tileViewItemElement1.ImageLocation = new System.Drawing.Point(200, 200);
            tileViewItemElement1.Text = "tileViewColumnClientId";
            tileViewItemElement1.TextVisible = false;
            tileViewItemElement2.Appearance.Hovered.BackColor = System.Drawing.Color.DarkGray;
            tileViewItemElement2.Appearance.Hovered.BackColor2 = System.Drawing.Color.Gainsboro;
            tileViewItemElement2.Appearance.Hovered.BorderColor = System.Drawing.Color.Black;
            tileViewItemElement2.Appearance.Hovered.Options.UseBackColor = true;
            tileViewItemElement2.Appearance.Hovered.Options.UseBorderColor = true;
            tileViewItemElement2.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement2.Appearance.Normal.ForeColor = System.Drawing.Color.SteelBlue;
            tileViewItemElement2.Appearance.Normal.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            tileViewItemElement2.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement2.Appearance.Normal.Options.UseForeColor = true;
            tileViewItemElement2.Appearance.Normal.Options.UseImage = true;
            tileViewItemElement2.Column = this.tileViewColumnName;
            tileViewItemElement2.ImageBorder = DevExpress.XtraEditors.TileItemElementImageBorderMode.SingleBorder;
            tileViewItemElement2.ImageBorderColor = System.Drawing.Color.Transparent;
            tileViewItemElement2.Text = "tileViewColumnName";
            tileViewItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopCenter;
            tileViewItemElement2.TextLocation = new System.Drawing.Point(8, -5);
            tileViewItemElement3.Column = this.tileViewColumnImage;
            tileViewItemElement3.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            tileViewItemElement3.ImageLocation = new System.Drawing.Point(-10, -10);
            tileViewItemElement3.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomOutside;
            tileViewItemElement3.ImageSize = new System.Drawing.Size(100, 120);
            tileViewItemElement3.ImageToTextAlignment = DevExpress.XtraEditors.TileControlImageToTextAlignment.Top;
            tileViewItemElement3.Text = "tileViewColumnImage";
            tileViewItemElement4.AnchorAlignment = DevExpress.Utils.AnchorAlignment.Left;
            tileViewItemElement4.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            tileViewItemElement4.Text = "Gender:";
            tileViewItemElement4.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            tileViewItemElement4.TextLocation = new System.Drawing.Point(100, 40);
            tileViewItemElement5.AnchorAlignment = DevExpress.Utils.AnchorAlignment.Left;
            tileViewItemElement5.Column = this.tileViewColumnGender;
            tileViewItemElement5.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            tileViewItemElement5.ImageLocation = new System.Drawing.Point(180, 450);
            tileViewItemElement5.Text = "tileViewColumnGender";
            tileViewItemElement5.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            tileViewItemElement5.TextLocation = new System.Drawing.Point(145, 40);
            tileViewItemElement6.Text = "PAN:";
            tileViewItemElement6.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            tileViewItemElement6.TextLocation = new System.Drawing.Point(100, 60);
            tileViewItemElement7.Column = this.tileViewColumnPANCARD;
            tileViewItemElement7.Text = "tileViewColumnPANCARD";
            tileViewItemElement7.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            tileViewItemElement7.TextLocation = new System.Drawing.Point(130, 60);
            tileViewItemElement8.Text = "DOB:";
            tileViewItemElement8.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            tileViewItemElement8.TextLocation = new System.Drawing.Point(100, 80);
            tileViewItemElement9.Column = this.tileViewColumnDOB;
            tileViewItemElement9.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            tileViewItemElement9.Text = "tileViewColumnDOB";
            tileViewItemElement9.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.Manual;
            tileViewItemElement9.TextLocation = new System.Drawing.Point(130, 80);
            tileViewItemElement9.Width = 60;
            this.tileViewClients.TileTemplate.Add(tileViewItemElement1);
            this.tileViewClients.TileTemplate.Add(tileViewItemElement2);
            this.tileViewClients.TileTemplate.Add(tileViewItemElement3);
            this.tileViewClients.TileTemplate.Add(tileViewItemElement4);
            this.tileViewClients.TileTemplate.Add(tileViewItemElement5);
            this.tileViewClients.TileTemplate.Add(tileViewItemElement6);
            this.tileViewClients.TileTemplate.Add(tileViewItemElement7);
            this.tileViewClients.TileTemplate.Add(tileViewItemElement8);
            this.tileViewClients.TileTemplate.Add(tileViewItemElement9);
            this.tileViewClients.DoubleClick += new System.EventHandler(this.tileViewClients_DoubleClick);
            // 
            // sqlDataSource1
            // 
            this.sqlDataSource1.ConnectionName = "DESKTOP-58FNOSV\\SQLEXPRESS_FinancialPlanner_Connection";
            this.sqlDataSource1.Name = "sqlDataSource1";
            columnExpression1.ColumnName = "Name";
            table1.MetaSerializable = "30|30|125|381";
            table1.Name = "Client";
            columnExpression1.Table = table1;
            column1.Expression = columnExpression1;
            columnExpression2.ColumnName = "Gender";
            columnExpression2.Table = table1;
            column2.Expression = columnExpression2;
            columnExpression3.ColumnName = "DOB";
            columnExpression3.Table = table1;
            column3.Expression = columnExpression3;
            columnExpression4.ColumnName = "PAN";
            columnExpression4.Table = table1;
            column4.Expression = columnExpression4;
            columnExpression5.ColumnName = "Married";
            columnExpression5.Table = table1;
            column5.Expression = columnExpression5;
            columnExpression6.ColumnName = "Occupation";
            columnExpression6.Table = table1;
            column6.Expression = columnExpression6;
            selectQuery1.Columns.Add(column1);
            selectQuery1.Columns.Add(column2);
            selectQuery1.Columns.Add(column3);
            selectQuery1.Columns.Add(column4);
            selectQuery1.Columns.Add(column5);
            selectQuery1.Columns.Add(column6);
            selectQuery1.Name = "Client";
            selectQuery1.Tables.Add(table1);
            this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            selectQuery1});
            this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
            // 
            // panelHeader
            // 
            this.panelHeader.Controls.Add(this.btnBack);
            this.panelHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHeader.Location = new System.Drawing.Point(0, 0);
            this.panelHeader.Name = "panelHeader";
            this.panelHeader.Size = new System.Drawing.Size(704, 50);
            this.panelHeader.TabIndex = 1;
            // 
            // btnBack
            // 
            this.btnBack.Image = ((System.Drawing.Image)(resources.GetObject("btnBack.Image")));
            this.btnBack.Location = new System.Drawing.Point(5, 10);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(40, 35);
            this.btnBack.TabIndex = 0;
            this.btnBack.ToolTip = "Back to Home";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // pnlOperationControls
            // 
            this.pnlOperationControls.Controls.Add(this.btnRefresh);
            this.pnlOperationControls.Controls.Add(this.btnSelect);
            this.pnlOperationControls.Controls.Add(this.btnDelete);
            this.pnlOperationControls.Controls.Add(this.btnEdit);
            this.pnlOperationControls.Controls.Add(this.btnAdd);
            this.pnlOperationControls.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlOperationControls.Location = new System.Drawing.Point(0, 360);
            this.pnlOperationControls.Name = "pnlOperationControls";
            this.pnlOperationControls.Size = new System.Drawing.Size(704, 35);
            this.pnlOperationControls.TabIndex = 3;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Image = ((System.Drawing.Image)(resources.GetObject("btnRefresh.Image")));
            this.btnRefresh.Location = new System.Drawing.Point(36, 7);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(25, 23);
            toolTipTitleItem1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            toolTipTitleItem1.Appearance.Options.UseImage = true;
            toolTipTitleItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem1.Image")));
            toolTipTitleItem1.Text = "Refesh";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "To refresh clients list click here.";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.btnRefresh.SuperTip = superToolTip1;
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Application;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Image = ((System.Drawing.Image)(resources.GetObject("btnSelect.Image")));
            this.btnSelect.Location = new System.Drawing.Point(5, 7);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(25, 23);
            toolTipTitleItem2.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            toolTipTitleItem2.Appearance.Options.UseImage = true;
            toolTipTitleItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem2.Image")));
            toolTipTitleItem2.Text = "Show Dashborad";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "To view client dashbord for selected client.";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.btnSelect.SuperTip = superToolTip2;
            this.btnSelect.TabIndex = 4;
            this.btnSelect.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Application;
            this.btnSelect.ToolTipTitle = "New Client";
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(674, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(25, 23);
            toolTipTitleItem3.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            toolTipTitleItem3.Appearance.Options.UseImage = true;
            toolTipTitleItem3.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem3.Image")));
            toolTipTitleItem3.Text = "Delete Client";
            toolTipItem3.LeftIndent = 6;
            toolTipItem3.Text = "To delete selected client record click here.";
            superToolTip3.Items.Add(toolTipTitleItem3);
            superToolTip3.Items.Add(toolTipItem3);
            this.btnDelete.SuperTip = superToolTip3;
            this.btnDelete.TabIndex = 3;
            this.btnDelete.ToolTip = "Delete Client";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(643, 5);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(25, 23);
            toolTipTitleItem4.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image4")));
            toolTipTitleItem4.Appearance.Options.UseImage = true;
            toolTipTitleItem4.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem4.Image")));
            toolTipTitleItem4.Text = "Edit Customer";
            toolTipItem4.LeftIndent = 6;
            toolTipItem4.Text = "To modify selected client information click here.";
            superToolTip4.Items.Add(toolTipTitleItem4);
            superToolTip4.Items.Add(toolTipItem4);
            this.btnEdit.SuperTip = superToolTip4;
            this.btnEdit.TabIndex = 2;
            this.btnEdit.ToolTip = "Edit Client";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(612, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 23);
            toolTipTitleItem5.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image5")));
            toolTipTitleItem5.Appearance.Options.UseImage = true;
            toolTipTitleItem5.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem5.Image")));
            toolTipTitleItem5.Text = "New Client";
            toolTipItem5.LeftIndent = 6;
            toolTipItem5.Text = "To add new client inforamtion click here.";
            superToolTip5.Items.Add(toolTipTitleItem5);
            superToolTip5.Items.Add(toolTipItem5);
            this.btnAdd.SuperTip = superToolTip5;
            this.btnAdd.TabIndex = 1;
            this.btnAdd.ToolTip = "Add new client";
            this.btnAdd.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Application;
            this.btnAdd.ToolTipTitle = "New Client";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // ClientSearch
            // 
            this.ClientSize = new System.Drawing.Size(704, 395);
            this.Controls.Add(this.pnlOperationControls);
            this.Controls.Add(this.panelHeader);
            this.Controls.Add(this.pnlClientSearch);
            this.MinimizeBox = false;
            this.Name = "ClientSearch";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Clients";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.ClientSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlClientSearch)).EndInit();
            this.pnlClientSearch.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlClients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileViewClients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelHeader)).EndInit();
            this.panelHeader.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlOperationControls)).EndInit();
            this.pnlOperationControls.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void loadCustomerData()
        {            
            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
            string apiurl = Program.WebServiceUrl + "/" + CLIENTS_GETALL;

            RestAPIExecutor restApiExecutor = new RestAPIExecutor();

            var restResult = restApiExecutor.Execute<List<Client>>(apiurl, null, "GET");

            if (jsonSerialization.IsValidJson(restResult.ToString()))
            {
                var clientColleection = jsonSerialization.DeserializeFromString<List<Client>>(restResult.ToString());
                _dtClient = ListtoDataTable.ToDataTable(clientColleection);
                fillClientGridView(_dtClient);
            }
            else
            {
                XtraMessageBox.Show(restResult.ToString(), "Error");
            }
        }

        private void fillClientGridView(DataTable dtClient)
        {
            _dtClient.Columns.Add("Image", typeof(Image));
            for (int i = 0; i <= _dtClient.Rows.Count - 1; i++)
            {
                if (_dtClient.Rows[i]["ImageData"] != System.DBNull.Value)
                    _dtClient.Rows[i]["Image"] = converToImageFromBase64String(_dtClient.Rows[i]["ImageData"].ToString());
                else
                    _dtClient.Rows[i]["Image"] = Properties.Resources.icons8_customer_30;
            }
            gridControlClients.DataSource = _dtClient;
            gridControlClients.RefreshDataSource();
        }

        private Image converToImageFromBase64String(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }

        private void ClientSearch_Load(object sender, EventArgs e)
        {
            WaitDialogForm waitdlg = new WaitDialogForm("Loading Data...");            
            loadCustomerData();
            waitdlg.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Ignore;
            this.Close();
        }

        private void tileViewClients_DoubleClick(object sender, EventArgs e)
        {
            if (tileViewClients.FocusedRowHandle >= 0)
            {
                int rowIndex = tileViewClients.FocusedRowHandle;
                _clientId = int.Parse(tileViewClients.GetFocusedRowCellValue("ID").ToString());
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
        public Client GetSelectedClient()
        {
            Client client = new Client();
            DataRow[] drs =  _dtClient.Select("ID = '" + _clientId.ToString() + "'");
            if (drs.Length > 0)
            {
                client = converToClient(drs[0]);
            }
            return client;
        }

        private Client converToClient(DataRow dataRow)
        {
            Client client = new Client();
            if (dataRow != null)
            {
                client.ID = int.Parse(dataRow.Field<string>("ID"));
                client.Name = dataRow.Field<string>("Name");
                client.FatherName = dataRow.Field<string>("FatherName");
                client.MotherName = dataRow.Field<string>("MotherName");
                client.IsMarried = bool.Parse(dataRow.Field<string>("IsMarried").ToString());
                if (dataRow.Field<string>("MarriageAnniversary") != null)
                client.MarriageAnniversary = DateTime.Parse(dataRow.Field<string>("MarriageAnniversary"));// == null ?  null : dataRow.Field<DateTime?>("MarriageAnniversary"));
                client.PAN = dataRow.Field<string>("PAN");
                client.Aadhar = dataRow.Field<string>("AADHAR");
                client.Occupation = dataRow.Field<string>("Occupation");
                client.DOB = DateTime.Parse(dataRow.Field<string>("DOB").ToString());
                client.Gender = dataRow.Field<string>("Gender");
                client.PlaceOfBirth = dataRow.Field<string>("PlaceOfBirth");
                client.IncomeSlab = dataRow.Field<string>("IncomeSlab");
                client.ImagePath = dataRow.Field<string>("ImagePath");
                client.ImageData = dataRow.Field<string>("ImageData");
                client.UpdatedByUserName = Program.CurrentUser.UserName;
            }
            return client;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            tileViewClients_DoubleClick(sender, e);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (tileViewClients.FocusedRowHandle >= 0)
            {
                int rowIndex = tileViewClients.FocusedRowHandle;
                _clientId = int.Parse(tileViewClients.GetFocusedRowCellValue("ID").ToString());
            }

            Client client = GetSelectedClient();
            if (client == null)
                XtraMessageBox.Show("Please select client.");
            showClientDetails(client);

        }

        private void showClientDetails(Client client)
        {
            ClientDetails clientDetails = new ClientDetails(client);
            clientDetails.ShowDialog();
            //if (clientDetails.DialogResult == System.Windows.Forms.DialogResult.OK)
            //{
            //    loadCustomerData();
            //}
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            showClientDetails(new Client());
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadCustomerData();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (tileViewClients.FocusedRowHandle >= 0)
            {
                int rowIndex = tileViewClients.FocusedRowHandle;
                _clientId = int.Parse(tileViewClients.GetFocusedRowCellValue("ID").ToString());
            }
            Client client = GetSelectedClient();
            if (client == null)
                XtraMessageBox.Show("Please select client.");
            else
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this client?",
                    "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ClientPersonalInfo clientPersonalInfo = new ClientPersonalInfo();
                    clientPersonalInfo.DeleteClient(client);
                }
            }
        }
    }
}
