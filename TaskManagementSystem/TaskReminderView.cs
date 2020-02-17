using FinancialPlanner.Common.Model.TaskManagement;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FinancialPlannerClient.TaskManagementSystem
{
    public partial class TaskReminderView : DevExpress.XtraEditors.XtraForm
    {
        int taskId;
        IList<TaskReminder> reminders;
        public TaskReminderView(int taskId)
        {
            InitializeComponent();
            this.taskId = taskId;
        }

        private void TaskReminder_Load(object sender, EventArgs e)
        {
            dtReminderDate.Properties.MinValue = DateTime.Now;
            timeReminder.EditValue = DateTime.Now.TimeOfDay;
            displayTaskReminders();
        }

        private void displayTaskReminders()
        {
            reminders = new TaskReminderInfo().GetTaskReminders(taskId);
            if (reminders != null)
            {
                if (reminders.Count > 0)
                {
                    gridControlReminder.DataSource = reminders;
                }
            }
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            if (!validateRquireField())
            {
                MessageBox.Show("Please enter all require field.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            TaskReminder taskReminder = GetTaskReminder();
            if (new TaskReminderInfo().Add(taskReminder))
            {
                MessageBox.Show("Record Saved Sucessfully", "Save",MessageBoxButtons.OK,MessageBoxIcon.Information);
                txtDescription.Text = string.Empty;
                dtReminderDate.Text = string.Empty;
                timeReminder.Text = string.Empty;
                displayTaskReminders();
            }
            else
            {
                MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private TaskReminder GetTaskReminder()
        {
            TaskReminder taskReminder = new TaskReminder();
            taskReminder.TaskId = taskId;
            taskReminder.ReminderDate = DateTime.Parse(dtReminderDate.Text);
            taskReminder.ReminderTime = DateTime.Parse(timeReminder.Text);
            taskReminder.Description = txtDescription.Text;
            return taskReminder;
        }

        private bool validateRquireField()
        {
            return !string.IsNullOrEmpty(dtReminderDate.Text) || !string.IsNullOrEmpty(timeReminder.Text) || !string.IsNullOrEmpty(txtDescription.Text);
        }
    }
}