using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.Utils;

namespace FinancialPlannerClient.Clients
{
    public partial class ClientEmailView : UserControl
    {
        WaitDialogForm waitdlg;
        public ClientEmailView()
        {
            InitializeComponent();
        }

        private void ClientEmailView_Load(object sender, EventArgs e)
        {
            //waitdlg = new WaitDialogForm("Loading Data...");
            //waitdlg.ShowDialog();
        }
    }
}
