using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class CurrentStatusDetails : DevExpress.XtraReports.UI.XtraReport
    {
        private const string MF = "Mutual Fund";
        private const string SHARES = "Shares";
        private const string EQUITY = "Equity";
        private const string DEBT = "Debt";
        DataTable dtCurrentStatus;
        public CurrentStatusDetails(DataTable dataTable)
        {
            InitializeComponent();
            this.dtCurrentStatus = dataTable;
            this.dtCurrentStatus.TableName = "CurrentStatus";
            this.dtCurrentStatus.Columns.Add("AssetClass", typeof(System.String));
            this.DataSource = dtCurrentStatus;
            this.DataMember = dtCurrentStatus.TableName;
                        
            var rowsToUpdate =  this.dtCurrentStatus.AsEnumerable().Where(r => r.Field<string>("Title") == MF || 
                r.Field<string>("Title") == SHARES);

            foreach (var row in rowsToUpdate)
            {
                row.SetField("Group", EQUITY);                
            }

            var rowsToUpdateForDebt = this.dtCurrentStatus.AsEnumerable().Where(r => r.Field<string>("Title") != MF &&
               r.Field<string>("Title") != SHARES);

            foreach (var row in rowsToUpdateForDebt)
            {
                row.SetField("Group", DEBT);
            }

            this.lblParticular.DataBindings.Add("Text", this.DataSource, "CurrentStatus.Title");
            this.lblAssetClass.DataBindings.Add("Text", this.DataSource, "CurrentStatus.Group");
            this.lblAmount.DataBindings.Add("Text", this.DataSource, "CurrentStatus.Amount");

            //this.lblName.DataBindings.Add("Text", this.DataSource, "FamilyMember.Name");
            //this.lblRelationship.DataBindings.Add("Text", this.DataSource, "FamilyMember.Relationship");
        }
    }
}
