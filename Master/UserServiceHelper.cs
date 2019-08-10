using FinancialPlanner.Common.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FinancialPlannerClient.Master
{
    public class UserServiceHelper
    {
        private const string USERAPI = "User";
        private const string USER_DELETE_API = "User/Remove";

        public List<User> GetAll()
        {
            List<User> users = new List<User>();
            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
            string apiurl = Program.WebServiceUrl + "/" + USERAPI;

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(apiurl);
            request.Method = "GET";
            String userResultJson = String.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);
                userResultJson = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
            }
            var userCollection = jsonSerialization.DeserializeFromString<Result<List<User>>>(userResultJson);

            if (userCollection.Value != null)
            {
                users =  userCollection.Value;
            }
            return users;
        }

        public bool Delete(User user)
        {
            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
            string apiurl = Program.WebServiceUrl + "/" + USER_DELETE_API;

            string DATA = jsonSerialization.SerializeToString<User>(user);

            WebClient client = new WebClient();
            client.Headers["Content-type"] = "application/json";
            client.Encoding = Encoding.UTF8;
            string json = client.UploadString(apiurl, "POST", DATA);

            if (json != null)
            {
                var resultObject = jsonSerialization.DeserializeFromString<Result>(json);
                return (resultObject.IsSuccess);
            }
            return false;
        }
    }
}
