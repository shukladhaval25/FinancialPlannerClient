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
        DataTable _dtLoan;
        List<Income> lstIncome;
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
            lstIncome = (List<Income>)incomeInfo.GetAll(this.planner.ID);
            _dtIncome = ListtoDataTable.ToDataTable(lstIncome);
            this.DataSource = _dtIncome;
            this.DataMember = _dtIncome.TableName;
            
            int index = 0;
            double totalIncome = 0;
            double totalIncomeTaxAmount = 0;
            foreach(DataRow dr in _dtIncome.Rows)
            {
                if (dr["StartYear"].ToString().Equals(DateTime.Now.Year.ToString()))
                {
                    xrTableIncome.Rows[index].Cells[0].Text = dr["IncomeBy"].ToString();
                    double income = double.Parse(dr["Amount"].ToString());
                    double incomeTax = double.Parse(dr["IncomeTax"].ToString());
                    //double postTaxIncome = (income - ((income * incomeTax) / 100));
                   
                    double taxAmount = ((income  * incomeTax) / 100);
                    totalIncomeTaxAmount = totalIncomeTaxAmount + taxAmount;


                    xrTableIncome.Rows[index].Cells[1].Text = income.ToString();
                    totalIncome = totalIncome + income;
                }
                index++;
            }
            lblAmount7.Text = totalIncome.ToString();
            xrLabelIncomeTaxAmount.Text = totalIncomeTaxAmount.ToString();
            xrLabelNetTotalIncome.Text = (totalIncome - totalIncomeTaxAmount).ToString();
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

            LoanInfo loanInfo = new LoanInfo();
            List<Loan> lstNonFinancialAsset = (List<Loan>)loanInfo.GetAll(this.planner.ID);
            _dtLoan = ListtoDataTable.ToDataTable(lstNonFinancialAsset);
            foreach (DataRow dr in _dtLoan.Rows)
            {
                if (DateTime.Parse(dr["LoanStartDate"].ToString()).Year  ==  DateTime.Now.Year )
                {
                    DataRow dataRowLoan = _dtExpenses.NewRow();
                    dataRowLoan["Item"] = dr["TypeOfLoan"];
                    dataRowLoan["Amount"] = double.Parse(dr["Emis"].ToString()) * 12;
                    _dtExpenses.Rows.Add(dataRowLoan);
                    //xrTableExp.Rows[index].Cells[0].Text = dr["TypeOfLoan"].ToString();
                    //xrTableExp.Rows[index].Cells[1].Text = dr["Emis"].ToString();
                    //totalExpenses = totalExpenses + double.Parse(dr["Emis"].ToString());
                }
                index++;
            }
            foreach (DataRow dr in _dtExpenses.Rows)
            {
                xrTableExp.Rows[index].Cells[0].Text = dr["Item"].ToString();
                double exp = (dr["OccuranceType"].ToString().Equals("Monthly") ? double.Parse(dr["Amount"].ToString()) * 12 : double.Parse(dr["Amount"].ToString()));
                xrTableExp.Rows[index].Cells[1].Text = exp.ToString();
                totalExpenses = totalExpenses + exp;
                index++;
            }           

           


            lblExpTotal.Text = totalExpenses.ToString();
            ExpenseOutFlowChart expenseOutFlowChart = new ExpenseOutFlowChart(_dtExpenses);
            expenseOutFlowChart.CreateDocument();
            this.xrSubreportExp.ReportSource = expenseOutFlowChart;
        }
    }
}
