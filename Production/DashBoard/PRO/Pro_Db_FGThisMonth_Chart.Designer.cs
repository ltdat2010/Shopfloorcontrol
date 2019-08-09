namespace Production.DashBoard
{
    partial class Pro_Db_FGThisMonth_Chart
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
            DevExpress.DashboardCommon.Measure measure1 = new DevExpress.DashboardCommon.Measure();
            DevExpress.DashboardCommon.Measure measure2 = new DevExpress.DashboardCommon.Measure();
            DevExpress.DashboardCommon.Measure measure3 = new DevExpress.DashboardCommon.Measure();
            DevExpress.DashboardCommon.ChartPane chartPane1 = new DevExpress.DashboardCommon.ChartPane();
            DevExpress.DashboardCommon.SimpleSeries simpleSeries1 = new DevExpress.DashboardCommon.SimpleSeries();
            DevExpress.DashboardCommon.SimpleSeries simpleSeries2 = new DevExpress.DashboardCommon.SimpleSeries();
            DevExpress.DashboardCommon.SimpleSeries simpleSeries3 = new DevExpress.DashboardCommon.SimpleSeries();
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DataAccess.Sql.QueryParameter queryParameter1 = new DevExpress.DataAccess.Sql.QueryParameter();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Pro_Db_FGThisMonth_Chart));
            DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery2 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
            DevExpress.DashboardCommon.DashboardLayoutGroup dashboardLayoutGroup1 = new DevExpress.DashboardCommon.DashboardLayoutGroup();
            DevExpress.DashboardCommon.DashboardLayoutItem dashboardLayoutItem1 = new DevExpress.DashboardCommon.DashboardLayoutItem();
            DevExpress.DashboardCommon.DashboardParameter dashboardParameter1 = new DevExpress.DashboardCommon.DashboardParameter();
            DevExpress.DashboardCommon.DynamicListLookUpSettings dynamicListLookUpSettings1 = new DevExpress.DashboardCommon.DynamicListLookUpSettings();
            this.chartDashboardItem1 = new DevExpress.DashboardCommon.ChartDashboardItem();
            this.dashboardSqlDataSource1 = new DevExpress.DashboardCommon.DashboardSqlDataSource();
            this.dashboardSqlDataSource2 = new DevExpress.DashboardCommon.DashboardSqlDataSource();
            ((System.ComponentModel.ISupportInitialize)(this.chartDashboardItem1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(dimension1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(measure1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(measure2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(measure3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardSqlDataSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardSqlDataSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // chartDashboardItem1
            // 
            dimension1.DataMember = "DT_FIN";
            dimension1.DateTimeGroupInterval = DevExpress.DashboardCommon.DateTimeGroupInterval.MonthYear;
            dimension1.Name = "Month-Year";
            dimension1.SortOrder = DevExpress.DashboardCommon.DimensionSortOrder.Descending;
            this.chartDashboardItem1.Arguments.AddRange(new DevExpress.DashboardCommon.Dimension[] {
            dimension1});
            this.chartDashboardItem1.AxisX.TitleVisible = false;
            this.chartDashboardItem1.ComponentName = "chartDashboardItem1";
            measure1.DataMember = "QT_LOT";
            measure1.Name = "Planned QTY.";
            measure1.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number;
            measure1.NumericFormat.IncludeGroupSeparator = true;
            measure1.NumericFormat.Precision = 0;
            measure1.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones;
            measure2.DataMember = "QT_MVMT";
            measure2.Name = "Manf. QTY.";
            measure2.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number;
            measure2.NumericFormat.IncludeGroupSeparator = true;
            measure2.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones;
            measure3.DataMember = "TOL_QTY_PAK";
            measure3.Name = "Pakaged QTY.";
            measure3.NumericFormat.FormatType = DevExpress.DashboardCommon.DataItemNumericFormatType.Number;
            measure3.NumericFormat.IncludeGroupSeparator = true;
            measure3.NumericFormat.Unit = DevExpress.DashboardCommon.DataItemNumericUnit.Ones;
            this.chartDashboardItem1.DataItemRepository.Clear();
            this.chartDashboardItem1.DataItemRepository.Add(dimension1, "DataItem0");
            this.chartDashboardItem1.DataItemRepository.Add(measure1, "DataItem2");
            this.chartDashboardItem1.DataItemRepository.Add(measure2, "DataItem1");
            this.chartDashboardItem1.DataItemRepository.Add(measure3, "DataItem3");
            this.chartDashboardItem1.DataMember = "Query";
            this.chartDashboardItem1.DataSource = this.dashboardSqlDataSource1;
            this.chartDashboardItem1.InteractivityOptions.IgnoreMasterFilters = false;
            this.chartDashboardItem1.Legend.InsidePosition = DevExpress.DashboardCommon.ChartLegendInsidePosition.TopRightVertical;
            this.chartDashboardItem1.Legend.IsInsideDiagram = true;
            this.chartDashboardItem1.Legend.OutsidePosition = DevExpress.DashboardCommon.ChartLegendOutsidePosition.BottomCenterHorizontal;
            this.chartDashboardItem1.Name = "Chart 1";
            chartPane1.Name = "Pane 1";
            chartPane1.PrimaryAxisY.AlwaysShowZeroLevel = true;
            chartPane1.PrimaryAxisY.ShowGridLines = true;
            chartPane1.PrimaryAxisY.TitleVisible = true;
            chartPane1.SecondaryAxisY.AlwaysShowZeroLevel = true;
            chartPane1.SecondaryAxisY.Logarithmic = true;
            chartPane1.SecondaryAxisY.ShowGridLines = false;
            chartPane1.SecondaryAxisY.TitleVisible = true;
            simpleSeries1.PointLabelOptions.ShowForZeroValues = true;
            simpleSeries1.PointLabelOptions.ShowPointLabels = true;
            simpleSeries1.AddDataItem("Value", measure1);
            simpleSeries2.PointLabelOptions.Position = DevExpress.DashboardCommon.PointLabelPosition.Inside;
            simpleSeries2.PointLabelOptions.ShowForZeroValues = true;
            simpleSeries2.PointLabelOptions.ShowPointLabels = true;
            simpleSeries2.AddDataItem("Value", measure2);
            simpleSeries3.PointLabelOptions.ShowForZeroValues = true;
            simpleSeries3.PointLabelOptions.ShowPointLabels = true;
            simpleSeries3.AddDataItem("Value", measure3);
            chartPane1.Series.AddRange(new DevExpress.DashboardCommon.ChartSeries[] {
            simpleSeries1,
            simpleSeries2,
            simpleSeries3});
            this.chartDashboardItem1.Panes.AddRange(new DevExpress.DashboardCommon.ChartPane[] {
            chartPane1});
            this.chartDashboardItem1.ShowCaption = false;
            // 
            // dashboardSqlDataSource1
            // 
            this.dashboardSqlDataSource1.ComponentName = "dashboardSqlDataSource1";
            this.dashboardSqlDataSource1.ConnectionName = "Production.Properties.Settings.SYNC_NUTRICIELConnectionString";
            this.dashboardSqlDataSource1.Name = "FG This Month Chart";
            customSqlQuery1.Name = "Query";
            queryParameter1.Name = "Parm_CD_MAT";
            queryParameter1.Type = typeof(DevExpress.DataAccess.Expression);
            queryParameter1.Value = new DevExpress.DataAccess.Expression("[Parameters.FGName]", typeof(string));
            customSqlQuery1.Parameters.Add(queryParameter1);
            customSqlQuery1.Sql = resources.GetString("customSqlQuery1.Sql");
            this.dashboardSqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
            this.dashboardSqlDataSource1.ResultSchemaSerializable = resources.GetString("dashboardSqlDataSource1.ResultSchemaSerializable");
            // 
            // dashboardSqlDataSource2
            // 
            this.dashboardSqlDataSource2.ComponentName = "dashboardSqlDataSource2";
            this.dashboardSqlDataSource2.ConnectionName = "Production.Properties.Settings.SYNC_NUTRICIELConnectionString";
            this.dashboardSqlDataSource2.Name = "List_Parm_CD_MAT";
            customSqlQuery2.Name = "Query";
            customSqlQuery2.Sql = resources.GetString("customSqlQuery2.Sql");
            this.dashboardSqlDataSource2.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery2});
            this.dashboardSqlDataSource2.ResultSchemaSerializable = "PERhdGFTZXQgTmFtZT0iTGlzdF9QYXJtX0NEX01BVCI+PFZpZXcgTmFtZT0iUXVlcnkiPjxGaWVsZCBOY" +
    "W1lPSJDRF9NQVQiIFR5cGU9IlN0cmluZyIgLz48RmllbGQgTmFtZT0iTEJfTUFUIiBUeXBlPSJTdHJpb" +
    "mciIC8+PC9WaWV3PjwvRGF0YVNldD4=";
            // 
            // Pro_Db_FGThisMonth_Chart
            // 
            this.DataSources.AddRange(new DevExpress.DashboardCommon.IDashboardDataSource[] {
            this.dashboardSqlDataSource1,
            this.dashboardSqlDataSource2});
            this.Items.AddRange(new DevExpress.DashboardCommon.DashboardItem[] {
            this.chartDashboardItem1});
            dashboardLayoutItem1.DashboardItem = this.chartDashboardItem1;
            dashboardLayoutItem1.Weight = 100D;
            dashboardLayoutGroup1.ChildNodes.AddRange(new DevExpress.DashboardCommon.DashboardLayoutNode[] {
            dashboardLayoutItem1});
            dashboardLayoutGroup1.DashboardItem = null;
            dashboardLayoutGroup1.Orientation = DevExpress.DashboardCommon.DashboardLayoutGroupOrientation.Vertical;
            this.LayoutRoot = dashboardLayoutGroup1;
            dynamicListLookUpSettings1.DataMember = "Query";
            dynamicListLookUpSettings1.DataSourceName = "dashboardSqlDataSource2";
            dynamicListLookUpSettings1.DisplayMember = "LB_MAT";
            dynamicListLookUpSettings1.SortByMember = "LB_MAT";
            dynamicListLookUpSettings1.ValueMember = "CD_MAT";
            dashboardParameter1.LookUpSettings = dynamicListLookUpSettings1;
            dashboardParameter1.Name = "FGName";
            dashboardParameter1.Type = typeof(string);
            dashboardParameter1.Value = "";
            this.Parameters.AddRange(new DevExpress.DashboardCommon.DashboardParameter[] {
            dashboardParameter1});
            this.Title.Text = "Total FG quantity monthly";
            ((System.ComponentModel.ISupportInitialize)(dimension1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(measure1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(measure2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(measure3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chartDashboardItem1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardSqlDataSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dashboardSqlDataSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.DashboardCommon.ChartDashboardItem chartDashboardItem1;
        private DevExpress.DashboardCommon.DashboardSqlDataSource dashboardSqlDataSource1;
        private DevExpress.DashboardCommon.DashboardSqlDataSource dashboardSqlDataSource2;
    }
}
