using DevExpress.XtraReports.UI;
using System.Data;
using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using FinancialPlanner.Common.DataConversion;
using System.Drawing;

namespace FinancialPlannerClient.PlanOptions
{
    public partial class FeesInvoiceReportView : DevExpress.XtraReports.UI.XtraReport
    {
        private DataTable dtInvoice;
        //private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        //private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
     
        private TopMarginBand topMarginBand;
        private DetailBand detailBand3;
        private BottomMarginBand bottomMarginBand;
        private ReportHeaderBand ReportHeader;
        private XRPanel xrPanel2;
        private XRPictureBox xrPictureBox1;
        private XRPanel xrPanel1;
        private XRPanel xrPanel3;
        private XRLabel xrLabel7;
        private XRLabel lblDate;
        private XRLabel xrLabel3;
        private XRLabel xrLabel2;
        private XRLabel lblBillNo;
        private XRLabel xrLabel5;
        private XRLabel lblClient;
        private XRLabel xrLabel4;
        private XRLabel xrLabel1;
        private XRLabel lblAdd1;
        private XRLabel lblCompanyTitle;
        private XRTable xrTable1;
        private XRTableRow xrTableRow1;
        private XRTableCell lblNo;
        private XRTableCell lblParticulars;
        private XRTableCell lblAmount;
        private XRTable xrTable2;
        private XRTableRow xrTableRow2;
        private XRTableCell xrTableCell5;
        private XRTableCell xrTableCell7;
        private XRTableCell xrTableCell4;
        private GroupFooterBand GroupFooter1;
        private XRTable xrTable3;
        private XRTableRow xrTableRow3;
        private XRTableCell xrTableCell6;
        private XRTableCell xrTableCell8;
        private XRLabel xrLabel12;
        private XRLabel lblMICRNo;
        private XRLabel xrLabel11;
        private XRLabel lblIFSCCode;
        private XRLabel xrLabel10;
        private XRLabel lblAccountNo;
        private XRLabel xrLabel9;
        private XRLabel lblBankName;
        private XRLabel lblCompanyName;
        private XRLabel xrLabel8;
        private XRLabel lblBankDetailsTitle;
        private XRTableCell xrTableCell9;
        private XRTableRow xrTableRow4;
        private XRTableCell lblAmountInWord;
        private XRTableCell lblTotalAmount;
        private XRTableRow xrTableRow5;
        private XRTableCell xrTableCell13;
        DataSet _ds = new DataSet();
        private FeesInvoiceTransacation transaction;
        private PageFooterBand PageFooter;
        private ReportFooterBand ReportFooter;
        private XRPanel xrPanel4;
        private XRPanel xrPanel5;
        private Client client;

        public FeesInvoiceReportView(FeesInvoiceTransacation transaction,Client client)
        {
            InitializeComponent();
            this.transaction = transaction;
            this.client = client;

            this.lblClient.Text = client.Name;
            this.lblBillNo.Text = transaction.InvoiceNo;
            this.lblDate.Text = transaction.InvoiceDate.ToShortDateString();

            if (transaction.feesInvoiceDetails.Count > 0)
            {
                dtInvoice = new DataTable();
                dtInvoice.Columns.Add("Particulars", typeof(System.String));
                dtInvoice.Columns.Add("Amount", typeof(System.Double));
                foreach(var invoiceDetail in transaction.feesInvoiceDetails)
                {
                    DataRow dr = dtInvoice.NewRow();
                    dr["Particulars"] = invoiceDetail.Particulars;
                    dr["Amount"] = invoiceDetail.Amount;
                    dtInvoice.Rows.Add(dr);
                }
                //dtInvoice = ListtoDataTable.ToDataTable(transaction.feesInvoiceDetails);
                dtInvoice.TableName = "FeesInvoice";
                _ds.Tables.Add(dtInvoice);
                this.DataSource = _ds;
                this.DataMember = _ds.Tables[0].TableName;

                this.lblParticulars.DataBindings.Add("Text", this.DataSource, "FeesInvoice.Particulars");
                this.lblAmount.DataBindings.Add("Text", this.DataSource, "FeesInvoice.Amount");
                this.lblTotalAmount.DataBindings.Add("Text", this.DataSource, "FeesInvoice.Amount");
                int totalOfSumAmount = 0;
                int.TryParse(dtInvoice.Compute("Sum(Amount)", string.Empty).ToString(), out totalOfSumAmount);
                lblAmountInWord.Text = (Converter.NumberToWords(totalOfSumAmount) + " only").ToUpper();

                lblCompanyName.Text = "Ascent Knowledge Academy";
                lblBankName.Text = "HDFC Bank";
                lblAccountNo.Text = "50200029311326";
                lblIFSCCode.Text = "HDFC0000147";
                lblMICRNo.Text = "390240003";
            }

            //this.lblClientName.Text = personalInformation.Client.Name;
            //FamilyMemberInfo familyMemberInfo = new FamilyMemberInfo();
            //lstFamilyMember = (List<FamilyMember>)familyMemberInfo.Get(personalInformation.Client.ID);
            //lstFamilyMember =  lstFamilyMember.FindAll( i => i.IsHuf == false);

            //lstFamilyMember.Insert(0, new FamilyMember() {Name  = personalInformation.Client.Name,Relationship = "Self",DOB = personalInformation.Client.DOB,Occupation = personalInformation.Client.Occupation  });
            //if (!string.IsNullOrEmpty(personalInformation.Spouse.Name))
            //{
            //    lstFamilyMember.Insert(1, new FamilyMember() { Name = personalInformation.Spouse.Name, Relationship = "spouse", DOB = personalInformation.Spouse.DOB, Occupation = personalInformation.Spouse.Occupation 
            //    });
            //}
            //_dtMOMPoints = ListtoDataTable.ToDataTable(transaction.MOMPoints);
            //_dtMOMPoints.TableName = "MOM";
            ////addAgeColumnToDataTable();
            //_ds.Tables.Add(_dtMOMPoints);

            //this.DataSource = _ds;
            //this.DataMember = _ds.Tables[0].TableName;

            //this.lblDate.Text = transaction.MeetingDate.ToShortDateString();
            //this.lblDateValue.Text = transaction.MeetingDate.ToShortDateString();
            //this.lblTypeOfMeeting.Text = transaction.MeetingType;
            ////lblTypeOfMeeting.DataBindings.AddRange(new DevExpress.XtraReports.UI.XRBinding[] {
            //// new DevExpress.XtraReports.UI.XRBinding("Text", this.DataSource,  "FamilyMember.Relationship")});
            //this.lblResponsibility.DataBindings.Add("Text", this.DataSource, "MOM.Responsibility");
            //this.lblPointsDiscussed.DataBindings.Add("Text", this.DataSource, "MOM.DiscussedPoint");
            //this.lblFutureAction.DataBindings.Add("Text", this.DataSource, "FamilyMember.Occupation");
            //this.lblDurationValue.Text = transaction.Duration.ToString();
            //this.lblDuration.Text = transaction.Duration.ToString();
        }


        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FeesInvoiceReportView));
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            this.topMarginBand = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrPanel2 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
            this.detailBand3 = new DevExpress.XtraReports.UI.DetailBand();
            this.xrPanel5 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
            this.lblNo = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblParticulars = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblAmount = new DevExpress.XtraReports.UI.XRTableCell();
            this.bottomMarginBand = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.xrPanel3 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrTable2 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell7 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblDate = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblBillNo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblClient = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrPanel1 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblAdd1 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblCompanyTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.xrPanel4 = new DevExpress.XtraReports.UI.XRPanel();
            this.xrTable3 = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow3 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell6 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableCell8 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblMICRNo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel11 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblIFSCCode = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblAccountNo = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel9 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblBankName = new DevExpress.XtraReports.UI.XRLabel();
            this.lblCompanyName = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblBankDetailsTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.xrTableCell9 = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow4 = new DevExpress.XtraReports.UI.XRTableRow();
            this.lblAmountInWord = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblTotalAmount = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.xrTableCell13 = new DevExpress.XtraReports.UI.XRTableCell();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // topMarginBand
            // 
            this.topMarginBand.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPanel2});
            this.topMarginBand.Dpi = 100F;
            this.topMarginBand.HeightF = 105.625F;
            this.topMarginBand.Name = "topMarginBand";
            // 
            // xrPanel2
            // 
            this.xrPanel2.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.xrPanel2.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrPanel2.BorderColor = System.Drawing.Color.Black;
            this.xrPanel2.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrPanel2.BorderWidth = 1F;
            this.xrPanel2.CanGrow = false;
            this.xrPanel2.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox1});
            this.xrPanel2.Dpi = 100F;
            this.xrPanel2.LocationFloat = new DevExpress.Utils.PointFloat(0F, 10.00001F);
            this.xrPanel2.Name = "xrPanel2";
            this.xrPanel2.SizeF = new System.Drawing.SizeF(749F, 95.62498F);
            this.xrPanel2.StylePriority.UseBorderColor = false;
            this.xrPanel2.StylePriority.UseBorders = false;
            this.xrPanel2.StylePriority.UseBorderWidth = false;
            // 
            // xrPictureBox1
            // 
            this.xrPictureBox1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrPictureBox1.Dpi = 100F;
            this.xrPictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("xrPictureBox1.Image")));
            this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(497.5417F, 7.416662F);
            this.xrPictureBox1.Name = "xrPictureBox1";
            this.xrPictureBox1.SizeF = new System.Drawing.SizeF(241.4583F, 77.12502F);
            this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
            this.xrPictureBox1.StylePriority.UseBorders = false;
            // 
            // detailBand3
            // 
            this.detailBand3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPanel5});
            this.detailBand3.Dpi = 100F;
            this.detailBand3.HeightF = 65.20811F;
            this.detailBand3.Name = "detailBand3";
            // 
            // xrPanel5
            // 
            this.xrPanel5.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.xrPanel5.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrPanel5.BorderColor = System.Drawing.Color.Black;
            this.xrPanel5.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrPanel5.BorderWidth = 1F;
            this.xrPanel5.CanGrow = false;
            this.xrPanel5.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable1});
            this.xrPanel5.Dpi = 100F;
            this.xrPanel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPanel5.Name = "xrPanel5";
            this.xrPanel5.SizeF = new System.Drawing.SizeF(749F, 65.20811F);
            this.xrPanel5.StylePriority.UseBorderColor = false;
            this.xrPanel5.StylePriority.UseBorders = false;
            this.xrPanel5.StylePriority.UseBorderWidth = false;
            // 
            // xrTable1
            // 
            this.xrTable1.BackColor = System.Drawing.Color.White;
            this.xrTable1.BorderColor = System.Drawing.Color.Black;
            this.xrTable1.Dpi = 100F;
            this.xrTable1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTable1.ForeColor = System.Drawing.Color.White;
            this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(10.0001F, 0F);
            this.xrTable1.Name = "xrTable1";
            this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
            this.xrTable1.SizeF = new System.Drawing.SizeF(729F, 65.20811F);
            this.xrTable1.StylePriority.UseBackColor = false;
            this.xrTable1.StylePriority.UseBorderColor = false;
            this.xrTable1.StylePriority.UseFont = false;
            this.xrTable1.StylePriority.UseForeColor = false;
            this.xrTable1.StylePriority.UseTextAlignment = false;
            this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow1
            // 
            this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.lblNo,
            this.lblParticulars,
            this.lblAmount});
            this.xrTableRow1.Dpi = 100F;
            this.xrTableRow1.Name = "xrTableRow1";
            this.xrTableRow1.Weight = 1D;
            // 
            // lblNo
            // 
            this.lblNo.BackColor = System.Drawing.Color.White;
            this.lblNo.BorderColor = System.Drawing.Color.Black;
            this.lblNo.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.lblNo.Dpi = 100F;
            this.lblNo.ForeColor = System.Drawing.Color.Black;
            this.lblNo.Name = "lblNo";
            this.lblNo.StylePriority.UseBackColor = false;
            this.lblNo.StylePriority.UseBorderColor = false;
            this.lblNo.StylePriority.UseBorders = false;
            this.lblNo.StylePriority.UseForeColor = false;
            xrSummary1.FormatString = "{0}";
            xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.RecordNumber;
            xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.lblNo.Summary = xrSummary1;
            this.lblNo.Text = "No.";
            this.lblNo.Weight = 0.7709697527304995D;
            // 
            // lblParticulars
            // 
            this.lblParticulars.BackColor = System.Drawing.Color.White;
            this.lblParticulars.BorderColor = System.Drawing.Color.Black;
            this.lblParticulars.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.lblParticulars.Dpi = 100F;
            this.lblParticulars.ForeColor = System.Drawing.Color.Black;
            this.lblParticulars.Name = "lblParticulars";
            this.lblParticulars.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.lblParticulars.StylePriority.UseBackColor = false;
            this.lblParticulars.StylePriority.UseBorderColor = false;
            this.lblParticulars.StylePriority.UseBorders = false;
            this.lblParticulars.StylePriority.UseForeColor = false;
            this.lblParticulars.StylePriority.UsePadding = false;
            this.lblParticulars.StylePriority.UseTextAlignment = false;
            this.lblParticulars.Text = "Particulars";
            this.lblParticulars.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.lblParticulars.Weight = 5.6440530890563521D;
            // 
            // lblAmount
            // 
            this.lblAmount.BackColor = System.Drawing.Color.White;
            this.lblAmount.BorderColor = System.Drawing.Color.Black;
            this.lblAmount.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right)));
            this.lblAmount.Dpi = 100F;
            this.lblAmount.ForeColor = System.Drawing.Color.Black;
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.StylePriority.UseBackColor = false;
            this.lblAmount.StylePriority.UseBorderColor = false;
            this.lblAmount.StylePriority.UseBorders = false;
            this.lblAmount.StylePriority.UseForeColor = false;
            this.lblAmount.Text = "Amount";
            this.lblAmount.Weight = 2.1233746361281147D;
            this.lblAmount.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.lblAmount_BeforePrint);
            // 
            // bottomMarginBand
            // 
            this.bottomMarginBand.Dpi = 100F;
            this.bottomMarginBand.HeightF = 0F;
            this.bottomMarginBand.Name = "bottomMarginBand";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPanel3,
            this.xrPanel1});
            this.ReportHeader.Dpi = 100F;
            this.ReportHeader.HeightF = 289.1664F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // xrPanel3
            // 
            this.xrPanel3.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.xrPanel3.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrPanel3.BorderColor = System.Drawing.Color.Black;
            this.xrPanel3.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right)));
            this.xrPanel3.BorderWidth = 1F;
            this.xrPanel3.CanGrow = false;
            this.xrPanel3.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable2,
            this.xrLabel7,
            this.lblDate,
            this.xrLabel3,
            this.xrLabel2,
            this.lblBillNo,
            this.xrLabel5,
            this.lblClient,
            this.xrLabel4});
            this.xrPanel3.Dpi = 100F;
            this.xrPanel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 126.6247F);
            this.xrPanel3.Name = "xrPanel3";
            this.xrPanel3.SizeF = new System.Drawing.SizeF(749F, 162.5417F);
            this.xrPanel3.StylePriority.UseBorderColor = false;
            this.xrPanel3.StylePriority.UseBorders = false;
            this.xrPanel3.StylePriority.UseBorderWidth = false;
            // 
            // xrTable2
            // 
            this.xrTable2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(117)))), ((int)(((byte)(181)))));
            this.xrTable2.BorderColor = System.Drawing.Color.Black;
            this.xrTable2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable2.Dpi = 100F;
            this.xrTable2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTable2.ForeColor = System.Drawing.Color.White;
            this.xrTable2.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 99.37506F);
            this.xrTable2.Name = "xrTable2";
            this.xrTable2.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2});
            this.xrTable2.SizeF = new System.Drawing.SizeF(729F, 62.08311F);
            this.xrTable2.StylePriority.UseBackColor = false;
            this.xrTable2.StylePriority.UseBorderColor = false;
            this.xrTable2.StylePriority.UseBorders = false;
            this.xrTable2.StylePriority.UseFont = false;
            this.xrTable2.StylePriority.UseForeColor = false;
            this.xrTable2.StylePriority.UseTextAlignment = false;
            this.xrTable2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell5,
            this.xrTableCell7,
            this.xrTableCell4});
            this.xrTableRow2.Dpi = 100F;
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // xrTableCell5
            // 
            this.xrTableCell5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(117)))), ((int)(((byte)(181)))));
            this.xrTableCell5.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell5.Dpi = 100F;
            this.xrTableCell5.Name = "xrTableCell5";
            this.xrTableCell5.StylePriority.UseBackColor = false;
            this.xrTableCell5.StylePriority.UseBorderColor = false;
            this.xrTableCell5.Text = "No.";
            this.xrTableCell5.Weight = 0.7709697527304995D;
            // 
            // xrTableCell7
            // 
            this.xrTableCell7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(117)))), ((int)(((byte)(181)))));
            this.xrTableCell7.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell7.Dpi = 100F;
            this.xrTableCell7.Name = "xrTableCell7";
            this.xrTableCell7.StylePriority.UseBackColor = false;
            this.xrTableCell7.StylePriority.UseBorderColor = false;
            this.xrTableCell7.StylePriority.UseTextAlignment = false;
            this.xrTableCell7.Text = "Particulars";
            this.xrTableCell7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrTableCell7.Weight = 5.6440530890563521D;
            // 
            // xrTableCell4
            // 
            this.xrTableCell4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(117)))), ((int)(((byte)(181)))));
            this.xrTableCell4.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell4.Dpi = 100F;
            this.xrTableCell4.Name = "xrTableCell4";
            this.xrTableCell4.StylePriority.UseBackColor = false;
            this.xrTableCell4.StylePriority.UseBorderColor = false;
            this.xrTableCell4.Text = "Amount";
            this.xrTableCell4.Weight = 2.1233746361281147D;
            // 
            // xrLabel7
            // 
            this.xrLabel7.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel7.Dpi = 100F;
            this.xrLabel7.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel7.ForeColor = System.Drawing.Color.Black;
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(557.7084F, 62.25004F);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(65.87494F, 26.12502F);
            this.xrLabel7.StylePriority.UseBorders = false;
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseForeColor = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "Date:";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lblDate
            // 
            this.lblDate.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lblDate.Dpi = 100F;
            this.lblDate.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDate.ForeColor = System.Drawing.Color.Black;
            this.lblDate.LocationFloat = new DevExpress.Utils.PointFloat(623.5834F, 62.25004F);
            this.lblDate.Multiline = true;
            this.lblDate.Name = "lblDate";
            this.lblDate.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDate.SizeF = new System.Drawing.SizeF(125.4167F, 26.12502F);
            this.lblDate.StylePriority.UseBorders = false;
            this.lblDate.StylePriority.UseFont = false;
            this.lblDate.StylePriority.UseForeColor = false;
            this.lblDate.StylePriority.UseTextAlignment = false;
            this.lblDate.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel3
            // 
            this.xrLabel3.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.ForeColor = System.Drawing.Color.Black;
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(60.87497F, 62.25004F);
            this.xrLabel3.Multiline = true;
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(466.6667F, 26.12502F);
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseForeColor = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel2
            // 
            this.xrLabel2.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.ForeColor = System.Drawing.Color.Black;
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(60.87497F, 36.12502F);
            this.xrLabel2.Multiline = true;
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(466.6667F, 26.12502F);
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseForeColor = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lblBillNo
            // 
            this.lblBillNo.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lblBillNo.Dpi = 100F;
            this.lblBillNo.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBillNo.ForeColor = System.Drawing.Color.Black;
            this.lblBillNo.LocationFloat = new DevExpress.Utils.PointFloat(623.5833F, 10.00001F);
            this.lblBillNo.Multiline = true;
            this.lblBillNo.Name = "lblBillNo";
            this.lblBillNo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblBillNo.SizeF = new System.Drawing.SizeF(125.4167F, 26.12502F);
            this.lblBillNo.StylePriority.UseBorders = false;
            this.lblBillNo.StylePriority.UseFont = false;
            this.lblBillNo.StylePriority.UseForeColor = false;
            this.lblBillNo.StylePriority.UseTextAlignment = false;
            this.lblBillNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel5
            // 
            this.xrLabel5.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel5.ForeColor = System.Drawing.Color.Black;
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(557.7084F, 10.00001F);
            this.xrLabel5.Multiline = true;
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(65.87494F, 26.12502F);
            this.xrLabel5.StylePriority.UseBorders = false;
            this.xrLabel5.StylePriority.UseFont = false;
            this.xrLabel5.StylePriority.UseForeColor = false;
            this.xrLabel5.StylePriority.UseTextAlignment = false;
            this.xrLabel5.Text = "Bill No:";
            this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lblClient
            // 
            this.lblClient.Borders = DevExpress.XtraPrinting.BorderSide.Bottom;
            this.lblClient.Dpi = 100F;
            this.lblClient.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClient.ForeColor = System.Drawing.Color.Black;
            this.lblClient.LocationFloat = new DevExpress.Utils.PointFloat(60.87499F, 10.00001F);
            this.lblClient.Multiline = true;
            this.lblClient.Name = "lblClient";
            this.lblClient.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblClient.SizeF = new System.Drawing.SizeF(466.6667F, 26.12502F);
            this.lblClient.StylePriority.UseBorders = false;
            this.lblClient.StylePriority.UseFont = false;
            this.lblClient.StylePriority.UseForeColor = false;
            this.lblClient.StylePriority.UseTextAlignment = false;
            this.lblClient.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel4
            // 
            this.xrLabel4.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.ForeColor = System.Drawing.Color.Black;
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(18.95833F, 10.00001F);
            this.xrLabel4.Multiline = true;
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(41.91666F, 26.12502F);
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseForeColor = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.Text = "M/S";
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrPanel1
            // 
            this.xrPanel1.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.xrPanel1.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrPanel1.BorderColor = System.Drawing.Color.Black;
            this.xrPanel1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrPanel1.BorderWidth = 1F;
            this.xrPanel1.CanGrow = false;
            this.xrPanel1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1,
            this.lblAdd1,
            this.lblCompanyTitle});
            this.xrPanel1.Dpi = 100F;
            this.xrPanel1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrPanel1.Name = "xrPanel1";
            this.xrPanel1.SizeF = new System.Drawing.SizeF(749F, 126.6247F);
            this.xrPanel1.StylePriority.UseBorderColor = false;
            this.xrPanel1.StylePriority.UseBorders = false;
            this.xrPanel1.StylePriority.UseBorderWidth = false;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.ForeColor = System.Drawing.Color.Black;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(18.95828F, 83.08331F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(720.0417F, 36.54165F);
            this.xrLabel1.StylePriority.UseBorders = false;
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseForeColor = false;
            this.xrLabel1.StylePriority.UseTextAlignment = false;
            this.xrLabel1.Text = "Mob. : 9512538707/9512538382";
            this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lblAdd1
            // 
            this.lblAdd1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblAdd1.Dpi = 100F;
            this.lblAdd1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdd1.ForeColor = System.Drawing.Color.Black;
            this.lblAdd1.LocationFloat = new DevExpress.Utils.PointFloat(18.95833F, 46.54166F);
            this.lblAdd1.Multiline = true;
            this.lblAdd1.Name = "lblAdd1";
            this.lblAdd1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblAdd1.SizeF = new System.Drawing.SizeF(720.0417F, 36.54165F);
            this.lblAdd1.StylePriority.UseBorders = false;
            this.lblAdd1.StylePriority.UseFont = false;
            this.lblAdd1.StylePriority.UseForeColor = false;
            this.lblAdd1.StylePriority.UseTextAlignment = false;
            this.lblAdd1.Text = "315 -316,Notus IT Park,Sarabhai Campus,Genda Circle, Vadodara, Gujarat - 390023";
            this.lblAdd1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // lblCompanyTitle
            // 
            this.lblCompanyTitle.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblCompanyTitle.Dpi = 100F;
            this.lblCompanyTitle.Font = new System.Drawing.Font("Calibri", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(117)))), ((int)(((byte)(181)))));
            this.lblCompanyTitle.LocationFloat = new DevExpress.Utils.PointFloat(18.95833F, 10.00001F);
            this.lblCompanyTitle.Multiline = true;
            this.lblCompanyTitle.Name = "lblCompanyTitle";
            this.lblCompanyTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblCompanyTitle.SizeF = new System.Drawing.SizeF(720.0417F, 36.54165F);
            this.lblCompanyTitle.StylePriority.UseBorders = false;
            this.lblCompanyTitle.StylePriority.UseFont = false;
            this.lblCompanyTitle.StylePriority.UseForeColor = false;
            this.lblCompanyTitle.StylePriority.UseTextAlignment = false;
            this.lblCompanyTitle.Text = "Ascent Knowledge Academy";
            this.lblCompanyTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPanel4});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 409.9581F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // xrPanel4
            // 
            this.xrPanel4.AnchorHorizontal = ((DevExpress.XtraReports.UI.HorizontalAnchorStyles)((DevExpress.XtraReports.UI.HorizontalAnchorStyles.Left | DevExpress.XtraReports.UI.HorizontalAnchorStyles.Right)));
            this.xrPanel4.AnchorVertical = ((DevExpress.XtraReports.UI.VerticalAnchorStyles)((DevExpress.XtraReports.UI.VerticalAnchorStyles.Top | DevExpress.XtraReports.UI.VerticalAnchorStyles.Bottom)));
            this.xrPanel4.BorderColor = System.Drawing.Color.Black;
            this.xrPanel4.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrPanel4.BorderWidth = 1F;
            this.xrPanel4.CanGrow = false;
            this.xrPanel4.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTable3});
            this.xrPanel4.Dpi = 100F;
            this.xrPanel4.LocationFloat = new DevExpress.Utils.PointFloat(4.768372E-05F, 0F);
            this.xrPanel4.Name = "xrPanel4";
            this.xrPanel4.SizeF = new System.Drawing.SizeF(749F, 399.9581F);
            this.xrPanel4.StylePriority.UseBorderColor = false;
            this.xrPanel4.StylePriority.UseBorders = false;
            this.xrPanel4.StylePriority.UseBorderWidth = false;
            // 
            // xrTable3
            // 
            this.xrTable3.BackColor = System.Drawing.Color.White;
            this.xrTable3.BorderColor = System.Drawing.Color.Black;
            this.xrTable3.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTable3.Dpi = 100F;
            this.xrTable3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTable3.ForeColor = System.Drawing.Color.White;
            this.xrTable3.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 0F);
            this.xrTable3.Name = "xrTable3";
            this.xrTable3.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow3,
            this.xrTableRow4,
            this.xrTableRow5});
            this.xrTable3.SizeF = new System.Drawing.SizeF(729.0001F, 330.2078F);
            this.xrTable3.StylePriority.UseBackColor = false;
            this.xrTable3.StylePriority.UseBorderColor = false;
            this.xrTable3.StylePriority.UseBorders = false;
            this.xrTable3.StylePriority.UseFont = false;
            this.xrTable3.StylePriority.UseForeColor = false;
            this.xrTable3.StylePriority.UseTextAlignment = false;
            this.xrTable3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrTableRow3
            // 
            this.xrTableRow3.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell6,
            this.xrTableCell8,
            this.xrTableCell9});
            this.xrTableRow3.Dpi = 100F;
            this.xrTableRow3.Name = "xrTableRow3";
            this.xrTableRow3.Weight = 1D;
            // 
            // xrTableCell6
            // 
            this.xrTableCell6.BackColor = System.Drawing.Color.White;
            this.xrTableCell6.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell6.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell6.Dpi = 100F;
            this.xrTableCell6.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell6.Name = "xrTableCell6";
            this.xrTableCell6.StylePriority.UseBackColor = false;
            this.xrTableCell6.StylePriority.UseBorderColor = false;
            this.xrTableCell6.StylePriority.UseBorders = false;
            this.xrTableCell6.StylePriority.UseForeColor = false;
            this.xrTableCell6.Weight = 0.7709697527304995D;
            // 
            // xrTableCell8
            // 
            this.xrTableCell8.BackColor = System.Drawing.Color.White;
            this.xrTableCell8.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell8.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell8.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel12,
            this.lblMICRNo,
            this.xrLabel11,
            this.lblIFSCCode,
            this.xrLabel10,
            this.lblAccountNo,
            this.xrLabel9,
            this.lblBankName,
            this.lblCompanyName,
            this.xrLabel8,
            this.lblBankDetailsTitle});
            this.xrTableCell8.Dpi = 100F;
            this.xrTableCell8.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell8.Name = "xrTableCell8";
            this.xrTableCell8.StylePriority.UseBackColor = false;
            this.xrTableCell8.StylePriority.UseBorderColor = false;
            this.xrTableCell8.StylePriority.UseBorders = false;
            this.xrTableCell8.StylePriority.UseForeColor = false;
            this.xrTableCell8.StylePriority.UseTextAlignment = false;
            this.xrTableCell8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.xrTableCell8.Weight = 5.6440530890563521D;
            // 
            // xrLabel12
            // 
            this.xrLabel12.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel12.Dpi = 100F;
            this.xrLabel12.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel12.ForeColor = System.Drawing.Color.Black;
            this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(7.608509F, 218.4583F);
            this.xrLabel12.Multiline = true;
            this.xrLabel12.Name = "xrLabel12";
            this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrLabel12.SizeF = new System.Drawing.SizeF(117.7085F, 26.12501F);
            this.xrLabel12.StylePriority.UseBorders = false;
            this.xrLabel12.StylePriority.UseFont = false;
            this.xrLabel12.StylePriority.UseForeColor = false;
            this.xrLabel12.StylePriority.UsePadding = false;
            this.xrLabel12.StylePriority.UseTextAlignment = false;
            this.xrLabel12.Text = "MICR No:";
            this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lblMICRNo
            // 
            this.lblMICRNo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblMICRNo.Dpi = 100F;
            this.lblMICRNo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMICRNo.ForeColor = System.Drawing.Color.Black;
            this.lblMICRNo.LocationFloat = new DevExpress.Utils.PointFloat(125.317F, 218.4583F);
            this.lblMICRNo.Multiline = true;
            this.lblMICRNo.Name = "lblMICRNo";
            this.lblMICRNo.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.lblMICRNo.SizeF = new System.Drawing.SizeF(346.5667F, 26.12501F);
            this.lblMICRNo.StylePriority.UseBorders = false;
            this.lblMICRNo.StylePriority.UseFont = false;
            this.lblMICRNo.StylePriority.UseForeColor = false;
            this.lblMICRNo.StylePriority.UsePadding = false;
            this.lblMICRNo.StylePriority.UseTextAlignment = false;
            this.lblMICRNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel11
            // 
            this.xrLabel11.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel11.Dpi = 100F;
            this.xrLabel11.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel11.ForeColor = System.Drawing.Color.Black;
            this.xrLabel11.LocationFloat = new DevExpress.Utils.PointFloat(7.608509F, 192.3333F);
            this.xrLabel11.Multiline = true;
            this.xrLabel11.Name = "xrLabel11";
            this.xrLabel11.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrLabel11.SizeF = new System.Drawing.SizeF(117.7085F, 26.12501F);
            this.xrLabel11.StylePriority.UseBorders = false;
            this.xrLabel11.StylePriority.UseFont = false;
            this.xrLabel11.StylePriority.UseForeColor = false;
            this.xrLabel11.StylePriority.UsePadding = false;
            this.xrLabel11.StylePriority.UseTextAlignment = false;
            this.xrLabel11.Text = "IFSC Code:";
            this.xrLabel11.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lblIFSCCode
            // 
            this.lblIFSCCode.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblIFSCCode.Dpi = 100F;
            this.lblIFSCCode.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblIFSCCode.ForeColor = System.Drawing.Color.Black;
            this.lblIFSCCode.LocationFloat = new DevExpress.Utils.PointFloat(125.317F, 192.3333F);
            this.lblIFSCCode.Multiline = true;
            this.lblIFSCCode.Name = "lblIFSCCode";
            this.lblIFSCCode.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.lblIFSCCode.SizeF = new System.Drawing.SizeF(346.5667F, 26.12501F);
            this.lblIFSCCode.StylePriority.UseBorders = false;
            this.lblIFSCCode.StylePriority.UseFont = false;
            this.lblIFSCCode.StylePriority.UseForeColor = false;
            this.lblIFSCCode.StylePriority.UsePadding = false;
            this.lblIFSCCode.StylePriority.UseTextAlignment = false;
            this.lblIFSCCode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel10
            // 
            this.xrLabel10.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel10.Dpi = 100F;
            this.xrLabel10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel10.ForeColor = System.Drawing.Color.Black;
            this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(7.608509F, 166.2083F);
            this.xrLabel10.Multiline = true;
            this.xrLabel10.Name = "xrLabel10";
            this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrLabel10.SizeF = new System.Drawing.SizeF(117.7085F, 26.12501F);
            this.xrLabel10.StylePriority.UseBorders = false;
            this.xrLabel10.StylePriority.UseFont = false;
            this.xrLabel10.StylePriority.UseForeColor = false;
            this.xrLabel10.StylePriority.UsePadding = false;
            this.xrLabel10.StylePriority.UseTextAlignment = false;
            this.xrLabel10.Text = "Account No:";
            this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lblAccountNo
            // 
            this.lblAccountNo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblAccountNo.Dpi = 100F;
            this.lblAccountNo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAccountNo.ForeColor = System.Drawing.Color.Black;
            this.lblAccountNo.LocationFloat = new DevExpress.Utils.PointFloat(125.317F, 166.2083F);
            this.lblAccountNo.Multiline = true;
            this.lblAccountNo.Name = "lblAccountNo";
            this.lblAccountNo.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.lblAccountNo.SizeF = new System.Drawing.SizeF(346.5667F, 26.12501F);
            this.lblAccountNo.StylePriority.UseBorders = false;
            this.lblAccountNo.StylePriority.UseFont = false;
            this.lblAccountNo.StylePriority.UseForeColor = false;
            this.lblAccountNo.StylePriority.UsePadding = false;
            this.lblAccountNo.StylePriority.UseTextAlignment = false;
            this.lblAccountNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel9
            // 
            this.xrLabel9.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel9.Dpi = 100F;
            this.xrLabel9.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel9.ForeColor = System.Drawing.Color.Black;
            this.xrLabel9.LocationFloat = new DevExpress.Utils.PointFloat(7.608509F, 140.0832F);
            this.xrLabel9.Multiline = true;
            this.xrLabel9.Name = "xrLabel9";
            this.xrLabel9.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrLabel9.SizeF = new System.Drawing.SizeF(117.7085F, 26.12501F);
            this.xrLabel9.StylePriority.UseBorders = false;
            this.xrLabel9.StylePriority.UseFont = false;
            this.xrLabel9.StylePriority.UseForeColor = false;
            this.xrLabel9.StylePriority.UsePadding = false;
            this.xrLabel9.StylePriority.UseTextAlignment = false;
            this.xrLabel9.Text = "Bank Name:";
            this.xrLabel9.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lblBankName
            // 
            this.lblBankName.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblBankName.Dpi = 100F;
            this.lblBankName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankName.ForeColor = System.Drawing.Color.Black;
            this.lblBankName.LocationFloat = new DevExpress.Utils.PointFloat(125.317F, 140.0832F);
            this.lblBankName.Multiline = true;
            this.lblBankName.Name = "lblBankName";
            this.lblBankName.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.lblBankName.SizeF = new System.Drawing.SizeF(346.5667F, 26.12501F);
            this.lblBankName.StylePriority.UseBorders = false;
            this.lblBankName.StylePriority.UseFont = false;
            this.lblBankName.StylePriority.UseForeColor = false;
            this.lblBankName.StylePriority.UsePadding = false;
            this.lblBankName.StylePriority.UseTextAlignment = false;
            this.lblBankName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblCompanyName.Dpi = 100F;
            this.lblCompanyName.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCompanyName.ForeColor = System.Drawing.Color.Black;
            this.lblCompanyName.LocationFloat = new DevExpress.Utils.PointFloat(125.317F, 113.9582F);
            this.lblCompanyName.Multiline = true;
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.lblCompanyName.SizeF = new System.Drawing.SizeF(346.5667F, 26.12502F);
            this.lblCompanyName.StylePriority.UseBorders = false;
            this.lblCompanyName.StylePriority.UseFont = false;
            this.lblCompanyName.StylePriority.UseForeColor = false;
            this.lblCompanyName.StylePriority.UsePadding = false;
            this.lblCompanyName.StylePriority.UseTextAlignment = false;
            this.lblCompanyName.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel8
            // 
            this.xrLabel8.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrLabel8.Dpi = 100F;
            this.xrLabel8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel8.ForeColor = System.Drawing.Color.Black;
            this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(7.608509F, 113.9582F);
            this.xrLabel8.Multiline = true;
            this.xrLabel8.Name = "xrLabel8";
            this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
            this.xrLabel8.SizeF = new System.Drawing.SizeF(117.7085F, 26.12502F);
            this.xrLabel8.StylePriority.UseBorders = false;
            this.xrLabel8.StylePriority.UseFont = false;
            this.xrLabel8.StylePriority.UseForeColor = false;
            this.xrLabel8.StylePriority.UsePadding = false;
            this.xrLabel8.StylePriority.UseTextAlignment = false;
            this.xrLabel8.Text = "Name:";
            this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lblBankDetailsTitle
            // 
            this.lblBankDetailsTitle.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblBankDetailsTitle.Dpi = 100F;
            this.lblBankDetailsTitle.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblBankDetailsTitle.ForeColor = System.Drawing.Color.Black;
            this.lblBankDetailsTitle.LocationFloat = new DevExpress.Utils.PointFloat(5.217028F, 76.77072F);
            this.lblBankDetailsTitle.Multiline = true;
            this.lblBankDetailsTitle.Name = "lblBankDetailsTitle";
            this.lblBankDetailsTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblBankDetailsTitle.SizeF = new System.Drawing.SizeF(466.6667F, 26.12502F);
            this.lblBankDetailsTitle.StylePriority.UseBorders = false;
            this.lblBankDetailsTitle.StylePriority.UseFont = false;
            this.lblBankDetailsTitle.StylePriority.UseForeColor = false;
            this.lblBankDetailsTitle.StylePriority.UseTextAlignment = false;
            this.lblBankDetailsTitle.Text = "Bank Details:";
            this.lblBankDetailsTitle.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrTableCell9
            // 
            this.xrTableCell9.BackColor = System.Drawing.Color.White;
            this.xrTableCell9.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell9.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell9.Dpi = 100F;
            this.xrTableCell9.ForeColor = System.Drawing.Color.Black;
            this.xrTableCell9.Name = "xrTableCell9";
            this.xrTableCell9.StylePriority.UseBackColor = false;
            this.xrTableCell9.StylePriority.UseBorderColor = false;
            this.xrTableCell9.StylePriority.UseBorders = false;
            this.xrTableCell9.StylePriority.UseForeColor = false;
            this.xrTableCell9.Weight = 2.1233746361281147D;
            // 
            // xrTableRow4
            // 
            this.xrTableRow4.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.lblAmountInWord,
            this.lblTotalAmount});
            this.xrTableRow4.Dpi = 100F;
            this.xrTableRow4.Name = "xrTableRow4";
            this.xrTableRow4.Weight = 0.14693810659897055D;
            // 
            // lblAmountInWord
            // 
            this.lblAmountInWord.BackColor = System.Drawing.Color.White;
            this.lblAmountInWord.BorderColor = System.Drawing.Color.Black;
            this.lblAmountInWord.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lblAmountInWord.Dpi = 100F;
            this.lblAmountInWord.ForeColor = System.Drawing.Color.Black;
            this.lblAmountInWord.Name = "lblAmountInWord";
            this.lblAmountInWord.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.lblAmountInWord.StylePriority.UseBackColor = false;
            this.lblAmountInWord.StylePriority.UseBorderColor = false;
            this.lblAmountInWord.StylePriority.UseBorders = false;
            this.lblAmountInWord.StylePriority.UseForeColor = false;
            this.lblAmountInWord.StylePriority.UsePadding = false;
            this.lblAmountInWord.StylePriority.UseTextAlignment = false;
            this.lblAmountInWord.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            this.lblAmountInWord.Weight = 6.4150228417868513D;
            // 
            // lblTotalAmount
            // 
            this.lblTotalAmount.BackColor = System.Drawing.Color.White;
            this.lblTotalAmount.BorderColor = System.Drawing.Color.Black;
            this.lblTotalAmount.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.lblTotalAmount.Dpi = 100F;
            this.lblTotalAmount.ForeColor = System.Drawing.Color.Black;
            this.lblTotalAmount.Name = "lblTotalAmount";
            this.lblTotalAmount.StylePriority.UseBackColor = false;
            this.lblTotalAmount.StylePriority.UseBorderColor = false;
            this.lblTotalAmount.StylePriority.UseBorders = false;
            this.lblTotalAmount.StylePriority.UseForeColor = false;
            xrSummary2.FormatString = "{0:n0}";
            xrSummary2.IgnoreNullValues = true;
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Page;
            this.lblTotalAmount.Summary = xrSummary2;
            this.lblTotalAmount.Weight = 2.1233746361281147D;
            this.lblTotalAmount.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.lblTotalAmount_BeforePrint);
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell13});
            this.xrTableRow5.Dpi = 100F;
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.Weight = 0.14693810659897055D;
            // 
            // xrTableCell13
            // 
            this.xrTableCell13.BackColor = System.Drawing.Color.White;
            this.xrTableCell13.BorderColor = System.Drawing.Color.Black;
            this.xrTableCell13.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableCell13.Dpi = 100F;
            this.xrTableCell13.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableCell13.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(64)))), ((int)(((byte)(0)))));
            this.xrTableCell13.Name = "xrTableCell13";
            this.xrTableCell13.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 5, 0, 0, 100F);
            this.xrTableCell13.StylePriority.UseBackColor = false;
            this.xrTableCell13.StylePriority.UseBorderColor = false;
            this.xrTableCell13.StylePriority.UseBorders = false;
            this.xrTableCell13.StylePriority.UseFont = false;
            this.xrTableCell13.StylePriority.UseForeColor = false;
            this.xrTableCell13.StylePriority.UsePadding = false;
            this.xrTableCell13.StylePriority.UseTextAlignment = false;
            this.xrTableCell13.Text = "For, Ascent Knowledge Academy";
            this.xrTableCell13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            this.xrTableCell13.Weight = 8.5383974779149661D;
            // 
            // PageFooter
            // 
            this.PageFooter.Dpi = 100F;
            this.PageFooter.HeightF = 4.166667F;
            this.PageFooter.Name = "PageFooter";
            // 
            // ReportFooter
            // 
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 2F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // FessInvoiceReportView
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.topMarginBand,
            this.detailBand3,
            this.bottomMarginBand,
            this.ReportHeader,
            this.GroupFooter1,
            this.PageFooter,
            this.ReportFooter});
            this.Margins = new System.Drawing.Printing.Margins(47, 54, 106, 0);
            this.Version = "16.2";
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.FessInvoiceReportView_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTable3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        private void FessInvoiceReportView_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            //XRCrossBandBox cbBox = new XRCrossBandBox() { BorderWidth = 1, BorderColor = Color.Black };
            //cbBox.StartBand = this.topMarginBand;
            //cbBox.EndBand = this.bottomMarginBand;
            //cbBox.StartPointF = new PointF(0, 0);
            //cbBox.EndPointF = new PointF(0, this.bottomMarginBand.HeightF);
            //cbBox.WidthF = this.PageWidth - 75;
            //this.CrossBandControls.Add(cbBox);
        }

        private void lblAmount_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            if (!string.IsNullOrEmpty(lblAmount.Text))
            {
                lblAmount.Text = int.Parse(lblAmount.Text).ToString("N0", PlannerMainReport.Info);
            }
        }

        private void lblTotalAmount_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
           
            if (!string.IsNullOrEmpty(lblTotalAmount.Text))
            {
                lblTotalAmount.Text =  int.Parse(lblTotalAmount.Text).ToString("N0", PlannerMainReport.Info);
            }
           
        }
    }
}
