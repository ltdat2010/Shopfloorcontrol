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
    public partial class F_KQKN_Result_List : UC_Base
    {
        //Kiem tra xem click chon row tren grid chua
        bool gridViewRowClick = false;

        Result_KQKN_TD OBJ = new Result_KQKN_TD();
        //Result_KQKN_KQTT OBJKQTT = new Result_KQKN_KQTT();
        //Result_KQKN_KL OBJKL = new Result_KQKN_KL();

        Result_KQKN_TDBUS BUSTD = new Result_KQKN_TDBUS();
        Result_KQKN_KQTTBUS BUSKQTT = new Result_KQKN_KQTTBUS();
        Result_KQKN_KLBUS BUSKL = new Result_KQKN_KLBUS();

        public F_KQKN_Result_List()
        {       
            
            InitializeComponent();
            Load += (s, e) =>
                {
                    // 1 Lấy thông tin user login
                    OBJ.CreatedBy = user.Username;

                    result_KQKN_ListTableAdapter.Fill(sYNC_NUTRICIELDataSet.Result_KQKN_List);
                  
                    gridControl1.DataSource = result_KQKN_ListTableAdapter.Fill(sYNC_NUTRICIELDataSet.Result_KQKN_List);                    
                    
                    gridView1.BestFitColumns();
                                       
                };
            // 7 Add hoặc New
            action1.Add(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Add));

            // 8 Lưu
            action1.Report(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Report));

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
                Set4Object(gridView1.GetFocusedDataRow());
            };
        }
        private void ItemClickEventHandler_Add(object sender, EventArgs e)
        {
            isAction = "Add";

            state = MenuState.Insert;
            //Update :  DELEGATE
            // Gọi form Details
            F_KQKN_Result_Details FRM = new F_KQKN_Result_Details();
            FRM.isAction = this.isAction;
            FRM.OBJTD = this.OBJ;
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

                // Truyen object LOC to DELEGATE
                F_KQKN_Result_Details F_LOC_Dtl = new F_KQKN_Result_Details();
                F_LOC_Dtl.OBJTD = this.OBJ;
                F_LOC_Dtl.isAction = this.isAction;
                F_LOC_Dtl.myFinished += this.finished;
                F_LOC_Dtl.Show();
            }
            else
                XtraMessageBox.Show("Vui lòng click vào dòng cần chỉnh sửa ");
        }
        private void ItemClickEventHandler_Report(object sender, EventArgs e)
        {
            R_PKN RPKN = new R_PKN();
            RPKN.SoPKN = gridView1.GetFocusedRowCellValue("SoPKN").ToString();
            RPKN.Lan = int.Parse(gridView1.GetFocusedRowCellValue("Lan").ToString());
            RPKN.Show();
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
            //OBJ = BUSTD.Result_KQKN_TD_SELECT(OBJ);
            // Truyen object LOC to DELEGATE
            F_KQKN_Result_Details F_LOC_Dtl = new F_KQKN_Result_Details();
            F_LOC_Dtl.isAction = this.isAction;
            F_LOC_Dtl.OBJTD = this.OBJ;
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
                OBJ.KQKNTemplateID = int.Parse(gridView1.GetFocusedRowCellValue("KQKNTemplateID").ToString());
                OBJ.SoPKN = gridView1.GetFocusedRowCellValue("SoPKN").ToString();

                DialogResult dlDel = XtraMessageBox.Show(" Bạn muốn xóa  : " + OBJ.SoPKN.ToString() + " ? ", "Xóa thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlDel == DialogResult.Yes)
                {
                    
                    BUSTD.Result_KQKN_TD_DELETE(OBJ);

                    BUSKQTT.Result_KQKN_KQTTBUS_DELETE(OBJ);

                    BUSKL.Result_KQKN_KLBUS_DELETE(OBJ);
                }
                // 18 Load lại datasource cho grid
                
                gridControl1.DataSource = result_KQKN_ListTableAdapter.Fill(sYNC_NUTRICIELDataSet.Result_KQKN_List);

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
     
        public void Set4Object(DataRow dr)
        {
            //OBJ.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            //OBJ.SoPKN = gridView1.GetFocusedRowCellValue("SoPKN").ToString();
            //OBJ.KQKNTemplateID = int.Parse(gridView1.GetFocusedRowCellValue("KQKNTemplateID").ToString());
            //OBJ.Note = gridView1.GetFocusedRowCellValue("Note").ToString();
            //OBJ.Locked = gridView1.GetFocusedRowCellValue("Locked").ToString() == "True" ? true : false;                 

            OBJ.ID = int.Parse(dr["ID"].ToString());
            OBJ.SoPKN = dr["SoPKN"].ToString();
            OBJ.SoPNK = dr["SoPNK"].ToString();
            OBJ.TenNL = dr["TenNL"].ToString();
            OBJ.Solo = dr["Solo"].ToString();
            OBJ.SLNhan = dr["SLNhan"].ToString();
            OBJ.QCDG = dr["QCDG"].ToString();
            OBJ.UoM1 = dr["UoM1"].ToString();
            OBJ.UoM2 = dr["UoM2"].ToString();
            OBJ.Note = dr["Note"].ToString();
            OBJ.NgaySX = DateTime.Parse(dr["NgaySX"].ToString());
            OBJ.NgayPT = DateTime.Parse(dr["NgayPT"].ToString());
            OBJ.NgayNhan = DateTime.Parse(dr["NgayNhan"].ToString());
            OBJ.Lan = int.Parse(dr["Lan"].ToString());
            OBJ.KQKNTemplateID = int.Parse(dr["KQKNTemplateID"].ToString());
            OBJ.SoMRA = dr["SoMRA"].ToString();
            OBJ.HSD = DateTime.Parse(dr["HSD"].ToString());
        }

        public void finished(object sender,string isActionReturn)
        {
            //Dong form DELEGATE
            //var frm = (Form)sender;
            var frm = (DevExpress.XtraEditors.XtraForm)sender;
            
            if(isActionReturn == "Edit")
                frm.Close();

            // Step 2 : Load lại daisActionReturnta tren grid sau khi Add
            gridControl1.DataSource = result_KQKN_ListTableAdapter.Fill(sYNC_NUTRICIELDataSet.Result_KQKN_List);

            gridView1.BestFitColumns();

        }


    }
}
