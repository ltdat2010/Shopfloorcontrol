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
using DevExpress.XtraGrid;
using System.Globalization;

namespace Production.Class
{
    public partial class R_COA_SelectLanguage : frm_Base
    {
                
        public string CD_OF ;        
        public string SoCOA ;
        public R_COA_SelectLanguage()
        {
            InitializeComponent();
            Load += (s,e) =>
            {                

            };         
              
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            R_COA RCOA = new R_COA();
            RCOA.CD_OF = this.CD_OF;
            RCOA.SoCOA = this.SoCOA;
            RCOA.ReportLanguage = this.cmbReportLanguage.SelectedText.ToString();
            RCOA.Show();
            this.Close();
        }        
                
    }
}
