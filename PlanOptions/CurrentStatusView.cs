using FinancialPlanner.Common.Model.CurrentStatus;
using FinancialPlannerClient.CurrentStatus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinancialPlannerClient.PlanOptions
{
    public partial class CurrentStatusView : DevExpress.XtraEditors.XtraForm
    {
        CurrentStatusCalculation _csCal;
        CurrentStatusInfo _csInfo = new CurrentStatusInfo();

        int _planId;
        public CurrentStatusView(int planId)
        {
            InitializeComponent();
            this._planId = planId;
        }

        private void CurrentStatusView_Load(object sender, EventArgs e)
        {
            _csCal = _csInfo.GetAllCurrestStatus(_planId);
            fillCurrentStatusData();
        }
        private void fillCurrentStatusData()
        {
            if (_csCal != null)
            {
                txtEquitySharesAmt.Text = _csCal.ShresValue.ToString();
                txtMFAmt.Text = _csCal.EquityMFvalue.ToString();
                txtEquityNPSAmt.Text = _csCal.NpsEquityValue.ToString();
                txtEquityOtherAmt.Text = _csCal.OtherEquityValue.ToString();
                double totalEquityAmount = getTotalEquityAmount();

                txtDebtMFValue.Text = _csCal.DebtMFValue.ToString();
                txtFDAmt.Text = _csCal.FdValue.ToString();
                txtRDAmt.Text = _csCal.RdValue.ToString();
                txtSAAmt.Text = _csCal.SaValue.ToString();
                txtDebtNPSAmt.Text = _csCal.NpsDebtValue.ToString();
                txtPPFAmt.Text = _csCal.PPFValue.ToString();
                txtEPFAmt.Text = _csCal.EPFValue.ToString();
                txtSSAmt.Text = _csCal.SSValue.ToString();
                txtSCSSValue.Text = _csCal.SCSSValue.ToString();
                txtNSCAmt.Text = _csCal.NscValue.ToString();
                txtDebOtherAmt.Text = _csCal.OtherDebtValue.ToString();
                txtBondsAmt.Text = _csCal.BondsValue.ToString();
                double totalDebtAmount = getTotalDebtAmount();

                txtGoldAmt.Text = _csCal.GoldValue.ToString();
                txtGoldOtherAmt.Text = _csCal.OthersGoldValue.ToString();
                double totalGoldAmount = getTotalGoldAmount();

                double totalCurrentStatusAmount = totalEquityAmount + totalDebtAmount + totalGoldAmount;

                displayTotalAmount(totalEquityAmount, totalDebtAmount, totalGoldAmount);

                if (totalCurrentStatusAmount > 0)
                {
                    double equityRatio = (totalEquityAmount * 100) / totalCurrentStatusAmount;
                    double debtRatio = (totalDebtAmount * 100) / totalCurrentStatusAmount;
                    double goldRatio = (totalGoldAmount * 100) / totalCurrentStatusAmount;
                    lblEquityShareRatio.Text = string.Format("{0} %", Math.Round(equityRatio).ToString());
                    lblDebtRatio.Text = string.Format("{0} %", Math.Round(debtRatio).ToString());
                    lblGoldRatio.Text = string.Format("{0} %", Math.Round(goldRatio).ToString());
                }
                else
                {
                    lblEquityShareRatio.Text = string.Format("{0} %", "0");
                    lblDebtRatio.Text = string.Format("{0} %", "0");
                    lblGoldRatio.Text = string.Format("{0} %", "0");
                }
            }
        }

        private void displayTotalAmount(double totalEquityAmount, double totalDebtAmount, double totalGoldAmount)
        {
            txtTotalEquityAmount.Text = totalEquityAmount.ToString();
            txtTotalDebtAmount.Text = totalDebtAmount.ToString();
            txtTotalGoldAmount.Text = totalGoldAmount.ToString();
            lblGrandTotalValue.Text = (totalEquityAmount + totalDebtAmount + totalGoldAmount).ToString("#,###,##");
        }

        private double getTotalGoldAmount()
        {
            return _csCal.GoldValue + _csCal.OthersGoldValue;
        }

        private double getTotalEquityAmount()
        {
            return _csCal.ShresValue + _csCal.EquityMFvalue +
            _csCal.NpsEquityValue + _csCal.OtherEquityValue;
        }

        private double getTotalDebtAmount()
        {
            return _csCal.DebtMFValue + _csCal.FdValue +
                            _csCal.RdValue + _csCal.SaValue + _csCal.NpsDebtValue +
                            _csCal.PPFValue + _csCal.EPFValue + _csCal.SSValue + _csCal.BondsValue +
                            _csCal.SCSSValue + _csCal.OtherDebtValue + _csCal.NscValue;
        }
    }
}
