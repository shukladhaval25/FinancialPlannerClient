using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FinancialPlannerClient.Master.TaskMaster;
using FinancialPlanner.Common.Model.TaskManagement.MFTransactions;
using FinancialPlanner.Common.Model;

namespace FinancialPlannerClient.PlanOptions
{
    public partial class InvestmentRecomendationView : DevExpress.XtraEditors.XtraForm
    {
        private IList<AMC> amcs;
        private int selectedSchemeId;
        private Client currentClient;

        public IList<Scheme> schemes { get; private set; }

        public InvestmentRecomendationView(Client client)
        {
            InitializeComponent();
            this.currentClient = client;
        }

        private void InvestmentRecomendationView_Load(object sender, EventArgs e)
        {
            loadAMC();
            loadMembers();
        }
        internal void loadMembers()
        {
            if (this.currentClient == null)
                return;

            cmbFirstHolder.Properties.Items.Clear();
            cmbSecondHolder.Properties.Items.Clear();

            new PlannerInfo.FamilyMemberInfo().FillFamilyMemberInCombo(this.currentClient.ID, cmbFirstHolder);
            cmbSecondHolder.Properties.Items.AddRange(cmbFirstHolder.Properties.Items);
        }
        internal void loadAMC()
        {
            AMCInfo aMCInfo = new AMCInfo();
            amcs = aMCInfo.GetAll();
            DataTable dtAMC = getAMCTable();
            lookupAMC.Properties.DataSource  = dtAMC;
            lookupAMC.Properties.DisplayMember = "Name";
            lookupAMC.Properties.ValueMember = "Id";
            lookupAMC.Properties.NullValuePrompt = "Please select valid value.";
        }

        private DataTable getAMCTable()
        {
            DataTable dtAMC = new DataTable();
            dtAMC.Columns.Add("Id", typeof(System.Int64));
            dtAMC.Columns.Add("Name", typeof(System.String));
            foreach (AMC amc in amcs)
            {
                DataRow dr = dtAMC.NewRow();
                dr["Id"] = amc.Id;
                dr["Name"] = amc.Name;
                dtAMC.Rows.Add(dr);
            }
            return dtAMC;
        }

        internal void loadScheme(int amcId)
        {
            SchemeInfo schemeInfo = new SchemeInfo();
            schemes = schemeInfo.GetAll(amcId);
            cmbScheme.Properties.Items.Clear();
            foreach (Scheme scheme in schemes)
            {
                cmbScheme.Properties.Items.Add(scheme.Name);
            }
        }

        private void lookupAMC_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit comboBoxEdit = (DevExpress.XtraEditors.LookUpEdit)sender;
            if (comboBoxEdit.SelectedText != null)
            {
                AMC amcobject = ((List<AMC>)amcs).Find(i => i.Name == comboBoxEdit.Text.ToString());
                loadScheme(amcobject.Id);
            }
        }

        private void cmbScheme_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit = (DevExpress.XtraEditors.ComboBoxEdit)sender;
            if (comboBoxEdit.SelectedItem != null)
            {
                Scheme scheme = ((List<Scheme>)schemes).Find(i => i.Name == comboBoxEdit.SelectedItem.ToString());
                selectedSchemeId = scheme.Id;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grpInvRecDetails.Enabled = true;
        }
    }
}