using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Permission;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinancialPlannerClient.Master
{
    public partial class AssumptionMasters : DevExpress.XtraEditors.XtraForm
    {
        AssumptionMaster assumptionMaster = new AssumptionMaster();
        public AssumptionMasters()
        {
            InitializeComponent();
        }

        private void txtRetirementAge_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !FinancialPlanner.Common.Validation.IsDigit(txtRetirementAge.Text);
        }

        private void txtLifeExpectancy_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !FinancialPlanner.Common.Validation.IsDigit(txtLifeExpectancy.Text);
            if (!e.Cancel)
            {
                int retirementAge,lifeExpectency = 0;
                int.TryParse(txtRetirementAge.Text, out retirementAge);
                int.TryParse(txtLifeExpectancy.Text, out lifeExpectency);
                if (lifeExpectency < retirementAge)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Life expectancy value must be greater than retirement age.","Invalid Value", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    e.Cancel = true;
                }                
            }
        }

        private void txtPreRetirmentInflationRate_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !FinancialPlanner.Common.Validation.IsDecimal(txtPreRetirmentInflationRate.Text);
        }

        private void txtPostRetirementInfationRate_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !FinancialPlanner.Common.Validation.IsDecimal(txtPostRetirementInfationRate.Text);
        }

        private void txtIncomeRaise_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !FinancialPlanner.Common.Validation.IsDecimal(txtIncomeRaise.Text);
        }

        private void txtOutgoingExp_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !FinancialPlanner.Common.Validation.IsDecimal(txtOutgoingExp.Text);
        }

        private void txtEquity_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !FinancialPlanner.Common.Validation.IsDecimal(txtEquity.Text);
        }

        private void txtDebt_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !FinancialPlanner.Common.Validation.IsDecimal(txtDebt.Text);
        }

        private void txtOthers_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !FinancialPlanner.Common.Validation.IsDecimal(txtOthers.Text);
        }

        private void txtNonFinancialRaise_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !FinancialPlanner.Common.Validation.IsDecimal(txtNonFinancialRaise.Text);
        }

        private void btnSaveAssumption_Click(object sender, EventArgs e)
        {
            AssumptionMasterInfo assumptionInfo = new AssumptionMasterInfo();
            getAssumptionData();
            bool isSaved = false;

            isSaved = assumptionInfo.Update(assumptionMaster);

            if (isSaved)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fillupAssumptionInfo();
            }
            else
                DevExpress.XtraEditors.XtraMessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void getAssumptionData()
        {
            assumptionMaster.Id = (txtRetirementAge.Tag != null ) ? int.Parse(txtRetirementAge.Tag.ToString()) : 0 ;
            assumptionMaster.RetirementAge = int.Parse(txtRetirementAge.Text);
            assumptionMaster.LifeExpectancy = int.Parse(txtLifeExpectancy.Text);
            assumptionMaster.PostRetirementInflactionRate = decimal.Parse(txtPostRetirementInfationRate.Text);
            assumptionMaster.PreRetirementInflactionRate = decimal.Parse(txtPreRetirmentInflationRate.Text);
            assumptionMaster.IncomeRaiseRatio = decimal.Parse(txtIncomeRaise.Text);
            assumptionMaster.OngoingExpRise = decimal.Parse(txtOutgoingExp.Text);
            assumptionMaster.EquityReturnRate = decimal.Parse(txtEquity.Text);
            assumptionMaster.DebtReturnRate = decimal.Parse(txtDebt.Text);
            assumptionMaster.OtherReturnRate = decimal.Parse(txtOthers.Text);
            assumptionMaster.NonFinancialRateOfReturn = decimal.Parse(txtNonFinancialRaise.Text);         
            assumptionMaster.UpdatedBy = Program.CurrentUser.Id;
            assumptionMaster.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            assumptionMaster.MachineName = System.Environment.MachineName;
            assumptionMaster.PostRetirementInvestmentReturnRate = decimal.Parse(txtPostRetirementInvReturn.Text);
            assumptionMaster.InsuranceReturnRate = decimal.Parse(txtInsuranceRateOfReturn.Text);
        }

        private void fillupAssumptionInfo()
        {
            txtRetirementAge.Tag = assumptionMaster.Id;
            txtRetirementAge.Text = assumptionMaster.RetirementAge.ToString();
            txtLifeExpectancy.Text = assumptionMaster.LifeExpectancy.ToString();
            txtPostRetirementInfationRate.Text = assumptionMaster.PostRetirementInflactionRate.ToString();
            txtPreRetirmentInflationRate.Text = assumptionMaster.PreRetirementInflactionRate.ToString();
            txtIncomeRaise.Text = assumptionMaster.IncomeRaiseRatio.ToString();
            txtOutgoingExp.Text = assumptionMaster.OngoingExpRise.ToString();
            txtEquity.Text = assumptionMaster.EquityReturnRate.ToString();
            txtDebt.Text = assumptionMaster.DebtReturnRate.ToString();
            txtOthers.Text = assumptionMaster.OtherReturnRate.ToString();
            txtNonFinancialRaise.Text = assumptionMaster.NonFinancialRateOfReturn.ToString();
            txtPostRetirementInvReturn.Text = assumptionMaster.PostRetirementInvestmentReturnRate.ToString();
            txtInsuranceRateOfReturn.Text = assumptionMaster.InsuranceReturnRate.ToString();
        }

        private void AssumptionMasters_Load(object sender, EventArgs e)
        {

            assumptionMaster = Program.GetAssumptionMaster();
            fillupAssumptionInfo();
        }

        private void ApplyPermission(string option)
        {
            List<RolePermission> rolePermission = (List<RolePermission>)Program.CurrentUserRolePermission.Permissions;
            RolePermission permission = rolePermission.Find(x => x.FormName == option);
            if (permission != null)
            {
                btnSaveAssumption.Visible = permission.IsAdd || permission.IsUpdate;
            }
            else
            {
                btnSaveAssumption.Visible = false;
            }
        }
        private void btnCloseClientInfo_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPostRetirementInvReturn_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !FinancialPlanner.Common.Validation.IsDecimal(txtPostRetirementInfationRate.Text);
        }

        private void txtInsuranceRateOfReturn_Validating(object sender, CancelEventArgs e)
        {
            e.Cancel = !FinancialPlanner.Common.Validation.IsDecimal(txtInsuranceRateOfReturn .Text);
        }
    }
}
