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
using System.Data.SqlClient;
using DevExpress.XtraBars;

namespace Production.Class
{
    public partial class R_RM_Used : frm_Base
    {
        OFBUS OFB                       = new OFBUS();
        RMUSEDBUS RMB                   = new RMUSEDBUS();
        public string Prefix_RM         = "";
        public string RptType           = "";
        DataTable   dt_RMUsed           = new DataTable();
        //----------------------------Report parameters declare---------------------------------------------
        //string Path = "C:";        
        string Path = Directory.GetCurrentDirectory();        
        CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        //----------------------------End Report parameters declare---------------------------------------------

        public R_RM_Used()
        {
            InitializeComponent();
            Load += (s,e) =>
            {
                //XtraMessageBox.Show("Path : " + Path);
                if (RptType == "D")
                {
                    dt_RMUsed = RMB.RMUsed_Report(Prefix_RM);                    

                    if (dt_RMUsed.Rows.Count > 0)
                    {   
                        dt_RMUsed.WriteXml(Path + "/Xml/dt_RMUsed.xml", System.Data.XmlWriteMode.IgnoreSchema);
                        rpt.Load(Path + "/RPT/Rpt_RMUsed.rpt");
                    }
                }
                else
                {
                    dt_RMUsed = RMB.RMUsed_Report_Simple(Prefix_RM);
                    //XtraMessageBox.Show(dt_RMUsed.Rows.Count.ToString());
                    if (dt_RMUsed.Rows.Count > 0)
                    {
                        dt_RMUsed.WriteXml(Path + "/Xml/dt_RMUsed_Simple.xml", System.Data.XmlWriteMode.IgnoreSchema);
                        rpt.Load(Path + "/RPT/Rpt_RMUsed_Simple.rpt");
                    }
                }
                    
                    crvReport.ReportSource = rpt;        
            };
            action1.Close(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Close));
            action1.Print(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Print));
        }

        private void ItemClickEventHandler_Close(object sender, ItemClickEventArgs e)
        {
            this.Close();
            //throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Print(object sender, EventArgs e)
        {
            try
            {
                PrintDialog printDialog1 = new PrintDialog();
                PrintDocument pd = new PrintDocument();

                printDialog1.Document = pd;
                printDialog1.ShowNetwork = true;
                printDialog1.AllowSomePages = true;
                printDialog1.AllowSelection = false;
                printDialog1.AllowCurrentPage = false;
                printDialog1.PrinterSettings.Copies = 1;
                //printDialog1.PrinterSettings.PrinterName = this.PrinterToPrint;
                DialogResult result = printDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    PrintReport(pd);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }       

        private void PrintReport(PrintDocument pd)
        {
            ReportDocument rDoc = (ReportDocument)crvReport.ReportSource;
            // This line helps, in case user selects a different printer 
            // other than the default selected.
            rDoc.PrintOptions.PrinterName = pd.PrinterSettings.PrinterName;
            // In place of Frompage and ToPage put 0,0 to print all pages,
            // however in that case user wont be able to choose selection.
            rDoc.PrintToPrinter(pd.PrinterSettings.Copies, false, pd.PrinterSettings.FromPage,pd.PrinterSettings.ToPage);
        }
    }
}
