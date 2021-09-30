using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Permission;
using FinancialPlannerClient.Master;
using FinancialPlannerClient.TaskManagementSystem;
using FinancialPlannerClient.TaskManagementSystem.TransactionOptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace FinancialPlannerClient
{
    static class Program
    {
        private static string _webServiceUrl;
        public static User CurrentUser;
        public static Role CurrentUserRolePermission;
        public static IUnityContainer container = new UnityContainer();
        private static AssumptionMaster assumptionMaster;
        public static string WebServiceUrl
        {
            get { return _webServiceUrl; }
        }
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            registerInterfaces();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            _webServiceUrl = getWebServiceUrl();
            Application.Run(new Login.frmXtraLogin());
            //Application.Run(new Testing() );
        }

        private static void registerInterfaces()
        {
            try
            {                
                container.RegisterType<ITransactionType, FreshPurchaseTrans>("Fresh Purchase");
                container.RegisterType<ITransactionType, AdditionalPurchase>("Additional Purchase");
                container.RegisterType<ITransactionType, AdditionalPurchase>("Redemption");
                container.RegisterType<ITransactionType, Switch>("Switch");
                container.RegisterType<ITransactionType, STPTrans>("STP");
                container.RegisterType<ITransactionType, SIPFresh>("New SIP");
                container.RegisterType<ITransactionType, SIPOld>("SIP Old");
                container.RegisterType<ITransactionType, SWPTrans>("SWP");

                container.RegisterType<ITransactionType, SWPTrans>("SWP Pause");
                container.RegisterType<ITransactionType, STPCancellationTrans>("STP Pause");
                container.RegisterType<ITransactionType, SIPCancellationTrans>("SIP Pause");
             
                container.RegisterType<ITransactionType, STPCancellationTrans>("STP Cancel");
                container.RegisterType<ITransactionType, SIPCancellationTrans>("SIP Cancel");
                container.RegisterType<ITransactionType, BankChangeRequestTrans>("Bank Change Request");
                container.RegisterType<ITransactionType, ContactUpdateTrans>("Contact Update");
                container.RegisterType<ITransactionType, LumsumInvestmentType>("Lumsum");
                container.RegisterType<ITransactionType, STPTypeRecomendation>("STPRecomendationType");
                container.RegisterType<ITransactionType, SIPInvestmentRecomendation>("SIPInvestmentRecomendation");
                container.RegisterType<ITransactionType, SwitchTypeInvRecommendationView>("SwitchTypeInvRecommendation");
                container.RegisterType<ITransactionType, PanCardUpdateTrans>("PAN Card Update");
                container.RegisterType<ITransactionType, AddressChangeTrans>("Address Change");
                container.RegisterType<ITransactionType, TransmissionAfterDeathTrans>("Transmission After Death");
                container.RegisterType<ITransactionType, SignatureChangeTrans>("Signature Change");
                container.RegisterType<ITransactionType, SIPBankChangeTrans>("SIP Bank Change");
                container.RegisterType<ITransactionType, MinorToMajorTrans>("Minor To Major");
                container.RegisterType<ITransactionType, ChangeOfNameTrans>("Change of Name");
                container.RegisterType<ITransactionType, NominationTrans>("Nomination");
            }
            catch(Exception ex)
            {
                Logger.LogDebug(ex);
            }
        }

        private static string getWebServiceUrl()
        {
            //return "http://localhost:37882/api";
            return System.Configuration.ConfigurationSettings.AppSettings.Get("webserviceurl");
        }

        public static AssumptionMaster GetAssumptionMaster()
        {
            if (assumptionMaster == null)
            {
                AssumptionMasterInfo assumptionInfo = new AssumptionMasterInfo();
                assumptionMaster = assumptionInfo.GetAll();
            }
            return assumptionMaster;
        }

        public static void ApplyPermission(string option,Form form)
        {
            if (CurrentUserRolePermission.Name == "Admin")
                return;

            List<RolePermission> rolePermission = (List<RolePermission>)Program.CurrentUserRolePermission.Permissions;
            RolePermission permission = rolePermission.Find(x => x.FormName == option);
            if (permission != null)
            {
                setControlsVisibility(form, permission);
            }
            else
            {
                disableAllControls(form);
            }
        }

        private static void setControlsVisibility(Form form, RolePermission permission)
        {
            foreach (Control control in form.Controls)
            {
                setControlVisibility(permission, control);
            }
        }

        private static void setControlVisibility(RolePermission permission, Control control)
        {
            string type = control.GetType().ToString();
            if (type == "DevExpress.XtraEditors.SimpleButton" &&
                (control.Name == "btnDelete" || control.Name == "btnEdit") ||
                control.Name == "btnAdd" || control.Name == "btnSave")
            {
                if (control.Name == "btnDelete")
                {
                    control.Visible = permission.IsDelete;
                }
                if (control.Name == "btnEdit")
                {
                    control.Visible = permission.IsUpdate;
                }
                if (control.Name == "btnAdd")
                {
                    control.Visible = permission.IsAdd;
                }
                //if (control.Name == "btnSave" &&
                //    permission.IsAdd == false && permission.IsUpdate == false)
                //{
                //    control.Visible = false;
                //}
            }
            else if (control.Controls.Count > 0)
            {
                foreach(Control childControl in control.Controls)
                {
                    setControlVisibility(permission, childControl);
                }
            }
        }

        private static void disableAllControls(Form form)
        {
            foreach (Control control in form.Controls)
            {
                string type = control.GetType().ToString();
                if (type == "DevExpress.XtraEditors.SimpleButton" &&
                    (control.Name == "btnDelete" || control.Name == "btnEdit") ||
                    control.Name == "btnAdd" || control.Name == "btnSave")
                {
                    control.Visible = false;
                }
            }
        }
    }
}
