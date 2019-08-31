using FinancialPlanner.Common;
using System;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;

namespace FinancialPlannerClient.TaskManagementSystem
{
    public partial class TaskMainPage : DevExpress.XtraEditors.XtraForm
    {
        public TaskMainPage()
        {
            InitializeComponent();
        }

        private void TaskMainPage_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            redirectToDashboardPage();
            btnNotification.Image = FinancialPlanner.Common.DataConversion.FPImage.AddTextToImageOnTopRight("100", btnNotification.Image);
            btnNotification.Tag = 3;
            Displaynotify();
        }
        protected void Displaynotify()
        {
            try
            {
                //System.IO.Path.GetFullPath(@"image\graph.ico"));
                //notifyIconTask.Icon = new System.Drawing.Icon(System.IO.Path.GetFullPath(@"C:\Application Development\Financial Planner Project\Other Documents\App.ico"));

                //frmHome.notifyIconTask.Text = "Custommer Support";
                //frmHome.notifyIconTask.Visible = true;
                //frmHome.notifyIconTask.BalloonTipTitle = "Please make a call to Mr. Dhaval Shukla @ 4:00 PM.";
                //frmHome.notifyIconTask.BalloonTipText = "Click Here to see details";
                //frmHome.notifyIconTask.ShowBalloonTip(100);
            }
            catch (Exception)
            {
            }
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
            //navigationPageDeshboard.Controls.Clear();
            //NewTaskCard newTaskCard = new NewTaskCard();
            ////newTaskCard.TopLevel = false;
            //newTaskCard.Visible = true;
            //////newTaskCard.Height = this.Height - 100;
            //////newTaskCard.Width = this.Width - 100;
            //navigationPageDeshboard.Name = newTaskCard.Name;
            //navigationPageDeshboard.Controls.Add(newTaskCard);
            //showNavigationPage(newTaskCard.Name);
            NewTaskCard newTask = new NewTaskCard();
            newTask.StartPosition = FormStartPosition.CenterParent;
            newTask.ShowDialog();
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
            
        }

        private void btnAllTask_Click(object sender, EventArgs e)
        {
            navigationPageDeshboard.Controls.Clear();
            AllTask allTask = new AllTask();
            allTask.TopLevel = false;
            allTask.Visible = true;
            ////newTaskCard.Height = this.Height - 100;
            ////newTaskCard.Width = this.Width - 100;
            navigationPageDeshboard.Name = allTask.Name;
            navigationPageDeshboard.Controls.Add(allTask);
            showNavigationPage(allTask.Name);
        }
    }
}
