namespace FinancialPlannerClient.PlanOptions.Reports.Investment_Recommendation
{
    partial class InvestmentDetails
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
            DevExpress.XtraCharts.Series series1 = new DevExpress.XtraCharts.Series();
            DevExpress.XtraCharts.PieSeriesLabel pieSeriesLabel1 = new DevExpress.XtraCharts.PieSeriesLabel();
            DevExpress.XtraCharts.SeriesPoint seriesPoint1 = new DevExpress.XtraCharts.SeriesPoint("Equity", new object[] {
            ((object)(60D))}, 0);
            DevExpress.XtraCharts.SeriesPoint seriesPoint2 = new DevExpress.XtraCharts.SeriesPoint("Debt", new object[] {
            ((object)(40D))}, 1);
            DevExpress.XtraCharts.PieSeriesView pieSeriesView1 = new DevExpress.XtraCharts.PieSeriesView();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.subReportSwitch = new DevExpress.XtraReports.UI.XRSubreport();
            this.subReportCheque = new DevExpress.XtraReports.UI.XRSubreport();
            this.subReportSTP = new DevExpress.XtraReports.UI.XRSubreport();
            this.subReportSchemeCategoryWise = new DevExpress.XtraReports.UI.XRSubreport();
            this.subReportInvBreackup = new DevExpress.XtraReports.UI.XRSubreport();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.lblDebt = new DevExpress.XtraReports.UI.XRLabel();
            this.lblEquity = new DevExpress.XtraReports.UI.XRLabel();
            this.xrChartAssetAllocation = new DevExpress.XtraReports.UI.XRChart();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            ((System.ComponentModel.ISupportInitialize)(this.xrChartAssetAllocation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // Detail
            // 
            this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.subReportSwitch,
            this.subReportCheque,
            this.subReportSTP,
            this.subReportSchemeCategoryWise,
            this.subReportInvBreackup});
            this.Detail.Dpi = 100F;
            this.Detail.HeightF = 166.6667F;
            this.Detail.Name = "Detail";
            this.Detail.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.Detail.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // subReportSwitch
            // 
            this.subReportSwitch.Dpi = 100F;
            this.subReportSwitch.LocationFloat = new DevExpress.Utils.PointFloat(10F, 133.6667F);
            this.subReportSwitch.Name = "subReportSwitch";
            this.subReportSwitch.SizeF = new System.Drawing.SizeF(716.4584F, 23F);
            // 
            // subReportCheque
            // 
            this.subReportCheque.Dpi = 100F;
            this.subReportCheque.LocationFloat = new DevExpress.Utils.PointFloat(10F, 104.5F);
            this.subReportCheque.Name = "subReportCheque";
            this.subReportCheque.SizeF = new System.Drawing.SizeF(716.4584F, 23.00001F);
            // 
            // subReportSTP
            // 
            this.subReportSTP.Dpi = 100F;
            this.subReportSTP.LocationFloat = new DevExpress.Utils.PointFloat(10F, 72.83334F);
            this.subReportSTP.Name = "subReportSTP";
            this.subReportSTP.SizeF = new System.Drawing.SizeF(716.4584F, 23.00001F);
            // 
            // subReportSchemeCategoryWise
            // 
            this.subReportSchemeCategoryWise.Dpi = 100F;
            this.subReportSchemeCategoryWise.LocationFloat = new DevExpress.Utils.PointFloat(9.999879F, 42.00001F);
            this.subReportSchemeCategoryWise.Name = "subReportSchemeCategoryWise";
            this.subReportSchemeCategoryWise.SizeF = new System.Drawing.SizeF(716.4585F, 23F);
            // 
            // subReportInvBreackup
            // 
            this.subReportInvBreackup.Dpi = 100F;
            this.subReportInvBreackup.LocationFloat = new DevExpress.Utils.PointFloat(10F, 10.00001F);
            this.subReportInvBreackup.Name = "subReportInvBreackup";
            this.subReportInvBreackup.SizeF = new System.Drawing.SizeF(716.4584F, 23F);
            // 
            // TopMargin
            // 
            this.TopMargin.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblDebt,
            this.lblEquity,
            this.xrChartAssetAllocation});
            this.TopMargin.Dpi = 100F;
            this.TopMargin.HeightF = 200F;
            this.TopMargin.Name = "TopMargin";
            this.TopMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.TopMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // lblDebt
            // 
            this.lblDebt.Dpi = 100F;
            this.lblDebt.LocationFloat = new DevExpress.Utils.PointFloat(584.3333F, 42.87499F);
            this.lblDebt.Name = "lblDebt";
            this.lblDebt.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblDebt.SizeF = new System.Drawing.SizeF(59.375F, 23F);
            this.lblDebt.Text = "Debt";
            // 
            // lblEquity
            // 
            this.lblEquity.Dpi = 100F;
            this.lblEquity.LocationFloat = new DevExpress.Utils.PointFloat(584.3333F, 20.87499F);
            this.lblEquity.Name = "lblEquity";
            this.lblEquity.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.lblEquity.SizeF = new System.Drawing.SizeF(59.375F, 23F);
            this.lblEquity.Text = "Equity";
            // 
            // xrChartAssetAllocation
            // 
            this.xrChartAssetAllocation.BorderColor = System.Drawing.Color.Black;
            this.xrChartAssetAllocation.Borders = DevExpress.XtraPrinting.BorderSide.None;
            this.xrChartAssetAllocation.Dpi = 100F;
            this.xrChartAssetAllocation.Legend.Border.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.xrChartAssetAllocation.Legend.ItemVisibilityMode = DevExpress.XtraCharts.LegendItemVisibilityMode.AutoGeneratedAndCustom;
            this.xrChartAssetAllocation.Legend.Name = "Default Legend";
            this.xrChartAssetAllocation.Legend.Visibility = DevExpress.Utils.DefaultBoolean.True;
            this.xrChartAssetAllocation.LocationFloat = new DevExpress.Utils.PointFloat(10.00001F, 10.00001F);
            this.xrChartAssetAllocation.Name = "xrChartAssetAllocation";
            pieSeriesLabel1.Position = DevExpress.XtraCharts.PieSeriesLabelPosition.Inside;
            pieSeriesLabel1.ResolveOverlappingMode = DevExpress.XtraCharts.ResolveOverlappingMode.Default;
            series1.Label = pieSeriesLabel1;
            series1.Name = "Series 1";
            series1.Points.AddRange(new DevExpress.XtraCharts.SeriesPoint[] {
            seriesPoint1,
            seriesPoint2});
            series1.View = pieSeriesView1;
            this.xrChartAssetAllocation.SeriesSerializable = new DevExpress.XtraCharts.Series[] {
        series1};
            this.xrChartAssetAllocation.SizeF = new System.Drawing.SizeF(716.4584F, 180F);
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 100F;
            this.BottomMargin.HeightF = 31.37499F;
            this.BottomMargin.Name = "BottomMargin";
            this.BottomMargin.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 100F);
            this.BottomMargin.TextAlignment = DevExpress.XtraPrinting.TextAlignment.TopLeft;
            // 
            // InvestmentDetails
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail,
            this.TopMargin,
            this.BottomMargin});
            this.Margins = new System.Drawing.Printing.Margins(49, 53, 200, 31);
            this.Version = "16.2";
            this.BeforePrint += new System.Drawing.Printing.PrintEventHandler(this.InvestmentDetails_BeforePrint);
            ((System.ComponentModel.ISupportInitialize)(pieSeriesLabel1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(pieSeriesView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(series1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xrChartAssetAllocation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.XRSubreport subReportInvBreackup;
        private DevExpress.XtraReports.UI.XRChart xrChartAssetAllocation;
        private DevExpress.XtraReports.UI.XRSubreport subReportSchemeCategoryWise;
        private DevExpress.XtraReports.UI.XRLabel lblDebt;
        private DevExpress.XtraReports.UI.XRLabel lblEquity;
        private DevExpress.XtraReports.UI.XRSubreport subReportSTP;
        private DevExpress.XtraReports.UI.XRSubreport subReportCheque;
        private DevExpress.XtraReports.UI.XRSubreport subReportSwitch;
    }
}
