using System;
using System.IO;

namespace Production.Class
{
    public partial class F_DashBoard_Pro : UC_Base
    {
        private string Path = Directory.GetCurrentDirectory();

        public F_DashBoard_Pro()
        {
            InitializeComponent();
            Load += (s, e) =>
                {
                    //    //*************************DASHBOARD**************************************************************************
                    //Dashboard dashboard = new Dashboard();
                    //DashboardObjectDataSource objectDataSource = new DashboardObjectDataSource();
                    //objectDataSource.DataSource = GetData();
                    //objectDataSource.Fill();

                    //ChartDashboardItem chart = new ChartDashboardItem();
                    //chart.DataSource = objectDataSource; //dashboard.DataSources[0];
                    //chart.DataMember = "CD_MAT";
                    //chart.Arguments.Add(new Dimension("DT_DEB", DateTimeGroupInterval.Year));
                    //chart.Panes.Add(new ChartPane());
                    //SimpleSeries freightSeries = new SimpleSeries(SimpleSeriesType.Bar);
                    //freightSeries.Value = new Measure("QT_MVMT");
                    //chart.Panes[0].Series.Add(freightSeries);

                    //dashboard.DataSources.Add(objectDataSource);
                    //dashboardViewer1.Dashboard = dashboard;

                    ////// Creates a new grid dashboard item with two columns that display car models and prices.
                    ////GridDashboardItem grid1 = new GridDashboardItem();
                    ////grid1.DataSource = dashboard.DataSources[0];
                    ////grid1.Columns.Add(new GridDimensionColumn(new Dimension("CD_MAT")));
                    ////grid1.Columns.Add(new GridMeasureColumn(new Measure("QT_MVMT")));
                    ////dashboard.Items.Add(grid1);
                };
        }

        private void dashboardViewer2_Load(object sender, EventArgs e)
        {
        }

        ////******************DASHBOARD*****************************************************************************************

        //public DataTable GetData()
        //{
        //    DataSet xmlDataSet = new DataSet();
        //    //xmlDataSet.ReadXml(Path + @"/../../Xml/OF_Report_ByDate_ThisWeek.xml");
        //    xmlDataSet.ReadXml(Path + @"/Xml/OF_Report_ByDate_ThisWeek.xml");
        //    return xmlDataSet.Tables["OF_Report_ByDate_ThisWeek"];
        //}

        ////*************************END DASHBOARD******************************************************************************
    }
}