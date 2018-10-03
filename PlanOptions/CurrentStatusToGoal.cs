using FinancialPlanner.Common.Model;
using FinancialPlannerClient.CurrentStatus;
using FinancialPlannerClient.PlannerInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlannerClient.PlanOptions
{
    internal class CurrentStatusToGoal
    {
        IList<Goals> goals;
        DataTable _dtmoneyToGoals;
        CurrentStatusInfo csInfo = new CurrentStatusInfo();
        int _planId;

        internal void GetGoals(int planId)
        {
            goals = new GoalsInfo().GetAll(planId);
        }

        internal DataTable CurrentStatusToGoalCalculation(int planId)
        {
            _planId = planId;
            GetGoals(planId);
            createTableStructureForMontyToGoals();
            addRowInMoneyToGoalsTable();
            return _dtmoneyToGoals;
        }

        private void addRowInMoneyToGoalsTable()
        {
            DataRow dr = _dtmoneyToGoals.NewRow();
            dr["GoalId"] = 0;
            dr["Goal"] = "MONEY TO BE USED IN GOALS";
            dr["FundAllocation"] = 0;
            dr["CurrentStatusMappedAmount"] = 0;
            dr["ExcessFund"] = getExcessFundFromCurrentStatus();
            _dtmoneyToGoals.Rows.Add(dr);

            foreach (Goals goal in goals)
            {
                dr = _dtmoneyToGoals.NewRow();
                dr["GoalId"] = goal.Id;
                dr["Goal"] = goal.Name;
                double csAllocatedFund = getCurrentStatusFundForMappedGoal(goal.Id);
                dr["CurrentStatusMappedAmount"] = csAllocatedFund;
                dr["ExcessFund"] = double.Parse(_dtmoneyToGoals.Rows[_dtmoneyToGoals.Rows.Count - 1]["ExcessFund"].ToString()) - csAllocatedFund;
                _dtmoneyToGoals.Rows.Add(dr);
            }

            dr = _dtmoneyToGoals.NewRow();
            dr["GoalId"] = 0;
            dr["Goal"] = "Retirement Corpus";
            dr["FundAllocation"] = 0;
            dr["CurrentStatusMappedAmount"] = 0;
            dr["ExcessFund"] = double.Parse(_dtmoneyToGoals.Rows[_dtmoneyToGoals.Rows.Count - 1]["ExcessFund"].ToString());
            _dtmoneyToGoals.Rows.Add(dr);
        }

        private double getCurrentStatusFundForMappedGoal(int id)
        {
            return csInfo.GetFundFromCurrentStatus(_planId, id);
        }

        private double getExcessFundFromCurrentStatus(int goalId = 0)
        {
           return csInfo.GetFundFromCurrentStatus(_planId,goalId);
        }

        private void createTableStructureForMontyToGoals()
        {
            if (_dtmoneyToGoals == null)
                _dtmoneyToGoals = new DataTable();

            DataColumn dcId = new DataColumn("GoalId",typeof(System.Int16));
            dcId.ReadOnly = true;
            _dtmoneyToGoals.Columns.Add(dcId);

            DataColumn dcGoal = new DataColumn("Goal",typeof(System.String));
            dcGoal.ReadOnly = true;
            _dtmoneyToGoals.Columns.Add(dcGoal);

            DataColumn dcMappedAmt = new DataColumn("CurrentStatusMappedAmount",typeof(System.String));
            dcGoal.ReadOnly = true;
            _dtmoneyToGoals.Columns.Add(dcMappedAmt);

            DataColumn dcFundAllocation = new DataColumn("FundAllocation",typeof(System.Double));
            dcGoal.ReadOnly = true;
            _dtmoneyToGoals.Columns.Add(dcFundAllocation);

            DataColumn dcExceesFund = new DataColumn("ExcessFund",typeof(System.Double));
            dcGoal.ReadOnly = true;
            _dtmoneyToGoals.Columns.Add(dcExceesFund);
        }
    }
}
