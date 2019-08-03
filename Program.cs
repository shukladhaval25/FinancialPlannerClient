﻿using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
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
        }

        private static void registerInterfaces()
        {
            try
            {                
                container.RegisterType<ITransactionType, FreshPurchase>("Fresh Purchase");
                container.RegisterType<ITransactionType, AdditionalPurchase>("Additional Purchase");
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
    }
}
