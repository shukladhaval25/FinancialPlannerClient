﻿using FinancialPlanner.Common.Model;
using FinancialPlannerClient.PlannerInfo;
using FinancialPlannerClient.RiskProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlannerClient.PlanOptions
{
    public class GoalCalculationManager
    {
        private int _planId;
        private Planner _planner;
        private RiskProfileInfo _riskProfileInfo;
        private int _riskProfileId;

        public IList<Goals> GoalsList;
        private IList<GoalsValueCalculationInfo> _goalsValuecalculationInfo = 
            new List<GoalsValueCalculationInfo>();
        private IList<GoalPlanning> _goalPlanning = new List<GoalPlanning>();
        public GoalCalculationManager(Planner planner, RiskProfileInfo  riskProfileInfo,int riskProfileId)
        {
            _planner = planner;
            _planId = _planner.ID;
            _riskProfileInfo = riskProfileInfo;
            _riskProfileId = riskProfileId;
        }

        public IList<GoalsValueCalculationInfo> GetGoalValueCalculations()
        {
            if (GoalsList != null)
            {
                foreach (Goals goal in GoalsList)
                {
                    GoalsValueCalculationInfo goalsValueInfo = new GoalsValueCalculationInfo(goal,_planner,_riskProfileInfo,_riskProfileId);
                    _goalsValuecalculationInfo.Add(goalsValueInfo);
                }
            }
            return _goalsValuecalculationInfo;
        }

        public GoalsValueCalculationInfo GetGoalValueCalculation(Goals goal)
        {
            GoalsValueCalculationInfo goalsValueInfo = new GoalsValueCalculationInfo(goal,_planner,_riskProfileInfo,_riskProfileId);
            _goalsValuecalculationInfo.Add(goalsValueInfo);
            return goalsValueInfo;
        }

        public IList<GoalPlanning> GetGoalPlanning()
        {
            if (GoalsList != null)
            {
                foreach (Goals goal in GoalsList)
                {
                    GoalPlanning goalPlanning = new GoalPlanning(goal);
                    _goalPlanning.Add(goalPlanning);
                }
            }
            return _goalPlanning;
        }

        private void fetchAllGols()
        {
            GoalsList = new GoalsInfo().GetAll(_planId);
        }

    }
}
