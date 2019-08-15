namespace Production.Class
{
    public partial class R_FrDate_ToDate_OABatch : frm_Base
    {
        //public string OF = "";
        //public string TotalBatchNb = "";
        //----------------------------Report parameters declare---------------------------------------------
        //string Path = "C:";
        //bool val = false;
        //string Path = Directory.GetCurrentDirectory();
        //CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        //----------------------------End Report parameters declare---------------------------------------------

        public R_FrDate_ToDate_OABatch()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
            };
            simpleButton1.Click += (s, e) =>
                {
                    R_Item_Date_OABatch ROABatch = new R_Item_Date_OABatch();
                    ROABatch.FrDate = DEFrDate.SelectedText.ToString();
                    ROABatch.ToDate = DEToDate.SelectedText.ToString();
                    ROABatch.Show();
                    this.Close();
                };
        }
    }
}