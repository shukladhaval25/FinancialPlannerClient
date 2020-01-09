using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using FinancialPlanner.Common.Model;
using System.Collections.Generic;

namespace FinancialPlannerClient.Review.Reports
{
    public partial class QuarterlyReivewData : DevExpress.XtraReports.UI.XtraReport
    {
        PersonalInformation personalInformation;
        public QuarterlyReivewData(PersonalInformation personalInformation)
        {
            InitializeComponent();
            this.personalInformation = personalInformation;
            IList<FamilyMember> famailyMembers = getFamilyMembersNameWithClientAndSpouse();

            createColumnForMembers(famailyMembers);
            GenerateDetailsColumnForMembers(famailyMembers);
            fillupQuarterlyReviewData();
        }

        private void fillupQuarterlyReviewData()
        {
            IList<QuarterlyReviewTemplate> quarterlyReviewTemplates  = new QuarterlyReviewTemplateInfo().GetAll(this.personalInformation.Client.ID);
            this.DataSource = quarterlyReviewTemplates;
            this.xrTableCellTypeOfInv.DataBindings.Add("Text", this.DataSource, "InvestmentType");
            if (quarterlyReviewTemplates.Count > 0)
            {
                xrLoanTable.Visible = quarterlyReviewTemplates[0].IsLoanSelected;
            }
            else
            {
                xrLoanTable.Visible = false;
            }
        }

        private void GenerateDetailsColumnForMembers(IList<FamilyMember> familyMembers)
        {
            int count = 1;
            float cellWidth = (900 - 300) / familyMembers.Count;
            foreach (FamilyMember familyMember in familyMembers)
            {
                XRTableCell xRTableCell = new XRTableCell();
                xRTableCell.Name = "family" + count;
                xRTableCell.BackColor = Color.White;
                xRTableCell.WidthF = cellWidth;
                xRTableCell.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
                xrDetailTable.Rows[0].Cells.Add(xRTableCell);
                xrDetailTable.Rows[0].Cells[0].WidthF = 300;
                count++;
            }
            xrDetailTable.Borders = DevExpress.XtraPrinting.BorderSide.All;
        }

        private void createColumnForMembers(IList<FamilyMember> familyMembers)
        {
            int count = 1;
            float cellWidth = (900 - 300) / familyMembers.Count;
            foreach (FamilyMember familyMember in familyMembers)
            {
                XRTableCell xRTableCell = new XRTableCell();
                xRTableCell.Name = "family" + count;
                xRTableCell.Text = familyMember.Name;
                xRTableCell.WidthF = cellWidth;
                xrHeaderTable.Rows[0].Cells.Add(xRTableCell);
                xrHeaderTable.Rows[0].Cells[0].WidthF = 300;
                count++;
            }
        }

        private IList<FamilyMember> getFamilyMembersNameWithClientAndSpouse()
        {
            IList<FamilyMember> familyMembers = new List<FamilyMember>();                
            FamilyMember client = new FamilyMember();
            client.Name = personalInformation.Client.Name;
            familyMembers.Add(client);
            FamilyMember spouse = new FamilyMember();
            spouse.Name = personalInformation.Spouse.Name;
            familyMembers.Add(spouse);
            IList<FamilyMember> familyMembersResult = new PlannerInfo.FamilyMemberInfo().Get(personalInformation.Client.ID);
            foreach(FamilyMember familyMember in familyMembersResult)
            {
                familyMembers.Add(familyMember);
            }
            return familyMembers;
        }
    }
}
