﻿using DevExpress.XtraEditors;
using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.AuditTrail;
using FinancialPlannerClient.Master;
using FinancialPlannerClient.Master.TaskMaster;
using FinancialPlannerClient.ProspectCustomer;
using FinancialPlannerClient.TaskManagementSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinancialPlannerClient.Home
{
    public class frmHome : XtraForm
    {
        private DevExpress.Utils.ImageCollection imageCollection1;
        private PanelControl panelControl1;
        private DevExpress.XtraNavBar.NavBarItem navBarItemCRMGroup;
        private DevExpress.XtraNavBar.NavBarItem navBarItemFestivals;
        private DevExpress.XtraNavBar.NavBarItem navItemProcessAction;
        private DevExpress.XtraNavBar.NavBarSeparatorItem navBarSeparatorItem1;
        private DevExpress.XtraNavBar.NavBarGroup mavBarMasterGroup;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroupClient;
        private DevExpress.XtraNavBar.NavBarControl navBarMenuGroup;
        private DevExpress.XtraBars.Navigation.NavigationFrame navigationFrame1;
        private DevExpress.XtraBars.Navigation.NavigationPage homeNavigationPage1;
        private DevExpress.XtraBars.Navigation.NavigationPage navigationMasterPage;
        private SimpleButton btnLogout;
        private PanelControl panelControl2;
        private PictureEdit pictureEdit1;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraNavBar.NavBarItem navBarItemClient;
        private DevExpress.XtraNavBar.NavBarItem navBarItemFinancialPlanner;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroupSetting;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private System.ComponentModel.IContainer components;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.SkinRibbonGalleryBarItem skinRibbonGalleryBarItem1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage4;
        private DevExpress.XtraNavBar.NavBarItem navBarItem2;
        private DevExpress.XtraNavBar.NavBarSeparatorItem navBarSeparatorItem2;
        private DevExpress.XtraNavBar.NavBarItem navBarItemOld;
        private DevExpress.XtraNavBar.NavBarItem navBarItemArea;
        private DevExpress.XtraNavBar.NavBarGroup navBarGroupOthers;
        private DevExpress.XtraNavBar.NavBarItem navBarItemAuditTrail;
        private DevExpress.XtraNavBar.NavBarItem navBarItemAssumptionMaster;
        private DevExpress.XtraNavBar.NavBarItem navBarItemProspectCustomer;
        private DevExpress.XtraNavBar.NavBarItem navBarItemClientRating;
        private DevExpress.XtraNavBar.NavBarItem navBarItemTask;
        public System.Windows.Forms.NotifyIcon notifyIconTask;
        private DevExpress.XtraNavBar.NavBarItem navBarItemARN;
        private DevExpress.XtraNavBar.NavBarItem navBarItemMFScheme;
        private LabelControl lblCurrentUser;
        private DevExpress.XtraNavBar.NavBarItem navBarItemAMC;
        private System.Windows.Forms.Timer timerNotification;
        private const string AUDITLOGCONTROLLER = "Activities/Add";

        public frmHome()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHome));
            DevExpress.Utils.SuperToolTip superToolTip12 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem15 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem11 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip13 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem16 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem12 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip14 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem17 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem13 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.ToolTipSeparatorItem toolTipSeparatorItem4 = new DevExpress.Utils.ToolTipSeparatorItem();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem18 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip19 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem25 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip15 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem19 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem14 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip16 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem20 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem15 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.ToolTipSeparatorItem toolTipSeparatorItem5 = new DevExpress.Utils.ToolTipSeparatorItem();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem21 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip17 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem22 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem16 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.ToolTipSeparatorItem toolTipSeparatorItem6 = new DevExpress.Utils.ToolTipSeparatorItem();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem23 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip18 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem24 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem17 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip20 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem26 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem18 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip21 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem27 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem19 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip22 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem28 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem20 = new DevExpress.Utils.ToolTipItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblCurrentUser = new DevExpress.XtraEditors.LabelControl();
            this.btnLogout = new DevExpress.XtraEditors.SimpleButton();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.navBarItemCRMGroup = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemFestivals = new DevExpress.XtraNavBar.NavBarItem();
            this.navItemProcessAction = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarSeparatorItem1 = new DevExpress.XtraNavBar.NavBarSeparatorItem();
            this.mavBarMasterGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarSeparatorItem2 = new DevExpress.XtraNavBar.NavBarSeparatorItem();
            this.navBarItemArea = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemAssumptionMaster = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemClientRating = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemARN = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemMFScheme = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemAMC = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroupClient = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItemProspectCustomer = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemClient = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemFinancialPlanner = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarMenuGroup = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroupSetting = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItemOld = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemTask = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarGroupOthers = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItemAuditTrail = new DevExpress.XtraNavBar.NavBarItem();
            this.navigationFrame1 = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.homeNavigationPage1 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationMasterPage = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage4 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.notifyIconTask = new System.Windows.Forms.NotifyIcon(this.components);
            this.timerNotification = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarMenuGroup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).BeginInit();
            this.navigationFrame1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // imageCollection1
            // 
            this.imageCollection1.ImageSize = new System.Drawing.Size(32, 32);
            this.imageCollection1.ImageStream = ((DevExpress.Utils.ImageCollectionStreamer)(resources.GetObject("imageCollection1.ImageStream")));
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblCurrentUser);
            this.panelControl1.Controls.Add(this.btnLogout);
            this.panelControl1.Controls.Add(this.pictureEdit1);
            this.panelControl1.Controls.Add(this.ribbonControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(939, 47);
            this.panelControl1.TabIndex = 0;
            // 
            // lblCurrentUser
            // 
            this.lblCurrentUser.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrentUser.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentUser.Appearance.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblCurrentUser.Appearance.Options.UseFont = true;
            this.lblCurrentUser.Appearance.Options.UseImageAlign = true;
            this.lblCurrentUser.Appearance.Options.UseTextOptions = true;
            this.lblCurrentUser.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblCurrentUser.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.lblCurrentUser.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblCurrentUser.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.lblCurrentUser.Location = new System.Drawing.Point(766, 15);
            this.lblCurrentUser.Name = "lblCurrentUser";
            this.lblCurrentUser.Size = new System.Drawing.Size(127, 0);
            this.lblCurrentUser.TabIndex = 3;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.Image = global::FinancialPlannerClient.Properties.Resources.shutdown_301;
            this.btnLogout.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleCenter;
            this.btnLogout.Location = new System.Drawing.Point(899, 6);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(35, 36);
            this.btnLogout.TabIndex = 1;
            this.btnLogout.Text = "Logout";
            this.btnLogout.ToolTip = "Logout";
            this.btnLogout.Click += new System.EventHandler(this.Logout_Click);
            // 
            // pictureEdit1
            // 
            this.behaviorManager1.SetBehaviors(this.pictureEdit1, new DevExpress.Utils.Behaviors.Behavior[] {
            ((DevExpress.Utils.Behaviors.Behavior)(DevExpress.Utils.Behaviors.Common.BannerBehavior.Create(typeof(DevExpress.XtraEditors.Behaviors.BannerBehaviorSourceForPictureEdit), 10000, true, new System.Drawing.Image[0])))});
            this.pictureEdit1.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit1.EditValue = ((object)(resources.GetObject("pictureEdit1.EditValue")));
            this.pictureEdit1.Location = new System.Drawing.Point(2, 2);
            this.pictureEdit1.Name = "pictureEdit1";
            this.pictureEdit1.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit1.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            this.pictureEdit1.Properties.ZoomAccelerationFactor = 1D;
            this.pictureEdit1.Size = new System.Drawing.Size(138, 43);
            this.pictureEdit1.TabIndex = 0;
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ribbonControl1.Dock = System.Windows.Forms.DockStyle.None;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.skinRibbonGalleryBarItem1});
            this.ribbonControl1.Location = new System.Drawing.Point(143, 2);
            this.ribbonControl1.MaxItemId = 2;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.QuickToolbarItemLinks.Add(this.skinRibbonGalleryBarItem1);
            this.ribbonControl1.ShowQatLocationSelector = false;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.Size = new System.Drawing.Size(796, 47);
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            // 
            // skinRibbonGalleryBarItem1
            // 
            this.skinRibbonGalleryBarItem1.Caption = "skinRibbonGalleryBarItem1";
            this.skinRibbonGalleryBarItem1.Id = 1;
            this.skinRibbonGalleryBarItem1.Name = "skinRibbonGalleryBarItem1";
            // 
            // navBarItemCRMGroup
            // 
            this.navBarItemCRMGroup.Caption = "CRM Group";
            this.navBarItemCRMGroup.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarItemCRMGroup.LargeImage")));
            this.navBarItemCRMGroup.Name = "navBarItemCRMGroup";
            this.navBarItemCRMGroup.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItemCRMGroup.SmallImage")));
            toolTipTitleItem15.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            toolTipTitleItem15.Appearance.Options.UseImage = true;
            toolTipTitleItem15.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem15.Image")));
            toolTipTitleItem15.Text = "CRM Group";
            toolTipItem11.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            toolTipItem11.Appearance.Options.UseImage = true;
            toolTipItem11.Image = ((System.Drawing.Image)(resources.GetObject("toolTipItem11.Image")));
            toolTipItem11.LeftIndent = 6;
            toolTipItem11.Text = "To view or modify CRM Group click here.";
            superToolTip12.Items.Add(toolTipTitleItem15);
            superToolTip12.Items.Add(toolTipItem11);
            this.navBarItemCRMGroup.SuperTip = superToolTip12;
            this.navBarItemCRMGroup.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemCRMGroup_LinkClicked);
            // 
            // navBarItemFestivals
            // 
            this.navBarItemFestivals.Caption = "Festivals";
            this.navBarItemFestivals.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarItemFestivals.LargeImage")));
            this.navBarItemFestivals.Name = "navBarItemFestivals";
            this.navBarItemFestivals.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItemFestivals.SmallImage")));
            toolTipTitleItem16.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            toolTipTitleItem16.Appearance.Options.UseImage = true;
            toolTipTitleItem16.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem16.Image")));
            toolTipTitleItem16.Text = "Festivals";
            toolTipItem12.LeftIndent = 6;
            toolTipItem12.Text = "To view or modify festivals click here.";
            superToolTip13.Items.Add(toolTipTitleItem16);
            superToolTip13.Items.Add(toolTipItem12);
            this.navBarItemFestivals.SuperTip = superToolTip13;
            this.navBarItemFestivals.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemFestivals_LinkClicked);
            // 
            // navItemProcessAction
            // 
            this.navItemProcessAction.Caption = "Planner Process";
            this.navItemProcessAction.LargeImage = ((System.Drawing.Image)(resources.GetObject("navItemProcessAction.LargeImage")));
            this.navItemProcessAction.Name = "navItemProcessAction";
            toolTipTitleItem17.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            toolTipTitleItem17.Appearance.Options.UseImage = true;
            toolTipTitleItem17.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem17.Image")));
            toolTipTitleItem17.Text = "Process";
            toolTipItem13.LeftIndent = 6;
            toolTipItem13.Text = "To view or modify process click here.";
            toolTipTitleItem18.LeftIndent = 6;
            toolTipTitleItem18.Text = "You can define process name and later it can be assign to sequence of process.";
            superToolTip14.Items.Add(toolTipTitleItem17);
            superToolTip14.Items.Add(toolTipItem13);
            superToolTip14.Items.Add(toolTipSeparatorItem4);
            superToolTip14.Items.Add(toolTipTitleItem18);
            this.navItemProcessAction.SuperTip = superToolTip14;
            this.navItemProcessAction.Visible = false;
            this.navItemProcessAction.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navItemProcessAction_LinkClicked);
            // 
            // navBarSeparatorItem1
            // 
            this.navBarSeparatorItem1.CanDrag = false;
            this.navBarSeparatorItem1.Enabled = false;
            this.navBarSeparatorItem1.Hint = null;
            this.navBarSeparatorItem1.LargeImageIndex = 0;
            this.navBarSeparatorItem1.LargeImageSize = new System.Drawing.Size(0, 0);
            this.navBarSeparatorItem1.Name = "navBarSeparatorItem1";
            this.navBarSeparatorItem1.SmallImageIndex = 0;
            this.navBarSeparatorItem1.SmallImageSize = new System.Drawing.Size(0, 0);
            // 
            // mavBarMasterGroup
            // 
            this.mavBarMasterGroup.Caption = "Masters";
            this.mavBarMasterGroup.Expanded = true;
            this.mavBarMasterGroup.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.mavBarMasterGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemCRMGroup),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemFestivals),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarSeparatorItem2),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemArea),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemAssumptionMaster),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemClientRating),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navItemProcessAction),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarSeparatorItem1),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem2),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemARN),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemMFScheme),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemAMC)});
            this.mavBarMasterGroup.LargeImage = ((System.Drawing.Image)(resources.GetObject("mavBarMasterGroup.LargeImage")));
            this.mavBarMasterGroup.Name = "mavBarMasterGroup";
            this.mavBarMasterGroup.SmallImage = ((System.Drawing.Image)(resources.GetObject("mavBarMasterGroup.SmallImage")));
            toolTipTitleItem25.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image6")));
            toolTipTitleItem25.Appearance.Options.UseImage = true;
            toolTipTitleItem25.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem25.Image")));
            superToolTip19.Items.Add(toolTipTitleItem25);
            this.mavBarMasterGroup.SuperTip = superToolTip19;
            // 
            // navBarSeparatorItem2
            // 
            this.navBarSeparatorItem2.CanDrag = false;
            this.navBarSeparatorItem2.Enabled = false;
            this.navBarSeparatorItem2.Hint = null;
            this.navBarSeparatorItem2.LargeImageIndex = 0;
            this.navBarSeparatorItem2.LargeImageSize = new System.Drawing.Size(0, 0);
            this.navBarSeparatorItem2.Name = "navBarSeparatorItem2";
            this.navBarSeparatorItem2.SmallImageIndex = 0;
            this.navBarSeparatorItem2.SmallImageSize = new System.Drawing.Size(0, 0);
            // 
            // navBarItemArea
            // 
            this.navBarItemArea.Caption = "Area";
            this.navBarItemArea.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarItemArea.LargeImage")));
            this.navBarItemArea.Name = "navBarItemArea";
            this.navBarItemArea.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemAre_LinkClicked);
            // 
            // navBarItemAssumptionMaster
            // 
            this.navBarItemAssumptionMaster.Caption = "Assumption Master";
            this.navBarItemAssumptionMaster.Hint = "Assumption Master";
            this.navBarItemAssumptionMaster.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarItemAssumptionMaster.LargeImage")));
            this.navBarItemAssumptionMaster.Name = "navBarItemAssumptionMaster";
            toolTipTitleItem19.Text = "Assumpiton Master";
            toolTipItem14.LeftIndent = 6;
            toolTipItem14.Text = "To view or modify assumpiton master information. Master entry will be reflace at " +
    "other places in applicaiton.";
            superToolTip15.Items.Add(toolTipTitleItem19);
            superToolTip15.Items.Add(toolTipItem14);
            this.navBarItemAssumptionMaster.SuperTip = superToolTip15;
            this.navBarItemAssumptionMaster.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemAssumptionMaster_LinkClicked);
            // 
            // navBarItemClientRating
            // 
            this.navBarItemClientRating.Caption = "Rating";
            this.navBarItemClientRating.LargeImage = global::FinancialPlannerClient.Properties.Resources.newcontact_32x321;
            this.navBarItemClientRating.Name = "navBarItemClientRating";
            toolTipTitleItem20.Appearance.Image = global::FinancialPlannerClient.Properties.Resources.newcontact_32x32;
            toolTipTitleItem20.Appearance.Options.UseImage = true;
            toolTipTitleItem20.Image = global::FinancialPlannerClient.Properties.Resources.newcontact_32x32;
            toolTipTitleItem20.Text = "Client Rating";
            toolTipItem15.LeftIndent = 6;
            toolTipItem15.Text = "To add or edit client rating master click here.";
            toolTipTitleItem21.LeftIndent = 6;
            toolTipTitleItem21.Text = "You can create master for rating.";
            superToolTip16.Items.Add(toolTipTitleItem20);
            superToolTip16.Items.Add(toolTipItem15);
            superToolTip16.Items.Add(toolTipSeparatorItem5);
            superToolTip16.Items.Add(toolTipTitleItem21);
            this.navBarItemClientRating.SuperTip = superToolTip16;
            this.navBarItemClientRating.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemClientRating_LinkClicked);
            // 
            // navBarItem2
            // 
            this.navBarItem2.Caption = "Complete Process";
            this.navBarItem2.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarItem2.LargeImage")));
            this.navBarItem2.Name = "navBarItem2";
            toolTipTitleItem22.Text = "Complete Process";
            toolTipItem16.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image4")));
            toolTipItem16.Appearance.Options.UseImage = true;
            toolTipItem16.Image = ((System.Drawing.Image)(resources.GetObject("toolTipItem16.Image")));
            toolTipItem16.LeftIndent = 6;
            toolTipItem16.Text = "To create or modify complete process infromation click here.";
            toolTipTitleItem23.LeftIndent = 6;
            toolTipTitleItem23.Text = "You can define one process and add sequence of action to complete on process.";
            superToolTip17.Items.Add(toolTipTitleItem22);
            superToolTip17.Items.Add(toolTipItem16);
            superToolTip17.Items.Add(toolTipSeparatorItem6);
            superToolTip17.Items.Add(toolTipTitleItem23);
            this.navBarItem2.SuperTip = superToolTip17;
            this.navBarItem2.Visible = false;
            // 
            // navBarItemARN
            // 
            this.navBarItemARN.Caption = "ARN";
            this.navBarItemARN.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarItemARN.LargeImage")));
            this.navBarItemARN.Name = "navBarItemARN";
            toolTipTitleItem24.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image5")));
            toolTipTitleItem24.Appearance.Options.UseImage = true;
            toolTipTitleItem24.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem24.Image")));
            toolTipTitleItem24.Text = "ARN";
            toolTipItem17.LeftIndent = 6;
            toolTipItem17.Text = "To view ARN details click here.";
            superToolTip18.Items.Add(toolTipTitleItem24);
            superToolTip18.Items.Add(toolTipItem17);
            this.navBarItemARN.SuperTip = superToolTip18;
            this.navBarItemARN.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemARN_LinkClicked);
            // 
            // navBarItemMFScheme
            // 
            this.navBarItemMFScheme.Caption = "MF Scheme";
            this.navBarItemMFScheme.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarItemMFScheme.LargeImage")));
            this.navBarItemMFScheme.Name = "navBarItemMFScheme";
            this.navBarItemMFScheme.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemMFScheme_LinkClicked);
            // 
            // navBarItemAMC
            // 
            this.navBarItemAMC.Caption = "AMC";
            this.navBarItemAMC.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarItemAMC.LargeImage")));
            this.navBarItemAMC.Name = "navBarItemAMC";
            this.navBarItemAMC.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemAMC_LinkClicked);
            // 
            // navBarGroupClient
            // 
            this.navBarGroupClient.Caption = "Client";
            this.navBarGroupClient.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroupClient.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemProspectCustomer),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemClient),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemFinancialPlanner)});
            this.navBarGroupClient.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarGroupClient.LargeImage")));
            this.navBarGroupClient.Name = "navBarGroupClient";
            this.navBarGroupClient.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroupClient.SmallImage")));
            // 
            // navBarItemProspectCustomer
            // 
            this.navBarItemProspectCustomer.Caption = "Prospect Customer";
            this.navBarItemProspectCustomer.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarItemProspectCustomer.LargeImage")));
            this.navBarItemProspectCustomer.Name = "navBarItemProspectCustomer";
            toolTipTitleItem26.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image7")));
            toolTipTitleItem26.Appearance.Options.UseImage = true;
            toolTipTitleItem26.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem26.Image")));
            toolTipTitleItem26.Text = "Prospect Customer";
            toolTipItem18.LeftIndent = 6;
            toolTipItem18.Text = "To view details about prospect customer click here.";
            superToolTip20.Items.Add(toolTipTitleItem26);
            superToolTip20.Items.Add(toolTipItem18);
            this.navBarItemProspectCustomer.SuperTip = superToolTip20;
            this.navBarItemProspectCustomer.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemProspectCustomer_LinkClicked);
            // 
            // navBarItemClient
            // 
            this.navBarItemClient.Caption = "Client";
            this.navBarItemClient.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarItemClient.LargeImage")));
            this.navBarItemClient.Name = "navBarItemClient";
            this.navBarItemClient.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItemClient.SmallImage")));
            toolTipTitleItem27.Appearance.Image = global::FinancialPlannerClient.Properties.Resources.icons8_customer_16;
            toolTipTitleItem27.Appearance.Options.UseImage = true;
            toolTipTitleItem27.Image = global::FinancialPlannerClient.Properties.Resources.icons8_customer_16;
            toolTipTitleItem27.Text = "Client";
            toolTipItem19.LeftIndent = 6;
            toolTipItem19.Text = "List of clients whoes investment and other portfolio manage by us.";
            superToolTip21.Items.Add(toolTipTitleItem27);
            superToolTip21.Items.Add(toolTipItem19);
            this.navBarItemClient.SuperTip = superToolTip21;
            this.navBarItemClient.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemFinancialPlanner_LinkClicked);
            // 
            // navBarItemFinancialPlanner
            // 
            this.navBarItemFinancialPlanner.Caption = "Financial Planner";
            this.navBarItemFinancialPlanner.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarItemFinancialPlanner.LargeImage")));
            this.navBarItemFinancialPlanner.Name = "navBarItemFinancialPlanner";
            this.navBarItemFinancialPlanner.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItemFinancialPlanner.SmallImage")));
            toolTipTitleItem28.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image8")));
            toolTipTitleItem28.Appearance.Options.UseImage = true;
            toolTipTitleItem28.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem28.Image")));
            toolTipTitleItem28.Text = "Financial Planner";
            toolTipItem20.LeftIndent = 6;
            toolTipItem20.Text = "List of all clients which are associated with financial planning.";
            superToolTip22.Items.Add(toolTipTitleItem28);
            superToolTip22.Items.Add(toolTipItem20);
            this.navBarItemFinancialPlanner.SuperTip = superToolTip22;
            this.navBarItemFinancialPlanner.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemFinancialPlanner_LinkClicked);
            // 
            // navBarMenuGroup
            // 
            this.navBarMenuGroup.ActiveGroup = this.mavBarMasterGroup;
            this.navBarMenuGroup.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.navBarMenuGroup.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navBarMenuGroup.Groups.AddRange(new DevExpress.XtraNavBar.NavBarGroup[] {
            this.mavBarMasterGroup,
            this.navBarGroupClient,
            this.navBarGroupSetting,
            this.navBarGroupOthers});
            this.navBarMenuGroup.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItemCRMGroup,
            this.navBarItemFestivals,
            this.navItemProcessAction,
            this.navBarSeparatorItem1,
            this.navBarItemClient,
            this.navBarItemFinancialPlanner,
            this.navBarItem2,
            this.navBarSeparatorItem2,
            this.navBarItemOld,
            this.navBarItemArea,
            this.navBarItemAuditTrail,
            this.navBarItemAssumptionMaster,
            this.navBarItemProspectCustomer,
            this.navBarItemClientRating,
            this.navBarItemTask,
            this.navBarItemARN,
            this.navBarItemMFScheme,
            this.navBarItemAMC});
            this.navBarMenuGroup.Location = new System.Drawing.Point(2, 2);
            this.navBarMenuGroup.Name = "navBarMenuGroup";
            this.navBarMenuGroup.OptionsNavPane.ExpandedWidth = 136;
            this.navBarMenuGroup.Size = new System.Drawing.Size(136, 546);
            this.navBarMenuGroup.TabIndex = 1;
            this.navBarMenuGroup.Text = "navBarControl1";
            // 
            // navBarGroupSetting
            // 
            this.navBarGroupSetting.Caption = "Setting";
            this.navBarGroupSetting.Expanded = true;
            this.navBarGroupSetting.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroupSetting.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemOld),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemTask)});
            this.navBarGroupSetting.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarGroupSetting.LargeImage")));
            this.navBarGroupSetting.Name = "navBarGroupSetting";
            this.navBarGroupSetting.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroupSetting.SmallImage")));
            // 
            // navBarItemOld
            // 
            this.navBarItemOld.Caption = "Old Application";
            this.navBarItemOld.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarItemOld.LargeImage")));
            this.navBarItemOld.Name = "navBarItemOld";
            this.navBarItemOld.Visible = false;
            this.navBarItemOld.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemOld_LinkClicked);
            // 
            // navBarItemTask
            // 
            this.navBarItemTask.Caption = "Task Management";
            this.navBarItemTask.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarItemTask.LargeImage")));
            this.navBarItemTask.Name = "navBarItemTask";
            this.navBarItemTask.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemTask_LinkClicked);
            // 
            // navBarGroupOthers
            // 
            this.navBarGroupOthers.Caption = "Tools";
            this.navBarGroupOthers.Expanded = true;
            this.navBarGroupOthers.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemAuditTrail)});
            this.navBarGroupOthers.Name = "navBarGroupOthers";
            // 
            // navBarItemAuditTrail
            // 
            this.navBarItemAuditTrail.Caption = "Audit Trail";
            this.navBarItemAuditTrail.Name = "navBarItemAuditTrail";
            this.navBarItemAuditTrail.SmallImage = global::FinancialPlannerClient.Properties.Resources.AuditTrail_301;
            this.navBarItemAuditTrail.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemAuditTrail_LinkClicked);
            // 
            // navigationFrame1
            // 
            this.navigationFrame1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.navigationFrame1.Controls.Add(this.homeNavigationPage1);
            this.navigationFrame1.Controls.Add(this.navigationMasterPage);
            this.navigationFrame1.Location = new System.Drawing.Point(146, 51);
            this.navigationFrame1.Name = "navigationFrame1";
            this.navigationFrame1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.homeNavigationPage1,
            this.navigationMasterPage});
            this.navigationFrame1.SelectedPage = this.navigationMasterPage;
            this.navigationFrame1.Size = new System.Drawing.Size(788, 542);
            this.navigationFrame1.TabIndex = 2;
            this.navigationFrame1.Text = "navigationFrame1";
            // 
            // homeNavigationPage1
            // 
            this.homeNavigationPage1.Name = "homeNavigationPage1";
            this.homeNavigationPage1.Size = new System.Drawing.Size(788, 542);
            this.homeNavigationPage1.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.homeNavigationPage1_ControlAdded);
            // 
            // navigationMasterPage
            // 
            this.navigationMasterPage.Name = "navigationMasterPage";
            this.navigationMasterPage.Size = new System.Drawing.Size(788, 542);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.navBarMenuGroup);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(0, 47);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(140, 550);
            this.panelControl2.TabIndex = 3;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.EnableBonusSkins = true;
            // 
            // ribbonPage2
            // 
            this.ribbonPage2.Name = "ribbonPage2";
            this.ribbonPage2.Text = "ribbonPage2";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // ribbonPage3
            // 
            this.ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup3});
            this.ribbonPage3.Name = "ribbonPage3";
            this.ribbonPage3.Text = "ribbonPage3";
            // 
            // ribbonPageGroup3
            // 
            this.ribbonPageGroup3.Name = "ribbonPageGroup3";
            this.ribbonPageGroup3.Text = "ribbonPageGroup3";
            // 
            // ribbonPage4
            // 
            this.ribbonPage4.Name = "ribbonPage4";
            this.ribbonPage4.Text = "ribbonPage4";
            // 
            // notifyIconTask
            // 
            this.notifyIconTask.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIconTask.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIconTask.Icon")));
            this.notifyIconTask.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIconTask_MouseDoubleClick);
            // 
            // timerNotification
            // 
            this.timerNotification.Interval = 60000;
            this.timerNotification.Tick += new System.EventHandler(this.timerNotification_Tick);
            // 
            // frmHome
            // 
            this.ClientSize = new System.Drawing.Size(939, 597);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.navigationFrame1);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmHome";
            this.Text = "Financial Planner Client";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHome_FormClosing);
            this.Load += new System.EventHandler(this.frmHome_Load);
            ((System.ComponentModel.ISupportInitialize)(this.imageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navBarMenuGroup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.navigationFrame1)).EndInit();
            this.navigationFrame1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);

        }

       
        private void Logout_Click(object sender, EventArgs e)
        {            
            this.Close();
        }

        private void navigationPage2_Paint_1(object sender, System.Windows.Forms.PaintEventArgs e)
        {

        }

        private void navBarItemCRMGroup_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Other other = new Other("CRM Groups");
            other.TopLevel = false;
            other.Visible = true;
            homeNavigationPage1.Name = other.Name;
            homeNavigationPage1.Controls.Add(other);
            showNavigationPage(other.Name);
        }

        private void navBarItemFestivals_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {            
            Other other = new Other("Festivals");
            other.TopLevel = false;
            other.Visible = true;
            homeNavigationPage1.Name = other.Name;
            homeNavigationPage1.Controls.Add(other);
            showNavigationPage(other.Name);
        }

        private void navBarItemFinancialPlanner_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Clients.ClientSearch clientSearch = new Clients.ClientSearch();
            if (clientSearch.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                Client client = clientSearch.GetSelectedClient();
                if (client != null)
                {
                    showClientDashboard(client);
                }
            }
        }

        private void showClientDashboard(Client client)
        {
            try
            {
                Clients.Clientdashboard clientdashboard = new Clients.Clientdashboard(client);
                this.Visible = false;
                clientdashboard.ShowDialog();
                this.Visible = true;
            }
            catch(Exception ex)
            {

            }
           
            
            
        }

        private void frmHome_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            try
            {
                FinancialPlanner.Common.JSONSerialization jsonSerialization = new FinancialPlanner.Common.JSONSerialization();
                string apiurl = Program.WebServiceUrl + "/" + AUDITLOGCONTROLLER;

                Activities activity = new Activities();
                activity.ActivityTypeValue = ActivityType.Logout;
                activity.EntryType = EntryStatus.Success;
                activity.SourceType = Source.Server;
                activity.HostName = Environment.MachineName;
                activity.UserName = Program.CurrentUser.UserName;

                string DATA = jsonSerialization.SerializeToString<Activities>(activity);

                WebClient client = new WebClient();
                client.Headers["Content-type"] = "application/json";
                client.Encoding = Encoding.UTF8;
                string json = client.UploadString(apiurl, DATA);

                if (json != null)
                {
                    var resultObject = jsonSerialization.DeserializeFromString<Result>(json);
                }
            }
            catch (Exception ex)
            {
                Logger.LogDebug(ex.ToString());
            }
        }

        private void navBarItemOld_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //Main frmclientMain = new Main();
            //this.Visible = false;
            //frmclientMain.ShowDialog();
            //this.Visible = true;
            Testing testing = new Testing();
            testing.Show();
        }

        private void navBarItemAre_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            //Others other = new Others("Areas");
            //other.ShowDialog();

            Other other = new Other("Areas");
            other.TopLevel = false;
            other.Visible = true;
            homeNavigationPage1.Name = other.Name;
            homeNavigationPage1.Controls.Add(other);
            showNavigationPage(other.Name);
        }

        private void navBarItemAuditTrail_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AuditTrail.AuditTrail auditTrail = new AuditTrail.AuditTrail();
            //AuditTrailView auditTrail = new AuditTrailView();
            auditTrail.TopLevel = false;
            auditTrail.Visible = true;
            homeNavigationPage1.Name = auditTrail.Name;
            homeNavigationPage1.Controls.Add(auditTrail);
            showNavigationPage(auditTrail.Name);
        }
        private void showNavigationPage(string pageName)
        {
            for (int index = 0; index <= navigationFrame1.Pages.Count; index++)
            {
                if (navigationFrame1.Pages[index].Name == pageName)
                {
                    navigationFrame1.SelectedPageIndex = index;
                    break;
                }
            }
        }

        private void navBarItemAssumptionMaster_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {            
            AssumptionMasters assumptionMasters = new AssumptionMasters();
            assumptionMasters.TopLevel = false;
            assumptionMasters.Visible = true;
            homeNavigationPage1.Name = assumptionMasters.Name;
            homeNavigationPage1.Controls.Add(assumptionMasters);
            showNavigationPage(assumptionMasters.Name);
        }

        private void navBarItemProspectCustomer_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ProspectCustomerList prospectCustomerList  = new ProspectCustomerList();
            prospectCustomerList.TopLevel = false;
            prospectCustomerList.Visible = true;
            homeNavigationPage1.Name = prospectCustomerList.Name;
            homeNavigationPage1.Controls.Add(prospectCustomerList);
            showNavigationPage(prospectCustomerList.Name);
        }

        private void navBarItemClientRating_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {           
            ClientRatingView clientRatingView = new ClientRatingView();
            clientRatingView.TopLevel = false;
            clientRatingView.Visible = true;
            homeNavigationPage1.Name = clientRatingView.Name;
            homeNavigationPage1.Controls.Add(clientRatingView);
            showNavigationPage(clientRatingView.Name);
        }

        private void navItemProcessAction_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            DefaultPlanningActions defaultPlanningActions = new DefaultPlanningActions();
            defaultPlanningActions.TopLevel = false;
            defaultPlanningActions.Visible = true;
            homeNavigationPage1.Name = defaultPlanningActions.Name;
            homeNavigationPage1.Controls.Add(defaultPlanningActions);
            showNavigationPage(defaultPlanningActions.Name);
        }

        private void navBarItemTask_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            TaskMainPage  taskMainPage = new TaskMainPage();
            taskMainPage.TopLevel = false;
            taskMainPage.Visible = true;
            //taskMainPage.Dock = System.Windows.Forms.DockStyle.Fill;
            homeNavigationPage1.Name = taskMainPage.Name;
            homeNavigationPage1.Controls.Add(taskMainPage);
            showNavigationPage(taskMainPage.Name);
        }

        private void homeNavigationPage1_ControlAdded(object sender, System.Windows.Forms.ControlEventArgs e)
        {
            if (homeNavigationPage1.Controls.Count > 1)
                homeNavigationPage1.Controls.RemoveAt(0);
        }

        private void navBarItemARN_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            ARNView arnView = new ARNView();
            arnView.TopLevel = false;
            arnView.Visible = true;
            homeNavigationPage1.Name = arnView.Name;
            homeNavigationPage1.Controls.Add(arnView);
            showNavigationPage(arnView.Name);
        }

        private void navBarItemMFScheme_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            SchemeView schemeView = new SchemeView();
            schemeView.TopLevel = false;
            schemeView.Visible = true;
            homeNavigationPage1.Name = schemeView.Name;
            homeNavigationPage1.Controls.Add(schemeView);
            showNavigationPage(schemeView.Name);
        }

        private void frmHome_Load(object sender, EventArgs e)
        {
            lblCurrentUser.BackColor = ribbonControl1.BackColor;
            lblCurrentUser.Text = Program.CurrentUser.UserName;
            timerNotification.Start();
        }

        private void navBarItemAMC_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            AmcView amcView = new AmcView();
            amcView.TopLevel = false;
            amcView.Visible = true;
            homeNavigationPage1.Name = amcView.Name;
            homeNavigationPage1.Controls.Add(amcView);
            showNavigationPage(amcView.Name);
        }

        private void timerNotification_Tick(object sender, EventArgs e)
        {
            int count = new TaskNotificationInfo().GetNotification(Program.CurrentUser.Id);
            if (count > 0)
            {
                displaynotify(count);
            }
        }

        protected void displaynotify(int notificationCount)
        {
            try
            {
                notifyIconTask.Icon = new System.Drawing.Icon(System.IO.Path.GetFullPath(@"C:\Application Development\Financial Planner Project\Other Documents\Notifications.ico"));

                this.notifyIconTask.Text = "Notification";
                this.notifyIconTask.Visible = true;
                this.notifyIconTask.BalloonTipTitle = string.Format("New task notifaction ({0})", notificationCount); 
                this.notifyIconTask.BalloonTipText = "Click here to view more details";
                this.notifyIconTask.ShowBalloonTip(1000);
                //notifyIconTask.Visible = true;
                //notifyIconTask.ShowBalloonTip(20000, "Task Notification", string.Format("New task notifaction ({0})", notificationCount),
                //    ToolTipIcon.Info);
            }
            catch (Exception)
            {
            }
        }

        private void notifyIconTask_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            //MessageBox.Show("Task notification work in progress");
        }
    }
}
