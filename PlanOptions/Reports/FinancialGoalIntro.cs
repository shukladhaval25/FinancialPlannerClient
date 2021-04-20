﻿using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FinancialPlanner.Common.Model;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class FinancialGoalIntro : DevExpress.XtraReports.UI.XtraReport
    {
        public FinancialGoalIntro(Client client)
        {
            InitializeComponent();
            this.lblClientName.Text = client.Name;
        }

        private void TopMargin_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //this.xrPictureBox2.Image = Image.FromFile("");
        }
    }
}
