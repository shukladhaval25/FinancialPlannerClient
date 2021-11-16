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
            setPersonalAccidentalInsurancePage();
            setOtherRecommendationPage();
        }

        private void setOtherRecommendationPage()
        {
            OtherRecommendationSettingInfo otherRecommendationSettingInfo = new OtherRecommendationSettingInfo();
            IList<OtherRecommendationSetting> otherRecommendationSettings = otherRecommendationSettingInfo.GetAll(this.planner.ID);

            if (otherRecommendationSettings != null)
            {
                if (otherRecommendationSettings.Count == 0)
                {
                    hideOtherRecommendation();
                }
                else
                {
                    int count = 0;
                    foreach(OtherRecommendationSetting other in otherRecommendationSettings)
                    {
                        if (other.IsSelected)
                        {
                            count = count + 1;
                        }
                    }
                    if (count > 0)
                    {
                        xrSubreportOthers.ReportSource = new OtherRecommendationPage(this.client, this.planner);
                    }
                    else
                    {
                        hideOtherRecommendation();
                    }
                }
            }
            else
            {
                hideOtherRecommendation();
            }
        }

        private void hideOtherRecommendation()
        {
            xrSubreportOthers.Visible = false;
            xrSubreportOthers.ReportSource = null;
            xrSubreportOthers.HeightF = 0;
            //this.components.Remove(xrSubreportOthers);
        }

        private void setPersonalAccidentalInsurancePage()
        {
            PersonalAccidentalInsuranceInfo personalAccidentalInsuranceInfo = new PersonalAccidentalInsuranceInfo();
            IList<PersonalAccidentInsurance> personalAccidentInsurances = personalAccidentalInsuranceInfo.GetAll(this.planner.ID);

            if (personalAccidentInsurances != null)
            {
                if (personalAccidentInsurances.Count == 0)
                {
                    hidePersonalAccidentInsurance();
                }
                else
                {
                    xrSubreportPersonalAccident.ReportSource = new PersonalAccidentalInsurancePage(this.client, this.planner);
                }
            }
            else
            {
                hidePersonalAccidentInsurance();
            }
        }

        private void hidePersonalAccidentInsurance()
        {
            xrSubreportPersonalAccident.Visible = false;
            xrSubreportPersonalAccident.ReportSource = null;
            xrSubreportPersonalAccident.HeightF = 0;
            xrSubreportOthers.TopF = xrSubreportPersonalAccident.TopF;
            xrSubreportOthers.LeftF = xrSubreportPersonalAccident.LeftF;
        }

        private void setTermInsurancePage()
        {
            InsuranceRecomendationInfo insuranceRecomendationInfo = new InsuranceRecomendationInfo();
            IList<InsuranceRecomendationTransaction> insuranceRecomendationTransactions = insuranceRecomendationInfo.GetAll(this.planner.ID);

            if (insuranceRecomendationTransactions != null)
            {
                if (insuranceRecomendationTransactions.Count == 0)
                {
                    hideTermInsuranceSection();
                }
                else
                {
                    TermInsurance termInsurance = new TermInsurance(this.client, this.planner);
                    xrSubreportInsuranceRecommendation.ReportSource = termInsurance;
                    xrSubreportInsuranceRecommendation.HeightF = termInsurance.PageHeight;
                }
            }
            else
            {
                hideTermInsuranceSection();
            }
        }

        private void hideTermInsuranceSection()
        {
            xrSubreportInsuranceRecommendation.Visible = false;
            xrSubreportInsuranceRecommendation.ReportSource = null;
            xrSubreportInsuranceRecommendation.HeightF = 0;
            xrSubreportPersonalAccident.TopF = xrSubreportInsuranceRecommendation.TopF;
            xrSubreportPersonalAccident.LeftF = xrSubreportInsuranceRecommendation.LeftF;
        }
    }
}
