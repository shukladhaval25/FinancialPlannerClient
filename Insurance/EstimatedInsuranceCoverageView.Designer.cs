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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtEstimatedIsurnceCoverage = new DevExpress.XtraEditors.TextEdit();
            this.gridInsuranceCalculation = new DevExpress.XtraGrid.GridControl();
            this.gridViewInsuranceCalculation = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.lblProcess = new DevExpress.XtraEditors.LabelControl();
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
            // lblProcess
            // 
            this.lblProcess.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProcess.Appearance.Options.UseFont = true;
            this.lblProcess.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblProcess.Location = new System.Drawing.Point(373, 13);
            this.lblProcess.Name = "lblProcess";
            this.lblProcess.Size = new System.Drawing.Size(564, 19);
            this.lblProcess.TabIndex = 3;
            this.lblProcess.Text = "Please wait loading data...";
            // 
            // EstimatedInsuranceCoverageView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 361);
            this.Controls.Add(this.lblProcess);
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
        private DevExpress.XtraEditors.LabelControl lblProcess;
    }
}