using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialPlanner.Common.Model;
using System.Diagnostics;
using System.Reflection;
using FinancialPlanner.Common;

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
            showInsuranceCoverage();
        }

        private async void showInsuranceCoverage()
        {
            InsuranceCoverageService insuranceCoverageService = new InsuranceCoverageService(client, planner);
            await Task.Run(() => insuranceCoverageService.CalculateInsuranceCoverNeed());
            progressPanel1.Visible = false;
            txtEstimatedIsurnceCoverage.Text = Math.Round(insuranceCoverageService.GetEstimatedInsurnceAmount(), 2).ToString();
            gridInsuranceCalculation.DataSource = insuranceCoverageService.GetEstimatedTable();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                string filePath = System.IO.Path.GetTempPath() + "/" + "InsuranceCalculation" + DateTime.Now.Ticks.ToString() + ".xls";
                gridInsuranceCalculation.ExportToXls(filePath);
                System.Diagnostics.Process.Start(filePath);
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.StackTrace.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                System.Windows.Forms.MessageBox.Show("Exception:" + ex.ToString());
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
    }
}