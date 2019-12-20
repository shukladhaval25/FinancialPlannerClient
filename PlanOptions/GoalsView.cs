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
        Client client;
        public GoalsView(int planId,Client client)
        {
            InitializeComponent();
            this.planId = planId;
            this.client = client;
        }

        private void chkLaonForGoal_CheckedChanged(object sender, EventArgs e)
        {
            grpLoanForGoal.Enabled = chkLaonForGoal.Checked;
        }

        private void rdoGoalType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoGoalType.SelectedIndex == 1)
            {
                chkLaonForGoal.Visible = false;
                grpLoanForGoal.Visible = false;
                cmbCategory.Text = "Retirement";
                cmbCategory.ReadOnly = true;
                lblAmountTitle.Text = "Annual Expense (Today's Value):";
                if (cmbCategory.Tag == null || cmbCategory.Tag.ToString() == "0")
                    setRetirementStartYearAndEndYear();
                lblOtherAnnualRetirementExp.Text = "Travelling && other annual expense (Today's Value)";
                lblOtherAnnualRetirementExp.Visible = true;
                txtOtherAnnualRetirementExp.Visible = true;
                txtOtherAnnualRetirementExp.Text = "0";
            }
            else
            {
                chkLaonForGoal.Visible = true;
                grpLoanForGoal.Visible = true;
                cmbCategory.ReadOnly = false;
                cmbCategory.Text = "";
                txtGoalStartYear.Text = "";
                txtGoalEndYear.Text = "";
                lblOtherAnnualRetirementExp.Visible = false;
                txtOtherAnnualRetirementExp.Visible = false;
            }

        }
        private void setRetirementStartYearAndEndYear()
        {
            PlannerAssumptionInfo plannerAssumptionInfo = new PlannerAssumptionInfo();
            PlannerAssumption plannerAssumption = plannerAssumptionInfo.GetAll(this.planId);
            int retirementYear = (client.DOB.Year + plannerAssumption.ClientRetirementAge);
            int endOfLifeYear = (client.DOB.Year + plannerAssumption.ClientLifeExpectancy) + 1;
            txtGoalStartYear.Text = retirementYear.ToString();
            txtGoalEndYear.Text = endOfLifeYear.ToString();
        }

        private void navigateToSelectedPage()
        {
            navigationFrameGoals.SelectedPage = (rdoGoalType.SelectedIndex == 0) ?
                            navigationPageRegGoal : navigationPageRetGoal;
        }

        private void GoalsView_Load(object sender, EventArgs e)
        {
            Program.ApplyPermission(this.Tag.ToString(), this);
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
                txtOtherAnnualRetirementExp.Text = goals.OtherAmount.ToString("#,##0.00");
                txtGoalStartYear.Text = goals.StartYear;
                txtInflationRate.Text = goals.InflationRate.ToString("##.00");
                txtGoalEndYear.Text = goals.EndYear;
                chkEligbileForInsuranceCoverage.Checked = goals.EligibleForInsuranceCoverage;
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
            if (gridViewGoals.SelectedRowsCount > 0)
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
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grpGoalsDetail.Enabled = true;
            rdoGoalType.Enabled = true;
            cmbCategory.Enabled = true;
            cmbCategory.ReadOnly = false;
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
            int maxPriority = string.IsNullOrEmpty(_dtGoals.Compute("Max(Priority)", "").ToString()) ? 0 :
                int.Parse(_dtGoals.Compute("Max(Priority)","").ToString());
            numPriority.Text = (maxPriority + 1).ToString();
            txtGoalDescription.Text = "";
            chkLaonForGoal.Checked = false;
            txtLoanForGoalAmount.Text = "";
            txtLoanForGoalAmount.Tag = "0";
            txtLoanForGoalEMI.Text = "";
            txtLoanForGoalROI.Text = "";
            txtLoanForGoalYears.Text = "";
            txtLoanForGoalStartYear.Text = "";
            txtLoanForGoalEndYear.Text = "";
            chkEligbileForInsuranceCoverage.Checked = false;
        }

        private void btnCloseClientInfo_Click(object sender, EventArgs e)
        {
            Goals goals = new GoalsInfo().GetGoalsInfo(gridViewGoals, _dtGoals);
            displayGoalsData(goals);
            grpGoalsDetail.Enabled = false;
        }

        private void btnSaveClientGoal_Click(object sender, EventArgs e)
        {
            try
            {
                Goals goals = getGoalsData();
                if (!repeatGoalValidated(goals))
                {
                    return;
                }
                GoalsInfo goalsInfo = new GoalsInfo();

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
            catch(Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Unable to save record." + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool repeatGoalValidated(Goals goals)
        {
            if (goals != null && goals.Id != 0)
                return true;

            if (string.IsNullOrEmpty(numPriority.Value.ToString()))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Please enter valid value for priority of goal.", "Invalid value", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (!string.IsNullOrEmpty(txtGoalStartYear.Text) && !string.IsNullOrEmpty(txtGoalEndYear.Text))
            {
                if (string.IsNullOrEmpty(txtGoalRecurrence.Text))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Please enter goal frequency value.", "Invalid value", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                return isValidPriorityNumberForGoal();
            }
            return true;
        }

        private bool isValidPriorityNumberForGoal()
        {
            if (!isDuplicatePriorityNumber(numPriority.Value.ToString()))
            {
                int startYear = int.Parse(txtGoalStartYear.Text);
                int endYear = int.Parse(txtGoalEndYear.Text);
                int frequency = (string.IsNullOrEmpty(txtGoalRecurrence.Text) ? 1 : int.Parse(txtGoalRecurrence.Text));
                bool isPriorityAssignDuplicate = false;
                int currentPriorityNumber = int.Parse(numPriority.Value.ToString());
                for (int year = startYear; year < endYear;)
                {
                    
                    isPriorityAssignDuplicate = isDuplicatePriorityNumber(currentPriorityNumber.ToString());
                    if (isPriorityAssignDuplicate)
                        return false;
                    currentPriorityNumber++;
                    year = year + frequency;
                }
                return true;
            }
            else
                return false;
        }

        private bool isDuplicatePriorityNumber(string priorityNumber)
        {
            DataRow[] dataRows = _dtGoals.Select("Priority = '" + priorityNumber + "'");
            if (dataRows.Length > 0)
            {
                XtraMessageBox.Show("Please enter different priority number.", "Duplicate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return true;
            }
            return false;
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
            Goals.EligibleForInsuranceCoverage = chkEligbileForInsuranceCoverage.Checked;
            Goals.OtherAmount = (!string.IsNullOrEmpty(txtOtherAnnualRetirementExp.Text)) ?
                double.Parse(txtOtherAnnualRetirementExp.Text) : 0;

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

        private void txtInflationRate_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            //if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            //{
            //    e.Handled = true;
            //    return;
            //}

            //// checks to make sure only 1 decimal is allowed
            //if (e.KeyChar == 46)
            //{
            //    if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
            //        e.Handled = true;
            //}
        }

        private void txtGoalName_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void txtGoalCurrentValue_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtGoalCurrentValue.Text))
                e.Cancel = !FinancialPlanner.Common.Validation.IsDigit(txtGoalCurrentValue.Text);
        }

        private void txtGoalStartYear_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtGoalStartYear.Text))
                e.Cancel = !FinancialPlanner.Common.Validation.IsDigit(txtGoalStartYear.Text);
        }

        private void txtGoalEndYear_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtGoalEndYear.Text))
                e.Cancel = !FinancialPlanner.Common.Validation.IsDigit(txtGoalEndYear.Text);
        }

        private void txtGoalRecurrence_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtGoalRecurrence.Text))
                e.Cancel = !FinancialPlanner.Common.Validation.IsDigit(txtGoalRecurrence.Text);
        }

        private void txtLoanForGoalAmount_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLoanForGoalAmount.Text))
                e.Cancel = !FinancialPlanner.Common.Validation.IsDigit(txtLoanForGoalAmount.Text);
        }

        private void txtLoanForGoalEMI_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLoanForGoalEMI.Text))
                e.Cancel = !FinancialPlanner.Common.Validation.IsDigit(txtLoanForGoalEMI.Text);
        }

        private void txtLoanForGoalROI_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLoanForGoalROI.Text))
                e.Cancel = !FinancialPlanner.Common.Validation.IsDecimal(txtLoanForGoalROI.Text);
        }

        private void txtLoanForGoalYears_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLoanForGoalYears.Text))
                e.Cancel = !FinancialPlanner.Common.Validation.IsDigit(txtLoanForGoalYears.Text);
        }

        private void txtLoanForGoalStartYear_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLoanForGoalStartYear.Text))
                e.Cancel = !FinancialPlanner.Common.Validation.IsDigit(txtLoanForGoalStartYear.Text);
        }

        private void txtLoanForGoalEndYear_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLoanForGoalEndYear.Text))
                e.Cancel = !FinancialPlanner.Common.Validation.IsDigit(txtLoanForGoalEndYear.Text);
        }

        private void txtInflationRate_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtInflationRate.Text))
                e.Cancel = !FinancialPlanner.Common.Validation.IsDigit(txtInflationRate.Text);
        }

        private void txtOtherAnnualRetirementExp_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtOtherAnnualRetirementExp.Text))
                e.Cancel = !FinancialPlanner.Common.Validation.IsDigit(txtOtherAnnualRetirementExp.Text);
        }
    }
}
