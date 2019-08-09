namespace Production.Class
{
    partial class F_DashBoard_QC
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
            this.dashboardViewer4 = new DevExpress.DashboardWin.DashboardViewer(this.components);
            this.dashboardViewer2 = new DevExpress.DashboardWin.DashboardViewer(this.components);
            this.dashboardViewer1 = new DevExpress.DashboardWin.DashboardViewer(this.components);
            this.layoutControlGroup1 = new DevExpress.XtraLayout.LayoutControlGroup();
            this.layoutControlItem1 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem2 = new DevExpress.XtraLayout.LayoutControlItem();
            this.layoutControlItem4 = new DevExpress.XtraLayout.LayoutControlItem();
            this.defaultLookAndFeel1 = new DevExpress.LookAndFeel.DefaultLookAndFeel(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).BeginInit();
            this.layoutControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardViewer4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardViewer2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardViewer1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).BeginInit();
            this.SuspendLayout();
            // 
            // layoutControl1
            // 
            this.layoutControl1.Controls.Add(this.dashboardViewer4);
            this.layoutControl1.Controls.Add(this.dashboardViewer2);
            this.layoutControl1.Controls.Add(this.dashboardViewer1);
            this.layoutControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.layoutControl1.Location = new System.Drawing.Point(0, 0);
            this.layoutControl1.Name = "layoutControl1";
            this.layoutControl1.Root = this.layoutControlGroup1;
            this.layoutControl1.Size = new System.Drawing.Size(955, 509);
            this.layoutControl1.TabIndex = 0;
            this.layoutControl1.Text = "layoutControl1";
            // 
            // dashboardViewer4
            // 
            this.dashboardViewer4.DashboardSource = typeof(Production.DashBoard.Pro_Db_COAThisMonth_Chart);
            this.dashboardViewer4.Location = new System.Drawing.Point(4, 266);
            this.dashboardViewer4.Name = "dashboardViewer4";
            this.dashboardViewer4.Size = new System.Drawing.Size(947, 239);
            this.dashboardViewer4.TabIndex = 7;
            // 
            // dashboardViewer2
            // 
            this.dashboardViewer2.DashboardSource = typeof(Production.DashBoard.Pro_Db_PKNThisMonth_Chart);
            this.dashboardViewer2.Location = new System.Drawing.Point(479, 4);
            this.dashboardViewer2.Name = "dashboardViewer2";
            this.dashboardViewer2.Size = new System.Drawing.Size(472, 258);
            this.dashboardViewer2.TabIndex = 5;
            this.dashboardViewer2.Load += new System.EventHandler(this.dashboardViewer2_Load);
            // 
            // dashboardViewer1
            // 
            this.dashboardViewer1.DashboardSource = typeof(Production.DashBoard.Pro_Db_PKNMonthly_Chart);
            this.dashboardViewer1.Location = new System.Drawing.Point(4, 4);
            this.dashboardViewer1.Name = "dashboardViewer1";
            this.dashboardViewer1.Size = new System.Drawing.Size(471, 258);
            this.dashboardViewer1.TabIndex = 4;
            // 
            // layoutControlGroup1
            // 
            this.layoutControlGroup1.EnableIndentsWithoutBorders = DevExpress.Utils.DefaultBoolean.True;
            this.layoutControlGroup1.GroupBordersVisible = false;
            this.layoutControlGroup1.Items.AddRange(new DevExpress.XtraLayout.BaseLayoutItem[] {
            this.layoutControlItem1,
            this.layoutControlItem2,
            this.layoutControlItem4});
            this.layoutControlGroup1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlGroup1.Name = "layoutControlGroup1";
            this.layoutControlGroup1.Padding = new DevExpress.XtraLayout.Utils.Padding(2, 2, 2, 2);
            this.layoutControlGroup1.Size = new System.Drawing.Size(955, 509);
            this.layoutControlGroup1.TextVisible = false;
            // 
            // layoutControlItem1
            // 
            this.layoutControlItem1.Control = this.dashboardViewer1;
            this.layoutControlItem1.Location = new System.Drawing.Point(0, 0);
            this.layoutControlItem1.Name = "layoutControlItem1";
            this.layoutControlItem1.Size = new System.Drawing.Size(475, 262);
            this.layoutControlItem1.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem1.TextVisible = false;
            // 
            // layoutControlItem2
            // 
            this.layoutControlItem2.Control = this.dashboardViewer2;
            this.layoutControlItem2.Location = new System.Drawing.Point(475, 0);
            this.layoutControlItem2.Name = "layoutControlItem2";
            this.layoutControlItem2.Size = new System.Drawing.Size(476, 262);
            this.layoutControlItem2.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem2.TextVisible = false;
            // 
            // layoutControlItem4
            // 
            this.layoutControlItem4.Control = this.dashboardViewer4;
            this.layoutControlItem4.Location = new System.Drawing.Point(0, 262);
            this.layoutControlItem4.Name = "layoutControlItem4";
            this.layoutControlItem4.Size = new System.Drawing.Size(951, 243);
            this.layoutControlItem4.TextSize = new System.Drawing.Size(0, 0);
            this.layoutControlItem4.TextVisible = false;
            // 
            // defaultLookAndFeel1
            // 
            this.defaultLookAndFeel1.LookAndFeel.SkinName = "Office 2016 Colorful";
            // 
            // F_DashBoard_QC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.layoutControl1);
            this.Name = "F_DashBoard_QC";
            this.Size = new System.Drawing.Size(955, 509);
            ((System.ComponentModel.ISupportInitialize)(this.layoutControl1)).EndInit();
            this.layoutControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dashboardViewer4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardViewer2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardViewer1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlGroup1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.layoutControlItem4)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraLayout.LayoutControl layoutControl1;
        private DevExpress.XtraLayout.LayoutControlGroup layoutControlGroup1;
        private DevExpress.DashboardWin.DashboardViewer dashboardViewer1;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem1;
        private DevExpress.DashboardWin.DashboardViewer dashboardViewer2;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem2;
        private DevExpress.DashboardWin.DashboardViewer dashboardViewer4;
        private DevExpress.XtraLayout.LayoutControlItem layoutControlItem4;
        private DevExpress.LookAndFeel.DefaultLookAndFeel defaultLookAndFeel1;
    }
}
