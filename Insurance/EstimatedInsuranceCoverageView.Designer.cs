namespace FinancialPlannerClient.Insurance
{
    partial class EstimatedInsuranceCoverageView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EstimatedInsuranceCoverageView));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtEstimatedIsurnceCoverage = new DevExpress.XtraEditors.TextEdit();
            this.gridInsuranceCalculation = new DevExpress.XtraGrid.GridControl();
            this.gridViewInsuranceCalculation = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.progressPanel1 = new DevExpress.XtraWaitForm.ProgressPanel();
            this.btnExport = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.txtEstimatedIsurnceCoverage.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInsuranceCalculation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInsuranceCalculation)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(13, 13);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(192, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Estimated Insurance Coverage Amount:";
            // 
            // txtEstimatedIsurnceCoverage
            // 
            this.txtEstimatedIsurnceCoverage.EditValue = "";
            this.txtEstimatedIsurnceCoverage.Location = new System.Drawing.Point(212, 13);
            this.txtEstimatedIsurnceCoverage.Name = "txtEstimatedIsurnceCoverage";
            this.txtEstimatedIsurnceCoverage.Properties.Appearance.Options.UseTextOptions = true;
            this.txtEstimatedIsurnceCoverage.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtEstimatedIsurnceCoverage.Properties.ReadOnly = true;
            this.txtEstimatedIsurnceCoverage.Size = new System.Drawing.Size(145, 20);
            this.txtEstimatedIsurnceCoverage.TabIndex = 1;
            // 
            // gridInsuranceCalculation
            // 
            this.gridInsuranceCalculation.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gridInsuranceCalculation.Location = new System.Drawing.Point(13, 43);
            this.gridInsuranceCalculation.MainView = this.gridViewInsuranceCalculation;
            this.gridInsuranceCalculation.Name = "gridInsuranceCalculation";
            this.gridInsuranceCalculation.Size = new System.Drawing.Size(924, 306);
            this.gridInsuranceCalculation.TabIndex = 2;
            this.gridInsuranceCalculation.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewInsuranceCalculation});
            // 
            // gridViewInsuranceCalculation
            // 
            this.gridViewInsuranceCalculation.GridControl = this.gridInsuranceCalculation;
            this.gridViewInsuranceCalculation.Name = "gridViewInsuranceCalculation";
            // 
            // progressPanel1
            // 
            this.progressPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressPanel1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.progressPanel1.Appearance.Options.UseBackColor = true;
            this.progressPanel1.BarAnimationElementThickness = 2;
            this.progressPanel1.Location = new System.Drawing.Point(351, 147);
            this.progressPanel1.Name = "progressPanel1";
            this.progressPanel1.Size = new System.Drawing.Size(246, 66);
            this.progressPanel1.TabIndex = 3;
            this.progressPanel1.Text = "progressPanel1";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExport.Image")));
            this.btnExport.Location = new System.Drawing.Point(907, 49);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(23, 23);
            this.btnExport.TabIndex = 4;
            this.btnExport.Text = "Export To Excel";
            this.btnExport.ToolTip = "Export to excel";
            this.btnExport.ToolTipTitle = "Export";
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // EstimatedInsuranceCoverageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 361);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.progressPanel1);
            this.Controls.Add(this.gridInsuranceCalculation);
            this.Controls.Add(this.txtEstimatedIsurnceCoverage);
            this.Controls.Add(this.labelControl1);
            this.Name = "EstimatedInsuranceCoverageView";
            this.Text = "EstimatedInsuranceCoverageView";
            this.Load += new System.EventHandler(this.EstimatedInsuranceCoverageView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtEstimatedIsurnceCoverage.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridInsuranceCalculation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInsuranceCalculation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtEstimatedIsurnceCoverage;
        private DevExpress.XtraGrid.GridControl gridInsuranceCalculation;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewInsuranceCalculation;
        private DevExpress.XtraWaitForm.ProgressPanel progressPanel1;
        private DevExpress.XtraEditors.SimpleButton btnExport;
    }
}