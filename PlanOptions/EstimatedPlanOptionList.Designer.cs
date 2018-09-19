namespace FinancialPlannerClient.PlanOptions
{
    partial class EstimatedPlanOptionList
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EstimatedPlanOptionList));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.grpActionControls = new System.Windows.Forms.GroupBox();
            this.btnDeleteOption = new System.Windows.Forms.Button();
            this.imgCollection = new System.Windows.Forms.ImageList(this.components);
            this.btnAddPlanOption = new System.Windows.Forms.Button();
            this.btnEditPlanOption = new System.Windows.Forms.Button();
            this.cmbPlanOption = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbPlan = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lblclientNameVal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.CashFlow = new System.Windows.Forms.TabPage();
            this.dtGridCashFlow = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnShowIncomeDetails = new System.Windows.Forms.Button();
            this.txtIncomeTax = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1.SuspendLayout();
            this.grpActionControls.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.CashFlow.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtGridCashFlow)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.grpActionControls);
            this.groupBox1.Controls.Add(this.cmbPlanOption);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmbPlan);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblclientNameVal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1044, 58);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Client With Planner Info";
            // 
            // grpActionControls
            // 
            this.grpActionControls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.grpActionControls.Controls.Add(this.btnDeleteOption);
            this.grpActionControls.Controls.Add(this.btnAddPlanOption);
            this.grpActionControls.Controls.Add(this.btnEditPlanOption);
            this.grpActionControls.Location = new System.Drawing.Point(927, 14);
            this.grpActionControls.Name = "grpActionControls";
            this.grpActionControls.Size = new System.Drawing.Size(111, 38);
            this.grpActionControls.TabIndex = 7;
            this.grpActionControls.TabStop = false;
            // 
            // btnDeleteOption
            // 
            this.btnDeleteOption.ImageIndex = 1;
            this.btnDeleteOption.ImageList = this.imgCollection;
            this.btnDeleteOption.Location = new System.Drawing.Point(76, 10);
            this.btnDeleteOption.Name = "btnDeleteOption";
            this.btnDeleteOption.Size = new System.Drawing.Size(29, 24);
            this.btnDeleteOption.TabIndex = 4;
            this.btnDeleteOption.UseVisualStyleBackColor = true;
            // 
            // imgCollection
            // 
            this.imgCollection.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgCollection.ImageStream")));
            this.imgCollection.TransparentColor = System.Drawing.Color.Transparent;
            this.imgCollection.Images.SetKeyName(0, "Add-Action.png");
            this.imgCollection.Images.SetKeyName(1, "delete.png");
            this.imgCollection.Images.SetKeyName(2, "deleteline.png");
            this.imgCollection.Images.SetKeyName(3, "drop-add.gif");
            this.imgCollection.Images.SetKeyName(4, "Edit.png");
            this.imgCollection.Images.SetKeyName(5, "User.png");
            this.imgCollection.Images.SetKeyName(6, "VirtualUser.png");
            this.imgCollection.Images.SetKeyName(7, "icons8-circled-play-16.png");
            this.imgCollection.Images.SetKeyName(8, "icons8-search-16.png");
            this.imgCollection.Images.SetKeyName(9, "icons8-customer-16.png");
            // 
            // btnAddPlanOption
            // 
            this.btnAddPlanOption.ImageIndex = 3;
            this.btnAddPlanOption.ImageList = this.imgCollection;
            this.btnAddPlanOption.Location = new System.Drawing.Point(6, 10);
            this.btnAddPlanOption.Name = "btnAddPlanOption";
            this.btnAddPlanOption.Size = new System.Drawing.Size(29, 24);
            this.btnAddPlanOption.TabIndex = 2;
            this.btnAddPlanOption.UseVisualStyleBackColor = true;
            this.btnAddPlanOption.Click += new System.EventHandler(this.btnAddPlanOption_Click);
            // 
            // btnEditPlanOption
            // 
            this.btnEditPlanOption.ImageIndex = 4;
            this.btnEditPlanOption.ImageList = this.imgCollection;
            this.btnEditPlanOption.Location = new System.Drawing.Point(41, 10);
            this.btnEditPlanOption.Name = "btnEditPlanOption";
            this.btnEditPlanOption.Size = new System.Drawing.Size(29, 24);
            this.btnEditPlanOption.TabIndex = 3;
            this.btnEditPlanOption.UseVisualStyleBackColor = true;
            this.btnEditPlanOption.Click += new System.EventHandler(this.btnEditPlanOption_Click);
            // 
            // cmbPlanOption
            // 
            this.cmbPlanOption.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlanOption.FormattingEnabled = true;
            this.cmbPlanOption.Location = new System.Drawing.Point(701, 27);
            this.cmbPlanOption.Name = "cmbPlanOption";
            this.cmbPlanOption.Size = new System.Drawing.Size(208, 21);
            this.cmbPlanOption.TabIndex = 5;
            this.cmbPlanOption.SelectedIndexChanged += new System.EventHandler(this.cmbPlanOption_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(630, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Plan Option:";
            // 
            // cmbPlan
            // 
            this.cmbPlan.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPlan.FormattingEnabled = true;
            this.cmbPlan.Location = new System.Drawing.Point(391, 27);
            this.cmbPlan.Name = "cmbPlan";
            this.cmbPlan.Size = new System.Drawing.Size(228, 21);
            this.cmbPlan.TabIndex = 3;
            this.cmbPlan.SelectedIndexChanged += new System.EventHandler(this.cmbPlan_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(333, 30);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Plan Info:";
            // 
            // lblclientNameVal
            // 
            this.lblclientNameVal.AutoSize = true;
            this.lblclientNameVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblclientNameVal.ForeColor = System.Drawing.Color.Maroon;
            this.lblclientNameVal.Location = new System.Drawing.Point(69, 29);
            this.lblclientNameVal.Name = "lblclientNameVal";
            this.lblclientNameVal.Size = new System.Drawing.Size(65, 16);
            this.lblclientNameVal.TabIndex = 1;
            this.lblclientNameVal.Text = "#Name#";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Client :";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.CashFlow);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 77);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1044, 277);
            this.tabControl1.TabIndex = 2;
            // 
            // CashFlow
            // 
            this.CashFlow.Controls.Add(this.dtGridCashFlow);
            this.CashFlow.Controls.Add(this.groupBox2);
            this.CashFlow.Location = new System.Drawing.Point(4, 22);
            this.CashFlow.Name = "CashFlow";
            this.CashFlow.Padding = new System.Windows.Forms.Padding(3);
            this.CashFlow.Size = new System.Drawing.Size(1036, 251);
            this.CashFlow.TabIndex = 0;
            this.CashFlow.Text = "Cash Flow";
            this.CashFlow.UseVisualStyleBackColor = true;
            // 
            // dtGridCashFlow
            // 
            this.dtGridCashFlow.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dtGridCashFlow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridCashFlow.Location = new System.Drawing.Point(6, 53);
            this.dtGridCashFlow.Name = "dtGridCashFlow";
            this.dtGridCashFlow.Size = new System.Drawing.Size(1022, 195);
            this.dtGridCashFlow.TabIndex = 1;
            this.dtGridCashFlow.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtGridCashFlow_CellEndEdit);
            this.dtGridCashFlow.CellValidating += new System.Windows.Forms.DataGridViewCellValidatingEventHandler(this.dtGridCashFlow_CellValidating);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnShowIncomeDetails);
            this.groupBox2.Controls.Add(this.txtIncomeTax);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(8, 7);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1020, 40);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // btnShowIncomeDetails
            // 
            this.btnShowIncomeDetails.Location = new System.Drawing.Point(201, 10);
            this.btnShowIncomeDetails.Name = "btnShowIncomeDetails";
            this.btnShowIncomeDetails.Size = new System.Drawing.Size(134, 23);
            this.btnShowIncomeDetails.TabIndex = 2;
            this.btnShowIncomeDetails.Text = "Show Income Details";
            this.btnShowIncomeDetails.UseVisualStyleBackColor = true;
            this.btnShowIncomeDetails.Click += new System.EventHandler(this.btnShowIncomeDetails_Click);
            // 
            // txtIncomeTax
            // 
            this.txtIncomeTax.Location = new System.Drawing.Point(95, 13);
            this.txtIncomeTax.Name = "txtIncomeTax";
            this.txtIncomeTax.Size = new System.Drawing.Size(100, 20);
            this.txtIncomeTax.TabIndex = 1;
            this.txtIncomeTax.Text = "10";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Income Tax (%):";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1036, 251);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "tabPage2";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // EstimatedPlanOptionList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 356);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Name = "EstimatedPlanOptionList";
            this.Text = "EstimatedPlanOptionList";
            this.Load += new System.EventHandler(this.EstimatedPlanOptionList_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpActionControls.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.CashFlow.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridCashFlow)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbPlanOption;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbPlan;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblclientNameVal;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpActionControls;
        private System.Windows.Forms.Button btnDeleteOption;
        private System.Windows.Forms.Button btnAddPlanOption;
        private System.Windows.Forms.Button btnEditPlanOption;
        private System.Windows.Forms.ImageList imgCollection;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage CashFlow;
        private System.Windows.Forms.DataGridView dtGridCashFlow;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnShowIncomeDetails;
        private System.Windows.Forms.TextBox txtIncomeTax;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage2;
    }
}