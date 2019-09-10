namespace FinancialPlannerClient.TaskManagementSystem
{
    partial class TaskMainPage
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskMainPage));
            this.imageCollectionForTaskMenu = new DevExpress.Utils.ImageCollection(this.components);
            this.navigationFrameDashboard = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPageDeshboard = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationPageForTasks = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.pnlTaskMenu = new DevExpress.XtraEditors.PanelControl();
            this.btnMyReminders = new DevExpress.XtraEditors.SimpleButton();
            this.btnNotification = new DevExpress.XtraEditors.SimpleButton();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnUser = new DevExpress.XtraEditors.SimpleButton();
            this.btnOverDue = new DevExpress.XtraEditors.SimpleButton();
            this.btnStatusWiseTask = new DevExpress.XtraEditors.SimpleButton();
            this.btnAllTask = new DevExpress.XtraEditors.SimpleButton();
            this.btnAssingToMe = new DevExpress.XtraEditors.SimpleButton();
            this.btnNewTask = new DevExpress.XtraEditors.SimpleButton();
            this.btnProjects = new DevExpress.XtraEditors.SimpleButton();
            this.timerTaskNotification = new System.Windows.Forms.Timer(this.components);
            this.timerBackgroundChange = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionForTaskMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrameDashboard)).BeginInit();
            this.navigationFrameDashboard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTaskMenu)).BeginInit();
            this.pnlTaskMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageCollectionForTaskMenu
            // 
            this.imageCollectionForTaskMenu.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollectionForTaskMenu.ImageStream")));
            this.imageCollectionForTaskMenu.InsertGalleryImage("projectdirectory_32x32.png", "images/programming/projectdirectory_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/programming/projectdirectory_32x32.png"), 0);
            this.imageCollectionForTaskMenu.Images.SetKeyName(0, "projectdirectory_32x32.png");
            this.imageCollectionForTaskMenu.InsertGalleryImage("employee_32x32.png", "images/people/employee_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/people/employee_32x32.png"), 1);
            this.imageCollectionForTaskMenu.Images.SetKeyName(1, "employee_32x32.png");
            this.imageCollectionForTaskMenu.InsertGalleryImage("newtask_32x32.png", "images/tasks/newtask_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/tasks/newtask_32x32.png"), 2);
            this.imageCollectionForTaskMenu.Images.SetKeyName(2, "newtask_32x32.png");
            this.imageCollectionForTaskMenu.InsertGalleryImage("find_32x32.png", "images/find/find_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/find/find_32x32.png"), 3);
            this.imageCollectionForTaskMenu.Images.SetKeyName(3, "find_32x32.png");
            this.imageCollectionForTaskMenu.InsertGalleryImage("cancel_32x32.png", "images/actions/cancel_32x32.png", DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/cancel_32x32.png"), 4);
            this.imageCollectionForTaskMenu.Images.SetKeyName(4, "cancel_32x32.png");
            // 
            // navigationFrameDashboard
            // 
            this.navigationFrameDashboard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.navigationFrameDashboard.Controls.Add(this.navigationPageDeshboard);
            this.navigationFrameDashboard.Controls.Add(this.navigationPageForTasks);
            this.navigationFrameDashboard.Location = new System.Drawing.Point(82, 3);
            this.navigationFrameDashboard.Name = "navigationFrameDashboard";
            this.navigationFrameDashboard.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPageDeshboard,
            this.navigationPageForTasks});
            this.navigationFrameDashboard.SelectedPage = this.navigationPageForTasks;
            this.navigationFrameDashboard.Size = new System.Drawing.Size(1126, 629);
            this.navigationFrameDashboard.TabIndex = 2;
            this.navigationFrameDashboard.Text = "navigationFrame1";
            // 
            // navigationPageDeshboard
            // 
            this.navigationPageDeshboard.Name = "navigationPageDeshboard";
            this.navigationPageDeshboard.Size = new System.Drawing.Size(1126, 629);
            // 
            // navigationPageForTasks
            // 
            this.navigationPageForTasks.AutoScroll = true;
            this.navigationPageForTasks.Name = "navigationPageForTasks";
            this.navigationPageForTasks.Size = new System.Drawing.Size(1126, 629);
            // 
            // pnlTaskMenu
            // 
            this.pnlTaskMenu.Controls.Add(this.btnMyReminders);
            this.pnlTaskMenu.Controls.Add(this.btnNotification);
            this.pnlTaskMenu.Controls.Add(this.btnClose);
            this.pnlTaskMenu.Controls.Add(this.btnUser);
            this.pnlTaskMenu.Controls.Add(this.btnOverDue);
            this.pnlTaskMenu.Controls.Add(this.btnStatusWiseTask);
            this.pnlTaskMenu.Controls.Add(this.btnAllTask);
            this.pnlTaskMenu.Controls.Add(this.btnAssingToMe);
            this.pnlTaskMenu.Controls.Add(this.btnNewTask);
            this.pnlTaskMenu.Controls.Add(this.btnProjects);
            this.pnlTaskMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlTaskMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlTaskMenu.Name = "pnlTaskMenu";
            this.pnlTaskMenu.Size = new System.Drawing.Size(79, 632);
            this.pnlTaskMenu.TabIndex = 3;
            // 
            // btnMyReminders
            // 
            this.btnMyReminders.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnMyReminders.ImageUri.Uri = "TimeLineView;Size32x32";
            this.btnMyReminders.Location = new System.Drawing.Point(3, 435);
            this.btnMyReminders.Name = "btnMyReminders";
            this.btnMyReminders.Size = new System.Drawing.Size(72, 52);
            this.btnMyReminders.TabIndex = 8;
            this.btnMyReminders.Text = "Reminders";
            this.btnMyReminders.Click += new System.EventHandler(this.btnMyReminders_Click);
            // 
            // btnNotification
            // 
            this.btnNotification.Image = global::FinancialPlannerClient.Properties.Resources.Apps_Notifications_icon;
            this.btnNotification.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnNotification.Location = new System.Drawing.Point(3, 381);
            this.btnNotification.Name = "btnNotification";
            this.btnNotification.Size = new System.Drawing.Size(72, 52);
            this.btnNotification.TabIndex = 7;
            this.btnNotification.Text = "Notification";
            this.btnNotification.Click += new System.EventHandler(this.btnNotification_Click);
            // 
            // btnClose
            // 
            this.btnClose.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnClose.ImageUri.Uri = "Close;Size32x32";
            this.btnClose.Location = new System.Drawing.Point(3, 489);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 52);
            this.btnClose.TabIndex = 9;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnUser
            // 
            this.btnUser.Image = global::FinancialPlannerClient.Properties.Resources.icons8_customer_30;
            this.btnUser.ImageIndex = 1;
            this.btnUser.ImageList = this.imageCollectionForTaskMenu;
            this.btnUser.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnUser.Location = new System.Drawing.Point(3, 327);
            this.btnUser.Name = "btnUser";
            this.btnUser.Size = new System.Drawing.Size(72, 52);
            this.btnUser.TabIndex = 6;
            this.btnUser.Text = "User";
            // 
            // btnOverDue
            // 
            this.btnOverDue.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnOverDue.ImageUri.Uri = "Today;Size32x32";
            this.btnOverDue.Location = new System.Drawing.Point(3, 273);
            this.btnOverDue.Name = "btnOverDue";
            this.btnOverDue.Size = new System.Drawing.Size(72, 52);
            this.btnOverDue.TabIndex = 5;
            this.btnOverDue.Text = "My Overdue";
            this.btnOverDue.Click += new System.EventHandler(this.btnOverDue_Click);
            // 
            // btnStatusWiseTask
            // 
            this.btnStatusWiseTask.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnStatusWiseTask.ImageUri.Uri = "Columns;Size32x32";
            this.btnStatusWiseTask.Location = new System.Drawing.Point(3, 219);
            this.btnStatusWiseTask.Name = "btnStatusWiseTask";
            this.btnStatusWiseTask.Size = new System.Drawing.Size(72, 52);
            this.btnStatusWiseTask.TabIndex = 4;
            this.btnStatusWiseTask.Text = "Status Wise";
            // 
            // btnAllTask
            // 
            this.btnAllTask.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnAllTask.ImageUri.Uri = "ListNumbers;Size32x32";
            this.btnAllTask.Location = new System.Drawing.Point(3, 165);
            this.btnAllTask.Name = "btnAllTask";
            this.btnAllTask.Size = new System.Drawing.Size(72, 52);
            this.btnAllTask.TabIndex = 3;
            this.btnAllTask.Text = "All Task";
            this.btnAllTask.Click += new System.EventHandler(this.btnAllTask_Click);
            // 
            // btnAssingToMe
            // 
            this.btnAssingToMe.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnAssingToMe.ImageUri.Uri = "Paste";
            this.btnAssingToMe.Location = new System.Drawing.Point(3, 111);
            this.btnAssingToMe.Name = "btnAssingToMe";
            this.btnAssingToMe.Size = new System.Drawing.Size(72, 52);
            this.btnAssingToMe.TabIndex = 2;
            this.btnAssingToMe.Text = "Assing To Me";
            this.btnAssingToMe.Click += new System.EventHandler(this.btnAssingToMe_Click);
            // 
            // btnNewTask
            // 
            this.btnNewTask.Image = ((System.Drawing.Image)(resources.GetObject("btnNewTask.Image")));
            this.btnNewTask.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnNewTask.Location = new System.Drawing.Point(3, 57);
            this.btnNewTask.Name = "btnNewTask";
            this.btnNewTask.Size = new System.Drawing.Size(72, 52);
            this.btnNewTask.TabIndex = 1;
            this.btnNewTask.Text = "New Task";
            this.btnNewTask.Click += new System.EventHandler(this.btnNewTask_Click);
            // 
            // btnProjects
            // 
            this.btnProjects.Image = ((System.Drawing.Image)(resources.GetObject("btnProjects.Image")));
            this.btnProjects.ImageLocation = DevExpress.XtraEditors.ImageLocation.TopCenter;
            this.btnProjects.Location = new System.Drawing.Point(3, 3);
            this.btnProjects.Name = "btnProjects";
            this.btnProjects.Size = new System.Drawing.Size(72, 52);
            this.btnProjects.TabIndex = 0;
            this.btnProjects.Text = "Projects";
            this.btnProjects.Click += new System.EventHandler(this.btnProjects_Click);
            // 
            // timerTaskNotification
            // 
            this.timerTaskNotification.Interval = 60000;
            this.timerTaskNotification.Tick += new System.EventHandler(this.timerTaskNotification_Tick);
            // 
            // timerBackgroundChange
            // 
            this.timerBackgroundChange.Interval = 10000;
            this.timerBackgroundChange.Tick += new System.EventHandler(this.timerBackgroundChange_Tick);
            // 
            // TaskMainPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1210, 632);
            this.Controls.Add(this.pnlTaskMenu);
            this.Controls.Add(this.navigationFrameDashboard);
            this.MinimizeBox = false;
            this.Name = "TaskMainPage";
            this.Load += new System.EventHandler(this.TaskMainPage_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollectionForTaskMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrameDashboard)).EndInit();
            this.navigationFrameDashboard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTaskMenu)).EndInit();
            this.pnlTaskMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.Utils.ImageCollection imageCollectionForTaskMenu;        
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrameDashboard;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPageDeshboard;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPageForTasks;
        private DevExpress.XtraEditors.PanelControl pnlTaskMenu;
        private DevExpress.XtraEditors.SimpleButton btnAssingToMe;
        private DevExpress.XtraEditors.SimpleButton btnNewTask;
        private DevExpress.XtraEditors.SimpleButton btnProjects;
        private DevExpress.XtraEditors.SimpleButton btnAllTask;
        private DevExpress.XtraEditors.SimpleButton btnStatusWiseTask;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraEditors.SimpleButton btnUser;
        private DevExpress.XtraEditors.SimpleButton btnOverDue;
        private DevExpress.XtraEditors.SimpleButton btnNotification;
        private DevExpress.XtraEditors.SimpleButton btnMyReminders;
        private System.Windows.Forms.Timer timerTaskNotification;
        private System.Windows.Forms.Timer timerBackgroundChange;
    }
}
