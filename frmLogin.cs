using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using System;
using System.IO;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace FinancialPlannerClient
{
    public partial class frmLogin : Form
    {
        private const string AUTHENTICATIONAPI = "Authentication/AuthenticateClient";
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string loginUrl = Program.WebServiceUrl +"/"+ AUTHENTICATIONAPI;
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();

                User user = getUserObjectFromUI();
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<User>(loginUrl, user, "POST");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    actionOnValidAuthentication(restResult.ToString());
                }
                else
                    MessageBox.Show(restResult.ToString(), "Login fail", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                Logger.LogDebug(ex);
            }

            //string DATA =  jsonSerialization.SerializeToString<User>(user);



            //WebClient client = new WebClient();
            //client.Headers["Content-type"] = "application/json";
            //client.Encoding = Encoding.UTF8;
            //string json = client.UploadString(loginUrl,"POST", DATA);
            //if (json != null)
            //{
            //    Result<User> resultObject = jsonSerialization.DeserializeFromString<Result<User>>(json);
            //    if (resultObject.IsSuccess && resultObject.Value != null)
            //    {
            //        Program.CurrentUser = resultObject.Value;
            //        Main frmclientMain = new Main();
            //        this.Visible = false;
            //        frmclientMain.ShowDialog();
            //        this.Close();
            //    }
            //    else
            //        MessageBox.Show("Invalid user or credential.", "Login fail", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //}
        }

        private void actionOnValidAuthentication(string restResult)
        {
            JSONSerialization jsonSerialization = new JSONSerialization();
            var deserializeUser = jsonSerialization.DeserializeFromString<User>(restResult.ToString());
            Program.CurrentUser = deserializeUser;
            Main frmclientMain = new Main();
            this.Visible = false;
            frmclientMain.ShowDialog();
            Close();
        }

        private User getUserObjectFromUI()
        {
            User user = new User()
            {
                UserName = txtUserName.Text,
                Password = FinancialPlanner.Common.DataEncrypterDecrypter.CryptoEngine.Encrypt(txtPassword.Text),
                MachineName = Environment.MachineName
            };
            return user;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
