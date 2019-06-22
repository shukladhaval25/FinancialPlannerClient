using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinancialPlannerClient.TaskManagementSystem
{
    public partial class NewProject : DevExpress.XtraEditors.XtraForm
    {
        public NewProject()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grpProjectDetails.Enabled = true;
        }
    }
}
