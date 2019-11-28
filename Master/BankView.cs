using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FinancialPlannerClient.Clients;
using FinancialPlanner.Common.Model.Masters;
using FinancialPlanner.Common.DataConversion;
using System.Diagnostics;
using System.Reflection;
using FinancialPlanner.Common;

namespace FinancialPlannerClient.Master
{
    public partial class BankView : DevExpress.XtraEditors.XtraForm
    {
        IList<Bank> BankDetails;
        DataTable dtBank;
        public BankView()
        {
            InitializeComponent();
        }

        private void Bank_Load(object sender, EventArgs e)
        {
            fillupBank();
        }

        private void fillupBank()
        {
            BankInfo bankInfo = new BankInfo();
            BankDetails  = bankInfo.GetAll();
            if (BankDetails != null && BankDetails.Count > 0)
            {
                dtBank = ListtoDataTable.ToDataTable(BankDetails.ToList());
                gridBank.DataSource = dtBank;
                setgridViewDisplay();
            }
        }

        private void setgridViewDisplay()
        {
            gridViewBank.Columns["Id"].Visible = false;
            gridViewBank.Columns["CreatedOn"].Visible = false;
            gridViewBank.Columns["CreatedBy"].Visible = false;
            gridViewBank.Columns["UpdatedOn"].Visible = false;
            gridViewBank.Columns["UpdatedBy"].Visible = false;
            gridViewBank.Columns["UpdatedByUserName"].Visible = false;
            gridViewBank.Columns["MachineName"].Visible = false;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grpBankDetails.Enabled = true;
            setDefaultValue();
        }

        private void setDefaultValue()
        {
            txtBankName.Tag = "0";
            txtBankName.Text = string.Empty;
            txtBranch.Text = string.Empty;
            txtAddress.Text = string.Empty;
            txtCity.Text = string.Empty;
            txtState.Text = string.Empty;
            txtPincode.Text = string.Empty;
            txtIFSC.Text = string.Empty;
            txtMICR.Text = string.Empty;
            txtCountry.Text = string.Empty;
        }

        private void btnCancelBankAccount_Click(object sender, EventArgs e)
        {
            grpBankDetails.Enabled = false;
        }

        private void btnSaveBankAccount_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBankName.Text) || string.IsNullOrEmpty(txtBranch.Text) || 
                string.IsNullOrEmpty(txtIFSC.Text) || string.IsNullOrEmpty(txtMICR.Text))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Please enter all requie fields (Name,Branch,IFSC,MICR).", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
            }
           
            Bank bank = getBankObject();

            if ((bank != null && bank.Id == 0) && isDuplicateIFSCCode())
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(string.Format("IFSC: {0} already exists. Please check bank and branch details.", txtIFSC.Text), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            BankInfo bankInfo = new BankInfo();
           
            bool isSaved = false;
            if (bank != null && bank.Id == 0)
                isSaved = bankInfo.Add(bank);
            else
                isSaved = bankInfo.Update(bank);

            if (isSaved)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Record save successfully.",
                   "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fillupBank();
                grpBankDetails.Enabled = false;
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Unable to save record.",
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool isDuplicateIFSCCode()
        {
            int recordCount = dtBank.Select("IFSC = '" + txtIFSC.Text +"'").Count();
            return (recordCount > 0);
        }

        private Bank getBankObject()
        {
            Bank bank = new Bank();
            bank.Id = string.IsNullOrEmpty(txtBankName.Tag.ToString()) ? 0 : 
                int.Parse(txtBankName.Tag.ToString());
            bank.Name = txtBankName.Text;
            bank.Branch = txtBranch.Text;
            bank.Address = txtAddress.Text;
            bank.City = txtCity.Text;
            bank.State = txtState.Text;
            bank.Country = txtCountry.Text;
            if (!string.IsNullOrEmpty(txtPincode.Text))
            bank.Pincode = int.Parse(txtPincode.Text);
            bank.IFSC = txtIFSC.Text;
            bank.MICR = txtMICR.Text;
            bank.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            bank.CreatedBy = Program.CurrentUser.Id;
            bank.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            bank.UpdatedBy = Program.CurrentUser.Id;
            bank.UpdatedByUserName = Program.CurrentUser.UserName;
            bank.MachineName = Environment.MachineName;
            return bank;
        }

        private void gridViewBank_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if (gridViewBank.FocusedRowHandle >= 0)
            {
                Bank bank = getBankByFocusedRow();
                displayBanK(bank);
            }
        }

        private void displayBanK(Bank bank)
        {
            try
            {
                txtBankName.Tag = bank.Id;
                txtBankName.Text = bank.Name;
                txtBranch.Text = bank.Branch;
                txtCity.Text = bank.City;
                txtState.Text = bank.State;
                txtAddress.Text = bank.Address;
                txtCountry.Text = bank.Country;
                txtPincode.Text = (bank.Pincode != null) ?
                    bank.Pincode.ToString(): null;
                txtIFSC.Text = bank.IFSC;
                txtMICR.Text = bank.MICR;
            }
            catch(Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                throw ex;
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

        private Bank getBankByFocusedRow()
        {
            int rowIndex = gridViewBank.FocusedRowHandle;
            int bankID = int.Parse(gridViewBank.GetFocusedRowCellValue("Id").ToString());
            DataRow[] drs = dtBank.Select("ID ='" + bankID + "'");
            Bank bank = new Bank();
            if (drs != null)
            {
                DataRow dr = drs[0];
                bank.Id = int.Parse(dr.Field<string>("ID"));
                bank.Name = dr.Field<string>("Name");
                bank.Branch  = dr.Field<string>("Branch");
                bank.Address = dr.Field<string>("Address");
                bank.City = dr.Field<string>("City");
                bank.State = dr.Field<string>("State");
                bank.Country = dr.Field<string>("Country");
                //bank.Pincode = dr.Field<int>("Pincode");
                bank.IFSC = dr.Field<string>("IFSC");
                bank.MICR = dr.Field<string>("MICR");                
            }
            return bank;
        }

        private void gridViewBank_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridViewBank.FocusedRowHandle >= 0)
            {
                Bank bank = getBankByFocusedRow();
                displayBanK(bank);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (gridViewBank.FocusedRowHandle >= 0)
            {
                Bank bank = getBankByFocusedRow();
                displayBanK(bank);
                grpBankDetails.Enabled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridViewBank.FocusedRowHandle >= 0)
            {
                if (MessageBox.Show("Are you sure, you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    BankInfo bankInfo = new BankInfo();
                    Bank bank = getBankByFocusedRow();
                    bankInfo.Delete(bank);
                    fillupBank();
                }
            }
        }
    }
}