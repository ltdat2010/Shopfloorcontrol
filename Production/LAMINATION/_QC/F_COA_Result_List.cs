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
    public partial class F_COA_Result_List : UC_Base
    {
        Result_COA_TD OBJ = new Result_COA_TD();
        //Result_KQKN_KQTT OBJKQTT = new Result_KQKN_KQTT();
        //Result_KQKN_KL OBJKL = new Result_KQKN_KL();

        Result_COA_TDBUS BUSTD = new Result_COA_TDBUS();
        Result_COA_KQBUS BUSKQ = new Result_COA_KQBUS();
        //Result_KQKN_KLBUS BUSKL = new Result_KQKN_KLBUS();

        public F_COA_Result_List()
        {       
            
            InitializeComponent();
            Load += (s, e) =>
                {
                    // 1 Lấy thông tin user login
                    OBJ.CreatedBy = user.Username;

                    tbl_Result_COA_TDTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_Result_COA_TD);
                  
                    //gridControl1.DataSource = result_KQKN_ListTableAdapter.Fill(sYNC_NUTRICIELDataSet.Result_KQKN_List);                    
                    
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
            F_COA_Result_Details FRM = new F_COA_Result_Details();
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
                F_COA_Result_Details F_LOC_Dtl = new F_COA_Result_Details();
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
            R_COA_SelectLanguage RPKN = new R_COA_SelectLanguage();
            RPKN.SoCOA = gridView1.GetFocusedRowCellValue("SoCOA").ToString();
            //RPKN.Lan = 1; //Mac dinh la lay lan 1 --- int.Parse(txtLan.Text.ToString());
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
            F_COA_Result_Details F_LOC_Dtl = new F_COA_Result_Details();
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
                OBJ.SoCOA = gridView1.GetFocusedRowCellValue("SoCOA").ToString();
                

                DialogResult dlDel = XtraMessageBox.Show(" Bạn muốn xóa  : " + OBJ.SoCOA.ToString() + " ? ", "Xóa thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlDel == DialogResult.Yes)
                {
                    
                    BUSTD.Result_COA_TDBUS_DELETE(OBJ);

                    BUSKQ.Result_COA_KQDAO_DELETE(OBJ);
                    
                }
                // 18 Load lại datasource cho grid
                
                gridControl1.DataSource = tbl_Result_COA_TDTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_Result_COA_TD);

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

            OBJ.ID              = int.Parse(dr["ID"].ToString());
            OBJ.COATemplateID   = int.Parse(dr["COATemplateID"].ToString());
            OBJ.SoCOA           = dr["SoCOA"].ToString();
            OBJ.WO              = dr["WO"].ToString();
            OBJ.SmpDate         = DateTime.Parse(dr["SmpDate"].ToString());
            OBJ.ManfDate        = DateTime.Parse(dr["ManfDate"].ToString());
            OBJ.ManfBy          = dr["ManfBy"].ToString();
            OBJ.AnlDate         = DateTime.Parse(dr["AnlDate"].ToString());
            OBJ.CreatedBy       = dr["CreatedBy"].ToString();
            OBJ.CreatedDate     = DateTime.Parse(dr["CreatedDate"].ToString());
            OBJ.ExpDate         = DateTime.Parse(dr["ExpDate"].ToString());
            OBJ.LB_MAT          = dr["LB_MAT"].ToString();
            //OBJ.Note            = dr["Note"].ToString();
            //OBJ.Locked          = bool.Parse(dr["Locked"].ToString());
        }

        public void finished(object sender,string isActionReturn)
        {
            //Dong form DELEGATE
            //var frm = (Form)sender;
            var frm = (DevExpress.XtraEditors.XtraForm)sender;
            
            if(isActionReturn == "Edit")
                frm.Close();

            // Step 2 : Load lại daisActionReturnta tren grid sau khi Add
            gridControl1.DataSource = tbl_Result_COA_TDTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_Result_COA_TD); 

            gridView1.BestFitColumns();

        }


    }
}
