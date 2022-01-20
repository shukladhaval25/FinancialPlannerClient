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
        Planner planner;
        Client client;
        private PlannerAssumption plannerAssumption;
        private PersonalInformation _personalInfo;

        public GoalsView(Planner planner, Client client)
        {
            InitializeComponent();
            this.planner = planner;
            this.planId = planner.ID;
            this.client = client;
            btnAdd.Visible = !this.planner.IsPlanLocked;
            btnDelete.Visible = !this.planner.IsPlanLocked;
            btnSaveClientGoal.Visible = !this.planner.IsPlanLocked;
        }

        private void chkLaonForGoal_CheckedChanged(object sender, EventArgs e)
        {
            grpLoanForGoal.Enabled = chkLaonForGoal.Checked;
            if (grpLoanForGoal.Enabled)
            {
                double currentValueOfGoal = double.Parse(txtGoalCurrentValue.Text);
                double futureValueOfGoal = futureValue(currentValueOfGoal, decimal.Parse(txtInflationRate.Text), int.Parse(txtGoalStartYear.Text) - this.planner.StartDate.Year);
                lblFV.Text = futureValueOfGoal.ToString("N0", PlannerMainReport.Info);
            }
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
                txtInflationRate.Text = plannerAssumption.PreRetirementInflactionRate.ToString();
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
            int retirementYear = (client.DOB.Year + plannerAssumption.ClientRetirementAge + 1);
            int endOfLifeYear = (client.DOB.Year + plannerAssumption.ClientLifeExpectancy) + 1;
            int spouseLifeYear = (_personalInfo.Spouse.DOB.Year + plannerAssumption.SpouseLifeExpectancy) + 1;

            endOfLifeYear = (endOfLifeYear > spouseLifeYear) ? endOfLifeYear : spouseLifeYear;

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
            if (planId != 0)
                fillupAssumptionInfo();

            ClientPersonalInfo clientPersonalInfo = new ClientPersonalInfo();
            _personalInfo = clientPersonalInfo.Get(client.ID);
        }

        private void fillupAssumptionInfo()
        {
            PlannerAssumptionInfo plannerassumptionInfo = new PlannerAssumptionInfo();
            plannerAssumption = plannerassumptionInfo.GetAll(planId);
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
            if (grpLoanForGoal.Enabled)
            {
                double currentValueOfGoal = double.Parse(txtGoalCurrentValue.Text);
                double futureValueOfGoal = futureValue(currentValueOfGoal, decimal.Parse(txtInflationRate.Text), int.Parse(txtGoalStartYear.Text) - this.planner.StartDate.Year);
                lblFV.Text = futureValueOfGoal.ToString("N0", PlannerMainReport.Info);
            }
            txtLoanForGoalAmount.Text = goals.LoanForGoal.LoanAmount.ToString("N0", PlannerMainReport.Info);
            txtLoanForGoalAmount.Tag = goals.LoanForGoal.Id.ToString();
            txtLoanForGoalEMI.Text = goals.LoanForGoal.EMI.ToString("N0", PlannerMainReport.Info);
            txtLoanForGoalROI.Text = goals.LoanForGoal.ROI.ToString();
            txtLoanForGoalYears.Text = goals.LoanForGoal.LoanYears.ToString();
            txtLoanForGoalStartYear.Text = goals.LoanForGoal.StratYear.ToString();
            txtLoanForGoalEndYear.Text = goals.LoanForGoal.EndYear.ToString();
            txtGoalLoanPortion.Text = goals.LoanForGoal.LoanPortion.ToString();
            //txtGoalLoanPortion.Text = (((100 * goals.Amount) / goals.LoanForGoal.LoanAmount)).ToString();

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
            txtOtherAnnualRetirementExp.Text = "0";
            txtGoalStartYear.Text = "";
            txtGoalEndYear.Text = "";
            txtGoalRecurrence.Text = "";
            int maxPriority = string.IsNullOrEmpty(_dtGoals.Compute("Max(Priority)", "").ToString()) ? 0 :
                int.Parse(_dtGoals.Compute("Max(Priority)", "").ToString());
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

                if (MessageBox.Show("Are you sure that entered inflation rate (%) is correct?", "Inflation Rate", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                    return;

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
            catch (Exception ex)
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
                int frequency = ((string.IsNullOrEmpty(txtGoalRecurrence.Text) || txtGoalRecurrence.Text == "0")
                    ? 1 : int.Parse(txtGoalRecurrence.Text));
                bool isPriorityAssignDuplicate = false;
                int currentPriorityNumber = int.Parse(numPriority.Value.ToString());
                if (cmbCategory.Text != "Retirement")
                {
                    for (int year = startYear; year < endYear;)
                    {

                        isPriorityAssignDuplicate = isDuplicatePriorityNumber(currentPriorityNumber.ToString());
                        if (isPriorityAssignDuplicate)
                            return false;
                        currentPriorityNumber++;
                        year = year + frequency;
                    }
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
            goalLoan.LoanPortion = decimal.Parse(txtGoalLoanPortion.Text);
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
            if (txtGoalName.Text.Contains("'"))
            {
                XtraMessageBox.Show("Single quote character not allowd here.");
                e.Cancel = true;
            }
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

        private void btnCalculateLoan_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtGoalCurrentValue.Text) || string.IsNullOrEmpty(txtGoalStartYear.Text) || string.IsNullOrEmpty(txtInflationRate.Text))
            {
                XtraMessageBox.Show("Please enter require data like Goal current value,Goal start year, Inflation Rate.", "Enter Require Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }
            //if (string.IsNullOrEmpty(txtGoalLoanPortion.Text))
            //{
            //    XtraMessageBox.Show("Please enter loan portion (%) data.", "Enter Require Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            //    return;
            //}
            if (string.IsNullOrEmpty(txtLoanForGoalAmount.Text) &&
               string.IsNullOrEmpty(txtLoanForGoalEMI.Text) &&
               string.IsNullOrEmpty(txtLoanForGoalROI.Text) &&
               string.IsNullOrEmpty(txtLoanForGoalYears.Text))
            {
                XtraMessageBox.Show("Please enter require data to calculate loan formula.", "Enter Require Data", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            CalculationType calculationType = getCalculationType();
            LoanCalcuation(calculationType);
        }

        private void LoanCalcuation(CalculationType calculationType)
        {
            try
            {
                double currentValueOfLoan = double.Parse(txtGoalCurrentValue.Text);
                double principalAmount = 0;
                double interestRate = 0;
                double numberOfYears = 0;
                double emi = 0;

                switch (calculationType)
                {
                    case CalculationType.OutstandingAmount:
                        interestRate = double.Parse(txtLoanForGoalROI.Text) / 1200;
                        numberOfYears = double.Parse(txtLoanForGoalYears.Text) * 12;
                        emi = double.Parse(txtLoanForGoalEMI.Text) * -1;
                        double outstandingAmt = Microsoft.VisualBasic.Financial.PV(interestRate, numberOfYears, emi);
                        txtLoanForGoalAmount.Text = outstandingAmt.ToString();
                        double loanPortionRatio = outstandingAmt * 100 / double.Parse(lblFV.Text);
                        txtGoalLoanPortion.Text = loanPortionRatio.ToString();
                        break;
                    case CalculationType.EMI:
                       // PMT(E21, E23, -E17)
                        principalAmount = double.Parse(txtLoanForGoalAmount.Text);
                        principalAmount = double.Parse(txtLoanForGoalAmount.Text);
                        principalAmount = double.Parse(txtLoanForGoalAmount.Text);
                        principalAmount = double.Parse(txtLoanForGoalAmount.Text);
                        interestRate = double.Parse(txtLoanForGoalROI.Text) / 1200;
                        numberOfYears = double.Parse(txtLoanForGoalYears.Text) * 12;
                        // E = P * r * Math.Pow(1 + r, n) / (Math.Pow(1 + r, n) - 1);
                        //emi = principalAmount * interestRate * Math.Pow(1 + interestRate, numberOfYears) / (Math.Pow(1 + interestRate, numberOfYears) - 1);
                        emi = Microsoft.VisualBasic.Financial.Pmt(interestRate, numberOfYears, principalAmount * -1);
                        txtLoanForGoalEMI.Text = Math.Round(emi).ToString();
                        break;
                    case CalculationType.Period:
                        //NPER(E31, E29, -E27)
                        interestRate = double.Parse(txtLoanForGoalROI.Text) / 1200;
                        emi = double.Parse(txtLoanForGoalEMI.Text);
                        principalAmount = double.Parse(txtLoanForGoalAmount.Text) * -1;
                        double period = Microsoft.VisualBasic.Financial.NPer(interestRate, emi, principalAmount);
                        txtLoanForGoalYears.Text = (period / 12).ToString();

                        break;
                    case CalculationType.RateOfInterest:
                        double pAmount = double.Parse(txtLoanForGoalAmount.Text) * -1;
                        double nPer = double.Parse(txtLoanForGoalYears.Text) * 12;
                        emi = double.Parse(txtLoanForGoalEMI.Text);

                        double r = Microsoft.VisualBasic.Financial.Rate(nPer, emi, pAmount);
                        r = r * 1200;
                        txtLoanForGoalROI.Text = r.ToString();

                        //double totalLoanAmountWithInterest = emi * n;
                        //var r = ((totalLoanAmountWithInterest - pAmount) / pAmount) * 100;


                        //principalAmount = double.Parse(txtLoanForGoalAmount.Text);
                        ////interestRate = float.Parse(txtLoanForGoalROI.Text) / 1200;
                        //numberOfYears = int.Parse(txtLoanForGoalYears.Text) * 12;
                        //// E = P * r * Math.Pow(1 + r, n) / (Math.Pow(1 + r, n) - 1);
                        //emi = double.Parse(txtLoanForGoalEMI.Text);
                        //var r = (principalAmount * emi) / Math.Pow(1 + emi, numberOfYears);
                        //txtLoanForGoalEMI.Text = Math.Round(emi).ToString();

                        break;

                }
            }
            catch (Exception ex)
            {

            }
        }

        private CalculationType getCalculationType()
        {
            if (string.IsNullOrEmpty(txtLoanForGoalAmount.Text) &&
                !string.IsNullOrEmpty(txtLoanForGoalEMI.Text) &&
                !string.IsNullOrEmpty(txtLoanForGoalROI.Text) &&
                !string.IsNullOrEmpty(txtLoanForGoalYears.Text) &&
                cmbLoanCalculationType.Text.Equals("Calculate Outstanding Amount"))
            {
                return CalculationType.OutstandingAmount;
            }

            if (!string.IsNullOrEmpty(txtLoanForGoalAmount.Text) &&
                string.IsNullOrEmpty(txtLoanForGoalEMI.Text) &&
                !string.IsNullOrEmpty(txtLoanForGoalROI.Text) &&
                !string.IsNullOrEmpty(txtLoanForGoalYears.Text) &&
                cmbLoanCalculationType.Text.Equals("Calculate EMI"))
            {
                return CalculationType.EMI;
            }

            if (!string.IsNullOrEmpty(txtLoanForGoalAmount.Text) &&
                !string.IsNullOrEmpty(txtLoanForGoalEMI.Text) &&
                !string.IsNullOrEmpty(txtLoanForGoalROI.Text) &&
                string.IsNullOrEmpty(txtLoanForGoalYears.Text))
            {
                return CalculationType.Period;
            }

            if (!string.IsNullOrEmpty(txtLoanForGoalAmount.Text) &&
             !string.IsNullOrEmpty(txtLoanForGoalEMI.Text) &&
             string.IsNullOrEmpty(txtLoanForGoalROI.Text) &&
             !string.IsNullOrEmpty(txtLoanForGoalYears.Text) && cmbLoanCalculationType.Text.Equals("Calculate Rate Of Interest"))
            {
                return CalculationType.RateOfInterest;
            }

            return CalculationType.None;
        }

        private static double presentValue(double futureValue, decimal interest_rate, int timePeriodInYears)
        {
            //PV = FV / (1 + I)T;
            interest_rate = interest_rate / 100;
            decimal presentValue = (decimal)futureValue /
                ((decimal)Math.Pow((double)(1 + interest_rate), (double)timePeriodInYears));

            return Math.Round((double)presentValue);
        }

        private static double futureValue(double presentValue, decimal interest_rate, int timePeriodInYears)
        {
            //FV = PV * (1 + I)T;
            interest_rate = interest_rate / 100;
            double futureValue = presentValue *
                (Math.Pow((double)(1 + interest_rate), (double)timePeriodInYears));

            return Math.Round(futureValue);
        }

        private void txtGoalLoanPortion_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtGoalLoanPortion.Text))
            {
                double currentValueOfGoal = double.Parse(txtGoalCurrentValue.Text);
                double futureValueOfGoal = futureValue(currentValueOfGoal, decimal.Parse(txtInflationRate.Text), int.Parse(txtGoalStartYear.Text) - this.planner.StartDate.Year);
                double loanPortion = double.Parse(txtGoalLoanPortion.Text);
                double futureLoanAmount = (futureValueOfGoal * loanPortion) / 100;

                txtLoanForGoalAmount.Text = futureLoanAmount.ToString();
            }

        }

        private void gridViewGoals_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void cmbCategory_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbCategory.Tag.Equals("0") && (cmbCategory.Text.Equals("Education") || cmbCategory.Text.Equals("Retirement")))
            {
                chkEligbileForInsuranceCoverage.Checked = true;
                if (cmbCategory.Text.Equals("Retirement"))
                {
                    txtInflationRate.Text = plannerAssumption.PreRetirementInflactionRate.ToString();
                }
            }
            else if (cmbCategory.Tag.Equals("0") && !cmbCategory.Text.Equals("Education") && !cmbCategory.Text.Equals("Retirement"))
            {
                chkEligbileForInsuranceCoverage.Checked = false;
                txtInflationRate.Text = "";
            }
            if (cmbCategory.Tag.Equals("0") && (cmbCategory.Text.Equals("Vehicale")))
            {
                txtInflationRate.Text = "4";
            }
        }

        private void txtLoanForGoalStartYear_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtLoanForGoalYears.Text))
            {
                int startYear;
                int loanYears;
                int.TryParse(txtLoanForGoalStartYear.Text, out startYear);
                int.TryParse(txtLoanForGoalYears.Text, out loanYears);
                txtLoanForGoalEndYear.Text = (this.planner.StartDate.Month != 1) ? (startYear + loanYears).ToString() : (startYear + (loanYears -1)).ToString();
            }
        }
    }

    public enum CalculationType
    {
        OutstandingAmount,
        EMI,
        Period,
        RateOfInterest,
        None
    }
}
