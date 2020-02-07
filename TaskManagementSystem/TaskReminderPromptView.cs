using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FinancialPlanner.Common.Model.TaskManagement;
using System.Diagnostics;
using System.Reflection;
using FinancialPlanner.Common;

namespace FinancialPlannerClient.TaskManagementSystem
{
    public partial class TaskReminderPromptView : DevExpress.XtraEditors.XtraForm
    {
        TaskReminder taskReminder;
        public TaskReminderPromptView(TaskReminder taskReminder)
        {
            InitializeComponent();
            this.taskReminder = taskReminder;
        }

        private void TaskReminderPromptView_Load(object sender, EventArgs e)
        {
            fillReminderData();
        }

        private void fillReminderData()
        {
            if (taskReminder != null)
            {
                lblDateValue.Text = taskReminder.ReminderDate.ToShortDateString();
                lblTimeValue.Text = taskReminder.ReminderTime.ToShortTimeString();
                txtDescription.Text = taskReminder.Description.ToString();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            taskReminder.ReminderDisplayed = true;
            try
            { 
                new TaskReminderInfo().Update(taskReminder);
            }
            catch(Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
            }
            this.Close();
        }

        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }
    }
}