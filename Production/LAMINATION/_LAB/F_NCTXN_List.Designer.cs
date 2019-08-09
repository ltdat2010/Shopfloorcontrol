namespace Production.Class
{
    partial class F_NCTXN_List
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
            this.tblNhomChiTieuXetNghiemLABBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sYNC_NUTRICIELDataSet = new Production.SYNC_NUTRICIELDataSet();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNCTXN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNCTXNDG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.action1 = new Production.Class.Action();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            this.tbl_NhomChiTieuXetNghiem_LABTableAdapter = new Production.SYNC_NUTRICIELDataSetTableAdapters.tbl_NhomChiTieuXetNghiem_LABTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblNhomChiTieuXetNghiemLABBindingSource)).BeginInit();
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
            this.layoutControl1.Size = new System.Drawing.Size(1114, 548);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.layoutControl2);
            this.groupControl1.Location = new System.Drawing.Point(12, 12);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1090, 524);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Form Nhóm chỉ tiêu xét nghiệm";
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.gridControl1);
            this.layoutControl2.Controls.Add(this.action1);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 22);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(1086, 500);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tblNhomChiTieuXetNghiemLABBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(4, 34);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1078, 462);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // tblNhomChiTieuXetNghiemLABBindingSource
            // 
            this.tblNhomChiTieuXetNghiemLABBindingSource.DataMember = "tbl_NhomChiTieuXetNghiem_LAB";
            this.tblNhomChiTieuXetNghiemLABBindingSource.DataSource = this.sYNC_NUTRICIELDataSet;
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
            this.colCreatedBy,
            this.colCreatedDate,
            this.colLocked,
            this.colNote,
            this.colNCTXN,
            this.colNCTXNDG});
            this.gridView1.DetailHeight = 377;
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
            this.colID.FieldName = "ID";
            this.colID.MinWidth = 23;
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            this.colID.Width = 87;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.FieldName = "CreatedBy";
            this.colCreatedBy.MinWidth = 23;
            this.colCreatedBy.Name = "colCreatedBy";
            this.colCreatedBy.Width = 87;
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.MinWidth = 23;
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.Width = 87;
            // 
            // colLocked
            // 
            this.colLocked.FieldName = "Locked";
            this.colLocked.MinWidth = 23;
            this.colLocked.Name = "colLocked";
            this.colLocked.Visible = true;
            this.colLocked.VisibleIndex = 3;
            this.colLocked.Width = 87;
            // 
            // colNote
            // 
            this.colNote.FieldName = "Note";
            this.colNote.MinWidth = 23;
            this.colNote.Name = "colNote";
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 4;
            this.colNote.Width = 87;
            // 
            // colNCTXN
            // 
            this.colNCTXN.Caption = "Nhóm chỉ tiêu xét nghiệm";
            this.colNCTXN.FieldName = "NCTXN";
            this.colNCTXN.MinWidth = 23;
            this.colNCTXN.Name = "colNCTXN";
            this.colNCTXN.Visible = true;
            this.colNCTXN.VisibleIndex = 1;
            this.colNCTXN.Width = 87;
            // 
            // colNCTXNDG
            // 
            this.colNCTXNDG.Caption = "Diễn giải";
            this.colNCTXNDG.FieldName = "NCTXNDG";
            this.colNCTXNDG.MinWidth = 23;
            this.colNCTXNDG.Name = "colNCTXNDG";
            this.colNCTXNDG.Visible = true;
            this.colNCTXNDG.VisibleIndex = 2;
            this.colNCTXNDG.Width = 89;
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
            this.action1.Size = new System.Drawing.Size(1078, 26);
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
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup2.Size = new System.Drawing.Size(1086, 500);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.action1;
            this.layoutControlItem18.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(1082, 30);
            this.layoutControlItem18.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem18.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.gridControl1;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 30);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(1082, 466);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(1114, 548);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.groupControl1;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(1094, 528);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2016 Colorful";
            // 
            // tbl_NhomChiTieuXetNghiem_LABTableAdapter
            // 
            this.tbl_NhomChiTieuXetNghiem_LABTableAdapter.ClearBeforeFill = true;
            // 
            // F_NCTXN_List
            // 
            this.Appearance.Font = new System.Drawing.Font("IBM Plex Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.LookAndFeel.SkinName = "Caramel";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "F_NCTXN_List";
            this.Size = new System.Drawing.Size(1114, 548);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblNhomChiTieuXetNghiemLABBindingSource)).EndInit();
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
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
        private System.Windows.Forms.BindingSource tblNhomChiTieuXetNghiemLABBindingSource;
        private SYNC_NUTRICIELDataSet sYNC_NUTRICIELDataSet;
        private SYNC_NUTRICIELDataSetTableAdapters.tbl_NhomChiTieuXetNghiem_LABTableAdapter tbl_NhomChiTieuXetNghiem_LABTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colLocked;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraGrid.Columns.GridColumn colNCTXN;
        private DevExpress.XtraGrid.Columns.GridColumn colNCTXNDG;
    }
}
