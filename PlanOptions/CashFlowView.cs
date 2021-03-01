﻿using DevExpress.Utils;
using FinancialPlanner.Common;
using FinancialPlanner.Common.Model.PlanOptions;
using FinancialPlannerClient.CashFlowManager;
using System;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;

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
            Logger.LogInfo("Cash flow load...");
            try
            {
                Logger.LogInfo("Get Cash Flow.");
                CashFlow cf = cashFlowService.GetCashFlow(_optionId);
                Logger.LogInfo("Generate cash flow");
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
            catch(Exception ex)
            {
                Logger.LogDebug("Cash flow load process exception:" + ex.ToString());
                System.Windows.Forms.MessageBox.Show("Exception:" + ex.ToString());
            }
            Logger.LogInfo("Cash flow load process completed.");
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = System.IO.Path.GetTempPath() + "/" + "CashFlow" + DateTime.Now.Ticks.ToString() + ".xls";
                gridSplitContainerViewCashFlow.ExportToXls(filePath);
                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.StackTrace.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                System.Windows.Forms.MessageBox.Show("Exception:" + ex.ToString());
            }
        }
        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }

        private void gridSplitContainerViewCashFlow_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            //if (e.Column.Caption == "Surplus Amount")
            //{
            //    double surplusAmt = 0;
            //    double.TryParse(e.Value.ToString(), out surplusAmt);
            //    if (surplusAmt < 0)
            //        //gridSplitContainerViewCashFlow.GetRow(e.RowHandle).
            //        e.Appearance.BackColor = Color.Purple;
            //}
        }

        private void gridSplitContainerViewCashFlow_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            if (e.Column.ToString() == "Surplus Amount")
            {
                double surplusAmt = 0;
                double.TryParse(e.CellValue.ToString(), out surplusAmt);
                if (surplusAmt < 0)
                    e.Appearance.ForeColor  = Color.DarkRed  ;
            }
        }
    }
}
