using FinancialPlanner.Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialPlannerClient.ProspectCustomer
{
    public partial class frmProspectCustomerConversation : Form
    {
        private ProspectClient _prospCustomer;
        private ProspectClientConversation _prospCustomerConversation;
        private const string ADD_CONVERSATION_API ="ProspectClient/AddConversation";
        private const string UPDATE_CONVERSATION_API ="ProspectClient/UpdateConversation";

        public frmProspectCustomerConversation(ProspectClient prospectCustomer)
        {
            InitializeComponent();
            _prospCustomer = prospectCustomer;           
        }

        public frmProspectCustomerConversation(ProspectClient prospectCustomer,int conversationId)
        {
            InitializeComponent();
            _prospCustomer = prospectCustomer;
            _prospCustomerConversation =  _prospCustomer.ProspectClientConversationList.First(i => i.ID == conversationId);
        }

        private void ProspectCustomerConversation_Load(object sender, EventArgs e)
        {
            if (_prospCustomer == null)
            {
                MessageBox.Show("Please select valid customer for doing transaction further.", "Invalid Customer", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (_prospCustomerConversation != null)
            {
                fillConvesationDetails();
            }
            fillCustomerDetail();
        }

        private void fillCustomerDetail()
        {
            lblName.Text = _prospCustomer.Name;
        }

        private void fillConvesationDetails()
        {
            dtConversation.Value = _prospCustomerConversation.ConversationDate;
            txtConversationBy.Text = _prospCustomerConversation.ConversationBy;
            txtRemarks.Text = _prospCustomerConversation.Remarks;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            updateConversation();
        }
       
        private void updateConversation()
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = string.Empty;

                ProspectClientConversation prosClientConv = new ProspectClientConversation()
                {
                    ProspectClientId = _prospCustomer.ID,
                    ConversationBy = txtConversationBy.Text,
                    ConversationDate = dtConversation.Value,
                    Remarks = txtRemarks.Text,
                    CreatedOn = DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")),
                    CreatedBy = Program.CurrentUser.Id,
                    UpdatedOn =  DateTime.Parse( DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")),
                    UpdatedBy = Program.CurrentUser.Id,
                    UpdatedByUserName = Program.CurrentUser.UserName,
                    MachineName = System.Environment.MachineName
                };

                if (_prospCustomerConversation == null)
                {
                    apiurl = Program.WebServiceUrl + "/" + ADD_CONVERSATION_API;
                }
                else
                {
                    apiurl = Program.WebServiceUrl + "/" + UPDATE_CONVERSATION_API;
                    prosClientConv.ID = _prospCustomerConversation.ID;
                }

                string DATA =  jsonSerialization.SerializeToString<ProspectClientConversation>(prosClientConv);

                WebClient client = new WebClient();
                client.Headers["Content-type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                string json = client.UploadString(apiurl, DATA);

                if (json != null)
                {
                    var resultObject = jsonSerialization.DeserializeFromString<Result>(json);
                    if (resultObject.IsSuccess)
                    {
                        MessageBox.Show("Record save successfully.","Record Saved",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
