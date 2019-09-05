using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using System;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_CHITIEUXETNGHIEM : UC_Base
    {
        //Kiem tra xem click chon row tren grid chua
        private bool gridViewRowClick = false;

        private string filePath = @"D:\ChiTieuXetNghiem_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";

        private string filePath_Upload = @"D:\ChiTieuXetNghiem_Upload_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";

        //Object
        private CHITIEUXETNGHIEM CUS = new CHITIEUXETNGHIEM();

        //BUS
        private CHITIEUXETNGHIEMBUS CUSBUS = new CHITIEUXETNGHIEMBUS();

        public F_CHITIEUXETNGHIEM()
        {
            InitializeComponent();
            Load += (s, e) =>
                {
                    /// 1 Lấy thông tin user login
                    CUS.CreatedBy = user.Username;

                    // 2 Fill data
                    tbl_ChiTieuXetNghiem_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_ChiTieuXetNghiem_LAB);

                    // 3 Gán controls trạng thái đọc
                    //ControlsReadOnly(true);

                    // 4 Gán datasource cho grid
                    //gridControl1.DataSource = grid_CUSTOMERTableAdapter.Fill(sYNC_NUTRICIELDataSet.Grid_CUSTOMER);

                    // 5 Để grid tự canh chỉnh cột
                    gridView1.BestFitColumns();
                };
            // 7 Add hoặc New
            action1.Add(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Add));

            // 8 Lưu
            action1.Save(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Save));

            // 9 Edit hoặc Update
            action1.Edit(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Edit));

            // 10 Del
            action1.Delete(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Delete));

            // 10a View
            action1.View(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_View));

            // 10B Cancel
            action1.Close(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Close));

            action1.Report(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Report));

            gridView1.RowClick += (s, e) =>
            {
                gridViewRowClick = true;
            };
            btnUpload.Click += (s, e) =>
            {
                //XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                //args.AutoCloseOptions.Delay = 10000;
                //args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                //args.DefaultButtonIndex = 0;
                //args.Caption = "Thông tin ";
                //args.Text = "Lưu thành công . Thông báo này sẽ tự đóng sau 10 giây.";
                //args.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Cancel };
                //XtraMessageBox.Show(args).ToString();
                //args.Showing += Args_Showing;
                System.Data.DataTable dt = new System.Data.DataTable();

                dt = ImportExceltoDatatable(filePath_Upload, "Sheet");

                Sql.ExecuteNonQuery(
                    "SAP",
                    "SP_tbl_ChiTieuXetNghiem_LAB_TYPE",
                    CommandType.StoredProcedure,
                    "@tableTYPE",
                    dt
                    );

                //Is_close = true;
            };
        }

        public System.Data.DataTable ImportExceltoDatatable(string filepath, string sheetname)
        {
            // string sqlquery= "Select * From [SheetName$] Where YourCondition";
            //string sqlquery = "Select * From [SheetName$] Where Id='ID_007'";
            string sqlquery = "Select * From [" + sheetname + "$]";
            DataSet ds = new DataSet();
            string constring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=\"Excel 12.0;HDR=YES;\"";
            OleDbConnection con = new OleDbConnection(constring + "");
            OleDbDataAdapter da = new OleDbDataAdapter(sqlquery, con);
            da.Fill(ds);
            System.Data.DataTable dt = ds.Tables[0];
            return dt;
        }

        private void ItemClickEventHandler_Report(object sender, EventArgs e)
        {
            //Export to excel -report xlsx
            //gridView1.ExportToXlsx(filePath);
            System.Diagnostics.Process.Start(filePath);

            //Tra về indent khi user them dong moi vo file excel
            txtIdentity.Text = CUSBUS.CTXN_INDENTITY_SELECT().ToString();

            //Export to excel for update
            //string filePath = @"D:\PriceList_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
            //Save current layout
            gridView1.SaveLayoutToXml(@"D:\tempLayout.xml");
            //Set to visible all column

            foreach (GridColumn column in gridView1.Columns)
            {
                if (column.Name == "colID")
                {
                    column.VisibleIndex = 0;
                    column.Visible = true;
                }
                else if (column.Name == "colMaCTXN")
                {
                    column.VisibleIndex = 1;
                    column.Visible = true;
                }
                else if (column.Name == "colCTXN")
                {
                    column.VisibleIndex = 2;
                    column.Visible = true;
                }
                else if (column.Name == "colCTXNDG")
                {
                    column.VisibleIndex = 3;
                    column.Visible = true;
                }
                else if (column.Name == "colCTXNDGTA")
                {
                    column.VisibleIndex = 4;
                    column.Visible = true;
                }
                else if (column.Name == "colPPXNID")
                {
                    column.VisibleIndex = 5;
                    column.Visible = true;
                }
                //else if (column.Name == "colMinValue")
                //{
                //    column.VisibleIndex = 6;
                //    column.Visible = true;
                //}
                //else if (column.Name == "colMaxValue")
                //{
                //    column.VisibleIndex = 7;
                //    column.Visible = true;
                //}
                //else if (column.Name == "colUnitValue")
                //{
                //    column.VisibleIndex = 8;
                //    column.Visible = true;
                //}
                else if (column.Name == "colNCTXNID")
                {
                    column.VisibleIndex = 6;
                    column.Visible = true;
                }
                else if (column.Name == "colDays")
                {
                    column.VisibleIndex = 7;
                    column.Visible = true;
                }
                else if (column.Name == "colAcronym")
                {
                    column.VisibleIndex = 8;
                    column.Visible = true;
                }
                //else if (column.Name == "colCreatedDate")
                //{
                //    column.VisibleIndex = 12;
                //    column.Visible = true;
                //}
                //else if (column.Name == "colCreatedBy")
                //{
                //    column.VisibleIndex = 13;
                //    column.Visible = true;
                //}
                //else if (column.Name == "colLocked")
                //{
                //    column.VisibleIndex = 14;
                //    column.Visible = true;
                //}
                //else if (column.Name == "colNote")
                //{
                //    column.VisibleIndex = 15;
                //    column.Visible = true;
                //}
                else
                    column.Visible = false;
            }
            //Export
            gridView1.ExportToXlsx(filePath_Upload);

            //Restore layout
            gridView1.RestoreLayoutFromXml(@"D:\tempLayout.xml");

            System.Diagnostics.Process.Start(filePath_Upload);
        }

        private void ItemClickEventHandler_Close(object sender, EventArgs e)
        {
            this.Close();
        }

        // Sự kiện xóa
        private void ItemClickEventHandler_Delete(object sender, EventArgs e)
        {
            // 14 Khai báo state cho các nút khi nhấn nút Del
            state = MenuState.Delete;

            if (gridViewRowClick == true)
            {
                CUS.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                CUS.CTXN = gridView1.GetFocusedRowCellValue("CTXN").ToString();

                DialogResult dlDel = XtraMessageBox.Show(" Bạn muốn xóa khách hàng mã : " + CUS.CTXN + " ? ", "Xóa thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlDel == DialogResult.Yes)
                {
                    try
                    {
                        CUSBUS.CHITIEUXETNGHIEM_DELETE(CUS);
                        XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                        args.AutoCloseOptions.Delay = 3000;
                        args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                        args.DefaultButtonIndex = 0;
                        args.Caption = "Thông báo ";
                        args.Text = "Xóa thành công. Thông báo này sẽ tự đóng sau 3 giây.";
                        args.Buttons = new DialogResult[] { DialogResult.OK };
                        XtraMessageBox.Show(args).ToString();
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
                // 18 Load lại datasource cho grid
                gridControl1.DataSource = tbl_ChiTieuXetNghiem_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_ChiTieuXetNghiem_LAB);
                // 17 trả trạng thái cho các nút như ban đầu
                state = MenuState.Full;
            }
            else
            {
                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.AutoCloseOptions.Delay = 3000;
                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                args.DefaultButtonIndex = 0;
                args.Caption = "Lưu ý ";
                args.Text = "Vui lòng click vào dòng cần chỉnh sửa. Thông báo này sẽ tự đóng sau 3 giây.";
                args.Buttons = new DialogResult[] { DialogResult.OK };
                XtraMessageBox.Show(args).ToString();
            }
            // 16 Xác nhận có muốn xoa không ?
        }

        private void ItemClickEventHandler_View(object sender, EventArgs e)
        {
            // 23 Gán state UPdate cho tat ca cac nut
            state = MenuState.Update;

            //24  Edit hoặc update nên  isNew gán bằng false
            //isNew = false;

            // 25 isEditting gan bang true
            //isEditting = true;
            isAction = "View";

            // 26 COntrols gỡ bỏ trạng thái đọc cho phép nhập liệu
            //ControlsReadOnly(false);
            //Disable
            this.Enabled = false;
            // Truyen object LOC to DELEGATE
            F_CHITIEUXETNGHIEM_Details F_CUS_Dtl = new F_CHITIEUXETNGHIEM_Details();
            F_CUS_Dtl.isAction = this.isAction;
            F_CUS_Dtl.CUS = this.CUS;
            F_CUS_Dtl.myFinished += this.finished;
            F_CUS_Dtl.Show();
        }

        private void ItemClickEventHandler_Add(object sender, EventArgs e)
        {
            isAction = "Add";

            state = MenuState.Insert;
            //Update :  DELEGATE
            // Gọi form Details
            //Disable
            this.Enabled = false;
            //
            F_CHITIEUXETNGHIEM_Details F_CUS_Dtl = new Class.F_CHITIEUXETNGHIEM_Details();
            F_CUS_Dtl.isAction = this.isAction;
            F_CUS_Dtl.CUS = this.CUS;
            F_CUS_Dtl.myFinished += this.finished;
            F_CUS_Dtl.Show();
        }

        private void ItemClickEventHandler_Edit(object sender, EventArgs e)
        {
            // 25 isEditting gan bang true
            //isEditting = true;
            isAction = "Edit";

            state = MenuState.Update;

            if (gridViewRowClick == true)
            {
                Set4Object();
                //Disable
                this.Enabled = false;
                //
                // Truyen object LOC to DELEGATE
                F_CHITIEUXETNGHIEM_Details F_CUS_Dtl = new Class.F_CHITIEUXETNGHIEM_Details();
                F_CUS_Dtl.CUS = this.CUS;
                F_CUS_Dtl.isAction = this.isAction;
                F_CUS_Dtl.myFinished += this.finished;
                F_CUS_Dtl.Show();
            }
            else
            {
                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.AutoCloseOptions.Delay = 3000;
                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                args.DefaultButtonIndex = 0;
                args.Caption = "Lưu ý ";
                args.Text = "Vui lòng click vào dòng cần chỉnh sửa. Thông báo này sẽ tự đóng sau 3 giây.";
                args.Buttons = new DialogResult[] { DialogResult.OK };
                XtraMessageBox.Show(args).ToString();
            }
        }

        private void ItemClickEventHandler_Save(object sender, EventArgs e)
        {
            // 27 Gán dữ liệ trên control cho object
            Set4Object();

            // 28 Kiem tra xem co phai là tao moi khong thi insert
            //if (isNew == true)
            if (isAction == "Add")
                CUSBUS.CHITIEUXETNGHIEM_INSERT(CUS);
            // 29 Khong la tao moi thi update
            else
                CUSBUS.CHITIEUXETNGHIEM_UPDATE(CUS);

            // 30 Gán du lieu ho datasource cua grid
            gridControl1.DataSource = tbl_ChiTieuXetNghiem_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_ChiTieuXetNghiem_LAB);

            // 31 Tra lai trang thai ban dau cho IsNew
            //isNew = false;
            isAction = "";

            // 32 Khoa cac cotrol sau khi luu
            //ControlsReadOnly(true);

            // 33 Xoa noi dung trong cac control
            //ResetControl();
        }

        //
        public void Set4Object()
        {
            //CUS.Id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
            CUS.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            CUS.MaCTXN = gridView1.GetFocusedRowCellValue("MaCTXN").ToString();
            CUS.CTXN = gridView1.GetFocusedRowCellValue("CTXN").ToString();
            CUS.CTXNDG = gridView1.GetFocusedRowCellValue("CTXNDG").ToString();
            CUS.CTXNDGTA = gridView1.GetFocusedRowCellValue("CTXNDGTA").ToString();
            CUS.Note = gridView1.GetFocusedRowCellValue("Note").ToString();
            CUS.MaxValue = gridView1.GetFocusedRowCellValue("MaxValue").ToString();
            CUS.MinValue = gridView1.GetFocusedRowCellValue("MinValue").ToString();
            CUS.NCTXNID = int.Parse(gridView1.GetFocusedRowCellValue("NCTXNID").ToString());
            CUS.PPXNID = int.Parse(gridView1.GetFocusedRowCellValue("PPXNID").ToString());
            //MessageBox.Show(gridView1.GetFocusedRowCellValue("Locked").ToString());
            CUS.Locked = gridView1.GetFocusedRowCellValue("Locked").ToString() == "True" ? true : false;
            CUS.UnitValue = gridView1.GetFocusedRowCellValue("UnitValue").ToString();
            CUS.CreatedBy = gridView1.GetFocusedRowCellValue("CreatedBy").ToString();
        }

        public void finished(object sender)
        {
            //Disable
            this.Enabled = true;
            //
            //Dong form DELEGATE
            //var frm = (Form)sender;
            var frm = (DevExpress.XtraEditors.XtraForm)sender;
            frm.Close();

            // Step 2 : Load lại data tren grid sau khi Add
            gridControl1.DataSource = tbl_ChiTieuXetNghiem_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_ChiTieuXetNghiem_LAB);
        }
    }
}