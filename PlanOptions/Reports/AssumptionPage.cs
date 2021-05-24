using FinancialPlanner.Common.Model;
using FinancialPlannerClient.PlannerInfo;

namespace FinancialPlannerClient.PlanOptions
{
    public partial class AssumptionPage : DevExpress.XtraReports.UI.XtraReport
    {
        int plannerId;
        public AssumptionPage(PersonalInformation personalInformation, int plannerId)
        {
            InitializeComponent();
            this.plannerId = plannerId;
            this.lblClientName.Text = personalInformation.Client.Name;
            this.lblClientNameForRet.Text = lblClientName.Text;
            this.lblSpouseNameForRet.Text = personalInformation.Spouse.Name;
            this.lblClientNameLifeExp.Text = lblClientName.Text;
            this.lblSpouseLifeExp.Text = personalInformation.Spouse.Name;
            lblClientNameForIncome.Text = lblClientName.Text;
            lblSpouseNameForIncome.Text = personalInformation.Spouse.Name;
           
            lblInsurance.Text = string.Format(lblInsurance.Text, lblClientName.Text, lblSpouseNameForIncome.Text ," 7");
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            PlannerAssumptionInfo plannerassumptionInfo = new PlannerAssumptionInfo();
            PlannerAssumption plannerAssumption = plannerassumptionInfo.GetAll(this.plannerId);
            lblClientRetAge.Text = string.Format("{0} Years", plannerAssumption.ClientRetirementAge);
            lblSpouseRetAge.Text = string.Format("{0} Years", plannerAssumption.SpouseRetirementAge);
            lblClientLifeExpVal.Text = string.Format("{0} Years", plannerAssumption.ClientLifeExpectancy);
            lblSpouseLifeExpVal.Text = string.Format("{0} Years", plannerAssumption.SpouseLifeExpectancy);
            lblPreRetInfRate.Text = string.Format("{0} %", plannerAssumption.PreRetirementInflactionRate);
            lblPostRetInfRate.Text = string.Format("{0} %", plannerAssumption.PostRetirementInflactionRate);
            lblEquityReturn.Text = string.Format("{0} %", plannerAssumption.EquityReturnRate);
            lblDebtReturn.Text = string.Format("{0} %", plannerAssumption.DebtReturnRate);
            lblRealEstateReturn.Text = string.Format("{0} %", plannerAssumption.OtherReturnRate);
            lblExpRaise.Text = string.Format(lblExpRaise.Text, plannerAssumption.OngoingExpRise);
            lblClientIncomeRaise.Text = string.Format("{0} %", plannerAssumption.ClientIncomeRise);
            lblSpouseIncomeRaise.Text = string.Format("{0} %", plannerAssumption.ClientIncomeRise);
            lblNote.Text = plannerAssumption.Decription;
        }
    }
}
