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
    public partial class F_KQKN_Template_List : UC_Base
    {
        
        
        KQKN_Template_Header OBJ = new KQKN_Template_Header();
        KQKN_Template_HeaderBUS BUS = new KQKN_Template_HeaderBUS();
       
        public F_KQKN_Template_List()
        {       
            
            InitializeComponent();
            Load += (s, e) =>
                {
                    // 1 Lấy thông tin user login
                    OBJ.CreatedBy = user.Username;

                    tbl_KQKN_Template_HeaderTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_KQKN_Template_Header);
                  
                    gridControl1.DataSource = tbl_KQKN_Template_HeaderTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_KQKN_Template_Header);                    
                    
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
            F_KQKN_Template_Header FRM = new F_KQKN_Template_Header();
            FRM.isAction = this.isAction;
            FRM.OBJ = this.OBJ;
            FRM.myFinished += this.finished;
            FRM.Show();
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
                F_KQKN_Template_Header F_LOC_Dtl = new Class.F_KQKN_Template_Header();
                F_LOC_Dtl.OBJ = this.OBJ;
                F_LOC_Dtl.isAction = this.isAction;
                F_LOC_Dtl.myFinished += this.finished;
                F_LOC_Dtl.Show();
            }
            else
                XtraMessageBox.Show("Vui lòng click vào dòng cần chỉnh sửa ");
        }
        private void ItemClickEventHandler_Save(object sender, EventArgs e)
        {
            
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
            F_KQKN_Template_Header F_LOC_Dtl = new F_KQKN_Template_Header();
            F_LOC_Dtl.isAction = this.isAction;
            F_LOC_Dtl.OBJ = this.OBJ;
            F_LOC_Dtl.myFinished += this.finished;
            F_LOC_Dtl.Show();
        }

        private void ItemClickEventHandler_Delete(object sender, EventArgs e)
        {
            // 14 Khai báo state cho các nút khi nhấn nút Del
            state = MenuState.Delete;

            if (gridViewRowClick == true)
            {
                OBJ.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                OBJ.KQKNTemplate = gridView1.GetFocusedRowCellValue("KQKNTemplate").ToString();

                DialogResult dlDel = XtraMessageBox.Show(" Bạn muốn xóa chỉ tiêu phân tích  : " + OBJ.KQKNTemplate + " ? ", "Xóa thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlDel == DialogResult.Yes)
                {
                    BUS.KQKN_Template_Header_DELETE(OBJ);
                }
                // 18 Load lại datasource cho grid
                
                gridControl1.DataSource = tbl_KQKN_Template_HeaderTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_KQKN_Template_Header);

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
            OBJ.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            OBJ.KQKNTemplate = gridView1.GetFocusedRowCellValue("KQKNTemplate").ToString();
            OBJ.SoMRA = gridView1.GetFocusedRowCellValue("SoMRA").ToString();
            OBJ.Note = gridView1.GetFocusedRowCellValue("Note").ToString();
            OBJ.Locked = gridView1.GetFocusedRowCellValue("Locked").ToString() == "True" ? true : false;
        }

        public void finished(object sender,string isActionReturn)
        {
            //Dong form DELEGATE
            //var frm = (Form)sender;
            var frm = (DevExpress.XtraEditors.XtraForm)sender;
            
            if(isActionReturn == "Edit")
                frm.Close();

            // Step 2 : Load lại daisActionReturnta tren grid sau khi Add
            gridControl1.DataSource = tbl_KQKN_Template_HeaderTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_KQKN_Template_Header);

            gridView1.BestFitColumns();

        }


    }
}
