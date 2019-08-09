namespace Production.Class
{
    partial class F_LOCATION
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
            this.components = new System.ComponentModel.Container();
            this.SSM = new DevExpress.XtraSplashScreen.SplashScreenManager();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.dataNavigator1 = new DevExpress.XtraEditors.DataNavigator();
            this.tblLOCATIONLABBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sYNC_NUTRICIELDataSet = new Production.SYNC_NUTRICIELDataSet();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.Id = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLOCName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLOCCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.action1 = new Production.Class.Action();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.tbl_LOCATION_LABTableAdapter = new Production.SYNC_NUTRICIELDataSetTableAdapters.tbl_LOCATION_LABTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tblLOCATIONLABBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sYNC_NUTRICIELDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.groupControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(931, 548);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Location = new System.Drawing.Point(4, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(923, 540);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "DANH SÁCH KHU VỰC";
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.dataNavigator1);
            this.layoutControl2.Controls.Add(this.gridControl1);
            this.layoutControl2.Controls.Add(this.action1);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 22);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(919, 516);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // dataNavigator1
            // 
            this.dataNavigator1.DataSource = this.tblLOCATIONLABBindingSource;
            this.dataNavigator1.Location = new System.Drawing.Point(4, 493);
            this.dataNavigator1.Name = "dataNavigator1";
            this.dataNavigator1.Size = new System.Drawing.Size(331, 19);
            this.dataNavigator1.StyleController = this.layoutControl2;
            this.dataNavigator1.TabIndex = 20;
            this.dataNavigator1.Text = "dataNavigator1";
            this.dataNavigator1.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.Center;
            // 
            // tblLOCATIONLABBindingSource
            // 
            this.tblLOCATIONLABBindingSource.DataMember = "tbl_LOCATION_LAB";
            this.tblLOCATIONLABBindingSource.DataSource = this.sYNC_NUTRICIELDataSet;
            // 
            // sYNC_NUTRICIELDataSet
            // 
            this.sYNC_NUTRICIELDataSet.DataSetName = "SYNC_NUTRICIELDataSet";
            this.sYNC_NUTRICIELDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tblLOCATIONLABBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(4, 50);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(911, 439);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.Id,
            this.colLOCName,
            this.colLOCCode,
            this.colCreatedDate,
            this.colCreatedBy,
            this.colLocked});
            this.gridView1.DetailHeight = 377;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // Id
            // 
            this.Id.Caption = "Mã code";
            this.Id.FieldName = "Id";
            this.Id.MinWidth = 23;
            this.Id.Name = "Id";
            this.Id.Width = 64;
            // 
            // colLOCName
            // 
            this.colLOCName.Caption = "Tên vùng";
            this.colLOCName.FieldName = "LOCName";
            this.colLOCName.MinWidth = 23;
            this.colLOCName.Name = "colLOCName";
            this.colLOCName.Visible = true;
            this.colLOCName.VisibleIndex = 1;
            this.colLOCName.Width = 201;
            // 
            // colLOCCode
            // 
            this.colLOCCode.Caption = "Mã vùng";
            this.colLOCCode.FieldName = "LOCCode";
            this.colLOCCode.MinWidth = 23;
            this.colLOCCode.Name = "colLOCCode";
            this.colLOCCode.Visible = true;
            this.colLOCCode.VisibleIndex = 0;
            this.colLOCCode.Width = 201;
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.MinWidth = 23;
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.Width = 201;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.FieldName = "CreatedBy";
            this.colCreatedBy.MinWidth = 23;
            this.colCreatedBy.Name = "colCreatedBy";
            this.colCreatedBy.Width = 201;
            // 
            // colLocked
            // 
            this.colLocked.FieldName = "Locked";
            this.colLocked.MinWidth = 23;
            this.colLocked.Name = "colLocked";
            this.colLocked.Width = 207;
            // 
            // action1
            // 
            this.action1.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.action1.Appearance.Options.UseForeColor = true;
            this.action1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.action1.Location = new System.Drawing.Point(4, 4);
            this.action1.LookAndFeel.SkinName = "Caramel";
            this.action1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.action1.Margin = new System.Windows.Forms.Padding(1);
            this.action1.Name = "action1";
            this.action1.Size = new System.Drawing.Size(911, 42);
            this.action1.StateMenu = Production.Class.MenuState.Empty;
            this.action1.TabIndex = 19;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem18,
            this.layoutControlItem5,
            this.layoutControlItem1});
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup2.Size = new System.Drawing.Size(919, 516);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.action1;
            this.layoutControlItem18.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(915, 46);
            this.layoutControlItem18.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem18.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.gridControl1;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 46);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(915, 443);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dataNavigator1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 489);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(915, 23);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup1.Size = new System.Drawing.Size(931, 548);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.groupControl1;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(927, 544);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2016 Colorful";
            // 
            // tbl_LOCATION_LABTableAdapter
            // 
            this.tbl_LOCATION_LABTableAdapter.ClearBeforeFill = true;
            // 
            // F_LOCATION
            // 
            this.Appearance.Font = new System.Drawing.Font("IBM Plex Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.LookAndFeel.SkinName = "Caramel";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "F_LOCATION";
            this.Size = new System.Drawing.Size(931, 548);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.tblLOCATIONLABBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sYNC_NUTRICIELDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private Action action1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private System.Windows.Forms.BindingSource tblLOCATIONLABBindingSource;
        private SYNC_NUTRICIELDataSet sYNC_NUTRICIELDataSet;
        private DevExpress.XtraGrid.Columns.GridColumn Id;
        private DevExpress.XtraGrid.Columns.GridColumn colLOCName;
        private DevExpress.XtraGrid.Columns.GridColumn colLOCCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colLocked;
        private SYNC_NUTRICIELDataSetTableAdapters.tbl_LOCATION_LABTableAdapter tbl_LOCATION_LABTableAdapter;
        private DevExpress.XtraEditors.DataNavigator dataNavigator1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraSplashScreen.SplashScreenManager SSM;
    }
}
