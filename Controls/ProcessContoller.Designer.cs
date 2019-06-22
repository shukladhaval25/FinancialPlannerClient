namespace FinancialPlannerClient.Controls
{
    partial class ProcessContoller
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.flowLayoutPanelProcessActions = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanelProcessActions
            // 
            this.flowLayoutPanelProcessActions.AllowDrop = true;
            this.flowLayoutPanelProcessActions.AutoScroll = true;
            this.flowLayoutPanelProcessActions.AutoSize = true;
            this.flowLayoutPanelProcessActions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelProcessActions.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelProcessActions.Name = "flowLayoutPanelProcessActions";
            this.flowLayoutPanelProcessActions.Size = new System.Drawing.Size(150, 150);
            this.flowLayoutPanelProcessActions.TabIndex = 0;
            this.flowLayoutPanelProcessActions.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.flowLayoutPanelProcessActions_ControlAdded);
            this.flowLayoutPanelProcessActions.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.flowLayoutPanelProcessActions_ControlRemoved);
            // 
            // ProcessContoller
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanelProcessActions);
            this.Name = "ProcessContoller";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelProcessActions;
    }
}
