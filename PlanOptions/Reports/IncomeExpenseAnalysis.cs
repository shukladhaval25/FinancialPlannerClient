using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.PlannerInfo;
using System.Collections.Generic;
using FinancialPlanner.Common.DataConversion;
using System.Data;
using DevExpress.XtraCharts;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class IncomeExpenseAnalysis : DevExpress.XtraReports.UI.XtraReport
    {
        Client client;
        Planner planner;
        DataTable _dtIncome;
        DataTable _dtExpenses;
        public IncomeExpenseAnalysis(Client client,Planner planner)
        {
            InitializeComponent();
            this.client = client;
            this.planner = planner;
            this.lblClientName.Text = client.Name;
            getIncomeData();
            getExpenseData();
        }
        private void getIncomeData()
        {
            IncomeInfo incomeInfo = new IncomeInfo();
            List<Income> lstIncome = (List<Income>)incomeInfo.GetAll(this.planner.ID);
            _dtIncome = ListtoDataTable.ToDataTable(lstIncome);
            this.DataSource = _dtIncome;
            this.DataMember = _dtIncome.TableName;
            
            int index = 0;
            double totalIncome = 0;
            foreach(DataRow dr in _dtIncome.Rows)
            {
                xrTableIncome.Rows[index].Cells[0].Text = dr["IncomeBy"].ToString();
                xrTableIncome.Rows[index].Cells[1].Text = dr["Amount"].ToString();
                totalIncome = totalIncome + double.Parse(dr["Amount"].ToString());
                index++;
            }
            lblAmount7.Text = totalIncome.ToString();

            IncomeInflowChart incomeInflowChart = new IncomeInflowChart(this.client, this.planner);
            incomeInflowChart.CreateDocument();
            this.subReportIncomeChart.ReportSource = incomeInflowChart;
        }
        private void getExpenseData()
        {
            ExpensesInfo  expensesInfo = new ExpensesInfo();
            List<Expenses> lstExp = (List<Expenses>)expensesInfo.GetAll(this.planner.ID);
            _dtExpenses = ListtoDataTable.ToDataTable(lstExp);
           
            int index = 0;
            double totalExpenses = 0;
            foreach (DataRow dr in _dtExpenses.Rows)
            {
                xrTableExp.Rows[index].Cells[0].Text = dr["Item"].ToString();
                xrTableExp.Rows[index].Cells[1].Text = dr["Amount"].ToString();
                totalExpenses = totalExpenses + double.Parse(dr["Amount"].ToString());
                index++;
            }
            lblExpTotal.Text = totalExpenses.ToString();
            ExpenseOutFlowChart expenseOutFlowChart = new ExpenseOutFlowChart(_dtExpenses);
            expenseOutFlowChart.CreateDocument();
            this.xrSubreportExp.ReportSource = expenseOutFlowChart;
        }
    }
}
