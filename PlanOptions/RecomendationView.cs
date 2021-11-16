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

            //fillPersonalInsuranceInformation();
        }

        private void fillPersonalInsuranceInformation()
        {
            gridControlPersonalAccident.DataSource = dtPersonalAccident;
            //gridViewPersonalAccident.AddNewRow();
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
                        isDelete = new PersonalAccidentalInsuranceInfo().DeleteRecomendationDetail(id);
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
            else if (tabRecomendation.SelectedPageIndex == 2)
            {
                loadOtherRecommendationInformation();
            }
        }

        private void loadOtherRecommendationInformation()
        {
            IList<OtherRecommendationSetting> otherRecommendationSettings = new List<OtherRecommendationSetting>();

            OtherRecommendationSettingInfo otherRecommendationSettingInfo = new OtherRecommendationSettingInfo();
            otherRecommendationSettings = otherRecommendationSettingInfo.GetAll(this.planner.ID);
            if (otherRecommendationSettings != null)
            {
                foreach(OtherRecommendationSetting otherRecommendationSetting in otherRecommendationSettings)
                {
                    if (otherRecommendationSetting.Title.Trim().Equals(chkPropertiesInsurance.Text))
                    {
                        chkPropertiesInsurance.Checked = otherRecommendationSetting.IsSelected;
                        txtPropertiesDescription.Text = otherRecommendationSetting.Description;
                    }
                    else if (otherRecommendationSetting.Title.Trim().Equals(chkMedicalInsurance.Text))
                    {
                        chkMedicalInsurance.Checked = otherRecommendationSetting.IsSelected;
                        txtMedicalDescription.Text = otherRecommendationSetting.Description;
                    }
                    else if (otherRecommendationSetting.Title.Trim().Equals(chkOtherRecommendation.Text))
                    {
                        chkOtherRecommendation.Checked = otherRecommendationSetting.IsSelected;
                        txtOtherDescription.Text = otherRecommendationSetting.Description;
                    }
                }
            }

        }

        private void loadPersonalAccidentalInsuranceInformation()
        {
            PersonalAccidentalInsuranceInfo personalAccidentalInsuranceInfo = new PersonalAccidentalInsuranceInfo();
            IList<PersonalAccidentInsurance> personalAccidentInsurances = personalAccidentalInsuranceInfo.GetAll(this.planner.ID);
            dtPersonalAccident = ListtoDataTable.ToDataTable(personalAccidentInsurances.ToList());
            gridControlPersonalAccident.DataSource = dtPersonalAccident;
        }

        private void gridViewPersonalAccident_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            try
            {
                PersonalAccidentInsurance personalAccidentInsurance = new PersonalAccidentInsurance();

                if (((System.Data.DataRowView)e.Row).Row.ItemArray[0] == DBNull.Value )
                {
                    personalAccidentInsurance.Id = 0;
                }
                else
                {
                    int.Parse(((System.Data.DataRowView)e.Row).Row.ItemArray[0].ToString());
                }
                personalAccidentInsurance.Name = ((System.Data.DataRowView)e.Row).Row.ItemArray[2].ToString();
                personalAccidentInsurance.PId = this.planner.ID;
                personalAccidentInsurance.InsuranceCompanyName = ((System.Data.DataRowView)e.Row).Row.ItemArray[3].ToString();
                personalAccidentInsurance.SumAssured = ((System.Data.DataRowView)e.Row).Row.ItemArray[4].ToString();
                personalAccidentInsurance.Premium = string.IsNullOrEmpty(((System.Data.DataRowView)e.Row).Row.ItemArray[5].ToString()) ? 0 :
                    double.Parse(((System.Data.DataRowView)e.Row).Row.ItemArray[5].ToString());
                bool isSaved = false;
                if (personalAccidentInsurance.Id == 0)
                {
                    isSaved = new PersonalAccidentalInsuranceInfo().Add(personalAccidentInsurance);
                }
                else
                {
                    isSaved = new PersonalAccidentalInsuranceInfo().Update(personalAccidentInsurance);
                }
                if (isSaved)
                {
                    //DevExpress.XtraEditors.XtraMessageBox.Show("Record save successfully.",
                    // "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //loadPersonalAccidentalInsuranceInformation();
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Unable to save record.",
                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chkPropertiesInsurance_CheckedChanged(object sender, EventArgs e)
        {
            txtPropertiesDescription.Enabled = chkPropertiesInsurance.Checked;
        }

        private void chkMedicalInsurance_CheckedChanged(object sender, EventArgs e)
        {
            txtMedicalDescription.Enabled = chkMedicalInsurance.Checked;
        }

        private void chkOtherRecommendation_CheckedChanged(object sender, EventArgs e)
        {
            txtOtherDescription.Enabled = chkOtherRecommendation.Checked;
        }

        private void btnCloseOthers_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSaveOthers_Click(object sender, EventArgs e)
        {
            IList<OtherRecommendationSetting> otherRecommendationSettings = getDataForOtherRecommendation();

            OtherRecommendationSettingInfo otherRecommendationSettingInfo = new OtherRecommendationSettingInfo();
            bool IsSaved = false;
            IsSaved = otherRecommendationSettingInfo.Update(otherRecommendationSettings);
            if (IsSaved)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Record saved sucessfully.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loadOtherRecommendationInformation();
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Unable to saved this record.", "Save", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private IList<OtherRecommendationSetting> getDataForOtherRecommendation()
        {
            IList<OtherRecommendationSetting> otherRecommendationSettings = new List<OtherRecommendationSetting>();
            string[] titles = new string[] { chkPropertiesInsurance.Text, chkMedicalInsurance.Text, chkOtherRecommendation.Text };
            foreach (string value in titles)
            {
                OtherRecommendationSetting otherRecommendationSetting = new OtherRecommendationSetting();
                otherRecommendationSetting.PID = this.planner.ID;
                if (value.Equals(chkPropertiesInsurance.Text))
                {
                    otherRecommendationSetting.IsSelected = chkPropertiesInsurance.Checked;
                    otherRecommendationSetting.Description = txtPropertiesDescription.Text;
                    otherRecommendationSetting.Title = chkPropertiesInsurance.Text;
                }
                else if (value.Equals(chkMedicalInsurance.Text))
                {
                    otherRecommendationSetting.IsSelected = chkMedicalInsurance.Checked;
                    otherRecommendationSetting.Description  = txtMedicalDescription.Text;
                    otherRecommendationSetting.Title = chkMedicalInsurance.Text;
                }
                else if (value.Equals(chkOtherRecommendation.Text))
                {
                    otherRecommendationSetting.IsSelected = chkOtherRecommendation.Checked;
                    otherRecommendationSetting.Description = txtOtherDescription.Text;
                    otherRecommendationSetting.Title = chkOtherRecommendation.Text;
                }
                otherRecommendationSettings.Add(otherRecommendationSetting);
            }
            return otherRecommendationSettings;
        }
    }
}
