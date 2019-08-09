﻿using System;
using System.Windows.Forms;
using System.Globalization;
using DevExpress.XtraEditors;
using System.Net.Mail;
using System.Data;
using System.Collections;

namespace Production.Class
{
    public partial class F_PTU_List : UC_Base
    {
        //Kiem tra xem click chon row tren grid chua
        bool gridViewRowClick = false;

        PTU_Header OBJ = new PTU_Header();

        PTU_Header_BUS BUS = new PTU_Header_BUS();

        PTU_Header PTUH_OBJ = new PTU_Header();
        PTU_Lines PTUL_OBJ = new PTU_Lines();

        /// <summary>
        /// DELEGATE
        /// </summary>        
        public delegate void MyAdd(object sender, string isActionReturn);
        public event MyAdd myFinished;

        public bool Is_close
        {
            set
            {
                if (value)
                {
                    if (myFinished != null) myFinished(sender: this, isActionReturn: isAction);
                }
            }
        }
        public F_PTU_List()
        {       
            
            InitializeComponent();
            Load += (s, e) =>
                {
                    //btnGiaoMau.Enabled = false;
                    // 1 Lấy thông tin user login
                    OBJ.CreatedBy = user.Username;

                    tbl_PTU_Header_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_PTU_Header_LAB);
                  
                    gridControl1.DataSource = tbl_PTU_Header_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_PTU_Header_LAB);                    
                    
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

            // 10a Report
            action1.Report(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Report));

            // 10B Cancel
            action1.Close(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Close));

            // 10C Excel
            action1.Excel(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Excel));

            gridView1.RowClick += (s, e) =>
            {
                if (!gridView1.IsGroupRow(gridView1.FocusedRowHandle))
                {
                    gridViewRowClick = true;
                    Set4Object();
                }
                //if ((bool)gridView1.GetFocusedRowCellValue("BanGiaoMauStatus") == false)
                    //btnGiaoMau.Enabled = true;
            };                    


                //btnGiaoMau.Click += (s, e) =>
                //{
                //    if (gridViewRowClick == true)
                //    {
                //        //Disable
                //        this.Enabled = false;
                //        //
                //        R_PGM_LAB FRM = new Class.R_PGM_LAB();
                //        FRM.OBJ = this.OBJ;
                //        FRM.Show();
                //    }
                //    else
                //        XtraMessageBox.Show("Vui lòng click vào đầu dòng cần giao mẫu ");
                //};
            }
        
        private void ItemClickEventHandler_Excel(object sender, EventArgs e)
        {
            string filePath = @"D:\PNM_Created_"+DateTime.Now.ToShortDateString().Replace("/","_")+".xlsx";
            gridView1.ExportToXlsx(filePath);
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
            F_PTU_LAB_Details FRM = new F_PTU_LAB_Details();
            FRM.isAction = this.isAction;
            //F_LOC_Dtl.OBJ = this.OBJ;
            FRM.myFinished += this.finished ;
            FRM.Show();
        }

        private void ItemClickEventHandler_Edit(object sender, EventArgs e)
        {
            if (!gridView1.IsGroupRow(gridView1.FocusedRowHandle))
            {
                // 25 isEditting gan bang true 
                //isEditting = true;
                isAction = "Edit";

                state = MenuState.Update;

                if (gridViewRowClick == true)
                {
                    Set4Object();

                    // Truyen object LOC to DELEGATE
                    //Disable
                    this.Enabled = false;
                    //XtraMessageBox.Show("Started form");
                    //
                    F_PTU_LAB_Details FRM = new F_PTU_LAB_Details();
                    FRM.OBJ_PTUH = this.OBJ;
                    //XtraMessageBox.Show("After set object");
                    FRM.isAction = this.isAction;
                    FRM.myFinished += this.finished;
                    FRM.Show();
                    //XtraMessageBox.Show("Showed");
                }

                else
                    XtraMessageBox.Show("Vui lòng click vào đầu dòng cần chỉnh sửa ");
            }
                
        }

        private void ItemClickEventHandler_Save(object sender, EventArgs e)
        {
            // 27 Gán dữ liệ trên control cho object
            Set4Object();

            // 28 Kiem tra xem co phai là tao moi khong thi insert
            //if (isNew == true)
            if (isAction == "Add")
                BUS.PTU_Header_INSERT(OBJ);
            // 29 Khong la tao moi thi update
            else
                BUS.PTU_Header_UPDATE(OBJ);

            // 30 Gán du lieu ho datasource cua grid
            gridControl1.DataSource = tbl_PTU_Header_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_PTU_Header_LAB);            

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

            //Truyen object LOC to DELEGATE
            //Disable
            this.Enabled = false;
            //
            F_PTU_LAB_Details FRM = new F_PTU_LAB_Details();
            FRM.isAction = this.isAction;
            FRM.OBJ_PTUH = this.OBJ;
            FRM.myFinished += this.finished;
            FRM.Show();
        }
        private void ItemClickEventHandler_Report(object sender, EventArgs e)
        {
            //if (!gridView1.IsGroupRow(((DevExpress.XtraGrid.Views.Base.ColumnView)(sender)).FocusedRowHandle))
            if (!gridView1.IsGroupRow(gridView1.FocusedRowHandle))
            {

                if (gridViewRowClick == true)
                {
                    //Disable
                    this.Enabled = false;
                    //
                    R_PTU_LAB FRM = new R_PTU_LAB();
                    FRM.OBJ = this.OBJ;
                    FRM.myFinished += this.finished;
                    FRM.Show();
                }
                else
                    XtraMessageBox.Show("Vui lòng click vào đầu dòng cần chỉnh sửa ");
            }
        }


        private void ItemClickEventHandler_Delete(object sender, EventArgs e)
        {
            // 14 Khai báo state cho các nút khi nhấn nút Del
            state = MenuState.Delete;

            if (gridViewRowClick == true)
            {
                OBJ.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                OBJ.SoPTU = gridView1.GetFocusedRowCellValue("SoPTU").ToString();

                DialogResult dlDel = XtraMessageBox.Show(" Bạn muốn xóa phiếu xét nghiệm số : " + OBJ.SoPTU + " ?. Lưu ý là tất cả thông tin bao gồm cả kết quả, liên quan đến phiếu xét nghiệm này sẽ bị xóa. Bạn chắc chắn vẫn muốn xóa ? ", "Xóa thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlDel == DialogResult.Yes)
                {             
                    BUS.PTU_Header_DELETE(OBJ.ID);                  
                }
                // 18 Load lại datasource cho grid
                
                gridControl1.DataSource = tbl_PTU_Header_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_PTU_Header_LAB);

                gridView1.BestFitColumns();
                // 17 trả trạng thái cho các nút như ban đầu
                state = MenuState.Full;
            }
            else
                // 16 Xác nhận có muốn xoa không ?
                XtraMessageBox.Show("Vui lòng click vào đầu dòng cần chỉnh sửa ");
        }

        private void ItemClickEventHandler_Close(object sender, EventArgs e)
        {
            this.Close();
        }
     
        public void Set4Object()
        {
            OBJ.ID                  = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            OBJ.SoPTU               = gridView1.GetFocusedRowCellValue("SoPTU").ToString();
            OBJ.NgayTamUng          = DateTime.Parse(gridView1.GetFocusedRowCellValue("NgayTamUng").ToString(), CultureInfo.CreateSpecificCulture("en-GB"));
            OBJ.NgayLapPhieu        = DateTime.Parse(gridView1.GetFocusedRowCellValue("NgayLapPhieu").ToString(), CultureInfo.CreateSpecificCulture("en-GB"));
            OBJ.PaymentTerm         = gridView1.GetFocusedRowCellValue("PaymentTerm").ToString();
            OBJ.VENDCode            = gridView1.GetFocusedRowCellValue("VENDCode").ToString();
            OBJ.VENDName            = gridView1.GetFocusedRowCellValue("VENDName").ToString();
            OBJ.NoiDung             = gridView1.GetFocusedRowCellValue("NoiDung").ToString();            
            OBJ.Locked              = gridView1.GetFocusedRowCellValue("Locked").ToString() == "True" ? true : false;
            OBJ.Note                = gridView1.GetFocusedRowCellValue("Note").ToString();
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
            gridControl1.DataSource = tbl_PTU_Header_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_PTU_Header_LAB);

            gridView1.BestFitColumns();

        }


    }
}
