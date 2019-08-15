using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_MYCOTOXIN_ConC : UC_Base
    {
        //Kiem tra xem click chon row tren grid chua
        private bool gridViewRowClick = false;

        private string filePath = @"D:\NongDo_COnC_ng_per_ml_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";

        //Object
        private MYCOTOXIN_ConC CUS = new MYCOTOXIN_ConC();

        //BUS
        private MYCOTOXIN_ConCBUS CUSBUS = new MYCOTOXIN_ConCBUS();

        public F_MYCOTOXIN_ConC()
        {
            InitializeComponent();
            Load += (s, e) =>
                {
                    /// 1 Lấy thông tin user login
                    CUS.CreatedBy = user.Username;

                    // 2 Fill data
                    tbl_MYCOTOXIN_ConCTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_MYCOTOXIN_ConC);

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
        }

        private void ItemClickEventHandler_Report(object sender, EventArgs e)
        {
            gridView1.ExportToXlsx(filePath);
            System.Diagnostics.Process.Start(filePath);
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

                DialogResult dlDel = XtraMessageBox.Show(" Bạn muốn xóa khách hàng mã : " + CUS.ID.ToString() + " ? ", "Xóa thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlDel == DialogResult.Yes)
                {
                    try
                    {
                        CUSBUS.MYCOTOXIN_ConC_DELETE(CUS);
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
                gridControl1.DataSource = tbl_MYCOTOXIN_ConCTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_MYCOTOXIN_ConC);
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
            F_MYCOTOXIN_ConC_Details F_CUS_Dtl = new F_MYCOTOXIN_ConC_Details();
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
            F_MYCOTOXIN_ConC_Details F_CUS_Dtl = new Class.F_MYCOTOXIN_ConC_Details();
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
                F_MYCOTOXIN_ConC_Details F_CUS_Dtl = new Class.F_MYCOTOXIN_ConC_Details();
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
                CUSBUS.MYCOTOXIN_ConC_INSERT(CUS);
            // 29 Khong la tao moi thi update
            else
                CUSBUS.MYCOTOXIN_ConC_UPDATE(CUS);

            // 30 Gán du lieu ho datasource cua grid
            gridControl1.DataSource = tbl_MYCOTOXIN_ConCTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_MYCOTOXIN_ConC);

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
            CUS.CTXN_ID = int.Parse(gridView1.GetFocusedRowCellValue("CTXN_ID").ToString());
            CUS.ConC = double.Parse(gridView1.GetFocusedRowCellValue("ConC").ToString());
            CUS.KHMau = gridView1.GetFocusedRowCellValue("KHMau").ToString();
            CUS.Note = gridView1.GetFocusedRowCellValue("Note").ToString();
            //MessageBox.Show(gridView1.GetFocusedRowCellValue("Locked").ToString());
            CUS.Locked = gridView1.GetFocusedRowCellValue("Locked").ToString() == "True" ? true : false;
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
            gridControl1.DataSource = tbl_MYCOTOXIN_ConCTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_MYCOTOXIN_ConC);
        }
    }
}