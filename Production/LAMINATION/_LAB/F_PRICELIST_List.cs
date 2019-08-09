using System;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Production.Class
{
    public partial class F_PRICELIST_List : UC_Base
    {
        //Kiem tra xem click chon row tren grid chua
        bool gridViewRowClick = false;

        PRICELIST OBJ = new PRICELIST();
        PRICELISTBUS BUS = new PRICELISTBUS();
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

        public F_PRICELIST_List()
        {       
            
            InitializeComponent();
            Load += (s, e) =>
                {
                    // 1 Lấy thông tin user login
                    OBJ.CreatedBy = user.Username;

                    tbl_PriceList_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_PriceList_LAB);
                  
                    gridControl1.DataSource = tbl_PriceList_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_PriceList_LAB);                    
                    
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

            btnPriceListHistory.Click += (s, e) =>
            {
                if(gridViewRowClick == true)
                {
                    Set4Object();
                    F_PRICELIST_History FRM = new Class.F_PRICELIST_History();
                    FRM.OBJ = this.OBJ;
                    FRM.isAction = this.isAction;
                    FRM.myFinished += this.finished;
                    FRM.Show();
                }
                else
                    XtraMessageBox.Show("Vui lòng click vào dòng cần chỉnh sửa ");
            };
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
            F_PRICELIST_Details F_LOC_Dtl = new F_PRICELIST_Details();
            F_LOC_Dtl.isAction = this.isAction;
            F_LOC_Dtl.OBJ = this.OBJ;
            F_LOC_Dtl.myFinished += this.finished ;
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
                F_PRICELIST_Details F_LOC_Dtl = new Class.F_PRICELIST_Details();
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
            // 27 Gán dữ liệ trên control cho object
            Set4Object();

            // 28 Kiem tra xem co phai là tao moi khong thi insert
            //if (isNew == true)
            if (isAction == "Add")
                BUS.PRICELISTBUS_INSERT(OBJ);
            // 29 Khong la tao moi thi update
            else
                BUS.PRICELISTBUS_UPDATE(OBJ);

            // 30 Gán du lieu ho datasource cua grid
            gridControl1.DataSource = tbl_PriceList_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_PriceList_LAB);

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
            //Disable
            this.Enabled = false;
            //
            // Truyen object LOC to DELEGATE
            F_PRICELIST_Details F_LOC_Dtl = new Class.F_PRICELIST_Details();
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
                OBJ.PL = gridView1.GetFocusedRowCellValue("PL").ToString();

                DialogResult dlDel = XtraMessageBox.Show(" Bạn muốn xóa phương pháp thử  : " + OBJ.PL + " ? ", "Xóa thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlDel == DialogResult.Yes)
                {
                    BUS.PRICELISTBUS_DELETE(OBJ);
                }
                // 18 Load lại datasource cho grid
                
                gridControl1.DataSource = tbl_PriceList_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_PriceList_LAB);

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
            OBJ.PL = gridView1.GetFocusedRowCellValue("PL").ToString();
            //OBJ.PLDG = gridView1.GetFocusedRowCellValue("PPTDG").ToString();
            OBJ.Note = gridView1.GetFocusedRowCellValue("Note").ToString();
            OBJ.Locked = gridView1.GetFocusedRowCellValue("Locked").ToString() == "True" ? true : false;
            OBJ.EffDate = DateTime.Parse(gridView1.GetFocusedRowCellValue("EffDate").ToString());
            OBJ.ExpDate = DateTime.Parse(gridView1.GetFocusedRowCellValue("ExpDate").ToString());
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
            gridControl1.DataSource = tbl_PriceList_LABTableAdapter.Fill(sYNC_NUTRICIELDataSet.tbl_PriceList_LAB);

            gridView1.BestFitColumns();

        }


    }
}
