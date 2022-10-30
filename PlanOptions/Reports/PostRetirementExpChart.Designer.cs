namespace FinancialPlannerClient.PlanOptions.Reports
{
    partial class PostRetirementExpChart
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
            DevExpress.XtraCharts.XYDiagram xyDiagram1 = new DevExpress.XtraCharts.XYDiagram();
            DevExpress.XtraCharts.CustomLegendItem customLegendItem1 = new DevExpress.XtraCharts.CustomLegendItem();
            DevExpress.XtraCharts.CustomLegendItem customLegendItem2 = new DevExpress.XtraCharts.CustomLegendItem();
            DevExpress.XtraCharts.Legend legend1 = new DevExpress.XtraCharts.Legend();
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.SideBySideBarSeriesLabel sideBySideBarSeriesLabel1 = new DevExpress.XtraCharts.SideBySideBarSeriesLabel();
            DevExpress.XtraCharts.SeriesPoint seriesPoint1 = new DevExpress.XtraCharts.SeriesPoint("Dhaval", new object[] {
            ((object)(70D))});
            DevExpress.XtraCharts.SeriesPoint seriesPoint2 = new DevExpress.XtraCharts.SeriesPoint("Chhaya", new object[] {
            ((object)(30D))});
            DevExpress.XtraCharts.SideBySideBarSeriesView sideBySideBarSeriesView1 = new DevExpress.XtraCharts.SideBySideBarSeriesView();
            DevExpress.XtraCharts.Series series2 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.ChartTitle chartTitle1 = new DevExpress.XtraCharts.ChartTitle();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.xrChart1 = new DevExpress.XtraReports.UI.XRChart();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.ReportFooter = new DevExpress.XtraReports.UI.ReportFooterBand();
            this.xrTableInfo = new DevExpress.XtraReports.UI.XRTable();
            this.xrTableRow2 = new DevExpress.XtraReports.UI.XRTableRow();
            this.lblClientName = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblClientAgeValue = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblStartYear = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblStartYearValue = new DevExpress.XtraReports.UI.XRTableCell();
            this.xrTableRow5 = new DevExpress.XtraReports.UI.XRTableRow();
            this.lblSpouse = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblSpouseAgeVal = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblEndYear = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblEndYearValue = new DevExpress.XtraReports.UI.XRTableCell();
            this.lblInfo = new DevExpress.XtraReports.UI.XRLabel();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTableInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 0F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrChart1});
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 537.4584F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // xrChart1
            // 
            this.xrChart1.AppearanceNameSerializable = "Light";
            this.xrChart1.BorderColor = System.Drawing.Color.Black;
            this.xrChart1.Borders = DevExpress.XtraPrinting.BorderSide.None;
            xyDiagram1.AxisX.VisibleInPanesSerializable = "-1";
            xyDiagram1.AxisY.VisibleInPanesSerializable = "-1";
            xyDiagram1.DefaultPane.EnableAxisXScrolling = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisXZooming = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisYScrolling = DevExpress.Utils.DefaultBoolean.False;
            xyDiagram1.DefaultPane.EnableAxisYZooming = DevExpress.Utils.DefaultBoolean.False;
            this.xrChart1.Diagram = xyDiagram1;
            this.xrChart1.Dpi = 100F;
            customLegendItem1.Name = "Custom Legend Item 1";
            customLegendItem2.Name = "Custom Legend Item 2";
            this.xrChart1.Legend.CustomItems.AddRange(new DevExpress.XtraCharts.CustomLegendItem[] {
            customLegendItem1,
            customLegendItem2});
            this.xrChart1.Legend.Name = "Default Legend";
            this.xrChart1.Legend.Visibility = DevExpress.Utils.DefaultBoolean.False;
            legend1.AlignmentHorizontal = DevExpress.XtraCharts.LegendAlignmentHorizontal.Center;
            legend1.AlignmentVertical = DevExpress.XtraCharts.LegendAlignmentVertical.BottomOutside;
            legend1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            legend1.Border.Color = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(54)))), ((int)(((byte)(93)))));
            legend1.Direction = DevExpress.XtraCharts.LegendDirection.BottomToTop;
            legend1.Name = "Legend1";
            legend1.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.xrChart1.Legends.AddRange(new DevExpress.XtraCharts.Legend[] {
            legend1});
            this.xrChart1.LocationFloat = new DevExpress.Utils.PointFloat(8.500061F, 32.29169F);
            this.xrChart1.Name = "xrChart1";
            this.xrChart1.PaletteBaseColorNumber = 4;
            this.xrChart1.PaletteName = "Apex";
            sideBySideBarSeriesLabel1.FillStyle.FillMode = DevExpress.XtraCharts.FillMode.Empty;
            series1.Label = sideBySideBarSeriesLabel1;
            series1.LabelsVisibility = DevExpress.Utils.DefaultBoolean.False;
            series1.Name = "Series 1";
            seriesPoint1.ColorSerializable = "#8DB3E2";
            seriesPoint2.ColorSerializable = "#FF8040";
            series1.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] {
            seriesPoint1,
            seriesPoint2});
            sideBySideBarSeriesView1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(150)))), ((int)(((byte)(70)))));
            series1.View = sideBySideBarSeriesView1;
            series2.Name = "Series 2";
            this.xrChart1.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1,
        series2};
            this.xrChart1.SizeF = new System.Drawing.SizeF(812.9999F, 505.1667F);
            chartTitle1.Text = "Post Retirement Exp. Flow";
            this.xrChart1.Titles.AddRange(new DevExpress.XtraCharts.ChartTitle[] {
            chartTitle1});
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 3.708394F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // ReportFooter
            // 
            this.ReportFooter.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrTableInfo,
            this.lblInfo});
            this.ReportFooter.Dpi = 100F;
            this.ReportFooter.HeightF = 100F;
            this.ReportFooter.Name = "ReportFooter";
            // 
            // xrTableInfo
            // 
            this.xrTableInfo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.xrTableInfo.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.xrTableInfo.BorderWidth = 1F;
            this.xrTableInfo.Dpi = 100F;
            this.xrTableInfo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.xrTableInfo.LocationFloat = new DevExpress.Utils.PointFloat(11.50001F, 40.00003F);
            this.xrTableInfo.Name = "xrTableInfo";
            this.xrTableInfo.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 0, 0, 0, 100F);
            this.xrTableInfo.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow2,
            this.xrTableRow5});
            this.xrTableInfo.SizeF = new System.Drawing.SizeF(809.9999F, 49.99999F);
            this.xrTableInfo.StylePriority.UseBorderColor = false;
            this.xrTableInfo.StylePriority.UseBorders = false;
            this.xrTableInfo.StylePriority.UseBorderWidth = false;
            this.xrTableInfo.StylePriority.UseFont = false;
            this.xrTableInfo.StylePriority.UsePadding = false;
            // 
            // xrTableRow2
            // 
            this.xrTableRow2.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.lblClientName,
            this.lblClientAgeValue,
            this.lblStartYear,
            this.lblStartYearValue});
            this.xrTableRow2.Dpi = 100F;
            this.xrTableRow2.Name = "xrTableRow2";
            this.xrTableRow2.Weight = 1D;
            // 
            // lblClientName
            // 
            this.lblClientName.Dpi = 100F;
            this.lblClientName.Name = "lblClientName";
            this.lblClientName.Text = "Client Age at that time";
            this.lblClientName.Weight = 1.5490891272341738D;
            // 
            // lblClientAgeValue
            // 
            this.lblClientAgeValue.Dpi = 100F;
            this.lblClientAgeValue.Name = "lblClientAgeValue";
            this.lblClientAgeValue.StylePriority.UseTextAlignment = false;
            this.lblClientAgeValue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.lblClientAgeValue.Weight = 1.2105268390230997D;
            // 
            // lblStartYear
            // 
            this.lblStartYear.Dpi = 100F;
            this.lblStartYear.Name = "lblStartYear";
            this.lblStartYear.StylePriority.UseTextAlignment = false;
            this.lblStartYear.Text = "Start Year";
            this.lblStartYear.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.lblStartYear.Weight = 1.2105268390230997D;
            // 
            // lblStartYearValue
            // 
            this.lblStartYearValue.Dpi = 100F;
            this.lblStartYearValue.Name = "lblStartYearValue";
            this.lblStartYearValue.StylePriority.UseTextAlignment = false;
            this.lblStartYearValue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.lblStartYearValue.Weight = 1.2105268390230997D;
            // 
            // xrTableRow5
            // 
            this.xrTableRow5.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.lblSpouse,
            this.lblSpouseAgeVal,
            this.lblEndYear,
            this.lblEndYearValue});
            this.xrTableRow5.Dpi = 100F;
            this.xrTableRow5.Name = "xrTableRow5";
            this.xrTableRow5.Weight = 1D;
            // 
            // lblSpouse
            // 
            this.lblSpouse.Dpi = 100F;
            this.lblSpouse.Name = "lblSpouse";
            this.lblSpouse.Text = "Spouse Age at that time";
            this.lblSpouse.Weight = 1.5490891272341738D;
            // 
            // lblSpouseAgeVal
            // 
            this.lblSpouseAgeVal.Dpi = 100F;
            this.lblSpouseAgeVal.Name = "lblSpouseAgeVal";
            this.lblSpouseAgeVal.StylePriority.UseTextAlignment = false;
            this.lblSpouseAgeVal.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.lblSpouseAgeVal.Weight = 1.2105268390230997D;
            // 
            // lblEndYear
            // 
            this.lblEndYear.Dpi = 100F;
            this.lblEndYear.Name = "lblEndYear";
            this.lblEndYear.StylePriority.UseTextAlignment = false;
            this.lblEndYear.Text = "End Year";
            this.lblEndYear.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.lblEndYear.Weight = 1.2105268390230997D;
            // 
            // lblEndYearValue
            // 
            this.lblEndYearValue.Dpi = 100F;
            this.lblEndYearValue.Name = "lblEndYearValue";
            this.lblEndYearValue.StylePriority.UseTextAlignment = false;
            this.lblEndYearValue.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopCenter;
            this.lblEndYearValue.Weight = 1.2105268390230997D;
            // 
            // lblInfo
            // 
            this.lblInfo.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.lblInfo.Dpi = 100F;
            this.lblInfo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInfo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(117)))), ((int)(((byte)(181)))));
            this.lblInfo.LocationFloat = new DevExpress.Utils.PointFloat(9.99999F, 9.999974F);
            this.lblInfo.Multiline = true;
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblInfo.SizeF = new System.Drawing.SizeF(810F, 25.08331F);
            this.lblInfo.StylePriority.UseBorders = false;
            this.lblInfo.StylePriority.UseFont = false;
            this.lblInfo.StylePriority.UseForeColor = false;
            this.lblInfo.Text = "At below age level remaining corpus fund becomes 0 or negative";
            // 
            // PostRetirementExpChart
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin,
            this.ReportFooter});
            this.Margins = new System.Drawing.Printing.Margins(14, 6, 537, 4);
            this.Version = "16.2";
            ((System.ComponentModel.ISupportInitialize)(xyDiagram1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(sideBySideBarSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrChart1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrTableInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRChart xrChart1;
        private DevExpress.XtraReports.UI.ReportFooterBand ReportFooter;
        private DevExpress.XtraReports.UI.XRLabel lblInfo;
        private DevExpress.XtraReports.UI.XRTable xrTableInfo;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow2;
        private DevExpress.XtraReports.UI.XRTableCell lblClientName;
        private DevExpress.XtraReports.UI.XRTableCell lblClientAgeValue;
        private DevExpress.XtraReports.UI.XRTableCell lblStartYear;
        private DevExpress.XtraReports.UI.XRTableCell lblStartYearValue;
        private DevExpress.XtraReports.UI.XRTableRow xrTableRow5;
        private DevExpress.XtraReports.UI.XRTableCell lblSpouse;
        private DevExpress.XtraReports.UI.XRTableCell lblSpouseAgeVal;
        private DevExpress.XtraReports.UI.XRTableCell lblEndYear;
        private DevExpress.XtraReports.UI.XRTableCell lblEndYearValue;
    }
}
