using DevExpress.XtraBars;
using DevExpress.XtraGrid.Columns;
using System;
using System.Data;
using System.Drawing.Printing;
using System.IO;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class R_BaoCao_HuyetThanhHoc_EXCEL : frm_Base
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

        public R_BaoCao_HuyetThanhHoc_EXCEL()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                //txtFrDate.Text = FrDate;
                //txtToDate.Text = ToDate;

                dt_BaoCao_HuyetThanhHoc = BUS.BaoCao_HuyetThanhHoc_IBD(year, CTXN_ID);

                if (dt_BaoCao_HuyetThanhHoc.Rows.Count > 0)
                    gridControl1.DataSource = dt_BaoCao_HuyetThanhHoc;

                gridView1.BestFitColumns();
            };

            action1.Print(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Print));
            action1.Close(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Close));
            action1.Excel(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Excel));
        }

        private void ItemClickEventHandler_Excel(object sender, ItemClickEventArgs e)
        {
            string filename = "BaoCaoHuyetThanhHoc_" + DateTime.Today.ToShortDateString().Replace("/", "") + ".xlsx";
            string filePath = @"X:\" + filename;

            //Save current layout
            gridView1.SaveLayoutToXml(@"X:\tempLayout.xml");
            //Set to visible all column
            foreach (GridColumn column in gridView1.Columns)
            {
                switch (column.Name)
                {
                    case "colSoPXN":
                        column.Caption = "Số phiếu nhận mẫu";
                        column.VisibleIndex = 1;
                        column.Visible = true;
                        break;

                    case "colMonth":
                        column.Caption = "Tháng";
                        column.VisibleIndex = 2;
                        column.Visible = true;
                        break;

                    case "colYear":
                        column.Caption = "Năm";
                        column.VisibleIndex = 3;
                        column.Visible = true;
                        break;

                    case "colProvinceName":
                        column.Caption = "Tỉnh/Thành";
                        column.VisibleIndex = 4;
                        column.Visible = true;
                        break;

                    case "colTenCoSoGuiMau":
                        column.Caption = "Người gửi mẫu";
                        column.VisibleIndex = 5;
                        column.Visible = true;
                        break;

                    case "colTenCoSoLayMau":
                        column.Caption = "Khách hàng";
                        column.VisibleIndex = 5;
                        column.Visible = true;
                        break;

                    case "colTenLoaiDV":
                        column.Caption = "Loài động vật";
                        column.VisibleIndex = 6;
                        column.Visible = true;
                        break;

                    case "colSoLuongXN":
                        column.Caption = "Số lượng";
                        column.VisibleIndex = 7;
                        column.Visible = true;
                        break;

                    case "colPos":
                        column.Caption = "Positive";
                        column.VisibleIndex = 8;
                        column.Visible = true;
                        break;

                    case "colNeg":
                        column.Caption = "Negative";
                        column.VisibleIndex = 9;
                        column.Visible = true;
                        break;

                    default:
                        column.Visible = false;
                        break;
                }
                //No
                //if (column.Name == "colID")
                //{
                //    //column.Caption = "No";
                //    column.VisibleIndex = 0;
                //    column.Visible = true;
                //}
                ////So PXN
                //else if (column.Name == "SoPXN")
                //{
                //    //column.Caption = "Mã KH";
                //    column.VisibleIndex = 1;
                //    column.Visible = true;
                //}
                ////Month
                //else if (column.Name == "Month")
                //{
                //    //column.Caption = "Month";
                //    column.VisibleIndex = 2;
                //    column.Visible = true;
                //}
                ////Year
                //else if (column.Name == "Year")
                //{
                //    //column.Caption = "Year";
                //    column.VisibleIndex = 3;
                //    column.Visible = true;
                //}
                ////Areas
                //else if (column.Name == "Province Name")
                //{
                //    //column.Caption = "Areas";
                //    column.VisibleIndex = 4;
                //    column.Visible = true;
                //}
                ////Customer
                //else if (column.Name == "TenCoSoLayMau")
                //{
                //    //column.Caption = "Customer";
                //    column.VisibleIndex = 5;
                //    column.Visible = true;
                //}
                ////Animals
                //else if (column.Name == "TenLoaiDV")
                //{
                //    //column.Caption = "Animals";
                //    column.VisibleIndex = 6;
                //    column.Visible = true;
                //}
                ////Quantity
                //else if (column.Name == "SoLuongXN")
                //{
                //    //column.Caption = "Quantity";
                //    column.VisibleIndex = 7;
                //    column.Visible = true;
                //}
                ////Positive
                //else if (column.Name == "Pos")
                //{
                //    //column.Caption = "Positive";
                //    column.VisibleIndex = 8;
                //    column.Visible = true;
                //}
                ////Negative
                //else if (column.Name == "Neg")
                //{
                //    //column.Caption = "Negative";
                //    column.VisibleIndex = 9;
                //    column.Visible = true;
                //}
                //else
                //    column.Visible = false;
            }
            //Export
            gridView1.ExportToXlsx(filePath);
            //Restore layout
            gridView1.RestoreLayoutFromXml(@"X:\tempLayout.xml");
            System.Diagnostics.Process.Start(filePath);
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
            //ReportDocument rDoc = (ReportDocument)crvReport.ReportSource;
            //// This line helps, in case user selects a different printer
            //// other than the default selected.
            //rDoc.PrintOptions.PrinterName = pd.PrinterSettings.PrinterName;
            //// In place of Frompage and ToPage put 0,0 to print all pages,
            //// however in that case user wont be able to choose selection.
            //rDoc.PrintToPrinter(pd.PrinterSettings.Copies, false, pd.PrinterSettings.FromPage,
            //   pd.PrinterSettings.ToPage);
        }
    }
}