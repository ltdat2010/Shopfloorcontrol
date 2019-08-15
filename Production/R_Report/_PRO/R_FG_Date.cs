using CrystalDecisions.CrystalReports.Engine;
using DevExpress.XtraBars;
using System;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class R_FG_Date : frm_Base
    {
        private OFBUS OFB = new OFBUS();
        public string FrDate;
        public string ToDate;
        private DataTable dt = new DataTable();
        //----------------------------Report parameters declare---------------------------------------------
        //string Path = "C:";

        private string Path = Directory.GetCurrentDirectory();
        private CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
        //----------------------------End Report parameters declare---------------------------------------------

        public R_FG_Date()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                txtFrDate.Text = FrDate;
                txtToDate.Text = ToDate;

                dt = OFB.OF_Report_ByDate(FrDate, ToDate);
                //XtraMessageBox.Show("dt.Rows.Count" + dt.Rows.Count.ToString());
                if (dt.Rows.Count > 0)
                    dt.WriteXml(Path + "/../../Xml/OF_Report_ByDate.xml", System.Data.XmlWriteMode.IgnoreSchema);

                rpt.Load(Path + "/../../RPT/Rpt_FG_by_Date.rpt");
                rpt.SetParameterValue("P_FrDate", FrDate);
                rpt.SetParameterValue("P_ToDate", ToDate);
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