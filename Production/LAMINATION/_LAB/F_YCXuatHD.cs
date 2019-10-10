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
using System.Linq;
using System.Net.Mail;
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

        string path = string.Empty;

        public int gridRow = 0;

        private bool Automatically = true;
        public string PCname = System.Environment.MachineName;
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

                if (PCname == "VPV-ASL-SAMPLE")
                    path = @"D:\YC_xuat_HD_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
                else
                    path = @"X:\YC_xuat_HD_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
                

                action_EndForm3.Add_Status(false);
                action_EndForm3.Delete_Status(false);
                action_EndForm3.Update_Status(false);
                action_EndForm3.Save_Status(true);
                action_EndForm3.View_Status(false);
                action_EndForm3.Close_Status(true);

                //btnSendMail.Enabled = false;
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

            btnXem.Click += (s, e) =>
            {
                //string filePath = string.Empty;

                //string PCname = System.Environment.MachineName;
                //if (PCname == "VPV-ASL-SAMPLE")
                //    filePath = @"D:\YCXuatHD_" + DateTime.Now.ToShortDateString().Replace("/","_") +".xlsx";
                //else
                //    filePath = @"X:\YCXuatHD_" + DateTime.Now.ToShortDateString().Replace("/", "_") + ".xlsx";
                if (cmbTuychon.SelectedText == "" || cmbTuychon.SelectedText == "Tất cả" || cmbTuychon.SelectedText == "Chưa gởi yêu cầu xuất hóa đơn")
                {
                    DataTable dTable = new DataTable();
                    dTable.Columns.Add("DocDate", typeof(string));
                    dTable.Columns.Add("SoPXN", typeof(string));
                    dTable.Columns.Add("CUSTCODE", typeof(string));
                    dTable.Columns.Add("CUSTNAME", typeof(string));
                    dTable.Columns.Add("CUSTADDRESS", typeof(string));
                    dTable.Columns.Add("TaxCode", typeof(string));
                    dTable.Columns.Add("CUSTTYPEName", typeof(string));
                    dTable.Columns.Add("MaCTXN", typeof(string));
                    dTable.Columns.Add("CTXN", typeof(string));
                    dTable.Columns.Add("DonViKHMau", typeof(string));
                    dTable.Columns.Add("SoLuongKHMau", typeof(int));
                    dTable.Columns.Add("DonGia", typeof(float));
                    dTable.Columns.Add("DonGiaSauDiscount", typeof(float));
                    dTable.Columns.Add("VAT", typeof(float));
                    dTable.Columns.Add("DonGiaSauVAT", typeof(float));
                    dTable.Columns.Add("ThanhTien", typeof(float));

                    DataTable dTableGrp = new DataTable();
                    dTableGrp.Columns.Add("Ngày xuất hóa đơn", typeof(string));
                    dTableGrp.Columns.Add("Ký hiệu mẫu", typeof(string));
                    dTableGrp.Columns.Add("Mã Đơn vị", typeof(string));
                    dTableGrp.Columns.Add("Đơn vị", typeof(string));
                    dTableGrp.Columns.Add("Địa chỉ", typeof(string));
                    //dTableGrp.Columns.Add("LOCName", typeof(string));
                    dTableGrp.Columns.Add("Mã số thuế", typeof(string));
                    dTableGrp.Columns.Add("Người gửi mẫu", typeof(string));
                    dTableGrp.Columns.Add("Khu vực", typeof(string));
                    dTableGrp.Columns.Add("Note", typeof(string));
                    dTableGrp.Columns.Add("Mã số (Code)", typeof(string));
                    dTableGrp.Columns.Add("Tên hàng hóa, dịch vụ (Description)", typeof(string));
                    dTableGrp.Columns.Add("ĐVT (Unit)", typeof(string));
                    dTableGrp.Columns.Add("Số lượng (Qty) ", typeof(int));
                    dTableGrp.Columns.Add("Giá  bán full (Chưa VAT)", typeof(float));
                    dTableGrp.Columns.Add("Discount", typeof(float));
                    dTableGrp.Columns.Add("Giá sau khi discount", typeof(float));
                    dTableGrp.Columns.Add("VAT", typeof(float));
                    dTableGrp.Columns.Add("Đơn giá sau VAT (Unit Price)", typeof(float));
                    dTableGrp.Columns.Add("Doanh thu", typeof(float));
                    dTableGrp.Columns.Add("Mua ngoài", typeof(string));
                    dTableGrp.Columns.Add("Giá mua ngoài", typeof(float));
                    foreach (int i in gridView2.GetSelectedRows())
                    {
                        if(bool.Parse(gridView2.GetRowCellValue(i, "GoiYCXuatHD").ToString())==false)
                        {
                            dTable.Rows.Add(string.Empty,
                                        string.Empty,
                                        gridView2.GetRowCellValue(i, "CUSTCODE").ToString(),
                                        gridView2.GetRowCellValue(i, "CUSTNAME").ToString(),
                                        gridView2.GetRowCellValue(i, "CUSTADDRESS").ToString(),
                                        gridView2.GetRowCellValue(i, "TaxCode").ToString(),
                                        gridView2.GetRowCellValue(i, "CUSTTYPEName").ToString(),
                                        gridView2.GetRowCellValue(i, "MaCTXN").ToString(),
                                        gridView2.GetRowCellValue(i, "CTXN").ToString(),
                                        gridView2.GetRowCellValue(i, "DonViKHMau").ToString(),
                                        int.Parse(gridView2.GetRowCellValue(i, "SoLuongKHMau").ToString()),
                                        float.Parse(gridView2.GetRowCellValue(i, "DonGia").ToString()),
                                        float.Parse(gridView2.GetRowCellValue(i, "DonGiaSauDiscount").ToString()),
                                        float.Parse(gridView2.GetRowCellValue(i, "VAT").ToString()),
                                        float.Parse(gridView2.GetRowCellValue(i, "DonGia").ToString()) * (1 + float.Parse(gridView2.GetRowCellValue(i, "VAT").ToString()) / 100),
                                        float.Parse(gridView2.GetRowCellValue(i, "ThanhTien").ToString())
                                        );
                        }
                        
                    }
                    var query = from t in dTable.AsEnumerable()
                                group t by new
                                {
                                    DocDate = string.Empty,
                                    SoPXN = string.Empty,
                                    CUSTCODE = t.Field<string>("CUSTCODE"),
                                    CUSTNAME = t.Field<string>("CUSTNAME"),
                                    CUSTADDRESS = t.Field<string>("CUSTADDRESS"),
                                    //LOCName = t.Field<string>("LOCName"),
                                    TaxCode = t.Field<string>("TaxCode"),
                                    CUSTTYPEName = t.Field<string>("CUSTTYPEName"),
                                    CTXN = t.Field<string>("CTXN"),
                                    MaCTXN = t.Field<string>("MaCTXN"),
                                    DonViKHMau = t.Field<string>("DonViKHMau"),
                                    //sumSL
                                    DonGia = t.Field<float>("DonGia"),
                                    DonGiaSauDiscount = t.Field<float>("DonGiaSauDiscount"),
                                    VAT = t.Field<float>("VAT"),
                                    DonGiaSauVAT = t.Field<float>("DonGiaSauVAT"),
                                    //ThanhTien = t.Field<string>("ThanhTien")
                                    //sum
                                } into grp
                                select new
                                {
                                    grp.Key.DocDate,
                                    grp.Key.SoPXN,
                                    grp.Key.CUSTCODE,
                                    grp.Key.CUSTNAME,
                                    grp.Key.CUSTADDRESS,
                                    //grp.Key.LOCName,
                                    grp.Key.TaxCode,
                                    grp.Key.CUSTTYPEName,
                                    grp.Key.CTXN,
                                    grp.Key.MaCTXN,
                                    grp.Key.DonViKHMau,
                                    grp.Key.DonGia,
                                    grp.Key.DonGiaSauDiscount,
                                    grp.Key.VAT,
                                    grp.Key.DonGiaSauVAT,
                                    sumSL = grp.Sum(r => r.Field<int>("SoLuongKHMau")),
                                    sum = grp.Sum(r => r.Field<float>("ThanhTien"))
                                };

                    //gridControl1.DataSource = dTable;

                    foreach (var grp in query)
                    {
                        dTableGrp.Rows.Add(grp.DocDate,
                                            grp.SoPXN,
                                            grp.CUSTCODE,
                                            grp.CUSTNAME,
                                            grp.CUSTADDRESS,
                                            //grp.LOCName,
                                            grp.TaxCode,
                                            string.Empty,
                                            string.Empty,
                                            grp.CUSTTYPEName,
                                            grp.CTXN,
                                            grp.MaCTXN,
                                            grp.DonViKHMau,
                                            //grp.SoLuongKHMau = grp.sumSL
                                            grp.sumSL,
                                            grp.DonGia,
                                            0.00,
                                            grp.DonGiaSauDiscount,
                                            grp.VAT,
                                            grp.DonGiaSauVAT,
                                            //grp.ThanhTien = grp.sum                            
                                            grp.sum,
                                            string.Empty,
                                            0.00);
                        //Response.Write(String.Format("The Sum of '{0}' is {1}", grp.Id, grp.sum));
                    }
                    gridControl1.DataSource = dTableGrp;
                }
                else
                {
                    XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                    args.AutoCloseOptions.Delay = 2000;
                    args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                    args.DefaultButtonIndex = 0;
                    args.Caption = "Không thực hiện được ";
                    args.Text = "Dữ liệu bên trên đã tiến hành gởi xuất hóa đơn";
                    args.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Cancel };
                    XtraMessageBox.Show(args).ToString();
                }                   
                
            };

                

            btnSendMail.Click += (s, e) =>
            {
                if (this.dxValidationProvider2.Validate() == true)
                {
                    //Kiểm tra xem user có check gửi mail không
                    string[] _TOList = null;
                    string[] _CCList = null;

                    _TOList = txtEmailTO.Text.Split(';');

                    _CCList = txtEmailCC.Text.Split(';');

                    DialogResult dlDel = XtraMessageBox.Show(" Bạn muốn gởi mail ? . Lưu ý hệ thống sẽ tiến hành gởi mail và không thể recall mail lại sau khi gởi", "Gởi mail", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlDel == DialogResult.Yes)
                    {
                        SendMail(_TOList, _CCList, "Yêu cầu xuất hóa đơn", path);
                        XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                        args.AutoCloseOptions.Delay = 2000;
                        args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                        args.DefaultButtonIndex = 0;
                        args.Caption = "Đã gởi mail ";
                        args.Text = "Nội dung yêu cầu xuất hóa đơn đã gởi cho bộ phận CS.";
                        args.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Cancel };
                        XtraMessageBox.Show(args).ToString();
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
                }
                else
                {
                    XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                    args.AutoCloseOptions.Delay = 2000;
                    args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                    args.DefaultButtonIndex = 0;
                    args.Caption = "Không có mail người nhận ";
                    args.Text = "Mail gởi đã hủy.";
                    args.Buttons = new DialogResult[] { DialogResult.OK, DialogResult.Cancel };
                    XtraMessageBox.Show(args).ToString();
                }

            };
            //Tra ket qua cho kach hang
            //Chi khi tat ca cac dong co gia tri cua TraKetQua = true thi moi xu ly
            btnTraKetQua.Click += (s, e) =>
            {
                //if (gridView2.GetFocusedRowCellValue("GoiYCXuatHD").ToString() == "False")
                //{
                    DialogResult dlDel = XtraMessageBox.Show(" Bạn muốn xuất hóa đơn cho dữ liệu đã chọn bên trên ? . " +
                            "Lưu ý hệ thống sẽ ghi nhận hôm nay là ngày yêu cầu xuất hóa đơn", "Xuất hóa đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlDel == DialogResult.Yes)
                    {
                        foreach (int i in gridView2.GetSelectedRows())
                        {
                            KHMauCTXNBUS.KHMau_CTXN_LABBUS_UPDATE_GoiYCXuatHD(gridView2.GetRowCellValue(i, "KHMau").ToString(), int.Parse(gridView2.GetRowCellValue(i, "CTXNID").ToString()));
                        }
                        //Export
                        gridView1.ExportToXlsx(path);
                        System.Diagnostics.Process.Start(path);
                    }
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
                       
            dteNgayYCXuatHD.EditValueChanged += (s, e) =>
            {
                //dteNgayDukienTra.ReadOnly = false;
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
                    if(cmbTuychon.SelectedText == "Đã gởi yêu cầu xuất hóa đơn")
                    //XtraMessageBox.Show(OBJ.DonViXuatHoaDon_ID.ToString());
                        gridControl2.DataSource = tbl_KHMau_LABTableAdapter.FillBy_DonViXuatHoaDon_ID_DagoiYCXHD(sYNC_NUTRICIELDataSet.tbl_KHMau_LAB,OBJ.DonViXuatHoaDon_ID);
                    else if (cmbTuychon.SelectedText == "Chưa gởi yêu cầu xuất hóa đơn")
                        gridControl2.DataSource = tbl_KHMau_LABTableAdapter.FillBy_DonViXuatHoaDon_ID_ChuagoiYCXHD(sYNC_NUTRICIELDataSet.tbl_KHMau_LAB, OBJ.DonViXuatHoaDon_ID);
                    else 
                        gridControl2.DataSource = tbl_KHMau_LABTableAdapter.FillBy_DonViXuatHoaDon_ID(sYNC_NUTRICIELDataSet.tbl_KHMau_LAB, OBJ.DonViXuatHoaDon_ID);
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
           
            action_EndForm3.Close(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Close3));
            action_EndForm3.Save(new DevExpress.XtraBars.ItemClickEventHandler(ItemClickEventHandler_Save3));

        }
        private void ItemClickEventHandler_Save_KHMau(object sender, ItemClickEventArgs e)
        {
            

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
            
        }

        private void ItemClickEventHandler_Update_KHMau(object sender, ItemClickEventArgs e)
        {
            
        }

        private void ItemClickEventHandler_Add_KHMau(object sender, ItemClickEventArgs e)
        {
            
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



        //Send Mail
        private void SendMail(string[] TOList, string[] CCList, string subject, string attachedfilename)
        {
            //Send email
            //SMTP
            SmtpClient SmtpServer = new SmtpClient("mail.olmixasia.com");
            SmtpServer.Port = 587;
            //SmtpServer.Credentials = new System.Net.NetworkCredential("dat.lt@olmixasia.com", "QwLmn090");
            SmtpServer.Credentials = new System.Net.NetworkCredential("truyen.htb@viphavet.com", "1234Vipha");

            //SEND
            try
            {
                MailMessage mail = new MailMessage();

                string messageBody = string.Empty;
                //SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress("truyen.htb@viphavet.com");
                //XtraMessageBox.Show(TOList.Count<string>().ToString());
                if (TOList.Count<string>() > 1)
                {
                    foreach (string _TO in TOList)
                        mail.To.Add(_TO);
                }
                //XtraMessageBox.Show(CCList.Count<string>().ToString());
                //mail.To.Add("dat.lt@olmixasia.com");
                if(CCList.Count<string>() > 1)
                {
                    foreach (string _CC in CCList)
                        mail.CC.Add(_CC);
                }
                

                //mail.CC.Add("dat.lt@olmixasia.com");
                //mail.CC.Add("tuyet.ntb@olmixasia.com");
                //mail.CC.Add("thom.lt@viphavet.com");
                mail.CC.Add("truyen.htb@viphavet.com");
                mail.Subject = subject;//"Vipha.Lab : Phiếu xét nghiệm số " + txtSoPXN.Text + " ( Mới )";
                                       //1_Export to pdf

                //2_Attach to Email
                //mail.Attachments.Add(new Attachment(@"X:\\" + attachedfilename + ".xlsx"));
                mail.Attachments.Add(new Attachment(attachedfilename));
                mail.IsBodyHtml = true;
                //string messageBody = "<font>Kính gửi : " + lkeTenCoSoGuiMau.Text + "</font><br><br>";
                string htmlTableStart = "<table style=\"border-collapse:collapse; text-align:center;\" >";
                string htmlTableEnd = "</table>";
                string htmlHeaderRowStart = "<tr style=\"background-color:#6FA1D2; color:#ffffff;\">";
                string htmlHeaderRowEnd = "</tr>";
                string htmlTrStart = "<tr style=\"color:#555555;\">";
                string htmlTrEnd = "</tr>";
                string htmlTdStart = "<td style=\" border-color:#5c87b2; border-style:solid; border-width:thin; padding: 5px;\">";
                string htmlTdEnd = "</td>";
                messageBody += "Anh/Chị vui lòng xuất nội dung yêu cầu xuất hóa đơn theo file đính kèm <br><br>";
                //messageBody += "Chúng tôi xin đính kèm Phiếu nhận mẫu xét nghiệm đối với các mẫu yêu cầu thử nghiệm của Quý Khách Hàng. <br><br>";
                //messageBody += "- Ngày nhận mẫu        : " + dteNgayNhanMau.EditValue.ToString() + " <br><br>";
                //messageBody += "- Ngày trả kết quả dự kiến : " + dteNgayDukienTra.EditValue.ToString() + " <br><br>";
                //messageBody += "Quý Khách Hàng vui lòng kiểm tra các thông tin trên Phiếu nhận mẫu xét nghiệm và vui lòng phản hồi nếu có bất kỳ thay đổi nào trong vòng 04 giờ kể từ khi nhận email này.  <br><br>";
                messageBody += "Xin cảm ơn đã hỗ trợ. <br><br>";
                mail.Body = messageBody;

                SmtpServer.Send(mail);

                //Cập nhật gởi mail
                OBJ.SendMail = "1";
                BUS.PXN_HeaderDAO_UPDATE_SendMail(OBJ.ID, OBJ.SendMail);

                XtraMessageBoxArgs args = new XtraMessageBoxArgs();
                args.AutoCloseOptions.Delay = 1000;
                args.AutoCloseOptions.ShowTimerOnDefaultButton = true;
                args.DefaultButtonIndex = 0;
                args.Caption = "Thông báo tự đóng ";
                args.Text = "Email đã được gởi đến bộ phận CS . Thông báo này sẽ tự đóng sau 1 giây.";
                args.Buttons = new DialogResult[] { DialogResult.OK };
                XtraMessageBox.Show(args).ToString();
            }
            catch (SmtpFailedRecipientException ex)
            {
                XtraMessageBox.Show(ex.FailedRecipient);
                //ex.GetBaseException(); //should give you enough info.
            }
            Is_close = true;
            this.Close();
        }
    }
}