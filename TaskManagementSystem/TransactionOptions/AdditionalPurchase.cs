using System;
using System.Collections.Generic;
using System.Linq;
using DevExpress.XtraVerticalGrid;
using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.TaskManagement.MFTransactions;

namespace FinancialPlannerClient.TaskManagementSystem.TransactionOptions
{
    public class AdditionalPurchase : ITransactionType
    {
        readonly string GRID_NAME = "vGridAdditionalPurchase";
        DevExpress.XtraVerticalGrid.VGridControl vGridTransaction;
        FreshPurchaseTrans freshPurchaseTrans;
        FreshPurchase freshPurchase;

        //private DevExpress.XtraVerticalGrid.Rows.EditorRow ARN;
        //private DevExpress.XtraVerticalGrid.Rows.EditorRow ClientGroup;
        //private DevExpress.XtraVerticalGrid.Rows.EditorRow MemberName;
        ////private DevExpress.XtraVerticalGrid.Rows.EditorRow SecondHolder;
        ////private DevExpress.XtraVerticalGrid.Rows.EditorRow ThirdHolder;
        ////private DevExpress.XtraVerticalGrid.Rows.EditorRow Nominee;
        ////private DevExpress.XtraVerticalGrid.Rows.EditorRow Guardian;
        //private DevExpress.XtraVerticalGrid.Rows.EditorRow ModeOfHolding;
        //private DevExpress.XtraVerticalGrid.Rows.EditorRow AMC;
        //private DevExpress.XtraVerticalGrid.Rows.EditorRow FolioNumber;
        //private DevExpress.XtraVerticalGrid.Rows.EditorRow Scheme;
        //private DevExpress.XtraVerticalGrid.Rows.EditorRow Options;
        //private DevExpress.XtraVerticalGrid.Rows.EditorRow Amount;
        //private DevExpress.XtraVerticalGrid.Rows.EditorRow TransactionDate;
        //private DevExpress.XtraVerticalGrid.Rows.EditorRow AssignedTo;
        //private DevExpress.XtraVerticalGrid.Rows.EditorRow ModeOfExecution;
        //private DevExpress.XtraVerticalGrid.Rows.EditorRow Remark;


        //private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemARN;
        //private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxClientGroup;
        //private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxMemberName;
        ////private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxSecondHolder;
        ////private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxThirdHolder;
        ////private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditNominee;
        ////private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditGuardian;
        //private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxModeOfHolding;
        //private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditAMC;
        //private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditFolioNumber;
        //private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxScheme;
        //private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxOption;
        //private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditAmount;
        //private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEditTransactionDate;
        //private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxAssignTo;
        //private DevExpress.XtraEditors.Repository.RepositoryItemComboBox repositoryItemComboBoxModeOfExecution;
        //private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEditRemark;

        private void InitializeComponent()
        {
            //if (this.vGridTransaction == null)
            //    return;

            //this.ARN = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            //this.ClientGroup = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            //this.MemberName = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            ////this.SecondHolder = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            ////this.ThirdHolder = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            ////this.Nominee = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            ////this.Guardian = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            //this.ModeOfHolding = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            //this.AMC = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            //this.FolioNumber = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            //this.Scheme = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            //this.Options = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            //this.Amount = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            //this.TransactionDate = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            //this.AssignedTo = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            //this.ModeOfExecution = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            //this.Remark = new DevExpress.XtraVerticalGrid.Rows.EditorRow();

            //this.repositoryItemARN = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            //this.repositoryItemComboBoxClientGroup = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            //this.repositoryItemComboBoxMemberName = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            ////this.repositoryItemComboBoxSecondHolder = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            ////this.repositoryItemComboBoxThirdHolder = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            ////this.repositoryItemTextEditNominee = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            ////this.repositoryItemTextEditGuardian = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            //this.repositoryItemComboBoxModeOfHolding = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            //this.repositoryItemTextEditAMC = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            //this.repositoryItemTextEditFolioNumber = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            //this.repositoryItemComboBoxScheme = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            //this.repositoryItemComboBoxOption = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            //this.repositoryItemTextEditAmount = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            //this.repositoryItemDateEditTransactionDate = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            //this.repositoryItemComboBoxAssignTo = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            //this.repositoryItemComboBoxModeOfExecution = new DevExpress.XtraEditors.Repository.RepositoryItemComboBox();
            //this.repositoryItemTextEditRemark = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            //// 
            //// ARN
            //// 
            //this.ARN.Name = "ARN";
            //this.ARN.Properties.Caption = "ARN";
            //this.ARN.Properties.FieldName = "ARN";
            //this.ARN.Properties.RowEdit = this.repositoryItemARN;
            ////
            //// ClientGroup
            ////
            //this.ClientGroup.Name = "ClientGroup";
            //this.ClientGroup.Properties.Caption = "Client Group";
            //this.ClientGroup.Properties.FieldName = "ClientGroup";
            //this.ClientGroup.Properties.RowEdit = this.repositoryItemComboBoxClientGroup;
            ////
            //// MemberName
            ////
            //this.MemberName.Name = "MemberName";
            //this.MemberName.Properties.Caption = "Member Name";
            //this.MemberName.Properties.FieldName = "MemberName";
            //this.MemberName.Properties.RowEdit = this.repositoryItemComboBoxMemberName;
            //////
            ////// SecondHolder
            //////
            ////this.SecondHolder.Name = "SecondHolder";
            ////this.SecondHolder.Properties.Caption = "Second Holder";
            ////this.SecondHolder.Properties.FieldName = "SecondHolder";
            ////this.SecondHolder.Properties.RowEdit = this.repositoryItemComboBoxSecondHolder;
            //////
            ////// ThirdHolder
            //////
            ////this.ThirdHolder.Name = "ThirdHolder";
            ////this.ThirdHolder.Properties.Caption = "Third Holder";
            ////this.ThirdHolder.Properties.FieldName = "ThirdHolder";
            ////this.ThirdHolder.Properties.RowEdit = this.repositoryItemComboBoxThirdHolder;
            //////
            ////// Nominee
            //////
            ////this.Nominee.Name = "Nominee";
            ////this.Nominee.Properties.Caption = "Nominee";
            ////this.Nominee.Properties.FieldName = "Nominee";
            ////this.Nominee.Properties.RowEdit = this.repositoryItemTextEditNominee;
            //////
            ////// Guardian
            //////
            ////this.Guardian.Name = "Guardian";
            ////this.Guardian.Properties.Caption = "Guardian";
            ////this.Guardian.Properties.FieldName = "Guardian";
            ////this.Guardian.Properties.RowEdit = this.repositoryItemTextEditGuardian;
            ////
            //// ModeOfHolding
            ////
            //this.ModeOfHolding.Name = "ModeOfHolding";
            //this.ModeOfHolding.Properties.Caption = "Mode of Holding";
            //this.ModeOfHolding.Properties.FieldName = "ModeOfHolding";
            //this.ModeOfHolding.Properties.RowEdit = this.repositoryItemComboBoxModeOfHolding;
            ////
            //// AMC
            ////
            //this.AMC.Name = "AMC";
            //this.AMC.Properties.Caption = "AMC";
            //this.AMC.Properties.FieldName = "AMC";
            //this.AMC.Properties.RowEdit = this.repositoryItemTextEditAMC;
            ////
            //// FolioNumber
            ////
            //this.FolioNumber.Name = "FolioNumber";
            //this.FolioNumber.Properties.Caption = "Folio Number";
            //this.FolioNumber.Properties.FieldName = "FolioNumber";
            //this.FolioNumber.Properties.RowEdit = this.repositoryItemTextEditFolioNumber;
            ////
            //// Scheme
            ////
            //this.Scheme.Name = "Scheme";
            //this.Scheme.Properties.Caption = "Scheme";
            //this.Scheme.Properties.FieldName = "Scheme";
            //this.Scheme.Properties.RowEdit = this.repositoryItemComboBoxScheme;
            ////
            //// Option
            ////
            //this.Options.Name = "Option";
            //this.Options.Properties.Caption = "Option";
            //this.Options.Properties.FieldName = "Option";
            //this.Options.Properties.RowEdit = this.repositoryItemComboBoxOption;
            ////
            //// Amount
            ////
            //this.Amount.Name = "Amount";
            //this.Amount.Properties.Caption = "Amount";
            //this.Amount.Properties.FieldName = "Amount";
            //this.Amount.Properties.Format.FormatType = FormatType.Numeric;
            //this.Amount.Properties.RowEdit = this.repositoryItemTextEditAmount;
            ////
            //// Transaction Date
            ////
            //this.TransactionDate.Name = "TransactionDate";
            //this.TransactionDate.Properties.Caption = "Transaction Date";
            //this.TransactionDate.Properties.FieldName = "TransactionDate";
            //this.TransactionDate.Properties.Format.FormatString = string.Format("dd/MM/yyyy");
            //this.TransactionDate.Properties.RowEdit = this.repositoryItemDateEditTransactionDate;
            ////
            //// AssignedTo
            ////
            //this.AssignedTo.Name = "AssignedTo";
            //this.AssignedTo.Properties.Caption = "Assigned To";
            //this.AssignedTo.Properties.FieldName = "AssignedTo";
            //this.AssignedTo.Properties.RowEdit = this.repositoryItemComboBoxAssignTo;
            ////
            //// ModeOfExecution
            ////
            //this.ModeOfExecution.Name = "ModeOfExecution";
            //this.ModeOfExecution.Properties.Caption = "Mode Of Execution";
            //this.ModeOfExecution.Properties.FieldName = "ModeOfExecution";
            //this.ModeOfExecution.Properties.RowEdit = this.repositoryItemComboBoxModeOfExecution;
            ////
            //// Remark
            ////
            //this.Remark.Name = "Remark";
            //this.Remark.Properties.Caption = "Remark";
            //this.Remark.Properties.FieldName = "Remark";
            //this.Remark.Properties.RowEdit = this.repositoryItemTextEditRemark;
            ////
            //// VGridControl
            ////
            //this.vGridTransaction.Name = GRIDNAME;
            //this.vGridTransaction.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            //    | System.Windows.Forms.AnchorStyles.Left)
            //    | System.Windows.Forms.AnchorStyles.Right)));

            //this.vGridTransaction.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            //    this.repositoryItemARN,
            //    this.repositoryItemComboBoxClientGroup,
            //    this.repositoryItemComboBoxMemberName,
            //    //this.repositoryItemComboBoxSecondHolder,
            //    //this.repositoryItemComboBoxThirdHolder,
            //    //this.repositoryItemTextEditNominee,
            //    //this.repositoryItemTextEditGuardian,
            //    this.repositoryItemComboBoxModeOfHolding,
            //this.repositoryItemTextEditAMC,
            //this.repositoryItemTextEditFolioNumber,
            //this.repositoryItemComboBoxScheme,
            //this.repositoryItemComboBoxOption,
            //this.repositoryItemTextEditAmount,
            //this.repositoryItemDateEditTransactionDate,
            //this.repositoryItemComboBoxAssignTo,
            //this.repositoryItemComboBoxModeOfExecution,
            //this.repositoryItemTextEditRemark
            //});

            //this.vGridTransaction.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[] {
            //    this.ARN,
            //    this.ClientGroup,
            //    this.MemberName,
            //    //this.SecondHolder,
            //    //this.ThirdHolder,
            //    //this.Nominee,
            //    //this.Guardian,
            //    this.ModeOfHolding,
            //this.AMC,
            //this.FolioNumber,
            //this.Scheme,
            //this.Options,
            //this.Amount,
            //this.TransactionDate,
            //this.AssignedTo,
            //this.ModeOfExecution,
            //this.Remark});
        }

        public void BindDataSource(Object obj)
        {
            if (obj == null)
            {
                LogDebug("FreshPurchase.BindDataSource()", new ArgumentNullException("object value is null"));
                return;
            }

            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();

            freshPurchase = jsonSerialization.DeserializeFromString<FinancialPlanner.Common.Model.TaskManagement.MFTransactions.FreshPurchase>(obj.ToString());
            this.vGridTransaction.Rows["ARN"].Properties.Value = freshPurchase.Arn;

            this.vGridTransaction.Rows["ClientGroup"].Properties.Value = getClientName(freshPurchase.Cid);
            freshPurchaseTrans.currentClient = ((List<Client>) freshPurchaseTrans.clients).Find(i => i.Name == this.vGridTransaction.Rows["ClientGroup"].Properties.Value.ToString());
            freshPurchaseTrans.loadMembers();
            this.vGridTransaction.Rows["MemberName"].Properties.Value = freshPurchase.MemberName;
            this.vGridTransaction.Rows["FolioNumber"].Properties.Value = freshPurchase.FolioNumber;
            this.vGridTransaction.Rows["AMC"].Properties.Value = freshPurchase.Amc;
            freshPurchaseTrans.repositoryItemAMC.GetDisplayValueByKeyValue(freshPurchase.Amc);
            freshPurchaseTrans.loadScheme(freshPurchase.Amc);
            this.vGridTransaction.Rows["Scheme"].Properties.Value = freshPurchaseTrans.getSchemeName(freshPurchase.Scheme);
            this.vGridTransaction.Rows["ModeOfHolding"].Properties.Value = freshPurchase.ModeOfHolding;
            this.vGridTransaction.Rows["Option"].Properties.Value = freshPurchase.Options;
            this.vGridTransaction.Rows["Amount"].Properties.Value = freshPurchase.Amount;
            this.vGridTransaction.Rows["TransactionDate"].Properties.Value = freshPurchase.TransactionDate;
            this.vGridTransaction.Rows["ModeOfExecution"].Properties.Value = freshPurchase.ModeOfExecution;
            this.vGridTransaction.Rows["Remark"].Properties.Value = freshPurchase.Remark;
        }

        public VGridControl GetGridControl()
        {
            return this.vGridTransaction;
        }

        public void setVGridControl(VGridControl vGrid)
        {
            this.vGridTransaction = vGrid;
            freshPurchaseTrans = new FreshPurchaseTrans();
            freshPurchaseTrans.setVGridControl(vGrid);
            removeUnwantedFields(vGrid);
        }

        private void LogDebug(string name, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = name;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }

        private string getClientName(int cid)
        {
            Client client = new Client();
            return (freshPurchaseTrans.clients.TryGetValue(freshPurchaseTrans.clients.FindIndex(i => i.ID == cid), out client)) ? client.Name : string.Empty;
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
            return new string[] { "SecondHolder","ThirdHolder","Nominee","Guardian" };
        }

        public object GetTransactionType()
        {
            FinancialPlanner.Common.Model.TaskManagement.MFTransactions.AdditionalPurchase additionalPurchase =
                 new FinancialPlanner.Common.Model.TaskManagement.MFTransactions.AdditionalPurchase();
            if (this.vGridTransaction.Rows.Count > 0)
            {
                additionalPurchase.Arn = int.Parse(this.vGridTransaction.Rows["ARN"].Properties.Value.ToString());
                additionalPurchase.Cid = freshPurchaseTrans.currentClient.ID;
                additionalPurchase.ClientGroup = this.vGridTransaction.Rows["ClientGroup"].Properties.Value.ToString();
                additionalPurchase.MemberName = this.vGridTransaction.Rows["MemberName"].Properties.Value.ToString();
                additionalPurchase.ModeOfHolding = this.vGridTransaction.Rows["ModeOfHolding"].Properties.Value.ToString();
                additionalPurchase.Amc = int.Parse(this.vGridTransaction.Rows["AMC"].Properties.Value.ToString());
                additionalPurchase.FolioNumber = this.vGridTransaction.Rows["FolioNumber"].Properties.Value.ToString();
                additionalPurchase.Scheme = freshPurchaseTrans.selectedSchemeId;
                additionalPurchase.Options = this.vGridTransaction.Rows["Option"].Properties.Value.ToString();
                additionalPurchase.Amount = double.Parse( this.vGridTransaction.Rows["Amount"].Properties.Value.ToString());
                additionalPurchase.TransactionDate = (DateTime) this.vGridTransaction.Rows["TransactionDate"].Properties.Value;
                additionalPurchase.ModeOfExecution = this.vGridTransaction.Rows["ModeOfExecution"].Properties.Value.ToString();
                additionalPurchase.Remark = ( this.vGridTransaction.Rows["Remark"].Properties.Value != null) ?
                    this.vGridTransaction.Rows["Remark"].Properties.Value.ToString() : string.Empty;
            }
            return additionalPurchase;
        }

        public bool IsAllRequireInputAvailable()
        {
            return freshPurchaseTrans.IsAllRequireInputAvailable();
        }

        public void SetARN(int arnNo)
        {
            this.vGridTransaction.Rows["ARN"].Properties.Value = arnNo;
        }
    }
}