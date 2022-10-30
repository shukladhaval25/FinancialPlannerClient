using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using FinancialPlanner.Common.Model.TaskManagement;
using FinancialPlannerClient.TaskManagementSystem;

namespace FinancialPlannerClient.PlanOptions.Reports.Tasks
{
    public partial class AllTaskReports : DevExpress.XtraReports.UI.XtraReport
    {
        DateTime dtFrom;
        DateTime dtTo;
        TaskReportGroupBy reportGroupBy;
        public AllTaskReports(DateTime dtFrom, DateTime dtTo, TaskReportGroupBy statusWise)
        {
            InitializeComponent();
            this.dtFrom = dtFrom;
            this.dtTo = dtTo;
            reportGroupBy = statusWise;
        }

        private void AllTaskReports_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            IList<TaskCard> taskCards = new TaskCardService().GetAllTasks();
            if (taskCards.Count > 0)
            {
                if (dtFrom != DateTime.MinValue && dtTo != DateTime.MinValue)
                {
                    taskCards = ((List<TaskCard>)taskCards).FindAll(i => i.UpdatedOn >= dtFrom && i.UpdatedOn <= dtTo);
                }
                if (reportGroupBy == TaskReportGroupBy.PendingTask)
                {
                    taskCards = ((List<TaskCard>)taskCards).FindAll(i => i.DueDate < DateTime.Now.Date && i.TaskStatus != TaskStatus.Close && i.TaskStatus != TaskStatus.Complete);
                }
                this.DataSource = taskCards;
                TaskCard taskCard = new TaskCard();
                SetGroupingBy(reportGroupBy);
                
                xrTableCell1.DataBindings.Add("Text", this.DataSource, "Id");
                xrTableCell2.DataBindings.Add("Text", this.DataSource, "CustomerName");
                xrTableCell3.DataBindings.Add("Text", this.DataSource, "Title");
                xrTableCell4.DataBindings.Add("Text", this.DataSource, "TaskStatus");
                xrTableCell5.DataBindings.Add("Text", this.DataSource, "OwnerName");
                xrTableCell6.DataBindings.Add("Text", this.DataSource, "AssignToName");
                lblCreatedDateValue.DataBindings.Add("Text", this.DataSource, "CreatedOn");
                xrTableCell7.DataBindings.Add("Text", this.DataSource, "DueDate");
                xrTableCell8.DataBindings.Add("Text", this.DataSource, "ProjectName");
                xrLabelOtherName.DataBindings.Add("Text", this.DataSource, "OtherName");
            }
        }

        private void SetGroupingBy(TaskReportGroupBy reportGroupBy)
        {
            if (reportGroupBy == TaskReportGroupBy.StatusWise)
            {
                setReportForStatusWise();
            }

            if ((reportGroupBy == TaskReportGroupBy.ClientWise) || (reportGroupBy == TaskReportGroupBy.PendingTask))
            {
                setReportForCustomerWise();
            }

            if (reportGroupBy == TaskReportGroupBy.AssigneeWise)
                setReportForAssigneeWise();
        }

        private void setReportForAssigneeWise()
        {
            this.GroupHeader1.GroupFields[0].FieldName = "AssignToName";
            this.lblGroupField.Text = "Assign To:";
            lblGroupFieldValue.DataBindings.Add("Text", this.DataSource, "AssignToName");
            xrLabelReportTitle.Text = "Assignee wise report";
        }

        private void setReportForCustomerWise()
        {
            this.GroupHeader1.GroupFields[0].FieldName = "CustomerName";
            this.lblGroupField.Text = "Customer:";
            lblGroupFieldValue.DataBindings.Add("Text", this.DataSource, "CustomerName");
            xrLabelReportTitle.Text = (reportGroupBy == TaskReportGroupBy.ClientWise) ?
                "Customer wise report" : "Pending task report";
        }

        private void setReportForStatusWise()
        {
            this.GroupHeader1.GroupFields[0].FieldName = "TaskStatus";
            this.lblGroupField.Text = "Task Status:";
            lblGroupFieldValue.DataBindings.Add("Text", this.DataSource, "TaskStatus");
            xrLabelReportTitle.Text = "Status wise report";
        }

        private void xrTableCell2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (string.IsNullOrEmpty(xrTableCell2.Text) && !string.IsNullOrEmpty(xrLabelOtherName.Text))
            {
                xrTableCell2.Text = xrLabelOtherName.Text;
            }
        }
    }
}
