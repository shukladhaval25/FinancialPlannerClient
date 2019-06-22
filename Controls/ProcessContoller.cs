using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FinancialPlanner.Common.Model.ProcessAction;

namespace FinancialPlannerClient.Controls
{
    public partial class ProcessContoller : UserControl
    {
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
            SingleProcess singleProcess = new SingleProcess();
            plannerProcess.StepNo = flowLayoutPanelProcessActions.Controls.Count + 1;
            singleProcess.Add(plannerProcess);

            flowLayoutPanelProcessActions.Controls.Add(singleProcess);
            processes.Add(singleProcess);            
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
            // setStepNo( (PlannerProcess) e);
            //((PlannerProcess)sender);
            if (processes.Count > 1)
            {
                flowLayoutPanelProcessActions.Controls[flowLayoutPanelProcessActions.Controls.Count - 1].Left =
                    flowLayoutPanelProcessActions.Controls[flowLayoutPanelProcessActions.Controls.Count - 2].Left + 600;

            }
        }

        private void flowLayoutPanelProcessActions_ControlRemoved(object sender, ControlEventArgs e)
        {
            int index = ((SingleProcess)e.Control).PlannerProcess.StepNo;
            processes.RemoveAt(index);
            
           // setStepNo(((SingleProcess)e.Control).PlannerProcess);
            int count = 1;
            foreach (SingleProcess singleProcess in flowLayoutPanelProcessActions.Controls)
            {
                singleProcess.SetStepNo(count);
                singleProcess.PlannerProcess.StepNo = count;
                //setStepNo(singleProcess.PlannerProcess);
                count++;
            }
            //processes.RemoveAt(((SingleProcess) e.Control).inde
        }
    }
}
