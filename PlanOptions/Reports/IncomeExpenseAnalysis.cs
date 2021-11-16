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
            DataRow[] drs = _dtIncome.Select("StartYear <='" + DateTime.Now.Year.ToString() + "' and EndYear >='" + DateTime.Now.Year.ToString() + "'");
            if (drs.Length > 0)
            _dtIncome = _dtIncome.Select("StartYear <='" + DateTime.Now.Year.ToString() + "' and EndYear >='" + DateTime.Now.Year.ToString() + "'").CopyToDataTable();
            this.DataSource = _dtIncome;
            this.DataMember = _dtIncome.TableName;
            
            int index = 0;
            double totalIncome = 0;
            double totalIncomeTaxAmount = 0;
            foreach(DataRow dr in _dtIncome.Rows)
            {
                if  ( int.Parse(dr["StartYear"].ToString()) <= (DateTime.Now.Year) && int.Parse(dr["EndYear"].ToString()) >= (DateTime.Now.Year))
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


            if (this.planner.FaceType.Equals("D"))
            {
                // Add logic for retirement exp with distribution face.
                double income = 0;
                xrTableIncome.Rows[index].Cells[0].Text = "Distribution face Income";
                xrTableIncome.Rows[index].Cells[1].Text = income.ToString();
                totalIncome = totalIncome + income;
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
                _dtIncome.Select("StartYear <='" + DateTime.Now.Year.ToString() + "' and EndYear >='" + DateTime.Now.Year.ToString() + "'").CopyToDataTable();



                if (string.IsNullOrEmpty(dr["ExpEndYear"].ToString()))
                {
                    xrTableExp.Rows[index].Cells[0].Text = dr["Item"].ToString();
                    double exp = (dr["OccuranceType"].ToString().Equals("Monthly") ? double.Parse(dr["Amount"].ToString()) * 12 : double.Parse(dr["Amount"].ToString()));
                    xrTableExp.Rows[index].Cells[1].Text = exp.ToString();
                    totalExpenses = totalExpenses + exp;
                    index++;
                }
                else if                     
                    ((int.Parse(dr["ExpStartYear"].ToString()) <= (DateTime.Now.Year) && int.Parse(dr["ExpEndYear"].ToString()) >= (DateTime.Now.Year)))
                {
                    xrTableExp.Rows[index].Cells[0].Text = dr["Item"].ToString();
                    double exp = (dr["OccuranceType"].ToString().Equals("Monthly") ? double.Parse(dr["Amount"].ToString()) * 12 : double.Parse(dr["Amount"].ToString()));
                    xrTableExp.Rows[index].Cells[1].Text = exp.ToString();
                    totalExpenses = totalExpenses + exp;
                    index++;
                }
            }

            if (this.planner.FaceType.Equals("D"))
            {
                // Add logic for retirement exp with distribution face.
                double exp = 0;
                xrTableExp.Rows[index].Cells[0].Text = "Distribution face exp";
                xrTableExp.Rows[index].Cells[1].Text = exp.ToString();
                totalExpenses = totalExpenses + exp;
            }


            lblExpTotal.Text = totalExpenses.ToString();
            ExpenseOutFlowChart expenseOutFlowChart = new ExpenseOutFlowChart(_dtExpenses);
            expenseOutFlowChart.CreateDocument();
            this.xrSubreportExp.ReportSource = expenseOutFlowChart;
        }
       

        private void lblAmount0_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblAmount0.Text) && !lblAmount0.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                lblAmount0.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblAmount0.Text).ToString("N0", PlannerMainReport.Info);
            }
            else if (!string.IsNullOrEmpty(lblAmount0.Text) && string.IsNullOrEmpty((PlannerMainReport.planner.CurrencySymbol)))
            {
                lblAmount0.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblAmount0.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void lblAmount1_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblAmount1.Text) && !lblAmount1.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                lblAmount1.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblAmount1.Text).ToString("N0", PlannerMainReport.Info);
            }
            else if (!string.IsNullOrEmpty(lblAmount1.Text) && string.IsNullOrEmpty((PlannerMainReport.planner.CurrencySymbol)))
            {
                lblAmount1.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblAmount1.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void lblAmount2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblAmount2.Text) && !lblAmount2.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                lblAmount2.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblAmount2.Text).ToString("N0", PlannerMainReport.Info);
            }
            else if (!string.IsNullOrEmpty(lblAmount2.Text) && string.IsNullOrEmpty((PlannerMainReport.planner.CurrencySymbol)))
            {
                lblAmount2.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblAmount2.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void lblAmount3_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblAmount3.Text) && !lblAmount3.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                lblAmount3.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblAmount3.Text).ToString("N0", PlannerMainReport.Info);
            }
            else if (!string.IsNullOrEmpty(lblAmount3.Text) && string.IsNullOrEmpty((PlannerMainReport.planner.CurrencySymbol)))
            {
                lblAmount3.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblAmount3.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void lblAmount5_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblAmount5.Text) && !lblAmount5.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                lblAmount5.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblAmount5.Text).ToString("N0", PlannerMainReport.Info);
            }
            else if (!string.IsNullOrEmpty(lblAmount5.Text) && string.IsNullOrEmpty((PlannerMainReport.planner.CurrencySymbol)))
            {
                lblAmount5.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblAmount5.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void lblAmount6_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblAmount6.Text) && !lblAmount6.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                lblAmount6.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblAmount6.Text).ToString("N0", PlannerMainReport.Info);
            }
            else if (!string.IsNullOrEmpty(lblAmount6.Text) && string.IsNullOrEmpty((PlannerMainReport.planner.CurrencySymbol)))
            {
                lblAmount6.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblAmount6.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void lblAmount7_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblAmount7.Text) && !lblAmount7.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                lblAmount7.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblAmount7.Text).ToString("N0", PlannerMainReport.Info);
            }
            else if (!string.IsNullOrEmpty(lblAmount7.Text) && string.IsNullOrEmpty((PlannerMainReport.planner.CurrencySymbol)))
            {
                lblAmount7.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblAmount7.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void xrLabelIncomeTaxAmount_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrLabelIncomeTaxAmount.Text) && !xrLabelIncomeTaxAmount.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrLabelIncomeTaxAmount.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrLabelIncomeTaxAmount.Text).ToString("N0", PlannerMainReport.Info);
            }
            else if (!string.IsNullOrEmpty(xrLabelIncomeTaxAmount.Text) && string.IsNullOrEmpty((PlannerMainReport.planner.CurrencySymbol)))
            {
                xrLabelIncomeTaxAmount.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrLabelIncomeTaxAmount.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void xrTableCell28_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell28.Text) && !xrTableCell28.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell28.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell28.Text).ToString("N0", PlannerMainReport.Info);
            }
            else if (!string.IsNullOrEmpty(xrTableCell28.Text) && string.IsNullOrEmpty((PlannerMainReport.planner.CurrencySymbol)))
            {
                xrTableCell28.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell28.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void xrTableCell2_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell2.Text) && !xrTableCell2.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            { 
                xrTableCell2.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell2.Text).ToString("N0", PlannerMainReport.Info);
            }
            else if (!string.IsNullOrEmpty(xrTableCell2.Text) && string.IsNullOrEmpty((PlannerMainReport.planner.CurrencySymbol)))
            {
                xrTableCell2.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell2.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void xrTableCell4_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell4.Text) && !xrTableCell4.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell4.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell4.Text).ToString("N0", PlannerMainReport.Info);
            }
            else if (!string.IsNullOrEmpty(xrTableCell4.Text) && string.IsNullOrEmpty((PlannerMainReport.planner.CurrencySymbol)))
            {
                xrTableCell4.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell4.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void xrTableCell6_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell6.Text) && !xrTableCell6.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell6.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell6.Text).ToString("N0", PlannerMainReport.Info);
            }
            else if (!string.IsNullOrEmpty(xrTableCell6.Text) && string.IsNullOrEmpty((PlannerMainReport.planner.CurrencySymbol)))
            {
                xrTableCell6.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell6.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void xrTableCell8_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {

            if (!string.IsNullOrEmpty(xrTableCell8.Text) && !xrTableCell8.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell8.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell8.Text).ToString("N0", PlannerMainReport.Info);
            }
            else if (!string.IsNullOrEmpty(xrTableCell8.Text) && string.IsNullOrEmpty((PlannerMainReport.planner.CurrencySymbol)))
            {
                xrTableCell8.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell8.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void xrTableCell10_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell10.Text) && !xrTableCell10.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell10.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell10.Text).ToString("N0", PlannerMainReport.Info);
            }
            else if (!string.IsNullOrEmpty(xrTableCell10.Text) && string.IsNullOrEmpty((PlannerMainReport.planner.CurrencySymbol)))
            {
                xrTableCell10.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell10.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void xrTableCell14_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell14.Text) && !xrTableCell10.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell14.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell14.Text).ToString("N0", PlannerMainReport.Info);
            }
            else if (!string.IsNullOrEmpty(xrTableCell14.Text) && string.IsNullOrEmpty((PlannerMainReport.planner.CurrencySymbol)))
            {
                xrTableCell14.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell14.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void xrTableCell16_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell16.Text) && !xrTableCell16.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell16.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell16.Text).ToString("N0", PlannerMainReport.Info);
            }
            else if (!string.IsNullOrEmpty(xrTableCell16.Text) && string.IsNullOrEmpty((PlannerMainReport.planner.CurrencySymbol)))
            {
                xrTableCell16.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell16.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void xrTableCell24_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell24.Text) && !xrTableCell24.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell24.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell24.Text).ToString("N0", PlannerMainReport.Info);
            }
            else if (!string.IsNullOrEmpty(xrTableCell24.Text) && string.IsNullOrEmpty((PlannerMainReport.planner.CurrencySymbol)))
            {
                xrTableCell24.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell24.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void xrTableCell22_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell22.Text) && !xrTableCell22.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell22.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell22.Text).ToString("N0", PlannerMainReport.Info);
            }
            else if (!string.IsNullOrEmpty(xrTableCell22.Text) && string.IsNullOrEmpty((PlannerMainReport.planner.CurrencySymbol)))
            {
                xrTableCell22.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell22.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void lblExpTotal_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblExpTotal.Text) && !lblExpTotal.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                lblExpTotal.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblExpTotal.Text).ToString("N0", PlannerMainReport.Info);
            }
            else if (!string.IsNullOrEmpty(lblExpTotal.Text) && string.IsNullOrEmpty((PlannerMainReport.planner.CurrencySymbol)))
            {
                lblExpTotal.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblExpTotal.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void xrLabelNetTotalIncome_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrLabelNetTotalIncome.Text) && !xrLabelNetTotalIncome.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrLabelNetTotalIncome.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrLabelNetTotalIncome.Text).ToString("N0", PlannerMainReport.Info);
            }
            else if (!string.IsNullOrEmpty(xrLabelNetTotalIncome.Text) && string.IsNullOrEmpty((PlannerMainReport.planner.CurrencySymbol)))
            {
                xrLabelNetTotalIncome.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrLabelNetTotalIncome.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void xrTableCell29_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell29.Text) && !xrTableCell29.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell29.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell29.Text).ToString("N0", PlannerMainReport.Info);
            }
            else if (!string.IsNullOrEmpty(xrTableCell29.Text) && string.IsNullOrEmpty((PlannerMainReport.planner.CurrencySymbol)))
            {
                xrTableCell29.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell29.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void xrTableCell33_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell33.Text) && !xrTableCell33.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell33.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell33.Text).ToString("N0", PlannerMainReport.Info);
            }
            else if (!string.IsNullOrEmpty(xrTableCell33.Text) && string.IsNullOrEmpty((PlannerMainReport.planner.CurrencySymbol)))
            {
                xrTableCell33.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell33.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void xrTableCell35_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell35.Text) && !xrTableCell35.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell35.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell35.Text).ToString("N0", PlannerMainReport.Info);
            }
            else if (!string.IsNullOrEmpty(xrTableCell35.Text) && string.IsNullOrEmpty((PlannerMainReport.planner.CurrencySymbol)))
            {
                xrTableCell35.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell35.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void xrTableCell31_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(xrTableCell31.Text) && !xrTableCell31.Text.StartsWith(PlannerMainReport.planner.CurrencySymbol))
            {
                xrTableCell31.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell31.Text).ToString("N0", PlannerMainReport.Info);
            }
            else if (!string.IsNullOrEmpty(xrTableCell31.Text) && string.IsNullOrEmpty((PlannerMainReport.planner.CurrencySymbol)))
            {
                xrTableCell31.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(xrTableCell31.Text).ToString("N0", PlannerMainReport.Info);
            }
        }
    }
}
