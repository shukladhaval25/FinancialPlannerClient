using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialPlanner.Common.Model.CurrentStatus;
using System.Data.Common;

namespace FinancialPlannerClient.CurrentStatus
{
    public partial class MFTransactionsForm : Form
    {
        private MutualFund mf;
        private DataTable _dtMFTrans;

        public MFTransactionsForm()
        {
            InitializeComponent();
        }

        public MFTransactionsForm(MutualFund mf)
        {
            InitializeComponent();
            this.mf = mf;
        }

        private void MFTransactions_Load(object sender, EventArgs e)
        {
            //if (this.mf != null)
            //{
            //    lblMFNameValue.Text = mf.SchemeName;
            //    lblSchemenameVal.Text = mf.SchemeName;
            //    lblFolioNoVal.Text = mf.FolioNo;
            //    fillMFTransData();
            //}
        }

        private void fillMFTransData()
        {
            MFTransInfo mfTransInfo = new MFTransInfo();
            _dtMFTrans = mfTransInfo.GetMFTransactionsInfo(mf.Id);
            if (_dtMFTrans != null && _dtMFTrans.Rows.Count == 0)
            {
                addBalanceCFRow();
            }
            dtGridMFTrans.DataSource = _dtMFTrans;
            dtGridMFTrans.Columns["ID"].Visible = false;
            dtGridMFTrans.Columns["MFID"].Visible = false;
            dtGridMFTrans.Columns["TransactionDate"].HeaderText = "Trans. Date";
            dtGridMFTrans.Columns["TransactionDate"].DisplayIndex = 1;

            dtGridMFTrans.Columns["TransactionType"].HeaderText = "Trans. Type";
            dtGridMFTrans.Columns["TransactionType"].DisplayIndex = 2;
            dtGridMFTrans.Columns["NAV"].DisplayIndex = 3;
            dtGridMFTrans.Columns["Units"].DisplayIndex = 4;
            dtGridMFTrans.Columns["CurrentValue"].DisplayIndex = 5;
            dtGridMFTrans.Columns["BalanceUnits"].DisplayIndex = 6;

            dtGridMFTrans.Columns["NAV"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtGridMFTrans.Columns["Units"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtGridMFTrans.Columns["CurrentValue"].HeaderText = "Value";
            dtGridMFTrans.Columns["CurrentValue"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
            dtGridMFTrans.Columns["BalanceUnits"].HeaderText = "Balance Units";
            dtGridMFTrans.Columns["BalanceUnits"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.BottomRight;
        }

        private void addBalanceCFRow()
        {
            DataRow dr = _dtMFTrans.NewRow() ;
            dr["ID"] = "0";
            dr["MFID"] = mf.Id;
            dr["NAV"] = mf.Nav;
            dr["UNITS"] = mf.Units;
            dr["CurrentValue"] = mf.Nav * mf.Units;
            dr["BalanceUnits"] = mf.Units;
            dr["TransactionType"] = "Op. Bal.";
            dr["TransactionDate"] = mf.CreatedOn;
            _dtMFTrans.Rows.Add(dr);
        }

        private void btnAddMF_Click(object sender, EventArgs e)
        {
            grpMFTransaction.Enabled = true;
            setDefaultMFTransaValue();
        }

        private void setDefaultMFTransaValue()
        {
            lblSchemenameVal.Text = mf.SchemeName;
            lblSchemenameVal.Tag = "0";
            cmbTransType.Text = "";
            txtNav.Text = "0";
            txtUnits.Text = "0";
            txtCurrentValue.Text = "0";

        }

        private void calculateAndSetMFCurrentValue()
        {
            double nav = 0;
            double units = 0;
            double.TryParse(txtNav.Text, out nav);
            double.TryParse(txtUnits.Text, out units);
            txtCurrentValue.Text = (nav * units).ToString();
        }

        private void btnCancelMFTrans_Click(object sender, EventArgs e)
        {
            grpMFTransaction.Enabled = false;
        }

        private void btnSaveMFTrans_Click(object sender, EventArgs e)
        {
            MFTransactions mfTrans = getMFTransData();
            bool isSaved = false;

            MFTransInfo mfTransInfo = new MFTransInfo();

            if (mfTrans != null && mfTrans.Id == 0)
                isSaved = mfTransInfo.Add(mfTrans);
            else
                isSaved = mfTransInfo.Update(mfTrans);

            if (isSaved)
            {
                MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                fillMFTransData();
                grpMFTransaction.Enabled = false;
            }
            else
                MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private MFTransactions getMFTransData()
        {
            MFTransactions mfTrans = new MFTransactions();
            mfTrans.Id = int.Parse(lblSchemenameVal.Tag.ToString());
            mfTrans.MFId = this.mf.Id;
            mfTrans.Nav = float.Parse(txtNav.Text);
            mfTrans.Units = int.Parse(txtUnits.Text);
            mfTrans.TransactionType = cmbTransType.Text;
            mfTrans.TransactionDate = dtTransDate.Value;
            return mfTrans;            
        }

        private void btnDeleteMF_Click(object sender, EventArgs e)
        {
            if (dtGridMFTrans.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure, you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    MFTransInfo mutualFundInfo = new MFTransInfo();
                    MFTransactions mfTrans =  getMFTransData();
                    mutualFundInfo.Delete(mfTrans);
                    fillMFTransData();
                }
            }
        }

        private void txtNav_Leave(object sender, EventArgs e)
        {
            calculateAndSetMFCurrentValue();
        }

        private void txtUnits_Leave(object sender, EventArgs e)
        {
            calculateAndSetMFCurrentValue();
        }
    }
}
