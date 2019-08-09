namespace Production.DashBoard
{
    partial class Pro_Db_OFThisWeek_Pie
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
            DevExpress.DashboardCommon.Dimension dimension1 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.Dimension dimension2 = new DevExpress.DashboardCommon.Dimension();
            DevExpress.DashboardCommon.Measure measure1 = new DevExpress.DashboardCommon.Measure();
            DevExpress.DashboardCommon.PercentOfTotalCalculation percentOfTotalCalculation1 = new DevExpress.DashboardCommon.PercentOfTotalCalculation();
            DevExpress.DashboardCommon.PieWindowDefinition pieWindowDefinition1 = new DevExpress.DashboardCommon.PieWindowDefinition();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pro_Db_OFThisWeek_Pie));
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery2 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DashboardCommon.DashboardLayoutGroup dashboardLayoutGroup1 = new DevExpress.DashboardCommon.DashboardLayoutGroup();
            DevExpress.DashboardCommon.DashboardLayoutItem dashboardLayoutItem1 = new DevExpress.DashboardCommon.DashboardLayoutItem();
            this.pieDashboardItem1 = new DevExpress.DashboardCommon.PieDashboardItem();
            this.dashboardSqlDataSource1 = new DevExpress.DashboardCommon.DashboardSqlDataSource();
            this.dashboardSqlDataSource2 = new DevExpress.DashboardCommon.DashboardSqlDataSource();
            ((System.ComponentModel.ISupportInitialize)(this.pieDashboardItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(measure1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardSqlDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardSqlDataSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // pieDashboardItem1
            // 
            dimension1.DataMember = "CD_MAT";
            dimension2.DataMember = "LB_MAT";
            this.pieDashboardItem1.Arguments.AddRange(new DevExpress.DashboardCommon.Dimension[] {
            dimension1,
            dimension2});
            this.pieDashboardItem1.ComponentName = "pieDashboardItem1";
            measure1.Calculation = percentOfTotalCalculation1;
            measure1.DataMember = "QT_MVMT";
            measure1.Name = "Manf. QTY.";
            measure1.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Percent;
            measure1.NumericFormat.IncludeGroupSeparator = true;
            measure1.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones;
            pieWindowDefinition1.DefinitionMode = DevExpress.DashboardCommon.PieWindowDefinitionMode.Arguments;
            measure1.WindowDefinition = pieWindowDefinition1;
            this.pieDashboardItem1.DataItemRepository.Clear();
            this.pieDashboardItem1.DataItemRepository.Add(measure1, "DataItem0");
            this.pieDashboardItem1.DataItemRepository.Add(dimension1, "DataItem1");
            this.pieDashboardItem1.DataItemRepository.Add(dimension2, "DataItem2");
            this.pieDashboardItem1.DataMember = "Query";
            this.pieDashboardItem1.DataSource = this.dashboardSqlDataSource1;
            this.pieDashboardItem1.InteractivityOptions.IgnoreMasterFilters = false;
            this.pieDashboardItem1.LabelContentType = ((DevExpress.DashboardCommon.PieValueType)((DevExpress.DashboardCommon.PieValueType.Argument | DevExpress.DashboardCommon.PieValueType.Value)));
            this.pieDashboardItem1.Name = "Pies 1";
            this.pieDashboardItem1.ShowCaption = false;
            this.pieDashboardItem1.ShowPieCaptions = false;
            this.pieDashboardItem1.Values.AddRange(new DevExpress.DashboardCommon.Measure[] {
            measure1});
            // 
            // dashboardSqlDataSource1
            // 
            this.dashboardSqlDataSource1.ComponentName = "dashboardSqlDataSource1";
            this.dashboardSqlDataSource1.ConnectionName = "Production.Properties.Settings.SYNC_NUTRICIELConnectionString";
            this.dashboardSqlDataSource1.Name = "OF This Week Pie";
            customSqlQuery1.Name = "Query";
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            this.dashboardSqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.dashboardSqlDataSource1.ResultSchemaSerializable = resources.GetString("dashboardSqlDataSource1.ResultSchemaSerializable");
            // 
            // dashboardSqlDataSource2
            // 
            this.dashboardSqlDataSource2.ComponentName = "dashboardSqlDataSource2";
            this.dashboardSqlDataSource2.ConnectionName = "Production.Properties.Settings.SYNC_NUTRICIELConnectionString";
            this.dashboardSqlDataSource2.Name = "OF This Month Pie";
            customSqlQuery2.Name = "Query";
            customSqlQuery2.Sql = resources.GetString("customSqlQuery2.Sql");
            this.dashboardSqlDataSource2.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery2});
            this.dashboardSqlDataSource2.ResultSchemaSerializable = resources.GetString("dashboardSqlDataSource2.ResultSchemaSerializable");
            // 
            // Pro_Db_OFThisWeek_Pie
            // 
            this.DataSources.AddRange(new DevExpress.DashboardCommon.IDashboardDataSource[] {
            this.dashboardSqlDataSource1,
            this.dashboardSqlDataSource2});
            this.Items.AddRange(new DevExpress.DashboardCommon.DashboardItem[] {
            this.pieDashboardItem1});
            dashboardLayoutItem1.DashboardItem = this.pieDashboardItem1;
            dashboardLayoutItem1.Weight = 50.133333333333333D;
            dashboardLayoutGroup1.ChildNodes.AddRange(new DevExpress.DashboardCommon.DashboardLayoutNode[] {
            dashboardLayoutItem1});
            dashboardLayoutGroup1.DashboardItem = null;
            dashboardLayoutGroup1.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical;
            this.LayoutRoot = dashboardLayoutGroup1;
            this.Title.Text = "Percentage of FG this week";
            ((System.ComponentModel.ISupportInitialize)(dimension1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(dimension2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(measure1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pieDashboardItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardSqlDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardSqlDataSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.DashboardCommon.PieDashboardItem pieDashboardItem1;
        private DevExpress.DashboardCommon.DashboardSqlDataSource dashboardSqlDataSource1;
        private DevExpress.DashboardCommon.DashboardSqlDataSource dashboardSqlDataSource2;
    }
}
