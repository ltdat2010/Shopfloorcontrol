namespace Production.Class
{
    partial class F_COA_Template_List
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
            this.action1 = new Production.Class.Action();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tblCOATemplateHeaderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sYNC_NUTRICIELDataSet = new Production.SYNC_NUTRICIELDataSet();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCOATemplate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCOADescription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNote = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLocked = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.tbl_COA_Template_HeaderTableAdapter = new Production.SYNC_NUTRICIELDataSetTableAdapters.tbl_COA_Template_HeaderTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCOATemplateHeaderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sYNC_NUTRICIELDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.action1);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(955, 509);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // action1
            // 
            this.action1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(245)))), ((int)(((byte)(241)))));
            this.action1.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.action1.Appearance.Options.UseBackColor = true;
            this.action1.Appearance.Options.UseForeColor = true;
            this.action1.Location = new System.Drawing.Point(12, 12);
            this.action1.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.action1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.action1.Name = "action1";
            this.action1.Size = new System.Drawing.Size(931, 25);
            this.action1.StateMenu = Production.Class.MenuState.Empty;
            this.action1.TabIndex = 5;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tblCOATemplateHeaderBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(12, 41);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(931, 456);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // tblCOATemplateHeaderBindingSource
            // 
            this.tblCOATemplateHeaderBindingSource.DataMember = "tbl_COA_Template_Header";
            this.tblCOATemplateHeaderBindingSource.DataSource = this.sYNC_NUTRICIELDataSet;
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
            this.colCOATemplate,
            this.colCOADescription,
            this.gridColumn1,
            this.colCreatedBy,
            this.colCreatedDate,
            this.colNote,
            this.colLocked});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colID
            // 
            this.colID.Caption = "Số ID";
            this.colID.FieldName = "ID";
            this.colID.Name = "colID";
            this.colID.Visible = true;
            this.colID.VisibleIndex = 0;
            this.colID.Width = 76;
            // 
            // colCOATemplate
            // 
            this.colCOATemplate.Caption = "Tên/ Mã COA ( Mẫu )";
            this.colCOATemplate.FieldName = "COATemplate";
            this.colCOATemplate.Name = "colCOATemplate";
            this.colCOATemplate.Visible = true;
            this.colCOATemplate.VisibleIndex = 1;
            this.colCOATemplate.Width = 89;
            // 
            // colCOADescription
            // 
            this.colCOADescription.Caption = "Diễn giải";
            this.colCOADescription.FieldName = "COADescription";
            this.colCOADescription.Name = "colCOADescription";
            this.colCOADescription.Visible = true;
            this.colCOADescription.VisibleIndex = 2;
            this.colCOADescription.Width = 98;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Image";
            this.gridColumn1.FieldName = "IMGCOA";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 5;
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
            // colNote
            // 
            this.colNote.FieldName = "Note";
            this.colNote.Name = "colNote";
            this.colNote.Visible = true;
            this.colNote.VisibleIndex = 3;
            this.colNote.Width = 76;
            // 
            // colLocked
            // 
            this.colLocked.FieldName = "Locked";
            this.colLocked.Name = "colLocked";
            this.colLocked.Visible = true;
            this.colLocked.VisibleIndex = 4;
            this.colLocked.Width = 76;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Size = new System.Drawing.Size(955, 509);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 29);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(935, 460);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.action1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(935, 29);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // tbl_COA_Template_HeaderTableAdapter
            // 
            this.tbl_COA_Template_HeaderTableAdapter.ClearBeforeFill = true;
            // 
            // F_COA_Template_List
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "F_COA_Template_List";
            this.Size = new System.Drawing.Size(955, 509);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tblCOATemplateHeaderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sYNC_NUTRICIELDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private Action action1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private SYNC_NUTRICIELDataSet sYNC_NUTRICIELDataSet;
        private System.Windows.Forms.BindingSource tblCOATemplateHeaderBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colID;
        private DevExpress.XtraGrid.Columns.GridColumn colCOATemplate;
        private DevExpress.XtraGrid.Columns.GridColumn colCOADescription;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedBy;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedDate;
        private DevExpress.XtraGrid.Columns.GridColumn colNote;
        private DevExpress.XtraGrid.Columns.GridColumn colLocked;
        private SYNC_NUTRICIELDataSetTableAdapters.tbl_COA_Template_HeaderTableAdapter tbl_COA_Template_HeaderTableAdapter;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
    }
}
