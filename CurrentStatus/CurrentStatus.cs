﻿using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.CurrentStatus;
using FinancialPlanner.Common.Permission;
using FinancialPlannerClient.PlannerInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace FinancialPlannerClient.CurrentStatus
{
    public partial class CurrentStatus : Form
    {
        private Client _client;
        int _planeId = 0;
        private Planner planner;
        DataTable _dtPlan;
        DataTable _dtLifeInsurance;
        DataTable _dtGeneralInsurance;
        DataTable _dtMutualFund;
        DataTable _dtNPS;
        DataTable _dtShares;
        DataTable _dtBond;
        DataTable _dtSA;
        IList<Goals> _goals;
        DataTable _dtFD;
        DataTable _dtPPF;
        DataTable _dtEPF;
        DataTable _dtSS;
        DataTable _dtSCSS;
        DataTable _dtOthers;
        DataTable _dtRD;
        DataTable _dtNSC;
        DataTable _dtULIP;

        public CurrentStatus()
        {
            InitializeComponent();
        }

        public CurrentStatus(Client client,Planner planner)
        {
            InitializeComponent();
            this._client = client;
            this.planner = planner;
            this._planeId = planner.ID;
        }

        private void CurrentStatus_Load(object sender, EventArgs e)
        {
            if (_client != null)
            {
                fllupClientAndPlanInfo();
                _dtPlan = new PlannerInfo.PlannerInfo().GetPlanData(_client.ID);
                fillPlanData();
                setAccessControlBasedOnPlannerLockStatus();
            }
        }

        private void setAccessControlBasedOnPlannerLockStatus()
        {
            //General Insurance
            grpActionControls.Visible = !this.planner.IsPlanLocked;
            btnPersonalDetailSave.Visible = !this.planner.IsPlanLocked;

            //General Insurance
            grpGenIsuranceControl.Visible = !this.planner.IsPlanLocked;
            btnGenInsSave.Visible = !this.planner.IsPlanLocked;

            //MF
            grpMFControls.Visible = !this.planner.IsPlanLocked;
            btnSaveMF.Visible = !this.planner.IsPlanLocked; 

            //NPS
            grpNPSControls.Visible = !this.planner.IsPlanLocked;
            btnNPSSave.Visible = !this.planner.IsPlanLocked;

            //Shares
            grpSharesControl.Visible = !this.planner.IsPlanLocked;
            btnSharesSave.Visible = !this.planner.IsPlanLocked;

            //Bonds
            grpBondsControl.Visible = !this.planner.IsPlanLocked;
            btnBondsSave.Visible = !this.planner.IsPlanLocked;

            //Saving Ac
            grpSavingACControls.Visible = !this.planner.IsPlanLocked;
            btnSaveSA.Visible = !this.planner.IsPlanLocked;

            //FD
            grpFDControls.Visible = !this.planner.IsPlanLocked;
            btnFDSave.Visible = !this.planner.IsPlanLocked;

            //RD
            grpRDControls.Visible = !this.planner.IsPlanLocked;
            btnRDSave.Visible = !this.planner.IsPlanLocked;

            //PPF
            grpPPFControls.Visible = !this.planner.IsPlanLocked;
            btnPPFSave.Visible = !this.planner.IsPlanLocked;

            //Sukanya
            grpSSControls.Visible = !this.planner.IsPlanLocked;
            btnSSSave.Visible = !this.planner.IsPlanLocked;

            //SCSS
            grpSCSSControls.Visible = !this.planner.IsPlanLocked;
            btnSCSSSave.Visible = !this.planner.IsPlanLocked;

            //NSC
            grpNSCControls.Visible = !this.planner.IsPlanLocked;
            btnNSCSave.Visible = !this.planner.IsPlanLocked;

            //ULIP
            grpULIPControls.Visible = !this.planner.IsPlanLocked;
            btnULIPSave.Visible = !this.planner.IsPlanLocked;

            //EPF
            grpEPFControls.Visible = !this.planner.IsPlanLocked;
            btnULIPSave.Visible = !this.planner.IsPlanLocked;

            //Others
            grpOtherControls.Visible = !this.planner.IsPlanLocked;
            btnOthersSave.Visible = !this.planner.IsPlanLocked;
        }

        private void fillLifeInsuranceApplicantCombobox()
        {
            new PlannerInfo.FamilyMemberInfo().FillFamilyMemberInCombo(this._client.ID, cmbApplicant);
        }
        private void fillGeneralInsuranceApplicantCombobox()
        {
            new PlannerInfo.FamilyMemberInfo().FillFamilyMemberInCombo(this._client.ID, cmbGeneralInsuranceApplicant);
        }


        private void fillNPSInvesterCombobox()
        {
            new PlannerInfo.FamilyMemberInfo().FillFamilyMemberInCombo(this._client.ID, cmbNPSInvester);
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
                case "Bonds":
                    fillupBondInfo();
                    break;
                case "SavingAC":
                    fillupSavingAccount();
                    break;
                case "FD":
                    fillupFDInfo();
                    break;
                case "RD":
                    fillupRDInfo();
                    break;
                case "PPF":
                    fillupPPFInfo();
                    break;
                case "EPF":
                    fillupEPFInfo();
                    break;
                case "Sukanya":
                    fillupSSInfo();
                    break;
                case "SCSS":
                    fillupSCSSInfo();
                    break;
                case "NSC":
                    fillupNSCInfo();
                    break;
                case "ULIP":
                    fillupULIPInfo();
                    break;
                case "Others":
                    fillupOthersInfo();
                    break;
            }
        }

        #region "FD"
        private void fillupFDInfo()
        {
            setPermission(grpFDControls);
            fillFDInvesterCombobox();
            fillFDGoalsCombobox();
            FDInfo fdInfo = new FDInfo();
            _dtFD = fdInfo.GetFixedDepositInfo(_planeId);
            dtGridFD.DataSource = _dtFD;
            fdInfo.SetGrid(dtGridFD);
        }

        private void fillFDGoalsCombobox()
        {
            cmbFDGoal.Items.Clear();
            _goals = new GoalsInfo().GetAll(_planeId);
            foreach (var goal in _goals)
            {
                cmbFDGoal.Items.Add(goal.Name);
            }
            cmbFDGoal.Items.Add("");
        }

        private void fillFDInvesterCombobox()
        {
            new PlannerInfo.FamilyMemberInfo().FillFamilyMemberInCombo(this._client.ID, cmbFDInvestor);
        }

        private void dtGridFD_SelectionChanged(object sender, EventArgs e)
        {
            DataRow dr = getSelectedDataRow(dtGridFD, _dtFD);
            if (dr != null)
                displayFDInfo(dr);
            else
                setDefaultValueFD();
        }

        private void setDefaultValueFD()
        {
            cmbFDInvestor.Tag = "0";
            cmbFDInvestor.Text = "";
            cmbFDAccountno.Text = "";
            cmbFDGoal.Tag = "0";
            cmbFDGoal.Text = "";
            txtFDBankName.Text = "";
            txtFDBranch.Text = "";
            txtFDROI.Text = "0";
            txtFDBalance.Text = "";
            txtFDMatuirtyAmt.Text = "";

        }

        private void displayFDInfo(DataRow dr)
        {
            if (dr != null)
            {
                cmbFDInvestor.Tag = dr.Field<string>("ID");
                cmbFDInvestor.Text = dr.Field<string>("InvesterName");
                txtFDBankName.Text = dr.Field<string>("BankName");
                cmbFDAccountno.Text = dr.Field<string>("AccountNo");
                txtFDBranch.Text = dr.Field<string>("Branch");
                txtFDBalance.Text = dr.Field<string>("Balance");
                txtFDROI.Text = dr.Field<string>("IntRate");
                txtFDMatuirtyAmt.Text = dr.Field<string>("MaturityAmt");
                dtFDDepositDate.Text = dr.Field<string>("DepositDate");
                dtMaturityDate.Text = dr.Field<string>("MaturityDate");
                if (dr["GoalID"] != null)
                {
                    cmbFDGoal.Tag = dr["GoalId"].ToString();
                    cmbFDGoal.Text = getGoalName(int.Parse(cmbFDGoal.Tag.ToString()));
                }
                else
                {
                    cmbSAGoalId.Tag = "0";
                    cmbSAGoalId.Text = "";
                }
            }
        }

        private void btnFDAdd_Click(object sender, EventArgs e)
        {
            grpFD.Enabled = true;
            setDefaultValueFD();
        }

        private void btnFDEdit_Click(object sender, EventArgs e)
        {
            grpFD.Enabled = true;
        }

        private void btnFDDelete_Click(object sender, EventArgs e)
        {
            if (dtGridFD.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure, you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    FDInfo fdInfo = new FDInfo();
                    FixedDeposit fd = getFDData();
                    fdInfo.Delete(fd);
                    fillupFDInfo();
                }
            }
        }

        private FixedDeposit getFDData()
        {
            FixedDeposit fd = new FixedDeposit();
            fd.Id = int.Parse(cmbFDInvestor.Tag.ToString());
            fd.Pid = _planeId;
            fd.InvesterName = cmbFDInvestor.Text;
            fd.AccountNo = cmbFDAccountno.Text;
            fd.BankName = txtFDBankName.Text;
            fd.Branch = txtFDBranch.Text;
            fd.Balance = (string.IsNullOrEmpty(txtFDBalance.Text) ? 0 : double.Parse(txtFDBalance.Text));
            fd.DepositDate = dtFDDepositDate.Value;
            fd.MaturityAmt = (string.IsNullOrEmpty(txtFDMatuirtyAmt.Text) ? 0 : double.Parse(txtFDMatuirtyAmt.Text));
            fd.MaturityDate = dtFDMaturityDate.Value;
            fd.GoalId = int.Parse(cmbFDGoal.Tag.ToString());
            fd.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            fd.CreatedBy = Program.CurrentUser.Id;
            fd.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            fd.UpdatedBy = Program.CurrentUser.Id;
            fd.MachineName = Environment.MachineName;
            return fd;
        }

        private void btnFDSave_Click(object sender, EventArgs e)
        {
            try
            {
                FDInfo FDInfo = new FDInfo();
                FixedDeposit fd = getFDData();
                bool isSaved = false;

                if (fd != null && fd.Id == 0)
                    isSaved = FDInfo.Add(fd);
                else
                    isSaved = FDInfo.Update(fd);

                if (isSaved)
                {
                    MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillupFDInfo();
                    grpFD.Enabled = false;
                }
                else
                    MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                MessageBox.Show("Unable to save record." + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFDCancel_Click(object sender, EventArgs e)
        {
            grpFD.Enabled = false;
        }

        private void cmbFDGoal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbFDGoal.Text != "")
                cmbFDGoal.Tag = _goals.FirstOrDefault(i => i.Name == cmbFDGoal.Text).Id;
            else
                cmbFDGoal.Tag = "0";
        }
        #endregion

        #region "RD"

        private void cmbRDGoal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbRDGoalId.Text != "")
                cmbRDGoalId.Tag = _goals.FirstOrDefault(i => i.Name == cmbRDGoalId.Text).Id;
            else
                cmbRDGoalId.Tag = "0";
        }

        private void fillupRDInfo()
        {
            setPermission(grpRDControls);
            fillRDInvesterCombobox();
            fillRDGoalsCombobox();
            RDInfo RDInfo = new RDInfo();
            _dtRD = RDInfo.GetRecurringDepositInfo(_planeId);
            dtGridRD.DataSource = _dtRD;
            RDInfo.SetGrid(dtGridRD);
        }

        private void fillRDGoalsCombobox()
        {
            cmbRDGoalId.Items.Clear();
            _goals = new GoalsInfo().GetAll(_planeId);
            foreach (var goal in _goals)
            {
                cmbRDGoalId.Items.Add(goal.Name);
            }
            cmbRDGoalId.Items.Add("");
        }

        private void fillRDInvesterCombobox()
        {
            new PlannerInfo.FamilyMemberInfo().FillFamilyMemberInCombo(this._client.ID, cmbRDInvestor);
        }

        private void dtGridRD_SelectionChanged(object sender, EventArgs e)
        {
            DataRow dr = getSelectedDataRow(dtGridRD, _dtRD);
            if (dr != null)
                displayRDInfo(dr);
            else
                setDefaultValueRD();
        }

        private void setDefaultValueRD()
        {
            cmbRDInvestor.Tag = "0";
            cmbRDInvestor.Text = "";
            cmbRDAccountNo.Text = "";
            cmbRDGoalId.Tag = "0";
            cmbRDGoalId.Text = "";
            txtRDBankName.Text = "";
            txtRDBranch.Text = "";
            txtRDROI.Text = "0";
            txtRDBalance.Text = "";
            txtRDMaturityAmt.Text = "";
            txtRDMonthlyInstallment.Text = "";

        }

        private void displayRDInfo(DataRow dr)
        {
            if (dr != null)
            {
                cmbRDInvestor.Tag = dr.Field<string>("ID");
                cmbRDInvestor.Text = dr.Field<string>("InvesterName");
                txtRDBankName.Text = dr.Field<string>("BankName");
                cmbRDAccountNo.Text = dr.Field<string>("AccountNo");
                txtRDBranch.Text = dr.Field<string>("Branch");
                txtRDBalance.Text = dr.Field<string>("Balance");
                txtRDROI.Text = dr.Field<string>("IntRate");
                txtRDMonthlyInstallment.Text = dr.Field<string>("MonthlyInstallment");
                txtRDMaturityAmt.Text = dr.Field<string>("MaturityAmt");
                dtRDDepositDate.Text = dr.Field<string>("DepositDate");
                dtMaturityDate.Text = dr.Field<string>("MaturityDate");
                if (dr["GoalID"] != null)
                {
                    cmbRDGoalId.Tag = dr["GoalId"].ToString();
                    cmbRDGoalId.Text = getGoalName(int.Parse(cmbRDGoalId.Tag.ToString()));
                }
                else
                {
                    cmbRDGoalId.Tag = "0";
                    cmbRDGoalId.Text = "";
                }
            }
        }

        private void btnRDAdd_Click(object sender, EventArgs e)
        {
            grpRD.Enabled = true;
            setDefaultValueRD();
        }

        private void btnRDEdit_Click(object sender, EventArgs e)
        {
            grpRD.Enabled = true;
        }

        private void btnRDDelete_Click(object sender, EventArgs e)
        {
            if (dtGridRD.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure, you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    RDInfo RDInfo = new RDInfo();
                    RecurringDeposit RD = getRDData();
                    RDInfo.Delete(RD);
                    fillupRDInfo();
                }
            }
        }

        private RecurringDeposit getRDData()
        {
            RecurringDeposit RD = new RecurringDeposit();
            RD.Id = int.Parse(cmbRDInvestor.Tag.ToString());
            RD.Pid = _planeId;
            RD.InvesterName = cmbRDInvestor.Text;
            RD.AccountNo = cmbRDAccountNo.Text;
            RD.BankName = txtRDBankName.Text;
            RD.Branch = txtRDBranch.Text;
            RD.IntRate = (string.IsNullOrEmpty(txtRDROI.Text) ? 0 : float.Parse(txtRDROI.Text));
            RD.Balance = (string.IsNullOrEmpty(txtRDBalance.Text) ? 0 : double.Parse(txtRDBalance.Text));
            RD.DepositDate = dtRDDepositDate.Value;
            RD.MonthlyInstallment = (string.IsNullOrEmpty(txtRDMonthlyInstallment.Text) ? 0 : double.Parse(txtRDMonthlyInstallment.Text));
            RD.MaturityAmt = (string.IsNullOrEmpty(txtRDMaturityAmt.Text) ? 0 : double.Parse(txtRDMaturityAmt.Text));
            RD.MaturityDate = dtRDMaturityDate.Value;
            RD.GoalId = int.Parse(cmbRDGoalId.Tag.ToString());
            RD.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            RD.CreatedBy = Program.CurrentUser.Id;
            RD.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            RD.UpdatedBy = Program.CurrentUser.Id;
            RD.MachineName = Environment.MachineName;
            return RD;
        }

        private void btnRDSave_Click(object sender, EventArgs e)
        {
            try
            {

                RDInfo RDInfo = new RDInfo();
                RecurringDeposit RD = getRDData();
                bool isSaved = false;

                if (RD != null && RD.Id == 0)
                    isSaved = RDInfo.Add(RD);
                else
                    isSaved = RDInfo.Update(RD);

                if (isSaved)
                {
                    MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillupRDInfo();
                    grpRD.Enabled = false;
                }
                else
                    MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                MessageBox.Show("Unable to save record." + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnRDCancel_Click(object sender, EventArgs e)
        {
            grpRD.Enabled = false;
        }
        #endregion

        #region "PPF"

        private void cmbPPFGoal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPPFGoal.Text != "")
                cmbPPFGoal.Tag = _goals.FirstOrDefault(i => i.Name == cmbPPFGoal.Text).Id;
            else
                cmbPPFGoal.Tag = "0";
        }

        private void fillupPPFInfo()
        {
            setPermission(grpPPFControls);
            fillPPFInvesterCombobox();
            fillPPFGoalsCombobox();
            PPFInfo PPFInfo = new PPFInfo();
            _dtPPF = PPFInfo.GetPPFInfo(_planeId);
            dtGridPPF.DataSource = _dtPPF;
            PPFInfo.SetGrid(dtGridPPF);
        }

        private void fillPPFGoalsCombobox()
        {
            cmbPPFGoal.Items.Clear();
            _goals = new GoalsInfo().GetAll(_planeId);
            foreach (var goal in _goals)
            {
                cmbPPFGoal.Items.Add(goal.Name);
            }
            cmbPPFGoal.Items.Add("");
        }

        private void fillPPFInvesterCombobox()
        {
            new PlannerInfo.FamilyMemberInfo().FillFamilyMemberInCombo(this._client.ID, cmbPPFInvestor);
        }

        private void dtGridPPF_SelectionChanged(object sender, EventArgs e)
        {
            DataRow dr = getSelectedDataRow(dtGridPPF, _dtPPF);
            if (dr != null)
                displayPPFInfo(dr);
            else
                setDefaultValuePPF();
        }

        private void setDefaultValuePPF()
        {
            cmbPPFInvestor.Tag = "0";
            cmbPPFInvestor.Text = "";
            cmbPPFAccountNo.Text = "";
            cmbPPFGoal.Tag = "0";
            cmbPPFGoal.Text = "";
            txtPPFBankName.Text = "";
            txtPPFBranch.Text = "";
            txtPPFCurrentValue.Text = "";
            txtPPF_ROI.Text = "0";
            chkPPFAccountExtended.Checked = false;
        }

        private void displayPPFInfo(DataRow dr)
        {
            if (dr != null)
            {
                cmbPPFInvestor.Tag = dr.Field<string>("ID");
                cmbPPFInvestor.Text = dr.Field<string>("InvesterName");
                txtPPFBankName.Text = dr.Field<string>("Bank");
                cmbPPFAccountNo.Text = dr.Field<string>("AccountNo");
                txtPPFCurrentValue.Text = dr.Field<string>("CurrentValue");
                dtPPFOpeningDate.Text = dr.Field<string>("OpeningDate");
                dtMaturityDate.Text = dr.Field<string>("MaturityDate");
                if (dr["GoalID"] != null)
                {
                    cmbPPFGoal.Tag = dr["GoalId"].ToString();
                    cmbPPFGoal.Text = getGoalName(int.Parse(cmbPPFGoal.Tag.ToString()));
                }
                else
                {
                    cmbPPFGoal.Tag = "0";
                    cmbPPFGoal.Text = "";
                }
                txtPPF_ROI.Text = dr.Field<string>("InvestmentReturnRate");
                chkPPFAccountExtended.Checked  = dr["IsAccountExtended"] == null ? false : bool.Parse(dr.Field<string>("IsAccountExtended"));

            }
        }

        private void btnPPFAdd_Click(object sender, EventArgs e)
        {
            grpPPF.Enabled = true;
            setDefaultValuePPF();
        }

        private void btnPPFEdit_Click(object sender, EventArgs e)
        {
            grpPPF.Enabled = true;
        }

        private void btnPPFDelete_Click(object sender, EventArgs e)
        {
            if (dtGridPPF.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure, you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    PPFInfo PPFInfo = new PPFInfo();
                    PPF PPF = getPPFData();
                    PPFInfo.Delete(PPF);
                    fillupPPFInfo();
                }
            }
        }

        private PPF getPPFData()
        {
            PPF PPF = new PPF();
            PPF.Id = int.Parse(cmbPPFInvestor.Tag.ToString());
            PPF.Pid = _planeId;
            PPF.InvesterName = cmbPPFInvestor.Text;
            PPF.AccountNo = cmbPPFAccountNo.Text;
            PPF.Bank = txtPPFBankName.Text;
            PPF.OpeningDate = dtPPFOpeningDate.Value;
            PPF.MaturityDate = dtPPFMaturityDate.Value;
            PPF.CurrentValue = (string.IsNullOrEmpty(txtPPFCurrentValue.Text) ? 0 : double.Parse(txtPPFCurrentValue.Text));
            PPF.GoalId = int.Parse(cmbPPFGoal.Tag.ToString());
            PPF.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            PPF.CreatedBy = Program.CurrentUser.Id;
            PPF.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            PPF.UpdatedBy = Program.CurrentUser.Id;
            PPF.MachineName = Environment.MachineName;
            PPF.InvestmentReturnRate = (string.IsNullOrEmpty(txtPPF_ROI.Text) ? 0 : float.Parse(txtPPF_ROI.Text));
            PPF.IsAccountExtended = chkPPFAccountExtended.Checked;
            return PPF;
        }

        private void btnPPFSave_Click(object sender, EventArgs e)
        {
            try
            {
                PPFInfo PPFInfo = new PPFInfo();
                PPF PPF = getPPFData();
                bool isSaved = false;

                if (PPF != null && PPF.Id == 0)
                    isSaved = PPFInfo.Add(PPF);
                else
                    isSaved = PPFInfo.Update(PPF);

                if (isSaved)
                {
                    MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillupPPFInfo();
                    grpPPF.Enabled = false;
                }
                else
                    MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                MessageBox.Show("Unable to save record." + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPPFCancel_Click(object sender, EventArgs e)
        {
            grpPPF.Enabled = false;
        }
        #endregion

        #region "Sukanya Samrudhi"

        private void cmbSSGoal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSSGoal.Text != "")
                cmbSSGoal.Tag = _goals.FirstOrDefault(i => i.Name == cmbSSGoal.Text).Id;
            else
                cmbSSGoal.Tag = "0";
        }

        private void fillupSSInfo()
        {
            setPermission(grpSSControls);
            fillSSInvesterCombobox();
            fillSSGoalsCombobox();
            SukanyaSamrudhiInfo SSInfo = new SukanyaSamrudhiInfo();
            _dtSS = SSInfo.GetSukanyaSamrudhiInfo(_planeId);
            dtGridSS.DataSource = _dtSS;
            SSInfo.SetGrid(dtGridSS);
        }

        private void fillSSGoalsCombobox()
        {
            cmbSSGoal.Items.Clear();
            _goals = new GoalsInfo().GetAll(_planeId);
            foreach (var goal in _goals)
            {
                cmbSSGoal.Items.Add(goal.Name);
            }
            cmbSSGoal.Items.Add("");
        }

        private void fillSSInvesterCombobox()
        {
            new PlannerInfo.FamilyMemberInfo().FillFamilyMemberInCombo(this._client.ID, cmbSSInvestor);
        }

        private void dtGridSS_SelectionChanged(object sender, EventArgs e)
        {
            DataRow dr = getSelectedDataRow(dtGridSS, _dtSS);
            if (dr != null)
                displaySSInfo(dr);
            else
                setDefaultValueSS();
        }

        private void setDefaultValueSS()
        {
            cmbSSInvestor.Tag = "0";
            cmbSSInvestor.Text = "";
            cmbSSAccountNo.Text = "";
            cmbSSGoal.Tag = "0";
            cmbSSGoal.Text = "";
            txtSSBankName.Text = "";
            txtSSCurrentValue.Text = "";
            txtSSROI.Text = "0";
        }

        private void displaySSInfo(DataRow dr)
        {
            if (dr != null)
            {
                cmbSSInvestor.Tag = dr.Field<string>("ID");
                cmbSSInvestor.Text = dr.Field<string>("InvesterName");
                txtSSBankName.Text = dr.Field<string>("Bank");
                cmbSSAccountNo.Text = dr.Field<string>("AccountNo");
                txtSSCurrentValue.Text = dr.Field<string>("CurrentValue");
                dtSSOpeningDate.Text = dr.Field<string>("OpeningDate");
                dtMaturityDate.Text = dr.Field<string>("MaturityDate");
                if (dr["GoalID"] != null)
                {
                    cmbSSGoal.Tag = dr["GoalId"].ToString();
                    cmbSSGoal.Text = getGoalName(int.Parse(cmbSSGoal.Tag.ToString()));
                }
                else
                {
                    cmbSSGoal.Tag = "0";
                    cmbSSGoal.Text = "";
                }
                txtSSROI.Text = dr.Field<string>("InvestmentReturnRate");
            }
        }

        private void btnSSAdd_Click(object sender, EventArgs e)
        {
            grpSS.Enabled = true;
            setDefaultValueSS();
        }

        private void btnSSEdit_Click(object sender, EventArgs e)
        {
            grpSS.Enabled = true;
        }

        private void btnSSDelete_Click(object sender, EventArgs e)
        {
            if (dtGridSS.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure, you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SukanyaSamrudhiInfo SSInfo = new SukanyaSamrudhiInfo();
                    SukanyaSamrudhi SS = getSSData();
                    SSInfo.Delete(SS);
                    fillupSSInfo();
                }
            }
        }

        private SukanyaSamrudhi getSSData()
        {
            SukanyaSamrudhi SS = new SukanyaSamrudhi();
            SS.Id = int.Parse(cmbSSInvestor.Tag.ToString());
            SS.Pid = _planeId;
            SS.InvesterName = cmbSSInvestor.Text;
            SS.AccountNo = cmbSSAccountNo.Text;
            SS.Bank = txtSSBankName.Text;
            SS.OpeningDate = dtSSOpeningDate.Value;
            SS.MaturityDate = dtSSMaturityDate.Value;
            SS.CurrentValue = (string.IsNullOrEmpty(txtSSCurrentValue.Text) ? 0 : double.Parse(txtSSCurrentValue.Text));
            SS.GoalId = int.Parse(cmbSSGoal.Tag.ToString());
            SS.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            SS.CreatedBy = Program.CurrentUser.Id;
            SS.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            SS.UpdatedBy = Program.CurrentUser.Id;
            SS.MachineName = Environment.MachineName;
            SS.InvestmentReturnRate = (string.IsNullOrEmpty(txtSSROI.Text) ? 0 : float.Parse(txtSSROI.Text));
            return SS;
        }

        private void btnSSSave_Click(object sender, EventArgs e)
        {
            try
            {
                SukanyaSamrudhiInfo SSInfo = new SukanyaSamrudhiInfo();
                SukanyaSamrudhi SS = getSSData();
                bool isSaved = false;

                if (SS != null && SS.Id == 0)
                    isSaved = SSInfo.Add(SS);
                else
                    isSaved = SSInfo.Update(SS);

                if (isSaved)
                {
                    MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillupSSInfo();
                    grpSS.Enabled = false;
                }
                else
                    MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                MessageBox.Show("Unable to save record." + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSSCancel_Click(object sender, EventArgs e)
        {
            grpSS.Enabled = false;
        }
        #endregion

        #region "SCSS"

        private void cmbSCSSGoal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSCSSGoal.Text != "")
                cmbSCSSGoal.Tag = _goals.FirstOrDefault(i => i.Name == cmbSCSSGoal.Text).Id;
            else
                cmbSCSSGoal.Tag = "0";
        }

        private void fillupSCSSInfo()
        {
            setPermission(grpSCSSControls);
            fillSCSSInvesterCombobox();
            fillSCSSGoalsCombobox();
            SCSSInfo SCSSInfo = new SCSSInfo();
            _dtSCSS = SCSSInfo.GetSCSSInfo(_planeId);
            dtGridSCSS.DataSource = _dtSCSS;
            SCSSInfo.SetGrid(dtGridSCSS);
        }

        private void fillSCSSGoalsCombobox()
        {
            cmbSCSSGoal.Items.Clear();
            _goals = new GoalsInfo().GetAll(_planeId);
            foreach (var goal in _goals)
            {
                cmbSCSSGoal.Items.Add(goal.Name);
            }
            cmbSCSSGoal.Items.Add("");
        }

        private void fillSCSSInvesterCombobox()
        {
            new PlannerInfo.FamilyMemberInfo().FillFamilyMemberInCombo(this._client.ID, cmbSCSSInvestor);
        }

        private void dtGridSCSS_SelectionChanged(object sender, EventArgs e)
        {
            DataRow dr = getSelectedDataRow(dtGridSCSS, _dtSCSS);
            if (dr != null)
                displaySCSSInfo(dr);
            else
                setDefaultValueSCSS();
        }

        private void setDefaultValueSCSS()
        {
            cmbSCSSInvestor.Tag = "0";
            cmbSCSSInvestor.Text = "";
            cmbSCSSAccountNo.Text = "";
            cmbSCSSGoal.Tag = "0";
            cmbSCSSGoal.Text = "";
            txtSCSSBankName.Text = "";
            txtSCSSCurrentValue.Text = "";
            txtSCSSROI.Text = "0";
        }

        private void displaySCSSInfo(DataRow dr)
        {
            if (dr != null)
            {
                cmbSCSSInvestor.Tag = dr.Field<string>("ID");
                cmbSCSSInvestor.Text = dr.Field<string>("InvesterName");
                txtSCSSBankName.Text = dr.Field<string>("Bank");
                cmbSCSSAccountNo.Text = dr.Field<string>("AccountNo");
                txtSCSSCurrentValue.Text = dr.Field<string>("CurrentValue");
                dtSCSSOpeningDate.Text = dr.Field<string>("OpeningDate");
                dtMaturityDate.Text = dr.Field<string>("MaturityDate");
                if (dr["GoalID"] != null)
                {
                    cmbSCSSGoal.Tag = dr["GoalId"].ToString();
                    cmbSCSSGoal.Text = getGoalName(int.Parse(cmbSCSSGoal.Tag.ToString()));
                }
                else
                {
                    cmbSCSSGoal.Tag = "0";
                    cmbSCSSGoal.Text = "";
                }
                txtSCSSROI.Text = dr.Field<string>("InvestmentReturnRate");
            }
        }

        private void btnSCSSAdd_Click(object sender, EventArgs e)
        {
            grpSCSS.Enabled = true;
            setDefaultValueSCSS();
        }

        private void btnSCSSEdit_Click(object sender, EventArgs e)
        {
            grpSCSS.Enabled = true;
        }

        private void btnSCSSDelete_Click(object sender, EventArgs e)
        {
            if (dtGridSCSS.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure, you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SCSSInfo SCSSInfo = new SCSSInfo();
                    SCSS SCSS = getSCSSData();
                    SCSSInfo.Delete(SCSS);
                    fillupSCSSInfo();
                }
            }
        }

        private SCSS getSCSSData()
        {
            SCSS SCSS = new SCSS();
            SCSS.Id = int.Parse(cmbSCSSInvestor.Tag.ToString());
            SCSS.Pid = _planeId;
            SCSS.InvesterName = cmbSCSSInvestor.Text;
            SCSS.AccountNo = cmbSCSSAccountNo.Text;
            SCSS.Bank = txtSCSSBankName.Text;
            SCSS.OpeningDate = dtSCSSOpeningDate.Value;
            SCSS.MaturityDate = dtSCSSMaturityDate.Value;
            SCSS.CurrentValue = (string.IsNullOrEmpty(txtSCSSCurrentValue.Text) ? 0 : double.Parse(txtSCSSCurrentValue.Text));
            SCSS.GoalId = int.Parse(cmbSCSSGoal.Tag.ToString());
            SCSS.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            SCSS.CreatedBy = Program.CurrentUser.Id;
            SCSS.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            SCSS.UpdatedBy = Program.CurrentUser.Id;
            SCSS.MachineName = Environment.MachineName;
            SCSS.InvestmentReturnRate = (string.IsNullOrEmpty(txtSCSSROI.Text) ? 0 : float.Parse(txtSCSSROI.Text));
            return SCSS;
        }

        private void btnSCSSSave_Click(object sender, EventArgs e)
        {
            try
            {
                SCSSInfo SCSSInfo = new SCSSInfo();
                SCSS SCSS = getSCSSData();
                bool isSaved = false;

                if (SCSS != null && SCSS.Id == 0)
                    isSaved = SCSSInfo.Add(SCSS);
                else
                    isSaved = SCSSInfo.Update(SCSS);

                if (isSaved)
                {
                    MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillupSCSSInfo();
                    grpSCSS.Enabled = false;
                }
                else
                    MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                MessageBox.Show("Unable to save record." + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSCSSCancel_Click(object sender, EventArgs e)
        {
            grpSCSS.Enabled = false;
        }
        #endregion

        #region "NSC"

        private void cmbNSCGoal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNSCGoal.Text != "")
                cmbNSCGoal.Tag = _goals.FirstOrDefault(i => i.Name == cmbNSCGoal.Text).Id;
            else
                cmbNSCGoal.Tag = "0";
        }

        private void fillupNSCInfo()
        {
            setPermission(grpNSCControls);
            fillNSCInvesterCombobox();
            fillNSCGoalsCombobox();
            NSCInfo NSCInfo = new NSCInfo();
            _dtNSC = NSCInfo.GetNSCInfo(_planeId);
            dtGridNSC.DataSource = _dtNSC;
            NSCInfo.SetGrid(dtGridNSC);
        }

        private void fillNSCGoalsCombobox()
        {
            cmbNSCGoal.Items.Clear();
            _goals = new GoalsInfo().GetAll(_planeId);
            foreach (var goal in _goals)
            {
                cmbNSCGoal.Items.Add(goal.Name);
            }
            cmbNSCGoal.Items.Add("");
        }

        private void fillNSCInvesterCombobox()
        {
            new PlannerInfo.FamilyMemberInfo().FillFamilyMemberInCombo(this._client.ID, cmbNSCInvestor);
        }

        private void dtGridNSC_SelectionChanged(object sender, EventArgs e)
        {
            DataRow dr = getSelectedDataRow(dtGridNSC, _dtNSC);
            if (dr != null)
                displayNSCInfo(dr);
            else
                setDefaultValueNSC();
        }

        private void setDefaultValueNSC()
        {
            cmbNSCInvestor.Tag = "0";
            cmbNSCInvestor.Text = "";
            cmbNSCDocumentNo.Text = "";
            cmbNSCGoal.Tag = "0";
            cmbNSCGoal.Text = "";
            txtNSCPostOffice.Text = "";
            txtNSCRate.Text = "0";
            txtNSCUnits.Text = "0";
            txtNSCValueOfOne.Text = "0";
            txtNSCCurrentValue.Text = "";
            txtNSC_ROI.Text = "0";
        }

        private void displayNSCInfo(DataRow dr)
        {
            if (dr != null)
            {
                cmbNSCInvestor.Tag = dr.Field<string>("ID");
                cmbNSCInvestor.Text = dr.Field<string>("InvesterName");
                txtNSCPostOffice.Text = dr.Field<string>("PostOfficeBranch");
                cmbNSCDocumentNo.Text = dr.Field<string>("DocumentNo");
                txtNSCCurrentValue.Text = dr.Field<string>("CurrentValue");
                txtNSCRate.Text = dr.Field<string>("Rate");
                txtNSCUnits.Text = dr.Field<string>("Units");
                txtNSCValueOfOne.Text = dr.Field<string>("ValueOfOne");
                calculateAndSetNSCCurrentValue();
                dtMaturityDate.Text = dr.Field<string>("MaturityDate");
                if (dr["GoalID"] != null)
                {
                    cmbNSCGoal.Tag = dr["GoalId"].ToString();
                    cmbNSCGoal.Text = getGoalName(int.Parse(cmbNSCGoal.Tag.ToString()));
                }
                else
                {
                    cmbNSCGoal.Tag = "0";
                    cmbNSCGoal.Text = "";
                }
                txtNSC_ROI.Text = dr.Field<string>("InvestmentReturnRate");
            }
        }

        private void btnNSCAdd_Click(object sender, EventArgs e)
        {
            grpNSC.Enabled = true;
            setDefaultValueNSC();
        }

        private void btnNSCEdit_Click(object sender, EventArgs e)
        {
            grpNSC.Enabled = true;
        }

        private void btnNSCDelete_Click(object sender, EventArgs e)
        {
            if (dtGridNSC.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure, you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    NSCInfo NSCInfo = new NSCInfo();
                    NSC NSC = getNSCData();
                    NSCInfo.Delete(NSC);
                    fillupNSCInfo();
                }
            }
        }

        private NSC getNSCData()
        {
            NSC NSC = new NSC();
            NSC.Id = int.Parse(cmbNSCInvestor.Tag.ToString());
            NSC.Pid = _planeId;
            NSC.InvesterName = cmbNSCInvestor.Text;
            NSC.DocumentNo = cmbNSCDocumentNo.Text;
            NSC.PostOfficeBranch = txtNSCPostOffice.Text;
            NSC.MaturityDate = dtNSCMaturityDate.Value;
            NSC.Rate = (string.IsNullOrEmpty(txtNSCRate.Text) ? 0 : float.Parse(txtNSCRate.Text));
            NSC.Units = (string.IsNullOrEmpty(txtNSCUnits.Text) ? 0 : int.Parse(txtNSCUnits.Text));
            NSC.CurrentValue = (string.IsNullOrEmpty(txtNSCCurrentValue.Text) ? 0 : double.Parse(txtNSCCurrentValue.Text));
            NSC.ValueOfOne = (string.IsNullOrEmpty(txtNSCValueOfOne.Text) ? 0 : float.Parse(txtNSCValueOfOne.Text));
            NSC.GoalId = int.Parse(cmbNSCGoal.Tag.ToString());
            NSC.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            NSC.CreatedBy = Program.CurrentUser.Id;
            NSC.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            NSC.UpdatedBy = Program.CurrentUser.Id;
            NSC.MachineName = Environment.MachineName;
            NSC.InvestmentReturnRate = (string.IsNullOrEmpty(txtNSC_ROI.Text) ? 0 : float.Parse(txtNSC_ROI.Text));
            return NSC;
        }

        private void btnNSCSave_Click(object sender, EventArgs e)
        {
            try
            {
                NSCInfo NSCInfo = new NSCInfo();
                NSC NSC = getNSCData();
                bool isSaved = false;

                if (NSC != null && NSC.Id == 0)
                    isSaved = NSCInfo.Add(NSC);
                else
                    isSaved = NSCInfo.Update(NSC);

                if (isSaved)
                {
                    MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillupNSCInfo();
                    grpNSC.Enabled = false;
                }
                else
                    MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                MessageBox.Show("Unable to save record." + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnNSCCancel_Click(object sender, EventArgs e)
        {
            grpNSC.Enabled = false;
        }
        private void calculateAndSetNSCCurrentValue()
        {
            float nav = 0;
            double units = 0;
            float.TryParse(txtNSCRate.Text, out nav);
            double.TryParse(txtNSCUnits.Text, out units);
            txtNSCCurrentValue.Text = (nav * units).ToString();
        }

        private void txtNSCRate_Leave(object sender, EventArgs e)
        {
            calculateAndSetNSCCurrentValue();
        }

        private void txtNSCUnits_Leave(object sender, EventArgs e)
        {
            calculateAndSetNSCCurrentValue();
        }

        private void txtNSCRate_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtNSCUnits_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        #endregion

        #region "Mutual Fund"
        private void fillupMutualFundInfo()
        {
            setPermission(grpMFControls);
            //setPermissionForMutualFund();
            fillMutualFundInvesterCombobox();
            fillMutualfundGolsCombobox();
            MutualFundInfo mutualFundInfo = new MutualFundInfo();
            _dtMutualFund = mutualFundInfo.GetMutualFundInfo(_planeId);
            dtGridMF.DataSource = _dtMutualFund;
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
                txtMFFirstHolder.Text = dr["FirstHolder"].ToString();
                txtMFSecondHolder.Text = dr["SecondHolder"].ToString();
                txtMFNominee.Text = dr["Nominee"].ToString();
                txtMFInvestmentReturnRate.Text = dr["InvestmentReturnRate"].ToString();
                txtMFCurrentVal.Text = dr["CurrentValue"].ToString();
            }
        }

        private DataRow getSelectedDataRowForMutualFund()
        {
            if (dtGridMF.SelectedRows.Count >= 1)
            {
                int selectedRowIndex = dtGridMF.SelectedRows[0].Index;
                if (dtGridMF.SelectedRows[0].Cells["ID"].Value != System.DBNull.Value)
                {
                    int selectedUserId = int.Parse(dtGridMF.SelectedRows[0].Cells["ID"].Value.ToString());
                    DataRow[] rows = _dtMutualFund.Select("Id ='" + selectedUserId + "'");
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
            txtNav.Text = "0";
            txtUnits.Text = "0";
            txtMFCurrentVal.Text = "0";
            txtMFEquityRatio.Text = "0";
            txtMFGoldRatio.Text = "0";
            txtMFDebtRatio.Text = "0";
            txtFreeUnits.Text = "0";
            txtRedumptionAmt.Text = "";
            cmbMFGoal.Text = "";
            cmbMFGoal.Tag = "0";
            txtMFFirstHolder.Text = "";
            txtMFSecondHolder.Text = "";
            txtMFNominee.Text = "";
            txtMFInvestmentReturnRate.Text = "0";
        }

        private void txtNav_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
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
            if (nav > 0 && units > 0)
                txtMFCurrentVal.Text = (nav * units).ToString();
        }

        private void btnCancelMF_Click(object sender, EventArgs e)
        {
            grpMF.Enabled = false;
        }

        private void btnSaveMF_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                MessageBox.Show("Unable to save record." + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            mf.Units = double.Parse(txtUnits.Text);
            mf.EquityRatio = float.Parse(txtMFEquityRatio.Text);
            mf.GoldRatio = float.Parse(txtMFGoldRatio.Text);
            mf.DebtRatio = float.Parse(txtMFDebtRatio.Text);
            mf.FreeUnit = int.Parse(txtFreeUnits.Text);
            double redumptionAmt = 0;
            mf.RedumptionAmount = double.TryParse(txtRedumptionAmt.Text, out redumptionAmt) ? redumptionAmt : 0;
            mf.GoalID = int.Parse(cmbMFGoal.Tag.ToString());
            mf.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            mf.CreatedBy = Program.CurrentUser.Id;
            mf.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            mf.UpdatedBy = Program.CurrentUser.Id;
            mf.MachineName = Environment.MachineName;
            mf.FirstHolder = txtMFFirstHolder.Text;
            mf.SecondHolder = txtMFSecondHolder.Text;
            mf.Nominee = txtMFNominee.Text;
            mf.InvestmentReturnRate = string.IsNullOrEmpty(txtMFInvestmentReturnRate.Text) ? 0 : float.Parse(txtMFInvestmentReturnRate.Text);
            mf.CurrentValue = double.Parse(txtMFCurrentVal.Text);
            return mf;
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
                    MutualFund mutualFund = getMutualFundData();
                    mutualFundInfo.Delete(mutualFund);
                    fillupMutualFundInfo();
                }
            }
        }

        private void btnMFViewDetails_Click(object sender, EventArgs e)
        {
            MutualFund mf = getMutualFundData();
            if (cmbMFInvester.Tag.ToString() != "0")
            {
                MFTransactionsForm mfTrans = new MFTransactionsForm(mf);
                mfTrans.ShowDialog();
            }
        }
        #endregion

        #region "ULIP"
        private void fillupULIPInfo()
        {
            setPermission(grpULIPControls);
            fillULIPInvesterCombobox();
            fillULIPGolsCombobox();
            ULIPInfo ULIPInfo = new ULIPInfo();
            _dtULIP = ULIPInfo.GetULIPInfo(_planeId);
            dtGridULIP.DataSource = _dtULIP;
        }

        private void fillULIPInvesterCombobox()
        {
            new PlannerInfo.FamilyMemberInfo().FillFamilyMemberInCombo(this._client.ID, cmbULIPInvestor);
        }
        private void fillULIPGolsCombobox()
        {
            cmbULIPGoal.Items.Clear();
            _goals = new GoalsInfo().GetAll(_planeId);
            foreach (var goal in _goals)
            {
                cmbULIPGoal.Items.Add(goal.Name);
            }
            cmbULIPGoal.Items.Add("");
        }

        private void dtGridULIP_SelectionChanged(object sender, EventArgs e)
        {
            DataRow dr = getSelectedDataRowForULIP();
            if (dr != null)
                displayULIPInfo(dr);
            else
                setDefaultValueULIP();
        }

        private void displayULIPInfo(DataRow dr)
        {
            if (dr != null)
            {
                cmbULIPInvestor.Tag = dr.Field<string>("ID");
                cmbULIPInvestor.Text = dr.Field<string>("InvesterName");
                cmbULIPScheme.Text = dr.Field<string>("SchemeName");
                txtULIPFolioNo.Text = dr.Field<string>("FolioNo");
                txtULIPNav.Text = dr["NAV"].ToString();
                txtULIPUnits.Text = dr["units"].ToString();
                calculateAndSetULIPCurrentValue();
                txtULIPEquityRatio.Text = dr["EquityRatio"].ToString();
                txtULIPGoldRatio.Text = dr["GoldRatio"].ToString();
                txtULIPDebtRatio.Text = dr["DebtRatio"].ToString();
                txtULIPSIPAmt.Text = dr["SIP"].ToString();
                txtULIPFreeUnits.Text = dr["FreeUnit"].ToString();
                txtULIPRedemptionAmt.Text = dr["RedumptionAmount"].ToString();
                if (dr["GoalID"] != null)
                {
                    cmbULIPGoal.Tag = dr["GoalId"].ToString();
                    cmbULIPGoal.Text = getGoalName(int.Parse(cmbULIPGoal.Tag.ToString()));
                }
                else
                {
                    cmbULIPGoal.Tag = "0";
                    cmbULIPGoal.Text = "";
                }
                txtULIPFirstHolder.Text = dr["FirstHolder"].ToString();
                txtULIPSecondHolder.Text = dr["SecondHolder"].ToString();
                txtULIPNominee.Text = dr["Nominee"].ToString();
                txtULIP_ROI.Text = dr["InvestmentReturnRate"].ToString();
            }
        }

        private DataRow getSelectedDataRowForULIP()
        {
            if (dtGridULIP.SelectedRows.Count >= 1)
            {
                int selectedRowIndex = dtGridULIP.SelectedRows[0].Index;
                if (dtGridULIP.SelectedRows[0].Cells["ID"].Value != System.DBNull.Value)
                {
                    int selectedUserId = int.Parse(dtGridULIP.SelectedRows[0].Cells["ID"].Value.ToString());
                    DataRow[] rows = _dtULIP.Select("Id ='" + selectedUserId + "'");
                    foreach (DataRow dr in rows)
                    {
                        return dr;
                    }
                }
            }
            return null;
        }

        private void btnAddULIP_Click(object sender, EventArgs e)
        {
            grpULIP.Enabled = true;
            setDefaultValueULIP();
        }

        private void setDefaultValueULIP()
        {
            cmbULIPInvestor.Tag = "0";
            cmbULIPInvestor.Text = "";
            cmbULIPScheme.Text = "";
            txtULIPFolioNo.Text = "";
            txtULIPNav.Text = "";
            txtULIPUnits.Text = "";
            txtULIPCurrentValue.Text = "0";
            txtULIPEquityRatio.Text = "0";
            txtULIPGoldRatio.Text = "0";
            txtULIPDebtRatio.Text = "0";
            txtULIPFreeUnits.Text = "0";
            txtULIPRedemptionAmt.Text = "";
            cmbULIPGoal.Text = "";
            cmbULIPGoal.Tag = "0";
            txtULIPFirstHolder.Text = "";
            txtULIPSecondHolder.Text = "";
            txtULIPNominee.Text = "";
            txtULIP_ROI.Text = "0";
        }

        private void txtULIPNav_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void txtULIPNav_Leave(object sender, EventArgs e)
        {
            calculateAndSetULIPCurrentValue();
        }
        private void calculateAndSetULIPCurrentValue()
        {
            float nav = 0;
            double units = 0;
            float.TryParse(txtULIPNav.Text, out nav);
            double.TryParse(txtULIPUnits.Text, out units);
            txtULIPCurrentValue.Text = (nav * units).ToString();
        }

        private void btnCancelULIP_Click(object sender, EventArgs e)
        {
            grpULIP.Enabled = false;
        }

        private void btnSaveULIP_Click(object sender, EventArgs e)
        {
            try
            {
                ULIPInfo ULIPInfo = new ULIPInfo();
                ULIP ULIP = getULIPData();
                bool isSaved = false;

                if (ULIP != null && ULIP.Id == 0)
                    isSaved = ULIPInfo.Add(ULIP);
                else
                    isSaved = ULIPInfo.Update(ULIP);

                if (isSaved)
                {
                    MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillupULIPInfo();
                    grpULIP.Enabled = false;
                }
                else
                    MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                MessageBox.Show("Unable to save record." + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private ULIP getULIPData()
        {
            ULIP ULIP = new ULIP();
            ULIP.Id = int.Parse(cmbULIPInvestor.Tag.ToString());
            ULIP.Pid = _planeId;
            ULIP.InvesterName = cmbULIPInvestor.Text;
            ULIP.SchemeName = cmbULIPScheme.Text;
            ULIP.FolioNo = txtULIPFolioNo.Text;
            ULIP.Nav = (string.IsNullOrEmpty(txtULIPNav.Text) ? 0 : float.Parse(txtULIPNav.Text));
            ULIP.Units = (string.IsNullOrEmpty(txtULIPUnits.Text) ? 0 : int.Parse(txtULIPUnits.Text));
            ULIP.EquityRatio = (string.IsNullOrEmpty(txtULIPEquityRatio.Text) ? 0 : float.Parse(txtULIPEquityRatio.Text));
            ULIP.GoldRatio = (string.IsNullOrEmpty(txtULIPGoldRatio.Text) ? 0 : float.Parse(txtULIPGoldRatio.Text));
            ULIP.DebtRatio = (string.IsNullOrEmpty(txtULIPDebtRatio.Text) ? 0 : float.Parse(txtULIPDebtRatio.Text));
            ULIP.FreeUnit = (string.IsNullOrEmpty(txtULIPFreeUnits.Text) ? 0 : int.Parse(txtULIPFreeUnits.Text));
            ULIP.RedumptionAmount = (string.IsNullOrEmpty(txtULIPRedemptionAmt.Text) ? 0 : double.Parse(txtULIPRedemptionAmt.Text));
            ULIP.GoalID = int.Parse(cmbULIPGoal.Tag.ToString());
            ULIP.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            ULIP.CreatedBy = Program.CurrentUser.Id;
            ULIP.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            ULIP.UpdatedBy = Program.CurrentUser.Id;
            ULIP.MachineName = Environment.MachineName;
            ULIP.FirstHolder = txtULIPFirstHolder.Text;
            ULIP.SecondHolder = txtULIPSecondHolder.Text;
            ULIP.Nominee = txtULIPNominee.Text;
            ULIP.InvestmentReturnRate = (string.IsNullOrEmpty(txtULIP_ROI.Text) ? 0 : float.Parse(txtULIP_ROI.Text));
            return ULIP;
        }

        private void cmbULIPGoal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbULIPGoal.Text != "")
                cmbULIPGoal.Tag = _goals.FirstOrDefault(i => i.Name == cmbULIPGoal.Text).Id;
            else
                cmbULIPGoal.Tag = "0";
        }

        private void btnEditULIP_Click(object sender, EventArgs e)
        {
            if (dtGridULIP.SelectedRows.Count > 0)
                grpULIP.Enabled = true;
        }

        private void btnDeleteULIP_Click(object sender, EventArgs e)
        {
            if (dtGridULIP.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure, you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ULIPInfo ULIPInfo = new ULIPInfo();
                    ULIP ULIP = getULIPData();
                    ULIPInfo.Delete(ULIP);
                    fillupULIPInfo();
                }
            }
        }
        #endregion

        #region "Shares"

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
        private void fillupSharesInfo()
        {
            setPermission(grpSharesControl);
            fillSharesInvesterCombobox();
            fillSharesGolsCombobox();
            SharesInfo sharesInfo = new SharesInfo();
            _dtShares = sharesInfo.GetSharesInfo(_planeId);
            dtGridShares.DataSource = _dtShares;
        }

        private void setPermission(Control control)
        {
            if (Program.CurrentUserRolePermission.Name == "Admin")
                return;

            List<RolePermission> rolePermission = (List<RolePermission>)Program.CurrentUserRolePermission.Permissions;
            RolePermission permission = rolePermission.Find(x => x.FormName == "Current Status");

            foreach (Control singleControl in control.Controls)
            {
                if (permission == null)
                    singleControl.Visible = false;
                else
                {
                    if (singleControl.Name.Contains("Add"))
                        singleControl.Visible = permission.IsAdd;

                    if (singleControl.Name.Contains("Edit"))
                        singleControl.Visible = permission.IsUpdate;

                    if (singleControl.Name.Contains("Delete"))
                        singleControl.Visible = permission.IsDelete;
                }
            }

        }

        private void fillSharesInvesterCombobox()
        {
            new PlannerInfo.FamilyMemberInfo().FillFamilyMemberInCombo(this._client.ID, cmbSharesInvester);
        }

        private void calculateAndSetSharesCurrentValue()
        {
            float nav = 0;
            double units = 0;
            float.TryParse(txtSharesMarketPrice.Text, out nav);
            double.TryParse(txtNoOfShares.Text, out units);
            txtSharesCurrentValue.Text = (nav * units).ToString();
        }

        private DataRow getSelectedDataRowForShares()
        {
            if (dtGridShares.SelectedRows.Count >= 1 && _dtShares != null)
            {
                int selectedRowIndex = dtGridShares.SelectedRows[0].Index;
                if (dtGridShares.SelectedRows[0].Cells["ID"].Value != System.DBNull.Value)
                {
                    int selectedUserId = int.Parse(dtGridShares.SelectedRows[0].Cells["ID"].Value.ToString());

                    DataRow[] rows = _dtShares.Select("Id ='" + selectedUserId + "'");
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
            //calculateAndSetSharesCurrentValue();
            cmbSharesGoal.Tag = "0";
            cmbSharesGoal.Text = "";
            txtSharesFirstHolder.Text = "";
            txtSharesSecondHolder.Text = "";
            txtSharesNominee.Text = "";
            txtSharesInvestmentReturnRate.Text = "0";
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
                //calculateAndSetSharesCurrentValue();
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
                txtSharesFirstHolder.Text = dr["FirstHolder"].ToString();
                txtSharesSecondHolder.Text = dr["SecondHolder"].ToString();
                txtSharesNominee.Text = dr["Nominee"].ToString();
                txtSharesInvestmentReturnRate.Text = dr["InvestmentReturnRate"].ToString();
            }
        }

        private void btnSharesSave_Click(object sender, EventArgs e)
        {
            try
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
                    grpShares.Enabled = false;
                }
                else
                    MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                MessageBox.Show("Unable to save record." + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Shares getSharesData()
        {
            Shares shares = new Shares();
            shares.Id = int.Parse(cmbSharesInvester.Tag.ToString());
            shares.Pid = _planeId;
            shares.InvesterName = cmbSharesInvester.Text;
            shares.CompanyName = cmbSharesCompnay.Text;
            shares.FaceValue = (string.IsNullOrEmpty(txtSharesFaceValue.Text) ? 0 : float.Parse(txtSharesFaceValue.Text));
            shares.NoOfShares = (string.IsNullOrEmpty(txtNoOfShares.Text) ? 0 : int.Parse(txtNoOfShares.Text));
            shares.MarketPrice = (string.IsNullOrEmpty(txtSharesMarketPrice.Text) ? 0 : float.Parse(txtSharesMarketPrice.Text));
            shares.CurrentValue = (string.IsNullOrEmpty(txtSharesCurrentValue.Text) ? 0 : double.Parse(txtSharesCurrentValue.Text));
            shares.GoalID = int.Parse(cmbSharesGoal.Tag.ToString());
            shares.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            shares.CreatedBy = Program.CurrentUser.Id;
            shares.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            shares.UpdatedBy = Program.CurrentUser.Id;
            shares.MachineName = Environment.MachineName;
            shares.FirstHolder = txtSharesFirstHolder.Text;
            shares.SecondHolder = txtSharesSecondHolder.Text;
            shares.Nominee = txtSharesNominee.Text;
            shares.InvestmentReturnRate = (string.IsNullOrEmpty(txtSharesInvestmentReturnRate.Text) ? 0 :
                float.Parse(txtSharesInvestmentReturnRate.Text));
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
                    Shares Shares = getSharesData();
                    SharesInfo.Delete(Shares);
                    fillupSharesInfo();
                }
            }
        }

        private void btnSharesAdd_Click(object sender, EventArgs e)
        {
            grpShares.Enabled = true;
            setDefaultValueShares();
        }

        private void txtNoOfShares_Leave(object sender, EventArgs e)
        {
            calculateAndSetSharesCurrentValue();
        }

        private void txtSharesMarketPrice_Leave(object sender, EventArgs e)
        {
            calculateAndSetSharesCurrentValue();
        }

        private void txtSharesFaceValue_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void cmbSharesGoal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSharesGoal.Text != "")
                cmbSharesGoal.Tag = _goals.FirstOrDefault(i => i.Name == cmbSharesGoal.Text).Id;
            else
                cmbSharesGoal.Tag = "0";
        }

        #endregion

        #region "Saving Account"
        private void fillupSavingAccount()
        {
            setPermission(grpSavingACControls);
            fillSavingAccountInvesterCombobox();
            fillSavngAccountGoalsCombobox();
            SavingAccountInfo savingAccountInfo = new SavingAccountInfo();
            _dtSA = savingAccountInfo.GetSavingAccountInfo(_planeId);
            dtGridSavingAccount.DataSource = _dtSA;
            savingAccountInfo.SetGrid(dtGridSavingAccount);
        }

        private void fillSavngAccountGoalsCombobox()
        {
            cmbSAGoalId.Items.Clear();
            _goals = new GoalsInfo().GetAll(_planeId);
            foreach (var goal in _goals)
            {
                cmbSAGoalId.Items.Add(goal.Name);
            }
            cmbSAGoalId.Items.Add("");
        }

        private void fillSavingAccountInvesterCombobox()
        {
            new PlannerInfo.FamilyMemberInfo().FillFamilyMemberInCombo(this._client.ID, cmbSAInvester);
        }


        private void dtGridSavingAccount_SelectionChanged(object sender, EventArgs e)
        {
            DataRow dr = getSelectedDataRow(dtGridSavingAccount, _dtSA);
            if (dr != null)
                displaySAInfo(dr);
            else
                setDefaultValueSA();
        }

        private void setDefaultValueSA()
        {
            cmbSAInvester.Tag = "0";
            cmbSAInvester.Text = "";
            txtSABank.Text = "";
            cmbSAAccountNo.Text = "";
            txtSABranch.Text = "";
            txtSABalance.Text = "";
            txtSAROI.Text = "";
            cmbSAGoalId.Tag = "0";
            cmbSAGoalId.Text = "";
        }

        private void displaySAInfo(DataRow dr)
        {
            if (dr != null)
            {
                cmbSAInvester.Tag = dr.Field<string>("ID");
                cmbSAInvester.Text = dr.Field<string>("InvesterName");
                txtSABank.Text = dr.Field<string>("BankName");
                cmbSAAccountNo.Text = dr.Field<string>("AccountNo");
                txtSABranch.Text = dr.Field<string>("Branch");
                txtSABalance.Text = dr.Field<string>("Balance");
                txtSAROI.Text = dr.Field<string>("IntRate");
                if (dr["GoalID"] != null)
                {
                    cmbSAGoalId.Tag = dr["GoalId"].ToString();
                    cmbSAGoalId.Text = getGoalName(int.Parse(cmbSAGoalId.Tag.ToString()));
                }
                else
                {
                    cmbSAGoalId.Tag = "0";
                    cmbSAGoalId.Text = "";
                }
            }
        }

        private void btnAddSA_Click(object sender, EventArgs e)
        {
            grpSa.Enabled = true;
            setDefaultValueSA();
        }

        private void btnEditSA_Click(object sender, EventArgs e)
        {
            grpSa.Enabled = true;
        }

        private void btnCancelSA_Click(object sender, EventArgs e)
        {
            grpSa.Enabled = false;
        }

        private void btnDeleteSA_Click(object sender, EventArgs e)
        {
            if (dtGridSavingAccount.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure, you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SavingAccountInfo saInfo = new SavingAccountInfo();
                    SavingAccount sa = getSA();
                    saInfo.Delete(sa);
                    fillupSavingAccount();
                }
            }
        }

        private SavingAccount getSA()
        {
            SavingAccount sa = new SavingAccount();
            sa.Id = int.Parse(cmbSAInvester.Tag.ToString());
            sa.Pid = _planeId;
            sa.InvesterName = cmbSAInvester.Text;
            sa.BankName = txtSABank.Text;
            sa.AccountNo = cmbSAAccountNo.Text;
            sa.Branch = txtSABranch.Text;
            sa.Balance = (string.IsNullOrEmpty(txtSABalance.Text) ? 0 : double.Parse(txtSABalance.Text));
            sa.IntRate = (string.IsNullOrEmpty(txtSAROI.Text) ? 0 : float.Parse(txtSAROI.Text));
            sa.GoalId = int.Parse(cmbSAGoalId.Tag.ToString());
            sa.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            sa.CreatedBy = Program.CurrentUser.Id;
            sa.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            sa.UpdatedBy = Program.CurrentUser.Id;
            sa.MachineName = Environment.MachineName;
            return sa;
        }


        private void cmbSAGoalId_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbSAGoalId.Text != "")
                cmbSAGoalId.Tag = _goals.FirstOrDefault(i => i.Name == cmbSAGoalId.Text).Id;
            else
                cmbSAGoalId.Tag = "0";
        }

        private void btnSaveSA_Click(object sender, EventArgs e)
        {
            try
            {
                SavingAccountInfo SavingAccountInfo = new SavingAccountInfo();
                SavingAccount sa = getSA();
                bool isSaved = false;

                if (sa != null && sa.Id == 0)
                    isSaved = SavingAccountInfo.Add(sa);
                else
                    isSaved = SavingAccountInfo.Update(sa);

                if (isSaved)
                {
                    MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillupSavingAccount();
                    grpSa.Enabled = false;
                }
                else
                    MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                MessageBox.Show("Unable to save record." + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region "EPF"

        private void cmbEPFGoal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbEPFGoalMap.Text != "")
                cmbEPFGoalMap.Tag = _goals.FirstOrDefault(i => i.Name == cmbEPFGoalMap.Text).Id;
            else
                cmbEPFGoalMap.Tag = "0";
        }

        private void fillupEPFInfo()
        {
            setPermission(grpEPFControls);
            fillEPFInvesterCombobox();
            fillEPFGoalsCombobox();
            EPFInfo epfInfo = new EPFInfo();
            _dtEPF = epfInfo.GetEPFInfo(_planeId);
            dataGridEPF.DataSource = _dtEPF;
            epfInfo.SetGrid(dataGridEPF);
        }

        private void fillEPFGoalsCombobox()
        {
            cmbEPFGoalMap.Items.Clear();
            _goals = new GoalsInfo().GetAll(_planeId);
            foreach (var goal in _goals)
            {
                cmbEPFGoalMap.Items.Add(goal.Name);
            }
            cmbEPFGoalMap.Items.Add("");
        }

        private void fillEPFInvesterCombobox()
        {
            new PlannerInfo.FamilyMemberInfo().FillFamilyMemberInCombo(this._client.ID, cmbEPF_Invester);
        }

        private void dtGridEPF_SelectionChanged(object sender, EventArgs e)
        {
            DataRow dr = getSelectedDataRow(dataGridEPF, _dtEPF);
            if (dr != null)
                displayEPFInfo(dr);
            else
                setDefaultValueEPF();
        }

        private void setDefaultValueEPF()
        {
            cmbEPF_Invester.Tag = "0";
            cmbEPF_Invester.Text = "";
            cmbEPFAccountNo.Text = "";
            cmbEPFGoalMap.Tag = "0";
            cmbEPFGoalMap.Text = "";
            txtEPFParticular.Text = "";
            txtEPFAmount.Text = "0";
            txtEPF_ROI.Text = "0";
        }

        private void displayEPFInfo(DataRow dr)
        {
            if (dr != null)
            {
                cmbEPF_Invester.Tag = dr.Field<string>("ID");
                cmbEPF_Invester.Text = dr.Field<string>("InvesterName");
                cmbEPFAccountNo.Text = dr.Field<string>("AccountNo");
                txtEPFAmount.Text = dr.Field<string>("Amount");
                txtEPFParticular.Text = dr.Field<string>("Particular");
                if (dr["GoalID"] != null)
                {
                    cmbEPFGoalMap.Tag = dr["GoalId"].ToString();
                    cmbEPFGoalMap.Text = getGoalName(int.Parse(cmbEPFGoalMap.Tag.ToString()));
                }
                else
                {
                    cmbEPFGoalMap.Tag = "0";
                    cmbEPFGoalMap.Text = "";
                }
                txtEPF_ROI.Text = dr.Field<string>("InvestmentReturnRate");
            }
        }

        private void btnEPFAdd_Click(object sender, EventArgs e)
        {
            grpEPF.Enabled = true;
            setDefaultValueEPF();
        }

        private void btnEPFEdit_Click(object sender, EventArgs e)
        {
            grpEPF.Enabled = true;
        }

        private void btnEPFDelete_Click(object sender, EventArgs e)
        {
            if (dataGridEPF.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure, you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    EPFInfo epfInfo = new EPFInfo();
                    EPF epf = getEPFData();
                    epfInfo.Delete(epf);
                    fillupEPFInfo();
                }
            }
        }

        private EPF getEPFData()
        {
            EPF EPF = new EPF();
            EPF.Id = (cmbEPF_Invester.Tag == null) ? 0 : int.Parse(cmbEPF_Invester.Tag.ToString());
            EPF.Pid = _planeId;
            EPF.InvesterName = cmbEPF_Invester.Text;
            EPF.AccountNo = cmbEPFAccountNo.Text;
            EPF.Particular = txtEPFParticular.Text;
            EPF.Amount = (string.IsNullOrEmpty(txtEPFAmount.Text) ? 0 : double.Parse(txtEPFAmount.Text));
            EPF.GoalId = int.Parse(cmbEPFGoalMap.Tag.ToString());
            EPF.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            EPF.CreatedBy = Program.CurrentUser.Id;
            EPF.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            EPF.UpdatedBy = Program.CurrentUser.Id;
            EPF.MachineName = Environment.MachineName;
            EPF.InvestmentReturnRate = (string.IsNullOrEmpty(txtEPF_ROI.Text) ? 0 : float.Parse(txtEPF_ROI.Text));
            return EPF;
        }

        private void btnEPFSave_Click(object sender, EventArgs e)
        {
            try
            {
                EPFInfo epfInfo = new EPFInfo();
                EPF PPF = getEPFData();
                bool isSaved = false;

                if (PPF != null && PPF.Id == 0)
                    isSaved = epfInfo.Add(PPF);
                else
                    isSaved = epfInfo.Update(PPF);

                if (isSaved)
                {
                    MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillupEPFInfo();
                    grpEPF.Enabled = false;
                }
                else
                    MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                MessageBox.Show("Unable to save record." + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEPFCancel_Click(object sender, EventArgs e)
        {
            grpEPF.Enabled = false;
        }
        #endregion

        #region "Others"

        private void cmbOthersGoal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbOtherGoalMap.Text != "")
                cmbOtherGoalMap.Tag = _goals.FirstOrDefault(i => i.Name == cmbOtherGoalMap.Text).Id;
            else
                cmbOtherGoalMap.Tag = "0";
        }

        private void fillupOthersInfo()
        {
            setPermission(grpOtherControls);
            fillOthersInvesterCombobox();
            fillOthersGoalsCombobox();
            OthersInfo OthersInfo = new OthersInfo();
            _dtOthers = OthersInfo.GetOthersInfo(_planeId);
            dtGridOthers.DataSource = _dtOthers;
            OthersInfo.SetGrid(dtGridOthers);
        }

        private void fillOthersGoalsCombobox()
        {
            cmbOtherGoalMap.Items.Clear();
            _goals = new GoalsInfo().GetAll(_planeId);
            foreach (var goal in _goals)
            {
                cmbOtherGoalMap.Items.Add(goal.Name);
            }
            cmbOtherGoalMap.Items.Add("");
        }

        private void fillOthersInvesterCombobox()
        {
            new PlannerInfo.FamilyMemberInfo().FillFamilyMemberInCombo(this._client.ID, cmbOthersInvestor);
        }

        private void dtGridOthers_SelectionChanged(object sender, EventArgs e)
        {
            DataRow dr = getSelectedDataRow(dtGridOthers, _dtOthers);
            if (dr != null)
                displayOthersInfo(dr);
            else
                setDefaultValueOthers();
        }

        private void setDefaultValueOthers()
        {
            cmbOthersInvestor.Tag = "0";
            cmbOthersInvestor.Text = "";
            txtOthersAccountNo.Text = "";
            cmbOtherGoalMap.Tag = "0";
            cmbOtherGoalMap.Text = "";
            txtOthersParticular.Text = "";
            txtOthersAmount.Text = "0";
            txtOthersROI.Text = "0";
            cmbOthersTransactionType.Text = "Equity";

        }

        private void displayOthersInfo(DataRow dr)
        {
            if (dr != null)
            {
                cmbOthersInvestor.Tag = dr.Field<string>("ID");
                cmbOthersInvestor.Text = dr.Field<string>("InvesterName");
                txtOthersAccountNo.Text = dr.Field<string>("AccountNo");
                txtOthersAmount.Text = dr.Field<string>("Amount");
                txtOthersParticular.Text = dr.Field<string>("Particular");
                if (dr["GoalID"] != null)
                {
                    cmbOtherGoalMap.Tag = dr["GoalId"].ToString();
                    cmbOtherGoalMap.Text = getGoalName(int.Parse(cmbOtherGoalMap.Tag.ToString()));
                }
                else
                {
                    cmbOtherGoalMap.Tag = "0";
                    cmbOtherGoalMap.Text = "";
                }
                txtOthersROI.Text = dr.Field<string>("InvestmentReturnRate");
                cmbOthersTransactionType.Text = dr.Field<string>("TransactionType");
            }
        }

        private void btnOthersAdd_Click(object sender, EventArgs e)
        {
            grpOthersDetails.Enabled = true;
            setDefaultValueOthers();
        }

        private void btnOthersEdit_Click(object sender, EventArgs e)
        {
            grpOthersDetails.Enabled = true;
        }

        private void btnOthersDelete_Click(object sender, EventArgs e)
        {
            if (dtGridOthers.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure, you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    OthersInfo OthersInfo = new OthersInfo();
                    Others Others = getOthersData();
                    OthersInfo.Delete(Others);
                    fillupOthersInfo();
                }
            }
        }

        private Others getOthersData()
        {
            Others Others = new Others();
            Others.Id = (cmbOthersInvestor.Tag == null) ? 0 : int.Parse(cmbOthersInvestor.Tag.ToString());
            Others.Pid = _planeId;
            Others.InvesterName = cmbOthersInvestor.Text;
            Others.AccountNo = txtOthersAccountNo.Text;
            Others.Particular = txtOthersParticular.Text;
            Others.Amount = (string.IsNullOrEmpty(txtOthersAmount.Text) ? 0 : double.Parse(txtOthersAmount.Text));
            Others.GoalId = int.Parse(cmbOtherGoalMap.Tag.ToString());
            Others.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            Others.CreatedBy = Program.CurrentUser.Id;
            Others.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            Others.UpdatedBy = Program.CurrentUser.Id;
            Others.MachineName = Environment.MachineName;
            Others.InvestmentReturnRate = (string.IsNullOrEmpty(txtOthersROI.Text) ? 0 : float.Parse(txtOthersROI.Text));
            Others.TransactionType = cmbOthersTransactionType.Text;
            return Others;
        }

        private void btnOthersSave_Click(object sender, EventArgs e)
        {
            try
            {
                OthersInfo OthersInfo = new OthersInfo();
                Others PPF = getOthersData();
                bool isSaved = false;

                if (PPF != null && PPF.Id == 0)
                    isSaved = OthersInfo.Add(PPF);
                else
                    isSaved = OthersInfo.Update(PPF);

                if (isSaved)
                {
                    MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillupOthersInfo();
                    grpOthersDetails.Enabled = false;
                }
                else
                    MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                MessageBox.Show("Unable to save record." + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnOthersCancel_Click(object sender, EventArgs e)
        {
            grpOthersDetails.Enabled = false;
        }
        #endregion

        private void fillupBondInfo()
        {
            setPermission(grpBondsControl);
            fillBondsInvesterCombobox();
            fillBondsGoalsCombobox();
            BondInfo bondInfo = new BondInfo();
            _dtBond = bondInfo.GetBondsInfo(_planeId);
            dtGridBonds.DataSource = _dtBond;
            bondInfo.SetGrid(dtGridBonds);
        }

        private void fillBondsGoalsCombobox()
        {
            cmbBondsGoal.Items.Clear();
            _goals = new GoalsInfo().GetAll(_planeId);
            foreach (var goal in _goals)
            {
                cmbBondsGoal.Items.Add(goal.Name);
            }
            cmbBondsGoal.Items.Add("");
        }
        private void fillBondsInvesterCombobox()
        {
            new PlannerInfo.FamilyMemberInfo().FillFamilyMemberInCombo(this._client.ID, cmbBondsInvester);
        }

        private void fillupNPSInfo()
        {
            setPermission(grpNPSControls);
            fillNPSInvesterCombobox();
            fillNPSGolsCombobox();
            NPSInfo npsInfo = new NPSInfo();
            _dtNPS = npsInfo.GetNPSInfo(_planeId);
            dtGridNPS.DataSource = _dtNPS;
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

        private void fillupGenralInsuranceInfo()
        {
            setPermission(grpGenIsuranceControl);
            GeneralInsuranceInfo gernalInsuranceInfo = new GeneralInsuranceInfo();
            _dtGeneralInsurance = gernalInsuranceInfo.GetLifeInsuranceInfo(_planeId);
            dtGridGeneralInsurance.DataSource = _dtGeneralInsurance;
            gernalInsuranceInfo.SetGridColumn(dtGridGeneralInsurance);
            fillGeneralInsuranceApplicantCombobox();
        }

        private void fillLifeInsuranceInfo()
        {
            setPermission(grpActionControls);
            LifeInsuranceInfo lifeInsuranceInfo = new LifeInsuranceInfo();
            _dtLifeInsurance = lifeInsuranceInfo.GetLifeInsuranceInfo(_planeId);
            dtGridLifeInsurance.DataSource = _dtLifeInsurance;
            lifeInsuranceInfo.SetGridColumn(dtGridLifeInsurance);
            fillLifeInsuranceApplicantCombobox();
        }

        private void cmbPlan_SelectedValueChanged(object sender, EventArgs e)
        {
            var val = _dtPlan.Select("NAME ='" + cmbPlan.Text + "'");
            //_planeId = int.Parse(val[0]["ID"].ToString());
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
            if (dtLastPremiumPaymentDate.Checked = !(System.DBNull.Value == dr["LastPremiumDate"]))
                dtLastPremiumPaymentDate.Value = DateTime.Parse(dr["LastPremiumDate"].ToString());
            chkLICSetReminderForPremium.Checked = bool.Parse(dr["SetReminder"].ToString());
        }

        private DataRow getSelectedDataRowForLifeInsurance()
        {
            if (dtGridLifeInsurance.SelectedRows.Count >= 1)
            {
                int selectedRowIndex = dtGridLifeInsurance.SelectedRows[0].Index;
                if (dtGridLifeInsurance.SelectedRows[0].Cells["ID"].Value != System.DBNull.Value)
                {
                    int selectedUserId = int.Parse(dtGridLifeInsurance.SelectedRows[0].Cells["ID"].Value.ToString());
                    DataRow[] rows = _dtLifeInsurance.Select("Id ='" + selectedUserId + "'");
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
            dtLastPremiumPaymentDate.Checked = false;
            dtLastPremiumPaymentDate.Text = "";
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
            if (string.IsNullOrEmpty(txtPolicyName.Text))
            {
                MessageBox.Show("Policy Name should be not be blank.");
                return;
            }
            try
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
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                MessageBox.Show("Unable to save record." + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            lifeInsurance.Premium = string.IsNullOrEmpty(txtPrmium.Text) ? 0 : double.Parse(txtPrmium.Text);
            lifeInsurance.Terms = string.IsNullOrEmpty(txtTerm.Text) ? 0 : int.Parse(txtTerm.Text);
            lifeInsurance.PremiumPayTerm = txtPremiumPayTerm.Text;
            lifeInsurance.SumAssured = string.IsNullOrEmpty(txtSumAssured.Text) ? 0 : double.Parse(txtSumAssured.Text);
            lifeInsurance.Status = txtStatus.Text;
            lifeInsurance.ModeOfPayment = cmbModeOfPayment.Text;
            lifeInsurance.Moneyback = cmbMoneyBack.Text;
            if (dtNextPremiumDate.Checked)
                lifeInsurance.NextPremDate = dtNextPremiumDate.Value;
            lifeInsurance.AccidentalDeathBenefit = string.IsNullOrEmpty(txtAccidentalDeathBenefit.Text) ? 0 : double.Parse(txtAccidentalDeathBenefit.Text);
            lifeInsurance.Type = cmbType.Text;
            lifeInsurance.Appointee = txtAppointee.Text;
            lifeInsurance.Nominee = txtNominee.Text;
            lifeInsurance.Relation = txtRelation.Text;
            lifeInsurance.LoanTaken = (string.IsNullOrEmpty(txtLoanTaken.Text) ? 0 : double.Parse(txtLoanTaken.Text));
            if (dtLoanDate.Checked)
                lifeInsurance.LoanDate = dtLoanDate.Value;
            lifeInsurance.BalanceUnit = txtBalanceUnit.Text;
            if (dtAsOnDate.Checked)
                lifeInsurance.AsOnDate = dtAsOnDate.Value;
            lifeInsurance.CurrentValue = (string.IsNullOrEmpty(txtCurrentValue.Text) ? 0 : double.Parse(txtCurrentValue.Text));
            lifeInsurance.ExpectedMaturityValue = (string.IsNullOrEmpty(txtExpectedMaturityValue.Text) ? 0 : double.Parse(txtExpectedMaturityValue.Text));
            lifeInsurance.Rider1 = txtRider1.Text;
            lifeInsurance.Rider1Amount = (string.IsNullOrEmpty(txtRider1Amt.Text) ? 0 : double.Parse(txtRider1Amt.Text));
            lifeInsurance.Rider2 = txtRider2.Text;
            lifeInsurance.Rider2Amount = (string.IsNullOrEmpty(txtRider2Amt.Text) ? 0 : double.Parse(txtRider2Amt.Text));
            lifeInsurance.Remarks = txtRemarks.Text;
            lifeInsurance.AttachmentPath = txtAttachPath.Text;
            lifeInsurance.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            lifeInsurance.CreatedBy = Program.CurrentUser.Id;
            lifeInsurance.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            lifeInsurance.UpdatedBy = Program.CurrentUser.Id;
            lifeInsurance.MachineName = Environment.MachineName;
            if (dtLastPremiumPaymentDate.Checked)
                lifeInsurance.LastPremiumDate = dtLastPremiumPaymentDate.Value;
            lifeInsurance.SetReminder = chkLICSetReminderForPremium.Checked;
            
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
                dtGenInsMaturityDate.Checked = !(System.DBNull.Value == dr["RenewalDate"]);
                if (dtGenralInsIssueDate.Checked)
                    dtGenInsMaturityDate.Value = DateTime.Parse(dr["RenewalDate"].ToString());
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
                chkGISetReminderForPremium.Checked = bool.Parse(dr["SetReminder"].ToString());
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
                    DataRow[] rows = _dtGeneralInsurance.Select("Id ='" + selectedUserId + "'");
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
            //dtGenInsMaturityDate.Checked = false;
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
            chkGISetReminderForPremium.Checked = false;
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
            try
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
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                MessageBox.Show("Unable to save record." + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                genIns.RenewalDate = DateTime.Parse(dtGenInsMaturityDate.Text);
            else
                genIns.RenewalDate = null;
            genIns.TermsInYears = int.Parse(txtGenInsTerm.Text);
            genIns.PolicyNo = txtGenInsPolicyNumber.Text;
            genIns.Company = cmbGenInsCompany.Text;
            genIns.Policy = cmbGenInsPolicy.Text;
            genIns.Type = cmbGenInsType.Text;
            genIns.SumAssured = double.Parse(txtGenInsSumAssured.Text);
            genIns.Bonus = (string.IsNullOrEmpty(txtGenInsBonus.Text)) ? 0 :  double.Parse(txtGenInsBonus.Text);
            genIns.Premium = double.Parse(txtGenInsPremium.Text);
            genIns.Remark = txtGenInsRemark.Text;
            genIns.AttachmentPath = txtGenInsAttachmentPath.Text;
            genIns.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            genIns.UpdatedBy = Program.CurrentUser.Id;
            genIns.UpdatedByUserName = Program.CurrentUser.UserName;
            genIns.MachineName = System.Environment.MachineName;
            genIns.SetReminder = chkGISetReminderForPremium.Checked;
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
                    LifeInsurance lifeInsurance = getLifeInsuranceData();
                    lifeInsuranceInfo.Delete(lifeInsurance);
                    fillLifeInsuranceInfo();
                }
            }
        }

        private string getGoalName(int v)
        {
            if (_goals != null && v > 0)
                return _goals.FirstOrDefault(i => i.Id == v).Name;
            else
                return string.Empty;
        }

        private void calculateAndSetNPSCurrentValue()
        {
            float nav = 0;
            double units = 0;
            float.TryParse(txtNPSNAV.Text, out nav);
            double.TryParse(txtNPSUnits.Text, out units);
            txtNPSCurrentVal.Text = (nav * units).ToString();
        }

        private void cmbSchemeName_Enter(object sender, EventArgs e)
        {
            if (_dtMutualFund != null)
            {
                var distinctRows = (from DataRow dRow in _dtMutualFund.Rows
                                    select dRow["SchemeName"]).Distinct();
                foreach (var schmeName in distinctRows)
                {
                    cmbSchemeName.Items.Add(schmeName);
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
            txtNPSNAV.Text = "0";
            txtUnits.Text = "0";
            txtNPSCurrentVal.Text = "0";
            txtNPSEquityRatio.Text = "0";
            txtNPSGoldRatio.Text = "0";
            txtNPSDebtRatio.Text = "0";
            cmbNPSGoal.Text = "";
            cmbNPSGoal.Tag = "0";
            txtNPSInvestmentReturnRate.Text = "0";
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
                    NPS nps = getNPSData();
                    npsInfo.Delete(nps);
                    fillupNPSInfo();
                }
            }
        }

        private NPS getNPSData()
        {
            NPS nps = new NPS();
            nps.Id = int.Parse(cmbNPSInvester.Tag.ToString());
            nps.Pid = _planeId;
            nps.InvesterName = cmbNPSInvester.Text;
            nps.SchemeName = cmbNPSScheme.Text;
            nps.FolioNo = txtNPSFolioNo.Text;
            nps.Nav = (string.IsNullOrEmpty(txtNPSNAV.Text) ? 0 : float.Parse(txtNPSNAV.Text));
            nps.Units = (string.IsNullOrEmpty(txtNPSUnits.Text) ? 0 : int.Parse(txtNPSUnits.Text));
            nps.EquityRatio = (string.IsNullOrEmpty(txtNPSEquityRatio.Text) ? 0 : float.Parse(txtNPSEquityRatio.Text));
            nps.GoldRatio = (string.IsNullOrEmpty(txtNPSGoldRatio.Text) ? 0 : float.Parse(txtNPSGoldRatio.Text));
            nps.DebtRatio = (string.IsNullOrEmpty(txtNPSDebtRatio.Text) ? 0 : float.Parse(txtNPSDebtRatio.Text));
            nps.GoalID = int.Parse(cmbNPSGoal.Tag.ToString());
            nps.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            nps.CreatedBy = Program.CurrentUser.Id;
            nps.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            nps.UpdatedBy = Program.CurrentUser.Id;
            nps.MachineName = Environment.MachineName;
            nps.InvestmentReturnRate = (string.IsNullOrEmpty(txtNPSInvestmentReturnRate.Text) ? 0 :
                float.Parse(txtNPSInvestmentReturnRate.Text));
            return nps;
        }

        private void btnNPSSave_Click(object sender, EventArgs e)
        {
            try
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
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                MessageBox.Show("Unable to save record." + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                txtNPSInvestmentReturnRate.Text = dr["InvestmentReturnRate"].ToString();
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

                    DataRow[] rows = _dtNPS.Select("Id ='" + selectedUserId + "'");
                    foreach (DataRow dr in rows)
                    {
                        return dr;
                    }
                }
            }
            return null;
        }


        private void btnAddBonds_Click(object sender, EventArgs e)
        {
            grpBonds.Enabled = true;
            setDefaultValueBonds();
        }

        private void setDefaultValueBonds()
        {
            cmbBondsInvester.Tag = "0";
            cmbBondsInvester.Text = "";
            cmbBondsCompany.Text = "";
            txtBondsFolioNo.Text = "";
            txtBondsFaceValue.Text = "0";
            txtBondsRate.Text = "0";
            txtBondsUnit.Text = "0";
            txtBondsCurrentValue.Text = "0";
            //calculateAndSetBondsCurrentValue();
            cmbBondsGoal.Tag = "0";
            cmbBondsGoal.Text = "";
            txtBondInvRetRate.Text = "0";
        }

        private void calculateAndSetBondsCurrentValue()
        {
            float nav = 0;
            double units = 0;
            float.TryParse(txtBondsRate.Text, out nav);
            double.TryParse(txtBondsUnit.Text, out units);
            txtBondsCurrentValue.Text = (nav * units).ToString();
        }

        private void btnEditBonds_Click(object sender, EventArgs e)
        {
            grpBonds.Enabled = true;
        }

        private void dtGridBonds_SelectionChanged(object sender, EventArgs e)
        {
            DataRow dr = getSelectedDataRow(dtGridBonds, _dtBond);
            if (dr != null)
                displayBondsInfo(dr);
            else
                setDefaultValueBonds();
        }

        private void displayBondsInfo(DataRow dr)
        {
            if (dr != null)
            {
                cmbBondsInvester.Tag = dr.Field<string>("ID");
                cmbBondsInvester.Text = dr.Field<string>("InvesterName");
                cmbBondsCompany.Text = dr.Field<string>("CompanyName");
                txtBondsFolioNo.Text = dr.Field<string>("FolioNo");
                txtBondsRate.Text = dr.Field<string>("Rate");
                dtMaturityDate.Text = dr.Field<string>("MaturityDate");
                txtBondsUnit.Text = dr.Field<string>("NOOFBOND");
                txtBondsFaceValue.Text = dr.Field<string>("FaceValue");
                dtBondsMaturityDate.Value = DateTime.Parse(dr.Field<string>("MaturityDate"));
                txtBondsCurrentValue.Text = dr.Field<string>("CurrentValue");
                //calculateAndSetBondsCurrentValue();
                if (dr["GoalID"] != null)
                {
                    cmbBondsGoal.Tag = dr["GoalId"].ToString();
                    cmbBondsGoal.Text = getGoalName(int.Parse(cmbBondsGoal.Tag.ToString()));
                }
                else
                {
                    cmbBondsGoal.Tag = "0";
                    cmbBondsGoal.Text = "";
                }
                txtBondInvRetRate.Text = dr.Field<string>("InvestmentReturnRate").ToString();
            }
        }

        private DataRow getSelectedDataRow(DataGridView dtGridView, DataTable dataTable)
        {
            if (dtGridView.SelectedRows.Count >= 1)
            {
                int selectedRowIndex = dtGridView.SelectedRows[0].Index;
                if (dtGridView.SelectedRows[0].Cells["ID"].Value != System.DBNull.Value)
                {
                    int selectedUserId = int.Parse(dtGridView.SelectedRows[0].Cells["ID"].Value.ToString());

                    DataRow[] rows = dataTable.Select("Id ='" + selectedUserId + "'");
                    foreach (DataRow dr in rows)
                    {
                        return dr;
                    }
                }
            }
            return null;
        }

        private void btnDeleteBonds_Click(object sender, EventArgs e)
        {
            if (dtGridBonds.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure, you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BondInfo bondInfo = new BondInfo();
                    Bonds bond = getBondsData();
                    bondInfo.Delete(bond);
                    fillupBondInfo();
                }
            }
        }

        private Bonds getBondsData()
        {

            Bonds Bonds = new Bonds();
            Bonds.Id = int.Parse(cmbBondsInvester.Tag.ToString());
            Bonds.Pid = _planeId;
            Bonds.InvesterName = cmbBondsInvester.Text;
            Bonds.CompanyName = cmbBondsCompany.Text;
            Bonds.FolioNo = txtBondsFolioNo.Text;
            Bonds.FaceValue = (string.IsNullOrEmpty(txtBondsFaceValue.Text) ? 0 : float.Parse(txtBondsFaceValue.Text));
            Bonds.NoOfBond = (string.IsNullOrEmpty(txtBondsUnit.Text) ? 0 : int.Parse(txtBondsUnit.Text));
            Bonds.Rate = (string.IsNullOrEmpty(txtBondsRate.Text) ? 0 : float.Parse(txtBondsRate.Text));
            Bonds.CurrentValue = (string.IsNullOrEmpty(txtBondsCurrentValue.Text) ? 0 : double.Parse(txtBondsCurrentValue.Text));
            Bonds.MaturityDate = dtMaturityDate.Value;
            Bonds.GoalId = int.Parse(cmbBondsGoal.Tag.ToString());
            Bonds.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            Bonds.CreatedBy = Program.CurrentUser.Id;
            Bonds.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            Bonds.UpdatedBy = Program.CurrentUser.Id;
            Bonds.MachineName = Environment.MachineName;
            Bonds.InvestmentReturnRate = (string.IsNullOrEmpty(txtBondInvRetRate.Text) ? 0 : float.Parse(txtBondInvRetRate.Text));
            return Bonds;
        }

        private void btnBondsSave_Click(object sender, EventArgs e)
        {
            try
            {
                BondInfo BondInfo = new BondInfo();
                Bonds bonds = getBondsData();
                bool isSaved = false;

                if (bonds != null && bonds.Id == 0)
                    isSaved = BondInfo.Add(bonds);
                else
                    isSaved = BondInfo.Update(bonds);

                if (isSaved)
                {
                    MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillupBondInfo();
                    grpBonds.Enabled = false;
                }
                else
                    MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                MessageBox.Show("Unable to save record." + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBondsCancel_Click(object sender, EventArgs e)
        {
            grpBonds.Enabled = false;
        }

        private void txtBondsRate_Leave(object sender, EventArgs e)
        {
            calculateAndSetBondsCurrentValue();
        }

        private void txtBondsUnit_Leave(object sender, EventArgs e)
        {
            calculateAndSetBondsCurrentValue();
        }

        private void cmbBondsGoal_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbBondsGoal.Text != "")
                cmbBondsGoal.Tag = _goals.FirstOrDefault(i => i.Name == cmbBondsGoal.Text).Id;
            else
                cmbBondsGoal.Tag = "0";
        }

        private void dtPPFOpeningDate_ValueChanged(object sender, EventArgs e)
        {
            calculatePPFMaturityDate();
        }

        private void calculatePPFMaturityDate()
        {
            if (dtPPFOpeningDate.Value != null)
            {
                DateTime ppfAccountCalStartDate = dtPPFOpeningDate.Value.Month < 4 ?
                     new DateTime(dtPPFOpeningDate.Value.Year, 4, 1) : new DateTime(dtPPFOpeningDate.Value.Year + 1, 4, 1);

                dtPPFMaturityDate.Value = (chkPPFAccountExtended.Checked) ? ppfAccountCalStartDate.AddYears(5):
                    ppfAccountCalStartDate.AddYears(15);
            }
        }

        private void chkPPFAccountExtended_CheckedChanged(object sender, EventArgs e)
        {
            calculatePPFMaturityDate();
        }    
    }
}
