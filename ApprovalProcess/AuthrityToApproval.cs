using FinancialPlanner.Common;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialPlannerClient.ApprovalProcess
{
    public partial class AuthrityToApproval : DevExpress.XtraEditors.XtraForm
    {
        private const string AUTHENTICATIONAPI = "Authentication/AuthenticateClient";
        private const string AUTHENTICATION_FAIL = "Authentication Fail due to invalid credential";
        private const string USERAPI = "User";
        private DataTable _dtUser;

        public AuthrityToApproval(bool isReAssign = false)
        {
            InitializeComponent();
            lblReassignTo.Visible = isReAssign;
            cmbReassignTo.Visible = isReAssign;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            bool isAuthorised = authenticateProcessCall();
            if (isAuthorised)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Invalid Password", "Authentication fail", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private bool authenticateProcessCall()
        {
            try
            {
                string loginUrl = Program.WebServiceUrl + "/" + AUTHENTICATIONAPI;
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();

                User user = getUserObjectFromUI();
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<User>(loginUrl, user, "POST");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    return approveAuthenticationProcess(restResult.ToString());
                }
                else
                    return false;

            }
            catch (Exception ex)
            {
                if (ex.Message.Equals(AUTHENTICATION_FAIL))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logger.LogDebug(ex);
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Exception:" + ex.ToString(), "Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logger.LogDebug(ex);
                }
                return false;
            }
        }

        private bool approveAuthenticationProcess(string restResult)
        {
            JSONSerialization jsonSerialization = new JSONSerialization();
            var deserializeUser = jsonSerialization.DeserializeFromString<User>(restResult.ToString());
            return true;
        }

        private User getUserObjectFromUI()
        {
            User user = new User()
            {
                UserName = Program.CurrentUser.UserName,
                Password = FinancialPlanner.Common.DataEncrypterDecrypter.CryptoEngine.Encrypt(txtPassword.Text),
                MachineName = Environment.MachineName
            };
            return user;
        }

        public string GetDescription()
        {
            return txtDescription.Text;
        }

        public string GetReassignUserId()
        {
            return cmbReassignTo.Tag.ToString();
        }

        private void AuthrityToApproval_Load(object sender, EventArgs e)
        {
            if (cmbReassignTo.Visible )
            {
                loadUserInformation();
            }
        }
        private void loadUserInformation()
        {
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
                _dtUser = ListtoDataTable.ToDataTable(userCollection.Value);
                fillUserList();
            }
        }

        private void fillUserList()
        {
            cmbReassignTo.Properties.Items.Clear();
            for (int i = 0; i <= _dtUser.Rows.Count - 1; i++)
            {
                cmbReassignTo.Properties.Items.Add(_dtUser.Rows[i]["FirstName"].ToString());
            }
        }

        private void cmbReassignTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbReassignTo.Tag = _dtUser.Select("FirstName ='" + cmbReassignTo.Text + "'")[0]["ID"].ToString();
        }
    }
}
