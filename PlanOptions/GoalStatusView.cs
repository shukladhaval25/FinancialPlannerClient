using FinancialPlanner.Common;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.CurrentStatus;
using FinancialPlannerClient.CashFlowManager;
using FinancialPlannerClient.CurrentStatus;
using FinancialPlannerClient.PlannerInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace FinancialPlannerClient.PlanOptions
{
    public partial class GoalStatusView : DevExpress.XtraEditors.XtraForm
    {
        Planner planner;
        private IList<Goals> _goals;
        GoalsCalculationInfo _goalCalculationInfo;
        CashFlowService cashFlowService = new CashFlowService();
        DataTable _dtCurrentStatustoGoals = new DataTable();
        DataTable _dtGoalMapped = new DataTable();
        IList<FinancialPlanner.Common.Model.PlanOptions.CurrentStatusToGoal> _currentStatusToGoal =
            new List<FinancialPlanner.Common.Model.PlanOptions.CurrentStatusToGoal>();
        int optionId;
        public GoalStatusView(Planner planner,int optionId)
        {
            InitializeComponent();
            this.planner = planner;
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
            }
            catch(Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.StackTrace.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
            }
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
            return Math.Round(totalCurrentStatusValue,2);
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

                foreach (var goal in _goals)
                {
                    cmbCurrentStsatusToGoal.Properties.Items.Add(goal.Name);
                }

                _currentStatusToGoal = new CurrentStatusInfo().GetCurrentStatusToGoal(this.optionId);
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
            catch(Exception ex)
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
                        MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _currentStatusToGoal.Add(currStatusToGoal);
                        calculateCurrentStatuFund();
                        fillCurrentStatusToGoalData();
                        cmbCurrentStsatusToGoal.Enabled = false;
                        txtFundAllocation.Enabled = false;
                    }
                    else
                        MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Fund allocation should not be more then access fund.", "Exceed Fund", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch(Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.StackTrace.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
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
            catch(Exception ex)
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
            currStatusToGoal.GoalId = int.Parse(cmbCurrentStsatusToGoal.Tag.ToString());
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
            try
            {
                if (gridViewAllocationOfCurrentStatus.SelectedRowsCount > 0)
                {
                    if (MessageBox.Show("Are you sure, you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        FinancialPlanner.Common.Model.PlanOptions.CurrentStatusToGoal currStatusToGoal = getCurrentStatusToGoalData();
                        bool isResult = new CurrentStatusInfo().DeleteCurrentStatusToGoal(currStatusToGoal);
                        fillCurrentStatusToGoalData();
                        calculateCurrentStatuFund();
                    }
                }
                else
                    DevExpress.XtraEditors.XtraMessageBox.Show("Please select row to delete record.");
            }
            catch(Exception ex)
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
                cmbCurrentStsatusToGoal.Tag = gridViewAllocationOfCurrentStatus.GetFocusedRowCellValue("ID").ToString();
                cmbCurrentStsatusToGoal.Text = gridViewAllocationOfCurrentStatus.GetFocusedRowCellValue("Goal").ToString();
                txtFundAllocation.Text = gridViewAllocationOfCurrentStatus.GetFocusedRowCellValue("FundAllocation").ToString();
            }
        }

        private void gridViewAllocationOfCurrentStatus_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridViewAllocationOfCurrentStatus.SelectedRowsCount > 0)
            {
                cmbCurrentStsatusToGoal.Tag = gridViewAllocationOfCurrentStatus.GetFocusedRowCellValue("Id").ToString();
                cmbCurrentStsatusToGoal.Text = gridViewAllocationOfCurrentStatus.GetFocusedRowCellValue("GoalName").ToString();
                txtFundAllocation.Text = gridViewAllocationOfCurrentStatus.GetFocusedRowCellValue("FundAllocation").ToString();
            }
        }
    }
}
