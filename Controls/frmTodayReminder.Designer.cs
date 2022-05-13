using System;
using System.Runtime.InteropServices;

namespace FinancialPlannerClient.Controls
{
    partial class frmTodayReminder
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
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.grpClient = new DevExpress.XtraEditors.GroupControl();
            this.grdPPF = new DevExpress.XtraGrid.GridControl();
            this.gridViewPPF = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemCheckEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grdBond = new DevExpress.XtraGrid.GridControl();
            this.gridViewBond = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemCheckEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.grdFD = new DevExpress.XtraGrid.GridControl();
            this.gridViewFD = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemCheckEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.btnClose = new DevExpress.XtraEditors.SimpleButton();
            this.btnModify = new DevExpress.XtraEditors.SimpleButton();
            this.grdDOB = new DevExpress.XtraGrid.GridControl();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
            this.groupControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
            this.groupControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpClient)).BeginInit();
            this.grpClient.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdPPF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPPF)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBond)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDOB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupControl1.Controls.Add(this.groupControl4);
            this.groupControl1.Controls.Add(this.groupControl3);
            this.groupControl1.Controls.Add(this.groupControl2);
            this.groupControl1.Controls.Add(this.grpClient);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1097, 455);
            this.groupControl1.TabIndex = 9;
            this.groupControl1.Text = "Reminder";
            // 
            // groupControl4
            // 
            this.groupControl4.Controls.Add(this.grdFD);
            this.groupControl4.Location = new System.Drawing.Point(550, 233);
            this.groupControl4.Name = "groupControl4";
            this.groupControl4.Size = new System.Drawing.Size(539, 210);
            this.groupControl4.TabIndex = 7;
            this.groupControl4.Text = "Fix Deposit";
            // 
            // groupControl3
            // 
            this.groupControl3.Controls.Add(this.grdBond);
            this.groupControl3.Location = new System.Drawing.Point(7, 233);
            this.groupControl3.Name = "groupControl3";
            this.groupControl3.Size = new System.Drawing.Size(537, 210);
            this.groupControl3.TabIndex = 6;
            this.groupControl3.Text = "Bonds";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grdPPF);
            this.groupControl2.Location = new System.Drawing.Point(548, 32);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(541, 195);
            this.groupControl2.TabIndex = 5;
            this.groupControl2.Text = "PPF";
            // 
            // grpClient
            // 
            this.grpClient.Controls.Add(this.grdDOB);
            this.grpClient.Location = new System.Drawing.Point(7, 32);
            this.grpClient.Name = "grpClient";
            this.grpClient.Size = new System.Drawing.Size(537, 195);
            this.grpClient.TabIndex = 4;
            this.grpClient.Text = "Client Birrhday";
            // 
            // grdPPF
            // 
            this.grdPPF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdPPF.Location = new System.Drawing.Point(2, 20);
            this.grdPPF.MainView = this.gridViewPPF;
            this.grdPPF.Name = "grdPPF";
            this.grdPPF.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit2});
            this.grdPPF.Size = new System.Drawing.Size(537, 173);
            this.grdPPF.TabIndex = 6;
            this.grdPPF.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewPPF});
            // 
            // gridViewPPF
            // 
            this.gridViewPPF.GridControl = this.grdPPF;
            this.gridViewPPF.Name = "gridViewPPF";
            this.gridViewPPF.OptionsView.ShowGroupPanel = false;
            // 
            // repositoryItemCheckEdit2
            // 
            this.repositoryItemCheckEdit2.AutoHeight = false;
            this.repositoryItemCheckEdit2.Name = "repositoryItemCheckEdit2";
            // 
            // grdBond
            // 
            this.grdBond.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdBond.Location = new System.Drawing.Point(2, 20);
            this.grdBond.MainView = this.gridViewBond;
            this.grdBond.Name = "grdBond";
            this.grdBond.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit3});
            this.grdBond.Size = new System.Drawing.Size(533, 188);
            this.grdBond.TabIndex = 7;
            this.grdBond.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewBond});
            // 
            // gridViewBond
            // 
            this.gridViewBond.GridControl = this.grdBond;
            this.gridViewBond.Name = "gridViewBond";
            this.gridViewBond.OptionsView.ShowGroupPanel = false;
            // 
            // repositoryItemCheckEdit3
            // 
            this.repositoryItemCheckEdit3.AutoHeight = false;
            this.repositoryItemCheckEdit3.Name = "repositoryItemCheckEdit3";
            // 
            // grdFD
            // 
            this.grdFD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdFD.Location = new System.Drawing.Point(2, 20);
            this.grdFD.MainView = this.gridViewFD;
            this.grdFD.Name = "grdFD";
            this.grdFD.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit4});
            this.grdFD.Size = new System.Drawing.Size(535, 188);
            this.grdFD.TabIndex = 7;
            this.grdFD.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewFD});
            // 
            // gridViewFD
            // 
            this.gridViewFD.GridControl = this.grdFD;
            this.gridViewFD.Name = "gridViewFD";
            this.gridViewFD.OptionsView.ShowGroupPanel = false;
            // 
            // repositoryItemCheckEdit4
            // 
            this.repositoryItemCheckEdit4.AutoHeight = false;
            this.repositoryItemCheckEdit4.Name = "repositoryItemCheckEdit4";
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(520, 473);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(83, 23);
            this.btnClose.TabIndex = 12;
            this.btnClose.Text = "Close";
            this.btnClose.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Application;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnModify
            // 
            this.btnModify.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnModify.Location = new System.Drawing.Point(12, 473);
            this.btnModify.Name = "btnModify";
            this.btnModify.Size = new System.Drawing.Size(92, 23);
            this.btnModify.TabIndex = 13;
            this.btnModify.Text = "Modify Search";
            this.btnModify.ToolTipIconType = DevExpress.Utils.ToolTipIconType.Application;
            this.btnModify.Visible = false;
            this.btnModify.Click += new System.EventHandler(this.btnModify_Click);
            // 
            // grdDOB
            // 
            this.grdDOB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdDOB.Location = new System.Drawing.Point(2, 20);
            this.grdDOB.MainView = this.gridView4;
            this.grdDOB.Name = "grdDOB";
            this.grdDOB.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdDOB.Size = new System.Drawing.Size(533, 173);
            this.grdDOB.TabIndex = 7;
            this.grdDOB.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView4});
            // 
            // gridView4
            // 
            this.gridView4.GridControl = this.grdDOB;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            // 
            // frmTodayReminder
            // 
            this.ClientSize = new System.Drawing.Size(1121, 502);
            this.Controls.Add(this.btnModify);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.groupControl1);
            this.Name = "frmTodayReminder";
            this.Text = "Today\'s Reminder";
            this.Load += new System.EventHandler(this.frmTodayReminder_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
            this.groupControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
            this.groupControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpClient)).EndInit();
            this.grpClient.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdPPF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewPPF)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdBond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewBond)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewFD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdDOB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);
            FlashWindow.Tray(this);
        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GroupControl grpClient;
        private DevExpress.XtraGrid.GridControl grdFD;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewFD;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit4;
        private DevExpress.XtraGrid.GridControl grdBond;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewBond;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit3;
        private DevExpress.XtraGrid.GridControl grdPPF;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewPPF;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit2;
        public DevExpress.XtraEditors.SimpleButton btnClose;
        public DevExpress.XtraEditors.SimpleButton btnModify;
        private DevExpress.XtraGrid.GridControl grdDOB;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }

    public static class FlashWindow
    {
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool FlashWindowEx(ref FLASHWINFO pwfi);

        /// Stop flashing. The system restores the window to its original state.            
        public const uint FLASHW_STOP = 0;

        /// Flash the window caption.            
        public const uint FLASHW_CAPTION = 1;

        /// Flash the taskbar button.            
        public const uint FLASHW_TRAY = 2;

        /// Flash both the window caption and taskbar button.
        /// This is equivalent to setting the FLASHW_CAPTION | FLASHW_TRAY flags.            
        public const uint FLASHW_ALL = 3;

        /// Flash continuously, until the FLASHW_STOP flag is set.            
        public const uint FLASHW_TIMER = 4;

        /// Flash continuously until the window comes to the foreground.            
        public const uint FLASHW_TIMERNOFG = 12;

        [StructLayout(LayoutKind.Sequential)]
        private struct FLASHWINFO
        {

            /// The size of the structure in bytes.
            public uint cbSize;

            /// A Handle to the Window to be Flashed. The window can be either opened or minimized.
            public IntPtr hwnd;

            /// The Flash Status.                
            public uint dwFlags;

            /// The number of times to Flash the window.
            public uint uCount;

            /// The rate at which the Window is to be flashed, in milliseconds. If Zero, the function uses the default cursor blink rate.                
            public uint dwTimeout;
        }

        /// Flash the specified Window (Form) until it receives focus.            
        public static bool Flash(System.Windows.Forms.Form form)
        {
            // Make sure we're running under Windows 2000 or later
            if (Win2000OrLater)
            {
                FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_ALL | FLASHW_TIMERNOFG, uint.MaxValue, 0);
                return FlashWindowEx(ref fi);
            }
            return false;
        }

        /// Flash the specified Window (form) for the specified number of times            
        public static bool Flash(System.Windows.Forms.Form form, uint count)
        {
            if (Win2000OrLater)
            {
                FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_ALL, count, 0);
                return FlashWindowEx(ref fi);
            }
            return false;
        }


        private static FLASHWINFO Create_FLASHWINFO(IntPtr handle, uint flags, uint count, uint timeout)
        {
            FLASHWINFO fi = new FLASHWINFO();
            fi.cbSize = Convert.ToUInt32(Marshal.SizeOf(fi));
            fi.hwnd = handle;
            fi.dwFlags = flags;
            fi.uCount = count;
            fi.dwTimeout = timeout;
            return fi;
        }


        /// helper methods           
        public static bool Tray(System.Windows.Forms.Form form)
        {
            if (Win2000OrLater)
            {
                FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_TRAY, uint.MaxValue, 0);
                return FlashWindowEx(ref fi);
            }
            return false;
        }

        public static bool TrayAndWindow(System.Windows.Forms.Form form)
        {
            if (Win2000OrLater)
            {
                FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_ALL, uint.MaxValue, 0);
                return FlashWindowEx(ref fi);
            }
            return false;
        }


        /// Stop Flashing the specified Window (form)            
        public static bool Stop(System.Windows.Forms.Form form)
        {
            if (Win2000OrLater)
            {
                FLASHWINFO fi = Create_FLASHWINFO(form.Handle, FLASHW_STOP, uint.MaxValue, 0);
                return FlashWindowEx(ref fi);
            }
            return false;
        }


        /// A boolean value indicating whether the application is running on Windows 2000 or later.
        private static bool Win2000OrLater
        {
            get { return System.Environment.OSVersion.Version.Major >= 5; }
        }

    }
}