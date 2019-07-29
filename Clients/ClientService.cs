using DevExpress.XtraEditors;
using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlannerClient.Clients
{
    public class ClientService
    {
        private const string CLIENTS_GETALL = "Client/Get";
        public IList<Client> GetAll()
        {
            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
            string apiurl = Program.WebServiceUrl + "/" + CLIENTS_GETALL;

            RestAPIExecutor restApiExecutor = new RestAPIExecutor();

            var restResult = restApiExecutor.Execute<List<Client>>(apiurl, null, "GET");

            if (jsonSerialization.IsValidJson(restResult.ToString()))
            {
                return jsonSerialization.DeserializeFromString<List<Client>>(restResult.ToString());
            }
            else
            {
                XtraMessageBox.Show(restResult.ToString(), "Error");
                return null;
            }
        }
    }
}
