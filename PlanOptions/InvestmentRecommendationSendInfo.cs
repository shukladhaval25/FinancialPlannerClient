using FinancialPlanner.Common;
using FinancialPlanner.Common.Model.PlanOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlannerClient.PlanOptions
{
    public class InvestmentRecommendationSendInfo
    {
        private readonly string GET_INVESTMENT_RECOMMENDATION_SEND = "InvestmentRecommendationController/Get?plannerId={0}";

        private readonly string ADD_INVESTMENT_RECOMMENDATION_SEND = "InvestmentRecommendationController/AddSendReport";

        public bool AddInvRecommendationSend(InvRecommendationSend invRecommendationSend)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = "";
                apiurl = Program.WebServiceUrl + "/" + ADD_INVESTMENT_RECOMMENDATION_SEND;

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<InvRecommendationSend>(apiurl, invRecommendationSend, "POST");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
