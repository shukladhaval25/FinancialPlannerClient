namespace FinancialPlannerClient.TaskManagementSystem
{
    partial class TaskCommentView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TaskCommentView));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.txtComment = new DevExpress.XtraEditors.MemoEdit();
            this.btnCloseTask = new DevExpress.XtraEditors.SimpleButton();
            this.btnSaveTask = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.txtComment);
            this.groupControl1.Location = new System.Drawing.Point(13, 13);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(560, 100);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Comment";
            // 
            // txtComment
            // 
            this.txtComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtComment.EditValue = "";
            this.txtComment.Location = new System.Drawing.Point(2, 20);
            this.txtComment.Name = "txtComment";
            this.txtComment.Size = new System.Drawing.Size(556, 78);
            this.txtComment.TabIndex = 0;
            // 
            // btnCloseTask
            // 
            this.btnCloseTask.Image = ((System.Drawing.Image)(resources.GetObject("btnCloseTask.Image")));
            this.btnCloseTask.Location = new System.Drawing.Point(511, 119);
            this.btnCloseTask.Name = "btnCloseTask";
            this.btnCloseTask.Size = new System.Drawing.Size(62, 23);
            toolTipTitleItem1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            toolTipTitleItem1.Appearance.Options.UseImage = true;
            toolTipTitleItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem1.Image")));
            toolTipTitleItem1.Text = "Cancel";
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "To close comment without saving any information click here.";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.btnCloseTask.SuperTip = superToolTip1;
            this.btnCloseTask.TabIndex = 50;
            this.btnCloseTask.Text = "&Close";
            this.btnCloseTask.Click += new System.EventHandler(this.btnCloseTask_Click);
            // 
            // btnSaveTask
            // 
            this.btnSaveTask.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveTask.Image")));
            this.btnSaveTask.Location = new System.Drawing.Point(448, 119);
            this.btnSaveTask.Name = "btnSaveTask";
            this.btnSaveTask.Size = new System.Drawing.Size(57, 23);
            toolTipTitleItem2.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            toolTipTitleItem2.Appearance.Options.UseImage = true;
            toolTipTitleItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem2.Image")));
            toolTipTitleItem2.Text = "Save";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "To save comment click here.";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.btnSaveTask.SuperTip = superToolTip2;
            this.btnSaveTask.TabIndex = 49;
            this.btnSaveTask.Text = "&Save";
            this.btnSaveTask.Click += new System.EventHandler(this.btnSaveTask_Click);
            // 
            // TaskCommentView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 150);
            this.Controls.Add(this.btnCloseTask);
            this.Controls.Add(this.btnSaveTask);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "TaskCommentView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Task Comment";
            this.Load += new System.EventHandler(this.TaskComment_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtComment.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.MemoEdit txtComment;
        private DevExpress.XtraEditors.SimpleButton btnCloseTask;
        private DevExpress.XtraEditors.SimpleButton btnSaveTask;
    }
}