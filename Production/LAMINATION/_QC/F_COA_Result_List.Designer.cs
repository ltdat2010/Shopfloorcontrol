namespace Production.Class
{
    partial class F_COA_Result_List
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
            this.tblResultCOATDBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sYNC_NUTRICIELDataSet = new Production.SYNC_NUTRICIELDataSet();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoCOA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCOATemplateID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colWO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSmpDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colExpDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAnlDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colManfBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colManfDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLB_MAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.action1 = new Production.Class.Action();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tbl_Result_COA_TDTableAdapter = new Production.SYNC_NUTRICIELDataSetTableAdapters.tbl_Result_COA_TDTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblResultCOATDBindingSource)).BeginInit();
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
            this.gridControl1.DataSource = this.tblResultCOATDBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(4, 29);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(919, 429);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // tblResultCOATDBindingSource
            // 
            this.tblResultCOATDBindingSource.DataMember = "tbl_Result_COA_TD";
            this.tblResultCOATDBindingSource.DataSource = this.sYNC_NUTRICIELDataSet;
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
            this.colSoCOA,
            this.colCOATemplateID,
            this.colWO,
            this.colSmpDate,
            this.colExpDate,
            this.colAnlDate,
            this.colManfBy,
            this.colManfDate,
            this.colLB_MAT,
            this.colCreatedBy,
            this.colCreatedDate,
            this.colLocked,
            this.colNote});
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
            this.colID.Width = 65;
            // 
            // colSoCOA
            // 
            this.colSoCOA.Caption = "Mã mẫu COA";
            this.colSoCOA.FieldName = "SoCOA";
            this.colSoCOA.Name = "colSoCOA";
            this.colSoCOA.Visible = true;
            this.colSoCOA.VisibleIndex = 1;
            this.colSoCOA.Width = 82;
            // 
            // colCOATemplateID
            // 
            this.colCOATemplateID.FieldName = "COATemplateID";
            this.colCOATemplateID.Name = "colCOATemplateID";
            this.colCOATemplateID.Width = 109;
            // 
            // colWO
            // 
            this.colWO.Caption = "Số Production Order";
            this.colWO.FieldName = "WO";
            this.colWO.Name = "colWO";
            this.colWO.Visible = true;
            this.colWO.VisibleIndex = 2;
            this.colWO.Width = 117;
            // 
            // colSmpDate
            // 
            this.colSmpDate.Caption = "Ngày lấy mẫu";
            this.colSmpDate.FieldName = "SmpDate";
            this.colSmpDate.Name = "colSmpDate";
            this.colSmpDate.Visible = true;
            this.colSmpDate.VisibleIndex = 4;
            this.colSmpDate.Width = 85;
            // 
            // colExpDate
            // 
            this.colExpDate.Caption = "Hạn sử dụng";
            this.colExpDate.FieldName = "ExpDate";
            this.colExpDate.Name = "colExpDate";
            this.colExpDate.Visible = true;
            this.colExpDate.VisibleIndex = 5;
            this.colExpDate.Width = 81;
            // 
            // colAnlDate
            // 
            this.colAnlDate.Caption = "Ngày phân tích";
            this.colAnlDate.FieldName = "AnlDate";
            this.colAnlDate.Name = "colAnlDate";
            this.colAnlDate.Visible = true;
            this.colAnlDate.VisibleIndex = 6;
            this.colAnlDate.Width = 92;
            // 
            // colManfBy
            // 
            this.colManfBy.Caption = "Sản xuất tại";
            this.colManfBy.FieldName = "ManfBy";
            this.colManfBy.Name = "colManfBy";
            this.colManfBy.Visible = true;
            this.colManfBy.VisibleIndex = 7;
            this.colManfBy.Width = 78;
            // 
            // colManfDate
            // 
            this.colManfDate.Caption = "Ngày sản xuất";
            this.colManfDate.FieldName = "ManfDate";
            this.colManfDate.Name = "colManfDate";
            this.colManfDate.Visible = true;
            this.colManfDate.VisibleIndex = 8;
            this.colManfDate.Width = 90;
            // 
            // colLB_MAT
            // 
            this.colLB_MAT.Caption = "Mã sản phẩm";
            this.colLB_MAT.FieldName = "LB_MAT";
            this.colLB_MAT.Name = "colLB_MAT";
            this.colLB_MAT.Visible = true;
            this.colLB_MAT.VisibleIndex = 3;
            this.colLB_MAT.Width = 83;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.FieldName = "CreatedBy";
            this.colCreatedBy.Name = "colCreatedBy";
            this.colCreatedBy.Width = 59;
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.Width = 59;
            // 
            // colLocked
            // 
            this.colLocked.FieldName = "Locked";
            this.colLocked.Name = "colLocked";
            this.colLocked.Visible = true;
            this.colLocked.VisibleIndex = 9;
            this.colLocked.Width = 60;
            // 
            // colNote
            // 
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 10;
            this.colNote.Width = 72;
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
            // tbl_Result_COA_TDTableAdapter
            // 
            this.tbl_Result_COA_TDTableAdapter.ClearBeforeFill = true;
            // 
            // F_COA_Result_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "F_COA_Result_List";
            this.Size = new System.Drawing.Size(955, 509);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblResultCOATDBindingSource)).EndInit();
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
        private System.Windows.Forms.BindingSource tblResultCOATDBindingSource;
        private SYNC_NUTRICIELDataSet sYNC_NUTRICIELDataSet;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colSoCOA;
        private DevExpress.XtraGrid.Columns.GridColumn colCOATemplateID;
        private DevExpress.XtraGrid.Columns.GridColumn colWO;
        private DevExpress.XtraGrid.Columns.GridColumn colSmpDate;
        private DevExpress.XtraGrid.Columns.GridColumn colExpDate;
        private DevExpress.XtraGrid.Columns.GridColumn colAnlDate;
        private DevExpress.XtraGrid.Columns.GridColumn colManfBy;
        private DevExpress.XtraGrid.Columns.GridColumn colManfDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLB_MAT;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLocked;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private SYNC_NUTRICIELDataSetTableAdapters.tbl_Result_COA_TDTableAdapter tbl_Result_COA_TDTableAdapter;
    }
}
