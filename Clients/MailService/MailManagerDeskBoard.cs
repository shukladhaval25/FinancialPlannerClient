using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Chilkat;
using FinancialPlanner.Common.EmailManager;
using FinancialPlanner.Common;
using System.Diagnostics;
using System.Reflection;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.DataConversion;

namespace FinancialPlannerClient.Clients.MailService
{
    public partial class MailManagerDeskBoard : DevExpress.XtraEditors.XtraForm
    {
        const string GET_MAIL_SERVER_SETTING_API = "ApplicationConfiguration";
        DataTable dtEmails = new DataTable();
        private delegate void bindEmailGridWithDataSource();
        PersonalInformation personalInformation;

        public MailManagerDeskBoard(PersonalInformation personalInformation)
        {
            InitializeComponent();
            this.personalInformation = personalInformation;
        }

        private void MailManagerDeskBoard_Load(object sender, EventArgs e)
        {
            loadDashBoradData();
        }

        private async void loadDashBoradData()
        {
            try
            {               
                Task<IList<Email>> task = new Task<IList<Email>>(getEmails);
                task.Start();

                IList<Email> emails = await (task);
                dtEmails = ListtoDataTable.ToDataTable(emails.ToList());
                bindEmailGrid();              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private IList<Email> getEmails()
        {
            getMailServerSetting();
            EmailService mailManager = new EmailService(MailServer.HostName, MailServer.HostPort, MailServer.UserName,
                MailServer.Password, MailServer.IsSSL, MailServer.FromEmail, MailServer.POP3_IMPS_HostName,
                MailServer.POP3_IMPS_HostPort);

            IList<Email> emails = mailManager.GetAllMails("");
            return emails;
        }

        private void getMailServerSetting()
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + GET_MAIL_SERVER_SETTING_API;

                RestAPIExecutor restApiExecutor = new RestAPIExecutor();

                var restResult = restApiExecutor.Execute<IList<ApplicationConfiguration>>(apiurl, null, "GET");
                var applicationConfigurations = jsonSerialization.DeserializeFromString<List<ApplicationConfiguration>>(restResult.ToString());
                DataTable _dtApplicationConfig = ListtoDataTable.ToDataTable(applicationConfigurations);
                DataRow[] dataRows = _dtApplicationConfig.Select("CATEGORY = 'Mail Server Setting'");
                foreach (DataRow dr in dataRows)
                {
                    if (dr.Field<string>("SettingName") == "FromEmail")
                    {
                        MailServer.FromEmail = dr.Field<string>("SettingValue");
                    }
                    else if (dr.Field<string>("SettingName") == "SMTPPort")
                    {
                        MailServer.HostPort = int.Parse(dr.Field<string>("SettingValue"));
                    }
                    else if (dr.Field<string>("SettingName") == "SMTPHost")
                    {
                        MailServer.HostName = dr.Field<string>("SettingValue");
                    }
                    else if (dr.Field<string>("SettingName") == "UserName")
                    {
                        MailServer.UserName = dr.Field<string>("SettingValue");
                    }
                    else if (dr.Field<string>("SettingName") == "Password")
                    {
                        MailServer.Password = dr.Field<string>("SettingValue");
                    }
                    else if (dr.Field<string>("SettingName") == "IsSSL")
                    {
                        MailServer.IsSSL = Boolean.Parse(dr.Field<string>("SettingValue"));
                    }
                    else if (dr.Field<string>("SettingName") == "POP3_IMPS_Host")
                    {
                        MailServer.POP3_IMPS_HostName = (dr.Field<string>("SettingValue"));
                    }
                    else if (dr.Field<string>("SettingName") == "POP3_IMPS_Port")
                    {
                        MailServer.POP3_IMPS_HostPort = (dr.Field<string>("SettingValue"));
                    }
                }
            }
            catch (System.Net.WebException webException)
            {
                if (webException.Message.Equals("The remote server returned an error: (401) Unauthorized."))
                {
                    MessageBox.Show("You session has been expired. Please Login again.", "Session Expired", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
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

        private void createEmailsDataStructure()
        {
            if (dtEmails.Columns.Count == 0)
            {
                dtEmails = new DataTable();
                dtEmails.Columns.Add("From", typeof(System.String));
                dtEmails.Columns.Add("FromName", typeof(System.String));
                dtEmails.Columns.Add("FromAddress", typeof(System.String));
                dtEmails.Columns.Add("To", typeof(System.String));
                dtEmails.Columns.Add("LocalDate", typeof(System.DateTime));
                dtEmails.Columns.Add("Subject", typeof(System.String));
                dtEmails.Columns.Add("Body", typeof(System.String));
                dtEmails.Columns.Add("NumAttachedMessages", typeof(System.Int16));
                dtEmails.Columns.Add("Size", typeof(System.Int64));
                dtEmails.Columns.Add("NumDaysOld", typeof(System.Int16));
            }
        }

        private void bindEmailGrid()
        {
            //createEmailsDataStructure();
            gridControlMailList.DataSource = dtEmails;
            for (int i = 0; i <= tileViewMailList.Columns.Count - 1; i++)
            {
                if (tileViewMailList.Columns[i].FieldName.Equals("Subject", StringComparison.OrdinalIgnoreCase) ||
                    tileViewMailList.Columns[i].FieldName.Equals("From", StringComparison.OrdinalIgnoreCase) ||
                    tileViewMailList.Columns[i].FieldName.Equals("LocalDateStr", StringComparison.OrdinalIgnoreCase) ||
                    tileViewMailList.Columns[i].FieldName.Equals("Size", StringComparison.OrdinalIgnoreCase))
                {
                    tileViewMailList.Columns[i].Visible = true;
                }
                else
                    tileViewMailList.Columns[i].Visible = false;
            }
        }
        private void gridControlMailList_Click(object sender, EventArgs e)
        {
            if (tileViewMailList.FocusedRowHandle >= 0)
            {
                int rowIndex = tileViewMailList.FocusedRowHandle;
                DataRow[] drEmails = dtEmails.Select("Subject ='" + tileViewMailList.GetFocusedRowCellValue("Subject").ToString().Replace("'", "''") +
                    "' and  LocalDateStr ='" + tileViewMailList.GetFocusedRowCellValue("LocalDateStr").ToString() +
                    "' and Size ='" + tileViewMailList.GetFocusedRowCellValue("Size").ToString() + "'");

                lblFromValue.Text = drEmails[0].Field<string>("From");

                lblSubjectValue.Text = drEmails[0].Field<string>("Subject");
                lblEmailDate.Text = drEmails[0].Field<string>("LocalDate");
                webBrowserEmailBody.DocumentText = drEmails[0].Field<string>("Body");
            }
        }
    }
}