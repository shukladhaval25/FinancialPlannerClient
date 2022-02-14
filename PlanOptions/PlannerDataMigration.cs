﻿using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.CurrentStatus;
using FinancialPlannerClient.CurrentStatus;
using FinancialPlannerClient.PlannerInfo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows.Forms;

namespace FinancialPlannerClient.PlanOptions
{
    public partial class PlannerDataMigration : DevExpress.XtraEditors.XtraForm
    {
        private readonly string GET_PLAN_BY_CLIENTID_API = "Planner/GetByClientId?id={0}";
        private List<Planner> _planners = new List<Planner>();
        private Planner sourcePlanner;
        private Planner currentPlanner;
        private Client client;
        private DataTable dtMigrationModule;
        private delegate void DelegateUpdateAllValues(DataRow dataRow, double value, string status, string note);
        private delegate void DelegateUpdateProgressValue(DataRow dataRow, double value);
        private delegate IList<Goals> DelegateGetGoals(int plannerId);

        string[] modules = new string[] {
                "",
                "Assumption Master",
                "Goals",
                "Loan",
                "Non Financial Assets",
                "Income",
                "Expense",
                "Life Insurance",
                "General Insurance",
                "MF",
                "NPS",
                "Shares",
                "Bonds",
                "SA",
                "FD",
                "RD",
                "PF",
                "SSA",
                "SCSS",
                "NSC",
                "ULIP",
                "EPF",
                "Others",
                "Insurance Recommendation",
                "Personal Accident",
                "Other Recommendation"

        };
        public PlannerDataMigration(Client client, Planner destinationPlanner)
        {
            InitializeComponent();
            this.client = client;
            this.currentPlanner = destinationPlanner;
            this.lblPlanVal.Text = this.currentPlanner.Name;
        }

        private void PlannerDataMigration_Load(object sender, EventArgs e)
        {
            loadPlanData();
            loadMigrationModule();
        }

        private void loadMigrationModule()
        {
            dtMigrationModule = new DataTable();
            dtMigrationModule.Columns.Add("IsSelected", Type.GetType("System.Boolean"));
            dtMigrationModule.Columns.Add("Module", Type.GetType("System.String"));
            dtMigrationModule.Columns.Add("Status", Type.GetType("System.Double"));
            dtMigrationModule.Columns.Add("FinalStatus", Type.GetType("System.String"));
            dtMigrationModule.Columns.Add("Note", Type.GetType("System.String"));

            gridModules.DataSource = dtMigrationModule;
            foreach (string module in modules)
            {
                DataRow dataRow = dtMigrationModule.NewRow();
                dataRow["IsSelected"] = false;
                dataRow["Module"] = module.Trim();
                dataRow["Status"] = 0;
                dtMigrationModule.Rows.Add(dataRow);
            }
        }

        private void loadPlanData()
        {
            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
            string apiurl = Program.WebServiceUrl + "/" + string.Format(GET_PLAN_BY_CLIENTID_API, this.client.ID);

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
            }
        }

        private void fillupPlannerCombobox()
        {
            cmbPlan.Properties.Items.Clear();
            if (this._planners.Count > 0)
            {
                foreach (Planner planner in _planners)
                {
                    cmbPlan.Properties.Items.Add(planner.Name);
                }
                cmbPlan.SelectedIndex = 0;
            }
        }

        private void cmbPlan_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this._planners.Count > 0)
            {
                foreach (Planner planner in _planners)
                {
                    if (planner.Name == cmbPlan.Text)
                    {
                        this.sourcePlanner = planner;
                        break;
                    }
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (sourcePlanner.ID == currentPlanner.ID)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Source and destination plan both are same. Can not migration data from same plan", "Migration Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (sourcePlanner.StartDate > currentPlanner.StartDate)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Source plan start date shoule be less then current plan start date", "Migration Data", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //bool isAllSelected = false;
            //for (int i = 0; i <= gridViewModules.RowCount - 1; i++)
            //{
            //    isAllSelected = gridViewModules.GetRowCellValue(i, "IsSelected").ToString().Equals("True");
            //    if (!isAllSelected)
            //        break;
            //}

            DataRow[] dataRows = dtMigrationModule.Select("IsSelected=true");
            if (dataRows.Length > 0)
            {
                startDataMigration(dataRows);
            }

            //if (isAllSelected)
            //{
            //    dataRows = dtMigrationModule.Select("Module='Assumption Master'");
            //    if (dataRows.Length > 0)
            //    {
            //        startDataMigration(dataRows);
            //    }
            //}
        }

        private void startDataMigration(DataRow[] dataRows)
        {
            foreach (DataRow dataRow in dataRows)
            {
                DelegateUpdateAllValues delegateUpdateAllValues = new DelegateUpdateAllValues(updateAllProgressValue);
                delegateUpdateAllValues(dataRow, 10, "In Progress", "");
                //await Task.Run(() => moduleDataMigration(dataRow));
                moduleDataMigration(dataRow);
            }
        }

        private void updateAllProgressValue(DataRow dataRow, double value, string status, string note)
        {
            dataRow["Status"] = value;
            dataRow["FinalStatus"] = status;
            dataRow["Note"] = (string.IsNullOrEmpty(note) ?
                  dataRow["Note"].ToString()
                : dataRow["Note"].ToString() + note + System.Environment.NewLine);
        }

        private void moduleDataMigration(DataRow dataRow)
        {
            switch (dataRow["Module"].ToString())
            {
                case "Assumption Master":
                    //await Task.Run(() =>migrateDataForAssumption(dataRow));
                    migrateDataForAssumption(dataRow);
                    break;
                case "Goals":
                    //await Task.Run(() => migrateDataForGoals(dataRow));
                    migrateDataForGoals(dataRow);
                    break;
                case "Loan":
                    migrateDataForLoan(dataRow);
                    break;
                case "Non Financial Assets":
                    migrateDataForNonFinancialAssets(dataRow);
                    break;
                case "Income":
                    migrateDataForIncome(dataRow);
                    break;
                case "Expense":
                    migrateDataForExpense(dataRow);
                    break;
                case "Life Insurance":
                    migrateDateForLifeInsurance(dataRow);
                    break;
                case "General Insurance":
                    migrateDateForGeneralInsurance(dataRow);
                    break;
                case "MF":
                    migrateDateForMF(dataRow);
                    break;
                case "NPS":
                    migrateDataForNPS(dataRow);
                    break;
                case "Shares":
                    migrateDataForShares(dataRow);
                    break;
                case "Bonds":
                    migrateDataForBonds(dataRow);
                    break;
                case "SA":
                    migrateDataForSA(dataRow);
                    break;
                case "FD":
                    migrateDataForFD(dataRow);
                    break;
                case "RD":
                    migrateDataForRD(dataRow);
                    break;
                case "PF":
                    migrateDataForPF(dataRow);
                    break;
                case "SSA":
                    migrateDataForSSA(dataRow);
                    break;
                case "SCSS":
                    migrateDataForSCSS(dataRow);
                    break;
                case "NSC":
                    migrateDataForNSC(dataRow);
                    break;
                case "ULIP":
                    migrateDataForULIP(dataRow);
                    break;
                case "EPF":
                    migrateDataForEPF(dataRow);
                    break;
                case "Others":
                    migrateDataForOthers(dataRow);
                    break;
                case "Insurance Recommendation":
                    migratDataForInsuranceRecommendation(dataRow);
                    break;
                case "Personal Accident":
                    migratDataForPersonalAccident(dataRow);
                    break;
                case "Other Recommendation":
                    migratDataForOtherRecommendation(dataRow);
                    break;
                default:
                    break;
            }
        }

        private void migratDataForOtherRecommendation(DataRow dataRow)
        {
            OtherRecommendationSettingInfo otherRecommendationSettingInfo = new OtherRecommendationSettingInfo();
            List<OtherRecommendationSetting> insurances = (List<OtherRecommendationSetting>)otherRecommendationSettingInfo.GetAll(this.sourcePlanner.ID);

            DelegateUpdateAllValues delegateUpdateAllValues = new DelegateUpdateAllValues(updateAllProgressValue);
            if (insurances.Count > 0)
            {
                double processIncrementalValue = 100 / insurances.Count;
                delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", "");
                foreach (OtherRecommendationSetting otherRecommendation in insurances)
                {
                    otherRecommendation.PID = this.currentPlanner.ID;
                }
                try
                {

                    otherRecommendationSettingInfo.Update(insurances);
                }
                catch (Exception ex)
                {
                    delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", "Fail to migrate other recommendations data.");

                    StackTrace st = new StackTrace();
                    StackFrame sf = st.GetFrame(0);
                    MethodBase currentMethodName = sf.GetMethod();
                    LogDebug(currentMethodName.Name, ex);
                }
            }
            delegateUpdateAllValues(dataRow, 100, string.IsNullOrEmpty(dataRow["Note"].ToString()) ? "Success" : "Fail", dataRow["Note"].ToString());
        }

        private void migratDataForPersonalAccident(DataRow dataRow)
        {
            PersonalAccidentalInsuranceInfo personalAccidentalInsuranceInfo = new PersonalAccidentalInsuranceInfo();
            List<PersonalAccidentInsurance> insurances = (List<PersonalAccidentInsurance>)personalAccidentalInsuranceInfo.GetAll(this.sourcePlanner.ID);

            DelegateUpdateAllValues delegateUpdateAllValues = new DelegateUpdateAllValues(updateAllProgressValue);
            if (insurances.Count > 0)
            {
                double processIncrementalValue = 100 / insurances.Count;
                foreach (PersonalAccidentInsurance personalAccident in insurances)
                {
                    delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", "");
                    try
                    {
                        personalAccident.PId = this.currentPlanner.ID;
                        personalAccidentalInsuranceInfo.Add(personalAccident);
                    }
                    catch (Exception ex)
                    {
                        delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", String.Format("Fail to migrate personal accident '{0}'", personalAccident.Id));

                        StackTrace st = new StackTrace();
                        StackFrame sf = st.GetFrame(0);
                        MethodBase currentMethodName = sf.GetMethod();
                        LogDebug(currentMethodName.Name, ex);
                    }
                }
            }
            delegateUpdateAllValues(dataRow, 100, string.IsNullOrEmpty(dataRow["Note"].ToString()) ? "Success" : "Fail", dataRow["Note"].ToString());
        }

        private void migratDataForInsuranceRecommendation(DataRow dataRow)
        {
            InsuranceRecomendationInfo insuranceRecomendationInfo = new InsuranceRecomendationInfo();
            List<InsuranceRecomendationTransaction> insurances = (List<InsuranceRecomendationTransaction>)insuranceRecomendationInfo.GetAll(this.sourcePlanner.ID);

            DelegateUpdateAllValues delegateUpdateAllValues = new DelegateUpdateAllValues(updateAllProgressValue);
            if (insurances.Count > 0)
            {
                double processIncrementalValue = 100 / insurances.Count;
                foreach (InsuranceRecomendationTransaction other in insurances)
                {
                    delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", "");
                    try
                    {
                        other.PId = this.currentPlanner.ID;
                        insuranceRecomendationInfo.Add(other);
                    }
                    catch (Exception ex)
                    {
                        delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", String.Format("Fail to migrate Insurance Recommendation '{0}'", other.Id));

                        StackTrace st = new StackTrace();
                        StackFrame sf = st.GetFrame(0);
                        MethodBase currentMethodName = sf.GetMethod();
                        LogDebug(currentMethodName.Name, ex);
                    }
                }
            }
            delegateUpdateAllValues(dataRow, 100, string.IsNullOrEmpty(dataRow["Note"].ToString()) ? "Success" : "Fail", dataRow["Note"].ToString());
        }

        private void migrateDataForOthers(DataRow dataRow)
        {
            OthersInfo othersInfo = new OthersInfo();
            List<Others> others = (List<Others>)othersInfo.GetAllOthers(this.sourcePlanner.ID);

            DelegateUpdateAllValues delegateUpdateAllValues = new DelegateUpdateAllValues(updateAllProgressValue);
            if (others.Count > 0)
            {
                double processIncrementalValue = 100 / others.Count;
                foreach (Others other in others)
                {
                    delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", "");
                    try
                    {
                        other.Pid = this.currentPlanner.ID;
                        othersInfo.Add(other);
                    }
                    catch (Exception ex)
                    {
                        delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", String.Format("Fail to migrate others '{0}'", other.AccountNo));

                        StackTrace st = new StackTrace();
                        StackFrame sf = st.GetFrame(0);
                        MethodBase currentMethodName = sf.GetMethod();
                        LogDebug(currentMethodName.Name, ex);
                    }
                }
            }
            delegateUpdateAllValues(dataRow, 100, string.IsNullOrEmpty(dataRow["Note"].ToString()) ? "Success" : "Fail", dataRow["Note"].ToString());
        }

        private void migrateDataForEPF(DataRow dataRow)
        {
            EPFInfo epfInfo = new EPFInfo();
            List<EPF> epfs = (List<EPF>)epfInfo.GetAllEPF(this.sourcePlanner.ID);

            DelegateUpdateAllValues delegateUpdateAllValues = new DelegateUpdateAllValues(updateAllProgressValue);
            if (epfs.Count > 0)
            {
                double processIncrementalValue = 100 / epfs.Count;
                foreach (EPF epf in epfs)
                {
                    delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", "");
                    try
                    {
                        epf.Pid = this.currentPlanner.ID;
                        epfInfo.Add(epf);
                    }
                    catch (Exception ex)
                    {
                        delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", String.Format("Fail to migrate ULIP '{0}'", epf.AccountNo));

                        StackTrace st = new StackTrace();
                        StackFrame sf = st.GetFrame(0);
                        MethodBase currentMethodName = sf.GetMethod();
                        LogDebug(currentMethodName.Name, ex);
                    }
                }
            }
            delegateUpdateAllValues(dataRow, 100, string.IsNullOrEmpty(dataRow["Note"].ToString()) ? "Success" : "Fail", dataRow["Note"].ToString());
        }

        private void migrateDataForULIP(DataRow dataRow)
        {
            ULIPInfo uLIPInfo = new ULIPInfo();
            List<ULIP> ulips = (List<ULIP>)uLIPInfo.GetAllULIP(this.sourcePlanner.ID);

            DelegateUpdateAllValues delegateUpdateAllValues = new DelegateUpdateAllValues(updateAllProgressValue);
            if (ulips.Count > 0)
            {
                double processIncrementalValue = 100 / ulips.Count;
                foreach (ULIP ulip in ulips)
                {
                    delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", "");
                    try
                    {
                        ulip.Pid = this.currentPlanner.ID;
                        uLIPInfo.Add(ulip);
                    }
                    catch (Exception ex)
                    {
                        delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", String.Format("Fail to migrate ULIP '{0}'", ulip.FolioNo));

                        StackTrace st = new StackTrace();
                        StackFrame sf = st.GetFrame(0);
                        MethodBase currentMethodName = sf.GetMethod();
                        LogDebug(currentMethodName.Name, ex);
                    }
                }
            }
            delegateUpdateAllValues(dataRow, 100, string.IsNullOrEmpty(dataRow["Note"].ToString()) ? "Success" : "Fail", dataRow["Note"].ToString());
        }

        private void migrateDataForNSC(DataRow dataRow)
        {
            NSCInfo nscInfo = new NSCInfo();
            List<NSC> nscs = (List<NSC>)nscInfo.GetAllNSC(this.sourcePlanner.ID);

            DelegateUpdateAllValues delegateUpdateAllValues = new DelegateUpdateAllValues(updateAllProgressValue);
            if (nscs.Count > 0)
            {
                double processIncrementalValue = 100 / nscs.Count;
                foreach (NSC nsc in nscs)
                {
                    delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", "");
                    try
                    {
                        nsc.Pid = this.currentPlanner.ID;
                        nscInfo.Add(nsc);
                    }
                    catch (Exception ex)
                    {
                        delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", String.Format("Fail to migrate NSC '{0}'", nsc.DocumentNo));

                        StackTrace st = new StackTrace();
                        StackFrame sf = st.GetFrame(0);
                        MethodBase currentMethodName = sf.GetMethod();
                        LogDebug(currentMethodName.Name, ex);
                    }
                }
            }
            delegateUpdateAllValues(dataRow, 100, string.IsNullOrEmpty(dataRow["Note"].ToString()) ? "Success" : "Fail", dataRow["Note"].ToString());
        }

        private void migrateDataForSCSS(DataRow dataRow)
        {
            SCSSInfo scssInfo = new SCSSInfo();
            List<SCSS> sCSSes = (List<SCSS>)scssInfo.GetAllSCSS(this.sourcePlanner.ID);


            DelegateUpdateAllValues delegateUpdateAllValues = new DelegateUpdateAllValues(updateAllProgressValue);

            if (sCSSes.Count > 0)
            {
                double processIncrementalValue = 100 / sCSSes.Count;
                foreach (SCSS sCSS in sCSSes)
                {
                    delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", "");
                    try
                    {
                        sCSS.Pid = this.currentPlanner.ID;
                        scssInfo.Add(sCSS);
                    }
                    catch (Exception ex)
                    {
                        delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", String.Format("Fail to migrate SCSS '{0}'", sCSS.AccountNo));

                        StackTrace st = new StackTrace();
                        StackFrame sf = st.GetFrame(0);
                        MethodBase currentMethodName = sf.GetMethod();
                        LogDebug(currentMethodName.Name, ex);
                    }
                }
            }
            delegateUpdateAllValues(dataRow, 100, string.IsNullOrEmpty(dataRow["Note"].ToString()) ? "Success" : "Fail", dataRow["Note"].ToString());
        }

        private void migrateDataForSSA(DataRow dataRow)
        {
            SukanyaSamrudhiInfo samrudhiInfo = new SukanyaSamrudhiInfo();
            List<SukanyaSamrudhi> sukanyas = (List<SukanyaSamrudhi>)samrudhiInfo.GetAllSukanyaSamrudhi(this.sourcePlanner.ID);

            DelegateUpdateAllValues delegateUpdateAllValues = new DelegateUpdateAllValues(updateAllProgressValue);
            if (sukanyas.Count > 0)
            {
                double processIncrementalValue = 100 / sukanyas.Count;
                foreach (SukanyaSamrudhi sukanyaSamrudhi in sukanyas)
                {
                    delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", "");
                    try
                    {
                        sukanyaSamrudhi.Pid = this.currentPlanner.ID;
                        samrudhiInfo.Add(sukanyaSamrudhi);
                    }
                    catch (Exception ex)
                    {
                        delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", String.Format("Fail to migrate Sukanya Samrudhi '{0}'", sukanyaSamrudhi.AccountNo));

                        StackTrace st = new StackTrace();
                        StackFrame sf = st.GetFrame(0);
                        MethodBase currentMethodName = sf.GetMethod();
                        LogDebug(currentMethodName.Name, ex);
                    }
                }
            }
            delegateUpdateAllValues(dataRow, 100, string.IsNullOrEmpty(dataRow["Note"].ToString()) ? "Success" : "Fail", dataRow["Note"].ToString());
        }

        private void migrateDataForPF(DataRow dataRow)
        {
            PPFInfo ppfInfo = new PPFInfo();
            List<PPF> ppfs = (List<PPF>)ppfInfo.GetPPFAccounts(this.sourcePlanner.ID);

            DelegateUpdateAllValues delegateUpdateAllValues = new DelegateUpdateAllValues(updateAllProgressValue);

            if (ppfs.Count > 0)
            {
                double processIncrementalValue = 100 / ppfs.Count;
                foreach (PPF ppf in ppfs)
                {
                    delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", "");
                    try
                    {
                        ppf.Pid = this.currentPlanner.ID;
                        ppfInfo.Add(ppf);
                    }
                    catch (Exception ex)
                    {
                        delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", String.Format("Fail to migrate PPF '{0}'", ppf.AccountNo));

                        StackTrace st = new StackTrace();
                        StackFrame sf = st.GetFrame(0);
                        MethodBase currentMethodName = sf.GetMethod();
                        LogDebug(currentMethodName.Name, ex);
                    }
                }
            }
            delegateUpdateAllValues(dataRow, 100, string.IsNullOrEmpty(dataRow["Note"].ToString()) ? "Success" : "Fail", dataRow["Note"].ToString());
        }

        private void migrateDataForRD(DataRow dataRow)
        {
            RDInfo fDInfo = new RDInfo();
            List<RecurringDeposit> recurringDeposits = (List<RecurringDeposit>)fDInfo.GetRecurringDeposits(this.sourcePlanner.ID);

            DelegateUpdateAllValues delegateUpdateAllValues = new DelegateUpdateAllValues(updateAllProgressValue);

            if (recurringDeposits.Count > 0)
            {
                double processIncrementalValue = 100 / recurringDeposits.Count;
                foreach (RecurringDeposit recurringDeposit in recurringDeposits)
                {
                    delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", "");
                    try
                    {
                        recurringDeposit.Pid = this.currentPlanner.ID;
                        fDInfo.Add(recurringDeposit);
                    }
                    catch (Exception ex)
                    {
                        delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", String.Format("Fail to migrate recurring deposit '{0}'", recurringDeposit.AccountNo));

                        StackTrace st = new StackTrace();
                        StackFrame sf = st.GetFrame(0);
                        MethodBase currentMethodName = sf.GetMethod();
                        LogDebug(currentMethodName.Name, ex);
                    }
                }
            }
            delegateUpdateAllValues(dataRow, 100, string.IsNullOrEmpty(dataRow["Note"].ToString()) ? "Success" : "Fail", dataRow["Note"].ToString());
        }


        private void migrateDataForFD(DataRow dataRow)
        {
            FDInfo fDInfo = new FDInfo();
            List<FixedDeposit> fixedDeposits = (List<FixedDeposit>)fDInfo.GetFixedDeposits(this.sourcePlanner.ID);

            DelegateUpdateAllValues delegateUpdateAllValues = new DelegateUpdateAllValues(updateAllProgressValue);
            if (fixedDeposits.Count > 0)
            {
                double processIncrementalValue = 100 / fixedDeposits.Count;
                foreach (FixedDeposit fixedDeposit in fixedDeposits)
                {
                    delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", "");
                    try
                    {
                        fixedDeposit.Pid = this.currentPlanner.ID;
                        fDInfo.Add(fixedDeposit);
                    }
                    catch (Exception ex)
                    {
                        delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", String.Format("Fail to migrate fixed deposit '{0}'", fixedDeposit.AccountNo));

                        StackTrace st = new StackTrace();
                        StackFrame sf = st.GetFrame(0);
                        MethodBase currentMethodName = sf.GetMethod();
                        LogDebug(currentMethodName.Name, ex);
                    }
                }
            }
            delegateUpdateAllValues(dataRow, 100, string.IsNullOrEmpty(dataRow["Note"].ToString()) ? "Success" : "Fail", dataRow["Note"].ToString());
        }

        private void migrateDataForSA(DataRow dataRow)
        {
            SavingAccountInfo savingAccountInfo = new SavingAccountInfo();
            List<SavingAccount> savingAccounts = (List<SavingAccount>)savingAccountInfo.GetSavingAccounts(this.sourcePlanner.ID);

            DelegateUpdateAllValues delegateUpdateAllValues = new DelegateUpdateAllValues(updateAllProgressValue);
            if (savingAccounts.Count > 0)
            {
                double processIncrementalValue = 100 / savingAccounts.Count;
                foreach (SavingAccount savingAccount in savingAccounts)
                {
                    delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", "");
                    try
                    {
                        savingAccount.Pid = this.currentPlanner.ID;
                        savingAccountInfo.Add(savingAccount);
                    }
                    catch (Exception ex)
                    {
                        delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", String.Format("Fail to migrate saving account '{0}'", savingAccount.AccountNo));

                        StackTrace st = new StackTrace();
                        StackFrame sf = st.GetFrame(0);
                        MethodBase currentMethodName = sf.GetMethod();
                        LogDebug(currentMethodName.Name, ex);
                    }
                }
            }
            delegateUpdateAllValues(dataRow, 100, string.IsNullOrEmpty(dataRow["Note"].ToString()) ? "Success" : "Fail", dataRow["Note"].ToString());
        }

        private void migrateDataForBonds(DataRow dataRow)
        {
            BondInfo bondInfo = new BondInfo();
            List<Bonds> bonds = (List<Bonds>)bondInfo.GetAllBonds(this.sourcePlanner.ID);

            DelegateUpdateAllValues delegateUpdateAllValues = new DelegateUpdateAllValues(updateAllProgressValue);
            if (bonds.Count > 0)
            {
                double processIncrementalValue = 100 / bonds.Count;
                foreach (Bonds bond in bonds)
                {
                    delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", "");
                    try
                    {
                        bond.Pid = this.currentPlanner.ID;
                        bondInfo.Add(bond);
                    }
                    catch (Exception ex)
                    {
                        delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", String.Format("Fail to migrate bonds '{0}'", bond.CompanyName));

                        StackTrace st = new StackTrace();
                        StackFrame sf = st.GetFrame(0);
                        MethodBase currentMethodName = sf.GetMethod();
                        LogDebug(currentMethodName.Name, ex);
                    }
                }
            }
            delegateUpdateAllValues(dataRow, 100, string.IsNullOrEmpty(dataRow["Note"].ToString()) ? "Success" : "Fail", dataRow["Note"].ToString());
        }

        private void migrateDataForShares(DataRow dataRow)
        {
            SharesInfo sharesInfo = new SharesInfo();
            List<Shares> shares = (List<Shares>)sharesInfo.GetShares(this.sourcePlanner.ID);

            DelegateUpdateAllValues delegateUpdateAllValues = new DelegateUpdateAllValues(updateAllProgressValue);
            if (shares.Count > 0)
            {
                double processIncrementalValue = 100 / shares.Count;
                foreach (Shares share in shares)
                {
                    delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", "");
                    try
                    {
                        share.Pid = this.currentPlanner.ID;
                        sharesInfo.Add(share);
                    }
                    catch (Exception ex)
                    {
                        delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", String.Format("Fail to migrate shares '{0}'", share.CompanyName));

                        StackTrace st = new StackTrace();
                        StackFrame sf = st.GetFrame(0);
                        MethodBase currentMethodName = sf.GetMethod();
                        LogDebug(currentMethodName.Name, ex);
                    }
                }
            }

            delegateUpdateAllValues(dataRow, 100, string.IsNullOrEmpty(dataRow["Note"].ToString()) ? "Success" : "Fail", dataRow["Note"].ToString());
        }

        private void migrateDataForNPS(DataRow dataRow)
        {
            NPSInfo npsinfo = new NPSInfo();
            List<NPS> nps = (List<NPS>)npsinfo.GetAllNPS(this.sourcePlanner.ID);

            DelegateUpdateAllValues delegateUpdateAllValues = new DelegateUpdateAllValues(updateAllProgressValue);
            if (nps.Count > 0)
            {
                double processIncrementalValue = 100 / nps.Count;
                foreach (NPS np in nps)
                {
                    delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", "");
                    try
                    {
                        np.Pid = this.currentPlanner.ID;
                        npsinfo.Add(np);
                    }
                    catch (Exception ex)
                    {
                        delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", String.Format("Fail to migrate NPS '{0}'", np.SchemeName));

                        StackTrace st = new StackTrace();
                        StackFrame sf = st.GetFrame(0);
                        MethodBase currentMethodName = sf.GetMethod();
                        LogDebug(currentMethodName.Name, ex);
                    }
                }
            }
            delegateUpdateAllValues(dataRow, 100, string.IsNullOrEmpty(dataRow["Note"].ToString()) ? "Success" : "Fail", dataRow["Note"].ToString());
        }

        private void migrateDateForMF(DataRow dataRow)
        {
            MutualFundInfo mutualFundInfo = new MutualFundInfo();
            List<MutualFund> mutualFunds = (List<MutualFund>)mutualFundInfo.GetMutualFunds(this.sourcePlanner.ID);
            List<MutualFund> destinationMutualFunds = (List<MutualFund>)mutualFundInfo.GetMutualFunds(this.currentPlanner.ID);


            DelegateUpdateAllValues delegateUpdateAllValues = new DelegateUpdateAllValues(updateAllProgressValue);
            if (mutualFunds.Count > 0)
            {
                double processIncrementalValue = 100 / mutualFunds.Count;
                foreach (MutualFund mutualFund in mutualFunds)
                {
                    MutualFund mf = destinationMutualFunds.Find(x => x.InvesterName.Equals(mutualFund.InvesterName) && x.FolioNo.Equals(mutualFund.FolioNo) &&
                      x.CurrentValue.Equals(mutualFund.CurrentValue) &&
                      x.InvestmentReturnRate.Equals(mutualFund.InvestmentReturnRate) &&
                      x.SchemeName.Equals(mutualFund.SchemeName) &&
                      x.Units.Equals(mutualFund.Units) && x.Nav.Equals(mutualFund.Nav));

                    if (mf == null)
                    {
                        delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", "");
                        try
                        {
                            mutualFund.Pid = this.currentPlanner.ID;
                            mutualFundInfo.Add(mutualFund);
                        }
                        catch (Exception ex)
                        {
                            delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", String.Format("Fail to migrate mutual fund '{0}'", mutualFund.SchemeName));

                            StackTrace st = new StackTrace();
                            StackFrame sf = st.GetFrame(0);
                            MethodBase currentMethodName = sf.GetMethod();
                            LogDebug(currentMethodName.Name, ex);
                        }
                    }
                }
            }
            delegateUpdateAllValues(dataRow, 100, string.IsNullOrEmpty(dataRow["Note"].ToString()) ? "Success" : "Fail", dataRow["Note"].ToString());
        }

        private void migrateDateForGeneralInsurance(DataRow dataRow)
        {
            GeneralInsuranceInfo generalInsuranceInfo = new GeneralInsuranceInfo();
            List<GeneralInsurance> generalInsurances = (List<GeneralInsurance>)generalInsuranceInfo.GetAllGeneralInsurances(this.sourcePlanner.ID);
            List<GeneralInsurance> destinationGeneralInsurances = (List<GeneralInsurance>)generalInsuranceInfo.GetAllGeneralInsurances(this.currentPlanner.ID);

            DelegateUpdateAllValues delegateUpdateAllValues = new DelegateUpdateAllValues(updateAllProgressValue);
            if (generalInsurances.Count > 0)
            {
                double processIncrementalValue = 100 / generalInsurances.Count;
                foreach (GeneralInsurance generalInsurance in generalInsurances)
                {
                   GeneralInsurance generalResult = destinationGeneralInsurances.Find(x => x.Policy.Equals(generalInsurance.Policy) && x.PolicyNo.Equals(generalInsurance.PolicyNo) && x.SumAssured.Equals(generalInsurance.SumAssured) &&
                        x.Premium.Equals(generalInsurance.Premium));
                    if (generalResult == null)
                    {
                        delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", "");
                        try
                        {
                            generalInsurance.Pid = this.currentPlanner.ID;
                            generalInsuranceInfo.Add(generalInsurance);
                        }
                        catch (Exception ex)
                        {
                            delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", String.Format("Fail to migrate general insurance '{0}'", generalInsurance.Policy));

                            StackTrace st = new StackTrace();
                            StackFrame sf = st.GetFrame(0);
                            MethodBase currentMethodName = sf.GetMethod();
                            LogDebug(currentMethodName.Name, ex);
                        }
                    }
                }
            }
            delegateUpdateAllValues(dataRow, 100, string.IsNullOrEmpty(dataRow["Note"].ToString()) ? "Success" : "Fail", dataRow["Note"].ToString());
        }

        private void migrateDateForLifeInsurance(DataRow dataRow)
        {
            LifeInsuranceInfo lifeInsuranceInfo = new LifeInsuranceInfo();
            List<LifeInsurance> lifeInsurances = (List<LifeInsurance>)lifeInsuranceInfo.GetAllLifeInsurance(this.sourcePlanner.ID);
            List<LifeInsurance> destinationLifeInsurances = (List<LifeInsurance>)lifeInsuranceInfo.GetAllLifeInsurance(this.currentPlanner.ID);

            DelegateUpdateAllValues delegateUpdateAllValues = new DelegateUpdateAllValues(updateAllProgressValue);
            if (lifeInsurances.Count > 0)
            {
                double processIncrementalValue = 100 / lifeInsurances.Count;
                foreach (LifeInsurance lifeInsurance in lifeInsurances)
                {
                    LifeInsurance insuranceResult = destinationLifeInsurances.Find(x => x.Applicant.Equals(lifeInsurance.Applicant) &&
                    x.Company.Equals(lifeInsurance.Company) && x.PolicyName.Equals(lifeInsurance.PolicyName) &&
                    x.PolicyNo.Equals(lifeInsurance.PolicyNo) && x.Premium.Equals(lifeInsurance.Premium));
                    if (insuranceResult == null)
                    {
                        delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", "");
                        try
                        {
                            lifeInsurance.Pid = this.currentPlanner.ID;
                            lifeInsuranceInfo.Add(lifeInsurance);
                        }
                        catch (Exception ex)
                        {
                            delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", String.Format("Fail to migrate life insurance '{0}'", lifeInsurance.PolicyName));

                            StackTrace st = new StackTrace();
                            StackFrame sf = st.GetFrame(0);
                            MethodBase currentMethodName = sf.GetMethod();
                            LogDebug(currentMethodName.Name, ex);
                        }
                    }
                }
            }
            delegateUpdateAllValues(dataRow, 100, string.IsNullOrEmpty(dataRow["Note"].ToString()) ? "Success" : "Fail", dataRow["Note"].ToString());
        }

        private void migrateDataForExpense(DataRow dataRow)
        {
            ExpensesInfo expensesInfo = new ExpensesInfo();
            IList<Expenses> expenses = expensesInfo.GetAll(this.sourcePlanner.ID);
            List<Expenses> destinationExpenses = (List<Expenses>) expensesInfo.GetAll(this.currentPlanner.ID);

            DelegateUpdateAllValues delegateUpdateAllValues = new DelegateUpdateAllValues(updateAllProgressValue);
            if (expenses.Count > 0)
            {
                double processIncrementalValue = 100 / expenses.Count;
                foreach (Expenses expense in expenses)
                {
                    Expenses expResult = destinationExpenses.Find(x => x.Item.Equals(expense.Item) &&
                        x.ItemCategory.Equals(expense.ItemCategory) && x.OccuranceType.Equals(expense.OccuranceType) &&
                        x.InflationRate.Equals(expense.InflationRate) && x.ExpStartYear.Equals(expense.ExpStartYear));

                    if (expResult == null)
                    {
                        delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", "");
                        bool isIncomeEligibleToMigrate = validateExpenseToMigrate(expense);
                        if (isIncomeEligibleToMigrate)
                        {
                            try
                            {
                                expense.Pid = this.currentPlanner.ID;
                                expense.ExpStartYear = this.currentPlanner.StartDate.Year.ToString();
                                expense.Amount = futureValue(expense.Amount, decimal.Parse(expense.InflationRate.ToString()), currentPlanner.StartDate.Year - int.Parse(expense.ExpStartYear));
                                expensesInfo.Add(expense);
                            }
                            catch (Exception ex)
                            {
                                delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", String.Format("Fail to migrate expense  '{0}'", expense.Item));

                                StackTrace st = new StackTrace();
                                StackFrame sf = st.GetFrame(0);
                                MethodBase currentMethodName = sf.GetMethod();
                                LogDebug(currentMethodName.Name, ex);
                            }
                        }
                    }
                }
            }
            delegateUpdateAllValues(dataRow, 100, string.IsNullOrEmpty(dataRow["Note"].ToString()) ? "Success" : "Fail", dataRow["Note"].ToString());
        }

        private void migrateDataForIncome(DataRow dataRow)
        {
            IncomeInfo incomeInfo = new IncomeInfo();
            IList<Income> incomes = incomeInfo.GetAll(this.sourcePlanner.ID);
            List<Income> destinationIncomes = (List<Income>) incomeInfo.GetAll(this.currentPlanner.ID);

            DelegateUpdateAllValues delegateUpdateAllValues = new DelegateUpdateAllValues(updateAllProgressValue);
            if (incomes.Count > 0)
            {
                double processIncrementalValue = 100 / incomes.Count;
                foreach (Income income in incomes)
                {
                    Income incomeResult = destinationIncomes.Find(x => x.IncomeBy.Equals(income.IncomeBy) &&
                        x.Source.Equals(income.Source) && x.IncomeTax.Equals(income.IncomeTax) &&
                        x.ExpectedGrowthType.Equals(income.ExpectedGrowthType) &&
                        x.ExpectGrowthInPercentage.Equals(income.ExpectGrowthInPercentage));
                    if (incomeResult == null)
                    {
                        delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", "");
                        bool isIncomeEligibleToMigrate = validateIncomeToMigrate(income);
                        if (isIncomeEligibleToMigrate)
                        {
                            try
                            {
                                income.Pid = this.currentPlanner.ID;
                                if (int.Parse(income.StartYear) <= currentPlanner.StartDate.Year)
                                {
                                    income.Amount = futureValue(income.Amount, income.ExpectGrowthInPercentage, currentPlanner.StartDate.Year - int.Parse(income.StartYear));
                                    income.StartYear = currentPlanner.StartDate.Year.ToString();
                                }
                                incomeInfo.Add(income);
                            }
                            catch (Exception ex)
                            {
                                delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", String.Format("Fail to migrate income  '{0}'", income.Description));

                                StackTrace st = new StackTrace();
                                StackFrame sf = st.GetFrame(0);
                                MethodBase currentMethodName = sf.GetMethod();
                                LogDebug(currentMethodName.Name, ex);
                            }
                        }
                    }
                }
            }
            delegateUpdateAllValues(dataRow, 100, string.IsNullOrEmpty(dataRow["Note"].ToString()) ? "Success" : "Fail", dataRow["Note"].ToString());
        }

        private void migrateDataForGoals(DataRow dataRow)
        {
            GoalsInfo goalsInfo = new GoalsInfo();
            //DelegateGetGoals delegateGetGoals = new DelegateGetGoals(goalsInfo.GetAll);
            //List<Goals> goals = (List<Goals>)delegateGetGoals(this.sourcePlanner.ID);
            List<Goals> sourceGoals = (List<Goals>)goalsInfo.GetAll(this.sourcePlanner.ID);
            sourceGoals = sourceGoals.OrderBy(i => i.Priority).ToList();

            List<Goals> destinationGoals = (List<Goals>)goalsInfo.GetAll(this.currentPlanner.ID);


            DelegateUpdateAllValues delegateUpdateAllValues = new DelegateUpdateAllValues(updateAllProgressValue);
            if (sourceGoals.Count > 0)
            {
                double processIncrementalValue = 100 / sourceGoals.Count;
                foreach (Goals goal in sourceGoals)
                {
                    try
                    {


                        Goals goalResult = destinationGoals.Find(x => x.Name.Equals(goal.Name, StringComparison.OrdinalIgnoreCase) && x.StartYear == goal.StartYear && x.Category.Equals(goal.Category, StringComparison.OrdinalIgnoreCase));

                        if (goalResult == null)
                        {
                            bool isGoalEligbleToMigrate = validateGoalIsEligibleToMigrate(goal);
                            if (isGoalEligbleToMigrate)
                            {
                                goal.Pid = this.currentPlanner.ID;

                                // Set Amount based on calculation.
                                goal.Amount = futureValue(goal.Amount, goal.InflationRate, currentPlanner.StartDate.Year - this.sourcePlanner.StartDate.Year);

                                // Set Other Amount based on calculation.
                                if (goal.OtherAmount > 0)
                                {
                                    goal.OtherAmount = futureValue(goal.OtherAmount, goal.InflationRate, (currentPlanner.StartDate.Year - sourcePlanner.StartDate.Year));
                                }
                                if (goal.LoanForGoal != null)
                                {
                                    //double currentValueOfGoal = goal.Amount;
                                    //double futureValueOfGoal = futureValue(currentValueOfGoal,goal.LoanForGoal.ROI, int.Parse(goal.StartYear) - currentPlanner.StartDate.Year);
                                    //double loanPortion = goal.LoanForGoal.LoanPortion;
                                    //double futureLoanAmount = (futureValueOfGoal * loanPortion) / 100;


                                    //goal.LoanForGoal.LoanAmount = futureLoanAmount;
                                    goal.LoanForGoal.CreatedBy = Program.CurrentUser.Id;
                                    goal.LoanForGoal.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                                    goal.LoanForGoal.UpdatedBy = Program.CurrentUser.Id;
                                    goal.LoanForGoal.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                                }
                                delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", "");
                                try
                                {
                                    if (!goalsInfo.Add(goal))
                                    {
                                        delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In " +
                                            "Progress", String.Format("Fail to migrate goal '{0}'", goal.Name));
                                    }
                                }
                                catch (Exception ex)
                                {
                                    delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", String.Format("Fail to migrate goal '{0}'", goal.Name));
                                    StackTrace st = new StackTrace();
                                    StackFrame sf = st.GetFrame(0);
                                    MethodBase currentMethodName = sf.GetMethod();
                                    LogDebug(currentMethodName.Name, ex);
                                }
                            }
                            else
                            {
                                if (DevExpress.XtraEditors.XtraMessageBox.Show("Do you want to migrate goal '" + goal.Name + "' which expected to complete in year " + goal.StartYear + "?", "Migrate Goal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    goal.Pid = this.currentPlanner.ID;
                                    goal.StartYear = this.currentPlanner.StartDate.Year.ToString();
                                    goal.EndYear = this.currentPlanner.StartDate.Year.ToString();
                                    goal.CreatedBy = Program.CurrentUser.Id;
                                    goal.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                                    goal.UpdatedBy = Program.CurrentUser.Id;
                                    goal.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));

                                    if (goal.LoanForGoal != null)
                                    {
                                        //double currentValueOfGoal = goal.Amount;
                                        //double futureValueOfGoal = futureValue(currentValueOfGoal, goal.LoanForGoal.ROI, int.Parse(goal.StartYear) - currentPlanner.StartDate.Year);
                                        //double loanPortion = goal.LoanForGoal.LoanPortion;
                                        //double futureLoanAmount = (futureValueOfGoal * loanPortion) / 100;


                                        //goal.LoanForGoal.LoanAmount = futureLoanAmount;
                                        goal.LoanForGoal.CreatedBy = Program.CurrentUser.Id;
                                        goal.LoanForGoal.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                                        goal.LoanForGoal.UpdatedBy = Program.CurrentUser.Id;
                                        goal.LoanForGoal.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                                    }

                                    try
                                    {
                                        if (!goalsInfo.Add(goal))
                                        {
                                            delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", String.Format("Fail to migrate goal '{0}'", goal.Name));
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", String.Format("Fail to migrate goal '{0}'", goal.Name));
                                        StackTrace st = new StackTrace();
                                        StackFrame sf = st.GetFrame(0);
                                        MethodBase currentMethodName = sf.GetMethod();
                                        LogDebug(currentMethodName.Name, ex);
                                    }
                                }
                            }
                        }
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                }
            }
            delegateUpdateAllValues(dataRow, 100, string.IsNullOrEmpty(dataRow["Note"].ToString()) ? "Success" : "Fail", dataRow["Note"].ToString());
        }

        private void migrateDataForAssumption(DataRow dataRow)
        {

            DelegateUpdateAllValues delegateUpdateAllValues = new DelegateUpdateAllValues(updateAllProgressValue);
            try
            {
                PlannerAssumptionInfo plannerassumptionInfo = new PlannerAssumptionInfo();
                PlannerAssumption plannerAssumption = plannerassumptionInfo.GetAll(this.sourcePlanner.ID);
                plannerAssumption.Id = 0;
                plannerAssumption.Pid = currentPlanner.ID;

                if (plannerassumptionInfo.Update(plannerAssumption))
                {
                    delegateUpdateAllValues(dataRow, 100, string.IsNullOrEmpty(dataRow["Note"].ToString()) ? "Success" : "Fail", dataRow["Note"].ToString());
                }
                else
                {
                    //dataRow["FinalStatus"] = "Fail";
                    //dataRow["Status"] = 100;
                    //dataRow["Note"] = "Unable to migrate data for Assumption. Please try again.";
                    delegateUpdateAllValues(dataRow, 100, "Fail", "Unable to migrate data for Assumption. Please try again.");
                }
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                delegateUpdateAllValues(dataRow, 100, "Fail", "Unable to migrate data for Assumption. Please try again.");
            }
        }

        private void migrateDataForLoan(DataRow dataRow)
        {
            DelegateUpdateAllValues delegateUpdateAllValues = new DelegateUpdateAllValues(updateAllProgressValue);
            LoanInfo loanInfo = new LoanInfo();
            IList<Loan> loans = loanInfo.GetAll(this.sourcePlanner.ID);
            List<Loan> destinationLoans = (List<Loan>)loanInfo.GetAll(this.currentPlanner.ID);

            if (loans.Count > 0)
            {
                double processIncrementalValue = 100 / loans.Count;
                foreach (Loan loan in loans)
                {
                    Loan loanResult = destinationLoans.Find(x => x.TypeOfLoan == loan.TypeOfLoan && x.Emis == loan.Emis);
                    if (loanResult == null)
                    {
                        delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", "");
                        try
                        {
                            loan.Pid = this.currentPlanner.ID;
                            loan.OutstandingAmt = (loan.OutstandingAmt - (loan.Emis * (currentPlanner.StartDate.Year - sourcePlanner.StartDate.Year)));
                            loan.TermLeftInMonths = loan.TermLeftInMonths - ((currentPlanner.StartDate.Year - sourcePlanner.StartDate.Year) * 12);
                            loan.CreatedBy = Program.CurrentUser.Id;
                            loan.CreatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                            loan.CreatedBy = Program.CurrentUser.Id;
                            loan.UpdatedOn = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss"));
                            loan.UpdatedBy = Program.CurrentUser.Id;
                            new LoanInfo().Add(loan);
                        }
                        catch (Exception ex)
                        {
                            delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", String.Format("Fail to migrate loan '{0}'", loan.Description));
                            StackTrace st = new StackTrace();
                            StackFrame sf = st.GetFrame(0);
                            MethodBase currentMethodName = sf.GetMethod();
                            LogDebug(currentMethodName.Name, ex);
                        }
                    }
                }
            }
            delegateUpdateAllValues(dataRow, 100, string.IsNullOrEmpty(dataRow["Note"].ToString()) ? "Success" : "Fail", dataRow["Note"].ToString());
        }

        private void migrateDataForNonFinancialAssets(DataRow dataRow)
        {
            NonFinancialAssetInfo nonFinancialAssetInfo = new NonFinancialAssetInfo();
            IList<NonFinancialAsset> nonFinancialAssets = nonFinancialAssetInfo.GetAll(this.sourcePlanner.ID);
            List<NonFinancialAsset> destinationNonFinancialAssets = (List<NonFinancialAsset>)nonFinancialAssetInfo.GetAll(this.currentPlanner.ID);

            DelegateUpdateAllValues delegateUpdateAllValues = new DelegateUpdateAllValues(updateAllProgressValue);
            if (nonFinancialAssets.Count > 0)
            {
                double processIncrementalValue = 100 / nonFinancialAssets.Count;
                foreach (NonFinancialAsset nonFinancialAsset in nonFinancialAssets)
                {
                    NonFinancialAsset nfa  = destinationNonFinancialAssets.Find(x => x.Name == nonFinancialAsset.Name && x.CurrentValue == nonFinancialAsset.CurrentValue && x.MappedGoalId == nonFinancialAsset.MappedGoalId);
                    if (nfa == null)
                    {
                        delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", "");
                        try
                        {
                            nonFinancialAsset.Pid = this.currentPlanner.ID;
                            nonFinancialAssetInfo.Add(nonFinancialAsset);
                        }
                        catch (Exception ex)
                        {
                            delegateUpdateAllValues(dataRow, int.Parse(dataRow["Status"].ToString()) + processIncrementalValue, "In Progress", String.Format("Fail to migrate non financial asset '{0}'", nonFinancialAsset.Description));

                            StackTrace st = new StackTrace();
                            StackFrame sf = st.GetFrame(0);
                            MethodBase currentMethodName = sf.GetMethod();
                            LogDebug(currentMethodName.Name, ex);
                        }
                    }
                }
            }
            delegateUpdateAllValues(dataRow, 100, string.IsNullOrEmpty(dataRow["Note"].ToString()) ? "Success" : "Fail", dataRow["Note"].ToString());
        }

        private bool validateGoalIsEligibleToMigrate(Goals goal)
        {
            return int.Parse(goal.StartYear.ToString()) >= currentPlanner.StartDate.Year;
        }

        private bool validateIncomeToMigrate(Income income)
        {
            if (string.IsNullOrEmpty(income.EndYear))
            {
                return true;
            }
            else
            {
                if (int.Parse(income.EndYear) >= this.currentPlanner.StartDate.Year)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        private bool validateExpenseToMigrate(Expenses expense)
        {
            if (string.IsNullOrEmpty(expense.ExpEndYear))
            {
                return true;
            }
            else
            {
                if (int.Parse(expense.ExpEndYear) >= this.currentPlanner.StartDate.Year)
                {
                    return true;
                }
                else
                    return false;
            }
        }

        private static double futureValue(double presentValue, decimal interest_rate, int timePeriodInYears)
        {
            //FV = PV * (1 + I)T;
            interest_rate = interest_rate / 100;
            decimal futureValue = (decimal)presentValue *
                ((decimal)Math.Pow((double)(1 + interest_rate), (double)timePeriodInYears));

            return Math.Round((double)futureValue);
        }


        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= gridViewModules.RowCount - 1; i++)
            {
                gridViewModules.SetRowCellValue(i, "IsSelected", true);
            }
        }

        private void btnDeSelectAll_Click(object sender, EventArgs e)
        {
            for (int i = 0; i <= gridViewModules.RowCount - 1; i++)
            {
                gridViewModules.SetRowCellValue(i, "IsSelected", false);
            }
        }

        private void gridViewModules_BeforePrintRow(object sender, DevExpress.XtraGrid.Views.Printing.CancelPrintRowEventArgs e)
        {            
        }

        private void gridViewModules_CustomRowFilter(object sender, DevExpress.XtraGrid.Views.Base.RowFilterEventArgs e)
        {
            string module = gridViewModules.GetListSourceRowCellValue(e.ListSourceRow, "Module").ToString();
            if (module == "")
            {
                e.Visible = false;
                e.Handled = true;
            }
        }
    }
}
