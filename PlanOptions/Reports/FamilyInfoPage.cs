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
            addAgeColumnToDataTable();
            _ds.Tables.Add(_dtFamilymember);
            _dtFamilymember = ListtoDataTable.ToDataTable(lstFamilyMember);

            this.DataSource = _ds;
            this.DataMember = _ds.Tables[0].TableName;
            
            this.lblName.DataBindings.Add("Text", this.DataSource, "FamilyMember.Name");
            this.lblRelationship.DataBindings.Add("Text", this.DataSource, "FamilyMember.Relationship");
            lblRelationship.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            new DevExpress.XtraReports.UI.XRBinding("Text", this.DataSource,  "FamilyMember.Relationship")});
            this.lblDOB.DataBindings.Add("Text", this.DataSource, "FamilyMember.DOB");
            this.lblAge.DataBindings.Add("Text", this.DataSource, "FamilyMember.Age");
            this.lblOccupation.DataBindings.Add("Text", this.DataSource, "FamilyMember.Occupation");
        }

        private void addAgeColumnToDataTable()
        {
           _dtFamilymember.Columns.Add("Age",typeof(System.Int16));
            foreach(DataRow dr in _dtFamilymember.Rows)
            {
                if (dr["DOB"] != DBNull.Value)
                    dr["Age"] = (DateTime.Now.Year - (DateTime.Parse(dr["DOB"].ToString()).Year)).ToString();                
            }
        }
    }
}
