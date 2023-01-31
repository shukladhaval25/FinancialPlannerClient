using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FinancialPlannerClient.PlannerInfo;
using System.Collections.Generic;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common;
using System.Data;
using FinancialPlanner.Common.DataConversion;
using DevExpress.XtraCharts;
using static DevExpress.XtraExport.Helpers.TableCellCss;
using System.Diagnostics;
using System.Reflection;
using FinancialPlanner.Common.Model.TaskManagement;
using FinancialPlannerClient.TaskManagementSystem;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class TaskCommentsReport : DevExpress.XtraReports.UI.XtraReport
    {
        int _taskId;
        public TaskCommentsReport(int taskId)
        {
            InitializeComponent();
            this._taskId = taskId;
            getIncomeData();
        }
        private void getIncomeData()
        {
            IList<TaskComment> taskComments = new TaskCommentInfo().GetTaskComments(this._taskId);
            xrTableCell17.DataBindings.Add("Text", taskComments, "Comment");
        }
    }
}
