using FinancialPlanner.Common;
using FinancialPlanner.Common.Model.Masters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace FinancialPlannerClient.Master
{
    public partial class ClientRatingView : DevExpress.XtraEditors.XtraForm
    {

        const string GET_All_API = "ClientRating/GetAll";
        const string ADD_ClientRating_API = "ClientRating/Add";
        const string DELETE_ClientRating_API = "ClientRating/Delete";

        List<ClientRating> clientRatings;
        public ClientRatingView()
        {
            InitializeComponent();
        }

        private void ClientRatingView_Load(object sender, EventArgs e)
        {
            Program.ApplyPermission(this.Text, this);
            grpRatingDetail.Enabled = false;
            fillListRating();
        }
        

        private void fillListRating()
        {
            try
            {
                lstRating.Items.Clear();
                clientRatings = GetAll().ToList();
                if (clientRatings.Count > 0)
                {
                    clientRatings.ForEach(i => lstRating.Items.Add(i.Rating));                   
                }
            }
            catch(Exception ex)
            {
                Logger.LogDebug(ex);
            }
        }

        public IList<ClientRating> GetAll()
        {
            IList<ClientRating> ClientRatingObj = new List<ClientRating>();
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + string.Format(GET_All_API);

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<ClientRating>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    ClientRatingObj = jsonSerialization.DeserializeFromString<IList<ClientRating>>(restResult.ToString());
                }
                return ClientRatingObj;
            }
            catch (Exception ex)
            {
                Logger.LogDebug(ex);
                return null;
            }
        }

        internal bool Delete(ClientRating fest)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + DELETE_ClientRating_API;

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<ClientRating>(apiurl, fest, "DELETE");

                return true;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                return false;
            }
        }

        private bool Add(ClientRating ClientRating)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + ADD_ClientRating_API;

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<ClientRating>(apiurl, ClientRating, "POST");

                return true;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                return false;
            }
        }
        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }

        private void lstRating_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstRating.SelectedItems.Count > 0)
            {
                txtRating.Text = lstRating.SelectedValue.ToString();
                grpRatingDetail.Enabled = true;
            }
            else
                grpRatingDetail.Enabled = false;
        }

        private void btnSaveClient_Click(object sender, EventArgs e)
        {
            if (txtRating.Text == "")
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Please enter client rating value.", "Validate", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            ClientRating clientRating = new ClientRating();
            clientRating.Rating = txtRating.Text;
            clientRating.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            clientRating.CreatedBy = Program.CurrentUser.Id;
            clientRating.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            clientRating.UpdatedBy = Program.CurrentUser.Id;
            clientRating.UpdatedByUserName = Program.CurrentUser.UserName;
            clientRating.MachineName = System.Environment.MachineName;

            if (Add(clientRating))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Record save successfully.", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fillListRating();
            }
            else
            {                
                DevExpress.XtraEditors.XtraMessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCloseClientInfo_Click(object sender, EventArgs e)
        {
            txtRating.Text = "";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grpRatingDetail.Enabled = true;
            txtRating.Text = "";
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (lstRating.SelectedItems.Count > 0)
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this record?",
                    "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    ClientRating clientRating = new ClientRating();
                    clientRating.Rating = txtRating.Text;
                    Delete(clientRating);
                    fillListRating();
                }
            }
        }
    }
}
