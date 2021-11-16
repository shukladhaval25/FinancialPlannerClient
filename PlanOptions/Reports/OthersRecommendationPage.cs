using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class OtherRecommendationPage : DevExpress.XtraReports.UI.XtraReport
    {
        string description = "* We recommend taking a Term Plan of Rs. {0} for {1} yrs." + Environment.NewLine + "Please find below stated quotes for your reference.";

        Client client;
        Planner planner;
        DataTable dtTermInsurance;
        DataSet ds;
        public OtherRecommendationPage(Client client, Planner planner)
        {
            InitializeComponent();
            this.client = client;
            this.planner = planner;
            generateData();
            //this.lblPersonName.Text = client.Name;
            //this.GroupHeader1.GroupFields[0].FieldName = this.goal.Name;
            //this.GroupHeader1.GroupFields[1].FieldName = this.goal.Name;
        }

        private void generateData()
        {
            OtherRecommendationSettingInfo otherRecommendationSettingInfo = new OtherRecommendationSettingInfo();
            IList<OtherRecommendationSetting> otherRecommendationSettings = otherRecommendationSettingInfo.GetAll(this.planner.ID);
            createTermInsuranceTable();
            if (otherRecommendationSettings != null)
            {

                dtTermInsurance = ListtoDataTable.ToDataTable((List<OtherRecommendationSetting>)otherRecommendationSettings);
                dtTermInsurance = dtTermInsurance.Select("IsSelected = True").CopyToDataTable();
                dtTermInsurance.TableName = "OtherRecommendation";
                ds = new DataSet();
                ds.Tables.Add(dtTermInsurance);
                this.DataSource = ds;
                this.DataMember = ds.Tables[0].TableName;
                this.lblTitle.DataBindings.Add("Text", this.DataSource, "OtherRecommendation.Title");
                this.lblDescription.DataBindings.Add("Text", this.DataSource, "OtherRecommendation.Description");
                //this.lblSumAssuredGrp.DataBindings.Add("Text", this.DataSource, "TermInsurance.InuRecMasterSumAssured");
                //lblInsuranceCompanyName.DataBindings.Add("Text", this.DataSource, "TermInsurance.InsuranceCompanyName");
                //lblTerms.DataBindings.Add("Text", this.DataSource, "TermInsurance.Term");
                //lblSumAssured.DataBindings.Add("Text", this.DataSource, "TermInsurance.SumAssured");
                //lblPremium.DataBindings.Add("Text", this.DataSource, "TermInsurance.Premium");
                //lblDescription.DataBindings.Add("Text", this.DataSource, "TermInsurance.Description");
                GroupHeader1.GroupFields[0].FieldName = "Title";
                //GroupHeader1.GroupFields[1].FieldName = "InuRecMasterSumAssured";
            }
        }

        private void createTermInsuranceTable()
        {
            dtTermInsurance = new DataTable();
            //dtTermInsurance.Columns.Add("Id", typeof(System.Int64));
            dtTermInsurance.Columns.Add("Name", typeof(System.String));
            dtTermInsurance.Columns.Add("InuRecMasterSumAssured", typeof(System.String));
            dtTermInsurance.Columns.Add("Description", typeof(System.String));
            dtTermInsurance.Columns.Add("InsuranceCompanyName", typeof(System.String));
            dtTermInsurance.Columns.Add("Term", typeof(System.String));
            dtTermInsurance.Columns.Add("SumAssured", typeof(System.String));
            dtTermInsurance.Columns.Add("Premium", typeof(System.Double));
        }
    }
}
