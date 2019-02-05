using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.PlanOptions;
using FinancialPlannerClient.CashFlowManager;
using FinancialPlannerClient.PlannerInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace FinancialPlannerClient.PlanOptions
{
    public partial class EstimatedPlan : DevExpress.XtraEditors.XtraForm
    {

        private const string RISKPROFILE_GETALL = "RiskProfileReturn/GetAll";
        Planner planner;
        int _clientId;
        DataTable _dtOption;

        private List<RiskProfiledReturnMaster> _riskProfileMasters = new List<RiskProfiledReturnMaster>();
        private int _riskProfileId;

        CashFlowService cashFlowService = new CashFlowService();
        DataTable _dtcashFlow;

        private IList<Goals> goals;


        public EstimatedPlan(int clientId, Planner planner)
        {
            InitializeComponent();
            this._clientId = clientId;
            this.planner = planner;
            lblPlanName.Text = this.planner.Name;
            string startMonth = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(this.planner.PlannerStartMonth);
            string endMonth = System.Globalization.CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(
                new DateTime(2000, this.planner.PlannerStartMonth, 1).AddMonths(-1).Month);
            lblPlanPeriod.Text = string.Format("{0} - {1}", startMonth, endMonth);
            fillOptionData();
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

            CashFlow cf = cashFlowService.GetCashFlow(int.Parse(val[0][0].ToString()));
            if (cf != null)
            {

                grdSplitCashFlow.DataSource = null;

                btnShowIncomeDetails_Click(sender, e);

            }

        }
        private void btnShowIncomeDetails_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cmbPlanOption.Text))
            {
                _dtcashFlow = cashFlowService.GenerateCashFlow(this._clientId, this.planner.ID, _riskProfileId);
                grdSplitCashFlow.DataSource = _dtcashFlow;
                grdSplitCashFlow.CreateSplitContainer();
                grdViewCashFlow.Columns["Id"].Visible = false;
                grdViewCashFlow.Columns["StartYear"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
                foreach (DevExpress.XtraGrid.Columns.GridColumn column in grdViewCashFlow.Columns)
                {
                    if (column.Name != "ID" && column.Name != "StartYear" && column.Name != "EndYear")
                    {
                        //    column.DefaultCellStyle.Format = "#,###";
                        //    column.DefaultCellStyle.Alignment = DataGridViewContentAlignment.TopRight;
                    }
                    if (column.Name != "IncomeTax")
                    {
                        //column.ReadOnly = true;
                    }
                    else
                        column.Caption = "Income Tax (%)";
                }
            }
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
            goals = new GoalsInfo().GetAll(this.planner.ID);
        }

        private void getGoals()
        {
            cmbGoals.Properties.Items.Clear();

            foreach (var goal in this.goals)
            {
                cmbGoals.Properties.Items.Add(goal.Name);
            }
        }
    }
}
