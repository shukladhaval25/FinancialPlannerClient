using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FinancialPlannerClient.Clients;
using FinancialPlanner.Common.Model;

namespace FinancialPlannerClient.Controls
{
    public partial class MOM : DevExpress.XtraEditors.XtraUserControl
    {
        IList<Client> clients;
        DataTable dtMon = new DataTable();
        
        public MOM()
        {
            InitializeComponent();
        }

        private void MOM_Load(object sender, EventArgs e)
        {
            fillupCustomer();
            dtMon.Columns.Add("Points");
            dtMon.Columns.Add("ActionPlan");
            dtMon.Columns.Add("Responsibility");
            dtMon.Columns.Add("Status");
            dtMon.Columns.Add("IsTaskCreationRequire", Type.GetType("System.Boolean"));
            dtMon.Columns.Add("TaskId", Type.GetType("System.String"));
            DataRow dr;
            dr = dtMon.NewRow();
            dtMon.Rows.Add(dr);
            gridControlMOM.DataSource = dtMon;
        }
        private void fillupCustomer()
        {
            ClientService clientService = new ClientService();
            clients = clientService.GetAll();
            cmbClient.Properties.Items.Clear();
            cmbClient.Properties.Items.AddRange(clients.Select(i => i.Name).ToList());
        }

        private void radioGroupMeetingWith_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroupMeetingWith.SelectedIndex == 0)
            {
                cmbClient.Visible = true;
            }
            else
            {
                cmbClient.Visible = false;
            }
        }

        private void repositoryItemButton_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            MessageBox.Show(e.ToString());
        }
    }
}
