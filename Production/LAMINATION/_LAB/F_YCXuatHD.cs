﻿using CrystalDecisions.CrystalReports.Engine;
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
using System.Windows.Forms;

namespace Production.Class
{
    public partial class F_YCXuatHD : frm_Base
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

        private bool Automatically = true;

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

        public KHMau_CTXN_LAB KHMAUCTXNOBJ = new KHMau_CTXN_LAB();

        private KHMau_LABBUS KHMauBUS = new KHMau_LABBUS();
        private KHMau_CTXN_LABBUS KHMauCTXNBUS = new KHMau_CTXN_LABBUS();
        private KHMau_CTXN_RESULT_DETAILS_LABBUS BUS3 = new KHMau_CTXN_RESULT_DETAILS_LABBUS();

        public PXN_Header OBJ = new PXN_Header();
        private PXN_Details OBJ1 = new PXN_Details();

        private PXN_HeaderBUS BUS = new PXN_HeaderBUS();
        private PXN_DetailsBUS BUS1 = new PXN_DetailsBUS();
        private KHMau_LABBUS BUS2 = new KHMau_LABBUS();

        //Shcedule
        private Resources RSRC = new Resources();

        private ResourcesBUS RSRCBUS = new ResourcesBUS();

        private List<bool> LstBool = new List<bool>();

        public F_YCXuatHD()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                this.Width = Screen.PrimaryScreen.Bounds.Width * 3 / 5;
                this.Height = Screen.PrimaryScreen.Bounds.Height - 30;                

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
                dteNgayYCXuatHD.ReadOnly = true;
                dteNgayYCXuatHD.DateTime = DateTime.Now; 

                if (isAction == "Edit")
                {                    
                    //chkGEN.ReadOnly = true;
                    //chkH2O.ReadOnly = true;
                    //chkHTH.ReadOnly = true;
                    //chkMDW.ReadOnly = true;
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
                    //dteNgayCoKetQua.ReadOnly            = true;
                    //dteNgayTraKetQua.ReadOnly = true;
                    TDControlsReadOnly(true);
                    txtID.ReadOnly = true;
                }                
            };

            gridView2.RowClick += (s, e) =>
            {
                gridViewRowClick2 = true;
                Set4ObjectKHMau();
                //if (gridView2.GetFocusedRowCellValue("U_InvoiceNo").ToString().Length != 0)
                //{
                //    
                //}                
            };

            

                //chkSendMail.CheckStateChanged += (s, e) =>
                //{
                //    if (chkSendMail.CheckState == CheckState.Checked)
                //    {
                //        if (txtEmailCoSoGuiMau.Text.Length == 0)
                //        {
                //            chkSendMail_status = false;
                //            btnSendMail.Enabled = false;
                //            //Khong co email nhan vien gui mau thi khong cho gui
                //            //MessageBox.Show("Email đã được gởi đến khách hàng.Trong trường hợp email bị lỗi bạn sẽ thấy thông báo lỗi trong mục Send của OutLook .");
                //            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                //            args.AutoCloseOptions.Delay = 2000;
                //            args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                //            args.DefaultButtonIndex = 0;
                //            args.Caption = "Lưu ý ";
                //            args.Text = "Email người nhận không được bỏ trống. Thông báo này sẽ tự đóng sau 2 giây.";
                //            args.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Cancel };
                //            XtraMessageBox.Show(args).ToString();
                //        }
                //        else if (gridView2.RowCount == 0)
                //        {
                //            chkSendMail_status = false;
                //            btnSendMail.Enabled = false;
                //            //Khong co email nhan vien gui mau thi khong cho gui
                //            //MessageBox.Show("Email đã được gởi đến khách hàng.Trong trường hợp email bị lỗi bạn sẽ thấy thông báo lỗi trong mục Send của OutLook .");
                //            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                //            args.AutoCloseOptions.Delay = 2000;
                //            args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                //            args.DefaultButtonIndex = 0;
                //            args.Caption = "Lưu ý ";
                //            args.Text = "Không có kí hiệu mẫu. Thông báo này sẽ tự đóng sau 2 giây.";
                //            args.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Cancel };
                //            XtraMessageBox.Show(args).ToString();
                //        }
                //        else if (txtEmailCoSoGuiMau.Text.Length > 0 && gridView2.RowCount > 0)
                //        {
                //            chkSendMail_status = true;
                //            btnSendMail.Enabled = true;
                //        }
                //    }
                //    else
                //    {
                //        chkSendMail_status = false;
                //        btnSendMail.Enabled = false;
                //    }
                //};

                //btnSendMail.Click += (s, e) =>
                //{
                //    //Kiểm tra xem user có check gửi mail không

                //    DialogResult dlDel = XtraMessageBox.Show(" Bạn muốn gởi mail tới người nhận :" + txtEmailCoSoGuiMau.Text + " . Lưu ý hệ thống sẽ tiến hành gởi mail và không thể recall mail lại sau khi gởi", "Gởi mail", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //    if (dlDel == DialogResult.Yes)
                //    {
                //        string filename = "PhieuXetNghiem" + txtSoPXN.Text;
                //        if (OBJ.SendMail == "0")
                //        {
                //            Export2Pdf(filename);
                //            SendMail(txtEmailCoSoGuiMau.Text, "Vipha.Lab : Phiếu xét nghiệm số " + txtSoPXN.Text + " ( Mới )", filename);
                //        }
                //        else if (OBJ.SendMail != "0")
                //        {
                //            Export2Pdf(filename);
                //            SendMail(txtEmailCoSoGuiMau.Text, "Vipha.Lab : Phiếu xét nghiệm số " + txtSoPXN.Text + " ( Cập nhật )", filename);
                //        }
                //    }
                //    else
                //    {
                //        XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                //        args.AutoCloseOptions.Delay = 2000;
                //        args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                //        args.DefaultButtonIndex = 0;
                //        args.Caption = "Hủy mail ";
                //        args.Text = "Mail gởi đã hủy.";
                //        args.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Cancel };
                //        XtraMessageBox.Show(args).ToString();
                //    }
                //};
                //Tra ket qua cho kach hang
                //Chi khi tat ca cac dong co gia tri cua TraKetQua = true thi moi xu ly
            btnTraKetQua.Click += (s, e) =>
            {
                string path = string.Empty;
                DialogResult dlDel = XtraMessageBox.Show(" Bạn muốn xuất hóa đơn cho dự liệu đã chọn bên dưới ? . " +
                            "Lưu ý hệ thống sẽ ghi nhận hôm nay là ngày yêu cầu xuất hóa đơn", "Xuất hóa đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dlDel == DialogResult.Yes)
                {
                    foreach (int i in gridView2.GetSelectedRows())
                    {
                        //MessageBox.Show("KHMau : " + gridView2.GetRowCellValue(i, "KHMau").ToString());
                        //MessageBox.Show("KHMau : " + gridView2.GetRowCellValue(i, "CTXNID").ToString());
                        KHMauCTXNBUS.KHMau_CTXN_LABBUS_UPDATE_GoiYCXuatHD(gridView2.GetRowCellValue(i, "KHMau").ToString(), int.Parse(gridView2.GetRowCellValue(i, "CTXNID").ToString()));
                    }
                    string PCname = System.Environment.MachineName;
                    if (PCname == "VPV-ASL-SAMPLE")
                        path = @"D:\YC_xuat_HD_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
                    else
                        path = @"X:\YC_xuat_HD_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";

                    gridView2.ExportToXlsx(path);
                    System.Diagnostics.Process.Start(path);
                }
                
                

                //if (txtSoPXN.Text.Substring(0, 3) == "HTH")
                //{
                //    if (gridView2.GetFocusedRowCellValue("KetQua").ToString() == "True")
                //    {
                //        if (gridView2.GetFocusedRowCellValue("DaTraKetQua").ToString() == "True")
                //        {
                //            DialogResult dlDel = XtraMessageBox.Show("In báo cáo kết quả cho kí kiệu mẫu : " + gridView2.GetFocusedRowCellValue("KHMau").ToString() + " với chỉ tiêu xét nghiệm đã được trả . " +
                //            "Hệ thống sẽ chỉ có thể xuất báo cáo dưa trên kết quả đã xuất trước đó ", "In báo cáo kết quả", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //            if (dlDel == DialogResult.Yes)
                //            {
                //                KHMAUCTXNOBJ.ID = int.Parse(gridView2.GetFocusedRowCellValue("KHMau_CTXN_ID").ToString());
                //                //KHMauCTXNBUS.KHMau_CTXN_LABBUS_UPDATE_TraKetQua(KHMAUCTXNOBJ);
                //                R_IBD_RESULT_LAB_ANALYSISREPORT FRM = new R_IBD_RESULT_LAB_ANALYSISREPORT();
                //                FRM.CTXNID = int.Parse(gridView2.GetFocusedRowCellValue("CTXNID").ToString());
                //                FRM.KHMau_GiaoMau = gridView2.GetFocusedRowCellValue("KHMau_GiaoMau").ToString();
                //                FRM.SoPXN = this.OBJ.SoPXN;
                //                FRM.Show();
                //            }
                //        }
                //        else
                //        {
                //            DialogResult dlDel = XtraMessageBox.Show(" Bạn muốn trả kết quả cho kí kiệu mẫu : " + gridView2.GetFocusedRowCellValue("KHMau").ToString() + " với chỉ tiêu xét nghiệm ? . " +
                //            "Lưu ý hệ thống sẽ ghi nhận hôm nay là ngày trả kết quả cho khách hàng", "Trả kết quả", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //            if (dlDel == DialogResult.Yes)
                //            {
                //                KHMAUCTXNOBJ.ID = int.Parse(gridView2.GetFocusedRowCellValue("KHMau_CTXN_ID").ToString());
                //                KHMauCTXNBUS.KHMau_CTXN_LABBUS_UPDATE_TraKetQua(KHMAUCTXNOBJ);
                //                R_IBD_RESULT_LAB_ANALYSISREPORT FRM = new R_IBD_RESULT_LAB_ANALYSISREPORT();
                //                FRM.CTXNID = int.Parse(gridView2.GetFocusedRowCellValue("CTXNID").ToString());
                //                FRM.KHMau_GiaoMau = gridView2.GetFocusedRowCellValue("KHMau_GiaoMau").ToString();
                //                FRM.SoPXN = this.OBJ.SoPXN;
                //                FRM.Show();
                //            }
                //        }
                //    }
                //    else
                //    {
                //        XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                //        args.AutoCloseOptions.Delay = 2000;
                //        args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                //        args.DefaultButtonIndex = 0;
                //        args.Caption = "Trả kết quả ";
                //        args.Text = "Một số chỉ tiêu chưa có kết quả, vui lòng cập nhật và thử lại .";
                //        args.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Cancel };
                //        XtraMessageBox.Show(args).ToString();
                //    }
                //}
                //else
                //{
                //    if (LstBool.Contains(false) != true)
                //    {
                //        DialogResult dlDel = XtraMessageBox.Show(" Bạn muốn trả kết quả cho kí kiệu mẫu : " + gridView2.GetFocusedRowCellValue("KHMau").ToString() + " với chỉ tiêu xét nghiệm ? . " +
                //            "Lưu ý hệ thống sẽ ghi nhận hôm nay là ngày trả kết quả cho khách hàng", "Trả kết quả", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //        if (dlDel == DialogResult.Yes)
                //        {
                //            BUS.PXN_HeaderDAO_UPDATE_NgayTraKetQua(txtSoPXN.Text);
                //            if (txtSoPXN.Text.Substring(0, 3) == "MDW")
                //            {
                //                R_MYCOTOXIN_RESULT_LAB_ANALYSISREPORT FRM = new R_MYCOTOXIN_RESULT_LAB_ANALYSISREPORT();
                //                FRM.SoPXN = this.OBJ.SoPXN;
                //                FRM.Show();
                //            }
                //        }
                //    }
                //    else
                //    {
                //        XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                //        args.AutoCloseOptions.Delay = 2000;
                //        args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                //        args.DefaultButtonIndex = 0;
                //        args.Caption = "Trả kết quả ";
                //        args.Text = "Một số chỉ tiêu chưa có kết quả, vui lòng cập nhật và thử lại .";
                //        args.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Cancel };
                //        XtraMessageBox.Show(args).ToString();
                //    }
                //}
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

            //chkGEN.CheckedChanged += (s, e) =>
            // {
            //     if (chkGEN.CheckState == CheckState.Checked)
            //     {
            //         dteNgayNhanMau.ReadOnly = false;
            //         //TDControlsReadOnly(false);
            //         chkH2O.CheckState = CheckState.Unchecked;
            //         chkHTH.CheckState = CheckState.Unchecked;
            //         chkMDW.CheckState = CheckState.Unchecked;
            //         //cmbLoaiDV
            //         //layoutControlItem30.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always ;
            //         //layoutControlItem30.Text = "Loại động vật";
            //         ////cmbMauNuoc
            //         //layoutControlItem39.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //         //layoutControlItem39.Text = "Mẫu nước";
            //     }
            //     if (isAction == "Add")
            //     {
            //         OBJ.LoaiXN = "GEN";
            //         if (Automatically == true)
            //             txtSoPXN.Text = Func_SoPXN_NPT(BUS.Result_PXN_Header_SoPXN(OBJ.LoaiXN));
            //     }
            // };           

            //chkHTH.CheckedChanged += (s, e) =>
            //{
            //    if (chkHTH.CheckState == CheckState.Checked)
            //    {
            //        dteNgayNhanMau.ReadOnly = false;
            //        //TDControlsReadOnly(false);
            //        chkH2O.CheckState = CheckState.Unchecked;
            //        chkGEN.CheckState = CheckState.Unchecked;
            //        chkMDW.CheckState = CheckState.Unchecked;
            //        ////cmbLoaiDV
            //        //layoutControlItem30.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //        //layoutControlItem30.Text = "Loại động vật";
            //        ////cmbMauNuoc
            //        //layoutControlItem39.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //        //layoutControlItem39.Text = "Mẫu nước";
            //    }

            //    if (isAction == "Add")
            //    {
            //        OBJ.LoaiXN = "HTH";
            //        if (Automatically == true)
            //            txtSoPXN.Text = Func_SoPXN_NPT(BUS.Result_PXN_Header_SoPXN(OBJ.LoaiXN));
            //    }
            //};

            //chkH2O.CheckedChanged += (s, e) =>
            //{
            //    if (chkH2O.CheckState == CheckState.Checked)
            //    {
            //        dteNgayNhanMau.ReadOnly = false;
            //        //TDControlsReadOnly(false);
            //        chkGEN.CheckState = CheckState.Unchecked;
            //        chkHTH.CheckState = CheckState.Unchecked;
            //        chkMDW.CheckState = CheckState.Unchecked;
            //        ////cmbLoaiDV
            //        //layoutControlItem30.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //        //layoutControlItem30.Text = "Loại động vật";
            //        ////cmbMauNuoc
            //        //layoutControlItem39.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //        //layoutControlItem39.Text = "Mẫu nước";
            //    }
            //    if (isAction == "Add")
            //    {
            //        OBJ.LoaiXN = "H2O";
            //        if (Automatically == true)
            //            txtSoPXN.Text = Func_SoPXN_NPT(BUS.Result_PXN_Header_SoPXN(OBJ.LoaiXN));
            //    }
            //};

            //chkMDW.CheckedChanged += (s, e) =>
            //{
            //    if (chkMDW.CheckState == CheckState.Checked)
            //    {
            //        dteNgayNhanMau.ReadOnly = false;
            //        //TDControlsReadOnly(false);

            //        chkGEN.CheckState = CheckState.Unchecked;
            //        chkHTH.CheckState = CheckState.Unchecked;
            //        chkH2O.CheckState = CheckState.Unchecked;
            //        ////cmbLoaiDV
            //        //layoutControlItem30.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Always;
            //        //layoutControlItem30.Text = "Loại động vật";

            //        ////cmbMauNuoc
            //        //layoutControlItem39.Visibility = DevExpress.XtraLayout.Utils.LayoutVisibility.Never;
            //        //layoutControlItem39.Text = "Mẫu nước";
            //    }
            //    if (isAction == "Add")
            //    {
            //        OBJ.LoaiXN = "MDW";
            //        if (Automatically == true)
            //            txtSoPXN.Text = Func_SoPXN_NPT(BUS.Result_PXN_Header_SoPXN(OBJ.LoaiXN));
            //    }
            //};        
                       
            dteNgayYCXuatHD.EditValueChanged += (s, e) =>
            {
                //dteNgayDukienTra.ReadOnly = false;
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
            

            lkeTenCoSoLayMau.EditValueChanged += (s, e) =>
            {
                DataRowView rowView = (DataRowView)lkeTenCoSoLayMau.GetSelectedDataRow();
                DataRow row = rowView.Row;
                txtDCCoSoLayMau.Text = row["CUSTADDRESS"].ToString();
                txtEmailCoSoLayMau.Text = row["ContactEmail"].ToString();
                txtPhoneCoSoLayMau.Text = row["CUSTPHONE"].ToString();
                //////////////////////////////////////////////////////////////////////////////////////////
                OBJ.MaCoSoLayMau = row["CUSTCODE"].ToString();
                OBJ.CUSTCODE_ID = int.Parse(row["Id"].ToString());
                OBJ.DonViXuatHoaDon_ID = int.Parse(row["Id"].ToString());
                if (OBJ.MaCoSoLayMau.Length > 0)
                {
                    XtraMessageBox.Show(OBJ.DonViXuatHoaDon_ID.ToString());
                    gridControl2.DataSource = tbl_KHMau_LABTableAdapter.FillBy_DonViXuatHoaDon_ID(sYNC_NUTRICIELDataSet.tbl_KHMau_LAB,OBJ.DonViXuatHoaDon_ID);
                    gridView2.BestFitColumns();
                }
                else
                {
                    XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                                    args.AutoCloseOptions.Delay = 2000;
                                    args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                                    args.DefaultButtonIndex = 0;
                                    args.Caption = "Lưu ý ";
                                    args.Text = "Không tìm thấy chỉ tiêu . Thông báo này sẽ tự đóng sau 2 giây.";
                                    args.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Cancel };
                                    XtraMessageBox.Show(args).ToString();
                }

            };

           
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
            ////throw new NotImplementedException();
            //// 14 Khai báo state cho các nút khi nhấn nút Del
            //state = MenuState.Delete;

            //if (gridViewRowClick == true)
            //{
            //    //OBJ1.ID = int.Parse(gridView1.GetFocusedRowCellValue("ID").ToString());

            //    DialogResult dlDel = XtraMessageBox.Show(" Bạn muốn xóa kí hiệu mẫu : " + KHMAUOBJ.KHMau + " ?. Lưu ý : Các chỉ tiêu xét nghiệm liên quan đến kí hiệu mẫu " + KHMAUOBJ.KHMau + " cũng sẽ bị xóa. Đồng ý xóa ? ", "Xóa kí hiệu mẫu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //    if (dlDel == DialogResult.Yes)
            //    {
            //        //BUS3.KHMau_CTXN_LABDAO_DELETE_ByKHMau_CTXN_ID();
            //        KHMauCTXNBUS.KHMau_CTXN_LABDAO_DELETE_ByKHMau(KHMAUOBJ.KHMau);
            //        KHMauBUS.KHMau_LABBUS_DELETE(KHMAUOBJ.KHMau);
            //        XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            //        args.AutoCloseOptions.Delay = 1000;
            //        args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
            //        args.DefaultButtonIndex = 0;
            //        args.Caption = "Thông báo ";
            //        args.Text = "Đã xóa kí hiệu mẫu :" + KHMAUOBJ.KHMau + ". Thông báo này sẽ tự đóng sau 1 giây.";
            //        args.Buttons = new DialogResult[] { DialogResult.OK };
            //        XtraMessageBox.Show(args).ToString();
            //    }
            //    // 18 Load lại datasource cho grid

            //    gridControl2.DataSource = this.tbl_KHMau_LABTableAdapter.FillBy(this.sYNC_NUTRICIELDataSet.tbl_KHMau_LAB, OBJ.SoPXN); ;

            //    gridView2.BestFitColumns();
            //    // 17 trả trạng thái cho các nút như ban đầu
            //    state = MenuState.Full;
            //}
            //else
            //    // 16 Xác nhận có muốn xoa không ?
            //    XtraMessageBox.Show("Vui lòng click vào dòng cần chỉnh sửa ");
            //{
            //    XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            //    args.AutoCloseOptions.Delay = 1000;
            //    args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
            //    args.DefaultButtonIndex = 0;
            //    args.Caption = "Chú ý ";
            //    args.Text = "Vui lòng click vào dòng cần chỉnh sửa. Thông báo này sẽ tự đóng sau 1 giây.";
            //    args.Buttons = new DialogResult[] { DialogResult.OK };
            //    XtraMessageBox.Show(args).ToString();
            //}
        }

        private void ItemClickEventHandler_Update_KHMau(object sender, ItemClickEventArgs e)
        {
            //isAction = "Edit";

            ////Set4ObjectHeader();

            ////Riêng cho trường hợp tạo mới Row trên KQKN template
            ////Truyen ID cua KQKN template cho Row

            //state = MenuState.Insert;

            //if (gridViewRowClick2 == true)
            //{
            //    Set4ObjectKHMau();
            //    gridViewRowClick2 = false;
            //    //Update :  DELEGATE
            //    // Gọi form Details
            //    // Disable form
            //    this.Enabled = false;

            //    F_KHMau_Details FRM = new F_KHMau_Details();
            //    FRM.isAction = this.isAction;
            //    FRM.ngaynhanmau = dteNgayYCXuatHD.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayYCXuatHD.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            //    //XtraMessageBox.Show(FRM.ngaynhanmau.ToString());
            //    FRM.KHMAUOBJ = this.KHMAUOBJ;
            //    FRM.myFinished += this.finished;
            //    FRM.Show();
            //}
            //else
            ////XtraMessageBox.Show("Vui lòng click vào dòng cần chỉnh sửa ", "Lỗi ", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //{
            //    XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            //    args.AutoCloseOptions.Delay = 3000;
            //    args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
            //    args.DefaultButtonIndex = 0;
            //    args.Caption = "Chú ý ";
            //    args.Text = "Vui lòng click vào dòng cần chỉnh sửa. Thông báo này sẽ tự đóng sau 3 giây.";
            //    args.Buttons = new DialogResult[] { DialogResult.OK };
            //    XtraMessageBox.Show(args).ToString();
            //}
            ////throw new NotImplementedException();
        }

        private void ItemClickEventHandler_Add_KHMau(object sender, ItemClickEventArgs e)
        {
            //if (this.dxValidationProvider2.Validate() == true)
            //{
            //    //Set4ObjectHeader();
            //    isAction = "Add";
            //    //NEW
            //    Set4ObjectKHMau();

            //    //Riêng cho trường hợp tạo mới Row trên KQKN template
            //    //Truyen ID cua KQKN template cho Row
            //    OBJ1.ID = OBJ.ID;

            //    state = MenuState.Insert;
            //    //Update :  DELEGATE
            //    // Gọi form Details
            //    //Disable form
            //    this.Enabled = false;
            //    //
            //    F_KHMau_Details FRM = new F_KHMau_Details();
            //    FRM.isAction = this.isAction;
            //    FRM.ngaynhanmau = dteNgayYCXuatHD.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayYCXuatHD.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            //    FRM.KHMAUOBJ = this.KHMAUOBJ;
            //    ;
            //    if (gridView2.DataRowCount > 0)
            //    {
            //        if (int.Parse(gridView2.GetRowCellValue(gridView2.DataRowCount - 1, "KHMau").ToString().Substring(gridView2.GetRowCellValue(gridView2.DataRowCount - 1, "KHMau").ToString().Length - 2, 2)) < 9)
            //            FRM.str_KHMau = KHMAUOBJ.SoPXN + "-0" + (int.Parse(gridView2.GetRowCellValue(gridView2.DataRowCount - 1, "KHMau").ToString().Substring(gridView2.GetRowCellValue(gridView2.DataRowCount - 1, "KHMau").ToString().Length - 2, 2)) + 1).ToString();
            //        else
            //            FRM.str_KHMau = KHMAUOBJ.SoPXN + "-" + (int.Parse(gridView2.GetRowCellValue(gridView2.DataRowCount - 1, "KHMau").ToString().Substring(gridView2.GetRowCellValue(gridView2.DataRowCount - 1, "KHMau").ToString().Length - 2, 2)) + 1).ToString();
            //    }
            //    else
            //        FRM.str_KHMau = KHMAUOBJ.SoPXN + "-01";
            //    FRM.myFinished += this.finished;
            //    FRM.Show();
            //    //throw new NotImplementedException();
            //}
            //else
            //{
            //    IList<Control> IControls = this.dxValidationProvider1.GetInvalidControls();
            //    foreach (Control ctrl in IControls)
            //        ctrl.Focus();
            //}
        }

        private void ItemClickEventHandler_Update(object sender, ItemClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Set4Controls()
        {
            txtID.Text = OBJ.ID.ToString();
            //if (OBJ.LoaiXN == "GEN")
            //{
            //    chkGEN.CheckState = CheckState.Checked;
            //    chkH2O.CheckState = CheckState.Unchecked;
            //    chkH2O.ReadOnly = true;
            //    chkHTH.CheckState = CheckState.Unchecked;
            //    chkHTH.ReadOnly = true;
            //    chkMDW.CheckState = CheckState.Unchecked;
            //    chkMDW.ReadOnly = true;
            //}
            //else if (OBJ.LoaiXN == "H2O")
            //{
            //    chkGEN.CheckState = CheckState.Unchecked;
            //    chkGEN.ReadOnly = true;
            //    chkH2O.CheckState = CheckState.Checked;
            //    chkHTH.CheckState = CheckState.Unchecked;
            //    chkHTH.ReadOnly = true;
            //    chkMDW.CheckState = CheckState.Unchecked;
            //    chkMDW.ReadOnly = true;
            //}
            //else if (OBJ.LoaiXN == "HTH")
            //{
            //    chkGEN.CheckState = CheckState.Unchecked;
            //    chkGEN.ReadOnly = true;
            //    chkH2O.CheckState = CheckState.Unchecked;
            //    chkH2O.ReadOnly = true;
            //    chkHTH.CheckState = CheckState.Checked;
            //    chkMDW.CheckState = CheckState.Unchecked;
            //    chkMDW.ReadOnly = true;
            //}
            //else if (OBJ.LoaiXN == "MDW")
            //{
            //    chkGEN.CheckState = CheckState.Unchecked;
            //    chkGEN.ReadOnly = true;
            //    chkMDW.CheckState = CheckState.Checked;
            //    chkHTH.CheckState = CheckState.Unchecked;
            //    chkHTH.ReadOnly = true;
            //    chkH2O.CheckState = CheckState.Unchecked;
            //    chkH2O.ReadOnly = true;
            //}
            
            dteNgayYCXuatHD.Text = OBJ.NgayNhanMau.ToString().Substring(0, 10);
            txtSoPXN.Text = OBJ.SoPXN;
            txtMSTCoSoGuiMau.Text = OBJ.MSTCoSoGuiMau;
            lkeTenCoSoLayMau.Text = OBJ.TenCoSoLayMau;
            lkeTenCoSoLayMau.EditValue = OBJ.DonViXuatHoaDon_ID;
            txtDCCoSoLayMau.Text = OBJ.DCCoSoLayMau;
            txtPhoneCoSoLayMau.Text = OBJ.PhoneCoSoLayMau;
            txtFaxCoSoLayMau.Text = OBJ.FaxCoSoLayMau;
            txtEmailCoSoLayMau.Text = OBJ.EmailCoSoLayMau;
            //dteNgayCoKetQua.Text            = OBJ.NgayCoKetQua.ToString().Substring(0, 10);
            //if (dteNgayCoKetQua.Text == "2019-01-01")
            //    dteNgayCoKetQua.Properties.ReadOnly = true;
            //dteNgayTraKetQua.Text = OBJ.NgayTraKetQua.ToString().Substring(0, 10);
            //if (dteNgayTraKetQua.Text == "2019-01-01")
            //    dteNgayTraKetQua.Properties.ReadOnly = true;
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

            //if (chkGEN.CheckState == CheckState.Checked)
            //{
            //    OBJ.LoaiXN = "GEN";
            //}
            //else if (chkH2O.CheckState == CheckState.Checked)
            //{
            //    OBJ.LoaiXN = "H2O";
            //}
            //else if (chkHTH.CheckState == CheckState.Checked)
            //{
            //    OBJ.LoaiXN = "H2O";
            //}

            OBJ.NgayNhanMau = dteNgayYCXuatHD.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayYCXuatHD.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            OBJ.SoPXN = txtSoPXN.Text;
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
            //if (chkVN.CheckState == CheckState.Checked)
            //    OBJ.NgonNgu = "VN";
            //else if (chkEN.CheckState == CheckState.Checked)
            //    OBJ.NgonNgu = "EN";
            
            OBJ.Locked = cmbKhoa.SelectedText.ToString() == "True" ? true : false;
            
            //OBJ.NgayCoKetQua = dteNgayCoKetQua.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayCoKetQua.Text, CultureInfo.CreateSpecificCulture("en-GB"));
            //OBJ.NgayTraKetQua = dteNgayTraKetQua.Text.Length == 0 ? DateTime.Today : DateTime.Parse(dteNgayTraKetQua.Text, CultureInfo.CreateSpecificCulture("en-GB"));
        }

        public void ResetControl()
        {
            txtID.Text = "";
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
            dteNgayYCXuatHD.ReadOnly = bl;
            txtSoPXN.ReadOnly = bl;
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
        }

        private void ItemClickEventHandler_Edit(object sender, EventArgs e)
        {
        }

        private void ItemClickEventHandler_Save(object sender, EventArgs e)
        {
            xtraTabControl1.Enabled = true;
            txtNote.ReadOnly = false;
            cmbKhoa.ReadOnly = false;
            //dteNgayTraKetQua.ReadOnly = false;
            try
            {
                if (isAction == "Add")
                {
                    Set4ObjectHeader();
                    Set4ObjectRow();
                    BUS.PXN_HeaderBUS_INSERT(OBJ);
                    //Gan gia tri ID moi insert vo table tbl_KQKN_Template_Hedaer cho form
                    txtID.Text = BUS.MAX_PXN_HeaderBUS_ID().ToString();
                    //2019-05-06
                    //ParentResourcesId///////////////////////////////////////////////
                    int ParentResourcesId;
                    // Tao ResourcesId--cho Schedule
                    RSRC.Subject = txtSoPXN.Text;
                    RSRC.Description = txtSoPXN.Text;
                    RSRC.CustomField1 = "LAB";
                    RSRCBUS.Resources_INSERT(RSRC);
                    ParentResourcesId = RSRCBUS.GET_ResourceId(RSRC.Description);
                    RSRC.ParentId = ParentResourcesId;
                    RSRCBUS.Appointments_INSERT(dteNgayYCXuatHD.SelectedText, dteNgayYCXuatHD.SelectedText, ParentResourcesId, "Code mẫu ( nhận mẫu )", "LAB", 1);
                    //////////////////////////////////////////////////////////////////
                    RSRC.Id = RSRCBUS.GET_ResourceId(RSRC.Description);
                    //////////////////////////////////////////////////////////////////
                    RSRCBUS.Appointments_INSERT(dteNgayYCXuatHD.EditValue.ToString(), dteNgayYCXuatHD.EditValue.ToString(), RSRC.Id, "Chuyển đến phòng XN", "LAB", 2);
                    //////////////////////////////////////////////////////////////////
                    RSRCBUS.Appointments_INSERT(dteNgayYCXuatHD.EditValue.ToString(), dteNgayYCXuatHD.EditValue.ToString(), RSRC.Id, "Thời gian bắt đầu XN", "LAB", 3);
                    //////////////////////////////////////////////////////////////////
                    RSRCBUS.Appointments_INSERT(dteNgayYCXuatHD.EditValue.ToString(), dteNgayYCXuatHD.EditValue.ToString(), RSRC.Id, "XN hoàn tất", "LAB", 4);
                    //////////////////////////////////////////////////////////////////
                    RSRCBUS.Appointments_INSERT(dteNgayYCXuatHD.EditValue.ToString(), dteNgayYCXuatHD.EditValue.ToString(), RSRC.Id, "Bộ phận nhận kết quả", "LAB", 5);
                    //////////////////////////////////////////////////////////////////
                    RSRCBUS.Appointments_INSERT(dteNgayYCXuatHD.EditValue.ToString(), dteNgayYCXuatHD.EditValue.ToString(), RSRC.Id, "Kiểm tra kết quả", "LAB", 6);
                    //////////////////////////////////////////////////////////////////
                    RSRCBUS.Appointments_INSERT(dteNgayYCXuatHD.EditValue.ToString(), dteNgayYCXuatHD.EditValue.ToString(), RSRC.Id, "Trả kết quả cho khách hàng", "LAB", 7);
                    //////////////////////////////////////////////////////////////////
                }
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
        }

        private void ItemClickEventHandler_Close(object sender, EventArgs e)
        {
        }

        public void finished(object sender)
        {
            this.Enabled = true;
            //Dong form DELEGATE
            var frm = (DevExpress.XtraEditors.XtraForm)sender;
            frm.Close();
            //// Step 2 : Load lại data tren grid sau khi Add
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_CUSTOMER_LAB' table. You can move, or remove it, as needed.
            
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_EMPLOYEE_LAB' table. You can move, or remove it, as needed.
            //this.tbl_EMPLOYEE_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_EMPLOYEE_LAB);

            gridControl2.DataSource = this.tbl_KHMau_LABTableAdapter.FillBy(this.sYNC_NUTRICIELDataSet.tbl_KHMau_LAB, txtSoPXN.Text);
            gridView2.BestFitColumns();

        }

        private void F_PRICELIST_Details_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_KHMau_LAB' table. You can move, or remove it, as needed.
            this.tbl_KHMau_LABTableAdapter.FillBy(this.sYNC_NUTRICIELDataSet.tbl_KHMau_LAB, OBJ.SoPXN);
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_CUSTOMER_LAB' table. You can move, or remove it, as needed.
            this.tbl_CUSTOMER_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_CUSTOMER_LAB);
            // TODO: This line of code loads data into the 'sYNC_NUTRICIELDataSet.tbl_EMPLOYEE_LAB' table. You can move, or remove it, as needed.
            //this.tbl_EMPLOYEE_LABTableAdapter.Fill(this.sYNC_NUTRICIELDataSet.tbl_EMPLOYEE_LAB);
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

        private void Export2Pdf(string filename)
        {
            ///////////////////////////////////////////////////////////////////////////////////////////////////
            string Path = Directory.GetCurrentDirectory();

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
                CrDiskFileDestinationOptions.DiskFileName = @"X:\\" + filename + ".pdf";
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
        //private void SendMail(string receipt, string subject, string attachedfilename)
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
        //        MailMessage mail = new MailMessage();
        //        //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
        //        mail.From = new MailAddress("truyen.htb@viphavet.com");
        //        mail.To.Add("vipha.lab@viphavet.com");
        //        mail.CC.Add("dat.lt@olmixasia.com");
        //        mail.CC.Add("tuyet.ntb@olmixasia.com");
        //        mail.CC.Add("thom.lt@viphavet.com");
        //        mail.CC.Add("truyen.htb@viphavet.com");
        //        mail.Subject = subject;//"Vipha.Lab : Phiếu xét nghiệm số " + txtSoPXN.Text + " ( Mới )";
        //                               //1_Export to pdf

        //        //2_Attach to Email
        //        mail.Attachments.Add(new Attachment(@"X:\\" + attachedfilename + ".pdf"));
        //        mail.IsBodyHtml = true;
        //        //string messageBody = "<font>Kính gửi : " + lkeTenCoSoGuiMau.Text + "</font><br><br>";
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
        //        messageBody += "- Ngày nhận mẫu        : " + dteNgayNhanMau.EditValue.ToString() + " <br><br>";
        //        //messageBody += "- Ngày trả kết quả dự kiến : " + dteNgayDukienTra.EditValue.ToString() + " <br><br>";
        //        messageBody += "Quý Khách Hàng vui lòng kiểm tra các thông tin trên Phiếu nhận mẫu xét nghiệm và vui lòng phản hồi nếu có bất kỳ thay đổi nào trong vòng 04 giờ kể từ khi nhận email này.  <br><br>";
        //        messageBody += "Trân trọng kính chào. <br><br>";
        //        mail.Body = messageBody;

        //        SmtpServer.Send(mail);

        //        //Cập nhật gởi mail
        //        OBJ.SendMail = "1";
        //        BUS.PXN_HeaderDAO_UPDATE_SendMail(OBJ.ID, OBJ.SendMail);

        //        XtraMessageBoxArgs args = new XtraMessageBoxArgs();
        //        args.AutoCloseOptions.Delay = 1000;
        //        args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
        //        args.DefaultButtonIndex = 0;
        //        args.Caption = "Thông báo tự đóng ";
        //        args.Text = "Email đã được gởi đến khách hàng . Thông báo này sẽ tự đóng sau 1 giây.";
        //        args.Buttons = new DialogResult[] { DialogResult.OK };
        //        XtraMessageBox.Show(args).ToString();
        //    }
        //    catch (SmtpFailedRecipientException ex)
        //    {
        //        XtraMessageBox.Show(ex.FailedRecipient);
        //        //ex.GetBaseException(); //should give you enough info.
        //    }
        //    Is_close = true;
        //    this.Close();
        //}
    }
}