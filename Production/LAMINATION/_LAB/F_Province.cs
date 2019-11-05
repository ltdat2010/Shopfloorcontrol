using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_Province : UC_Base
    {
        //Kiem tra xem click chon row tren grid chua
        private bool gridViewRowClick = false;

        //Object
        private Province LOC = new Province();

        //BUS
        private ProvinceBUS LOCBUS = new ProvinceBUS();

        public F_Province()
        {
            InitializeComponent();
            Load += (s, e) =>
                {
                    // 1 Lấy thông tin user login
                    LOC.CreatedBy = user.Username;

                    // 2 Fill data
                    //tbl_ProvinceTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_Province);

                    // 3 Gán controls trạng thái đọc
                    //ControlsReadOnly(true);

                    // 4 Gán datasource cho grid
                    gridControl1.DataSource = tbl_ProvinceTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_Province);

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
                LOC.ProvinceCode = gridView1.GetFocusedRowCellValue("LOCCode").ToString();

                DialogResult dlDel = XtraMessageBox.Show(" Bạn muốn xóa khu vực mã : " + LOC.ProvinceCode + " ? ", "Xóa thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlDel == DialogResult.Yes)
                {
                    LOCBUS.Province_DELETE(LOC);
                    XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                    args.AutoCloseOptions.Delay = 3000;
                    args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                    args.DefaultButtonIndex = 0;
                    args.Caption = "Thông báo ";
                    args.Text = "Xóa thành công . Thông báo này sẽ tự đóng sau 3 giây.";
                    args.Buttons = new DialogResult[] { DialogResult.OK };
                    XtraMessageBox.Show(args).ToString();
                }
                // 18 Load lại datasource cho grid
                gridControl1.DataSource = tbl_ProvinceTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_Province);
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
            F_Province_Details F_LOC_Dtl = new Class.F_Province_Details();
            F_LOC_Dtl.isAction = this.isAction;
            F_LOC_Dtl.LOC = this.LOC;
            F_LOC_Dtl.myFinished += this.finished;
            F_LOC_Dtl.Show();
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
            F_Province_Details F_LOC_Dtl = new Class.F_Province_Details();
            F_LOC_Dtl.isAction = this.isAction;
            F_LOC_Dtl.LOC = this.LOC;
            F_LOC_Dtl.myFinished += this.finished;
            F_LOC_Dtl.Show();
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
                F_Province_Details F_LOC_Dtl = new Class.F_Province_Details();
                F_LOC_Dtl.LOC = this.LOC;
                F_LOC_Dtl.isAction = this.isAction;
                F_LOC_Dtl.myFinished += this.finished;
                F_LOC_Dtl.Show();
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
                LOCBUS.Province_INSERT(LOC);
            // 29 Khong la tao moi thi update
            else
                LOCBUS.Province_UPDATE(LOC);

            // 30 Gán du lieu ho datasource cua grid
            gridControl1.DataSource = tbl_ProvinceTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_Province);

            // 31 Tra lai trang thai ban dau cho IsNew
            //isNew = false;
            isAction = "";
        }

        //
        public void Set4Object()
        {
            LOC.Id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
            LOC.LOCId = int.Parse(gridView1.GetFocusedRowCellValue("LOCId").ToString());
            LOC.ProvinceCode = gridView1.GetFocusedRowCellValue("ProvinceCode").ToString();
            LOC.ProvinceName = gridView1.GetFocusedRowCellValue("ProvinceName").ToString();
            LOC.Note = gridView1.GetFocusedRowCellValue("Note").ToString();
            LOC.Locked = gridView1.GetFocusedRowCellValue("Locked").ToString() == "True" ? true : false;
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
            gridControl1.DataSource = tbl_ProvinceTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_Province);
        }
    }
}