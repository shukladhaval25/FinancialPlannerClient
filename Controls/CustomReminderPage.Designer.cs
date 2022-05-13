namespace FinancialPlannerClient.Controls
{
    partial class CustomReminderPage
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
            this.groupOption = new DevExpress.XtraEditors.GroupControl();
            this.cmbOption = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dtTo = new DevExpress.XtraEditors.DateEdit();
            this.dtFrom = new DevExpress.XtraEditors.DateEdit();
            this.btnSearch = new DevExpress.XtraEditors.SimpleButton();
            this.lblOtpion = new DevExpress.XtraEditors.LabelControl();
            this.lblLine = new DevExpress.XtraEditors.LabelControl();
            this.lblTo = new DevExpress.XtraEditors.LabelControl();
            this.lblFromDate = new DevExpress.XtraEditors.LabelControl();
            this.gridControlClients = new DevExpress.XtraGrid.GridControl();
            this.gridViewClient = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupOption)).BeginInit();
            this.groupOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbOption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlClients)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupOption
            // 
            this.groupOption.Controls.Add(this.cmbOption);
            this.groupOption.Controls.Add(this.dtTo);
            this.groupOption.Controls.Add(this.dtFrom);
            this.groupOption.Controls.Add(this.btnSearch);
            this.groupOption.Controls.Add(this.lblOtpion);
            this.groupOption.Controls.Add(this.lblLine);
            this.groupOption.Controls.Add(this.lblTo);
            this.groupOption.Controls.Add(this.lblFromDate);
            this.groupOption.Location = new System.Drawing.Point(12, 16);
            this.groupOption.Name = "groupOption";
            this.groupOption.ShowCaption = false;
            this.groupOption.Size = new System.Drawing.Size(1146, 38);
            this.groupOption.TabIndex = 1;
            this.groupOption.Text = "Option";
            // 
            // cmbOption
            // 
            this.cmbOption.Location = new System.Drawing.Point(623, 10);
            this.cmbOption.Name = "cmbOption";
            this.cmbOption.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbOption.Properties.Items.AddRange(new object[] {
            "PPF",
            "FD",
            "Bond",
            "Date of Birth (Client)"});
            this.cmbOption.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbOption.Size = new System.Drawing.Size(300, 20);
            this.cmbOption.TabIndex = 9;
            // 
            // dtTo
            // 
            this.dtTo.EditValue = null;
            this.dtTo.Location = new System.Drawing.Point(284, 9);
            this.dtTo.Name = "dtTo";
            this.dtTo.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtTo.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtTo.Properties.CalendarTimeProperties.DisplayFormat.FormatString = "d";
            this.dtTo.Properties.CalendarTimeProperties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dtTo.Size = new System.Drawing.Size(178, 20);
            this.dtTo.TabIndex = 7;
            this.dtTo.EditValueChanged += new System.EventHandler(this.dtTo_EditValueChanged);
            this.dtTo.Leave += new System.EventHandler(this.dtTo_Leave);
            // 
            // dtFrom
            // 
            this.dtFrom.EditValue = null;
            this.dtFrom.Location = new System.Drawing.Point(56, 10);
            this.dtFrom.Name = "dtFrom";
            this.dtFrom.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFrom.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtFrom.Size = new System.Drawing.Size(178, 20);
            this.dtFrom.TabIndex = 5;
            this.dtFrom.Leave += new System.EventHandler(this.dtFrom_Leave);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.Location = new System.Drawing.Point(929, 7);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(83, 23);
            this.btnSearch.TabIndex = 11;
            this.btnSearch.Text = "Search";
            this.btnSearch.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Application;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // lblOtpion
            // 
            this.lblOtpion.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOtpion.Appearance.Options.UseFont = true;
            this.lblOtpion.Appearance.Options.UseTextOptions = true;
            this.lblOtpion.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblOtpion.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblOtpion.Location = new System.Drawing.Point(500, 7);
            this.lblOtpion.Name = "lblOtpion";
            this.lblOtpion.Size = new System.Drawing.Size(117, 23);
            this.lblOtpion.TabIndex = 9;
            this.lblOtpion.Text = "Select your option:";
            // 
            // lblLine
            // 
            this.lblLine.Appearance.BackColor = System.Drawing.Color.Gray;
            this.lblLine.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLine.Appearance.Options.UseBackColor = true;
            this.lblLine.Appearance.Options.UseFont = true;
            this.lblLine.Appearance.Options.UseTextOptions = true;
            this.lblLine.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblLine.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblLine.Location = new System.Drawing.Point(480, 4);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(2, 30);
            this.lblLine.TabIndex = 8;
            // 
            // lblTo
            // 
            this.lblTo.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTo.Appearance.Options.UseFont = true;
            this.lblTo.Appearance.Options.UseTextOptions = true;
            this.lblTo.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblTo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTo.Location = new System.Drawing.Point(254, 7);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(24, 23);
            this.lblTo.TabIndex = 6;
            this.lblTo.Text = "To:";
            // 
            // lblFromDate
            // 
            this.lblFromDate.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFromDate.Appearance.Options.UseFont = true;
            this.lblFromDate.Appearance.Options.UseTextOptions = true;
            this.lblFromDate.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblFromDate.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblFromDate.Location = new System.Drawing.Point(8, 7);
            this.lblFromDate.Name = "lblFromDate";
            this.lblFromDate.Size = new System.Drawing.Size(47, 23);
            this.lblFromDate.TabIndex = 4;
            this.lblFromDate.Text = "From :";
            // 
            // gridControlClients
            // 
            this.gridControlClients.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridControlClients.Location = new System.Drawing.Point(12, 60);
            this.gridControlClients.MainView = this.gridViewClient;
            this.gridControlClients.Name = "gridControlClients";
            this.gridControlClients.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.gridControlClients.Size = new System.Drawing.Size(1146, 441);
            this.gridControlClients.TabIndex = 4;
            this.gridControlClients.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewClient});
            // 
            // gridViewClient
            // 
            this.gridViewClient.GridControl = this.gridControlClients;
            this.gridViewClient.Name = "gridViewClient";
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // CustomReminderPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gridControlClients);
            this.Controls.Add(this.groupOption);
            this.Name = "CustomReminderPage";
            this.Size = new System.Drawing.Size(1172, 515);
            ((System.ComponentModel.ISupportInitialize)(this.groupOption)).EndInit();
            this.groupOption.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbOption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtTo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtFrom.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlClients)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupOption;
        private DevExpress.XtraEditors.LabelControl lblOtpion;
        private DevExpress.XtraEditors.LabelControl lblLine;
        private DevExpress.XtraEditors.LabelControl lblTo;
        private DevExpress.XtraEditors.LabelControl lblFromDate;
        private DevExpress.XtraGrid.GridControl gridControlClients;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewClient;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        public DevExpress.XtraEditors.SimpleButton btnSearch;
        private DevExpress.XtraEditors.DateEdit dtTo;
        private DevExpress.XtraEditors.DateEdit dtFrom;
        private DevExpress.XtraEditors.ComboBoxEdit cmbOption;
    }
}
