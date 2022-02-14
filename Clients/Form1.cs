using FinancialPlanner.Common.DataConversion;
using FinancialPlanner.Common.Planning;
using FinancialPlannerClient.Clients;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace DXApplication1
{
    public partial class NewTask : DevExpress.XtraEditors.XtraForm
    {
        DataTable dtProcess = new DataTable();
        IList<PrimaryStep> primarySteps;
        IList<LinkSubStep> linkSubSteps;
        const int processControllerWidth = 320;
        const int processControllerHeight = 90;
        FinancialPlannerClient.Controls.ProcessContoller[] processContollers;
        FinancialPlannerClient.Controls.ProcessContoller[] subStepProcessControllers;
        DataTable dtProcessInfo;
        public NewTask()
        {
            InitializeComponent();
        }

        private void NewTask_Load(object sender, EventArgs e)
        {
            loadPrimaryStepData();
            loadProcessCompleteInforamtion();
        }

        private void loadProcessCompleteInforamtion()
        {
            dtProcessInfo = new DataTable();
            dtProcessInfo.Columns.Add("Id");
            dtProcessInfo.Columns.Add("StepNo");
            dtProcessInfo.Columns.Add("ProcessAssignTo");
            dtProcessInfo.Columns.Add("ProcessStartDate");
            dtProcessInfo.Columns.Add("ExpectedCompleteDate");
            dtProcessInfo.Columns.Add("ActualCompleteDate");

            DataRow dr = dtProcessInfo.NewRow();
            dr["Id"] = "1";
            dr["StepNo"] = "1";
            dr["ProcessAssignTo"] = "Prakash Luhana";
            dr["ProcessStartDate"] = "05/01/2022";
            dr["ExpectedCompleteDate"] = "15/01/2022";
            dr["ActualCompleteDate"] = "14/01/2022";
            dtProcessInfo.Rows.Add(dr);

            //dr = dtProcessInfo.NewRow();
            //dr["Id"] = "1";
            //dr["StepNo"] = "2";
            //dr["ProcessAssignTo"] = "Prakash Luhana";
            //dr["ProcessStartDate"] = "05/01/2022";
            //dr["ExpectedCompleteDate"] = "15/01/2022";
            //dr["ActualCompleteDate"] = "14/01/2022";
            //dtProcessInfo.Rows.Add(dr);

            //throw new NotImplementedException();
        }

        private void loadPrimaryStepData()
        {
            ProcessesInfo processesInfo = new ProcessesInfo();
            primarySteps = processesInfo.GetPrimarySteps();
            dtProcess = ListtoDataTable.ToDataTable(primarySteps.ToList());
            grdProcessStep.DataSource = dtProcess;

            processContollers = new FinancialPlannerClient.Controls.ProcessContoller[dtProcess.Rows.Count];
            int positionX = 10;
            int positionY = 50;

            for (int i = 0; i < dtProcess.Rows.Count; i++)
            {
                processContollers[i] = new FinancialPlannerClient.Controls.ProcessContoller();
                processContollers[i].lblProcessNo.Text = dtProcess.Rows[i]["StepNo"].ToString();
                processContollers[i].lblTitle.Text  = dtProcess.Rows[i]["Title"].ToString();
                processContollers[i].Visible = true;
                pnlProcessControl.Controls.Add(processContollers[i]);
                processContollers[i].Location = new Point(positionX,positionY);
                processContollers[i].lblProcessNo.Click += new System.EventHandler(this.processContoller_Click);
                processContollers[i].lblTitle.Click += new System.EventHandler(this.processContoller_Click);
                processContollers[i].Click += new System.EventHandler(this.processContoller_Click);
                if (i == 0)
                {
                    processContollers[i].IsProcessCompleted = true;
                }
                else if (i == 1)
                {
                    processContollers[i].IsInProcess = true;
                }
               
                if (i !=  dtProcess.Rows.Count - 1)
                {
                    //processContollers[i].IsHaveNextProcess = true;
                    //positionX = positionX + processControllerWidth;
                    processContollers[i].IsHaveSubProcess = true;
                    positionY = positionY + processControllerHeight;
                }
                else
                {
                    processContollers[i].IsHaveSubProcess = false ;
                }
                //positionY = positionY + 20;
            }
        }

        private void processContoller_Click(object sender, EventArgs e)
        {
            int processNo = 0;
            string processTitle = "";
            PrimaryStep primaryStep = new PrimaryStep();
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
                    MessageBox.Show("Process No:" + primaryStep.StepNo + " and Title = " + primaryStep.Title);
                }
                else if (((System.Windows.Forms.Label)sender).Name.Equals("lblProcessNo"))
                {
                    primaryStep = primarySteps.First(i => i.StepNo.ToString().Equals(((System.Windows.Forms.Label)sender).Text.Trim()));
                    MessageBox.Show("Process No:" + primaryStep.StepNo + " and Title = " + primaryStep.Title);
                }
            }
            ProcessesInfo processesInfo = new ProcessesInfo();
            linkSubSteps = processesInfo.GetLinkSubSteps(primaryStep.Id);
            //linkSubSteps.Add(new LinkSubStep() { Id = 8, StepNo = 8, Title = "Process Title" });
            //linkSubSteps.Add(new LinkSubStep() { Id = 9, StepNo = 9, Title = "Process Title 2" });
            //linkSubSteps.Add(new LinkSubStep() { Id = 10, StepNo = 10, Title = "Process Title 3" });
            //linkSubSteps.Add(new LinkSubStep() { Id = 11, StepNo = 11, Title = "Process Title 4" });
            //linkSubSteps.Add(new LinkSubStep() { Id = 12, StepNo = 12, Title = "Process Title 5" });
            //linkSubSteps.Add(new LinkSubStep() { Id = 13, StepNo = 13, Title = "Process Title 6" });

            DataTable dtLinkSubStep = ListtoDataTable.ToDataTable(linkSubSteps.ToList());
            //grdLinkSubProcessStep.DataSource = dtLinkSubStep;
            if (subStepProcessControllers != null)
            {
                pnlSubStepProcess.Controls.Clear();
                pnlSubStepProcess.Controls.Add(lblSubProcessStepTitle);
            }
            subStepProcessControllers = new FinancialPlannerClient.Controls.ProcessContoller[dtLinkSubStep.Rows.Count];
            lblSubProcessStepTitle.Text = "Sub Process Step" + " (" + primaryStep.Title  +")";
            int positionX = 10;
            int positionY = 50;

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
                if (i == 0 || i == 1)
                    subStepProcessControllers[i].IsProcessCompleted = true;
                if (i == 2)
                {
                    subStepProcessControllers[i].IsProcessOverDue = true;
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

        }

        private void processInfo_Click(object sender, EventArgs e)
        {
            string StepNo = ((DevExpress.XtraEditors.SimpleButton)sender).Tag.ToString().Trim();
            gridControl1.DataSource = dtProcessInfo;
            //throw new NotImplementedException();
        }

        private void subStepProcessContoller_Click(object sender, EventArgs e)
        {

        }
    }
}
