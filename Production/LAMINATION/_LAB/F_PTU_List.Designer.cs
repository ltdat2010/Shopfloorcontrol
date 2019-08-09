namespace Production.Class
{
    partial class F_PTU_List
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tblPTUHeaderLABBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sYNC_NUTRICIELDataSet = new Production.SYNC_NUTRICIELDataSet();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoPTU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayLapPhieu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayTamUng = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNoiDung = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoTienDaTamUng = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoTienDeNghiThanhToan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoTienTamUng = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVENDCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVENDName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPaymentTerm = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoPO_Note = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoTien_PO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.action1 = new Production.Class.Action();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tbl_PTU_Header_LABTableAdapter = new Production.SYNC_NUTRICIELDataSetTableAdapters.tbl_PTU_Header_LABTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPTUHeaderLABBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sYNC_NUTRICIELDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
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
            this.groupControl1.Size = new System.Drawing.Size(1108, 542);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Danh sách phiếu tạm ứng";
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.gridControl1);
            this.layoutControl2.Controls.Add(this.action1);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 20);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(1104, 520);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tblPTUHeaderLABBindingSource;
            gridLevelNode1.RelationName = "Level1";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(4, 46);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1096, 470);
            this.gridControl1.TabIndex = 20;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // tblPTUHeaderLABBindingSource
            // 
            this.tblPTUHeaderLABBindingSource.DataMember = "tbl_PTU_Header_LAB";
            this.tblPTUHeaderLABBindingSource.DataSource = this.sYNC_NUTRICIELDataSet;
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
            this.colSoPTU,
            this.colNgayLapPhieu,
            this.colNgayTamUng,
            this.colNoiDung,
            this.colCreatedBy,
            this.colCreatedDate,
            this.colNote,
            this.colLocked,
            this.colSoTienDaTamUng,
            this.colSoTienDeNghiThanhToan,
            this.colSoTienTamUng,
            this.colVENDCode,
            this.colVENDName,
            this.colPaymentTerm,
            this.colSoPO_Note,
            this.colSoTien_PO});
            this.gridView1.DetailHeight = 377;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupCount = 1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SoTien_PO", null, "(So Tien_PO: SUM={0:0.##})")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoExpandAllGroups = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colSoPTU, DevExpress.Data.ColumnSortOrder.Ascending),
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colSoTienTamUng, DevExpress.Data.ColumnSortOrder.Descending)});
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Width = 78;
            // 
            // colSoPTU
            // 
            this.colSoPTU.Caption = "Số phiếu tạm ứng";
            this.colSoPTU.FieldName = "SoPTU";
            this.colSoPTU.Name = "colSoPTU";
            this.colSoPTU.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "SoPTU", "SUM={0:0.##}")});
            this.colSoPTU.Visible = true;
            this.colSoPTU.VisibleIndex = 1;
            this.colSoPTU.Width = 59;
            // 
            // colNgayLapPhieu
            // 
            this.colNgayLapPhieu.FieldName = "NgayLapPhieu";
            this.colNgayLapPhieu.Name = "colNgayLapPhieu";
            this.colNgayLapPhieu.Width = 63;
            // 
            // colNgayTamUng
            // 
            this.colNgayTamUng.Caption = "Ngày tạm ứng";
            this.colNgayTamUng.FieldName = "NgayTamUng";
            this.colNgayTamUng.Name = "colNgayTamUng";
            this.colNgayTamUng.Visible = true;
            this.colNgayTamUng.VisibleIndex = 2;
            this.colNgayTamUng.Width = 96;
            // 
            // colNoiDung
            // 
            this.colNoiDung.Caption = "Nội dung";
            this.colNoiDung.FieldName = "NoiDung";
            this.colNoiDung.Name = "colNoiDung";
            this.colNoiDung.Visible = true;
            this.colNoiDung.VisibleIndex = 3;
            this.colNoiDung.Width = 215;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.FieldName = "CreatedBy";
            this.colCreatedBy.Name = "colCreatedBy";
            this.colCreatedBy.Width = 63;
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.Width = 63;
            // 
            // colNote
            // 
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            this.colNote.Width = 63;
            // 
            // colLocked
            // 
            this.colLocked.FieldName = "Locked";
            this.colLocked.Name = "colLocked";
            this.colLocked.Width = 63;
            // 
            // colSoTienDaTamUng
            // 
            this.colSoTienDaTamUng.Caption = "Đã tạm ứng (VND)";
            this.colSoTienDaTamUng.FieldName = "SoTienDaTamUng";
            this.colSoTienDaTamUng.Name = "colSoTienDaTamUng";
            this.colSoTienDaTamUng.Visible = true;
            this.colSoTienDaTamUng.VisibleIndex = 6;
            this.colSoTienDaTamUng.Width = 118;
            // 
            // colSoTienDeNghiThanhToan
            // 
            this.colSoTienDeNghiThanhToan.Caption = "Đề nghị thanh toán (VND)";
            this.colSoTienDeNghiThanhToan.FieldName = "SoTienDeNghiThanhToan";
            this.colSoTienDeNghiThanhToan.Name = "colSoTienDeNghiThanhToan";
            this.colSoTienDeNghiThanhToan.Visible = true;
            this.colSoTienDeNghiThanhToan.VisibleIndex = 7;
            this.colSoTienDeNghiThanhToan.Width = 137;
            // 
            // colSoTienTamUng
            // 
            this.colSoTienTamUng.Caption = "Tạm ứng (VND)";
            this.colSoTienTamUng.FieldName = "SoTienTamUng";
            this.colSoTienTamUng.Name = "colSoTienTamUng";
            this.colSoTienTamUng.Visible = true;
            this.colSoTienTamUng.VisibleIndex = 5;
            this.colSoTienTamUng.Width = 115;
            // 
            // colVENDCode
            // 
            this.colVENDCode.Caption = "Mã đơn vị thực hiện";
            this.colVENDCode.FieldName = "VENDCode";
            this.colVENDCode.Name = "colVENDCode";
            this.colVENDCode.Width = 112;
            // 
            // colVENDName
            // 
            this.colVENDName.Caption = "Tên đơn vị thực hiện";
            this.colVENDName.FieldName = "VENDName";
            this.colVENDName.Name = "colVENDName";
            this.colVENDName.Visible = true;
            this.colVENDName.VisibleIndex = 4;
            this.colVENDName.Width = 215;
            // 
            // colPaymentTerm
            // 
            this.colPaymentTerm.FieldName = "PaymentTerm";
            this.colPaymentTerm.Name = "colPaymentTerm";
            this.colPaymentTerm.Width = 59;
            // 
            // colSoPO_Note
            // 
            this.colSoPO_Note.Caption = "Số đơn mua hàng";
            this.colSoPO_Note.FieldName = "SoPO_Note";
            this.colSoPO_Note.Name = "colSoPO_Note";
            this.colSoPO_Note.Visible = true;
            this.colSoPO_Note.VisibleIndex = 0;
            this.colSoPO_Note.Width = 95;
            // 
            // colSoTien_PO
            // 
            this.colSoTien_PO.Caption = "Tổng cộng đơn mua hàng (VND)";
            this.colSoTien_PO.FieldName = "SoTien_PO";
            this.colSoTien_PO.Name = "colSoTien_PO";
            this.colSoTien_PO.Visible = true;
            this.colSoTien_PO.VisibleIndex = 1;
            this.colSoTien_PO.Width = 76;
            // 
            // action1
            // 
            this.action1.Appearance.ForeColor = System.Drawing.Color.Transparent;
            this.action1.Appearance.Options.UseForeColor = true;
            this.action1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.action1.Location = new System.Drawing.Point(4, 4);
            this.action1.Margin = new System.Windows.Forms.Padding(1);
            this.action1.Name = "action1";
            this.action1.Size = new System.Drawing.Size(1096, 38);
            this.action1.StateMenu = Production.Class.MenuState.Empty;
            this.action1.TabIndex = 19;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem18,
            this.layoutControlItem1});
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup2.Size = new System.Drawing.Size(1104, 520);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.action1;
            this.layoutControlItem18.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(1100, 42);
            this.layoutControlItem18.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem18.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 42);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1100, 474);
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
            // tbl_PTU_Header_LABTableAdapter
            // 
            this.tbl_PTU_Header_LABTableAdapter.ClearBeforeFill = true;
            // 
            // F_PTU_List
            // 
            this.Appearance.Font = new System.Drawing.Font("IBM Plex Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.LookAndFeel.SkinName = "Caramel";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "F_PTU_List";
            this.Size = new System.Drawing.Size(1114, 548);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblPTUHeaderLABBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sYNC_NUTRICIELDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
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
        private SYNC_NUTRICIELDataSet sYNC_NUTRICIELDataSet;
        private System.Windows.Forms.BindingSource tblPTUHeaderLABBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colSoPTU;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayLapPhieu;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayTamUng;
        private DevExpress.XtraGrid.Columns.GridColumn colNoiDung;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraGrid.Columns.GridColumn colLocked;
        private DevExpress.XtraGrid.Columns.GridColumn colSoTienDaTamUng;
        private DevExpress.XtraGrid.Columns.GridColumn colSoTienDeNghiThanhToan;
        private DevExpress.XtraGrid.Columns.GridColumn colSoTienTamUng;
        private DevExpress.XtraGrid.Columns.GridColumn colVENDCode;
        private DevExpress.XtraGrid.Columns.GridColumn colVENDName;
        private DevExpress.XtraGrid.Columns.GridColumn colPaymentTerm;
        private DevExpress.XtraGrid.Columns.GridColumn colSoPO_Note;
        private DevExpress.XtraGrid.Columns.GridColumn colSoTien_PO;
        private SYNC_NUTRICIELDataSetTableAdapters.tbl_PTU_Header_LABTableAdapter tbl_PTU_Header_LABTableAdapter;
    }
}
