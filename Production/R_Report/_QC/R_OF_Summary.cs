using System;
using System.Data;
using System.Windows.Forms;
using System.Drawing.Printing;
using CrystalDecisions.CrystalReports.Engine;
using System.IO;
using DevExpress.XtraBars;

namespace Production.Class
{
    public partial class R_OF_Summary : frm_Base
    {
        OFBUS OFB                       = new OFBUS();
        public string OF                = "";
        public string TotalBatchNb      = "";
        DataTable   dt_OFHeader           ,
                    dt_OF_Report_OFSummary_PREP,
                    dt_OFListBatchDetails = new DataTable();
        //----------------------------Report parameters declare---------------------------------------------
        //string Path = "C:";        
        string Path = Directory.GetCurrentDirectory();        
        CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        //----------------------------End Report parameters declare---------------------------------------------

        public R_OF_Summary()
        {
            InitializeComponent();
            Load += (s,e) =>
            {
                    //XtraMessageBox.Show("Path : " + Path);
                    dt_OFHeader = OFB.OF_Report_OFHeader(OF);
                    //dt_OFListBatchs = OFB.OF_Report_OFListBatchs(OF);
                    dt_OFListBatchDetails = OFB.OF_Report_OFSummary(OF);
                    dt_OF_Report_OFSummary_PREP = OFB.OF_Report_OFSummary_PREP(OF);

                if (dt_OFHeader.Rows.Count > 0)
                    {
                        //Khong can chay lai OFHeader vi da in roi
                        //dt_OFHeader.WriteXml(Path + "/Xml/dt_OFHeader.xml", System.Data.XmlWriteMode.IgnoreSchema);
                        //dt_OFListBatchs.WriteXml(Path + "/Xml/dt_OFListBatchs.xml", System.Data.XmlWriteMode.IgnoreSchema);
                        dt_OFListBatchDetails.WriteXml(Path + "/Xml/dt_OF_Summary.xml", System.Data.XmlWriteMode.IgnoreSchema);
                        dt_OF_Report_OFSummary_PREP.WriteXml(Path + "/Xml/dt_OF_Report_OFSummary_PREP.xml", System.Data.XmlWriteMode.IgnoreSchema);
                }
                    rpt.Load(Path + "/RPT/Rpt_OF_Summary.rpt");
                    crvReport.ReportSource = rpt;        
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
