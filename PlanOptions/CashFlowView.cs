using DevExpress.Utils;
using FinancialPlanner.Common.Model.PlanOptions;
using FinancialPlannerClient.CashFlowManager;
using System;
using System.Data;

namespace FinancialPlannerClient.PlanOptions
{
    public partial class CashFlowView : DevExpress.XtraEditors.XtraForm
    {
        private int _clientId;
        private int _planId;
        private int _riskProfileId;
        private int _optionId;

        CashFlowService cashFlowService = new CashFlowService();
        DataTable _dtcashFlow;
        
        public CashFlowView()
        {
            InitializeComponent();
        }
        public CashFlowView(int clientId, int iD, int riskProfileId,int optionId)
        {
            InitializeComponent();
            _clientId = clientId;
            this._planId = iD;
            _riskProfileId = riskProfileId;
            _optionId = optionId;
        }
        public CashFlowService GetCashFlowService()
        {
            return this.cashFlowService;
        }

        private void CashFlowView_Load(object sender, EventArgs e)
        {
            CashFlow cf = cashFlowService.GetCashFlow(_optionId);
            _dtcashFlow = cashFlowService.GenerateCashFlow(this._clientId, this._planId, _riskProfileId);
            grdSplitCashFlow.DataSource = _dtcashFlow;
            //grdSplitCashFlow.CreateSplitContainer();
            gridSplitContainerViewCashFlow.Columns["Id"].Visible = false;
            gridSplitContainerViewCashFlow.Columns["StartYear"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridSplitContainerViewCashFlow.Columns)
            {
                if (column.FieldName == "Total Post Tax Income")
                    column.ToolTip = "Total Income - Total Tax Deduction";
                if (column.FieldName == "Surplus Amount")
                    column.ToolTip = "Total Post Tax Income - (Total Annual Expenses + Total Annual Loans)";               
            }
        }
    }
}
