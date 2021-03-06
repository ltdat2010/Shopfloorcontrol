﻿using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class R_PO_LAB : frm_Base
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

        private PO_Header_BUS BUS = new PO_Header_BUS();
        private PO_Lines_BUS BUS1 = new PO_Lines_BUS();

        //KHMau_LABBUS BUS2 = new KHMau_LABBUS();
        public PO_Header OBJ = new PO_Header();

        private DataTable dt_PO_Header,
                    dt_PO_Lines = new DataTable();

        //----------------------------Report parameters declare---------------------------------------------
        //string Path = "C:";
        private string XmlPath = _GEN.Xml_Path.Create_Temp_Xml();
        private string Path = Directory.GetCurrentDirectory();

        private CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        //----------------------------End Report parameters declare---------------------------------------------

        public R_PO_LAB()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                dt_PO_Header = BUS.PO_Header_SELECT(OBJ.SoPO);
                dt_PO_Lines = BUS1.PO_Lines_SELECT(OBJ.SoPO);

                dt_PO_Header.WriteXml(XmlPath + @"\dt_PO_Header_LAB.xml", System.Data.XmlWriteMode.IgnoreSchema);
                dt_PO_Lines.WriteXml(XmlPath + @"\dt_PO_Lines_LAB.xml", System.Data.XmlWriteMode.IgnoreSchema);

                rpt.Load(Path + @"\RPT\_LAB\Rpt_PO_LAB.rpt");
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