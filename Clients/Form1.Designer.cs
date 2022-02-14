namespace DXApplication1
{
    partial class NewTask
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
            this.tileViewColumnStepNo = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumnTitle = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumnId = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.grdProcessStep = new DevExpress.XtraGrid.GridControl();
            this.tileViewProcesStep = new DevExpress.XtraGrid.Views.Tile.TileView();
            this.tileViewColumnDescription = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumnRemarks = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumnDuration = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumnTimeline = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumnPrimaryResponsibility = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumnOwner = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.tileViewColumnChecker = new DevExpress.XtraGrid.Columns.TileViewColumn();
            this.cardView1 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.pnlProcessControl = new System.Windows.Forms.Panel();
            this.lblProcessTitle = new System.Windows.Forms.Label();
            this.pnlSubStepProcess = new System.Windows.Forms.Panel();
            this.lblSubProcessStepTitle = new System.Windows.Forms.Label();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.cardView3 = new DevExpress.XtraGrid.Views.Card.CardView();
            this.tileViewColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tileViewColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tileViewColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tileViewColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tileViewColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.tileViewColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.cardView2 = new DevExpress.XtraGrid.Views.Card.CardView();
            ((System.ComponentModel.ISupportInitialize)(this.grdProcessStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileViewProcesStep)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).BeginInit();
            this.pnlProcessControl.SuspendLayout();
            this.pnlSubStepProcess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView2)).BeginInit();
            this.SuspendLayout();
            // 
            // tileViewColumnStepNo
            // 
            this.tileViewColumnStepNo.Caption = "StepNo";
            this.tileViewColumnStepNo.FieldName = "StepNo";
            this.tileViewColumnStepNo.Name = "tileViewColumnStepNo";
            this.tileViewColumnStepNo.Visible = true;
            this.tileViewColumnStepNo.VisibleIndex = 0;
            // 
            // tileViewColumnTitle
            // 
            this.tileViewColumnTitle.Caption = "Title";
            this.tileViewColumnTitle.FieldName = "Title";
            this.tileViewColumnTitle.Name = "tileViewColumnTitle";
            this.tileViewColumnTitle.Visible = true;
            this.tileViewColumnTitle.VisibleIndex = 1;
            // 
            // tileViewColumnId
            // 
            this.tileViewColumnId.Caption = "Id";
            this.tileViewColumnId.FieldName = "Id";
            this.tileViewColumnId.Name = "tileViewColumnId";
            // 
            // grdProcessStep
            // 
            this.grdProcessStep.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.grdProcessStep.Location = new System.Drawing.Point(1120, 12);
            this.grdProcessStep.MainView = this.tileViewProcesStep;
            this.grdProcessStep.Name = "grdProcessStep";
            this.grdProcessStep.Size = new System.Drawing.Size(10, 442);
            this.grdProcessStep.TabIndex = 5;
            this.grdProcessStep.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.tileViewProcesStep,
            this.cardView1});
            // 
            // tileViewProcesStep
            // 
            this.tileViewProcesStep.Appearance.ItemHovered.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.tileViewProcesStep.Appearance.ItemHovered.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileViewProcesStep.Appearance.ItemHovered.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.tileViewProcesStep.Appearance.ItemHovered.Options.UseBorderColor = true;
            this.tileViewProcesStep.Appearance.ItemHovered.Options.UseFont = true;
            this.tileViewProcesStep.Appearance.ItemHovered.Options.UseForeColor = true;
            this.tileViewProcesStep.Appearance.ItemSelected.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.tileViewProcesStep.Appearance.ItemSelected.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tileViewProcesStep.Appearance.ItemSelected.FontStyleDelta = System.Drawing.FontStyle.Bold;
            this.tileViewProcesStep.Appearance.ItemSelected.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            this.tileViewProcesStep.Appearance.ItemSelected.Options.UseBorderColor = true;
            this.tileViewProcesStep.Appearance.ItemSelected.Options.UseFont = true;
            this.tileViewProcesStep.Appearance.ItemSelected.Options.UseForeColor = true;
            this.tileViewProcesStep.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.tileViewColumnId,
            this.tileViewColumnStepNo,
            this.tileViewColumnTitle,
            this.tileViewColumnDescription,
            this.tileViewColumnRemarks,
            this.tileViewColumnDuration,
            this.tileViewColumnTimeline,
            this.tileViewColumnPrimaryResponsibility,
            this.tileViewColumnOwner,
            this.tileViewColumnChecker});
            this.tileViewProcesStep.GridControl = this.grdProcessStep;
            this.tileViewProcesStep.Name = "tileViewProcesStep";
            this.tileViewProcesStep.OptionsTiles.Orientation = System.Windows.Forms.Orientation.Vertical;
            tileViewItemElement1.Appearance.Hovered.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement1.Appearance.Hovered.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            tileViewItemElement1.Appearance.Hovered.Options.UseFont = true;
            tileViewItemElement1.Appearance.Hovered.Options.UseForeColor = true;
            tileViewItemElement1.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement1.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement1.Column = this.tileViewColumnStepNo;
            tileViewItemElement1.Text = "tileViewColumnStepNo";
            tileViewItemElement1.TextLocation = new System.Drawing.Point(100, 20);
            tileViewItemElement2.AnimateTransition = DevExpress.Utils.DefaultBoolean.True;
            tileViewItemElement2.Appearance.Hovered.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement2.Appearance.Hovered.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(255)))));
            tileViewItemElement2.Appearance.Hovered.Options.UseFont = true;
            tileViewItemElement2.Appearance.Hovered.Options.UseForeColor = true;
            tileViewItemElement2.Appearance.Normal.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            tileViewItemElement2.Appearance.Normal.Options.UseFont = true;
            tileViewItemElement2.Column = this.tileViewColumnTitle;
            tileViewItemElement2.StretchHorizontal = true;
            tileViewItemElement2.Text = "tileViewColumnTitle";
            tileViewItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.TopCenter;
            tileViewItemElement2.TextLocation = new System.Drawing.Point(0, 45);
            tileViewItemElement3.Column = this.tileViewColumnId;
            tileViewItemElement3.Text = "tileViewColumnId";
            this.tileViewProcesStep.TileTemplate.Add(tileViewItemElement1);
            this.tileViewProcesStep.TileTemplate.Add(tileViewItemElement2);
            this.tileViewProcesStep.TileTemplate.Add(tileViewItemElement3);
            // 
            // tileViewColumnDescription
            // 
            this.tileViewColumnDescription.Caption = "Description";
            this.tileViewColumnDescription.FieldName = "Description";
            this.tileViewColumnDescription.Name = "tileViewColumnDescription";
            this.tileViewColumnDescription.Visible = true;
            this.tileViewColumnDescription.VisibleIndex = 2;
            // 
            // tileViewColumnRemarks
            // 
            this.tileViewColumnRemarks.Caption = "Remarks";
            this.tileViewColumnRemarks.FieldName = "Remarks";
            this.tileViewColumnRemarks.Name = "tileViewColumnRemarks";
            this.tileViewColumnRemarks.Visible = true;
            this.tileViewColumnRemarks.VisibleIndex = 3;
            // 
            // tileViewColumnDuration
            // 
            this.tileViewColumnDuration.Caption = "Duration In Minutes";
            this.tileViewColumnDuration.FieldName = "DurationInMinutes";
            this.tileViewColumnDuration.Name = "tileViewColumnDuration";
            this.tileViewColumnDuration.Visible = true;
            this.tileViewColumnDuration.VisibleIndex = 4;
            // 
            // tileViewColumnTimeline
            // 
            this.tileViewColumnTimeline.Caption = "Timeline In Days";
            this.tileViewColumnTimeline.FieldName = "TimelineInDays";
            this.tileViewColumnTimeline.Name = "tileViewColumnTimeline";
            this.tileViewColumnTimeline.Visible = true;
            this.tileViewColumnTimeline.VisibleIndex = 5;
            // 
            // tileViewColumnPrimaryResponsibility
            // 
            this.tileViewColumnPrimaryResponsibility.Caption = "Primary Responsibility";
            this.tileViewColumnPrimaryResponsibility.FieldName = "PrimaryResponsibility";
            this.tileViewColumnPrimaryResponsibility.Name = "tileViewColumnPrimaryResponsibility";
            this.tileViewColumnPrimaryResponsibility.Visible = true;
            this.tileViewColumnPrimaryResponsibility.VisibleIndex = 6;
            // 
            // tileViewColumnOwner
            // 
            this.tileViewColumnOwner.Caption = "Owner";
            this.tileViewColumnOwner.FieldName = "Owner";
            this.tileViewColumnOwner.Name = "tileViewColumnOwner";
            this.tileViewColumnOwner.Visible = true;
            this.tileViewColumnOwner.VisibleIndex = 7;
            // 
            // tileViewColumnChecker
            // 
            this.tileViewColumnChecker.Caption = "Checker";
            this.tileViewColumnChecker.FieldName = "Checker";
            this.tileViewColumnChecker.Name = "tileViewColumnChecker";
            this.tileViewColumnChecker.Visible = true;
            this.tileViewColumnChecker.VisibleIndex = 8;
            // 
            // cardView1
            // 
            this.cardView1.FocusedCardTopFieldIndex = 0;
            this.cardView1.GridControl = this.grdProcessStep;
            this.cardView1.Name = "cardView1";
            // 
            // pnlProcessControl
            // 
            this.pnlProcessControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlProcessControl.AutoScroll = true;
            this.pnlProcessControl.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.pnlProcessControl.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlProcessControl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProcessControl.Controls.Add(this.lblProcessTitle);
            this.pnlProcessControl.Location = new System.Drawing.Point(3, 3);
            this.pnlProcessControl.Name = "pnlProcessControl";
            this.pnlProcessControl.Size = new System.Drawing.Size(332, 458);
            this.pnlProcessControl.TabIndex = 6;
            // 
            // lblProcessTitle
            // 
            this.lblProcessTitle.BackColor = System.Drawing.Color.Khaki;
            this.lblProcessTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblProcessTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblProcessTitle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcessTitle.Location = new System.Drawing.Point(0, 0);
            this.lblProcessTitle.Name = "lblProcessTitle";
            this.lblProcessTitle.Size = new System.Drawing.Size(330, 31);
            this.lblProcessTitle.TabIndex = 0;
            this.lblProcessTitle.Text = "Primary Process Steps";
            this.lblProcessTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlSubStepProcess
            // 
            this.pnlSubStepProcess.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlSubStepProcess.AutoScroll = true;
            this.pnlSubStepProcess.AutoScrollMargin = new System.Drawing.Size(10, 10);
            this.pnlSubStepProcess.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlSubStepProcess.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlSubStepProcess.Controls.Add(this.lblSubProcessStepTitle);
            this.pnlSubStepProcess.Location = new System.Drawing.Point(341, 4);
            this.pnlSubStepProcess.Name = "pnlSubStepProcess";
            this.pnlSubStepProcess.Size = new System.Drawing.Size(334, 458);
            this.pnlSubStepProcess.TabIndex = 7;
            // 
            // lblSubProcessStepTitle
            // 
            this.lblSubProcessStepTitle.BackColor = System.Drawing.Color.Khaki;
            this.lblSubProcessStepTitle.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSubProcessStepTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSubProcessStepTitle.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubProcessStepTitle.Location = new System.Drawing.Point(0, 0);
            this.lblSubProcessStepTitle.Name = "lblSubProcessStepTitle";
            this.lblSubProcessStepTitle.Size = new System.Drawing.Size(332, 31);
            this.lblSubProcessStepTitle.TabIndex = 0;
            this.lblSubProcessStepTitle.Text = "Sub Process Step";
            this.lblSubProcessStepTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // gridControl1
            // 
            this.gridControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gridControl1.Location = new System.Drawing.Point(724, 12);
            this.gridControl1.MainView = this.cardView3;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(390, 190);
            this.gridControl1.TabIndex = 8;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.cardView3,
            this.cardView2});
            // 
            // cardView3
            // 
            this.cardView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.tileViewColumn1,
            this.tileViewColumn6,
            this.tileViewColumn2,
            this.tileViewColumn3,
            this.tileViewColumn4,
            this.tileViewColumn5});
            this.cardView3.FocusedCardTopFieldIndex = 0;
            this.cardView3.GridControl = this.gridControl1;
            this.cardView3.Name = "cardView3";
            this.cardView3.VertScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Auto;
            // 
            // tileViewColumn1
            // 
            this.tileViewColumn1.Caption = "Id";
            this.tileViewColumn1.FieldName = "Id";
            this.tileViewColumn1.Name = "tileViewColumn1";
            this.tileViewColumn1.Visible = true;
            this.tileViewColumn1.VisibleIndex = 0;
            // 
            // tileViewColumn6
            // 
            this.tileViewColumn6.Caption = "StepNo";
            this.tileViewColumn6.FieldName = "StepNo";
            this.tileViewColumn6.Name = "tileViewColumn6";
            this.tileViewColumn6.Visible = true;
            this.tileViewColumn6.VisibleIndex = 1;
            // 
            // tileViewColumn2
            // 
            this.tileViewColumn2.Caption = "Process Assign To";
            this.tileViewColumn2.FieldName = "ProcessAssignTo";
            this.tileViewColumn2.Name = "tileViewColumn2";
            this.tileViewColumn2.Visible = true;
            this.tileViewColumn2.VisibleIndex = 2;
            // 
            // tileViewColumn3
            // 
            this.tileViewColumn3.Caption = "Process Start Date";
            this.tileViewColumn3.FieldName = "ProcessStartDate";
            this.tileViewColumn3.Name = "tileViewColumn3";
            this.tileViewColumn3.Visible = true;
            this.tileViewColumn3.VisibleIndex = 3;
            // 
            // tileViewColumn4
            // 
            this.tileViewColumn4.Caption = "Expected Complete Date";
            this.tileViewColumn4.FieldName = "ExpectedCompleteDate";
            this.tileViewColumn4.Name = "tileViewColumn4";
            this.tileViewColumn4.Visible = true;
            this.tileViewColumn4.VisibleIndex = 4;
            // 
            // tileViewColumn5
            // 
            this.tileViewColumn5.Caption = "Actual Complete Date";
            this.tileViewColumn5.FieldName = "ActualCompleteDate";
            this.tileViewColumn5.Name = "tileViewColumn5";
            this.tileViewColumn5.Visible = true;
            this.tileViewColumn5.VisibleIndex = 5;
            // 
            // cardView2
            // 
            this.cardView2.FocusedCardTopFieldIndex = 0;
            this.cardView2.GridControl = this.gridControl1;
            this.cardView2.Name = "cardView2";
            // 
            // NewTask
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1142, 466);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.pnlSubStepProcess);
            this.Controls.Add(this.pnlProcessControl);
            this.Controls.Add(this.grdProcessStep);
            this.Name = "NewTask";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.NewTask_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdProcessStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tileViewProcesStep)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView1)).EndInit();
            this.pnlProcessControl.ResumeLayout(false);
            this.pnlSubStepProcess.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cardView2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdProcessStep;
        private DevExpress.XtraGrid.Views.Tile.TileView tileViewProcesStep;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumnId;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumnStepNo;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumnTitle;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumnDescription;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumnRemarks;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumnDuration;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumnTimeline;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumnPrimaryResponsibility;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumnOwner;
        private DevExpress.XtraGrid.Columns.TileViewColumn tileViewColumnChecker;
        private DevExpress.XtraGrid.Views.Card.CardView cardView1;
        private System.Windows.Forms.Panel pnlProcessControl;
        private System.Windows.Forms.Label lblProcessTitle;
        private System.Windows.Forms.Panel pnlSubStepProcess;
        private System.Windows.Forms.Label lblSubProcessStepTitle;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Card.CardView cardView2;
        private DevExpress.XtraGrid.Views.Card.CardView cardView3;
        private DevExpress.XtraGrid.Columns.GridColumn tileViewColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn tileViewColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn tileViewColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn tileViewColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn tileViewColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn tileViewColumn5;
    }
}

