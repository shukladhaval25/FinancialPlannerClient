using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Permission;
using FinancialPlannerClient.Permissions;

namespace FinancialPlannerClient.Login
{
    public class frmXtraLogin : XtraForm
    {
        private PictureEdit imgLogin;
        private LabelControl labelControl1;
        private TextEdit txtPassword;
        private LabelControl labelControl2;
        private TextEdit txtUserName;
        private SimpleButton btnLogin;
        private SimpleButton btnCancel;
        private GroupControl grpLogin;
        private bool isForApproval = false;
        private bool isApproved = false;
        public bool IsAuthenticationPassForApproval { get { return isApproved; } }
        public frmXtraLogin()
        {
            InitializeComponent();
        }
        public frmXtraLogin(bool forApprovalProcess)
        {
            InitializeComponent();
            this.isForApproval = forApprovalProcess;
        }

        private void InitializeComponent()
        {
            this.grpLogin = new DevExpress.XtraEditors.GroupControl();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnLogin = new DevExpress.XtraEditors.SimpleButton();
            this.txtPassword = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtUserName = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.imgLogin = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.grpLogin)).BeginInit();
            this.grpLogin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogin.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // grpLogin
            // 
            this.grpLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpLogin.Controls.Add(this.btnCancel);
            this.grpLogin.Controls.Add(this.btnLogin);
            this.grpLogin.Controls.Add(this.txtPassword);
            this.grpLogin.Controls.Add(this.labelControl2);
            this.grpLogin.Controls.Add(this.txtUserName);
            this.grpLogin.Controls.Add(this.labelControl1);
            this.grpLogin.Controls.Add(this.imgLogin);
            this.grpLogin.Location = new System.Drawing.Point(5, 7);
            this.grpLogin.Name = "grpLogin";
            this.grpLogin.Size = new System.Drawing.Size(344, 119);
            this.grpLogin.TabIndex = 0;
            this.grpLogin.Text = "Login";
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(257, 83);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(63, 23);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(183, 83);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(63, 23);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Login";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(183, 57);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Properties.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(137, 20);
            this.txtPassword.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(112, 60);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(50, 13);
            this.labelControl2.TabIndex = 3;
            this.labelControl2.Text = "Password:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(183, 31);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(137, 20);
            this.txtUserName.TabIndex = 2;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(112, 34);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(56, 13);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "User Name:";
            // 
            // imgLogin
            // 
            this.imgLogin.Cursor = System.Windows.Forms.Cursors.Default;
            this.imgLogin.EditValue = global::FinancialPlannerClient.Properties.Resources.if_run_45545;
            this.imgLogin.Location = new System.Drawing.Point(6, 24);
            this.imgLogin.Name = "imgLogin";
            this.imgLogin.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.imgLogin.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
            this.imgLogin.Properties.ZoomAccelerationFactor = 1D;
            this.imgLogin.Size = new System.Drawing.Size(100, 86);
            this.imgLogin.TabIndex = 0;
            // 
            // frmXtraLogin
            // 
            this.AcceptButton = this.btnLogin;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(354, 132);
            this.ControlBox = false;
            this.Controls.Add(this.grpLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.Name = "frmXtraLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmXtraLogin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grpLogin)).EndInit();
            this.grpLogin.ResumeLayout(false);
            this.grpLogin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtUserName.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLogin.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        private const string AUTHENTICATIONAPI = "Authentication/AuthenticateClient";
        private const string AUTHENTICATION_FAIL = "Authentication Fail due to invalid credential";

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string loginUrl = Program.WebServiceUrl + "/" + AUTHENTICATIONAPI;
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();

                User user = getUserObjectFromUI();
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<User>(loginUrl, user, "POST");

                if (jsonSerialization.IsValidJson(restResult.ToString()))
                {
                    if (isForApproval == false)
                    {
                        actionOnValidAuthentication(restResult.ToString());
                    }
                    else
                    {
                        approveAuthenticationProcess(restResult.ToString());
                    }
                }
                else
                    DevExpress.XtraEditors.XtraMessageBox.Show(restResult.ToString(), "Login fail", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                if (ex.Message.Equals(AUTHENTICATION_FAIL))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message, "Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logger.LogDebug(ex);
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Exception:" + ex.ToString(), "Error occurred", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Logger.LogDebug(ex);
                }
            }
        }

        private void approveAuthenticationProcess(string restResult)
        {
            JSONSerialization jsonSerialization = new JSONSerialization();
            var deserializeUser = jsonSerialization.DeserializeFromString<User>(restResult.ToString());
            isApproved = true;
            this.Close();
        }

        private void actionOnValidAuthentication(string restResult)
        {
            JSONSerialization jsonSerialization = new JSONSerialization();
            var deserializeUser = jsonSerialization.DeserializeFromString<User>(restResult.ToString());
            Program.CurrentUser = deserializeUser;
            Program.CurrentUserRolePermission = getCurrentUserRolePermission();
            Home.frmHome frmclientMain = new Home.frmHome();
            this.Visible = false;
            frmclientMain.ShowDialog();
            Close();
        }

        private Role getCurrentUserRolePermission()
        {
            if (Program.CurrentUser != null)
            {
                PermissionInfo permissionInfo = new PermissionInfo();
                Role role = permissionInfo.Get(Program.CurrentUser.RoleId);
                return role;
            }
            return new Role();
        }
        private User getUserObjectFromUI()
        {
            User user = new User()
            {
                UserName = txtUserName.Text,
                Password = FinancialPlanner.Common.DataEncrypterDecrypter.CryptoEngine.Encrypt(txtPassword.Text),
                MachineName = Environment.MachineName
            };
            return user;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmXtraLogin_Load(object sender, EventArgs e)
        {
            this.Text =   (isForApproval) ? "Approval" : "Login";
            this.btnLogin.Text = (isForApproval) ? "Approval" : "Login";
            txtUserName.Text = (isForApproval) ? "Admin" :  "";
            txtUserName.Enabled = !isForApproval;
        }
    }
}
