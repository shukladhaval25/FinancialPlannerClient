using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using System;
using System.Collections.Generic;
using System.Data;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class PersonalAccidentalInsurancePage : DevExpress.XtraReports.UI.XtraReport
    {
        string description = "* We recommend you to take Personal Accident Insurance policy for {0} please find below stated qutoes for your reference.";

        Client client;
        Planner planner;
        DataTable dtTermInsurance;
        DataSet ds;
        public PersonalAccidentalInsurancePage(Client client, Planner planner)
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
            PersonalAccidentalInsuranceInfo insuranceRecomendationInfo = new PersonalAccidentalInsuranceInfo();
            IList<PersonalAccidentInsurance> insuranceRecomendationTransactions = insuranceRecomendationInfo.GetAll(this.planner.ID);
            createTermInsuranceTable();
            if (insuranceRecomendationTransactions != null)
            {
                //foreach(PersonalAccidentalInsuranceInfo recomendationTransaction in insuranceRecomendationTransactions)
                //{
                    foreach (PersonalAccidentInsurance personalAccidentInsurance in insuranceRecomendationTransactions)
                    {
                        DataRow dr = dtTermInsurance.NewRow();
                        dr["Name"] = personalAccidentInsurance.Name;
                        //dr["InuRecMasterSumAssured"] = recomendationTransaction.SumAssured;
                        //dr["Description"] = recomendationTransaction.Description;
                        dr["InsuranceCompanyName"] = personalAccidentInsurance.InsuranceCompanyName;
                        dr["SumAssured"] = personalAccidentInsurance.SumAssured;
                        //dr["Term"] = insuranceRecomendationDetail.Term;
                        dr["Premium"] = personalAccidentInsurance.Premium;
                        dtTermInsurance.Rows.Add(dr);
                    }
                //}
                //dtTermInsurance = ListtoDataTable.ToDataTable((List<InsuranceRecomendationDetail>)insuranceRecomendationTransactions.);
                dtTermInsurance.TableName = "TermInsurance";
                ds = new DataSet();
                ds.Tables.Add(dtTermInsurance);
                this.DataSource = ds;
                this.DataMember = ds.Tables[0].TableName;
                this.lblName.DataBindings.Add("Text", this.DataSource, "TermInsurance.Name");
                //this.lblSumAssuredGrp.DataBindings.Add("Text", this.DataSource, "TermInsurance.InuRecMasterSumAssured");
                lblInsuranceCompanyName.DataBindings.Add("Text", this.DataSource, "TermInsurance.InsuranceCompanyName");
                //lblTerms.DataBindings.Add("Text", this.DataSource, "TermInsurance.Term");
                lblSumAssured.DataBindings.Add("Text", this.DataSource, "TermInsurance.SumAssured");
                lblPremium.DataBindings.Add("Text", this.DataSource, "TermInsurance.Premium");
                string name = "";
                int count = 0;
                foreach (PersonalAccidentInsurance personalAccidentInsurance in insuranceRecomendationTransactions)
                {
                    if (count == 0)
                    {
                        name = personalAccidentInsurance.Name;
                    }
                    else
                    {
                        name = name + " and " + personalAccidentInsurance.Name;
                    }
                    count++;
                }
                    lblDescription.Text = string.Format(description, name);
                //GroupHeader1.GroupFields[0].FieldName = "Name";
                //GroupHeader1.GroupFields[1].FieldName = "InuRecMasterSumAssured";
            }
        }

        private void createTermInsuranceTable()
        {
            dtTermInsurance = new DataTable();
            //dtTermInsurance.Columns.Add("Id", typeof(System.Int64));
            dtTermInsurance.Columns.Add("Name", typeof(System.String));
            //dtTermInsurance.Columns.Add("InuRecMasterSumAssured", typeof(System.String));
            //dtTermInsurance.Columns.Add("Description", typeof(System.String));
            dtTermInsurance.Columns.Add("InsuranceCompanyName", typeof(System.String));
            //dtTermInsurance.Columns.Add("Term", typeof(System.String));
            dtTermInsurance.Columns.Add("SumAssured", typeof(System.String));
            dtTermInsurance.Columns.Add("Premium", typeof(System.Double));
        }
    }
}
