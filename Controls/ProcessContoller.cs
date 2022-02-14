using FinancialPlanner.Common.Model.ProcessAction;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace FinancialPlannerClient.Controls
{
    public partial class ProcessContoller : UserControl
    {
        bool _isHaveSubProcess = false;
        bool _isHaveNextProcess = false;
        bool _isInProcess = false;
        bool _isProcessCompleted = false;
        bool _isProcessOverDue = false;
        
        public bool IsProcessOverDue
        {
            get { return _isProcessOverDue; }
            set
            {
                _isProcessOverDue = value;
                setProcessSteps();
            }
        }

        public bool IsInProcess
        {
            get { return _isInProcess; }
            set
            {
                _isInProcess = value;
                _isProcessOverDue = false;
                _isProcessCompleted = false;
                setProcessSteps();
            }
        }

        public bool IsProcessCompleted
        {
            get { return _isProcessCompleted; }
            set
            {
                _isProcessCompleted = value;
                _isInProcess = false;
                _isProcessOverDue = false;
                setProcessSteps();
            }
        }

        public bool IsHaveSubProcess {
            get { return _isHaveSubProcess; }
            set
            {
                _isHaveSubProcess = value;
                setProcessSteps();
            }
        }
        public bool IsHaveNextProcess
        {
            get { return _isHaveNextProcess; }
            set
            {
                _isHaveNextProcess = value;
                setProcessSteps();
            }
        }
        List<SingleProcess> processes = new List<SingleProcess>();
        public ProcessContoller()
        {
            InitializeComponent();
        }

        public List<SingleProcess> GetProcesses()
        {
            return this.processes;
        }

        public void Add(PlannerProcess plannerProcess)
        {
            //SingleProcess singleProcess = new SingleProcess();
            //plannerProcess.StepNo = ProcessFlowStep.Controls.Count + 1;
            //singleProcess.Add(plannerProcess);

            //ProcessFlowStep.Controls.Add(singleProcess);
            //processes.Add(singleProcess);            
        }

        private void setStepNo(PlannerProcess plannerProcess)
        {
            int count = 1;
            foreach (SingleProcess singleProcessObj in processes)
            {
                plannerProcess.StepNo = count;
                count++;
            }
        }

        private void flowLayoutPanelProcessActions_ControlAdded(object sender, ControlEventArgs e)
        {
            //// setStepNo( (PlannerProcess) e);
            ////((PlannerProcess)sender);
            //if (processes.Count > 1)
            //{
            //    ProcessFlowStep.Controls[ProcessFlowStep.Controls.Count - 1].Left =
            //        ProcessFlowStep.Controls[ProcessFlowStep.Controls.Count - 2].Left + 600;

            //}
        }

        private void flowLayoutPanelProcessActions_ControlRemoved(object sender, ControlEventArgs e)
        {
            // int index = ((SingleProcess)e.Control).PlannerProcess.StepNo;
            // processes.RemoveAt(index);

            //// setStepNo(((SingleProcess)e.Control).PlannerProcess);
            // int count = 1;
            // foreach (SingleProcess singleProcess in ProcessFlowStep.Controls)
            // {
            //     singleProcess.SetStepNo(count);
            //     singleProcess.PlannerProcess.StepNo = count;
            //     //setStepNo(singleProcess.PlannerProcess);
            //     count++;
            // }
            //processes.RemoveAt(((SingleProcess) e.Control).inde
        }

        private void ProcessContoller_Load(object sender, EventArgs e)
        {
            //picNextStep.Visible = IsHaveNextProcess;
            //picSubStep.Visible = IsHaveSubProcess;
            //int width = (IsHaveSubProcess) ? 335 : 295;
            //int height = (IsHaveSubProcess) ? 97 : 57;
            //this.Size = new System.Drawing.Size(width, height);  
            setProcessSteps();
        }

        private void setProcessSteps()
        {
            timer1.Stop();
            picNextStep.Visible = _isHaveNextProcess;
            picSubStep.Visible = _isHaveSubProcess;
            int width = (_isHaveNextProcess) ? 335 : 295;
            int height = (_isHaveSubProcess) ? 97 : 57;
            this.Size = new System.Drawing.Size(width, height);
            if (_isInProcess)
            {
                lblTitle.BackColor = System.Drawing.Color.Orange;
                lblTitle.ForeColor = System.Drawing.Color.Black;
            }
            else if (_isProcessCompleted)
            {
                lblTitle.BackColor = System.Drawing.Color.Turquoise;
                //lblTitle.ForeColor = System.Drawing.Color.White;
            }
            else
            {
                //lblTitle.BackColor =System.Drawing.Color.Active;
                lblTitle.ForeColor = System.Drawing.Color.Black;
            }
            if (_isProcessOverDue)
            {
                lblTitle.BackColor = System.Drawing.Color.LightCoral;
                timer1.Start();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_isProcessOverDue)
            {
                if (lblTitle.BackColor.Equals(System.Drawing.Color.LightCoral))
                {
                    lblTitle.BackColor = System.Drawing.Color.Orange;
                }
                else
                {
                    lblTitle.BackColor = System.Drawing.Color.LightCoral;
                }
            }
        }
    }
}
