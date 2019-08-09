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
using DevExpress.XtraBars;

namespace Production.Class
{
    public partial class R_COA : frm_Base
    {
        COABUS COB = new COABUS();
        public string SoCOA ;
        public string ReportLanguage; 
        public string CD_OF;
        DataTable TDCOA, KQCOA_Phy,KQCOA_Che;
                //----------------------------Report parameters declare---------------------------------------------
        //string Path = "C:";
        string Path = Directory.GetCurrentDirectory();        
        CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        //----------------------------End Report parameters declare---------------------------------------------

        public R_COA()
        {
            InitializeComponent();
            Load += (s,e) =>
            {
                //XtraMessageBox.Show(Path);
                TDCOA = COB.TDCOA_Search(SoCOA);
                TDCOA.WriteXml(Path + "/Xml/TDCOA.xml", System.Data.XmlWriteMode.IgnoreSchema);
                KQCOA_Phy = COB.KQCOA_Search(SoCOA.ToString(), "Physical");
                KQCOA_Phy.WriteXml(Path + "/Xml/KQCOA_Phy.xml", System.Data.XmlWriteMode.IgnoreSchema);
                KQCOA_Che = COB.KQCOA_Search(SoCOA.ToString(), "Chemical");
                KQCOA_Che.WriteXml(Path + "/Xml/KQCOA_Che.xml", System.Data.XmlWriteMode.IgnoreSchema);
                ////Export data to datatable 
                //dt = cyn_.Report_DEPT_CM(textEdit1.Text.ToString().Trim(), dateEdit1.Text, dateEdit2.Text);
                ////loop via datatable row to XML 
                //if (dt.Rows.Count > 0)
                //{
                //    val = true;
                //    dt.WriteXml(Path1 + "/../../Xml/CM.xml", System.Data.XmlWriteMode.IgnoreSchema);

                //}

                //if (val == true)
                //{
                    //XtraMessageBox.Show("Path :" + Path.ToString());
                    //Load rpt
                if(ReportLanguage == "English")
                    rpt.Load(Path + "/RPT/Rpt_COA_EN.rpt");
                else
                    rpt.Load(Path + "/RPT/Rpt_COA_VN.rpt");
                    //rpt.Load("C:/CM/Production/Report/Rpt_CM_2_2.rpt");
                    //rpt.SetDatabaseLogon("netika", "bsvn", "192.168.0.249", "SYNC_NUTRICIEL");
                    //rpt.SetParameterValue("@FromDate", FrDate);
                    //rpt.SetParameterValue("@ToDate", ToDate);
                    //rpt.SetParameterValue("@Keywords", textEdit1.Text);
                    //rpt.SetParameterValue("@SoPKN", SoPKN);
                crvReport.ReportSource = rpt;
                //}
                //else
                //    XtraMessageBox.Show("No record can be displayed... ", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            };

            action1.Print(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Print));
            action1.Close(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Close));
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
                printDialog1.PrinterSettings.Copies = 1; // (short)int.Parse(TotalBatchNb);
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
            rDoc.PrintToPrinter(pd.PrinterSettings.Copies, false, pd.PrinterSettings.FromPage,
               pd.PrinterSettings.ToPage);
        }
    }
}
