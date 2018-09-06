using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlannerClient.PlannerInfo
{
    public class ClientContactInfo
    {
        public string GET_CLIENT_CONTACT_API =  "ClientContact/Get?id={0}";
        public string UPDATE_CONTACT_API = "ClientContact/Update";

        public ClientContact Get(int clientId)
        {
            ClientContact clientContactObj = new ClientContact();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ string.Format(GET_CLIENT_CONTACT_API,clientId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<Client>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    clientContactObj = jsonSerialization.DeserializeFromString<ClientContact>(restResult.ToString());
                }
                return clientContactObj;
            }
            catch (Exception ex)
            {
                Logger.LogDebug(ex);
                return null;
            } 
        }
        public bool Update(ClientContact clientContact)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ UPDATE_CONTACT_API;

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<ClientContact>(apiurl, clientContact, "POST");

                return true;
            }
            catch (Exception ex)
            {
                Logger.LogDebug(ex);
                return false;
            }
        }
    }
}
