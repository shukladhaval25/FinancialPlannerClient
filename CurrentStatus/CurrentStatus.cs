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
using FinancialPlanner.Common.Model.CurrentStatus;
using FinancialPlannerClient.CurrentStatus;

namespace FinancialPlannerClient.CurrentStatus
{
    public partial class CurrentStatus : Form
    {
        private Client _client;
        int _planeId = 0;
        DataTable _dtPlan;
        DataTable _dtLifeInsurance;
        DataTable _dtGeneralInsurance;

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
            }
        }

        private void fillupGenralInsuranceInfo()
        {
            GeneralInsuranceInfo gernalInsuranceInfo = new GeneralInsuranceInfo();
            _dtGeneralInsurance = gernalInsuranceInfo.GetLifeInsuranceInfo(_planeId);
            dtGridGeneralInsurance.DataSource = _dtGeneralInsurance;
            gernalInsuranceInfo.SetGridColumn(dtGridGeneralInsurance);
        }

        private void fillLifeInsuranceInfo()
        {
            LifeInsuranceInfo lifeInsuranceInfo = new LifeInsuranceInfo();
            _dtLifeInsurance = lifeInsuranceInfo.GetLifeInsuranceInfo(_planeId);
            dtGridLifeInsurance.DataSource = _dtLifeInsurance;
            lifeInsuranceInfo.SetGridColumn(dtGridLifeInsurance);
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
            dtLoanDate.Checked = !(System.DBNull.Value == dr["LoanDate"]);
            dtLoanDate.Value = DateTime.Parse(dr["LoanDate"].ToString());
            txtBalanceUnit.Text = dr.Field<string>("BalanceUnit");
            dtAsOnDate.Checked = !(System.DBNull.Value == dr["AsOnDate"]);
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
    }
}
