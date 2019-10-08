using CrystalDecisions.CrystalReports.Engine;
using DevExpress.XtraBars;
using System;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class R_BaoCao_HuyetThanhHoc : frm_Base
    {
        private IBD_RESULT_Header_LABBUS BUS = new IBD_RESULT_Header_LABBUS();
        public int CTXN_ID;
        public string year;

        //public string ToDate;
        private DataTable dt_BaoCao_HuyetThanhHoc = new DataTable();

        //----------------------------Report parameters declare---------------------------------------------

        private string XmlPath = _GEN.Xml_Path.Create_Temp_Xml();
        private string Path = Directory.GetCurrentDirectory();
        private CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        //----------------------------End Report parameters declare---------------------------------------------

        public R_BaoCao_HuyetThanhHoc()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                //txtFrDate.Text = FrDate;
                //txtToDate.Text = ToDate;

                dt_BaoCao_HuyetThanhHoc = BUS.BaoCao_HuyetThanhHoc_IBD(year, CTXN_ID);
                //XtraMessageBox.Show("dt.Rows.Count" + dt.Rows.Count.ToString());
                if (dt_BaoCao_HuyetThanhHoc.Rows.Count > 0)
                    dt_BaoCao_HuyetThanhHoc.WriteXml(XmlPath + "/dt_BaoCao_HuyetThanhHoc.xml", System.Data.XmlWriteMode.IgnoreSchema);

                rpt.Load(Path + "/RPT/Rpt_BaoCao_HuyetThanhHoc.rpt");
                rpt.SetParameterValue("CTXN_ID", CTXN_ID);
                rpt.SetParameterValue("year", year);
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