using DevExpress.Utils;
using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.CashFlowManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FinancialPlannerClient.PlanOptions
{
    public partial class EstimatedPlan : DevExpress.XtraEditors.XtraForm
    {
        Planner planner;
        Client client;
        DataTable _dtOption;

        private const string RISKPROFILE_GETALL = "RiskProfileReturn/GetAll";       
        private List<RiskProfiledReturnMaster> _riskProfileMasters = new List<RiskProfiledReturnMaster>();
        private int _riskProfileId;
        private CashFlowService cashFlowService;

        public EstimatedPlan(Client client, Planner planner)
        {
            WaitDialogForm waitdlg = new WaitDialogForm("Loading Data...");
            InitializeComponent();
            this.client = client;
            showPlannerInformation(planner);
            fillOptionData();
            waitdlg.Close();

        }

        private void showPlannerInformation(Planner planner)
        {
            this.planner = planner;
            lblPlanName.Text = this.planner.Name;
            string startMonth = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(this.planner.PlannerStartMonth);
            string endMonth = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(
                new DateTime(2000, this.planner.PlannerStartMonth, 1).AddMonths(-1).Month);
            lblPlanPeriod.Text = string.Format("{0} - {1}", startMonth, endMonth);
            lblStartDate.Text = this.planner.StartDate.ToShortDateString();
        }

        private void fillOptionData()
        {
            cmbPlanOption.Properties.Items.Clear();
            _dtOption = new PlanOptionInfo().GetAll(this.planner.ID);
            if (_dtOption != null)
            {
                if (_dtOption.Rows.Count > 0)
                {
                    DataRow[] drs = _dtOption.Select("", "Name ASC");
                    foreach (DataRow dr in drs)
                    {
                        cmbPlanOption.Properties.Items.Add(dr.Field<string>("Name"));
                    }
                    cmbPlanOption.SelectedIndex = 0;
                }
            }
        }

        private void cmbPlanOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            var val = _dtOption.Select("NAME ='" + cmbPlanOption.Text + "'");
            if (val != null)
                cmbPlanOption.Tag = int.Parse(val[0][0].ToString());

            loadRiskProfileData();
            RiskProfiledReturnMaster riskProfMaster = _riskProfileMasters.FirstOrDefault(i => i.Id == int.Parse(val[0]["RiskProfileID"].ToString()));
            lblRiskProfileValue.Text = riskProfMaster.Name;
            lblRiskProfileValue.Tag = riskProfMaster.Id;
            _riskProfileId = riskProfMaster.Id;
            showCashFlow();
        }

        private void showCashFlow()
        {
            if (!string.IsNullOrEmpty(cmbPlanOption.Text))
            {
                CashFlowView cashFlowView = new CashFlowView(this.client.ID, this.planner.ID,
                    _riskProfileId,
                    int.Parse(cmbPlanOption.Tag.ToString()));
                cashFlowView.TopLevel = false;
                cashFlowView.Visible = true;
                tabNavigationPageCashFlow.Controls.Clear();
                tabNavigationPageCashFlow.Controls.Add(cashFlowView);
                tabNavigationPageCashFlow.Controls[0].Dock = DockStyle.Fill;
                cashFlowService = cashFlowView.GetCashFlowService();
            }
            tabEstimatedPlan.SelectedPage = tabNavigationPageCashFlow;
        }

        private void loadRiskProfileData()
        {

            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
            string apiurl = Program.WebServiceUrl + "/" + RISKPROFILE_GETALL;

            RestAPIExecutor restApiExecutor = new RestAPIExecutor();

            var restResult = restApiExecutor.Execute<List<RiskProfiledReturnMaster>>(apiurl, null, "GET");

            if (jsonSerialization.IsValidJson(restResult.ToString()))
            {
                _riskProfileMasters = jsonSerialization.DeserializeFromString<List<RiskProfiledReturnMaster>>(restResult.ToString());
            }
            else
                MessageBox.Show(restResult.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void EstimatedPlan_Load(object sender, EventArgs e)
        {

        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void EstimatedPlan_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.Parent != null)
                this.Parent.Controls.Clear();
        }

        private void tabEstimatedPlan_SelectedPageChanging(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangingEventArgs e)
        {
        }
        private void showGoalsView()
        {

            GoalCalView goalCalView = new GoalCalView(this.planner, _riskProfileId, int.Parse(cmbPlanOption.Tag.ToString()));
            goalCalView.setCashFlowService(cashFlowService);
            goalCalView.TopLevel = false;
            goalCalView.Visible = true;

            tabNavigationPageGoal.Controls.Clear();
            tabNavigationPageGoal.Controls.Add(goalCalView);
            tabNavigationPageGoal.Controls[0].Dock = DockStyle.Fill;
            tabEstimatedPlan.SelectedPage = tabNavigationPageGoal;
        }

        private void tabEstimatedPlan_SelectedPageChanged(object sender, DevExpress.XtraBars.Navigation.SelectedPageChangedEventArgs e)
        {
            switch (tabEstimatedPlan.SelectedPage.Caption)
            {
                case "Goals":
                    showGoalsView();
                    break;
                case "Current Status":
                    showCurrentStatusView();
                    break;
            }
        }

        private void showCurrentStatusView()
        {
            if (tabNavigationPageCurrentStatus.Controls.Count == 0)
            {
                CurrentStatusView currentStatusView = new CurrentStatusView(this.planner.ID);
                currentStatusView.TopLevel = false;
                currentStatusView.Visible = true;

                tabNavigationPageCurrentStatus.Controls.Clear();
                tabNavigationPageCurrentStatus.Controls.Add(currentStatusView);
            }
            tabEstimatedPlan.SelectedPage = tabNavigationPageCurrentStatus;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            PlanOptions planOptions = new PlanOptions(this.client, this.planner);
            if (planOptions.ShowDialog() == DialogResult.OK)
            {
                fillOptionData();
            }
        }
    }
}
