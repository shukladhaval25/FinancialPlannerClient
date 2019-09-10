using DevExpress.XtraEditors;
using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlannerClient.Users
{
    public class UserInfo
    {
        private const string USERAPI = "User";
        private const string USERBYID = "User?Id={0}";
        public List<FinancialPlanner.Common.Model.User> GetAll()
        {
            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
            string apiurl = Program.WebServiceUrl + "/" + USERAPI;

            RestAPIExecutor restApiExecutor = new RestAPIExecutor();

            var restResult = restApiExecutor.Execute<List<FinancialPlanner.Common.Model.User>>(apiurl, null, "GET");

            if (jsonSerialization.IsValidJson(restResult.ToString()))
            {
                return jsonSerialization.DeserializeFromString<List<FinancialPlanner.Common.Model.User>>(restResult.ToString());
            }
            else
            {
                XtraMessageBox.Show(restResult.ToString(), "Error");
                return null;
            }
        }
        public FinancialPlanner.Common.Model.User GetById(int userId)
        {
            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
            string apiurl = Program.WebServiceUrl + "/" + string.Format(USERBYID,userId);

            RestAPIExecutor restApiExecutor = new RestAPIExecutor();

            var restResult = restApiExecutor.Execute<FinancialPlanner.Common.Model.User>(apiurl, null, "GET");

            if (jsonSerialization.IsValidJson(restResult.ToString()))
            {
                return jsonSerialization.DeserializeFromString<FinancialPlanner.Common.Model.User>(restResult.ToString());
            }
            else
            {
                XtraMessageBox.Show(restResult.ToString(), "Error");
                return null;
            }
        }
    }
}
