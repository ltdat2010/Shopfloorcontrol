namespace Production.Class
{
    partial class R_BaoCaoCongNo_LAB
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
            this.layoutControl1 = new DevExpress.XtraLayout.LayoutControl();
            this.txtToDate = new DevExpress.XtraEditors.TextEdit();
            this.txtFrDate = new DevExpress.XtraEditors.TextEdit();
            this.action1 = new Production.Class.Action();
            this.crvReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.emptySpaceItem1 = new DevExpress.XtraLayout.EmptySpaceItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem5 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtToDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.txtToDate);
            this.layoutControl1.Controls.Add(this.txtFrDate);
            this.layoutControl1.Controls.Add(this.action1);
            this.layoutControl1.Controls.Add(this.crvReport);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(842, 541);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // txtToDate
            // 
            this.txtToDate.Location = new System.Drawing.Point(250, 47);
            this.txtToDate.Name = "txtToDate";
            this.txtToDate.Properties.ReadOnly = true;
            this.txtToDate.Size = new System.Drawing.Size(131, 20);
            this.txtToDate.StyleController = this.layoutControl1;
            this.txtToDate.TabIndex = 8;
            // 
            // txtFrDate
            // 
            this.txtFrDate.Location = new System.Drawing.Point(63, 47);
            this.txtFrDate.Name = "txtFrDate";
            this.txtFrDate.Properties.ReadOnly = true;
            this.txtFrDate.Size = new System.Drawing.Size(124, 20);
            this.txtFrDate.StyleController = this.layoutControl1;
            this.txtFrDate.TabIndex = 7;
            // 
            // action1
            // 
            this.action1.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.action1.Appearance.Options.UseForeColor = true;
            this.action1.Location = new System.Drawing.Point(4, 4);
            this.action1.LookAndFeel.SkinName = "Money Twins";
            this.action1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.action1.Name = "action1";
            this.action1.Size = new System.Drawing.Size(834, 39);
            this.action1.StateMenu = Production.Class.MenuState.Empty;
            this.action1.TabIndex = 5;
            this.action1.Visible = false;
            // 
            // crvReport
            // 
            this.crvReport.ActiveViewIndex = -1;
            this.crvReport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.crvReport.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvReport.DisplayStatusBar = false;
            this.crvReport.Location = new System.Drawing.Point(4, 71);
            this.crvReport.Name = "crvReport";
            this.crvReport.ShowCloseButton = false;
            this.crvReport.ShowCopyButton = false;
            this.crvReport.ShowExportButton = false;
            this.crvReport.ShowGroupTreeButton = false;
            this.crvReport.ShowLogo = false;
            this.crvReport.ShowParameterPanelButton = false;
            this.crvReport.ShowPrintButton = false;
            this.crvReport.ShowRefreshButton = false;
            this.crvReport.ShowTextSearchButton = false;
            this.crvReport.ShowZoomButton = false;
            this.crvReport.Size = new System.Drawing.Size(834, 466);
            this.crvReport.TabIndex = 4;
            this.crvReport.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.emptySpaceItem1,
            this.layoutControlItem4,
            this.layoutControlItem5});
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup1.Size = new System.Drawing.Size(842, 541);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.crvReport;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 67);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(838, 470);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.action1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(838, 43);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // emptySpaceItem1
            // 
            this.emptySpaceItem1.AllowHotTrack = false;
            this.emptySpaceItem1.Location = new System.Drawing.Point(381, 43);
            this.emptySpaceItem1.Name = "emptySpaceItem1";
            this.emptySpaceItem1.Size = new System.Drawing.Size(457, 24);
            this.emptySpaceItem1.TextSize = new System.Drawing.Size(0, 0);
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.txtFrDate;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 43);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(187, 24);
            this.layoutControlItem4.Text = "From date :";
            this.layoutControlItem4.TextSize = new System.Drawing.Size(56, 13);
            // 
            // layoutControlItem5
            // 
            this.layoutControlItem5.Control = this.txtToDate;
            this.layoutControlItem5.Location = new System.Drawing.Point(187, 43);
            this.layoutControlItem5.Name = "layoutControlItem5";
            this.layoutControlItem5.Size = new System.Drawing.Size(194, 24);
            this.layoutControlItem5.Text = "To date :";
            this.layoutControlItem5.TextSize = new System.Drawing.Size(56, 13);
            // 
            // R_BaoCaoCongNo_LAB
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(842, 541);
            this.Controls.Add(this.layoutControl1);
            this.LookAndFeel.SkinName = "Caramel";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "R_BaoCaoCongNo_LAB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "R_OF";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtToDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtFrDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.emptySpaceItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem5)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReport;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private Action action1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.XtraLayout.EmptySpaceItem emptySpaceItem1;
        private DevExpress.XtraEditors.TextEdit txtToDate;
        private DevExpress.XtraEditors.TextEdit txtFrDate;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem5;

    }
}