namespace FinancialPlannerClient.Insurance
{
    partial class InsuranceCalculation
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
            this.lblContactTitle = new DevExpress.XtraEditors.LabelControl();
            this.gridInsuranceCoverage = new DevExpress.XtraGrid.GridControl();
            this.gridViewInsuranceCoverage = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridInsuranceCoverage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInsuranceCoverage)).BeginInit();
            this.SuspendLayout();
            // 
            // lblContactTitle
            // 
            this.lblContactTitle.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContactTitle.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblContactTitle.Appearance.Options.UseFont = true;
            this.lblContactTitle.Appearance.Options.UseForeColor = true;
            this.lblContactTitle.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblContactTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblContactTitle.Location = new System.Drawing.Point(0, 0);
            this.lblContactTitle.Name = "lblContactTitle";
            this.lblContactTitle.Size = new System.Drawing.Size(953, 21);
            this.lblContactTitle.TabIndex = 7;
            this.lblContactTitle.Text = "Life Insurance Require Analysis";
            // 
            // gridInsuranceCoverage
            // 
            this.gridInsuranceCoverage.Location = new System.Drawing.Point(12, 47);
            this.gridInsuranceCoverage.MainView = this.gridViewInsuranceCoverage;
            this.gridInsuranceCoverage.Name = "gridInsuranceCoverage";
            this.gridInsuranceCoverage.Size = new System.Drawing.Size(537, 278);
            this.gridInsuranceCoverage.TabIndex = 8;
            this.gridInsuranceCoverage.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewInsuranceCoverage});
            // 
            // gridViewInsuranceCoverage
            // 
            this.gridViewInsuranceCoverage.GridControl = this.gridInsuranceCoverage;
            this.gridViewInsuranceCoverage.Name = "gridViewInsuranceCoverage";
            this.gridViewInsuranceCoverage.OptionsView.ShowGroupPanel = false;
            // 
            // InsuranceCalculation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(953, 436);
            this.Controls.Add(this.gridInsuranceCoverage);
            this.Controls.Add(this.lblContactTitle);
            this.Name = "InsuranceCalculation";
            this.Text = "Insurance";
            ((System.ComponentModel.ISupportInitialize)(this.gridInsuranceCoverage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewInsuranceCoverage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblContactTitle;
        private DevExpress.XtraGrid.GridControl gridInsuranceCoverage;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewInsuranceCoverage;
    }
}

