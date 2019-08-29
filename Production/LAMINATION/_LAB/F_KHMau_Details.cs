using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_KHMau_Details : frm_Base
    {
        public DateTime ngaynhanmau;
        private string Path = Directory.GetCurrentDirectory();
        public string isAction = "";
        public string str_KHMau = "";
        private bool gridViewRowClick = false;

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

        
        private KHMau_CTXN_LAB KHMAUCTXNOBJ = new KHMau_CTXN_LAB();
        private KHMau_LABBUS BUS1 = new KHMau_LABBUS();
        private KHMau_CTXN_LABBUS BUS2 = new KHMau_CTXN_LABBUS();

        public F_KHMau_Details()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                this.Width = Screen.PrimaryScreen.Bounds.Width * 3 / 5;
                this.Height = Screen.PrimaryScreen.Bounds.Height - 30;

                action_EndForm1.Add_Status(false);
                action_EndForm1.Delete_Status(false);
                action_EndForm1.Update_Status(false);
                action_EndForm1.Save_Status(true);
                action_EndForm1.View_Status(true);
                action_EndForm1.Close_Status(false);

                action_EndForm2.Add_Status(true);
                action_EndForm2.Delete_Status(true);
                action_EndForm2.Update_Status(true);
                action_EndForm2.Save_Status(false);
                action_EndForm2.View_Status(false);
                action_EndForm2.Close_Status(false);

                action_EndForm3.Add_Status(false);
                action_EndForm3.Delete_Status(false);
                action_EndForm3.Update_Status(false);
                action_EndForm3.Save_Status(true);
                action_EndForm3.View_Status(false);
                action_EndForm3.Close_Status(true);

                cmbNhanVienHuyMau.ReadOnly = true;
                txtTaiLieuHuy.ReadOnly = true;
                dteNgayHuyMau.ReadOnly = true;
                txtSoLuongHuy.ReadOnly = true;

                this.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Right - this.Width, 0);
                //if(isEditting == true)
                //Set4Controls();

                if (KHMAUOBJ.SoPXN.Substring(0, 3) == "GEN" || KHMAUOBJ.SoPXN.Substring(0, 3) == "HTH" || KHMAUOBJ.SoPXN.Substring(0, 3) == "MDW")
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
                    //txtKHMau.ReadOnly = true;
                    txtSoPXN.ReadOnly = true;

                    Set4Controls_Header();
                    Set4Controls_Details();
                    //XtraMessageBox.Show(KHMAUOBJ.KHMau);

                    gridControl1.DataSource = this.tbl_KHMau_CTXN_LABTableAdapter.FillBy(this.sYNC_NUTRICIELDataSet.tbl_KHMau_CTXN_LAB, KHMAUOBJ.KHMau);
                    //Tao moi KH_Mau
                    //btnCreate.Enabled = false;

                    //Nut Luu khi Tao moi KH_Mau
                    //btnSave.Enabled = false;

                    //Luu khi cap nhat thong tin KH_Mau
                    //btnUpdate.Enabled = true;
                }
                else if (isAction == "Add")
                {
                    txtKHMau.Text = this.str_KHMau;
                    Set4Controls_Header();
                    //gridControl1.DataSource = this.tbl_KHMau_CTXN_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_KHMau_CTXN_LAB);
                    //Tao moi KH_Mau
                    //btnCreate.Enabled = true;

                    //Nut Luu khi Tao moi KH_Mau
                    //btnSave.Enabled = true;

                    //Luu khi cap nhat thong tin KH_Mau
                    //btnUpdate.Enabled = false;

                    //KH_Mau
                    txtKHMau.ReadOnly = false;
                    txtSoPXN.ReadOnly = true;
                    txtID.ReadOnly = true;
                    layoutControlGroup4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    //btnCancel.Enabled = false;
                }
                //Khong tao moi thi huy form
                //btnSave.Enabled = true;
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

            gridView1.RowClick += (s, e) =>
            {
                KHMAUCTXNOBJ.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                gridViewRowClick = true;
                Set4Object_Details();
            };

            chkHuyMau.CheckedChanged += (s, e) =>
             {
                 if (chkHuyMau.CheckState == CheckState.Checked)
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

            GrdLoaiDongVat.ButtonClick += (s, e) =>
            {
                if (e.Button.Index == 1)
                {
                    //Disable
                    this.Enabled = false;
                    //
                    F_LoaiDV_Details FRM = new F_LoaiDV_Details();
                    FRM.isAction = "Add";
                    //FRM.ngaynhanmau = this.ngaynhanmau;
                    //FRM.KHMAUOBJ = this.KHMAUOBJ;
                    //FRM.KHMAUCTXNOBJ = this.KHMAUCTXNOBJ;
                    FRM.myFinished += this.finished;
                    FRM.Show();
                }
            };

            GrdLoaiMauGui.ButtonClick += (s, e) =>
            {
                if (e.Button.Index == 1)
                {
                    //Disable
                    this.Enabled = false;
                    //
                    F_LoaiMauGoi_Details FRM = new F_LoaiMauGoi_Details();
                    FRM.isAction = "Add";
                    this.Visible = false;
                    //FRM.ngaynhanmau = this.ngaynhanmau;
                    //FRM.KHMAUOBJ = this.KHMAUOBJ;
                    //FRM.KHMAUCTXNOBJ = this.KHMAUCTXNOBJ;
                    FRM.myFinished += this.finished;
                    FRM.Show();
                }
            };

            //Action_EndForm
            action_EndForm1.Add(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Add));
            action_EndForm1.Update(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Update));
            action_EndForm1.Close(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Close));
            action_EndForm1.Save(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Save));
            //Action_EndForm
            action_EndForm2.Add(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Add2));
            action_EndForm2.Update(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Update2));
            action_EndForm2.Close(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Close2));
            action_EndForm2.Save(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Save2));
            action_EndForm2.Delete(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Delete2));
            //Action_EndForm
            action_EndForm3.Add(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Add3));
            action_EndForm3.Update(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Update3));
            action_EndForm3.Close(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Close3));
            action_EndForm3.Save(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Save3));
        }

        private void ItemClickEventHandler_Save3(object sender, ItemClickEventArgs e)
        {
            if (this.dxValidationProvider1.Validate() == true)
            {
                Set4Object_Header();
                Set4Object_Details();
                BUS1.KHMau_LABBUS_UPDATE(KHMAUOBJ);
                //BUS2.KHMau_CTXN_LABDAO_UPDATE(KHMAUCTXNOBJ);
                Is_close = true;
                //throw new NotImplementedException();
            }
            else
            {
                IList<Control> IControls = this.dxValidationProvider1.GetInvalidControls();
                foreach (Control ctrl in IControls)
                    ctrl.Focus();
            }
        }

        private void ItemClickEventHandler_Close3(object sender, ItemClickEventArgs e)
        {
            if (this.dxValidationProvider1.Validate() == true)
            {
                //Neu grid co data thi khong xoa KHMau
                if (gridView1.DataRowCount > 0)
                {
                    Set4Object_Header();
                    Set4Object_Details();
                    //KHMau_LABBUS
                    BUS1.KHMau_LABBUS_UPDATE(KHMAUOBJ);
                }
                else
                    //Neu grid khong co data thi xoa KHMau vua tao trang loi
                    BUS1.KHMau_LABBUS_DELETE(KHMAUOBJ.KHMau);

                Is_close = true;
            }
            else
            {
                IList<Control> IControls = this.dxValidationProvider1.GetInvalidControls();
                foreach (Control ctrl in IControls)
                    ctrl.Focus();
            }
            
            //throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Update3(object sender, ItemClickEventArgs e)
        {
            Set4Object_Details();
            //if (lkeNCTXNID.Text.Length > 0)
            //{
            //KHMAUCTXNOBJ.KHMau = txtCTXN.Text;
            //KHMAUCTXNOBJ.CTXNID = lkeNCTXNID.EditValue.ToString();
            BUS1.KHMau_LABBUS_UPDATE(KHMAUOBJ);

            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            args.AutoCloseOptions.Delay = 3000;
            args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
            args.DefaultButtonIndex = 0;
            args.Caption = "Thông báo ";
            args.Text = "Cập nhật thành công. Thông báo này sẽ tự đóng sau 5 giây.";
            args.Buttons = new DialogResult[] { DialogResult.OK };
            XtraMessageBox.Show(args).ToString();

            Is_close = true;
            //}
            //throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Add3(object sender, ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Delete2(object sender, ItemClickEventArgs e)
        {
            if (gridViewRowClick == true)
            {
                BUS2.KHMau_CTXN_LABDAO_DELETE(KHMAUCTXNOBJ.ID);
                gridViewRowClick = false;
                //XtraMessageBox.Show("Xóa thành công ");
                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.AutoCloseOptions.Delay = 3000;
                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                args.DefaultButtonIndex = 0;
                args.Caption = "Thông báo ";
                args.Text = "Xóa thành công. Thông báo này sẽ tự đóng sau 3 giây.";
                args.Buttons = new DialogResult[] { DialogResult.OK };
                XtraMessageBox.Show(args).ToString();
                gridControl1.DataSource = this.tbl_KHMau_CTXN_LABTableAdapter.FillBy(this.sYNC_NUTRICIELDataSet.tbl_KHMau_CTXN_LAB, txtKHMau.Text);
            }
            else
            {
                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.AutoCloseOptions.Delay = 3000;
                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                args.DefaultButtonIndex = 0;
                args.Caption = "Thông báo ";
                args.Text = "Vui lòng click vào đầu dòng cần xóa. Thông báo này sẽ tự đóng sau 3 giây.";
                args.Buttons = new DialogResult[] { DialogResult.OK };
                XtraMessageBox.Show(args).ToString();
            }
            //throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Save2(object sender, ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Close2(object sender, ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Update2(object sender, ItemClickEventArgs e)
        {
            if (gridViewRowClick == true)
            {
                isAction = "Edit";

                state = MenuState.Insert;
                //Update :  DELEGATE
                // Gọi form Details
                //Disable
                this.Enabled = false;
                //
                F_KHMau_CTXN_Details FRM = new F_KHMau_CTXN_Details();
                FRM.isAction = this.isAction;
                FRM.ngaynhanmau = this.ngaynhanmau;
                Set4Object_Details();
                FRM.KHMAUOBJ = this.KHMAUOBJ;
                FRM.KHMAUCTXNOBJ = this.KHMAUCTXNOBJ;
                FRM.myFinished += this.finished;
                FRM.Show();
            }
            else
            {
                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.AutoCloseOptions.Delay = 3000;
                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                args.DefaultButtonIndex = 0;
                args.Caption = "Thông báo tự đóng ";
                args.Text = "Vui lòng click chọn dòng cần cập nhật. Thông báo này sẽ tự đóng sau 3 giây.";
                args.Buttons = new DialogResult[] { DialogResult.OK };
                XtraMessageBox.Show(args).ToString();
            }

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

            //throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Add2(object sender, ItemClickEventArgs e)
        {
            if (this.dxValidationProvider2.Validate() == true)
            {
                //isAction = "Add";
                state = MenuState.Insert;
                //Update :  DELEGATE
                // Gọi form Details
                //Diable form
                this.Enabled = false;
                //
                F_KHMau_CTXN_Details FRM = new F_KHMau_CTXN_Details();
                FRM.isAction = "Add";
                FRM.ngaynhanmau = this.ngaynhanmau;
                Set4Object_Details();
                FRM.KHMAUOBJ = this.KHMAUOBJ;
                FRM.KHMAUCTXNOBJ = this.KHMAUCTXNOBJ;
                FRM.myFinished += this.finished;
                FRM.Show();
            }
            else
            {
                IList<Control> IControls = this.dxValidationProvider2.GetInvalidControls();
                foreach (Control ctrl in IControls)
                    ctrl.Focus();
            }            
        }

        private void ItemClickEventHandler_Save(object sender, ItemClickEventArgs e)
        {
            if (txtKHMau.Text.Length > 0)
            {
                layoutControlGroup4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                //KH_Mau
                txtKHMau.ReadOnly = true;
                KHMAUOBJ.KHMau = txtKHMau.Text;
                Set4Object_Header();
                Set4Object_Details();
                KHMAUOBJ.ID = BUS1.KHMau_LABBUS_INSERT(KHMAUOBJ);
                txtID.Text = KHMAUOBJ.ID.ToString();
                gridControl1.DataSource = this.tbl_KHMau_CTXN_LABTableAdapter.FillBy(this.sYNC_NUTRICIELDataSet.tbl_KHMau_CTXN_LAB, txtKHMau.Text);
                isAction = "Edit";
            }
            //throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Close(object sender, ItemClickEventArgs e)
        {
            Is_close = true;
            //this.Close();
            //throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Update(object sender, ItemClickEventArgs e)
        {
            //throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Add(object sender, ItemClickEventArgs e)
        {
            //throw new NotImplementedException();
        }

        public void Set4Controls_Header()
        {
            txtSoPXN.Text = KHMAUOBJ.SoPXN;

            if (isAction == "Edit")
            {
                txtKHMau.Text = KHMAUOBJ.KHMau;
                txtID.Text = KHMAUOBJ.ID.ToString();
            }
        }

        public void Set4Controls_Details()
        {
            if (KHMAUOBJ.TrangThaiKHMau == true)
                chkHuyMau.CheckState = CheckState.Checked;
            else
                chkHuyMau.CheckState = CheckState.Unchecked;
            txtKHMau_KH.Text = KHMAUOBJ.KHMau_KhachHang;
            if (isAction == "Edit")
                txtID.Text = KHMAUOBJ.ID.ToString();
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
            if (txtSoPXN.Text.Substring(0, 3) == "H2O")
            {
                //XtraMessageBox.Show(txtSoPXN.Text.Substring(0, 3));
                GrdLoaiDongVat.Text = "";
                cmbMauNuoc.Text = KHMAUOBJ.LoaiDVMauNuoc;
                //XtraMessageBox.Show(KHMAUOBJ.LoaiDVMauNuoc);
            }
            else if (txtSoPXN.Text.Substring(0, 3) == "GEN" || txtSoPXN.Text.Substring(0, 3) == "HTH" || txtSoPXN.Text.Substring(0, 3) == "MDW")
            {
                //XtraMessageBox.Show(txtSoPXN.Text.Substring(0, 3));
                GrdLoaiDongVat.EditValue = KHMAUOBJ.LoaiDVMauNuoc;
                cmbMauNuoc.Text = "";
                //XtraMessageBox.Show(KHMAUOBJ.LoaiDVMauNuoc);
            }
            dteNgayLayMau.Text = KHMAUOBJ.NgayLayMau.ToString().Substring(0, 10);
            GrdLoaiMauGui.Text = KHMAUOBJ.LoaiMauGui;
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
            if (isAction == "Edit")
                KHMAUOBJ.ID = int.Parse(txtID.Text.ToString());
            KHMAUOBJ.SoPXN = txtSoPXN.Text;
        }

        public void Set4Object_Details()
        {
            //KHMAUCTXNOBJ

            if (isAction == "Edit" && gridView1.DataRowCount > 0)
            {
                KHMAUCTXNOBJ.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                KHMAUCTXNOBJ.SoLuongXN = gridView1.GetFocusedRowCellValue("SoLuongXN").ToString();
                KHMAUCTXNOBJ.CTXNID = int.Parse(gridView1.GetFocusedRowCellValue("CTXNID").ToString());
            }
            //else
            //KHMAUCTXNOBJ.ID = int.Parse(txtID.Text);
            if (chkHuyMau.CheckState == CheckState.Checked)
                KHMAUOBJ.TrangThaiKHMau = true;
            else
                KHMAUOBJ.TrangThaiKHMau = false;
            KHMAUOBJ.CreatedBy = user.Username;
            //KHMAUOBJ.CreatedDate
            KHMAUOBJ.KHMau_KhachHang = txtKHMau_KH.Text.Length == 0 ? "N/A" : txtKHMau_KH.Text;
            KHMAUOBJ.DonViKHMau = cmbDonViTinh.Text.ToString();
            KHMAUOBJ.Locked = cmbKhoa.Text.ToString() == "True" ? true : false;
            KHMAUOBJ.Note = txtNote.Text;
            KHMAUOBJ.NhanVienHuyKHMau = cmbNhanVienHuyMau.Text;
            KHMAUOBJ.NhanVienLuuKHMau = cmbNhanVienLuuMau.Text;
            KHMAUOBJ.PhuongPhapBaoQuan = cmbPhuongPhapBaoQuan.Text;
            KHMAUOBJ.SoLuongHuyKHMau = txtSoLuongHuy.Text.Length == 0 ? "0" : txtSoLuongHuy.Text;
            KHMAUOBJ.SoLuongKHMau = txtSoLuong.Text.Length == 0 ? "0" : txtSoLuong.Text;
            KHMAUOBJ.TaiLieuHuyKHMau = txtTaiLieuHuy.Text.Length == 0 ? "N/A" : txtTaiLieuHuy.Text;
            //KHMAUOBJ.TrangThaiKHMau
            KHMAUOBJ.VitriLuuKHMau = cmbViTriLuuMau.Text;
            //XtraMessageBox.Show(dteNgayHuyMau.Text.ToString());
            //KHMAUOBJ.NgayHuyKHMau = dteNgayHuyMau.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayHuyMau.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            if (isAction == "Add")
            {
                //XtraMessageBox.Show(dteNgayHuyMau.Text.ToString());
                if (dteNgayHuyMau.Text.ToString() == null || dteNgayHuyMau.Text.Length == 0)
                    KHMAUOBJ.NgayHuyKHMau = DateTime.Parse("2019-01-01");
                else
                    KHMAUOBJ.NgayHuyKHMau = DateTime.Parse(dteNgayHuyMau.Text.ToString(), CultureInfo.CreateSpecificCulture("en-GB"));

                if (dteNgayLuuMau.Text.ToString() == null || dteNgayLuuMau.Text.Length == 0)
                    KHMAUOBJ.NgayLuuKHMau = DateTime.Parse("2019-01-01");
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
            if (GrdLoaiDongVat.Text.Length == 0)
            {
                KHMAUOBJ.LoaiDVMauNuoc = cmbMauNuoc.Text;
            }
            else if (cmbMauNuoc.Text.Length == 0)
            {
                //KHMAUOBJ.LoaiDVMauNuoc = GrdLoaiDongVat.Text;
                KHMAUOBJ.LoaiDVMauNuoc = GrdLoaiDongVat.EditValue.ToString();
            }
            //XtraMessageBox.Show("GrdLoaiDongVat.Text.Length" + GrdLoaiDongVat.Text.Length);
            //XtraMessageBox.Show("cmbMauNuoc.Text.Length" + cmbMauNuoc.Text.Length);
            //XtraMessageBox.Show(KHMAUOBJ.LoaiDVMauNuoc);
            //KHMAUOBJ.LoaiDVMauNuoc = GrdLoaiDongVat.Text.Length == 0 ? cmbMauNuoc.Text : GrdLoaiMauGui.Text;

            //KHMAUOBJ.NgayLayMau = dteNgayLayMau.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayLayMau.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            if (dteNgayLayMau.Text.ToString() == null || dteNgayLayMau.Text.Length == 0 || dteNgayLayMau.Text.ToString().Substring(0, 10) == "01/01/0001")
                KHMAUOBJ.NgayLayMau = DateTime.Parse("2019-01-01");
            else
                KHMAUOBJ.NgayLayMau = DateTime.Parse(dteNgayLayMau.Text.ToString(), CultureInfo.CreateSpecificCulture("en-GB"));

            //KHMAUOBJ.LoaiMauGui             = GrdLoaiMauGui.Text.Length == 0 ? "nt" : GrdLoaiMauGui.Text;
            KHMAUOBJ.LoaiMauGui = GrdLoaiMauGui.EditValue.ToString().Length == 0 ? "N/A" : GrdLoaiMauGui.EditValue.ToString();
            KHMAUOBJ.TTMauGui = txtTTMauGui.Text.Length == 0 ? "N/A" : txtTTMauGui.Text;
            KHMAUOBJ.VTLayMauDayChuong = txtVTMauDayChuong.Text.Length == 0 ? "N/A" : txtVTMauDayChuong.Text;
            KHMAUOBJ.GioLayMauTuoi = txtGioLayMauTuoi.Text.Length == 0 ? "N/A" : txtGioLayMauTuoi.Text; ;
            KHMAUOBJ.Khac = txtKhac.Text;
            KHMAUOBJ.SoLuongKHMauKhongDat = txtSoLuongKhongDat.Text.Length == 0 ? "0" : txtSoLuongKhongDat.Text;
            KHMAUOBJ.LiDoKHMauKhongDat = txtLiDo.Text.Length == 0 ? "N/A" : txtLiDo.Text;
            KHMAUOBJ.Note = txtNote.Text;
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
            //Enable
            this.Enabled = true;
            //
            //Dong form DELEGATE
            //var frm = (Form)sender;
            var frm = (DevExpress.XtraEditors.XtraForm)sender;
            frm.Close();

            this.Visible = true;

            // Step 2 : Load lại data tren grid sau khi Add
            this.tbl_KHMau_CTXN_LABTableAdapter.FillBy(this.sYNC_NUTRICIELDataSet.tbl_KHMau_CTXN_LAB, KHMAUOBJ.KHMau);
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_LoaiMau_LAB' table. You can move, or remove it, as needed.
            this.tbl_LoaiMau_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_LoaiMau_LAB);
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_LoaiDV_LAB' table. You can move, or remove it, as needed.
            this.tbl_LoaiDV_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_LoaiDV_LAB);

            gridView1.BestFitColumns();
        }

        private void F_CUSTOMER_Details_Load(object sender, EventArgs e)
        {
            //if (isAction == "Edit")
            //{
            //}
            //else if (isAction == "Add")
            //{
            //}

            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_LoaiMau_LAB' table. You can move, or remove it, as needed.
            this.tbl_LoaiMau_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_LoaiMau_LAB);

            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_PhuongPhapBaoQuan_LAB' table. You can move, or remove it, as needed.
            this.tbl_PhuongPhapBaoQuan_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_PhuongPhapBaoQuan_LAB);

            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_MauNuoc_LAB' table. You can move, or remove it, as needed.
            this.tbl_MauNuoc_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_MauNuoc_LAB);

            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_MauNuoc_LAB' table. You can move, or remove it, as needed.
            this.tbl_MauNuoc_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_MauNuoc_LAB);

            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_LoaiDV_LAB' table. You can move, or remove it, as needed.
            this.tbl_LoaiDV_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_LoaiDV_LAB);

            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_KHMau_CTXN_LAB' table. You can move, or remove it, as needed.
            //this.tbl_KHMau_CTXN_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_KHMau_CTXN_LAB);
            //XtraMessageBox.Show(ngaynhanmau.ToString());
            this.tbl_ChiTieuXetNghiem_LAB_ByNgayNhanMauTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_ChiTieuXetNghiem_LAB_ByNgayNhanMau, ngaynhanmau.ToString());
        }
    }
}