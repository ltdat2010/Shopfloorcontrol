using DevExpress.XtraGrid.Columns;
using System;
using System.Data;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_RECEIPT_Details : frm_Base //DevExpress.XtraEditors.XtraForm
    {
        private bool EXP_EXCEL = false;
        private int MAX_XHL;
        private RECEIPTBUS RECEIPTB = new RECEIPTBUS();
        public string ECHRECEPS = "";

        public F_RECEIPT_Details()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                RECEIPTB.F_RECEIPT_Detail(gridControl1, ECHRECEPS);

                //for (int i = 0; i < gridView1.DataRowCount; i++)
                //{
                //    int j = 1;
                //    //XtraMessageBox.Show("i :" + i.ToString());
                //    if (i == 0)
                //    {
                //        //XtraMessageBox.Show("i =0 thì j :" + j.ToString());
                //        //j = 1;
                //        gridView1.SetRowCellValue(i, "XHL", j);
                //    }
                //    else
                //    {
                //        if (gridView1.GetRowCellValue(i, "CD_MAT").ToString() == gridView1.GetRowCellValue(i - 1, "CD_MAT").ToString())
                //        {
                //            //XtraMessageBox.Show("2 CD_MAT bang nhau j :" + j.ToString());
                //            gridView1.SetRowCellValue(i, "XHL", int.Parse(gridView1.GetRowCellValue(i - 1, "XHL").ToString()) + 1);
                //        }
                //        else
                //        {
                //            j = 1;
                //            //j = j + 1;
                //            //XtraMessageBox.Show("j :" + j.ToString());
                //            gridView1.SetRowCellValue(i, "XHL", j);
                //        }
                //    }
                //    //XtraMessageBox.Show("1");
                //}

                //Reload lai lên grid để có field XHL
                //gridControl1.DataSource = RECEIPTB.RECEIPT_Detail_Reload(ECHRECEPS);
                //XtraMessageBox.Show("3");
            };
            //FormClosing += (s, e) =>
            //    {
            //        if (EXP_EXCEL == false)
            //        {
            //            RECEIPTB.OF_Detail_DELETE(ECHRECEPS);
            //            RECEIPTB.OF_DELETE(ECHRECEPS);
            //        }
            //    };
        }

        //void gridView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        //{
        //    if (e.Column.FieldName == "XHL")
        //    {
        //        if (e.IsGetData)
        //            e.Value = stats[e.ListSourceRowIndex];
        //        if (e.IsSetData)
        //            stats[e.ListSourceRowIndex] = int.Parse(e.Value.ToString());
        //    }
        //}

        //Export to CSV
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            EXP_EXCEL = true;
            //Kiem tra xu lý data truoc khi update
            //Kiem tra ECH_RECEP bi trùng
            if (RECEIPTB.F_RECEIPT_Find(ECHRECEPS).Rows.Count <= 0)
            {
                // Save to Receipt
                RECEIPTB.RECEIPT_INSERT(gridView1);

                //Save to Receipt details
                DataTable tmp = RECEIPTB.GridView2DataTable(gridView1);
                RECEIPTB.RECEIPT_Detail_INSERT(tmp);

                for (int i = 0; i < gridView1.DataRowCount; i++)
                {
                    if (i > 0 && int.Parse(gridView1.GetRowCellValue(i, "ECH_RECEP").ToString()) <= int.Parse(gridView1.GetRowCellValue(i - 1, "ECH_RECEP").ToString()))
                        gridView1.SetRowCellValue(i, "ECH_RECEP", int.Parse(gridView1.GetRowCellValue(i - 1, "ECH_RECEP").ToString()) + 1000);
                    if (gridView1.GetRowCellValue(i, "LB_MAT").ToString().Length >= 25)
                        gridView1.SetRowCellValue(i, "LB_MAT", gridView1.GetRowCellValue(i, "LB_MAT").ToString().Substring(0, 24));
                }
                RECEIPTB.F_RECEIPT_DetailsCSV(gridView1);

                MessageBox.Show("RECEIPT : " + ECHRECEPS + " đã nhập vào hệ thống thành công.");
            }
            else
                MessageBox.Show("Lưu ý : RECEIPT số :" + ECHRECEPS + " đã được lưu trước đây.");
            this.Close();
        }

        private void ItemClickEventHandler_COA(object sender, EventArgs e)
        {
        }

        private void CreateUnboundColumn()
        {
            GridColumn col = gridView1.Columns.AddVisible("XHL", "XHL");
            col.UnboundType = DevExpress.Data.UnboundColumnType.Integer;
        }

        //Gan giá trị cho unbound column
        //private void CreateXHL(GridView gr)
        //{
        //XtraMessageBox.Show("run");
        //GridView view = sender as GridView;
        //int k = 0;
        //if (e.Column.FieldName == "XHL" && e.IsGetData)
        //{
        //    e.Value = k;

        //    k = k + 1;
        //}
        //XtraMessageBox.Show("view.DataRowCount : " + view.DataRowCount.ToString());
        //for (int i = 0; i <= view.DataRowCount - 1; i++)
        //{
        //    XtraMessageBox.Show("i : " + i.ToString());
        //    int j = 0;
        //    if (e.Column.FieldName == "XHL" && e.IsGetData)
        //    {
        //        XtraMessageBox.Show("start");
        //        if (i == 0)
        //        {
        //            j = 1;
        //            //gridView1.SetRowCellValue(i, "XHL", j);
        //            e.Value = j;
        //        }
        //        else
        //        {
        //            if (view.GetRowCellValue(i, "CD_MAT").ToString() == view.GetRowCellValue(i - 1, "CD_MAT").ToString())
        //                //gridView1.SetRowCellValue(i, "XHL", j);
        //                e.Value = j;
        //            else
        //            {
        //                j = j + 1;
        //                //gridView1.SetRowCellValue(i, "XHL", j.ToString());
        //                e.Value = j;
        //            }

        //        }
        //        XtraMessageBox.Show("end");
        //    }
        //}

        //}

        //private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        //{
        //    if (e.Column.FieldName == "CD_MAT")
        //    {
        //        for (int i = 0; i <= gridView1.DataRowCount - 1; i++)
        //        {
        //            XtraMessageBox.Show("i : " + i.ToString());
        //            int j = 0;

        //            //XtraMessageBox.Show("start");
        //            if (i == 0)
        //            {
        //                j = 1;
        //                gridView1.SetRowCellValue(i, "XHL", j);
        //                //gridView1.UpdateCurrentRow();
        //                //e.Value = j;
        //            }
        //            else
        //            {
        //                if (gridView1.GetRowCellValue(i, "CD_MAT").ToString() == gridView1.GetRowCellValue(i - 1, "CD_MAT").ToString())
        //                    gridView1.SetRowCellValue(i, "XHL", j);
        //                //e.Value = j;
        //                else
        //                {
        //                    j = j + 1;
        //                    gridView1.SetRowCellValue(i, "XHL", j.ToString());
        //                    //e.Value = j;
        //                }

        //            }
        //            //XtraMessageBox.Show("end");

        //        }
        //    }
        //}
    }
}