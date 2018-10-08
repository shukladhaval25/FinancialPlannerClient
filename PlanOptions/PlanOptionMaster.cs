using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FinancialPlannerClient.PlanOptions
{
    public partial class PlanOptionMaster : Form
    {

        private const string RISKPROFILE_GETALL = "RiskProfileReturn/GetAll";
        private List<RiskProfiledReturnMaster> _riskProfileMasters = new List<RiskProfiledReturnMaster>();
        private string _riskProfileName;
        public PlanOptionMaster()
        {
            InitializeComponent();
        }
        public PlanOptionMaster(string RiskProfileName)
        {
            InitializeComponent();
            _riskProfileName = RiskProfileName;
        }

        private void btnGenInsCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        
        private void btnGenInsSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(cmbRiskProfile.Text))
            {
                MessageBox.Show("Please select Risk profile value.", "Risk profile require", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            PlanOption planOpt = new PlanOption();
            planOpt.Id = int.Parse(txtOptionName.Tag.ToString());
            planOpt.Pid = int.Parse(lblPlanVal.Tag.ToString());
            planOpt.Name = txtOptionName.Text;
            planOpt.RiskProfileId = int.Parse(cmbRiskProfile.Tag.ToString());
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

        private void PlanOptionMaster_Load(object sender, EventArgs e)
        {
            loadRiskProfileData();
        }
        private void loadRiskProfileData()
        {
            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
            string apiurl = Program.WebServiceUrl +"/"+ RISKPROFILE_GETALL;

            RestAPIExecutor restApiExecutor = new RestAPIExecutor();

            var restResult = restApiExecutor.Execute<List<RiskProfiledReturnMaster>>(apiurl, null, "GET");

            if (jsonSerialization.IsValidJson(restResult.ToString()))
            {
                _riskProfileMasters = jsonSerialization.DeserializeFromString<List<RiskProfiledReturnMaster>>(restResult.ToString());
                foreach (var riskProfile in _riskProfileMasters)
                {
                    cmbRiskProfile.Items.Add(riskProfile.Name);
                }               
            }
            else
                MessageBox.Show(restResult.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            cmbRiskProfile.Text = _riskProfileName;            
        }

        private void cmbRiskProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            RiskProfiledReturnMaster rpm =   _riskProfileMasters.Find(i => i.Name == cmbRiskProfile.Text);
            if (rpm != null)
                cmbRiskProfile.Tag = rpm.Id;        
        }
    }
}
