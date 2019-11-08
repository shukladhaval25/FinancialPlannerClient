using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.Masters;
using FinancialPlannerClient.PlannerInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FinancialPlannerClient.Clients
{
    public partial class BankDetails : DevExpress.XtraEditors.XtraForm
    {
        PersonalInformation personalInformation;
        DataTable _dtBankAccount = new DataTable();
        public BankDetails(PersonalInformation personalInformation)
        {
            InitializeComponent();
            this.personalInformation = personalInformation;
        }

        private void fillupBankAccountInfo()
        {
            BankAccountInfo bankAccountInfo = new BankAccountInfo();
            IList<BankAccountDetail> bankAcDetails = bankAccountInfo.GetAll(personalInformation.Client.ID);
            if (bankAcDetails != null)
            {
                _dtBankAccount = ListtoDataTable.ToDataTable(bankAcDetails.ToList());
                gridBankAccount.DataSource =  _dtBankAccount;
                setgridViewDisplay();
            }
            fillListOfAccountHolders();
        }

        private void setgridViewDisplay()
        {
            gridViewBankAccount.Columns["Id"].Visible = false;

            gridViewBankAccount.Columns[0].Visible = false;
            gridViewBankAccount.Columns[1].Visible = false;
            gridViewBankAccount.Columns[2].Visible = false;

            gridViewBankAccount.Columns[3].Caption = "Bank Name";
            gridViewBankAccount.Columns[4].Caption = "Account Type";
            gridViewBankAccount.Columns[5].Caption = "Account No";
            gridViewBankAccount.Columns[6].Caption = "Branch";
            gridViewBankAccount.Columns[7].Caption = "ContactNo";
            gridViewBankAccount.Columns[8].Visible = false;
            gridViewBankAccount.Columns[9].Visible = false;
            gridViewBankAccount.Columns[10].Caption = "Minimum Require Balance";
            gridViewBankAccount.Columns["CreatedOn"].Visible = false;
            gridViewBankAccount.Columns["CreatedBy"].Visible = false;
            gridViewBankAccount.Columns["UpdatedOn"].Visible = false;
            gridViewBankAccount.Columns["UpdatedBy"].Visible = false;
            gridViewBankAccount.Columns["UpdatedByUserName"].Visible = false;
            gridViewBankAccount.Columns["MachineName"].Visible = false;
            gridViewBankAccount.Columns["BankId"].Visible = false;
        }

        private void fillListOfAccountHolders()
        {
            cmbAccountHolder.Properties.Items.Clear();
            cmbAccountHolder.Properties.Items.Add(personalInformation.Client.Name);
            cmbAccountHolder.Properties.Items.Add(personalInformation.Spouse.Name);
        }

        private void btnAddBankAcc_Click(object sender, EventArgs e)
        {
            grpBankAccountDetails.Enabled = true;
            setDefaultValueForBankAccountDetails();
        }

        private void setDefaultValueForBankAccountDetails()
        {
            cmbAccountHolder.Text = personalInformation.Client.Name;
            cmbAccountHolder.Tag = personalInformation.Client.ID;
            lookupBank.Tag = null;
            txtBankName.Text = "";
            txtAccountNo.Text = "";
            txtAccountNo.Tag = "0";
            cmbAccountType.Text = "";
            txtBranchAddress.Text = "";
            txtBranchContactNo.Text = "";
            rdoNoJoinAC.Checked = true;
            txtJoinHolderName.Text = "";
            txtMinReqBalance.Text = "0";
        }

        private void btnEditBankAcc_Click(object sender, EventArgs e)
        {
            grpBankAccountDetails.Enabled = true;
        }

        private void btnDeleteBankAcc_Click(object sender, EventArgs e)
        {
            if (gridViewBankAccount.FocusedRowHandle >= 0)
            {
                if (MessageBox.Show("Are you sure, you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BankAccountInfo bankAcInfo = new BankAccountInfo();
                    BankAccountDetail bank = getBankDetailsByFocusedRow();                    
                    bankAcInfo.Delete(bank);
                    fillupBankAccountInfo();
                }
            }
        }

        private void cmbAccountHolder_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbAccountHolder.Text == personalInformation.Client.Name)
                cmbAccountHolder.Tag = personalInformation.Client.ID;
            else if (cmbAccountHolder.Text == personalInformation.Spouse.Name)
                cmbAccountHolder.Tag = personalInformation.Spouse.ID;
        }
    
        private void displayBankAccountData(BankAccountDetail bankAccount)
        {
            if (bankAccount != null)
            {
                cmbAccountHolder.Tag = bankAccount.AccountHolderID.ToString();
                cmbAccountHolder.Text = (bankAccount.AccountHolderID == personalInformation.Client.ID) ?
                    personalInformation.Client.Name : personalInformation.Spouse.Name;
                txtBankName.Text = bankAccount.BankName;
                txtAccountNo.Tag = bankAccount.Id;
                txtAccountNo.Text = bankAccount.AccountNo;
                cmbAccountType.Text = bankAccount.AccountType;
                txtBranchAddress.Text = bankAccount.Address;
                txtBranchContactNo.Text = bankAccount.ContactNo;
                rdoYesJoinAC.Checked = bankAccount.IsJoinAccount;
                txtJoinHolderName.Text = bankAccount.JoinHolderName;
                txtMinReqBalance.Text = bankAccount.MinRequireBalance.ToString();
                lookupBank.Text = bankAccount.BankName;
                lookupBank.Tag = bankAccount.BankId;
            }
        }

        private void btnCancelBankAccount_Click(object sender, EventArgs e)
        {
            grpBankAccountDetails.Enabled = false;
            BankAccountDetail bank = getBankDetailsByFocusedRow();
            displayBankAccountData(bank);
        }

        private void btnSaveBankAccount_Click(object sender, EventArgs e)
        {
            BankAccountInfo bankAccInfo = new BankAccountInfo();
            BankAccountDetail bankAcDetails = getBankDetailsData();
            bool isSaved = false;

            if (bankAcDetails != null && bankAcDetails.Id == 0)
                isSaved = bankAccInfo.Add(bankAcDetails);
            else
                isSaved = bankAccInfo.Update(bankAcDetails);

            if (isSaved)
            {
                MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fillupBankAccountInfo();
                grpBankAccountDetails.Enabled = false;
            }
            else
                MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private BankAccountDetail getBankDetailsData()
        {
            BankAccountDetail bankACDetails = new BankAccountDetail();
            bankACDetails.Id = int.Parse(txtAccountNo.Tag.ToString());
            bankACDetails.Cid = personalInformation.Client.ID;
            bankACDetails.AccountHolderID = int.Parse(cmbAccountHolder.Tag.ToString());
            bankACDetails.BankName = txtBankName.Text;
            bankACDetails.AccountNo = txtAccountNo.Text;
            bankACDetails.AccountType = cmbAccountType.Text;
            bankACDetails.Address = txtBranchAddress.Text;
            bankACDetails.ContactNo = txtBranchContactNo.Text;
            bankACDetails.IsJoinAccount = rdoYesJoinAC.Checked;
            bankACDetails.JoinHolderName = (rdoYesJoinAC.Checked) ? txtJoinHolderName.Text : string.Empty;
            bankACDetails.MinRequireBalance = double.Parse(txtMinReqBalance.Text);
            bankACDetails.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            bankACDetails.CreatedBy = Program.CurrentUser.Id;
            bankACDetails.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            bankACDetails.UpdatedBy = Program.CurrentUser.Id;
            bankACDetails.UpdatedByUserName = Program.CurrentUser.UserName;
            bankACDetails.MachineName = Environment.MachineName;
            bankACDetails.BankId = (lookupBank.EditValue == null) ? 0 : int.Parse(lookupBank.EditValue.ToString());
            return bankACDetails;
        }

        private void BankDetails_Load(object sender, EventArgs e)
        {
            fillupBankAccountInfo();
            fillupBankMaster();
        }

        private void fillupBankMaster()
        {
            BankInfo bankInfo = new BankInfo();
            List<Bank> banks = (List<Bank>)bankInfo.GetAll();
            DataTable dtBank = ListtoDataTable.ToDataTable(banks);
            lookupBank.Properties.DataSource = dtBank;
        }

        private void lookupBank_EditValueChanged(object sender, EventArgs e)
        {
            var dataRow = lookupBank.GetSelectedDataRow();
            if (dataRow != null)
            {
                txtBankName.Text = ((System.Data.DataRowView)dataRow).Row.ItemArray[1].ToString();
                lookupBank.Tag = int.Parse(lookupBank.EditValue.ToString());
            }
        }

        private void gridViewBankAccount_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (gridViewBankAccount.FocusedRowHandle >= 0)
            {
                BankAccountDetail bank = getBankDetailsByFocusedRow();
                displayBankAccountData(bank);
            }
        }

        private void gridViewBankAccount_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridViewBankAccount.FocusedRowHandle >= 0)
            {
                BankAccountDetail bank = getBankDetailsByFocusedRow();
                displayBankAccountData(bank);
            }
        }

        private BankAccountDetail getBankDetailsByFocusedRow()
        {
            int rowIndex = gridViewBankAccount.FocusedRowHandle;
            int bankID = int.Parse(gridViewBankAccount.GetFocusedRowCellValue("Id").ToString());
            DataRow[] drs = _dtBankAccount.Select("ID ='" + bankID + "'");
            BankAccountDetail bank = new BankAccountDetail();
            if (drs != null)
            {
                DataRow dr = drs[0];
               
                bank.Id = int.Parse(dr.Field<string>("ID"));
                bank.Cid = int.Parse(dr.Field<string>("CID"));
                bank.BankName = dr.Field<string>("BankName");
                bank.AccountNo = dr.Field<string>("AccountNo");
                bank.AccountType = dr.Field<string>("AccountType");
                bank.Address = dr.Field<string>("Address");
                bank.ContactNo = dr.Field<string>("ContactNo");
                bank.IsJoinAccount = bool.Parse(dr.Field<string>("IsJoinAccount"));
                bank.JoinHolderName = dr.Field<string>("JoinHolderName");
                bank.MinRequireBalance = Double.Parse(dr.Field<string>("MinRequireBalance"));
                bank.BankId = (dr["BankId"] == null) ? 0 : int.Parse(dr.Field<string>("BankId"));
            }
            return bank;
        }

        private void txtMinReqBalance_KeyPress(object sender, KeyPressEventArgs e)
        {
            // allows 0-9, backspace, and decimal
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8))
            {
                e.Handled = true;
                return;
            }
        }

        private void txtMinReqBalance_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtMinReqBalance.Text))
                e.Cancel = !FinancialPlanner.Common.Validation.IsDigit(txtMinReqBalance.Text);
        }

        private void cmbAccountType_Enter(object sender, EventArgs e)
        {
            cmbAccountType.Items.Clear();
            if (this.personalInformation.Client.ResiStatus != "Indian")
            {
                
                cmbAccountType.Items.Add("NRE");
                cmbAccountType.Items.Add("NRO");
            }
            else
            {
                cmbAccountType.Items.Add("SA");
                cmbAccountType.Items.Add("CA");
            }
        }       
    }
}
