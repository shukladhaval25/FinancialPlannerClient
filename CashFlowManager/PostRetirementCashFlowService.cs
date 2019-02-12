using FinancialPlanner.Common.Model;
using FinancialPlannerClient.PlannerInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlannerClient.CashFlowManager
{
    public class PostRetirementCashFlowService
    {
        PersonalInformation personalInformation;
        PlannerAssumption plannerAssumption;
        CashFlowCalculation cashFlowCalculation;
        Planner planner;

        int retirementPlanningYearStartFrom;
        int expectedLifeEndYear;
        private DataTable _dtRetirementCashFlow;

        public PostRetirementCashFlowService(PersonalInformation personalInformation,Planner planner)
        {
            this.personalInformation = personalInformation;
            this.planner = planner;
            loadPlannerAssumption();
            generateCashFlowCalculationData();
            this.retirementPlanningYearStartFrom = getRetirementYear();
            this.expectedLifeEndYear = getExpectedLifeEndYear();
        }
        public CashFlowCalculation GetCashFlowCalculationData()
        {
            return cashFlowCalculation;
        }
        private void loadPlannerAssumption()
        {
            plannerAssumption = new PlannerAssumptionInfo().GetAll(this.planner.ID);
        }
        private void generateCashFlowCalculationData()
        {
            cashFlowCalculation = new CashFlowCalculation();
            cashFlowCalculation.Cid = personalInformation.Client.ID;
            cashFlowCalculation.ClientName = personalInformation.Client.Name;
            cashFlowCalculation.ClientDateOfBirth = personalInformation.Client.DOB;
            cashFlowCalculation.ClientRetirementAge = plannerAssumption.ClientRetirementAge;
            cashFlowCalculation.IslientRetirmentAgeForPrimaryCalculation = 
                plannerAssumption.IsClientRetirmentAgeIsPrimary;
            cashFlowCalculation.ClientLifeExpected = plannerAssumption.ClientLifeExpectancy;

            cashFlowCalculation.Sid = personalInformation.Spouse.ID;
            cashFlowCalculation.SpouseName = personalInformation.Spouse.Name;
            cashFlowCalculation.SpouseDateOfBirth = personalInformation.Spouse.DOB;
            cashFlowCalculation.SpouseRetirementAge = plannerAssumption.SpouseRetirementAge;
            cashFlowCalculation.SpouseLifeExpected = plannerAssumption.SpouseLifeExpectancy;
        }
        private int getRetirementYear()
        {
            int year = cashFlowCalculation.IslientRetirmentAgeForPrimaryCalculation ?
                 DateTime.Now.Year + (cashFlowCalculation.ClientRetirementAge - cashFlowCalculation.ClientCurrentAge) :
                 DateTime.Now.Year + (cashFlowCalculation.SpouseRetirementAge - cashFlowCalculation.SpouseCurrentAge);
            return year;
        }
        private int getExpectedLifeEndYear()
        {
            int year = cashFlowCalculation.IslientRetirmentAgeForPrimaryCalculation ?
                 DateTime.Now.Year + (cashFlowCalculation.ClientLifeExpected - cashFlowCalculation.ClientCurrentAge) :
                 DateTime.Now.Year + (cashFlowCalculation.SpouseLifeExpected - cashFlowCalculation.SpouseCurrentAge);
            return year;
        }
        private void createRetiremtnCashFlowTable()
        {
            _dtRetirementCashFlow = new DataTable();
            _dtRetirementCashFlow.Columns.Add("StartYear", typeof(System.Int16));
            _dtRetirementCashFlow.Columns.Add("EndYear", typeof(System.Int16));
            _dtRetirementCashFlow.Columns.Add("ClientCurrentAge", typeof(System.Int16));
            _dtRetirementCashFlow.Columns.Add("SpouseCurrentAge", typeof(System.Int16));
        }
        public DataTable GetPostRetirementCashFlowData()
        {
            createRetiremtnCashFlowTable();
            for (int i = retirementPlanningYearStartFrom + 1; i<= expectedLifeEndYear;i++)
            {
                DataRow dr = _dtRetirementCashFlow.NewRow();
                dr["StartYear"] = i;
                dr["EndYear"] = i + 1;
                if (cashFlowCalculation.ClientLifeExpected >= (i - personalInformation.Client.DOB.Year))
                    dr["ClientCurrentAge"] = (i - personalInformation.Client.DOB.Year);
                if (cashFlowCalculation.SpouseLifeExpected >= (i - personalInformation.Spouse.DOB.Year))
                    dr["SpouseCurrentAge"] = (i - personalInformation.Spouse.DOB.Year);
                _dtRetirementCashFlow.Rows.Add(dr);
            }
            return _dtRetirementCashFlow;
        }
    }
}
