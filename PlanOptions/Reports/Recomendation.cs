using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FinancialPlanner.Common.Model;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class Recomendation : DevExpress.XtraReports.UI.XtraReport
    {
        public Recomendation(Client client,string recomendationNote)
        {
            InitializeComponent();
            this.lblClientName.Text = client.Name;

            //System.Windows.Forms.RichTextBox richTextBox = new System.Windows.Forms.RichTextBox();
            //richTextBox.Font = new System.Drawing.Font("Calibri", 11.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            //richTextBox.SelectedText = recomendationNote;


            //((XRRichText)this.FindControl("lblRecomendation", true)).Rtf = richTextBox.Rtf;

           this.lblRecomendation.Rtf = recomendationNote;
        }

    }
}
