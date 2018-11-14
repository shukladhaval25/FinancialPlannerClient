namespace FinancialPlannerClient.Master
{
    partial class Others
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Others));
            this.dtGridOther = new System.Windows.Forms.DataGridView();
            this.grpOtherControls = new System.Windows.Forms.GroupBox();
            this.btnDeleteOther = new System.Windows.Forms.Button();
            this.btnAddOther = new System.Windows.Forms.Button();
            this.imgCollection = new System.Windows.Forms.ImageList(this.components);
            this.grpItem = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblReligion = new System.Windows.Forms.Label();
            this.txtReligion = new System.Windows.Forms.TextBox();
            this.btnOtherCancel = new System.Windows.Forms.Button();
            this.btnOtherSave = new System.Windows.Forms.Button();
            this.imageList16x16 = new System.Windows.Forms.ImageList(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dtGridOther)).BeginInit();
            this.grpOtherControls.SuspendLayout();
            this.grpItem.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtGridOther
            // 
            this.dtGridOther.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtGridOther.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dtGridOther.Location = new System.Drawing.Point(12, 24);
            this.dtGridOther.Name = "dtGridOther";
            this.dtGridOther.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtGridOther.Size = new System.Drawing.Size(282, 289);
            this.dtGridOther.TabIndex = 0;
            this.dtGridOther.SelectionChanged += new System.EventHandler(this.dtGridOther_SelectionChanged);
            // 
            // grpOtherControls
            // 
            this.grpOtherControls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpOtherControls.Controls.Add(this.btnDeleteOther);
            this.grpOtherControls.Controls.Add(this.btnAddOther);
            this.grpOtherControls.Location = new System.Drawing.Point(215, 319);
            this.grpOtherControls.Name = "grpOtherControls";
            this.grpOtherControls.Size = new System.Drawing.Size(79, 38);
            this.grpOtherControls.TabIndex = 3;
            this.grpOtherControls.TabStop = false;
            // 
            // btnDeleteOther
            // 
            this.btnDeleteOther.ImageIndex = 1;
            this.btnDeleteOther.ImageList = this.imgCollection;
            this.btnDeleteOther.Location = new System.Drawing.Point(41, 10);
            this.btnDeleteOther.Name = "btnDeleteOther";
            this.btnDeleteOther.Size = new System.Drawing.Size(29, 24);
            this.btnDeleteOther.TabIndex = 4;
            this.btnDeleteOther.UseVisualStyleBackColor = true;
            this.btnDeleteOther.Click += new System.EventHandler(this.btnDeleteOther_Click);
            // 
            // btnAddOther
            // 
            this.btnAddOther.ImageIndex = 3;
            this.btnAddOther.ImageList = this.imgCollection;
            this.btnAddOther.Location = new System.Drawing.Point(6, 10);
            this.btnAddOther.Name = "btnAddOther";
            this.btnAddOther.Size = new System.Drawing.Size(29, 24);
            this.btnAddOther.TabIndex = 2;
            this.btnAddOther.UseVisualStyleBackColor = true;
            this.btnAddOther.Click += new System.EventHandler(this.btnAddOther_Click);
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
            this.imgCollection.Images.SetKeyName(7, "Run.png");
            this.imgCollection.Images.SetKeyName(8, "icons8-search-16.png");
            this.imgCollection.Images.SetKeyName(9, "icons8-customer-16.png");
            // 
            // grpItem
            // 
            this.grpItem.Controls.Add(this.btnOtherCancel);
            this.grpItem.Controls.Add(this.btnOtherSave);
            this.grpItem.Controls.Add(this.txtReligion);
            this.grpItem.Controls.Add(this.lblReligion);
            this.grpItem.Controls.Add(this.txtName);
            this.grpItem.Controls.Add(this.label1);
            this.grpItem.Enabled = false;
            this.grpItem.Location = new System.Drawing.Point(310, 17);
            this.grpItem.Name = "grpItem";
            this.grpItem.Size = new System.Drawing.Size(322, 119);
            this.grpItem.TabIndex = 4;
            this.grpItem.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name :";
            // 
            // txtName
            // 
            this.txtName.Location = new System.Drawing.Point(86, 26);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(212, 20);
            this.txtName.TabIndex = 1;
            // 
            // lblReligion
            // 
            this.lblReligion.AutoSize = true;
            this.lblReligion.Location = new System.Drawing.Point(32, 55);
            this.lblReligion.Name = "lblReligion";
            this.lblReligion.Size = new System.Drawing.Size(48, 13);
            this.lblReligion.TabIndex = 2;
            this.lblReligion.Text = "Religion:";
            // 
            // txtReligion
            // 
            this.txtReligion.Location = new System.Drawing.Point(86, 52);
            this.txtReligion.Name = "txtReligion";
            this.txtReligion.Size = new System.Drawing.Size(212, 20);
            this.txtReligion.TabIndex = 3;
            // 
            // btnOtherCancel
            // 
            this.btnOtherCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOtherCancel.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOtherCancel.ImageKey = "icons8-cancel-16.png";
            this.btnOtherCancel.ImageList = this.imageList16x16;
            this.btnOtherCancel.Location = new System.Drawing.Point(212, 83);
            this.btnOtherCancel.Name = "btnOtherCancel";
            this.btnOtherCancel.Size = new System.Drawing.Size(86, 26);
            this.btnOtherCancel.TabIndex = 17;
            this.btnOtherCancel.Text = "Cancel";
            this.btnOtherCancel.UseVisualStyleBackColor = true;
            this.btnOtherCancel.Click += new System.EventHandler(this.btnOtherCancel_Click);
            // 
            // btnOtherSave
            // 
            this.btnOtherSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOtherSave.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnOtherSave.ImageKey = "icons8-save-close-16.png";
            this.btnOtherSave.ImageList = this.imageList16x16;
            this.btnOtherSave.Location = new System.Drawing.Point(120, 83);
            this.btnOtherSave.Name = "btnOtherSave";
            this.btnOtherSave.Size = new System.Drawing.Size(86, 26);
            this.btnOtherSave.TabIndex = 16;
            this.btnOtherSave.Text = "Save";
            this.btnOtherSave.UseVisualStyleBackColor = true;
            this.btnOtherSave.Click += new System.EventHandler(this.btnOtherSave_Click);
            // 
            // imageList16x16
            // 
            this.imageList16x16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList16x16.ImageStream")));
            this.imageList16x16.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList16x16.Images.SetKeyName(0, "icons8-contact-details-16-2.png");
            this.imageList16x16.Images.SetKeyName(1, "icons8-resume-16.png");
            this.imageList16x16.Images.SetKeyName(2, "icons8-customer-16.png");
            this.imageList16x16.Images.SetKeyName(3, "icons8-cancel-16.png");
            this.imageList16x16.Images.SetKeyName(4, "icons8-save-close-16.png");
            // 
            // Others
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 364);
            this.Controls.Add(this.grpItem);
            this.Controls.Add(this.grpOtherControls);
            this.Controls.Add(this.dtGridOther);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Others";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Others";
            ((System.ComponentModel.ISupportInitialize)(this.dtGridOther)).EndInit();
            this.grpOtherControls.ResumeLayout(false);
            this.grpItem.ResumeLayout(false);
            this.grpItem.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox grpOtherControls;
        private System.Windows.Forms.Button btnDeleteOther;
        private System.Windows.Forms.Button btnAddOther;
        private System.Windows.Forms.ImageList imgCollection;
        private System.Windows.Forms.GroupBox grpItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtReligion;
        private System.Windows.Forms.Label lblReligion;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Button btnOtherCancel;
        private System.Windows.Forms.Button btnOtherSave;
        private System.Windows.Forms.ImageList imageList16x16;
        internal System.Windows.Forms.DataGridView dtGridOther;
    }
}