using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FinancialPlanner.Common.Model;
using System.Collections.Generic;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class OtherRecommendation : DevExpress.XtraReports.UI.XtraReport
    {
        Client client;
        Planner planner;

        public OtherRecommendation(Client client, Planner planner)
        {
            InitializeComponent();
            this.client = client;
            this.planner = planner;
            this.lblClientName.Text = client.Name;
            generateData();
        }

        private void generateData()
        {
            setTermInsurancePage();
        }

        private void setTermInsurancePage()
        {
            InsuranceRecomendationInfo insuranceRecomendationInfo = new InsuranceRecomendationInfo();
            IList<InsuranceRecomendationTransaction> insuranceRecomendationTransactions = insuranceRecomendationInfo.GetAll(this.planner.ID);

            if (insuranceRecomendationTransactions != null)
            {
                if (insuranceRecomendationTransactions.Count == 0)
                {
                    xrSubreportInsuranceRecommendation.Visible = false;
                    xrSubreportInsuranceRecommendation.ReportSource = null;
                    xrSubreportInsuranceRecommendation.HeightF = 0;
                }
                else
                {
                    xrSubreportInsuranceRecommendation.ReportSource = new TermInsurance(this.client, this.planner);
                }
            }
            else
            {
                xrSubreportInsuranceRecommendation.Visible = false;
                xrSubreportInsuranceRecommendation.ReportSource = null;
                xrSubreportInsuranceRecommendation.HeightF = 0;
            }
        }
    }
}
