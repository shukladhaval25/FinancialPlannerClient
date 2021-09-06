using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using System.Linq;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class CurrentStatusDetails : DevExpress.XtraReports.UI.XtraReport
    {
        private const string EMF = "Equity Mutual Fund";
        private const string SHARES = "Shares";
        private const string EQUITY = "Equity";
        private const string DEBT = "Debt";
        double totalAmount,totalEquityAmount, totalDebtAmount = 0;
        DataTable dtCurrentStatus;
        public CurrentStatusDetails(DataTable dataTable)
        {
            InitializeComponent();
            this.dtCurrentStatus = dataTable;
            this.dtCurrentStatus.TableName = "CurrentStatus";
            this.dtCurrentStatus.Columns.Add("AssetClass", typeof(System.String));
            this.DataSource = dtCurrentStatus;
            this.DataMember = dtCurrentStatus.TableName;
                        
            var rowsToUpdate =  this.dtCurrentStatus.AsEnumerable().Where(r => r.Field<string>("Title") == EMF || 
                r.Field<string>("Title") == SHARES);

            foreach (var row in rowsToUpdate)
            {
                row.SetField("Group", EQUITY);                
            }

            var rowsToUpdateForDebt = this.dtCurrentStatus.AsEnumerable().Where(r => r.Field<string>("Title") != EMF &&
               r.Field<string>("Title") != SHARES);

            foreach (var row in rowsToUpdateForDebt)
            {
                row.SetField("Group", DEBT);
            }

            GroupField groupField = new GroupField();
            groupField.FieldName = "Group";
            groupField.SortOrder = XRColumnSortOrder.Descending;
            this.GroupHeader1.GroupFields.Add(groupField);

            this.lblTotalGroupAmt.DataBindings.Add("Text", this.DataSource, "CurrentStatus.Amount");
            this.lblTotalGroupPerValue.DataBindings.Add("Text", this.DataSource, "CurrentStatus.Amount");
            this.lblPageTotal.DataBindings.Add("Text", this.DataSource, "CurrentStatus.Amount");

            this.lblParticular.DataBindings.Add("Text", this.DataSource, "CurrentStatus.Title");
            this.xrLblGroupAssets.DataBindings.Add("Text", this.DataSource, "CurrentStatus.Group");
            this.lblAmount.DataBindings.Add("Text", this.DataSource, "CurrentStatus.Amount");
            this.lblGroupTitle.Text = string.Format(lblGroupTitle.Text, xrLblGroupAssets.Text);

           totalAmount = dtCurrentStatus.AsEnumerable().Sum(x => Convert.ToDouble(x["Amount"]));
           totalEquityAmount =  dtCurrentStatus.AsEnumerable()
                .Where(x => x.Field<string>("Group") == "Equity")
                .Sum(x => Convert.ToDouble(x["Amount"]));

            totalDebtAmount = dtCurrentStatus.AsEnumerable()
                .Where(x => x.Field<string>("Group") == "Debt")
                .Sum(x => Convert.ToDouble(x["Amount"]));
        }

        private void lblTotalGroupAmt_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblTotalGroupAmt.Text))
            {
                lblTotalGroupAmt.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblTotalGroupAmt.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void lblPageTotal_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblPageTotal.Text))
            {
                lblPageTotal.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblPageTotal.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void lblAmount_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblAmount.Text))
            {
                lblAmount.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblAmount.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void lblPercentageValue_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //lblPercentageValue.Text = (System.Math.Round((double.Parse(lblAmount.Text) * 100) / totalAmount)).ToString() + " %"; 
        }

        private void lblTotalGroupPerValue_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblTotalGroupPerValue.Text))
            {
                lblTotalGroupPerValue.Text = PlannerMainReport.planner.CurrencySymbol + double.Parse(lblTotalGroupPerValue.Text).ToString("N0", PlannerMainReport.Info);
            }
            //lblTotalGroupPerValue.Text = (System.Math.Round((double.Parse(lblTotalGroupAmt.Text) * 100) / totalAmount)).ToString() + " %";
        }
    }
}
