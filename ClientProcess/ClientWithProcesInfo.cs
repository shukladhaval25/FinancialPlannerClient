using FinancialPlanner.Common;
using FinancialPlanner.Common.Planning;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlannerClient.ClientProcess
{
    class ClientWithProcesInfo
    {
        const string GET_All_API = "ClientProcess/GetAll";
        const string GET_CLIENTPROCESS_BY_CLIENTID_PLANNERID = "ClientProcess/GetClientProcess?clientId={0}&plannerId={1}";

        public IList<CurrentClientProcess> GetAll()
        {
            IList<CurrentClientProcess> currentClientProcesses = new List<CurrentClientProcess>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + string.Format(GET_All_API);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<CurrentClientProcess>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    currentClientProcesses = jsonSerialization.DeserializeFromString<IList<CurrentClientProcess>>(restResult.ToString());
                }
                return currentClientProcesses;
            }
            catch (Exception ex)
            {
                Logger.LogDebug(ex);
                return null;
            }
        }

        public IList<CurrentClientProcess> GetClientProcess(int clientId,int? plannerId)
        {
            IList<CurrentClientProcess> currentClientProcesses = new List<CurrentClientProcess>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + string.Format(GET_CLIENTPROCESS_BY_CLIENTID_PLANNERID,clientId,plannerId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<CurrentClientProcess>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    currentClientProcesses = jsonSerialization.DeserializeFromString<IList<CurrentClientProcess>>(restResult.ToString());
                }
                return currentClientProcesses;
            }
            catch (Exception ex)
            {
                Logger.LogDebug(ex);
                return null;
            }
        }
    }
}
