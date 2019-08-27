namespace Production.Class
{
    partial class F_PXN_List
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(F_PXN_List));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.btnGiaoMau = new DevExpress.XtraEditors.SimpleButton();
            this.btnViewProcess = new DevExpress.XtraEditors.SimpleButton();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tblPXNHeaderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sYNC_NUTRICIELDataSet = new Production.SYNC_NUTRICIELDataSet();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaSoPXN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPXNDescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCoSoGuiMau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenCoSoGuiMau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhoneCoSoGuiMau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaxCoSoGuiMau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmailCoSoGuiMau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMSTCoSoGuiMau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCoSoLayMau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenCoSoLayMau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPhoneCoSoLayMau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaxCoSoLayMau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmailCoSoLayMau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLock = new DevExpress.XtraGrid.Columns.GridColumn();
            this.action1 = new Production.Class.Action();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tbl_PXN_HeaderTableAdapter = new Production.SYNC_NUTRICIELDataSetTableAdapters.tbl_PXN_HeaderTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPXNHeaderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sYNC_NUTRICIELDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
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
            this.layoutControl1.Size = new System.Drawing.Size(1114, 548);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Location = new System.Drawing.Point(3, 3);
            this.groupControl1.Margin = new System.Windows.Forms.Padding(1);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(1108, 542);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Danh sách phiếu xét nghiệm mẫu";
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.btnGiaoMau);
            this.layoutControl2.Controls.Add(this.btnViewProcess);
            this.layoutControl2.Controls.Add(this.gridControl1);
            this.layoutControl2.Controls.Add(this.action1);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 2);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(1104, 538);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // btnGiaoMau
            // 
            this.btnGiaoMau.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnGiaoMau.ImageOptions.Image")));
            this.btnGiaoMau.Location = new System.Drawing.Point(902, 498);
            this.btnGiaoMau.Name = "btnGiaoMau";
            this.btnGiaoMau.Size = new System.Drawing.Size(88, 36);
            this.btnGiaoMau.StyleController = this.layoutControl2;
            this.btnGiaoMau.TabIndex = 22;
            this.btnGiaoMau.Text = "Giao mẫu";
            // 
            // btnViewProcess
            // 
            this.btnViewProcess.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnViewProcess.ImageOptions.Image")));
            this.btnViewProcess.Location = new System.Drawing.Point(994, 498);
            this.btnViewProcess.Name = "btnViewProcess";
            this.btnViewProcess.Size = new System.Drawing.Size(106, 36);
            this.btnViewProcess.StyleController = this.layoutControl2;
            this.btnViewProcess.TabIndex = 21;
            this.btnViewProcess.Text = "View process";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tblPXNHeaderBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(4, 48);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1096, 446);
            this.gridControl1.TabIndex = 20;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // tblPXNHeaderBindingSource
            // 
            this.tblPXNHeaderBindingSource.DataMember = "tbl_PXN_Header";
            this.tblPXNHeaderBindingSource.DataSource = this.sYNC_NUTRICIELDataSet;
            // 
            // sYNC_NUTRICIELDataSet
            // 
            this.sYNC_NUTRICIELDataSet.DataSetName = "SYNC_NUTRICIELDataSet";
            this.sYNC_NUTRICIELDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colID,
            this.colMaSoPXN,
            this.colPXNDescription,
            this.colCoSoGuiMau,
            this.colTenCoSoGuiMau,
            this.colPhoneCoSoGuiMau,
            this.colFaxCoSoGuiMau,
            this.colEmailCoSoGuiMau,
            this.colMSTCoSoGuiMau,
            this.colCoSoLayMau,
            this.colTenCoSoLayMau,
            this.colPhoneCoSoLayMau,
            this.colFaxCoSoLayMau,
            this.colEmailCoSoLayMau,
            this.colCreatedDate,
            this.colCreatedBy,
            this.colNote,
            this.colLock});
            this.gridView1.DetailHeight = 377;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colCoSoGuiMau, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.MinWidth = 23;
            this.colID.Name = "colID";
            this.colID.Width = 87;
            // 
            // colMaSoPXN
            // 
            this.colMaSoPXN.Caption = "Số PXN";
            this.colMaSoPXN.FieldName = "SoPXN";
            this.colMaSoPXN.MinWidth = 23;
            this.colMaSoPXN.Name = "colMaSoPXN";
            this.colMaSoPXN.Visible = true;
            this.colMaSoPXN.VisibleIndex = 0;
            this.colMaSoPXN.Width = 82;
            // 
            // colPXNDescription
            // 
            this.colPXNDescription.FieldName = "PXNDescription";
            this.colPXNDescription.MinWidth = 23;
            this.colPXNDescription.Name = "colPXNDescription";
            this.colPXNDescription.Width = 87;
            // 
            // colCoSoGuiMau
            // 
            this.colCoSoGuiMau.Caption = "Cơ sở gửi mẫu";
            this.colCoSoGuiMau.FieldName = "CoSoGuiMau";
            this.colCoSoGuiMau.MinWidth = 23;
            this.colCoSoGuiMau.Name = "colCoSoGuiMau";
            this.colCoSoGuiMau.Width = 100;
            // 
            // colTenCoSoGuiMau
            // 
            this.colTenCoSoGuiMau.Caption = "Tên cơ sở gửi mẫu";
            this.colTenCoSoGuiMau.FieldName = "TenCoSoGuiMau";
            this.colTenCoSoGuiMau.MinWidth = 23;
            this.colTenCoSoGuiMau.Name = "colTenCoSoGuiMau";
            this.colTenCoSoGuiMau.Visible = true;
            this.colTenCoSoGuiMau.VisibleIndex = 2;
            this.colTenCoSoGuiMau.Width = 123;
            // 
            // colPhoneCoSoGuiMau
            // 
            this.colPhoneCoSoGuiMau.FieldName = "PhoneCoSoGuiMau";
            this.colPhoneCoSoGuiMau.MinWidth = 23;
            this.colPhoneCoSoGuiMau.Name = "colPhoneCoSoGuiMau";
            this.colPhoneCoSoGuiMau.Width = 87;
            // 
            // colFaxCoSoGuiMau
            // 
            this.colFaxCoSoGuiMau.FieldName = "FaxCoSoGuiMau";
            this.colFaxCoSoGuiMau.MinWidth = 23;
            this.colFaxCoSoGuiMau.Name = "colFaxCoSoGuiMau";
            this.colFaxCoSoGuiMau.Width = 87;
            // 
            // colEmailCoSoGuiMau
            // 
            this.colEmailCoSoGuiMau.FieldName = "EmailCoSoGuiMau";
            this.colEmailCoSoGuiMau.MinWidth = 23;
            this.colEmailCoSoGuiMau.Name = "colEmailCoSoGuiMau";
            this.colEmailCoSoGuiMau.Width = 87;
            // 
            // colMSTCoSoGuiMau
            // 
            this.colMSTCoSoGuiMau.FieldName = "MSTCoSoGuiMau";
            this.colMSTCoSoGuiMau.MinWidth = 23;
            this.colMSTCoSoGuiMau.Name = "colMSTCoSoGuiMau";
            this.colMSTCoSoGuiMau.Width = 87;
            // 
            // colCoSoLayMau
            // 
            this.colCoSoLayMau.Caption = "Cơ sở lấy mẫu";
            this.colCoSoLayMau.FieldName = "CoSoLayMau";
            this.colCoSoLayMau.MinWidth = 23;
            this.colCoSoLayMau.Name = "colCoSoLayMau";
            this.colCoSoLayMau.Width = 189;
            // 
            // colTenCoSoLayMau
            // 
            this.colTenCoSoLayMau.Caption = "Tên cơ sở lấy mẫu";
            this.colTenCoSoLayMau.FieldName = "TenCoSoLayMau";
            this.colTenCoSoLayMau.MinWidth = 23;
            this.colTenCoSoLayMau.Name = "colTenCoSoLayMau";
            this.colTenCoSoLayMau.Visible = true;
            this.colTenCoSoLayMau.VisibleIndex = 3;
            this.colTenCoSoLayMau.Width = 519;
            // 
            // colPhoneCoSoLayMau
            // 
            this.colPhoneCoSoLayMau.FieldName = "PhoneCoSoLayMau";
            this.colPhoneCoSoLayMau.MinWidth = 23;
            this.colPhoneCoSoLayMau.Name = "colPhoneCoSoLayMau";
            this.colPhoneCoSoLayMau.Width = 87;
            // 
            // colFaxCoSoLayMau
            // 
            this.colFaxCoSoLayMau.FieldName = "FaxCoSoLayMau";
            this.colFaxCoSoLayMau.MinWidth = 23;
            this.colFaxCoSoLayMau.Name = "colFaxCoSoLayMau";
            this.colFaxCoSoLayMau.Width = 87;
            // 
            // colEmailCoSoLayMau
            // 
            this.colEmailCoSoLayMau.FieldName = "EmailCoSoLayMau";
            this.colEmailCoSoLayMau.MinWidth = 23;
            this.colEmailCoSoLayMau.Name = "colEmailCoSoLayMau";
            this.colEmailCoSoLayMau.Width = 87;
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.Caption = "Ngày tạo";
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.MinWidth = 23;
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.Visible = true;
            this.colCreatedDate.VisibleIndex = 1;
            this.colCreatedDate.Width = 76;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.FieldName = "CreatedBy";
            this.colCreatedBy.MinWidth = 23;
            this.colCreatedBy.Name = "colCreatedBy";
            this.colCreatedBy.Width = 87;
            // 
            // colNote
            // 
            this.colNote.Caption = "Ghi chú";
            this.colNote.FieldName = "Note";
            this.colNote.MinWidth = 23;
            this.colNote.Name = "colNote";
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 4;
            this.colNote.Width = 183;
            // 
            // colLock
            // 
            this.colLock.Caption = "Khóa";
            this.colLock.FieldName = "Lock";
            this.colLock.MinWidth = 23;
            this.colLock.Name = "colLock";
            this.colLock.Visible = true;
            this.colLock.VisibleIndex = 5;
            this.colLock.Width = 65;
            // 
            // action1
            // 
            this.action1.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.action1.Appearance.Options.UseForeColor = true;
            this.action1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.action1.Location = new System.Drawing.Point(4, 4);
            this.action1.Margin = new System.Windows.Forms.Padding(1);
            this.action1.Name = "action1";
            this.action1.Size = new System.Drawing.Size(1096, 40);
            this.action1.StateMenu = Production.Class.MenuState.Empty;
            this.action1.TabIndex = 19;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem18,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem3});
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup2.Size = new System.Drawing.Size(1104, 538);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.action1;
            this.layoutControlItem18.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(1100, 44);
            this.layoutControlItem18.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem18.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 44);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1100, 450);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.btnViewProcess;
            this.layoutControlItem2.Location = new System.Drawing.Point(990, 494);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(110, 40);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 494);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(898, 40);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.btnGiaoMau;
            this.layoutControlItem3.Location = new System.Drawing.Point(898, 494);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(92, 40);
            this.layoutControlItem3.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem3.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1114, 548);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.groupControl1;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(1112, 546);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // tbl_PXN_HeaderTableAdapter
            // 
            this.tbl_PXN_HeaderTableAdapter.ClearBeforeFill = true;
            // 
            // F_PXN_List
            // 
            this.Appearance.Font = new System.Drawing.Font("IBM Plex Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "F_PXN_List";
            this.Size = new System.Drawing.Size(1114, 548);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPXNHeaderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sYNC_NUTRICIELDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControl layoutControl2;
        private Action action1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem18;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private System.Windows.Forms.BindingSource tblPXNHeaderBindingSource;
        private SYNC_NUTRICIELDataSet sYNC_NUTRICIELDataSet;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colMaSoPXN;
        private DevExpress.XtraGrid.Columns.GridColumn colPXNDescription;
        private DevExpress.XtraGrid.Columns.GridColumn colCoSoGuiMau;
        private DevExpress.XtraGrid.Columns.GridColumn colTenCoSoGuiMau;
        private DevExpress.XtraGrid.Columns.GridColumn colPhoneCoSoGuiMau;
        private DevExpress.XtraGrid.Columns.GridColumn colFaxCoSoGuiMau;
        private DevExpress.XtraGrid.Columns.GridColumn colEmailCoSoGuiMau;
        private DevExpress.XtraGrid.Columns.GridColumn colMSTCoSoGuiMau;
        private DevExpress.XtraGrid.Columns.GridColumn colCoSoLayMau;
        private DevExpress.XtraGrid.Columns.GridColumn colTenCoSoLayMau;
        private DevExpress.XtraGrid.Columns.GridColumn colPhoneCoSoLayMau;
        private DevExpress.XtraGrid.Columns.GridColumn colFaxCoSoLayMau;
        private DevExpress.XtraGrid.Columns.GridColumn colEmailCoSoLayMau;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraGrid.Columns.GridColumn colLock;
        private SYNC_NUTRICIELDataSetTableAdapters.tbl_PXN_HeaderTableAdapter tbl_PXN_HeaderTableAdapter;
        private DevExpress.XtraEditors.SimpleButton btnViewProcess;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton btnGiaoMau;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
    }
}
