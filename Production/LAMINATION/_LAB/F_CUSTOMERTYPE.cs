using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Globalization;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace Production.Class
{
    public partial class F_CUSTOMERTYPE : UC_Base
    {
        //Kiem tra xem click chon row tren grid chua
        bool gridViewRowClick = false;
        //Object
        CUSTOMERTYPE CUSTPE = new CUSTOMERTYPE();
        //BUS
        CUSTOMERTYPEBUS CUSTPEBUS = new CUSTOMERTYPEBUS();
        public F_CUSTOMERTYPE()
        {       
            
            InitializeComponent();
            Load += (s, e) =>
                {
                    // 1 Lấy thông tin user login
                    CUSTPE.CreatedBy = user.Username;  

                    // 2 Fill data                  
                    tbl_CUSTOMERTYPE_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_CUSTOMERTYPE_LAB);  
                     
                    // 3 Gán controls trạng thái đọc
                    //ControlsReadOnly(true);

                    // 4 Gán datasource cho grid                    
                    gridControl1.DataSource = tbl_CUSTOMERTYPE_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_CUSTOMERTYPE_LAB);        
                                
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

            if(gridViewRowClick == true )
            {
                CUSTPE.CUSTTYPECode = gridView1.GetFocusedRowCellValue("CUSTTYPECode").ToString();

                DialogResult dlDel = XtraMessageBox.Show(" Bạn muốn xóa loại khách hàng : " + CUSTPE.CUSTTYPEName + " ? ", "Xóa thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlDel == DialogResult.Yes)
                {
                    CUSTPEBUS.CUSTOMERTYPE_DELETE(CUSTPE);
                }
                // 18 Load lại datasource cho grid
                gridControl1.DataSource = tbl_CUSTOMERTYPE_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_CUSTOMERTYPE_LAB);
                // 17 trả trạng thái cho các nút như ban đầu
                state = MenuState.Full;
            }
            else
                // 16 Xác nhận có muốn xoa không ?
                XtraMessageBox.Show("Vui lòng click vào dòng cần chỉnh sửa ");      
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
            F_CUSTOMERTYPE_Details F_CUSTPE_Dtl = new Class.F_CUSTOMERTYPE_Details();
            F_CUSTPE_Dtl.isAction = this.isAction;
            F_CUSTPE_Dtl.CUSTPE = this.CUSTPE;
            F_CUSTPE_Dtl.myFinished += this.finished;
            F_CUSTPE_Dtl.Show();
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
            F_CUSTOMERTYPE_Details F_CUSTPE_Dtl = new Class.F_CUSTOMERTYPE_Details();
            F_CUSTPE_Dtl.isAction = this.isAction;
            F_CUSTPE_Dtl.CUSTPE = this.CUSTPE;
            F_CUSTPE_Dtl.myFinished += this.finished;
            F_CUSTPE_Dtl.Show();

            //Gọi sự kiến hoàn tất
            // Step 1 : Đóng form details


            // 19 Khai báo trang thái cho các nut khi nhấn Add New


            // 21 bien isNew gan bang true
            //isNew = true;



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
                F_CUSTOMERTYPE_Details F_CUSTPE_Dtl = new Class.F_CUSTOMERTYPE_Details();
                F_CUSTPE_Dtl.isAction = this.isAction;
                F_CUSTPE_Dtl.CUSTPE = this.CUSTPE;
                F_CUSTPE_Dtl.myFinished += this.finished;
                F_CUSTPE_Dtl.Show();
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
                CUSTPEBUS.CUSTOMERTYPE_INSERT(CUSTPE);
            // 29 Khong la tao moi thi update
            else
                CUSTPEBUS.CUSTOMERTYPE_UPDATE(CUSTPE);

            // 30 Gán du lieu ho datasource cua grid
            gridControl1.DataSource = tbl_CUSTOMERTYPE_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_CUSTOMERTYPE_LAB);

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
            CUSTPE.Id = int.Parse(gridView1.GetFocusedRowCellValue("Id").ToString());
            CUSTPE.CUSTTYPECode = gridView1.GetFocusedRowCellValue("CUSTTYPECode").ToString();
            CUSTPE.CUSTTYPEName = gridView1.GetFocusedRowCellValue("CUSTTYPEName").ToString();
            CUSTPE.Note = gridView1.GetFocusedRowCellValue("Note").ToString();
            CUSTPE.Locked = gridView1.GetFocusedRowCellValue("Locked").ToString() == "True" ? true : false;
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
            gridControl1.DataSource = tbl_CUSTOMERTYPE_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_CUSTOMERTYPE_LAB);            

        }
    }
}
