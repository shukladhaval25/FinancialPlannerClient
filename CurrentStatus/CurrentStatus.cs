using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialPlanner.Common.Model;

namespace FinancialPlannerClient.CurrentStatus
{
    public partial class CurrentStatus : Form
    {
        private Client _client;
        DataTable _dtPlan;

        public CurrentStatus()
        {
            InitializeComponent();
        }

        public CurrentStatus(Client client)
        {
            InitializeComponent();
            this._client = client;
        }

        private void CurrentStatus_Load(object sender, EventArgs e)
        {
            if (_client != null)
            {
                fllupClientAndPlanInfo();
                _dtPlan = new PlannerInfo.PlannerInfo().GetPlanData(_client.ID);
                fillPlanData();
            }
        }

        private void fillPlanData()
        {
            if (_dtPlan != null)
            {
                cmbPlan.Items.Clear();
                if (_dtPlan.Rows.Count > 0)
                {
                    DataRow[] drs = _dtPlan.Select("", "StartDate DESC");
                    foreach (DataRow dr in drs)
                    {
                        cmbPlan.Items.Add(dr.Field<string>("Name"));
                    }
                    cmbPlan.SelectedIndex = 0;
                }
            }
        }

        private void fllupClientAndPlanInfo()
        {
            lblclientNameVal.Text = _client.Name;            
        }

    }
}
