using DevExpress.DataAccess.Sql;
using System;
using System.IO;

namespace Production.Class
{
    public partial class F_DashBoard_LAB : UC_Base
    {
        private string Path = Directory.GetCurrentDirectory();

        public F_DashBoard_LAB()
        {
            InitializeComponent();
            Load += (s, e) =>
                {
                };
        }

        private void dashboardViewer1_Load(object sender, EventArgs e)
        {
            SqlDataSource.DisableCustomQueryValidation = true;
        }
    }
}