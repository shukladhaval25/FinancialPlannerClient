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

namespace FinancialPlannerClient.ProspectCustomer
{
    public partial class ProspectCustomerList : Form
    {
        private const string PROSPECT_CLIENTS_GETALL = "ProspectClient/GetAll";
        private const string PROSPECT_CLIENTS_GETBYNAME = "ProspectClient/GetByName";
        private const string DELETE_PROSPECT_CLIENTS_API = "ProspectClient/Delete";

        private DataTable _dtProspClients;
        public ProspectCustomerList()
        {
            InitializeComponent();
        }

        private void ProspectCustomerList_Load(object sender, EventArgs e)
        {
            loadProspectCustomerData();
        }

        private void loadProspectCustomerData()
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ PROSPECT_CLIENTS_GETALL;

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<List<ProspectClient>>(apiurl, null, "GET");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    var prospClientCollection = jsonSerialization.DeserializeFromString<List<ProspectClient>>(restResult.ToString());
                    _dtProspClients = ListtoDataTable.ToDataTable(prospClientCollection);
                    fillTreeviewData(_dtProspClients);
                }
                else
                    MessageBox.Show(restResult.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch(Exception ex)
            {
                Logger.LogDebug(ex);
            }


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
            //var prospClientCollection = jsonSerialization.DeserializeFromString<Result<List<ProspectClient>>>(prospClientResultJosn);

            //if (prospClientCollection.Value != null)
            //{
            //    _dtProspClients = ListtoDataTable.ToDataTable(prospClientCollection.Value);
            //    //dataGridProspClients.DataSource = _dtProspClients;
            //    fillTreeviewData(_dtProspClients);
            //    //gridDisplaySetting();
            //}
        }

        private void fillTreeviewData(DataTable dtProspClients)
        {
            trvList.Nodes.Clear();
            trvList.Nodes.Add("0", "Prospect Client", 5);
            foreach (DataRow dr in dtProspClients.Rows)
            {
                TreeNode node = new TreeNode();
                node.Tag = dr.Field<string>("ID");
                node.Text = dr.Field<string>("Name");
                node.ImageIndex = 10;
                node.ToolTipText = dr.Field<string>("Name");
                trvList.Nodes[0].Nodes.Add(node);
            }
            trvList.ExpandAll();
        }

        //private void gridDisplaySetting()
        //{
        //    dataGridProspClients.Columns["ID"].Visible = false;
        //    //dataGridProspClients.Columns["Name"].Visible = false;
        //    //dataGridProspClients.Columns["PhoneNo"].Visible = false;
        //    dataGridProspClients.Columns["CreatedBy"].Visible = false;
        //    dataGridProspClients.Columns["CreatedOn"].Visible = false;
        //    //dataGridProspClients.Columns["CreatedByUserName"].Visible = false;
        //    dataGridProspClients.Columns["UpdatedBy"].Visible = false;
        //    //dataGridProspClients.Columns["UserName"].HeaderText = "User Name";
        //    //dataGridProspClients.Columns["FirstName"].HeaderText = "First Name";
        //    //dataGridProspClients.Columns["LastName"].HeaderText = "Last Name";
        //    dataGridProspClients.Columns["UpdatedOn"].HeaderText = "Updated On";
        //    dataGridProspClients.Columns["UpdatedByUserName"].HeaderText = "Updated By";
        //}

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //ProspectCustomer frmProspectCustomer = new ProspectCustomer();
            //frmProspectCustomer.TopLevel = false;
            //splitContainer.Panel2.Controls.Add(frmProspectCustomer);
            //frmProspectCustomer.Dock = DockStyle.Fill;
            //frmProspectCustomer.Show();

            ProspectCustomer frmProspectCustomer = new ProspectCustomer();
            frmProspectCustomer.TopLevel = false;
            TabPage prospectCustomerpage = new TabPage();
            prospectCustomerpage.Name = "New Client";
            prospectCustomerpage.Text = "New Client";
            prospectCustomerpage.Controls.Add(frmProspectCustomer);
            tabControl1.TabPages.Add(prospectCustomerpage);
            frmProspectCustomer.Dock = DockStyle.Fill;
            frmProspectCustomer.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (trvList.SelectedNode != null)
            {
                //ProspectClient prospClient = convertSelectedRowDataToProspectCustomer();
                //ProspectCustomer frmProspectCustomer = new ProspectCustomer(prospClient);
                //frmProspectCustomer.TopLevel = false;
                //splitContainer.Panel2.Controls.Add(frmProspectCustomer);
                //frmProspectCustomer.Dock = DockStyle.Fill;
                //frmProspectCustomer.BringToFront();
                //frmProspectCustomer.Show();

                ProspectClient prospClient = convertSelectedRowDataToProspectCustomer();
                ProspectCustomer frmProspectCustomer = new ProspectCustomer(prospClient);
                frmProspectCustomer.TopLevel = false;
                TabPage prospectCustomerpage = new TabPage();
                prospectCustomerpage.Name = trvList.SelectedNode.Tag.ToString();
                prospectCustomerpage.Text = trvList.SelectedNode.Text;
                prospectCustomerpage.ImageKey = "icons8-reception-16 - Copy.png";
                prospectCustomerpage.Controls.Add(frmProspectCustomer);
                tabControl1.TabPages.Add(prospectCustomerpage);
                tabControl1.SelectTab(tabControl1.TabPages.Count - 1);
                frmProspectCustomer.Dock = DockStyle.Fill;
                frmProspectCustomer.Show();

            }
            else
                MessageBox.Show("Please select valid client.", "Invalid client selection", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private ProspectClient convertSelectedRowDataToProspectCustomer()
        {
            ProspectClient prospectCustomer = new ProspectClient();
            if (trvList.SelectedNode.Tag != null)
            {
                DataRow dr = getSelectedDataRow(int.Parse(trvList.SelectedNode.Tag.ToString()));
                if (dr != null)
                {
                    prospectCustomer.ID = int.Parse(dr.Field<string>("ID"));
                    prospectCustomer.Name = dr.Field<string>("Name");
                    prospectCustomer.PhoneNo = dr.Field<string>("PhoneNo");
                    prospectCustomer.Occupation = dr.Field<string>("Occupation");
                    prospectCustomer.ReferedBy = dr.Field<string>("ReferedBy");
                    prospectCustomer.Email = dr.Field<string>("Email");
                    prospectCustomer.Remarks = dr.Field<string>("Remarks");
                    prospectCustomer.Event = dr.Field<string>("Event");
                    prospectCustomer.EventDate = DateTime.Parse(dr.Field<string>("EventDate").ToString());
                    prospectCustomer.UpdatedByUserName = Program.CurrentUser.UserName;
                }
            }
            return prospectCustomer;
        }

        private DataRow getSelectedDataRow(int id)
        {
            DataRow[] rows = _dtProspClients.Select("Id = " + id);
            foreach (DataRow dr in rows)
            {
                return dr;
            }
            return null;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DataTable queryResultTable = new DataTable();
            string query = string.Format("Name like '%{0}%' or PhoneNo like '%{0}%' or Email like '%{0}%' " +
                "or ReferedBy ='%{0}' or Event like '%{0}%' or EventDate like '%{0}%'",txtSearch.Text);
            try
            {
                queryResultTable = _dtProspClients.Select(query).CopyToDataTable();
                fillTreeviewData(queryResultTable);
            }
            catch (Exception ex)
            {
                MessageBox.Show("No matching records found.", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (trvList.SelectedNode != null)
            {
                if (MessageBox.Show(
                    string.Format("Are you sure you want to remove {0}'s record? If you select 'Yes' then all associated conversation gets deleted.", trvList.SelectedNode.Text),
                    "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    removeRecord(trvList.SelectedNode);
                }
            }
            else
            {
                MessageBox.Show("Please select item to perform action.", "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void removeRecord(TreeNode selectedNode)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl  = Program.WebServiceUrl + "/" + DELETE_PROSPECT_CLIENTS_API;

                ProspectClient prospClient = convertSelectedRowDataToProspectCustomer();

                string DATA =  jsonSerialization.SerializeToString<ProspectClient>(prospClient);

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
                        trvList.SelectedNode.Remove();
                        DataRow[] dr =  _dtProspClients.Select("ID =" + prospClient.ID);
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

        private void trvList_DoubleClick(object sender, EventArgs e)
        {
            btnEdit_Click(sender, e);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadProspectCustomerData();
        }
    }
}
