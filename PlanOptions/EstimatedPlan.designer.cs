namespace FinancialPlannerClient.PlanOptions
{
    partial class EstimatedPlan
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EstimatedPlan));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPlanOption = new DevExpress.XtraEditors.ComboBoxEdit();
            this.label1 = new System.Windows.Forms.Label();
            this.grpPlanDetail = new DevExpress.XtraEditors.GroupControl();
            this.lblStartDate = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lblPlanPeriod = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPlanName = new System.Windows.Forms.Label();
            this.grpPlanOption = new DevExpress.XtraEditors.GroupControl();
            this.btnPlanOptinView = new DevExpress.XtraEditors.SimpleButton();
            this.lblRiskProfileValue = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.tabEstimatedPlan = new DevExpress.XtraBars.Navigation.TabPane();
            this.tabNavigationPageCashFlow = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.tabNavigationPageGoal = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.tabNavigationPageCurrentStatus = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            this.tabNavigationPagePostRetirementCashFlow = new DevExpress.XtraBars.Navigation.TabNavigationPage();
            ((System.ComponentModel.ISupportInitialize)(this.cmbPlanOption.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPlanDetail)).BeginInit();
            this.grpPlanDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpPlanOption)).BeginInit();
            this.grpPlanOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabEstimatedPlan)).BeginInit();
            this.tabEstimatedPlan.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Plan Option:";
            // 
            // cmbPlanOption
            // 
            this.cmbPlanOption.Location = new System.Drawing.Point(5, 42);
            this.cmbPlanOption.Name = "cmbPlanOption";
            this.cmbPlanOption.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cmbPlanOption.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cmbPlanOption.Size = new System.Drawing.Size(193, 20);
            this.cmbPlanOption.TabIndex = 6;
            this.cmbPlanOption.SelectedIndexChanged += new System.EventHandler(this.cmbPlanOption_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Name :";
            // 
            // grpPlanDetail
            // 
            this.grpPlanDetail.Controls.Add(this.lblStartDate);
            this.grpPlanDetail.Controls.Add(this.label6);
            this.grpPlanDetail.Controls.Add(this.lblPlanPeriod);
            this.grpPlanDetail.Controls.Add(this.label4);
            this.grpPlanDetail.Controls.Add(this.lblPlanName);
            this.grpPlanDetail.Controls.Add(this.label1);
            this.grpPlanDetail.Location = new System.Drawing.Point(6, 4);
            this.grpPlanDetail.Name = "grpPlanDetail";
            this.grpPlanDetail.Size = new System.Drawing.Size(461, 77);
            this.grpPlanDetail.TabIndex = 8;
            this.grpPlanDetail.Text = "Plan Details";
            // 
            // lblStartDate
            // 
            this.lblStartDate.AutoSize = true;
            this.lblStartDate.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStartDate.Location = new System.Drawing.Point(311, 51);
            this.lblStartDate.Name = "lblStartDate";
            this.lblStartDate.Size = new System.Drawing.Size(72, 13);
            this.lblStartDate.TabIndex = 12;
            this.lblStartDate.Text = "#StartDate";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(311, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Start Date";
            // 
            // lblPlanPeriod
            // 
            this.lblPlanPeriod.AutoSize = true;
            this.lblPlanPeriod.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanPeriod.Location = new System.Drawing.Point(155, 51);
            this.lblPlanPeriod.Name = "lblPlanPeriod";
            this.lblPlanPeriod.Size = new System.Drawing.Size(42, 13);
            this.lblPlanPeriod.TabIndex = 10;
            this.lblPlanPeriod.Text = "Name ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(155, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Period :";
            // 
            // lblPlanName
            // 
            this.lblPlanName.AutoSize = true;
            this.lblPlanName.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanName.Location = new System.Drawing.Point(5, 51);
            this.lblPlanName.Name = "lblPlanName";
            this.lblPlanName.Size = new System.Drawing.Size(42, 13);
            this.lblPlanName.TabIndex = 8;
            this.lblPlanName.Text = "Name ";
            // 
            // grpPlanOption
            // 
            this.grpPlanOption.Controls.Add(this.btnPlanOptinView);
            this.grpPlanOption.Controls.Add(this.lblRiskProfileValue);
            this.grpPlanOption.Controls.Add(this.label3);
            this.grpPlanOption.Controls.Add(this.cmbPlanOption);
            this.grpPlanOption.Controls.Add(this.label2);
            this.grpPlanOption.Location = new System.Drawing.Point(473, 4);
            this.grpPlanOption.Name = "grpPlanOption";
            this.grpPlanOption.Size = new System.Drawing.Size(572, 77);
            this.grpPlanOption.TabIndex = 9;
            this.grpPlanOption.Text = "Plan Option Details";
            // 
            // btnPlanOptinView
            // 
            this.btnPlanOptinView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPlanOptinView.Image = ((System.Drawing.Image)(resources.GetObject("btnPlanOptinView.Image")));
            this.btnPlanOptinView.Location = new System.Drawing.Point(485, 33);
            this.btnPlanOptinView.Name = "btnPlanOptinView";
            this.btnPlanOptinView.Size = new System.Drawing.Size(82, 29);
            toolTipTitleItem1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            toolTipTitleItem1.Appearance.Options.UseImage = true;
            toolTipTitleItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem1.Image")));
            toolTipTitleItem1.Text = "Plan options";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "To get more details about plan option click here.";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.btnPlanOptinView.SuperTip = superToolTip1;
            this.btnPlanOptinView.TabIndex = 9;
            this.btnPlanOptinView.Text = "Get Details";
            this.btnPlanOptinView.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Application;
            this.btnPlanOptinView.ToolTipTitle = "New Client";
            this.btnPlanOptinView.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lblRiskProfileValue
            // 
            this.lblRiskProfileValue.AutoSize = true;
            this.lblRiskProfileValue.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRiskProfileValue.Location = new System.Drawing.Point(258, 45);
            this.lblRiskProfileValue.Name = "lblRiskProfileValue";
            this.lblRiskProfileValue.Size = new System.Drawing.Size(116, 13);
            this.lblRiskProfileValue.TabIndex = 8;
            this.lblRiskProfileValue.Text = "#RiskProfileValue#";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(258, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(76, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Risk Profile :";
            // 
            // btnClose
            // 
            this.btnClose.ImageUri.Uri = "Cancel";
            this.btnClose.Location = new System.Drawing.Point(1051, 37);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(107, 29);
            this.btnClose.TabIndex = 27;
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tabEstimatedPlan
            // 
            this.tabEstimatedPlan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabEstimatedPlan.Controls.Add(this.tabNavigationPageCashFlow);
            this.tabEstimatedPlan.Controls.Add(this.tabNavigationPageGoal);
            this.tabEstimatedPlan.Controls.Add(this.tabNavigationPageCurrentStatus);
            this.tabEstimatedPlan.Controls.Add(this.tabNavigationPagePostRetirementCashFlow);
            this.tabEstimatedPlan.Location = new System.Drawing.Point(6, 87);
            this.tabEstimatedPlan.Name = "tabEstimatedPlan";
            this.tabEstimatedPlan.PageProperties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabEstimatedPlan.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.tabNavigationPageCashFlow,
            this.tabNavigationPageCurrentStatus,
            this.tabNavigationPageGoal,
            this.tabNavigationPagePostRetirementCashFlow});
            this.tabEstimatedPlan.RegularSize = new System.Drawing.Size(1161, 650);
            this.tabEstimatedPlan.SelectedPage = this.tabNavigationPageCashFlow;
            this.tabEstimatedPlan.Size = new System.Drawing.Size(1161, 650);
            this.tabEstimatedPlan.TabIndex = 29;
            this.tabEstimatedPlan.Text = "Estimated Plan";
            this.tabEstimatedPlan.SelectedPageChanged += new DevExpress.XtraBars.Navigation.SelectedPageChangedEventHandler(this.tabEstimatedPlan_SelectedPageChanged);
            this.tabEstimatedPlan.SelectedPageChanging += new DevExpress.XtraBars.Navigation.SelectedPageChangingEventHandler(this.tabEstimatedPlan_SelectedPageChanging);
            // 
            // tabNavigationPageCashFlow
            // 
            this.tabNavigationPageCashFlow.AutoSize = true;
            this.tabNavigationPageCashFlow.Caption = "Cash Flow";
            this.tabNavigationPageCashFlow.Image = ((System.Drawing.Image)(resources.GetObject("tabNavigationPageCashFlow.Image")));
            this.tabNavigationPageCashFlow.ItemShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabNavigationPageCashFlow.Name = "tabNavigationPageCashFlow";
            this.tabNavigationPageCashFlow.Properties.ShowMode = DevExpress.XtraBars.Navigation.ItemShowMode.ImageAndText;
            this.tabNavigationPageCashFlow.Size = new System.Drawing.Size(1143, 602);
            // 
            // tabNavigationPageGoal
            // 
            this.tabNavigationPageGoal.Caption = "Goals";
            this.tabNavigationPageGoal.Image = global::FinancialPlannerClient.Properties.Resources.icons8_goal_16;
            this.tabNavigationPageGoal.Name = "tabNavigationPageGoal";
            this.tabNavigationPageGoal.Size = new System.Drawing.Size(1143, 602);
            // 
            // tabNavigationPageCurrentStatus
            // 
            this.tabNavigationPageCurrentStatus.Caption = "Current Status";
            this.tabNavigationPageCurrentStatus.Image = global::FinancialPlannerClient.Properties.Resources.icons8_date_span_16;
            this.tabNavigationPageCurrentStatus.Name = "tabNavigationPageCurrentStatus";
            this.tabNavigationPageCurrentStatus.Size = new System.Drawing.Size(1161, 650);
            // 
            // tabNavigationPagePostRetirementCashFlow
            // 
            this.tabNavigationPagePostRetirementCashFlow.Caption = "Post Retirement Cash Flow";
            this.tabNavigationPagePostRetirementCashFlow.Image = ((System.Drawing.Image)(resources.GetObject("tabNavigationPagePostRetirementCashFlow.Image")));
            this.tabNavigationPagePostRetirementCashFlow.Name = "tabNavigationPagePostRetirementCashFlow";
            this.tabNavigationPagePostRetirementCashFlow.Size = new System.Drawing.Size(1143, 602);
            // 
            // EstimatedPlan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1179, 749);
            this.Controls.Add(this.tabEstimatedPlan);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.grpPlanOption);
            this.Controls.Add(this.grpPlanDetail);
            this.MinimizeBox = false;
            this.Name = "EstimatedPlan";
            this.Text = "Estimated Plan";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.EstimatedPlan_FormClosed);
            this.Load += new System.EventHandler(this.EstimatedPlan_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cmbPlanOption.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpPlanDetail)).EndInit();
            this.grpPlanDetail.ResumeLayout(false);
            this.grpPlanDetail.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpPlanOption)).EndInit();
            this.grpPlanOption.ResumeLayout(false);
            this.grpPlanOption.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tabEstimatedPlan)).EndInit();
            this.tabEstimatedPlan.ResumeLayout(false);
            this.tabEstimatedPlan.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.ComboBoxEdit cmbPlanOption;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GroupControl grpPlanDetail;
        private System.Windows.Forms.Label lblPlanName;
        private System.Windows.Forms.Label lblPlanPeriod;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.GroupControl grpPlanOption;
        private System.Windows.Forms.Label lblRiskProfileValue;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.SimpleButton btnPlanOptinView;
        private DevExpress.XtraEditors.SimpleButton btnClose;
        private DevExpress.XtraBars.Navigation.TabPane tabEstimatedPlan;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPageCashFlow;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPageGoal;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPageCurrentStatus;
        private System.Windows.Forms.Label lblStartDate;
        private System.Windows.Forms.Label label6;
        private DevExpress.XtraBars.Navigation.TabNavigationPage tabNavigationPagePostRetirementCashFlow;
    }
}

