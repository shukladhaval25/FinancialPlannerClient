using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Net;

namespace FinancialPlannerClient.PlannerInfo
{
    public class PlannerInfo
    {
        private const string GET_PLAN_BY_CLIENTID_API = "Planner/GetByClientId?id={0}";

        internal DataTable GetPlanData(int ClientId)
        {
            return loadPlanData(ClientId);
        }
        private DataTable loadPlanData(int ClientId)
        {
            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
            string apiurl = Program.WebServiceUrl +"/"+ string.Format(GET_PLAN_BY_CLIENTID_API,ClientId);

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(apiurl);
            request.Method = "GET";
            String planerResultJson = String.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);
                planerResultJson = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
            }
            var plannerCollection = jsonSerialization.DeserializeFromString<Result<List<Planner>>>(planerResultJson);

            if (plannerCollection.Value != null)
            {
                return ListtoDataTable.ToDataTable(plannerCollection.Value);
            }
            return null;
        }
    }
}
