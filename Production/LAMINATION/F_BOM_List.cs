using System;
using System.Collections.Generic;

namespace Production.Class
{
    public partial class F_BOM_List : UC_Base
    {
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

        public F_BOM_List()
        {
            InitializeComponent();

            Load += (s, e) =>
            {
                //OFB.F_OF_List(gridControl1);
                //gridView1.BestFitColumns();
                oITTTableAdapter.Fill(aSIALANDDataSet.OITT);
                //oITTTableAdapter.Fill(aSIALANDDataSet.ITT1);
                //gridControl2.DataSource = tbl_OF_FinishedTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_OF_Finished);
                //gridView2.BestFitColumns();
                ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////

                //this.repositoryItemLookUpEdit1.DataSource = OFB.CD_OF_Finished();
            };

            action1.View(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_View));
            action1.CSV(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_CSV));
            action1.Report(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Report));
            action_Function1.PKN(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_PKN));
            action_Function1.COA(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_COA));
            action_Function1.TRACE(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_TRACE));
            gridView1.DoubleClick += (s, e) =>
                {
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
                //foreach (OF item in OFList)
                //{
                //    OFB.OF_Finished_UPDATE(
                //        item.CD_OF,
                //        item.TOL_QTY_PAK,
                //        item.FUL_PAK_TYPE,
                //        item.FUL_PAK_BAG,
                //        item.LST_PAK_TYPE,
                //        item.LST_PAK_BAG,
                //        item.CONTAMINATION_PAK,
                //        item.FRM_CD_OF,
                //        item.REMAIN_PREV_CD_OF_QTY
                //        );
                //}
            };

            btnPrintPreview.Click += (s, e) =>
            {
                //// Open the Preview window.
                //gridControl2.ShowPrintPreview();
            };

            btnExportToXslx.Click += (s, e) =>
            {
                //// Open the Preview window.
                //gridControl2.ExportToXlsx("D:\\All_OF_" + DateTime.Now.ToString("yyyyMMdd") + ".xlsx");
            };

            gridView2.CellValueChanged += (s, e) =>
            {
                //OFList.Add(new OF(
                //    gridView2.GetFocusedRowCellValue("CD_OF").ToString(),
                //    gridView2.GetFocusedRowCellValue("TOL_QTY_PAK").ToString().Length == 0 ? 0 :float.Parse(gridView2.GetFocusedRowCellValue("TOL_QTY_PAK").ToString()),
                //    gridView2.GetFocusedRowCellValue("FUL_PAK_TYPE").ToString(),
                //    gridView2.GetFocusedRowCellValue("FUL_PAK_BAG").ToString().Length == 0 ? 0 : float.Parse(gridView2.GetFocusedRowCellValue("FUL_PAK_BAG").ToString()),
                //    gridView2.GetFocusedRowCellValue("LST_PAK_TYPE").ToString(),
                //    gridView2.GetFocusedRowCellValue("LST_PAK_BAG").ToString().Length == 0 ? 0 : float.Parse(gridView2.GetFocusedRowCellValue("LST_PAK_BAG").ToString()),
                //    gridView2.GetFocusedRowCellValue("CONTAMINATION_PAK").ToString().Length == 0 ? 0 : float.Parse(gridView2.GetFocusedRowCellValue("CONTAMINATION_PAK").ToString()),
                //    gridView2.GetFocusedRowCellValue("FRM_CD_OF").ToString(),
                //    gridView2.GetFocusedRowCellValue("REMAIN_PREV_CD_OF_QTY").ToString().Length == 0 ? 0 : float.Parse(gridView2.GetFocusedRowCellValue("REMAIN_PREV_CD_OF_QTY").ToString())
                //    ));
            };
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
        }

        private void ItemClickEventHandler_PKN(object sender, EventArgs e)
        {
        }

        private void ItemClickEventHandler_COA(object sender, EventArgs e)
        {
        }

        private void ItemClickEventHandler_TRACE(object sender, EventArgs e)
        {
        }

        private void gridView2_PrintInitialize(object sender, DevExpress.XtraGrid.Views.Base.PrintInitializeEventArgs e)
        {
        }
    }
}