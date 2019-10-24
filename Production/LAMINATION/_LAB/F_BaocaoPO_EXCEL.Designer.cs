namespace Production.LAMINATION._LAB
{
    partial class F_BaocaoPO_EXCEL
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.filter_Vertical1 = new Production.LAMINATION._GEN._UC.Filter_Vertical();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.baoCaoPOBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sYNC_NUTRICIEL_REPORT = new Production.SYNC_NUTRICIEL_REPORT();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSốPO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNgàyPO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMÃNHÀCUNGCẤP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNHÀCUNGCẤP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCODEMẪU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTÊNKHÁCHHÀNG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCODEXN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTÊNXÉTNGHIỆM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colĐơnGiáchưaVAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTiềnthuế = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTổngtiền = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGiảmgiá = new DevExpress.XtraGrid.Columns.GridColumn();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            this.baoCao_POTableAdapter = new Production.SYNC_NUTRICIEL_REPORTTableAdapters.BaoCao_POTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.baoCaoPOBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sYNC_NUTRICIEL_REPORT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.filter_Vertical1);
            this.layoutControl1.Controls.Add(this.gridControl1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(800, 450);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // filter_Vertical1
            // 
            this.filter_Vertical1.Appearance.Font = new System.Drawing.Font("IBM Plex Mono", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filter_Vertical1.Appearance.Options.UseFont = true;
            this.filter_Vertical1.Location = new System.Drawing.Point(3, 3);
            this.filter_Vertical1.Margin = new System.Windows.Forms.Padding(0);
            this.filter_Vertical1.Name = "filter_Vertical1";
            this.filter_Vertical1.Size = new System.Drawing.Size(118, 444);
            this.filter_Vertical1.TabIndex = 14;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.baoCaoPOBindingSource;
            this.gridControl1.Location = new System.Drawing.Point(125, 3);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(672, 444);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // baoCaoPOBindingSource
            // 
            this.baoCaoPOBindingSource.DataMember = "BaoCao_PO";
            this.baoCaoPOBindingSource.DataSource = this.sYNC_NUTRICIEL_REPORT;
            // 
            // sYNC_NUTRICIEL_REPORT
            // 
            this.sYNC_NUTRICIEL_REPORT.DataSetName = "SYNC_NUTRICIEL_REPORT";
            this.sYNC_NUTRICIEL_REPORT.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSốPO,
            this.colNgàyPO,
            this.colMÃNHÀCUNGCẤP,
            this.colNHÀCUNGCẤP,
            this.colCODEMẪU,
            this.colTÊNKHÁCHHÀNG,
            this.colCODEXN,
            this.colTÊNXÉTNGHIỆM,
            this.colĐơnGiáchưaVAT,
            this.gridColumn1,
            this.colTiềnthuế,
            this.gridColumn2,
            this.colTổngtiền,
            this.colGiảmgiá});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.HorzScrollVisibility = DevExpress.XtraGrid.Views.Base.ScrollVisibility.Always;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ColumnAutoWidth = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colSốPO
            // 
            this.colSốPO.FieldName = "Số PO";
            this.colSốPO.Name = "colSốPO";
            this.colSốPO.Visible = true;
            this.colSốPO.VisibleIndex = 0;
            // 
            // colNgàyPO
            // 
            this.colNgàyPO.FieldName = "Ngày PO";
            this.colNgàyPO.Name = "colNgàyPO";
            this.colNgàyPO.Visible = true;
            this.colNgàyPO.VisibleIndex = 1;
            // 
            // colMÃNHÀCUNGCẤP
            // 
            this.colMÃNHÀCUNGCẤP.FieldName = "MÃ NHÀ CUNG CẤP";
            this.colMÃNHÀCUNGCẤP.Name = "colMÃNHÀCUNGCẤP";
            this.colMÃNHÀCUNGCẤP.Visible = true;
            this.colMÃNHÀCUNGCẤP.VisibleIndex = 2;
            this.colMÃNHÀCUNGCẤP.Width = 113;
            // 
            // colNHÀCUNGCẤP
            // 
            this.colNHÀCUNGCẤP.FieldName = "NHÀ CUNG CẤP";
            this.colNHÀCUNGCẤP.Name = "colNHÀCUNGCẤP";
            this.colNHÀCUNGCẤP.Visible = true;
            this.colNHÀCUNGCẤP.VisibleIndex = 3;
            this.colNHÀCUNGCẤP.Width = 224;
            // 
            // colCODEMẪU
            // 
            this.colCODEMẪU.FieldName = "CODE MẪU";
            this.colCODEMẪU.Name = "colCODEMẪU";
            this.colCODEMẪU.Visible = true;
            this.colCODEMẪU.VisibleIndex = 4;
            // 
            // colTÊNKHÁCHHÀNG
            // 
            this.colTÊNKHÁCHHÀNG.FieldName = "TÊN KHÁCH HÀNG";
            this.colTÊNKHÁCHHÀNG.Name = "colTÊNKHÁCHHÀNG";
            this.colTÊNKHÁCHHÀNG.Visible = true;
            this.colTÊNKHÁCHHÀNG.VisibleIndex = 5;
            this.colTÊNKHÁCHHÀNG.Width = 223;
            // 
            // colCODEXN
            // 
            this.colCODEXN.FieldName = "CODE XN";
            this.colCODEXN.Name = "colCODEXN";
            this.colCODEXN.Visible = true;
            this.colCODEXN.VisibleIndex = 6;
            // 
            // colTÊNXÉTNGHIỆM
            // 
            this.colTÊNXÉTNGHIỆM.FieldName = "TÊN XÉT NGHIỆM";
            this.colTÊNXÉTNGHIỆM.Name = "colTÊNXÉTNGHIỆM";
            this.colTÊNXÉTNGHIỆM.Visible = true;
            this.colTÊNXÉTNGHIỆM.VisibleIndex = 7;
            this.colTÊNXÉTNGHIỆM.Width = 339;
            // 
            // colĐơnGiáchưaVAT
            // 
            this.colĐơnGiáchưaVAT.FieldName = "Đơn Giá chưa VAT";
            this.colĐơnGiáchưaVAT.Name = "colĐơnGiáchưaVAT";
            this.colĐơnGiáchưaVAT.Visible = true;
            this.colĐơnGiáchưaVAT.VisibleIndex = 8;
            // 
            // gridColumn1
            // 
            this.gridColumn1.FieldName = "VAT %";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 9;
            // 
            // colTiềnthuế
            // 
            this.colTiềnthuế.FieldName = "Tiền thuế";
            this.colTiềnthuế.Name = "colTiềnthuế";
            this.colTiềnthuế.Visible = true;
            this.colTiềnthuế.VisibleIndex = 10;
            // 
            // gridColumn2
            // 
            this.gridColumn2.FieldName = "Thành tiền / mẫu";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 11;
            this.gridColumn2.Width = 114;
            // 
            // colTổngtiền
            // 
            this.colTổngtiền.FieldName = "Tổng tiền";
            this.colTổngtiền.Name = "colTổngtiền";
            this.colTổngtiền.Visible = true;
            this.colTổngtiền.VisibleIndex = 12;
            // 
            // colGiảmgiá
            // 
            this.colGiảmgiá.FieldName = "Giảm giá";
            this.colGiảmgiá.Name = "colGiảmgiá";
            this.colGiảmgiá.Visible = true;
            this.colGiảmgiá.VisibleIndex = 13;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem5});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(1, 1, 1, 1);
            this.layoutControlGroup1.Size = new System.Drawing.Size(800, 450);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.gridControl1;
            this.layoutControlItem1.Location = new System.Drawing.Point(122, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(676, 448);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.filter_Vertical1;
            this.layoutControlItem5.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(122, 448);
            this.layoutControlItem5.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem5.TextVisible = false;
            // 
            // baoCao_POTableAdapter
            // 
            this.baoCao_POTableAdapter.ClearBeforeFill = true;
            // 
            // F_BaocaoPO_EXCEL
            // 
            this.Appearance.BackColor = System.Drawing.SystemColors.Control;
            this.Appearance.Options.UseBackColor = true;
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.layoutControl1);
            this.Name = "F_BaocaoPO_EXCEL";
            this.Text = "F_BaoCao_PO";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.baoCaoPOBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sYNC_NUTRICIEL_REPORT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private _GEN._UC.Filter_Vertical filter_Vertical1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;
        private System.Windows.Forms.BindingSource baoCaoPOBindingSource;
        private SYNC_NUTRICIEL_REPORT sYNC_NUTRICIEL_REPORT;
        private DevExpress.XtraGrid.Columns.GridColumn colSốPO;
        private DevExpress.XtraGrid.Columns.GridColumn colNgàyPO;
        private DevExpress.XtraGrid.Columns.GridColumn colMÃNHÀCUNGCẤP;
        private DevExpress.XtraGrid.Columns.GridColumn colNHÀCUNGCẤP;
        private DevExpress.XtraGrid.Columns.GridColumn colCODEMẪU;
        private DevExpress.XtraGrid.Columns.GridColumn colTÊNKHÁCHHÀNG;
        private DevExpress.XtraGrid.Columns.GridColumn colCODEXN;
        private DevExpress.XtraGrid.Columns.GridColumn colTÊNXÉTNGHIỆM;
        private DevExpress.XtraGrid.Columns.GridColumn colĐơnGiáchưaVAT;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn colTiềnthuế;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn colTổngtiền;
        private DevExpress.XtraGrid.Columns.GridColumn colGiảmgiá;
        private SYNC_NUTRICIEL_REPORTTableAdapters.BaoCao_POTableAdapter baoCao_POTableAdapter;
    }
}