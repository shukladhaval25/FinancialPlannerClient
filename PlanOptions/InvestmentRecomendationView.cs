using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using FinancialPlannerClient.Master.TaskMaster;
using FinancialPlanner.Common.Model.TaskManagement.MFTransactions;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.TaskManagementSystem;
using Unity;
using FinancialPlannerClient.Master;
using FinancialPlanner.Common.Model.Masters;
using FinancialPlannerClient.TaskManagementSystem.TransactionOptions.Helper;
using FinancialPlanner.Common.DataConversion;

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
        LumsumInvestmentRecomendationHelper lumsumInvestmentRecomendationHelper = new LumsumInvestmentRecomendationHelper();
        private ITransactionType transactionType;

        public IList<Scheme> schemes { get; private set; }

        public InvestmentRecomendationView(Client client, Planner planner)
        {
            InitializeComponent();
            this.currentClient = client;
            this.planner = planner;
        }

        private void InvestmentRecomendationView_Load(object sender, EventArgs e)
        {
            loadAMC();
            loadLumsumInvestment();
            loadSTPInvestment();
            loadSIPInvestment();
        }

        private void loadSIPInvestment()
        {
            dtSIPInvestment.Columns.Add("Id", Type.GetType("System.Int64"));
            dtSIPInvestment.Columns.Add("PId", Type.GetType("System.Int64"));
            dtSIPInvestment.Columns.Add("CId", Type.GetType("System.Int64"));
            dtSIPInvestment.Columns.Add("SchemeId", Type.GetType("System.Int64"));
            dtSIPInvestment.Columns.Add("SchemeName", Type.GetType("System.String"));
            dtSIPInvestment.Columns.Add("Amount", Type.GetType("System.Double"));
            dtSIPInvestment.Columns.Add("Category", Type.GetType("System.String"));
            dtSIPInvestment.Columns.Add("ChequeInFavourOff", Type.GetType("System.String"));
            dtSIPInvestment.Columns.Add("FirstHolder", Type.GetType("System.String"));
            dtSIPInvestment.Columns.Add("SecondHolder", Type.GetType("System.String"));
        }

        private void loadSTPInvestment()
        {
            dtSTPInvestment.Columns.Add("Id", Type.GetType("System.Int64"));
            dtSTPInvestment.Columns.Add("PId", Type.GetType("System.Int64"));
            dtSTPInvestment.Columns.Add("CId", Type.GetType("System.Int64"));
            dtSTPInvestment.Columns.Add("FromSchemeId", Type.GetType("System.Int64"));
            dtSTPInvestment.Columns.Add("FromSchemeName", Type.GetType("System.String"));
            dtSTPInvestment.Columns.Add("SchemeId", Type.GetType("System.Int64"));
            dtSTPInvestment.Columns.Add("SchemeName", Type.GetType("System.String"));
            dtSTPInvestment.Columns.Add("Amount", Type.GetType("System.Double"));
            dtSTPInvestment.Columns.Add("Duration", Type.GetType("System.Int16"));
            dtSTPInvestment.Columns.Add("Frequency", Type.GetType("System.String"));           
        }

        private void loadLumsumInvestment()
        {
            List<LumsumInvestmentRecomendation> lumsumInvestmentRecomendations = 
                (List<LumsumInvestmentRecomendation>) lumsumInvestmentRecomendationHelper.GetAll(this.planner.ID);
            dtLumsumInvestment = ListtoDataTable.ToDataTable(lumsumInvestmentRecomendations);
            gridControlLumsumInvestment.DataSource = dtLumsumInvestment;
            gridViewLumsumInvestment.Columns["SchemeName"].VisibleIndex = 0;
            gridViewLumsumInvestment.Columns["Amount"].VisibleIndex = 1;
            gridViewLumsumInvestment.Columns["Category"].VisibleIndex = 2;
            gridViewLumsumInvestment.Columns["ChequeInFavourOff"].VisibleIndex = 3;
            gridViewLumsumInvestment.Columns["FirstHolder"].VisibleIndex = 4;
            gridViewLumsumInvestment.Columns["SecondHolder"].VisibleIndex = 5;
            gridViewLumsumInvestment.Columns["Id"].Visible = false;
            gridViewLumsumInvestment.Columns["Cid"].Visible = false;
            gridViewLumsumInvestment.Columns["Pid"].Visible = false;
            gridViewLumsumInvestment.Columns["SchemeId"].Visible = false;
            gridViewLumsumInvestment.Columns["CreatedOn"].Visible = false;
            gridViewLumsumInvestment.Columns["CreatedBy"].Visible = false;
            gridViewLumsumInvestment.Columns["UpdatedBy"].Visible = false;
            gridViewLumsumInvestment.Columns["UpdatedOn"].Visible = false;
            gridViewLumsumInvestment.Columns["MachineName"].Visible = false;
            gridViewLumsumInvestment.Columns["UpdatedByUserName"].Visible = false;           
        }

        internal void loadAMC()
        {
            AMCInfo aMCInfo = new AMCInfo();
            amcs = aMCInfo.GetAll();
            DataTable dtAMC = getAMCTable();
            lookupAMC.Properties.DataSource  = dtAMC;
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
            lstSchemes.Items.Clear();
            foreach (Scheme scheme in schemes)
            {
                lstSchemes.Items.Add(scheme.Name);
            }
        }

        private void lookupAMC_EditValueChanged(object sender, EventArgs e)
        {
            DevExpress.XtraEditors.LookUpEdit comboBoxEdit = (DevExpress.XtraEditors.LookUpEdit)sender;
            if (comboBoxEdit.SelectedText != null)
            {
                AMC amcobject = ((List<AMC>)amcs).Find(i => i.Name == comboBoxEdit.Text.ToString());
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
            if (lstSchemes.SelectedItems.Count <= 0)
            {
                MessageBox.Show("Please select scheme name.", "Scheme Require", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if (rdoInvestmentType.SelectedIndex == 0)
            {
                loadLumpsumValue();
            }
            else if(rdoInvestmentType.SelectedIndex == 1)
            {
                loadSTPValue();
            }
            else if (rdoInvestmentType.SelectedIndex == 2)
            {
                loadSIPValue();
            }
        }

        private void loadSIPValue()
        {
            try
            {
                SIPTypeInvestmentRecomendation sipInvestmentRecomendation = new SIPTypeInvestmentRecomendation();
                sipInvestmentRecomendation.Cid = this.currentClient.ID;
                Scheme selectedScheme = getSelectedScheme(lstSchemes.SelectedItem.ToString());
                sipInvestmentRecomendation.SchemeId = selectedScheme.Id;
                sipInvestmentRecomendation.SchemeName = selectedScheme.Name;
                sipInvestmentRecomendation.Category = getCategoryName(selectedScheme.CategoryId);
                sipInvestmentRecomendation.ChequeInFavourOff = selectedScheme.ChequeInFavourOff;
                transactionType = Program.container.Resolve<ITransactionType>("SIPInvestmentRecomendation");
                transactionType.setVGridControl(this.vGridTransaction);
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
                Scheme selectedScheme = getSelectedScheme(lstSchemes.SelectedItem.ToString());
                stpInvestmentRecomendation.SchemeId = selectedScheme.Id;
                stpInvestmentRecomendation.SchemeName = selectedScheme.Name;
                transactionType = Program.container.Resolve<ITransactionType>("STPRecomendationType");
                transactionType.setVGridControl(this.vGridTransaction);
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();

                transactionType.BindDataSource(jsonSerialization.SerializeToString<STPTypeInvestmentRecomendation>(stpInvestmentRecomendation));
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
                Scheme selectedScheme = getSelectedScheme(lstSchemes.SelectedItem.ToString());
                investmentRecomendation.SchemeId = selectedScheme.Id;
                investmentRecomendation.SchemeName = selectedScheme.Name;
                investmentRecomendation.Category = getCategoryName(selectedScheme.CategoryId);
                investmentRecomendation.ChequeInFavourOff = selectedScheme.ChequeInFavourOff;
                transactionType = Program.container.Resolve<ITransactionType>("Lumsum");
                transactionType.setVGridControl(this.vGridTransaction);
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                
                transactionType.BindDataSource(jsonSerialization.SerializeToString<LumsumInvestmentRecomendation>(investmentRecomendation));
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
            foreach(Scheme scheme in schemes)
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
                if (scheme.Id  == id)
                {
                    return scheme;
                }
            }
            return new Scheme();
        }

        private void lstSchemes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSchemes.SelectedItem != null)
            {
                rdoInvestmentType_SelectedIndexChanged(sender, e);
            }
        }

        private void vGridInvestmentRatio_CellValueChanged(object sender, DevExpress.XtraVerticalGrid.Events.CellValueChangedEventArgs e)
        {
            if (e.Value != null && e.Value.ToString() != "")
            {
                decimal totalPercentage = 100;
                decimal currentCellValue;
                decimal.TryParse(e.Value.ToString(), out currentCellValue);
                decimal otherCellValue = totalPercentage - currentCellValue;
                if (e.Row.Index == 0 )
                {
                    vGridInvestmentRatio.Rows[e.Row.Index + 1].Properties.Value = otherCellValue;
                }
                else
                {
                    vGridInvestmentRatio.Rows[e.Row.Index - 1].Properties.Value = otherCellValue;
                }
            }
            
        }

        private void btnAddInvestment_Click(object sender, EventArgs e)
        {
            try
            {
                if (lstSchemes.SelectedItems.Count <= 0)
                {
                    MessageBox.Show("Please select scheme name.", "Scheme Require", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }            
                if (rdoInvestmentType.SelectedIndex == 0)
                {
                    LumsumInvestmentRecomendation investmentRecomendation = getInvestmentRecomendation();
                    if (lumsumInvestmentRecomendationHelper.Save(investmentRecomendation))
                    {
                        loadLumsumInvestment();
                    }
                }
                else if (rdoInvestmentType.SelectedIndex == 1)
                {
                    STPTypeInvestmentRecomendation stpInvestmentRecomendation = getSTPInvestment();
                    addSTPInvestment(stpInvestmentRecomendation);
                }
                else if (rdoInvestmentType.SelectedIndex == 2)
                {
                    SIPTypeInvestmentRecomendation sIPTypeInvestmentRecomendation = getSIPInvestment();
                    addSIPInvestment(sIPTypeInvestmentRecomendation);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
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
            gridViewSIPInvestmentRecomendation .Columns["CId"].Visible = false;
            gridViewSIPInvestmentRecomendation.Columns["PId"].Visible = false;
            gridViewSIPInvestmentRecomendation.Columns["SchemeId"].Visible = false;
        }

        private SIPTypeInvestmentRecomendation getSIPInvestment()
        {
            SIPTypeInvestmentRecomendation sipTypeInvestment = new SIPTypeInvestmentRecomendation();
            Scheme selectedScheme = getSelectedScheme(lstSchemes.SelectedItem.ToString());
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
            return sipTypeInvestment;
        }

        private STPTypeInvestmentRecomendation getSTPInvestment()
        {
            STPTypeInvestmentRecomendation stpInvestmentRecomendation = new STPTypeInvestmentRecomendation();
            stpInvestmentRecomendation = (STPTypeInvestmentRecomendation)this.transactionType.GetTransactionType();
            stpInvestmentRecomendation.Cid = this.currentClient.ID;
            Scheme selectedScheme = getSelectedScheme(lstSchemes.SelectedItem.ToString());
            stpInvestmentRecomendation.SchemeId = selectedScheme.Id;
            stpInvestmentRecomendation.SchemeName = selectedScheme.Name;
            stpInvestmentRecomendation.Pid = this.planner.ID;
            return stpInvestmentRecomendation;
        }

        private LumsumInvestmentRecomendation getInvestmentRecomendation()
        {
            LumsumInvestmentRecomendation investmentRecomendation = new LumsumInvestmentRecomendation();
            Scheme selectedScheme = getSelectedScheme(lstSchemes.SelectedItem.ToString());
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

        private void addLumsumInvestment(LumsumInvestmentRecomendation investmentRecomendation)
        {
            DataRow drLumsumInv = dtLumsumInvestment.NewRow();
            drLumsumInv["CID"] = investmentRecomendation.Cid;
            drLumsumInv["PID"] = investmentRecomendation.Pid;
            drLumsumInv["SchemeId"] = investmentRecomendation.SchemeId;
            drLumsumInv["SchemeName"] = investmentRecomendation.SchemeName;
            drLumsumInv["Category"] = investmentRecomendation.Category;
            drLumsumInv["Amount"] = investmentRecomendation.Amount;
            drLumsumInv["ChequeInFavourOff"] = investmentRecomendation.ChequeInFavourOff;
            drLumsumInv["FirstHolder"] = investmentRecomendation.FirstHolder;
            drLumsumInv["SecondHolder"] = investmentRecomendation.SecondHolder;

            dtLumsumInvestment.Rows.Add(drLumsumInv);
                   
        }
        private void addSTPInvestment (STPTypeInvestmentRecomendation stpInvestmentRecomendation)
        {
            DataRow dataRow = dtSTPInvestment.NewRow();
            dataRow["CID"] = stpInvestmentRecomendation.Cid;
            dataRow["PID"] = stpInvestmentRecomendation.Pid;
            dataRow["FromSchemeId"] = stpInvestmentRecomendation.FromSchemeId;
            dataRow["FromSchemeName"] = stpInvestmentRecomendation.FromSchemeName;
            dataRow["SchemeId"] = stpInvestmentRecomendation.SchemeId;
            dataRow["SchemeName"] = stpInvestmentRecomendation.SchemeName;
            dataRow["Amount"] = stpInvestmentRecomendation.Amount;
            dataRow["Duration"] = stpInvestmentRecomendation.Duration;
            dataRow["Frequency"] = stpInvestmentRecomendation.Frequency;

            dtSTPInvestment.Rows.Add(dataRow);
            gridControlSTPInvestment.DataSource = dtSTPInvestment;
            gridViewSTPInvestment.Columns["Id"].Visible = false;
            gridViewSTPInvestment.Columns["CId"].Visible = false;
            gridViewSTPInvestment.Columns["PId"].Visible = false;
            gridViewSTPInvestment.Columns["SchemeId"].Visible = false;
            gridViewSTPInvestment.Columns["FromSchemeId"].Visible = false;
        }

        private void gridControlLumsumInvestment_Click(object sender, EventArgs e)
        {

        }
    }
}