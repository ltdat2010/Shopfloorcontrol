namespace Production.Class
{
    partial class F_PXN_Scheduling_LAB
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_PXN_Scheduling_LAB));
            DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
            DevExpress.XtraScheduler.TimeRuler timeRuler3 = new DevExpress.XtraScheduler.TimeRuler();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.btnOF = new DevExpress.XtraEditors.ButtonEdit();
            this.btnView = new DevExpress.XtraEditors.SimpleButton();
            this.dteend = new DevExpress.XtraEditors.DateEdit();
            this.dtestr = new DevExpress.XtraEditors.DateEdit();
            this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            this.resourcesTree1 = new DevExpress.XtraScheduler.UI.ResourcesTree();
            this.colId = new DevExpress.XtraScheduler.Native.ResourceTreeColumn();
            this.colIdSort = new DevExpress.XtraScheduler.Native.ResourceTreeColumn();
            this.colDescription = new DevExpress.XtraScheduler.Native.ResourceTreeColumn();
            this.schedulerControl1 = new DevExpress.XtraScheduler.SchedulerControl();
            this.schedulerStorage1 = new DevExpress.XtraScheduler.SchedulerStorage(this.components);
            this.taskDependenciesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sYNC_NUTRICIELDataSet = new Production.SYNC_NUTRICIELDataSet();
            this.appointmentsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.resourcesBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.appointmentsTableAdapter = new Production.SYNC_NUTRICIELDataSetTableAdapters.AppointmentsTableAdapter();
            this.resourcesTableAdapter = new Production.SYNC_NUTRICIELDataSetTableAdapters.ResourcesTableAdapter();
            this.taskDependenciesTableAdapter = new Production.SYNC_NUTRICIELDataSetTableAdapters.TaskDependenciesTableAdapter();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnOF.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteend.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteend.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtestr.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtestr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
            this.splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesTree1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskDependenciesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sYNC_NUTRICIELDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.btnOF);
            this.layoutControl1.Controls.Add(this.btnView);
            this.layoutControl1.Controls.Add(this.dteend);
            this.layoutControl1.Controls.Add(this.dtestr);
            this.layoutControl1.Controls.Add(this.splitContainerControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(1111, 495);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // btnOF
            // 
            this.btnOF.Location = new System.Drawing.Point(597, 5);
            this.btnOF.Name = "btnOF";
            this.btnOF.Properties.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.btnOF.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Search)});
            this.btnOF.Properties.ContextImageOptions.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.btnOF.Size = new System.Drawing.Size(50, 20);
            this.btnOF.StyleController = this.layoutControl1;
            this.btnOF.TabIndex = 8;
            this.btnOF.ButtonClick += new DevExpress.XtraEditors.Controls.ButtonPressedEventHandler(this.btnOF_ButtonClick);
            // 
            // btnView
            // 
            this.btnView.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnView.ImageOptions.Image")));
            this.btnView.Location = new System.Drawing.Point(387, 5);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(50, 22);
            this.btnView.StyleController = this.layoutControl1;
            this.btnView.TabIndex = 7;
            this.btnView.Text = "View";
            // 
            // dteend
            // 
            this.dteend.EditValue = null;
            this.dteend.Location = new System.Drawing.Point(270, 5);
            this.dteend.Name = "dteend";
            this.dteend.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteend.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteend.Size = new System.Drawing.Size(113, 20);
            this.dteend.StyleController = this.layoutControl1;
            this.dteend.TabIndex = 6;
            // 
            // dtestr
            // 
            this.dtestr.EditValue = null;
            this.dtestr.Location = new System.Drawing.Point(91, 5);
            this.dtestr.Name = "dtestr";
            this.dtestr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtestr.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtestr.Size = new System.Drawing.Size(89, 20);
            this.dtestr.StyleController = this.layoutControl1;
            this.dtestr.TabIndex = 5;
            // 
            // splitContainerControl1
            // 
            this.splitContainerControl1.Location = new System.Drawing.Point(5, 31);
            this.splitContainerControl1.Name = "splitContainerControl1";
            this.splitContainerControl1.Panel1.Controls.Add(this.resourcesTree1);
            this.splitContainerControl1.Panel1.Text = "Panel1";
            this.splitContainerControl1.Panel2.Controls.Add(this.schedulerControl1);
            this.splitContainerControl1.Panel2.Text = "Panel2";
            this.splitContainerControl1.Size = new System.Drawing.Size(1101, 459);
            this.splitContainerControl1.SplitterPosition = 240;
            this.splitContainerControl1.TabIndex = 4;
            this.splitContainerControl1.Text = "splitContainerControl1";
            // 
            // resourcesTree1
            // 
            this.resourcesTree1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colId,
            this.colIdSort,
            this.colDescription});
            this.resourcesTree1.Cursor = System.Windows.Forms.Cursors.Default;
            this.resourcesTree1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resourcesTree1.Location = new System.Drawing.Point(0, 0);
            this.resourcesTree1.LookAndFeel.SkinName = "Office 2010 Silver";
            this.resourcesTree1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.resourcesTree1.Name = "resourcesTree1";
            this.resourcesTree1.OptionsBehavior.Editable = false;
            this.resourcesTree1.SchedulerControl = this.schedulerControl1;
            this.resourcesTree1.Size = new System.Drawing.Size(240, 459);
            this.resourcesTree1.TabIndex = 0;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colIdSort
            // 
            this.colIdSort.FieldName = "IdSort";
            this.colIdSort.Name = "colIdSort";
            // 
            // colDescription
            // 
            this.colDescription.Caption = "WO/ OF";
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 0;
            // 
            // schedulerControl1
            // 
            this.schedulerControl1.ActiveViewType = DevExpress.XtraScheduler.SchedulerViewType.Gantt;
            this.schedulerControl1.DataStorage = this.schedulerStorage1;
            this.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.schedulerControl1.GroupType = DevExpress.XtraScheduler.SchedulerGroupType.Resource;
            this.schedulerControl1.Location = new System.Drawing.Point(0, 0);
            this.schedulerControl1.LookAndFeel.SkinName = "Office 2010 Silver";
            this.schedulerControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.schedulerControl1.Name = "schedulerControl1";
            this.schedulerControl1.OptionsView.FirstDayOfWeek = DevExpress.XtraScheduler.FirstDayOfWeek.Monday;
            this.schedulerControl1.PaintStyleName = "Skin";
            this.schedulerControl1.Size = new System.Drawing.Size(849, 459);
            this.schedulerControl1.Start = new System.DateTime(2018, 12, 31, 0, 0, 0, 0);
            this.schedulerControl1.TabIndex = 0;
            this.schedulerControl1.Text = "schedulerControl1";
            this.schedulerControl1.Views.AgendaView.Enabled = false;
            this.schedulerControl1.Views.DayView.Enabled = false;
            this.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1);
            this.schedulerControl1.Views.FullWeekView.TimeRulers.Add(timeRuler2);
            this.schedulerControl1.Views.GanttView.WorkTime = new DevExpress.XtraScheduler.WorkTimeInterval(System.TimeSpan.Parse("08:00:00"), System.TimeSpan.Parse("17:00:00"));
            this.schedulerControl1.Views.MonthView.Enabled = false;
            this.schedulerControl1.Views.TimelineView.CellsAutoHeightOptions.Enabled = true;
            this.schedulerControl1.Views.TimelineView.Enabled = false;
            this.schedulerControl1.Views.WeekView.Enabled = false;
            this.schedulerControl1.Views.WorkWeekView.Enabled = false;
            this.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler3);
            this.schedulerControl1.EditAppointmentFormShowing += new DevExpress.XtraScheduler.AppointmentFormEventHandler(this.schedulerControl1_EditAppointmentFormShowing_3);
            // 
            // schedulerStorage1
            // 
            this.schedulerStorage1.AppointmentDependencies.DataSource = this.taskDependenciesBindingSource;
            this.schedulerStorage1.AppointmentDependencies.Mappings.DependentId = "DependentId";
            this.schedulerStorage1.AppointmentDependencies.Mappings.ParentId = "ParentId";
            this.schedulerStorage1.AppointmentDependencies.Mappings.Type = "Type";
            this.schedulerStorage1.Appointments.DataSource = this.appointmentsBindingSource;
            this.schedulerStorage1.Appointments.Mappings.AllDay = "AllDay";
            this.schedulerStorage1.Appointments.Mappings.AppointmentId = "UniqueId";
            this.schedulerStorage1.Appointments.Mappings.Description = "Description";
            this.schedulerStorage1.Appointments.Mappings.End = "EndDate";
            this.schedulerStorage1.Appointments.Mappings.Label = "Label";
            this.schedulerStorage1.Appointments.Mappings.Location = "Location";
            this.schedulerStorage1.Appointments.Mappings.PercentComplete = "PercentComplete";
            this.schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "RecurrenceInfo";
            this.schedulerStorage1.Appointments.Mappings.ReminderInfo = "ReminderInfo";
            this.schedulerStorage1.Appointments.Mappings.ResourceId = "ResourceId";
            this.schedulerStorage1.Appointments.Mappings.Start = "StartDate";
            this.schedulerStorage1.Appointments.Mappings.Status = "Status";
            this.schedulerStorage1.Appointments.Mappings.Subject = "Subject";
            this.schedulerStorage1.Appointments.Mappings.TimeZoneId = "TimeZoneId";
            this.schedulerStorage1.Appointments.Mappings.Type = "Type";
            this.schedulerStorage1.Resources.CustomFieldMappings.Add(new DevExpress.XtraScheduler.ResourceCustomFieldMapping("CustomField1", "CustomField1"));
            this.schedulerStorage1.Resources.CustomFieldMappings.Add(new DevExpress.XtraScheduler.ResourceCustomFieldMapping("IdSort", "IdSort"));
            this.schedulerStorage1.Resources.DataSource = this.resourcesBindingSource;
            this.schedulerStorage1.Resources.Mappings.Caption = "Description";
            this.schedulerStorage1.Resources.Mappings.Color = "Color";
            this.schedulerStorage1.Resources.Mappings.Id = "Id";
            this.schedulerStorage1.Resources.Mappings.Image = "Image";
            this.schedulerStorage1.Resources.Mappings.ParentId = "ParentId";
            // 
            // taskDependenciesBindingSource
            // 
            this.taskDependenciesBindingSource.DataMember = "TaskDependencies";
            this.taskDependenciesBindingSource.DataSource = this.sYNC_NUTRICIELDataSet;
            // 
            // sYNC_NUTRICIELDataSet
            // 
            this.sYNC_NUTRICIELDataSet.DataSetName = "SYNC_NUTRICIELDataSet";
            this.sYNC_NUTRICIELDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // appointmentsBindingSource
            // 
            this.appointmentsBindingSource.DataMember = "Appointments";
            this.appointmentsBindingSource.DataSource = this.sYNC_NUTRICIELDataSet;
            // 
            // resourcesBindingSource
            // 
            this.resourcesBindingSource.DataMember = "Resources";
            this.resourcesBindingSource.DataSource = this.sYNC_NUTRICIELDataSet;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.layoutControlItem4,
            this.emptySpaceItem1,
            this.layoutControlItem5,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(3, 3, 3, 3);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1111, 495);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.splitContainerControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 26);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1105, 463);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dtestr;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(179, 26);
            this.layoutControlItem2.Text = "Start Date :";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(83, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dteend;
            this.layoutControlItem3.Location = new System.Drawing.Point(179, 0);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(203, 26);
            this.layoutControlItem3.Text = "End Date :";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(83, 13);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.btnView;
            this.layoutControlItem4.Location = new System.Drawing.Point(382, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(54, 26);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(646, 0);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(459, 26);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.btnOF;
            this.layoutControlItem5.Location = new System.Drawing.Point(506, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(140, 26);
            this.layoutControlItem5.Text = "WO/OF Number :";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(83, 13);
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(436, 0);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(70, 26);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // appointmentsTableAdapter
            // 
            this.appointmentsTableAdapter.ClearBeforeFill = true;
            // 
            // resourcesTableAdapter
            // 
            this.resourcesTableAdapter.ClearBeforeFill = true;
            // 
            // taskDependenciesTableAdapter
            // 
            this.taskDependenciesTableAdapter.ClearBeforeFill = true;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2016 Colorful";
            // 
            // F_PXN_Scheduling_LAB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 495);
            this.Controls.Add(this.layoutControl1);
            this.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.Name = "F_PXN_Scheduling_LAB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Production date ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.F_OFScheduling_Pro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnOF.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteend.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteend.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtestr.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtestr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
            this.splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.resourcesTree1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.schedulerStorage1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.taskDependenciesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sYNC_NUTRICIELDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.appointmentsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resourcesBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraScheduler.UI.ResourcesTree resourcesTree1;
        private DevExpress.XtraScheduler.SchedulerControl schedulerControl1;
        private DevExpress.XtraScheduler.SchedulerStorage schedulerStorage1;
        private SYNC_NUTRICIELDataSet sYNC_NUTRICIELDataSet;
        private System.Windows.Forms.BindingSource appointmentsBindingSource;
        private SYNC_NUTRICIELDataSetTableAdapters.AppointmentsTableAdapter appointmentsTableAdapter;
        private System.Windows.Forms.BindingSource resourcesBindingSource;
        private SYNC_NUTRICIELDataSetTableAdapters.ResourcesTableAdapter resourcesTableAdapter;
        private System.Windows.Forms.BindingSource taskDependenciesBindingSource;
        private SYNC_NUTRICIELDataSetTableAdapters.TaskDependenciesTableAdapter taskDependenciesTableAdapter;
        private DevExpress.XtraScheduler.Native.ResourceTreeColumn colId;
        private DevExpress.XtraScheduler.Native.ResourceTreeColumn colIdSort;
        private DevExpress.XtraScheduler.Native.ResourceTreeColumn colDescription;
        private DevExpress.XtraEditors.DateEdit dteend;
        private DevExpress.XtraEditors.DateEdit dtestr;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraEditors.SimpleButton btnView;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.ButtonEdit btnOF;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
    }
}