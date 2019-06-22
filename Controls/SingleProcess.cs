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
    public partial class SingleProcess : UserControl
    {
        private PlannerProcess plannerProcess = new PlannerProcess();
       
        public PlannerProcess PlannerProcess
        {
            get { return this.plannerProcess; }
            set
            {
                this.plannerProcess = value;
                setUI();
            }
        }

        public void SetStepNo(int count)
        {
            lblStep.Text = string.Format("Step {0}", count);
        }

        private void setUI()
        {
            ImgProcess.Image = Image.FromFile(plannerProcess.ProcessImagePath);
            lblAction.Text = plannerProcess.Action;
            lblStep.Text = string.Format("Step {0}", plannerProcess.StepNo);
        }

        public SingleProcess()
        {
            InitializeComponent();                   
            //setToolTip();
        }

        private void setToolTip()
        {
            DevExpress.Utils.SuperToolTipSetupArgs superToolTipSetupArgs =
               new DevExpress.Utils.SuperToolTipSetupArgs();
            superToolTipSetupArgs.Title.Text = string.Format("{0} - ({1})", lblAction.Text, this.PlannerProcess.StepNo);
            superToolTipSetupArgs.Contents.Text = this.PlannerProcess.Description + System.Environment.NewLine + 
                string.Format("Senior Validation require : {0}" , this.plannerProcess.IsVarificationRequireBySenior ? "Yes" : "No");
            superToolTipSetupArgs.ShowFooterSeparator = true;
            superToolTipSetupArgs.Footer.Text = string.Format("Estimated days to complete {0} day(s).",
                this.PlannerProcess.EstimatedDaysToComplete);
            ImgProcess.SuperTip = new DevExpress.Utils.SuperToolTip();
            ImgProcess.SuperTip.Setup(superToolTipSetupArgs);
        }

        public void Add(PlannerProcess plannerProcess)
        {
            this.PlannerProcess = plannerProcess;
            setToolTip();
        }

        public void Add(string action,string imagePath,int stepno, int estimatedDaysToComplte,bool isDelay)
        {
            this.plannerProcess.Action = action;
            this.plannerProcess.ProcessImagePath = imagePath;
            this.plannerProcess.StepNo = stepno;
            this.plannerProcess.EstimatedDaysToComplete = estimatedDaysToComplte;
            this.plannerProcess.Description = "";
            this.plannerProcess.IsDelay = isDelay;
            this.PlannerProcess = plannerProcess;
        }

        private void ImgCloase_Click(object sender, EventArgs e)
        {
            this.Visible = false;
            this.Dispose(true);
        }

        private void lblStep_Click(object sender, EventArgs e)
        {

        }

        private void ImgProcess_Click(object sender, EventArgs e)
        {
            this.Select(true, true);
            this.BorderStyle = BorderStyle.Fixed3D;
        }
    }
}
