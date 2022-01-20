using FinancialPlanner.Common.Model;
using FinancialPlannerClient.CurrentStatus;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FinancialPlannerClient.PlannerInfo;
using FinancialPlanner.Common.DataConversion;
using FinancialPlannerClient.RiskProfile;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public class ExecutionSheetInfo
    {
        DataTable dtExecution;
        Planner planner;
        int optionId;
        int riskProfileId;
        DataTable _dtCurrentStatustoGoals;
        DataTable dtGoalMapped;
        Double contigencyFund = 0;
        public ExecutionSheetInfo()
        {
            this.dtExecution = new DataTable();
        }
        public ExecutionSheetInfo(Client client, Planner planner, int OptionId, int riskprofileId)
        {
            this.planner = planner;
            this.optionId = OptionId;
            this.riskProfileId = riskprofileId;
            getExecutionCalcuation();
        }

        public DataTable GetExeuctionSheetTable()
        {
            return dtExecution;
        }

        private void getExecutionCalcuation()
        {
          


            dtExecution = new DataTable();
            dtExecution.Columns.Add("GoalName");
            dtExecution.Columns.Add("TotalAmount", typeof(System.Double));
            dtExecution.Columns.Add("EquityPercentage", typeof(System.Double));
            dtExecution.Columns.Add("EquityAmount", typeof(System.Double));
            dtExecution.Columns.Add("DebtPercentage", typeof(System.Double));
            dtExecution.Columns.Add("DebtAmount", typeof(System.Double));
            dtExecution.Columns.Add("FinalTotal", typeof(System.Double));

            contigencyFund = new CurrentStatusInfo().GetContingencyFund(this.optionId, this.planner.ID).Amount;
            addContigencyRow(contigencyFund);
            addGoalsInformation();
        }

        private void addGoalsInformation()
        {
            GoalsInfo GoalsInfo = new GoalsInfo();
            List<Goals> lstGoal = (List<Goals>)GoalsInfo.GetAll(planner.ID);
            lstGoal = lstGoal.OrderBy(x => x.Priority).ToList();
            //dtExecution = ListtoDataTable.ToDataTable(lstGoal);

            IList<FinancialPlanner.Common.Model.PlanOptions.CurrentStatusToGoal> currentStatusToGoal =
                    new List<FinancialPlanner.Common.Model.PlanOptions.CurrentStatusToGoal>();
            currentStatusToGoal = new CurrentStatusInfo().GetCurrentStatusToGoal(this.optionId, this.planner.ID);
            dtGoalMapped = new DataTable();
            if (currentStatusToGoal != null)
            {
                dtGoalMapped = ListtoDataTable.ToDataTable(currentStatusToGoal.ToList());
            }

            RiskProfileInfo riskProfile = new RiskProfileInfo();
            DataTable dtRiskProfileReturn = riskProfile.GetRiskProfileReturnById(riskProfileId);


            if (dtGoalMapped.Rows.Count > 0)
            {
                foreach(Goals goal in lstGoal)
                {
                    DataRow[] dataRows =  dtGoalMapped.Select("GoalId =" + goal.Id);
                    if (dataRows.Count() > 0)
                    {
                        foreach(DataRow dr in dataRows)
                        {
                            double fundAllocation = 0;
                            //int differeceYear = int.Parse(goal.StartYear) - planner.StartDate.Year;
                            //double equityRatio = 0;
                            //double debtRation = 0;

                            //DataRow[] dataRowRiskProfile = dtRiskProfileReturn.Select("YearRemaining ='" + differeceYear + "'");
                            //if (dataRowRiskProfile.Length > 0)
                            //{
                            //    double.TryParse(dataRowRiskProfile[0]["EquityInvestementRatio"].ToString(), out equityRatio);
                            //    double.TryParse(dataRowRiskProfile[0]["DebtInvestementRatio"].ToString(), out debtRation);
                            //}

                            double.TryParse(dr["FundAllocation"].ToString(), out fundAllocation);
                            //DataRow drNew = dtExecution.NewRow();
                            //drNew["GoalName"] = goal.Name;
                            //drNew["TotalAmount"] = fundAllocation;
                            //drNew["EquityPercentage"] = equityRatio;
                            //drNew["EquityAmount"] = (fundAllocation * equityRatio) / 100;
                            //drNew["DebtPercentage"] = debtRation;
                            //drNew["DebtAmount"] = (fundAllocation * debtRation) / 100;
                            //drNew["FinalTotal"] = fundAllocation;
                            //dtExecution.Rows.Add(drNew);

                            addGoalToTable(dtRiskProfileReturn, goal, fundAllocation);
                        }
                    }
                    else if (goal.Name.Trim().Equals("Retirement"))
                    {
                        CurrentStatusToGoal csGoal = new CurrentStatusToGoal();
                        _dtCurrentStatustoGoals = csGoal.CurrentStatusToGoalCalculation(planner.ID);
                        double currentStatusSurpluValue = getTotalCurrentSatusSurplusValue();
                        double totalFundAllocation = getTotalFundAllocationValue();
                        double accessFundForRetirmentGoal = currentStatusSurpluValue - (totalFundAllocation + contigencyFund);

                        addGoalToTable(dtRiskProfileReturn, goal, accessFundForRetirmentGoal);
                    }
                    else
                    {
                        DataRow drNew = dtExecution.NewRow();
                        drNew["GoalName"] = goal.Name;
                        drNew["TotalAmount"] = 0;
                        drNew["EquityPercentage"] = 0;
                        drNew["EquityAmount"] = 0;
                        drNew["DebtPercentage"] = 0;
                        drNew["DebtAmount"] = 0;
                        drNew["FinalTotal"] = 0;
                        dtExecution.Rows.Add(drNew);
                    }
                }
            }
            else
            {
                Goals goal = lstGoal.First(x => x.Category.ToLower().Equals("retirement"));
                if (goal != null)
                {
                    CurrentStatusToGoal csGoal = new CurrentStatusToGoal();
                    _dtCurrentStatustoGoals = csGoal.CurrentStatusToGoalCalculation(planner.ID);
                    double currentStatusSurpluValue = getTotalCurrentSatusSurplusValue();
                    double totalFundAllocation = getTotalFundAllocationValue();
                    double accessFundForRetirmentGoal = currentStatusSurpluValue - (totalFundAllocation + contigencyFund);

                    addGoalToTable(dtRiskProfileReturn, goal, accessFundForRetirmentGoal);
                }
            }
        }

        private void addGoalToTable(DataTable dtRiskProfileReturn, Goals goal, double accessFundForRetirmentGoal)
        {
            double fundAllocation = 0;
            int differeceYear = int.Parse(goal.StartYear) - planner.StartDate.Year;
            double equityRatio = 0;
            double debtRation = 0;

            DataRow[] dataRowRiskProfile = dtRiskProfileReturn.Select("YearRemaining ='" + differeceYear + "'");
            if (dataRowRiskProfile.Length > 0)
            {
                double.TryParse(dataRowRiskProfile[0]["EquityInvestementRatio"].ToString(), out equityRatio);
                double.TryParse(dataRowRiskProfile[0]["DebtInvestementRatio"].ToString(), out debtRation);
            }

            fundAllocation = accessFundForRetirmentGoal;
            DataRow drNew = dtExecution.NewRow();
            drNew["GoalName"] = goal.Name;
            drNew["TotalAmount"] = fundAllocation;
            drNew["EquityPercentage"] = equityRatio;
            drNew["EquityAmount"] = (fundAllocation * equityRatio) / 100;
            drNew["DebtPercentage"] = debtRation;
            drNew["DebtAmount"] = (fundAllocation * debtRation) / 100;
            drNew["FinalTotal"] = fundAllocation;
            dtExecution.Rows.Add(drNew);
        }

        private void addContigencyRow(double contigencyFund)
        {
            DataRow dr = dtExecution.NewRow();
            dr["GoalName"] = "Contingency Fund";
            dr["TotalAmount"] = contigencyFund;
            dr["EquityPercentage"] = 0;
            dr["EquityAmount"] = 0;
            dr["DebtPercentage"] = 100;
            dr["DebtAmount"] = contigencyFund;
            dr["FinalTotal"] = contigencyFund;
            dtExecution.Rows.Add(dr);
        }

        private double getTotalCurrentSatusSurplusValue()
        {
            double totalCurrentStatusValue = 0;
            if (_dtCurrentStatustoGoals.Rows.Count > 0)
            {
                totalCurrentStatusValue = string.IsNullOrEmpty(_dtCurrentStatustoGoals.Rows[0]["ExcessFund"].ToString()) ? 0 :
                    double.Parse(_dtCurrentStatustoGoals.Rows[0]["ExcessFund"].ToString());

                //string mappedValue = _dtCurrentStatustoGoals.Compute("Sum(CurrentStatusMappedAmount)", string.Empty).ToString();
                double alreadyMappedValue = _dtCurrentStatustoGoals.AsEnumerable().Sum(x => Convert.ToDouble(x["CurrentStatusMappedAmount"]));
                totalCurrentStatusValue = totalCurrentStatusValue + alreadyMappedValue;
            }
            return Math.Round(totalCurrentStatusValue, 2);
        }

        private double getTotalFundAllocationValue()
        {
            double alredyMappedValue = _dtCurrentStatustoGoals.AsEnumerable().Sum(x => Convert.ToDouble(x["CurrentStatusMappedAmount"]));
            double mappedByProjetManager = dtGoalMapped.AsEnumerable().Sum(x => Convert.ToDouble(x["FundAllocation"]));
            return alredyMappedValue + mappedByProjetManager;
        }
    }
}
