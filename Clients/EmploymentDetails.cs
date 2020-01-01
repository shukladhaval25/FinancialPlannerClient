using DevExpress.XtraEditors;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Permission;
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
    public partial class EmploymentDetails : DevExpress.XtraEditors.XtraForm
    {
        int clientId;
        public EmploymentDetails()
        {
            InitializeComponent();
        }
        public EmploymentDetails(Client client)
        {
            InitializeComponent();
            if (client != null)
            {
                clientId = client.ID;
                fillupEmploymentDetails();
            }
        }

        private void fillupEmploymentDetails()
        {
            EmploymentInfo employmentInfo = new EmploymentInfo();
            var employment = employmentInfo.Get(clientId);
            fillupEmploymentInfo(employment);
        }

        private void fillupEmploymentInfo(Employment employment)
        {
            if (employment != null)
            {
                fillupClientEmploymentInfo(employment.ClientEmployment);
                fillupSpouseEmploymentInfo(employment.SpouseEmployment);
            }
        }

        private void fillupSpouseEmploymentInfo(SpouseEmployment spouseEmployment)
        {
            if (spouseEmployment != null)
            {
                txtSpouseDesigation.Text = spouseEmployment.Designation;
                txtSpouseEmployer.Text = spouseEmployment.EmployerName;
                txtSpouseEmployerAdd.Text = spouseEmployment.Address;
                txtSpouseEmployerCity.Text = spouseEmployment.City;
                txtSpouseEmployerStreet.Text = spouseEmployment.Street;
                txtSpouseEmployerPin.Text = spouseEmployment.Pin;
                txtSpouseIncome.Text = spouseEmployment.Income;
            }
        }

        private void fillupClientEmploymentInfo(ClientEmployment clientEmployment)
        {
            if (clientEmployment != null)
            {
                txtClientDesignation.Text = clientEmployment.Designation;
                txtClientEmployer.Text = clientEmployment.EmployerName;
                txtClientEmployerAdd.Text = clientEmployment.Address;
                txtClientEmployerCity.Text = clientEmployment.City;
                txtClientEmployerStreet.Text = clientEmployment.Street;
                txtClientEmployerPin.Text = clientEmployment.Pin;
                txtClientIncome.Text = clientEmployment.Income;
            }
        }

        private void btnCancelEmployment_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EmploymentDetails_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void btnSaveEmployment_Click(object sender, EventArgs e)
        {
            EmploymentInfo employmentInfo = new EmploymentInfo();
            Employment empoloyment = new Employment();
            empoloyment = getEmploymentDetails();
            if (employmentInfo.Update(empoloyment))
                XtraMessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                XtraMessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        private Employment getEmploymentDetails()
        {
            Employment employment = new Employment();
            employment.ClientEmployment = getClientEmploymentInfo();
            employment.SpouseEmployment = getSpouseEmploymentInfo();
            return employment;
        }

        private SpouseEmployment getSpouseEmploymentInfo()
        {
            SpouseEmployment spouseEmployment = new SpouseEmployment();
            spouseEmployment.Cid = clientId;
            spouseEmployment.Designation = txtSpouseDesigation.Text;
            spouseEmployment.EmployerName = txtSpouseEmployer.Text;
            spouseEmployment.Address = txtSpouseEmployerAdd.Text;
            spouseEmployment.City = txtSpouseEmployerCity.Text;
            spouseEmployment.Street = txtSpouseEmployerStreet.Text;
            spouseEmployment.Pin = txtSpouseEmployerPin.Text;
            spouseEmployment.Income = txtSpouseIncome.Text;
            spouseEmployment.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            spouseEmployment.UpdatedBy = Program.CurrentUser.Id;
            spouseEmployment.UpdatedByUserName = Program.CurrentUser.UserName;
            spouseEmployment.MachineName = System.Environment.MachineName;
            return spouseEmployment;
        }

        private ClientEmployment getClientEmploymentInfo()
        {
            ClientEmployment clientEmployment = new ClientEmployment();
            clientEmployment.Cid = clientId;
            clientEmployment.Designation = txtClientDesignation.Text;
            clientEmployment.EmployerName = txtClientEmployer.Text;
            clientEmployment.Address = txtClientEmployerAdd.Text;
            clientEmployment.City = txtClientEmployerCity.Text;
            clientEmployment.Street = txtClientEmployerStreet.Text;
            clientEmployment.Pin = txtClientEmployerPin.Text;
            clientEmployment.Income = txtClientIncome.Text;
            clientEmployment.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            clientEmployment.UpdatedBy = Program.CurrentUser.Id;
            clientEmployment.UpdatedByUserName = Program.CurrentUser.UserName;
            clientEmployment.MachineName = System.Environment.MachineName;
            return clientEmployment;
        }

        private void EmploymentDetails_Load(object sender, EventArgs e)
        {
            setVisibilityOfControlBasedOnPermission();
        }
        private void setVisibilityOfControlBasedOnPermission()
        {
            if (Program.CurrentUserRolePermission.Name == "Admin")
                return;

            List<RolePermission> rolePermission = (List<RolePermission>)Program.CurrentUserRolePermission.Permissions;
            RolePermission permission = rolePermission.Find(x => x.FormName == this.Tag.ToString());
            btnSaveEmployment.Visible = (permission.IsAdd || permission.IsUpdate) ? true : false;
        }
    }
}
