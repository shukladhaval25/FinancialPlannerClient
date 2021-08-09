using FinancialPlanner.Common;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using System;

namespace FinancialPlannerClient.RiskProfile
{
    public class RiskProfileInfo
    {
        const string  RISKPROFILERETURN_DETAIL_GETALL ="RiskProfileReturn/GetAllDetails?id={0}";

        DataSet _dsRisProfile;
        DataTable _dtRiskProfileMaster;
        DataTable _dtRiskProfileReturn;
        const int DEFAULT_YEARS  = 80;

        public RiskProfileInfo()
        {
            _dtRiskProfileMaster = new DataTable();
            _dtRiskProfileReturn = new DataTable();
        }

        //public DataTable GetDefaultRiskProfileReturn()
        //{
        //    setDefaultColumnsForRiskPrifleReturn();
        //    setDefaultValueBasedonRemainingYears();
        //    return _dtRiskProfileReturn;
        //}

        public DataTable GetDefaultRiskProfileReturn(RiskProfiledReturnMaster riskProfiledReturnMaster)
        {
            if (riskProfiledReturnMaster != null)
            {
                setDefaultColumnsForRiskPrifleReturn();
                generateRiskProfileTable(riskProfiledReturnMaster);
                return _dtRiskProfileReturn;
            }
            return null;
        }

        private void generateRiskProfileTable(RiskProfiledReturnMaster riskProfiledReturnMaster)
        {
            for (int i = 0; i <= riskProfiledReturnMaster.MaxYear; i++)
            {
                RiskProfiledReturn riskProfileReturn = new RiskProfiledReturn();
                riskProfileReturn.YearRemaining = i;
                DataRow drRiskProfRetun = _dtRiskProfileReturn.NewRow();
                drRiskProfRetun["YearRemaining"] = riskProfileReturn.YearRemaining;

                float foreingInvRatio,foreingInvReturn;
                float equityInvRatio,equityInvReturn;
                float debtInvRatio,debtInvReturn;

                if (riskProfileReturn.YearRemaining <= riskProfiledReturnMaster.ThresholdYear)
                {
                    drRiskProfRetun["ForeingInvestmentRatio"] = riskProfiledReturnMaster.PreForeingInvestmentRatio;
                    foreingInvRatio = riskProfiledReturnMaster.PreForeingInvestmentRatio;
                    drRiskProfRetun["EquityInvestementRatio"] = riskProfiledReturnMaster.PreEquityInvestmentRatio;
                    equityInvRatio = riskProfiledReturnMaster.PreEquityInvestmentRatio;
                    drRiskProfRetun["DebtInvestementRatio"] = riskProfiledReturnMaster.PreDebtInvestmentRatio;
                    debtInvRatio = riskProfiledReturnMaster.PreDebtInvestmentRatio;
                }
                else
                {
                    drRiskProfRetun["ForeingInvestmentRatio"] = riskProfiledReturnMaster.PostForeingInvestmentRatio;
                    foreingInvRatio = riskProfiledReturnMaster.PostForeingInvestmentRatio;
                    drRiskProfRetun["EquityInvestementRatio"] = riskProfiledReturnMaster.PostEquityInvestmentRatio;
                    equityInvRatio = riskProfiledReturnMaster.PostEquityInvestmentRatio;
                    drRiskProfRetun["DebtInvestementRatio"] = riskProfiledReturnMaster.PostDebtInvestmentRatio;
                    debtInvRatio = riskProfiledReturnMaster.PostDebtInvestmentRatio;
                }

                drRiskProfRetun["ForeingInvestementReaturn"] = riskProfiledReturnMaster.ForeingInvestmentReturn;
                foreingInvReturn = riskProfiledReturnMaster.ForeingInvestmentReturn;
                drRiskProfRetun["EquityInvestementReturn"] = riskProfiledReturnMaster.EquityInvestmentReturn;
                equityInvReturn = riskProfiledReturnMaster.EquityInvestmentReturn;
                drRiskProfRetun["DebtInvestementReturn"] = riskProfiledReturnMaster.DebtInvestmentReturn;
                debtInvReturn = riskProfiledReturnMaster.DebtInvestmentReturn;

                drRiskProfRetun["AverageInvestementReturn"] = (((foreingInvRatio * foreingInvReturn) / 100) + ((equityInvRatio * equityInvReturn) / 100) + ((debtInvRatio * debtInvReturn) / 100));
                _dtRiskProfileReturn.Rows.Add(drRiskProfRetun);
            }
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

            DataRow[] drs = _dtRiskProfileReturn.Select(string.Format("YearRemaining = '0'"));
            drs[0]["AverageInvestemetReturn"] = 0;
            return _dtRiskProfileReturn;
        }

        public decimal GetRiskProfileReturnRatio(int RiskProfileId,int yearRemaining)
        {
            if (yearRemaining == 0)
                return 0;

            if (_dtRiskProfileReturn.Rows.Count == 0)
                GetRiskProfileReturnById(RiskProfileId);

            DataRow[] drs = _dtRiskProfileReturn.Select(string.Format("RiskProfileId ='{0}' and YearRemaining = '{1}'", RiskProfileId, yearRemaining));
            if (drs != null)
            {
                foreach (var dr in drs)
                {
                    return decimal.Parse(dr["AverageInvestemetReturn"].ToString());
                }
            }
            return 0;
        }

        public RiskProfiledReturn GetResikProfile(int RiskProfileId, int yearRemaining)
        {
            if (_dtRiskProfileReturn.Rows.Count == 0)
                GetRiskProfileReturnById(RiskProfileId);

            RiskProfiledReturn riskProfiledReturn = new RiskProfiledReturn();
            try
            {
                DataRow[] drs = _dtRiskProfileReturn.Select(string.Format("RiskProfileId ='{0}' and YearRemaining = '{1}'", RiskProfileId, yearRemaining));
                if (drs != null)
                {
                    foreach (var dr in drs)
                    {
                        riskProfiledReturn = convertToRiskProfileDetailsObject(dr);
                        return riskProfiledReturn;
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show("Error:" + ex.ToString());
            }

            return riskProfiledReturn;
        }

        private RiskProfiledReturn convertToRiskProfileDetailsObject(DataRow dr)
        {
            RiskProfiledReturn riskProfile = new RiskProfiledReturn();
            //riskProfile.Id = dr.Field<int>("ID");
            riskProfile.RiskProfileId = int.Parse(dr["RiskProfileID"].ToString());
            riskProfile.YearRemaining = int.Parse(dr["YearRemaining"].ToString());
            riskProfile.ForeingInvestmentRatio = decimal.Parse(dr["ForeingInvestmentRatio"].ToString());
            riskProfile.EquityInvestementRatio = decimal.Parse(dr["EquityInvestementRatio"].ToString());
            riskProfile.DebtInvestementRatio = decimal.Parse(dr["DebtInvestementRatio"].ToString());

            riskProfile.ForeingInvestementReaturn = decimal.Parse(dr["ForeingInvestementReaturn"].ToString());
            riskProfile.EquityInvestementReturn = decimal.Parse(dr["EquityInvestementReturn"].ToString());
            riskProfile.DebtInvestementReturn = decimal.Parse(dr["DebtInvestementReturn"].ToString());
            return riskProfile;
        }


        private void setDefaultColumnsForRiskPrifleReturn()
        {
            _dtRiskProfileReturn.Columns.Clear();
            _dtRiskProfileReturn.Clear();
            DataColumn dcId = new DataColumn("ID",typeof(System.Int64));
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

            DataColumn dcAvgReturn = new DataColumn("AverageInvestementReturn", typeof(System.Decimal));

            dcAvgReturn.ReadOnly = false;
            _dtRiskProfileReturn.Columns.Add(dcAvgReturn);

        }

    }
}
