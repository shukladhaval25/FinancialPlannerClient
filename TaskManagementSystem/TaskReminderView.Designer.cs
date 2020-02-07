namespace FinancialPlannerClient.TaskManagementSystem
{
    partial class TaskReminderView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskReminderView));
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.btnApply = new DevExpress.XtraEditors.SimpleButton();
            this.txtDescription = new DevExpress.XtraEditors.MemoEdit();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timeReminder = new DevExpress.XtraEditors.TimeEdit();
            this.dtReminderDate = new DevExpress.XtraEditors.DateEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblLine = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.gridControlReminder = new DevExpress.XtraGrid.GridControl();
            this.gridViewReminder = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumnTaskId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnReminderDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnReminderTime = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumnReminderDisplayed = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.repositoryItemTimeEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeReminder.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtReminderDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtReminderDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlReminder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewReminder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.labelControl1);
            this.groupControl1.Controls.Add(this.btnApply);
            this.groupControl1.Controls.Add(this.txtDescription);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Controls.Add(this.timeReminder);
            this.groupControl1.Controls.Add(this.dtReminderDate);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.lblTitle);
            this.groupControl1.Controls.Add(this.lblLine);
            this.groupControl1.Controls.Add(this.pictureEdit1);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(578, 196);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Set Reminder";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Appearance.Options.UseForeColor = true;
            this.labelControl1.Location = new System.Drawing.Point(33, 169);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(308, 13);
            this.labelControl1.TabIndex = 10;
            this.labelControl1.Text = "Reminder will display to either task owner or assignee.";
            // 
            // btnApply
            // 
            this.btnApply.ImageUri.Uri = "Apply;Size16x16";
            this.btnApply.Location = new System.Drawing.Point(486, 164);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(75, 23);
            this.btnApply.TabIndex = 9;
            this.btnApply.Text = "&Apply";
            this.btnApply.Click += new System.EventHandler(this.btnApply_Click);
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(179, 102);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(382, 56);
            this.txtDescription.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(176, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Description:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 137);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(33, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Time:";
            // 
            // timeReminder
            // 
            this.timeReminder.EditValue = new System.DateTime(((long)(0)));
            this.timeReminder.Location = new System.Drawing.Point(70, 134);
            this.timeReminder.Name = "timeReminder";
            this.timeReminder.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.timeReminder.Properties.DisplayFormat.FormatString = "HH:mm";
            this.timeReminder.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.timeReminder.Properties.EditFormat.FormatString = "HH:mm";
            this.timeReminder.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.timeReminder.Properties.Mask.BeepOnError = true;
            this.timeReminder.Properties.Mask.EditMask = "t";
            this.timeReminder.Size = new System.Drawing.Size(103, 20);
            this.timeReminder.TabIndex = 5;
            // 
            // dtReminderDate
            // 
            this.dtReminderDate.EditValue = null;
            this.dtReminderDate.Location = new System.Drawing.Point(70, 107);
            this.dtReminderDate.Name = "dtReminderDate";
            this.dtReminderDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtReminderDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtReminderDate.Size = new System.Drawing.Size(103, 20);
            this.dtReminderDate.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Date:";
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(74, 23);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(498, 48);
            this.lblTitle.TabIndex = 2;
            this.lblTitle.Text = "To set reminder for task please enter date and time and description here.";
            // 
            // lblLine
            // 
            this.lblLine.Appearance.BackColor = System.Drawing.Color.Silver;
            this.lblLine.Appearance.Options.UseBackColor = true;
            this.lblLine.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblLine.Location = new System.Drawing.Point(5, 74);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(567, 2);
            this.lblLine.TabIndex = 1;
            // 
            // pictureEdit1
            // 
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(5, 23);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureEdit1.Properties.InitialImage")));
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.pictureEdit1.Properties.ZoomAccelerationFactor = 1D;
            this.pictureEdit1.Size = new System.Drawing.Size(63, 45);
            this.pictureEdit1.TabIndex = 0;
            // 
            // gridControlReminder
            // 
            this.gridControlReminder.Location = new System.Drawing.Point(12, 214);
            this.gridControlReminder.MainView = this.gridViewReminder;
            this.gridControlReminder.Name = "gridControlReminder";
            this.gridControlReminder.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTimeEdit1,
            this.repositoryItemCheckEdit1});
            this.gridControlReminder.Size = new System.Drawing.Size(578, 119);
            this.gridControlReminder.TabIndex = 1;
            this.gridControlReminder.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewReminder});
            // 
            // gridViewReminder
            // 
            this.gridViewReminder.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumnTaskId,
            this.gridColumnReminderDate,
            this.gridColumnReminderTime,
            this.gridColumnDescription,
            this.gridColumnReminderDisplayed});
            this.gridViewReminder.GridControl = this.gridControlReminder;
            this.gridViewReminder.Name = "gridViewReminder";
            this.gridViewReminder.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumnTaskId
            // 
            this.gridColumnTaskId.Caption = "Task Id";
            this.gridColumnTaskId.FieldName = "TaskId";
            this.gridColumnTaskId.Name = "gridColumnTaskId";
            // 
            // gridColumnReminderDate
            // 
            this.gridColumnReminderDate.Caption = "Reminder Date";
            this.gridColumnReminderDate.FieldName = "ReminderDate";
            this.gridColumnReminderDate.Name = "gridColumnReminderDate";
            this.gridColumnReminderDate.Visible = true;
            this.gridColumnReminderDate.VisibleIndex = 0;
            this.gridColumnReminderDate.Width = 113;
            // 
            // gridColumnReminderTime
            // 
            this.gridColumnReminderTime.Caption = "Reminder Time";
            this.gridColumnReminderTime.DisplayFormat.FormatString = "HH:mm";
            this.gridColumnReminderTime.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Custom;
            this.gridColumnReminderTime.FieldName = "ReminderTime";
            this.gridColumnReminderTime.Name = "gridColumnReminderTime";
            this.gridColumnReminderTime.OptionsColumn.AllowEdit = false;
            this.gridColumnReminderTime.Visible = true;
            this.gridColumnReminderTime.VisibleIndex = 1;
            this.gridColumnReminderTime.Width = 92;
            // 
            // gridColumnDescription
            // 
            this.gridColumnDescription.Caption = "Description";
            this.gridColumnDescription.FieldName = "Description";
            this.gridColumnDescription.Name = "gridColumnDescription";
            this.gridColumnDescription.OptionsColumn.AllowEdit = false;
            this.gridColumnDescription.Visible = true;
            this.gridColumnDescription.VisibleIndex = 2;
            this.gridColumnDescription.Width = 355;
            // 
            // gridColumnReminderDisplayed
            // 
            this.gridColumnReminderDisplayed.Caption = "Reminder Displayed";
            this.gridColumnReminderDisplayed.ColumnEdit = this.repositoryItemCheckEdit1;
            this.gridColumnReminderDisplayed.FieldName = "ReminderDisplayed";
            this.gridColumnReminderDisplayed.Name = "gridColumnReminderDisplayed";
            this.gridColumnReminderDisplayed.OptionsColumn.AllowEdit = false;
            this.gridColumnReminderDisplayed.Visible = true;
            this.gridColumnReminderDisplayed.VisibleIndex = 3;
            this.gridColumnReminderDisplayed.Width = 102;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // repositoryItemTimeEdit1
            // 
            this.repositoryItemTimeEdit1.AutoHeight = false;
            this.repositoryItemTimeEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemTimeEdit1.Name = "repositoryItemTimeEdit1";
            // 
            // TaskReminderView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 343);
            this.ControlBox = false;
            this.Controls.Add(this.gridControlReminder);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TaskReminderView";
            this.Text = "Reminder";
            this.Load += new System.EventHandler(this.TaskReminder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeReminder.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtReminderDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtReminderDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControlReminder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewReminder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTimeEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.DateEdit dtReminderDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitle;
        private DevExpress.XtraEditors.LabelControl lblLine;
        private DevExpress.XtraEditors.PictureEdit pictureEdit1;
        private DevExpress.XtraEditors.SimpleButton btnApply;
        private DevExpress.XtraEditors.MemoEdit txtDescription;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.TimeEdit timeReminder;
        private DevExpress.XtraGrid.GridControl gridControlReminder;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewReminder;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnTaskId;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnReminderDate;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnReminderTime;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnDescription;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repositoryItemTimeEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumnReminderDisplayed;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }
}