namespace FinancialPlannerClient.PlanOptions.Reports
{
    partial class CurrentStatusDetails
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary2 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary3 = new DevExpress.XtraReports.UI.XRSummary();
            DevExpress.XtraReports.UI.XRSummary xrSummary4 = new DevExpress.XtraReports.UI.XRSummary();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.lblParticular = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPercentageValue = new DevExpress.XtraReports.UI.XRLabel();
            this.lblAmount = new DevExpress.XtraReports.UI.XRLabel();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
            this.GroupHeader1 = new DevExpress.XtraReports.UI.GroupHeaderBand();
            this.xrLblGroupAssets = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel4 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
            this.xrLabel2 = new DevExpress.XtraReports.UI.XRLabel();
            this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
            this.formattingRule1 = new DevExpress.XtraReports.UI.FormattingRule();
            this.GroupFooter1 = new DevExpress.XtraReports.UI.GroupFooterBand();
            this.lblTotalGroupAmt = new DevExpress.XtraReports.UI.XRLabel();
            this.lblTotalGroupPerValue = new DevExpress.XtraReports.UI.XRLabel();
            this.lblGroupTitle = new DevExpress.XtraReports.UI.XRLabel();
            this.PageFooter = new DevExpress.XtraReports.UI.PageFooterBand();
            this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
            this.lblPageTotal = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblParticular,
            this.lblPercentageValue,
            this.lblAmount});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 25F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lblParticular
            // 
            this.lblParticular.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblParticular.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblParticular.Dpi = 100F;
            this.lblParticular.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 0F);
            this.lblParticular.Name = "lblParticular";
            this.lblParticular.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblParticular.SizeF = new System.Drawing.SizeF(200F, 25F);
            this.lblParticular.StylePriority.UseBackColor = false;
            this.lblParticular.StylePriority.UseBorders = false;
            this.lblParticular.StylePriority.UsePadding = false;
            this.lblParticular.StylePriority.UseTextAlignment = false;
            this.lblParticular.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lblPercentageValue
            // 
            this.lblPercentageValue.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblPercentageValue.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblPercentageValue.Dpi = 100F;
            this.lblPercentageValue.LocationFloat = new DevExpress.Utils.PointFloat(210F, 0F);
            this.lblPercentageValue.Name = "lblPercentageValue";
            this.lblPercentageValue.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPercentageValue.SizeF = new System.Drawing.SizeF(111.7188F, 25F);
            this.lblPercentageValue.StylePriority.UseBackColor = false;
            this.lblPercentageValue.StylePriority.UseBorders = false;
            this.lblPercentageValue.StylePriority.UsePadding = false;
            this.lblPercentageValue.StylePriority.UseTextAlignment = false;
            xrSummary1.Func = DevExpress.XtraReports.UI.SummaryFunc.Percentage;
            this.lblPercentageValue.Summary = xrSummary1;
            this.lblPercentageValue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.lblPercentageValue.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.lblPercentageValue_BeforePrint);
            // 
            // lblAmount
            // 
            this.lblAmount.BackColor = System.Drawing.Color.LemonChiffon;
            this.lblAmount.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblAmount.Dpi = 100F;
            this.lblAmount.LocationFloat = new DevExpress.Utils.PointFloat(321.7187F, 0F);
            this.lblAmount.Name = "lblAmount";
            this.lblAmount.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblAmount.SizeF = new System.Drawing.SizeF(146.8749F, 25F);
            this.lblAmount.StylePriority.UseBackColor = false;
            this.lblAmount.StylePriority.UseBorders = false;
            this.lblAmount.StylePriority.UsePadding = false;
            this.lblAmount.StylePriority.UseTextAlignment = false;
            this.lblAmount.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopRight;
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 1.041667F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrLabel1
            // 
            this.xrLabel1.Dpi = 100F;
            this.xrLabel1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 10.00001F);
            this.xrLabel1.Multiline = true;
            this.xrLabel1.Name = "xrLabel1";
            this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel1.SizeF = new System.Drawing.SizeF(164.5833F, 26.12498F);
            this.xrLabel1.StylePriority.UseFont = false;
            this.xrLabel1.StylePriority.UseForeColor = false;
            this.xrLabel1.Text = "Current Status:";
            // 
            // GroupHeader1
            // 
            this.GroupHeader1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLblGroupAssets,
            this.xrLabel6,
            this.xrLabel4,
            this.xrLabel3,
            this.xrLabel2});
            this.GroupHeader1.Dpi = 100F;
            this.GroupHeader1.HeightF = 72.91668F;
            this.GroupHeader1.Name = "GroupHeader1";
            // 
            // xrLblGroupAssets
            // 
            this.xrLblGroupAssets.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.xrLblGroupAssets.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLblGroupAssets.Dpi = 100F;
            this.xrLblGroupAssets.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLblGroupAssets.LocationFloat = new DevExpress.Utils.PointFloat(110F, 9.25F);
            this.xrLblGroupAssets.Name = "xrLblGroupAssets";
            this.xrLblGroupAssets.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLblGroupAssets.SizeF = new System.Drawing.SizeF(200F, 23F);
            this.xrLblGroupAssets.StylePriority.UseBackColor = false;
            this.xrLblGroupAssets.StylePriority.UseBorders = false;
            this.xrLblGroupAssets.StylePriority.UseFont = false;
            this.xrLblGroupAssets.StylePriority.UseTextAlignment = false;
            this.xrLblGroupAssets.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel6
            // 
            this.xrLabel6.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.xrLabel6.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel6.Dpi = 100F;
            this.xrLabel6.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(321.7186F, 49.91668F);
            this.xrLabel6.Name = "xrLabel6";
            this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel6.SizeF = new System.Drawing.SizeF(146.875F, 23F);
            this.xrLabel6.StylePriority.UseBackColor = false;
            this.xrLabel6.StylePriority.UseBorders = false;
            this.xrLabel6.StylePriority.UseFont = false;
            this.xrLabel6.StylePriority.UseTextAlignment = false;
            this.xrLabel6.Text = "Amount";
            this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel4
            // 
            this.xrLabel4.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.xrLabel4.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel4.Dpi = 100F;
            this.xrLabel4.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel4.LocationFloat = new DevExpress.Utils.PointFloat(210F, 49.91665F);
            this.xrLabel4.Name = "xrLabel4";
            this.xrLabel4.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel4.SizeF = new System.Drawing.SizeF(111.7188F, 23F);
            this.xrLabel4.StylePriority.UseBackColor = false;
            this.xrLabel4.StylePriority.UseBorders = false;
            this.xrLabel4.StylePriority.UseFont = false;
            this.xrLabel4.StylePriority.UseTextAlignment = false;
            this.xrLabel4.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel3
            // 
            this.xrLabel3.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.xrLabel3.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel3.Dpi = 100F;
            this.xrLabel3.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 9.25F);
            this.xrLabel3.Name = "xrLabel3";
            this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel3.SizeF = new System.Drawing.SizeF(100F, 23F);
            this.xrLabel3.StylePriority.UseBackColor = false;
            this.xrLabel3.StylePriority.UseBorders = false;
            this.xrLabel3.StylePriority.UseFont = false;
            this.xrLabel3.StylePriority.UseTextAlignment = false;
            this.xrLabel3.Text = "Assets Class";
            this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrLabel2
            // 
            this.xrLabel2.BackColor = System.Drawing.Color.DarkSeaGreen;
            this.xrLabel2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrLabel2.Dpi = 100F;
            this.xrLabel2.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrLabel2.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 49.91665F);
            this.xrLabel2.Name = "xrLabel2";
            this.xrLabel2.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel2.SizeF = new System.Drawing.SizeF(200F, 23F);
            this.xrLabel2.StylePriority.UseBackColor = false;
            this.xrLabel2.StylePriority.UseBorders = false;
            this.xrLabel2.StylePriority.UseFont = false;
            this.xrLabel2.StylePriority.UseTextAlignment = false;
            this.xrLabel2.Text = "Particulars";
            this.xrLabel2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // PageHeader
            // 
            this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel1});
            this.PageHeader.Dpi = 100F;
            this.PageHeader.HeightF = 47.91667F;
            this.PageHeader.Name = "PageHeader";
            // 
            // formattingRule1
            // 
            this.formattingRule1.Name = "formattingRule1";
            // 
            // GroupFooter1
            // 
            this.GroupFooter1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblTotalGroupAmt,
            this.lblTotalGroupPerValue,
            this.lblGroupTitle});
            this.GroupFooter1.Dpi = 100F;
            this.GroupFooter1.HeightF = 26.04167F;
            this.GroupFooter1.Name = "GroupFooter1";
            // 
            // lblTotalGroupAmt
            // 
            this.lblTotalGroupAmt.Dpi = 100F;
            this.lblTotalGroupAmt.LocationFloat = new DevExpress.Utils.PointFloat(321.7187F, 0F);
            this.lblTotalGroupAmt.Name = "lblTotalGroupAmt";
            this.lblTotalGroupAmt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTotalGroupAmt.SizeF = new System.Drawing.SizeF(146.8749F, 23F);
            this.lblTotalGroupAmt.StylePriority.UseTextAlignment = false;
            xrSummary2.FormatString = "{0:#,#.00}";
            xrSummary2.Running = DevExpress.XtraReports.UI.SummaryRunning.Group;
            this.lblTotalGroupAmt.Summary = xrSummary2;
            this.lblTotalGroupAmt.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // lblTotalGroupPerValue
            // 
            this.lblTotalGroupPerValue.Dpi = 100F;
            this.lblTotalGroupPerValue.LocationFloat = new DevExpress.Utils.PointFloat(210F, 0F);
            this.lblTotalGroupPerValue.Name = "lblTotalGroupPerValue";
            this.lblTotalGroupPerValue.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblTotalGroupPerValue.SizeF = new System.Drawing.SizeF(111.7188F, 23F);
            this.lblTotalGroupPerValue.StylePriority.UseTextAlignment = false;
            xrSummary3.FormatString = "{0:0.00%}";
            xrSummary3.Func = DevExpress.XtraReports.UI.SummaryFunc.Percentage;
            xrSummary3.IgnoreNullValues = true;
            this.lblTotalGroupPerValue.Summary = xrSummary3;
            this.lblTotalGroupPerValue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.lblTotalGroupPerValue.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.lblTotalGroupPerValue_BeforePrint);
            // 
            // lblGroupTitle
            // 
            this.lblGroupTitle.Dpi = 100F;
            this.lblGroupTitle.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 0F);
            this.lblGroupTitle.Name = "lblGroupTitle";
            this.lblGroupTitle.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblGroupTitle.SizeF = new System.Drawing.SizeF(200F, 23F);
            this.lblGroupTitle.Text = "{0} Total :";
            // 
            // PageFooter
            // 
            this.PageFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrLabel5,
            this.lblPageTotal});
            this.PageFooter.Dpi = 100F;
            this.PageFooter.HeightF = 38.54167F;
            this.PageFooter.Name = "PageFooter";
            // 
            // xrLabel5
            // 
            this.xrLabel5.Dpi = 100F;
            this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 5.541674F);
            this.xrLabel5.Name = "xrLabel5";
            this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel5.SizeF = new System.Drawing.SizeF(311.7187F, 23F);
            this.xrLabel5.Text = "Final Total";
            // 
            // lblPageTotal
            // 
            this.lblPageTotal.Dpi = 100F;
            this.lblPageTotal.LocationFloat = new DevExpress.Utils.PointFloat(321.7187F, 5.541674F);
            this.lblPageTotal.Name = "lblPageTotal";
            this.lblPageTotal.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblPageTotal.SizeF = new System.Drawing.SizeF(146.8749F, 23F);
            this.lblPageTotal.StylePriority.UseTextAlignment = false;
            xrSummary4.FormatString = "{0:#,#.00}";
            xrSummary4.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
            this.lblPageTotal.Summary = xrSummary4;
            this.lblPageTotal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
            // 
            // CurrentStatusDetails
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.GroupHeader1,
            this.PageHeader,
            this.GroupFooter1,
            this.PageFooter});
            this.FormattingRuleSheet.AddRange(new DevExpress.XtraReports.UI.FormattingRule[] {
            this.formattingRule1});
            this.Margins = new System.Drawing.Printing.Margins(100, 100, 0, 1);
            this.Version = "16.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRLabel xrLabel1;
        private DevExpress.XtraReports.UI.GroupHeaderBand GroupHeader1;
        private DevExpress.XtraReports.UI.XRLabel xrLabel3;
        private DevExpress.XtraReports.UI.XRLabel xrLabel2;
        private DevExpress.XtraReports.UI.XRLabel xrLabel6;
        private DevExpress.XtraReports.UI.XRLabel xrLabel4;
        private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
        private DevExpress.XtraReports.UI.XRLabel xrLblGroupAssets;
        private DevExpress.XtraReports.UI.FormattingRule formattingRule1;
        private DevExpress.XtraReports.UI.XRLabel lblParticular;
        private DevExpress.XtraReports.UI.XRLabel lblPercentageValue;
        private DevExpress.XtraReports.UI.XRLabel lblAmount;
        private DevExpress.XtraReports.UI.GroupFooterBand GroupFooter1;
        private DevExpress.XtraReports.UI.XRLabel lblTotalGroupPerValue;
        private DevExpress.XtraReports.UI.XRLabel lblGroupTitle;
        private DevExpress.XtraReports.UI.XRLabel lblTotalGroupAmt;
        private DevExpress.XtraReports.UI.PageFooterBand PageFooter;
        private DevExpress.XtraReports.UI.XRLabel lblPageTotal;
        private DevExpress.XtraReports.UI.XRLabel xrLabel5;
    }
}
