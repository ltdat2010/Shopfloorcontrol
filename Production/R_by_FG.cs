using System;
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
    public partial class R_by_FG : frm_Base
    {
        OFBUS OFB = new OFBUS();

        /// <summary>
        /// DELEGATE
        /// </summary>        
        public delegate void MyAdd(object sender);
        public event MyAdd myFinished;

        public bool Is_close
        {
            set
            {
                if (value)
                {
                    if (myFinished != null) myFinished(sender: this);
                }
            }
        }
        

        public string OF = "";
        public string TotalBatchNb = "";       
        //----------------------------Report parameters declare---------------------------------------------
        //string Path = "C:";
        
        string Path = Directory.GetCurrentDirectory();        
        CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        //----------------------------End Report parameters declare---------------------------------------------

        public R_by_FG()
        {
            InitializeComponent();
            Load += (s,e) =>
            {
                DEFrDate.Properties.DataSource = OFB.F_FG_Finished();
                DEFrDate.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
                DEFrDate.Properties.ValueMember = "CD_MAT";
                DEFrDate.Properties.DisplayMember = "LB_MAT";
                DEFrDate.Properties.AutoSearchColumnIndex = 4;
                DEFrDate.Properties.SearchMode = DevExpress.XtraEditors.Controls.SearchMode.AutoComplete;
            };
            simpleButton1.Click += (s, e) =>
                {
                    R_FG_FG RFGDate = new R_FG_FG();
                    RFGDate.FG = DEFrDate.EditValue.ToString();               
                    RFGDate.Show();
                    Is_close = true;
                    this.Close();
                };
           
        }
               

    }
}
