using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using System;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_PRICELIST_Details : frm_Base
    {
        #region Variables

        private int ImageID = 0;
        private String strFilePath = "";
        private Image DefaultImage;
        private Byte[] ImageByteArray;
        ////before executing -create database with given script - change connection string according to yours
        //public static string varConnect_S = "Data Source= 192.168.0.249;" +
        //                                       "Database= SYNC_NUTRICIEL;" +
        //                                       "User ID= netika;" +
        //                                       "password= bsvn";
        ////public static SqlConnection conn_S = new SqlConnection(Conn.varConnect_S);
        //SqlConnection sqlcon = new SqlConnection(varConnect_S);

        #endregion Variables

        private bool gridViewRowClick = false;
        private string Path = Directory.GetCurrentDirectory();
        private string filePath = @"D:\PriceList_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";

        /// <summary>
        /// DELEGATE
        /// </summary>
        public delegate void MyAdd(object sender);//, string isActionReturn);

        public event MyAdd myFinished;

        public bool Is_close
        {
            set
            {
                if (value)
                {
                    if (myFinished != null) myFinished(sender: this);//, isActionReturn: isAction);
                }
            }
        }

        public PRICELIST OBJ = new PRICELIST();
        private PRICELIST_Details OBJ1 = new PRICELIST_Details();
        //public KQKN_Template_Details_Row OBJ1 = new KQKN_Template_Details_Row();

        private PRICELISTBUS BUS = new PRICELISTBUS();
        private PRICELIST_DetailsBUS BUS1 = new PRICELIST_DetailsBUS();

        public F_PRICELIST_Details()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                if (isAction == "Edit")
                {
                    TDControlsReadOnly(true);
                    Set4Controls();

                    gridControl1.DataSource = tbl_PriceList_Details_LABTableAdapter.FillbyPLID(sYNC_NUTRICIELDataSet.tbl_PriceList_Details_LAB, int.Parse(txtID.Text));

                    //ImageByteArray = OBJ.IMGCOA;
                    //pbxImage.Image = Image.FromStream(new MemoryStream(OBJ.IMGCOA));
                }
                else if (isAction == "Add")
                {
                    gridControl1.Enabled = false;
                    actionMini1.Enabled = false;
                    txtID.ReadOnly = true;
                }
            };

            btnSave.Click += (s, e) =>
            {
                try
                {
                    btnSave.Enabled = false;

                    if (isAction == "Add")
                    {
                        Set4ObjectHeader();
                        Set4ObjectRow();
                        BUS.PRICELISTBUS_INSERT(OBJ);
                        gridControl1.Enabled = true;
                        actionMini1.Enabled = true;

                        //Gan gia tri ID moi insert vo table tbl_KQKN_Template_Hedaer cho form
                        OBJ.ID = BUS.MAX_PRICELIST_ID();
                    }
                    else if (isAction == "Edit")
                    {
                        Set4ObjectHeader();
                        Set4ObjectRow();

                        BUS.PRICELISTBUS_UPDATE(OBJ);
                    }

                    Is_close = true;
                    //XtraMessageBox.Show("3");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                isAction = "";
            };
            gridView1.RowClick += (s, e) =>
            {
                gridViewRowClick = true;
            };

            btnCancel.Click += (s, e) =>
            {
                Is_close = true;
                //this.Close();
            };

            txtNote.TextChanged += (s, e) =>
            {
                if (isAction == "Edit" || isAction == "Changed")
                {
                    isAction = "Changed";
                    btnSave.Enabled = true;
                }
            };

            cmbKhoa.TextChanged += (s, e) =>
            {
                if (isAction == "Edit" || isAction == "Changed")
                {
                    isAction = "Changed";
                    btnSave.Enabled = true;
                }
            };

            btnUpload.Click += (s, e) =>
            {
                //XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                //args.AutoCloseOptions.Delay = 10000;
                //args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                //args.DefaultButtonIndex = 0;
                //args.Caption = "Thông tin ";
                //args.Text = "Lưu thành công . Thông báo này sẽ tự đóng sau 10 giây.";
                //args.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Cancel };
                //XtraMessageBox.Show(args).ToString();
                //args.Showing += Args_Showing;
                System.Data.DataTable dt = new System.Data.DataTable();

                dt = ImportExceltoDatatable(filePath, "Sheet");

                Sql.ExecuteNonQuery(
                    "SAP",
                    "SP_tbl_PriceList_Details_LAB_TYPE",
                    CommandType.StoredProcedure,
                    "@tableTYPE",
                    dt
                    );

                Is_close = true;
            };

            // 7 Add hoặc New
            actionMini1.Add(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Add));

            // 8 Lưu
            actionMini1.Save(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Save));

            // 9 Edit hoặc Update
            actionMini1.Edit(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Edit));

            // 10 Del
            actionMini1.Delete(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Delete));

            // 10a View
            actionMini1.View(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_View));

            // 10B Cancel
            actionMini1.Close(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Close));

            // 10C PDF
            actionMini1.Report(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Report));
        }

        public void Set4Controls()
        {
            txtID.Text = OBJ.ID.ToString();
            txtTenmauCOA.Text = OBJ.PL.ToString();
            txtDienGiai.Text = OBJ.PL.ToString();
            txtNote.Text = OBJ.Note;
            cmbKhoa.Text = OBJ.Locked.ToString();
            dteEffDate.Text = OBJ.EffDate.ToString().Substring(0, 10);
            dteExpDate.Text = OBJ.ExpDate.ToString().Substring(0, 10);
        }

        public void Set4ObjectRow()
        {
            if (isAction == "Edit")
            {
                //OBJ1
                //MessageBox.Show("1");
                OBJ1.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                //MessageBox.Show("2");
                OBJ1.CTXNID = int.Parse(gridView1.GetFocusedRowCellValue("CTXNID").ToString());
                //MessageBox.Show("3");
                OBJ1.PLID = int.Parse(gridView1.GetFocusedRowCellValue("PLID").ToString());
                //MessageBox.Show("4");
                //OBJ1.ToleranceVN = gridView1.GetFocusedRowCellValue("ToleranceVN").ToString();
                OBJ1.DonGia = gridView1.GetFocusedRowCellValue("DonGia").ToString();
                OBJ1.Giam = gridView1.GetFocusedRowCellValue("Giam").ToString();
                OBJ1.SoLuong = gridView1.GetFocusedRowCellValue("SoLuong").ToString();
                OBJ1.UoM = gridView1.GetFocusedRowCellValue("UoM").ToString();
                OBJ1.UoMGiam = gridView1.GetFocusedRowCellValue("UoMGiam").ToString();
                //MessageBox.Show("5");
                //OBJ1.ValueVN = gridView1.GetFocusedRowCellValue("ValueVN").ToString();
                OBJ1.Note = gridView1.GetFocusedRowCellValue("Note").ToString();
                //MessageBox.Show("6");
                OBJ1.CreatedBy = gridView1.GetFocusedRowCellValue("CreatedBy").ToString();
                //MessageBox.Show("7");
                OBJ1.Locked = gridView1.GetFocusedRowCellValue("Locked").ToString() == "True" ? true : false;
                //MessageBox.Show("8");
                OBJ1.MuaNgoai = gridView1.GetFocusedRowCellValue("MuaNgoai").ToString() == "True" ? true : false;
                OBJ1.DVMuaNgoaiCode = gridView1.GetFocusedRowCellValue("DVMuaNgoaiCode").ToString();
                OBJ1.DVMuaNgoaiName = gridView1.GetFocusedRowCellValue("DVMuaNgoaiName").ToString();
            }
        }

        public void Set4ObjectHeader()
        {
            if (isAction == "Edit")
            {
                //MessageBox.Show("Bat dau Edit");
                //OBJ
                OBJ.ID = int.Parse(txtID.Text);
                //OBJ.COAName = txtTenmauCOA.Text;
                //OBJ.COADescription = txtDienGiai.Text;
                //OBJ.Note = txtNote.Text;
                //OBJ.Locked = cmbKhoa.SelectedText.ToString() == "True" ? true : false;
            }
            OBJ.PL = txtTenmauCOA.Text;
            //OBJ.PL = txtDienGiai.Text;
            OBJ.EffDate = dteEffDate.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteEffDate.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            OBJ.ExpDate = dteExpDate.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteExpDate.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            OBJ.Note = txtNote.Text;
            OBJ.Locked = cmbKhoa.SelectedText.ToString() == "True" ? true : false;
        }

        public void ResetControl()
        {
            txtID.Text = "";
            txtTenmauCOA.Text = "";
            //lkeCTPT.Text = "";
            //lkeTC.Text = "";

            txtNote.Text = "";
            cmbKhoa.Text = null;
        }

        public void TDControlsReadOnly(bool bl)
        {
            txtID.ReadOnly = bl;
            //lkeCTPT.ReadOnly = bl;
            //lkeTC.ReadOnly = bl;
            dteEffDate.ReadOnly = bl;
            dteExpDate.ReadOnly = bl;
            txtTenmauCOA.ReadOnly = bl;
            txtDienGiai.ReadOnly = bl;
            //txtNote.ReadOnly = bl;
            //cmbKhoa.ReadOnly = bl;
        }

        private void ItemClickEventHandler_Report(object sender, EventArgs e)
        {
            //string filePath = @"D:\PriceList_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
            //Save current layout
            gridView1.SaveLayoutToXml(@"D:\tempLayout.xml");
            //Set to visible all column

            //IDENTITY khi them dong moi
            txtIDENTITY.Text = BUS1.PRICELIST_INDENTITY_SELECT().ToString();

            foreach (GridColumn column in gridView1.Columns)
            {
                if (column.Name == "colID")
                {
                    column.VisibleIndex = 0;
                    column.Visible = true;
                }
                else if (column.Name == "colPLID")
                {
                    column.VisibleIndex = 1;
                    column.Visible = true;
                }
                else if (column.Name == "colCTXNID")
                {
                    column.VisibleIndex = 2;
                    column.Visible = true;
                }
                else if (column.Name == "colUoM")
                {
                    column.VisibleIndex = 3;
                    column.Visible = true;
                }
                else if (column.Name == "colSoLuong")
                {
                    column.VisibleIndex = 4;
                    column.Visible = true;
                }
                else if (column.Name == "colDonGia")
                {
                    column.VisibleIndex = 5;
                    column.Visible = true;
                }
                else if (column.Name == "colVAT")
                {
                    column.VisibleIndex = 6;
                    column.Visible = true;
                }
                else if (column.Name == "colDonGiaMuaNgoai")
                {
                    column.VisibleIndex = 7;
                    column.Visible = true;
                }
                else if (column.Name == "colDVMuaNgoaiCode")
                {
                    column.VisibleIndex = 8;
                    column.Visible = true;
                }
                else if (column.Name == "colDVMuaNgoaiName")
                {
                    column.VisibleIndex = 9;
                    column.Visible = true;
                }
                else if (column.Name == "colMuaNgoai")
                {
                    column.VisibleIndex = 10;
                    column.Visible = true;
                }
                else if (column.Name == "colCreatedDate")
                {
                    column.VisibleIndex = 11;
                    column.Visible = true;
                }
                else if (column.Name == "colCreatedBy")
                {
                    column.VisibleIndex = 12;
                    column.Visible = true;
                }
                else if (column.Name == "colLocked")
                {
                    column.VisibleIndex = 13;
                    column.Visible = true;
                }
                else if (column.Name == "colNote")
                {
                    column.VisibleIndex = 14;
                    column.Visible = true;
                }
                else
                    column.Visible = false;
            }
            //Export
            gridView1.ExportToXlsx(filePath);

            //Restore layout
            gridView1.RestoreLayoutFromXml(@"D:\tempLayout.xml");

            System.Diagnostics.Process.Start(filePath);
        }

        private void ItemClickEventHandler_Add(object sender, EventArgs e)
        {
            isActionMini = "Add";
            //Riêng cho trường hợp tạo mới Row trên KQKN template
            //Truyen ID cua KQKN template cho Row
            OBJ1.PLID = OBJ.ID;
            state = MenuState.Insert;
            //Update :  DELEGATE
            // Gọi form Details
            //Disable
            this.Enabled = false;
            //
            F_PRICELIST_Details_Added_Row FRM = new F_PRICELIST_Details_Added_Row();
            FRM.isAction = this.isActionMini;
            FRM.OBJ = this.OBJ1;
            FRM.myFinished += this.finished;
            FRM.Show();
        }

        private void ItemClickEventHandler_Edit(object sender, EventArgs e)
        {
            isActionMini = "Edit";
            //Riêng cho trường hợp tạo mới Row trên KQKN template
            //Truyen ID cua KQKN template cho Row
            Set4Object_PriceList_Details();
            state = MenuState.Update;
            //Update :  DELEGATE
            // Gọi form Details
            //Disable
            this.Enabled = false;
            //
            F_PRICELIST_Details_Added_Row FRM = new F_PRICELIST_Details_Added_Row();
            FRM.isAction = this.isActionMini;
            FRM.OBJ = this.OBJ1;
            FRM.myFinished += this.finished;
            FRM.Show();
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
            isActionMini = "View";

            // 26 COntrols gỡ bỏ trạng thái đọc cho phép nhập liệu
            //ControlsReadOnly(false);
            //Disable
            this.Enabled = false;
            //
            // Truyen object LOC to DELEGATE
            F_PRICELIST_Details_Added_Row F_LOC_Dtl = new F_PRICELIST_Details_Added_Row();
            F_LOC_Dtl.isAction = this.isActionMini;
            F_LOC_Dtl.OBJ = this.OBJ1;
            F_LOC_Dtl.myFinished += this.finished;
            F_LOC_Dtl.Show();
        }

        private void ItemClickEventHandler_Delete(object sender, EventArgs e)
        {
            // Cap nhat 2019-07-06
            // Khong cho xoa ma chi set Locked = '1'
            // De luu history price list detail
            // 14 Khai báo state cho các nút khi nhấn nút Del
            state = MenuState.Delete;

            if (gridViewRowClick == true)
            {
                OBJ1.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());

                DialogResult dlDel = XtraMessageBox.Show(" Bạn muốn xóa giá chỉ tiêu có mã  : " + OBJ1.ID + " ? ", "Xóa thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlDel == DialogResult.Yes)
                {
                    BUS1.PRICELIST_DELETE(OBJ1);
                }
                // 18 Load lại datasource cho grid

                gridControl1.DataSource = tbl_PriceList_Details_LABTableAdapter.FillbyPLID(sYNC_NUTRICIELDataSet.tbl_PriceList_Details_LAB, int.Parse(txtID.Text));

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
            if (isAction != "Changed")
                Is_close = true;
            //this.Close();
            else
            {
                DialogResult Dlg = XtraMessageBox.Show(" Bạn đã thay đổi nội dung . Bạn có muốn lưu lại ?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Dlg == DialogResult.No)
                    Is_close = true;
                //this.Close();
                else
                {
                    Set4ObjectHeader();
                    BUS.PRICELISTBUS_UPDATE(OBJ);
                    Is_close = true;
                    //this.Close();
                }
            }
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

            //// Step 2 : Load lại data tren grid sau khi Add
            gridControl1.DataSource = tbl_PriceList_Details_LABTableAdapter.FillbyPLID(sYNC_NUTRICIELDataSet.tbl_PriceList_Details_LAB, OBJ.ID);
            gridView1.BestFitColumns();
        }

        public System.Data.DataTable ImportExceltoDatatable(string filepath, string sheetname)
        {
            // string sqlquery= "Select * From [SheetName$] Where YourCondition";
            //string sqlquery = "Select * From [SheetName$] Where Id='ID_007'";
            string sqlquery = "Select * From [" + sheetname + "$]";
            DataSet ds = new DataSet();
            string constring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=\"Excel 12.0;HDR=YES;\"";
            OleDbConnection con = new OleDbConnection(constring + "");
            OleDbDataAdapter da = new OleDbDataAdapter(sqlquery, con);
            da.Fill(ds);
            System.Data.DataTable dt = ds.Tables[0];
            return dt;
        }

        private void Set4Object_PriceList_Details()
        {
            OBJ1.PLID = OBJ.ID;
            OBJ1.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            OBJ1.PLID = int.Parse(gridView1.GetFocusedRowCellValue("PLID").ToString());
            OBJ1.DonGia = gridView1.GetFocusedRowCellValue("DonGia").ToString();
            OBJ1.DonGiaMuaNgoai = gridView1.GetFocusedRowCellValue("DonGiaMuaNgoai").ToString();
            OBJ1.VAT = gridView1.GetFocusedRowCellValue("VAT").ToString();
            OBJ1.SoLuong = gridView1.GetFocusedRowCellValue("SoLuong").ToString();
            OBJ1.UoM = gridView1.GetFocusedRowCellValue("UoM").ToString();
            OBJ1.UoMGiam = gridView1.GetFocusedRowCellValue("UoMGiam").ToString();
            OBJ1.Giam = gridView1.GetFocusedRowCellValue("Giam").ToString();
            OBJ1.Note = gridView1.GetFocusedRowCellValue("Note").ToString();
            OBJ1.Locked = gridView1.GetFocusedRowCellValue("Locked").ToString() == "True" ? true : false;
            OBJ1.CTXNID = int.Parse(gridView1.GetFocusedRowCellValue("CTXNID").ToString());
            OBJ1.MuaNgoai = gridView1.GetFocusedRowCellValue("MuaNgoai").ToString() == "True" ? true : false;
            OBJ1.DVMuaNgoaiCode = gridView1.GetFocusedRowCellValue("DVMuaNgoaiCode").ToString();
            OBJ1.DVMuaNgoaiName = gridView1.GetFocusedRowCellValue("DVMuaNgoaiName").ToString();
        }

        //public void FillFromReader(DbDataReader reader)
        //{
        //    // We want to get the schema information (i.e. columns) from the
        //    // DbDataReader and
        //    // import it into *this* DataTable, NOT a new one.
        //    System.Data.DataTable schema = reader.GetSchemaTable();
        //    //GetSchemaTable() returns a DataTable with the columns we want.

        //    ImportSchema(this, schema); // <--- how do we do this?
        //}

        //void ImportSchema(System.Data.DataTable dest, System.Data.DataTable source)
        //{
        //    foreach (var c in source.Columns)
        //        dest.Columns.Add(c);
        //}

        private void F_PRICELIST_Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_PriceList_Details_LAB' table. You can move, or remove it, as needed.
            this.tbl_PriceList_Details_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_PriceList_Details_LAB);
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            Set4Object_PriceList_Details();
            BUS1.PRICELIST_UPDATE(OBJ1);
            tbl_PriceList_Details_LABTableAdapter.FillbyPLID(sYNC_NUTRICIELDataSet.tbl_PriceList_Details_LAB, OBJ.ID);
        }
    }
}