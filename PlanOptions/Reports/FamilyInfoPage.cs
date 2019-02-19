using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using System.Data;
using FinancialPlannerClient.PlannerInfo;
using FinancialPlanner.Common.Model;
using System.Collections.Generic;
using FinancialPlanner.Common.DataConversion;

namespace FinancialPlannerClient.PlanOptions.Reports
{
    public partial class FamilyInfoPage : DevExpress.XtraReports.UI.XtraReport
    {
        private DataTable _dtFamilymember;
        List<FamilyMember> lstFamilyMember;
        DataSet _ds = new DataSet();
        public FamilyInfoPage(Client client)
        {
            InitializeComponent();
            this.lblClientName.Text = client.Name;
            FamilyMemberInfo familyMemberInfo = new FamilyMemberInfo();
            lstFamilyMember = (List<FamilyMember>)familyMemberInfo.Get(client.ID);
            _dtFamilymember = ListtoDataTable.ToDataTable(lstFamilyMember);
            _ds.Tables.Add(_dtFamilymember);

            this.DataSource = _ds;
            this.DataMember = _ds.Tables[0].TableName;
            _dtFamilymember = ListtoDataTable.ToDataTable(lstFamilyMember);
            this.lblName.DataBindings.Add("Text", null, "FamilyMember.Name");
            //this.lblRelationship.DataBindings.Add("Text", _dtFamilymember, "FamilyMember.Relationship");
            lblRelationship.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", null,  "FamilyMember.Relationship")});
            this.lblDOB.DataBindings.Add("Text", _dtFamilymember, "FamilyMember.DOB");           
        }

        private void PageHeader_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            
        }

        private void lblDOB_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            ///this.lblDOB.DataBindings.Add ("Text", null, "FamilyMember.DOB");                       
            lblAge.Text = (DateTime.Now.Year - (DateTime.Parse(lblDOB.Text).Year)).ToString();
        }
    }
}
