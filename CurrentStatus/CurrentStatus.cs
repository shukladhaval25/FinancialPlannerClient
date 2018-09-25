using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.CurrentStatus;
using FinancialPlannerClient.PlannerInfo;

namespace FinancialPlannerClient.CurrentStatus
{
    public partial class CurrentStatus : Form
    {
        private Client _client;
        int _planeId = 0;
        DataTable _dtPlan;
        DataTable _dtLifeInsurance;
        DataTable _dtGeneralInsurance;
        DataTable _dtMutualFund;
        DataTable _dtNPS;
        DataTable _dtShares;
        IList<Goals> _goals;

        public CurrentStatus()
        {
            InitializeComponent();
        }

        public CurrentStatus(Client client)
        {
            InitializeComponent();
            this._client = client;
        }

        private void CurrentStatus_Load(object sender, EventArgs e)
        {
            if (_client != null)
            {
                fllupClientAndPlanInfo();
                _dtPlan = new PlannerInfo.PlannerInfo().GetPlanData(_client.ID);
                fillPlanData();

            }
        }

        private void fillLifeInsuranceApplicantCombobox()
        {
            new PlannerInfo.FamilyMemberInfo().FillFamilyMemberInCombo(this._client.ID, cmbApplicant);
        }
        private void fillGeneralInsuranceApplicantCombobox()
        {
            new PlannerInfo.FamilyMemberInfo().FillFamilyMemberInCombo(this._client.ID, cmbGeneralInsuranceApplicant);
        }
        private void fillMutualFundInvesterCombobox()
        {
            new PlannerInfo.FamilyMemberInfo().FillFamilyMemberInCombo(this._client.ID, cmbMFInvester);
        }
        private void fillMutualfundGolsCombobox()
        {
            cmbMFGoal.Items.Clear();
            _goals = new GoalsInfo().GetAll(_planeId);
            foreach (var goal in _goals)
            {
                cmbMFGoal.Items.Add(goal.Name);
            }
            cmbMFGoal.Items.Add("");
        }

        private void fillNPSInvesterCombobox()
        {
            new PlannerInfo.FamilyMemberInfo().FillFamilyMemberInCombo(this._client.ID, cmbNPSInvester);
        }
        private void fillSharesInvesterCombobox()
        {
            new PlannerInfo.FamilyMemberInfo().FillFamilyMemberInCombo(this._client.ID, cmbSharesInvester);
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
            lblclientNameVal.Text = _client.Name;
        }

        private void tabCurrenStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tabCurrenStatus.SelectedTab.Name)
            {
                case "LifeInsurance":
                    fillLifeInsuranceInfo();
                    break;
                case "GeneralInsurance":
                    fillupGenralInsuranceInfo();
                    break;
                case "MutualFund":
                    fillupMutualFundInfo();
                    break;
                case "NPS":
                    fillupNPSInfo();
                    break;
                case "Shares":
                    fillupSharesInfo();
                    break;
            }
        }

        private void fillupSharesInfo()
        {
            SharesInfo sharesInfo = new SharesInfo();
            _dtShares = sharesInfo.GetSharesInfo(_planeId);
            dtGridShares.DataSource = _dtShares;
            fillSharesInvesterCombobox();
            fillSharesGolsCombobox();
        }

        private void fillupNPSInfo()
        {
            NPSInfo npsInfo = new NPSInfo();
            _dtNPS = npsInfo.GetNPSInfo(_planeId);
            dtGridNPS.DataSource = _dtNPS;
            fillNPSInvesterCombobox();
            fillNPSGolsCombobox();
        }

        private void fillNPSGolsCombobox()
        {
            cmbNPSGoal.Items.Clear();
            _goals = new GoalsInfo().GetAll(_planeId);
            foreach (var goal in _goals)
            {
                cmbNPSGoal.Items.Add(goal.Name);
            }
            cmbNPSGoal.Items.Add("");
        }

        private void fillSharesGolsCombobox()
        {
            cmbSharesGoal.Items.Clear();
            _goals = new GoalsInfo().GetAll(_planeId);
            foreach (var goal in _goals)
            {
                cmbSharesGoal.Items.Add(goal.Name);
            }
            cmbSharesGoal.Items.Add("");
        }

        private void fillupMutualFundInfo()
        {
            MutualFundInfo mutualFundInfo = new MutualFundInfo();
            _dtMutualFund = mutualFundInfo.GetMutualFundInfo(_planeId);
            dtGridMF.DataSource = _dtMutualFund;
            fillMutualFundInvesterCombobox();
            fillMutualfundGolsCombobox();
        }

        private void fillupGenralInsuranceInfo()
        {
            GeneralInsuranceInfo gernalInsuranceInfo = new GeneralInsuranceInfo();
            _dtGeneralInsurance = gernalInsuranceInfo.GetLifeInsuranceInfo(_planeId);
            dtGridGeneralInsurance.DataSource = _dtGeneralInsurance;
            gernalInsuranceInfo.SetGridColumn(dtGridGeneralInsurance);
            fillGeneralInsuranceApplicantCombobox();
        }

        private void fillLifeInsuranceInfo()
        {
            LifeInsuranceInfo lifeInsuranceInfo = new LifeInsuranceInfo();
            _dtLifeInsurance = lifeInsuranceInfo.GetLifeInsuranceInfo(_planeId);
            dtGridLifeInsurance.DataSource = _dtLifeInsurance;
            lifeInsuranceInfo.SetGridColumn(dtGridLifeInsurance);
            fillLifeInsuranceApplicantCombobox();
        }

        private void cmbPlan_SelectedValueChanged(object sender, EventArgs e)
        {
            var val =  _dtPlan.Select("NAME ='" + cmbPlan.Text + "'");
            _planeId = int.Parse(val[0][0].ToString());
            fillLifeInsuranceInfo();
        }

        private void dtGridLifeInsurance_SelectionChanged(object sender, EventArgs e)
        {
            DataRow dr = getSelectedDataRowForLifeInsurance();
            if (dr != null)
                displayLifeInsuranceInfo(dr);
        }

        private void displayLifeInsuranceInfo(DataRow dr)
        {
            cmbApplicant.Tag = int.Parse(dr.Field<string>("ID"));
            cmbApplicant.Text = dr.Field<string>("Applicant");
            txtBranch.Text = dr.Field<string>("Branch");
            txtAgent.Text = dr.Field<string>("Agent");
            dtDateOfIssue.Checked = !(System.DBNull.Value == dr["DateOfIssue"]);
            dtDateOfIssue.Value = DateTime.Parse(dr["DateOfIssue"].ToString());
            dtMaturityDate.Checked = !(System.DBNull.Value == dr["MaturityDate"]);
            dtMaturityDate.Value = DateTime.Parse(dr["MaturityDate"].ToString());
            txtCompany.Text = dr.Field<string>("Company");
            txtPolicyName.Text = dr.Field<string>("PolicyName");
            txtPolicyNo.Text = dr.Field<string>("PolicyNo");
            txtPrmium.Text = dr.Field<string>("Premium");
            txtTerm.Text = dr.Field<string>("Terms");
            txtPremiumPayTerm.Text = dr.Field<string>("PremiumPayTerm");
            txtSumAssured.Text = dr.Field<string>("SumAssured");
            txtStatus.Text = dr.Field<string>("Status");
            cmbModeOfPayment.Text = dr.Field<string>("ModeOfPayment");
            cmbMoneyBack.Text = dr.Field<string>("Moneyback");
            dtNextPremiumDate.Checked = !(System.DBNull.Value == dr["NextPremDate"]);
            dtNextPremiumDate.Value = DateTime.Parse(dr["NextPremDate"].ToString());
            txtAccidentalDeathBenefit.Text = dr.Field<string>("AccidentalDeathBenefit");
            cmbType.Text = dr.Field<string>("Type");
            txtAppointee.Text = dr.Field<string>("Appointee");
            txtNominee.Text = dr.Field<string>("Nominee");
            txtRelation.Text = dr.Field<string>("Relation");
            txtLoanTaken.Text = dr.Field<string>("LoanTaken");
            if (dtLoanDate.Checked = !(System.DBNull.Value == dr["LoanDate"]))
                dtLoanDate.Value = DateTime.Parse(dr["LoanDate"].ToString());
            txtBalanceUnit.Text = dr.Field<string>("BalanceUnit");
            if (dtAsOnDate.Checked = !(System.DBNull.Value == dr["AsOnDate"]))
                dtAsOnDate.Value = DateTime.Parse(dr["AsOnDate"].ToString());
            txtCurrentValue.Text = dr.Field<string>("CurrentValue");
            txtExpectedMaturityValue.Text = dr.Field<string>("ExpectedMaturityValue");
            txtRider1.Text = dr.Field<string>("Rider1");
            txtRider1Amt.Text = dr.Field<string>("Rider1Amount");
            txtRider2.Text = dr.Field<string>("Rider2");
            txtRider2Amt.Text = dr.Field<string>("Rider2Amount");
            txtRemarks.Text = dr.Field<string>("Remarks");
            txtAttachPath.Text = dr.Field<string>("AttachmentPath");
        }

        private DataRow getSelectedDataRowForLifeInsurance()
        {
            if (dtGridLifeInsurance.SelectedRows.Count >= 1)
            {
                int selectedRowIndex = dtGridLifeInsurance.SelectedRows[0].Index;
                if (dtGridLifeInsurance.SelectedRows[0].Cells["ID"].Value != System.DBNull.Value)
                {
                    int selectedUserId = int.Parse(dtGridLifeInsurance.SelectedRows[0].Cells["ID"].Value.ToString());
                    DataRow[] rows = _dtLifeInsurance.Select("Id ='" + selectedUserId +"'");
                    foreach (DataRow dr in rows)
                    {
                        return dr;
                    }
                }
            }
            return null;
        }

        private void btnAddFamilyMember_Click(object sender, EventArgs e)
        {
            pnlLifeInsuranceDetail.Enabled = true;
            setDefaultValue();
        }

        private void setDefaultValue()
        {
            fillLifeInsuranceApplicantCombobox();
            cmbApplicant.Tag = "0";
            cmbApplicant.Text = "";
            txtBranch.Text = "";
            txtAgent.Text = "";
            dtDateOfIssue.Checked = false;
            dtMaturityDate.Checked = false;
            txtCompany.Text = "";
            txtPolicyName.Text = "";
            txtPolicyNo.Text = "";
            txtPrmium.Text = "0";
            txtTerm.Text = "0";
            txtPremiumPayTerm.Text = "";
            txtSumAssured.Text = "0";
            txtStatus.Text = "";
            cmbModeOfPayment.Text = "";
            cmbMoneyBack.Text = "";
            dtNextPremiumDate.Checked = false;
            txtAccidentalDeathBenefit.Text = "";
            cmbType.Text = "";
            txtAppointee.Text = "";
            txtNominee.Text = "";
            txtRelation.Text = "";
            txtLoanTaken.Text = "";
            dtLoanDate.Checked = false;
            txtBalanceUnit.Text = "";
            dtAsOnDate.Checked = false;
            txtCurrentValue.Text = "";
            txtExpectedMaturityValue.Text = "";
            txtRider1.Text = "";
            txtRider1Amt.Text = "0";
            txtRider2.Text = "";
            txtRider2Amt.Text = "0";
            txtRemarks.Text = "";
            txtAttachPath.Text = "";
        }

        private void btnEditFamilyMember_Click(object sender, EventArgs e)
        {
            if (dtGridLifeInsurance.SelectedRows.Count > 0)
                pnlLifeInsuranceDetail.Enabled = true;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            pnlLifeInsuranceDetail.Enabled = false;
        }

        private void btnPersonalDetailSave_Click(object sender, EventArgs e)
        {
            LifeInsuranceInfo lifeInsuranceInfo = new LifeInsuranceInfo();
            LifeInsurance lifeInsurance = getLifeInsuranceData();
            bool isSaved = false;

            if (lifeInsurance != null && lifeInsurance.Id == 0)
                isSaved = lifeInsuranceInfo.Add(lifeInsurance);
            else
                isSaved = lifeInsuranceInfo.Update(lifeInsurance);

            if (isSaved)
            {
                MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fillLifeInsuranceInfo();
                pnlLifeInsuranceDetail.Enabled = false;
            }
            else
                MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private LifeInsurance getLifeInsuranceData()
        {
            LifeInsurance lifeInsurance = new FinancialPlanner.Common.Model.CurrentStatus.LifeInsurance();

            lifeInsurance.Id = int.Parse(cmbApplicant.Tag.ToString());
            lifeInsurance.Pid = _planeId;
            lifeInsurance.Applicant = cmbApplicant.Text;
            lifeInsurance.Branch = txtBranch.Text;
            lifeInsurance.Agent = txtAgent.Text;
            if (dtDateOfIssue.Checked)
                lifeInsurance.DateOfIssue = dtDateOfIssue.Value;
            if (dtMaturityDate.Checked)
                lifeInsurance.MaturityDate = dtMaturityDate.Value;
            lifeInsurance.Company = txtCompany.Text;
            lifeInsurance.PolicyName = txtPolicyName.Text;
            lifeInsurance.PolicyNo = txtPolicyNo.Text;
            lifeInsurance.Premium = double.Parse(txtPrmium.Text);
            lifeInsurance.Terms = int.Parse(txtTerm.Text);
            lifeInsurance.PremiumPayTerm = txtPremiumPayTerm.Text;
            lifeInsurance.SumAssured = double.Parse(txtSumAssured.Text);
            lifeInsurance.Status = txtStatus.Text;
            lifeInsurance.ModeOfPayment = cmbModeOfPayment.Text;
            lifeInsurance.Moneyback = cmbMoneyBack.Text;
            if (dtNextPremiumDate.Checked)
                lifeInsurance.NextPremDate = dtNextPremiumDate.Value;
            lifeInsurance.AccidentalDeathBenefit = double.Parse(txtAccidentalDeathBenefit.Text);
            lifeInsurance.Type = cmbType.Text;
            lifeInsurance.Appointee = txtAppointee.Text;
            lifeInsurance.Nominee = txtNominee.Text;
            lifeInsurance.Relation = txtRelation.Text;
            lifeInsurance.LoanTaken = double.Parse(txtLoanTaken.Text);
            if (dtLoanDate.Checked)
                lifeInsurance.LoanDate = dtLoanDate.Value;
            lifeInsurance.BalanceUnit = txtBalanceUnit.Text;
            if (dtAsOnDate.Checked)
                lifeInsurance.AsOnDate = dtAsOnDate.Value;
            lifeInsurance.CurrentValue = double.Parse(txtCurrentValue.Text);
            lifeInsurance.ExpectedMaturityValue = double.Parse(txtExpectedMaturityValue.Text);
            lifeInsurance.Rider1 = txtRider1.Text;
            lifeInsurance.Rider1Amount = double.Parse(txtRider1Amt.Text);
            lifeInsurance.Rider2 = txtRider2.Text;
            lifeInsurance.Rider2Amount = double.Parse(txtRider2Amt.Text);
            lifeInsurance.Remarks = txtRemarks.Text;
            lifeInsurance.AttachmentPath = txtAttachPath.Text;
            lifeInsurance.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            lifeInsurance.CreatedBy = Program.CurrentUser.Id;
            lifeInsurance.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            lifeInsurance.UpdatedBy = Program.CurrentUser.Id;
            lifeInsurance.MachineName = Environment.MachineName;
            return lifeInsurance;
        }

        private void dtGridGeneralInsurance_SelectionChanged(object sender, EventArgs e)
        {
            DataRow dr = getSelectedDataRowForGeneralInsurance();
            if (dr != null)
                displayGernalInsuranceInfo(dr);
        }

        private void displayGernalInsuranceInfo(DataRow dr)
        {
            if (dr != null)
            {
                cmbGeneralInsuranceApplicant.Tag = dr.Field<string>("ID");
                cmbGeneralInsuranceApplicant.Text = dr.Field<string>("Applicant");
                dtGenralInsIssueDate.Checked = !(System.DBNull.Value == dr["IssueDate"]);
                if (dtGenralInsIssueDate.Checked)
                    dtGenralInsIssueDate.Value = DateTime.Parse(dr["IssueDate"].ToString());
                dtGenInsMaturityDate.Checked = !(System.DBNull.Value == dr["MaturityDate"]);
                if (dtGenralInsIssueDate.Checked)
                    dtGenInsMaturityDate.Value = DateTime.Parse(dr["MaturityDate"].ToString());
                txtGenInsTerm.Text = dr.Field<string>("TermsInYears");
                txtGenInsPolicyNumber.Text = dr.Field<string>("PolicyNo");
                cmbGenInsCompany.Text = dr.Field<string>("Company");
                cmbGenInsPolicy.Text = dr.Field<string>("Policy");
                cmbGenInsType.Text = dr.Field<string>("Type");
                txtGenInsSumAssured.Text = dr.Field<string>("SumAssured");
                txtGenInsBonus.Text = dr.Field<string>("Bonus");
                txtGenInsPremium.Text = dr.Field<string>("Premium");
                txtGenInsRemark.Text = dr.Field<string>("Remark");
                txtGenInsAttachmentPath.Text = dr.Field<string>("AttachmentPath");
            }
        }

        private DataRow getSelectedDataRowForGeneralInsurance()
        {
            if (dtGridGeneralInsurance.SelectedRows.Count >= 1)
            {
                int selectedRowIndex = dtGridGeneralInsurance.SelectedRows[0].Index;
                if (dtGridGeneralInsurance.SelectedRows[0].Cells["ID"].Value != System.DBNull.Value)
                {
                    int selectedUserId = int.Parse(dtGridGeneralInsurance.SelectedRows[0].Cells["ID"].Value.ToString());
                    DataRow[] rows = _dtGeneralInsurance.Select("Id ='" + selectedUserId +"'");
                    foreach (DataRow dr in rows)
                    {
                        return dr;
                    }
                }
            }
            return null;
        }

        private void btnGenInsAdd_Click(object sender, EventArgs e)
        {
            grpGeneralInsurance.Enabled = true;
            setDefaultValueForGeneralInsurance();
        }

        private void setDefaultValueForGeneralInsurance()
        {
            fillGeneralInsuranceApplicantCombobox();
            cmbGeneralInsuranceApplicant.Tag = "0";
            cmbGeneralInsuranceApplicant.Text = "";
            dtGenralInsIssueDate.Checked = false;
            dtGenralInsIssueDate.Text = "";
            dtGenInsMaturityDate.Checked = false;
            dtGenInsMaturityDate.Text = "";
            txtGenInsTerm.Text = "";
            txtGenInsPolicyNumber.Text = "";
            cmbGenInsCompany.Text = "";
            cmbGenInsPolicy.Text = "";
            cmbGenInsType.Text = "";
            txtGenInsSumAssured.Text = "";
            txtGenInsBonus.Text = "";
            txtGenInsPremium.Text = "";
            txtGenInsRemark.Text = "";
            txtGenInsAttachmentPath.Text = "";
        }

        private void btnGenInsEdit_Click(object sender, EventArgs e)
        {
            if (dtGridGeneralInsurance.SelectedRows.Count > 0)
                grpGeneralInsurance.Enabled = true;
        }

        private void btnGenInsCancel_Click(object sender, EventArgs e)
        {
            grpGeneralInsurance.Enabled = false;
        }

        private void btnGenInsSave_Click(object sender, EventArgs e)
        {
            GeneralInsuranceInfo generalInsuranceInfo = new GeneralInsuranceInfo();
            GeneralInsurance generalInsurance = getGeneralInsurnaceData();
            bool isSaved = false;

            if (generalInsurance != null && generalInsurance.Id == 0)
                isSaved = generalInsuranceInfo.Add(generalInsurance);
            else
                isSaved = generalInsuranceInfo.Update(generalInsurance);

            if (isSaved)
            {
                MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fillupGenralInsuranceInfo();
                grpGeneralInsurance.Enabled = false;
            }
            else
                MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private GeneralInsurance getGeneralInsurnaceData()
        {
            GeneralInsurance genIns = new FinancialPlanner.Common.Model.CurrentStatus.GeneralInsurance();
            genIns.Id = int.Parse(cmbGeneralInsuranceApplicant.Tag.ToString());
            genIns.Pid = _planeId;
            genIns.Applicant = cmbGeneralInsuranceApplicant.Text;
            if (dtGenralInsIssueDate.Checked)
                genIns.IssueDate = DateTime.Parse(dtGenralInsIssueDate.Text);
            else
                genIns.IssueDate = null;
            if (dtGenInsMaturityDate.Checked)
                genIns.MaturityDate = DateTime.Parse(dtGenInsMaturityDate.Text);
            else
                genIns.MachineName = null;
            genIns.TermsInYears = int.Parse(txtGenInsTerm.Text);
            genIns.PolicyNo = txtGenInsPolicyNumber.Text;
            genIns.Company = cmbGenInsCompany.Text;
            genIns.Policy = cmbGenInsPolicy.Text;
            genIns.Type = cmbGenInsType.Text;
            genIns.SumAssured = double.Parse(txtGenInsSumAssured.Text);
            genIns.Bonus = double.Parse(txtGenInsBonus.Text);
            genIns.Premium = double.Parse(txtGenInsPremium.Text);
            genIns.Remark = txtGenInsRemark.Text;
            genIns.AttachmentPath = txtGenInsAttachmentPath.Text;
            genIns.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            genIns.UpdatedBy = Program.CurrentUser.Id;
            genIns.UpdatedByUserName = Program.CurrentUser.UserName;
            genIns.MachineName = System.Environment.MachineName;
            return genIns;
        }

        private void btnGenInsDelete_Click(object sender, EventArgs e)
        {
            if (dtGridGeneralInsurance.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure, you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    GeneralInsuranceInfo generalInsuranceInfo = new GeneralInsuranceInfo();
                    GeneralInsurance generalInsurance = getGeneralInsurnaceData();
                    if (!generalInsuranceInfo.Delete(generalInsurance))
                        MessageBox.Show("Unable to delete selected record. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    fillupGenralInsuranceInfo();
                }
            }
        }

        private void btnDeleteLifeInsurance_Click(object sender, EventArgs e)
        {
            if (dtGridLifeInsurance.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure, you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    LifeInsuranceInfo lifeInsuranceInfo = new LifeInsuranceInfo();
                    LifeInsurance lifeInsurance =  getLifeInsuranceData();
                    lifeInsuranceInfo.Delete(lifeInsurance);
                    fillLifeInsuranceInfo();
                }
            }
        }

        private void dtGridMF_SelectionChanged(object sender, EventArgs e)
        {
            DataRow dr = getSelectedDataRowForMutualFund();
            if (dr != null)
                displayMutualFundInfo(dr);
            else
                setDefaultValueMF();
        }

        private void displayMutualFundInfo(DataRow dr)
        {
            if (dr != null)
            {
                cmbMFInvester.Tag = dr.Field<string>("ID");
                cmbMFInvester.Text = dr.Field<string>("InvesterName");
                cmbSchemeName.Text = dr.Field<string>("SchemeName");
                txtFolioNo.Text = dr.Field<string>("FolioNo");
                txtNav.Text = dr["NAV"].ToString();
                txtUnits.Text = dr["units"].ToString();
                calculateAndSetMFCurrentValue();
                txtMFEquityRatio.Text = dr["EquityRatio"].ToString();
                txtMFGoldRatio.Text = dr["GoldRatio"].ToString();
                txtMFDebtRatio.Text = dr["DebtRatio"].ToString();
                txtSIPAmount.Text = dr["SIP"].ToString();
                txtFreeUnits.Text = dr["FreeUnit"].ToString();
                txtRedumptionAmt.Text = dr["RedumptionAmount"].ToString();
                if (dr["GoalID"] != null)
                {
                    cmbMFGoal.Tag = dr["GoalId"].ToString();
                    cmbMFGoal.Text = getGoalName(int.Parse(cmbMFGoal.Tag.ToString()));                    
                }
                else
                {
                    cmbMFGoal.Tag = "0";
                    cmbMFGoal.Text = "";
                }
            }
        }

        private string getGoalName(int v)
        {
            if (_goals != null && v > 0 )
                return _goals.FirstOrDefault(i => i.Id == v).Name;
            else
                return string.Empty;
        }

        private DataRow getSelectedDataRowForMutualFund()
        {
            if (dtGridMF.SelectedRows.Count >= 1)
            {
                int selectedRowIndex = dtGridMF.SelectedRows[0].Index;
                if (dtGridMF.SelectedRows[0].Cells["ID"].Value != System.DBNull.Value)
                {
                    int selectedUserId = int.Parse(dtGridMF.SelectedRows[0].Cells["ID"].Value.ToString());
                    DataRow[] rows = _dtMutualFund.Select("Id ='" + selectedUserId +"'");
                    foreach (DataRow dr in rows)
                    {
                        return dr;
                    }
                }
            }
            return null;
        }

        private void btnAddMF_Click(object sender, EventArgs e)
        {
            grpMF.Enabled = true;
            setDefaultValueMF();
        }

        private void setDefaultValueMF()
        {
            cmbMFInvester.Tag = "0";
            cmbMFInvester.Text = "";
            cmbSchemeName.Text = "";
            txtFolioNo.Text = "";
            txtNav.Text = "";
            txtUnits.Text = "";
            txtMFCurrentVal.Text = "0";
            txtMFEquityRatio.Text = "0";
            txtMFGoldRatio.Text = "0";
            txtMFDebtRatio.Text = "0";
            txtFreeUnits.Text = "0";
            txtRedumptionAmt.Text = "";
            cmbMFGoal.Text = "";
            cmbMFGoal.Tag = "0";
        }

        private void txtNav_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtNav_Leave(object sender, EventArgs e)
        {
            calculateAndSetMFCurrentValue();
        }
        private void calculateAndSetMFCurrentValue()
        {
            float nav = 0;
            double units = 0;
            float.TryParse(txtNav.Text, out nav);
            double.TryParse(txtUnits.Text, out units);
            txtMFCurrentVal.Text = (nav * units).ToString();
        }

        private void calculateAndSetNPSCurrentValue()
        {
            float nav = 0;
            double units = 0;
            float.TryParse(txtNPSNAV.Text, out nav);
            double.TryParse(txtNPSUnits.Text, out units);
            txtNPSCurrentVal.Text = (nav * units).ToString();
        }
        private void calculateAndSetSharesCurrentValue()
        {
            float nav = 0;
            double units = 0;
            float.TryParse(txtSharesMarketPrice.Text, out nav);
            double.TryParse(txtNoOfShares.Text, out units);
            txtSharesCurrentValue.Text = (nav * units).ToString();
        }
        private void btnCancelMF_Click(object sender, EventArgs e)
        {
            grpMF.Enabled = false;
        }

        private void btnSaveMF_Click(object sender, EventArgs e)
        {
            MutualFundInfo mutualFundInfo = new MutualFundInfo();
            MutualFund mf = getMutualFundData();
            bool isSaved = false;

            if (mf != null && mf.Id == 0)
                isSaved = mutualFundInfo.Add(mf);
            else
                isSaved = mutualFundInfo.Update(mf);

            if (isSaved)
            {
                MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fillupMutualFundInfo();
                grpMF.Enabled = false;
            }
            else
                MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private MutualFund getMutualFundData()
        {
            MutualFund mf = new MutualFund();
            mf.Id = int.Parse(cmbMFInvester.Tag.ToString());
            mf.Pid = _planeId;
            mf.InvesterName = cmbMFInvester.Text;
            mf.SchemeName = cmbSchemeName.Text;
            mf.FolioNo = txtFolioNo.Text;
            mf.Nav = float.Parse(txtNav.Text);
            mf.Units = int.Parse(txtUnits.Text);
            mf.EquityRatio = float.Parse(txtMFEquityRatio.Text);
            mf.GoldRatio = float.Parse(txtMFGoldRatio.Text);
            mf.DebtRatio = float.Parse(txtMFDebtRatio.Text);
            mf.FreeUnit = int.Parse(txtFreeUnits.Text);
            mf.RedumptionAmount = double.Parse(txtRedumptionAmt.Text);
            mf.GoalID = int.Parse(cmbMFGoal.Tag.ToString());
            mf.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            mf.CreatedBy = Program.CurrentUser.Id;
            mf.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            mf.UpdatedBy = Program.CurrentUser.Id;
            mf.MachineName = Environment.MachineName;
            return mf;
        }

        private void cmbSchemeName_Enter(object sender, EventArgs e)
        {
            if (_dtMutualFund != null)
            {
                var distinctRows = (from DataRow dRow in _dtMutualFund.Rows
                                    select dRow["SchemeName"] ).Distinct();
                foreach (var schmeName in distinctRows)
                {
                    cmbSchemeName.Items.Add(schmeName);
                }
            }
        }

        private void cmbMFGoal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbMFGoal.Text != "")
                cmbMFGoal.Tag = _goals.FirstOrDefault(i => i.Name == cmbMFGoal.Text).Id;
            else
                cmbMFGoal.Tag = "0";
        }

        private void btnEditMF_Click(object sender, EventArgs e)
        {
            if (dtGridMF.SelectedRows.Count > 0)
                grpMF.Enabled = true;
        }

        private void btnDeleteMF_Click(object sender, EventArgs e)
        {
            if (dtGridMF.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure, you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MutualFundInfo mutualFundInfo = new MutualFundInfo();
                    MutualFund mutualFund =  getMutualFundData();
                    mutualFundInfo.Delete(mutualFund);
                    fillupMutualFundInfo();
                }
            }
        }

        private void btnAddNPS_Click(object sender, EventArgs e)
        {
            grpNPS.Enabled = true;
            setDefaultValueNPS();
        }

        private void setDefaultValueNPS()
        {
            cmbNPSInvester.Tag = "0";
            cmbNPSInvester.Text = "";
            cmbSchemeName.Text = "";
            txtNPSFolioNo.Text = "";
            txtNPSNAV.Text = "";
            txtUnits.Text = "";
            txtNPSCurrentVal.Text = "0";
            txtNPSEquityRatio.Text = "0";
            txtNPSGoldRatio.Text = "0";
            txtNPSDebtRatio.Text = "0";
            cmbNPSGoal.Text = "";
            cmbNPSGoal.Tag = "0";
        }

        private void btnEditNPS_Click(object sender, EventArgs e)
        {
            grpNPS.Enabled = true;
        }

        private void cmbNPSGoal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNPSGoal.Text != "")
                cmbNPSGoal.Tag = _goals.FirstOrDefault(i => i.Name == cmbNPSGoal.Text).Id;
            else
                cmbNPSGoal.Tag = "0";
        }

        private void btnNPSCancel_Click(object sender, EventArgs e)
        {
            grpNPS.Enabled = false;
        }

        private void btnDeleteNPS_Click(object sender, EventArgs e)
        {
            if (dtGridNPS.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure, you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    NPSInfo npsInfo = new NPSInfo();
                    NPS nps  =  getNPSData();
                    npsInfo.Delete(nps);
                    fillupNPSInfo();
                }
            }
        }

        private NPS getNPSData()
        {
            NPS  nps = new NPS();
            nps.Id = int.Parse(cmbNPSInvester.Tag.ToString());
            nps.Pid = _planeId;
            nps.InvesterName = cmbNPSInvester.Text;
            nps.SchemeName = cmbNPSScheme.Text;
            nps.FolioNo = txtNPSFolioNo.Text;
            nps.Nav = float.Parse(txtNPSNAV.Text);
            nps.Units = int.Parse(txtNPSUnits.Text);
            nps.EquityRatio = float.Parse(txtNPSEquityRatio.Text);
            nps.GoldRatio = float.Parse(txtNPSGoldRatio.Text);
            nps.DebtRatio = float.Parse(txtNPSDebtRatio.Text);
            nps.GoalID = int.Parse(cmbNPSGoal.Tag.ToString());
            nps.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            nps.CreatedBy = Program.CurrentUser.Id;
            nps.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            nps.UpdatedBy = Program.CurrentUser.Id;
            nps.MachineName = Environment.MachineName;
            return nps;
        }

        private void btnNPSSave_Click(object sender, EventArgs e)
        {
            NPSInfo nPSInfo = new NPSInfo();
            NPS mf = getNPSData();
            bool isSaved = false;

            if (mf != null && mf.Id == 0)
                isSaved = nPSInfo.Add(mf);
            else
                isSaved = nPSInfo.Update(mf);

            if (isSaved)
            {
                MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fillupNPSInfo();
                grpMF.Enabled = false;
            }
            else
                MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void txtNPSNAV_Leave(object sender, EventArgs e)
        {
            calculateAndSetNPSCurrentValue();
        }

        private void txtNPSUnits_Leave(object sender, EventArgs e)
        {
            calculateAndSetNPSCurrentValue();
        }

        private void dtGridNPS_SelectionChanged(object sender, EventArgs e)
        {
            DataRow dr = getSelectedDataRowForNPS();
            if (dr != null)
                displayNPSInfo(dr);
            else
                setDefaultValueNPS();
        }

        private void displayNPSInfo(DataRow dr)
        {
            if (dr != null)
            {
                cmbNPSInvester.Tag = dr.Field<string>("ID");
                cmbNPSInvester.Text = dr.Field<string>("InvesterName");
                cmbNPSScheme.Text = dr.Field<string>("SchemeName");
                txtNPSFolioNo.Text = dr.Field<string>("FolioNo");
                txtNPSNAV.Text = dr["NAV"].ToString();
                txtNPSUnits.Text = dr["units"].ToString();
                calculateAndSetNPSCurrentValue();
                txtNPSEquityRatio.Text = dr["EquityRatio"].ToString();
                txtNPSGoldRatio.Text = dr["GoldRatio"].ToString();
                txtNPSDebtRatio.Text = dr["DebtRatio"].ToString();
                txtSIPAmount.Text = dr["SIP"].ToString();              
                if (dr["GoalID"] != null)
                {
                    cmbNPSGoal.Tag = dr["GoalId"].ToString();
                    cmbNPSGoal.Text = getGoalName(int.Parse(cmbNPSGoal.Tag.ToString()));
                }
                else
                {
                    cmbNPSGoal.Tag = "0";
                    cmbNPSGoal.Text = "";
                }
            }
        }

        private DataRow getSelectedDataRowForNPS()
        {
            if (dtGridNPS.SelectedRows.Count >= 1)
            {
                int selectedRowIndex = dtGridNPS.SelectedRows[0].Index;
                if (dtGridNPS.SelectedRows[0].Cells["ID"].Value != System.DBNull.Value)
                {
                    int selectedUserId = int.Parse(dtGridNPS.SelectedRows[0].Cells["ID"].Value.ToString());
                    
                    DataRow[] rows = _dtNPS.Select("Id ='" + selectedUserId +"'");
                    foreach (DataRow dr in rows)
                    {
                        return dr;
                    }
                }
            }
            return null;
        }

        private DataRow getSelectedDataRowForShares()
        {
            if (dtGridShares.SelectedRows.Count >= 1)
            {
                int selectedRowIndex = dtGridShares.SelectedRows[0].Index;
                if (dtGridShares.SelectedRows[0].Cells["ID"].Value != System.DBNull.Value)
                {
                    int selectedUserId = int.Parse(dtGridShares.SelectedRows[0].Cells["ID"].Value.ToString());

                    DataRow[] rows = _dtShares.Select("Id ='" + selectedUserId +"'");
                    foreach (DataRow dr in rows)
                    {
                        return dr;
                    }
                }
            }
            return null;
        }

        private void dtGridShares_SelectionChanged(object sender, EventArgs e)
        {
            DataRow dr = getSelectedDataRowForShares();
            if (dr != null)
                displaySharesInfo(dr);
            else
                setDefaultValueShares();
        }

        private void setDefaultValueShares()
        {
            cmbSharesInvester.Tag = "0";
            cmbSharesInvester.Text = "";
            cmbSharesCompnay.Text = "";
            txtSharesFaceValue.Text = "0";
            txtNoOfShares.Text = "0";
            txtSharesMarketPrice.Text = "0";
            txtSharesCurrentValue.Text = "0";
            calculateAndSetSharesCurrentValue();
            cmbSharesGoal.Tag = "0";
            cmbSharesGoal.Text = "";
        }

        private void displaySharesInfo(DataRow dr)
        {
            if (dr != null)
            {
                cmbSharesInvester.Tag = dr.Field<string>("ID");
                cmbSharesInvester.Text = dr.Field<string>("InvesterName");
                cmbSharesCompnay.Text = dr.Field<string>("CompanyName");
                txtSharesFaceValue.Text = dr.Field<string>("FaceValue");
                txtNoOfShares.Text = dr["NoOfShares"].ToString();
                txtSharesMarketPrice.Text = dr["MarketPrice"].ToString();
                txtSharesCurrentValue.Text = dr["CurrentValue"].ToString();
                calculateAndSetSharesCurrentValue();             
                if (dr["GoalID"] != null)
                {
                    cmbSharesGoal.Tag = dr["GoalId"].ToString();
                    cmbSharesGoal.Text = getGoalName(int.Parse(cmbSharesGoal.Tag.ToString()));
                }
                else
                {
                    cmbSharesGoal.Tag = "0";
                    cmbSharesGoal.Text = "";
                }
            }
        }

        private void btnSharesSave_Click(object sender, EventArgs e)
        {
            SharesInfo SharesInfo = new SharesInfo();
            Shares shares = getSharesData();
            bool isSaved = false;

            if (shares != null && shares.Id == 0)
                isSaved = SharesInfo.Add(shares);
            else
                isSaved = SharesInfo.Update(shares);

            if (isSaved)
            {
                MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fillupSharesInfo();
                grpMF.Enabled = false;
            }
            else
                MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private Shares getSharesData()
        {
            Shares  shares = new Shares();
            shares.Id = int.Parse(cmbSharesInvester.Tag.ToString());
            shares.Pid = _planeId;
            shares.InvesterName = cmbSharesInvester.Text;
            shares.CompanyName = cmbSharesCompnay.Text;
            shares.FaceValue = float.Parse(txtSharesFaceValue.Text);
            shares.NoOfShares = int.Parse(txtNoOfShares.Text);
            shares.MarketPrice = float.Parse(txtSharesMarketPrice.Text);
            shares.CurrentValue = double.Parse(txtSharesCurrentValue.Text);        
            shares.GoalID = int.Parse(cmbSharesGoal.Tag.ToString());
            shares.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            shares.CreatedBy = Program.CurrentUser.Id;
            shares.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            shares.UpdatedBy = Program.CurrentUser.Id;
            shares.MachineName = Environment.MachineName;
            return shares;
        }

        private void btnSharesCancel_Click(object sender, EventArgs e)
        {
            grpShares.Enabled = false;
        }

        private void btnSharesEdit_Click(object sender, EventArgs e)
        {
            if (dtGridShares.SelectedRows.Count > 0)
                grpShares.Enabled = true;
        }

        private void btnSharesDelete_Click(object sender, EventArgs e)
        {
            if (dtGridShares.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure, you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SharesInfo SharesInfo = new SharesInfo();
                    Shares Shares  =  getSharesData();
                    SharesInfo.Delete(Shares);
                    fillupSharesInfo();
                }
            }
        }
    }
}
