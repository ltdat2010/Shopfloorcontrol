namespace Production.Class
{
    partial class F_KQKN_Result_List
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.layoutControl2 = new DevExpress.XtraLayout.LayoutControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.resultKQKNListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sYNC_NUTRICIELDataSet = new Production.SYNC_NUTRICIELDataSet();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoPKN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKQKNTemplateID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoPNK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSLNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayNhan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSolo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTenNL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLan = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQCDG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgaySX = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHSD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgayPT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUoM1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUoM2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colQCDG_Full = new DevExpress.XtraGrid.Columns.GridColumn();
            this.action1 = new Production.Class.Action();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.result_KQKN_ListTableAdapter = new Production.SYNC_NUTRICIELDataSetTableAdapters.Result_KQKN_ListTableAdapter();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultKQKNListBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sYNC_NUTRICIELDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
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
            this.layoutControl1.Size = new System.Drawing.Size(955, 509);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(931, 485);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Form Chỉ Tiêu Phân Tích";
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.gridControl1);
            this.layoutControl2.Controls.Add(this.action1);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 21);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(927, 462);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.resultKQKNListBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(4, 29);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(919, 429);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // resultKQKNListBindingSource
            // 
            this.resultKQKNListBindingSource.DataMember = "Result_KQKN_List";
            this.resultKQKNListBindingSource.DataSource = this.sYNC_NUTRICIELDataSet;
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
            this.colSoPKN,
            this.colKQKNTemplateID,
            this.gridColumn1,
            this.colSoPNK,
            this.colSLNhan,
            this.colNgayNhan,
            this.colSolo,
            this.colTenNL,
            this.colLan,
            this.colNote,
            this.colQCDG,
            this.colNgaySX,
            this.colHSD,
            this.colNgayPT,
            this.colUoM1,
            this.colUoM2,
            this.colQCDG_Full});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsFind.AlwaysVisible = true;
            this.gridView1.OptionsFind.FindMode = DevExpress.XtraEditors.FindMode.Always;
            this.gridView1.OptionsFind.ShowClearButton = false;
            this.gridView1.OptionsFind.ShowCloseButton = false;
            this.gridView1.OptionsFind.ShowFindButton = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colID
            // 
            this.colID.Caption = "Số ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            this.colID.Width = 70;
            // 
            // colSoPKN
            // 
            this.colSoPKN.Caption = "Số Phiếu kiểm nghiệm";
            this.colSoPKN.FieldName = "SoPKN";
            this.colSoPKN.Name = "colSoPKN";
            this.colSoPKN.Visible = true;
            this.colSoPKN.VisibleIndex = 1;
            this.colSoPKN.Width = 143;
            // 
            // colKQKNTemplateID
            // 
            this.colKQKNTemplateID.FieldName = "KQKNTemplateID";
            this.colKQKNTemplateID.Name = "colKQKNTemplateID";
            this.colKQKNTemplateID.Width = 125;
            // 
            // colSoPNK
            // 
            this.colSoPNK.Caption = "Số Phiếu kiểm nghiệm";
            this.colSoPNK.FieldName = "SoPNK";
            this.colSoPNK.Name = "colSoPNK";
            this.colSoPNK.Width = 125;
            // 
            // colSLNhan
            // 
            this.colSLNhan.Caption = "Số lượng nhận";
            this.colSLNhan.FieldName = "SLNhan";
            this.colSLNhan.Name = "colSLNhan";
            this.colSLNhan.Visible = true;
            this.colSLNhan.VisibleIndex = 3;
            this.colSLNhan.Width = 89;
            // 
            // colNgayNhan
            // 
            this.colNgayNhan.Caption = "Ngày nhận";
            this.colNgayNhan.FieldName = "NgayNhan";
            this.colNgayNhan.Name = "colNgayNhan";
            this.colNgayNhan.Visible = true;
            this.colNgayNhan.VisibleIndex = 6;
            this.colNgayNhan.Width = 96;
            // 
            // colSolo
            // 
            this.colSolo.Caption = "Số lô";
            this.colSolo.FieldName = "Solo";
            this.colSolo.Name = "colSolo";
            this.colSolo.Visible = true;
            this.colSolo.VisibleIndex = 4;
            this.colSolo.Width = 44;
            // 
            // colTenNL
            // 
            this.colTenNL.Caption = "Tên nguyên liệu";
            this.colTenNL.FieldName = "TenNL";
            this.colTenNL.Name = "colTenNL";
            this.colTenNL.Visible = true;
            this.colTenNL.VisibleIndex = 5;
            this.colTenNL.Width = 96;
            // 
            // colLan
            // 
            this.colLan.FieldName = "Lan";
            this.colLan.Name = "colLan";
            this.colLan.Width = 43;
            // 
            // colNote
            // 
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 10;
            this.colNote.Width = 44;
            // 
            // colQCDG
            // 
            this.colQCDG.FieldName = "QCDG";
            this.colQCDG.Name = "colQCDG";
            this.colQCDG.Width = 43;
            // 
            // colNgaySX
            // 
            this.colNgaySX.Caption = "Ngày sản xuất";
            this.colNgaySX.FieldName = "NgaySX";
            this.colNgaySX.Name = "colNgaySX";
            this.colNgaySX.Visible = true;
            this.colNgaySX.VisibleIndex = 7;
            this.colNgaySX.Width = 90;
            // 
            // colHSD
            // 
            this.colHSD.Caption = "Hạn sử dụng";
            this.colHSD.FieldName = "HSD";
            this.colHSD.Name = "colHSD";
            this.colHSD.Visible = true;
            this.colHSD.VisibleIndex = 8;
            this.colHSD.Width = 81;
            // 
            // colNgayPT
            // 
            this.colNgayPT.Caption = "Ngày phân tích";
            this.colNgayPT.FieldName = "NgayPT";
            this.colNgayPT.Name = "colNgayPT";
            this.colNgayPT.Visible = true;
            this.colNgayPT.VisibleIndex = 9;
            this.colNgayPT.Width = 92;
            // 
            // colUoM1
            // 
            this.colUoM1.FieldName = "UoM1";
            this.colUoM1.Name = "colUoM1";
            this.colUoM1.Width = 43;
            // 
            // colUoM2
            // 
            this.colUoM2.FieldName = "UoM2";
            this.colUoM2.Name = "colUoM2";
            this.colUoM2.Width = 43;
            // 
            // colQCDG_Full
            // 
            this.colQCDG_Full.FieldName = "QCDG_Full";
            this.colQCDG_Full.Name = "colQCDG_Full";
            this.colQCDG_Full.Width = 101;
            // 
            // action1
            // 
            this.action1.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.action1.Appearance.Options.UseForeColor = true;
            this.action1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.action1.Location = new System.Drawing.Point(4, 4);
            this.action1.LookAndFeel.SkinName = "Money Twins";
            this.action1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.action1.Margin = new System.Windows.Forms.Padding(1);
            this.action1.Name = "action1";
            this.action1.Size = new System.Drawing.Size(919, 21);
            this.action1.StateMenu = Production.Class.MenuState.Empty;
            this.action1.TabIndex = 19;
            // 
            // layoutControlGroup2
            // 
            this.layoutControlGroup2.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup2.GroupBordersVisible = false;
            this.layoutControlGroup2.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem18,
            this.layoutControlItem5});
            this.layoutControlGroup2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup2.Size = new System.Drawing.Size(927, 462);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.action1;
            this.layoutControlItem18.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(923, 25);
            this.layoutControlItem18.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem18.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.gridControl1;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 25);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(923, 433);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(955, 509);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.groupControl1;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(935, 489);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // result_KQKN_ListTableAdapter
            // 
            this.result_KQKN_ListTableAdapter.ClearBeforeFill = true;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Số MRA";
            this.gridColumn1.FieldName = "SoMRA";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 2;
            // 
            // F_KQKN_Result_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "F_KQKN_Result_List";
            this.Size = new System.Drawing.Size(955, 509);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.resultKQKNListBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sYNC_NUTRICIELDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
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
        private SYNC_NUTRICIELDataSetTableAdapters.tbl_KQKNTemplateTableAdapter tbl_KQKNTemplateTableAdapter;
        private System.Windows.Forms.BindingSource resultKQKNListBindingSource;
        private SYNC_NUTRICIELDataSet sYNC_NUTRICIELDataSet;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colSoPKN;
        private DevExpress.XtraGrid.Columns.GridColumn colKQKNTemplateID;
        private DevExpress.XtraGrid.Columns.GridColumn colSoPNK;
        private DevExpress.XtraGrid.Columns.GridColumn colSLNhan;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayNhan;
        private DevExpress.XtraGrid.Columns.GridColumn colSolo;
        private DevExpress.XtraGrid.Columns.GridColumn colTenNL;
        private DevExpress.XtraGrid.Columns.GridColumn colLan;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraGrid.Columns.GridColumn colQCDG;
        private DevExpress.XtraGrid.Columns.GridColumn colNgaySX;
        private DevExpress.XtraGrid.Columns.GridColumn colHSD;
        private DevExpress.XtraGrid.Columns.GridColumn colNgayPT;
        private DevExpress.XtraGrid.Columns.GridColumn colUoM1;
        private DevExpress.XtraGrid.Columns.GridColumn colUoM2;
        private DevExpress.XtraGrid.Columns.GridColumn colQCDG_Full;
        private SYNC_NUTRICIELDataSetTableAdapters.Result_KQKN_ListTableAdapter result_KQKN_ListTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}
