namespace FinancialPlannerClient.PlanOptions
{
    partial class RecomendationView
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
            DevExpress.Utils.SuperToolTip superToolTip11 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem11 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem11 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip12 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem12 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem12 = new DevExpress.Utils.ToolTipItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RecomendationView));
            DevExpress.Utils.SuperToolTip superToolTip9 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem9 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem9 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip10 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem10 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem10 = new DevExpress.Utils.ToolTipItem();
            this.tabRecomendation = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabNavigationPageInsuranceRecomendation = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.tabNavigationPagePersonalAccident = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.tabNavigationPageOthers = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.gridControlOthers = new DevExpress.XtraGrid.GridControl();
            this.gridViewOthers = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grpItem = new DevExpress.XtraEditors.GroupControl();
            this.txtReligion = new DevExpress.XtraEditors.TextEdit();
            this.lblReligion = new DevExpress.XtraEditors.LabelControl();
            this.txtName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnSave = new DevExpress.XtraEditors.SimpleButton();
            this.gridMOMPoints = new DevExpress.XtraGrid.GridControl();
            this.gridViewMOMPoints = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnInsuranceCompany = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnInsuranceCompanyId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTerm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnSumAssured = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnPremium = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemComboBoxInsuranceCompany = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            this.btnRemoveMoMPoints = new DevExpress.XtraEditors.SimpleButton();
            this.btnAddMoMPoints = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.tabRecomendation)).BeginInit();
            this.tabRecomendation.SuspendLayout();
            this.tabNavigationPageInsuranceRecomendation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOthers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOthers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpItem)).BeginInit();
            this.grpItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReligion.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMOMPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMOMPoints)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxInsuranceCompany)).BeginInit();
            this.SuspendLayout();
            // 
            // tabRecomendation
            // 
            this.tabRecomendation.Controls.Add(this.tabNavigationPageInsuranceRecomendation);
            this.tabRecomendation.Controls.Add(this.tabNavigationPagePersonalAccident);
            this.tabRecomendation.Controls.Add(this.tabNavigationPageOthers);
            this.tabRecomendation.Location = new System.Drawing.Point(2, 12);
            this.tabRecomendation.Name = "tabRecomendation";
            this.tabRecomendation.PageProperties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabRecomendation.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNavigationPageInsuranceRecomendation,
            this.tabNavigationPagePersonalAccident,
            this.tabNavigationPageOthers});
            this.tabRecomendation.RegularSize = new System.Drawing.Size(869, 426);
            this.tabRecomendation.SelectedPage = this.tabNavigationPageInsuranceRecomendation;
            this.tabRecomendation.Size = new System.Drawing.Size(869, 426);
            this.tabRecomendation.TabIndex = 30;
            this.tabRecomendation.Text = "Insurance Recomendation";
            // 
            // tabNavigationPageInsuranceRecomendation
            // 
            this.tabNavigationPageInsuranceRecomendation.AutoSize = true;
            this.tabNavigationPageInsuranceRecomendation.Caption = "Insurance Recomendation";
            this.tabNavigationPageInsuranceRecomendation.Controls.Add(this.grpItem);
            this.tabNavigationPageInsuranceRecomendation.Controls.Add(this.gridControlOthers);
            this.tabNavigationPageInsuranceRecomendation.Image = ((System.Drawing.Image)(resources.GetObject("tabNavigationPageInsuranceRecomendation.Image")));
            this.tabNavigationPageInsuranceRecomendation.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabNavigationPageInsuranceRecomendation.Name = "tabNavigationPageInsuranceRecomendation";
            this.tabNavigationPageInsuranceRecomendation.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabNavigationPageInsuranceRecomendation.Size = new System.Drawing.Size(856, 378);
            // 
            // tabNavigationPagePersonalAccident
            // 
            this.tabNavigationPagePersonalAccident.Caption = "Personal Accident";
            this.tabNavigationPagePersonalAccident.Image = ((System.Drawing.Image)(resources.GetObject("tabNavigationPagePersonalAccident.Image")));
            this.tabNavigationPagePersonalAccident.Name = "tabNavigationPagePersonalAccident";
            this.tabNavigationPagePersonalAccident.Size = new System.Drawing.Size(869, 426);
            // 
            // tabNavigationPageOthers
            // 
            this.tabNavigationPageOthers.Caption = "Others";
            this.tabNavigationPageOthers.Image = ((System.Drawing.Image)(resources.GetObject("tabNavigationPageOthers.Image")));
            this.tabNavigationPageOthers.Name = "tabNavigationPageOthers";
            this.tabNavigationPageOthers.Size = new System.Drawing.Size(869, 426);
            // 
            // gridControlOthers
            // 
            this.gridControlOthers.Location = new System.Drawing.Point(3, 3);
            this.gridControlOthers.MainView = this.gridViewOthers;
            this.gridControlOthers.Name = "gridControlOthers";
            this.gridControlOthers.Size = new System.Drawing.Size(206, 321);
            this.gridControlOthers.TabIndex = 9;
            this.gridControlOthers.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewOthers});
            // 
            // gridViewOthers
            // 
            this.gridViewOthers.GridControl = this.gridControlOthers;
            this.gridViewOthers.Name = "gridViewOthers";
            this.gridViewOthers.OptionsBehavior.Editable = false;
            this.gridViewOthers.OptionsBehavior.ReadOnly = true;
            this.gridViewOthers.OptionsView.ShowGroupPanel = false;
            // 
            // grpItem
            // 
            this.grpItem.Controls.Add(this.btnRemoveMoMPoints);
            this.grpItem.Controls.Add(this.btnAddMoMPoints);
            this.grpItem.Controls.Add(this.gridMOMPoints);
            this.grpItem.Controls.Add(this.txtReligion);
            this.grpItem.Controls.Add(this.lblReligion);
            this.grpItem.Controls.Add(this.txtName);
            this.grpItem.Controls.Add(this.labelControl1);
            this.grpItem.Controls.Add(this.btnClose);
            this.grpItem.Controls.Add(this.btnSave);
            this.grpItem.Location = new System.Drawing.Point(215, 3);
            this.grpItem.Name = "grpItem";
            this.grpItem.Size = new System.Drawing.Size(638, 368);
            this.grpItem.TabIndex = 10;
            // 
            // txtReligion
            // 
            this.txtReligion.Location = new System.Drawing.Point(126, 70);
            this.txtReligion.Name = "txtReligion";
            this.txtReligion.Size = new System.Drawing.Size(214, 20);
            this.txtReligion.TabIndex = 2;
            // 
            // lblReligion
            // 
            this.lblReligion.Location = new System.Drawing.Point(44, 73);
            this.lblReligion.Name = "lblReligion";
            this.lblReligion.Size = new System.Drawing.Size(41, 13);
            this.lblReligion.TabIndex = 27;
            this.lblReligion.Text = "Religion:";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(126, 44);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(214, 20);
            this.txtName.TabIndex = 1;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(44, 47);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(31, 13);
            this.labelControl1.TabIndex = 25;
            this.labelControl1.Text = "Name:";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Image = ((System.Drawing.Image)(resources.GetObject("btnClose.Image")));
            this.btnClose.Location = new System.Drawing.Point(325, 323);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(62, 23);
            toolTipTitleItem11.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            toolTipTitleItem11.Appearance.Options.UseImage = true;
            toolTipTitleItem11.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem11.Image")));
            toolTipTitleItem11.Text = "Cancel";
            toolTipItem11.LeftIndent = 6;
            toolTipItem11.Text = "To close client rating without saving any information click here.";
            superToolTip11.Items.Add(toolTipTitleItem11);
            superToolTip11.Items.Add(toolTipItem11);
            this.btnClose.SuperTip = superToolTip11;
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Enabled = false;
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.Location = new System.Drawing.Point(262, 323);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(57, 23);
            toolTipTitleItem12.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            toolTipTitleItem12.Appearance.Options.UseImage = true;
            toolTipTitleItem12.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem12.Image")));
            toolTipTitleItem12.Text = "Save";
            toolTipItem12.LeftIndent = 6;
            toolTipItem12.Text = "To save record click here.";
            superToolTip12.Items.Add(toolTipTitleItem12);
            superToolTip12.Items.Add(toolTipItem12);
            this.btnSave.SuperTip = superToolTip12;
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "Save";
            // 
            // gridMOMPoints
            // 
            this.gridMOMPoints.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridMOMPoints.Location = new System.Drawing.Point(10, 106);
            this.gridMOMPoints.MainView = this.gridViewMOMPoints;
            this.gridMOMPoints.Name = "gridMOMPoints";
            this.gridMOMPoints.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemComboBoxInsuranceCompany});
            this.gridMOMPoints.Size = new System.Drawing.Size(623, 151);
            this.gridMOMPoints.TabIndex = 28;
            this.gridMOMPoints.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMOMPoints});
            // 
            // gridViewMOMPoints
            // 
            this.gridViewMOMPoints.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnId,
            this.gridColumnInsuranceCompany,
            this.gridColumnInsuranceCompanyId,
            this.gridColumnTerm,
            this.gridColumnSumAssured,
            this.gridColumnPremium});
            this.gridViewMOMPoints.GridControl = this.gridMOMPoints;
            this.gridViewMOMPoints.Name = "gridViewMOMPoints";
            this.gridViewMOMPoints.OptionsBehavior.AllowAddRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewMOMPoints.OptionsBehavior.AllowDeleteRows = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewMOMPoints.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
            this.gridViewMOMPoints.OptionsBehavior.EditorShowMode = DevExpress.Utils.EditorShowMode.MouseDown;
            this.gridViewMOMPoints.OptionsEditForm.ShowUpdateCancelPanel = DevExpress.Utils.DefaultBoolean.True;
            this.gridViewMOMPoints.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnId
            // 
            this.gridColumnId.Caption = "Id";
            this.gridColumnId.FieldName = "Id";
            this.gridColumnId.Name = "gridColumnId";
            // 
            // gridColumnInsuranceCompany
            // 
            this.gridColumnInsuranceCompany.Caption = "Insurance Company";
            this.gridColumnInsuranceCompany.ColumnEdit = this.repositoryItemComboBoxInsuranceCompany;
            this.gridColumnInsuranceCompany.Name = "gridColumnInsuranceCompany";
            this.gridColumnInsuranceCompany.Visible = true;
            this.gridColumnInsuranceCompany.VisibleIndex = 0;
            // 
            // gridColumnInsuranceCompanyId
            // 
            this.gridColumnInsuranceCompanyId.Caption = "Insurance Company Id";
            this.gridColumnInsuranceCompanyId.FieldName = "InsuranceCompanyId";
            this.gridColumnInsuranceCompanyId.Name = "gridColumnInsuranceCompanyId";
            this.gridColumnInsuranceCompanyId.Width = 119;
            // 
            // gridColumnTerm
            // 
            this.gridColumnTerm.Caption = "Term";
            this.gridColumnTerm.FieldName = "Term";
            this.gridColumnTerm.Name = "gridColumnTerm";
            this.gridColumnTerm.Visible = true;
            this.gridColumnTerm.VisibleIndex = 1;
            // 
            // gridColumnSumAssured
            // 
            this.gridColumnSumAssured.Caption = "Sum Assured";
            this.gridColumnSumAssured.FieldName = "SumAssured";
            this.gridColumnSumAssured.Name = "gridColumnSumAssured";
            this.gridColumnSumAssured.Visible = true;
            this.gridColumnSumAssured.VisibleIndex = 2;
            this.gridColumnSumAssured.Width = 82;
            // 
            // gridColumnPremium
            // 
            this.gridColumnPremium.Caption = "Premium";
            this.gridColumnPremium.FieldName = "Premium";
            this.gridColumnPremium.Name = "gridColumnPremium";
            this.gridColumnPremium.Visible = true;
            this.gridColumnPremium.VisibleIndex = 3;
            this.gridColumnPremium.Width = 70;
            // 
            // repositoryItemComboBoxInsuranceCompany
            // 
            this.repositoryItemComboBoxInsuranceCompany.AutoHeight = false;
            this.repositoryItemComboBoxInsuranceCompany.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemComboBoxInsuranceCompany.Name = "repositoryItemComboBoxInsuranceCompany";
            // 
            // btnRemoveMoMPoints
            // 
            this.btnRemoveMoMPoints.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnRemoveMoMPoints.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveMoMPoints.Image")));
            this.btnRemoveMoMPoints.Location = new System.Drawing.Point(320, 263);
            this.btnRemoveMoMPoints.Name = "btnRemoveMoMPoints";
            this.btnRemoveMoMPoints.Size = new System.Drawing.Size(25, 23);
            toolTipTitleItem9.Text = "Delete MOM point";
            toolTipItem9.LeftIndent = 6;
            toolTipItem9.Text = "To delete selected point of MOM record click here.";
            superToolTip9.Items.Add(toolTipTitleItem9);
            superToolTip9.Items.Add(toolTipItem9);
            this.btnRemoveMoMPoints.SuperTip = superToolTip9;
            this.btnRemoveMoMPoints.TabIndex = 30;
            this.btnRemoveMoMPoints.ToolTip = "Delete Client";
            // 
            // btnAddMoMPoints
            // 
            this.btnAddMoMPoints.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnAddMoMPoints.Image = ((System.Drawing.Image)(resources.GetObject("btnAddMoMPoints.Image")));
            this.btnAddMoMPoints.Location = new System.Drawing.Point(289, 263);
            this.btnAddMoMPoints.Name = "btnAddMoMPoints";
            this.btnAddMoMPoints.Size = new System.Drawing.Size(25, 23);
            toolTipTitleItem10.Text = "New MOM point";
            toolTipItem10.LeftIndent = 6;
            toolTipItem10.Text = "To add new point for mom inforamtion click here.";
            superToolTip10.Items.Add(toolTipTitleItem10);
            superToolTip10.Items.Add(toolTipItem10);
            this.btnAddMoMPoints.SuperTip = superToolTip10;
            this.btnAddMoMPoints.TabIndex = 29;
            this.btnAddMoMPoints.ToolTip = "Add new client";
            this.btnAddMoMPoints.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Application;
            this.btnAddMoMPoints.ToolTipTitle = "New Client";
            // 
            // RecomendationView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 450);
            this.Controls.Add(this.tabRecomendation);
            this.Name = "RecomendationView";
            this.Text = "Recomendation";
            ((System.ComponentModel.ISupportInitialize)(this.tabRecomendation)).EndInit();
            this.tabRecomendation.ResumeLayout(false);
            this.tabRecomendation.PerformLayout();
            this.tabNavigationPageInsuranceRecomendation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControlOthers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewOthers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpItem)).EndInit();
            this.grpItem.ResumeLayout(false);
            this.grpItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtReligion.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridMOMPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMOMPoints)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemComboBoxInsuranceCompany)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraBars.Navigation.TabPane tabRecomendation;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPageInsuranceRecomendation;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPagePersonalAccident;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPageOthers;
        private DevExpress.XtraGrid.GridControl gridControlOthers;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewOthers;
        private DevExpress.XtraEditors.GroupControl grpItem;
        private DevExpress.XtraEditors.TextEdit txtReligion;
        private DevExpress.XtraEditors.LabelControl lblReligion;
        private DevExpress.XtraEditors.TextEdit txtName;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnSave;
        private DevExpress.XtraGrid.GridControl gridMOMPoints;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMOMPoints;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnInsuranceCompany;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnInsuranceCompanyId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTerm;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnSumAssured;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPremium;
        private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxInsuranceCompany;
        public DevExpress.XtraEditors.SimpleButton btnRemoveMoMPoints;
        public DevExpress.XtraEditors.SimpleButton btnAddMoMPoints;
    }
}