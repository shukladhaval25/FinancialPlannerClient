using FinancialPlanner.Common.Model;
using FinancialPlannerClient.PlannerInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinancialPlannerClient.PlanOptions
{
    public partial class Assumption : DevExpress.XtraEditors.XtraForm
    {
        Client client;
        Planner planner;
        string spouseName;
        public Assumption()
        {
            InitializeComponent();
        }
        public Assumption(Client client,Planner planner,string spouseName)
        {
            InitializeComponent();
            this.client = client;
            this.planner = planner;
            this.spouseName = spouseName;
            fillupAssumptionInfo();
        }

        private void fillupAssumptionInfo()
        {
            lblClientTiitle.Text = client.Name;
            lblSpouseTitle.Text = spouseName;
            PlannerAssumptionInfo plannerassumptionInfo = new PlannerAssumptionInfo();
            PlannerAssumption plannerAssumption = plannerassumptionInfo.GetAll(planner.ID);
            displayPlannerAssumptionData(plannerAssumption);
        }

        private void displayPlannerAssumptionData(PlannerAssumption plannerAssumption)
        {
            if (plannerAssumption != null)
            {
                txtClientRetAge.Tag = plannerAssumption.Id;
                txtClientRetAge.Text = plannerAssumption.ClientRetirementAge.ToString();
                txtSpouseRetAge.Text = plannerAssumption.SpouseRetirementAge.ToString();
                txtClientLifeExp.Text = plannerAssumption.ClientLifeExpectancy.ToString();
                txtSpouseLifeExp.Text = plannerAssumption.SpouseLifeExpectancy.ToString();
                txtPreRetInflationRate.Text = plannerAssumption.PreRetirementInflactionRate.ToString();
                txtPostRetInflationRate.Text = plannerAssumption.PostRetirementInflactionRate.ToString();
                txtEquityReturn.Text = plannerAssumption.EquityReturnRate.ToString();
                txtDebtReturn.Text = plannerAssumption.DebtReturnRate.ToString();
                txtOtherReturn.Text = plannerAssumption.OtherReturnRate.ToString();
                txtPlannerAssumptionDescription.Text = plannerAssumption.Decription;
                rdoPrimaryRetirement.SelectedIndex = (plannerAssumption.IsClientRetirmentAgeIsPrimary) ? 0 : 1;
                txtIncomeRiseForClient.Text = plannerAssumption.ClientIncomeRise.ToString();
                txtIncomeRiseForSpouse.Text = plannerAssumption.SpouseIncomeRise.ToString();
                txtOngoingExpRise.Text = plannerAssumption.OngoingExpRise.ToString();
            }
        }

        private void Assumption_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Parent != null)
                this.Parent.Controls.Clear();
        }

        private void btnSaveAssumption_Click(object sender, EventArgs e)
        {
            PlannerAssumptionInfo PlannerAssumptionInfo = new PlannerAssumptionInfo();
            PlannerAssumption PlannerAssumption = getPlannerAssumptionData();
            bool isSaved = false;

            isSaved = PlannerAssumptionInfo.Update(PlannerAssumption);

            if (isSaved)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fillupAssumptionInfo();
            }
            else
                DevExpress.XtraEditors.XtraMessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private PlannerAssumption getPlannerAssumptionData()
        {
            PlannerAssumption plannerAssumption = new PlannerAssumption();
            plannerAssumption.Id = int.Parse(txtClientRetAge.Tag.ToString());
            plannerAssumption.Pid = this.planner.ID;
            plannerAssumption.ClientRetirementAge = int.Parse(txtClientRetAge.Text);
            plannerAssumption.SpouseRetirementAge = int.Parse(txtSpouseRetAge.Text);
            plannerAssumption.ClientLifeExpectancy = int.Parse(txtClientLifeExp.Text);
            plannerAssumption.SpouseLifeExpectancy = int.Parse(txtSpouseLifeExp.Text);
            plannerAssumption.PreRetirementInflactionRate = decimal.Parse(txtPreRetInflationRate.Text);
            plannerAssumption.PostRetirementInflactionRate = decimal.Parse(txtPostRetInflationRate.Text);
            plannerAssumption.EquityReturnRate = decimal.Parse(txtEquityReturn.Text);
            plannerAssumption.DebtReturnRate = decimal.Parse(txtDebtReturn.Text);
            plannerAssumption.OtherReturnRate = decimal.Parse(txtOtherReturn.Text);
            plannerAssumption.Decription = txtPlannerAssumptionDescription.Text;
            plannerAssumption.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            plannerAssumption.UpdatedBy = Program.CurrentUser.Id;
            plannerAssumption.UpdatedByUserName = Program.CurrentUser.UserName;
            plannerAssumption.MachineName = System.Environment.MachineName;
            plannerAssumption.IsClientRetirmentAgeIsPrimary = (rdoPrimaryRetirement.SelectedIndex == 0 ? true : false);
            plannerAssumption.ClientIncomeRise = decimal.Parse(txtIncomeRiseForClient.Text);
            plannerAssumption.SpouseIncomeRise = decimal.Parse(txtIncomeRiseForSpouse.Text);
            plannerAssumption.OngoingExpRise = decimal.Parse(txtOngoingExpRise.Text);

            return plannerAssumption;
        }
    }
}
