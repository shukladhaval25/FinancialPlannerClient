using FinancialPlanner.Common.Model;
using System;
using System.Windows.Forms;

namespace FinancialPlannerClient.PlanOptions
{
    public partial class PlanOptionMaster : Form
    {
  

        public PlanOptionMaster()
        {
            InitializeComponent();
        }

        private void btnGenInsCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        
        private void btnGenInsSave_Click(object sender, EventArgs e)
        {
            PlanOption planOpt = new PlanOption();
            planOpt.Id = int.Parse(txtOptionName.Tag.ToString());
            planOpt.Pid = int.Parse(lblPlanVal.Tag.ToString());
            planOpt.Name = txtOptionName.Text;
            planOpt.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            planOpt.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            planOpt.UpdatedBy = Program.CurrentUser.Id;
            planOpt.CreatedBy = Program.CurrentUser.Id;
            planOpt.UpdatedByUserName = Program.CurrentUser.UserName;
            planOpt.MachineName = System.Environment.MachineName;

            if (new PlanOptionInfo().Save(planOpt))
            {
                MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
                MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
