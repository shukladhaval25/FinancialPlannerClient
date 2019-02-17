using DevExpress.XtraEditors;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.PlannerInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace FinancialPlannerClient.PlanOptions
{
    public partial class GoalsView : DevExpress.XtraEditors.XtraForm
    {
        private DataTable _dtGoals;
        private const string RETIREMENT_GOAL_TYPE = "Retirement";
        int planId;

        public GoalsView(int planId)
        {
            InitializeComponent();
            this.planId = planId;
        }

        private void chkLaonForGoal_CheckedChanged(object sender, EventArgs e)
        {
            grpLoanForGoal.Enabled = chkLaonForGoal.Checked;           
        }

        private void rdoGoalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            navigateToSelectedPage();

        }

        private void navigateToSelectedPage()
        {
            navigationFrameGoals.SelectedPage = (rdoGoalType.SelectedIndex == 0) ?
                            navigationPageRegGoal : navigationPageRetGoal;
        }

        private void GoalsView_Load(object sender, EventArgs e)
        {
            rdoGoalType.SelectedIndex = 0;
            navigateToSelectedPage();
            fillupGoalsInfo();
        }

        private void fillupGoalsInfo()
        {
            GoalsInfo GoalsInfo = new GoalsInfo();
            List<Goals> lstIncome = (List<Goals>)GoalsInfo.GetAll(planId);
            _dtGoals = ListtoDataTable.ToDataTable(lstIncome);
            grdGoals.DataSource = _dtGoals;
            GoalsInfo.FillGrid(gridViewGoals);
        }

        private void gridViewGoals_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            Goals goals = new GoalsInfo().GetGoalsInfo(gridViewGoals, _dtGoals);
            displayGoalsData(goals);
        }
        private void displayGoalsData(Goals goals)
        {
            if (goals != null)
            {
                rdoGoalType.SelectedIndex =
                    (goals.Category == RETIREMENT_GOAL_TYPE) ? 1 : 0;
               
                cmbCategory.Tag = goals.Id;
                cmbCategory.Text = goals.Category;
                cmbCategory.Enabled = (goals.Category == RETIREMENT_GOAL_TYPE) ? false : true;
                txtGoalName.Text = goals.Name;
                txtGoalCurrentValue.Text = goals.Amount.ToString("#,##0.00");
                txtGoalStartYear.Text = goals.StartYear;
                txtInflationRate.Text = goals.InflationRate.ToString("##.00");
                txtGoalEndYear.Text = goals.EndYear;
                if (goals.Recurrence != null)
                    txtGoalRecurrence.Text = goals.Recurrence.Value.ToString();
                else
                    txtGoalRecurrence.Text = "";
                numPriority.Value = goals.Priority;
                txtGoalDescription.Text = goals.Description;
                if (goals.LoanForGoal != null)
                {
                    chkLaonForGoal.Checked = true;
                    displayLaonForGoalData(goals);
                }
                else
                {
                    chkLaonForGoal.Checked = false;
                    txtLoanForGoalAmount.Tag = "0";
                    txtLoanForGoalAmount.Text = "";
                    txtLoanForGoalEMI.Text = "";
                    txtLoanForGoalROI.Text = "";
                    txtLoanForGoalYears.Text = "";
                    txtLoanForGoalStartYear.Text = "";
                    txtLoanForGoalEndYear.Text = "";
                }
            }
        }

        private void displayLaonForGoalData(Goals goals)
        {
            txtLoanForGoalAmount.Text = goals.LoanForGoal.LoanAmount.ToString("#,##0.00");
            txtLoanForGoalAmount.Tag = goals.LoanForGoal.Id.ToString();
            txtLoanForGoalEMI.Text = goals.LoanForGoal.EMI.ToString("#,##0.00");
            txtLoanForGoalROI.Text = goals.LoanForGoal.ROI.ToString();
            txtLoanForGoalYears.Text = goals.LoanForGoal.LoanYears.ToString();
            txtLoanForGoalStartYear.Text = goals.LoanForGoal.StratYear.ToString();
            txtLoanForGoalEndYear.Text = goals.LoanForGoal.EndYear.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            Goals goals = new GoalsInfo().GetGoalsInfo(gridViewGoals, _dtGoals);
            displayGoalsData(goals);
            grpGoalsDetail.Enabled = true;
            rdoGoalType.Enabled = false;
            navigationFrameGoals.Enabled = true;            
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (XtraMessageBox.Show("Are you sure, you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GoalsInfo goalsInfo = new GoalsInfo();
                Goals goals = goalsInfo.GetGoalsInfo(gridViewGoals, _dtGoals);
                if (!goalsInfo.Delete(goals))
                    XtraMessageBox.Show("Unable to delete selected record. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fillupGoalsInfo();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grpGoalsDetail.Enabled = true;
            rdoGoalType.Enabled = true;
            setDefaultGoalsValue();
        }

        private void setDefaultGoalsValue()
        {
            cmbCategory.Tag = "0";
            cmbCategory.Text = "";
            txtGoalName.Text = "";
            txtGoalCurrentValue.Text = "0";
            txtGoalStartYear.Text = "";
            txtGoalEndYear.Text = "";
            txtGoalRecurrence.Text = "";
            numPriority.Text = "";
            txtGoalDescription.Text = "";
            chkLaonForGoal.Checked = false;
            txtLoanForGoalAmount.Text = "";
            txtLoanForGoalAmount.Tag = "0";
            txtLoanForGoalEMI.Text = "";
            txtLoanForGoalROI.Text = "";
            txtLoanForGoalYears.Text = "";
            txtLoanForGoalStartYear.Text = "";
            txtLoanForGoalEndYear.Text = "";
        }

        private void btnCloseClientInfo_Click(object sender, EventArgs e)
        {
            Goals goals = new GoalsInfo().GetGoalsInfo(gridViewGoals, _dtGoals);
            displayGoalsData(goals);
            grpGoalsDetail.Enabled = false;
        }

        private void btnSaveClientGoal_Click(object sender, EventArgs e)
        {
            GoalsInfo goalsInfo = new GoalsInfo();
            Goals goals = getGoalsData();
            bool isSaved = false;

            if (goals != null && goals.Id == 0)
                isSaved = goalsInfo.Add(goals);
            else
                isSaved = goalsInfo.Update(goals);

            if (isSaved)
            {
                MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fillupGoalsInfo();
                grpGoalsDetail.Enabled = false;
            }
            else
                MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private Goals getGoalsData()
        {
            Goals Goals = new Goals();
            Goals.Id = int.Parse(cmbCategory.Tag.ToString());
            Goals.Pid = this.planId;
            Goals.Category = cmbCategory.Text;
            Goals.Name = txtGoalName.Text;
            Goals.Amount = double.Parse(txtGoalCurrentValue.Text);
            Goals.Recurrence = string.IsNullOrEmpty(txtGoalRecurrence.Text) ? 0 : int.Parse(txtGoalRecurrence.Text);
            Goals.Priority = int.Parse(numPriority.Value.ToString());
            Goals.Description = txtGoalDescription.Text;
            Goals.StartYear = txtGoalStartYear.Text;
            Goals.EndYear = txtGoalEndYear.Text;
            Goals.InflationRate = decimal.Parse(txtInflationRate.Text);
            Goals.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            Goals.CreatedBy = Program.CurrentUser.Id;
            Goals.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            Goals.UpdatedBy = Program.CurrentUser.Id;
            Goals.UpdatedByUserName = Program.CurrentUser.UserName;
            Goals.MachineName = Environment.MachineName;

            if (chkLaonForGoal.Checked)
                Goals.LoanForGoal = getLoanForGoalData();

            return Goals;
        }
        private LoanForGoal getLoanForGoalData()
        {
            LoanForGoal goalLoan = new LoanForGoal();
            goalLoan.Id = int.Parse(txtLoanForGoalAmount.Tag.ToString());
            goalLoan.GoalId = int.Parse(cmbCategory.Tag.ToString());
            goalLoan.LoanAmount = double.Parse(txtLoanForGoalAmount.Text);
            goalLoan.EMI = double.Parse(txtLoanForGoalEMI.Text);
            goalLoan.ROI = decimal.Parse(txtLoanForGoalROI.Text);
            goalLoan.LoanYears = int.Parse(txtLoanForGoalYears.Text);
            goalLoan.StratYear = int.Parse(txtLoanForGoalStartYear.Text);
            goalLoan.EndYear = int.Parse(txtLoanForGoalEndYear.Text);
            goalLoan.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            goalLoan.CreatedBy = Program.CurrentUser.Id;
            goalLoan.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            goalLoan.UpdatedBy = Program.CurrentUser.Id;
            goalLoan.UpdatedByUserName = Program.CurrentUser.UserName;
            goalLoan.MachineName = Environment.MachineName;
            return goalLoan;
        }
    }
}
