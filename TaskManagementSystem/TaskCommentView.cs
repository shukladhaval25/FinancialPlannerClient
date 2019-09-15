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

namespace FinancialPlannerClient.TaskManagementSystem
{
    public partial class TaskCommentView : DevExpress.XtraEditors.XtraForm
    {
        int taskId;
        private TaskComment taskComment;

        public TaskCommentView(int id)
        {
            this.taskId = id;
            InitializeComponent();
        }

        public TaskCommentView(TaskComment taskComment, int id)
        {
            this.taskComment = taskComment;
            this.taskId = id;
            InitializeComponent();
        }

        private void TaskComment_Load(object sender, EventArgs e)
        {
            txtComment.Tag = taskComment.Id;
            txtComment.Text = taskComment.Comment;            
        }

        private void btnCloseTask_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnSaveTask_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtComment.Text))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Please enter comment value.", "Validate");
                return;
            }
            TaskComment taskComment = getTaskComment();
            bool isSaved = false;
            if (taskComment.Id == 0)
                isSaved = new TaskCommentInfo().Add(taskComment);

            if (isSaved)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Record saved sucessfully.",
                   "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnSaveTask.Enabled = false;
            }

        }

        private TaskComment getTaskComment()
        {
            taskComment.TaskId  = taskId;
            taskComment.CommantedBy = Program.CurrentUser.Id;
            taskComment.Comment = txtComment.Text.Replace("'", "''");
            taskComment.IsEditable = (taskComment.Id > 0) ? true : false;
            return taskComment;
        }
    }
}