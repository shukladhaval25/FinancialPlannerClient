using FinancialPlanner.Common;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialPlannerClient.PlannerInfo
{
    public class ClientPersonalInfo
    {
        public string GET_CLIENT_PERSONAL_API =  "Client/GetById?id={0}";
        public string GET_SPOUSE_PERSONAL_API = "ClientSpouse/GetById?id={0}";
        public string UPDATE_CLIENTPERSONAL_INFO_API ="Client/Update";
        public string UPDATE_CLIENTSPOUSE_PERSONAL_INFO_API = "ClientSpouse/Update";
        private PersonalInformation _personalInfo;

        public PersonalInformation Get(int clientId)
        {
            _personalInfo = new PersonalInformation();
            _personalInfo.Client = getClientPersonalInfo(clientId);
            _personalInfo.Spouse = getSpousePersonalInfo(clientId);
            return _personalInfo;
        }
        public void Update(PersonalInformation personalInfo)
        {
            bool isUpdateClientPersonalInfo =  updateClientPersonalInfo(personalInfo.Client);
            bool isUpdateClientSpousePersonalInfo = false;
            if (isUpdateClientPersonalInfo)
            {
                isUpdateClientSpousePersonalInfo = updateClientSpousePersonalInfo(personalInfo.Spouse);
                if (isUpdateClientSpousePersonalInfo)
                {
                    MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private bool updateClientSpousePersonalInfo(ClientSpouse spouse)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ UPDATE_CLIENTSPOUSE_PERSONAL_INFO_API;

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<ClientSpouse>(apiurl, spouse, "POST");

                return true;
            }
            catch (Exception ex)
            {
                Logger.LogDebug(ex);
                return false;
            }
        }

        private bool updateClientPersonalInfo(Client client)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ UPDATE_CLIENTPERSONAL_INFO_API;

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<Client>(apiurl, client, "POST");

                return true;
            }
            catch (Exception ex)
            {
                Logger.LogDebug(ex);
                return false;
            }
        }

        private ClientSpouse getSpousePersonalInfo(int clientId)
        {
            ClientSpouse clientSpouseObj = new ClientSpouse();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ string.Format(GET_SPOUSE_PERSONAL_API,clientId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<Client>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    clientSpouseObj = jsonSerialization.DeserializeFromString<ClientSpouse>(restResult.ToString());
                }
                return clientSpouseObj;
            }
            catch (Exception ex)
            {
                Logger.LogDebug(ex);
                return null;
            }
        }

        private Client getClientPersonalInfo(int clientId)
        {
            Client clientObj = new Client();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ string.Format(GET_CLIENT_PERSONAL_API,clientId);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<Client>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    clientObj = jsonSerialization.DeserializeFromString<Client>(restResult.ToString());
                }
                else
                    MessageBox.Show(restResult.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                return clientObj;
            }
            catch (Exception ex)
            {
                Logger.LogDebug(ex);
                return clientObj;
            }
        }
    }
}
