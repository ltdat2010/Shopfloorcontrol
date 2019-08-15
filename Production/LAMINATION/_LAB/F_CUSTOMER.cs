using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_CUSTOMER : UC_Base
    {
        //Kiem tra xem click chon row tren grid chua
        private bool gridViewRowClick = false;

        //Object
        private CUSTOMER CUS = new CUSTOMER();

        //BUS
        private CUSTOMERBUS CUSBUS = new CUSTOMERBUS();

        public F_CUSTOMER()
        {
            InitializeComponent();
            Load += (s, e) =>
                {
                    /// 1 Lấy thông tin user login
                    CUS.CreatedBy = user.Username;

                    // 2 Fill data
                    grid_CUSTOMER_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.Grid_CUSTOMER_LAB);

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

            gridView1.RowClick += (s, e) =>
                {
                    gridViewRowClick = true;
                };
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
                CUS.CUSTCODE = gridView1.GetFocusedRowCellValue("CUSTCODE").ToString();

                DialogResult dlDel = XtraMessageBox.Show(" Bạn muốn xóa khách hàng mã : " + CUS.CUSTCODE + " ? ", "Xóa thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlDel == DialogResult.Yes)
                {
                    CUSBUS.CUSTOMER_DELETE(CUS);
                    XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                    args.AutoCloseOptions.Delay = 3000;
                    args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                    args.DefaultButtonIndex = 0;
                    args.Caption = "Thông báo ";
                    args.Text = "Xóa thành công. Thông báo này sẽ tự đóng sau 3 giây.";
                    args.Buttons = new DialogResult[] { DialogResult.OK };
                    XtraMessageBox.Show(args).ToString();
                }
                // 18 Load lại datasource cho grid
                gridControl1.DataSource = grid_CUSTOMER_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.Grid_CUSTOMER_LAB);
                // 17 trả trạng thái cho các nút như ban đầu
                state = MenuState.Full;
            }
            else
            // 16 Xác nhận có muốn xoa không ?
            {
                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.AutoCloseOptions.Delay = 3000;
                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                args.DefaultButtonIndex = 0;
                args.Caption = "Lưu ý ";
                args.Text = "Vui lòng click vào dòng cần chỉnh sửa . Thông báo này sẽ tự đóng sau 3 giây.";
                args.Buttons = new DialogResult[] { DialogResult.OK };
                XtraMessageBox.Show(args).ToString();
            }
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
            //
            // Truyen object LOC to DELEGATE
            F_CUSTOMER_Details F_CUS_Dtl = new F_CUSTOMER_Details();
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
            F_CUSTOMER_Details F_CUS_Dtl = new Class.F_CUSTOMER_Details();
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
                F_CUSTOMER_Details F_CUS_Dtl = new Class.F_CUSTOMER_Details();
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
                args.Text = "Vui lòng click vào dòng cần chỉnh sửa . Thông báo này sẽ tự đóng sau 3 giây.";
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
                CUSBUS.CUSTOMER_INSERT(CUS);
            // 29 Khong la tao moi thi update
            else
                CUSBUS.CUSTOMER_UPDATE(CUS);

            // 30 Gán du lieu ho datasource cua grid
            gridControl1.DataSource = grid_CUSTOMER_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.Grid_CUSTOMER_LAB);

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
            CUS.CUSTCODE = gridView1.GetFocusedRowCellValue("CUSTCODE").ToString();
            CUS.CUSTNAME = gridView1.GetFocusedRowCellValue("CUSTNAME").ToString();
            CUS.EMPCode = gridView1.GetFocusedRowCellValue("EMPCode").ToString();
            CUS.CUSTTYPECode = gridView1.GetFocusedRowCellValue("CUSTTYPECode").ToString();
            CUS.Note = gridView1.GetFocusedRowCellValue("Note").ToString();
            CUS.ContactName = gridView1.GetFocusedRowCellValue("ContactName").ToString();
            CUS.ContactNumber = gridView1.GetFocusedRowCellValue("ContactNumber").ToString();
            CUS.CUSTADDRESS = gridView1.GetFocusedRowCellValue("CUSTADDRESS").ToString();
            CUS.TaxCode = gridView1.GetFocusedRowCellValue("TaxCode").ToString();
            CUS.Locked = gridView1.GetFocusedRowCellValue("Locked").ToString() == "True" ? true : false;
            CUS.ContactEmail = gridView1.GetFocusedRowCellValue("ContactEmail").ToString();
            CUS.LOCCode = gridView1.GetFocusedRowCellValue("LOCCode").ToString();
            CUS.ContactNumber = gridView1.GetFocusedRowCellValue("ContactNumber").ToString();
            CUS.ProvinceName = gridView1.GetFocusedRowCellValue("ProvinceName").ToString();
        }

        public void finished(object sender)
        {
            this.Enabled = true;
            //Dong form DELEGATE
            //var frm = (Form)sender;
            var frm = (DevExpress.XtraEditors.XtraForm)sender;
            frm.Close();

            // Step 2 : Load lại data tren grid sau khi Add
            gridControl1.DataSource = grid_CUSTOMER_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.Grid_CUSTOMER_LAB);
        }
    }
}