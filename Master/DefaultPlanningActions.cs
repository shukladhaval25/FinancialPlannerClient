using FinancialPlanner.Common;
using FinancialPlanner.Common.Model.ProcessAction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace FinancialPlannerClient.Master
{
    public partial class DefaultPlanningActions : DevExpress.XtraEditors.XtraForm
    {              
        public DefaultPlanningActions()
        {
            InitializeComponent();
        }

        private void btnChangeImage_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtImgActionPath.Text = openFileDialog1.FileName;
                ImgAction.Image = Image.FromFile(openFileDialog1.FileName);
                //_client.ImageData = getStringfromFile(txtImagePath.Text);
                //_client.ImagePath = _client.Name + System.IO.Path.GetExtension(txtImagePath.Text);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                PlannerProcess plannerProcess = getPlannerProcess();
                this.ProcessController.Add(plannerProcess);
                clearFieldValues();
            }
            catch(Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
            }
        }

        private void clearFieldValues()
        {
            txtProcessName.Text = "";
            txtDaysRequireToComplete.Text = "1";
            chkIsDelay.Checked = false;
            chkVerifiedBySenior.Checked = false;
            ImgAction.Image = null;
            txtImgActionPath.Text = "";
            txtDescription.Text = "";
        }

        private PlannerProcess getPlannerProcess()
        {
            PlannerProcess plannerProcess = new PlannerProcess();
            if (!string.IsNullOrEmpty(txtImgActionPath.Text))
            {
                plannerProcess.ImageData = getStringfromFile(txtImgActionPath.Text);
                plannerProcess.ProcessImagePath = txtImgActionPath.Text;
            }
            plannerProcess.Action = txtProcessName.Text;
            plannerProcess.StepNo = this.ProcessController.GetProcesses().Count + 1;
            plannerProcess.EstimatedDaysToComplete = int.Parse(txtDaysRequireToComplete.Text);
            plannerProcess.Description = this.txtDescription.Text;
            plannerProcess.IsDelay = chkIsDelay.Checked;
            plannerProcess.IsVarificationRequireBySenior = chkVerifiedBySenior.Checked;

            return plannerProcess;
        }

        private string getStringfromFile(string filePath)
        {
            try
            {
                if (!string.IsNullOrEmpty(filePath))
                {
                    if (System.IO.File.Exists(filePath))
                    {
                        FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                        byte[] filebytes = new byte[fs.Length];
                        fs.Read(filebytes, 0, Convert.ToInt32(fs.Length));
                        return Convert.ToBase64String(filebytes,
                                                      Base64FormattingOptions.InsertLineBreaks);
                    }
                }
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace();
                StackFrame sf = st.GetFrame(0);
                MethodBase currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
            }
            return null;
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
