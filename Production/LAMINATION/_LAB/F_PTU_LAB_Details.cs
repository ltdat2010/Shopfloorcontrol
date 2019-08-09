using System;
using System.Windows.Forms;
using System.IO;
using DevExpress.XtraEditors;
using System.Globalization;
using System.Data;
using DevExpress.XtraBars;
using System.Collections.Generic;

namespace Production.Class
{
    public partial class F_PTU_LAB_Details : frm_Base
    {
        public DateTime ngaynhanmau;
        string Path = Directory.GetCurrentDirectory();
        public string isAction = "";
        public string str_KHMau = "";
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
            
        
        public PTU_Header OBJ_PTUH = new PTU_Header();
        PTU_Lines OBJ_PTUL = new PTU_Lines();

        PTU_Header_BUS BUS_PTUH = new PTU_Header_BUS();
        PTU_Lines_BUS BUS_PTUL = new PTU_Lines_BUS();

        public F_PTU_LAB_Details()
        {
            InitializeComponent();
            Load += (s,e) =>
            {

                this.Width                      = Screen.PrimaryScreen.Bounds.Width * 2 / 5;
                this.Height                     = Screen.PrimaryScreen.Bounds.Height -30;


               
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


               
                
                this.Location = new System.Drawing.Point(Screen.PrimaryScreen.Bounds.Right - this.Width, 0);
                

                if (isAction == "Edit")
                {

                    gridControl1.DataSource = this.tbl_PTU_Lines_LABTableAdapter.FillBy_SoPTU(sYNC_NUTRICIELDataSet.tbl_PTU_Lines_LAB, txtSoPTU.Text);

                    layoutControlGroup4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    
                    //KH_Mau
                    
                    txtSoPTU.ReadOnly = true;
                    Set4Controls_Header();
                    Set4Controls_Details();

                    


                }
                else if (isAction == "Add")
                {
                    //txtKHMau.Text = this.str_KHMau;
                    Set4Controls_Header();
                    
                    txtSoPTU.ReadOnly = true;
                    
                    int suff_SoPTU = int.Parse(BUS_PTUH.Issued_SoPTU());

                    if (suff_SoPTU == 0)
                        txtSoPTU.Text = "TU"+DateTime.Now.Year.ToString().Substring(2, 2) + "." + "0001";
                    else if (suff_SoPTU <= 9 && suff_SoPTU > 0)
                    {
                        suff_SoPTU = suff_SoPTU + 1;
                        txtSoPTU.Text = "TU" + DateTime.Now.Year.ToString().Substring(2, 2) + "." + "000" + suff_SoPTU.ToString();
                    }
                    else if (suff_SoPTU <= 99 && suff_SoPTU > 9)
                    {
                        suff_SoPTU = suff_SoPTU + 1;
                        txtSoPTU.Text = "TU" + DateTime.Now.Year.ToString().Substring(2, 2) + "." + "00" + suff_SoPTU.ToString();
                    }
                    else if (suff_SoPTU <= 999 && suff_SoPTU > 99)
                    {
                        suff_SoPTU = suff_SoPTU + 1;
                        txtSoPTU.Text = "TU" + DateTime.Now.Year.ToString().Substring(2, 2) + "." + "0" + suff_SoPTU.ToString();
                    }

                    else if (suff_SoPTU <= 9999 && suff_SoPTU > 999)
                    {
                        suff_SoPTU = suff_SoPTU + 1;
                        txtSoPTU.Text = "TU" + DateTime.Now.Year.ToString().Substring(2, 2) + "." + suff_SoPTU.ToString();
                    }

                    txtID.ReadOnly = true;
                    layoutControlGroup4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    
                }
                //Khong tao moi thi huy form
                //btnSave.Enabled = true;
            };
                        

            lkeNhaCungCap.EditValueChanged += (s, e) =>
            {
                DataRowView row = lkeNhaCungCap.GetSelectedDataRow() as DataRowView;
                //OBJ_POL.CTXNDG = row["CTXNDG"].ToString();
                OBJ_PTUH.VENDCode= row["VENDCode"].ToString();
                OBJ_PTUH.VENDName= row["VENDName"].ToString();                
            };

            gridView1.RowClick += (s, e) =>
            {
                //KHMAUCTXNOBJ.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                gridViewRowClick = true;
                Set4Object_Details();
            };                        

           

            lkeNhaCungCap.ButtonClick += (s, e) =>
            {
                if (e.Button.Index == 1)
                {
                    
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
                Is_close = true;
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
            if (gridView1.RowCount > 0)
            {
                Set4Object_Details();
            }
            else
            {
                //this.Close();
            }
            Is_close = true;
        }

        private void ItemClickEventHandler_Update3(object sender, ItemClickEventArgs e)
        {
            Set4Object_Details();

            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            args.AutoCloseOptions.Delay = 3000;
            args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
            args.DefaultButtonIndex = 0;
            args.Caption = "Thông báo ";
            args.Text = "Cập nhật thành công. Thông báo này sẽ tự đóng sau 5 giây.";
            args.Buttons = new DialogResult[] { DialogResult.OK };
            XtraMessageBox.Show(args).ToString();

            Is_close = true;
        }

        private void ItemClickEventHandler_Add3(object sender, ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Delete2(object sender, ItemClickEventArgs e)
        {
            if (gridViewRowClick == true)
            {
                gridViewRowClick = false;
                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.AutoCloseOptions.Delay = 3000;
                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                args.DefaultButtonIndex = 0;
                args.Caption = "Thông báo ";
                args.Text = "Xóa thành công. Thông báo này sẽ tự đóng sau 3 giây.";
                args.Buttons = new DialogResult[] { DialogResult.OK };
                XtraMessageBox.Show(args).ToString();
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
            ////throw new NotImplementedException();
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
                F_PTU_Lines_Added_Row FRM = new F_PTU_Lines_Added_Row();
                FRM.isAction = this.isAction;
                FRM.ngaynhanmau = this.ngaynhanmau;
                Set4Object_Details();
                FRM.OBJ_PTUH = this.OBJ_PTUH;
                FRM.OBJ_PTUL = this.OBJ_PTUL;
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
            //isAction = "Add";
            state = MenuState.Insert;
            //Update :  DELEGATE
            // Gọi form Details
            //Diable form
            this.Enabled = false;
            //
            F_PTU_Lines_Added_Row FRM = new F_PTU_Lines_Added_Row();
            FRM.isAction = "Add";
            FRM.ngaynhanmau = this.ngaynhanmau;
            Set4Object_Details();
            FRM.OBJ_PTUH = this.OBJ_PTUH;
            FRM.OBJ_PTUL = this.OBJ_PTUL;
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

            //throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Save(object sender, ItemClickEventArgs e)
        {
            try
            {                
                Set4Object_Header();
                BUS_PTUH.PTU_Header_INSERT(OBJ_PTUH);
                //BUS_PTUH.Update_SoPO(OBJ_PTUH.SoPTU);
                
                layoutControlGroup4.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;

                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.AutoCloseOptions.Delay = 2000;
                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                args.DefaultButtonIndex = 0;
                args.Caption = "Thông báo ";
                args.Text = "Lưu thành công . Thông báo này sẽ tự đóng sau 1 giây.";
                args.Buttons = new DialogResult[] { DialogResult.OK };
                XtraMessageBox.Show(args).ToString();

                //Is_close = true;

                
            }
            catch(Exception ex)
            {
                throw new NotImplementedException();
            }
            
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
            txtSoPTU.Text = OBJ_PTUH.SoPTU;
            
            if (isAction == "Edit")
            {
                //txtKHMau.Text = KHMAUOBJ.KHMau;
                txtID.Text = OBJ_PTUH.ID.ToString();
            }          
        }

        public void Set4Controls_Details()
        {
                     
            //if(KHMAUOBJ.TrangThaiKHMau == true )            
            //    chkHuyMau.CheckState = CheckState.Checked;
            //else
            //    chkHuyMau.CheckState = CheckState.Unchecked;
            
            //txtKHMau_KH.Text = KHMAUOBJ.KHMau_KhachHang;
            if (isAction == "Edit")
                txtID.Text = OBJ_PTUH.ID.ToString();

            cmbKhoa.Text = OBJ_PTUH.Locked.ToString();
            txtNote.Text = OBJ_PTUH.Note;            
            //txtSoLuong.Text = KHMAUOBJ.SoLuongKHMau;
            //cmbDonViTinh.Text = KHMAUOBJ.DonViKHMau;
            //cmbDonViTinh.Text = KHMAUOBJ.DonViKHMau;
            //cmbNhanVienLuuMau.Text = KHMAUOBJ.NhanVienLuuKHMau;
            //cmbViTriLuuMau.Text = KHMAUOBJ.VitriLuuKHMau;
            //cmbPhuongPhapBaoQuan.Text = KHMAUOBJ.PhuongPhapBaoQuan;
            //dteNgayLuuMau.Text = KHMAUOBJ.NgayLuuKHMau.ToString().Substring(0, 10);
            //cmbNhanVienHuyMau.Text = KHMAUOBJ.NhanVienHuyKHMau;
            //txtTaiLieuHuy.Text = KHMAUOBJ.TaiLieuHuyKHMau;
            //dteNgayHuyMau.Text = KHMAUOBJ.NgayHuyKHMau.ToString().Substring(0, 10);
            //txtSoLuongHuy.Text = KHMAUOBJ.SoLuongHuyKHMau;
            //gridControl1.DataSource = this.tbl_KHMau_CTXN_LABTableAdapter.FillBy(this.sYNC_NUTRICIELDataSet.tbl_KHMau_CTXN_LAB, KHMAUOBJ.KHMau);
            ///////////////////////////////////////////////////////////////
            if (txtSoPTU.Text.Substring(0,3) == "H2O")
            {
                //XtraMessageBox.Show(txtSoPXN.Text.Substring(0, 3));
                lkeNhaCungCap.Text = "";
                //cmbMauNuoc.Text = KHMAUOBJ.LoaiDVMauNuoc;
                //XtraMessageBox.Show(KHMAUOBJ.LoaiDVMauNuoc);
            }
            else if (txtSoPTU.Text.Substring(0, 3) == "GEN" || txtSoPTU.Text.Substring(0, 3) == "HTH" || txtSoPTU.Text.Substring(0, 3) == "MDW")
            {
                //XtraMessageBox.Show(txtSoPXN.Text.Substring(0, 3));
                //GrdLoaiDongVat.EditValue = OBJ_POH.LoaiDVMauNuoc;
                //cmbMauNuoc.Text = "";
                //XtraMessageBox.Show(KHMAUOBJ.LoaiDVMauNuoc);
            }
            
            dteNgayLapPO.Text = OBJ_PTUH.NgayLapPhieu.ToString().Substring(0, 10);
            //GrdLoaiMauGui.Text = KHMAUOBJ.LoaiMauGui;
            //txtTTMauGui.Text = KHMAUOBJ.TTMauGui;
            //txtVTMauDayChuong.Text = KHMAUOBJ.VTLayMauDayChuong;
            //txtGioLayMauTuoi.Text = KHMAUOBJ.GioLayMauTuoi;
            //txtKHMau.Text = KHMAUOBJ.KHMau;
            //txtKhac.Text = KHMAUOBJ.Khac;
            //txtSoLuongKhongDat.Text = KHMAUOBJ.SoLuongKHMauKhongDat;
            //txtLiDo.Text = KHMAUOBJ.LiDoKHMauKhongDat;

        }

        public void Set4Object_Header()
        {
            //KHMAUOBJ.KHMau = txtKHMau.Text;
            //XtraMessageBox.Show(isAction);
            if( isAction == "Edit")
                OBJ_PTUH.ID = int.Parse(txtID.Text.ToString()) ;

            OBJ_PTUH.SoPTU= txtSoPTU.Text;

            if (dteNgayLapPO.Text.ToString() == null || dteNgayLapPO.Text.Length == 0)
                OBJ_PTUH.NgayLapPhieu = DateTime.Parse("2019-01-01");

            else
                OBJ_PTUH.NgayLapPhieu = DateTime.Parse(dteNgayLapPO.Text.ToString(), CultureInfo.CreateSpecificCulture("en-GB"));

            if (dteNgayGiaoHang.Text.ToString() == null || dteNgayGiaoHang.Text.Length == 0)
                OBJ_PTUH.NgayTamUng = DateTime.Parse("2019-01-01");

            else
                OBJ_PTUH.NgayTamUng = DateTime.Parse(dteNgayGiaoHang.Text.ToString(), CultureInfo.CreateSpecificCulture("en-GB"));

            //OBJ_POH.NgayLapPO = DateTime.Parse(row["NgayLapPO"].ToString(), CultureInfo.CreateSpecificCulture("en-GB"));
            //OBJ_POH.NgayGiaoHang = DateTime.Parse(row["NgayGiaoHang"].ToString(), CultureInfo.CreateSpecificCulture("en-GB"));
            if(chkCK.CheckState == CheckState.Checked)
                OBJ_PTUH.PaymentTerm = "CK";
            else if ( chkTM.CheckState == CheckState.Checked)
                OBJ_PTUH.PaymentTerm = "TM";



            //row["PaymentTerm"].ToString();
            //OBJ_POH.SoPO = row["SoPO"].ToString();
            OBJ_PTUH.NoiDung = txtNoiDung.Text;
            OBJ_PTUH.CreatedBy = user.Username; //row["CreatedBy"].ToString();
            OBJ_PTUH.Note = txtNote.Text ; //row["Note"].ToString();
            //OBJ_POH.CreatedDate = DateTime.Parse(row["CreatedDate"].ToString(), CultureInfo.CreateSpecificCulture("en-GB"));
            OBJ_PTUH.Locked = cmbKhoa.Text.ToString() == "True" ? true : false;   //row["Locked"].ToString() == "True" ? true : false;

        }

        public void Set4Object_Details()
        {
            //KHMAUCTXNOBJ
            
            if (isAction == "Edit" && gridView1.DataRowCount > 0)
            {
                OBJ_PTUL.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                OBJ_PTUL.SoPTU = gridView1.GetFocusedRowCellValue("SoPTU").ToString();
                //OBJ_POL.CTXNID = int.Parse(gridView1.GetFocusedRowCellValue("CTXNID").ToString());
            }
            //else
            //KHMAUCTXNOBJ.ID = int.Parse(txtID.Text);


            //if (chkHuyMau.CheckState == CheckState.Checked)
            //    KHMAUOBJ.TrangThaiKHMau = true;
            //else
            //    KHMAUOBJ.TrangThaiKHMau = false;

            OBJ_PTUH.CreatedBy = user.Username;
            //KHMAUOBJ.CreatedDate
            //KHMAUOBJ.KHMau_KhachHang = txtKHMau_KH.Text.Length == 0 ? "nt" : txtKHMau_KH.Text; 
            //KHMAUOBJ.DonViKHMau = cmbDonViTinh.Text.ToString();
            OBJ_PTUH.Locked = cmbKhoa.Text.ToString() == "True" ? true : false;
            OBJ_PTUH.Note = txtNote.Text;
            //KHMAUOBJ.NhanVienHuyKHMau = cmbNhanVienHuyMau.Text;
            //KHMAUOBJ.NhanVienLuuKHMau = cmbNhanVienLuuMau.Text;
            //KHMAUOBJ.PhuongPhapBaoQuan = cmbPhuongPhapBaoQuan.Text;
            //KHMAUOBJ.SoLuongHuyKHMau = txtSoLuongHuy.Text.Length == 0 ? "0": txtSoLuongHuy.Text;
            //KHMAUOBJ.SoLuongKHMau = txtSoLuong.Text.Length == 0 ? "0" : txtSoLuong.Text;
            //KHMAUOBJ.TaiLieuHuyKHMau = txtTaiLieuHuy.Text.Length == 0 ? "nt" : txtTaiLieuHuy.Text;
            //KHMAUOBJ.TrangThaiKHMau
            //KHMAUOBJ.VitriLuuKHMau = cmbViTriLuuMau.Text;
            //XtraMessageBox.Show(dteNgayHuyMau.Text.ToString());
            //KHMAUOBJ.NgayHuyKHMau = dteNgayHuyMau.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayHuyMau.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            //if(isAction == "Add")
            //{
            //    //XtraMessageBox.Show(dteNgayHuyMau.Text.ToString());
            //    if (dteNgayHuyMau.Text.ToString() == null || dteNgayHuyMau.Text.Length == 0)
            //        KHMAUOBJ.NgayHuyKHMau = DateTime.Parse("2019-01-01");

            //    else
            //        KHMAUOBJ.NgayHuyKHMau = DateTime.Parse(dteNgayHuyMau.Text.ToString(), CultureInfo.CreateSpecificCulture("en-GB"));

            //    if (dteNgayLuuMau.Text.ToString() == null || dteNgayLuuMau.Text.Length == 0 )
            //        KHMAUOBJ.NgayLuuKHMau = DateTime.Parse("2019-01-01");

            //    else
            //        KHMAUOBJ.NgayLuuKHMau = DateTime.Parse(dteNgayLuuMau.Text.ToString(), CultureInfo.CreateSpecificCulture("en-GB"));
            //}
            //else
            //{
            //    KHMAUOBJ.NgayHuyKHMau = DateTime.Parse(dteNgayHuyMau.Text.ToString(), CultureInfo.CreateSpecificCulture("en-GB"));
            //    KHMAUOBJ.NgayLuuKHMau = DateTime.Parse(dteNgayLuuMau.Text.ToString(), CultureInfo.CreateSpecificCulture("en-GB"));

            //}
            //XtraMessageBox.Show(KHMAUOBJ.NgayHuyKHMau.ToString());
            //KHMAUOBJ.NgayLuuKHMau = dteNgayLuuMau.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayLuuMau.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            //KHMAUOBJ.NgayLuuKHMau = dteNgayLuuMau.Text== null || dteNgayLuuMau.Text.ToString().Substring(0, 10) == "01/01/0001" || dteNgayLuuMau.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayLuuMau.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            /////////////////////////////////////////
            //if (GrdLoaiDongVat.Text.Length == 0)
            //{
            //    KHMAUOBJ.LoaiDVMauNuoc = cmbMauNuoc.Text;
            //}
            //else if (cmbMauNuoc.Text.Length == 0)
            //{
            //    //KHMAUOBJ.LoaiDVMauNuoc = GrdLoaiDongVat.Text;
            //    KHMAUOBJ.LoaiDVMauNuoc = GrdLoaiDongVat.EditValue.ToString();
            //}
            //XtraMessageBox.Show("GrdLoaiDongVat.Text.Length" + GrdLoaiDongVat.Text.Length);
            //XtraMessageBox.Show("cmbMauNuoc.Text.Length" + cmbMauNuoc.Text.Length);
            //XtraMessageBox.Show(KHMAUOBJ.LoaiDVMauNuoc);
            //KHMAUOBJ.LoaiDVMauNuoc = GrdLoaiDongVat.Text.Length == 0 ? cmbMauNuoc.Text : GrdLoaiMauGui.Text;

            //KHMAUOBJ.NgayLayMau = dteNgayLayMau.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayLayMau.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            //if (dteNgayLapPO.Text.ToString() == null || dteNgayLapPO.Text.Length == 0 || dteNgayLapPO.Text.ToString().Substring(0, 10) == "01/01/0001")
            //    KHMAUOBJ.NgayLayMau = DateTime.Parse("2019-01-01");            
            //else
            //    KHMAUOBJ.NgayLayMau = DateTime.Parse(dteNgayLapPO.Text.ToString(), CultureInfo.CreateSpecificCulture("en-GB"));

            //KHMAUOBJ.LoaiMauGui             = GrdLoaiMauGui.Text.Length == 0 ? "nt" : GrdLoaiMauGui.Text;
            //KHMAUOBJ.LoaiMauGui             = GrdLoaiMauGui.EditValue.ToString().Length == 0 ? "nt" : GrdLoaiMauGui.EditValue.ToString();
            //KHMAUOBJ.TTMauGui               = txtTTMauGui.Text.Length == 0 ? "nt" : txtTTMauGui.Text;
            //KHMAUOBJ.VTLayMauDayChuong      = txtVTMauDayChuong.Text.Length == 0 ? "nt" : txtVTMauDayChuong.Text; 
            //KHMAUOBJ.GioLayMauTuoi          = txtGioLayMauTuoi.Text.Length == 0 ? "nt" : txtGioLayMauTuoi.Text; ;
            //KHMAUOBJ.Khac                   = txtKhac.Text;
            //KHMAUOBJ.SoLuongKHMauKhongDat   = txtSoLuongKhongDat.Text.Length == 0 ? "0" : txtSoLuongKhongDat.Text ;
            //KHMAUOBJ.LiDoKHMauKhongDat      = txtLiDo.Text.Length == 0 ? "nt" : txtLiDo.Text;
            OBJ_PTUH.Note                   = txtNote.Text;
        }


        public void ResetControl()
        {            
            //lkeMaDN.Text = "";
            //txtTenDN.Text = "";
            //txtKHMau.Text = "";
            //txtSoLuong.Text = "";
            //cmbDonViTinh.Text = "";
            //lkeCTXN.Text = "";
            cmbKhoa.Text = "";
            //lkePPXNID.EditValue = null;
            txtNote.Text = "";
        }
        //
        public void ControlsReadOnly(bool bl)
        {            
            //txtKHMau.ReadOnly = bl;
            //txtSoLuong.ReadOnly = bl;
            //cmbDonViTinh.ReadOnly = bl;
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
            //this.tbl_KHMau_CTXN_LABTableAdapter.FillBy(this.sYNC_NUTRICIELDataSet.tbl_KHMau_CTXN_LAB,KHMAUOBJ.KHMau);
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_LoaiMau_LAB' table. You can move, or remove it, as needed.
            //this.tbl_LoaiMau_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_LoaiMau_LAB);
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_LoaiDV_LAB' table. You can move, or remove it, as needed.
            //this.tbl_LoaiDV_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_LoaiDV_LAB);
            this.tbl_PTU_Lines_LABTableAdapter.FillBy_SoPTU(sYNC_NUTRICIELDataSet.tbl_PTU_Lines_LAB, txtSoPTU.Text);

            gridView1.BestFitColumns();
        }
        private void F_CUSTOMER_Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_Dept' table. You can move, or remove it, as needed.
            this.tbl_DeptTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_Dept);
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_PTU_Lines_LAB' table. You can move, or remove it, as needed.
            this.tbl_PTU_Lines_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_PTU_Lines_LAB);
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.V_VENDOR' table. You can move, or remove it, as needed.
            this.v_VENDORTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.V_VENDOR);

            //if (isAction == "Edit")
            //{

            //}
            //else if (isAction == "Add")
            //{

            //}

            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_LoaiMau_LAB' table. You can move, or remove it, as needed.
            //this.tbl_LoaiMau_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_LoaiMau_LAB);

            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_PhuongPhapBaoQuan_LAB' table. You can move, or remove it, as needed.
            //this.tbl_PhuongPhapBaoQuan_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_PhuongPhapBaoQuan_LAB);

              // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_MauNuoc_LAB' table. You can move, or remove it, as needed.
            //this.tbl_MauNuoc_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_MauNuoc_LAB);

            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_MauNuoc_LAB' table. You can move, or remove it, as needed.
            //this.tbl_MauNuoc_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_MauNuoc_LAB);

            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_LoaiDV_LAB' table. You can move, or remove it, as needed.
            //this.tbl_LoaiDV_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_LoaiDV_LAB);

            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_KHMau_CTXN_LAB' table. You can move, or remove it, as needed.
            //this.tbl_KHMau_CTXN_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_KHMau_CTXN_LAB);            

            //this.tbl_ChiTieuXetNghiem_LAB_ByNgayNhanMauTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_ChiTieuXetNghiem_LAB_ByNgayNhanMau, ngaynhanmau.ToString());

        }
    }
    
}
