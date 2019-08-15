using DevExpress.XtraEditors;
using System;
using System.IO;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_OABatch_Issued : UC_Base
    {
        private OABatchBUS OAB = new OABatchBUS();
        private CSVFromToDataTable XLSX = new CSVFromToDataTable();

        public F_OABatch_Issued()
        {
            InitializeComponent();

            Load += (s, e) =>
                {
                    BtnOABATCH.Enabled = false;
                    gridControl2.DataSource = OAB.OABatch_View();
                };
            action1.Excel(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Excel));
            action1.Report(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Report));
            BtnOABATCH.Click += (s, e) =>
                {
                    for (int i = 0; i <= gridView1.RowCount - 1; i++)
                    {
                        string tmp =
                         gridView1.GetRowCellValue(i, "Item Code").ToString() +
                         gridView1.GetRowCellValue(i, "Supplier code").ToString() +
                         (DateTime.Parse(gridView1.GetRowCellValue(i, "Received date").ToString())).DayOfYear.ToString() +
                         (DateTime.Parse(gridView1.GetRowCellValue(i, "Received date").ToString())).Year.ToString().Substring(2, 2) +
                         gridView1.GetRowCellValue(i, "Times of receiving in day").ToString();
                        //Chua co Lot-Number thi tao moi
                        System.Data.DataTable dtLotNumber = new System.Data.DataTable();
                        dtLotNumber = OAB.Lot_Number_Visible(gridView1.GetRowCellValue(i, "Lot number").ToString());

                        if (dtLotNumber.Rows.Count <= 0)
                            gridView1.SetRowCellValue(i, "OA BATCH", tmp);

                        //Ton tao Lot_number thi lay OABatch da co
                        else
                            gridView1.SetRowCellValue(i, "OA BATCH", dtLotNumber.Rows[0]["OA BATCH"].ToString());

                        if (gridView1.GetRowCellValue(i, "Lot number").ToString().Length == 0)
                        {
                            gridView1.SetRowCellValue(i, "Lot number", gridView1.GetRowCellValue(i, "OA BATCH").ToString());
                        }

                        //Kiem tra xem [OA Batch] tồn tại chưa--Update cho trung OA Batch
                        OAB.OABatch_INSERT(gridView1.GetDataRow(i));
                    }

                    gridControl2.DataSource = OAB.OABatch_View();

                    XLSX.WRITE2XSLX(gridView1);

                    gridControl1.DataSource = null;
                };

            BtnEXCEL.Click += (s, e) =>
                {
                    string savepath = "D:\\OABatch_Export" + DateTime.Today.ToString("yyyymmdd") + ".xlsx";
                    gridControl2.ExportToXlsx(savepath);

                    FileInfo fi = new FileInfo(savepath);
                    if (fi.Exists)
                    {
                        System.Diagnostics.Process.Start(savepath);
                    }
                    else
                    {
                        XtraMessageBox.Show("File doesn't exist");
                    }
                };
        }

        private void ItemClickEventHandler_Excel(object sender, EventArgs e)
        {
            try
            {
                XLSX.XLSX2Grid(gridControl1);

                BtnOABATCH.Enabled = true;
            }
            catch (Exception ex)
            {
                string _error = ex.Message;
                MessageBox.Show(_error);
                throw;
            }
        }

        private void copyAlltoClipboard()
        {
            //to remove the first blank column from datagridview
            gridView1.SelectAll();
            gridView1.CopyToClipboard();
        }

        private void ItemClickEventHandler_Report(object sender, EventArgs e)
        {
            R_FrDate_ToDate_OABatch RFTOAB = new R_FrDate_ToDate_OABatch();
            RFTOAB.Show();
        }
    }
}