using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class TermInsurance : DevExpress.XtraReports.UI.XtraReport
    {
        string description = "* We recommend taking a Term Plan of Rs. {0} for {1} yrs." + Environment.NewLine + "Please find below stated quotes for your reference.";

        Client client;
        Planner planner;
        DataTable dtTermInsurance;
        DataSet ds;
        public TermInsurance(Client client, Planner planner)
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
            InsuranceRecomendationInfo insuranceRecomendationInfo = new InsuranceRecomendationInfo();
            IList<InsuranceRecomendationTransaction> insuranceRecomendationTransactions = insuranceRecomendationInfo.GetAll(this.planner.ID);
            if (insuranceRecomendationTransactions != null)
            {
                //dtTermInsurance = ListtoDataTable.ToDataTable((List<InsuranceRecomendationDetail>)insuranceRecomendationTransactions.);
                //dtTermInsurance.TableName = "TermInsurance";
                //ds = new DataSet();
                //ds.Tables.Add(dtTermInsurance);
                //this.DataSource = ds;
                //this.DataMember = ds.Tables[0].TableName;
                //this.lblPersonName.DataBindings.Add("Text", this.DataSource, "FamilyMember.Name");
            }
        }
    }
}
