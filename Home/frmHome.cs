﻿using DevExpress.XtraEditors;
using FinancialPlanner.Common;
using FinancialPlanner.Common.Model;
using FinancialPlannerClient.Master;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

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
        private DevExpress.XtraBars.Navigation.NavigationPage navigationPage1;
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
        private const string AUDITLOGCONTROLLER = "Activities/Add";

        public frmHome()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmHome));
            DevExpress.Utils.SuperToolTip superToolTip1 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem1 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem1 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip2 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem2 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem2 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip3 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem3 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem3 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.ToolTipSeparatorItem toolTipSeparatorItem1 = new DevExpress.Utils.ToolTipSeparatorItem();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem4 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip5 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem7 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip4 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem5 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem4 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.ToolTipSeparatorItem toolTipSeparatorItem2 = new DevExpress.Utils.ToolTipSeparatorItem();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem6 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.SuperToolTip superToolTip6 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem8 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem5 = new DevExpress.Utils.ToolTipItem();
            DevExpress.Utils.SuperToolTip superToolTip7 = new DevExpress.Utils.SuperToolTip();
            DevExpress.Utils.ToolTipTitleItem toolTipTitleItem9 = new DevExpress.Utils.ToolTipTitleItem();
            DevExpress.Utils.ToolTipItem toolTipItem6 = new DevExpress.Utils.ToolTipItem();
            this.imageCollection1 = new DevExpress.Utils.ImageCollection(this.components);
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnLogout = new DevExpress.XtraEditors.SimpleButton();
            this.pictureEdit1 = new DevExpress.XtraEditors.PictureEdit();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.skinRibbonGalleryBarItem1 = new DevExpress.XtraBars.SkinRibbonGalleryBarItem();
            this.navBarItemCRMGroup = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemFestivals = new DevExpress.XtraNavBar.NavBarItem();
            this.navItemProcessAction = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarSeparatorItem1 = new DevExpress.XtraNavBar.NavBarSeparatorItem();
            this.mavBarMasterGroup = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItem2 = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarSeparatorItem2 = new DevExpress.XtraNavBar.NavBarSeparatorItem();
            this.navBarGroupClient = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItemClient = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarItemFinancialPlanner = new DevExpress.XtraNavBar.NavBarItem();
            this.navBarMenuGroup = new DevExpress.XtraNavBar.NavBarControl();
            this.navBarGroupSetting = new DevExpress.XtraNavBar.NavBarGroup();
            this.navBarItemOld = new DevExpress.XtraNavBar.NavBarItem();
            this.navigationFrame1 = new DevExpress.XtraBars.Navigation.NavigationFrame();
            this.navigationPage1 = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.navigationMasterPage = new DevExpress.XtraBars.Navigation.NavigationPage();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPage4 = new DevExpress.XtraBars.Ribbon.RibbonPage();
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
            this.panelControl1.Controls.Add(this.btnLogout);
            this.panelControl1.Controls.Add(this.pictureEdit1);
            this.panelControl1.Controls.Add(this.ribbonControl1);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(797, 47);
            this.panelControl1.TabIndex = 0;
            // 
            // btnLogout
            // 
            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLogout.Image = ((System.Drawing.Image)(resources.GetObject("btnLogout.Image")));
            this.btnLogout.Location = new System.Drawing.Point(771, 6);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(25, 22);
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
            this.ribbonControl1.Size = new System.Drawing.Size(653, 47);
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
            toolTipTitleItem1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            toolTipTitleItem1.Appearance.Options.UseImage = true;
            toolTipTitleItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem1.Image")));
            toolTipTitleItem1.Text = "CRM Group";
            toolTipItem1.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image1")));
            toolTipItem1.Appearance.Options.UseImage = true;
            toolTipItem1.Image = ((System.Drawing.Image)(resources.GetObject("toolTipItem1.Image")));
            toolTipItem1.LeftIndent = 6;
            toolTipItem1.Text = "To view or modify CRM Group click here.";
            superToolTip1.Items.Add(toolTipTitleItem1);
            superToolTip1.Items.Add(toolTipItem1);
            this.navBarItemCRMGroup.SuperTip = superToolTip1;
            this.navBarItemCRMGroup.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemCRMGroup_LinkClicked);
            // 
            // navBarItemFestivals
            // 
            this.navBarItemFestivals.Caption = "Festivals";
            this.navBarItemFestivals.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarItemFestivals.LargeImage")));
            this.navBarItemFestivals.Name = "navBarItemFestivals";
            this.navBarItemFestivals.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItemFestivals.SmallImage")));
            toolTipTitleItem2.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image2")));
            toolTipTitleItem2.Appearance.Options.UseImage = true;
            toolTipTitleItem2.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem2.Image")));
            toolTipTitleItem2.Text = "Festivals";
            toolTipItem2.LeftIndent = 6;
            toolTipItem2.Text = "To view or modify festivals click here.";
            superToolTip2.Items.Add(toolTipTitleItem2);
            superToolTip2.Items.Add(toolTipItem2);
            this.navBarItemFestivals.SuperTip = superToolTip2;
            this.navBarItemFestivals.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemFestivals_LinkClicked);
            // 
            // navItemProcessAction
            // 
            this.navItemProcessAction.Caption = "Process Name";
            this.navItemProcessAction.LargeImage = ((System.Drawing.Image)(resources.GetObject("navItemProcessAction.LargeImage")));
            this.navItemProcessAction.Name = "navItemProcessAction";
            toolTipTitleItem3.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image3")));
            toolTipTitleItem3.Appearance.Options.UseImage = true;
            toolTipTitleItem3.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem3.Image")));
            toolTipTitleItem3.Text = "Process";
            toolTipItem3.LeftIndent = 6;
            toolTipItem3.Text = "To view or modify process click here.";
            toolTipTitleItem4.LeftIndent = 6;
            toolTipTitleItem4.Text = "You can define process name and later it can be assign to sequence of process.";
            superToolTip3.Items.Add(toolTipTitleItem3);
            superToolTip3.Items.Add(toolTipItem3);
            superToolTip3.Items.Add(toolTipSeparatorItem1);
            superToolTip3.Items.Add(toolTipTitleItem4);
            this.navItemProcessAction.SuperTip = superToolTip3;
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
            this.mavBarMasterGroup.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.mavBarMasterGroup.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemCRMGroup),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemFestivals),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navItemProcessAction),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarSeparatorItem1),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItem2),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarSeparatorItem2)});
            this.mavBarMasterGroup.LargeImage = ((System.Drawing.Image)(resources.GetObject("mavBarMasterGroup.LargeImage")));
            this.mavBarMasterGroup.Name = "mavBarMasterGroup";
            this.mavBarMasterGroup.SmallImage = ((System.Drawing.Image)(resources.GetObject("mavBarMasterGroup.SmallImage")));
            toolTipTitleItem7.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image5")));
            toolTipTitleItem7.Appearance.Options.UseImage = true;
            toolTipTitleItem7.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem7.Image")));
            superToolTip5.Items.Add(toolTipTitleItem7);
            this.mavBarMasterGroup.SuperTip = superToolTip5;
            // 
            // navBarItem2
            // 
            this.navBarItem2.Caption = "Complete Process";
            this.navBarItem2.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarItem2.LargeImage")));
            this.navBarItem2.Name = "navBarItem2";
            toolTipTitleItem5.Text = "Complete Process";
            toolTipItem4.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image4")));
            toolTipItem4.Appearance.Options.UseImage = true;
            toolTipItem4.Image = ((System.Drawing.Image)(resources.GetObject("toolTipItem4.Image")));
            toolTipItem4.LeftIndent = 6;
            toolTipItem4.Text = "To create or modify complete process infromation click here.";
            toolTipTitleItem6.LeftIndent = 6;
            toolTipTitleItem6.Text = "You can define one process and add sequence of action to complete on process.";
            superToolTip4.Items.Add(toolTipTitleItem5);
            superToolTip4.Items.Add(toolTipItem4);
            superToolTip4.Items.Add(toolTipSeparatorItem2);
            superToolTip4.Items.Add(toolTipTitleItem6);
            this.navBarItem2.SuperTip = superToolTip4;
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
            // navBarGroupClient
            // 
            this.navBarGroupClient.Caption = "Client";
            this.navBarGroupClient.Expanded = true;
            this.navBarGroupClient.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroupClient.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemClient),
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemFinancialPlanner)});
            this.navBarGroupClient.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarGroupClient.LargeImage")));
            this.navBarGroupClient.Name = "navBarGroupClient";
            this.navBarGroupClient.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroupClient.SmallImage")));
            // 
            // navBarItemClient
            // 
            this.navBarItemClient.Caption = "Client";
            this.navBarItemClient.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarItemClient.LargeImage")));
            this.navBarItemClient.Name = "navBarItemClient";
            this.navBarItemClient.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItemClient.SmallImage")));
            toolTipTitleItem8.Appearance.Image = global::FinancialPlannerClient.Properties.Resources.icons8_customer_16;
            toolTipTitleItem8.Appearance.Options.UseImage = true;
            toolTipTitleItem8.Image = global::FinancialPlannerClient.Properties.Resources.icons8_customer_16;
            toolTipTitleItem8.Text = "Client";
            toolTipItem5.LeftIndent = 6;
            toolTipItem5.Text = "List of clients whoes investment and other portfolio manage by us.";
            superToolTip6.Items.Add(toolTipTitleItem8);
            superToolTip6.Items.Add(toolTipItem5);
            this.navBarItemClient.SuperTip = superToolTip6;
            this.navBarItemClient.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemFinancialPlanner_LinkClicked);
            // 
            // navBarItemFinancialPlanner
            // 
            this.navBarItemFinancialPlanner.Caption = "Financial Planner";
            this.navBarItemFinancialPlanner.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarItemFinancialPlanner.LargeImage")));
            this.navBarItemFinancialPlanner.Name = "navBarItemFinancialPlanner";
            this.navBarItemFinancialPlanner.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarItemFinancialPlanner.SmallImage")));
            toolTipTitleItem9.Appearance.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image6")));
            toolTipTitleItem9.Appearance.Options.UseImage = true;
            toolTipTitleItem9.Image = ((System.Drawing.Image)(resources.GetObject("toolTipTitleItem9.Image")));
            toolTipTitleItem9.Text = "Financial Planner";
            toolTipItem6.LeftIndent = 6;
            toolTipItem6.Text = "List of all clients which are associated with financial planning.";
            superToolTip7.Items.Add(toolTipTitleItem9);
            superToolTip7.Items.Add(toolTipItem6);
            this.navBarItemFinancialPlanner.SuperTip = superToolTip7;
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
            this.navBarGroupSetting});
            this.navBarMenuGroup.Items.AddRange(new DevExpress.XtraNavBar.NavBarItem[] {
            this.navBarItemCRMGroup,
            this.navBarItemFestivals,
            this.navItemProcessAction,
            this.navBarSeparatorItem1,
            this.navBarItemClient,
            this.navBarItemFinancialPlanner,
            this.navBarItem2,
            this.navBarSeparatorItem2,
            this.navBarItemOld});
            this.navBarMenuGroup.Location = new System.Drawing.Point(2, 2);
            this.navBarMenuGroup.Name = "navBarMenuGroup";
            this.navBarMenuGroup.OptionsNavPane.ExpandedWidth = 136;
            this.navBarMenuGroup.Size = new System.Drawing.Size(136, 309);
            this.navBarMenuGroup.TabIndex = 1;
            this.navBarMenuGroup.Text = "navBarControl1";
            // 
            // navBarGroupSetting
            // 
            this.navBarGroupSetting.Caption = "Setting";
            this.navBarGroupSetting.Expanded = true;
            this.navBarGroupSetting.GroupStyle = DevExpress.XtraNavBar.NavBarGroupStyle.LargeIconsText;
            this.navBarGroupSetting.ItemLinks.AddRange(new DevExpress.XtraNavBar.NavBarItemLink[] {
            new DevExpress.XtraNavBar.NavBarItemLink(this.navBarItemOld)});
            this.navBarGroupSetting.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarGroupSetting.LargeImage")));
            this.navBarGroupSetting.Name = "navBarGroupSetting";
            this.navBarGroupSetting.SmallImage = ((System.Drawing.Image)(resources.GetObject("navBarGroupSetting.SmallImage")));
            // 
            // navBarItemOld
            // 
            this.navBarItemOld.Caption = "Old Application";
            this.navBarItemOld.LargeImage = ((System.Drawing.Image)(resources.GetObject("navBarItemOld.LargeImage")));
            this.navBarItemOld.Name = "navBarItemOld";
            this.navBarItemOld.LinkClicked += new DevExpress.XtraNavBar.NavBarLinkEventHandler(this.navBarItemOld_LinkClicked);
            // 
            // navigationFrame1
            // 
            this.navigationFrame1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.navigationFrame1.Controls.Add(this.navigationPage1);
            this.navigationFrame1.Controls.Add(this.navigationMasterPage);
            this.navigationFrame1.Location = new System.Drawing.Point(146, 51);
            this.navigationFrame1.Name = "navigationFrame1";
            this.navigationFrame1.Pages.AddRange(new DevExpress.XtraBars.Navigation.NavigationPageBase[] {
            this.navigationPage1,
            this.navigationMasterPage});
            this.navigationFrame1.SelectedPage = this.navigationMasterPage;
            this.navigationFrame1.Size = new System.Drawing.Size(646, 305);
            this.navigationFrame1.TabIndex = 2;
            this.navigationFrame1.Text = "navigationFrame1";
            // 
            // navigationPage1
            // 
            this.navigationPage1.Name = "navigationPage1";
            this.navigationPage1.Size = new System.Drawing.Size(646, 305);
            // 
            // navigationMasterPage
            // 
            this.navigationMasterPage.Name = "navigationMasterPage";
            this.navigationMasterPage.Size = new System.Drawing.Size(646, 305);
            // 
            // panelControl2
            // 
            this.panelControl2.Controls.Add(this.navBarMenuGroup);
            this.panelControl2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelControl2.Location = new System.Drawing.Point(0, 47);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(140, 313);
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
            // frmHome
            // 
            this.ClientSize = new System.Drawing.Size(797, 360);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.navigationFrame1);
            this.Controls.Add(this.panelControl1);
            this.Name = "frmHome";
            this.Text = "Financial Planner Client";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmHome_FormClosing);
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
            Others other = new Others("CRM Groups");
            other.ShowDialog();
        }

        private void navBarItemFestivals_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            Others other = new Others("Festivals");
            other.ShowDialog();
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
            Clients.Clientdashboard clientdashboard = new Clients.Clientdashboard(client);
            this.Visible = false;
            clientdashboard.ShowDialog();
            this.Visible = true;
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
            Main frmclientMain = new Main();
            this.Visible = false;
            frmclientMain.ShowDialog();
            this.Visible = true;
        }
    }
}