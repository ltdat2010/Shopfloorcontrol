using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_EMPLOYEE : UC_Base
    {
        //Kiem tra xem click chon row tren grid chua
        private bool gridViewRowClick = false;

        //Object
        private EMPLOYEE EMP = new EMPLOYEE();

        //BUS
        private EMPLOYEEBUS EMPBUS = new EMPLOYEEBUS();

        public F_EMPLOYEE()
        {
            InitializeComponent();
            Load += (s, e) =>
                {
                    /// 1 Lấy thông tin user login
                    EMP.CreatedBy = user.Username;

                    // 2 Fill data
                    tbl_EMPLOYEE_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_EMPLOYEE_LAB);

                    // 3 Gán controls trạng thái đọc
                    //ControlsReadOnly(true);

                    // 4 Gán datasource cho grid
                    gridControl1.DataSource = tbl_EMPLOYEE_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_EMPLOYEE_LAB);

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
                EMP.EMPCode = gridView1.GetFocusedRowCellValue("EMPCode").ToString();

                DialogResult dlDel = XtraMessageBox.Show(" Bạn muốn xóa nhân viên có số điện thoại : " + EMP.EMPCode + " ? ", "Xóa thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlDel == DialogResult.Yes)
                {
                    EMPBUS.EMPLOYEE_DELETE(EMP);
                    XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                    args.AutoCloseOptions.Delay = 3000;
                    args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                    args.DefaultButtonIndex = 0;
                    args.Caption = "Thông báo ";
                    args.Text = "Xóa nhân viên thành công . Thông báo này sẽ tự đóng sau 3 giây.";
                    args.Buttons = new DialogResult[] { DialogResult.OK };
                    XtraMessageBox.Show(args).ToString();
                }
                // 18 Load lại datasource cho grid
                gridControl1.DataSource = tbl_EMPLOYEE_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_EMPLOYEE_LAB);
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
                args.Text = "Vui lòng click vào đầu dòng cần chỉnh sửa . Thông báo này sẽ tự đóng sau 3 giây.";
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
            F_EMPLOYEE_Details F_EMP_Dtl = new F_EMPLOYEE_Details();
            F_EMP_Dtl.isAction = this.isAction;
            F_EMP_Dtl.EMP = this.EMP;
            F_EMP_Dtl.myFinished += this.finished;
            F_EMP_Dtl.Show();
        }

        private void ItemClickEventHandler_Add(object sender, EventArgs e)
        {
            isAction = "Add";

            state = MenuState.Insert;
            //Disable
            this.Enabled = false;
            //
            //Update :  DELEGATE
            // Gọi form Details
            F_EMPLOYEE_Details F_EMP_Dtl = new Class.F_EMPLOYEE_Details();
            F_EMP_Dtl.isAction = this.isAction;
            F_EMP_Dtl.EMP = this.EMP;
            F_EMP_Dtl.myFinished += this.finished;
            F_EMP_Dtl.Show();
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
                F_EMPLOYEE_Details FRM = new F_EMPLOYEE_Details();
                FRM.EMP = this.EMP;
                FRM.isAction = this.isAction;
                FRM.myFinished += this.finished;
                FRM.Show();
            }
            else
            {
                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.AutoCloseOptions.Delay = 3000;
                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                args.DefaultButtonIndex = 0;
                args.Caption = "Lưu ý ";
                args.Text = "Vui lòng click vào đầu dòng cần chỉnh sửa . Thông báo này sẽ tự đóng sau 3 giây.";
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
                EMPBUS.EMPLOYEE_INSERT(EMP);
            // 29 Khong la tao moi thi update
            else
                EMPBUS.EMPLOYEE_UPDATE(EMP);

            // 30 Gán du lieu ho datasource cua grid
            gridControl1.DataSource = tbl_EMPLOYEE_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_EMPLOYEE_LAB);

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
            EMP.Id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
            EMP.EMPCode = gridView1.GetFocusedRowCellValue("EMPCode").ToString();
            EMP.EMPName = gridView1.GetFocusedRowCellValue("EMPName").ToString();
            EMP.EMPMobile = gridView1.GetFocusedRowCellValue("EMPMobile").ToString();
            EMP.EMPEmail = gridView1.GetFocusedRowCellValue("EMPEmail").ToString();
            EMP.Note = gridView1.GetFocusedRowCellValue("Note").ToString();
            EMP.Locked = gridView1.GetFocusedRowCellValue("Locked").ToString() == "True" ? true : false;
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
            gridControl1.DataSource = tbl_EMPLOYEE_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_EMPLOYEE_LAB);
        }
    }
}