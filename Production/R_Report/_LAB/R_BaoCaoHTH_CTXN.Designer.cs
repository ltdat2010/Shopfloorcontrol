namespace Production.Class
{
    partial class R_BaoCaoHTH_CTXN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(R_BaoCaoHTH_CTXN));
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.lkeCTXN = new DevExpress.XtraEditors.GridLookUpEdit();
            this.tblChiTieuXetNghiemLABBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sYNC_NUTRICIELDataSet = new Production.SYNC_NUTRICIELDataSet();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colMinValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaxValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUnitValue = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCTXN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCTXNDG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCTXNDGTA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNCTXNID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPPXNID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNCTXN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPPXN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDays = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMaCTXN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpr1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAcronym = new DevExpress.XtraGrid.Columns.GridColumn();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.dteYear = new DevExpress.XtraEditors.ComboBoxEdit();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem3 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tbl_ChiTieuXetNghiem_LABTableAdapter = new Production.SYNC_NUTRICIELDataSetTableAdapters.tbl_ChiTieuXetNghiem_LABTableAdapter();
            this.emptySpaceItem2 = new DevExpress.XtraLayout.EmptySpaceItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lkeCTXN.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblChiTieuXetNghiemLABBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sYNC_NUTRICIELDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteYear.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.lkeCTXN);
            this.layoutControl1.Controls.Add(this.simpleButton1);
            this.layoutControl1.Controls.Add(this.dteYear);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(878, 80);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // lkeCTXN
            // 
            this.lkeCTXN.EditValue = "";
            this.lkeCTXN.Location = new System.Drawing.Point(106, 4);
            this.lkeCTXN.Name = "lkeCTXN";
            this.lkeCTXN.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.lkeCTXN.Properties.DataSource = this.tblChiTieuXetNghiemLABBindingSource;
            this.lkeCTXN.Properties.DisplayMember = "CTXN";
            this.lkeCTXN.Properties.PopupView = this.gridLookUpEdit1View;
            this.lkeCTXN.Properties.ValueMember = "ID";
            this.lkeCTXN.Size = new System.Drawing.Size(768, 20);
            this.lkeCTXN.StyleController = this.layoutControl1;
            this.lkeCTXN.TabIndex = 9;
            // 
            // tblChiTieuXetNghiemLABBindingSource
            // 
            this.tblChiTieuXetNghiemLABBindingSource.DataMember = "tbl_ChiTieuXetNghiem_LAB";
            this.tblChiTieuXetNghiemLABBindingSource.DataSource = this.sYNC_NUTRICIELDataSet;
            // 
            // sYNC_NUTRICIELDataSet
            // 
            this.sYNC_NUTRICIELDataSet.DataSetName = "SYNC_NUTRICIELDataSet";
            this.sYNC_NUTRICIELDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colMinValue,
            this.colMaxValue,
            this.colUnitValue,
            this.colNote,
            this.colCTXN,
            this.colCTXNDG,
            this.colCTXNDGTA,
            this.colNCTXNID,
            this.colPPXNID,
            this.colNCTXN,
            this.colPPXN,
            this.colID,
            this.colLocked,
            this.colCreatedBy,
            this.colCreatedDate,
            this.colDays,
            this.colMaCTXN,
            this.colExpr1,
            this.colAcronym});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            this.gridLookUpEdit1View.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colExpr1, DevExpress.Data.ColumnSortOrder.Ascending)});
            // 
            // colMinValue
            // 
            this.colMinValue.FieldName = "MinValue";
            this.colMinValue.Name = "colMinValue";
            // 
            // colMaxValue
            // 
            this.colMaxValue.FieldName = "MaxValue";
            this.colMaxValue.Name = "colMaxValue";
            // 
            // colUnitValue
            // 
            this.colUnitValue.FieldName = "UnitValue";
            this.colUnitValue.Name = "colUnitValue";
            // 
            // colNote
            // 
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            // 
            // colCTXN
            // 
            this.colCTXN.FieldName = "CTXN";
            this.colCTXN.Name = "colCTXN";
            this.colCTXN.Visible = true;
            this.colCTXN.VisibleIndex = 2;
            this.colCTXN.Width = 308;
            // 
            // colCTXNDG
            // 
            this.colCTXNDG.FieldName = "CTXNDG";
            this.colCTXNDG.Name = "colCTXNDG";
            this.colCTXNDG.Visible = true;
            this.colCTXNDG.VisibleIndex = 3;
            this.colCTXNDG.Width = 148;
            // 
            // colCTXNDGTA
            // 
            this.colCTXNDGTA.FieldName = "CTXNDGTA";
            this.colCTXNDGTA.Name = "colCTXNDGTA";
            this.colCTXNDGTA.Visible = true;
            this.colCTXNDGTA.VisibleIndex = 4;
            this.colCTXNDGTA.Width = 196;
            // 
            // colNCTXNID
            // 
            this.colNCTXNID.FieldName = "NCTXNID";
            this.colNCTXNID.Name = "colNCTXNID";
            // 
            // colPPXNID
            // 
            this.colPPXNID.FieldName = "PPXNID";
            this.colPPXNID.Name = "colPPXNID";
            // 
            // colNCTXN
            // 
            this.colNCTXN.FieldName = "NCTXN";
            this.colNCTXN.Name = "colNCTXN";
            this.colNCTXN.Visible = true;
            this.colNCTXN.VisibleIndex = 5;
            this.colNCTXN.Width = 144;
            // 
            // colPPXN
            // 
            this.colPPXN.FieldName = "PPXN";
            this.colPPXN.Name = "colPPXN";
            this.colPPXN.Visible = true;
            this.colPPXN.VisibleIndex = 6;
            this.colPPXN.Width = 78;
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            this.colID.Width = 48;
            // 
            // colLocked
            // 
            this.colLocked.FieldName = "Locked";
            this.colLocked.Name = "colLocked";
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.FieldName = "CreatedBy";
            this.colCreatedBy.Name = "colCreatedBy";
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.Name = "colCreatedDate";
            // 
            // colDays
            // 
            this.colDays.FieldName = "Days";
            this.colDays.Name = "colDays";
            // 
            // colMaCTXN
            // 
            this.colMaCTXN.FieldName = "MaCTXN";
            this.colMaCTXN.Name = "colMaCTXN";
            this.colMaCTXN.Visible = true;
            this.colMaCTXN.VisibleIndex = 1;
            this.colMaCTXN.Width = 72;
            // 
            // colExpr1
            // 
            this.colExpr1.FieldName = "Expr1";
            this.colExpr1.Name = "colExpr1";
            // 
            // colAcronym
            // 
            this.colAcronym.FieldName = "Acronym";
            this.colAcronym.Name = "colAcronym";
            this.colAcronym.Visible = true;
            this.colAcronym.VisibleIndex = 7;
            this.colAcronym.Width = 56;
            // 
            // simpleButton1
            // 
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(813, 52);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(61, 23);
            this.simpleButton1.StyleController = this.layoutControl1;
            this.simpleButton1.TabIndex = 8;
            this.simpleButton1.Text = "Search";
            // 
            // dteYear
            // 
            this.dteYear.Location = new System.Drawing.Point(106, 28);
            this.dteYear.Name = "dteYear";
            this.dteYear.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dteYear.Properties.Appearance.ForeColor = System.Drawing.Color.Blue;
            this.dteYear.Properties.Appearance.Options.UseFont = true;
            this.dteYear.Properties.Appearance.Options.UseForeColor = true;
            this.dteYear.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dteYear.Properties.DisplayFormat.FormatString = "d";
            this.dteYear.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dteYear.Properties.EditFormat.FormatString = "d";
            this.dteYear.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.dteYear.Properties.Items.AddRange(new object[] {
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030",
            "2031",
            "2032",
            "2033",
            "2034",
            "2035",
            "2036",
            "2037",
            "2038",
            "2039",
            "2040"});
            this.dteYear.Size = new System.Drawing.Size(66, 20);
            this.dteYear.StyleController = this.layoutControl1;
            this.dteYear.TabIndex = 10;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.emptySpaceItem1,
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem3,
            this.emptySpaceItem2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup1.Size = new System.Drawing.Size(878, 80);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(0, 48);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(809, 28);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.simpleButton1;
            this.layoutControlItem1.Location = new System.Drawing.Point(809, 48);
            this.layoutControlItem1.MaxSize = new System.Drawing.Size(65, 27);
            this.layoutControlItem1.MinSize = new System.Drawing.Size(65, 27);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(65, 28);
            this.layoutControlItem1.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.lkeCTXN;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(874, 24);
            this.layoutControlItem2.Text = "Chỉ tiêu xét nghiệm :";
            this.layoutControlItem2.TextSize = new System.Drawing.Size(99, 13);
            // 
            // layoutControlItem3
            // 
            this.layoutControlItem3.Control = this.dteYear;
            this.layoutControlItem3.Location = new System.Drawing.Point(0, 24);
            this.layoutControlItem3.MaxSize = new System.Drawing.Size(172, 24);
            this.layoutControlItem3.MinSize = new System.Drawing.Size(172, 24);
            this.layoutControlItem3.Name = "layoutControlItem3";
            this.layoutControlItem3.Size = new System.Drawing.Size(172, 24);
            this.layoutControlItem3.SizeConstraintsType = DevExpress.XtraLayout.SizeConstraintsType.Custom;
            this.layoutControlItem3.Text = "Năm :";
            this.layoutControlItem3.TextSize = new System.Drawing.Size(99, 13);
            // 
            // tbl_ChiTieuXetNghiem_LABTableAdapter
            // 
            this.tbl_ChiTieuXetNghiem_LABTableAdapter.ClearBeforeFill = true;
            // 
            // emptySpaceItem2
            // 
            this.emptySpaceItem2.AllowHotTrack = false;
            this.emptySpaceItem2.Location = new System.Drawing.Point(172, 24);
            this.emptySpaceItem2.Name = "emptySpaceItem2";
            this.emptySpaceItem2.Size = new System.Drawing.Size(702, 24);
            this.emptySpaceItem2.TextSize = new System.Drawing.Size(0, 0);
            // 
            // R_BaoCaoHTH_CTXN
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(878, 80);
            this.Controls.Add(this.layoutControl1);
            this.Name = "R_BaoCaoHTH_CTXN";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chọn chỉ tiêu xét nghiệm cần báo cáo";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.R_BaoCaoHTH_CTXN_Load);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.lkeCTXN.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblChiTieuXetNghiemLABBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sYNC_NUTRICIELDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dteYear.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraEditors.GridLookUpEdit lkeCTXN;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private SYNC_NUTRICIELDataSet sYNC_NUTRICIELDataSet;
        private System.Windows.Forms.BindingSource tblChiTieuXetNghiemLABBindingSource;
        private SYNC_NUTRICIELDataSetTableAdapters.tbl_ChiTieuXetNghiem_LABTableAdapter tbl_ChiTieuXetNghiem_LABTableAdapter;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem3;
        private DevExpress.XtraGrid.Columns.GridColumn colMinValue;
        private DevExpress.XtraGrid.Columns.GridColumn colMaxValue;
        private DevExpress.XtraGrid.Columns.GridColumn colUnitValue;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraGrid.Columns.GridColumn colCTXN;
        private DevExpress.XtraGrid.Columns.GridColumn colCTXNDG;
        private DevExpress.XtraGrid.Columns.GridColumn colCTXNDGTA;
        private DevExpress.XtraGrid.Columns.GridColumn colNCTXNID;
        private DevExpress.XtraGrid.Columns.GridColumn colPPXNID;
        private DevExpress.XtraGrid.Columns.GridColumn colNCTXN;
        private DevExpress.XtraGrid.Columns.GridColumn colPPXN;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colLocked;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colDays;
        private DevExpress.XtraGrid.Columns.GridColumn colMaCTXN;
        private DevExpress.XtraGrid.Columns.GridColumn colExpr1;
        private DevExpress.XtraGrid.Columns.GridColumn colAcronym;
        private DevExpress.XtraEditors.ComboBoxEdit dteYear;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem2;
    }
}