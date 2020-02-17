namespace FinancialPlannerClient.Controls
{
    partial class MOM
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MOM));
            this.grpMOM = new DevExpress.XtraEditors.GroupControl();
            this.gridControlMOM = new DevExpress.XtraGrid.GridControl();
            this.gridViewMOM = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnPoint = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnActionPlan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnResponsibility = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTaskRequire = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.gridColumnTaskId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnTask = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemButton = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.textEdit1 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cmbClient = new DevExpress.XtraEditors.ComboBoxEdit();
            this.lblName = new DevExpress.XtraEditors.LabelControl();
            this.groupOption = new DevExpress.XtraEditors.GroupControl();
            this.radioGroupMeetingWith = new DevExpress.XtraEditors.RadioGroup();
            ((System.ComponentModel.ISupportInitialize)(this.grpMOM)).BeginInit();
            this.grpMOM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMOM)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbClient.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupOption)).BeginInit();
            this.groupOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupMeetingWith.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grpMOM
            // 
            this.grpMOM.CaptionImage = ((System.Drawing.Image)(resources.GetObject("grpMOM.CaptionImage")));
            this.grpMOM.Controls.Add(this.gridControlMOM);
            this.grpMOM.Controls.Add(this.textEdit1);
            this.grpMOM.Controls.Add(this.labelControl2);
            this.grpMOM.Controls.Add(this.dateTimePicker1);
            this.grpMOM.Controls.Add(this.labelControl1);
            this.grpMOM.Controls.Add(this.cmbClient);
            this.grpMOM.Controls.Add(this.lblName);
            this.grpMOM.Controls.Add(this.groupOption);
            this.grpMOM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMOM.Location = new System.Drawing.Point(0, 0);
            this.grpMOM.Name = "grpMOM";
            this.grpMOM.Size = new System.Drawing.Size(896, 450);
            this.grpMOM.TabIndex = 0;
            this.grpMOM.Text = "Minutes Of Meeting";
            // 
            // gridControlMOM
            // 
            this.gridControlMOM.Location = new System.Drawing.Point(25, 156);
            this.gridControlMOM.MainView = this.gridViewMOM;
            this.gridControlMOM.Name = "gridControlMOM";
            this.gridControlMOM.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1,
            this.repositoryItemButton});
            this.gridControlMOM.Size = new System.Drawing.Size(845, 240);
            this.gridControlMOM.TabIndex = 7;
            this.gridControlMOM.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewMOM});
            // 
            // gridViewMOM
            // 
            this.gridViewMOM.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnPoint,
            this.gridColumnActionPlan,
            this.gridColumnResponsibility,
            this.gridColumnStatus,
            this.gridColumnTaskRequire,
            this.gridColumnTaskId,
            this.gridColumnTask});
            this.gridViewMOM.GridControl = this.gridControlMOM;
            this.gridViewMOM.Name = "gridViewMOM";
            this.gridViewMOM.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnPoint
            // 
            this.gridColumnPoint.Caption = "Points Discussed";
            this.gridColumnPoint.FieldName = "Points";
            this.gridColumnPoint.Name = "gridColumnPoint";
            this.gridColumnPoint.Visible = true;
            this.gridColumnPoint.VisibleIndex = 0;
            this.gridColumnPoint.Width = 285;
            // 
            // gridColumnActionPlan
            // 
            this.gridColumnActionPlan.Caption = "Action Plan";
            this.gridColumnActionPlan.FieldName = "ActionPlan";
            this.gridColumnActionPlan.Name = "gridColumnActionPlan";
            this.gridColumnActionPlan.Visible = true;
            this.gridColumnActionPlan.VisibleIndex = 1;
            this.gridColumnActionPlan.Width = 187;
            // 
            // gridColumnResponsibility
            // 
            this.gridColumnResponsibility.Caption = "Responsibility";
            this.gridColumnResponsibility.FieldName = "Responsibility";
            this.gridColumnResponsibility.Name = "gridColumnResponsibility";
            this.gridColumnResponsibility.Visible = true;
            this.gridColumnResponsibility.VisibleIndex = 2;
            this.gridColumnResponsibility.Width = 124;
            // 
            // gridColumnStatus
            // 
            this.gridColumnStatus.Caption = "Status";
            this.gridColumnStatus.FieldName = "Status";
            this.gridColumnStatus.Name = "gridColumnStatus";
            this.gridColumnStatus.Visible = true;
            this.gridColumnStatus.VisibleIndex = 3;
            this.gridColumnStatus.Width = 69;
            // 
            // gridColumnTaskRequire
            // 
            this.gridColumnTaskRequire.Caption = "Task Require";
            this.gridColumnTaskRequire.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumnTaskRequire.FieldName = "IsTaskCreationRequire";
            this.gridColumnTaskRequire.Name = "gridColumnTaskRequire";
            this.gridColumnTaskRequire.Visible = true;
            this.gridColumnTaskRequire.VisibleIndex = 4;
            this.gridColumnTaskRequire.Width = 80;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // gridColumnTaskId
            // 
            this.gridColumnTaskId.Caption = "Mapped TaskId";
            this.gridColumnTaskId.FieldName = "TaskId";
            this.gridColumnTaskId.Name = "gridColumnTaskId";
            this.gridColumnTaskId.OptionsColumn.AllowEdit = false;
            this.gridColumnTaskId.Visible = true;
            this.gridColumnTaskId.VisibleIndex = 5;
            this.gridColumnTaskId.Width = 82;
            // 
            // gridColumnTask
            // 
            this.gridColumnTask.Caption = "Task";
            this.gridColumnTask.ColumnEdit = this.repositoryItemButton;
            this.gridColumnTask.Name = "gridColumnTask";
            this.gridColumnTask.Visible = true;
            this.gridColumnTask.VisibleIndex = 6;
            // 
            // repositoryItemButton
            // 
            this.repositoryItemButton.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemButton.Appearance.Image")));
            this.repositoryItemButton.Appearance.Options.UseImage = true;
            this.repositoryItemButton.Appearance.Options.UseTextOptions = true;
            this.repositoryItemButton.AppearanceFocused.Image = ((System.Drawing.Image)(resources.GetObject("repositoryItemButton.AppearanceFocused.Image")));
            this.repositoryItemButton.AppearanceFocused.Options.UseImage = true;
            this.repositoryItemButton.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph)});
            this.repositoryItemButton.ContextImage = ((System.Drawing.Image)(resources.GetObject("repositoryItemButton.ContextImage")));
            this.repositoryItemButton.Name = "repositoryItemButton";
            this.repositoryItemButton.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
            this.repositoryItemButton.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.repositoryItemButton_ButtonClick);
            // 
            // textEdit1
            // 
            this.textEdit1.Location = new System.Drawing.Point(236, 121);
            this.textEdit1.Name = "textEdit1";
            this.textEdit1.Size = new System.Drawing.Size(443, 20);
            this.textEdit1.TabIndex = 6;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(158, 128);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(69, 13);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "Meeting Type:";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(236, 93);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(113, 21);
            this.dateTimePicker1.TabIndex = 4;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(158, 101);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(27, 13);
            this.labelControl1.TabIndex = 3;
            this.labelControl1.Text = "Date:";
            // 
            // cmbClient
            // 
            this.cmbClient.Location = new System.Drawing.Point(236, 67);
            this.cmbClient.Name = "cmbClient";
            this.cmbClient.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbClient.Size = new System.Drawing.Size(443, 20);
            this.cmbClient.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.Location = new System.Drawing.Point(158, 70);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(31, 13);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Name:";
            // 
            // groupOption
            // 
            this.groupOption.Controls.Add(this.radioGroupMeetingWith);
            this.groupOption.Location = new System.Drawing.Point(20, 23);
            this.groupOption.Name = "groupOption";
            this.groupOption.ShowCaption = false;
            this.groupOption.Size = new System.Drawing.Size(850, 38);
            this.groupOption.TabIndex = 0;
            this.groupOption.Text = "Option";
            // 
            // radioGroupMeetingWith
            // 
            this.radioGroupMeetingWith.Location = new System.Drawing.Point(5, 6);
            this.radioGroupMeetingWith.Name = "radioGroupMeetingWith";
            this.radioGroupMeetingWith.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.radioGroupMeetingWith.Properties.Appearance.Options.UseFont = true;
            this.radioGroupMeetingWith.Properties.Items.AddRange(new DevExpress.XtraEditors.Controls.RadioGroupItem[] {
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Client", "Meeting with Client"),
            new DevExpress.XtraEditors.Controls.RadioGroupItem("Others", "Meeting with other then client")});
            this.radioGroupMeetingWith.Size = new System.Drawing.Size(840, 26);
            this.radioGroupMeetingWith.TabIndex = 0;
            this.radioGroupMeetingWith.SelectedIndexChanged += new System.EventHandler(this.radioGroupMeetingWith_SelectedIndexChanged);
            // 
            // MOM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpMOM);
            this.Name = "MOM";
            this.Size = new System.Drawing.Size(896, 450);
            this.Load += new System.EventHandler(this.MOM_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpMOM)).EndInit();
            this.grpMOM.ResumeLayout(false);
            this.grpMOM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlMOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewMOM)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cmbClient.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupOption)).EndInit();
            this.groupOption.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.radioGroupMeetingWith.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl grpMOM;
        private DevExpress.XtraEditors.GroupControl groupOption;
        private DevExpress.XtraEditors.ComboBoxEdit cmbClient;
        private DevExpress.XtraEditors.LabelControl lblName;
        private DevExpress.XtraEditors.RadioGroup radioGroupMeetingWith;
        private DevExpress.XtraGrid.GridControl gridControlMOM;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewMOM;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnPoint;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnActionPlan;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnResponsibility;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnStatus;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTaskRequire;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTaskId;
        private DevExpress.XtraEditors.TextEdit textEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButton;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTask;
    }
}
