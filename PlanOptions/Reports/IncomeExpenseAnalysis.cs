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
            _dtIncome = _dtIncome.Select("StartYear ='" + DateTime.Now.Year.ToString() + "'").CopyToDataTable();
            this.DataSource = _dtIncome;
            this.DataMember = _dtIncome.TableName;
            
            int index = 0;
            double totalIncome = 0;
            double totalIncomeTaxAmount = 0;
            foreach(DataRow dr in _dtIncome.Rows)
            {
                if (dr["StartYear"].ToString().Equals(DateTime.Now.Year.ToString()))
                {
                    xrTableIncome.Rows[index].Cells[0].Text = dr["Source"].ToString() + " - " +  dr["IncomeBy"].ToString();
                    double income = double.Parse(dr["Amount"].ToString());
                    double incomeTax = double.Parse(dr["IncomeTax"].ToString());
                    //double postTaxIncome = (income - ((income * incomeTax) / 100));
                   
                    double taxAmount = ((income  * incomeTax) / 100);
                    totalIncomeTaxAmount = totalIncomeTaxAmount + taxAmount;


                    xrTableIncome.Rows[index].Cells[1].Text = income.ToString();
                    totalIncome = totalIncome + income;
                    index++;
                }
               
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
                if (DateTime.Parse(dr["LoanStartDate"].ToString()).Year  <= planner.StartDate.Year  )
                {
                    DataRow dataRowLoan = _dtExpenses.NewRow();
                    dataRowLoan["Item"] = dr["TypeOfLoan"];
                    dataRowLoan["Amount"] = double.Parse(dr["Emis"].ToString()) * 12;
                    _dtExpenses.Rows.Add(dataRowLoan);
                    //index++;
                }
               
            }
            foreach (DataRow dr in _dtExpenses.Rows)
            {
                if (dr["ExpStartYear"].ToString().Equals(DateTime.Now.Year.ToString()) || string.IsNullOrEmpty(dr["ExpStartYear"].ToString()))
                {
                    xrTableExp.Rows[index].Cells[0].Text = dr["Item"].ToString();
                    double exp = (dr["OccuranceType"].ToString().Equals("Monthly") ? double.Parse(dr["Amount"].ToString()) * 12 : double.Parse(dr["Amount"].ToString()));
                    xrTableExp.Rows[index].Cells[1].Text = exp.ToString();
                    totalExpenses = totalExpenses + exp;
                    index++;
                }
            }           

            lblExpTotal.Text = totalExpenses.ToString();
            ExpenseOutFlowChart expenseOutFlowChart = new ExpenseOutFlowChart(_dtExpenses);
            expenseOutFlowChart.CreateDocument();
            this.xrSubreportExp.ReportSource = expenseOutFlowChart;
        }

        private void lblAmount0_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            lblAmount0.Text = String.Format("{0:#,###}", double.Parse(lblAmount0.Text));
        }

        private void lblAmount1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblAmount1.Text))
            {
                lblAmount1.Text = String.Format("{0:#,###}", double.Parse(lblAmount1.Text));
            }
        }

        private void lblAmount2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblAmount2.Text))
            {
                lblAmount2.Text = String.Format("{0:#,###}", double.Parse(lblAmount2.Text));
            }
        }

        private void lblAmount3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblAmount3.Text))
            {
                lblAmount3.Text = String.Format("{0:#,###}", double.Parse(lblAmount3.Text));
            }
        }

        private void lblAmount5_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblAmount5.Text))
            {
                lblAmount5.Text = String.Format("{0:#,###}", double.Parse(lblAmount5.Text));
            }
        }

        private void lblAmount6_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblAmount6.Text))
            {
                lblAmount6.Text = String.Format("{0:#,###}", double.Parse(lblAmount6.Text));
            }
        }

        private void lblAmount7_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblAmount7.Text))
            {
                lblAmount7.Text = String.Format("{0:#,###}", double.Parse(lblAmount7.Text));
            }
        }

        private void xrLabelIncomeTaxAmount_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrLabelIncomeTaxAmount.Text))
            {
                xrLabelIncomeTaxAmount.Text = String.Format("{0:#,###}", double.Parse(xrLabelIncomeTaxAmount.Text));
            }
        }

        private void xrTableCell28_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell28.Text))
            {
                xrTableCell28.Text = String.Format("{0:#,###}", double.Parse(xrTableCell28.Text));
            }
        }

        private void xrTableCell2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell2.Text))
            { 
                xrTableCell2.Text = String.Format("{0:#,###}", double.Parse(xrTableCell2.Text));
            }
        }

        private void xrTableCell4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell4.Text))
            {
                xrTableCell4.Text = String.Format("{0:#,###}", double.Parse(xrTableCell4.Text));
            }
        }

        private void xrTableCell6_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell6.Text))
            {
                xrTableCell6.Text = String.Format("{0:#,###}", double.Parse(xrTableCell6.Text));
            }
        }

        private void xrTableCell8_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            if (!string.IsNullOrEmpty(xrTableCell8.Text))
            {
                xrTableCell8.Text = String.Format("{0:#,###}", double.Parse(xrTableCell8.Text));
            }
        }

        private void xrTableCell10_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell10.Text))
            {
                xrTableCell10.Text = String.Format("{0:#,###}", double.Parse(xrTableCell10.Text));
            }
        }

        private void xrTableCell14_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell14.Text))
            {
                xrTableCell14.Text = String.Format("{0:#,###}", double.Parse(xrTableCell14.Text));
            }
        }

        private void xrTableCell16_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell16.Text))
            {
                xrTableCell16.Text = String.Format("{0:#,###}", double.Parse(xrTableCell16.Text));
            }
        }

        private void xrTableCell24_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell24.Text))
            {
                xrTableCell24.Text = String.Format("{0:#,###}", double.Parse(xrTableCell24.Text));
            }
        }

        private void xrTableCell22_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell22.Text))
            {
                xrTableCell22.Text = String.Format("{0:#,###}", double.Parse(xrTableCell22.Text));
            }
        }

        private void lblExpTotal_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblExpTotal.Text))
            {
                lblExpTotal.Text = String.Format("{0:#,###}", double.Parse(lblExpTotal.Text));
            }
        }

        private void xrLabelNetTotalIncome_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrLabelNetTotalIncome.Text))
            {
                xrLabelNetTotalIncome.Text = String.Format("{0:#,###}", double.Parse(xrLabelNetTotalIncome.Text));
            }
        }

        private void xrTableCell29_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell29.Text))
            {
                xrTableCell29.Text = String.Format("{0:#,###}", double.Parse(xrTableCell29.Text));
            }
        }

        private void xrTableCell33_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell33.Text))
            {
                xrTableCell33.Text = String.Format("{0:#,###}", double.Parse(xrTableCell33.Text));
            }
        }

        private void xrTableCell35_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell35.Text))
            {
                xrTableCell35.Text = String.Format("{0:#,###}", double.Parse(xrTableCell35.Text));
            }
        }

        private void xrTableCell31_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell31.Text))
            {
                xrTableCell31.Text = String.Format("{0:#,###}", double.Parse(xrTableCell31.Text));
            }
        }
    }
}
