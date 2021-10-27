using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.Masters;
using FinancialPlannerClient.Master;
using FinancialPlannerClient.PlannerInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialPlannerClient.PlanOptions
{
    public partial class RecomendationView : DevExpress.XtraEditors.XtraForm
    {
        Client client;
        Planner planner;
        DataTable dtInsuranceRecomendation;
        DataTable dtRecomendationDetail;
        DataTable dtPersonalAccident;
        InsuranceRecomendationInfo insuranceRecomendationInfo;
        IList<InsuranceRecomendationTransaction> insuranceRecomendationTransactions;
        PersonalInformation personalInfo;
        public RecomendationView(Client client,Planner planner)
        {
            InitializeComponent();
            this.client = client;
            this.planner = planner;
        }

        private void RecomendationView_Load(object sender, EventArgs e)
        {
            if (this.client == null)
            {
                throw new Exception("Invalid client");
            }

            dtRecomendationDetail = new DataTable();
            dtRecomendationDetail.Columns.Add("InsuranceRecMasterId", typeof(System.Int64));
            dtRecomendationDetail.Columns.Add("InsuranceCompanyName", typeof(System.String));
            dtRecomendationDetail.Columns.Add("Term", typeof(System.String));
            dtRecomendationDetail.Columns.Add("SumAssured", typeof(System.String));
            dtRecomendationDetail.Columns.Add("Premium", typeof(System.Double));

            createPersonalAccidentTable();

            fillupClientAndSpouseInformation();
            gridInsuranceRecDetail.DataSource = dtRecomendationDetail;
            //gridViewInsuranceRecDetail.AddNewRow();
            addInsuranceCompanyList();
            fillInsuranceRecomendationGrid();

            fillPersonalInsuranceInformation();
        }

        private void fillPersonalInsuranceInformation()
        {
            gridControlPersonalAccident.DataSource = dtPersonalAccident;
            gridViewPersonalAccident.AddNewRow();
        }

        private void createPersonalAccidentTable()
        {
            dtPersonalAccident = new DataTable();

            dtPersonalAccident.Columns.Add("Id", typeof(System.Int64));
            dtPersonalAccident.Columns.Add("PersonName", typeof(System.String));
            dtPersonalAccident.Columns.Add("InsuranceCompanyName", typeof(System.String));
            dtPersonalAccident.Columns.Add("SumAssured", typeof(System.String));
            dtPersonalAccident.Columns.Add("Premium", typeof(System.Double));
        }

        private void fillupClientAndSpouseInformation()
        {
            new PlannerInfo.FamilyMemberInfo().FillFamilyMemberInCombo(this.client.ID, cmbName);
            foreach(string value in cmbName.Properties.Items)
            {
                repositoryItemCmbClientSpouse.Items.Add(value);
            }
            
        }

        private void fillInsuranceRecomendationGrid()
        {
            insuranceRecomendationInfo = new InsuranceRecomendationInfo();
            insuranceRecomendationTransactions =  insuranceRecomendationInfo.GetAll(this.planner.ID);
            if (insuranceRecomendationTransactions != null)
            {
                
                dtInsuranceRecomendation  = ListtoDataTable.ToDataTable(insuranceRecomendationTransactions.ToList());
                gridControlInsuranceRecomendation.DataSource = dtInsuranceRecomendation;
                gridViewInsuranceRecomendation.Columns["Id"].Visible = false;
                gridViewInsuranceRecomendation.Columns["PId"].Visible = false;
                gridViewInsuranceRecomendation.Columns["CId"].Visible = false;
                gridViewInsuranceRecomendation.Columns["SpouseId"].Visible = false;
                gridViewInsuranceRecomendation.Columns["Name"].VisibleIndex = 1;
                gridViewInsuranceRecomendation.Columns["SumAssured"].VisibleIndex = 2;
                gridViewInsuranceRecomendation.Columns["Description"].Visible = false;
                gridViewInsuranceRecomendation.Columns["InsuranceRecomendationDetails"].Visible = false;

            }
            
        }

        private void addInsuranceCompanyList()
        {
            repositoryItemComboBoxInsuranceCompany.Items.Clear();
           

            InsuranceCompanyInfo insuranceCompanyInfo = new InsuranceCompanyInfo();
            IList<InsuranceCompany> insuranceCompanies = insuranceCompanyInfo.GetAll();
            if (insuranceCompanies != null)
            {
                foreach (InsuranceCompany insuranceCompany in insuranceCompanies)
                {
                    repositoryItemComboBoxInsuranceCompany.Items.Add(insuranceCompany.Name);
                }
            }
        }

        private void gridViewInsuranceRecomendation_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            try
            {
                if (gridViewInsuranceRecomendation.FocusedRowHandle >= 0)
                {
                    lblName.Tag = gridViewInsuranceRecomendation.GetFocusedRowCellValue(gridViewInsuranceRecomendation.Columns["Id"]).ToString();

                    cmbName.Text = gridViewInsuranceRecomendation.GetFocusedRowCellValue(gridViewInsuranceRecomendation.Columns["Name"]).ToString();
                    if (cmbName.Text.Equals(this.client.Name))
                    {
                        cmbName.Tag = gridViewInsuranceRecomendation.GetFocusedRowCellValue(gridViewInsuranceRecomendation.Columns["CId"]).ToString();
                    }
                    else
                    {
                        cmbName.Tag = gridViewInsuranceRecomendation.GetFocusedRowCellValue(gridViewInsuranceRecomendation.Columns["SpouseId"]).ToString();
                    }

                    txtSumAssured.Text = gridViewInsuranceRecomendation.GetFocusedRowCellValue(gridViewInsuranceRecomendation.Columns["SumAssured"]).ToString();
                    txtDescription.Text = gridViewInsuranceRecomendation.GetFocusedRowCellValue(gridViewInsuranceRecomendation.Columns["Description"]).ToString();


                    int id = int.Parse(lblName.Tag.ToString());
                    InsuranceRecomendationTransaction transaction = insuranceRecomendationTransactions.First(i => i.Id == id);
                    dtRecomendationDetail = ListtoDataTable.ToDataTable(transaction.InsuranceRecomendationDetails.ToList());

                    gridInsuranceRecDetail.DataSource = dtRecomendationDetail;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnAddInsRecDetail_Click(object sender, EventArgs e)
        {
            gridViewInsuranceRecDetail.AddNewRow();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            lblName.Tag = "0";
            cmbName.Text = "";
            txtSumAssured.Text = "";
            txtDescription.Text = "";
            btnSave.Enabled = true;

            if (dtRecomendationDetail  == null)
            {
                InsuranceRecomendationTransaction transaction = new InsuranceRecomendationTransaction();
                transaction.InsuranceRecomendationDetails = new List<InsuranceRecomendationDetail>();
                dtRecomendationDetail = ListtoDataTable.ToDataTable(transaction.InsuranceRecomendationDetails.ToList());
                gridInsuranceRecDetail.DataSource = dtRecomendationDetail;
            }
            dtRecomendationDetail.Rows.Clear();
        }

        private void cmbName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbName.Text.Equals(this.client.Name))
            {
                cmbName.Tag = this.client.ID;
            }
            else
            {
                ClientPersonalInfo clientPersonalInfo = new ClientPersonalInfo();
                personalInfo = clientPersonalInfo.Get(this.client.ID);
                cmbName.Tag = personalInfo.Spouse.ID;
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
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
                InsuranceRecomendationTransaction transaction = getInsRecTransction();
                bool isSucess;
                if (transaction.Id == 0)
                {
                    isSucess = insuranceRecomendationInfo.Add(transaction);
                }
                else
                {
                    isSucess = insuranceRecomendationInfo.Update(transaction);
                }

                if (isSucess)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Record saved sucessfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    fillInsuranceRecomendationGrid();
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Unable to saved this record.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Error :" + ex.ToString(),
               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private InsuranceRecomendationTransaction getInsRecTransction()
        {
            InsuranceRecomendationTransaction recomendationTransaction = new InsuranceRecomendationTransaction();
            recomendationTransaction.Id = int.Parse(lblName.Tag.ToString());
            recomendationTransaction.PId = this.planner.ID;
            if (cmbName.Text.Equals(this.client.Name))
            {
                recomendationTransaction.CId = this.client.ID;
                recomendationTransaction.SpouseId = null;
            }
            else
            {
                recomendationTransaction.CId = null;
                recomendationTransaction.SpouseId = int.Parse(cmbName.Tag.ToString());
            }



            recomendationTransaction.SumAssured = txtSumAssured.Text;
            recomendationTransaction.Description = txtDescription.Text;
           
            recomendationTransaction.InsuranceRecomendationDetails = new List<InsuranceRecomendationDetail>();
            for (int rowIndex = 0; rowIndex <= gridViewInsuranceRecDetail.RowCount - 1; rowIndex++)
            {
                InsuranceRecomendationDetail insuranceRecomendationDetail = new InsuranceRecomendationDetail();
                //int id, EmpId = 0;
                //int.TryParse(gridViewInsuranceRecDetail.GetRowCellValue(rowIndex, "Id").ToString(), out id);

                insuranceRecomendationDetail.InsRecMasterId = recomendationTransaction.Id;
                insuranceRecomendationDetail.InsuranceCompanyName = gridViewInsuranceRecDetail.GetRowCellValue(rowIndex, "InsuranceCompanyName").ToString();
                insuranceRecomendationDetail.Term = gridViewInsuranceRecDetail.GetRowCellValue(rowIndex, "Term").ToString();
                insuranceRecomendationDetail.SumAssured = gridViewInsuranceRecDetail.GetRowCellValue(rowIndex, "SumAssured").ToString();
                insuranceRecomendationDetail.Premium = double.Parse(gridViewInsuranceRecDetail.GetRowCellValue(rowIndex, "Premium").ToString());
                recomendationTransaction.InsuranceRecomendationDetails.Add(insuranceRecomendationDetail);
            }
            return recomendationTransaction;
        }

        private bool isValidateRecord()
        {
            if (string.IsNullOrEmpty(cmbName.Text) || string.IsNullOrEmpty(txtSumAssured.Text) )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void btnRemoveInsRecDetail_Click(object sender, EventArgs e)
        {
            try
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete selected record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = 0;
                    int.TryParse(lblName.Tag.ToString(), out id);
                    string insuranceCompanyName = gridViewInsuranceRecDetail.GetRowCellValue(gridViewInsuranceRecDetail.FocusedRowHandle, "InsuranceCompanyName").ToString();
                    bool isDelete = false;
                    if (id > 0)
                    {
                        isDelete = insuranceRecomendationInfo.DeleteRecomendationDetail(insuranceCompanyName,id);
                    }
                    else
                    {
                        isDelete = true;
                    }

                    if (isDelete)
                    {
                        gridViewInsuranceRecDetail.DeleteRow(gridViewInsuranceRecDetail.FocusedRowHandle);
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Unable to delete this record. Please try again.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (gridViewInsuranceRecomendation.FocusedRowHandle >= 0)
            {
                if ((DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete this record?",
                  "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes))
                {

                    int id = 0;
                    int.TryParse(gridViewInsuranceRecomendation.GetRowCellValue(gridViewInsuranceRecomendation.FocusedRowHandle, "Id").ToString(), out id);

                    if (!insuranceRecomendationInfo.DeleteInsuranceRecomendation(id))
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Unable to delete this record.",
                            "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                        fillInsuranceRecomendationGrid();
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnPersonalAccidentAdd_Click(object sender, EventArgs e)
        {
            gridViewPersonalAccident.AddNewRow();
        }

        private void btnPersonalAccidentDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("Are you sure you want to delete selected record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int id = 0;
                    int.TryParse(gridViewPersonalAccident.GetRowCellValue(gridViewPersonalAccident.FocusedRowHandle, "Id").ToString(), out id);
                    bool isDelete = false;

                    if (id > 0)
                    {
                        //isDelete = insuranceRecomendationInfo.DeleteRecomendationDetail(insuranceCompanyName, id);
                    }
                    else
                    {
                        isDelete = true;
                    }

                    if (isDelete)
                    {
                        //gridViewInsuranceRecDetail.DeleteRow(gridViewInsuranceRecDetail.FocusedRowHandle);
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Unable to delete this record. Please try again.", "Delete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void tabRecomendation_SelectedPageIndexChanged(object sender, EventArgs e)
        {
            if (tabRecomendation.SelectedPageIndex == 1)
            {
                loadPersonalAccidentalInsuranceInformation();
            }
        }

        private void loadPersonalAccidentalInsuranceInformation()
        {
            
        }
    }
}
