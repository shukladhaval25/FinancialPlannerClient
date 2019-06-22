using FinancialPlanner.Common.Model.TaskManagement;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinancialPlannerClient.TaskManagementSystem
{
    public partial class ViewTaskCard : DevExpress.XtraEditors.XtraForm
    {
        List<TaskComment> taskComments = new List<TaskComment>();
        public ViewTaskCard()
        {
            InitializeComponent();
        }

        private void ViewTaskCard_Load(object sender, EventArgs e)
        {
            dummyTaskComments();
            fillGridView();
        }

        private void fillGridView()
        {
            DataTable dtComments = new DataTable();
            dtComments = FinancialPlanner.Common.DataConversion.ListtoDataTable.ToDataTable(taskComments);
            gridControl1.DataSource = dtComments;
        }

        private void dummyTaskComments()
        {
            TaskComment taskComment = new TaskComment();
            taskComment.Id = 1;
            taskComment.TaskId = "PF-001";
            taskComment.CommantedBy = "Admin";
            taskComment.CommentedOn = new DateTime(2019, 02, 06);
            taskComment.To = new List<string>() { "Amit Shah" };
            taskComment.Comment = "This work is not going to complete unless and untill you provide client contact inforamtion";
            taskComments.Add(taskComment);

            TaskComment taskComment1 = new TaskComment();
            taskComment1.Id = 2;
            taskComment1.TaskId = "PF-001";
            taskComment1.CommantedBy = "Amit Shah";
            taskComment1.CommentedOn = new DateTime(2019, 02, 06);
            taskComment1.To = new List<string>() { "Admin" };
            taskComment1.Comment = "Client contact information is as below: Mobile 9869544585";
            taskComments.Add(taskComment1);

        }

        private void ViewTaskCard_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }
    }
}
