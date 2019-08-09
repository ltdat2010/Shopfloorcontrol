using DevExpress.XtraScheduler.UI;
namespace Production.LAMINATION._LAB
{
    partial class OutlookAppointmentForm
    {

        #region Designer generated code
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OutlookAppointmentForm));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.backstageViewControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewControl();
            this.bvPrint = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.btnPrint = new DevExpress.XtraEditors.SimpleButton();
            this.dvInfo = new DevExpress.XtraPrinting.Preview.DocumentViewer();
            this.bvtPrint = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.bvbSave = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            this.bvbSaveAs = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            this.bvbClose = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            this.btnSaveAndClose = new DevExpress.XtraBars.BarButtonItem();
            this.btnDelete = new DevExpress.XtraBars.BarButtonItem();
            this.btnSave = new DevExpress.XtraBars.BarButtonItem();
            this.btnNext = new DevExpress.XtraBars.BarButtonItem();
            this.btnPrevious = new DevExpress.XtraBars.BarButtonItem();
            this.rpAppointment = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.rpgActions = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.riAppointmentLabel = new DevExpress.XtraScheduler.UI.RepositoryItemAppointmentLabel();
            this.riAppointmentResource = new DevExpress.XtraScheduler.UI.RepositoryItemAppointmentResource();
            this.riAppointmentStatus = new DevExpress.XtraScheduler.UI.RepositoryItemAppointmentStatus();
            this.riDuration = new DevExpress.XtraScheduler.UI.RepositoryItemDuration();
            this.lblStartTime = new DevExpress.XtraEditors.LabelControl();
            this.edtStartDate = new DevExpress.XtraEditors.DateEdit();
            this.edtStartTime = new DevExpress.XtraEditors.TimeEdit();
            this.lblEndTime = new DevExpress.XtraEditors.LabelControl();
            this.edtEndDate = new DevExpress.XtraEditors.DateEdit();
            this.edtEndTime = new DevExpress.XtraEditors.TimeEdit();
            this.lblLocation = new DevExpress.XtraEditors.LabelControl();
            this.lblResource = new DevExpress.XtraEditors.LabelControl();
            this.edtResource = new DevExpress.XtraScheduler.UI.AppointmentResourceEdit();
            this.tbSubject = new DevExpress.XtraEditors.TextEdit();
            this.progressPanel = new System.Windows.Forms.Panel();
            this.tbProgress = new DevExpress.XtraEditors.TrackBarControl();
            this.lblPercentCompleteValue = new DevExpress.XtraEditors.LabelControl();
            this.lblPercentComplete = new DevExpress.XtraEditors.LabelControl();
            this.lblSubject = new DevExpress.XtraEditors.LabelControl();
            this.panelMain = new System.Windows.Forms.Panel();
            this.tbDescription = new DevExpress.XtraEditors.MemoEdit();
            this.panelDescription = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.tbsDescription = new DevExpress.XtraEditors.TextEdit();
            this.panel3 = new System.Windows.Forms.Panel();
            this.defaultBarAndDockingController = new DevExpress.XtraBars.DefaultBarAndDockingController(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backstageViewControl1)).BeginInit();
            this.backstageViewControl1.SuspendLayout();
            this.bvPrint.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.riAppointmentLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riAppointmentResource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riAppointmentStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndTime.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResource.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSubject.Properties)).BeginInit();
            this.progressPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbProgress)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbProgress.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDescription.Properties)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbsDescription.Properties)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.defaultBarAndDockingController.Controller)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationButtonDropDownControl = this.backstageViewControl1;
            this.ribbonControl1.AutoSizeItems = true;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnSaveAndClose,
            this.btnDelete,
            this.btnSave,
            this.btnNext,
            this.btnPrevious});
            resources.ApplyResources(this.ribbonControl1, "ribbonControl1");
            this.ribbonControl1.MaxItemId = 3;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.rpAppointment});
            this.ribbonControl1.QuickToolbarItemLinks.Add(this.btnSave);
            this.ribbonControl1.QuickToolbarItemLinks.Add(this.btnPrevious);
            this.ribbonControl1.QuickToolbarItemLinks.Add(this.btnNext);
            this.ribbonControl1.QuickToolbarItemLinks.Add(this.btnDelete);
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.riAppointmentLabel,
            this.riAppointmentResource,
            this.riAppointmentStatus,
            this.riDuration});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2013;
            this.ribbonControl1.ApplicationButtonClick += new System.EventHandler(this.ribbonControl1_ApplicationButtonClick);
            // 
            // backstageViewControl1
            // 
            resources.ApplyResources(this.backstageViewControl1, "backstageViewControl1");
            this.backstageViewControl1.Controls.Add(this.bvPrint);
            this.backstageViewControl1.Items.Add(this.bvtPrint);
            this.backstageViewControl1.Items.Add(this.bvbSave);
            this.backstageViewControl1.Items.Add(this.bvbSaveAs);
            this.backstageViewControl1.Items.Add(this.bvbClose);
            this.backstageViewControl1.Name = "backstageViewControl1";
            this.backstageViewControl1.OwnerControl = this.ribbonControl1;
            this.backstageViewControl1.SelectedTab = this.bvtPrint;
            this.backstageViewControl1.SelectedTabIndex = 0;
            this.backstageViewControl1.Style = DevExpress.XtraBars.Ribbon.BackstageViewStyle.Office2013;
            // 
            // bvPrint
            // 
            resources.ApplyResources(this.bvPrint, "bvPrint");
            this.bvPrint.Controls.Add(this.btnPrint);
            this.bvPrint.Controls.Add(this.dvInfo);
            this.bvPrint.Name = "bvPrint";
            // 
            // btnPrint
            // 
            resources.ApplyResources(this.btnPrint, "btnPrint");
            this.btnPrint.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPrint.ImageOptions.Image")));
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // dvInfo
            // 
            resources.ApplyResources(this.dvInfo, "dvInfo");
            this.dvInfo.AutoZoom = true;
            this.dvInfo.Name = "dvInfo";
            // 
            // bvtPrint
            // 
            resources.ApplyResources(this.bvtPrint, "bvtPrint");
            this.bvtPrint.ContentControl = this.bvPrint;
            this.bvtPrint.Name = "bvtPrint";
            this.bvtPrint.Selected = true;
            // 
            // bvbSave
            // 
            resources.ApplyResources(this.bvbSave, "bvbSave");
            this.bvbSave.Name = "bvbSave";
            this.bvbSave.ItemClick += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.bvbSave_ItemClick);
            // 
            // bvbSaveAs
            // 
            resources.ApplyResources(this.bvbSaveAs, "bvbSaveAs");
            this.bvbSaveAs.Name = "bvbSaveAs";
            this.bvbSaveAs.ItemClick += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.bvbSaveAs_ItemClick);
            // 
            // bvbClose
            // 
            resources.ApplyResources(this.bvbClose, "bvbClose");
            this.bvbClose.Name = "bvbClose";
            this.bvbClose.ItemClick += new DevExpress.XtraBars.Ribbon.BackstageViewItemEventHandler(this.bvbClose_ItemClick);
            // 
            // btnSaveAndClose
            // 
            resources.ApplyResources(this.btnSaveAndClose, "btnSaveAndClose");
            this.btnSaveAndClose.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnSaveAndClose.Id = 3;
            this.btnSaveAndClose.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSaveAndClose.ImageOptions.Image")));
            this.btnSaveAndClose.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnSaveAndClose.ImageOptions.LargeImage")));
            this.btnSaveAndClose.Name = "btnSaveAndClose";
            this.btnSaveAndClose.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSaveAndClose_ItemClick);
            // 
            // btnDelete
            // 
            resources.ApplyResources(this.btnDelete, "btnDelete");
            this.btnDelete.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnDelete.Id = 4;
            this.btnDelete.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.Image")));
            this.btnDelete.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnDelete.ImageOptions.LargeImage")));
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonDelete_ItemClick);
            // 
            // btnSave
            // 
            resources.ApplyResources(this.btnSave, "btnSave");
            this.btnSave.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnSave.Id = 1;
            this.btnSave.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.ImageOptions.Image")));
            this.btnSave.Name = "btnSave";
            this.btnSave.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnSave_ItemClick);
            // 
            // btnNext
            // 
            resources.ApplyResources(this.btnNext, "btnNext");
            this.btnNext.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnNext.Id = 3;
            this.btnNext.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnNext.ImageOptions.Image")));
            this.btnNext.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnNext.ImageOptions.LargeImage")));
            this.btnNext.Name = "btnNext";
            this.btnNext.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnNext_ItemClick);
            // 
            // btnPrevious
            // 
            resources.ApplyResources(this.btnPrevious, "btnPrevious");
            this.btnPrevious.CategoryGuid = new System.Guid("6ffddb2b-9015-4d97-a4c1-91613e0ef537");
            this.btnPrevious.Id = 4;
            this.btnPrevious.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPrevious.ImageOptions.Image")));
            this.btnPrevious.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("btnPrevious.ImageOptions.LargeImage")));
            this.btnPrevious.Name = "btnPrevious";
            this.btnPrevious.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnPrevious_ItemClick);
            // 
            // rpAppointment
            // 
            this.rpAppointment.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.rpgActions});
            this.rpAppointment.Name = "rpAppointment";
            resources.ApplyResources(this.rpAppointment, "rpAppointment");
            // 
            // rpgActions
            // 
            this.rpgActions.ItemLinks.Add(this.btnSaveAndClose);
            this.rpgActions.ItemLinks.Add(this.btnDelete);
            this.rpgActions.Name = "rpgActions";
            this.rpgActions.ShowCaptionButton = false;
            resources.ApplyResources(this.rpgActions, "rpgActions");
            // 
            // riAppointmentLabel
            // 
            resources.ApplyResources(this.riAppointmentLabel, "riAppointmentLabel");
            this.riAppointmentLabel.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("riAppointmentLabel.Buttons"))))});
            this.riAppointmentLabel.Name = "riAppointmentLabel";
            // 
            // riAppointmentResource
            // 
            resources.ApplyResources(this.riAppointmentResource, "riAppointmentResource");
            this.riAppointmentResource.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("riAppointmentResource.Buttons"))))});
            this.riAppointmentResource.Name = "riAppointmentResource";
            // 
            // riAppointmentStatus
            // 
            resources.ApplyResources(this.riAppointmentStatus, "riAppointmentStatus");
            this.riAppointmentStatus.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("riAppointmentStatus.Buttons"))))});
            this.riAppointmentStatus.Name = "riAppointmentStatus";
            // 
            // riDuration
            // 
            resources.ApplyResources(this.riDuration, "riDuration");
            this.riDuration.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("riDuration.Buttons"))))});
            this.riDuration.DisabledStateText = null;
            this.riDuration.Name = "riDuration";
            this.riDuration.ShowEmptyItem = true;
            // 
            // lblStartTime
            // 
            resources.ApplyResources(this.lblStartTime, "lblStartTime");
            this.lblStartTime.Name = "lblStartTime";
            // 
            // edtStartDate
            // 
            resources.ApplyResources(this.edtStartDate, "edtStartDate");
            this.edtStartDate.Name = "edtStartDate";
            this.edtStartDate.Properties.AccessibleName = resources.GetString("edtStartDate.Properties.AccessibleName");
            this.edtStartDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("edtStartDate.Properties.Buttons"))))});
            this.edtStartDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtStartDate.Properties.MaxValue = new System.DateTime(4000, 1, 1, 0, 0, 0, 0);
            // 
            // edtStartTime
            // 
            resources.ApplyResources(this.edtStartTime, "edtStartTime");
            this.edtStartTime.Name = "edtStartTime";
            this.edtStartTime.Properties.AccessibleName = resources.GetString("edtStartTime.Properties.AccessibleName");
            this.edtStartTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtStartTime.Properties.Mask.EditMask = resources.GetString("edtStartTime.Properties.Mask.EditMask");
            // 
            // lblEndTime
            // 
            resources.ApplyResources(this.lblEndTime, "lblEndTime");
            this.lblEndTime.Name = "lblEndTime";
            // 
            // edtEndDate
            // 
            resources.ApplyResources(this.edtEndDate, "edtEndDate");
            this.edtEndDate.Name = "edtEndDate";
            this.edtEndDate.Properties.AccessibleName = resources.GetString("edtEndDate.Properties.AccessibleName");
            this.edtEndDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("edtEndDate.Properties.Buttons"))))});
            this.edtEndDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtEndDate.Properties.MaxValue = new System.DateTime(4000, 1, 1, 0, 0, 0, 0);
            // 
            // edtEndTime
            // 
            resources.ApplyResources(this.edtEndTime, "edtEndTime");
            this.edtEndTime.Name = "edtEndTime";
            this.edtEndTime.Properties.AccessibleName = resources.GetString("edtEndTime.Properties.AccessibleName");
            this.edtEndTime.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.edtEndTime.Properties.Mask.EditMask = resources.GetString("edtEndTime.Properties.Mask.EditMask");
            // 
            // lblLocation
            // 
            resources.ApplyResources(this.lblLocation, "lblLocation");
            this.lblLocation.Name = "lblLocation";
            // 
            // lblResource
            // 
            resources.ApplyResources(this.lblResource, "lblResource");
            this.lblResource.Name = "lblResource";
            // 
            // edtResource
            // 
            resources.ApplyResources(this.edtResource, "edtResource");
            this.edtResource.Name = "edtResource";
            this.edtResource.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.ComboBox;
            this.edtResource.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("edtResource.Properties.Buttons"))))});
            // 
            // tbSubject
            // 
            resources.ApplyResources(this.tbSubject, "tbSubject");
            this.tbSubject.Name = "tbSubject";
            this.tbSubject.Properties.AccessibleName = resources.GetString("tbSubject.Properties.AccessibleName");
            // 
            // progressPanel
            // 
            this.progressPanel.Controls.Add(this.tbProgress);
            this.progressPanel.Controls.Add(this.lblPercentCompleteValue);
            this.progressPanel.Controls.Add(this.lblPercentComplete);
            resources.ApplyResources(this.progressPanel, "progressPanel");
            this.progressPanel.Name = "progressPanel";
            this.progressPanel.TabStop = true;
            // 
            // tbProgress
            // 
            resources.ApplyResources(this.tbProgress, "tbProgress");
            this.tbProgress.Name = "tbProgress";
            this.tbProgress.Properties.AutoSize = false;
            this.tbProgress.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tbProgress.Properties.Maximum = 1;
            this.tbProgress.Properties.ShowValueToolTip = true;
            this.tbProgress.Properties.SmallChange = 100;
            // 
            // lblPercentCompleteValue
            // 
            resources.ApplyResources(this.lblPercentCompleteValue, "lblPercentCompleteValue");
            this.lblPercentCompleteValue.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("lblPercentCompleteValue.Appearance.BackColor")));
            this.lblPercentCompleteValue.Appearance.Options.UseBackColor = true;
            this.lblPercentCompleteValue.Name = "lblPercentCompleteValue";
            // 
            // lblPercentComplete
            // 
            resources.ApplyResources(this.lblPercentComplete, "lblPercentComplete");
            this.lblPercentComplete.Appearance.BackColor = ((System.Drawing.Color)(resources.GetObject("lblPercentComplete.Appearance.BackColor")));
            this.lblPercentComplete.Appearance.Options.UseBackColor = true;
            this.lblPercentComplete.Name = "lblPercentComplete";
            // 
            // lblSubject
            // 
            resources.ApplyResources(this.lblSubject, "lblSubject");
            this.lblSubject.Name = "lblSubject";
            // 
            // panelMain
            // 
            resources.ApplyResources(this.panelMain, "panelMain");
            this.panelMain.Name = "panelMain";
            // 
            // tbDescription
            // 
            resources.ApplyResources(this.tbDescription, "tbDescription");
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Properties.AccessibleName = resources.GetString("tbDescription.Properties.AccessibleName");
            this.tbDescription.Properties.AccessibleRole = System.Windows.Forms.AccessibleRole.Client;
            // 
            // panelDescription
            // 
            resources.ApplyResources(this.panelDescription, "panelDescription");
            this.panelDescription.Name = "panelDescription";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.simpleButton1);
            this.panel2.Controls.Add(this.tbsDescription);
            this.panel2.Controls.Add(this.lblSubject);
            this.panel2.Controls.Add(this.edtResource);
            this.panel2.Controls.Add(this.lblResource);
            this.panel2.Controls.Add(this.tbSubject);
            this.panel2.Controls.Add(this.edtEndTime);
            this.panel2.Controls.Add(this.lblLocation);
            this.panel2.Controls.Add(this.edtEndDate);
            this.panel2.Controls.Add(this.lblEndTime);
            this.panel2.Controls.Add(this.lblStartTime);
            this.panel2.Controls.Add(this.edtStartTime);
            this.panel2.Controls.Add(this.edtStartDate);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            resources.ApplyResources(this.simpleButton1, "simpleButton1");
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // tbsDescription
            // 
            resources.ApplyResources(this.tbsDescription, "tbsDescription");
            this.tbsDescription.MenuManager = this.ribbonControl1;
            this.tbsDescription.Name = "tbsDescription";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.backstageViewControl1);
            this.panel3.Controls.Add(this.tbDescription);
            resources.ApplyResources(this.panel3, "panel3");
            this.panel3.Name = "panel3";
            // 
            // defaultBarAndDockingController
            // 
            this.defaultBarAndDockingController.Controller.PropertiesDocking.ViewStyle = DevExpress.XtraBars.Docking2010.Views.DockingViewStyle.Classic;
            // 
            // OutlookAppointmentForm
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.Window;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.progressPanel);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ribbonControl1);
            this.FormBorderEffect = DevExpress.XtraEditors.FormBorderEffect.None;
            this.Name = "OutlookAppointmentForm";
            this.Ribbon = this.ribbonControl1;
            this.ShowInTaskbar = false;
            this.Activated += new System.EventHandler(this.OnAppointmentFormActivated);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backstageViewControl1)).EndInit();
            this.backstageViewControl1.ResumeLayout(false);
            this.bvPrint.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.riAppointmentLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riAppointmentResource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riAppointmentStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.riDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtStartTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtEndTime.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.edtResource.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbSubject.Properties)).EndInit();
            this.progressPanel.ResumeLayout(false);
            this.progressPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbProgress.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbProgress)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbDescription.Properties)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbsDescription.Properties)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.defaultBarAndDockingController.Controller)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        private System.ComponentModel.IContainer components = null;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage rpAppointment;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup rpgActions;
        private DevExpress.XtraBars.BarButtonItem btnSaveAndClose;
        private DevExpress.XtraBars.BarButtonItem btnDelete;
        private RepositoryItemAppointmentLabel riAppointmentLabel;
        private RepositoryItemAppointmentResource riAppointmentResource;
        private RepositoryItemAppointmentStatus riAppointmentStatus;
        private RepositoryItemDuration riDuration;
        protected DevExpress.XtraEditors.LabelControl lblStartTime;
        protected DevExpress.XtraEditors.DateEdit edtStartDate;
        protected DevExpress.XtraEditors.TimeEdit edtStartTime;
        protected DevExpress.XtraEditors.LabelControl lblEndTime;
        protected DevExpress.XtraEditors.DateEdit edtEndDate;
        protected DevExpress.XtraEditors.TimeEdit edtEndTime;
        protected DevExpress.XtraEditors.LabelControl lblLocation;
        protected DevExpress.XtraEditors.LabelControl lblResource;
        protected AppointmentResourceEdit edtResource;
        protected DevExpress.XtraEditors.TextEdit tbSubject;
        protected System.Windows.Forms.Panel progressPanel;
        protected DevExpress.XtraEditors.TrackBarControl tbProgress;
        protected DevExpress.XtraEditors.LabelControl lblPercentCompleteValue;
        protected DevExpress.XtraEditors.LabelControl lblPercentComplete;
        protected DevExpress.XtraEditors.LabelControl lblSubject;
        private System.Windows.Forms.Panel panelMain;
        protected DevExpress.XtraEditors.MemoEdit tbDescription;
        private System.Windows.Forms.Panel panelDescription;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private DevExpress.XtraBars.Ribbon.BackstageViewControl backstageViewControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem bvbSave;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem bvbSaveAs;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem bvbClose;
        private DevExpress.XtraBars.BarButtonItem btnSave;
        private DevExpress.XtraBars.BarButtonItem btnNext;
        private DevExpress.XtraBars.BarButtonItem btnPrevious;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl bvPrint;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem bvtPrint;
        private DevExpress.XtraPrinting.Preview.DocumentViewer dvInfo;
        private DevExpress.XtraEditors.SimpleButton btnPrint;
        private DevExpress.XtraBars.DefaultBarAndDockingController defaultBarAndDockingController;
        private DevExpress.XtraEditors.TextEdit tbsDescription;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}