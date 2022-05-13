using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.CurrentStatus;
using FinancialPlannerClient.CurrentStatus;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialPlannerClient.Controls
{
    public partial class frmTodayReminder : Form
    {
        DateTime searchDate;
        public frmTodayReminder(DateTime dateTime)
        {
            InitializeComponent();
            searchDate = dateTime;
        }

        private void frmTodayReminder_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            //this.Close();
            ////mon.TopLevel = false;
            //string name = this.Parent.Parent.Controls[0].Name;
            //customReminder.Visible = true;
            //homeNavigationPage1.Name = customReminder.Name;
            //homeNavigationPage1.Controls.Add(customReminder);
            //showNavigationPage(customReminder.Name);
        }

        private void frmTodayReminder_Load(object sender, EventArgs e)
        {
            displayReminderData();
        }

        private async void displayReminderData()
        {
            try
            {
                string[] reminders = new string[] { "Date of Birth(Client)", "PPF", "Bond", "FD" };

                //if (string.IsNullOrEmpty(dtFrom.Text) || string.IsNullOrEmpty(dtTo.Text))
                //{
                //    MessageBox.Show("Please select proper from and to date.", "Invalid Data");
                //    return;
                //}
                //dtTo.DateTime = dtTo.DateTime.AddDays(1);
                int count = 0;
                foreach (string opt in reminders)
                {
                    if (opt.Equals("Date of Birth(Client)"))
                    {
                        ClientDOBReminder clientDOBReminder = new ClientDOBReminder();
                        DataTable dtResult = await Task.Run(() => clientDOBReminder.GetRecord(searchDate, searchDate.AddDays(1)));
                        if (dtResult != null)
                        {
                            count = count + dtResult.Rows.Count;
                            grdDOB.DataSource = dtResult;
                        }
                    }
                    if (opt.Equals("PPF"))
                    {
                        PPFInfo ppfInfo = new PPFInfo();
                        IList<PPFMaturity> ppfs = await Task.Run(() => ppfInfo.GetPPFMaturity(searchDate, searchDate.AddDays(1)));
                        DataTable dtResult = ListtoDataTable.ToDataTable(ppfs.ToList());
                        if (dtResult != null)
                        {
                            count = count + dtResult.Rows.Count;
                            grdPPF.DataSource = dtResult;
                        }
                    }
                    if (opt.Equals("FD"))
                    {
                        FDInfo fdInfo = new FDInfo();
                        IList<FixedDeposit> ppfs = await Task.Run(() => fdInfo.GetFDMaturity(searchDate, searchDate.AddDays(1)));
                        DataTable dtResult = ListtoDataTable.ToDataTable(ppfs.ToList());
                        if (dtResult != null)
                        {
                            grdFD.DataSource = dtResult;
                            count = count + dtResult.Rows.Count;
                            gridViewFD.Columns["Id"].Visible = false;
                            gridViewFD.Columns["Pid"].Visible = false;
                            gridViewFD.Columns["CreatedOn"].Visible = false;
                            gridViewFD.Columns["CreatedBy"].Visible = false;
                            gridViewFD.Columns["UpdatedBy"].Visible = false;
                            gridViewFD.Columns["UpdatedOn"].Visible = false;
                            gridViewFD.Columns["MachineName"].Visible = false;
                            gridViewFD.Columns["UpdatedByUserName"].Visible = false;
                            gridViewFD.Columns["IntRate"].Visible = false;
                            gridViewFD.Columns["GoalId"].Visible = false;
                        }
                    }
                    if (opt.Equals("Bond"))
                    {
                        BondInfo bondInfo = new BondInfo();
                        IList<Bonds> ppfs = await Task.Run(() => bondInfo.GetMaturity(searchDate, searchDate.AddDays(1)));
                        DataTable dtResult = ListtoDataTable.ToDataTable(ppfs.ToList());
                        if (dtResult != null)
                        {
                            grdBond.DataSource = dtResult;
                            gridViewBond.Columns["Id"].Visible = false;
                            gridViewBond.Columns["Pid"].Visible = false;
                            gridViewBond.Columns["Rate"].Visible = false;
                            gridViewBond.Columns["GoalId"].Visible = false;
                            gridViewBond.Columns["NoOfBond"].Visible = false;
                            gridViewBond.Columns["FaceValue"].Visible = false;
                            gridViewBond.Columns["InvestmentReturnRate"].Visible = false;
                            gridViewBond.Columns["CreatedOn"].Visible = false;
                            gridViewBond.Columns["CreatedBy"].Visible = false;
                            gridViewBond.Columns["UpdatedBy"].Visible = false;
                            gridViewBond.Columns["UpdatedOn"].Visible = false;
                            gridViewBond.Columns["MachineName"].Visible = false;
                            gridViewBond.Columns["UpdatedByUserName"].Visible = false;
                            count = count + dtResult.Rows.Count;
                        }
                    }
                }
                if (count == 0)
                {
                    this.Close();
                }
            }
            catch(Exception ex)
            {
                this.Close();
            }
        }
    }
}
