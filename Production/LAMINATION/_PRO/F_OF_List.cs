using DevExpress.XtraEditors;
using DevExpress.XtraPrinting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_OF_List : UC_Base
    {
        private OF of = new OF();
        private OFBUS OFB = new OFBUS();
        private COABUS COB = new COABUS();
        private CSVFromToDataTable CSV = new CSVFromToDataTable();
        private RMUSEDBUS RMB = new RMUSEDBUS();

        private DataTable dt_OFHeader,
                    dt_OFListComponents,
                    dt_OFListBatchs,
                    dt_OFListBatchDetails = new DataTable();

        //Luu du lieu edit vao list
        //class UserVal
        //{
        //    public UserVal(string col, int row, float value)
        //    {
        //        this.Col = col;
        //        this.Row = row;
        //        this.Value = value;

        //    }
        //    public string Col;
        //    public int Row;
        //    public float Value;
        //}

        private List<OF> OFList = new List<OF>();

        public F_OF_List()
        {
            InitializeComponent();

            Load += (s, e) =>
            {
                OFB.F_OF_List(gridControl1);
                gridView1.BestFitColumns();

                //2018-09-25
                //Load OF từ Nutriciel
                //DataTable dt2 = new DataTable();
                //dt2 = OFB.F_OF_Finished();
                //gridControl2.DataSource = dt2;
                //sYNC_NUTRICIELDataSet.tbl_OF_Finished.Clear();
                //gridControl2.DataSource = tbl_OF_FinishedTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_OF_Finished);
                gridControl2.DataSource = OFB.F_OF_Finished();
                gridView2.BestFitColumns();
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                ////Load dữ liệu từ MF lên grid
                ////gridControl2.DataSource = CSV.ConvertCsvStringToDataTable(true, @"D:\\Eresis\\EXCHANGES\\OUT\\MP_1199.CSV");
                ////gridControl2.DataSource =CSV.OpenCsvFileAsDataTable(@"D:\\Eresis\\EXCHANGES\\OUT\\MP_1199.CSV", false);

                this.repositoryItemLookUpEdit1.DataSource = OFB.CD_OF_Finished();
            };

            action1.View(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_View));
            action1.CSV(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_CSV));
            action1.Report(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Report));
            action_Function1.PKN(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_PKN));
            action_Function1.COA(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_COA));
            action_Function1.TRACE(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_TRACE));
            gridView1.DoubleClick += (s, e) =>
                {
                    ////Lưu ý phải lớn hơn 1, >0 bị lỗi
                    //if (CSV.ConvertCsvStringToDataTable(true, @"D:\\Eresis\\EXCHANGES\\OUT\\MP_" +
                    //                    gridView1.GetFocusedRowCellValue("CD_OF").ToString() + ".CSV").Rows.Count > 1)
                    //{
                    //        gridControl2.DataSource = CSV.ConvertCsvStringToDataTable(true, @"D:\\Eresis\\EXCHANGES\\OUT\\MP_" +
                    //                                gridView1.GetFocusedRowCellValue("CD_OF").ToString() + ".CSV");

                    //        //Kiểm tra có lưu trong database chưa
                    //        //Nếu chưa thì lưu
                    //        if (RMB.RMUSED_Find(gridView1.GetFocusedRowCellValue("CD_OF").ToString()).Rows.Count <= 0)
                    //        {
                    //            //MessageBox.Show("gridView2.DataRowCount :" + gridView2.DataRowCount.ToString());
                    //            for (int i = 0; i < gridView2.DataRowCount; i++)
                    //            {
                    //                //MessageBox.Show("i :" + i.ToString());
                    //                RMB.RMUSED_INSERT(gridView2.GetDataRow(i));
                    //            }
                    //        }
                    //}
                    //else
                    //    gridControl2.DataSource = null;
                };
            gridView2.DoubleClick += (s, e) =>
            {
                //if (gridView2.GetFocusedRowCellValue("CD_OF").ToString().Length > 0)
                //{
                //    gridControl3.DataSource = OFB.OF_ListBatch(gridView2.GetFocusedRowCellValue("CD_OF").ToString());
                //    gridView3.BestFitColumns();
                //    gridControl4.DataSource = COB.COA_Search_ByWO(gridView2.GetFocusedRowCellValue("CD_OF").ToString());
                //    gridView4.BestFitColumns();
                //}
            };
            btnUpdate.Click += (s, e) =>
            {
                foreach (OF item in OFList)
                {
                    OFB.OF_Finished_UPDATE(
                        item.CD_OF,
                        item.TOL_QTY_PAK,
                        item.FUL_PAK_TYPE,
                        item.FUL_PAK_BAG,
                        item.LST_PAK_TYPE,
                        item.LST_PAK_BAG,
                        item.CONTAMINATION_PAK,
                        item.FRM_CD_OF,
                        item.REMAIN_PREV_CD_OF_QTY
                        );
                }
            };

            btnPrintPreview.Click += (s, e) =>
            {
                // Open the Preview window.
                gridControl2.ShowPrintPreview();
            };

            btnExportToXslx.Click += (s, e) =>
            {
                // Open the Preview window.
                gridControl2.ExportToXlsx("D:\\Display_OF_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx");
                XtraMessageBox.Show("Your file has been exported as the following path : D:\\Display_OF_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx");
            };

            gridView2.CellValueChanged += (s, e) =>
            {
                OFList.Add(new OF(
                    gridView2.GetFocusedRowCellValue("CD_OF").ToString(),
                    gridView2.GetFocusedRowCellValue("TOL_QTY_PAK").ToString().Length == 0 ? 0 : float.Parse(gridView2.GetFocusedRowCellValue("TOL_QTY_PAK").ToString()),
                    gridView2.GetFocusedRowCellValue("FUL_PAK_TYPE").ToString(),
                    gridView2.GetFocusedRowCellValue("FUL_PAK_BAG").ToString().Length == 0 ? 0 : float.Parse(gridView2.GetFocusedRowCellValue("FUL_PAK_BAG").ToString()),
                    gridView2.GetFocusedRowCellValue("LST_PAK_TYPE").ToString(),
                    gridView2.GetFocusedRowCellValue("LST_PAK_BAG").ToString().Length == 0 ? 0 : float.Parse(gridView2.GetFocusedRowCellValue("LST_PAK_BAG").ToString()),
                    gridView2.GetFocusedRowCellValue("CONTAMINATION_PAK").ToString().Length == 0 ? 0 : float.Parse(gridView2.GetFocusedRowCellValue("CONTAMINATION_PAK").ToString()),
                    gridView2.GetFocusedRowCellValue("FRM_CD_OF").ToString(),
                    gridView2.GetFocusedRowCellValue("REMAIN_PREV_CD_OF_QTY").ToString().Length == 0 ? 0 : float.Parse(gridView2.GetFocusedRowCellValue("REMAIN_PREV_CD_OF_QTY").ToString())
                    ));
            };

            //gridView3.DoubleClick += (s, e) =>
            //{
            //    if(gridView3.GetFocusedRowCellValue("SoPKN").ToString()!="0")
            //    {
            //        frm_PKN PKN = new frm_PKN();
            //        PKN.KQKNTemplateID = int.Parse(gridView1.GetFocusedRowCellValue("KQKNTemplateID").ToString());
            //        PKN.ActStatus = "V";
            //        PKN.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            //        PKN.SoPKN = gridView1.GetFocusedRowCellValue("SoPKN").ToString();
            //        PKN.SoPNK = gridView1.GetFocusedRowCellValue("SoPNK").ToString();
            //        PKN.Show();
            //    }

            //};

            //gridView4.RowClick += (s, e) =>
            //{
            //    frm_COA COA = new frm_COA();
            //    COA.SoCOA = gridView4.GetFocusedRowCellValue("SoCOA").ToString();
            //    COA.ActStatus = "V";
            //    COA.CD_OF = gridView4.GetFocusedRowCellValue("WO").ToString();
            //    COA.Show();
            //};

            //gridView3.CustomDrawEmptyForeground += (s, e) =>
            //{
            //    DevExpress.XtraGrid.Views.Grid.GridView view = s as DevExpress.XtraGrid.Views.Grid.GridView;

            //    if (view.RowCount != 0) return;

            //    StringFormat drawFormat = new StringFormat();

            //    drawFormat.Alignment = drawFormat.LineAlignment = StringAlignment.Center;

            //    e.Graphics.DrawString("Vui lòng chọn WO bên trên ", e.Appearance.Font, SystemBrushes.ControlDark, new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), drawFormat);

            //};

            //gridView4.CustomDrawEmptyForeground += (s, e) =>
            //{
            //    DevExpress.XtraGrid.Views.Grid.GridView view = s as DevExpress.XtraGrid.Views.Grid.GridView;

            //    if (view.RowCount != 0) return;

            //    StringFormat drawFormat = new StringFormat();

            //    drawFormat.Alignment = drawFormat.LineAlignment = StringAlignment.Center;

            //    e.Graphics.DrawString("Vui lòng chọn WO bên trên ", e.Appearance.Font, SystemBrushes.ControlDark, new RectangleF(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height), drawFormat);

            //};
        }

        private void ItemClickEventHandler_View(object sender, EventArgs e)
        {
            //MessageBox.Show("click");
        }

        private void ItemClickEventHandler_CSV(object sender, EventArgs e)
        {
            F_OF_Details F_OFD = new F_OF_Details();
            F_OFD.CDOF = gridView1.GetFocusedRowCellValue("CD_OF").ToString();
            F_OFD.Show();
        }

        private void ItemClickEventHandler_Report(object sender, EventArgs e)
        {
            if (!gridView2.GetFocusedRowCellValue("CD_OF").ToString().Equals(""))
            {
                R_OF ROF = new R_OF();
                //Dòng đầu tiên
                ROF.OF = gridView2.GetFocusedRowCellValue("CD_OF").ToString();
                ROF.TotalBatchNb = "1";
                ROF.Show();
                //Tạm kháo mở lại sau ngày 29/05/2019
                //R_OF_Summary ROFS = new R_OF_Summary();
                ////Dòng đầu tiên
                //ROFS.OF = gridView2.GetFocusedRowCellValue("CD_OF").ToString();
                //ROFS.TotalBatchNb = "1";
                //ROFS.Show();
            }
            else
                XtraMessageBox.Show(" Vui lòng chọn số WO ");
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
            R_OF_Tracebility RTR = new R_OF_Tracebility();
            RTR.OF = gridView2.GetFocusedRowCellValue("CD_OF").ToString();
            RTR.Show();
        }

        private void gridView2_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
            PrintingSystemBase pb = e.PrintingSystem as PrintingSystemBase;
            pb.PageSettings.Landscape = true;
            pb.PageSettings.LeftMargin = 5;
            pb.PageSettings.RightMargin = 0;
            pb.PageSettings.BottomMargin = 0;
            pb.PageSettings.TopMargin = 5;
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            //XtraMessageBox.Show(gridView1.GetFocusedRowCellValue("CD_OF").ToString());
            //XtraMessageBox.Show(e.Button.Caption);
            if (e.Button.Caption == "Finished")
            {
                if (OFB.OF_Report_OFHeader_Visible(gridView1.GetFocusedRowCellValue("CD_OF").ToString()) == false)
                {
                    if (XtraMessageBox.Show("Do you want to mark WO " + gridView1.GetFocusedRowCellValue("CD_OF").ToString() + " as finished ?. You cannot preverse the WO status after finished. Are your sure ?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //XtraMessageBox.Show(gridView1.GetFocusedRowCellValue("CD_OF").ToString());
                        dt_OFHeader = OFB.OF_Report_OFHeader(gridView1.GetFocusedRowCellValue("CD_OF").ToString());
                        dt_OFListBatchDetails = OFB.OF_Report_OFListBatchDetails(gridView1.GetFocusedRowCellValue("CD_OF").ToString());

                        if (OFB.OF_Report_OFHeader_Visible(gridView1.GetFocusedRowCellValue("CD_OF").ToString()) == false)
                        {
                            if (dt_OFHeader.Rows.Count > 0 && dt_OFListBatchDetails.Rows.Count > 0)
                            {
                                foreach (DataRow dr in dt_OFHeader.Rows)
                                {
                                    OFB.OF_Report_OFHeader_Insert(dr);
                                }
                                foreach (DataRow dr in dt_OFListBatchDetails.Rows)
                                {
                                    OFB.OF_Report_OFListBatchDetails_Insert(gridView1.GetFocusedRowCellValue("CD_OF").ToString(), dr);
                                }
                                //sYNC_NUTRICIELDataSet.tbl_OF_Finished.Clear();
                                //gridControl2.DataSource = tbl_OF_FinishedTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_OF_Finished);
                                gridControl2.DataSource = OFB.F_OF_Finished();
                            }
                            else
                                XtraMessageBox.Show("The Work Order selected is invalidated or not completed. Please contact Production Dept. Thanks");
                        }
                    }
                }
                else
                    XtraMessageBox.Show("The Work Order is Finished. Please don't try import to OF finished list");
            }
            repositoryItemButtonEdit1.ReadOnly = false;
        }
    }
}