using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using CrystalDecisions.Windows.Forms;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Net.Mail;
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_PXN_Details : frm_Base
    {
        #region Variables

        private int ImageID = 0;
        private String strFilePath = "";
        private Image DefaultImage;
        private Byte[] ImageByteArray;

        #endregion Variables

        private bool gridViewRowClick = false;
        private bool gridViewRowClick2 = false;
        private bool chkSendMail_status = false;
        private string isChanged = "";
        private string Path = Directory.GetCurrentDirectory();
        public int gridRow = 0;

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
                }
            }
        }

        //NEW : Phan khai bao cho KH Mau
        public KHMau_LAB KHMAUOBJ = new KHMau_LAB();

        private KHMau_LABBUS KHMauBUS = new KHMau_LABBUS();
        private KHMau_CTXN_LABBUS KHMauCTXNBUS = new KHMau_CTXN_LABBUS();

        public PXN_Header OBJ = new PXN_Header();
        private PXN_Details OBJ1 = new PXN_Details();

        private PXN_HeaderBUS BUS = new PXN_HeaderBUS();
        private PXN_DetailsBUS BUS1 = new PXN_DetailsBUS();
        private KHMau_LABBUS BUS2 = new KHMau_LABBUS();

        //Shcedule
        private Resources RSRC = new Resources();

        private ResourcesBUS RSRCBUS = new ResourcesBUS();

        private List<bool> LstBool = new List<bool>();

        public F_PXN_Details()
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
                action_EndForm1.View_Status(false);
                action_EndForm1.Close_Status(true);

                action_EndForm2.Add_Status(true);
                action_EndForm2.Delete_Status(true);
                action_EndForm2.Update_Status(true);
                action_EndForm2.Save_Status(true);
                action_EndForm2.View_Status(false);
                action_EndForm2.Close_Status(false);

                action_EndForm3.Add_Status(false);
                action_EndForm3.Delete_Status(false);
                action_EndForm3.Update_Status(false);
                action_EndForm3.Save_Status(true);
                action_EndForm3.View_Status(false);
                action_EndForm3.Close_Status(true);

                btnSendMail.Enabled = false;
                //MessageBox.Show(isAction);
                if (isAction == "Edit")
                {
                    Set4Controls();
                    TDControlsReadOnly(false);
                    //XtraMessageBox.Show("Edit SoPXN :" + txtSoPXN.Text);
                    gridControl2.DataSource = this.tbl_KHMau_LABTableAdapter.FillBy(this.sYNC_NUTRICIELDataSet.tbl_KHMau_LAB, txtSoPXN.Text);
                    for (int i = 0; i < gridView2.DataRowCount; i++)
                        LstBool.Add(bool.Parse(gridView2.GetRowCellValue(i, "KetQua").ToString() == "1" ? "true" : "false"));
                }
                else if (isAction == "Add")
                {
                    xtraTabControl1.Enabled = false;
                    txtNote.ReadOnly = true;
                    cmbKhoa.ReadOnly = true;
                    txtSendMail.ReadOnly = true;
                    //dteNgayCoKetQua.ReadOnly            = true;
                    dteNgayTraKetQua.ReadOnly = true;
                    TDControlsReadOnly(true);
                    txtID.ReadOnly = true;
                    txtSendMail.Text = OBJ.SendMail = "0";
                }
                gridControl3.DataSource = KHMauBUS.KHMau_LABDAO_REPORT_STORAGE(KHMAUOBJ.SoPXN);
                gridView3.BestFitColumns();

                gridControl4.DataSource = KHMauBUS.KHMau_LABDAO_REPORT_DETROY(KHMAUOBJ.SoPXN);
                gridView4.BestFitColumns();
            };

            gridView2.RowClick += (s, e) =>
            {
                gridViewRowClick2 = true;
                Set4ObjectKHMau();
            };

            chkSendMail.CheckStateChanged += (s, e) =>
            {
                if (chkSendMail.CheckState == CheckState.Checked)
                {
                    if (txtEmailCoSoGuiMau.Text.Length == 0)
                    {
                        chkSendMail_status = false;
                        btnSendMail.Enabled = false;
                        //Khong co email nhan vien gui mau thi khong cho gui
                        //MessageBox.Show("Email đã được gởi đến khách hàng.Trong trường hợp email bị lỗi bạn sẽ thấy thông báo lỗi trong mục Send của OutLook .");
                        XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                        args.AutoCloseOptions.Delay = 2000;
                        args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                        args.DefaultButtonIndex = 0;
                        args.Caption = "Lưu ý ";
                        args.Text = "Email người nhận không được bỏ trống. Thông báo này sẽ tự đóng sau 2 giây.";
                        args.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Cancel };
                        XtraMessageBox.Show(args).ToString();
                    }
                    else if (gridView2.RowCount == 0)
                    {
                        chkSendMail_status = false;
                        btnSendMail.Enabled = false;
                        //Khong co email nhan vien gui mau thi khong cho gui
                        //MessageBox.Show("Email đã được gởi đến khách hàng.Trong trường hợp email bị lỗi bạn sẽ thấy thông báo lỗi trong mục Send của OutLook .");
                        XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                        args.AutoCloseOptions.Delay = 2000;
                        args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                        args.DefaultButtonIndex = 0;
                        args.Caption = "Lưu ý ";
                        args.Text = "Không có kí hiệu mẫu. Thông báo này sẽ tự đóng sau 2 giây.";
                        args.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Cancel };
                        XtraMessageBox.Show(args).ToString();
                    }
                    else if (txtEmailCoSoGuiMau.Text.Length > 0 && gridView2.RowCount > 0)
                    {
                        chkSendMail_status = true;
                        btnSendMail.Enabled = true;
                    }
                }
                else
                {
                    chkSendMail_status = false;
                    btnSendMail.Enabled = false;
                }
            };

            btnSendMail.Click += (s, e) =>
            {
                //Kiểm tra xem user có check gửi mail không

                DialogResult dlDel = XtraMessageBox.Show(" Bạn muốn gởi mail tới người nhận :" + txtEmailCoSoGuiMau.Text + " . Lưu ý hệ thống sẽ tiến hành gởi mail và không thể recall mail lại sau khi gởi", "Gởi mail", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlDel == DialogResult.Yes)
                {
                    string filename = "PhieuXetNghiem" + txtSoPXN.Text;
                    if (OBJ.SendMail == "0")
                    {
                        Export2Pdf(filename);
                        SendMail(txtEmailCoSoGuiMau.Text, "Vipha.Lab : Phiếu xét nghiệm số " + txtSoPXN.Text + " ( Mới )", filename);
                    }
                    else if (OBJ.SendMail != "0")
                    {
                        Export2Pdf(filename);
                        SendMail(txtEmailCoSoGuiMau.Text, "Vipha.Lab : Phiếu xét nghiệm số " + txtSoPXN.Text + " ( Cập nhật )", filename);
                    }
                }
                else
                {
                    XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                    args.AutoCloseOptions.Delay = 2000;
                    args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                    args.DefaultButtonIndex = 0;
                    args.Caption = "Hủy mail ";
                    args.Text = "Mail gởi đã hủy.";
                    args.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Cancel };
                    XtraMessageBox.Show(args).ToString();
                }
            };
            //Tra ket qua cho kach hang
            //Chi khi tat ca cac dong co gia tri cua TraKetQua = true thi moi xu ly
            btnTraKetQua.Click += (s, e) =>
            {
                if (LstBool.Contains(false) != true)
                {
                    DialogResult dlDel = XtraMessageBox.Show(" Bạn muốn xuất kết quả ? . Lưu ý hệ thống sẽ ghi nhận hôm nay là ngày trả kết quả cho khách hàng", "Trả kết quả", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlDel == DialogResult.Yes)
                    {
                        BUS.PXN_HeaderDAO_UPDATE_NgayTraKetQua(txtSoPXN.Text);
                        if (txtSoPXN.Text.Substring(0, 3) == "MDW")
                        {
                            R_MYCOTOXIN_RESULT_LAB_ANALYSISREPORT FRM = new R_MYCOTOXIN_RESULT_LAB_ANALYSISREPORT();
                            FRM.SoPXN = this.OBJ.SoPXN;
                            FRM.Show();
                        }
                    }
                }
                else
                {
                    XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                    args.AutoCloseOptions.Delay = 2000;
                    args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                    args.DefaultButtonIndex = 0;
                    args.Caption = "Trả kết quả ";
                    args.Text = "Một số chỉ tiêu chưa có kết quả, vui lòng cập nhật và thử lại .";
                    args.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Cancel };
                    XtraMessageBox.Show(args).ToString();
                }
            };

            gridView2.RowClick += (s, e) =>
            {
                gridViewRowClick = true;
                Set4ObjectKHMau();
            };

            gridView2.InitNewRow += (s, e) =>
            {
                gridViewRowClick = true;
            };

            //this.FormClosed += (s, e) =>
            //{
            //};

            txtNote.TextChanged += (s, e) =>
            {
                if (isAction == "Edit" || isChanged == "Changed")
                    //btnSave.Enabled = true;
                    isChanged = "Changed";
            };

            cmbKhoa.TextChanged += (s, e) =>
            {
                if (isAction == "Edit" || isChanged == "Changed")
                    // btnSave.Enabled = true;
                    isChanged = "Changed";
            };

            chkGEN.CheckedChanged += (s, e) =>
             {
                 if (chkGEN.CheckState == CheckState.Checked)
                 {
                     dteNgayNhanMau.ReadOnly = false;
                     //TDControlsReadOnly(false);
                     chkH2O.CheckState = CheckState.Unchecked;
                     chkHTH.CheckState = CheckState.Unchecked;
                     chkMDW.CheckState = CheckState.Unchecked;
                     //cmbLoaiDV
                     //layoutControlItem30.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always ;
                     //layoutControlItem30.Text = "Loại động vật";
                     ////cmbMauNuoc
                     //layoutControlItem39.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                     //layoutControlItem39.Text = "Mẫu nước";
                 }
                 if (isAction == "Add")
                 {
                     OBJ.LoaiXN = "GEN";
                     txtSoPXN.Text = Func_SoPXN_NPT(BUS.Result_PXN_Header_SoPXN(OBJ.LoaiXN));
                 }
             };

            chkHTH.CheckedChanged += (s, e) =>
            {
                if (chkHTH.CheckState == CheckState.Checked)
                {
                    dteNgayNhanMau.ReadOnly = false;
                    //TDControlsReadOnly(false);
                    chkH2O.CheckState = CheckState.Unchecked;
                    chkGEN.CheckState = CheckState.Unchecked;
                    chkMDW.CheckState = CheckState.Unchecked;
                    ////cmbLoaiDV
                    //layoutControlItem30.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    //layoutControlItem30.Text = "Loại động vật";
                    ////cmbMauNuoc
                    //layoutControlItem39.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    //layoutControlItem39.Text = "Mẫu nước";
                }

                if (isAction == "Add")
                {
                    OBJ.LoaiXN = "HTH";
                    txtSoPXN.Text = Func_SoPXN_NPT(BUS.Result_PXN_Header_SoPXN(OBJ.LoaiXN));
                }
            };

            chkH2O.CheckedChanged += (s, e) =>
            {
                if (chkH2O.CheckState == CheckState.Checked)
                {
                    dteNgayNhanMau.ReadOnly = false;
                    //TDControlsReadOnly(false);
                    chkGEN.CheckState = CheckState.Unchecked;
                    chkHTH.CheckState = CheckState.Unchecked;
                    chkMDW.CheckState = CheckState.Unchecked;
                    ////cmbLoaiDV
                    //layoutControlItem30.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    //layoutControlItem30.Text = "Loại động vật";
                    ////cmbMauNuoc
                    //layoutControlItem39.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    //layoutControlItem39.Text = "Mẫu nước";
                }
                if (isAction == "Add")
                {
                    OBJ.LoaiXN = "H2O";
                    txtSoPXN.Text = Func_SoPXN_NPT(BUS.Result_PXN_Header_SoPXN(OBJ.LoaiXN));
                }
            };

            chkMDW.CheckedChanged += (s, e) =>
            {
                if (chkMDW.CheckState == CheckState.Checked)
                {
                    dteNgayNhanMau.ReadOnly = false;
                    //TDControlsReadOnly(false);

                    chkGEN.CheckState = CheckState.Unchecked;
                    chkHTH.CheckState = CheckState.Unchecked;
                    chkH2O.CheckState = CheckState.Unchecked;
                    ////cmbLoaiDV
                    //layoutControlItem30.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
                    //layoutControlItem30.Text = "Loại động vật";

                    ////cmbMauNuoc
                    //layoutControlItem39.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
                    //layoutControlItem39.Text = "Mẫu nước";
                }
                if (isAction == "Add")
                {
                    OBJ.LoaiXN = "MDW";
                    txtSoPXN.Text = Func_SoPXN_NPT(BUS.Result_PXN_Header_SoPXN(OBJ.LoaiXN));
                }
            };

            chkPTN.CheckedChanged += (s, e) =>
            {
                if (chkPTN.CheckState == CheckState.Checked)
                {
                    chkPTN.CheckState = CheckState.Checked;
                    chkNTP.CheckState = CheckState.Unchecked;
                }
                else
                {
                    chkPTN.CheckState = CheckState.Unchecked;
                    chkNTP.CheckState = CheckState.Checked;
                }
            };

            chkNTP.CheckedChanged += (s, e) =>
            {
                if (chkNTP.CheckState == CheckState.Checked)
                {
                    chkNTP.CheckState = CheckState.Checked;
                    chkPTN.CheckState = CheckState.Unchecked;
                }
                else
                {
                    chkNTP.CheckState = CheckState.Unchecked;
                    chkPTN.CheckState = CheckState.Checked;
                }
            };

            dteNgayNhanMau.EditValueChanged += (s, e) =>
            {
                dteNgayDukienTra.ReadOnly = false;
            };

            dteNgayDukienTra.EditValueChanged += (s, e) =>
            {
                TDControlsReadOnly(false);
            };

            //Cập nhật ngày có kết quả --- Tạm chờ làm phần kết quả
            //dteNgayCoKetQua.ButtonClick += (s, e) =>
            //{
            //    if (e.Button.Index == 1)
            //    {
            //        if (dteNgayCoKetQua.Properties.ReadOnly == false)
            //        {
            //            if (dteNgayCoKetQua.Text != "2019-01-01")
            //                BUS.PXN_HeaderDAO_UPDATE_NgayCoKetQua(OBJ.ID, DateTime.Parse(dteNgayCoKetQua.Text, CultureInfo.CreateSpecificCulture("en-GB")),true);
            //            //OBJ.NgayCoKetQua = dteNgayCoKetQua.Text.Length == 0 ? DateTime.Parse("2019-01-01") : DateTime.Parse(dteNgayCoKetQua.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            //            else
            //            {
            //                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            //                args.AutoCloseOptions.Delay = 2000;
            //                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
            //                args.DefaultButtonIndex = 0;
            //                args.Caption = "Lưu ý ";
            //                args.Text = "Vui lòng chọn ngày có kết quả. Thông báo này sẽ tự đóng sau 2 giây.";
            //                args.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Cancel };
            //                XtraMessageBox.Show(args).ToString();
            //            }
            //        }
            //    }
            //};

            //Cập nhật ngày đã trả kết quả --- Tạm chờ làm phần kết quả
            //dteNgayTraKetQua.ButtonClick += (s, e) =>
            //{
            //    if (e.Button.Index == 1)
            //    {
            //        if (dteNgayTraKetQua.Properties.ReadOnly == false)
            //        {
            //            if (dteNgayTraKetQua.Text != "2019-01-01")
            //                BUS.PXN_HeaderDAO_UPDATE_NgayTraKetQua(OBJ.ID, DateTime.Parse(dteNgayTraKetQua.Text, CultureInfo.CreateSpecificCulture("en-GB")),true);
            //            //OBJ.NgayCoKetQua = dteNgayCoKetQua.Text.Length == 0 ? DateTime.Parse("2019-01-01") : DateTime.Parse(dteNgayCoKetQua.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            //            else
            //            {
            //                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            //                args.AutoCloseOptions.Delay = 2000;
            //                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
            //                args.DefaultButtonIndex = 0;
            //                args.Caption = "Lưu ý ";
            //                args.Text = "Vui lòng chọn ngày trả kết quả. Thông báo này sẽ tự đóng sau 2 giây.";
            //                args.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Cancel };
            //                XtraMessageBox.Show(args).ToString();
            //            }
            //        }
            //    }
            //};

            lkeTenCoSoGuiMau.ButtonClick += (s, e) =>
            {
                if (e.Button.Index == 1)
                {
                    //Disable
                    this.Enabled = false;
                    //
                    F_EMPLOYEE_Details F_EMP_Dtl = new Class.F_EMPLOYEE_Details();
                    F_EMP_Dtl.isAction = "Add";
                    //F_EMP_Dtl.EMP = this.EMP;
                    F_EMP_Dtl.myFinished += this.finished;
                    F_EMP_Dtl.Show();
                }
            };

            lkeTenCoSoLayMau.ButtonClick += (s, e) =>
            {
                if (e.Button.Index == 1)
                {
                    //Disable
                    this.Enabled = false;
                    //
                    F_CUSTOMER_Details F_CUS_Dtl = new Class.F_CUSTOMER_Details();
                    F_CUS_Dtl.isAction = this.isAction;
                    //F_CUS_Dtl.CUS = this.CUS;
                    F_CUS_Dtl.myFinished += this.finished;
                    F_CUS_Dtl.Show();
                }
            };

            lkeTenCoSoGuiMau.EditValueChanged += (s, e) =>
            {
                DataRowView rowView = (DataRowView)lkeTenCoSoGuiMau.GetSelectedDataRow();
                DataRow row = rowView.Row;
                txtPhoneCoSoGuiMau.Text = row["EMPMobile"].ToString();
                txtEmailCoSoGuiMau.Text = row["EMPEmail"].ToString();
                /////////////////////
                OBJ.MaCoSoGuiMau = row["EMPCode"].ToString();
                OBJ.EMPCode_ID = int.Parse(row["Id"].ToString());

                this.tbl_CUSTOMER_LABTableAdapter.FillByEMPCode(sYNC_NUTRICIELDataSet.tbl_CUSTOMER_LAB, lkeTenCoSoGuiMau.EditValue.ToString());
            };

            lkeTenCoSoLayMau.EditValueChanged += (s, e) =>
            {
                DataRowView rowView = (DataRowView)lkeTenCoSoLayMau.GetSelectedDataRow();
                DataRow row = rowView.Row;
                txtDCCoSoLayMau.Text = row["CUSTADDRESS"].ToString();
                txtEmailCoSoLayMau.Text = row["ContactEmail"].ToString();
                txtPhoneCoSoLayMau.Text = row["CUSTPHONE"].ToString();
                ///////////////////
                OBJ.MaCoSoLayMau = row["CUSTCODE"].ToString();
                OBJ.CUSTCODE_ID = int.Parse(row["Id"].ToString());
            };

            //Action_EndForm
            action_EndForm1.Add(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Add));
            action_EndForm1.Update(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Update));
            action_EndForm1.Close(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Close));
            action_EndForm1.Save(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Save));

            //Action_EndForm KHMau
            action_EndForm2.Add(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Add_KHMau));
            action_EndForm2.Update(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Update_KHMau));
            action_EndForm2.Delete(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Delete_KHMau));
            //action_EndForm2.Save(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Save_KHMau));
            //Action_EndForm Form
            //action_EndForm3.Add(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Add3));
            //action_EndForm3.Update(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Update3));
            action_EndForm3.Close(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Close3));
            action_EndForm3.Save(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Save3));

            // 7 Add hoặc New
            //actionMini1.Add(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Add));

            // 8 Lưu
            //actionMini1.Save(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Save));

            // 9 Edit hoặc Update
            //actionMini1.Edit(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Edit));

            // 10 Del
            //actionMini1.Delete(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Delete));

            // 10a View
            //actionMini1.View(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_View));

            // 10B Cancel
            // actionMini1.Close(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Close));
        }

        private void ItemClickEventHandler_Close3(object sender, ItemClickEventArgs e)
        {
            Set4ObjectHeader();
            //Set4ObjectRow();
            //Khong cho update Header
            //XtraMessageBox.Show(OBJ.SoPXN);
            BUS.PXN_HeaderBUS_UPDATE(OBJ);
            Is_close = true;
            //this.Close();
            //throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Save3(object sender, ItemClickEventArgs e)
        {
            if (this.dxValidationProvider2.Validate() == true)
            {
                Set4ObjectHeader();
                //Set4ObjectRow();
                //Khong cho update Header
                //XtraMessageBox.Show(OBJ.Note);
                BUS.PXN_HeaderBUS_UPDATE(OBJ);

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

        private void ItemClickEventHandler_Delete_KHMau(object sender, ItemClickEventArgs e)
        {
            //throw new NotImplementedException();
            // 14 Khai báo state cho các nút khi nhấn nút Del
            state = MenuState.Delete;

            if (gridViewRowClick == true)
            {
                //OBJ1.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());

                DialogResult dlDel = XtraMessageBox.Show(" Bạn muốn xóa mục có mã  : " + KHMAUOBJ.KHMau + " ? ", "Xóa kí hiệu mẫu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlDel == DialogResult.Yes)
                {
                    KHMauCTXNBUS.KHMau_CTXN_LABDAO_DELETE_ByKHMau(KHMAUOBJ.KHMau);
                    KHMauBUS.KHMau_LABBUS_DELETE(KHMAUOBJ.KHMau);
                    XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                    args.AutoCloseOptions.Delay = 1000;
                    args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                    args.DefaultButtonIndex = 0;
                    args.Caption = "Thông báo ";
                    args.Text = "Đã xóa kí hiệu mẫu :" + KHMAUOBJ.KHMau + ". Thông báo này sẽ tự đóng sau 1 giây.";
                    args.Buttons = new DialogResult[] { DialogResult.OK };
                    XtraMessageBox.Show(args).ToString();
                }
                // 18 Load lại datasource cho grid

                gridControl2.DataSource = this.tbl_KHMau_LABTableAdapter.FillBy(this.sYNC_NUTRICIELDataSet.tbl_KHMau_LAB, OBJ.SoPXN); ;

                gridView2.BestFitColumns();
                // 17 trả trạng thái cho các nút như ban đầu
                state = MenuState.Full;
            }
            else
                // 16 Xác nhận có muốn xoa không ?
                XtraMessageBox.Show("Vui lòng click vào dòng cần chỉnh sửa ");
            {
                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.AutoCloseOptions.Delay = 1000;
                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                args.DefaultButtonIndex = 0;
                args.Caption = "Chú ý ";
                args.Text = "Vui lòng click vào dòng cần chỉnh sửa. Thông báo này sẽ tự đóng sau 1 giây.";
                args.Buttons = new DialogResult[] { DialogResult.OK };
                XtraMessageBox.Show(args).ToString();
            }
        }

        private void ItemClickEventHandler_Update_KHMau(object sender, ItemClickEventArgs e)
        {
            isAction = "Edit";

            //Set4ObjectHeader();

            //Riêng cho trường hợp tạo mới Row trên KQKN template
            //Truyen ID cua KQKN template cho Row

            state = MenuState.Insert;

            if (gridViewRowClick2 == true)
            {
                Set4ObjectKHMau();
                gridViewRowClick2 = false;
                //Update :  DELEGATE
                // Gọi form Details
                // Disable form
                this.Enabled = false;

                F_KHMau_Details FRM = new F_KHMau_Details();
                FRM.isAction = this.isAction;
                FRM.ngaynhanmau = dteNgayNhanMau.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayNhanMau.Text, CultureInfo.CreateSpecificCulture("en-GB"));
                //XtraMessageBox.Show(FRM.ngaynhanmau.ToString());
                FRM.KHMAUOBJ = this.KHMAUOBJ;
                FRM.myFinished += this.finished;
                FRM.Show();
            }
            else
            //XtraMessageBox.Show("Vui lòng click vào dòng cần chỉnh sửa ", "Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            {
                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.AutoCloseOptions.Delay = 3000;
                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                args.DefaultButtonIndex = 0;
                args.Caption = "Chú ý ";
                args.Text = "Vui lòng click vào dòng cần chỉnh sửa. Thông báo này sẽ tự đóng sau 3 giây.";
                args.Buttons = new DialogResult[] { DialogResult.OK };
                XtraMessageBox.Show(args).ToString();
            }
            //throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Add_KHMau(object sender, ItemClickEventArgs e)
        {
            if (this.dxValidationProvider2.Validate() == true)
            {
                //Set4ObjectHeader();
                isAction = "Add";
                //NEW
                Set4ObjectKHMau();

                //Riêng cho trường hợp tạo mới Row trên KQKN template
                //Truyen ID cua KQKN template cho Row
                OBJ1.ID = OBJ.ID;

                state = MenuState.Insert;
                //Update :  DELEGATE
                // Gọi form Details
                //Disable form
                this.Enabled = false;
                //
                F_KHMau_Details FRM = new F_KHMau_Details();
                FRM.isAction = this.isAction;
                FRM.ngaynhanmau = dteNgayNhanMau.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayNhanMau.Text, CultureInfo.CreateSpecificCulture("en-GB"));
                FRM.KHMAUOBJ = this.KHMAUOBJ;
                ;
                if (gridView2.DataRowCount > 0)
                {
                    if (int.Parse(gridView2.GetRowCellValue(gridView2.DataRowCount - 1, "KHMau").ToString().Substring(gridView2.GetRowCellValue(gridView2.DataRowCount - 1, "KHMau").ToString().Length - 2, 2)) < 9)
                        FRM.str_KHMau = KHMAUOBJ.SoPXN + "-0" + (int.Parse(gridView2.GetRowCellValue(gridView2.DataRowCount - 1, "KHMau").ToString().Substring(gridView2.GetRowCellValue(gridView2.DataRowCount - 1, "KHMau").ToString().Length - 2, 2)) + 1).ToString();
                    else
                        FRM.str_KHMau = KHMAUOBJ.SoPXN + "-" + (int.Parse(gridView2.GetRowCellValue(gridView2.DataRowCount - 1, "KHMau").ToString().Substring(gridView2.GetRowCellValue(gridView2.DataRowCount - 1, "KHMau").ToString().Length - 2, 2)) + 1).ToString();
                }
                else
                    FRM.str_KHMau = KHMAUOBJ.SoPXN + "-01";
                FRM.myFinished += this.finished;
                FRM.Show();
                //throw new NotImplementedException();
            }
            else
            {
                IList<Control> IControls = this.dxValidationProvider1.GetInvalidControls();
                foreach (Control ctrl in IControls)
                    ctrl.Focus();
            }
        }

        private void ItemClickEventHandler_Update(object sender, ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Set4Controls()
        {
            txtID.Text = OBJ.ID.ToString();
            if (OBJ.LoaiXN == "GEN")
            {
                chkGEN.CheckState = CheckState.Checked;
                chkH2O.CheckState = CheckState.Unchecked;
                chkH2O.ReadOnly = true;
                chkHTH.CheckState = CheckState.Unchecked;
                chkHTH.ReadOnly = true;
                chkMDW.CheckState = CheckState.Unchecked;
                chkMDW.ReadOnly = true;
            }
            else if (OBJ.LoaiXN == "H2O")
            {
                chkGEN.CheckState = CheckState.Unchecked;
                chkGEN.ReadOnly = true;
                chkH2O.CheckState = CheckState.Checked;
                chkHTH.CheckState = CheckState.Unchecked;
                chkHTH.ReadOnly = true;
                chkMDW.CheckState = CheckState.Unchecked;
                chkMDW.ReadOnly = true;
            }
            else if (OBJ.LoaiXN == "HTH")
            {
                chkGEN.CheckState = CheckState.Unchecked;
                chkGEN.ReadOnly = true;
                chkH2O.CheckState = CheckState.Unchecked;
                chkH2O.ReadOnly = true;
                chkHTH.CheckState = CheckState.Checked;
                chkMDW.CheckState = CheckState.Unchecked;
                chkMDW.ReadOnly = true;
            }
            else if (OBJ.LoaiXN == "MDW")
            {
                chkGEN.CheckState = CheckState.Unchecked;
                chkGEN.ReadOnly = true;
                chkMDW.CheckState = CheckState.Checked;
                chkHTH.CheckState = CheckState.Unchecked;
                chkHTH.ReadOnly = true;
                chkH2O.CheckState = CheckState.Unchecked;
                chkH2O.ReadOnly = true;
            }

            if (OBJ.DichTeDan == true)
                chkDichTeDan.CheckState = CheckState.Checked;
            else
                chkDichTeDan.CheckState = CheckState.Unchecked;

            txtSendMail.Text = OBJ.SendMail;
            dteNgayNhanMau.Text = OBJ.NgayNhanMau.ToString().Substring(0, 10);
            txtSoPXN.Text = OBJ.SoPXN;
            lkeTenCoSoGuiMau.Text = OBJ.TenCoSoGuiMau;
            txtDCCoSoGuiMau.Text = OBJ.DCCoSoGuiMau;
            txtPhoneCoSoGuiMau.Text = OBJ.PhoneCoSoGuiMau;
            txtFaxCoSoGuiMau.Text = OBJ.FaxCoSoGuiMau;
            txtEmailCoSoGuiMau.Text = OBJ.EmailCoSoGuiMau;
            txtMSTCoSoGuiMau.Text = OBJ.MSTCoSoGuiMau;
            lkeTenCoSoLayMau.Text = OBJ.TenCoSoLayMau;
            txtDCCoSoLayMau.Text = OBJ.DCCoSoLayMau;
            txtPhoneCoSoLayMau.Text = OBJ.PhoneCoSoLayMau;
            txtFaxCoSoLayMau.Text = OBJ.FaxCoSoLayMau;
            txtEmailCoSoLayMau.Text = OBJ.EmailCoSoLayMau;
            dteNgayDukienTra.Text = OBJ.NgayDuKienTra.ToString().Substring(0, 10);
            //dteNgayCoKetQua.Text            = OBJ.NgayCoKetQua.ToString().Substring(0, 10);
            //if (dteNgayCoKetQua.Text == "2019-01-01")
            //    dteNgayCoKetQua.Properties.ReadOnly = true;
            dteNgayTraKetQua.Text = OBJ.NgayTraKetQua.ToString().Substring(0, 10);
            if (dteNgayTraKetQua.Text == "2019-01-01")
                dteNgayTraKetQua.Properties.ReadOnly = true;
            //if (chkH2O.CheckState == CheckState.Checked)
            //{
            //    cmbLoaiDongVat.Text = "";
            //    cmbMauNuoc.Text = OBJ.LoaiDVMauNuoc;
            //}
            //else if (chkHTH.CheckState == CheckState.Checked || chkGEN.CheckState == CheckState.Checked)
            //{
            //    cmbLoaiDongVat.Text = OBJ.LoaiDVMauNuoc;
            //    cmbMauNuoc.Text = "";
            //}
            //dteNgayLayMau.Text = OBJ.NgayLayMau.ToString().Substring(0, 10);
            //cmbLoaiMauGui.Text = OBJ.LoaiMauGui;
            //txtSLMauGui.Text = OBJ.SLMauGui;
            //txtTTMauGui.Text = OBJ.TTMauGui;
            //txtVTMauDayChuong.Text = OBJ.VTLayMauDayChuong;
            //txtGioLayMauTuoi.Text = OBJ.GioLayMauTuoi;
            //txtKHMau.Text = OBJ.KHMau;
            //txtKhac.Text = OBJ.Khac;
            if (OBJ.PTNThucHien == true)
                chkPTN.CheckState = CheckState.Checked;
            else if (OBJ.PTNThucHien == false)
                chkNTP.CheckState = CheckState.Checked;
            else
                chkPTN.CheckState = CheckState.Checked;

            if (OBJ.NgonNgu == "VN")
                chkVN.CheckState = CheckState.Checked;
            else if (OBJ.NgonNgu == "EN")
                chkEN.CheckState = CheckState.Checked;
            else
                chkVN.CheckState = CheckState.Checked;

            //chkGEN
            //chkH2O
            //chkHTH
            //dteNgayNhanMau
            //txtSoPXN
            //txtTenCoSoGuiMau
            //txtDCCoSoGuiMau
            //txtPhoneCoSoGuiMau
            //txtFaxCoSoGuiMau
            //txtEmailCoSoGuiMau
            //txtMSTCoSoGuiMau
            //txtTenCoSoLayMau
            //txtDCCoSoLayMau
            //txtPhoneCoSoLayMau.Properties
            //txtFaxCoSoLayMau.Properties
            //txtEmailCoSoLayMau.Properties
            //dteExpDate
            //cmbLoaiDongVat
            //cmbMauNuoc
            //dteNgayLayMau
            //cmbLoaiMauGui
            //txtSLMauGui
            //txtTTMauGui
            //txtVTMauDayChuong
            //txtGioLayMauTuoi
            //txtKHMau
            //txtKhac
            //chkPTN
            //chkNTP

            ////txtTenmauCOA.Text = OBJ.PL.ToString();
            ////txtDienGiai.Text = OBJ.PL.ToString();
            txtNote.Text = OBJ.Note;
            cmbKhoa.Text = OBJ.Locked.ToString();
            ////dteEffDate.Text = OBJ.EffDate.ToString().Substring(0, 10);
            ////dteExpDate.Text = OBJ.ExpDate.ToString().Substring(0, 10);
        }

        public void Set4ObjectRow()
        {
            if (isAction == "Edit")
            {
                ////OBJ1
                ////MessageBox.Show("1");
                //OBJ1.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
                ////MessageBox.Show("2");
                //OBJ1.CTXNID = int.Parse(gridView1.GetFocusedRowCellValue("CTXNID").ToString());
                ////MessageBox.Show("3");
                //OBJ1.PLID = int.Parse(gridView1.GetFocusedRowCellValue("PLID").ToString());
                ////MessageBox.Show("4");
                //OBJ1.DonGia = gridView1.GetFocusedRowCellValue("DonGia").ToString();
                //OBJ1.Giam = gridView1.GetFocusedRowCellValue("Giam").ToString();
                //OBJ1.SoLuong = gridView1.GetFocusedRowCellValue("SoLuong").ToString();
                //OBJ1.UoM = gridView1.GetFocusedRowCellValue("UoM").ToString();
                //OBJ1.UoMGiam = gridView1.GetFocusedRowCellValue("UoMGiam").ToString();
                ////MessageBox.Show("5");
                //OBJ1.Note = gridView1.GetFocusedRowCellValue("Note").ToString();
                ////MessageBox.Show("6");
                //OBJ1.CreatedBy = gridView1.GetFocusedRowCellValue("CreatedBy").ToString();
                ////MessageBox.Show("7");
                //OBJ1.Locked = gridView1.GetFocusedRowCellValue("Locked").ToString() == "True" ? true : false;
                ////MessageBox.Show("8");
            }
        }

        public void Set4ObjectKHMau()
        {
            KHMAUOBJ.SoPXN = txtSoPXN.Text;
            //XtraMessageBox.Show(isAction);
            //XtraMessageBox.Show(isAction);
            if (isAction != "Add")
            {
                if (isAction == "Edit" || isChanged == "Changed")
                {
                    KHMAUOBJ.KHMau = gridView2.GetFocusedRowCellValue("KHMau").ToString();
                    KHMAUOBJ.ID = int.Parse(gridView2.GetFocusedRowCellValue("ID").ToString());
                    KHMAUOBJ.DonViKHMau = gridView2.GetFocusedRowCellValue("DonViKHMau").ToString();
                    KHMAUOBJ.Locked = gridView2.GetFocusedRowCellValue("Locked").ToString() == "True" ? true : false;
                    KHMAUOBJ.NgayHuyKHMau = gridView2.GetFocusedRowCellValue("NgayHuyKHMau").ToString().Length == 0 ? DateTime.Today : DateTime.Parse(gridView2.GetFocusedRowCellValue("NgayHuyKHMau").ToString(), CultureInfo.CreateSpecificCulture("en-GB"));
                    KHMAUOBJ.NgayLuuKHMau = gridView2.GetFocusedRowCellValue("NgayLuuKHMau").ToString().Length == 0 ? DateTime.Today : DateTime.Parse(gridView2.GetFocusedRowCellValue("NgayLuuKHMau").ToString(), CultureInfo.CreateSpecificCulture("en-GB"));
                    KHMAUOBJ.NhanVienHuyKHMau = gridView2.GetFocusedRowCellValue("NhanVienHuyKHMau").ToString();
                    KHMAUOBJ.NhanVienLuuKHMau = gridView2.GetFocusedRowCellValue("NhanVienLuuKHMau").ToString();
                    KHMAUOBJ.Note = gridView2.GetFocusedRowCellValue("Note").ToString();
                    KHMAUOBJ.PhuongPhapBaoQuan = gridView2.GetFocusedRowCellValue("PhuongPhapBaoQuan").ToString();
                    KHMAUOBJ.SoLuongHuyKHMau = gridView2.GetFocusedRowCellValue("SoLuongHuyKHMau").ToString();
                    KHMAUOBJ.SoLuongKHMau = gridView2.GetFocusedRowCellValue("SoLuongKHMau").ToString();
                    KHMAUOBJ.TaiLieuHuyKHMau = gridView2.GetFocusedRowCellValue("TaiLieuHuyKHMau").ToString();
                    KHMAUOBJ.VitriLuuKHMau = gridView2.GetFocusedRowCellValue("VitriLuuKHMau").ToString();
                    KHMAUOBJ.LoaiDVMauNuoc = gridView2.GetFocusedRowCellValue("LoaiDVMauNuoc").ToString();
                    KHMAUOBJ.NgayLayMau = gridView2.GetFocusedRowCellValue("NgayLayMau").ToString().Length == 0 ? DateTime.Today : DateTime.Parse(gridView2.GetFocusedRowCellValue("NgayLayMau").ToString(), CultureInfo.CreateSpecificCulture("en-GB"));
                    KHMAUOBJ.LoaiMauGui = gridView2.GetFocusedRowCellValue("LoaiMauGui").ToString();
                    KHMAUOBJ.TTMauGui = gridView2.GetFocusedRowCellValue("TTMauGui").ToString();
                    KHMAUOBJ.VTLayMauDayChuong = gridView2.GetFocusedRowCellValue("VTLayMauDayChuong").ToString();
                    KHMAUOBJ.GioLayMauTuoi = gridView2.GetFocusedRowCellValue("GioLayMauTuoi").ToString();
                    KHMAUOBJ.Khac = gridView2.GetFocusedRowCellValue("Khac").ToString();
                    KHMAUOBJ.SoLuongKHMauKhongDat = gridView2.GetFocusedRowCellValue("SoLuongKHMauKhongDat").ToString();
                    KHMAUOBJ.LiDoKHMauKhongDat = gridView2.GetFocusedRowCellValue("LiDoKHMauKhongDat").ToString();
                    KHMAUOBJ.CreatedBy = gridView2.GetFocusedRowCellValue("CreatedBy").ToString();
                }
            }
            //KHMAUOBJ.CreatedBy
            //KHMAUOBJ.CreatedDate
        }

        public void Set4ObjectHeader()
        {
            //XtraMessageBox.Show("isAction "+isAction.ToString());
            //XtraMessageBox.Show("isChanged "+isChanged.ToString());
            //XtraMessageBox.Show(txtID.Text);
            if (isAction == "Edit" || isChanged == "Changed")
                OBJ.ID = int.Parse(txtID.Text);

            if (chkGEN.CheckState == CheckState.Checked)
            {
                OBJ.LoaiXN = "GEN";
            }
            else if (chkH2O.CheckState == CheckState.Checked)
            {
                OBJ.LoaiXN = "H2O";
            }
            else if (chkHTH.CheckState == CheckState.Checked)
            {
                OBJ.LoaiXN = "H2O";
            }

            OBJ.NgayNhanMau = dteNgayNhanMau.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayNhanMau.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            OBJ.SoPXN = txtSoPXN.Text;
            OBJ.TenCoSoGuiMau = lkeTenCoSoGuiMau.Text;
            OBJ.DCCoSoGuiMau = txtDCCoSoGuiMau.Text;
            OBJ.PhoneCoSoGuiMau = txtPhoneCoSoGuiMau.Text;
            OBJ.FaxCoSoGuiMau = txtFaxCoSoGuiMau.Text;
            OBJ.EmailCoSoGuiMau = txtEmailCoSoGuiMau.Text;
            OBJ.MSTCoSoGuiMau = txtMSTCoSoGuiMau.Text;
            OBJ.TenCoSoLayMau = lkeTenCoSoLayMau.Text;
            OBJ.DCCoSoLayMau = txtDCCoSoLayMau.Text;
            OBJ.PhoneCoSoLayMau = txtPhoneCoSoLayMau.Text;
            OBJ.FaxCoSoLayMau = txtFaxCoSoLayMau.Text;
            OBJ.EmailCoSoLayMau = txtEmailCoSoLayMau.Text;
            //OBJ.KHMau = txtKHMau.Text;
            //OBJ.Khac = txtKhac.Text;
            //if (chkPTN.CheckState == CheckState.Checked)
            //    OBJ.PTNThucHien = true;
            //else if (chkNTP.CheckState == CheckState.Checked)
            //    OBJ.PTNThucHien = false;
            OBJ.PTNThucHien = chkPTN.CheckState == CheckState.Checked ? true : false;
            //if (chkVN.CheckState == CheckState.Checked)
            //    OBJ.NgonNgu = "VN";
            //else if (chkEN.CheckState == CheckState.Checked)
            //    OBJ.NgonNgu = "EN";
            OBJ.DichTeDan = chkDichTeDan.CheckState == CheckState.Checked ? true : false;
            OBJ.NgonNgu = chkEN.CheckState == CheckState.Checked ? "EN" : "VN";
            OBJ.Note = txtNote.Text;
            OBJ.Locked = cmbKhoa.SelectedText.ToString() == "True" ? true : false;
            OBJ.NgayDuKienTra = dteNgayDukienTra.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayDukienTra.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            OBJ.SendMail = txtSendMail.Text;
            //OBJ.NgayCoKetQua = dteNgayCoKetQua.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayCoKetQua.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            //OBJ.NgayTraKetQua = dteNgayTraKetQua.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayTraKetQua.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            OBJ.NgayTraTruoc = dteNgayTraTruoc.Text.Length == 0 ? DateTime.Parse("2019-01-01") : DateTime.Parse(dteNgayTraTruoc.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            OBJ.NgayThuTien = dteNgayThuTien.Text.Length == 0 ? DateTime.Parse("2019-01-01") : DateTime.Parse(dteNgayThuTien.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            OBJ.NgayXuatHoaDon = dteNgayXuatHoaDon.Text.Length == 0 ? DateTime.Parse("2019-01-01") : DateTime.Parse(dteNgayXuatHoaDon.Text, CultureInfo.CreateSpecificCulture("en-GB"));
        }

        public void ResetControl()
        {
            txtID.Text = "";
            lkeTenCoSoGuiMau.Text = "";
            //lkeCTPT.Text = "";
            //lkeTC.Text = "";
            txtNote.Text = "";
            cmbKhoa.Text = null;
        }

        public void TDControlsReadOnly(bool bl)
        {
            //txtID.ReadOnly = bl;
            //chkGEN.ReadOnly = bl;
            //chkH2O.ReadOnly = bl;
            //chkHTH.ReadOnly = bl;
            chkDichTeDan.ReadOnly = bl;
            dteNgayNhanMau.ReadOnly = bl;
            dteNgayDukienTra.ReadOnly = bl;
            txtSoPXN.ReadOnly = bl;
            lkeTenCoSoGuiMau.ReadOnly = bl;
            txtDCCoSoGuiMau.ReadOnly = bl;
            txtPhoneCoSoGuiMau.ReadOnly = bl;
            txtFaxCoSoGuiMau.ReadOnly = bl;
            txtEmailCoSoGuiMau.ReadOnly = bl;
            txtMSTCoSoGuiMau.ReadOnly = bl;
            lkeTenCoSoLayMau.ReadOnly = bl;
            txtDCCoSoLayMau.ReadOnly = bl;
            txtPhoneCoSoLayMau.ReadOnly = bl;
            txtFaxCoSoLayMau.ReadOnly = bl;
            txtEmailCoSoLayMau.ReadOnly = bl;
            //cmbLoaiDongVat.ReadOnly = bl;
            //cmbMauNuoc.ReadOnly = bl;
            //dteNgayLayMau.ReadOnly = bl;
            //dteNgayDukienTra.ReadOnly = bl;
            //cmbLoaiMauGui.ReadOnly = bl;
            //txtSLMauGui.ReadOnly = bl;
            //txtTTMauGui.ReadOnly = bl;
            //txtVTMauDayChuong.ReadOnly = bl;
            //txtGioLayMauTuoi.ReadOnly = bl;
            //txtKHMau.ReadOnly = bl;
            //txtKhac.ReadOnly = bl;
            //chkPTN.ReadOnly = bl;
            //chkNTP.ReadOnly = bl;
        }

        private void ItemClickEventHandler_Add(object sender, EventArgs e)
        {
            //Set4ObjectHeader();

            //isActionMini = "Add";
            ////Riêng cho trường hợp tạo mới Row trên KQKN template
            ////Truyen ID cua KQKN template cho Row
            //OBJ1.ID = OBJ.ID;

            //state = MenuState.Insert;
            ////Update :  DELEGATE
            //// Gọi form Details
            ////Disable
            //this.Enabled = false;
            ////
            //F_PXN_Details_Added_Row FRM = new F_PXN_Details_Added_Row();
            //FRM.isAction = this.isActionMini;
            //FRM.ngaynhanmau = dteNgayNhanMau.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayNhanMau.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            //OBJ1.SoPXN = OBJ.SoPXN;
            //FRM.OBJ = this.OBJ1;
            ////XtraMessageBox.Show("Delegate finished start");
            //FRM.myFinished += this.finished;
            ////XtraMessageBox.Show("Delegate finished");
            //FRM.Show();
        }

        private void ItemClickEventHandler_Edit(object sender, EventArgs e)
        {
            //Luu y : Chỉ cho xóa ko ch edit

            //isActionMini = "Edit";
            ////Riêng cho trường hợp tạo mới Row trên KQKN template
            ////Truyen ID cua KQKN template cho Row
            //OBJ1.PLID = OBJ.ID;
            //OBJ1.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());
            //OBJ1.PLID = int.Parse(gridView1.GetFocusedRowCellValue("PLID").ToString());
            //OBJ1.DonGia = gridView1.GetFocusedRowCellValue("DonGia").ToString();
            //OBJ1.VAT = gridView1.GetFocusedRowCellValue("VAT").ToString();
            //OBJ1.SoLuong = gridView1.GetFocusedRowCellValue("SoLuong").ToString();
            //OBJ1.UoM = gridView1.GetFocusedRowCellValue("UoM").ToString();
            //OBJ1.UoMGiam = gridView1.GetFocusedRowCellValue("UoMGiam").ToString();
            //OBJ1.Giam = gridView1.GetFocusedRowCellValue("Giam").ToString();
            //OBJ1.Note = gridView1.GetFocusedRowCellValue("Note").ToString();
            //OBJ1.Locked = gridView1.GetFocusedRowCellValue("Locked").ToString() == "True" ? true : false;
            //OBJ1.CTXNID = int.Parse(gridView1.GetFocusedRowCellValue("CTXNID").ToString());

            //state = MenuState.Update;
            ////Update :  DELEGATE
            //// Gọi form Details
            //F_PRICELIST_Details_Added_Row FRM = new F_PRICELIST_Details_Added_Row();
            //FRM.isAction = this.isActionMini;
            //FRM.OBJ = this.OBJ1;
            //FRM.myFinished += this.finished;
            //FRM.Show();
        }

        private void ItemClickEventHandler_Save(object sender, EventArgs e)
        {
            xtraTabControl1.Enabled = true;
            txtNote.ReadOnly = false;
            cmbKhoa.ReadOnly = false;
            txtSendMail.ReadOnly = false;
            //dteNgayCoKetQua.ReadOnly = false;
            dteNgayTraKetQua.ReadOnly = false;
            //MessageBox.Show(isAction.ToString());
            try
            {
                //btnSave.Enabled = false;

                if (isAction == "Add")
                {
                    Set4ObjectHeader();
                    Set4ObjectRow();
                    chkPTN.CheckState = CheckState.Checked;
                    chkVN.CheckState = CheckState.Checked;
                    BUS.PXN_HeaderBUS_INSERT(OBJ);
                    //gridControl1.Enabled = true;
                    //actionMini1.Enabled = true;
                    //Gan gia tri ID moi insert vo table tbl_KQKN_Template_Hedaer cho form
                    txtID.Text = BUS.MAX_PXN_HeaderBUS_ID().ToString();
                    //2019-05-06
                    //OBJ.ID = BUS.MAX_PXN_HeaderBUS_ID();
                    //ParentResourcesId///////////////////////////////////////////////
                    int ParentResourcesId;
                    // Tao ResourcesId--cho Schedule
                    RSRC.Subject = txtSoPXN.Text;
                    RSRC.Description = txtSoPXN.Text;
                    RSRC.CustomField1 = "LAB";
                    //MessageBox.Show("1");
                    RSRCBUS.Resources_INSERT(RSRC);
                    //MessageBox.Show("2");
                    ParentResourcesId = RSRCBUS.GET_ResourceId(RSRC.Description);
                    RSRC.ParentId = ParentResourcesId;
                    //MessageBox.Show("3");
                    RSRCBUS.Appointments_INSERT(dteNgayNhanMau.SelectedText, dteNgayNhanMau.SelectedText, ParentResourcesId, "Code mẫu ( nhận mẫu )", "LAB", 1);
                    //MessageBox.Show("4" + dteNgayNhanMau.EditValue.ToString());
                    //////////////////////////////////////////////////////////////////
                    RSRC.Id = RSRCBUS.GET_ResourceId(RSRC.Description);
                    //////////////////////////////////////////////////////////////////
                    RSRCBUS.Appointments_INSERT(dteNgayNhanMau.EditValue.ToString(), dteNgayNhanMau.EditValue.ToString(), RSRC.Id, "Chuyển đến phòng XN", "LAB", 2);
                    //////////////////////////////////////////////////////////////////
                    RSRCBUS.Appointments_INSERT(dteNgayNhanMau.EditValue.ToString(), dteNgayNhanMau.EditValue.ToString(), RSRC.Id, "Thời gian bắt đầu XN", "LAB", 3);
                    //////////////////////////////////////////////////////////////////
                    RSRCBUS.Appointments_INSERT(dteNgayNhanMau.EditValue.ToString(), dteNgayNhanMau.EditValue.ToString(), RSRC.Id, "XN hoàn tất", "LAB", 4);
                    //////////////////////////////////////////////////////////////////
                    RSRCBUS.Appointments_INSERT(dteNgayNhanMau.EditValue.ToString(), dteNgayNhanMau.EditValue.ToString(), RSRC.Id, "Bộ phận nhận kết quả", "LAB", 5);
                    //////////////////////////////////////////////////////////////////
                    RSRCBUS.Appointments_INSERT(dteNgayNhanMau.EditValue.ToString(), dteNgayNhanMau.EditValue.ToString(), RSRC.Id, "Kiểm tra kết quả", "LAB", 6);
                    //////////////////////////////////////////////////////////////////
                    RSRCBUS.Appointments_INSERT(dteNgayNhanMau.EditValue.ToString(), dteNgayNhanMau.EditValue.ToString(), RSRC.Id, "Trả kết quả cho khách hàng", "LAB", 7);
                    //////////////////////////////////////////////////////////////////
                }

                //Is_close = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            isAction = "Edit";
            txtID.Text = BUS.PXN_HeaderDAO_ID_bySoPXN(txtSoPXN.Text).ToString();
        }

        private void ItemClickEventHandler_View(object sender, EventArgs e)
        {
            //Set4ObjectHeader();
            //// 23 Gán state UPdate cho tat ca cac nut
            //state = MenuState.Update;

            ////24  Edit hoặc update nên  isNew gán bằng false
            ////isNew = false;

            //// 25 isEditting gan bang true
            ////isEditting = true;
            //isActionMini = "View";

            //// 26 COntrols gỡ bỏ trạng thái đọc cho phép nhập liệu
            ////ControlsReadOnly(false);

            //// Truyen object LOC to DELEGATE
            ////Disable
            //this.Enabled = false;
            ////
            //F_PXN_Details_Added_Row FRM = new F_PXN_Details_Added_Row();
            //FRM.isAction = this.isActionMini;
            //FRM.ngaynhanmau = dteNgayNhanMau.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayNhanMau.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            //OBJ1.SoPXN = OBJ.SoPXN;
            //FRM.OBJ = this.OBJ1;
            //FRM.myFinished += this.finished;
            //FRM.Show();
        }

        //private void ItemClickEventHandler_Delete(object sender, EventArgs e)
        //{
        //    //// 14 Khai báo state cho các nút khi nhấn nút Del
        //    //state = MenuState.Delete;

        //    //if (gridViewRowClick == true)
        //    //{
        //    //    //OBJ1.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());

        //    //    DialogResult dlDel = XtraMessageBox.Show(" Bạn muốn xóa mục có mã  : " + OBJ1.ID + " ? ", "Xóa thông tin", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        //    //    if (dlDel == DialogResult.Yes)
        //    //    {
        //    //        BUS1.PXN_DetailsBUS_DELETE(OBJ1);
        //    //    }
        //    //    // 18 Load lại datasource cho grid

        //    //    //gridControl1.DataSource = tbl_PXN_DetailsTableAdapter.FillBySoPXN(sYNC_NUTRICIELDataSet.tbl_PXN_Details, txtSoPXN.Text);

        //    //    //gridView1.BestFitColumns();
        //    //    // 17 trả trạng thái cho các nút như ban đầu
        //    //    state = MenuState.Full;
        //    //}
        //    //else
        //    //    // 16 Xác nhận có muốn xoa không ?
        //    //    XtraMessageBox.Show("Vui lòng click vào dòng cần chỉnh sửa ");
        //}

        private void ItemClickEventHandler_Close(object sender, EventArgs e)
        {
            //if (isChanged != "Changed")
            //    this.Close();
            //else
            //{
            //    DialogResult Dlg = XtraMessageBox.Show(" Bạn đã thay đổi nội dung . Bạn có muốn lưu lại ?", "Lưu ý", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (Dlg == DialogResult.No)
            //        this.Close();
            //    else
            //    {
            //        Set4ObjectHeader();
            //        //BUS.PRICELISTBUS_UPDATE(OBJ);
            //        this.Close();
            //    }

            //}
            //Is_close = true;
        }

        public void finished(object sender)
        {
            this.Enabled = true;
            //Dong form DELEGATE
            //var frm = (Form)sender;
            var frm = (DevExpress.XtraEditors.XtraForm)sender;
            frm.Close();
            //// Step 2 : Load lại data tren grid sau khi Add
            //gridControl2.DataSource = tbl_PXN_DetailsTableAdapter.FillBySoPXN(sYNC_NUTRICIELDataSet.tbl_PXN_Details, txtSoPXN.Text);
            //gridView2.BestFitColumns();
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_CUSTOMER_LAB' table. You can move, or remove it, as needed.
            this.tbl_CUSTOMER_LABTableAdapter.FillByEMPCode(this.sYNC_NUTRICIELDataSet.tbl_CUSTOMER_LAB, lkeTenCoSoGuiMau.EditValue.ToString());

            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_EMPLOYEE_LAB' table. You can move, or remove it, as needed.
            this.tbl_EMPLOYEE_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_EMPLOYEE_LAB);

            gridControl2.DataSource = this.tbl_KHMau_LABTableAdapter.FillBy(this.sYNC_NUTRICIELDataSet.tbl_KHMau_LAB, txtSoPXN.Text);
            gridView2.BestFitColumns();

            gridControl3.DataSource = KHMauBUS.KHMau_LABDAO_REPORT_STORAGE(KHMAUOBJ.SoPXN);
            gridView3.BestFitColumns();

            gridControl4.DataSource = KHMauBUS.KHMau_LABDAO_REPORT_DETROY(KHMAUOBJ.SoPXN);
            gridView4.BestFitColumns();
        }

        private void F_PRICELIST_Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_KHMau_LAB' table. You can move, or remove it, as needed.
            this.tbl_KHMau_LABTableAdapter.FillBy(this.sYNC_NUTRICIELDataSet.tbl_KHMau_LAB, OBJ.SoPXN);
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_CUSTOMER_LAB' table. You can move, or remove it, as needed.
            this.tbl_CUSTOMER_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_CUSTOMER_LAB);
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_EMPLOYEE_LAB' table. You can move, or remove it, as needed.
            this.tbl_EMPLOYEE_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_EMPLOYEE_LAB);
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_PriceList_Details_LAB' table. You can move, or remove it, as needed.
            //this.tbl_PXN_DetailsTableAdapter.FillBySoPXN(this.sYNC_NUTRICIELDataSet.tbl_PXN_Details,txtSoPXN.Text);
        }

        public string Func_SoPXN_NPT(int SoPXN)
        {
            string SoPXN_Text = "";

            switch (SoPXN.ToString().Length)
            {
                case (1):
                    SoPXN_Text = OBJ.LoaiXN + DateTime.Now.Year.ToString().Substring(2, 2) + "000" + BUS.Result_PXN_Header_SoPXN(OBJ.LoaiXN).ToString();
                    break;

                case (2):
                    SoPXN_Text = OBJ.LoaiXN + DateTime.Now.Year.ToString().Substring(2, 2) + "00" + BUS.Result_PXN_Header_SoPXN(OBJ.LoaiXN).ToString();
                    break;

                case (3):
                    SoPXN_Text = OBJ.LoaiXN + DateTime.Now.Year.ToString().Substring(2, 2) + "0" + BUS.Result_PXN_Header_SoPXN(OBJ.LoaiXN).ToString();
                    break;

                case (4):
                    SoPXN_Text = OBJ.LoaiXN + DateTime.Now.Year.ToString().Substring(2, 2) + BUS.Result_PXN_Header_SoPXN(OBJ.LoaiXN).ToString();
                    break;
            }
            return SoPXN_Text;
        }

        //private void lkeTenCoSoGuiMau_EditValueChanged(object sender, EventArgs e)
        //{
        //    DataRowView row = lkeTenCoSoGuiMau.Properties.GetDataSourceRowByKeyValue(lkeTenCoSoGuiMau.EditValue) as DataRowView;
        //    //txtDCCoSoGuiMau.Text = row["DCCoSoGuiMau"].ToString();
        //}
        private void Export2Pdf(string filename)
        {
            ///////////////////////////////////////////////////////////////////////////////////////////////////
            string Path = Directory.GetCurrentDirectory();
            //PXN_HeaderBUS BUS = new PXN_HeaderBUS();
            //PXN_DetailsBUS BUS1 = new PXN_DetailsBUS();
            //KHMau_LABBUS BUS2 = new KHMau_LABBUS();
            //PXN_Header OBJ = new PXN_Header();

            DataTable dt_PXN_Header,
                        dt_KHMau_Receipt,
                        dt_KHMau_Details,
                        dt_KHMau_STORAGE,
                        dt_KHMau_DETROY,
                        dt_PXN_Details = new DataTable();

            //////////////////////////////////////////////
            float TongTien = 0;

            dt_PXN_Header = BUS.PXN_HeaderBUS_SELECT(OBJ.SoPXN);
            dt_KHMau_Receipt = BUS2.KHMau_LABDAO_REPORT_RECEIPT(OBJ.SoPXN);
            dt_KHMau_Details = BUS2.KHMau_LABDAO_REPORT_DETAILS(OBJ.SoPXN);
            dt_KHMau_STORAGE = BUS2.KHMau_LABDAO_REPORT_STORAGE(OBJ.SoPXN);
            dt_KHMau_DETROY = BUS2.KHMau_LABDAO_REPORT_DETROY(OBJ.SoPXN);
            dt_PXN_Details = BUS1.PXN_DetailsBUS_SELECT(OBJ.SoPXN);

            dt_PXN_Header.WriteXml(Path + "/Xml/dt_PXN_Header_LAB.xml", System.Data.XmlWriteMode.IgnoreSchema);
            dt_PXN_Details.WriteXml(Path + "/Xml/dt_PXN_Details_LAB.xml", System.Data.XmlWriteMode.IgnoreSchema);
            dt_KHMau_Receipt.WriteXml(Path + "/Xml/dt_KHMau_Receipt.xml", System.Data.XmlWriteMode.IgnoreSchema);
            dt_KHMau_Details.WriteXml(Path + "/Xml/dt_KHMau_Details.xml", System.Data.XmlWriteMode.IgnoreSchema);
            dt_KHMau_STORAGE.WriteXml(Path + "/Xml/dt_KHMau_STORAGE.xml", System.Data.XmlWriteMode.IgnoreSchema);
            dt_KHMau_DETROY.WriteXml(Path + "/Xml/dt_KHMau_DETROY.xml", System.Data.XmlWriteMode.IgnoreSchema);

            //EXPORT CRYSTAL REPORT TO PDF SAVE ON DRIVER D:\MAPXN.PDF/////////////////////////////////////////
            ReportDocument cryRpt = new ReportDocument();
            CrystalReportViewer crystalReportViewer = new CrystalReportViewer();

            cryRpt.Load(Path + "/RPT/Rpt_PXN_LAB.rpt");
            crystalReportViewer.ReportSource = cryRpt;
            crystalReportViewer.Refresh();
            try
            {
                ExportOptions CrExportOptions;
                DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
                PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
                CrDiskFileDestinationOptions.DiskFileName = "D:\\" + filename + ".pdf";
                CrExportOptions = cryRpt.ExportOptions;
                {
                    CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                    CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                    CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                    CrExportOptions.FormatOptions = CrFormatTypeOptions;
                }
                cryRpt.Export();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        //Send Mail
        private void SendMail(string receipt, string subject, string attachedfilename)
        {
            //XtraMessageBox.Show(OBJ.SendMail);

            ///////////////////////////////////////////////////////////////////////////////////////////////////
            //if (OBJ.SendMail == "0")
            //{
            //Send email
            //SMTP
            SmtpClient SmtpServer = new SmtpClient("mail.olmixasia.com");
            SmtpServer.Port = 587;
            //SmtpServer.Credentials = new System.Net.NetworkCredential("dat.lt@olmixasia.com", "QwLmn090");
            SmtpServer.Credentials = new System.Net.NetworkCredential("truyen.htb@viphavet.com", "1234Vipha");

            //SEND
            try
            {
                //MessageBox.Show("1");
                MailMessage mail = new MailMessage();
                //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("truyen.htb@viphavet.com");
                mail.To.Add("vipha.lab@viphavet.com");
                mail.CC.Add("dat.lt@olmixasia.com");
                mail.CC.Add("tuyet.ntb@olmixasia.com");
                mail.CC.Add("thom.lt@viphavet.com");
                mail.CC.Add("truyen.htb@viphavet.com");
                mail.Subject = subject;//"Vipha.Lab : Phiếu xét nghiệm số " + txtSoPXN.Text + " ( Mới )";
                                       //1_Export to pdf

                //2_Attach to Email
                mail.Attachments.Add(new Attachment("D:\\" + attachedfilename + ".pdf"));
                //mail.Body = "This is for testing SMTP mail from DAT to TRUYEN";
                mail.IsBodyHtml = true;
                //SmtpServer.Port = 587;
                //SmtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
                //SmtpServer.EnableSsl = true;
                string messageBody = "<font>Kính gửi : " + lkeTenCoSoGuiMau.Text + "</font><br><br>";

                //if (grid.RowCount == 0) return messageBody;
                string htmlTableStart = "<table style=\"border-collapse:collapse; text-align:center;\" >";
                string htmlTableEnd = "</table>";
                string htmlHeaderRowStart = "<tr style=\"background-color:#6FA1D2; color:#ffffff;\">";
                string htmlHeaderRowEnd = "</tr>";
                string htmlTrStart = "<tr style=\"color:#555555;\">";
                string htmlTrEnd = "</tr>";
                string htmlTdStart = "<td style=\" border-color:#5c87b2; border-style:solid; border-width:thin; padding: 5px;\">";
                string htmlTdEnd = "</td>";
                messageBody += "Vipha.Lab trân trọng cảm ơn Quý Khách Hàng đã sử dụng dịch vụ xét nghiệm của chúng tôi. <br><br>";
                messageBody += "Chúng tôi xin đính kèm Phiếu nhận mẫu xét nghiệm đối với các mẫu yêu cầu thử nghiệm của Quý Khách Hàng. <br><br>";
                //messageBody += "Code mẫu             :" + txtSoPXN.Text + " <br><br>";
                messageBody += "- Ngày nhận mẫu        : " + dteNgayNhanMau.EditValue.ToString() + " <br><br>";
                messageBody += "- Ngày trả kết quả dự kiến : " + dteNgayDukienTra.EditValue.ToString() + " <br><br>";
                messageBody += "Quý Khách Hàng vui lòng kiểm tra các thông tin trên Phiếu nhận mẫu xét nghiệm và vui lòng phản hồi nếu có bất kỳ thay đổi nào trong vòng 04 giờ kể từ khi nhận email này.  <br><br>";
                //messageBody += htmlTableStart;
                //messageBody += htmlHeaderRowStart;
                //messageBody += htmlTdStart + "Chỉ tiêu xét nghiệm" + htmlTdEnd;
                //messageBody += htmlTdStart + "Số lượng mẫu" + htmlTdEnd;
                //messageBody += htmlTdStart + "Đơn giá (VND)" + htmlTdEnd;
                //messageBody += htmlTdStart + "VAT (%)" + htmlTdEnd;
                //messageBody += htmlTdStart + "Thành tiền (VND)" + htmlTdEnd;
                //messageBody += htmlHeaderRowEnd;
                //for (int i = 0; i <= gridView2.DataRowCount - 1; i++)
                //{
                //    float ThanhTien = 0;
                //    ThanhTien = float.Parse(gridView2.GetRowCellValue(i, "ThanhTien").ToString());
                //    TongTien = TongTien + float.Parse(gridView2.GetRowCellValue(i, "ThanhTien").ToString());
                //    messageBody = messageBody + htmlTrStart;
                //    messageBody = messageBody + htmlTdStart + gridView2.GetRowCellValue(i, "CTXN").ToString() + htmlTdEnd; //adding student name
                //    messageBody = messageBody + htmlTdStart + gridView2.GetRowCellValue(i, "SoLuongXN").ToString() + htmlTdEnd;
                //    messageBody = messageBody + htmlTdStart + gridView2.GetRowCellValue(i, "DonGia").ToString() + htmlTdEnd;
                //    messageBody = messageBody + htmlTdStart + gridView2.GetRowCellValue(i, "VAT").ToString() + htmlTdEnd;
                //    messageBody = messageBody + htmlTdStart + ThanhTien.ToString("0,000.##") + htmlTdEnd;
                //    messageBody = messageBody + htmlTrEnd;
                //}
                //messageBody = messageBody + htmlTdStart + htmlTdEnd; //adding student name
                //messageBody = messageBody + htmlTdStart + htmlTdEnd;
                //messageBody = messageBody + htmlTdStart + htmlTdEnd;
                //messageBody = messageBody + htmlTdStart + "Tổng cộng" + htmlTdEnd;
                //messageBody = messageBody + htmlTdStart + TongTien.ToString("0,000.##") + htmlTdEnd;

                //messageBody = messageBody + htmlTableEnd;
                messageBody += "Trân trọng kính chào. <br><br>";
                mail.Body = messageBody;

                SmtpServer.Send(mail);

                //Cập nhật gởi mail
                OBJ.SendMail = "1";
                BUS.PXN_HeaderDAO_UPDATE_SendMail(OBJ.ID, OBJ.SendMail);

                //MessageBox.Show("Email đã được gởi đến khách hàng.Trong trường hợp email bị lỗi bạn sẽ thấy thông báo lỗi trong mục Send của OutLook .");
                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.AutoCloseOptions.Delay = 1000;
                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                args.DefaultButtonIndex = 0;
                args.Caption = "Thông báo tự đóng ";
                args.Text = "Email đã được gởi đến khách hàng . Thông báo này sẽ tự đóng sau 1 giây.";
                //args.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Cancel };
                args.Buttons = new DialogResult[] { DialogResult.OK };
                XtraMessageBox.Show(args).ToString();
            }
            catch (SmtpFailedRecipientException ex)
            {
                XtraMessageBox.Show(ex.FailedRecipient);
                //ex.GetBaseException(); //should give you enough info.
            }
            //}
            //else if (OBJ.SendMail != "0")
            //{
            //    //Send email
            //    //SMTP
            //    SmtpClient SmtpServer = new SmtpClient("mail.olmixasia.com");
            //    SmtpServer.Port = 587;
            //    //SmtpServer.Credentials = new System.Net.NetworkCredential("dat.lt@olmixasia.com", "QwLmn090");
            //    SmtpServer.Credentials = new System.Net.NetworkCredential("truyen.htb@viphavet.com", "1234Vipha");
            //    //SEND
            //    try
            //    {
            //        //MessageBox.Show("1");
            //        MailMessage mail = new MailMessage();
            //        //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

            //        mail.From = new MailAddress("truyen.htb@viphavet.com");
            //        mail.To.Add("vipha.lab@viphavet.com");
            //        mail.CC.Add("dat.lt@olmixasia.com");
            //        mail.CC.Add("tuyet.ntb@olmixasia.com");
            //        mail.CC.Add("thom.lt@viphavet.com");
            //        mail.CC.Add("truyen.htb@viphavet.com");
            //        mail.Subject = subject; //"Vipha.Lab : Phiếu xét nghiệm số " + txtSoPXN.Text + " ( Cập nhật )"; ;
            //        //1_Export to pdf

            //        //2_Attach to Email
            //        mail.Attachments.Add(new Attachment("D:\\" + txtSoPXN.Text + ".pdf"));
            //        //mail.Body = "This is for testing SMTP mail from DAT to TRUYEN";
            //        mail.IsBodyHtml = true;
            //        //SmtpServer.Port = 587;
            //        //SmtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
            //        //SmtpServer.EnableSsl = true;
            //        string messageBody = "<font>Kính gửi: " + lkeTenCoSoGuiMau.Text + "</font><br><br>";
            //        //if (grid.RowCount == 0) return messageBody;
            //        string htmlTableStart = "<table style=\"border-collapse:collapse; text-align:center;\" >";
            //        string htmlTableEnd = "</table>";
            //        string htmlHeaderRowStart = "<tr style=\"background-color:#6FA1D2; color:#ffffff;\">";
            //        string htmlHeaderRowEnd = "</tr>";
            //        string htmlTrStart = "<tr style=\"color:#555555;\">";
            //        string htmlTrEnd = "</tr>";
            //        string htmlTdStart = "<td style=\" border-color:#5c87b2; border-style:solid; border-width:thin; padding: 5px;\">";
            //        string htmlTdEnd = "</td>";
            //        messageBody += "Vipha.Lab trân trọng cảm ơn Quý Khách Hàng đã sử dụng dịch vụ xét nghiệm của chúng tôi. <br><br>";
            //        messageBody += "Chúng tôi xin đính kèm Phiếu nhận mẫu xét nghiệm đối với các mẫu yêu cầu thử nghiệm của Quý Khách Hàng. <br><br>";
            //        //messageBody += "Code mẫu             :" + txtSoPXN.Text + " <br><br>";
            //        messageBody += "- Ngày nhận mẫu        : " + dteNgayNhanMau.EditValue.ToString() + " <br><br>";
            //        messageBody += "- Ngày trả kết quả dự kiến : " + dteNgayDukienTra.EditValue.ToString() + " <br><br>";
            //        messageBody += "Quý Khách Hàng vui lòng kiểm tra các thông tin trên Phiếu nhận mẫu xét nghiệm và vui lòng phản hồi nếu có bất kỳ thay đổi nào trong vòng 04 giờ kể từ khi nhận email này.  <br><br>";
            //    //messageBody += htmlTableStart;
            //    //messageBody += htmlHeaderRowStart;
            //    //messageBody += htmlTdStart + "Chỉ tiêu xét nghiệm" + htmlTdEnd;
            //    //messageBody += htmlTdStart + "Số lượng mẫu" + htmlTdEnd;
            //    //messageBody += htmlTdStart + "Đơn giá (VND)" + htmlTdEnd;
            //    //messageBody += htmlTdStart + "VAT (%)" + htmlTdEnd;
            //    //messageBody += htmlTdStart + "Thành tiền (VND)" + htmlTdEnd;
            //    //messageBody += htmlHeaderRowEnd;
            //    //for (int i = 0; i <= gridView2.DataRowCount - 1; i++)
            //    //{
            //    //    float ThanhTien = 0;
            //    //    ThanhTien = float.Parse(gridView2.GetRowCellValue(i, "ThanhTien").ToString());
            //    //    TongTien = TongTien + float.Parse(gridView2.GetRowCellValue(i, "ThanhTien").ToString());
            //    //    messageBody = messageBody + htmlTrStart;
            //    //    messageBody = messageBody + htmlTdStart + gridView2.GetRowCellValue(i, "CTXN").ToString() + htmlTdEnd; //adding student name
            //    //    messageBody = messageBody + htmlTdStart + gridView2.GetRowCellValue(i, "SoLuongXN").ToString() + htmlTdEnd;
            //    //    messageBody = messageBody + htmlTdStart + gridView2.GetRowCellValue(i, "DonGia").ToString() + htmlTdEnd;
            //    //    messageBody = messageBody + htmlTdStart + gridView2.GetRowCellValue(i, "VAT").ToString() + htmlTdEnd;
            //    //    messageBody = messageBody + htmlTdStart + ThanhTien.ToString("0,000.##") + htmlTdEnd;
            //    //    messageBody = messageBody + htmlTrEnd;
            //    //}

            //    //messageBody = messageBody + htmlTdStart + htmlTdEnd; //adding student name
            //    //messageBody = messageBody + htmlTdStart + htmlTdEnd;
            //    //messageBody = messageBody + htmlTdStart + htmlTdEnd;
            //    //messageBody = messageBody + htmlTdStart + "Tổng cộng" + htmlTdEnd;
            //    //messageBody = messageBody + htmlTdStart + TongTien.ToString("0,000.##") + htmlTdEnd;

            //    //messageBody = messageBody + htmlTableEnd;
            //    messageBody += "Trân trọng kính chào. <br><br>";
            //    mail.Body = messageBody;
            //        SmtpServer.Send(mail);
            //        txtSendMail.Text = (int.Parse(OBJ.SendMail) + 1).ToString();

            //        //Cập nhật gởi mail
            //        OBJ.SendMail = (int.Parse(OBJ.SendMail)+1).ToString();
            //        BUS.PXN_HeaderDAO_UPDATE_SendMail(OBJ.ID, OBJ.SendMail);

            //        //XtraMessageBox.Show("Email đã được gởi đến khách hàng.Trong trường hợp email bị lỗi bạn sẽ thấy thông báo lỗi trong mục Send của OutLook .");
            //        XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            //        args.AutoCloseOptions.Delay = 1000;
            //        args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
            //        args.DefaultButtonIndex = 0;
            //        args.Caption = "Thông báo tự đóng ";
            //        args.Text = "Email đã được gởi đến khách hàng . Thông báo này sẽ tự đóng sau 1 giây.";
            //        //args.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Cancel };
            //        args.Buttons = new DialogResult[] { DialogResult.OK };
            //    XtraMessageBox.Show(args).ToString();
            //    }
            //    catch (SmtpFailedRecipientException ex)
            //    {
            //        XtraMessageBox.Show(ex.FailedRecipient);
            //        //ex.FailedRecipient and ex.GetBaseException() should give you enough info.
            //    }
            //}
            //Set4ObjectHeader();
            //XtraMessageBox.Show(OBJ.SoPXN);
            //BUS.PXN_HeaderBUS_UPDATE(OBJ);
            //Set4ObjectHeader();
            //Set4ObjectRow();
            txtSendMail.Text = (int.Parse(txtSendMail.Text) + 1).ToString();
            Is_close = true;
            this.Close();
        }
    }
}