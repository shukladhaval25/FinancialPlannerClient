using System;
using System.Collections.Generic;
using System.Data;
using FinancialPlannerClient.Master.TaskMaster;
using FinancialPlanner.Common.Model.TaskManagement.MFTransactions;
using FinancialPlanner.Common.Model;
using System.Windows.Forms;

namespace FinancialPlannerClient.Clients
{
    public partial class ClientARNView : DevExpress.XtraEditors.XtraForm
    {
        internal IList<ARN> arns;
        FinancialPlanner.Common.Model.Client client;
        ClientARN clientARN;
        public ClientARNView(FinancialPlanner.Common.Model.Client client)
        {
            InitializeComponent();
            this.client = client;
        }

        private void ClientARN_Load(object sender, EventArgs e)
        {
            loadAllARNValue();
            loadClientARN();
        }

        private void loadClientARN()
        {
            ClientARNInfo clientARNInfo = new ClientARNInfo();
            clientARN = clientARNInfo.Get(client.ID);
            if (clientARN != null)
            {
                lookUpARN.Tag = clientARN.ARNId;
                lookUpARN.Text = clientARN.ArnNumber;
                txtARNName.Text = clientARN.ARNName;
                txtARNName.Tag = clientARN.Id;
            }
        }

        internal void loadAllARNValue()
        {
            ARNInfo arnInfo = new ARNInfo();
            arns = arnInfo.GetAll();
            DataTable dtARN = getARNTable();
            lookUpARN.Properties.DataSource = dtARN;
        }
        private DataTable getARNTable()
        {
            DataTable dtARN = new DataTable();
            dtARN.Columns.Add("ID", typeof(System.Int64));
            dtARN.Columns.Add("ARNNumber", typeof(System.String));
            dtARN.Columns.Add("Name", typeof(System.String));
            foreach (ARN arn in arns)
            {
                DataRow dr = dtARN.NewRow();
                dr["ID"] = arn.Id;
                dr["ARNNumber"] = arn.ArnNumber;
                dr["Name"] = arn.Name;
                dtARN.Rows.Add(dr);
            }
            return dtARN;
        }

        private void lookUpARN_EditValueChanged(object sender, EventArgs e)
        {
            var dataRow = lookUpARN.GetSelectedDataRow();
            if (dataRow != null)
            {
                txtARNName.Text = ((System.Data.DataRowView)dataRow).Row.ItemArray[2].ToString();
                lookUpARN.Tag = ((System.Data.DataRowView)dataRow).Row.ItemArray[0].ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lookUpARN.Text))
            {
                MessageBox.Show("Please select ARN details");
            }

            ClientARNInfo clientARNInfo = new ClientARNInfo();
            clientARN.Cid = this.client.ID;
            clientARN.ARNId = int.Parse(lookUpARN.EditValue.ToString());
            clientARN.ARNName = txtARNName.Text;

            if (txtARNName.Tag.ToString() == "0")
            {                               
                clientARNInfo.Add(clientARN);
            }
            else
            {
                clientARNInfo.Update(clientARN);
            }
            MessageBox.Show("Record save successfully", "Save");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            ClientARNInfo clientARNInfo = new ClientARNInfo();
            clientARN.Cid = this.client.ID;
            clientARN.ARNId = int.Parse(lookUpARN.EditValue.ToString());
            clientARN.ARNName = txtARNName.Text;
            if (clientARNInfo.Delete(clientARN))
                MessageBox.Show("Record deleted sucessfully.");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}