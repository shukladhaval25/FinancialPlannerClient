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

namespace FinancialPlannerClient.Clients
{   
    public partial class AllClientsList : Form
    {
        private const string CLIENTS_GETALL = "Client/Get";
        private const string CLIENTS_GETBYID = "Client/GetById?id={0}";
        private const string DELETE_CLIENT_API = "Client/Delete";

        private DataTable _dtClient;
        public AllClientsList()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ClientWithPrimaryDetails frmClient = new ClientWithPrimaryDetails();
            frmClient.TopLevel = false;
            splitContainer.Panel2.Controls.Add(frmClient);
            frmClient.Dock = DockStyle.Fill;
            frmClient.Show();
        }

        private void ClientList_Load(object sender, EventArgs e)
        {
            loadCustomerData();
        }

        private void loadCustomerData()
        {
            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
            string apiurl = Program.WebServiceUrl +"/"+ CLIENTS_GETALL;
            
            RestAPIExecutor restApiExecutor = new RestAPIExecutor();

            var restResult = restApiExecutor.Execute<List<Client>>(apiurl, null, "GET");

            if (jsonSerialization.IsValidJson(restResult.ToString()))
            {
                var clientColleection = jsonSerialization.DeserializeFromString<List<Client>>(restResult.ToString());
                _dtClient = ListtoDataTable.ToDataTable(clientColleection);
                fillTreeviewData(_dtClient);
            }
            else
                MessageBox.Show(restResult.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            //HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(apiurl);
            //request.Method = "GET";
            //String prospClientResultJosn = String.Empty;
            //using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            //{
            //    Stream dataStream = response.GetResponseStream();

            //    StreamReader reader = new StreamReader(dataStream);
            //    prospClientResultJosn = reader.ReadToEnd();
            //    reader.Close();
            //    dataStream.Close();
            //}
            //var clientColleection = jsonSerialization.DeserializeFromString<Result<List<Client>>>(prospClientResultJosn);

            //if (clientColleection.Value != null)
            //{
            //    _dtClient = ListtoDataTable.ToDataTable(clientColleection.Value);
            //    fillTreeviewData(_dtClient);                
            //}
        }
        private void fillTreeviewData(DataTable dtProspClients)
        {
            trvList.Nodes.Clear();
            trvList.Nodes.Add("0", "Client", 5);
            foreach (DataRow dr in dtProspClients.Rows)
            {
                TreeNode node = new TreeNode();
                node.Tag = dr.Field<string>("ID");
                node.Text = dr.Field<string>("Name");
                node.ImageIndex = 9;
                node.ToolTipText = dr.Field<string>("Name");
                trvList.Nodes[0].Nodes.Add(node);
            }
            trvList.ExpandAll();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (trvList.SelectedNode != null)
            {
                Client client = convertSelectedRowDataToClient();
                ClientWithPrimaryDetails frmClient = new ClientWithPrimaryDetails(client);
                frmClient.TopLevel = false;
                splitContainer.Panel2.Controls.Add(frmClient);
                frmClient.Dock = DockStyle.Fill;
                frmClient.Show();
            }
        }

        private Client convertSelectedRowDataToClient()
        {
            Client client = new Client();
            if (trvList.SelectedNode.Tag != null)
            {
                DataRow dr = getSelectedDataRow(int.Parse(trvList.SelectedNode.Tag.ToString()));
                if (dr != null)
                {
                    client.ID = int.Parse(dr.Field<string>("ID"));
                    client.Name = dr.Field<string>("Name");
                    client.FatherName = dr.Field<string>("FatherName");
                    client.MotherName = dr.Field<string>("MotherName");
                    client.IsMarried = bool.Parse(dr.Field<string>("IsMarried").ToString());
                    //client.MarriageAnniversary = (dr.Field<string>("MarriageAnniversary") == null ?  null : dr.Field<DateTime?>("MarriageAnniversary"));
                    client.PAN = dr.Field<string>("PAN");
                    client.Aadhar = dr.Field<string>("AADHAR");
                    client.Occupation = dr.Field<string>("Occupation");
                    client.DOB = DateTime.Parse(dr.Field<string>("DOB").ToString());
                    client.Gender = dr.Field<string>("Gender");
                    client.PlaceOfBirth = dr.Field<string>("PlaceOfBirth");
                    client.IncomeSlab = dr.Field<string>("IncomeSlab");                    
                    client.UpdatedByUserName = Program.CurrentUser.UserName;
                }
            }
            return client;
        }
        private DataRow getSelectedDataRow(int id)
        {
            DataRow[] rows = _dtClient.Select("Id = " + id);
            foreach (DataRow dr in rows)
            {
                return dr;
            }
            return null;
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadCustomerData();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable queryResultTable = new DataTable();
            string query = string.Format("Name like '%{0}%' " +
                "or PAN LIKE '%{0}%' OR AADHAR LIKE '%{0}%'",txtSearch.Text);
            try
            {
                queryResultTable = _dtClient.Select(query).CopyToDataTable();
                fillTreeviewData(queryResultTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No matching records found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}
