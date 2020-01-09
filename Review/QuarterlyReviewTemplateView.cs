using FinancialPlanner.Common;
using FinancialPlanner.Common.EmailManager;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.PlannerInfo;
using FinancialPlannerClient.Review.Reports;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Windows.Forms;

namespace FinancialPlannerClient.Review
{
    public partial class QuarterlyReviewTemplateView : DevExpress.XtraEditors.XtraForm
    {
        DataTable dtQuterlyReviewSetting;
        PersonalInformation personalInformation;
        string[] typeOfInvs;
        public QuarterlyReviewTemplateView(PersonalInformation personalInformation)
        {
            InitializeComponent();
            this.personalInformation = personalInformation;
        }

        private void QuarterlyReviewSendSetting_Load(object sender, EventArgs e)
        {
            CreateMasterListForInvestmentType();
            fillupQuarterlyReviewTemplateGrid();
            gridQuarterlyReview.DataSource = dtQuterlyReviewSetting;
        }

        private void fillupQuarterlyReviewTemplateGrid()
        {
            IList<QuarterlyReviewTemplate> quarterlyReviewTemplates = new QuarterlyReviewTemplateInfo().GetAll(this.personalInformation.Client.ID);

            foreach (string typeOfInv in typeOfInvs)
            {
                DataRow dr = dtQuterlyReviewSetting.NewRow();
                QuarterlyReviewTemplate quarterlyReviewTemplate = new QuarterlyReviewTemplate();
                if (quarterlyReviewTemplates.Count > 0)
                quarterlyReviewTemplate = quarterlyReviewTemplates.FirstOrDefault(i => i.InvestmentType == typeOfInv);

                if (quarterlyReviewTemplate != null)
                    dr["IsSelected"] = quarterlyReviewTemplate.IsSelected;

                dr["TypeOfInvestment"] = typeOfInv;
                dtQuterlyReviewSetting.Rows.Add(dr);
            }
            if (quarterlyReviewTemplates.Count > 0)
                chkLoan.Checked = quarterlyReviewTemplates[0].IsLoanSelected;
            else
                chkLoan.Checked = false;
        }

        private void CreateMasterListForInvestmentType()
        {
            dtQuterlyReviewSetting = new DataTable();
            dtQuterlyReviewSetting.Columns.Add("IsSelected", Type.GetType("System.Boolean"));
            dtQuterlyReviewSetting.Columns.Add("TypeOfInvestment", Type.GetType("System.String"));

            typeOfInvs = new string[] {
                "PPF Balance",
                "EPF/CPF/GPF Balance",
                "Fixed deposits balance",
                "Savings account balance",
                "Recurring Deposits balance",
                "Bonds",
                "Market Value of investment in shares",
                "Market Value of investment MF",
                "NSC/KVP",
                "Sukanya sum. Account"
            };


        }

        private void btnViewReport_Click(object sender, EventArgs e)
        {
            QuarterlyReivewData quarterlyReviewData = new QuarterlyReivewData(this.personalInformation);
            DevExpress.XtraReports.UI.ReportPrintTool printTool = new DevExpress.XtraReports.UI.ReportPrintTool(quarterlyReviewData);
            printTool.ShowRibbonPreviewDialog();
        }

        private void btnSaveAssumption_Click(object sender, EventArgs e)
        {
            try
            {
                IList<QuarterlyReviewTemplate> quarterlyReviewTemplates = getQuarterlyReviewTemplate();
                bool isSaved = new QuarterlyReviewTemplateInfo().Add(quarterlyReviewTemplates);
                if (isSaved)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Record Save Successfully", "Save");
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Unable to save record.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                DevExpress.XtraEditors.XtraMessageBox.Show("Unable to save record.", "Fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }
        private IList<QuarterlyReviewTemplate> getQuarterlyReviewTemplate()
        {
            IList<QuarterlyReviewTemplate> quarterlyReviewTemplates = new List<QuarterlyReviewTemplate>();

            for (int rowIndex = 0; rowIndex < (gridViewQuarterlyReview.DataRowCount); rowIndex++)
            {
                bool isSelected = gridViewQuarterlyReview.GetRowCellValue(rowIndex, "IsSelected") == DBNull.Value ? false :
                        (bool)gridViewQuarterlyReview.GetRowCellValue(rowIndex, "IsSelected");

                if (isSelected)
                {
                    QuarterlyReviewTemplate quarterlyReviewTemplate = new QuarterlyReviewTemplate();
                    quarterlyReviewTemplate.Cid = this.personalInformation.Client.ID;
                    quarterlyReviewTemplate.IsSelected = true;
                    quarterlyReviewTemplate.InvestmentType = gridViewQuarterlyReview.GetRowCellValue(rowIndex, "TypeOfInvestment").ToString();
                    quarterlyReviewTemplate.IsLoanSelected = chkLoan.Checked;
                    quarterlyReviewTemplates.Add(quarterlyReviewTemplate);
                }
            }
            return quarterlyReviewTemplates;
        }

        private void btnSendInvestmentReport_Click(object sender, EventArgs e)
        {
            ClientContactInfo clientContactInfo = new ClientContactInfo();
            var contactInfo = clientContactInfo.Get(this.personalInformation.Client.ID);
            if (!isPrimaryEmailSetForClient(contactInfo))
                return;
            sendEmail(contactInfo.PrimaryEmail);
        }

        private void sendEmail(string primaryEmail)
        {
            try
            {
                Attachment attachment = getQuarterlyReviewTemplateForEmail();
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(MailServer.FromEmail);
                mailMessage.To.Add(new MailAddress(primaryEmail));
                mailMessage.Subject = string.Format("Investment Recommendation on : {0}", DateTime.Now.Date);
                mailMessage.IsBodyHtml = true;
                mailMessage.Attachments.Add(attachment);
                mailMessage.Body = "Hi" + this.personalInformation.Client.Name + "," + Environment.NewLine + Environment.NewLine +
                    "Quartely Review information send." +
                     Environment.NewLine + Environment.NewLine +
                    "With Regards," + Environment.NewLine + Environment.NewLine + "Asccent Finance solution";

                bool isEmailSend = EmailService.SendEmail(mailMessage);
                if (isEmailSend)
                {
                    MessageBox.Show("Quarterly Review Template report send to client on '" + primaryEmail + "'.", "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Unable to send email to '" + primaryEmail + "'. Check your email configuration setting.", "Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Attachment getQuarterlyReviewTemplateForEmail()
        {
            QuarterlyReivewData quarterlyReivewData = new QuarterlyReivewData(this.personalInformation);
            quarterlyReivewData.ExportToPdf(Path.Combine(System.IO.Path.GetTempPath(), "QuarterlyReviewTemplate.pdf"));
            string hostName = MailServer.HostName;
            Attachment attachment = new Attachment(Path.Combine(System.IO.Path.GetTempPath(), "QuarterlyReviewTemplate.pdf"));
            attachment.Name = "QuarterlyReviewTemplate.pdf";
            return attachment;
        }

        private static bool isPrimaryEmailSetForClient(ClientContact contactInfo)
        {
            if (string.IsNullOrEmpty(contactInfo.PrimaryEmail))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("You can not send this report to client. You require to update client contant details and set primary email option.", "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            return true;
        }

        private void btnCloseClientInfo_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}