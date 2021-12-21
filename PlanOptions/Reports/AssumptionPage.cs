﻿using DevExpress.XtraReports.UI;
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
           
            
        }

        private void Detail_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            PlannerAssumptionInfo plannerassumptionInfo = new PlannerAssumptionInfo();
            PlannerAssumption plannerAssumption = plannerassumptionInfo.GetAll(this.plannerId);

            AssumptionConfig assumptionConfig = plannerassumptionInfo.GetAssumptionConfig(this.plannerId);

            lblClientRetAge.Text = string.Format("{0} Years", plannerAssumption.ClientRetirementAge);
            lblSpouseRetAge.Text = string.Format("{0} Years", plannerAssumption.SpouseRetirementAge);
            lblClientLifeExpVal.Text = string.Format("{0} Years", plannerAssumption.ClientLifeExpectancy);
            lblSpouseLifeExpVal.Text = string.Format("{0} Years", plannerAssumption.SpouseLifeExpectancy);
            if (assumptionConfig.RateOfInflation)
            {
                lblPreRetInfRate.Text = string.Format("{0} %", plannerAssumption.PreRetirementInflactionRate);
                lblPostRetInfRate.Text = string.Format("{0} %", plannerAssumption.PostRetirementInflactionRate);
            }
            if (assumptionConfig.PostTaxRateOfReturn)
            {
                lblEquityReturn.Text = string.Format("{0} %", plannerAssumption.EquityReturnRate);
                lblDebtReturn.Text = string.Format("{0} %", plannerAssumption.DebtReturnRate);
                lblRealEstateReturn.Text = string.Format("{0} %", plannerAssumption.OtherReturnRate);
            }

            if (assumptionConfig.RegularOngoingExp)
            {
                lblExpRaise.Text = string.Format(lblExpRaise.Text, plannerAssumption.OngoingExpRise);
            }

            lblClientIncomeRaise.Text = string.Format("{0} %", plannerAssumption.ClientIncomeRise);
            lblSpouseIncomeRaise.Text = string.Format("{0} %", plannerAssumption.SpouseIncomeRise );

            AssumptionMaster assumptionMaster = Program.GetAssumptionMaster();
            lblInsurance.Text = string.Format(lblInsurance.Text, lblClientName.Text, lblSpouseNameForIncome.Text, assumptionMaster.InsuranceReturnRate);

            System.Windows.Forms.RichTextBox richTextBox = new System.Windows.Forms.RichTextBox();
            richTextBox.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            richTextBox.Text = plannerAssumption.Decription.ToString();
            
            ((XRRichText)this.FindControl("lblNote", true)).Rtf = richTextBox.Text ;

            //lblNote.Rtf = plannerAssumption.Decription;
        }
    }
}
