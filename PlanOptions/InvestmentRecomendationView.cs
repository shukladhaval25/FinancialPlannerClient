using FinancialPlanner.Common;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.EmailManager;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.Masters;
using FinancialPlanner.Common.Model.PlanOptions;
using FinancialPlanner.Common.Model.TaskManagement.MFTransactions;
using FinancialPlanner.Common.Permission;
using FinancialPlannerClient.Master;
using FinancialPlannerClient.Master.TaskMaster;
using FinancialPlannerClient.PlannerInfo;
using FinancialPlannerClient.PlanOptions.Reports.Investment_Recommendation;
using FinancialPlannerClient.TaskManagementSystem;
using FinancialPlannerClient.TaskManagementSystem.TransactionOptions;
using FinancialPlannerClient.TaskManagementSystem.TransactionOptions.Helper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Windows.Forms;
using Unity;

namespace FinancialPlannerClient.PlanOptions
{
    public partial class InvestmentRecomendationView : DevExpress.XtraEditors.XtraForm
    {
        internal IList<AMC> amcs;
        private int selectedSchemeId;
        private Client currentClient;
        private Planner planner;
        private DataTable dtLumsumInvestment = new DataTable();
        private DataTable dtSTPInvestment = new DataTable();
        private DataTable dtSIPInvestment = new DataTable();
        private DataTable dtSwitchInvestment = new DataTable();
        int amcId;
        LumsumInvestmentRecomendationHelper lumsumInvestmentRecomendationHelper = new LumsumInvestmentRecomendationHelper();
        STPInvestmentRecommendationHelper stpInvestmentRecommendationHelper = new STPInvestmentRecommendationHelper();
        SIPInvestmentRecomendationHelper sipInvestmentRecommendationHelper = new SIPInvestmentRecomendationHelper();
        SwitchTypeInvestmentRecommendationHelper switchTypeInvestmentRecommendationHelper = new SwitchTypeInvestmentRecommendationHelper();
        InvestmentRecommedationRatioHelper investmentRecommedationRatioHelper = new InvestmentRecommedationRatioHelper();
        private ITransactionType transactionType;
        private STPTypeRecomendation stpTransactionType;
        private SwitchTypeInvRecommendationView switchTypeInvRecommendationView;
        double lumsumInvestmentAmount = 0;

        public IList<Scheme> schemes { get; private set; }

        public InvestmentRecomendationView(Client client, Planner planner)
        {
            InitializeComponent();
            this.currentClient = client;
            this.planner = planner;
        }

        private void InvestmentRecomendationView_Load(object sender, EventArgs e)
        {
            setPermission();
            loadInvestmentRatioInfo();
            loadAMC();
            loadLumsumInvestment();
            loadSTPInvestment();
            loadSIPInvestment();
            loadSwitchInvestment();
        }

        private void loadSwitchInvestment()
        {
            List<SwitchTypeInvestmentRecommendation> switchTypeInvestmentRecommendation =
                 (List<SwitchTypeInvestmentRecommendation>)switchTypeInvestmentRecommendationHelper.GetAll(this.planner.ID);
            dtSwitchInvestment = ListtoDataTable.ToDataTable(switchTypeInvestmentRecommendation);
            gridControlSwitch.DataSource = dtSwitchInvestment;
            gridViewSwitch.Columns["FromSchemeName"].VisibleIndex = 0;
            gridViewSwitch.Columns["ToSchemeName"].VisibleIndex = 1;
            gridViewSwitch.Columns["Amount"].VisibleIndex = 2;
            gridViewSwitch.Columns["Id"].Visible = false;
            gridViewSwitch.Columns["Cid"].Visible = false;
            gridViewSwitch.Columns["Pid"].Visible = false;
            gridViewSwitch.Columns["ToSchemeId"].Visible = false;
            gridViewSwitch.Columns["CreatedOn"].Visible = false;
            gridViewSwitch.Columns["CreatedBy"].Visible = false;
            gridViewSwitch.Columns["UpdatedBy"].Visible = false;
            gridViewSwitch.Columns["UpdatedOn"].Visible = false;
            gridViewSwitch.Columns["MachineName"].Visible = false;
            gridViewSwitch.Columns["UpdatedByUserName"].Visible = false;
            gridViewSwitch.Columns["FromSchemeId"].Visible = false;
        }

        private void setPermission()
        {
            if (Program.CurrentUserRolePermission.Name == "Admin")
                return;

            List<RolePermission> rolePermission = (List<RolePermission>)Program.CurrentUserRolePermission.Permissions;
            RolePermission permission = rolePermission.Find(x => x.FormName.Trim() == "Investment Recommendation");

            if (permission == null)
            {
                btnAddInvestment.Visible = false;
                btnDeleteLumsum.Visible = false;
                btnDeleteSIPInvestement.Visible = false;
                btnDeleteSTPInvestementRecommendation.Visible = false;
            }
            else
            {
                btnAddInvestment.Visible = permission.IsAdd;
                btnDeleteLumsum.Visible = permission.IsDelete;
                btnDeleteSIPInvestement.Visible = permission.IsDelete;
                btnDeleteSTPInvestementRecommendation.Visible = permission.IsDelete;
            }
        }

        private void loadInvestmentRatioInfo()
        {
            InvestmentRecommendationRatio investmentRecommendationRatio = new InvestmentRecommendationRatio();
            investmentRecommendationRatio = investmentRecommedationRatioHelper.Get(this.planner.ID);
            vGridInvestmentRatio.Rows[0].Properties.Value = investmentRecommendationRatio.EquityRatio;
            vGridInvestmentRatio.Rows[1].Properties.Value = investmentRecommendationRatio.DebtRatio;
        }

        private void loadInvestmentRatio()
        {
            DataTable dt = new DataTable();
            dt = getGroupbyTypeAndCategoryData();
            DataTable dtInvestmentRatio = new DataTable();
            dtInvestmentRatio.Columns.Add("Category", Type.GetType("System.String"));
            dtInvestmentRatio.Columns.Add("Amount", Type.GetType("System.Double"));
            dtInvestmentRatio.Columns.Add("Ratio (%)", Type.GetType("System.Double"));
            dtInvestmentRatio.Columns.Add("Type", Type.GetType("System.String"));
            double totalAmount = 0;
            foreach (DataRow dr in dt.Rows)
            {
                DataRow drInvRatio = dtInvestmentRatio.NewRow();
                drInvRatio["Category"] = dr["Category"];
                drInvRatio["Amount"] = dr["Amount"];
                totalAmount = totalAmount + double.Parse(dr["Amount"].ToString());
                drInvRatio["Type"] = dr["Type"];
                dtInvestmentRatio.Rows.Add(drInvRatio);
            }
            foreach (DataRow dr in dtInvestmentRatio.Rows)
            {
                DataRow drInvRatio = dr;
                drInvRatio["Ratio (%)"] = Math.Round((double.Parse(dr["Amount"].ToString()) * 100) / totalAmount, 2);
            }
            gridControlInvestmenRatio.DataSource = dtInvestmentRatio;
            calculateEquityDebtRatio(dtInvestmentRatio, totalAmount);
        }

        private void calculateEquityDebtRatio(DataTable dtInvestmentRatio, double totalAmount)
        {
            if (dtInvestmentRatio.Rows.Count == 0)
                return;

            DataTable newDt = dtInvestmentRatio.AsEnumerable()
                          .GroupBy(r => r.Field<string>("Type"))
                          .Select(g =>
                          {
                              var row = dtInvestmentRatio.NewRow();
                              row["Type"] = g.Key;
                              row["Amount"] = g.Sum(r => r.Field<double>("Amount"));
                              return row;
                          }).CopyToDataTable();
            if (newDt.Rows.Count > 0)
            {
                foreach (DataRow dr in newDt.Rows)
                {
                    if (dr["Type"].ToString().Trim() == "Equity")
                    {
                        txtEquityRatio.Text = Math.Round((double.Parse(dr["Amount"].ToString()) * 100) / totalAmount, 2).ToString();
                    }
                    else if (dr["Type"].ToString().Trim() == "Debt")
                    {
                        txtDebtRatio.Text = Math.Round((double.Parse(dr["Amount"].ToString()) * 100) / totalAmount, 2).ToString();
                    }
                }
            }
        }

        private DataTable getGroupbyTypeAndCategoryData()
        {
            DataTable dt = new DataTable();
            if (dtLumsumInvestment.Rows.Count > 0)
            {
                dt = dtLumsumInvestment.AsEnumerable()
                    .OrderByDescending(en => en.Field<String>("Type"))
                    .GroupBy(r => new { Col1 = r["Type"], Col2 = r["Category"] })
                    .Select(g =>
                    {
                        var row = dtLumsumInvestment.NewRow();
                        row["Amount"] = g.Sum(r => r.Field<double>("Amount"));
                        row["Category"] = g.Key.Col2;
                        row["Type"] = g.Key.Col1;
                        return row;

                    })
                    .CopyToDataTable();
            }
            return dt;
        }

        private void loadSIPInvestment()
        {
            List<SIPTypeInvestmentRecomendation> sipTypeInvestmentRecommendation =
                 (List<SIPTypeInvestmentRecomendation>)sipInvestmentRecommendationHelper.GetAll(this.planner.ID);
            dtSIPInvestment = ListtoDataTable.ToDataTable(sipTypeInvestmentRecommendation);
            gridControlSIPInvestment.DataSource = dtSIPInvestment;
            gridViewSIPInvestmentRecomendation.Columns["SchemeName"].VisibleIndex = 0;
            gridViewSIPInvestmentRecomendation.Columns["Amount"].VisibleIndex = 1;
            gridViewSIPInvestmentRecomendation.Columns["Category"].VisibleIndex = 2;
            gridViewSIPInvestmentRecomendation.Columns["ChequeInFavourOff"].VisibleIndex = 3;
            gridViewSIPInvestmentRecomendation.Columns["FirstHolder"].VisibleIndex = 4;
            gridViewSIPInvestmentRecomendation.Columns["SecondHolder"].VisibleIndex = 5;
            gridViewSIPInvestmentRecomendation.Columns["Id"].Visible = false;
            gridViewSIPInvestmentRecomendation.Columns["Cid"].Visible = false;
            gridViewSIPInvestmentRecomendation.Columns["Pid"].Visible = false;
            gridViewSIPInvestmentRecomendation.Columns["SchemeId"].Visible = false;
            gridViewSIPInvestmentRecomendation.Columns["CreatedOn"].Visible = false;
            gridViewSIPInvestmentRecomendation.Columns["CreatedBy"].Visible = false;
            gridViewSIPInvestmentRecomendation.Columns["UpdatedBy"].Visible = false;
            gridViewSIPInvestmentRecomendation.Columns["UpdatedOn"].Visible = false;
            gridViewSIPInvestmentRecomendation.Columns["MachineName"].Visible = false;
            gridViewSIPInvestmentRecomendation.Columns["UpdatedByUserName"].Visible = false;
            gridViewSIPInvestmentRecomendation.Columns["Type"].Visible = false;
        }

        private void loadSTPInvestment()
        {
            List<STPTypeInvestmentRecomendation> lumsumInvestmentRecomendations =
                (List<STPTypeInvestmentRecomendation>)stpInvestmentRecommendationHelper.GetAll(this.planner.ID);
            dtSTPInvestment = ListtoDataTable.ToDataTable(lumsumInvestmentRecomendations);
            gridControlSTPInvestment.DataSource = dtSTPInvestment;
            gridViewSTPInvestment.Columns["FromSchemeName"].VisibleIndex = 0;
            gridViewSTPInvestment.Columns["SchemeName"].VisibleIndex = 1;
            gridViewSTPInvestment.Columns["Amount"].VisibleIndex = 2;
            gridViewSTPInvestment.Columns["Duration"].VisibleIndex = 3;
            gridViewSTPInvestment.Columns["Frequency"].VisibleIndex = 4;

            gridViewSTPInvestment.Columns["Id"].Visible = false;
            gridViewSTPInvestment.Columns["Cid"].Visible = false;
            gridViewSTPInvestment.Columns["Pid"].Visible = false;
            gridViewSTPInvestment.Columns["FromSchemeId"].Visible = false;
            gridViewSTPInvestment.Columns["SchemeId"].Visible = false;
            gridViewSTPInvestment.Columns["CreatedOn"].Visible = false;
            gridViewSTPInvestment.Columns["CreatedBy"].Visible = false;
            gridViewSTPInvestment.Columns["UpdatedBy"].Visible = false;
            gridViewSTPInvestment.Columns["UpdatedOn"].Visible = false;
            gridViewSTPInvestment.Columns["MachineName"].Visible = false;
            gridViewSTPInvestment.Columns["UpdatedByUserName"].Visible = false;
        }

        private void loadLumsumInvestment()
        {
            List<LumsumInvestmentRecomendation> lumsumInvestmentRecomendations =
                (List<LumsumInvestmentRecomendation>)lumsumInvestmentRecomendationHelper.GetAll(this.planner.ID);
            DataTable dttempLumsumInv = ListtoDataTable.ToDataTable(lumsumInvestmentRecomendations);

            dtLumsumInvestment = dttempLumsumInv.Clone();
            dtLumsumInvestment.Columns["Amount"].DataType = typeof(Double);
            foreach (DataRow row in dttempLumsumInv.Rows)
            {
                dtLumsumInvestment.ImportRow(row);
            }

            gridControlLumsumInvestment.DataSource = dtLumsumInvestment;
            gridViewLumsumInvestment.Columns["Amount"].SummaryItem.SetSummary(DevExpress.Data.SummaryItemType.Custom, "{0.00##}");

            //gridViewLumsumInvestment.Columns["SchemeName"].VisibleIndex = 0;
            //gridViewLumsumInvestment.Columns["Amount"].VisibleIndex = 1;
            //gridViewLumsumInvestment.Columns["Category"].VisibleIndex = 2;
            //gridViewLumsumInvestment.Columns["ChequeInFavourOff"].VisibleIndex = 3;
            //gridViewLumsumInvestment.Columns["FirstHolder"].VisibleIndex = 4;
            //gridViewLumsumInvestment.Columns["SecondHolder"].VisibleIndex = 5;
            //gridViewLumsumInvestment.Columns["Id"].Visible = false;
            //gridViewLumsumInvestment.Columns["Cid"].Visible = false;
            //gridViewLumsumInvestment.Columns["Pid"].Visible = false;
            //gridViewLumsumInvestment.Columns["SchemeId"].Visible = false;
            //gridViewLumsumInvestment.Columns["CreatedOn"].Visible = false;
            //gridViewLumsumInvestment.Columns["CreatedBy"].Visible = false;
            //gridViewLumsumInvestment.Columns["UpdatedBy"].Visible = false;
            //gridViewLumsumInvestment.Columns["UpdatedOn"].Visible = false;
            //gridViewLumsumInvestment.Columns["MachineName"].Visible = false;
            //gridViewLumsumInvestment.Columns["UpdatedByUserName"].Visible = false;
            //gridViewLumsumInvestment.Columns["Type"].Visible = false;
            loadInvestmentRatio();
        }

        internal void loadAMC()
        {
            AMCInfo aMCInfo = new AMCInfo();
            amcs = aMCInfo.GetAll();
            DataTable dtAMC = getAMCTable();
            lookupAMC.Properties.DataSource = dtAMC;
            lookupAMC.Properties.DisplayMember = "Name";
            lookupAMC.Properties.ValueMember = "Id";
            lookupAMC.Properties.NullValuePrompt = "Please select valid value.";
        }

        private DataTable getAMCTable()
        {
            DataTable dtAMC = new DataTable();
            dtAMC.Columns.Add("Id", typeof(System.Int64));
            dtAMC.Columns.Add("Name", typeof(System.String));
            foreach (AMC amc in amcs)
            {
                DataRow dr = dtAMC.NewRow();
                dr["Id"] = amc.Id;
                dr["Name"] = amc.Name;
                dtAMC.Rows.Add(dr);
            }
            return dtAMC;
        }

        internal void loadScheme(int amcId)
        {
            SchemeInfo schemeInfo = new SchemeInfo();
            schemes = schemeInfo.GetAll(amcId);
            cmbScheme.Properties.Items.Clear();
            cmbScheme.Text = "";
            foreach (Scheme scheme in schemes)
            {
                cmbScheme.Properties.Items.Add(scheme.Name);
            }
        }

        private void lookupAMC_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit comboBoxEdit = (DevExpress.XtraEditors.LookUpEdit)sender;
            if (comboBoxEdit.SelectedText != null)
            {
                AMC amcobject = ((List<AMC>)amcs).Find(i => i.Name == comboBoxEdit.Text.ToString());
                amcId = amcobject.Id;
                loadScheme(amcobject.Id);
            }
        }

        private void cmbScheme_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.ComboBoxEdit comboBoxEdit = (DevExpress.XtraEditors.ComboBoxEdit)sender;
            if (comboBoxEdit.SelectedItem != null)
            {
                Scheme scheme = ((List<Scheme>)schemes).Find(i => i.Name == comboBoxEdit.SelectedItem.ToString());
                selectedSchemeId = scheme.Id;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            //grpInvRecDetails.Enabled = true;
        }

        private void groupControl1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void grpInvRec_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rdoInvestmentType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbScheme.SelectedItem == null)
            {
                MessageBox.Show("Please select scheme name.", "Scheme Require", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            setDisplayOption();
        }

        private void setDisplayOption()
        {
            if (rdoInvestmentType.SelectedIndex == 0)
            {
                loadLumpsumValue();
                chkSTPApply.Visible = true;
            }
            else if (rdoInvestmentType.SelectedIndex == 1)
            {
                loadSIPValue();
                chkSTPApply.Visible = false;
            }
            else if (rdoInvestmentType.SelectedIndex == 2)
            {
                loadSwitchInvestmentRecommendation();
                chkSTPApply.Visible = false;
            }
        }

        private void loadSIPValue()
        {
            try
            {
                SIPTypeInvestmentRecomendation sipInvestmentRecomendation = new SIPTypeInvestmentRecomendation();
                sipInvestmentRecomendation.Cid = this.currentClient.ID;
                Scheme selectedScheme = getSelectedScheme(cmbScheme.SelectedText.ToString());
                sipInvestmentRecomendation.SchemeId = selectedScheme.Id;
                sipInvestmentRecomendation.SchemeName = selectedScheme.Name;
                sipInvestmentRecomendation.Category = getCategoryName(selectedScheme.CategoryId);
                sipInvestmentRecomendation.ChequeInFavourOff = selectedScheme.ChequeInFavourOff;
                transactionType = Program.container.Resolve<ITransactionType>("SIPInvestmentRecomendation");
                transactionType.setVGridControl(this.vGridTransaction,this.currentClient);
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();

                transactionType.BindDataSource(jsonSerialization.SerializeToString<SIPTypeInvestmentRecomendation>(sipInvestmentRecomendation));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void loadSTPValue()
        {
            try
            {
                STPTypeInvestmentRecomendation stpInvestmentRecomendation = new STPTypeInvestmentRecomendation();
                stpInvestmentRecomendation.Cid = this.currentClient.ID;
                Scheme selectedScheme = getSelectedScheme(cmbScheme.SelectedText.ToString());
                stpInvestmentRecomendation.SchemeId = selectedScheme.Id;
                stpInvestmentRecomendation.SchemeName = selectedScheme.Name;
                stpTransactionType = new STPTypeRecomendation(amcId);
                stpTransactionType.setVGridControl(this.vGridControlSTP,this.currentClient);
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                stpInvestmentRecomendation.LumsumAmount = lumsumInvestmentAmount;
                stpTransactionType.BindDataSource(jsonSerialization.SerializeToString<STPTypeInvestmentRecomendation>(stpInvestmentRecomendation));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void loadLumpsumValue()
        {
            try
            {
                LumsumInvestmentRecomendation investmentRecomendation = new LumsumInvestmentRecomendation();
                investmentRecomendation.Cid = this.currentClient.ID;
                Scheme selectedScheme = getSelectedScheme(cmbScheme.SelectedText.ToString());
                investmentRecomendation.SchemeId = selectedScheme.Id;
                investmentRecomendation.SchemeName = selectedScheme.Name;
                investmentRecomendation.Category = getCategoryName(selectedScheme.CategoryId);
                investmentRecomendation.ChequeInFavourOff = selectedScheme.ChequeInFavourOff;
                transactionType = Program.container.Resolve<ITransactionType>("Lumsum");
                transactionType.setVGridControl(this.vGridTransaction,this.currentClient);
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();

                transactionType.BindDataSource(jsonSerialization.SerializeToString<LumsumInvestmentRecomendation>(investmentRecomendation));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
        private void loadSwitchInvestmentRecommendation()
        {
            try
            {
                SwitchTypeInvestmentRecommendation switchTypeInvestmentRecommendation = new SwitchTypeInvestmentRecommendation();
                switchTypeInvestmentRecommendation.Cid = this.currentClient.ID;
                Scheme selectedScheme = getSelectedScheme(cmbScheme.SelectedText.ToString());
                switchTypeInvestmentRecommendation.ToSchemeId = selectedScheme.Id;
                switchTypeInvestmentRecommendation.ToSchemeName = selectedScheme.Name;
                switchTypeInvRecommendationView = new SwitchTypeInvRecommendationView(amcId);
                switchTypeInvRecommendationView.setVGridControl(this.vGridTransaction,this.currentClient);
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();

                switchTypeInvRecommendationView.BindDataSource(jsonSerialization.SerializeToString<SwitchTypeInvestmentRecommendation>(switchTypeInvestmentRecommendation));
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private string getCategoryName(int categoryId)
        {
            SchemeCategoryInfo schemeCategoryInfo = new SchemeCategoryInfo();
            SchemeCategory schemeCategories = schemeCategoryInfo.Get(categoryId);
            return schemeCategories.Name;
        }

        private Scheme getSelectedScheme(string schemeName)
        {
            foreach (Scheme scheme in schemes)
            {
                if (scheme.Name == schemeName)
                {
                    return scheme;
                }
            }
            return new Scheme();
        }

        private Scheme getSelectedScheme(int id)
        {
            foreach (Scheme scheme in schemes)
            {
                if (scheme.Id == id)
                {
                    return scheme;
                }
            }
            return new Scheme();
        }

        private void vGridInvestmentRatio_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
        {
            double equityRatio = 0;
            double debtRatio = 0;
            if (e.Value != null && e.Value.ToString() != "")
            {
                decimal totalPercentage = 100;
                decimal currentCellValue;
                decimal.TryParse(e.Value.ToString(), out currentCellValue);
                decimal otherCellValue = totalPercentage - currentCellValue;

                if (e.Row.Index == 0)
                {
                    equityRatio = double.Parse(currentCellValue.ToString());
                    debtRatio = double.Parse(otherCellValue.ToString());
                    vGridInvestmentRatio.Rows[e.Row.Index + 1].Properties.Value = otherCellValue;
                }
                else
                {
                    debtRatio = double.Parse(currentCellValue.ToString());
                    equityRatio = double.Parse(otherCellValue.ToString());
                    vGridInvestmentRatio.Rows[e.Row.Index - 1].Properties.Value = otherCellValue;
                }
            }
            InvestmentRecommendationRatio investmentRecommendationRatio = new InvestmentRecommendationRatio();
            investmentRecommendationRatio.Pid = this.planner.ID;
            investmentRecommendationRatio.EquityRatio = equityRatio;
            investmentRecommendationRatio.DebtRatio = debtRatio;
            investmentRecommendationRatio.CreatedBy = this.currentClient.ID;
            investmentRecommendationRatio.CreatedOn = DateTime.Now;
            investmentRecommendationRatio.UpdatedBy = this.currentClient.ID;
            investmentRecommendationRatio.UpdatedOn = DateTime.Now;
            investmentRecommendationRatio.MachineName = Environment.MachineName;
            investmentRecommedationRatioHelper.Save(investmentRecommendationRatio);
        }

        private void btnAddInvestment_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbScheme.SelectedItem == null)
                {
                    MessageBox.Show("Please select scheme name.", "Scheme Require", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (rdoInvestmentType.SelectedIndex == 0)
                {
                    LumsumInvestmentRecomendation investmentRecomendation = getInvestmentRecomendation();
                    if (lumsumInvestmentRecomendationHelper.Save(investmentRecomendation))
                    {
                        if (chkSTPApply.Checked)
                        {
                            STPTypeInvestmentRecomendation stpInvestmentRecomendation = getSTPInvestment();
                            if (stpInvestmentRecommendationHelper.Save(stpInvestmentRecomendation))
                            {
                                loadSTPInvestment();
                                chkSTPApply.Checked = false;
                            }
                        }
                        loadLumsumInvestment();
                    }
                }                
                else if (rdoInvestmentType.SelectedIndex == 1)
                {
                    SIPTypeInvestmentRecomendation sIPTypeInvestmentRecomendation = getSIPInvestment();
                    if (sipInvestmentRecommendationHelper.Save(sIPTypeInvestmentRecomendation))
                    {
                        loadSIPInvestment();
                    }
                }
                else if (rdoInvestmentType.SelectedIndex == 2)
                {
                    SwitchTypeInvestmentRecommendation switchTypeInvestmentRecommendation = getSwitchTypeInvRecommendation();
                    if (switchTypeInvestmentRecommendationHelper.Save(switchTypeInvestmentRecommendation))
                    {
                        loadSwitchInvestment();
                        //loadSwitchInvestmentRecommendation();
                    }
                }
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                MessageBox.Show(ex.ToString());
            }
        }

        private SwitchTypeInvestmentRecommendation getSwitchTypeInvRecommendation()
        {
            SwitchTypeInvestmentRecommendation switchInvestmentRecomendation = new SwitchTypeInvestmentRecommendation();
            switchInvestmentRecomendation = (SwitchTypeInvestmentRecommendation)this.switchTypeInvRecommendationView.GetTransactionType();
            switchInvestmentRecomendation.Cid = this.currentClient.ID;
            Scheme selectedScheme = getSelectedScheme(cmbScheme.SelectedText.ToString());
            //switchInvestmentRecomendation.FromSchemeId = selectedScheme.Id;
            //switchInvestmentRecomendation.ToSchemeName = selectedScheme.Name;
            switchInvestmentRecomendation.ToSchemeId = selectedScheme.Id;
            switchInvestmentRecomendation.ToSchemeName = selectedScheme.Name;
            switchInvestmentRecomendation.Pid = this.planner.ID;
            switchInvestmentRecomendation.CreatedBy = this.currentClient.ID;
            switchInvestmentRecomendation.CreatedOn = DateTime.Now;
            switchInvestmentRecomendation.UpdatedBy = this.currentClient.ID;
            switchInvestmentRecomendation.UpdatedOn = DateTime.Now;
            switchInvestmentRecomendation.MachineName = Environment.MachineName;
           
            return switchInvestmentRecomendation;
        }

        private void LogDebug(string methodName, Exception ex)
        {
            DebuggerLogInfo debuggerInfo = new DebuggerLogInfo();
            debuggerInfo.ClassName = this.GetType().Name;
            debuggerInfo.Method = methodName;
            debuggerInfo.ExceptionInfo = ex;
            Logger.LogDebug(debuggerInfo);
        }
        private void addSIPInvestment(SIPTypeInvestmentRecomendation sIPTypeInvestmentRecomendation)
        {
            DataRow dataRow = dtSIPInvestment.NewRow();
            dataRow["CID"] = sIPTypeInvestmentRecomendation.Cid;
            dataRow["PID"] = sIPTypeInvestmentRecomendation.Pid;
            dataRow["SchemeId"] = sIPTypeInvestmentRecomendation.SchemeId;
            dataRow["SchemeName"] = sIPTypeInvestmentRecomendation.SchemeName;
            dataRow["Category"] = sIPTypeInvestmentRecomendation.Category;
            dataRow["Amount"] = sIPTypeInvestmentRecomendation.Amount;
            dataRow["ChequeInFavourOff"] = sIPTypeInvestmentRecomendation.ChequeInFavourOff;
            dataRow["FirstHolder"] = sIPTypeInvestmentRecomendation.FirstHolder;
            dataRow["SecondHolder"] = sIPTypeInvestmentRecomendation.SecondHolder;

            dtSIPInvestment.Rows.Add(dataRow);
            gridControlSIPInvestment.DataSource = dtSIPInvestment;
            gridViewSIPInvestmentRecomendation.Columns["Id"].Visible = false;
            gridViewSIPInvestmentRecomendation.Columns["CId"].Visible = false;
            gridViewSIPInvestmentRecomendation.Columns["PId"].Visible = false;
            gridViewSIPInvestmentRecomendation.Columns["SchemeId"].Visible = false;
        }

        private SIPTypeInvestmentRecomendation getSIPInvestment()
        {
            SIPTypeInvestmentRecomendation sipTypeInvestment = new SIPTypeInvestmentRecomendation();
            Scheme selectedScheme = getSelectedScheme(cmbScheme.SelectedText.ToString());
            sipTypeInvestment.SchemeId = selectedScheme.Id;
            sipTypeInvestment.SchemeName = selectedScheme.Name;
            sipTypeInvestment.Category = getCategoryName(selectedScheme.CategoryId);
            sipTypeInvestment.ChequeInFavourOff = selectedScheme.ChequeInFavourOff;
            sipTypeInvestment = (SIPTypeInvestmentRecomendation)this.transactionType.GetTransactionType();
            sipTypeInvestment.Pid = this.planner.ID;
            sipTypeInvestment.Cid = this.currentClient.ID;
            sipTypeInvestment.SchemeId = selectedScheme.Id;
            sipTypeInvestment.SchemeName = selectedScheme.Name;
            sipTypeInvestment.Category = getCategoryName(selectedScheme.CategoryId);
            sipTypeInvestment.CreatedBy = this.currentClient.ID;
            sipTypeInvestment.CreatedOn = DateTime.Now;
            sipTypeInvestment.UpdatedBy = this.currentClient.ID;
            sipTypeInvestment.UpdatedOn = DateTime.Now;
            sipTypeInvestment.MachineName = Environment.MachineName;
            return sipTypeInvestment;
        }

        private STPTypeInvestmentRecomendation getSTPInvestment()
        {
            STPTypeInvestmentRecomendation stpInvestmentRecomendation = new STPTypeInvestmentRecomendation();
            stpInvestmentRecomendation = (STPTypeInvestmentRecomendation)this.stpTransactionType.GetTransactionType();
            stpInvestmentRecomendation.Cid = this.currentClient.ID;
            Scheme selectedScheme = getSelectedScheme(cmbScheme.SelectedText.ToString());
            stpInvestmentRecomendation.SchemeId = selectedScheme.Id;
            stpInvestmentRecomendation.SchemeName = selectedScheme.Name;
            stpInvestmentRecomendation.Pid = this.planner.ID;
            stpInvestmentRecomendation.CreatedBy = this.currentClient.ID;
            stpInvestmentRecomendation.CreatedOn = DateTime.Now;
            stpInvestmentRecomendation.UpdatedBy = this.currentClient.ID;
            stpInvestmentRecomendation.UpdatedOn = DateTime.Now;
            stpInvestmentRecomendation.MachineName = Environment.MachineName;
            if (stpInvestmentRecomendation.Duration > 0)
            {
                stpInvestmentRecomendation.Amount = Math.Round(lumsumInvestmentAmount / stpInvestmentRecomendation.Duration);
            }
            stpInvestmentRecomendation.LumsumAmount = lumsumInvestmentAmount;
            return stpInvestmentRecomendation;
        }

        private LumsumInvestmentRecomendation getInvestmentRecomendation()
        {
            LumsumInvestmentRecomendation investmentRecomendation = new LumsumInvestmentRecomendation();
            Scheme selectedScheme = getSelectedScheme(cmbScheme.SelectedText.ToString());
            investmentRecomendation.SchemeId = selectedScheme.Id;
            investmentRecomendation.SchemeName = selectedScheme.Name;
            investmentRecomendation.Category = getCategoryName(selectedScheme.CategoryId);
            investmentRecomendation.ChequeInFavourOff = selectedScheme.ChequeInFavourOff;
            investmentRecomendation = (LumsumInvestmentRecomendation)this.transactionType.GetTransactionType();
            investmentRecomendation.Pid = this.planner.ID;
            investmentRecomendation.Cid = this.currentClient.ID;
            investmentRecomendation.SchemeId = selectedScheme.Id;
            investmentRecomendation.SchemeName = selectedScheme.Name;
            investmentRecomendation.Category = getCategoryName(selectedScheme.CategoryId);
            investmentRecomendation.CreatedBy = this.currentClient.ID;
            investmentRecomendation.CreatedOn = DateTime.Now;
            investmentRecomendation.UpdatedBy = this.currentClient.ID;
            investmentRecomendation.UpdatedOn = DateTime.Now;
            investmentRecomendation.MachineName = Environment.MachineName;
            return investmentRecomendation;
        }

        private void gridControlLumsumInvestment_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteLumsum_Click(object sender, EventArgs e)
        {
            try
            {
                LumsumInvestmentRecomendation investmentRecomendation = getSeletedLumsum();
                if (lumsumInvestmentRecomendationHelper.Delete(investmentRecomendation))
                {
                    MessageBox.Show("Record deleted sucessfully.");
                    loadLumsumInvestment();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private LumsumInvestmentRecomendation getSeletedLumsum()
        {
            LumsumInvestmentRecomendation lumsumInvestmentRecomendation = new LumsumInvestmentRecomendation();
            if (gridViewLumsumInvestment.SelectedRowsCount > 0)
            {
                object obj = gridViewLumsumInvestment.GetFocusedRow();
                lumsumInvestmentRecomendation.Id = int.Parse(gridViewLumsumInvestment.GetFocusedRowCellValue("Id").ToString());
                lumsumInvestmentRecomendation.Pid = int.Parse(gridViewLumsumInvestment.GetFocusedRowCellValue("Pid").ToString());
                lumsumInvestmentRecomendation.SchemeId = int.Parse(gridViewLumsumInvestment.GetFocusedRowCellValue("SchemeId").ToString());
                lumsumInvestmentRecomendation.Amount = double.Parse(gridViewLumsumInvestment.GetFocusedRowCellValue("Amount").ToString());
            }
            return lumsumInvestmentRecomendation;
        }

        private void btnDeleteSTPInvestementRecommendation_Click(object sender, EventArgs e)
        {
            try
            {
                STPTypeInvestmentRecomendation stpInvestmentRecommendation = getSelectedSTPTypeInvestmentRecommendation();
                if (stpInvestmentRecommendationHelper.Delete(stpInvestmentRecommendation))
                {
                    MessageBox.Show("Record deleted sucessfully.");
                    loadSTPInvestment();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private STPTypeInvestmentRecomendation getSelectedSTPTypeInvestmentRecommendation()
        {
            STPTypeInvestmentRecomendation sTPTypeInvestmentRecomendation = new STPTypeInvestmentRecomendation();
            if (gridViewSTPInvestment.SelectedRowsCount > 0)
            {
                object obj = gridViewLumsumInvestment.GetFocusedRow();
                sTPTypeInvestmentRecomendation.Id = int.Parse(gridViewSTPInvestment.GetFocusedRowCellValue("Id").ToString());
                sTPTypeInvestmentRecomendation.Pid = int.Parse(gridViewSTPInvestment.GetFocusedRowCellValue("Pid").ToString());
                sTPTypeInvestmentRecomendation.SchemeId = int.Parse(gridViewSTPInvestment.GetFocusedRowCellValue("SchemeId").ToString());
                sTPTypeInvestmentRecomendation.Amount = double.Parse(gridViewSTPInvestment.GetFocusedRowCellValue("Amount").ToString());
            }
            return sTPTypeInvestmentRecomendation;
        }

        private void btnDeleteSIPInvestement_Click(object sender, EventArgs e)
        {
            try
            {
                SIPTypeInvestmentRecomendation sipTypeInvestmentRecommendation = getSelectedSIPTypeInvestmentRecommendation();
                if (sipInvestmentRecommendationHelper.Delete(sipTypeInvestmentRecommendation))
                {
                    MessageBox.Show("Record deleted sucessfully.");
                    loadSIPInvestment();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private SIPTypeInvestmentRecomendation getSelectedSIPTypeInvestmentRecommendation()
        {
            SIPTypeInvestmentRecomendation sipInvestmentRecommendation = new SIPTypeInvestmentRecomendation();
            if (gridViewSTPInvestment.SelectedRowsCount > 0)
            {
                object obj = gridViewSIPInvestmentRecomendation.GetFocusedRow();
                sipInvestmentRecommendation.Id = int.Parse(gridViewSIPInvestmentRecomendation.GetFocusedRowCellValue("Id").ToString());
                sipInvestmentRecommendation.Pid = int.Parse(gridViewSIPInvestmentRecomendation.GetFocusedRowCellValue("Pid").ToString());
                sipInvestmentRecommendation.SchemeId = int.Parse(gridViewSIPInvestmentRecomendation.GetFocusedRowCellValue("SchemeId").ToString());
                sipInvestmentRecommendation.Amount = double.Parse(gridViewSIPInvestmentRecomendation.GetFocusedRowCellValue("Amount").ToString());
            }
            return sipInvestmentRecommendation;
        }

        private void chkSTPApply_CheckedChanged(object sender, EventArgs e)
        {
            vGridControlSTP.Visible = chkSTPApply.Checked;
            loadSTPValue();
        }

        private void cmbScheme_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cmbScheme.SelectedItem != null)
            {
                rdoInvestmentType_SelectedIndexChanged(sender, e);
            }
        }

        private void xtraTabInvestmentRecomendationDetails_Click(object sender, EventArgs e)
        {

        }

        private void btnReportInvRec_Click(object sender, EventArgs e)
        {
            investmentRecommendation investmentRecommendation = new investmentRecommendation(this.currentClient, this.planner);
            DevExpress.XtraReports.UI.ReportPrintTool printTool = new DevExpress.XtraReports.UI.ReportPrintTool(investmentRecommendation);
            printTool.ShowRibbonPreviewDialog();
        }

        private void btnSendInvestmentReport_Click(object sender, EventArgs e)
        {
            ClientContactInfo clientContactInfo = new ClientContactInfo();
            var contactInfo = clientContactInfo.Get(this.currentClient.ID);
            if (!isPrimaryEmailSetForClient(contactInfo))
                return;
            sendEmailForInvestmentRecommendation(contactInfo.PrimaryEmail);
            AddInvestmentSendRecommendationReport();
        }

        private void AddInvestmentSendRecommendationReport()
        {
            string filePath = Path.Combine(System.IO.Path.GetTempPath(), "InvestmentRecommendation.pdf");
            InvRecommendationSend invRecommendationSend = new InvRecommendationSend();
            invRecommendationSend.ClientId = this.currentClient.ID;
            invRecommendationSend.Pid = this.planner.ID;
            invRecommendationSend.SendDate = DateTime.Now;
            invRecommendationSend.ReportDataPath = FileConversion.GetStringfromFile(filePath);
            InvestmentRecommendationSendInfo investmentRecommendationSendInfo = new InvestmentRecommendationSendInfo();
            bool isSaved = investmentRecommendationSendInfo.AddInvRecommendationSend(invRecommendationSend);
            if (isSaved)
            {
                MessageBox.Show("Investment recommendation send sucessfully");
            }
        }
        
        private void sendEmailForInvestmentRecommendation(string primaryEmail)
        {
            try
            {
                Attachment attachment = getInvestmentRecommendationAsAttachment();
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(MailServer.FromEmail);
                mailMessage.To.Add(new MailAddress(primaryEmail));
                mailMessage.Subject = string.Format("Investment Recommendation on : {0}", DateTime.Now.Date);
                mailMessage.IsBodyHtml = true;
                mailMessage.Attachments.Add(attachment);
                mailMessage.Body = "Hi" + this.currentClient.Name + "," + Environment.NewLine + Environment.NewLine +
                    "Here in attachment we are sending you investment recommendation based on our discussion.Kindly follow your investment based on that to achieve your goals." +
                     Environment.NewLine + Environment.NewLine +
                    "With Regards," + Environment.NewLine + Environment.NewLine + "Asccent Finance solution";

                bool isEmailSend = EmailService.SendEmail(mailMessage);
                if (isEmailSend)
                {
                    MessageBox.Show("Investment recommendation report send to client on '" + primaryEmail + "'.", "Email", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Unable to send email to '" + primaryEmail + "'. Check your email configuration setting.", "Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private Attachment getInvestmentRecommendationAsAttachment()
        {
            investmentRecommendation investmentRecommendation = new investmentRecommendation(this.currentClient, this.planner);
            investmentRecommendation.ExportToPdf(Path.Combine(System.IO.Path.GetTempPath(), "InvestmentRecommendation.pdf"));
            string hostName = MailServer.HostName;
            Attachment attachment = new Attachment(Path.Combine(System.IO.Path.GetTempPath(), "InvestmentRecommendation.pdf"));
            attachment.Name = "Investment Recommendation.pdf";
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

        private void btnViewSendDetails_Click(object sender, EventArgs e)
        {
            InvRecSendDetails invRecSendDetails = new InvRecSendDetails(this.currentClient, this.planner);
            invRecSendDetails.Show();
        }


        private void btnDeleteSwitch_Click(object sender, EventArgs e)
        {
            try
            {
                SwitchTypeInvestmentRecommendation switchTypeInvestmentRecommendation = getSwitchTypeInvRecommendation();

                if (switchTypeInvestmentRecommendationHelper.Delete(switchTypeInvestmentRecommendation))
                {
                    MessageBox.Show("Record deleted sucessfully.");
                    loadSwitchInvestment();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}