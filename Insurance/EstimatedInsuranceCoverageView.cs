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
using FinancialPlanner.Common.Model;

namespace FinancialPlannerClient.Insurance
{
    public partial class EstimatedInsuranceCoverageView : DevExpress.XtraEditors.XtraForm
    {
        Client client;
        Planner planner;
        public EstimatedInsuranceCoverageView(Client client, Planner planner)
        {
            InitializeComponent();
            this.client = client;
            this.planner = planner;
        }

        private void EstimatedInsuranceCoverageView_Load(object sender, EventArgs e)
        {
            InsuranceCoverageService insuranceCoverageService = new InsuranceCoverageService(client, planner);
            insuranceCoverageService.CalculateInsuranceCoverNeed();
            txtEstimatedIsurnceCoverage.Text = Math.Round(insuranceCoverageService.GetEstimatedInsurnceAmount(),2).ToString();
            gridInsuranceCalculation.DataSource = insuranceCoverageService.GetEstimatedTable();

        }
    }
}