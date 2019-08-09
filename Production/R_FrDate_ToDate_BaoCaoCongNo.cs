﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DevExpress.Skins;
using DevExpress.LookAndFeel;
using DevExpress.UserSkins;
using DevExpress.XtraEditors;
using System.Drawing.Printing;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;

namespace Production.Class
{
    public partial class R_FrDate_ToDate_BaoCaoCongNo : frm_Base
    {
        //public string OF = "";
        //public string TotalBatchNb = "";        
        //----------------------------Report parameters declare---------------------------------------------
        //string Path = "C:";
        bool val = false;
        string Path = Directory.GetCurrentDirectory();        
        CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        //----------------------------End Report parameters declare---------------------------------------------

        public R_FrDate_ToDate_BaoCaoCongNo()
        {
            InitializeComponent();
            Load += (s,e) =>
            {
                
            };
            simpleButton1.Click += (s, e) =>
                {
                    R_BaoCaoCongNo_LAB FRM = new R_BaoCaoCongNo_LAB();
                    FRM.FrDate = DateTime.Parse(DEFrDate.SelectedText.ToString());
                    FRM.ToDate = DateTime.Parse(DEToDate.SelectedText.ToString());
                    FRM.Show();
                    this.Close();
                };
           
        }
               

    }
}
