using DevExpress.Utils;
using DevExpress.XtraEditors;
using FinancialPlanner.Common;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.PlanOptions;
using FinancialPlannerClient.CashFlowManager;
using FinancialPlannerClient.CurrentStatus;
using FinancialPlannerClient.PlannerInfo;
using FinancialPlannerClient.RiskProfile;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace FinancialPlannerClient.PlanOptions
{
    public partial class GoalStatusView : DevExpress.XtraEditors.XtraForm
    {
        Planner planner;
        private IList<Goals> _goals;
        GoalsCalculationInfo _goalCalculationInfo;
        CashFlowService cashFlowService;
        DataTable _dtCurrentStatustoGoals = new DataTable();
        DataTable _dtGoalMapped = new DataTable();
        IList<FinancialPlanner.Common.Model.PlanOptions.CurrentStatusToGoal> _currentStatusToGoal =
            new List<FinancialPlanner.Common.Model.PlanOptions.CurrentStatusToGoal>();
        int optionId;
        int riskProfileId;
        public GoalStatusView(Planner planner, int riskProfileId, int optionId)
        {
            InitializeComponent();
            this.planner = planner;
            this.riskProfileId = riskProfileId;
            this.optionId = optionId;
            this._goals = new GoalsInfo().GetAll(this.planner.ID);
        }
        private void getGoalStatus()
        {
            try
            {
                CurrentStatusToGoal csGoal = new CurrentStatusToGoal();
                _dtCurrentStatustoGoals = csGoal.CurrentStatusToGoalCalculation(planner.ID);

                gridControlCurrentStatusGoal.DataSource = _dtCurrentStatustoGoals;
                gridViewCurrentStatusGoal.Columns[2].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;

                gridViewCurrentStatusGoal.Columns[3].AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
                //dtGridCurrentStatusGoals.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
                gridViewCurrentStatusGoal.Columns[0].Visible = false;
                gridViewCurrentStatusGoal.Columns[1].Width = 220;
                gridViewCurrentStatusGoal.Columns[2].Caption = "Current Status Fund Allocated";
                gridViewCurrentStatusGoal.Columns[3].Caption = "Surplus Fund";
                gridViewCurrentStatusGoal.Columns[3].Visible = false;
                //gridViewCurrentStatusGoal.Columns[4].HeaderText = "Excess Fund";

                fillCurrentStatusToGoalData();

                txtTotalCurrentStatusSurplusValue.Text = getTotalCurrentSatusSurplusValue().ToString();
                txtTotalMappedValue.Text = getTotalFundAllocationValue().ToString();
                txtAcessCurrentStautsValue.Text = (double.Parse(txtTotalCurrentStatusSurplusValue.Text) -
                    double.Parse(txtTotalMappedValue.Text)).ToString();
                txtContingencyfund.Text = new CurrentStatusInfo().GetContingencyFund(this.optionId, this.planner.ID).Amount.ToString();
                setAccessFundValue();
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.StackTrace.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
            }
        }

        internal void setCashFlowService(CashFlowService cashFlowService)
        {
            this.cashFlowService = cashFlowService;
        }

        private double getTotalFundAllocationValue()
        {
            double alredyMappedValue = _dtCurrentStatustoGoals.AsEnumerable().Sum(x => Convert.ToDouble(x["CurrentStatusMappedAmount"]));
            double mappedByProjetManager = _dtGoalMapped.AsEnumerable().Sum(x => Convert.ToDouble(x["FundAllocation"]));
            return alredyMappedValue + mappedByProjetManager;
        }

        private double getTotalCurrentSatusSurplusValue()
        {
            double totalCurrentStatusValue = 0;
            if (_dtCurrentStatustoGoals.Rows.Count > 0)
            {
                totalCurrentStatusValue = string.IsNullOrEmpty(_dtCurrentStatustoGoals.Rows[0]["ExcessFund"].ToString()) ? 0 :
                    double.Parse(_dtCurrentStatustoGoals.Rows[0]["ExcessFund"].ToString());

                //string mappedValue = _dtCurrentStatustoGoals.Compute("Sum(CurrentStatusMappedAmount)", string.Empty).ToString();
                double alreadyMappedValue = _dtCurrentStatustoGoals.AsEnumerable().Sum(x => Convert.ToDouble(x["CurrentStatusMappedAmount"]));
                totalCurrentStatusValue = totalCurrentStatusValue + alreadyMappedValue;
            }
            return Math.Round(totalCurrentStatusValue, 2);
        }

        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }
        private void dtGridCurrentStatusGoals_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //try
            //{
            //    if (e.ColumnIndex == 3)
            //    {
            //        double excessFund = 0;
            //        if (e.RowIndex > 0 &&
            //        double.Parse(gridViewCurrentStatusGoal.GetFocusedRowCellValue .Cells[4].Value.ToString()) > 0)
            //        {
            //            excessFund = double.Parse(dtGridCurrentStatusGoals.Rows[e.RowIndex - 1].Cells[4].Value.ToString()) -
            //                (double.Parse(dtGridCurrentStatusGoals.Rows[e.RowIndex].Cells[2].Value.ToString()) +
            //                double.Parse(dtGridCurrentStatusGoals.Rows[e.RowIndex].Cells[3].Value.ToString()));
            //            if (excessFund > 0)
            //            {
            //                if (dtGridCurrentStatusGoals.Rows[e.RowIndex].Cells[0].Value.ToString() != "0")
            //                {
            //                    Goals goal = _goals.First(i => i.Id == int.Parse(dtGridCurrentStatusGoals.Rows[e.RowIndex].Cells[0].Value.ToString()));
            //                    //var drs = _dtPlan.Select("ID = " + _planeId);
            //                    //Planner planner = convertToPlanner(drs[0]);

            //                    //RiskProfileInfo _riskProfileInfo = new RiskProfileInfo();
            //                    dtGridCurrentStatusGoals.Rows[e.RowIndex].Cells[4].Value = excessFund;
            //                    if (_goalCalculationInfo == null)
            //                    {
            //                        _goalCalculationInfo =
            //                                              new GoalsCalculationInfo(goal, planner, _riskProfileInfo, _riskProfileId, int.Parse(cmbPlanOption.Tag.ToString()));
            //                        _goalCalculationInfo.GoalCalManager = cashFlowService.GoalCalculationMgr;
            //                    }
            //                    _goalCalculationInfo.SetGoalProfilevalue(double.Parse(dtGridCurrentStatusGoals.Rows[e.RowIndex].Cells[3].Value.ToString()));

            //                    for (int i = e.RowIndex + 1; i <= dtGridCurrentStatusGoals.Rows.Count; i++)
            //                    {
            //                        excessFund = double.Parse(dtGridCurrentStatusGoals.Rows[i - 1].Cells[4].Value.ToString()) -
            //                                (double.Parse(dtGridCurrentStatusGoals.Rows[i].Cells[2].Value.ToString()) +
            //                                (string.IsNullOrEmpty(dtGridCurrentStatusGoals.Rows[i].Cells[3].Value.ToString()) ? 0 :
            //                                double.Parse(dtGridCurrentStatusGoals.Rows[i].Cells[3].Value.ToString())));
            //                        dtGridCurrentStatusGoals.Rows[i].Cells[4].Value = excessFund;
            //                        if (excessFund < 0)
            //                        {
            //                            MessageBox.Show("Fund allocation should not be allowed more then excess fund.", "Fund Allocation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //                            dtGridCurrentStatusGoals.Rows[i].Cells[3].Value = 0;
            //                        }
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show("Fund allocation should not be allowed more then excess fund.", "Fund Allocation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //                dtGridCurrentStatusGoals.Rows[e.RowIndex].Cells[3].Value = 0;
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //}
        }


        private void fillCurrentStatusToGoalData()
        {
            try
            {
                cmbCurrentStsatusToGoal.Properties.Items.Clear();
                if (_goals != null)
                {
                    foreach (var goal in _goals)
                    {
                        cmbCurrentStsatusToGoal.Properties.Items.Add(goal.Name);
                    }
                }

                _currentStatusToGoal = new CurrentStatusInfo().GetCurrentStatusToGoal(this.optionId, this.planner.ID);
                if (_currentStatusToGoal != null)
                {
                    _dtGoalMapped = ListtoDataTable.ToDataTable(_currentStatusToGoal.ToList());
                    gridControlAllocationOfCurrentStatus.DataSource = _dtGoalMapped;
                    gridViewAllocationOfCurrentStatus.Columns[1].Visible = false;
                    gridViewAllocationOfCurrentStatus.Columns[2].Visible = false;
                    gridViewAllocationOfCurrentStatus.Columns[3].Visible = false;
                    gridViewAllocationOfCurrentStatus.Columns[6].Visible = false;
                    gridViewAllocationOfCurrentStatus.Columns[7].Visible = false;
                    gridViewAllocationOfCurrentStatus.Columns[8].Visible = false;
                    gridViewAllocationOfCurrentStatus.Columns[9].Visible = false;
                    gridViewAllocationOfCurrentStatus.Columns[10].Visible = false;
                    gridViewAllocationOfCurrentStatus.Columns[11].Visible = false;
                    gridViewAllocationOfCurrentStatus.Columns[5].VisibleIndex = 0;
                    gridViewAllocationOfCurrentStatus.Columns[5].Caption = "Goal";
                    gridViewAllocationOfCurrentStatus.Columns[4].VisibleIndex = 1;
                    gridViewAllocationOfCurrentStatus.Columns[4].Caption = "Fund Allocation";
                    //gridViewAllocationOfCurrentStatus.Columns["ID"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.StackTrace.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
            }
        }

        private void btnAddCurrentStatuaToGoal_Click(object sender, EventArgs e)
        {
            cmbCurrentStsatusToGoal.Text = "";
            txtFundAllocation.Text = "";
            txtFundAllocation.Tag = 0;

            cmbCurrentStsatusToGoal.Enabled = true;
            txtFundAllocation.Enabled = true;
        }

        private void btnCancelCurrentStatusToGoal_Click(object sender, EventArgs e)
        {
            cmbCurrentStsatusToGoal.Text = "";
            txtFundAllocation.Text = "";

            cmbCurrentStsatusToGoal.Enabled = false;
            txtFundAllocation.Enabled = false;
        }

        private void btnEditCurrentStatusToGoal_Click(object sender, EventArgs e)
        {
            cmbCurrentStsatusToGoal.Enabled = true;
            txtFundAllocation.Enabled = true;
        }

        private void dtGridCurrentStatusToGoal_SelectionChanged(object sender, EventArgs e)
        {
            if (_dtCurrentStatustoGoals.Rows.Count > 0)
            {
                DataRow dr = _dtCurrentStatustoGoals.Select()[0]; //getSelectedDataRow(dtGridCurrentStatusToGoal, _dtCurrentStatustoGoals);
                if (dr != null)
                    displayCurrenStatusToGridInfo(dr);
                else
                    setDefaultCurrentStatusToGoal();
            }
        }

        private void setDefaultCurrentStatusToGoal()
        {
            cmbCurrentStsatusToGoal.Text = "";
            cmbCurrentStsatusToGoal.Tag = "0";
            txtFundAllocation.Text = "0";
        }

        private void displayCurrenStatusToGridInfo(DataRow dr)
        {
            cmbCurrentStsatusToGoal.Text = _goals.First(i => i.Id == int.Parse(dr["GoalId"].ToString())).Name;
            cmbCurrentStsatusToGoal.Tag = dr["GoalId"].ToString();
            txtFundAllocation.Text = dr["FundAllocation"].ToString();
            txtFundAllocation.Tag = dr["Id"].ToString();
        }

        private DataRow getSelectedDataRow(DataGridView dtGridView, DataTable dataTable)
        {
            if (dtGridView.SelectedRows.Count >= 1)
            {
                int selectedRowIndex = dtGridView.SelectedRows[0].Index;
                if (dtGridView.SelectedRows[0].Cells["Id"].Value != System.DBNull.Value)
                {
                    int selectedUserId = int.Parse(dtGridView.SelectedRows[0].Cells["Id"].Value.ToString());

                    DataRow[] rows = dataTable.Select("Id ='" + selectedUserId + "'");
                    foreach (DataRow dr in rows)
                    {
                        return dr;
                    }
                }
            }
            return null;
        }
        private void cmbCurrentStsatusToGoal_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbCurrentStsatusToGoal.Text != "")
                cmbCurrentStsatusToGoal.Tag = _goals.FirstOrDefault(i => i.Name == cmbCurrentStsatusToGoal.Text).Id;
            else
                cmbCurrentStsatusToGoal.Tag = "0";
        }

        private void btnSaveCurrentStatusToGoal_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(cmbCurrentStsatusToGoal.Text) || string.IsNullOrEmpty(txtFundAllocation.Text))
                {
                    MessageBox.Show("Please enter goal and fund allocation value.", "Validate Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (isAllowToFundAlocate())
                {
                    FinancialPlanner.Common.Model.PlanOptions.CurrentStatusToGoal currStatusToGoal = getCurrentStatusToGoalData();
                    var goal = _currentStatusToGoal.FirstOrDefault(i => i.GoalId == int.Parse(cmbCurrentStsatusToGoal.Tag.ToString()));
                    bool isSaved = false;

                    if (goal == null)
                        isSaved = new CurrentStatusInfo().AddCurrentStatuToGoal(currStatusToGoal);
                    else
                        isSaved = new CurrentStatusInfo().UpdateCurrentStatuToGoal(currStatusToGoal);

                    if (isSaved)
                    {
                        WaitDialogForm waitdlg = new WaitDialogForm("Saving Data...");
                        //Calculate goal complition part.
                        GoalCalView goalCalView = new GoalCalView(this.planner, this.riskProfileId, this.optionId);
                        goalCalView.setCashFlowService(cashFlowService);
                        Goals paramGoal = _goals.FirstOrDefault(i => i.Name == cmbCurrentStsatusToGoal.Text);
                        double goalPercentge = goalCalView.WithCashFlowAllocationGetGoalComplitionPercentage(paramGoal);

                        _currentStatusToGoal.Add(currStatusToGoal);
                        calculateCurrentStatuFund();
                        fillCurrentStatusToGoalData();
                        getGoalStatus();
                        cmbCurrentStsatusToGoal.Enabled = false;
                        txtFundAllocation.Enabled = false;

                        validateGoalComplitionWithCashAllocation(currStatusToGoal, waitdlg, goalPercentge);
                    }
                    else
                        MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Fund allocation should not be more then access fund.", "Exceed Fund", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.StackTrace.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
            }
        }

        private void validateGoalComplitionWithCashAllocation(FinancialPlanner.Common.Model.PlanOptions.CurrentStatusToGoal currStatusToGoal, WaitDialogForm waitdlg, double goalPercentge)
        {
            if (goalPercentge > 100)
            {
                DataTable dtchanges = _dtGoalMapped.GetChanges();
                Goals goals = this._goals.First(i => i.Id == currStatusToGoal.GoalId);
                int goalsAfterRetirmentPriorityCount = goals.Category.Equals("Retirement") ?
                    this._goals.Count(i => i.Pid == currStatusToGoal.PlannerId && i.Priority > goals.Priority) : 0;

                waitdlg.Close();
                if (goals.Category.Equals("Retirement") && goalsAfterRetirmentPriorityCount == 0)
                {
                    MessageBox.Show("Current fund allocation amount is more then require. Based on current allocation selected goal meet " + goalPercentge + "%.", "Excess Cash Allocatation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                else
                {
                    MessageBox.Show("Current fund allocation amount is more then require. Based on current allocation selected goal meet " + goalPercentge + "%." + System.Environment.NewLine + System.Environment.NewLine + "Transaction abort.", "Excess Cash    Allocatation", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                    WaitDialogForm waitdlgAbort = new WaitDialogForm("Revert changes...");
                    DataRow[] dataRows = dtchanges.Select("goalname ='" + currStatusToGoal.GoalName + "' and  fundAllocation ='" + currStatusToGoal.FundAllocation + "'");
                    if (dataRows.Count() > 0)
                        currStatusToGoal.Id = int.Parse(dataRows[0]["ID"].ToString());
                    bool isResult = new CurrentStatusInfo().DeleteCurrentStatusToGoal(currStatusToGoal);
                    fillCurrentStatusToGoalData();
                    calculateCurrentStatuFund();
                    getGoalStatus();
                    cmbCurrentStsatusToGoal.Text = "";
                    txtFundAllocation.Text = "";
                    waitdlgAbort.Close();
                }
            }
            else
            {
                waitdlg.Close();
                MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void calculateCurrentStatuFund()
        {
            txtTotalMappedValue.Text = getTotalFundAllocationValue().ToString();
            txtAcessCurrentStautsValue.Text = (double.Parse(txtTotalCurrentStatusSurplusValue.Text) -
                double.Parse(txtTotalMappedValue.Text)).ToString();
        }

        private bool isAllowToFundAlocate()
        {
            try
            {
                return (double.Parse(txtAcessCurrentStautsValue.Text) > double.Parse(txtFundAllocation.Text));
            }
            catch (Exception)
            {
                return false;
            }
        }

        private FinancialPlanner.Common.Model.PlanOptions.CurrentStatusToGoal getCurrentStatusToGoalData()
        {
            FinancialPlanner.Common.Model.PlanOptions.CurrentStatusToGoal currStatusToGoal =
                new FinancialPlanner.Common.Model.PlanOptions.CurrentStatusToGoal();
            currStatusToGoal.PlannerId = planner.ID;
            currStatusToGoal.OptionId = this.optionId;
            currStatusToGoal.Id = int.Parse(txtFundAllocation.Tag.ToString());
            currStatusToGoal.GoalId = int.Parse(cmbCurrentStsatusToGoal.Tag.ToString());
            currStatusToGoal.GoalName = cmbCurrentStsatusToGoal.Text;
            currStatusToGoal.FundAllocation = double.Parse(txtFundAllocation.Text);
            currStatusToGoal.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            currStatusToGoal.CreatedBy = Program.CurrentUser.Id;
            currStatusToGoal.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            currStatusToGoal.UpdatedBy = Program.CurrentUser.Id;
            currStatusToGoal.UpdatedByUserName = Program.CurrentUser.UserName;
            currStatusToGoal.MachineName = System.Environment.MachineName;
            return currStatusToGoal;
        }
        private void dtGridCurrentStatusToGoal_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            //if (dtGridCurrentStatusToGoal.Columns[e.ColumnIndex].Name == "GoalId")
            //{
            //    if (dtGridCurrentStatusToGoal.Rows[e.RowIndex].Cells["GoalId"].Value != null)
            //        e.Value =
            //            (dtGridIncome.Rows[e.RowIndex].Cells["IncomeBy"].Value.ToString().Equals("Client", StringComparison.OrdinalIgnoreCase)) ?
            //            _client.Name : getSpouseName();
            //}
        }


        private void btnDeleteCurrentStatusToGoal_Click(object sender, EventArgs e)
        {
            WaitDialogForm waitdlg;
            try
            {
                if (gridViewAllocationOfCurrentStatus.SelectedRowsCount > 0)
                {
                    if (MessageBox.Show("Are you sure, you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        FinancialPlanner.Common.Model.PlanOptions.CurrentStatusToGoal currStatusToGoal = getCurrentStatusToGoalData();
                        bool isResult = new CurrentStatusInfo().DeleteCurrentStatusToGoal(currStatusToGoal);
                        waitdlg = new WaitDialogForm("Deleting Data...");
                        fillCurrentStatusToGoalData();
                        calculateCurrentStatuFund();
                        getGoalStatus();
                        cmbCurrentStsatusToGoal.Text = "";
                        txtFundAllocation.Text = "";
                        waitdlg.Close();
                    }
                }
                else
                    DevExpress.XtraEditors.XtraMessageBox.Show("Please select row to delete record.");
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.StackTrace.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
            }
        }

        private void GoalStatusView_Load(object sender, EventArgs e)
        {
            getGoalStatus();
        }


        private void gridViewCurrentStatusGoal_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //try
            //{
            //    if (e.Column.AbsoluteIndex == 3)
            //    {
            //        double excessFund = 0;
            //        if (e.RowHandle > 0 &&
            //        double.Parse(gridViewCurrentStatusGoal.GetFocusedRowCellValue("").ToString()) > 0)
            //        {
            //            excessFund = double.Parse(dtGridCurrentStatusGoals.Rows[e.RowIndex - 1].Cells[4].Value.ToString()) -
            //                (double.Parse(dtGridCurrentStatusGoals.Rows[e.RowIndex].Cells[2].Value.ToString()) +
            //                double.Parse(dtGridCurrentStatusGoals.Rows[e.RowIndex].Cells[3].Value.ToString()));
            //            if (excessFund > 0)
            //            {
            //                if (dtGridCurrentStatusGoals.Rows[e.RowIndex].Cells[0].Value.ToString() != "0")
            //                {
            //                    Goals goal = _goals.First(i => i.Id == int.Parse(dtGridCurrentStatusGoals.Rows[e.RowIndex].Cells[0].Value.ToString()));
            //                    //var drs = _dtPlan.Select("ID = " + _planeId);
            //                    //Planner planner = convertToPlanner(drs[0]);

            //                    //RiskProfileInfo _riskProfileInfo = new RiskProfileInfo();
            //                    dtGridCurrentStatusGoals.Rows[e.RowIndex].Cells[4].Value = excessFund;
            //                    if (_goalCalculationInfo == null)
            //                    {
            //                        _goalCalculationInfo =
            //                                              new GoalsCalculationInfo(goal, planner, _riskProfileInfo, _riskProfileId, int.Parse(cmbPlanOption.Tag.ToString()));
            //                        _goalCalculationInfo.GoalCalManager = cashFlowService.GoalCalculationMgr;
            //                    }
            //                    _goalCalculationInfo.SetGoalProfilevalue(double.Parse(dtGridCurrentStatusGoals.Rows[e.RowIndex].Cells[3].Value.ToString()));

            //                    for (int i = e.RowIndex + 1; i <= dtGridCurrentStatusGoals.Rows.Count; i++)
            //                    {
            //                        excessFund = double.Parse(dtGridCurrentStatusGoals.Rows[i - 1].Cells[4].Value.ToString()) -
            //                                (double.Parse(dtGridCurrentStatusGoals.Rows[i].Cells[2].Value.ToString()) +
            //                                (string.IsNullOrEmpty(dtGridCurrentStatusGoals.Rows[i].Cells[3].Value.ToString()) ? 0 :
            //                                double.Parse(dtGridCurrentStatusGoals.Rows[i].Cells[3].Value.ToString())));
            //                        dtGridCurrentStatusGoals.Rows[i].Cells[4].Value = excessFund;
            //                        if (excessFund < 0)
            //                        {
            //                            MessageBox.Show("Fund allocation should not be allowed more then excess fund.", "Fund Allocation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //                            dtGridCurrentStatusGoals.Rows[i].Cells[3].Value = 0;
            //                        }
            //                    }
            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show("Fund allocation should not be allowed more then excess fund.", "Fund Allocation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            //                dtGridCurrentStatusGoals.Rows[e.RowIndex].Cells[3].Value = 0;
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //}
        }

        private void gridViewAllocationOfCurrentStatus_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (gridViewAllocationOfCurrentStatus.SelectedRowsCount > 0)
            {
                cmbCurrentStsatusToGoal.Tag = gridViewAllocationOfCurrentStatus.GetFocusedRowCellValue("GoalID").ToString();
                cmbCurrentStsatusToGoal.Text = gridViewAllocationOfCurrentStatus.GetFocusedRowCellValue("Goal").ToString();
                txtFundAllocation.Text = gridViewAllocationOfCurrentStatus.GetFocusedRowCellValue("FundAllocation").ToString();
            }
        }

        private void gridViewAllocationOfCurrentStatus_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridViewAllocationOfCurrentStatus.SelectedRowsCount > 0)
            {
                cmbCurrentStsatusToGoal.Tag = gridViewAllocationOfCurrentStatus.GetFocusedRowCellValue("GoalId").ToString();
                cmbCurrentStsatusToGoal.Text = gridViewAllocationOfCurrentStatus.GetFocusedRowCellValue("GoalName").ToString();
                txtFundAllocation.Text = gridViewAllocationOfCurrentStatus.GetFocusedRowCellValue("FundAllocation").ToString();
                txtFundAllocation.Tag = gridViewAllocationOfCurrentStatus.GetFocusedRowCellValue("Id").ToString();
            }
        }

        private void txtContingencyfund_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtContingencyfund_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtContingencyfund_Leave(object sender, EventArgs e)
        {
            double contiguencyfundValue = string.IsNullOrEmpty(txtContingencyfund.Text) ? 0 : double.Parse(txtContingencyfund.Text);
            if (!string.IsNullOrEmpty(txtContingencyfund.Text))
            {
                double currentRemainingSurplusFund = string.IsNullOrEmpty(txtAcessCurrentStautsValue.Text) ? 0 : double.Parse(txtAcessCurrentStautsValue.Text);
                if (currentRemainingSurplusFund < contiguencyfundValue)
                {
                    XtraMessageBox.Show("You can not allocate more fund for contigency more then existing surplus value.", "Over value", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtContingencyfund.Focus();
                    return;
                }
            }
            else
            {
                txtAcessCurrentStautsValue.Text = "0";
            }
            setAccessFundValue();
        }

        private void setAccessFundValue()
        {
            double contiguencyfundValue = string.IsNullOrEmpty(txtContingencyfund.Text) ? 0 : double.Parse(txtContingencyfund.Text);
            double totalCurrentStatusSurplus = string.IsNullOrEmpty(txtTotalCurrentStatusSurplusValue.Text) ? 0 : double.Parse(txtTotalCurrentStatusSurplusValue.Text);
            double totalValueMapped = string.IsNullOrEmpty(txtTotalMappedValue.Text) ? 0 : double.Parse(txtTotalMappedValue.Text);

            double accessFund = totalCurrentStatusSurplus - (totalValueMapped + contiguencyfundValue);
            txtAcessCurrentStautsValue.Text = accessFund.ToString();
        }

        public double GetAccessFundValueForRetirementCorpus()
        {
            getGoalStatus();
            return double.Parse(txtAcessCurrentStautsValue.Text);
        }

        private void btnSaveConfingencyFund_Click(object sender, EventArgs e)
        {
            bool isSaved = false;
            ContingencyFund contingencyfund = new ContingencyFund()
            {
                OptionId = this.optionId,
                PlannerId = planner.ID,
                Amount = double.Parse(txtContingencyfund.Text),
                UpdatedBy = Program.CurrentUser.Id,
                UpdatedByUserName = Program.CurrentUser.UserName,
                MachineName = System.Environment.MachineName
            };
            isSaved = new CurrentStatusInfo().UpdateContingencyFund(contingencyfund);
            if (isSaved)
            {
                MessageBox.Show("Contingency fund saved successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnGetEstimatedValue_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbCurrentStsatusToGoal.Text))
            {
                MessageBox.Show("Please select goal first.", "Select Goal", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            RiskProfileInfo _riskProfileInfo = new RiskProfileInfo();
            Goals goal = _goals.FirstOrDefault(i => i.Id.ToString() == cmbCurrentStsatusToGoal.Tag.ToString());
            if (goal != null)
            {
                GoalsValueCalculationInfo goalValCalInfo = this.cashFlowService.GoalCalculationMgr.GetGoalValueCalculation(goal);
                GoalPlanning goalPlanning = goalValCalInfo.GetLIFOGoalPlanning(this.planner.StartDate.Year);
                lblEstimatedValue.Text = goalPlanning.ActualFreshInvestment.ToString();

                GoalCalView goalCalView = new GoalCalView(this.planner, this.riskProfileId, this.optionId);
                goalCalView.setCashFlowService(cashFlowService);
                Goals paramGoal = _goals.FirstOrDefault(i => i.Id.ToString() == cmbCurrentStsatusToGoal.Tag.ToString());
                DataTable dtGoalValue = goalCalView.GetGoalsValueTable(paramGoal);
                dtGoalValue.Columns.Add("EstimatedValue", typeof(System.Double));
                double assetsMappingValue = 0;
                assetsMappingValue = (dtGoalValue.Rows.Count > 0 && !dtGoalValue.Rows[dtGoalValue.Rows.Count - 1]["Assets Mapping"].ToString().Equals("")) ?
                    double.Parse(dtGoalValue.Rows[dtGoalValue.Rows.Count - 1]["Assets Mapping"].ToString()) :
                   0;

                double goalComplitionValue = (dtGoalValue.Rows.Count > 0) ?
                    (double.Parse(dtGoalValue.Rows[dtGoalValue.Rows.Count - 1]["Cash outflow Goal Year"].ToString()) - assetsMappingValue)
                    : 0;
                double goalActualComplitionValue = 0;
                for (int rowIndex = dtGoalValue.Rows.Count - 1; rowIndex >= 0; rowIndex--)
                {
                    double portfolioValue, freshInvestment = 0;
                    double portFolioReturnRate = 0;
                    double previousYearExpectedPortfilioValue = 0;
                    double afterDebugFreshInvestmentValue = 0;

                    int previousYearRowIndex = rowIndex - 1;


                    double.TryParse(dtGoalValue.Rows[rowIndex]["Portfolio Value"].ToString(), out portfolioValue);

                    double.TryParse(dtGoalValue.Rows[rowIndex]["Fresh Investment"].ToString(), out freshInvestment);

                    if (goalActualComplitionValue == 0 && rowIndex == dtGoalValue.Rows.Count - 1)
                    {
                        double.TryParse(dtGoalValue.Rows[rowIndex]["Portfolio Return"].ToString(), out portFolioReturnRate);
                        double.TryParse(dtGoalValue.Rows[rowIndex]["Cash outflow Goal Year"].ToString(), out goalActualComplitionValue);
                        if (goal.LoanForGoal != null && goal.LoanForGoal.LoanAmount > 0)
                        {
                            goalActualComplitionValue = goalActualComplitionValue - goal.LoanForGoal.LoanAmount;
                        }
                        dtGoalValue.Rows[previousYearRowIndex]["EstimatedValue"] = (goalActualComplitionValue * 100) / (100 + portFolioReturnRate);
                        goalActualComplitionValue = (goalActualComplitionValue * 100) / (100 + portFolioReturnRate);
                    }
                    else if (rowIndex > 0 && goalActualComplitionValue > 0)
                    {
                        double.TryParse(dtGoalValue.Rows[rowIndex]["Portfolio Return"].ToString(), out portFolioReturnRate);
                        afterDebugFreshInvestmentValue = goalActualComplitionValue - freshInvestment;
                        previousYearExpectedPortfilioValue = (afterDebugFreshInvestmentValue * 100) / (100 + portFolioReturnRate);

                        goalActualComplitionValue = previousYearExpectedPortfilioValue;
                        if (previousYearRowIndex >= 0)
                            dtGoalValue.Rows[previousYearRowIndex]["EstimatedValue"] = goalActualComplitionValue;
                    }
                    else if (rowIndex == 0)
                    {
                        double.TryParse(dtGoalValue.Rows[rowIndex]["Portfolio Return"].ToString(), out portFolioReturnRate);
                        if (freshInvestment > 0)
                        {
                            goalActualComplitionValue = goalActualComplitionValue - freshInvestment;
                            goalActualComplitionValue = (goalActualComplitionValue * 100) / (100 + portFolioReturnRate);
                        }
                        dtGoalValue.Rows[rowIndex]["EstimatedValue"] = goalActualComplitionValue;
                    }
                }
               
                lblEstimatedValue.Text = goalActualComplitionValue.ToString();
            }
        }
    }
}
