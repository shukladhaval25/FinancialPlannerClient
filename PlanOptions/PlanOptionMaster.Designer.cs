namespace FinancialPlannerClient.PlanOptions
{
    partial class PlanOptionMaster
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGenInsCancel = new System.Windows.Forms.Button();
            this.btnGenInsSave = new System.Windows.Forms.Button();
            this.txtOptionName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblPlanVal = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lblclientNameVal = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGenInsCancel);
            this.groupBox1.Controls.Add(this.btnGenInsSave);
            this.groupBox1.Controls.Add(this.txtOptionName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.lblPlanVal);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lblclientNameVal);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(331, 154);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // btnGenInsCancel
            // 
            this.btnGenInsCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenInsCancel.ImageKey = "icons8-cancel-16.png";
            this.btnGenInsCancel.Location = new System.Drawing.Point(191, 110);
            this.btnGenInsCancel.Name = "btnGenInsCancel";
            this.btnGenInsCancel.Size = new System.Drawing.Size(86, 26);
            this.btnGenInsCancel.TabIndex = 10;
            this.btnGenInsCancel.Text = "Cancel";
            this.btnGenInsCancel.UseVisualStyleBackColor = true;
            this.btnGenInsCancel.Click += new System.EventHandler(this.btnGenInsCancel_Click);
            // 
            // btnGenInsSave
            // 
            this.btnGenInsSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnGenInsSave.ImageKey = "icons8-save-close-16.png";
            this.btnGenInsSave.Location = new System.Drawing.Point(99, 110);
            this.btnGenInsSave.Name = "btnGenInsSave";
            this.btnGenInsSave.Size = new System.Drawing.Size(86, 26);
            this.btnGenInsSave.TabIndex = 9;
            this.btnGenInsSave.Text = "Save";
            this.btnGenInsSave.UseVisualStyleBackColor = true;
            this.btnGenInsSave.Click += new System.EventHandler(this.btnGenInsSave_Click);
            // 
            // txtOptionName
            // 
            this.txtOptionName.Location = new System.Drawing.Point(124, 74);
            this.txtOptionName.Name = "txtOptionName";
            this.txtOptionName.Size = new System.Drawing.Size(182, 20);
            this.txtOptionName.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Option Name :";
            // 
            // lblPlanVal
            // 
            this.lblPlanVal.AutoSize = true;
            this.lblPlanVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPlanVal.ForeColor = System.Drawing.Color.Maroon;
            this.lblPlanVal.Location = new System.Drawing.Point(66, 46);
            this.lblPlanVal.Name = "lblPlanVal";
            this.lblPlanVal.Size = new System.Drawing.Size(55, 16);
            this.lblPlanVal.TabIndex = 5;
            this.lblPlanVal.Text = "#Plan#";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 46);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Plan:";
            // 
            // lblclientNameVal
            // 
            this.lblclientNameVal.AutoSize = true;
            this.lblclientNameVal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblclientNameVal.ForeColor = System.Drawing.Color.Maroon;
            this.lblclientNameVal.Location = new System.Drawing.Point(66, 16);
            this.lblclientNameVal.Name = "lblclientNameVal";
            this.lblclientNameVal.Size = new System.Drawing.Size(65, 16);
            this.lblclientNameVal.TabIndex = 3;
            this.lblclientNameVal.Text = "#Name#";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "Client :";
            // 
            // PlanOptionMaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 175);
            this.ControlBox = false;
            this.Controls.Add(this.groupBox1);
            this.Name = "PlanOptionMaster";
            this.Text = "Plan Option";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnGenInsCancel;
        private System.Windows.Forms.Button btnGenInsSave;
        internal System.Windows.Forms.TextBox txtOptionName;
        internal System.Windows.Forms.Label lblclientNameVal;
        internal System.Windows.Forms.Label lblPlanVal;
    }
}