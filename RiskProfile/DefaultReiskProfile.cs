using FinancialPlanner.Common;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace FinancialPlannerClient.RiskProfile
{
    public class ReiskProfileInfo
    {
        const string  RISKPROFILERETURN_DETAIL_GETALL ="RiskProfileReturn/GetAllDetails?id={0}";

        DataSet _dsRisProfile;
        DataTable _dtRiskProfileMaster;
        DataTable _dtRiskProfileReturn;
        const int DEFAULT_YEARS  = 80;

        public ReiskProfileInfo()
        {
            _dtRiskProfileMaster = new DataTable();
            _dtRiskProfileReturn = new DataTable();
        }

        public DataTable GetDefaultRiskProfileReturn()
        {
            setDefaultColumnsForRiskPrifleReturn();
            setDefaultValueBasedonRemainingYears();
            return _dtRiskProfileReturn;
        }

        public DataTable GetRiskProfileReturnById(int id)
        {
            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
            string apiurl = Program.WebServiceUrl +"/"+ string.Format(RISKPROFILERETURN_DETAIL_GETALL,id);

            RestAPIExecutor restApiExecutor = new RestAPIExecutor();

            var restResult = restApiExecutor.Execute<List<RiskProfiledReturn>>(apiurl, null, "GET");

            if (jsonSerialization.IsValidJson(restResult.ToString()))
            {
                var riskProfileColleection = jsonSerialization.DeserializeFromString<List<RiskProfiledReturn>>(restResult.ToString());
                _dtRiskProfileReturn.Clear();
                _dtRiskProfileReturn = ListtoDataTable.ToDataTable(riskProfileColleection);
            }
            else
                MessageBox.Show(restResult.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

            return _dtRiskProfileReturn;
        }

        private void setDefaultValueBasedonRemainingYears()
        {
            for(int i =0; i<= DEFAULT_YEARS;i++)
            {
                RiskProfiledReturn riskProfileReturn = new RiskProfiledReturn();
                riskProfileReturn.YearRemaining = i;
                riskProfileReturn.ForeingInvestmentRatio = 0;
                riskProfileReturn.EquityInvestementRatio = 0;
                riskProfileReturn.DebtInvestementRatio = 0;
                riskProfileReturn.ForeingInvestementReaturn = 0;
                riskProfileReturn.EquityInvestementReturn = 0;
                riskProfileReturn.DebtInvestementReturn = 0;

                DataRow drRiskProfRetun = _dtRiskProfileReturn.NewRow();
                drRiskProfRetun["YearRemaining"] = riskProfileReturn.YearRemaining;
                drRiskProfRetun["ForeingInvestmentRatio"] = riskProfileReturn.ForeingInvestmentRatio;
                drRiskProfRetun["EquityInvestementRatio"] = riskProfileReturn.EquityInvestementRatio;
                drRiskProfRetun["DebtInvestementRatio"] = riskProfileReturn.DebtInvestementRatio;
                drRiskProfRetun["ForeingInvestementReaturn"] = riskProfileReturn.ForeingInvestementReaturn;
                drRiskProfRetun["EquityInvestementReturn"] = riskProfileReturn.EquityInvestementReturn;
                drRiskProfRetun["DebtInvestementReturn"] = riskProfileReturn.DebtInvestementReturn;
                drRiskProfRetun["AverageInvestementReturn"] = riskProfileReturn.AverageInvestemetReturn;
                _dtRiskProfileReturn.Rows.Add(drRiskProfRetun);
            }           
        }

        private void setDefaultColumnsForRiskPrifleReturn()
        {
            DataColumn dcId = new DataColumn("ID",typeof(System.Int16));
            _dtRiskProfileReturn.Columns.Add(dcId);

            DataColumn dcRiskProfileId = new DataColumn("RiskProfileId",typeof(System.Int16));
            _dtRiskProfileReturn.Columns.Add(dcRiskProfileId);

            DataColumn dcYearRemaining = new DataColumn("YearRemaining",typeof(System.Int16));
            _dtRiskProfileReturn.Columns.Add(dcYearRemaining);

            DataColumn dcforeingInvestmentRatio = new DataColumn("ForeingInvestmentRatio",typeof(System.Decimal));
            _dtRiskProfileReturn.Columns.Add(dcforeingInvestmentRatio);

            DataColumn dcEquityInvestmentRatio = new DataColumn("EquityInvestementRatio",typeof(System.Decimal));
            _dtRiskProfileReturn.Columns.Add(dcEquityInvestmentRatio);

            DataColumn dcDebtInvestmentRatio = new DataColumn("DebtInvestementRatio",typeof(System.Decimal));
            _dtRiskProfileReturn.Columns.Add(dcDebtInvestmentRatio);

            DataColumn dcforeingInvestmentReturnRatio = new DataColumn("ForeingInvestementReaturn",typeof(System.Decimal));
            _dtRiskProfileReturn.Columns.Add(dcforeingInvestmentReturnRatio);

            DataColumn dcEquityInvestmentReturnRatio = new DataColumn("EquityInvestementReturn",typeof(System.Decimal));
            _dtRiskProfileReturn.Columns.Add(dcEquityInvestmentReturnRatio);

            DataColumn dcDebtInvestmentReturnRatio = new DataColumn("DebtInvestementReturn",typeof(System.Decimal));
            _dtRiskProfileReturn.Columns.Add(dcDebtInvestmentReturnRatio);

            DataColumn dcAvgReturn = new DataColumn("AverageInvestementReturn",typeof(System.Decimal));
            _dtRiskProfileReturn.Columns.Add(dcAvgReturn);

        }

    }
}
