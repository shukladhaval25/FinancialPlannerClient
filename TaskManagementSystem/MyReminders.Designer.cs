namespace FinancialPlannerClient.TaskManagementSystem
{
    partial class MyReminders
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
            this.components = new System.ComponentModel.Container();
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler3 = new DevExpress.XtraScheduler.TimeRuler();
            this.schedulerControl = new DevExpress.XtraScheduler.SchedulerControl();
            this.schedulerStorage1 = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // schedulerControl
            // 
            this.schedulerControl.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.WorkWeek;
            this.schedulerControl.DataStorage = this.schedulerStorage1;
            this.schedulerControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulerControl.Location = new System.Drawing.Point(0, 47);
            this.schedulerControl.MenuManager = this.ribbonControl1;
            this.schedulerControl.Name = "schedulerControl";
            this.schedulerControl.Size = new System.Drawing.Size(936, 403);
            this.schedulerControl.Start = new System.DateTime(2019, 5, 19, 0, 0, 0, 0);
            this.schedulerControl.TabIndex = 0;
            this.schedulerControl.Text = "schedulerControl1";
            this.schedulerControl.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schedulerControl.Views.FullWeekView.TimeRulers.Add(timeRuler2);
            this.schedulerControl.Views.WorkWeekView.AllDayAreaScrollBarVisible = true;
            this.schedulerControl.Views.WorkWeekView.ShowFullWeek = true;
            this.schedulerControl.Views.WorkWeekView.TimeRulers.Add(timeRuler3);
            this.schedulerControl.EditAppointmentFormShowing += new DevExpress.XtraScheduler.AppointmentFormEventHandler(this.schedulerControl1_EditAppointmentFormShowing);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 16;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Size = new System.Drawing.Size(936, 47);
            // 
            // MyReminders
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(936, 450);
            this.Controls.Add(this.schedulerControl);
            this.Controls.Add(this.ribbonControl1);
            this.Name = "MyReminders";
            this.Text = "My Reminders";
            this.Load += new System.EventHandler(this.MyReminders_Load);
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.Controls.CalendarControl calendarControl1;
        private DevExpress.Utils.Taskbar.TaskbarAssistant taskbarAssistant1;
        private DevExpress.XtraScheduler.SchedulerControl schedulerControl;
        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage1;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
    }
}