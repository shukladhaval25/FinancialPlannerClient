﻿using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraNavBar;
using DevExpress.XtraReports.UI;
using FinancialPlanner.Common;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Permission;
using FinancialPlannerClient.Clients.MailService;
using FinancialPlannerClient.Insurance;
using FinancialPlannerClient.PlannerInfo;
using FinancialPlannerClient.PlanOptions;
using FinancialPlannerClient.Review;
using FinancialPlannerClient.MOM;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace FinancialPlannerClient.Clients
{
    public partial class Clientdashboard : DevExpress.XtraEditors.XtraForm
    {
        
        private enum NavigateTo
        {
            Dashborad = 0,
            ContactInfo = 1,
            EmployeeInfo = 2,
            Client = 3,
        }

        bool isControlAdded = false;
        

        #region "ClientInfo variables"
        internal Client _client;
        private DataTable _dtBankAccount;
        private const string UPDATE_CLIENT_API = "Client/Update";
        PersonalInformation personalInformation;
        #endregion

        #region "Planner Variables"
        private readonly string GET_PLAN_BY_CLIENTID_API = "Planner/GetByClientId?id={0}";
        private List<Planner> _planners = new List<Planner>();
        public Planner planner;
        #endregion

        public Clientdashboard(Client client)
        {
            if (client == null)
                throw new InvalidOperationException("Fail to perform operation due to invalid object.");

            getPersonalDetails(client.ID);
            InitializeComponent();
            displayClientInfo();
            LoadPlanData();
            DashboardNavFrame.SelectedPageIndex = (int)NavigateTo.Dashborad;
        }

        private void getPersonalDetails(int clientId)
        {
            ClientPersonalInfo clientPersonalInfo = new ClientPersonalInfo();
            personalInformation = clientPersonalInfo.Get(clientId);
            if (personalInformation != null && personalInformation.Client != null)
            {
                this._client = personalInformation.Client;
            }
        }
        private void displayClientInfo()
        {
            lblName.Text = this._client.Name;
            lblClientID.Text = this._client.ID.ToString();
            clientImage.Image = (this._client.ImageData == null) ?
                Properties.Resources.icons8_customer_30 :
                converToImageFromBase64String(this._client.ImageData);

        }

        private Image converToImageFromBase64String(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }

        private void ContactInfo_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Contact clientContact = new Contact(this._client);
            clientContact.TopLevel = false;
            clientContact.Visible = true;
            navigationPageContactInfo.Name = clientContact.Name;
            navigationPageContactInfo.Controls.Add(clientContact);
            showNavigationPage(clientContact.Name);
        }

        private void btnShowDashborad_Click(object sender, EventArgs e)
        {
            redirectToDashboardPage();
        }

        private void redirectToDashboardPage()
        {
            DashboardNavFrame.SelectedPageIndex = (int)NavigateTo.Dashborad;
        }

        private void EmployeeInfo_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            EmploymentDetails employmentDetails = new EmploymentDetails(this._client);
            employmentDetails.TopLevel = false;
            employmentDetails.Visible = true;
            navigationPageEmployee.Name = employmentDetails.Name;
            navigationPageEmployee.Controls.Add(employmentDetails);
            showNavigationPage(employmentDetails.Name);
        }

        private void btnViewClientInfo_Click(object sender, EventArgs e)
        {
            ClientDetails clientDetails = new ClientDetails(this._client);
            clientDetails.TopLevel = false;
            clientDetails.Visible = true;
            navigationPageClient.Name = clientDetails.Name;
            navigationPageClient.Controls.Clear();
            navigationPageClient.Controls.Add(clientDetails);
            showNavigationPage(clientDetails.Name);
        }

        #region "Client Info"
        private void showClientInfo()
        {
            ClientImageInfo.Image = clientImage.Image;
            txtName.Text = this._client.Name;
            txtName.Tag = this._client.ID;
            txtFatherName.Text = this._client.FatherName;
            txtMotherName.Text = this._client.MotherName;
            cmbGender.Text = this._client.Gender;
            dtDOB.Text = this._client.DOB.ToShortDateString();
            chkMarrried.Checked = this._client.IsMarried;
            dtMarriageAnniversary.Text = this._client.MarriageAnniversary.HasValue ?
                this._client.MarriageAnniversary.Value.ToShortDateString() :
                string.Empty;
            txtPAN.Text = this._client.PAN;
            txtAadharCard.Text = this._client.Aadhar;
            txtPlaceOfBirth.Text = this._client.PlaceOfBirth;
            txtClientOccupation.Text = this._client.Occupation;
        }

        private void showBankDetails()
        {
            BankAccountInfo bankAccountInfo = new BankAccountInfo();
            IList<BankAccountDetail> bankAcDetails = bankAccountInfo.GetAll(_client.ID);
            if (bankAcDetails != null)
            {
                _dtBankAccount = ListtoDataTable.ToDataTable(bankAcDetails.ToList());
                grdBank.DataSource = _dtBankAccount;
            }
        }
        private void btnChangeImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtImagePath.Text = openFileDialog1.FileName;
                ClientImageInfo.Image = Image.FromFile(openFileDialog1.FileName);
                _client.ImageData = getStringfromFile(txtImagePath.Text);
                _client.ImagePath = _client.Name + System.IO.Path.GetExtension(txtImagePath.Text);
            }
        }
        private void btnCloseClientInfo_Click(object sender, EventArgs e)
        {
            redirectToDashboardPage();
        }

        private void btnSaveClient_Click(object sender, EventArgs e)
        {
            updateClient();
        }

        private void updateClient()
        {
            try
            {
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    XtraMessageBox.Show("Please enter client name.", "Invalid Data", System.Windows.Forms.MessageBoxButtons.OK);
                    return;
                }

                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = string.Empty;

                Client client = new Client()
                {
                    ID = _client.ID,
                    Name = txtName.Text,
                    FatherName = txtFatherName.Text,
                    MotherName = txtMotherName.Text,
                    DOB = dtDOB.DateTime,
                    PlaceOfBirth = txtPlaceOfBirth.Text,
                    Gender = cmbGender.Text,
                    IsMarried = chkMarrried.Checked,
                    MarriageAnniversary = dtMarriageAnniversary.DateTime,
                    PAN = txtPAN.Text,
                    Aadhar = txtAadharCard.Text,
                    Occupation = txtClientOccupation.Text,
                    CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")),
                    CreatedBy = Program.CurrentUser.Id,
                    UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")),
                    UpdatedBy = Program.CurrentUser.Id,
                    UpdatedByUserName = Program.CurrentUser.UserName,
                    MachineName = System.Environment.MachineName,
                    ImageData = _client.ImageData,
                    ImagePath = _client.ImagePath
                };

                _client = client;

                apiurl = Program.WebServiceUrl + "/" + UPDATE_CLIENT_API;

                string DATA = jsonSerialization.SerializeToString<Client>(client);

                WebClient webclient = new WebClient();
                webclient.Headers["Content-type"] = "application/json";
                webclient.Encoding = Encoding.UTF8;
                string json = webclient.UploadString(apiurl, "POST", DATA);

                if (json != null)
                {
                    var resultObject = jsonSerialization.DeserializeFromString<Result>(json);
                    if (resultObject.IsSuccess)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Record save successfully.", "Record Saved", System.Windows.Forms.MessageBoxButtons.OK, System.Windows.Forms.MessageBoxIcon.Information);
                        redirectToDashboardPage();
                        displayClientInfo();
                    }
                }
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Unable to save record.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
            }
        }

        private string getStringfromFile(string filePath)
        {
            try
            {
                if (!string.IsNullOrEmpty(filePath))
                {
                    if (System.IO.File.Exists(filePath))
                    {
                        FileStream fs = new FileStream(filePath, FileMode.Open, System.IO.FileAccess.Read);
                        byte[] filebytes = new byte[fs.Length];
                        fs.Read(filebytes, 0, Convert.ToInt32(fs.Length));
                        return Convert.ToBase64String(filebytes,
                                                      Base64FormattingOptions.InsertLineBreaks);
                    }
                }
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
            }
            return null;
        }

        #endregion

        #region "Plan Information"
        public void LoadPlanData()
        {
            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
            string apiurl = Program.WebServiceUrl + "/" + string.Format(GET_PLAN_BY_CLIENTID_API, this._client.ID);

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(apiurl);
            request.Method = "GET";
            String planerResultJson = String.Empty;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                Stream dataStream = response.GetResponseStream();

                StreamReader reader = new StreamReader(dataStream);
                planerResultJson = reader.ReadToEnd();
                reader.Close();
                dataStream.Close();
            }
            var plannerCollection = jsonSerialization.DeserializeFromString<Result<List<Planner>>>(planerResultJson);

            if (plannerCollection.IsSuccess && plannerCollection.Value.Count > 0)
            {
                //var newList  // ToList optional
                this._planners = plannerCollection.Value.OrderByDescending(x => x.StartDate).ToList();
                fillupPlannerCombobox();
                navBarControlPlanner.Enabled = true;
            }
            else
            {
                navBarControlPlanner.Enabled = false;
            }
        }

        private void fillupPlannerCombobox()
        {
            cmbPlanner.Properties.Items.Clear();
            if (this._planners.Count > 0)
            {
                foreach (Planner planner in _planners)
                {
                    cmbPlanner.Properties.Items.Add(planner.Name);
                }
                cmbPlanner.SelectedIndex = 0;
            }

        }
        private void cmbPlanner_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this._planners.Count > 0)
            {
                foreach (Planner planner in _planners)
                {
                    if (planner.Name == cmbPlanner.Text)
                    {
                        this.planner = planner;
                        break;
                    }
                }
            }
            else
            {
                //this.planner = new Planner();
            }
        }
        #endregion

        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }

        private void Clientdashboard_Load(object sender, EventArgs e)
        {
            applyPermissionOnClientDashBoard();
        }

        private void applyPermissionOnClientDashBoard()
        {
            if (Program.CurrentUserRolePermission.Name == "Admin")
                return;

            List<RolePermission> rolePermission = (List<RolePermission>)Program.CurrentUserRolePermission.Permissions;
            setPersonalInfoMenuPermission(rolePermission);          
        }

        

        private void setPersonalInfoMenuPermission(List<RolePermission> rolePermission)
        {
            setVisibilityForViewClientInfoBasedOnPermission(rolePermission);

            foreach (NavBarItemLink control in Personalnfo.ItemLinks)
            {
                setMenuControlPermission(rolePermission, control);
            }
            foreach (NavBarItemLink control in navBarGroupPlannerData.ItemLinks)
            {
                setMenuControlPermission(rolePermission, control);
            }
            foreach (NavBarItemLink control in navBarGroupPlanOption.ItemLinks)
            {
                setMenuControlPermission(rolePermission, control);
            }
        }

        private void setVisibilityForViewClientInfoBasedOnPermission(List<RolePermission> rolePermission)
        {
            RolePermission permission = rolePermission.Find(x => x.FormName == "Client View Details");
            if (permission != null)
                btnViewClientInfo.Visible = permission.IsView;
            else
                btnViewClientInfo.Visible = false;
        }

        private static void setMenuControlPermission(List<RolePermission> rolePermission, NavBarItemLink control)
        {
            RolePermission permission = rolePermission.Find(x => x.FormName.Trim() == control.Caption.Trim());
            if (permission != null)
                control.Visible = permission.IsView;
            else
                control.Visible = false;
        }
        //private bool addNewNavigationPage(string pagename, DevExpress.XtraEditors.XtraForm xtraForm)
        //{
        //    bool result = false;
        //    if (string.IsNullOrEmpty(pagename))
        //        throw new ArgumentNullException("Cotrol name should not be null.");

        //    if (xtraForm == null)
        //        throw new ArgumentNullException("Control should not be null");

        //    int nameMatchCount = DashboardNavFrame.Pages.Where(i => i.Name == pagename).Count();
        //    if (nameMatchCount == 0)
        //    {
        //        DevExpress.XtraBars.Navigation.NavigationPageBase navigationPageBase = new DevExpress.XtraBars.Navigation.NavigationPageBase
        //        {
        //            Name = pagename
        //        };
        //        navigationPageBase.Controls.Add(xtraForm);
        //        DashboardNavFrame.Pages.Add(navigationPageBase);
        //        result = true;
        //    }
        //    return result;
        //}

        private void showNavigationPage(string pageName)
        {
            for (int index = 0; index <= DashboardNavFrame.Pages.Count; index++)
            {
                if (DashboardNavFrame.Pages[index].Name == pageName)
                {
                    DashboardNavFrame.SelectedPageIndex = index;
                    break;
                }
            }
        }

        private void navigationPageClient_ControlRemoved(object sender, ControlEventArgs e)
        {
            redirectToDashboardPage();
        }
        private void navBarItemAssumptions_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            string spouseName = (personalInformation.Spouse != null) ?
                personalInformation.Spouse.Name : string.Empty;
            int spouseAge = getSpouseAge(personalInformation.Spouse);
            Assumption assumption = new Assumption(this._client, planner, spouseName,spouseAge);
            assumption.TopLevel = false;
            assumption.Visible = true;
            navigationPageOther.Name = assumption.Name;
            navigationPageOther.Controls.Clear();
            navigationPageOther.Controls.Add(assumption);
            showNavigationPage(assumption.Name);
        }

        private int getSpouseAge(ClientSpouse spouse)
        {
            if (spouse != null)
                return (DateTime.Now.Year - spouse.DOB.Year);
            else
                return 0;
        }

        private void navBarItemEstimatedPlan_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            EstimatedPlan estimatedPlan = new EstimatedPlan(this.personalInformation, planner);
            estimatedPlan.TopLevel = false;
            estimatedPlan.Visible = true;
            navigationPageOther.Name = estimatedPlan.Name;
            navigationPageOther.Controls.Clear();
            navigationPageOther.Controls.Add(estimatedPlan);
            showNavigationPage(estimatedPlan.Name);
        }

        private void navBarItemReport_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ReportParams reportParameters = new ReportParams(this.planner);
            if (reportParameters.ShowDialog() == DialogResult.OK)
            {

                //XtraReport report = new XtraReport();
                //report.LoadLayout("C:\\Application Softwares\\FinancialPlannerClient\\bin\\Debug\\PlannerMainReport.repx");
                //report.ShowPreview();


                PlannerMainReport plannerMainReport = new PlannerMainReport(this.personalInformation, planner,
                    reportParameters.GetRiskProfileId(), reportParameters.GetOptionId(),reportParameters.txtRecomendation.Text,reportParameters);
                
                //plannerMainReport.LoadLayout("C:\\Application Softwares\\FinancialPlannerClient\\bin\\Debug\\PlannerMainReport.repx");
                DevExpress.XtraReports.UI.ReportPrintTool printTool = new DevExpress.XtraReports.UI.ReportPrintTool(plannerMainReport);
                if (reportParameters.Option == ReportOption.Preview)
                    printTool.ShowRibbonPreview();
                else if (reportParameters.Option == ReportOption.SendMail)
                {
                    FinancialPlannerSendEmailConfiguration financialPlannerSendEmailConfiguration = new FinancialPlannerSendEmailConfiguration(plannerMainReport,this._client,reportParameters.cmbPlanOption.Text);
                    financialPlannerSendEmailConfiguration.Show();
                }
            }
        }

        private void navBarItemOtherInformation_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ClientInfo clientInfo = new ClientInfo(planner.ID, this._client, true);
            clientInfo.TopLevel = false;
            clientInfo.Visible = true;
            navigationPageOther.Name = clientInfo.Name;
            navigationPageOther.Controls.Clear();
            navigationPageOther.Controls.Add(clientInfo);
            showNavigationPage(clientInfo.Name);
        }

        private void navigationPageOther_ControlAdded(object sender, ControlEventArgs e)
        {
            isControlAdded = true;
        }

        private void navBarItemGoals_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            GoalsView goalsView = new GoalsView(planner.ID,this.personalInformation.Client);
            goalsView.TopLevel = false;
            goalsView.Visible = true;
            navigationPageOther.Name = goalsView.Name;
            navigationPageOther.Controls.Clear();
            navigationPageOther.Controls.Add(goalsView);
            showNavigationPage(goalsView.Name);
        }

        private void navBarItemCurrentStatus_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FinancialPlannerClient.CurrentStatus.CurrentStatus currentStatus =
                            new FinancialPlannerClient.CurrentStatus.CurrentStatus(this.personalInformation.Client);
            currentStatus.TopLevel = false;
            currentStatus.Visible = true;
            navigationPageOther.Name = currentStatus.Name;
            navigationPageOther.Controls.Clear();
            navigationPageOther.Controls.Add(currentStatus);
            showNavigationPage(currentStatus.Name);
        }

        private void btnViewPlann_Click(object sender, EventArgs e)
        {
            PlannerView plannerView = new PlannerView(this.personalInformation,this.planner);
            plannerView.TopLevel = false;
            plannerView.Visible = true;
            navigationPageOther.Name = plannerView.Name;
            navigationPageOther.Controls.Clear();
            navigationPageOther.Controls.Add(plannerView);
            showNavigationPage(plannerView.Name);
            this.planner = plannerView.GetCurrentPlanner();
        }

        private void navBarItemRiskProfile_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            FinancialPlannerClient.RiskProfile.frmRiskProfiledReturnList riskProfile =
                            new FinancialPlannerClient.RiskProfile.frmRiskProfiledReturnList(); //(this.personalInformation.Client);
            //FinancialPlannerClient.RiskProfile.RiskProfileReturn riskProfile = new RiskProfile.RiskProfileReturn();
            riskProfile.TopLevel = false;
            riskProfile.Visible = true;
            navigationPageOther.Name = riskProfile.Name;
            navigationPageOther.Controls.Clear();
            navigationPageOther.Controls.Add(riskProfile);
            showNavigationPage(riskProfile.Name);
        }

        private void navBarItemInsurance_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            InsuranceCalculation insuranceCalculation = new
                InsuranceCalculation(this.personalInformation.Client,  this.planner);
            insuranceCalculation.TopLevel = false;
            insuranceCalculation.Visible = true;
            navigationPageOther.Name = insuranceCalculation.Name;
            navigationPageOther.Controls.Clear();
            navigationPageOther.Controls.Add(insuranceCalculation);
            showNavigationPage(insuranceCalculation.Name);
        }

        private void BankDetails_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            BankDetails bankDetails = new BankDetails(this.personalInformation);
            bankDetails.TopLevel = false;
            bankDetails.Visible = true;
            navigationPageOther.Name = bankDetails.Name;
            navigationPageOther.Controls.Clear();
            navigationPageOther.Controls.Add(bankDetails);
            showNavigationPage(bankDetails.Name);
        }

        

        private void gridControlMailList_DataSourceChanged(object sender, EventArgs e)
        {
            //gridControlMailList.RefreshDataSource();
        }

        private void navBarMailManager_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            MailManagerDeskBoard mailManagerDeskBorad = new MailManagerDeskBoard(this.personalInformation);
            mailManagerDeskBorad.TopLevel = false;
            mailManagerDeskBorad.Visible = true;
            navigationPageOther.Name = mailManagerDeskBorad.Name;
            navigationPageOther.Controls.Clear();
            navigationPageOther.Controls.Add(mailManagerDeskBorad);
            showNavigationPage(mailManagerDeskBorad.Name);
        }

        private void navBarItemInvRecomm_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            InvestmentRecomendationView investmentRecomendationView = 
                new InvestmentRecomendationView(this.personalInformation.Client,this.planner);
            investmentRecomendationView.TopLevel = false;
            investmentRecomendationView.Visible = true;
            navigationPageOther.Name = investmentRecomendationView.Name;
            navigationPageOther.Controls.Clear();
            navigationPageOther.Controls.Add(investmentRecomendationView);
            showNavigationPage(investmentRecomendationView.Name);
        }

        private void navBarItemFamily_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ClientInfo clientInfo = new ClientInfo(this._client, true);
            clientInfo.TopLevel = false;
            clientInfo.Visible = true;
            navigationPageOther.Name = clientInfo.Name;
            navigationPageOther.Controls.Clear();
            navigationPageOther.Controls.Add(clientInfo);
            showNavigationPage(clientInfo.Name);
        }

        private void navBarItemClientARN_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ClientARNView clientInfo = new ClientARNView(this._client);
            clientInfo.TopLevel = false;
            clientInfo.Visible = true;
            navigationPageOther.Name = clientInfo.Name;
            navigationPageOther.Controls.Clear();
            navigationPageOther.Controls.Add(clientInfo);
            showNavigationPage(clientInfo.Name);
        }

        private void navBarQuarterlyReviewFormat_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            QuarterlyReviewTemplateView quarterlyReviewSendSetting = new QuarterlyReviewTemplateView(this.personalInformation);
            quarterlyReviewSendSetting.TopLevel = false;
            quarterlyReviewSendSetting.Visible = true;
            navigationPageOther.Name = quarterlyReviewSendSetting.Name;
            navigationPageOther.Controls.Clear();
            navigationPageOther.Controls.Add(quarterlyReviewSendSetting);
            showNavigationPage(quarterlyReviewSendSetting.Name);
        }

        private void navBarItemNetWorth_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            NetWorthAssets   netWorthAssets   = new NetWorthAssets(this._client,this.planner);
            netWorthAssets.TopLevel = false;
            netWorthAssets.Visible = true;
            navigationPageOther.Name = netWorthAssets.Name;
            navigationPageOther.Controls.Clear();
            navigationPageOther.Controls.Add(netWorthAssets);
            showNavigationPage(netWorthAssets.Name);
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            PlannerDataMigration plannerDataMigration = new PlannerDataMigration(this._client, this.planner);
            plannerDataMigration.Show();
        }

        private void navBarItemMOM_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            frmMOM frmMOM  = new frmMOM(this._client);
            frmMOM.TopLevel = false;
            frmMOM.Visible = true;
            navigationPageOther.Name = frmMOM.Name;
            navigationPageOther.Controls.Clear();
            navigationPageOther.Controls.Add(frmMOM);
            showNavigationPage(frmMOM.Name);
        }

        private void navBarItemFeesInvoice_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            FeesInvoiceView feesInvoice = new FeesInvoiceView(this._client,this.planner);
            feesInvoice.TopLevel = false;
            feesInvoice.Visible = true;
            navigationPageOther.Name = feesInvoice.Name;
            navigationPageOther.Controls.Clear();
            navigationPageOther.Controls.Add(feesInvoice);
            showNavigationPage(feesInvoice.Name);
        }

        private void navBarItemRecomendation_LinkClicked(object sender, NavBarLinkEventArgs e)
        {
            RecomendationView recomendationView = new RecomendationView(this._client, this.planner);
            recomendationView.TopLevel = false;
            recomendationView.Visible = true;
            navigationPageOther.Name = recomendationView.Name;
            navigationPageOther.Controls.Clear();
            navigationPageOther.Controls.Add(recomendationView);
            showNavigationPage(recomendationView.Name);
        }
    }
}
