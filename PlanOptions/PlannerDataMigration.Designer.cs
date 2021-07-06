namespace FinancialPlannerClient.PlanOptions
{
    partial class PlannerDataMigration
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
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlannerDataMigration));
            this.grpDataMigration = new DevExpress.XtraEditors.GroupControl();
            this.grpMigrationModules = new DevExpress.XtraEditors.GroupControl();
            this.gridModules = new DevExpress.XtraGrid.GridControl();
            this.gridViewModules = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridSelect = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumnModule = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.gridColumnFinalStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemImageEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemImageEdit();
            this.lblSourcePlan = new System.Windows.Forms.Label();
            this.btnStart = new DevExpress.XtraEditors.SimpleButton();
            this.cmbPlan = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.lblPlanVal = new System.Windows.Forms.Label();
            this.btnDeSelectAll = new DevExpress.XtraEditors.SimpleButton();
            this.btnSelectAll = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.grpDataMigration)).BeginInit();
            this.grpDataMigration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpMigrationModules)).BeginInit();
            this.grpMigrationModules.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridModules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewModules)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPlan.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grpDataMigration
            // 
            this.grpDataMigration.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDataMigration.Controls.Add(this.btnDeSelectAll);
            this.grpDataMigration.Controls.Add(this.btnSelectAll);
            this.grpDataMigration.Controls.Add(this.grpMigrationModules);
            this.grpDataMigration.Controls.Add(this.lblSourcePlan);
            this.grpDataMigration.Controls.Add(this.btnStart);
            this.grpDataMigration.Controls.Add(this.cmbPlan);
            this.grpDataMigration.Controls.Add(this.label3);
            this.grpDataMigration.Controls.Add(this.lblPlanVal);
            this.grpDataMigration.Location = new System.Drawing.Point(12, 12);
            this.grpDataMigration.Name = "grpDataMigration";
            this.grpDataMigration.Size = new System.Drawing.Size(784, 478);
            this.grpDataMigration.TabIndex = 9;
            this.grpDataMigration.Text = "Data migration process for plan";
            // 
            // grpMigrationModules
            // 
            this.grpMigrationModules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpMigrationModules.Controls.Add(this.gridModules);
            this.grpMigrationModules.Location = new System.Drawing.Point(5, 97);
            this.grpMigrationModules.Name = "grpMigrationModules";
            this.grpMigrationModules.Size = new System.Drawing.Size(774, 347);
            this.grpMigrationModules.TabIndex = 25;
            this.grpMigrationModules.Text = "Migration Modules Details";
            // 
            // gridModules
            // 
            this.gridModules.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridModules.Location = new System.Drawing.Point(2, 20);
            this.gridModules.MainView = this.gridViewModules;
            this.gridModules.Name = "gridModules";
            this.gridModules.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemProgressBar1,
            this.repositoryItemImageEdit1});
            this.gridModules.Size = new System.Drawing.Size(770, 325);
            this.gridModules.TabIndex = 1;
            this.gridModules.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewModules});
            // 
            // gridViewModules
            // 
            this.gridViewModules.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridSelect,
            this.gridColumnModule,
            this.gridColumnStatus,
            this.gridColumnFinalStatus,
            this.gridColumnNote});
            this.gridViewModules.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFullFocus;
            this.gridViewModules.GridControl = this.gridModules;
            this.gridViewModules.Name = "gridViewModules";
            this.gridViewModules.OptionsView.ShowGroupPanel = false;
            // 
            // gridSelect
            // 
            this.gridSelect.Caption = "Select";
            this.gridSelect.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridSelect.FieldName = "IsSelected";
            this.gridSelect.Name = "gridSelect";
            this.gridSelect.Visible = true;
            this.gridSelect.VisibleIndex = 0;
            this.gridSelect.Width = 45;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gridColumnModule
            // 
            this.gridColumnModule.Caption = "Module";
            this.gridColumnModule.FieldName = "Module";
            this.gridColumnModule.Name = "gridColumnModule";
            this.gridColumnModule.Visible = true;
            this.gridColumnModule.VisibleIndex = 1;
            this.gridColumnModule.Width = 208;
            // 
            // gridColumnStatus
            // 
            this.gridColumnStatus.Caption = "Status";
            this.gridColumnStatus.ColumnEdit = this.repositoryItemProgressBar1;
            this.gridColumnStatus.FieldName = "Status";
            this.gridColumnStatus.Name = "gridColumnStatus";
            this.gridColumnStatus.Visible = true;
            this.gridColumnStatus.VisibleIndex = 2;
            this.gridColumnStatus.Width = 169;
            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            this.repositoryItemProgressBar1.ProgressViewStyle = DevExpress.XtraEditors.Controls.ProgressViewStyle.Solid;
            this.repositoryItemProgressBar1.ShowTitle = true;
            this.repositoryItemProgressBar1.StartColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            // 
            // gridColumnFinalStatus
            // 
            this.gridColumnFinalStatus.FieldName = "FinalStatus";
            this.gridColumnFinalStatus.Name = "gridColumnFinalStatus";
            this.gridColumnFinalStatus.Visible = true;
            this.gridColumnFinalStatus.VisibleIndex = 3;
            this.gridColumnFinalStatus.Width = 79;
            // 
            // gridColumnNote
            // 
            this.gridColumnNote.Caption = "Note";
            this.gridColumnNote.FieldName = "Note";
            this.gridColumnNote.Name = "gridColumnNote";
            this.gridColumnNote.Visible = true;
            this.gridColumnNote.VisibleIndex = 4;
            this.gridColumnNote.Width = 253;
            // 
            // repositoryItemImageEdit1
            // 
            this.repositoryItemImageEdit1.AutoHeight = false;
            this.repositoryItemImageEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemImageEdit1.Name = "repositoryItemImageEdit1";
            // 
            // lblSourcePlan
            // 
            this.lblSourcePlan.AutoSize = true;
            this.lblSourcePlan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSourcePlan.Location = new System.Drawing.Point(57, 42);
            this.lblSourcePlan.Name = "lblSourcePlan";
            this.lblSourcePlan.Size = new System.Drawing.Size(82, 16);
            this.lblSourcePlan.TabIndex = 2;
            this.lblSourcePlan.Text = "From Plan:";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnStart.Image = ((System.Drawing.Image)(resources.GetObject("btnStart.Image")));
            this.btnStart.Location = new System.Drawing.Point(366, 450);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(104, 23);
            toolTipTitleItem1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            toolTipTitleItem1.Appearance.Options.UseImage = true;
            toolTipTitleItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem1.Image")));
            toolTipTitleItem1.Text = "Start Process";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "Process for migration of data from source plan to destination will stat on click." +
    "";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.btnStart.SuperTip = superToolTip1;
            this.btnStart.TabIndex = 23;
            this.btnStart.Text = "Start Process";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // cmbPlan
            // 
            this.cmbPlan.Location = new System.Drawing.Point(169, 41);
            this.cmbPlan.Name = "cmbPlan";
            this.cmbPlan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPlan.Properties.Sorted = true;
            this.cmbPlan.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbPlan.Size = new System.Drawing.Size(182, 20);
            this.cmbPlan.TabIndex = 13;
            this.cmbPlan.SelectedValueChanged += new System.EventHandler(this.cmbPlan_SelectedValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(57, 72);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "To Plan:";
            // 
            // lblPlanVal
            // 
            this.lblPlanVal.AutoSize = true;
            this.lblPlanVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanVal.ForeColor = System.Drawing.Color.Maroon;
            this.lblPlanVal.Location = new System.Drawing.Point(166, 72);
            this.lblPlanVal.Name = "lblPlanVal";
            this.lblPlanVal.Size = new System.Drawing.Size(55, 16);
            this.lblPlanVal.TabIndex = 5;
            this.lblPlanVal.Text = "#Plan#";
            // 
            // btnDeSelectAll
            // 
            this.btnDeSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDeSelectAll.Location = new System.Drawing.Point(96, 450);
            this.btnDeSelectAll.Name = "btnDeSelectAll";
            this.btnDeSelectAll.Size = new System.Drawing.Size(83, 23);
            this.btnDeSelectAll.TabIndex = 27;
            this.btnDeSelectAll.Text = "Deselect All";
            this.btnDeSelectAll.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Application;
            this.btnDeSelectAll.Click += new System.EventHandler(this.btnDeSelectAll_Click);
            // 
            // btnSelectAll
            // 
            this.btnSelectAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnSelectAll.Image = ((System.Drawing.Image)(resources.GetObject("btnSelectAll.Image")));
            this.btnSelectAll.Location = new System.Drawing.Point(7, 450);
            this.btnSelectAll.Name = "btnSelectAll";
            this.btnSelectAll.Size = new System.Drawing.Size(83, 23);
            this.btnSelectAll.TabIndex = 26;
            this.btnSelectAll.Text = "Select All";
            this.btnSelectAll.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Application;
            this.btnSelectAll.Click += new System.EventHandler(this.btnSelectAll_Click);
            // 
            // PlannerDataMigration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 502);
            this.Controls.Add(this.grpDataMigration);
            this.Name = "PlannerDataMigration";
            this.Text = "Planner Data Migration";
            this.Load += new System.EventHandler(this.PlannerDataMigration_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpDataMigration)).EndInit();
            this.grpDataMigration.ResumeLayout(false);
            this.grpDataMigration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpMigrationModules)).EndInit();
            this.grpMigrationModules.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridModules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewModules)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemImageEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPlan.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpDataMigration;
        private System.Windows.Forms.Label lblSourcePlan;
        private DevExpress.XtraEditors.SimpleButton btnStart;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPlan;
        private System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label lblPlanVal;
        private DevExpress.XtraEditors.GroupControl grpMigrationModules;
        private DevExpress.XtraGrid.GridControl gridModules;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewModules;
        private DevExpress.XtraGrid.Columns.GridColumn gridSelect;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnModule;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnFinalStatus;
        private DevExpress.XtraEditors.Repository.RepositoryItemImageEdit repositoryItemImageEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnNote;
        public DevExpress.XtraEditors.SimpleButton btnDeSelectAll;
        public DevExpress.XtraEditors.SimpleButton btnSelectAll;
    }
}