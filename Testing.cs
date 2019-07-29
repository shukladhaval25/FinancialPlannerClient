using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialPlannerClient
{
    public partial class Testing : Form
    {
        const string ADD_BankAccount_API = "Document/Add";
        Controls.ProcessContoller ProcessContoller = new Controls.ProcessContoller();

        public Testing()
        {
            InitializeComponent();
            ProcessContoller.Dock = DockStyle.Fill;
            groupControl1.Controls.Add(ProcessContoller);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Document document = new Document();
            document.Cid = 1;
            document.Pid = 1;
            document.Name = textBox2.Text;
            document.Path = textBox1.Text;
            document.Data = getStringfromFile(document.Path);
            bool result = uploadfile(document);

            PlannerProcess plannerProcess = new PlannerProcess()
            {
                Action = textBox2.Text,
                ProcessImagePath = textBox1.Text,
                IsDelay = false,
                Description = "This is testing purpose",
                EstimatedDaysToComplete = 5,
            };
            this.ProcessContoller.Add(plannerProcess);

        }

        private bool uploadfile(Document doc)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl +"/"+ ADD_BankAccount_API;
                RestAPIExecutor restApiExecutor = new RestAPIExecutor();
                var restResult = restApiExecutor.Execute<Document>(apiurl, doc, "POST");
                return true;
            }
            catch (Exception ex)
            {
                StackTrace st = new StackTrace ();
                StackFrame sf = st.GetFrame (0);
                MethodBase  currentMethodName = sf.GetMethod();
                LogDebug(currentMethodName.Name, ex);
                return false;
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

        private void createFile(Document document)
        {
            byte[] arrBytes = Convert.FromBase64String(document.Data);
            File.WriteAllBytes(@"E:\FP Repo\1.txt", arrBytes);
        }

        private string getStringfromFile(string filePath)
        {
            if (!string.IsNullOrEmpty(filePath))
            {
                FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                byte[] filebytes = new byte[fs.Length];
                fs.Read(filebytes, 0, Convert.ToInt32(fs.Length));
                return Convert.ToBase64String(filebytes,
                                              Base64FormattingOptions.InsertLineBreaks);
            }
            return null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.Multiselect = false;
            openFileDialog1.ShowDialog();           
            textBox1.Text = openFileDialog1.FileName;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
           
            DevExpress.XtraVerticalGrid.Rows.EditorRow ARN = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            ARN.Name = "ARN";
            ARN.Properties.FieldName = "ARN";
            ARN.Properties.Caption = "ARN";

            DevExpress.XtraVerticalGrid.Rows.EditorRow ClientGroup = new DevExpress.XtraVerticalGrid.Rows.EditorRow();
            ClientGroup.Name = "ClientGroup";
            ClientGroup.Properties.FieldName = "ClientGroup";
            ClientGroup.Properties.Caption = "ClientGroup";

            vGridControl1.Rows.AddRange(new DevExpress.XtraVerticalGrid.Rows.BaseRow[]{ ARN,ClientGroup });
           

        }
    }
}
