using FinancialPlanner.Common;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace FinancialPlannerClient.TaskManagementSystem
{
    public partial class TaskMainPage : DevExpress.XtraEditors.XtraForm
    {
        System.Drawing.Color notificationButtonDefaultColor;
        System.Drawing.Color notificationColorChange = System.Drawing.Color.OrangeRed;
        public TaskMainPage()
        {
            InitializeComponent();
        }

        private void TaskMainPage_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            redirectToDashboardPage();
            notificationButtonDefaultColor = btnNotification.BackColor;
            timerTaskNotification.Start();
        }
       
        //private Bitmap addTextToImageOnTopRight(string text,Image sourceImage)
        //{           
        //   //string imageFilePath = btnNotification.Image.i
        //    Bitmap bitmap = (Bitmap)sourceImage;   //Image.FromFile(imageFilePath);//load the image file

        //    using (Graphics graphics = Graphics.FromImage(bitmap))
        //    {
        //        using (Font arialFont = new Font("Arial", 8,FontStyle.Bold))
        //        {
        //            graphics.DrawString(text, arialFont, Brushes.Red, new Point(0,5));
        //        }
        //    }
        //    return bitmap;
        //    //bitmap.Save(imageFilePath);//save the image file
        //}
        private void showNavigationPage(string pageName)
        {
            for (int index = 0; index <= navigationFrameDashboard.Pages.Count; index++)
            {
                if (navigationFrameDashboard.Pages[index].Name == pageName)
                {
                    navigationFrameDashboard.SelectedPageIndex = index;
                    break;
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Parent.Controls.Clear();
        }

        private void btnNewTask_Click(object sender, EventArgs e)
        {
            NewTaskCard newTask = new NewTaskCard();
            newTask.StartPosition = FormStartPosition.CenterParent;
            newTask.Show();
        }
        private void redirectToDashboardPage()
        {
            try
            {
                navigationPageDeshboard.Controls.Clear();
                TaskDeshborad taskDeshborad = new TaskDeshborad();
                taskDeshborad.Visible = true;
                navigationPageDeshboard.Name = taskDeshborad.Name;
                navigationPageDeshboard.Controls.Add(taskDeshborad);
                taskDeshborad.Dock = DockStyle.Fill;
                showNavigationPage(taskDeshborad.Name);
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
            }
        }
        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }

        private void btnProjects_Click(object sender, EventArgs e)
        {
            navigationPageForTasks.Controls.Clear();
            NewProject newProject = new NewProject();
            newProject.TopLevel = false;
            newProject.Visible = true;
            //newProject.Dock = DockStyle.Fill;
            navigationPageForTasks.Name = newProject.Name;
            navigationPageForTasks.Controls.Add(newProject);
            showNavigationPage(newProject.Name);
        }

        private void btnMyReminders_Click(object sender, EventArgs e)
        {
            navigationPageForTasks.Controls.Clear();
            MyReminders myReminders = new MyReminders();
            myReminders.TopLevel = false;
            myReminders.Visible = true;
            //newProject.Dock = DockStyle.Fill;
            navigationPageForTasks.Name = myReminders.Name;
            navigationPageForTasks.Controls.Add(myReminders);
            showNavigationPage(myReminders.Name);
        }

        private void btnAssingToMe_Click(object sender, EventArgs e)
        {
            navigationPageDeshboard.Controls.Clear();
            AllTask allTask = new AllTask(TaskView.AssignToMe);
            allTask.TopLevel = false;
            allTask.Visible = true;
            navigationPageDeshboard.Name = allTask.Name;
            navigationPageDeshboard.Controls.Add(allTask);
            showNavigationPage(allTask.Name);
        }

        private void btnAllTask_Click(object sender, EventArgs e)
        {
            navigationPageDeshboard.Controls.Clear();
            AllTask allTask = new AllTask(TaskView.GetAll);
            allTask.TopLevel = false;
            allTask.Visible = true;
            navigationPageDeshboard.Name = allTask.Name;
            navigationPageDeshboard.Controls.Add(allTask);
            showNavigationPage(allTask.Name);
        }

        private void timerTaskNotification_Tick(object sender, EventArgs e)
        {
            int count = new TaskNotificationInfo().GetNotification(Program.CurrentUser.Id);
            displaynotify(count);           
        }

        private void displaynotify(int count)
        {
            if (count > 0)
            {
                btnNotification.Image = FinancialPlanner.Common.DataConversion.FPImage.AddTextToImageOnTopRight(count.ToString(), btnNotification.Image);
                btnNotification.Tag = count;
                timerBackgroundChange.Start();
            }
            else
            {
                resetNotificationButton();
            }

        }

        private void resetNotificationButton()
        {
            btnNotification.Image = global::FinancialPlannerClient.Properties.Resources.Apps_Notifications_icon;
            btnNotification.BackColor = notificationButtonDefaultColor;
            timerBackgroundChange.Stop();
        }

        private void timerBackgroundChange_Tick(object sender, EventArgs e)
        {
            btnNotification.BackColor = (btnNotification.BackColor == notificationButtonDefaultColor) ? notificationColorChange :
                notificationButtonDefaultColor;
        }

        private void btnNotification_Click(object sender, EventArgs e)
        {
            navigationPageDeshboard.Controls.Clear();
            AllTask allTask = new AllTask(TaskView.Notified);
            allTask.TopLevel = false;
            allTask.Visible = true;
            navigationPageDeshboard.Name = allTask.Name;
            navigationPageDeshboard.Controls.Add(allTask);
            showNavigationPage(allTask.Name);
            resetNotificationButton();
        }

        private void btnOverDue_Click(object sender, EventArgs e)
        {
            navigationPageDeshboard.Controls.Clear();
            AllTask allTask = new AllTask(TaskView.MyOverDue);
            allTask.TopLevel = false;
            allTask.Visible = true;
            navigationPageDeshboard.Name = allTask.Name;
            navigationPageDeshboard.Controls.Add(allTask);
            showNavigationPage(allTask.Name);
        }
    }
}
