using FinancialPlanner.Common.Model;
using FinancialPlannerClient.Master;
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
    public partial class Contact : DevExpress.XtraEditors.XtraForm
    {
        Client client;
        public Contact()
        {
            InitializeComponent();
        }

        public Contact(Client client)
        {
            this.client = client;
            InitializeComponent();
        }
       
        private void ClientContact_Load(object sender, EventArgs e)
        {
            fillupClientAreaList();
            fillupContactDetails();
        }

        private void fillupClientAreaList()
        {
            cmbArea.Properties.Items.Clear();
            AreaInfo areaInfo = new AreaInfo();
            var areas = areaInfo.GetAll();
            if (areas != null)
            {
                foreach (Area area in areas)
                {
                    cmbArea.Properties.Items.Add(area.Name);
                }
            }
        }

        private void fillupContactDetails()
        {
            ClientContactInfo clientContactInfo = new ClientContactInfo();
            var contactInfo = clientContactInfo.Get(client.ID);
            fillupContactInfo(contactInfo);

            //fillupClientAreaList();
        }
        private void fillupContactInfo(ClientContact contactInfo)
        {
            if (contactInfo != null)
            {
                txtHouseNo.Text = contactInfo.Add1;
                txtStreetName.Text = contactInfo.Street;
                txtCity.Text = contactInfo.City;
                txtState.Text = contactInfo.State;
                txtPincode.Text = contactInfo.Pin;
                cmbArea.Text = contactInfo.Area;
                txtCountry.Text = contactInfo.Country;
                txtClientEmailId.Text = contactInfo.Email;
                txtSpouseEmailId.Text = contactInfo.SpouseEmail;
                txtClientMobile.Text = contactInfo.Mobile;
                txtSpouseMobile.Text = contactInfo.Spousemobile;
                if (txtClientEmailId.Text.Equals(contactInfo.PrimaryEmail) && 
                    !string.IsNullOrEmpty(contactInfo.PrimaryEmail.ToString()))
                    chkPrimaryEmail.Checked = true;
                if (txtSpouseEmailId.Text.Equals(contactInfo.PrimaryEmail) && 
                    !string.IsNullOrEmpty(contactInfo.PrimaryEmail.ToString()))
                    chkSpousePrimaryEmail.Checked = true;
                if (txtClientMobile.Text.Equals(contactInfo.PrimaryMobile) && 
                    !string.IsNullOrEmpty(contactInfo.PrimaryMobile))
                    chkMobileNo.Checked = true;
                if (txtSpouseMobile.Text.Equals(contactInfo.PrimaryMobile) && 
                    !string.IsNullOrEmpty(contactInfo.PrimaryMobile))
                    chkSpouseMobileNo.Checked = true;
                txtPerferedTime.Text = contactInfo.PreferedTime;
            }
        }

        private void btnSaveContact_Click(object sender, EventArgs e)
        {
            ClientContactInfo clientContactInfo = new ClientContactInfo();
            ClientContact clientContact = new ClientContact();
            clientContact = getClientContactData();
            if (clientContactInfo.Update(clientContact))
                DevExpress.XtraEditors.XtraMessageBox.Show("Record save successfully.", "Record Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
            else
                DevExpress.XtraEditors.XtraMessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private ClientContact getClientContactData()
        {
            ClientContact contactInfo = new ClientContact();
            contactInfo.Cid = client.ID;
            contactInfo.Add1 = txtHouseNo.Text;
            contactInfo.Street = txtStreetName.Text;
            contactInfo.City = txtCity.Text;
            contactInfo.State = txtState.Text;
            contactInfo.Area = cmbArea.Text;
            contactInfo.Country = txtCountry.Text;
            contactInfo.Pin = txtPincode.Text;
            contactInfo.Email = txtClientEmailId.Text;
            contactInfo.SpouseEmail = txtSpouseEmailId.Text;
            contactInfo.Mobile = txtClientMobile.Text;
            contactInfo.Spousemobile = txtSpouseMobile.Text;
            if (chkPrimaryEmail.Checked)
                contactInfo.PrimaryEmail = txtClientEmailId.Text;
            if (chkSpousePrimaryEmail.Checked)
                contactInfo.SpouseEmail = txtSpouseEmailId.Text;
            if (chkMobileNo.Checked)
                contactInfo.PrimaryMobile = txtClientMobile.Text;
            if (chkSpouseMobileNo.Checked)
                contactInfo.PrimaryMobile = txtSpouseMobile.Text;
            contactInfo.PreferedTime = txtPerferedTime.Text;
            contactInfo.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
            contactInfo.UpdatedBy = Program.CurrentUser.Id;
            contactInfo.UpdatedByUserName = Program.CurrentUser.UserName;
            contactInfo.MachineName = System.Environment.MachineName;
            return contactInfo;
        }

        private void chkPrimaryEmail_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPrimaryEmail.Checked)
                chkSpousePrimaryEmail.Checked = false;
        }

        private void chkSpousePrimaryEmail_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSpousePrimaryEmail.Checked)
                chkPrimaryEmail.Checked = false;
        }

        private void chkMobileNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMobileNo.Checked)
                chkSpouseMobileNo.Checked = false;
        }

        private void chkSpouseMobileNo_CheckedChanged(object sender, EventArgs e)
        {
            if (chkSpouseMobileNo.Checked)
                chkMobileNo.Checked = false;
        }

        private void btnCancelContact_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Contact_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Parent.Controls.Remove(this);
        }

        private void txtPincode_Properties_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtSpouseEmailId_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtSpouseMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtClientMobile_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void txtClientEmailId_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtClientEmailId.Text))
                e.Cancel = !FinancialPlanner.Common.Validation.IsValidEmail(txtClientEmailId.Text);
        }

        private void txtSpouseEmailId_Validating(object sender, CancelEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtClientEmailId.Text))
                e.Cancel = !FinancialPlanner.Common.Validation.IsValidEmail(txtClientEmailId.Text);
        }
    }
}
