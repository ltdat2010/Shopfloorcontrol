using CrystalDecisions.CrystalReports.Engine;
using System;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class R_IBD_RESULT_LAB_ANALYSISREPORT : frm_Base
    {
        /// <summary>
        /// DELEGATE
        /// </summary>
        public delegate void MyAdd(object sender);

        public event MyAdd myFinished;

        public string MaCTXN;
        public string SoPXN;

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

        public int ID;
        public string KHMau_GiaoMau;
        public int CTXNID;
        public bool SN = false;

        private IBD_RESULT_Lines_LABBUS BUS1 = new IBD_RESULT_Lines_LABBUS();
        private IBD_RESULT_Header_LABBUS BUS2 = new IBD_RESULT_Header_LABBUS();
        private PXN_HeaderBUS BUS3 = new PXN_HeaderBUS();
        private KHMau_LABBUS kHMau_LABBUS = new KHMau_LABBUS();

        private DataTable
                    dt_PXN_Header,
                    dt_KHMau_LAB_AnalysisReport,
                    dt_IBD_RESULT_Header,
                    dt_IBD_RESULT_Lines
                    = new DataTable();

        private DataSet ds_PXN_Header,
                    ds_KHMau_LAB_AnalysisReport,
                    ds_IBD_RESULT_Header,
                    ds_IBD_RESULT_Lines
                    = new DataSet();

        //----------------------------Report parameters declare---------------------------------------------
        //string Path = "C:";
        private string XmlPath = _GEN.Xml_Path.Create_Temp_Xml();

        private string Path = Directory.GetCurrentDirectory();
        private CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        //----------------------------End Report parameters declare-----------------------------------------

        public R_IBD_RESULT_LAB_ANALYSISREPORT()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                //XtraMessageBox.Show("Path"+Path);
                //XtraMessageBox.Show("XmlPath"+XmlPath);
                dt_PXN_Header = BUS3.PXN_HeaderBUS_SELECT(SoPXN);
                dt_KHMau_LAB_AnalysisReport = kHMau_LABBUS.KHMau_LABDAO_REPORT_AnalysisReport(SoPXN, CTXNID, KHMau_GiaoMau);
                dt_IBD_RESULT_Header = BUS2.IBD_RESULT_Header_LABDAO_SELECT(KHMau_GiaoMau, CTXNID);
                ID = int.Parse(dt_IBD_RESULT_Header.Rows[0]["ID"].ToString());
                dt_IBD_RESULT_Lines = BUS1.IBD_RESULT_Lines_LABDAO_SELECT(ID);
                //Write to XML

                dt_PXN_Header.WriteXml(XmlPath + @"\dt_PXN_Header.xml", System.Data.XmlWriteMode.IgnoreSchema);
                //ds_PXN_Header.ReadXml(XmlPath + @"\dt_PXN_Header.xml");
                //rpt.SetDataSource(ds_PXN_Header);

                dt_KHMau_LAB_AnalysisReport.WriteXml(XmlPath + @"\dt_KHMau_LAB_AnalysisReport.xml", System.Data.XmlWriteMode.IgnoreSchema);
                //dt_KHMau_LAB_AnalysisReport.ReadXml(XmlPath + @"\dt_KHMau_LAB_AnalysisReport.xml");
                //rpt.SetDataSource(ds_PXN_Header);

                dt_IBD_RESULT_Header.WriteXml(XmlPath + @"\dt_IBD_RESULT_Header.xml", System.Data.XmlWriteMode.IgnoreSchema);
                //dt_IBD_RESULT_Header.ReadXml(XmlPath + @"\dt_IBD_RESULT_Header.xml");
                //rpt.SetDataSource(ds_PXN_Header);

                dt_IBD_RESULT_Lines.WriteXml(XmlPath + @"\dt_IBD_RESULT_Lines.xml", System.Data.XmlWriteMode.IgnoreSchema);
                //dt_IBD_RESULT_Lines.ReadXml(XmlPath + @"\dt_IBD_RESULT_Lines.xml");
                //rpt.SetDataSource(ds_PXN_Header);

                ////XtraMessageBox.Show(Path.ToString());

                if (dt_PXN_Header.Rows[0]["NgonNgu"].ToString() == "EN")
                {
                    if (SN == false)
                        rpt.Load(Path + @"\RPT\_LAB/Rpt_IBD_RESULT_Lines_AnalysisReport_LAB_EN.rpt");
                    else
                        rpt.Load(Path + @"\RPT\_LAB/Rpt_IBD_RESULT_Lines_AnalysisReport_LAB_WithSN_EN.rpt");
                }
                else
                {
                    if (SN == false)
                        rpt.Load(Path + @"\RPT\_LAB/Rpt_IBD_RESULT_Lines_AnalysisReport_LAB_VN.rpt");
                    else
                        rpt.Load(Path + @"\RPT\_LAB/Rpt_IBD_RESULT_Lines_AnalysisReport_LAB_WithSN_VN.rpt");
                }
                //rpt.SetParameterValue("PicPath", @"D:\Temp_Xml\AI_Graph.jpeg");
                //CHEK PC Name
                string PCname = System.Environment.MachineName;
                //if (PCname == "vpv-lab-sample")
                //    rpt.SetParameterValue("PicPath", @"D:\SYNC_NUTRICIEL_IMG\IMG_" + KHMau_GiaoMau + CTXNID.ToString() + ".jpeg");
                //else
                rpt.SetParameterValue("PicPath", @"X:\Temp_Xml\IMG_" + KHMau_GiaoMau + CTXNID.ToString() + ".jpeg");
                //rpt.SetParameterValue("PicPath", @"\\VPV-LAB-SAMPLE\SYNC_NUTRICIEL_IMG\IMG_"+ KHMau_GiaoMau + CTXNID .ToString()+ ".jpeg");
                crvReport.ReportSource = rpt;
            };
            action1.Print(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Print));
            action1.Close(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Close));
        }

        private void ItemClickEventHandler_Print(object sender, EventArgs e)
        {
            try
            {
                ////PrinterSettings prs = new PrinterSettings();
                PrintDialog printDialog1 = new PrintDialog();
                PrintDocument pd = new PrintDocument();
                PaperSource ps = new PaperSource();
                ////IEnumerable<PaperSize> paperSizes = prs.PaperSizes.Cast<PaperSize>();
                ////PaperSize sizeLetter = paperSizes.First<PaperSize>(size => size.Kind == PaperKind.Letter); // setting paper size to A4 size
                PaperKind ppk = new PaperKind();
                ppk = PaperKind.Letter;

                //ps.SourceName = "cassette 1";
                pd.DefaultPageSettings.PaperSource = ps;
                pd.DefaultPageSettings.PaperSize.RawKind = (int)ppk;
                printDialog1.Document = pd;
                printDialog1.ShowNetwork = true;
                printDialog1.AllowSomePages = true;
                printDialog1.AllowSelection = false;
                printDialog1.AllowCurrentPage = false;
                printDialog1.PrinterSettings.Copies = 1;

                ////printDialog1.PrinterSettings.PrinterName = this.PrinterToPrint;
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