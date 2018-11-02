using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.CashFlowManager;
using System.Diagnostics;
using System.Reflection;
using FinancialPlanner.Common;
using FinancialPlanner.Common.Model.PlanOptions;
using FinancialPlannerClient.CurrentStatus;
using FinancialPlanner.Common.Model.CurrentStatus;
using FinancialPlannerClient.PlannerInfo;
using FinancialPlannerClient.RiskProfile;
using FinancialPlanner.Common.DataConversion;

namespace FinancialPlannerClient.PlanOptions
{
    public partial class EstimatedPlanOptionList : Form
    {
        private const string RISKPROFILE_GETALL = "RiskProfileReturn/GetAll";
        private Client client;
        DataTable _dtPlan;
        DataTable _dtOption;
        DataTable _dtcashFlow;
        DataTable _dtCurrentStatustoGoals;
        DataTable _dtGoalValue;
        DataTable _dtGoalCal;
        DataTable _dtCurrentStatusToGoal = new DataTable();
        private int _planeId;
        private int _optinId;
        private int _riskProfileId;
        CurrentStatusCalculation _csCal;
        CurrentStatusInfo _csInfo = new CurrentStatusInfo();
        private IList<Goals> _goals;
        private List<RiskProfiledReturnMaster> _riskProfileMasters = new List<RiskProfiledReturnMaster>();
        GoalsCalculationInfo _goalCalculationInfo;
        CashFlowService cashFlowService = new CashFlowService();
        IList<FinancialPlanner.Common.Model.PlanOptions.CurrentStatusToGoal> _currentStatusToGoal =
            new List<FinancialPlanner.Common.Model.PlanOptions.CurrentStatusToGoal>();

        public EstimatedPlanOptionList(Client client)
        {
            InitializeComponent();
            this.client = client;
        }

        private void btnAddPlanOption_Click(object sender, EventArgs e)
        {
            PlanOptionMaster planoptionmaster = new PlanOptionMaster();
            planoptionmaster.lblclientNameVal.Text = lblclientNameVal.Text;
            planoptionmaster.lblPlanVal.Text = cmbPlan.Text;
            planoptionmaster.lblPlanVal.Tag = cmbPlan.Tag.ToString();
            planoptionmaster.txtOptionName.Tag = "0";
            planoptionmaster.txtOptionName.Text = "";
            planoptionmaster.StartPosition = FormStartPosition.CenterParent;

            if (planoptionmaster.ShowDialog() == DialogResult.OK)
            {
                if (!cmbPlanOption.Items.Contains(planoptionmaster.txtOptionName))
                {
                    cmbPlanOption.Items.Add(planoptionmaster.txtOptionName);
                    fillOptionData();
                }
            }
        }

        private void EstimatedPlanOptionList_Load(object sender, EventArgs e)
        {

            if (this.client != null)
            {
                fllupClientAndPlanInfo();
                _dtPlan = new PlannerInfo.PlannerInfo().GetPlanData(this.client.ID);

                fillPlanData();

                fillOptionData();
            }
        }

        private void fillOptionData()
        {
            cmbPlanOption.Items.Clear();
            _dtOption = new PlanOptionInfo().GetAll(this._planeId);
            if (_dtOption != null)
            {
                if (_dtOption.Rows.Count > 0)
                {
                    DataRow[] drs = _dtOption.Select("", "Name ASC");
                    foreach (DataRow dr in drs)
                    {
                        cmbPlanOption.Items.Add(dr.Field<string>("Name"));
                    }
                    cmbPlanOption.SelectedIndex = 0;
                }
            }

        }

        private void fillPlanData()
        {
            if (_dtPlan != null)
            {
                cmbPlan.Items.Clear();
                if (_dtPlan.Rows.Count > 0)
                {
                    DataRow[] drs = _dtPlan.Select("", "StartDate DESC");
                    foreach (DataRow dr in drs)
                    {
                        cmbPlan.Items.Add(dr.Field<string>("Name"));
                    }
                }
            }
        }

        private void fllupClientAndPlanInfo()
        {
            lblclientNameVal.Text = this.client.Name;
        }

        private void cmbPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var val =  _dtPlan.Select("NAME ='" + cmbPlan.Text + "'");
                _planeId = int.Parse(val[0][0].ToString());
                cmbPlan.Tag = _planeId;
                fillOptionData();
                _goals = new GoalsInfo().GetAll(_planeId);
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace ();
                StackFrame sf = st.GetFrame (0);
                MethodBase  currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
            }
        }
        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }
        private void cmbPlanOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            var val =  _dtOption.Select("NAME ='" + cmbPlanOption.Text + "'");
            if (val != null)
                cmbPlanOption.Tag = int.Parse(val[0][0].ToString());

            loadRiskProfileData();
            RiskProfiledReturnMaster riskProfMaster = _riskProfileMasters.FirstOrDefault(i => i.Id == int.Parse(val[0]["RiskProfileID"].ToString()));
            lblRiskProfileVal.Text = riskProfMaster.Name;
            lblRiskProfileVal.Tag = riskProfMaster.Id;
            _riskProfileId = riskProfMaster.Id;

            CashFlow cf =  cashFlowService.GetCashFlow(int.Parse(val[0][0].ToString()));
            if (cf != null)
            {
                //txtIncomeTax.Text = cf.IncomeTax.ToString();
                //txtIncomeTax.Tag = cf.Id;
                dtGridCashFlow.DataSource = null;

                btnShowIncomeDetails_Click(sender, e);
                //_investmentToGoal = cashFlowService.GetInvestmentToGoalData();
                //try
                //{
                //    dtGridCashFlow.Columns["StartYear"].Frozen = true;
                //    dtGridCashFlow.Columns["EndYear"].Frozen = true;
                //    dtGridCashFlow.Columns["Total Post Tax Income"].Frozen = true;
                //    dtGridCashFlow.Columns["Total Annual Expenses"].Frozen = true;
                //    dtGridCashFlow.Columns["Total Annual Loans"].Frozen = true;
                //}
                //catch (Exception ex)
                //{
                //}
            }
            //else
            //{
            //    txtIncomeTax.Text = "";
            //    txtIncomeTax.Tag = "0";
            //}
        }

        private void btnShowIncomeDetails_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbPlanOption.Text))
            {
                _dtcashFlow = cashFlowService.GenerateCashFlow(this.client.ID, _planeId, _riskProfileId);
                dtGridCashFlow.DataSource = _dtcashFlow;
                dtGridCashFlow.Columns["ID"].Visible = false;
                foreach (DataGridViewColumn column in dtGridCashFlow.Columns)
                {
                    if (column.Name != "ID" && column.Name != "StartYear" && column.Name != "EndYear")
                    {
                        column.DefaultCellStyle.Format = "#,###";
                        column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                    }
                    if (column.Name != "IncomeTax")
                        column.ReadOnly = true;
                    else
                        column.HeaderText = "Income Tax (%)";
                }
            }
        }

        private void btnEditPlanOption_Click(object sender, EventArgs e)
        {
            if (cmbPlanOption.Text == "")
            {
                MessageBox.Show("Please select valid value for plan option and try again.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            PlanOptionMaster planoptionmaster = new PlanOptionMaster(lblRiskProfileVal.Text);
            planoptionmaster.lblclientNameVal.Text = lblclientNameVal.Text;
            planoptionmaster.lblPlanVal.Text = cmbPlan.Text;
            planoptionmaster.lblPlanVal.Tag = cmbPlan.Tag.ToString();
            planoptionmaster.txtOptionName.Text = cmbPlanOption.Text;
            planoptionmaster.txtOptionName.Tag = cmbPlanOption.Tag;
            planoptionmaster.cmbRiskProfile.Tag = lblRiskProfileVal.Tag;
            planoptionmaster.cmbRiskProfile.Text = lblRiskProfileVal.Text;
            planoptionmaster.StartPosition = FormStartPosition.CenterParent;

            if (planoptionmaster.ShowDialog() == DialogResult.OK)
            {
                if (!cmbPlanOption.Items.Contains(planoptionmaster.txtOptionName))
                {
                    cmbPlanOption.Items.Add(planoptionmaster.txtOptionName);
                }
            }
        }

        private void dtGridCashFlow_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            calculateIncomeTax(e);
            calculateFundAllocation(e);

        }

        private void calculateFundAllocation(DataGridViewCellEventArgs e)
        {
            double surplusAmt = double.Parse(
                dtGridCashFlow.Rows[e.RowIndex].Cells["Surplus Amount"].Value.ToString());

            double totalFundAllocation = 0;
            foreach (Goals goal in _goals)
            {
                double fundallocation = string.IsNullOrEmpty((dtGridCashFlow.Rows[e.RowIndex].Cells[string.Format("{0} - {1}", goal.Priority, goal.Name)].Value.ToString()))
                    ? 0 : double.Parse(dtGridCashFlow.Rows[e.RowIndex].Cells[string.Format("{0} - {1}", goal.Priority, goal.Name)].Value.ToString());

                totalFundAllocation = totalFundAllocation + fundallocation;
            }
            if (totalFundAllocation > surplusAmt)
                MessageBox.Show("Fund allocation exceed then available surplus amount.", "Exceed fund allocation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void calculateIncomeTax(DataGridViewCellEventArgs e)
        {
            #region "Tax Calculation"
            double total = 0;
            double.TryParse(
                 dtGridCashFlow.Rows[e.RowIndex].Cells["Total"].Value.ToString(), out total);
            double incomeTax = 0;
            double.TryParse(
                dtGridCashFlow.Rows[e.RowIndex].Cells["IncomeTax"].Value.ToString(), out incomeTax);
            double taxAmount = ((total * incomeTax) /100);
            dtGridCashFlow.Rows[e.RowIndex].Cells["Tax"].ReadOnly = false;
            dtGridCashFlow.Rows[e.RowIndex].Cells["Tax"].Value = taxAmount;
            dtGridCashFlow.Rows[e.RowIndex].Cells["Tax"].ReadOnly = true;
            dtGridCashFlow.Rows[e.RowIndex].Cells["Post Tax Income"].ReadOnly = false;
            dtGridCashFlow.Rows[e.RowIndex].Cells["Post Tax Income"].Value = total - taxAmount;
            dtGridCashFlow.Rows[e.RowIndex].Cells["Post Tax Income"].ReadOnly = true;
            #endregion
        }

        private void dtGridCashFlow_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
        }

        private void tabEstimatedPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabEstimatedPlan.SelectedTab.Name)
            {
                case "CashFlow":
                    //getCashFlowData();
                    break;
                case "CurrentStatus":
                    getCurrentStatus();
                    break;
                case "GoalStatus":
                    getGoalStatus();
                    break;
                case "Goals":
                    getGoals();
                    break;
            }
        }

        private void loadRiskProfileData()
        {

            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
            string apiurl = Program.WebServiceUrl +"/"+ RISKPROFILE_GETALL;

            RestAPIExecutor restApiExecutor = new RestAPIExecutor();

            var restResult = restApiExecutor.Execute<List<RiskProfiledReturnMaster>>(apiurl, null, "GET");

            if (jsonSerialization.IsValidJson(restResult.ToString()))
            {
                _riskProfileMasters = jsonSerialization.DeserializeFromString<List<RiskProfiledReturnMaster>>(restResult.ToString());
            }
            else
                MessageBox.Show(restResult.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #region "Current Status"

        private void getCurrentStatus()
        {
            _csCal = _csInfo.GetAllCurrestStatus(_planeId);
            fillCurrentStatusData();
            //fillCurrentStatusToGoalData(); 
        }



        private void fillCurrentStatusData()
        {
            if (_csCal != null)
            {
                txtEquitySharesAmt.Text = _csCal.ShresValue.ToString();
                txtMFAmt.Text = _csCal.EquityMFvalue.ToString();
                txtEquityNPSAmt.Text = _csCal.NpsEquityValue.ToString();
                txtEquityOtherAmt.Text = _csCal.OtherEquityValue.ToString();

                double totalEquityAmount = _csCal.ShresValue +  _csCal.EquityMFvalue +
                _csCal.NpsEquityValue + _csCal.OtherEquityValue;

                txtDebtMFValue.Text = _csCal.DebtMFValue.ToString();
                txtFDAmt.Text = _csCal.FdValue.ToString();
                txtRDAmt.Text = _csCal.RdValue.ToString();
                txtSAAmt.Text = _csCal.SaValue.ToString();
                txtDebtNPSAmt.Text = _csCal.NpsDebtValue.ToString();
                txtPPFAmt.Text = _csCal.PPFValue.ToString();
                txtEPFAmt.Text = _csCal.EPFValue.ToString();
                txtSSAmt.Text = _csCal.SSValue.ToString();
                txtSCSSValue.Text = _csCal.SCSSValue.ToString();
                txtDebOtherAmt.Text = _csCal.OtherDebtValue.ToString();
                txtBondsAmt.Text = _csCal.BondsValue.ToString();

                double totalDebtAmount = _csCal.DebtMFValue +  _csCal.FdValue +
                _csCal.RdValue + _csCal.SaValue + _csCal.NpsDebtValue +
                _csCal.PPFValue + _csCal.EPFValue  + _csCal.SSValue + _csCal.BondsValue +
                _csCal.SCSSValue + _csCal.OtherDebtValue;

                txtGoldAmt.Text = _csCal.GoldValue.ToString();
                txtGoldOtherAmt.Text = _csCal.OthersGoldValue.ToString();
                double totalGoldAmount  = _csCal.GoldValue + _csCal.OthersGoldValue;

                double totalCurrentStatusAmount = totalEquityAmount + totalDebtAmount + totalGoldAmount;
                if (totalCurrentStatusAmount > 0)
                {
                    double equityRatio = (totalEquityAmount * 100) / totalCurrentStatusAmount;
                    double debtRatio =  (totalDebtAmount * 100) / totalCurrentStatusAmount;
                    double goldRatio =  (totalGoldAmount * 100) / totalCurrentStatusAmount;
                    lblEquityShareRatio.Text = string.Format("{0} %", Math.Round(equityRatio).ToString());
                    lblDebtRatio.Text = string.Format("{0} %", Math.Round(debtRatio).ToString());
                    lblGoldRatio.Text = string.Format("{0} %", Math.Round(goldRatio).ToString());
                }
                else
                {
                    lblEquityShareRatio.Text = string.Format("{0} %", "0");
                    lblDebtRatio.Text = string.Format("{0} %", "0");
                    lblGoldRatio.Text = string.Format("{0} %", "0");
                }
            }
        }


        #endregion

        #region "Goal Status"
        private void getGoalStatus()
        {
            CurrentStatusToGoal csGoal = new CurrentStatusToGoal();
            _dtCurrentStatustoGoals = csGoal.CurrentStatusToGoalCalculation(_planeId);
            dtGridCurrentStatusGoals.DataSource = _dtCurrentStatustoGoals;
            dtGridCurrentStatusGoals.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtGridCurrentStatusGoals.Columns[3].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            //dtGridCurrentStatusGoals.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtGridCurrentStatusGoals.Columns[0].Visible = false;
            dtGridCurrentStatusGoals.Columns[1].Width = 220;
            dtGridCurrentStatusGoals.Columns[2].HeaderText = "Current Status Fund Allocated";
            dtGridCurrentStatusGoals.Columns[3].HeaderText = "Surplus Fund";
            //dtGridCurrentStatusGoals.Columns[4].HeaderText = "Excess Fund";

            fillCurrentStatusToGoalData();
        }

        private void dtGridCurrentStatusGoals_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.ColumnIndex == 3)
                {
                    double excessFund = 0;
                    if (e.RowIndex > 0 &&
                    double.Parse(dtGridCurrentStatusGoals.Rows[e.RowIndex - 1].Cells[4].Value.ToString()) > 0)
                    {
                        excessFund = double.Parse(dtGridCurrentStatusGoals.Rows[e.RowIndex - 1].Cells[4].Value.ToString()) -
                            (double.Parse(dtGridCurrentStatusGoals.Rows[e.RowIndex].Cells[2].Value.ToString()) +
                            double.Parse(dtGridCurrentStatusGoals.Rows[e.RowIndex].Cells[3].Value.ToString()));
                        if (excessFund > 0)
                        {
                            if (dtGridCurrentStatusGoals.Rows[e.RowIndex].Cells[0].Value.ToString() != "0")
                            {
                                Goals goal = _goals.First(i => i.Id == int.Parse(dtGridCurrentStatusGoals.Rows[e.RowIndex].Cells[0].Value.ToString()));
                                var drs = _dtPlan.Select("ID = " + _planeId);
                                Planner planner = convertToPlanner(drs[0]);

                                RiskProfileInfo _riskProfileInfo = new RiskProfileInfo();
                                dtGridCurrentStatusGoals.Rows[e.RowIndex].Cells[4].Value = excessFund;
                                if (_goalCalculationInfo == null)
                                {
                                    _goalCalculationInfo =
                                                          new GoalsCalculationInfo(goal, planner, _riskProfileInfo, _riskProfileId, int.Parse(cmbPlanOption.Tag.ToString()));
                                    _goalCalculationInfo.GoalCalManager = cashFlowService.GoalCalculationMgr;
                                }
                                _goalCalculationInfo.SetGoalProfilevalue(double.Parse(dtGridCurrentStatusGoals.Rows[e.RowIndex].Cells[3].Value.ToString()));

                                for (int i = e.RowIndex + 1; i <= dtGridCurrentStatusGoals.Rows.Count; i++)
                                {
                                    excessFund = double.Parse(dtGridCurrentStatusGoals.Rows[i - 1].Cells[4].Value.ToString()) -
                                            (double.Parse(dtGridCurrentStatusGoals.Rows[i].Cells[2].Value.ToString()) +
                                            (string.IsNullOrEmpty(dtGridCurrentStatusGoals.Rows[i].Cells[3].Value.ToString()) ? 0 :
                                            double.Parse(dtGridCurrentStatusGoals.Rows[i].Cells[3].Value.ToString())));
                                    dtGridCurrentStatusGoals.Rows[i].Cells[4].Value = excessFund;
                                    if (excessFund < 0)
                                    {
                                        MessageBox.Show("Fund allocation should not be allowed more then excess fund.", "Fund Allocation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                        dtGridCurrentStatusGoals.Rows[i].Cells[3].Value = 0;
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Fund allocation should not be allowed more then excess fund.", "Fund Allocation", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            dtGridCurrentStatusGoals.Rows[e.RowIndex].Cells[3].Value = 0;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
            }
        }


        private void fillCurrentStatusToGoalData()
        {
            cmbCurrentStsatusToGoal.Items.Clear();

            foreach (var goal in _goals)
            {
                cmbCurrentStsatusToGoal.Items.Add(goal.Name);
            }

            _currentStatusToGoal = new CurrentStatusInfo().GetCurrentStatusToGoal(int.Parse(cmbPlanOption.Tag.ToString()));
            if (_currentStatusToGoal != null)
            {
                _dtCurrentStatustoGoals = ListtoDataTable.ToDataTable(_currentStatusToGoal.ToList());
                dtGridCurrentStatusToGoal.DataSource = _dtCurrentStatustoGoals;
                dtGridCurrentStatusToGoal.Columns[0].Visible = false;
                dtGridCurrentStatusToGoal.Columns[1].Visible = false;
                dtGridCurrentStatusToGoal.Columns[2].Visible = false;
                dtGridCurrentStatusToGoal.Columns[3].Visible = false;
                dtGridCurrentStatusToGoal.Columns[6].Visible = false;
                dtGridCurrentStatusToGoal.Columns[7].Visible = false;
                dtGridCurrentStatusToGoal.Columns[8].Visible = false;
                dtGridCurrentStatusToGoal.Columns[9].Visible = false;
                dtGridCurrentStatusToGoal.Columns[10].Visible = false;
                dtGridCurrentStatusToGoal.Columns[11].Visible = false;
                dtGridCurrentStatusToGoal.Columns[5].DisplayIndex = 0;
                dtGridCurrentStatusToGoal.Columns[5].HeaderText = "Goal";
                dtGridCurrentStatusToGoal.Columns[4].DisplayIndex = 1;
                dtGridCurrentStatusToGoal.Columns[4].HeaderText = "Fund Allocation";
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
                DataRow dr = getSelectedDataRow(dtGridCurrentStatusToGoal,_dtCurrentStatustoGoals);
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

                    DataRow[] rows = dataTable.Select("Id ='" + selectedUserId +"'");
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
            if (string.IsNullOrEmpty(cmbCurrentStsatusToGoal.Text) || string.IsNullOrEmpty(txtFundAllocation.Text))
            {
                MessageBox.Show("Please enter goal and fund allocation value.", "Validate Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

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
                fillCurrentStatusToGoalData();
                cmbCurrentStsatusToGoal.Enabled = false;
                txtFundAllocation.Enabled = false;
            }
            else
                MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private FinancialPlanner.Common.Model.PlanOptions.CurrentStatusToGoal getCurrentStatusToGoalData()
        {
            FinancialPlanner.Common.Model.PlanOptions.CurrentStatusToGoal currStatusToGoal =
                new FinancialPlanner.Common.Model.PlanOptions.CurrentStatusToGoal();
            currStatusToGoal.PlannerId = _planeId;
            currStatusToGoal.OptionId = int.Parse(cmbPlanOption.Tag.ToString());
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
            if (dtGridCurrentStatusToGoal.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure, you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    FinancialPlanner.Common.Model.PlanOptions.CurrentStatusToGoal currStatusToGoal = getCurrentStatusToGoalData();
                    bool isResult =  new CurrentStatusInfo().DeleteCurrentStatusToGoal(currStatusToGoal);
                    fillCurrentStatusToGoalData();
                }
            }
        }
        #endregion

        #region "Goals"


        private void getGoals()
        {
            cmbGoals.Items.Clear();

            foreach (var goal in _goals)
            {
                cmbGoals.Items.Add(goal.Name);
            }
        }

        private void cmbGoals_SelectedIndexChanged(object sender, EventArgs e)
        {
            setGoalId();
            if (cmbGoals.Tag == "0")
            {
                dtGridGoalValue.DataSource = null;
                dtGridGoalCal.DataSource = null;
            }
            else
            {

                Goals goal = _goals.First(i => i.Id == int.Parse(cmbGoals.Tag.ToString()));
                var drs = _dtPlan.Select("ID = " + _planeId);
                Planner planner = convertToPlanner(drs[0]);


                RiskProfileInfo _riskProfileInfo = new RiskProfileInfo();
                //decimal growthPercentage = _riskProfileInfo.GetRiskProfileReturnRatio(_riskProfileId, int.Parse(goal.StartYear) - planner.StartDate.Year);
                if (_goalCalculationInfo == null)
                {
                    _goalCalculationInfo =
                        new GoalsCalculationInfo(goal, planner, _riskProfileInfo, _riskProfileId,int.Parse(cmbPlanOption.Tag.ToString()));
                    _goalCalculationInfo.GoalCalManager = cashFlowService.GoalCalculationMgr;
                }

                // _goalCalculationInfo.SetInvestmentInGoal(_investmentToGoal);
                _dtGoalValue = _goalCalculationInfo.GetGoalValue(int.Parse(cmbGoals.Tag.ToString()),
                    _planeId, int.Parse(lblRiskProfileVal.Tag.ToString()));
                if (_dtGoalValue != null && _dtGoalValue.Rows.Count > 0)
                {
                    lblGoalPeriodValue.Text = _dtGoalValue.Rows[0]["GoalYear"].ToString();
                    txtPorfolioValue.Text = _goalCalculationInfo.GetProfileValue().ToString();

                    setGoalValueGrid();
                    _dtGoalCal = _goalCalculationInfo.GetGoalCalculation();
                    dtGridGoalCal.DataSource = _dtGoalCal;
                    setGoalCalGrid();
                }
            }
        }

        private void setGoalCalGrid()
        {
            dtGridGoalCal.Columns["Fresh Investment"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtGridGoalCal.Columns["Fresh Investment"].DefaultCellStyle.Format = "#,###.00";

            dtGridGoalCal.Columns["Portfolio Value"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtGridGoalCal.Columns["Portfolio Value"].DefaultCellStyle.Format = "#,###.00";

            dtGridGoalCal.Columns["Cash outflow Goal Year"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtGridGoalCal.Columns["Cash outflow Goal Year"].DefaultCellStyle.Format = "#,###.00";

            dtGridGoalCal.Columns["Portfolio Return"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            dtGridGoalCal.Columns["Assets Mapping"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtGridGoalCal.Columns["Assets Mapping"].DefaultCellStyle.Format = "#,###.00";

            dtGridGoalCal.Columns["Instrument Mapped"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            dtGridGoalCal.Columns["Instrument Mapped"].DefaultCellStyle.Format = "#,###.00";
        }

        private Planner convertToPlanner(DataRow dataRow)
        {
            Planner planner = new Planner();
            planner.ID = int.Parse(dataRow["ID"].ToString());
            planner.StartDate = DateTime.Parse(dataRow["StartDate"].ToString());
            planner.Name = dataRow["Name"].ToString();
            return planner;
        }

        private void setGoalValueGrid()
        {
            dtGridGoalValue.DataSource = _dtGoalValue;
            dtGridGoalValue.Columns["CurrentValue"].HeaderText = "Current Value";
            dtGridGoalValue.Columns["CurrentValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtGridGoalValue.Columns["CurrentValue"].DefaultCellStyle.Format = "#,###.00";

            dtGridGoalValue.Columns["Inflation"].HeaderText = "Inflation (%)";
            dtGridGoalValue.Columns["Inflation"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            //dtGridGoalValue.Columns["Inflation"].DefaultCellStyle.Format = "# %";

            dtGridGoalValue.Columns["GoalValue"].HeaderText = "Goal Value";
            dtGridGoalValue.Columns["GoalValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtGridGoalValue.Columns["GoalValue"].DefaultCellStyle.Format = "#,###.00";
        }

        private void setGoalId()
        {
            if (cmbGoals.Text != "")
                cmbGoals.Tag = _goals.FirstOrDefault(i => i.Name == cmbGoals.Text).Id;
            else
                cmbGoals.Tag = "0";
        }

        private void dtGridGoalCal_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                for (int selectedRowIndex = e.RowIndex; selectedRowIndex <= dtGridGoalCal.Rows.Count - 1;
                    selectedRowIndex++)
                {
                    double portfolioValue = (double) dtGridGoalCal.Rows[selectedRowIndex - 1].Cells["Portfolio Value"].Value;
                    double freshInvestment = (double) dtGridGoalCal.Rows[selectedRowIndex].Cells["Fresh Investment"].Value;
                    double assetsMapping = (double) dtGridGoalCal.Rows[selectedRowIndex].Cells["Assets Mapping"].Value;
                    double instrumentMapped = (double) dtGridGoalCal.Rows[selectedRowIndex].Cells["Instrument Mapped"].Value;
                    decimal portfolioReturn  = (decimal) dtGridGoalCal.Rows[selectedRowIndex].Cells["Portfolio Return"].Value;
                    double recalculatedPortfolioValue = _goalCalculationInfo.ReCalculatePortFolioValue(portfolioValue,freshInvestment,
                                assetsMapping,instrumentMapped,portfolioReturn);
                    dtGridGoalCal.Rows[selectedRowIndex].Cells["Portfolio Value"].Value = System.Math.Round(recalculatedPortfolioValue);
                }
            }
            catch (Exception ex)
            {
                Logger.LogDebug(ex);
            }
        }

        #endregion

        private void txtPorfolioValue_TextChanged(object sender, EventArgs e)
        {
            //btnShowIncomeDetails_Click(sender,e);
            //cmbGoals_SelectedIndexChanged(sender, e);
        }

    }
}
