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
    public partial class R_RMUsed_SelectPrefixRM : frm_Base
    {
        string RptType = "";          
        //----------------------------Report parameters declare---------------------------------------------
        //string Path = "C:";
        
        string Path = Directory.GetCurrentDirectory();        
        CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        //----------------------------End Report parameters declare---------------------------------------------

        public R_RMUsed_SelectPrefixRM()
        {
            InitializeComponent();
            Load += (s,e) =>
            {
                
            };
            simpleButton1.Click += (s, e) =>
                {
                    R_RM_Used RMU = new R_RM_Used();

                    if (chkRptType.CheckState == CheckState.Checked)
                        RMU.RptType = "D";
                    else
                        RMU.RptType = "S";
                    
                    RMU.Prefix_RM = DEFrDate.SelectedText.ToString();
                    RMU.Show();
                    this.Close();
                };            
           
        }
               

    }
}
