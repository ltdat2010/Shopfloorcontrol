using System;
using System.IO;

namespace Production.Class
{
    public partial class R_FrDate_ToDate_BaoCaoPXN_Nhan_LAB : frm_Base
    {
        public string OF = "";
        public string TotalBatchNb = "";

        //----------------------------Report parameters declare---------------------------------------------
        //string Path = "C:";
        private bool val = false;

        private string Path = Directory.GetCurrentDirectory();
        private CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        //----------------------------End Report parameters declare---------------------------------------------

        public R_FrDate_ToDate_BaoCaoPXN_Nhan_LAB()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
            };
            simpleButton1.Click += (s, e) =>
                {
                    R_BaoCaoPXN_Nhan_LAB RFGDate = new R_BaoCaoPXN_Nhan_LAB();
                    RFGDate.FrDate = DateTime.Parse(DEFrDate.SelectedText.ToString());
                    RFGDate.ToDate = DateTime.Parse(DEToDate.SelectedText.ToString());
                    RFGDate.Show();
                    this.Close();
                };
        }
    }
}