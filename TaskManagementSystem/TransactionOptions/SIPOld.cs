using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraVerticalGrid;
using FinancialPlanner.Common.Model.TaskManagement.MFTransactions;

namespace FinancialPlannerClient.TaskManagementSystem.TransactionOptions
{
    class SIPOld : ITransactionType
    {
        readonly string GRID_NAME = "vGridSIPOld";
        SIPFresh sIPFresh;
        DevExpress.XtraVerticalGrid.VGridControl vGridTransaction;
        public void BindDataSource(Object obj)
        {
            //throw new NotImplementedException();
        }

        public VGridControl GetGridControl()
        {
            throw new NotImplementedException();
        }

        public void setVGridControl(VGridControl vGrid)
        {
            this.vGridTransaction = vGrid;
            sIPFresh = new SIPFresh();
            sIPFresh.setVGridControl(vGrid);
            removeUnwantedFields(vGrid);
        }
        private void removeUnwantedFields(VGridControl vGrid)
        {
            string[] removeRows = getRemoveRows();
            
            List<int> indexRows = new List<int>();
            for (int index = 0; index < vGrid.Rows.Count; index++)
            {
                if (removeRows.Contains(vGrid.Rows[index].Name))
                {
                    indexRows.Add(index);
                }
            }
            for (int index = indexRows.Count - 1; index >= 0; index--)
            {
                vGrid.Rows.RemoveAt(indexRows[index]);
            }
        }

        private string[] getRemoveRows()
        {
            return new string[] { "SecondHolder", "ThirdHolder", "Nominee", "Guardian" };
        }

        public object GetTransactionType()
        {
            SIP sip = new SIP();
            if (this.vGridTransaction.Rows.Count > 0)
            {
                sip.CID = sIPFresh.currentClient.ID;
                sip.MemberName = this.vGridTransaction.Rows["MemberName"].Properties.Value.ToString();
                sip.AMC = int.Parse( this.vGridTransaction.Rows["AMC"].Properties.Value.ToString());
                sip.FolioNo = this.vGridTransaction.Rows["FolioNumber"].Properties.Value.ToString();
                sip.SchemeId = sIPFresh.selectedSchemeId;
                sip.Option = this.vGridTransaction.Rows["Option"].Properties.Value.ToString();
                sip.Amount = double.Parse(this.vGridTransaction.Rows["Amount"].Properties.Value.ToString());
                sip.AccounType = this.vGridTransaction.Rows["AccountType"].Properties.Value.ToString();
                sip.SIPDayOn = int.Parse(this.vGridTransaction.Rows["SIPDate"].Properties.Value.ToString());
                sip.TransactionDate = (DateTime)this.vGridTransaction.Rows["TransactionDate"].Properties.Value;
                sip.SIPStartDate = (DateTime)this.vGridTransaction.Rows["SIPStartDate"].Properties.Value;
                sip.SIPEndDate = (DateTime)this.vGridTransaction.Rows["SIPEndDate"].Properties.Value;
                sip.ModeOfExecution = this.vGridTransaction.Rows["ModeOfExecution"].Properties.Value.ToString();
                sip.Remark = (this.vGridTransaction.Rows["Remark"].Properties.Value != null) ?
                    this.vGridTransaction.Rows["Remark"].Properties.Value.ToString() : string.Empty;
            }
            return sip;
        }

        public bool IsAllRequireInputAvailable()
        {
            return sIPFresh.IsAllRequireInputAvailable();
        }
    }
}
