using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace FinancialPlannerClient.PlanOptions
{
    public partial class EstimatedPlanOptionList : Form
    {
        private Client client;
        DataTable _dtPlan;
        DataTable _dtOption;
        DataTable _dtcashFlow;
        DataTable _dtCurrentStatustoGoals;
        DataTable _dtGoalValue;
        private int _planeId;
        private int _optinId;
        CurrentStatusCalculation _csCal;
        CurrentStatusInfo _csInfo = new CurrentStatusInfo();
        private IList<Goals> _goals;

        public EstimatedPlanOptionList()
        {
            InitializeComponent();
        }

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
                    cmbPlan.SelectedIndex = 0;
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
            cmbPlanOption.Tag = int.Parse(val[0][0].ToString());
            CashFlowService cashFlowService = new CashFlowService();
            CashFlow cf =  cashFlowService.GetCashFlow(int.Parse(val[0][0].ToString()));
            if (cf != null)
            {
                txtIncomeTax.Text = cf.IncomeTax.ToString();
                txtIncomeTax.Tag = cf.Id;
                dtGridCashFlow.DataSource = null;
               
                btnShowIncomeDetails_Click(sender, e);
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
            else
            {
                txtIncomeTax.Text = "";
                txtIncomeTax.Tag = "0";
            }
        }

        private void btnShowIncomeDetails_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbPlanOption.Text))
            {
                CashFlowService cashFlowService = new CashFlowService();
                _dtcashFlow = cashFlowService.GenerateCashFlow(this.client.ID, _planeId, float.Parse(txtIncomeTax.Text));
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
            PlanOptionMaster planoptionmaster = new PlanOptionMaster();
            planoptionmaster.lblclientNameVal.Text = lblclientNameVal.Text;
            planoptionmaster.lblPlanVal.Text = cmbPlan.Text;
            planoptionmaster.lblPlanVal.Tag = cmbPlan.Tag.ToString();
            planoptionmaster.txtOptionName.Text = cmbPlanOption.Text;
            planoptionmaster.txtOptionName.Tag = cmbPlanOption.Tag;
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
        }

        private void dtGridCashFlow_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //if (e.ColumnIndex == dtGridCashFlow.Columns["IncomeTax"].Index)
            //{
            //    dtGridCashFlow.Rows[e.RowIndex].ErrorText = "";
            //    decimal newDecimal;
            //    if (dtGridCashFlow.Rows[e.RowIndex].IsNewRow) { return; }
            //    if (!decimal.TryParse(e.FormattedValue.ToString(),
            //        out newDecimal) || ((newDecimal < 0) || (newDecimal > 100)))
            //    {
            //        e.Cancel = true;
            //        dtGridCashFlow.Rows[e.RowIndex].ErrorText = "Value must be a between 0 to 100";
            //    }
            //}
        }

        private void btnCashFlowSave_Click(object sender, EventArgs e)
        {
            CashFlow cf = getCashFlowData();
            CashFlowService cfService = new CashFlowService();

            if (cfService.Save(cf))
            {
                MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
            else
                MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private CashFlow getCashFlowData()
        {
            CashFlow cf = new CashFlow();
            cf.Id = int.Parse(txtIncomeTax.Tag.ToString());
            cf.Oid = int.Parse(cmbPlanOption.Tag.ToString());
            cf.IncomeTax = float.Parse(txtIncomeTax.Text);
            cf.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            cf.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            cf.UpdatedBy = Program.CurrentUser.Id;
            cf.CreatedBy = Program.CurrentUser.Id;
            cf.UpdatedByUserName = Program.CurrentUser.UserName;
            cf.MachineName = System.Environment.MachineName;
            return cf;
        }

        private void tabEstimatedPlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabEstimatedPlan.SelectedTab.Name)
            {
                case "CashFlow":
                    getCashFlowData();
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


        #region "Current Status"

        private void getCurrentStatus()
        {
            _csCal = _csInfo.GetAllCurrestStatus(_planeId);
            fillCurrentStatusData();
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
            dtGridCurrentStatusGoals.Columns[4].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtGridCurrentStatusGoals.Columns[0].Visible = false;
            dtGridCurrentStatusGoals.Columns[1].Width = 250;
            dtGridCurrentStatusGoals.Columns[2].HeaderText = "Current Status Fund Allocated";
            dtGridCurrentStatusGoals.Columns[3].HeaderText = "Fund Allocation";
            dtGridCurrentStatusGoals.Columns[4].HeaderText = "Excess Fund";
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
            _dtGoalValue = new GoalsCalculationInfo().GetGoalValue(int.Parse(cmbGoals.Tag.ToString()), _planeId);
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
        #endregion
    }
}
