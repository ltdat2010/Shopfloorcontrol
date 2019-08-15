using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class R_PGM_LAB : frm_Base
    {
        private PXN_HeaderBUS BUS = new PXN_HeaderBUS();
        private PXN_DetailsBUS BUS1 = new PXN_DetailsBUS();
        private KHMau_LABBUS BUS2 = new KHMau_LABBUS();
        public PXN_Header OBJ = new PXN_Header();

        private DataTable dt_PXN_Header,
                    dt_KHMau_Details = new DataTable();

        //----------------------------Report parameters declare---------------------------------------------
        //string Path = "C:";
        private string Path = Directory.GetCurrentDirectory();

        private CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        //----------------------------End Report parameters declare---------------------------------------------

        public R_PGM_LAB()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                dt_PXN_Header = BUS.PXN_HeaderBUS_SELECT(OBJ.SoPXN);
                dt_KHMau_Details = BUS2.KHMau_LABDAO_REPORT_DETAILS(OBJ.SoPXN);

                dt_PXN_Header.WriteXml(Path + "/Xml/dt_PXN_Header_LAB.xml", System.Data.XmlWriteMode.IgnoreSchema);
                dt_KHMau_Details.WriteXml(Path + "/Xml/dt_KHMau_Details.xml", System.Data.XmlWriteMode.IgnoreSchema);

                rpt.Load(Path + "/RPT/Rpt_PGM_LAB.rpt");
                crvReport.ReportSource = rpt;
            };

            action1.Print(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Print));
            action1.Close(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Close));
        }

        private void ItemClickEventHandler_Print(object sender, EventArgs e)
        {
            try
            {
                //PrinterSettings prs = new PrinterSettings();
                PrintDialog printDialog1 = new PrintDialog();
                PrintDocument pd = new PrintDocument();
                PaperSource ps = new PaperSource();
                //IEnumerable<PaperSize> paperSizes = prs.PaperSizes.Cast<PaperSize>();
                //PaperSize sizeLetter = paperSizes.First<PaperSize>(size => size.Kind == PaperKind.Letter); // setting paper size to A4 size

                PaperKind pk = new PaperKind();
                pk = PaperKind.Letter;

                ps.SourceName = "cassette 1";

                pd.DefaultPageSettings.PaperSource = ps;
                pd.DefaultPageSettings.PaperSize.RawKind = (int)pk;

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

        private void ItemClickEventHandler_Close(object sender, EventArgs e)
        {
            this.Close();
        }

        private void PrintReport(PrintDocument pd)
        {
            ReportDocument rDoc = (ReportDocument)crvReport.ReportSource;
            // This line helps, in case user selects a different printer
            // other than the default selected.
            rDoc.PrintOptions.PrinterName = pd.PrinterSettings.PrinterName;
            // In place of Frompage and ToPage put 0,0 to print all pages,
            // however in that case user wont be able to choose selection.
            rDoc.PrintToPrinter(pd.PrinterSettings.Copies, false, pd.PrinterSettings.FromPage, pd.PrinterSettings.ToPage);
        }
    }
}