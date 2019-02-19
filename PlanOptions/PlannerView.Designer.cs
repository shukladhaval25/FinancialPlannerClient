namespace FinancialPlannerClient.PlanOptions
{
    partial class PlannerView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlannerView));
            DevExpress.Utils.SuperToolTip superToolTip11 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem11 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem11 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip12 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem12 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem12 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip13 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem13 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem13 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip14 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem14 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem14 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip15 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem15 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem15 = new DevExpress.Utils.ToolTipItem();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lstPlanner = new DevExpress.XtraEditors.ListBoxControl();
            this.tabPlanner = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabNavigationPagePlanner = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.cmbEndMonth = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.cmbStartMonth = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtEndDate = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.dtStartDate = new DevExpress.XtraEditors.DateEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtPlanName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.tabNavigationPageManagedBy = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.memoDescription = new DevExpress.XtraEditors.MemoEdit();
            this.labelControl8 = new DevExpress.XtraEditors.LabelControl();
            this.cmbManagedBy = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnClosePlanoptions = new DevExpress.XtraEditors.SimpleButton();
            this.btnSavePlanoption = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.lstPlanner)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPlanner)).BeginInit();
            this.tabPlanner.SuspendLayout();
            this.tabNavigationPagePlanner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEndMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStartMonth.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlanName.Properties)).BeginInit();
            this.tabNavigationPageManagedBy.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbManagedBy.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(12, 2);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(97, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Planner Details";
            // 
            // lstPlanner
            // 
            this.lstPlanner.Cursor = System.Windows.Forms.Cursors.Default;
            this.lstPlanner.Location = new System.Drawing.Point(12, 41);
            this.lstPlanner.Name = "lstPlanner";
            this.lstPlanner.Size = new System.Drawing.Size(187, 225);
            this.lstPlanner.TabIndex = 1;
            this.lstPlanner.SelectedIndexChanged += new System.EventHandler(this.lstPlanner_SelectedIndexChanged);
            // 
            // tabPlanner
            // 
            this.tabPlanner.Controls.Add(this.tabNavigationPagePlanner);
            this.tabPlanner.Controls.Add(this.tabNavigationPageManagedBy);
            this.tabPlanner.Location = new System.Drawing.Point(206, 41);
            this.tabPlanner.Name = "tabPlanner";
            this.tabPlanner.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNavigationPagePlanner,
            this.tabNavigationPageManagedBy});
            this.tabPlanner.RegularSize = new System.Drawing.Size(570, 225);
            this.tabPlanner.SelectedPage = this.tabNavigationPagePlanner;
            this.tabPlanner.Size = new System.Drawing.Size(570, 225);
            this.tabPlanner.TabIndex = 2;
            this.tabPlanner.Text = "tabPane1";
            // 
            // tabNavigationPagePlanner
            // 
            this.tabNavigationPagePlanner.Caption = "Planner Information";
            this.tabNavigationPagePlanner.Controls.Add(this.cmbEndMonth);
            this.tabNavigationPagePlanner.Controls.Add(this.labelControl6);
            this.tabNavigationPagePlanner.Controls.Add(this.cmbStartMonth);
            this.tabNavigationPagePlanner.Controls.Add(this.labelControl5);
            this.tabNavigationPagePlanner.Controls.Add(this.txtEndDate);
            this.tabNavigationPagePlanner.Controls.Add(this.labelControl4);
            this.tabNavigationPagePlanner.Controls.Add(this.dtStartDate);
            this.tabNavigationPagePlanner.Controls.Add(this.labelControl3);
            this.tabNavigationPagePlanner.Controls.Add(this.txtPlanName);
            this.tabNavigationPagePlanner.Controls.Add(this.labelControl2);
            this.tabNavigationPagePlanner.Image = ((System.Drawing.Image)(resources.GetObject("tabNavigationPagePlanner.Image")));
            this.tabNavigationPagePlanner.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabNavigationPagePlanner.Name = "tabNavigationPagePlanner";
            this.tabNavigationPagePlanner.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabNavigationPagePlanner.Size = new System.Drawing.Size(552, 177);
            // 
            // cmbEndMonth
            // 
            this.cmbEndMonth.Location = new System.Drawing.Point(317, 123);
            this.cmbEndMonth.Name = "cmbEndMonth";
            this.cmbEndMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbEndMonth.Properties.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmbEndMonth.Properties.ReadOnly = true;
            this.cmbEndMonth.Size = new System.Drawing.Size(178, 20);
            this.cmbEndMonth.TabIndex = 9;
            // 
            // labelControl6
            // 
            this.labelControl6.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl6.Location = new System.Drawing.Point(332, 104);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(151, 13);
            this.labelControl6.TabIndex = 8;
            this.labelControl6.Text = "Calculation Start From Month:";
            // 
            // cmbStartMonth
            // 
            this.cmbStartMonth.Location = new System.Drawing.Point(118, 123);
            this.cmbStartMonth.Name = "cmbStartMonth";
            this.cmbStartMonth.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbStartMonth.Properties.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "September",
            "October",
            "November",
            "December"});
            this.cmbStartMonth.Size = new System.Drawing.Size(178, 20);
            this.cmbStartMonth.TabIndex = 7;
            this.cmbStartMonth.SelectedIndexChanged += new System.EventHandler(this.cmbStartMonth_SelectedIndexChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl5.Location = new System.Drawing.Point(132, 104);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(151, 13);
            this.labelControl5.TabIndex = 6;
            this.labelControl5.Text = "Calculation Start From Month:";
            // 
            // txtEndDate
            // 
            this.txtEndDate.Location = new System.Drawing.Point(117, 72);
            this.txtEndDate.Name = "txtEndDate";
            this.txtEndDate.Properties.DisplayFormat.FormatString = "d";
            this.txtEndDate.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.txtEndDate.Properties.ReadOnly = true;
            this.txtEndDate.Size = new System.Drawing.Size(178, 20);
            this.txtEndDate.TabIndex = 5;
            // 
            // labelControl4
            // 
            this.labelControl4.Location = new System.Drawing.Point(20, 75);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(48, 13);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "End Date:";
            // 
            // dtStartDate
            // 
            this.dtStartDate.EditValue = null;
            this.dtStartDate.Location = new System.Drawing.Point(117, 46);
            this.dtStartDate.Name = "dtStartDate";
            this.dtStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtStartDate.Size = new System.Drawing.Size(178, 20);
            this.dtStartDate.TabIndex = 3;
            this.dtStartDate.TextChanged += new System.EventHandler(this.dtStartDate_TextChanged);
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(20, 49);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(54, 13);
            this.labelControl3.TabIndex = 2;
            this.labelControl3.Text = "Start Date:";
            // 
            // txtPlanName
            // 
            this.txtPlanName.Location = new System.Drawing.Point(117, 20);
            this.txtPlanName.Name = "txtPlanName";
            this.txtPlanName.Size = new System.Drawing.Size(178, 20);
            this.txtPlanName.TabIndex = 1;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(20, 23);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(54, 13);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "Plan Name:";
            // 
            // tabNavigationPageManagedBy
            // 
            this.tabNavigationPageManagedBy.Caption = "Manager Information";
            this.tabNavigationPageManagedBy.Controls.Add(this.memoDescription);
            this.tabNavigationPageManagedBy.Controls.Add(this.labelControl8);
            this.tabNavigationPageManagedBy.Controls.Add(this.cmbManagedBy);
            this.tabNavigationPageManagedBy.Controls.Add(this.labelControl7);
            this.tabNavigationPageManagedBy.Image = ((System.Drawing.Image)(resources.GetObject("tabNavigationPageManagedBy.Image")));
            this.tabNavigationPageManagedBy.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabNavigationPageManagedBy.Name = "tabNavigationPageManagedBy";
            this.tabNavigationPageManagedBy.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabNavigationPageManagedBy.Size = new System.Drawing.Size(552, 177);
            // 
            // memoDescription
            // 
            this.memoDescription.Location = new System.Drawing.Point(12, 92);
            this.memoDescription.Name = "memoDescription";
            this.memoDescription.Size = new System.Drawing.Size(528, 73);
            this.memoDescription.TabIndex = 11;
            // 
            // labelControl8
            // 
            this.labelControl8.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl8.Location = new System.Drawing.Point(12, 72);
            this.labelControl8.Name = "labelControl8";
            this.labelControl8.Size = new System.Drawing.Size(151, 13);
            this.labelControl8.TabIndex = 10;
            this.labelControl8.Text = "Description:";
            // 
            // cmbManagedBy
            // 
            this.cmbManagedBy.Location = new System.Drawing.Point(12, 36);
            this.cmbManagedBy.Name = "cmbManagedBy";
            this.cmbManagedBy.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbManagedBy.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbManagedBy.Size = new System.Drawing.Size(178, 20);
            this.cmbManagedBy.TabIndex = 9;
            this.cmbManagedBy.SelectedIndexChanged += new System.EventHandler(this.cmbManagedBy_SelectedIndexChanged);
            // 
            // labelControl7
            // 
            this.labelControl7.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.labelControl7.Location = new System.Drawing.Point(12, 17);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(151, 13);
            this.labelControl7.TabIndex = 8;
            this.labelControl7.Text = "Plan Managed By:";
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(96, 272);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(25, 23);
            toolTipTitleItem11.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            toolTipTitleItem11.Appearance.Options.UseImage = true;
            toolTipTitleItem11.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem11.Image")));
            toolTipTitleItem11.Text = "Delete plan";
            toolTipItem11.LeftIndent = 6;
            toolTipItem11.Text = "To delete selected plan option click here.";
            superToolTip11.Items.Add(toolTipTitleItem11);
            superToolTip11.Items.Add(toolTipItem11);
            this.btnDelete.SuperTip = superToolTip11;
            this.btnDelete.TabIndex = 10;
            this.btnDelete.ToolTip = "Delete Client";
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(174, 272);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(25, 23);
            toolTipTitleItem12.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            toolTipTitleItem12.Appearance.Options.UseImage = true;
            toolTipTitleItem12.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem12.Image")));
            toolTipTitleItem12.Text = "Edit plan";
            toolTipItem12.LeftIndent = 6;
            toolTipItem12.Text = "To modify selected plan information click here.";
            superToolTip12.Items.Add(toolTipTitleItem12);
            superToolTip12.Items.Add(toolTipItem12);
            this.btnEdit.SuperTip = superToolTip12;
            this.btnEdit.TabIndex = 9;
            this.btnEdit.ToolTip = "Edit Client";
            this.btnEdit.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(65, 272);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(25, 23);
            toolTipTitleItem13.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            toolTipTitleItem13.Appearance.Options.UseImage = true;
            toolTipTitleItem13.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem13.Image")));
            toolTipTitleItem13.Text = "New Plan";
            toolTipItem13.LeftIndent = 6;
            toolTipItem13.Text = "To add new plan for client click here.";
            superToolTip13.Items.Add(toolTipTitleItem13);
            superToolTip13.Items.Add(toolTipItem13);
            this.btnAdd.SuperTip = superToolTip13;
            this.btnAdd.TabIndex = 8;
            this.btnAdd.ToolTip = "Add new client";
            this.btnAdd.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Application;
            this.btnAdd.ToolTipTitle = "New Client";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnClosePlanoptions
            // 
            this.btnClosePlanoptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClosePlanoptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClosePlanoptions.Image")));
            this.btnClosePlanoptions.Location = new System.Drawing.Point(688, 272);
            this.btnClosePlanoptions.Name = "btnClosePlanoptions";
            this.btnClosePlanoptions.Size = new System.Drawing.Size(88, 23);
            toolTipTitleItem14.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            toolTipTitleItem14.Appearance.Options.UseImage = true;
            toolTipTitleItem14.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem14.Image")));
            toolTipTitleItem14.Text = "Cancel";
            toolTipItem14.LeftIndent = 6;
            toolTipItem14.Text = "To close client information without saving any information click here.";
            superToolTip14.Items.Add(toolTipTitleItem14);
            superToolTip14.Items.Add(toolTipItem14);
            this.btnClosePlanoptions.SuperTip = superToolTip14;
            this.btnClosePlanoptions.TabIndex = 26;
            this.btnClosePlanoptions.Text = "Close";
            this.btnClosePlanoptions.Click += new System.EventHandler(this.btnClosePlanoptions_Click);
            // 
            // btnSavePlanoption
            // 
            this.btnSavePlanoption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSavePlanoption.Image = ((System.Drawing.Image)(resources.GetObject("btnSavePlanoption.Image")));
            this.btnSavePlanoption.Location = new System.Drawing.Point(594, 272);
            this.btnSavePlanoption.Name = "btnSavePlanoption";
            this.btnSavePlanoption.Size = new System.Drawing.Size(88, 23);
            toolTipTitleItem15.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image4")));
            toolTipTitleItem15.Appearance.Options.UseImage = true;
            toolTipTitleItem15.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem15.Image")));
            toolTipTitleItem15.Text = "Save";
            toolTipItem15.LeftIndent = 6;
            toolTipItem15.Text = "To save client infroamtion click here.";
            superToolTip15.Items.Add(toolTipTitleItem15);
            superToolTip15.Items.Add(toolTipItem15);
            this.btnSavePlanoption.SuperTip = superToolTip15;
            this.btnSavePlanoption.TabIndex = 25;
            this.btnSavePlanoption.Text = "Save";
            this.btnSavePlanoption.Click += new System.EventHandler(this.btnSavePlanoption_Click);
            // 
            // PlannerView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(788, 302);
            this.Controls.Add(this.btnClosePlanoptions);
            this.Controls.Add(this.btnSavePlanoption);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.tabPlanner);
            this.Controls.Add(this.lstPlanner);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PlannerView";
            this.Text = "Planner Information";
            this.Load += new System.EventHandler(this.PlannerView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lstPlanner)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabPlanner)).EndInit();
            this.tabPlanner.ResumeLayout(false);
            this.tabNavigationPagePlanner.ResumeLayout(false);
            this.tabNavigationPagePlanner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbEndMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbStartMonth.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPlanName.Properties)).EndInit();
            this.tabNavigationPageManagedBy.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbManagedBy.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ListBoxControl lstPlanner;
        private DevExpress.XtraBars.Navigation.TabPane tabPlanner;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPagePlanner;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPageManagedBy;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtPlanName;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.DateEdit dtStartDate;
        private DevExpress.XtraEditors.TextEdit txtEndDate;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.ComboBoxEdit cmbStartMonth;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.ComboBoxEdit cmbEndMonth;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.MemoEdit memoDescription;
        private DevExpress.XtraEditors.LabelControl labelControl8;
        private DevExpress.XtraEditors.ComboBoxEdit cmbManagedBy;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnClosePlanoptions;
        private DevExpress.XtraEditors.SimpleButton btnSavePlanoption;
    }
}

