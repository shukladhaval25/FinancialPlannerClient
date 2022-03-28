using FinancialPlanner.Common;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.EmailManager;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.Clients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialPlannerClient.ProspectCustomer
{
    public partial class ProspectCustomer : Form
    {
        private const string CONVERSATIONBY_ID = "ProspectClient/Conversation/GetByProspectClientId?id={0}";
        private const string DELETE_CONVERSATION_API = "ProspectClient/DeleteConversation";
        private const string ADD_PROSPECTCLIENT_API = "ProspectClient/Add";
        private const string UPDATE_PROSPECTCLIENT_API ="ProspectClient/Update";
        private const string USERAPI = "User";

        private ProspectClient _prospectClient;
        private DataTable _dtConversation;
        private DataTable _dtUser;
        IList<Client> clients;

        public ProspectCustomer()
        {
            InitializeComponent();
        }

        public ProspectCustomer(ProspectClient prospClient)
        {
            InitializeComponent();
            _prospectClient = prospClient;
        }

        private void btnShowConversation_Click(object sender, EventArgs e)
        {
            grpConverstion.Visible = true;
            btnShowConversation.Visible = false;
            this.WindowState = FormWindowState.Maximized;
            this.dataGridConversation.Visible = true;
            btnHideConversation.Visible = true;
            getConversationDetails();
        }

        private void getConversationDetails()
        {
            if (_dtConversation != null && _dtConversation.Rows.Count > 0)
                _dtConversation.Clear();

            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
            string apiurl = Program.WebServiceUrl +"/"+ string.Format(CONVERSATIONBY_ID,_prospectClient.ID);

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(apiurl);
            request.Method = "GET";
            String prospClientResultJosn = String.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);
                prospClientResultJosn = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
            }
            var prospClientConversationCollection = jsonSerialization.DeserializeFromString<Result<List<ProspectClientConversation>>>(prospClientResultJosn);

            if (prospClientConversationCollection.Value != null)
            {
                _prospectClient.ProspectClientConversationList = prospClientConversationCollection.Value;
                _dtConversation = ListtoDataTable.ToDataTable(prospClientConversationCollection.Value);
                dataGridConversation.DataSource = _dtConversation;
                gridDisplaySetting();
            }
        }

        private void gridDisplaySetting()
        {
            hideGridColumns();
            setGridHeaderText();
            setGridColumnWidth();
            setGridColumnDisplayIndex();
        }

        private void setGridColumnDisplayIndex()
        {
            dataGridConversation.Columns["Remarks"].DisplayIndex = 1;
            dataGridConversation.Columns["ConversationDate"].DisplayIndex = 2;
        }

        private void setGridColumnWidth()
        {
            dataGridConversation.Columns["ConversationDate"].Width = 130;
            dataGridConversation.Columns["ConversationBy"].Width = 130;
            dataGridConversation.Columns["Remarks"].Width = 550;
            dataGridConversation.Columns["UpdatedOn"].Width = 130;
            dataGridConversation.Columns["UpdatedByUserName"].Width = 130;
        }

        private void setGridHeaderText()
        {
            dataGridConversation.Columns["ConversationDate"].HeaderText = "Conversation On";
            dataGridConversation.Columns["ConversationBy"].HeaderText = "Conversation By";
            dataGridConversation.Columns["UpdatedOn"].HeaderText = "Updated On";
            dataGridConversation.Columns["UpdatedByUserName"].HeaderText = "Updated By";
        }

        private void hideGridColumns()
        {
            dataGridConversation.Columns["ID"].Visible = false;
            dataGridConversation.Columns["ProspectClientId"].Visible = false;
            dataGridConversation.Columns["CreatedBy"].Visible = false;
            dataGridConversation.Columns["CreatedOn"].Visible = false;
            dataGridConversation.Columns["UpdatedBy"].Visible = false;
            dataGridConversation.Columns["MachineName"].Visible = false;
        }

        private void btnHideConversation_Click(object sender, EventArgs e)
        {
            grpConverstion.Visible = false;
            this.Height = 350;
            btnHideConversation.Visible = false;
            btnShowConversation.Visible = !btnHideConversation.Visible;
            this.dataGridConversation.Visible = false;

        }

        private void ProspectCustomer_Load(object sender, EventArgs e)
        {
            if (_prospectClient != null)
                fillProspectClient();
            loadUserInformation();
            if (_prospectClient == null)
            {
                btnConvertToClient.Visible = false;
            }
        }

        private void fillProspectClient()
        {
            txtName.Text = _prospectClient.Name;
            txtEvent.Text = _prospectClient.Event;
            txtPhoneNo.Text = _prospectClient.PhoneNo;
            txtEmail.Text = _prospectClient.Email;
            txtOccupation.Text = _prospectClient.Occupation;
            dtEventDate.Value = _prospectClient.EventDate;
            txtRefBy.Text = _prospectClient.ReferedBy;
            txtRemark.Text = _prospectClient.Remarks;
            chkStopSendingEmail.Checked = _prospectClient.StopSendingEmail;
            chkIntroductionCompleted.Checked = _prospectClient.IntroductionCompleted;
            if (chkIntroductionCompleted.Checked)
                dtIntroductionCompletdOn.Value = _prospectClient.IntroductionCompletedDate;
            getConversationDetails();
            
        }

        private void btnAddConversation_Click(object sender, EventArgs e)
        {
            frmProspectCustomerConversation frmProspCustomerConversation =
                new frmProspectCustomerConversation(_prospectClient);

            if (frmProspCustomerConversation.ShowDialog() == DialogResult.OK && btnHideConversation.Visible)
            {
                getConversationDetails();
            }
        }

        private void btnEditConversation_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRowIndex = dataGridConversation.SelectedRows[0].Index;
                int selectedId = int.Parse(dataGridConversation.SelectedRows[0].Cells["ID"].Value.ToString());

                frmProspectCustomerConversation frmProspCustomerConversation =
                new frmProspectCustomerConversation(_prospectClient,selectedId);

                if (frmProspCustomerConversation.ShowDialog() == DialogResult.OK && btnHideConversation.Visible)
                {
                    getConversationDetails();
                }
            }
            catch(Exception ex)
            {
                Logger.LogDebug(ex.ToString());
            }
        }
        private ProspectClientConversation convertSelectedRowDataToConversation()
        {
            ProspectClientConversation prospClinetConv = new ProspectClientConversation();
            if (dataGridConversation.SelectedRows.Count > 0)
            {
                DataRow dr = getSelectedDataRow();
                prospClinetConv.ID = int.Parse(dr.Field<string>("ID"));
                prospClinetConv.ProspectClientId = int.Parse(dr.Field<string>("ProspectClientId"));
                prospClinetConv.ConversationBy = dr.Field<string>("ConversationBy");
                prospClinetConv.ConversationDate = dr.Field<DateTime>("ConversationDate");
                prospClinetConv.Remarks = dr.Field<string>("Remarks");
                prospClinetConv.UpdatedByUserName = Program.CurrentUser.UserName;
            }
            return prospClinetConv;
        }
        private DataRow getSelectedDataRow()
        {
            int selectedRowIndex = dataGridConversation.SelectedRows[0].Index;
            int selectedUserId = int.Parse(dataGridConversation.SelectedRows[0].Cells["ID"].Value.ToString());
            DataRow[] rows = _dtConversation.Select("Id = " + selectedUserId);
            foreach (DataRow dr in rows)
            {
                return dr;
            }
            return null;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int selectedRowIndex = dataGridConversation.SelectedRows[0].Index;
            int selectedId = int.Parse(dataGridConversation.SelectedRows[0].Cells["ID"].Value.ToString());

            if (selectedId <= 0)
            {
                MessageBox.Show("Please select item to perform action.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            if (MessageBox.Show("Are you sure you want to remove record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                removeRecord(selectedId);
            }
        }

        private void removeRecord(int selectedId)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl  = Program.WebServiceUrl + "/" + DELETE_CONVERSATION_API;

                ProspectClientConversation prosClientConv = new ProspectClientConversation()
                {
                    ID = selectedId,
                    ProspectClientId = _prospectClient.ID,
                    MachineName = System.Environment.MachineName,
                    UpdatedByUserName = Program.CurrentUser.UserName
                };

                string DATA =  jsonSerialization.SerializeToString<ProspectClientConversation>(prosClientConv);

                WebClient client = new WebClient();
                client.Headers["Content-type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                string json = client.UploadString(apiurl,"DELETE", DATA);

                if (json != null)
                {
                    var resultObject = jsonSerialization.DeserializeFromString<Result>(json);
                    if (resultObject.IsSuccess)
                    {
                        MessageBox.Show("Record deleted successfully.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DataRow[] dr =  _dtConversation.Select("ID =" + selectedId);
                        if (dr.Count() > 0)
                            dr[0].Delete();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to delete record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            updateClient();
        }
        private void updateClient()
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = string.Empty;

                ProspectClient prosCustomer = new ProspectClient()
                {
                    Name = txtName.Text,
                    Occupation = txtOccupation.Text,
                    PhoneNo = txtPhoneNo.Text,
                    Email = txtEmail.Text,
                    Event = txtEvent.Text,
                    EventDate = dtEventDate.Value,
                    ReferedBy = txtRefBy.Text,
                    IsConvertedToClient = chkIsConvertedToCustomer.Checked,
                    StopSendingEmail = chkStopSendingEmail.Checked,
                    Remarks = txtRemark.Text,
                    CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")),
                    CreatedBy = Program.CurrentUser.Id,
                    UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")),
                    UpdatedBy = Program.CurrentUser.Id,
                    UpdatedByUserName = Program.CurrentUser.UserName,
                    MachineName = System.Environment.MachineName,
                    IntroductionCompleted = chkIntroductionCompleted.Checked                 
                };

                if (chkIsConvertedToCustomer.Checked && string.IsNullOrEmpty(cmbClient.Text))
                {
                    MessageBox.Show("You have chosen option converted to client then you have to select client from client list and client assign to. Please select client from list client as converted client or select client assign to.", "Select Client or Assign To", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (chkIntroductionCompleted.Checked) {
                    prosCustomer.IntroductionCompletedDate = dtIntroductionCompletdOn.Value;
                }
                if (chkIsConvertedToCustomer.Checked)
                {
                    prosCustomer.ClientId = int.Parse(cmbClient.Tag.ToString());
                    prosCustomer.ClientAssignTo = int.Parse(cmbClientAssignTo.Tag.ToString());
                }
                if (_prospectClient == null)
                {
                    apiurl = Program.WebServiceUrl + "/" + ADD_PROSPECTCLIENT_API;
                }
                else
                {
                    apiurl = Program.WebServiceUrl + "/" + UPDATE_PROSPECTCLIENT_API;
                    prosCustomer.ID = _prospectClient.ID;
                }

                string DATA =  jsonSerialization.SerializeToString<ProspectClient>(prosCustomer);

                WebClient client = new WebClient();
                client.Headers["Content-type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                string json = client.UploadString(apiurl,"POST", DATA);

                if (json != null)
                {
                    var resultObject = jsonSerialization.DeserializeFromString<Result>(json);
                    if (resultObject.IsSuccess)
                    {
                        if (chkIsConvertedToCustomer.Checked && btnConvertToClient.Visible)
                        {
                            try
                            {
                                sendEmailToAddRegisterNewClientEmailId(prosCustomer);
                            }
                            catch(Exception ex)
                            {
                                MessageBox.Show("Unable to send email for add client email Id to system. Error inforamtion " + ex.ToString());
                            }
                        }
                        MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void sendEmailToAddRegisterNewClientEmailId(ProspectClient prospectClient)
        {
            string primaryEmail = "services@ascentsolutions.in";
            string bcc = "";

            MailMessage mailMessage = new MailMessage();
            mailMessage.From = new MailAddress(MailServer.FromEmail);
            mailMessage.To.Add(new MailAddress(primaryEmail));
            if (!string.IsNullOrEmpty(bcc))
            {
                mailMessage.Bcc.Add(new MailAddress(bcc));
            }
            mailMessage.Subject = "Add new client email address.";
            mailMessage.IsBodyHtml = false;
            mailMessage.Body = "Dear Mohit Tolani, " + Environment.NewLine + Environment.NewLine +

               "Greetings From ASCENT FINANCIAL SOLUTIONS!!!" + Environment.NewLine + Environment.NewLine +

               "We would like to request you that kindly add the following mentioned mail ID of a New Client. From Now Onwards, we will be communicating and interacting with this Mentioned New Client by this mail ID." + Environment.NewLine + Environment.NewLine +

               "Kindly find below the details," + Environment.NewLine + Environment.NewLine +

               "Client Name: " + prospectClient.Name + Environment.NewLine + Environment.NewLine +

               "Registered Mail ID:" + prospectClient.Email + Environment.NewLine + Environment.NewLine +

               "We thank you to allow us our request for the addition of a New Mail ID." + Environment.NewLine + Environment.NewLine +


              "Regards," + Environment.NewLine +

               "Financial Planning Team" + Environment.NewLine +
               "ASCENT FINANCIAL SOLUTIONS PVT. LTD." + Environment.NewLine +
               "315,316 Notus IT park, Sarabhai Campus," + Environment.NewLine +
               "Genda Circle, Vadodara, Gujarat 390023" + Environment.NewLine +
                "PH.: 0265 - 2961205." + Environment.NewLine +
                "Mob.: 9512538380" + Environment.NewLine +
               "http://www.ascentsolutions.in";

            string reviewSheetPath = string.Empty;
            bool isEmailSend = FinancialPlanner.Common.EmailManager.EmailService.SendEmailWithChilkat(mailMessage, reviewSheetPath);
            //if (isEmailSend)
            //{
            //    // MessageBox.Show("Quarterly Review Template report send to client on '" + primaryEmail + "'.", "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    gridViewClient.SetRowCellValue(index, "Status", "Email send successfully");
            //}
            //else
            //{
            //    gridViewClient.SetRowCellValue(index, "Status", "Unable to send email to:" + primaryEmail);
            //    //MessageBox.Show("Unable to send email to '" + primaryEmail + "'. Check your email configuration setting.", "Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProspectCustomer_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((TabControl)((TabPage)this.Parent).Parent).TabPages.Remove((TabPage)this.Parent);
        }
        private bool isValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtEmail.Text))
            {
                //MessageBox.Show("Please enter valid email address.", "Email Address", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = !isValidEmail(txtEmail.Text);
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                MessageBox.Show("Please enter name of customer.", "Customer Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }
        }

        private void chkIntroductionCompleted_CheckedChanged(object sender, EventArgs e)
        {
            dtIntroductionCompletdOn.Visible = chkIntroductionCompleted.Checked;
            chkIntroductionCompleted.Text = (chkIntroductionCompleted.Checked) ? "Introduction Completed on " : "Introduction Completed";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtRefBy_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblRefBy_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void grpProspectCustomer_Enter(object sender, EventArgs e)
        {

        }

        private void chkStopSendingEmail_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void chkIsConvertedToCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (chkIsConvertedToCustomer.Checked)
                fillupCustomer();
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
                fillManagedByList();
            }
        }

        private void fillManagedByList()
        {
            cmbClientAssignTo.Properties.Items.Clear();
            for (int i = 0; i <= _dtUser.Rows.Count - 1; i++)
            {
                cmbClientAssignTo.Properties.Items.Add(_dtUser.Rows[i]["FirstName"].ToString());
            }
        }
        private void fillupCustomer()
        {
            ClientService clientService = new ClientService();
            clients = clientService.GetAll();
            Client client = new Client();
            client.Name = "";
            clients.Insert(0, client);
            cmbClient.Properties.Items.Clear();
            cmbClient.Properties.Items.AddRange(clients.Select(i => i.Name).ToList());
        }
        private void cmbClient_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbClient.Text))
            {
                cmbClient.Tag = clients.FirstOrDefault(i => i.Name == cmbClient.Text).ID;
            }
        }

        private void txtRemark_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtIntroductionCompletdOn_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cmbManagedBy_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbClientAssignTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbClientAssignTo.Tag = _dtUser.Select("FirstName ='" + cmbClientAssignTo.Text + "'")[0]["ID"].ToString();
        }

        private void btnConvertToClient_Click(object sender, EventArgs e)
        {
            showClientDetails(new Client());
            pnlClient.Visible = true;
        }
        private void showClientDetails(Client client)
        {
            ClientDetails clientDetails = new ClientDetails(client);
            clientDetails.ShowDialog();
        }
    }
}
