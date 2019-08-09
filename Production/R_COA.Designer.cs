namespace Production.Class
{
    partial class R_COA
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
            this.action1 = new Production.Class.Action();
            this.crvReport = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.action1);
            this.layoutControl1.Controls.Add(this.crvReport);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(722, 502);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // action1
            // 
            this.action1.Appearance.ForeColor = System.Drawing.Color.DimGray;
            this.action1.Appearance.Options.UseForeColor = true;
            this.action1.Location = new System.Drawing.Point(4, 4);
            this.action1.LookAndFeel.SkinName = "Money Twins";
            this.action1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.action1.Name = "action1";
            this.action1.Size = new System.Drawing.Size(714, 23);
            this.action1.StateMenu = Production.Class.MenuState.Empty;
            this.action1.TabIndex = 5;
            this.action1.Visible = false;
            // 
            // crvReport
            // 
            this.crvReport.ActiveViewIndex = -1;
            this.crvReport.Cursor = System.Windows.Forms.Cursors.Default;
            this.crvReport.DisplayStatusBar = false;
            this.crvReport.Location = new System.Drawing.Point(4, 31);
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
            this.crvReport.Size = new System.Drawing.Size(714, 467);
            this.crvReport.TabIndex = 4;
            this.crvReport.ToolPanelView = CrystalDecisions.Windows.Forms.ToolPanelViewType.None;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup1.Size = new System.Drawing.Size(722, 502);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.crvReport;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 27);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(718, 471);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.action1;
            this.layoutControlItem2.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(718, 27);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // R_COA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(722, 502);
            this.Controls.Add(this.layoutControl1);
            this.LookAndFeel.SkinName = "Caramel";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
            this.Name = "R_COA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "R_OF";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private CrystalDecisions.Windows.Forms.CrystalReportViewer crvReport;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private Action action1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;

    }
}