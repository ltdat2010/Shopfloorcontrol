using System.IO;

namespace Production.Class
{
    public partial class R_FrDate_ToDate : frm_Base
    {
        public string OF = "";
        public string TotalBatchNb = "";

        //----------------------------Report parameters declare---------------------------------------------
        //string Path = "C:";
        private bool val = false;

        private string Path = Directory.GetCurrentDirectory();
        private CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        //----------------------------End Report parameters declare---------------------------------------------

        public R_FrDate_ToDate()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
            };
            simpleButton1.Click += (s, e) =>
                {
                    R_FG_Date RFGDate = new R_FG_Date();
                    RFGDate.FrDate = DEFrDate.SelectedText.ToString();
                    RFGDate.ToDate = DEToDate.SelectedText.ToString();
                    RFGDate.Show();
                    this.Close();
                };
        }
    }
}