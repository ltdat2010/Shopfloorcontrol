﻿using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_CTPT_List : UC_Base
    {
        //Kiem tra xem click chon row tren grid chua
        private bool gridViewRowClick = false;

        private ChiTieuPhanTich CTPT = new ChiTieuPhanTich();
        private ChiTieuPhanTichBUS CTPTBUS = new ChiTieuPhanTichBUS();

        public F_CTPT_List()
        {
            InitializeComponent();
            Load += (s, e) =>
                {
                    // 1 Lấy thông tin user login
                    CTPT.CreatedBy = user.Username;

                    tbl_ChiTieuPhanTichTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_ChiTieuPhanTich);

                    gridControl1.DataSource = tbl_ChiTieuPhanTichTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_ChiTieuPhanTich);

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

        private void ItemClickEventHandler_Add(object sender, EventArgs e)
        {
            isAction = "Add";

            state = MenuState.Insert;
            //Update :  DELEGATE
            // Gọi form Details
            F_CTPT_Details F_LOC_Dtl = new F_CTPT_Details();
            F_LOC_Dtl.isAction = this.isAction;
            F_LOC_Dtl.CTPT = this.CTPT;
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

                // Truyen object LOC to DELEGATE
                F_CTPT_Details F_LOC_Dtl = new Class.F_CTPT_Details();
                F_LOC_Dtl.CTPT = this.CTPT;
                F_LOC_Dtl.isAction = this.isAction;
                F_LOC_Dtl.myFinished += this.finished;
                F_LOC_Dtl.Show();
            }
            else
                XtraMessageBox.Show("Vui lòng click vào dòng cần chỉnh sửa ");
        }

        private void ItemClickEventHandler_Save(object sender, EventArgs e)
        {
            // 27 Gán dữ liệ trên control cho object
            Set4Object();

            // 28 Kiem tra xem co phai là tao moi khong thi insert
            //if (isNew == true)
            if (isAction == "Add")
                CTPTBUS.CTPT_INSERT(CTPT);
            // 29 Khong la tao moi thi update
            else
                CTPTBUS.CTPT_UPDATE(CTPT);

            // 30 Gán du lieu ho datasource cua grid
            gridControl1.DataSource = tbl_ChiTieuPhanTichTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_ChiTieuPhanTich);

            gridView1.BestFitColumns();
            // 31 Tra lai trang thai ban dau cho IsNew
            //isNew = false;
            isAction = "";
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

            // Truyen object LOC to DELEGATE
            F_CTPT_Details F_LOC_Dtl = new Class.F_CTPT_Details();
            F_LOC_Dtl.isAction = this.isAction;
            F_LOC_Dtl.CTPT = this.CTPT;
            F_LOC_Dtl.myFinished += this.finished;
            F_LOC_Dtl.Show();
        }

        private void ItemClickEventHandler_Delete(object sender, EventArgs e)
        {
            // 14 Khai báo state cho các nút khi nhấn nút Del
            state = MenuState.Delete;

            if (gridViewRowClick == true)
            {
                CTPT.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                CTPT.CTPT = gridView1.GetFocusedRowCellValue("CTPT").ToString();

                DialogResult dlDel = XtraMessageBox.Show(" Bạn muốn xóa chỉ tiêu phân tích  : " + CTPT.CTPT + " ? ", "Xóa thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlDel == DialogResult.Yes)
                {
                    CTPTBUS.CTPT_DELETE(CTPT);
                }
                // 18 Load lại datasource cho grid

                gridControl1.DataSource = tbl_ChiTieuPhanTichTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_ChiTieuPhanTich);

                gridView1.BestFitColumns();
                // 17 trả trạng thái cho các nút như ban đầu
                state = MenuState.Full;
            }
            else
                // 16 Xác nhận có muốn xoa không ?
                XtraMessageBox.Show("Vui lòng click vào dòng cần chỉnh sửa ");
        }

        private void ItemClickEventHandler_Close(object sender, EventArgs e)
        {
            this.Close();
        }

        public void Set4Object()
        {
            CTPT.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            CTPT.CTPT = gridView1.GetFocusedRowCellValue("CTPT").ToString();
            CTPT.CTPTDG = gridView1.GetFocusedRowCellValue("CTPTDG").ToString();
            CTPT.Note = gridView1.GetFocusedRowCellValue("Note").ToString();
            CTPT.Locked = gridView1.GetFocusedRowCellValue("Locked").ToString() == "True" ? true : false;
        }

        public void finished(object sender)
        {
            //Dong form DELEGATE
            //var frm = (Form)sender;
            var frm = (DevExpress.XtraEditors.XtraForm)sender;
            frm.Close();

            // Step 2 : Load lại data tren grid sau khi Add
            gridControl1.DataSource = tbl_ChiTieuPhanTichTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_ChiTieuPhanTich);

            gridView1.BestFitColumns();
        }
    }
}