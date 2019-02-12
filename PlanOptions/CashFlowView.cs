﻿using DevExpress.Utils;
using FinancialPlanner.Common.Model.PlanOptions;
using FinancialPlannerClient.CashFlowManager;
using System;
using System.Data;

namespace FinancialPlannerClient.PlanOptions
{
    public partial class CashFlowView : DevExpress.XtraEditors.XtraForm
    {
        private int _clientId;
        private int iD;
        private int _riskProfileId;
        private int _optionId;

        CashFlowService cashFlowService = new CashFlowService();
        DataTable _dtcashFlow;
        
        public CashFlowView()
        {
            InitializeComponent();
        }
        public CashFlowView(int clientId, int iD, int riskProfileId,int optinId)
        {
            InitializeComponent();
            _clientId = clientId;
            this.iD = iD;
            _riskProfileId = riskProfileId;
            _optionId = _optionId;
        }
        public CashFlowService GetCashFlowService()
        {
            return this.cashFlowService;
        }

        private void CashFlowView_Load(object sender, EventArgs e)
        {
            CashFlow cf = cashFlowService.GetCashFlow(_optionId);
            _dtcashFlow = cashFlowService.GenerateCashFlow(this._clientId, this.iD, _riskProfileId);
            grdSplitCashFlow.DataSource = _dtcashFlow;
            //grdSplitCashFlow.CreateSplitContainer();
            gridSplitContainerViewCashFlow.Columns["Id"].Visible = false;
            gridSplitContainerViewCashFlow.Columns["StartYear"].Fixed = DevExpress.XtraGrid.Columns.FixedStyle.Left;
            foreach (DevExpress.XtraGrid.Columns.GridColumn column in gridSplitContainerViewCashFlow.Columns)
            {
                if (column.Name != "ID" && column.Name != "StartYear" && column.Name != "EndYear")
                {
                    column.DisplayFormat.FormatType = FormatType.Numeric;
                    column.DisplayFormat.FormatString = "#,###";
                    column.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;                 
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
}
