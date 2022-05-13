using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialPlannerClient.CurrentStatus;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model.CurrentStatus;

namespace FinancialPlannerClient.Controls
{
    public partial class CustomReminderPage : DevExpress.XtraEditors.XtraUserControl
    {
        public CustomReminderPage()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(dtFrom.Text) || string.IsNullOrEmpty(dtTo.Text))
            {
                MessageBox.Show("Please select proper from and to date.", "Invalid Data");
                return;
            }
            //dtTo.DateTime = dtTo.DateTime.AddDays(1);
            if (cmbOption.Text.Equals("Date of Birth (Client)"))
            {
                ClientDOBReminder clientDOBReminder = new ClientDOBReminder();
                DataTable dtResult =  clientDOBReminder.GetRecord(dtFrom.DateTime, dtTo.DateTime);
                gridControlClients.DataSource = dtResult;
                return;
            }
            if (cmbOption.Text.Equals("PPF"))
            {
                PPFInfo ppfInfo = new PPFInfo();
                IList<PPFMaturity> ppfs =  ppfInfo.GetPPFMaturity(dtFrom.DateTime, dtTo.DateTime);
                DataTable dtResult = ListtoDataTable.ToDataTable(ppfs.ToList());
                gridControlClients.DataSource = dtResult;
                return;
            }
            if (cmbOption.Text.Equals("FD"))
            {
                FDInfo fdInfo = new FDInfo();
                IList<FixedDeposit> ppfs = fdInfo.GetFDMaturity(dtFrom.DateTime, dtTo.DateTime);
                DataTable dtResult = ListtoDataTable.ToDataTable(ppfs.ToList());
                gridControlClients.DataSource = dtResult;
                return;
            }
            if (cmbOption.Text.Equals("Bond"))
            {
                BondInfo bondInfo = new BondInfo();
                IList<Bonds> ppfs = bondInfo.GetMaturity(dtFrom.DateTime, dtTo.DateTime);
                DataTable dtResult = ListtoDataTable.ToDataTable(ppfs.ToList());
                gridControlClients.DataSource = dtResult;
                return;
            }
        }

        private void dtTo_EditValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dtTo_Leave(object sender, EventArgs e)
        {
            dtTo.DateTime = new DateTime(dtTo.DateTime.Year, dtTo.DateTime.Month, dtTo.DateTime.Day, 23, 59, 59);//  dtTo.DateTime.AddHours(23.59);
        }

        private void dtFrom_Leave(object sender, EventArgs e)
        {
            dtFrom.DateTime = new DateTime(dtFrom.DateTime.Year, dtFrom.DateTime.Month, dtFrom.DateTime.Day, 00, 00, 00);
        }
    }
}
