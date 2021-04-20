using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common;
using System.Collections.Generic;
using System.Linq;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class StrategicAssetsCollection : DevExpress.XtraReports.UI.XtraReport
    {
        private const string RISKPROFILE_GETALL = "RiskProfileReturn/GetAll";
        private List<RiskProfiledReturnMaster> _riskProfileMasters = new List<RiskProfiledReturnMaster>();
        public StrategicAssetsCollection(Client client,int riskProfileId)
        {
            InitializeComponent();
            this.lblClientName.Text = client.Name;
            loadRiskProfileData();
            RiskProfiledReturnMaster riskProfiledReturnMaster = _riskProfileMasters.First(i => i.Id == riskProfileId);

            lblEquityAllocation.Text = riskProfiledReturnMaster.PreEquityInvestmentRatio.ToString() + "%";
            lblLoweLimitEquity.Text = (riskProfiledReturnMaster.PreEquityInvestmentRatio - 10).ToString() + "%";
            lblUpperLimitEquity.Text = (riskProfiledReturnMaster.PreEquityInvestmentRatio + 10).ToString() + "%";

            lblDebtAllocation.Text = riskProfiledReturnMaster.PreDebtInvestmentRatio.ToString() + "%";
            lblLoweLimitDebt.Text = (riskProfiledReturnMaster.PreDebtInvestmentRatio - 10).ToString() + "%";
            lblUpperLevelDebt.Text = (riskProfiledReturnMaster.PreDebtInvestmentRatio + 10).ToString() + "%";

        }

        private void loadRiskProfileData()
        {
            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
            string apiurl = Program.WebServiceUrl + "/" + RISKPROFILE_GETALL;

            RestAPIExecutor restApiExecutor = new RestAPIExecutor();

            var restResult = restApiExecutor.Execute<List<RiskProfiledReturnMaster>>(apiurl, null, "GET");

            if (jsonSerialization.IsValidJson(restResult.ToString()))
            {
                _riskProfileMasters = jsonSerialization.DeserializeFromString<List<RiskProfiledReturnMaster>>(restResult.ToString());
            }
        }

    }
}
