using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class R_PXN_LAB : frm_Base
    {
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

        private PXN_HeaderBUS BUS = new PXN_HeaderBUS();
        private PXN_DetailsBUS BUS1 = new PXN_DetailsBUS();
        private KHMau_LABBUS BUS2 = new KHMau_LABBUS();
        public PXN_Header OBJ = new PXN_Header();

        private DataTable dt_PXN_Header,
                    dt_KHMau_Receipt,
                    dt_KHMau_Details,
                    dt_KHMau_STORAGE,
                    dt_KHMau_DETROY,
                    dt_PXN_Details = new DataTable();

        //----------------------------Report parameters declare---------------------------------------------
        //string Path = "C:";
        private string Path = Directory.GetCurrentDirectory();

        private CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        //----------------------------End Report parameters declare---------------------------------------------

        public R_PXN_LAB()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                dt_PXN_Header = BUS.PXN_HeaderBUS_SELECT(OBJ.SoPXN);
                dt_KHMau_Receipt = BUS2.KHMau_LABDAO_REPORT_RECEIPT(OBJ.SoPXN);
                dt_KHMau_Details = BUS2.KHMau_LABDAO_REPORT_DETAILS(OBJ.SoPXN);
                dt_KHMau_STORAGE = BUS2.KHMau_LABDAO_REPORT_STORAGE(OBJ.SoPXN);
                dt_KHMau_DETROY = BUS2.KHMau_LABDAO_REPORT_DETROY(OBJ.SoPXN);
                dt_PXN_Details = BUS1.PXN_DetailsBUS_SELECT(OBJ.SoPXN);

                dt_PXN_Header.WriteXml(Path + "/Xml/dt_PXN_Header_LAB.xml", System.Data.XmlWriteMode.IgnoreSchema);
                dt_PXN_Details.WriteXml(Path + "/Xml/dt_PXN_Details_LAB.xml", System.Data.XmlWriteMode.IgnoreSchema);
                dt_KHMau_Receipt.WriteXml(Path + "/Xml/dt_KHMau_Receipt.xml", System.Data.XmlWriteMode.IgnoreSchema);
                dt_KHMau_Details.WriteXml(Path + "/Xml/dt_KHMau_Details.xml", System.Data.XmlWriteMode.IgnoreSchema);
                dt_KHMau_STORAGE.WriteXml(Path + "/Xml/dt_KHMau_STORAGE.xml", System.Data.XmlWriteMode.IgnoreSchema);
                dt_KHMau_DETROY.WriteXml(Path + "/Xml/dt_KHMau_DETROY.xml", System.Data.XmlWriteMode.IgnoreSchema);

                rpt.Load(Path + "/RPT/Rpt_PXN_LAB.rpt");
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

                PaperKind ppk = new PaperKind();
                ppk = PaperKind.Letter;

                ps.SourceName = "cassette 1";
                pd.DefaultPageSettings.PaperSource = ps;
                pd.DefaultPageSettings.PaperSize.RawKind = (int)ppk;
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
            Is_close = true;
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