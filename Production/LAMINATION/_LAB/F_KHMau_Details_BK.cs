using System;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors;
using System.Globalization;
using System.Data;

namespace Production.Class
{
    public partial class F_KHMau_Details_BK : frm_Base
    {
        public DateTime ngaynhanmau;
        string Path = Directory.GetCurrentDirectory();
        public string isAction = "";
        bool gridViewRowClick = false;
        /// <summary>
        /// DELEGATE
        /// </summary>        
        public delegate void MyAdd(object sender);
        public event MyAdd myFinished;
        
        public bool Is_close
        {
            set
            {
                if (value)
                {
                    if (myFinished != null) myFinished(sender: this);
                    //myFinished?.Invoke(sender: this);
                }
            }
        }
        //NEW : Phan khai bao cho KH Mau
        public KHMau_LAB KHMAUOBJ = new KHMau_LAB();
        KHMau_CTXN_LAB KHMAUCTXNOBJ = new KHMau_CTXN_LAB();
        KHMau_LABBUS BUS1 = new KHMau_LABBUS();
        KHMau_CTXN_LABBUS BUS2 = new KHMau_CTXN_LABBUS();        

        public F_KHMau_Details_BK()
        {
            InitializeComponent();
            Load += (s,e) =>
            {
                cmbNhanVienHuyMau.ReadOnly = true;
                txtTaiLieuHuy.ReadOnly = true;
                dteNgayHuyMau.ReadOnly = true;
                txtSoLuongHuy.ReadOnly = true;

                this.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Right - this.Width, 0);
                //if(isEditting == true)
                //Set4Controls();

                if (KHMAUOBJ.SoPXN.Substring(0,3) == "GEN" || KHMAUOBJ.SoPXN.Substring(0, 3) == "HTH" || KHMAUOBJ.SoPXN.Substring(0, 3) == "MDW")
                {
                    //cmbLoaiDV
                    layoutControlItem30.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlItem30.Text = "Loại động vật";

                    //cmbMauNuoc
                    layoutControlItem29.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layoutControlItem29.Text = "Mẫu nước";
                }

                else if (KHMAUOBJ.SoPXN.Substring(0, 3) == "H2O")
                {
                    //cmbLoaiDV
                    layoutControlItem30.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    layoutControlItem30.Text = "Loại động vật";

                    //cmbMauNuoc
                    layoutControlItem29.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    layoutControlItem29.Text = "Mẫu nước";
                }

                if (isAction == "Edit")
                {
                    layoutControlGroup4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                    //KH_Mau
                    txtKHMau.ReadOnly = true;
                    txtSoPXN.ReadOnly = true;
                    Set4Controls_Header();
                    Set4Controls_Details();

                    //XtraMessageBox.Show(KHMAUOBJ.KHMau);

                    gridControl1.DataSource = this.tbl_KHMau_CTXN_LABTableAdapter.FillBy(this.sYNC_NUTRICIELDataSet.tbl_KHMau_CTXN_LAB, KHMAUOBJ.KHMau);
                    //Tao moi KH_Mau
                    btnCreate.Enabled = false;

                    //Nut Luu khi Tao moi KH_Mau
                    btnSave.Enabled = false;

                    //Luu khi cap nhat thong tin KH_Mau
                    btnUpdate.Enabled = true;


                }
                else if (isAction == "Add")
                {
                    Set4Controls_Header();
                    //gridControl1.DataSource = this.tbl_KHMau_CTXN_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_KHMau_CTXN_LAB);
                    //Tao moi KH_Mau
                    btnCreate.Enabled = true;

                    //Nut Luu khi Tao moi KH_Mau
                    btnSave.Enabled = true;

                    //Luu khi cap nhat thong tin KH_Mau
                    btnUpdate.Enabled = false;

                    //KH_Mau
                    txtKHMau.ReadOnly = false;
                    txtSoPXN.ReadOnly = true;
                    txtID.ReadOnly = true;
                    layoutControlGroup4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    btnCancel.Enabled = false;
                }
                //Khong tao moi thi huy form
                btnSave.Enabled = true;
            };            

            //Them Chi tieu hay yeu cau xet nghiem
            btnAdd1.Click += (s, e) =>
            {
                isAction = "Add";

                state = MenuState.Insert;
                //Update :  DELEGATE
                // Gọi form Details
                F_KHMau_CTXN_Details FRM = new F_KHMau_CTXN_Details();
                FRM.isAction = this.isAction;
                FRM.ngaynhanmau = this.ngaynhanmau;
                FRM.KHMAUOBJ = this.KHMAUOBJ;
                FRM.KHMAUCTXNOBJ = this.KHMAUCTXNOBJ;
                FRM.myFinished += this.finished;
                FRM.Show();                               


                //if(lkeCTXN.Text.Length > 0 && lkeCTXN.Text != "...")
                //{
                //    if (txtSoLuong.Text == null)
                //        XtraMessageBox.Show("Vui lòng nhập số lượng mẫu đã nhận","Lưu ý");
                //    else
                //    {
                //        if (txtSoLuongXN.Text == null)
                //            txtSoLuongXN.Text = txtSoLuong.Text;

                //        if (KHMAUCTXNOBJ.DonGia != 0)
                //            KHMAUCTXNOBJ.ThanhTien = (KHMAUCTXNOBJ.DonGia * float.Parse(txtSoLuongXN.Text) * (100 + KHMAUCTXNOBJ.VAT) / 100);
                //        else
                //            KHMAUCTXNOBJ.ThanhTien = 0;

                //        KHMAUCTXNOBJ.KHMau = txtKHMau.Text;
                //        KHMAUCTXNOBJ.CTXNID = int.Parse(lkeCTXN.EditValue.ToString());
                //        KHMAUCTXNOBJ.SoLuongXN = txtSoLuongXN.Text;
                //        BUS2.KHMau_CTXN_LABBUS_INSERT(KHMAUCTXNOBJ);
                //    }
                //}
                //this.tbl_KHMau_CTXN_LABTableAdapter.ClearBeforeFill = true;
                //gridControl1.DataSource = this.tbl_KHMau_CTXN_LABTableAdapter.FillBy(this.sYNC_NUTRICIELDataSet.tbl_KHMau_CTXN_LAB, txtKHMau.Text);

            };

            //Cap nhat Chi tieu hay yeu cau xet nghiem
            btnEdit1.Click += (s, e) =>
            {
                if (gridViewRowClick == true)
                {
                    isAction = "Edit";

                    state = MenuState.Insert;
                    //Update :  DELEGATE
                    // Gọi form Details
                    F_KHMau_CTXN_Details FRM = new F_KHMau_CTXN_Details();
                    FRM.isAction = this.isAction;
                    FRM.ngaynhanmau = this.ngaynhanmau;
                    FRM.KHMAUOBJ = this.KHMAUOBJ;
                    FRM.KHMAUCTXNOBJ = this.KHMAUCTXNOBJ;
                    FRM.myFinished += this.finished;
                    FRM.Show();
                }
                else
                    XtraMessageBox.Show("Vui lòng click chọn dòng cần cập nhật");



                //if(lkeCTXN.Text.Length > 0 && lkeCTXN.Text != "...")
                //{
                //    if (txtSoLuong.Text == null)
                //        XtraMessageBox.Show("Vui lòng nhập số lượng mẫu đã nhận","Lưu ý");
                //    else
                //    {
                //        if (txtSoLuongXN.Text == null)
                //            txtSoLuongXN.Text = txtSoLuong.Text;

                //        if (KHMAUCTXNOBJ.DonGia != 0)
                //            KHMAUCTXNOBJ.ThanhTien = (KHMAUCTXNOBJ.DonGia * float.Parse(txtSoLuongXN.Text) * (100 + KHMAUCTXNOBJ.VAT) / 100);
                //        else
                //            KHMAUCTXNOBJ.ThanhTien = 0;

                //        KHMAUCTXNOBJ.KHMau = txtKHMau.Text;
                //        KHMAUCTXNOBJ.CTXNID = int.Parse(lkeCTXN.EditValue.ToString());
                //        KHMAUCTXNOBJ.SoLuongXN = txtSoLuongXN.Text;
                //        BUS2.KHMau_CTXN_LABBUS_INSERT(KHMAUCTXNOBJ);
                //    }
                //}
                //this.tbl_KHMau_CTXN_LABTableAdapter.ClearBeforeFill = true;
                //gridControl1.DataSource = this.tbl_KHMau_CTXN_LABTableAdapter.FillBy(this.sYNC_NUTRICIELDataSet.tbl_KHMau_CTXN_LAB, txtKHMau.Text);

            };

            //lkeCTXN.TextChanged += (s, e) =>
            //{
            //    object row                  = lkeCTXN.Properties.GetDataSourceRowByKeyValue(lkeCTXN.EditValue);
            //    //MessageBox.Show((row as DataRowView)["PPXNID"].ToString());
            //    //MessageBox.Show((row as DataRowView)["VAT"].ToString());
            //    //MessageBox.Show((row as DataRowView)["DonGia"].ToString());
            //    //lkePPXN.EditValue = int.Parse((row as DataRowView)["PPXNID"].ToString());
            //    KHMAUCTXNOBJ.DonGia         = float.Parse((row as DataRowView)["DonGia"].ToString());
                
            //    KHMAUCTXNOBJ.VAT            = float.Parse((row as DataRowView)["VAT"].ToString());
                
            //    //txtVAT.Text = (row as DataRowView)["VAT"].ToString();
            //    //MessageBox.Show("DonGia " +(row as DataRowView)["DonGia"].ToString());
            //    //MessageBox.Show("ThanhTien " + (row as DataRowView)["ThanhTien"].ToString());
            //};

            btnUpdate.Click += (s, e) =>
            {
                Set4Object_Details();
                //if (lkeNCTXNID.Text.Length > 0)
                //{
                //KHMAUCTXNOBJ.KHMau = txtCTXN.Text;
                //KHMAUCTXNOBJ.CTXNID = lkeNCTXNID.EditValue.ToString();
                BUS1.KHMau_LABBUS_UPDATE(KHMAUOBJ);
                XtraMessageBox.Show("Cập nhật thành công");
                Is_close = true;
                //}
            };

            gridView1.RowClick += (s, e) =>
            {
                KHMAUCTXNOBJ.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                gridViewRowClick = true;
                Set4Object_Details();

            };

            btnDel1.Click += (s, e) =>
            {
                if (gridViewRowClick == true)
                {                     
                    BUS2.KHMau_CTXN_LABDAO_DELETE(KHMAUCTXNOBJ.ID);
                    gridViewRowClick = false;
                    XtraMessageBox.Show("Xóa thành công ");
                    gridControl1.DataSource = this.tbl_KHMau_CTXN_LABTableAdapter.FillBy(this.sYNC_NUTRICIELDataSet.tbl_KHMau_CTXN_LAB, txtKHMau.Text);
                }
                else
                    XtraMessageBox.Show("Vui lòng click vào đầu dòng cần xóa ");
            };

            btnCreate.Click += (s, e) =>
            {
                if (txtKHMau.Text.Length > 0)
                {
                    layoutControlGroup4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    //KH_Mau
                    txtKHMau.ReadOnly = true;
                    KHMAUOBJ.KHMau = txtKHMau.Text;
                    Set4Object_Header();
                    Set4Object_Details();
                    BUS1.KHMau_LABBUS_INSERT(KHMAUOBJ);
                    gridControl1.DataSource = this.tbl_KHMau_CTXN_LABTableAdapter.FillBy(this.sYNC_NUTRICIELDataSet.tbl_KHMau_CTXN_LAB, txtKHMau.Text);
                }
            };

            btnSave.Click += (s,e) =>
            {
                try
                {
                    //if (isAction == "Edit")
                    //{
                        Set4Object_Header();
                        Set4Object_Details();
                        BUS1.KHMau_LABBUS_UPDATE(KHMAUOBJ);
                    //}                
                    Is_close = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            };

            btnCancel.Click += (s, e) =>
            {
                Set4Object_Details();
                //KHMau_LABBUS
                BUS1.KHMau_LABBUS_UPDATE(KHMAUOBJ);
                Is_close = true;
            };

            chkHuyMau.CheckedChanged +=(s,e) =>
            {
                if(chkHuyMau.CheckState == CheckState.Checked)
                {
                    KHMAUOBJ.TrangThaiKHMau = false;
                    cmbNhanVienHuyMau.ReadOnly = false;
                    txtTaiLieuHuy.ReadOnly = false;
                    dteNgayHuyMau.ReadOnly = false;
                    txtSoLuongHuy.ReadOnly = false;
                }

                else
                {
                    KHMAUOBJ.TrangThaiKHMau = true;
                    cmbNhanVienHuyMau.ReadOnly = true;
                    txtTaiLieuHuy.ReadOnly = true;
                    dteNgayHuyMau.ReadOnly = true;
                    txtSoLuongHuy.ReadOnly = true;
                }
            };

            
        }
        public void Set4Controls_Header()
        {
                      
           
            txtSoPXN.Text = KHMAUOBJ.SoPXN;
            txtID.Text = KHMAUOBJ.ID.ToString() ;
            if(isAction == "Edit")
                txtKHMau.Text = KHMAUOBJ.KHMau;           
        }

        public void Set4Controls_Details()
        {
                     
            if(KHMAUOBJ.TrangThaiKHMau == true )            
                chkHuyMau.CheckState = CheckState.Checked;
            else
                chkHuyMau.CheckState = CheckState.Unchecked;
            
            txtKHMau_KH.Text = KHMAUOBJ.KHMau_KhachHang;
            cmbKhoa.Text = KHMAUOBJ.Locked.ToString();
            txtNote.Text = KHMAUOBJ.Note;            
            txtSoLuong.Text = KHMAUOBJ.SoLuongKHMau;
            cmbDonViTinh.Text = KHMAUOBJ.DonViKHMau;
            cmbDonViTinh.Text = KHMAUOBJ.DonViKHMau;
            cmbNhanVienLuuMau.Text = KHMAUOBJ.NhanVienLuuKHMau;
            cmbViTriLuuMau.Text = KHMAUOBJ.VitriLuuKHMau;
            cmbPhuongPhapBaoQuan.Text = KHMAUOBJ.PhuongPhapBaoQuan;
            dteNgayLuuMau.Text = KHMAUOBJ.NgayLuuKHMau.ToString().Substring(0, 10);
            cmbNhanVienHuyMau.Text = KHMAUOBJ.NhanVienHuyKHMau;
            txtTaiLieuHuy.Text = KHMAUOBJ.TaiLieuHuyKHMau;
            dteNgayHuyMau.Text = KHMAUOBJ.NgayHuyKHMau.ToString().Substring(0, 10);
            txtSoLuongHuy.Text = KHMAUOBJ.SoLuongHuyKHMau;
            gridControl1.DataSource = this.tbl_KHMau_CTXN_LABTableAdapter.FillBy(this.sYNC_NUTRICIELDataSet.tbl_KHMau_CTXN_LAB, KHMAUOBJ.KHMau);
            ///////////////////////////////////////////////////////////////
            if (txtSoPXN.Text.Substring(0,3) == "H2O")
            {
                //XtraMessageBox.Show(txtSoPXN.Text.Substring(0, 3));
                cmbLoaiDongVat.Text = "";
                cmbMauNuoc.Text = KHMAUOBJ.LoaiDVMauNuoc;
                //XtraMessageBox.Show(KHMAUOBJ.LoaiDVMauNuoc);
            }
            else if (txtSoPXN.Text.Substring(0, 3) == "GEN" || txtSoPXN.Text.Substring(0, 3) == "HTH" || txtSoPXN.Text.Substring(0, 3) == "MDW")
            {
                //XtraMessageBox.Show(txtSoPXN.Text.Substring(0, 3));
                cmbLoaiDongVat.Text = KHMAUOBJ.LoaiDVMauNuoc;
                cmbMauNuoc.Text = "";
                //XtraMessageBox.Show(KHMAUOBJ.LoaiDVMauNuoc);
            }
            
            dteNgayLayMau.Text = KHMAUOBJ.NgayLayMau.ToString().Substring(0, 10);
            txtLoaiMauGui.Text = KHMAUOBJ.LoaiMauGui;
            txtTTMauGui.Text = KHMAUOBJ.TTMauGui;
            txtVTMauDayChuong.Text = KHMAUOBJ.VTLayMauDayChuong;
            txtGioLayMauTuoi.Text = KHMAUOBJ.GioLayMauTuoi;
            txtKHMau.Text = KHMAUOBJ.KHMau;
            txtKhac.Text = KHMAUOBJ.Khac;
            txtSoLuongKhongDat.Text = KHMAUOBJ.SoLuongKHMauKhongDat;
            txtLiDo.Text = KHMAUOBJ.LiDoKHMauKhongDat;

        }

        public void Set4Object_Header()
        {
            KHMAUOBJ.KHMau = txtKHMau.Text;
            if( isAction == "Edit")
                KHMAUOBJ.ID = int.Parse(txtID.Text.ToString()) ;            
            KHMAUOBJ.SoPXN= txtSoPXN.Text;
        }

        public void Set4Object_Details()
        {

            //KHMAUCTXNOBJ
            
            if (isAction == "Edit")
            {
                KHMAUCTXNOBJ.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                KHMAUCTXNOBJ.SoLuongXN = gridView1.GetFocusedRowCellValue("SoLuongXN").ToString();
                KHMAUCTXNOBJ.CTXNID = int.Parse(gridView1.GetFocusedRowCellValue("CTXNID").ToString());
            }                

            if (chkHuyMau.CheckState == CheckState.Checked)
                KHMAUOBJ.TrangThaiKHMau = true;
            else
                KHMAUOBJ.TrangThaiKHMau = false;

            KHMAUOBJ.CreatedBy = user.Username;
            //KHMAUOBJ.CreatedDate
            KHMAUOBJ.KHMau_KhachHang = txtKHMau_KH.Text;
            KHMAUOBJ.DonViKHMau = cmbDonViTinh.Text.ToString();
            KHMAUOBJ.Locked = cmbKhoa.Text.ToString() == "True" ? true : false;
            KHMAUOBJ.Note = txtNote.Text;
            KHMAUOBJ.NhanVienHuyKHMau = cmbNhanVienHuyMau.Text;
            KHMAUOBJ.NhanVienLuuKHMau = cmbNhanVienLuuMau.Text;
            KHMAUOBJ.PhuongPhapBaoQuan = cmbPhuongPhapBaoQuan.Text;
            KHMAUOBJ.SoLuongHuyKHMau = txtSoLuongHuy.Text;
            KHMAUOBJ.SoLuongKHMau = txtSoLuong.Text;
            KHMAUOBJ.TaiLieuHuyKHMau = txtTaiLieuHuy.Text;
            //KHMAUOBJ.TrangThaiKHMau
            KHMAUOBJ.VitriLuuKHMau = cmbViTriLuuMau.Text;
            //XtraMessageBox.Show(dteNgayHuyMau.Text.ToString());
            //KHMAUOBJ.NgayHuyKHMau = dteNgayHuyMau.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayHuyMau.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            if(isAction == "Add")
            {
                //XtraMessageBox.Show(dteNgayHuyMau.Text.ToString());
                if (dteNgayHuyMau.Text.ToString() == null || dteNgayHuyMau.Text.Length == 0)
                    KHMAUOBJ.NgayHuyKHMau = DateTime.Parse("1999-01-01");
                
                else
                    KHMAUOBJ.NgayHuyKHMau = DateTime.Parse(dteNgayHuyMau.Text.ToString(), CultureInfo.CreateSpecificCulture("en-GB"));

                if (dteNgayLuuMau.Text.ToString() == null || dteNgayLuuMau.Text.Length == 0 )
                    KHMAUOBJ.NgayLuuKHMau = DateTime.Parse("1999-01-01");
                
                else
                    KHMAUOBJ.NgayLuuKHMau = DateTime.Parse(dteNgayLuuMau.Text.ToString(), CultureInfo.CreateSpecificCulture("en-GB"));
            }
            else
            {
                KHMAUOBJ.NgayHuyKHMau = DateTime.Parse(dteNgayHuyMau.Text.ToString(), CultureInfo.CreateSpecificCulture("en-GB"));
                KHMAUOBJ.NgayLuuKHMau = DateTime.Parse(dteNgayLuuMau.Text.ToString(), CultureInfo.CreateSpecificCulture("en-GB"));

            }
            //XtraMessageBox.Show(KHMAUOBJ.NgayHuyKHMau.ToString());
            //KHMAUOBJ.NgayLuuKHMau = dteNgayLuuMau.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayLuuMau.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            //KHMAUOBJ.NgayLuuKHMau = dteNgayLuuMau.Text== null || dteNgayLuuMau.Text.ToString().Substring(0, 10) == "01/01/0001" || dteNgayLuuMau.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayLuuMau.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            /////////////////////////////////////////
            if (cmbLoaiDongVat.Text == "")
            {
                KHMAUOBJ.LoaiDVMauNuoc = cmbMauNuoc.Text;
            }
            else if (cmbMauNuoc.Text == "")
            {
                KHMAUOBJ.LoaiDVMauNuoc = cmbLoaiDongVat.Text;
            }
            //KHMAUOBJ.NgayLayMau = dteNgayLayMau.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayLayMau.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            if (dteNgayLayMau.Text.ToString() == null || dteNgayLayMau.Text.Length == 0 || dteNgayLayMau.Text.ToString().Substring(0, 10) == "01/01/0001")
                KHMAUOBJ.NgayLayMau = DateTime.Parse("1999-01-01");            
            else
                KHMAUOBJ.NgayLayMau = DateTime.Parse(dteNgayLayMau.Text.ToString(), CultureInfo.CreateSpecificCulture("en-GB"));

            KHMAUOBJ.LoaiMauGui = txtLoaiMauGui.Text;
            KHMAUOBJ.TTMauGui = txtTTMauGui.Text;
            KHMAUOBJ.VTLayMauDayChuong = txtVTMauDayChuong.Text;
            KHMAUOBJ.GioLayMauTuoi = txtGioLayMauTuoi.Text;
            KHMAUOBJ.Khac = txtKhac.Text;
            KHMAUOBJ.SoLuongKHMauKhongDat = txtSoLuongKhongDat.Text;
            KHMAUOBJ.LiDoKHMauKhongDat = txtLiDo.Text;
        }


        public void ResetControl()
        {
            
            //lkeMaDN.Text = "";
            //txtTenDN.Text = "";
            txtKHMau.Text = "";
            txtSoLuong.Text = "";
            cmbDonViTinh.Text = "";
            //lkeCTXN.Text = "";
            cmbKhoa.Text = "";
            //lkePPXNID.EditValue = null;
            txtNote.Text = "";
        }
        //
        public void ControlsReadOnly(bool bl)
        {
            
            txtKHMau.ReadOnly = bl;
            txtSoLuong.ReadOnly = bl;
            cmbDonViTinh.ReadOnly = bl;
            //lkeCTXN.ReadOnly = bl;
            cmbKhoa.ReadOnly = bl;
            //lkePPXNID.ReadOnly = bl;
            txtNote.ReadOnly = bl;
        }
        public void finished(object sender)
        {
            //Dong form DELEGATE
            //var frm = (Form)sender;
            var frm = (DevExpress.XtraEditors.XtraForm)sender;
            frm.Close();

            // Step 2 : Load lại data tren grid sau khi Add
            this.tbl_KHMau_CTXN_LABTableAdapter.FillBy(this.sYNC_NUTRICIELDataSet.tbl_KHMau_CTXN_LAB,KHMAUOBJ.KHMau);

            gridView1.BestFitColumns();

        }
        private void F_CUSTOMER_Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_PhuongPhapBaoQuan_LAB' table. You can move, or remove it, as needed.
            this.tbl_PhuongPhapBaoQuan_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_PhuongPhapBaoQuan_LAB);
              // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_MauNuoc_LAB' table. You can move, or remove it, as needed.
            this.tbl_MauNuoc_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_MauNuoc_LAB);
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_MauNuoc_LAB' table. You can move, or remove it, as needed.
            this.tbl_MauNuoc_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_MauNuoc_LAB);
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_LoaiDV_LAB' table. You can move, or remove it, as needed.
            this.tbl_LoaiDV_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_LoaiDV_LAB);
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_KHMau_CTXN_LAB' table. You can move, or remove it, as needed.
            this.tbl_KHMau_CTXN_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_KHMau_CTXN_LAB);            

            this.tbl_ChiTieuXetNghiem_LAB_ByNgayNhanMauTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_ChiTieuXetNghiem_LAB_ByNgayNhanMau, ngaynhanmau.ToString());

        }
    }
    
}
