using FinancialPlanner.Common;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model.CurrentStatus;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;

namespace FinancialPlannerClient.CurrentStatus
{
    internal class CurrentStatusInfo
    {
        CurrentStatusCalculation csCal = new CurrentStatusCalculation();
        private readonly string GET_CURRENT_STATUS_API= "CurrentStatusCalculator/Get?plannerId={0}&goalId={1}";
        private readonly string GET_ALL_CURRENT_STATUS_API= "CurrentStatusCalculator/GetALL?plannerId={0}";
        //private readonly string GET_ALL_CURRENT_STATUS_API= "CurrentStatusCalculator/Get?plannerId={0}";


        public CurrentStatusCalculation GetCurrestStatusWithoutGoalMapped(int plannerId,int goalId = 0)
        {
          
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ string.Format(GET_CURRENT_STATUS_API,plannerId,goalId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<CurrentStatusCalculation>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    csCal = jsonSerialization.DeserializeFromString<CurrentStatusCalculation>(restResult.ToString());
                }
                return csCal;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace ();
                StackFrame sf = st.GetFrame (0);
                MethodBase  currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                return null;
            }
        }
        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }

        public CurrentStatusCalculation GetAllCurrestStatus(int plannerId)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ string.Format(GET_ALL_CURRENT_STATUS_API,plannerId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<CurrentStatusCalculation>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    csCal = jsonSerialization.DeserializeFromString<CurrentStatusCalculation>(restResult.ToString());
                }
                return csCal;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace ();
                StackFrame sf = st.GetFrame (0);
                MethodBase  currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                return null;
            }
        }

        public double GetFundFromCurrentStatus(int plannerId,int goalId = 0)
        {
            CurrentStatusCalculation csCal =  GetCurrestStatusWithoutGoalMapped(plannerId,goalId);
            if (csCal != null)
            {
                double totalEquityAmount = csCal.ShresValue +  csCal.EquityMFvalue +
                csCal.NpsEquityValue + csCal.OtherEquityValue;

                double totalDebtAmount = csCal.DebtMFValue +  csCal.FdValue +
                csCal.RdValue + csCal.SaValue + csCal.NpsDebtValue +
                csCal.PPFValue + csCal.EPFValue  + csCal.SSValue +
                csCal.SCSSValue + csCal.BondsValue + csCal.OtherDebtValue;

                double totalGoldAmount  = csCal.GoldValue + csCal.OthersGoldValue;

                double totalCurrentStatusAmount = totalEquityAmount + totalDebtAmount + totalGoldAmount;
                return totalCurrentStatusAmount;
            }
            return 0; 
        }
    }
}
