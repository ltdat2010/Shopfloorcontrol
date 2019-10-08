using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;

namespace Production.Class
{
    public partial class F_InternalTranfer_List : UC_Base
    {
        private string Path = Directory.GetCurrentDirectory();
        private CrystalDecisions.CrystalReports.Engine.ReportDocument rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();

        private DataTable dt_InternalTransfer_Header,
                  dt_InternalTransfer_Detail = new DataTable();

        private ASIALANDDataSetTableAdapters.Internal_Transfer_DetailTableAdapter internal_Transfer_DetailTableAdapter = new ASIALANDDataSetTableAdapters.Internal_Transfer_DetailTableAdapter();

        public F_InternalTranfer_List()
        {
            InitializeComponent();

            Load += (s, e) =>
            {
                warehouseTableAdapter.Fill(aSIALANDDataSet.Warehouse);
                //XtraMessageBox.Show("Path : " +Path);
            };
            //};

            action1.View(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_View));
            action1.CSV(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_CSV));
            action1.Report(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Report));

            lkEWarehouse.EditValueChanged += (s, e) =>
            {
                gridControl1.DataSource = internal_TransferTableAdapter.Fill(aSIALANDDataSet.Internal_Transfer, lkEWarehouse.EditValue.ToString());
            };

            gridView1.DoubleClick += (s, e) =>
            {
                //dt_InternalTransfer_Header = internal_TransferTableAdapter.GetDataBy(int.Parse(gridView4.GetFocusedRowCellValue("DocNum").ToString()));
                //dt_InternalTransfer_Detail = internal_Transfer_DetailTableAdapter.GetDataBy(int.Parse(gridView4.GetFocusedRowCellValue("DocNum").ToString()));

                //dt_InternalTransfer_Header.WriteXml(Path + "/Xml/dt_InternalTransfer_Header.xml", System.Data.XmlWriteMode.IgnoreSchema);
                //dt_InternalTransfer_Detail.WriteXml(Path + "/Xml/dt_InternalTransfer_Details.xml", System.Data.XmlWriteMode.IgnoreSchema);

                //rpt.Load(Path + "/RPT/Rpt_InternalTransfer.rpt");

                //crvReport.ReportSource = rpt;
            };

            gridView1.CustomDrawEmptyForeground += (s, e) =>
{
    DevExpress.XtraGrid.Views.Grid.GridView view = s as DevExpress.XtraGrid.Views.Grid.GridView;

    if (view.RowCount != 0) return;

    StringFormat drawFormat = new StringFormat();

    drawFormat.Alignment = drawFormat.LineAlignment = StringAlignment.Center;

    e.Graphics.DrawString("Vui lòng chọn WO bên trên ", e.Appearance.Font, SystemBrushes.ControlDark, new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), drawFormat);
};

            action1.Print(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Print));
        }

        private void ItemClickEventHandler_Print(object sender, EventArgs e)
        {
            //try
            //{
            //    PrintDialog printDialog1                            =                           new PrintDialog();
            //    PrintDocument pd                                    =                           new PrintDocument();
            //    printDialog1.Document                               =                           pd;
            //    printDialog1.ShowNetwork                            =                           true;
            //    printDialog1.AllowSomePages                         =                           true;
            //    printDialog1.AllowSelection                         =                           false;
            //    printDialog1.AllowCurrentPage                       =                           false;
            //    printDialog1.PrinterSettings.Copies                 =                           1;
            //    DialogResult result                                 =                           printDialog1.ShowDialog();
            //    if (result                                          ==                          DialogResult.OK)
            //    {
            //        PrintReport(pd);
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }

        private void PrintReport(PrintDocument pd)
        {
            //ReportDocument rDoc                                     =                           (ReportDocument)crvReport.ReportSource;
            //// This line helps, in case user selects a different printer
            //// other than the default selected.
            //rDoc.PrintOptions.PrinterName                           =                           pd.PrinterSettings.PrinterName;
            //// In place of Frompage and ToPage put 0,0 to print all pages,
            //// however in that case user wont be able to choose selection.
            //rDoc.PrintToPrinter(pd.PrinterSettings.Copies, false, pd.PrinterSettings.FromPage,
            //pd.PrinterSettings.ToPage);
        }

        private void ItemClickEventHandler_View(object sender, EventArgs e)
        {
            //MessageBox.Show("click");
        }

        private void ItemClickEventHandler_CSV(object sender, EventArgs e)
        {
        }

        private void ItemClickEventHandler_Report(object sender, EventArgs e)
        {
            R_InternalTransfer_FN RIT = new R_InternalTransfer_FN();
            RIT.DocNum = gridView1.GetFocusedRowCellValue("DocNum").ToString();
            RIT.Show();
        }

        private void ItemClickEventHandler_PKN(object sender, EventArgs e)
        {
            //MessageBox.Show("click");
        }

        private void ItemClickEventHandler_COA(object sender, EventArgs e)
        {
        }

        private void ItemClickEventHandler_TRACE(object sender, EventArgs e)
        {
        }
    }
}