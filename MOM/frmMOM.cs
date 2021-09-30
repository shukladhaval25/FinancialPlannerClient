using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.TaskManagement;
using FinancialPlannerClient.Master;
using FinancialPlannerClient.TaskManagementSystem;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TaskStatus = FinancialPlanner.Common.Model.TaskManagement.TaskStatus;

namespace FinancialPlannerClient.MOM
{
    public partial class frmMOM : DevExpress.XtraEditors.XtraForm
    {
        Client client;
        DataTable dtMOM;
        DataTable dtMOMPoints;
        MOMInfo momInfo;
        List<MOMTransaction> mOMTransactions;
        List<User> users;
        public frmMOM(FinancialPlanner.Common.Model.Client client)
        {
            InitializeComponent();
            this.client = client;
        }

        private void frmMOM_Load(object sender, EventArgs e)
        {
            if (this.client == null)
            {
                throw new Exception("Invalid client");
            }

            repositoryItemComboBoxResponsibility.Items.Clear();
            repositoryItemComboBoxResponsibility.Items.Add("Client");
            repositoryItemComboBoxResponsibility.Items.Add("Ascent Finance Solution");

            UserServiceHelper userServiceHelper = new UserServiceHelper();
            users = userServiceHelper.GetAll();
            if (users != null)
            {
                foreach (User user in users)
                {
                    repositoryItemComboBoxEmployee.Items.Add(user.UserName);
                }
            }

            fillMOM();
        }

        private void fillMOM()
        {
            momInfo = new MOMInfo();
            var obj = momInfo.GetAll(this.client.ID);
            if (obj != null)
            {
                mOMTransactions = obj.ToList();
                dtMOM = ListtoDataTable.ToDataTable(obj.ToList());
                gridMOM.DataSource = dtMOM;
                gridViewMoM.Columns["MId"].Visible = false;
                gridViewMoM.Columns["CId"].Visible = false;
                gridViewMoM.Columns["MOMPoints"].Visible = false;
                //gridViewMOMPoints.Columns["EmpId"].Visible = false;
                gridViewMOMPoints.Columns["UserName"].VisibleIndex = 2;
                gridViewMOMPoints.Columns["UserName"].Caption = "Employee";
                gridViewMOMPoints.Columns["DiscussedPoint"].Width = 90;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            dtMeetingDate.Value = DateTime.Now.Date;
            dtMeetingDate.Tag = "0";
            chkIsImportantMeeting.Checked = false;
            txtClientName.Text = this.client.Name;
            txtMeetingType.Text = "";
            txtNotes.Text = "";
            txtDuration.Text = "";
            if (dtMOMPoints == null)
            {
                MOMTransaction transaction = new MOMTransaction();
                transaction.MOMPoints = new List<MOMPoint>();
                dtMOMPoints = ListtoDataTable.ToDataTable(transaction.MOMPoints.ToList());
                gridMOMPoints.DataSource = dtMOMPoints;
            }
            dtMOMPoints.Rows.Clear();
        }

        private void gridViewMoM_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridViewMoM.FocusedRowHandle >= 0)
            {
                dtMeetingDate.Tag = gridViewMoM.GetFocusedRowCellValue(gridViewMoM.Columns["MId"]).ToString();
                dtMeetingDate.Value = DateTime.Parse(gridViewMoM.GetFocusedRowCellValue(gridViewMoM.Columns["MeetingDate"]).ToString());
                chkIsImportantMeeting.Checked = bool.Parse(gridViewMoM.GetFocusedRowCellValue(gridViewMoM.Columns["MarkAsImportant"]).ToString());
                txtClientName.Tag = gridViewMoM.GetFocusedRowCellValue(gridViewMoM.Columns["CId"]).ToString();
                txtClientName.Text = this.client.Name;
                txtMeetingType.Text = gridViewMoM.GetFocusedRowCellValue(gridViewMoM.Columns["MeetingType"]).ToString();
                txtDuration.Text = gridViewMoM.GetFocusedRowCellValue(gridViewMoM.Columns["Duration"]).ToString();
                txtNotes.Text = gridViewMoM.GetFocusedRowCellValue(gridViewMoM.Columns["Notes"]).ToString();

                int Mid = int.Parse(dtMeetingDate.Tag.ToString());
                MOMTransaction transaction =  mOMTransactions.First(i => i.MId == Mid);
                dtMOMPoints = ListtoDataTable.ToDataTable(transaction.MOMPoints.ToList());
                gridMOMPoints.DataSource = dtMOMPoints;
                //gridViewMOMPoints.Columns["Id"].Visible = false;
                //gridViewMOMPoints.Columns["MId"].Visible = false;
                //gridViewMOMPoints.Columns["FeatureAction"].Visible = false;

            }
        }

        private void gridViewMOMPoints_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.Caption == "Employee")
            {
                User user = users.First(i => i.UserName == e.Value.ToString());
                if (user != null)
                {
                    gridViewMOMPoints.SetRowCellValue(e.RowHandle, "EmpId", user.Id);
                }
            }
            else if (e.Column.Caption == "Link Task Id")
            {
                TaskCardService taskCardService = new TaskCardService();
                IList<TaskCard> taskCards =   taskCardService.GetTaskByTaskId(e.Value.ToString());
                if (taskCards != null)
                {
                    if (taskCards.Count > 0)
                    {
                        gridViewMOMPoints.SetRowCellValue(e.RowHandle,"EmpId", taskCards[0].TaskStatus.ToString());
                    }
                }
            }
        }

        private void btnAddMoMPoints_Click(object sender, EventArgs e)
        {
            gridViewMOMPoints.AddNewRow();
        }

        private void btnRemoveMoMPoints_Click(object sender, EventArgs e)
        {
            try
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete selected record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = 0;
                    int.TryParse(gridViewMOMPoints.GetRowCellValue(gridViewMoM.FocusedRowHandle, "Id").ToString(), out id);
                    bool isDelete = false;
                    if (id > 0)
                    {
                        isDelete = momInfo.DeleteMomPoint(id);
                    }
                    else
                    {
                        isDelete = true;
                    }

                    if (isDelete)
                    {
                        gridViewMOMPoints.DeleteRow(gridViewMOMPoints.FocusedRowHandle);
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Unable to delete this record. Please try again.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch(Exception ex)
            {

            }
        }

        private void repositoryItemButtonAddTask_Click(object sender, EventArgs e)
        {
            NewTaskCard newTask = new NewTaskCard();
            newTask.StartPosition = FormStartPosition.CenterParent;
            newTask.ShowDialog();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (!isValidateRecord())
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Please enter all require fields.",
                          "Invalid Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                MOMTransaction momTransaction = getMOMTransction();
                bool isSucess;
                if (momTransaction.MId == 0)
                {
                    isSucess = momInfo.Add(momTransaction);
                }
                else
                {
                    isSucess = momInfo.UpdateMOM(momTransaction);
                }

                if (isSucess)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Record saved sucessfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Unable to saved this record.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Error :" + ex.ToString(),
               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private MOMTransaction getMOMTransction()
        {
            MOMTransaction momTransaction = new MOMTransaction();
            momTransaction.MId = int.Parse(dtMeetingDate.Tag.ToString());
            momTransaction.CId = this.client.ID;
            momTransaction.MeetingDate = dtMeetingDate.Value;
            momTransaction.MarkAsImportant = chkIsImportantMeeting.Checked;
            momTransaction.MeetingType = txtMeetingType.Text;
            momTransaction.Duration = txtDuration.Text;
            momTransaction.Notes = txtNotes.Text;
            momTransaction.MOMPoints = new List<MOMPoint>();
            for (int rowIndex = 0; rowIndex <= gridViewMOMPoints.RowCount - 1; rowIndex++)
            {
                MOMPoint point = new MOMPoint();
                int id,EmpId = 0;
                int.TryParse(gridViewMOMPoints.GetRowCellValue(rowIndex, "Id").ToString(), out id);
                point.Id = id;
                point.MId = momTransaction.MId;
                point.DiscussedPoint = gridViewMOMPoints.GetRowCellValue(rowIndex, "DiscussedPoint").ToString();
                point.Responsibility = gridViewMOMPoints.GetRowCellValue(rowIndex, "Responsibility").ToString();

                int.TryParse(gridViewMOMPoints.GetRowCellValue(rowIndex, "EmpId").ToString(), out EmpId);
                point.EmpId  =  EmpId;

                point.TaskId = gridViewMOMPoints.GetRowCellValue(rowIndex, "TaskId").ToString();
                momTransaction.MOMPoints.Add(point);
            }
            return momTransaction;
        }

        private bool isValidateRecord()
        {
            if ((dtMeetingDate.Value != null) && !string.IsNullOrEmpty(txtMeetingType.Text) &&
                    !string.IsNullOrEmpty(txtClientName.Text) && !string.IsNullOrEmpty(txtDuration.Text))
            {
                return true;
            }
            return false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridViewMoM.FocusedRowHandle >= 0)
            {
                if ((DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this record?",
                  "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {

                    int mid= 0;
                    int.TryParse(gridViewMOMPoints.GetRowCellValue(gridViewMoM.FocusedRowHandle, "MId").ToString(), out mid);

                    if (!momInfo.DeleteMom(mid))
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Unable to delete this record.",
                            "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        fillMOM();
                }
            }

        }
    }
}
