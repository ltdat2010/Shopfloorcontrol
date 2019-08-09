namespace Production.Class
{
    partial class F_MYCOTOXIN_ConC
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
            this.tblMYCOTOXINConCBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sYNC_NUTRICIELDataSet = new Production.SYNC_NUTRICIELDataSet();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAcronym = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colConC = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKHMau = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dataNavigator1 = new DevExpress.XtraEditors.DataNavigator();
            this.action1 = new Production.Class.Action();
            this.layoutControlGroup2 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem18 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tbl_MYCOTOXIN_ConCTableAdapter = new Production.SYNC_NUTRICIELDataSetTableAdapters.tbl_MYCOTOXIN_ConCTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).BeginInit();
            this.layoutControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMYCOTOXINConCBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sYNC_NUTRICIELDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
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
            this.groupControl1.Location = new System.Drawing.Point(4, 4);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1106, 540);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "ConC (ng/ml)";
            // 
            // layoutControl2
            // 
            this.layoutControl2.Controls.Add(this.gridControl1);
            this.layoutControl2.Controls.Add(this.dataNavigator1);
            this.layoutControl2.Controls.Add(this.action1);
            this.layoutControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl2.Location = new System.Drawing.Point(2, 22);
            this.layoutControl2.Name = "layoutControl2";
            this.layoutControl2.Root = this.layoutControlGroup2;
            this.layoutControl2.Size = new System.Drawing.Size(1102, 516);
            this.layoutControl2.TabIndex = 0;
            this.layoutControl2.Text = "layoutControl2";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tblMYCOTOXINConCBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(4, 47);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1094, 442);
            this.gridControl1.TabIndex = 21;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // tblMYCOTOXINConCBindingSource
            // 
            this.tblMYCOTOXINConCBindingSource.DataMember = "tbl_MYCOTOXIN_ConC";
            this.tblMYCOTOXINConCBindingSource.DataSource = this.sYNC_NUTRICIELDataSet;
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
            this.colAcronym,
            this.colConC,
            this.colCreatedDate,
            this.colCreatedBy,
            this.colLocked,
            this.colNote,
            this.colKHMau});
            this.gridView1.DetailHeight = 377;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsClipboard.ShowProgress = DevExpress.Export.ProgressMode.Always;
            this.gridView1.OptionsNavigation.EnterMoveNextColumn = true;
            this.gridView1.OptionsView.AllowCellMerge = true;
            this.gridView1.OptionsView.BestFitMode = DevExpress.XtraGrid.Views.Grid.GridBestFitMode.Full;
            this.gridView1.OptionsView.ColumnHeaderAutoHeight = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.ShowAlways;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colID
            // 
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            // 
            // colAcronym
            // 
            this.colAcronym.FieldName = "Acronym";
            this.colAcronym.Name = "colAcronym";
            this.colAcronym.Visible = true;
            this.colAcronym.VisibleIndex = 1;
            // 
            // colConC
            // 
            this.colConC.FieldName = "ConC";
            this.colConC.Name = "colConC";
            this.colConC.Visible = true;
            this.colConC.VisibleIndex = 2;
            // 
            // colCreatedDate
            // 
            this.colCreatedDate.FieldName = "CreatedDate";
            this.colCreatedDate.Name = "colCreatedDate";
            this.colCreatedDate.Visible = true;
            this.colCreatedDate.VisibleIndex = 3;
            // 
            // colCreatedBy
            // 
            this.colCreatedBy.FieldName = "CreatedBy";
            this.colCreatedBy.Name = "colCreatedBy";
            this.colCreatedBy.Visible = true;
            this.colCreatedBy.VisibleIndex = 4;
            // 
            // colLocked
            // 
            this.colLocked.FieldName = "Locked";
            this.colLocked.Name = "colLocked";
            this.colLocked.Visible = true;
            this.colLocked.VisibleIndex = 5;
            // 
            // colNote
            // 
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 6;
            // 
            // colKHMau
            // 
            this.colKHMau.FieldName = "KHMau";
            this.colKHMau.Name = "colKHMau";
            this.colKHMau.Visible = true;
            this.colKHMau.VisibleIndex = 7;
            // 
            // dataNavigator1
            // 
            this.dataNavigator1.Location = new System.Drawing.Point(4, 493);
            this.dataNavigator1.Name = "dataNavigator1";
            this.dataNavigator1.Size = new System.Drawing.Size(228, 19);
            this.dataNavigator1.StyleController = this.layoutControl2;
            this.dataNavigator1.TabIndex = 20;
            this.dataNavigator1.Text = "dataNavigator1";
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
            this.action1.Size = new System.Drawing.Size(1094, 39);
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
            this.layoutControlItem2});
            this.layoutControlGroup2.Name = "layoutControlGroup2";
            this.layoutControlGroup2.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup2.Size = new System.Drawing.Size(1102, 516);
            this.layoutControlGroup2.TextVisible = false;
            // 
            // layoutControlItem18
            // 
            this.layoutControlItem18.Control = this.action1;
            this.layoutControlItem18.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem18.Name = "layoutControlItem18";
            this.layoutControlItem18.Size = new System.Drawing.Size(1098, 43);
            this.layoutControlItem18.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem18.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dataNavigator1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 489);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(1098, 23);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.gridControl1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 43);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(1098, 446);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem4});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup1.Size = new System.Drawing.Size(1114, 548);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.groupControl1;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(1110, 544);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // tbl_MYCOTOXIN_ConCTableAdapter
            // 
            this.tbl_MYCOTOXIN_ConCTableAdapter.ClearBeforeFill = true;
            // 
            // F_MYCOTOXIN_ConC
            // 
            this.Appearance.Font = new System.Drawing.Font("IBM Plex Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.LookAndFeel.SkinName = "Caramel";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "F_MYCOTOXIN_ConC";
            this.Size = new System.Drawing.Size(1114, 548);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl2)).EndInit();
            this.layoutControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblMYCOTOXINConCBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sYNC_NUTRICIELDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
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
        private DevExpress.XtraEditors.DataNavigator dataNavigator1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private SYNC_NUTRICIELDataSet sYNC_NUTRICIELDataSet;
        private System.Windows.Forms.BindingSource tblMYCOTOXINConCBindingSource;
        private SYNC_NUTRICIELDataSetTableAdapters.tbl_MYCOTOXIN_ConCTableAdapter tbl_MYCOTOXIN_ConCTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colAcronym;
        private DevExpress.XtraGrid.Columns.GridColumn colConC;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colLocked;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraGrid.Columns.GridColumn colKHMau;
    }
}
