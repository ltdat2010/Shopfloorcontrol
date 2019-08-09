using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Production.Class
{
    public partial class F_COA_Template_List : UC_Base
    {
        COA_Template_Header OBJ = new COA_Template_Header();

        COA_Template_HeaderBUS BUS = new COA_Template_HeaderBUS();
        HangMucKiemTraBUS BUS1 = new HangMucKiemTraBUS();
        
        public F_COA_Template_List()
        {
            InitializeComponent();
            Load += (s, e) =>
                {
                    // 1 Lấy thông tin user login
                    OBJ.CreatedBy = user.Username;

                    gridControl1.DataSource = tbl_COA_Template_HeaderTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_COA_Template_Header);
                    
                    gridView1.BestFitColumns();
                    
                    gridView1.OptionsBehavior.ReadOnly = true;
                   
                };
            action1.Add(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Add));

            action1.Edit(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Edit));

            action1.Save(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Save));

            action1.Delete(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Delete));

            action1.View(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_View));

            action1.CSV(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_CSV));

            action1.Report(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Report));

            action1.Close(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Close));

            gridView1.RowClick += (s, e) =>
                {
                    gridViewRowClick = true;
                    //txtID.Text = gridView1.GetFocusedRowCellValue("ID").ToString();
                    //txtCOA.Text = gridView1.GetFocusedRowCellValue("COA").ToString();
                    //gridControl2.DataSource = COB.COA_Template(int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString()));
                };       
        }

        private void ItemClickEventHandler_Add(object sender, EventArgs e)
        {
            isAction = "Add";

            state = MenuState.Insert;
            //Update :  DELEGATE
            // Gọi form Details
            F_COA_Template_Header FRM = new F_COA_Template_Header();
            FRM.isAction = this.isAction;
            FRM.OBJ = this.OBJ;
            FRM.myFinished += this.finished;
            FRM.Show();
            //    txtID.Text = COB.COA_Template_Max_COAID().ToString();            
            //    ControlsReadOnly(false);
            //    gridView2.OptionsBehavior.Editable = true;               
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
                F_COA_Template_Header FRM = new F_COA_Template_Header();
                FRM.OBJ = this.OBJ;
                FRM.isAction = this.isAction;
                FRM.myFinished += this.finished;
                FRM.Show();
            }
            else
                XtraMessageBox.Show("Vui lòng click vào dòng cần chỉnh sửa ");
            //    isNew = false;
            //    if(txtID.Text.Length > 0)
            //    {                
            //        ControlsReadOnly(false);
            //        gridView2.OptionsBehavior.Editable = true;       
            //    }            
        }

        private void ItemClickEventHandler_Save(object sender, EventArgs e)
        {        
        }

        private void ItemClickEventHandler_Delete(object sender, EventArgs e)
        {
            // 14 Khai báo state cho các nút khi nhấn nút Del
            state = MenuState.Delete;

            if (gridViewRowClick == true)
            {
                OBJ.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                OBJ.COATemplate = gridView1.GetFocusedRowCellValue("COATemplate").ToString();

                DialogResult dlDel = XtraMessageBox.Show(" Bạn muốn xóa chỉ tiêu phân tích  : " + OBJ.COATemplate + " ? ", "Xóa thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlDel == DialogResult.Yes)
                {
                    BUS.COA_Template_HeaderDAO_DELETE(OBJ);
                }
                // 18 Load lại datasource cho grid

                gridControl1.DataSource = tbl_COA_Template_HeaderTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_COA_Template_Header);

                gridView1.BestFitColumns();
                // 17 trả trạng thái cho các nút như ban đầu
                state = MenuState.Full;
            }
            else
                // 16 Xác nhận có muốn xoa không ?
                XtraMessageBox.Show("Vui lòng click vào dòng cần chỉnh sửa ");
            //    COB.COA_Template_Delete(int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString()));
            //    ResetControl();
            //    ControlsReadOnly(true);
            //    gridView2.OptionsBehavior.Editable = false;
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
            F_COA_Template_Header FRM = new F_COA_Template_Header();
            FRM.isAction = this.isAction;
            FRM.OBJ = this.OBJ;
            FRM.myFinished += this.finished;
            FRM.Show();
        }

        private void ItemClickEventHandler_CSV(object sender, EventArgs e)
        {

        }

        private void ItemClickEventHandler_Report(object sender, EventArgs e)
        {

        }

        private void ItemClickEventHandler_Close(object sender, EventArgs e)
        {
            this.Close();
        }

        //public void ResetControl()
        //{            
        //    gridControl1.DataSource = tbl_COATableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_COA);           
        //    txtID.Text = "";            
        //}

        //public void ControlsReadOnly(bool bl)
        //{
        //    txtCOA.ReadOnly = bl;            
        //} 

        public void Set4Object()
        {
            OBJ.ID              = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            OBJ.COATemplate     = gridView1.GetFocusedRowCellValue("COATemplate").ToString();
            OBJ.COADescription  = gridView1.GetFocusedRowCellValue("COADescription").ToString();
            OBJ.Note            = gridView1.GetFocusedRowCellValue("Note").ToString();
            OBJ.Locked          = gridView1.GetFocusedRowCellValue("Locked").ToString() == "True" ? true : false;
            //XtraMessageBox.Show(string.IsNullOrEmpty(gridView1.GetFocusedRowCellValue("IMGCOA").ToString()).ToString());
            if(string.IsNullOrEmpty(gridView1.GetFocusedRowCellValue("IMGCOA").ToString()) == false)
                OBJ.IMGCOA          = (byte[])gridView1.GetFocusedRowCellValue("IMGCOA");            

        }

        public void finished(object sender, string isActionReturn)
        {
            //Dong form DELEGATE
            //var frm = (Form)sender;
            var frm = (DevExpress.XtraEditors.XtraForm)sender;

            if (isActionReturn == "Edit")
                frm.Close();
            
            // Step 2 : Load lại daisActionReturnta tren grid sau khi Add
            gridControl1.DataSource = tbl_COA_Template_HeaderTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_COA_Template_Header);

            gridView1.BestFitColumns();

        }

        static byte[] GetBytes(string str)
        {
            byte[] bytes = new byte[str.Length * sizeof(char)];
            System.Buffer.BlockCopy(str.ToCharArray(), 0, bytes, 0, bytes.Length);
            return bytes;
        }

        static string GetString(byte[] bytes)
        {
            char[] chars = new char[bytes.Length / sizeof(char)];
            System.Buffer.BlockCopy(bytes, 0, chars, 0, bytes.Length);
            return new string(chars);
        }

    }
}
