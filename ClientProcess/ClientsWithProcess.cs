using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using FinancialPlanner.Common;
using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Model.TaskManagement;
using FinancialPlanner.Common.Planning;
using FinancialPlannerClient.Clients;
using FinancialPlannerClient.TaskManagementSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FinancialPlannerClient.ClientProcess
{
    public partial class ClientsWithProcess : DevExpress.XtraEditors.XtraForm
    {
        DataTable dtCurrentClientProcess;
        DataTable dtProspectClients;
        ClientWithProcesInfo clientWithProcesInfo;


        DataTable dtProcess = new DataTable();
        IList<PrimaryStep> primarySteps;
        IList<LinkSubStep> linkSubSteps;
        const int processControllerWidth = 320;
        const int processControllerHeight = 90;
        private const string CLIENTS_GETBYID = "Client/GetById?id={0}";
        FinancialPlannerClient.Controls.ProcessContoller[] processContollers;
        FinancialPlannerClient.Controls.ProcessContoller[] subStepProcessControllers;
        DataTable dtProcessInfo;


        public ClientsWithProcess()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ClientsWithProcess_Load(object sender, EventArgs e)
        {
            clientWithProcesInfo = new ClientWithProcesInfo();
            IList<CurrentClientProcess> currentClientProcesses = clientWithProcesInfo.GetAll();
            dtCurrentClientProcess = ListtoDataTable.ToDataTable(currentClientProcesses.ToList());
            gridClientWithProcess.DataSource = dtCurrentClientProcess;
            gridViewClientWithProcess.Columns["PrimaryStepId"].Visible = false;
            gridViewClientWithProcess.Columns["LinkSubStepId"].Visible = false;
            rdoViewOption.SelectedIndex = 0;
        }

        private void rdoViewOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rdoViewOption.SelectedIndex == 0)
            {
                pnlProcessWiseClient.Visible = false;
                pnlClientWiseProcess.Visible = true;
                pnlClientWiseProcess.Width = pnlProcessWiseClient.Width;
            }
            else if (rdoViewOption.SelectedIndex == 1)
            {
                pnlClientWiseProcess.Visible = false;
                pnlProcessWiseClient.Visible = true;
                loadPrimaryStepData();
            }
            else
            {
                pnlClientWiseProcess.Visible = false;
                pnlProcessWiseClient.Visible = false;
            }
        }

        #region "Process Wise Client"
        PrimaryStep primaryStep = new PrimaryStep();

        private void loadPrimaryStepData()
        {
            TaskManagementSystem.ProcessesInfo processesInfo = new TaskManagementSystem.ProcessesInfo();
            primarySteps = processesInfo.GetPrimarySteps();
            dtProcess = ListtoDataTable.ToDataTable(primarySteps.ToList());
            

            processContollers = new FinancialPlannerClient.Controls.ProcessContoller[dtProcess.Rows.Count];
            int positionX = 10;
            int positionY = 50;

            for (int i = 0; i < dtProcess.Rows.Count; i++)
            {
                processContollers[i] = new FinancialPlannerClient.Controls.ProcessContoller();
                processContollers[i].lblProcessNo.Tag = dtProcess.Rows[i]["Id"].ToString();
                processContollers[i].lblProcessNo.Text = dtProcess.Rows[i]["StepNo"].ToString();
                processContollers[i].lblTitle.Text = dtProcess.Rows[i]["Title"].ToString();
                processContollers[i].lblTitle.BackColor = processContollers[i].lblProcessNo.BackColor; processContollers[i].Visible = true;
                pnlProcessControl.Controls.Add(processContollers[i]);
                processContollers[i].Location = new Point(positionX, positionY);
                processContollers[i].lblProcessNo.Click += new System.EventHandler(this.processContoller_Click);
                processContollers[i].lblTitle.Click += new System.EventHandler(this.processContoller_Click);
                processContollers[i].Click += new System.EventHandler(this.processContoller_Click);
                processContollers[i].btnInformation.Click += new System.EventHandler(this.primaryProcessInfo_Click);
                processContollers[i].btnInformation.Tag = dtProcess.Rows[i]["StepNo"].ToString();

                if (i != dtProcess.Rows.Count - 1)
                {
                    processContollers[i].IsHaveSubProcess = true;
                    positionY = positionY + processControllerHeight;
                }
                else
                {
                    processContollers[i].IsHaveSubProcess = false;
                }
            }
        }

        private void primaryProcessInfo_Click(object sender, EventArgs e)
        {

            processContoller_Click(sender, e);

            DataTable dtData = new DataTable();

            DataRow[] drs = dtCurrentClientProcess.Select("PrimaryStepNo =" + primaryStep.StepNo);
            if (drs.Count() > 0)
            {
                dtData = drs.CopyToDataTable();
            }
            gridClientProcess.DataSource = dtData;
            if (grdViewClientProcess.Columns.Count > 0)
            {
                grdViewClientProcess.Columns["ClientId"].Visible = false;
                grdViewClientProcess.Columns["PrimaryStepId"].Visible = false;
                grdViewClientProcess.Columns["LinkSubStepId"].Visible = false;
                grdViewClientProcess.Columns["AssignTo"].Visible = false;
            }
        }

        private void processContoller_Click(object sender, EventArgs e)
        {
            int processNo = 0;
            string processTitle = "";

            if (sender.GetType().Name.Equals("ProcessContoller"))
            {
                int.TryParse(((FinancialPlannerClient.Controls.ProcessContoller)sender).lblProcessNo.Text, out processNo);
                processTitle = ((FinancialPlannerClient.Controls.ProcessContoller)sender).lblTitle.Text;
                primaryStep = primarySteps.First(i => i.StepNo.ToString().Equals(((System.Windows.Forms.Label)sender).Text.Trim()));
            }

            if (sender.GetType().Name.Equals("Label"))
            {
                if (((System.Windows.Forms.Label)sender).Name.Equals("lblTitle"))
                {
                    primaryStep = primarySteps.First(i => i.Title.Equals(((System.Windows.Forms.Label)sender).Text.Trim()));
                }
                else if (((System.Windows.Forms.Label)sender).Name.Equals("lblProcessNo"))
                {
                    primaryStep = primarySteps.First(i => i.StepNo.ToString().Equals(((System.Windows.Forms.Label)sender).Text.Trim()));
                }
            }
            if (sender.GetType().Name.Equals("SimpleButton"))
            {
                int.TryParse(((FinancialPlannerClient.Controls.ProcessContoller)((DevExpress.XtraEditors.SimpleButton)sender).Parent.Parent).lblProcessNo.Text, out processNo);
                processTitle = ((FinancialPlannerClient.Controls.ProcessContoller)((DevExpress.XtraEditors.SimpleButton)sender).Parent.Parent).lblTitle.Text;
                primaryStep = primarySteps.First(i => i.StepNo.ToString().Equals(processNo.ToString()));
            }
            TaskManagementSystem.ProcessesInfo processesInfo = new TaskManagementSystem.ProcessesInfo();
            linkSubSteps = processesInfo.GetLinkSubSteps(primaryStep.Id);

            DataTable dtLinkSubStep = ListtoDataTable.ToDataTable(linkSubSteps.ToList());
            
            if (subStepProcessControllers != null)
            {
                pnlSubStepProcess.Controls.Clear();
                pnlSubStepProcess.Controls.Add(lblSubProcessStepTitle);
            }
            subStepProcessControllers = new FinancialPlannerClient.Controls.ProcessContoller[dtLinkSubStep.Rows.Count];
            lblSubProcessStepTitle.Text = "Sub Process Step" + " (" + primaryStep.Title + ")";
            int positionX = 10;
            int positionY = 50;

            for (int i = 0; i < dtLinkSubStep.Rows.Count; i++)
            {
                subStepProcessControllers[i] = new FinancialPlannerClient.Controls.ProcessContoller();
                subStepProcessControllers[i].lblProcessNo.Text = primaryStep.StepNo + "." + dtLinkSubStep.Rows[i]["StepNo"].ToString();
                subStepProcessControllers[i].lblProcessNo.Tag = dtLinkSubStep.Rows[i]["StepNo"].ToString();
                subStepProcessControllers[i].lblTitle.Text = dtLinkSubStep.Rows[i]["Title"].ToString();
                subStepProcessControllers[i].lblTitle.BackColor = subStepProcessControllers[i].lblProcessNo.BackColor;
                subStepProcessControllers[i].Visible = true;
                pnlSubStepProcess.Controls.Add(subStepProcessControllers[i]);
                subStepProcessControllers[i].Location = new Point(positionX, positionY);
                subStepProcessControllers[i].lblProcessNo.Click += new System.EventHandler(this.subStepProcessContoller_Click);
                subStepProcessControllers[i].lblTitle.Click += new System.EventHandler(this.subStepProcessContoller_Click);
                subStepProcessControllers[i].Click += new System.EventHandler(this.subStepProcessContoller_Click);
                subStepProcessControllers[i].btnInformation.Click += new System.EventHandler(this.processInfo_Click);
                subStepProcessControllers[i].btnInformation.Tag = dtLinkSubStep.Rows[i]["StepNo"].ToString();

                if (i != dtLinkSubStep.Rows.Count - 1)
                {
                    subStepProcessControllers[i].IsHaveSubProcess = true;
                    positionY = positionY + processControllerHeight;
                }
                else
                {
                    subStepProcessControllers[i].IsHaveSubProcess = false;
                }
            }

        }

        private void subStepProcessContoller_Click(object sender, EventArgs e)
        {
        }

        private void processInfo_Click(object sender, EventArgs e)
        {
            DataTable dtData = new DataTable();

            string linkSubStepNo = ((DevExpress.XtraEditors.SimpleButton)sender).Tag.ToString().Trim();

            DataRow[] drs = dtCurrentClientProcess.Select("PrimaryStepNo =" + primaryStep.StepNo + " and LinkSubStepNo =" + linkSubStepNo);
            if (drs.Count() > 0)
            {
                dtData = drs.CopyToDataTable();
            }
            gridClientProcess.DataSource = dtData;
            if (dtData.Columns.Count > 0)
            {
                grdViewClientProcess.Columns["ClientId"].Visible = false;
                grdViewClientProcess.Columns["PrimaryStepId"].Visible = false;
                grdViewClientProcess.Columns["LinkSubStepId"].Visible = false;
                grdViewClientProcess.Columns["AssignTo"].Visible = false;
            }
        }

        private void grdViewClientProcess_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
        {
            GridView View = sender as GridView;
            if (e.RowHandle >= 0)
            {
                DateTime expectedCompletionDate;
                DateTime.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["ExpectedCompletionDate"]), out expectedCompletionDate);

                if (isOverProcessOverDue(e, View, expectedCompletionDate))
                {
                    e.Appearance.BackColor = Color.LightSalmon;
                    e.Appearance.BackColor2 = Color.SeaShell;
                    e.HighPriority = true;
                }
            }
        }

        private static bool isOverProcessOverDue(RowStyleEventArgs e, GridView View, DateTime expectedCompletionDate)
        {
            if (string.IsNullOrEmpty(View.GetRowCellDisplayText(e.RowHandle, View.Columns["ActualCompletionDate"])))
                return string.IsNullOrEmpty(View.GetRowCellDisplayText(e.RowHandle, View.Columns["ActualCompletionDate"])) && DateTime.Now.Date > expectedCompletionDate;
            else
            {
                DateTime actualCompletionDate;
                DateTime.TryParse(View.GetRowCellDisplayText(e.RowHandle, View.Columns["ActualCompletionDate"]), out actualCompletionDate);
                if (actualCompletionDate > expectedCompletionDate)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
        #endregion

        private void grdViewClientProcess_DoubleClick(object sender, EventArgs e)
        {
            gridViewClientWithProcess_DoubleClick(sender, e);
            //DXMouseEventArgs ea = e as DXMouseEventArgs;
            //GridView view = sender as GridView;
            //GridHitInfo info = view.CalcHitInfo(ea.Location);
            //if (info.HitTest == GridHitTest.RowIndicator)
            //{
            //    MessageBox.Show(string.Format("DoubleClick on row indicator, row #{0}", info.RowHandle));
            //}
        }

        private void gridViewClientWithProcess_DoubleClick(object sender, EventArgs e)
        {
            DXMouseEventArgs ea = e as DXMouseEventArgs;
            GridView view = sender as GridView;
            GridHitInfo info = view.CalcHitInfo(ea.Location);
            if (info.HitTest == GridHitTest.RowCell && info.Column.FieldName.Equals("RefTaskId"))
            {
                openTask(info);
            }
            else if (info.HitTest == GridHitTest.RowCell && (info.Column.FieldName.Equals("ClientId") ||
                info.Column.FieldName.Equals("ClientName")))
            {
                int clientId  = int.Parse(view.GetRowCellValue(info.RowHandle, "ClientId").ToString());
                openCustomer(clientId);
            }
        }

        private void openCustomer(int id)
        {
            Client client = loadCustomerData(id);
            ClientDetails clientDetails = new ClientDetails(client);
            clientDetails.ShowDialog();
        }

        private Client loadCustomerData(int clientId)
        {
            FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
            string apiurl = Program.WebServiceUrl + "/" + string.Format(CLIENTS_GETBYID,clientId);

            RestAPIExecutor restApiExecutor = new RestAPIExecutor();

            var restResult = restApiExecutor.Execute<Client>(apiurl, null, "GET");

            if (jsonSerialization.IsValidJson(restResult.ToString()))
            {
                Client client = jsonSerialization.DeserializeFromString<Client>(restResult.ToString());
                return client;
            }
            else
            {
                XtraMessageBox.Show(restResult.ToString(), "Error");
            }
            return null;
        }



        private static void openTask(GridHitInfo info)
        {
            string taskId = (info.View.FocusedValue == null) ? "" : info.View.FocusedValue.ToString();
            TaskCardService taskCardService = new TaskCardService();
            IList<TaskCard> tasks = taskCardService.GetTaskByTaskId(taskId);
            if (tasks.Count > 0)
            {
                ViewTaskCard viewTaskCard = new ViewTaskCard(tasks[0]);
                viewTaskCard.Show();
            }
        }
    }
}
