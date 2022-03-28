using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.Planning;
using FinancialPlannerClient.Clients;
using FinancialPlannerClient.Controls;
using FinancialPlannerClient.TaskManagementSystem;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace FinancialPlannerClient.ClientProcess
{
    public partial class SingleClientProcess : DevExpress.XtraEditors.XtraForm
    {
        DataTable dtProcess = new DataTable();
        IList<PrimaryStep> primarySteps;
        IList<LinkSubStep> linkSubSteps;
        const int processControllerWidth = 320;
        const int processControllerHeight = 90;
        FinancialPlannerClient.Controls.ProcessContoller[] processContollers;
        FinancialPlannerClient.Controls.ProcessContoller[] subStepProcessControllers;
        DataTable dtClientProcess = new DataTable();
        PersonalInformation personalInformation;
        Planner planner;
        PrimaryStep primaryStep = new PrimaryStep();
        
        public SingleClientProcess(PersonalInformation personalInformation, Planner planner)
        {
            InitializeComponent();
            this.personalInformation = personalInformation;
            this.planner = planner;
        }

        private void SingleClientProcess_Load(object sender, EventArgs e)
        {
            loadProcessCompleteInforamtion();
            loadPrimaryStepData();
        }


        private void loadProcessCompleteInforamtion()
        {
            ClientWithProcesInfo clientWithProcesInfo = new ClientWithProcesInfo();
            IList<CurrentClientProcess> currentClientProcesses = (this.planner == null) ?
                clientWithProcesInfo.GetClientProcess(this.personalInformation.Client.ID, null) :
                clientWithProcesInfo.GetClientProcess(this.personalInformation.Client.ID, planner.ID);
            if (currentClientProcesses != null)
                dtClientProcess = ListtoDataTable.ToDataTable(currentClientProcesses.ToList());
        }

        private void loadPrimaryStepData()
        {
            ProcessesInfo processesInfo = new ProcessesInfo();
            primarySteps = processesInfo.GetPrimarySteps();
            dtProcess = ListtoDataTable.ToDataTable(primarySteps.ToList());
            //grdProcessStep.DataSource = dtProcess;

            processContollers = new FinancialPlannerClient.Controls.ProcessContoller[dtProcess.Rows.Count];
            int positionX = 10;
            int positionY = 50;

            for (int i = 0; i < dtProcess.Rows.Count; i++)
            {
                processContollers[i] = new FinancialPlannerClient.Controls.ProcessContoller();
                processContollers[i].lblProcessNo.Text = dtProcess.Rows[i]["StepNo"].ToString();
                processContollers[i].lblTitle.Text = dtProcess.Rows[i]["Title"].ToString();
                processContollers[i].Visible = true;
                pnlProcessControl.Controls.Add(processContollers[i]);
                processContollers[i].Location = new Point(positionX, positionY);
                processContollers[i].lblProcessNo.Click += new System.EventHandler(this.processContoller_Click);
                processContollers[i].lblTitle.Click += new System.EventHandler(this.processContoller_Click);
                processContollers[i].Click += new System.EventHandler(this.processContoller_Click);
                processContollers[i].btnInformation.Click += new System.EventHandler(this.primaryProcessInfo_Click);

                if (dtClientProcess.Columns.Contains("ProcesssStatus"))
                {
                    DataRow[] dataRows = dtClientProcess.Select("ProcessStatus = 'P'");
                    if (dataRows.Count() > 0)
                    {
                        int inProcessPrimaryStepNo = int.Parse(dataRows[0]["PrimaryStepNo"].ToString());
                        if (dtProcess.Rows[i]["StepNo"].ToString().Equals(inProcessPrimaryStepNo.ToString()))
                        {
                            processContollers[i].IsInProcess = true;
                        }
                        else if (int.Parse(dtProcess.Rows[i]["StepNo"].ToString()) < inProcessPrimaryStepNo)
                        {
                            processContollers[i].IsProcessCompleted = true;
                        }
                    }
                }
                

                if (i != dtProcess.Rows.Count - 1)
                {
                    processContollers[i].IsHaveSubProcess = true;
                    positionY = positionY + processControllerHeight;
                }
                else
                {
                    processContollers[i].IsHaveSubProcess = false;
                }
                //positionY = positionY + 20;
            }
        }

        private void primaryProcessInfo_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            processContoller_Click(sender, e);
            if (dtClientProcess.Columns.Count > 0)
            {
                DataRow[] dataRows = dtClientProcess.Select("PrimaryStepNo =" + primaryStep.StepNo);
                if (dataRows.Count() > 0)
                {
                    DataTable dataTable = dataRows.CopyToDataTable();
                    gridControl1.DataSource = dataTable;
                }
                else
                {
                    gridControl1.DataSource = null;
                }
            }
        }

        private void processContoller_Click(object sender, EventArgs e)
        {
            try
            {
                getLinkSubStepProcess(sender);

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
                bool isAllSubProcessCompleted = true;
                for (int i = 0; i < dtLinkSubStep.Rows.Count; i++)
                {
                    subStepProcessControllers[i] = new FinancialPlannerClient.Controls.ProcessContoller();
                    subStepProcessControllers[i].lblProcessNo.Text = primaryStep.StepNo + "." + dtLinkSubStep.Rows[i]["StepNo"].ToString();
                    subStepProcessControllers[i].lblProcessNo.Tag = dtLinkSubStep.Rows[i]["StepNo"].ToString();
                    subStepProcessControllers[i].lblTitle.Text = dtLinkSubStep.Rows[i]["Title"].ToString();
                    subStepProcessControllers[i].Visible = true;
                    pnlSubStepProcess.Controls.Add(subStepProcessControllers[i]);
                    subStepProcessControllers[i].Location = new Point(positionX, positionY);
                    subStepProcessControllers[i].lblProcessNo.Click += new System.EventHandler(this.subStepProcessContoller_Click);
                    subStepProcessControllers[i].lblTitle.Click += new System.EventHandler(this.subStepProcessContoller_Click);
                    subStepProcessControllers[i].Click += new System.EventHandler(this.subStepProcessContoller_Click);
                    subStepProcessControllers[i].btnInformation.Click += new System.EventHandler(this.processInfo_Click);
                    subStepProcessControllers[i].btnInformation.Tag = dtLinkSubStep.Rows[i]["StepNo"].ToString();

                    if (dtClientProcess.Columns.Count > 0)
                    {
                        DataRow[] dataRows = dtClientProcess.Select("PrimaryStepNo =" + primaryStep.StepNo + " And LinkSubStepNo =" + dtLinkSubStep.Rows[i]["StepNo"].ToString());
                        if (dataRows.Count() > 0)
                        {
                            if (dataRows[0]["ProcessStatus"].ToString().Equals("C"))
                            {
                                subStepProcessControllers[i].IsProcessCompleted = true;
                            }
                            else
                            {
                                DateTime expectedCompleDate = DateTime.Parse(dataRows[0]["ExpectedCompletionDate"].ToString());
                                if (DateTime.Now.Date > expectedCompleDate && dataRows[0]["ActualCompletionDate"].ToString().Equals(""))
                                {
                                    subStepProcessControllers[i].IsProcessOverDue = true;
                                }
                                else if (DateTime.Now.Date <= expectedCompleDate && dataRows[0]["ActualCompletionDate"].ToString().Equals(""))
                                {
                                    subStepProcessControllers[i].IsInProcess = true;
                                }
                                isAllSubProcessCompleted = false;
                            }
                        }
                        else
                        {
                            isAllSubProcessCompleted = false;
                        }
                    }
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

                if (dtLinkSubStep.Rows.Count == 0)
                {
                    if (dtClientProcess.Columns.Contains("PrimaryStepNo") && dtClientProcess.Columns.Contains("ProcessStatus"))
                    {
                        DataRow[] dataRows = dtClientProcess.Select("PrimaryStepNo = " + primaryStep.StepNo + " and ProcessStatus = 'C'");
                        if (dataRows.Count() == 0)
                        {
                            isAllSubProcessCompleted = false;
                        }
                    }
                }

                ProcessContoller processController = processContollers.First(i => i.lblProcessNo.Text == primaryStep.StepNo.ToString());
                if (isAllSubProcessCompleted && dtClientProcess.Rows.Count > 0)
                {
                    processController.IsProcessCompleted = isAllSubProcessCompleted;
                }
                //else
                //{
                //    processController.IsInProcess = dtLinkSubStep.Rows.Count > 0;
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void getLinkSubStepProcess(object sender)
        {
            int processNo = 0;
            string processTitle = "";

            if (sender.GetType().Name.Equals("ProcessContoller"))
            {
                int.TryParse(((FinancialPlannerClient.Controls.ProcessContoller)sender).lblProcessNo.Text, out processNo);
                processTitle = ((FinancialPlannerClient.Controls.ProcessContoller)sender).lblTitle.Text;
                MessageBox.Show("Process No:" + processNo.ToString() + " and Title = " + processTitle);
            }

            if (sender.GetType().Name.Equals("Label"))
            {
                if (((System.Windows.Forms.Label)sender).Name.Equals("lblTitle"))
                {
                    primaryStep = primarySteps.First(i => i.Title.Equals(((System.Windows.Forms.Label)sender).Text.Trim()));
                    //MessageBox.Show("Process No:" + primaryStep.StepNo + " and Title = " + primaryStep.Title);
                }
                else if (((System.Windows.Forms.Label)sender).Name.Equals("lblProcessNo"))
                {
                    primaryStep = primarySteps.First(i => i.StepNo.ToString().Equals(((System.Windows.Forms.Label)sender).Text.Trim()));
                    //MessageBox.Show("Process No:" + primaryStep.StepNo + " and Title = " + primaryStep.Title);
                }
            }

            if (sender.GetType().Name.Equals("SimpleButton"))
            {
                int.TryParse(((FinancialPlannerClient.Controls.ProcessContoller)((DevExpress.XtraEditors.SimpleButton)sender).Parent.Parent).lblProcessNo.Text, out processNo);
                processTitle = ((FinancialPlannerClient.Controls.ProcessContoller)((DevExpress.XtraEditors.SimpleButton)sender).Parent.Parent).lblTitle.Text;
                primaryStep = primarySteps.First(i => i.StepNo.ToString().Equals(processNo.ToString()));
            }

            ProcessesInfo processesInfo = new ProcessesInfo();
            linkSubSteps = processesInfo.GetLinkSubSteps(primaryStep.Id);
        }

        private void processInfo_Click(object sender, EventArgs e)
        {
            string StepNo = ((DevExpress.XtraEditors.SimpleButton)sender).Tag.ToString().Trim();
            if (dtClientProcess.Columns.Count > 0)
            {
                DataRow[] dataRows = dtClientProcess.Select("LinkSubStepNo =" + StepNo + "and PrimaryStepNo ='" + primaryStep.StepNo + "'");
                if (dataRows.Count() > 0)
                {
                    DataTable dataTable = dataRows.CopyToDataTable();
                    gridControl1.DataSource = dataTable;
                }
                else
                {
                    gridControl1.DataSource = null;
                }
            }
        }

        private void subStepProcessContoller_Click(object sender, EventArgs e)
        {

        }
    }
}
