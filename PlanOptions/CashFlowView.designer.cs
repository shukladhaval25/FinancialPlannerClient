namespace FinancialPlannerClient.PlanOptions
{
    partial class CashFlowView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grdSplitCashFlow = new DevExpress.XtraGrid.GridControl();
            this.gridSplitContainerViewCashFlow = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.grdSplitCashFlow)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainerViewCashFlow)).BeginInit();
            this.SuspendLayout();
            // 
            // grdSplitCashFlow
            // 
            this.grdSplitCashFlow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grdSplitCashFlow.Location = new System.Drawing.Point(6, 7);
            this.grdSplitCashFlow.MainView = this.gridSplitContainerViewCashFlow;
            this.grdSplitCashFlow.Name = "grdSplitCashFlow";
            this.grdSplitCashFlow.Size = new System.Drawing.Size(1070, 510);
            this.grdSplitCashFlow.TabIndex = 1;
            this.grdSplitCashFlow.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridSplitContainerViewCashFlow});
            // 
            // gridSplitContainerViewCashFlow
            // 
            this.gridSplitContainerViewCashFlow.GridControl = this.grdSplitCashFlow;
            this.gridSplitContainerViewCashFlow.Name = "gridSplitContainerViewCashFlow";
            this.gridSplitContainerViewCashFlow.OptionsBehavior.Editable = false;
            this.gridSplitContainerViewCashFlow.OptionsBehavior.ReadOnly = true;
            this.gridSplitContainerViewCashFlow.OptionsMenu.ShowConditionalFormattingItem = true;
            this.gridSplitContainerViewCashFlow.OptionsView.ColumnAutoWidth = false;
            // 
            // CashFlowView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 522);
            this.Controls.Add(this.grdSplitCashFlow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CashFlowView";
            this.Text = "Cash Flow";
            this.Load += new System.EventHandler(this.CashFlowView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdSplitCashFlow)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSplitContainerViewCashFlow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl grdSplitCashFlow;
        private DevExpress.XtraGrid.Views.Grid.GridView gridSplitContainerViewCashFlow;
    }
}

