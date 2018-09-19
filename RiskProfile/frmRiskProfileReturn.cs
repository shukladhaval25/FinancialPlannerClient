using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialPlannerClient.RiskProfile
{
    public partial class frmRiskProfileReturn : Form
    {
        const string ADD_RISKPROFILE_RETURN = "RiskProfileReturn/Add";
        const string UPDATE_RISKPROFILE_RETURN = "RiskProfileReturn/Update";
        const string DELETE_RISKPROFILE_RETURN = "RiskProfileReturn/Delete";

        int _riskProfileId = 0;
        RiskProfiledReturnMaster _riskProfiledReturnMaster;
        ReiskProfileInfo _defaultRiskProfile = new ReiskProfileInfo();
        DataTable _dtRiskProfileReturn;
        public frmRiskProfileReturn()
        {
            InitializeComponent();
        }
        public frmRiskProfileReturn(RiskProfiledReturnMaster riskProfiledReturnMaster)
        {
            InitializeComponent();
            _riskProfiledReturnMaster = riskProfiledReturnMaster;
            loadRiskProfileMasterData();
            loadRislProfileReturnDetails();
        }

        private void loadRislProfileReturnDetails()
        {
            _dtRiskProfileReturn = _defaultRiskProfile.GetRiskProfileReturnById(_riskProfileId);
            dtGridRiskProfileDetails.DataSource = _dtRiskProfileReturn;
            setRiskProfileDetailsGrid();
        }

        private void loadRiskProfileMasterData()
        {
            _riskProfileId = _riskProfiledReturnMaster.Id;
            txtRiskProfileName.Tag = _riskProfiledReturnMaster.Id.ToString();
            txtRiskProfileName.Text = _riskProfiledReturnMaster.Name;
            txtDescription.Text = _riskProfiledReturnMaster.Description;
        }

        private void frmRiskProfileReturn_Load(object sender, EventArgs e)
        {
            if (_riskProfileId == 0)
            {
                txtRiskProfileName.Text = "";
                txtDescription.Text = "";
               
                _dtRiskProfileReturn = _defaultRiskProfile.GetDefaultRiskProfileReturn();
                dtGridRiskProfileDetails.DataSource = _dtRiskProfileReturn;
                setRiskProfileDetailsGrid();
            }          
        }

        private void setRiskProfileDetailsGrid()
        {
            dtGridRiskProfileDetails.Columns[0].Visible = false;
            dtGridRiskProfileDetails.Columns[1].Visible = false;
            dtGridRiskProfileDetails.Columns[2].ReadOnly = true;
            dtGridRiskProfileDetails.Columns[9].ReadOnly = true;
            dtGridRiskProfileDetails.Columns[2].HeaderText = "Reaming Year";
            dtGridRiskProfileDetails.Columns[3].HeaderText = "Foreing Investment (%)";
            dtGridRiskProfileDetails.Columns[4].HeaderText = "Equity Investment (%)";
            dtGridRiskProfileDetails.Columns[5].HeaderText = "Debt Investment (%)";
            dtGridRiskProfileDetails.Columns[6].HeaderText = "Foreing Return (%)";
            dtGridRiskProfileDetails.Columns[7].HeaderText = "Equity Return (%)";
            dtGridRiskProfileDetails.Columns[8].HeaderText = "Debt Return (%)";
            dtGridRiskProfileDetails.Columns[9].HeaderText = "Average Return (%)";
        }

        private void dtGridRiskProfileDetails_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            
        }
        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }
        private decimal getAverageReturn(int rowIndex)
        {
            decimal foreingInv;
            decimal.TryParse(
                dtGridRiskProfileDetails.Rows[rowIndex].Cells["ForeingInvestmentRatio"].Value.ToString(),
                out foreingInv);

            decimal equityInv;
            decimal.TryParse(
                dtGridRiskProfileDetails.Rows[rowIndex].Cells["EquityInvestementRatio"].Value.ToString(),
                out equityInv);

            decimal debtInv;
            decimal.TryParse(
                dtGridRiskProfileDetails.Rows[rowIndex].Cells["DebtInvestementRatio"].Value.ToString(),
                out debtInv);

            decimal foreingReturn;
            decimal.TryParse(
                dtGridRiskProfileDetails.Rows[rowIndex].Cells["ForeingInvestementReaturn"].Value.ToString(),
                out foreingReturn);

            decimal equityReturn;
            decimal.TryParse(
                dtGridRiskProfileDetails.Rows[rowIndex].Cells["EquityInvestementReturn"].Value.ToString(),
                out equityReturn);

            decimal debtReturn;
            decimal.TryParse(
                dtGridRiskProfileDetails.Rows[rowIndex].Cells["DebtInvestementReturn"].Value.ToString(),
                out debtReturn);

            decimal _foreingValue =  (foreingInv * foreingReturn) / 100;
            decimal _equityvalue =  (equityInv * equityReturn) / 100;
            decimal _debtValue =   (debtInv * debtReturn) / 100;

            decimal averageReturn = _foreingValue + _equityvalue + _debtValue;
            return averageReturn;
        }

        private void dtGridRiskProfileDetails_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            if (e.ColumnIndex == dtGridRiskProfileDetails.Columns["ForeingInvestmentRatio"].Index ||
                e.ColumnIndex == dtGridRiskProfileDetails.Columns["EquityInvestementRatio"].Index ||
                e.ColumnIndex == dtGridRiskProfileDetails.Columns["DebtInvestementRatio"].Index ||
                e.ColumnIndex == dtGridRiskProfileDetails.Columns["ForeingInvestementReaturn"].Index ||
                e.ColumnIndex == dtGridRiskProfileDetails.Columns["EquityInvestementReturn"].Index ||
                e.ColumnIndex == dtGridRiskProfileDetails.Columns["DebtInvestementReturn"].Index)
            {
                dtGridRiskProfileDetails.Rows[e.RowIndex].ErrorText = "";
                decimal newDecimal;
                if (dtGridRiskProfileDetails.Rows[e.RowIndex].IsNewRow) { return; }
                if (!decimal.TryParse(e.FormattedValue.ToString(),
                    out newDecimal) || ((newDecimal < 0) || (newDecimal > 100)))
                {
                    e.Cancel = true;
                    dtGridRiskProfileDetails.Rows[e.RowIndex].ErrorText = "the value must be a between 0 to 100";
                }                
            }
        }

        private void btnPersonalDetailSave_Click(object sender, EventArgs e)
        {           
            RiskProfiledReturnMaster riskProfileMaster = new RiskProfiledReturnMaster();
            riskProfileMaster = getRiskProfileData();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = string.Empty;
                if (riskProfileMaster.Id == 0)
                    apiurl = Program.WebServiceUrl + "/" + ADD_RISKPROFILE_RETURN;
                else
                    apiurl = Program.WebServiceUrl +"/"+ UPDATE_RISKPROFILE_RETURN;

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<RiskProfiledReturnMaster>(apiurl, riskProfileMaster, "POST");
                MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Logger.LogDebug(ex);
            }
        }

        private RiskProfiledReturnMaster getRiskProfileData()
        {
            RiskProfiledReturnMaster rpr = new RiskProfiledReturnMaster();
            rpr.Id = _riskProfileId;
            rpr.Name = txtRiskProfileName.Text;
            rpr.Description = txtDescription.Text;
            rpr.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            rpr.UpdatedBy = Program.CurrentUser.Id;
            rpr.UpdatedByUserName = Program.CurrentUser.UserName;
            rpr.MachineName = System.Environment.MachineName;
            rpr.RiskProfileReturn = new List<RiskProfiledReturn>();
            foreach (DataRow dr in _dtRiskProfileReturn.Rows)
            {
                RiskProfiledReturn riskProfile = new RiskProfiledReturn();
                //riskProfile.Id = dr.Field<int>("ID");
                riskProfile.RiskProfileId = rpr.Id;
                riskProfile.YearRemaining = int.Parse(dr["YearRemaining"].ToString());
                riskProfile.ForeingInvestmentRatio = decimal.Parse(dr["ForeingInvestmentRatio"].ToString());
                riskProfile.EquityInvestementRatio = decimal.Parse(dr["EquityInvestementRatio"].ToString());
                riskProfile.DebtInvestementRatio = decimal.Parse(dr["DebtInvestementRatio"].ToString());

                riskProfile.ForeingInvestementReaturn = decimal.Parse(dr["ForeingInvestementReaturn"].ToString());
                riskProfile.EquityInvestementReturn =decimal.Parse(dr["EquityInvestementReturn"].ToString());
                riskProfile.DebtInvestementReturn = decimal.Parse(dr["DebtInvestementReturn"].ToString());
                rpr.RiskProfileReturn.Add(riskProfile);
            }
            return rpr;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dtGridRiskProfileDetails_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (dtGridRiskProfileDetails.Rows[e.RowIndex].Cells[2].Value.ToString() != "")
                {
                    if (e.ColumnIndex != 0 && e.ColumnIndex != 1 & e.ColumnIndex != 2)
                    {
                        decimal averageReturn = getAverageReturn(e.RowIndex);
                        dtGridRiskProfileDetails.Rows[e.RowIndex].Cells[9].Value = averageReturn;
                    }
                }
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace ();
                StackFrame sf = st.GetFrame (0);
                MethodBase  currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
            }
        }
    }
}
