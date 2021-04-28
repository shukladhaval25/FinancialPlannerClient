﻿using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace FinancialPlannerClient.PlanOptions
{
    public partial class NetWorthAssets : DevExpress.XtraEditors.XtraForm
    {
        Client _client;
        DataTable dtNetWorht;
        public NetWorthAssets(Client client)
        {
            InitializeComponent();
            this._client = client;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            txtYear.Tag = "";
            txtNetWorth.Text ="";
            txtYear.Text = "";
            btnSave.Enabled = true;
            grpNetWorthDetails.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isValidate())
            {
                NetWorth netWorth = new NetWorth()
                {
                    Id = (txtYear.Tag.ToString() == "") ? 0 : int.Parse(txtYear.Tag.ToString()),
                    CId = this._client.ID,
                    Year = int.Parse(txtYear.Text.ToString()),
                    Amount = double.Parse(txtNetWorth.Text.ToString()),
                    UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")),
                    CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")),
                    UpdatedBy = Program.CurrentUser.Id,
                    CreatedBy = Program.CurrentUser.Id,
                    UpdatedByUserName = Program.CurrentUser.UserName,
                    MachineName = System.Environment.MachineName
                };
                NetWorthInfo netWorthInfo = new NetWorthInfo();
                if (netWorthInfo.Save(netWorth))
                {
                    MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadNetWorthData();
                    //_otherItems.LoadData(dtGridOther);
                    //grpItem.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private bool isValidate()
        {
            return (!string.IsNullOrEmpty(txtYear.Text) && !string.IsNullOrEmpty(txtNetWorth.Text)) ? true : false;
        }

        private void NetWorthAssets_Load(object sender, EventArgs e)
        {
            loadNetWorthData();
        }

        private void loadNetWorthData()
        {
            NetWorthInfo netWorthInfo = new NetWorthInfo();
            List<NetWorth> lstNetWorth =(List<NetWorth>) netWorthInfo.Get(this._client.ID);
            dtNetWorht = ListtoDataTable.ToDataTable(lstNetWorth);
            grdNetWorth.DataSource = dtNetWorht;
            gridViewNetWorth.Columns["Id"].Visible = false;
            gridViewNetWorth.Columns["CId"].Visible = false;
            gridViewNetWorth.Columns["CreatedOn"].Visible = false;
            gridViewNetWorth.Columns["CreatedBy"].Visible = false;
            gridViewNetWorth.Columns["UpdatedOn"].Visible = false;
            gridViewNetWorth.Columns["UpdatedBy"].Visible = false;

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            grpNetWorthDetails.Enabled = true;
            btnSave.Enabled = true;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridViewNetWorth.FocusedRowHandle >= 0)
            {
                if (MessageBox.Show("Are you sure, you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    NetWorthInfo netWorthInfo = new NetWorthInfo();
                    NetWorth  netWorth = getNetWorthInfomation();
                    netWorthInfo.Delete(netWorth);
                    loadNetWorthData();
                }
            }
        }

        private void gridViewNetWorth_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            //if (gridViewNetWorth.FocusedRowHandle >= 0)
            //{
            //    NetWorth netWorth  = getNetWorthInfomation();
            //    displayNetworthData(netWorth);
            //}
        }

        private void displayNetworthData(NetWorth netWorth)
        {
            txtYear.Tag = netWorth.Id;
            txtYear.Text = netWorth.Year.ToString();
            txtNetWorth.Text = netWorth.Amount.ToString();

        }

        private NetWorth  getNetWorthInfomation()
        {
            int rowIndex = gridViewNetWorth.FocusedRowHandle;
            int bankID = int.Parse(gridViewNetWorth.GetFocusedRowCellValue("Id").ToString());
            DataRow[] drs = dtNetWorht.Select("ID ='" + bankID + "'");
            NetWorth  netWorth  = new NetWorth();
            if (drs != null)
            {
                DataRow dr = drs[0];

                netWorth.Id = int.Parse(dr["ID"].ToString());
                netWorth.CId = int.Parse(dr["CID"].ToString());
                netWorth.Year = int.Parse(dr["Year"].ToString());
                netWorth.Amount = double.Parse(dr["Amount"].ToString());
            }
            return netWorth;
        }

        private void gridViewNetWorth_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            if (gridViewNetWorth.FocusedRowHandle >= 0)
            {
                NetWorth netWorth = getNetWorthInfomation();
                displayNetworthData(netWorth);
            }
        }
    }
}