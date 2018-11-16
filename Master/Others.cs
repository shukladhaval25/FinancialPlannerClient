using FinancialPlanner.Common.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialPlannerClient.Master
{
    public partial class Others : Form
    {

        private DataTable _dtOtherItems;
        private IOtherItems _otherItems;

        public Others()
        {
            InitializeComponent();
        }
        public Others(string option)
        {
            InitializeComponent(); 
            if (option == "Festivals")
            {
                _otherItems = new FestivalsImplimenter();
                setFestivalsUI();
            }
            else if (option == "CRM Groups")
            {
                _otherItems = new CRMGroupsImplimenter();
                setCRMGroupUI();                
            }
            else if (option == "Areas")
            {
                _otherItems = new AreaImplimenter();
                setAreaUI();
            }
            _otherItems.LoadData(dtGridOther);
            if (dtGridOther.Columns.Count > 0 && this.Text != "Festivals Master")
                dtGridOther.Columns[0].Width = 220;
        }
            
        private void dtGridOther_SelectionChanged(object sender, EventArgs e)
        {
            if (dtGridOther.SelectedRows.Count > 0 )
            {
                
                if (this.Text == "Festivals Master")
                {
                    txtName.Text = dtGridOther.SelectedRows[0].Cells[1].Value.ToString();
                    txtReligion.Text = dtGridOther.SelectedRows[0].Cells[0].Value.ToString();
                }
                else
                    txtName.Text = dtGridOther.SelectedRows[0].Cells[0].Value.ToString();
            }
        }

        private void btnAddOther_Click(object sender, EventArgs e)
        {
            grpItem.Enabled = true;
            txtName.Text = "";
            txtReligion.Text = "";
        }

        private void btnEditOther_Click(object sender, EventArgs e)
        {
            grpItem.Enabled = true;
        }

        private void btnOtherCancel_Click(object sender, EventArgs e)
        {
            grpItem.Enabled = false;
        }

        private void btnOtherSave_Click(object sender, EventArgs e)
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
            
        }
        
        private void btnDeleteOther_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure, you want to delete this record?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (this.Text == "Festivals Master")
                {
                    Festivals festivals = getFestivalsData();
                    if (_otherItems.Delete(festivals))
                        _otherItems.LoadData(dtGridOther);
                }
                else if (this.Text == "CRM Groups")
                {
                    CRMGroup crmGroup = getCRMGroupData();
                    if (_otherItems.Delete(crmGroup))
                        _otherItems.LoadData(dtGridOther);
                }
                else if (this.Text == "Areas")
                {
                    Area area = getAreaData();
                    if (_otherItems.Delete(area))
                        _otherItems.LoadData(dtGridOther);
                }
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
                _otherItems.LoadData(dtGridOther);
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
                _otherItems.LoadData(dtGridOther);
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
                _otherItems.LoadData(dtGridOther);
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
    }
}
