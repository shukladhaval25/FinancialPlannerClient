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
using FinancialPlanner.Common.Model;

namespace FinancialPlannerClient.Clients
{
    public partial class LoanSchedule : DevExpress.XtraEditors.XtraForm
    {
        Loan loan;
        DataTable dtLoanScheduler;
        public LoanSchedule(Loan loan)
        {
            InitializeComponent();
            if (loan == null)
                throw new ArgumentNullException("loan", "Loan argument is null.");

            this.loan = loan;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoanSchedule_Load(object sender, EventArgs e)
        {
            showloansData();
            createLoanSchedulerTable();
            calculateLoanSchedule();
            displayDataOnGrid();
        }

        private void showloansData()
        {
            lblDateOfLoanValue.Text = loan.LoanStartDate.ToShortDateString();
            lblEMIValue.Text = loan.Emis.ToString();
            lblInterestRateValue.Text = loan.InterestRate.ToString("##.##") + " %";
            lblPrincipalAmountValue.Text = loan.OutstandingAmt.ToString("#,###");
            lblTenureMonths.Text = loan.TermLeftInMonths.ToString();

        }

        private void displayDataOnGrid()
        {
            grdLoanScheduler.DataSource = dtLoanScheduler;
        }

        private void calculateLoanSchedule()
        {
            int loanMonths = loan.TermLeftInMonths;
            DateTime loanStartDate = loan.LoanStartDate;
            double outstandingLoanAmount = loan.OutstandingAmt;
            for(int currentMonth =1; currentMonth <= loanMonths; currentMonth++)
            {
                DataRow drLoan = dtLoanScheduler.NewRow();
                drLoan["Sr.No"] = currentMonth;
                drLoan["Enstallment Date"] = loanStartDate;
                drLoan["BeginingPrincipalAmount"] = outstandingLoanAmount;
                drLoan["EMI"] = loan.Emis;
                drLoan["InterestRate"] = loan.InterestRate;
                double interestAmount =  (((outstandingLoanAmount * (double)loan.InterestRate) /100)/ 12);
                double principalAmount = loan.Emis - interestAmount;
                outstandingLoanAmount = outstandingLoanAmount - principalAmount;
                dtLoanScheduler.Rows.Add(drLoan);
                loanStartDate = loanStartDate.AddMonths(1);
            }
        }

        private void createLoanSchedulerTable()
        {
            dtLoanScheduler = new DataTable();
            dtLoanScheduler.Columns.Add("Sr.No", typeof(System.Int64));
            dtLoanScheduler.Columns.Add("Enstallment Date", typeof(System.DateTime));
            dtLoanScheduler.Columns.Add("BeginingPrincipalAmount", typeof(System.Double));
            dtLoanScheduler.Columns.Add("EMI", typeof(System.Double));
            dtLoanScheduler.Columns.Add("InterestRate", typeof(System.Decimal));
            dtLoanScheduler.Columns.Add("Interest", typeof(System.Double), 
                "((BeginingPrincipalAmount * InterestRate)/100)/12");
            dtLoanScheduler.Columns.Add("Principal", typeof(System.Double),"EMI -Interest");            
            dtLoanScheduler.Columns.Add("RemainingPrincipalAmount", typeof(System.Double),
                "BeginingPrincipalAmount - Principal");
        }
    }
}