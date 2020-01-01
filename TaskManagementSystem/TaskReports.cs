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
using FinancialPlannerClient.Clients;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.Master;
using FinancialPlanner.Common.Model.TaskManagement;
using FinancialPlannerClient.PlanOptions.Reports.Tasks;

namespace FinancialPlannerClient.TaskManagementSystem
{
    public partial class TaskReports : DevExpress.XtraEditors.XtraForm
    {
        string[] reportOptions;
        public TaskReports()
        {
            InitializeComponent();
        }

        private void btnStatusWise_Click(object sender, EventArgs e)
        {
            //grpReportFilterOptions.Visible = true;
            //grpFilter.Visible = true;
            //reportOptions = null;

            //reportOptions = new string[] { "Status wise", "Status wise client wise", "Status wise assignee wise" };
            //cmbReportOption.Items.AddRange(reportOptions);
            //string[] taskStatus = new string[] { "Backlog", "InProgress", "Backlog", "Complete", "Discard", "Close" };
            //chkComboFilterOption1.Properties.Items.Clear();
            //chkComboFilterOption1.Properties.Items.AddRange(taskStatus);
            //fillupOption2ForStatusWise();
            DateTime fromDate = DateTime.MinValue;
            DateTime toDate = DateTime.MinValue;

            if (dateTimePicker1.Checked)
                fromDate = dateTimePicker1.Value;
            if (dateTimePicker2.Checked)
                toDate = dateTimePicker2.Value;

            AllTaskReports taskReports = new AllTaskReports(fromDate.Date, toDate.Date,TaskReportGroupBy.StatusWise);
            DevExpress.XtraReports.UI.ReportPrintTool printTool = new DevExpress.XtraReports.UI.ReportPrintTool(taskReports);
            printTool.ShowRibbonPreviewDialog();
        }

        private void fillupOption2ForStatusWise()
        {
            if (cmbReportOption.Text == "Status wise client wise")
            {
                List<Client> clients = new ClientService().GetAll().ToList();
                chkComboFilterOption2.Properties.Items.Clear();
                foreach (Client client in clients)
                {                    
                    chkComboFilterOption2.Properties.Items.Add(client.Name);
                }
            }
            if (cmbReportOption.Text == "Status wise assignee wise")
            {
                List<User> users = new UserServiceHelper().GetAll();
                foreach (User user in users)
                {
                    chkComboFilterOption2.Properties.Items.Add(user.UserName);
                }
            }
        }

        private void btnClientWise_Click(object sender, EventArgs e)
        {
            //grpFilter.Visible = true;
            //reportOptions = null;
            //reportOptions = new string[] { "Client wise", "Client wise status wise", "Client wise assignee wise" };
            //cmbReportOption.Items.AddRange(reportOptions);
            DateTime fromDate = DateTime.MinValue;
            DateTime toDate = DateTime.MinValue;

            if (dateTimePicker1.Checked)
                fromDate = dateTimePicker1.Value;
            if (dateTimePicker2.Checked)
                toDate = dateTimePicker2.Value;

            AllTaskReports taskReports = new AllTaskReports(fromDate.Date, toDate.Date,TaskReportGroupBy.ClientWise);
            DevExpress.XtraReports.UI.ReportPrintTool printTool = new DevExpress.XtraReports.UI.ReportPrintTool(taskReports);
            printTool.ShowRibbonPreviewDialog();
        }

        private void btnPendingTask_Click(object sender, EventArgs e)
        {
            DateTime fromDate = DateTime.MinValue;
            DateTime toDate = DateTime.MinValue;

            if (dateTimePicker1.Checked)
                fromDate = dateTimePicker1.Value;
            if (dateTimePicker2.Checked)
                toDate = dateTimePicker2.Value;

            AllTaskReports taskReports = new AllTaskReports(fromDate.Date, toDate.Date, TaskReportGroupBy.PendingTask);
            DevExpress.XtraReports.UI.ReportPrintTool printTool = new DevExpress.XtraReports.UI.ReportPrintTool(taskReports);
            printTool.ShowRibbonPreviewDialog();
        }

        private void btnAssigneeWise_Click(object sender, EventArgs e)
        {
            DateTime fromDate = DateTime.MinValue;
            DateTime toDate = DateTime.MinValue;

            if (dateTimePicker1.Checked)
                fromDate = dateTimePicker1.Value;
            if (dateTimePicker2.Checked)
                toDate = dateTimePicker2.Value;

            AllTaskReports taskReports = new AllTaskReports(fromDate.Date, toDate.Date, TaskReportGroupBy.AssigneeWise);
            DevExpress.XtraReports.UI.ReportPrintTool printTool = new DevExpress.XtraReports.UI.ReportPrintTool(taskReports);
            printTool.ShowRibbonPreviewDialog();
        }
    }

    public enum TaskReportGroupBy
    {
        StatusWise,
        ClientWise,
        PendingTask,
        AssigneeWise
    }
}