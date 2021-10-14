using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FinancialPlanner.Common.Model;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class RiskProfiling : DevExpress.XtraReports.UI.XtraReport
    {
        public RiskProfiling(Client client)
        {
            InitializeComponent();
            this.lblClientName.Text = client.Name;

            System.Windows.Forms.RichTextBox richTextBox = new System.Windows.Forms.RichTextBox();
            richTextBox.Font = new System.Drawing.Font("Calibri", 11.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            richTextBox.SelectedText =
                "Risk profiling is a process for finding the optimal level of investment risk for you considering the risk required, risk capacity and risk tolerance, where," + Environment.NewLine +
                "* Risk required is the risk associated with the return required to achieve your goals from the financial resources available," + Environment.NewLine +
                "* Risk Capacity is the level of financial risk that you can afford to take, and " + Environment.NewLine +
                "* Risk Tolerance is the level of risk you are comfortable with.";
          
            ((XRRichText)this.FindControl("xrRichText1", true)).Rtf = richTextBox.Rtf;
        }

    }
}
