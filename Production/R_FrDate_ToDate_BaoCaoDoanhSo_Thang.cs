﻿using System;
using System.IO;

namespace Production.Class
{
    public partial class R_FrDate_ToDate_BaoCaoDoanhSo_Thang : frm_Base
    {
        //public string OF = "";
        //public string TotalBatchNb = "";
        //----------------------------Report parameters declare---------------------------------------------
        //string Path = "C:";
        private bool val = false;

        private string Path = Directory.GetCurrentDirectory();
        private CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        //----------------------------End Report parameters declare---------------------------------------------

        public R_FrDate_ToDate_BaoCaoDoanhSo_Thang()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
            };
            simpleButton1.Click += (s, e) =>
                {
                    R_BaoCaoDoanhSo_Thang_LAB FRM = new R_BaoCaoDoanhSo_Thang_LAB();
                    FRM.FrDate = DateTime.Parse(DEFrDate.SelectedText.ToString());
                    FRM.ToDate = DateTime.Parse(DEToDate.SelectedText.ToString());
                    FRM.Show();
                    this.Close();
                };
        }
    }
}