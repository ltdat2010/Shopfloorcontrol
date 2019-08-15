using CrystalDecisions.CrystalReports.Engine;
using DevExpress.XtraBars;
using System;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class R_InternalTransfer_FN : frm_Base
    {
        public string DocNum = "";
        private CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

        private DataTable dt_InternalTransfer_Header,
                  dt_InternalTransfer_Detail = new DataTable();

        private ASIALANDDataSetTableAdapters.Internal_Transfer_DetailTableAdapter internal_Transfer_DetailTableAdapter = new ASIALANDDataSetTableAdapters.Internal_Transfer_DetailTableAdapter();
        private ASIALANDDataSetTableAdapters.Internal_TransferTableAdapter internal_TransferTableAdapter = new ASIALANDDataSetTableAdapters.Internal_TransferTableAdapter();
        private string Path = Directory.GetCurrentDirectory();
        //----------------------------End Report parameters declare---------------------------------------------

        public R_InternalTransfer_FN()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                dt_InternalTransfer_Header = internal_TransferTableAdapter.GetDataBy(int.Parse(DocNum));
                dt_InternalTransfer_Detail = internal_Transfer_DetailTableAdapter.GetDataBy(int.Parse(DocNum));

                //XtraMessageBox.Show("Path : " +Path);

                //
                //if (dt_InternalTransfer_Header.Rows.Count > 0)
                //{
                dt_InternalTransfer_Header.WriteXml(Path + "/Xml/dt_InternalTransfer_Header.xml", System.Data.XmlWriteMode.IgnoreSchema);
                dt_InternalTransfer_Detail.WriteXml(Path + "/Xml/dt_InternalTransfer_Details.xml", System.Data.XmlWriteMode.IgnoreSchema);
                //}

                //XtraMessageBox.Show("rpt.Load ");
                rpt.Load(Path + "/RPT/Rpt_InternalTransfer.rpt");

                //XtraMessageBox.Show("crvReport.ReportSource ");
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
            rDoc.PrintToPrinter(pd.PrinterSettings.Copies, false, pd.PrinterSettings.FromPage, pd.PrinterSettings.ToPage);
        }
    }
}