﻿using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.Masters;
using FinancialPlanner.Common.Permission;
using FinancialPlannerClient.Permissions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace FinancialPlannerClient.Master
{
    public partial class Other : DevExpress.XtraEditors.XtraForm
    {

        private DataTable _dtOtherItems;
        private IOtherItems _otherItems;
        private string _formOptionName;

        List<ClientRating> clientRatings;
        public Other()
        {
            InitializeComponent();
        }
        public Other(string option)
        {
            InitializeComponent();
            _formOptionName = option;
            ApplyPermission(option);
            switch (option)
            {
                case "Festivals":
                    _otherItems = new FestivalsImplimenter();
                    setFestivalsUI();
                    break;
                case "CRM Groups":
                    _otherItems = new CRMGroupsImplimenter();
                    setCRMGroupUI();
                    break;
                case "Areas":
                    _otherItems = new AreaImplimenter();
                    setAreaUI();
                    break;
                case "MF Category":
                    _otherItems = new MFCategoryImpl();
                    setSchemeCategoryUI();
                    break;
                case "InsuranceCompany":
                    _otherItems = new InsuranceCompanyImplimenter();
                    setInsurnceCompanyUI();
                    break;
            }            
            _otherItems.LoadData(gridControlOthers);
            
            if (gridViewOthers.Columns.Count > 0 && this.Text != "Festivals Master")
                gridViewOthers.Columns[0].Width = 220;
        }

       

        private void ApplyPermission(string option)
        {
            if (Program.CurrentUserRolePermission.Name == "Admin")
                return;

            List<RolePermission> rolePermission = (List<RolePermission>)Program.CurrentUserRolePermission.Permissions;
            RolePermission permission = rolePermission.Find(x => x.FormName == option);
            if (permission != null)
            {
                btnAdd.Visible = permission.IsAdd;
                btnDelete.Visible = permission.IsDelete;
            }               
            else
            {
                btnAdd.Visible = false;
                btnDelete.Visible = false;
            }
        }

        #region "Area"

        private void setAreaUI()
        {
            this.Text = "Areas";
            lblReligion.Visible = false;
            txtReligion.Visible = false;
        }

        private void saveArea()
        {
            Area area = getAreaData();
            if (_otherItems.Save(area))
            {
                MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _otherItems.LoadData(gridControlOthers);
                grpItem.Enabled = false;
            }
            else
            {
                MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Area getAreaData()
        {
            Area area = new Area();
            area.Name = txtName.Text;
            area.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            area.CreatedBy = Program.CurrentUser.Id;
            area.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            area.UpdatedBy = Program.CurrentUser.Id;
            area.MachineName = Environment.MachineName;
            return area;
        }
        #endregion

        #region "CRM Group"
        private void setCRMGroupUI()
        {
            this.Text = "CRM Groups";
            lblReligion.Visible = false;
            txtReligion.Visible = false;
        }

        private void saveCRMGroup()
        {
            CRMGroup crmGroup = getCRMGroupData();
            if (_otherItems.Save(crmGroup))
            {
                MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _otherItems.LoadData(gridControlOthers);
                grpItem.Enabled = false;
            }
            else
            {
                MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private CRMGroup getCRMGroupData()
        {
            CRMGroup crmGroup = new CRMGroup();
            crmGroup.Name = txtName.Text;
            crmGroup.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            crmGroup.CreatedBy = Program.CurrentUser.Id;
            crmGroup.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            crmGroup.UpdatedBy = Program.CurrentUser.Id;
            crmGroup.MachineName = Environment.MachineName;
            return crmGroup;
        }
        #endregion

        #region "Festival"
        private void setFestivalsUI()
        {
            this.Text = "Festivals Master";
        }
        private void saveFestivals()
        {
            Festivals festivals = getFestivalsData();
            if (_otherItems.Save(festivals))
            {
                MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _otherItems.LoadData(gridControlOthers);
                grpItem.Enabled = false;
            }
            else
            {
                MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private Festivals getFestivalsData()
        {
            Festivals festivals = new Festivals();
            festivals.Name = txtName.Text;
            festivals.Religion = txtReligion.Text;
            festivals.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            festivals.CreatedBy = Program.CurrentUser.Id;
            festivals.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            festivals.UpdatedBy = Program.CurrentUser.Id;
            festivals.MachineName = Environment.MachineName;
            return festivals;
        }
        #endregion

        #region "MF Category"
        private void setSchemeCategoryUI()
        {
            this.Text = "Category";
            lblReligion.Visible = false;
            txtReligion.Visible = false;
        }

        private void saveCategory()
        {
            SchemeCategory schemeCategory = getSchemeCategoryData();
            if (_otherItems.Save(schemeCategory))
            {
                MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _otherItems.LoadData(gridControlOthers);
                grpItem.Enabled = false;
            }
            else
            {
                MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private SchemeCategory getSchemeCategoryData()
        {
            SchemeCategory schemeCategory = new SchemeCategory();
            schemeCategory.Name = txtName.Text;
            schemeCategory.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            schemeCategory.CreatedBy = Program.CurrentUser.Id;
            schemeCategory.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            schemeCategory.UpdatedBy = Program.CurrentUser.Id;
            schemeCategory.MachineName = Environment.MachineName;
            return schemeCategory;
        }
        #endregion

        #region "Insurance Company"

        private void setInsurnceCompanyUI()
        {
            this.Text = "Insurance Company";
            lblReligion.Visible = false;
            txtReligion.Visible = false;
        }

        private void saveInsuranceCompany()
        {
            InsuranceCompany insuranceCompany = getInsuraceCompanyData();
            if (_otherItems.Save(insuranceCompany))
            {
                MessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _otherItems.LoadData(gridControlOthers);
                grpItem.Enabled = false;
            }
            else
            {
                MessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private InsuranceCompany getInsuraceCompanyData()
        {
            InsuranceCompany insuranceCompany = new InsuranceCompany();
            insuranceCompany.Name = txtName.Text;

            return insuranceCompany;
        }

        #endregion

        private void gridViewOthers_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
           
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            grpItem.Enabled = true;
            txtName.Text = "";
            txtName.Tag = "";
            txtReligion.Text = "";
            btnSave.Enabled = true;
        }

        private void btnCloseClientInfo_Click(object sender, EventArgs e)
        {
            grpItem.Enabled = false;
        }

        private void btnSaveClient_Click(object sender, EventArgs e)
        {
            if (this.Text == "Festivals Master")
            {
                saveFestivals();
            }
            else if (this.Text == "CRM Groups")
            {
                saveCRMGroup();
            }
            else if (this.Text == "Areas")
            {
                saveArea();
            }
            else if(this.Text == "Category")
            {
                saveCategory();
            }
            else if (this.Text == "Insurance Company")
            {
                saveInsuranceCompany();
            }
        }
      
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure, you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (this.Text == "Festivals Master")
                {
                    Festivals festivals = getFestivalsData();
                    //if (_otherItems.Delete(festivals))
                       // _otherItems.LoadData(gridControlOthers);
                }
                else if (this.Text == "CRM Groups")
                {
                    CRMGroup crmGroup = getCRMGroupData();
                    //if (_otherItems.Delete(crmGroup))
                        //_otherItems.LoadData(gridControlOthers);
                }
                else if (this.Text == "Areas")
                {
                    Area area = getAreaData();
                    //if (_otherItems.Delete(area))
                        //_otherItems.LoadData(gridControlOthers);
                }
                else if (this.Text == "Category")
                {
                    SchemeCategory schemeCategory = getSchemeCategoryData();
                    _otherItems.Delete(schemeCategory);
                }
                else if (this.Text == "Insurance Company")
                {
                    //saveInsuranceCompany();
                    InsuranceCompany insuranceCompany = new InsuranceCompany() { Id = (txtName.Tag.ToString() == "") ? 0 : int.Parse(txtName.Tag.ToString()), Name = txtName.Text };
                    _otherItems.Delete(insuranceCompany);
                    _otherItems.LoadData(gridControlOthers);
                }
            }
        }

        private void gridViewOthers_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridViewOthers.FocusedRowHandle >= 0)
            {
                if (this.Text == "Festivals Master")
                {
                    txtName.Text = gridViewOthers.GetFocusedRowCellValue(gridViewOthers.Columns[1]).ToString();  //dtGridOther.SelectedRows[0].Cells[1].Value.ToString();
                    txtReligion.Text = gridViewOthers.GetFocusedRowCellValue(gridViewOthers.Columns[0]).ToString();
                }
                else if (this.Text == "Category" || this.Text == "Insurance Company")
                {
                    txtName.Text = gridViewOthers.GetFocusedRowCellValue(gridViewOthers.Columns[1]).ToString(); 
                    txtName.Tag = gridViewOthers.GetFocusedRowCellValue(gridViewOthers.Columns[0]).ToString();
                }
                else
                    txtName.Text = gridViewOthers.GetFocusedRowCellValue(gridViewOthers.Columns[0]).ToString();
            }
        }

        private void Other_Load(object sender, EventArgs e)
        {

        }
    }
}
