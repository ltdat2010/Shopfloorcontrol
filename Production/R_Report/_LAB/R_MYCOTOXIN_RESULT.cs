using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class R_MYCOTOXIN_RESULT : frm_Base
    {
        /// <summary>
        /// DELEGATE
        /// </summary>        
        public delegate void MyAdd(object sender);
        public event MyAdd myFinished;
        public string RptName;
        public int ID;
        public string acr ;

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

        MYCOTOXIN_RESULT_StandardCurveBUS BUS   = new MYCOTOXIN_RESULT_StandardCurveBUS();
        MYCOTOXIN_RESULT_LinesBUS BUS1 = new MYCOTOXIN_RESULT_LinesBUS();
        MYCOTOXIN_RESULT_HeaderBUS BUS2 = new MYCOTOXIN_RESULT_HeaderBUS();
        //KHMau_LABBUS BUS2 = new KHMau_LABBUS();

        //public PO_Header OBJ = new PO_Header();

        DataTable   dt_MYCOTOXIN_RESULT_Header,
                    dt_MYCOTOXIN_RESULT_StandardCurve,
                    dt_MYCOTOXIN_RESULT_ACR_Lines,
                    dt_MYCOTOXIN_RESULT_STD_Lines,
                    dt_MYCOTOXIN_RESULT_Lines,
                    dt_MYCOTOXIN_RESULT_StandardCurve_Graph
                    = new DataTable();
        //----------------------------Report parameters declare---------------------------------------------
        //string Path = "C:";   
        string XmlPath = _GEN.Xml_Path.Create_Temp_Xml();

        string Path = Directory.GetCurrentDirectory();        
        CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        //----------------------------End Report parameters declare---------------------------------------------
        
        public R_MYCOTOXIN_RESULT()
        {
            InitializeComponent();
            Load += (s,e) =>
            {
                dt_MYCOTOXIN_RESULT_Header = BUS2.MYCOTOXIN_RESULT_Header_SELECT(ID);
                dt_MYCOTOXIN_RESULT_StandardCurve = BUS.MYCOTOXIN_RESULT_StandardCurve_SELECT(ID, acr);
                dt_MYCOTOXIN_RESULT_ACR_Lines = BUS1.MYCOTOXIN_RESULT_Lines_ACR_SELECT(ID, acr);
                dt_MYCOTOXIN_RESULT_STD_Lines = BUS1.MYCOTOXIN_RESULT_Lines_STD_SELECT(ID, acr);
                dt_MYCOTOXIN_RESULT_StandardCurve_Graph = BUS1.MYCOTOXIN_RESULT_Lines_StandardCurve_Graph(ID, acr);
                dt_MYCOTOXIN_RESULT_Lines = BUS1.MYCOTOXIN_RESULT_Lines_SELECT(ID);

                dt_MYCOTOXIN_RESULT_Header.WriteXml(XmlPath + "/dt_MYCOTOXIN_RESULT_Header_LAB.xml", System.Data.XmlWriteMode.IgnoreSchema);
                dt_MYCOTOXIN_RESULT_StandardCurve.WriteXml(XmlPath + "/dt_MYCOTOXIN_RESULT_StandardCurve_LAB.xml", System.Data.XmlWriteMode.IgnoreSchema);
                dt_MYCOTOXIN_RESULT_ACR_Lines.WriteXml(XmlPath + "/dt_MYCOTOXIN_RESULT_ACR_Lines_LAB.xml", System.Data.XmlWriteMode.IgnoreSchema);
                dt_MYCOTOXIN_RESULT_STD_Lines.WriteXml(XmlPath + "/dt_MYCOTOXIN_RESULT_STD_Lines_LAB.xml", System.Data.XmlWriteMode.IgnoreSchema);
                dt_MYCOTOXIN_RESULT_StandardCurve_Graph.WriteXml(XmlPath + "/dt_MYCOTOXIN_RESULT_StandardCurve_Graph_LAB.xml", System.Data.XmlWriteMode.IgnoreSchema);
                dt_MYCOTOXIN_RESULT_Lines.WriteXml(XmlPath + "/dt_MYCOTOXIN_RESULT_Lines_LAB.xml", System.Data.XmlWriteMode.IgnoreSchema);
                //rpt.Load(Path + "/RPT/Rpt_MYCOTOXIN_RESULT_LAB.rpt");
                //XtraMessageBox.Show(Path);                
                rpt.Load(Path + "/RPT/_LAB/"+ RptName + ".rpt");
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
            rDoc.PrintToPrinter(pd.PrinterSettings.Copies, false, pd.PrinterSettings.FromPage,pd.PrinterSettings.ToPage);
        }      
    }
}
