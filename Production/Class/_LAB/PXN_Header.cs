using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Windows;

namespace Production.Class
{
    public class PXN_Header
    {
        public PXN_Header()
        {

        }
        
        public int ID { get; set; } 
        public string SoPXN { get; set; }
        public string PXNDescription { get; set; }
        public string CoSoGuiMau { get; set; }
        public string MaCoSoGuiMau { get; set; }
        public string TenCoSoGuiMau { get; set; }
        public string DCCoSoGuiMau { get; set; }
        public string PhoneCoSoGuiMau { get; set; }
        public string FaxCoSoGuiMau { get; set; }
        public string EmailCoSoGuiMau { get; set; }
        public string MSTCoSoGuiMau { get; set; }
        public string CoSoLayMau { get; set; }
        public string MaCoSoLayMau { get; set; }
        public string TenCoSoLayMau { get; set; }
        public string DCCoSoLayMau { get; set; }
        public string PhoneCoSoLayMau { get; set; }
        public string FaxCoSoLayMau { get; set; }
        public string EmailCoSoLayMau { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string Note { get; set; }
        public bool Locked { get; set; }
        public DateTime NgayNhanMau { get; set; }
        public DateTime NgayDuKienTra { get; set; }
        public DateTime NgayCoKetQua { get; set; }
        public DateTime NgayTraKetQua { get; set; }
        //DateTime NgayLayMau,
        //string LoaiDVMauNuoc,
        //string LoaiMauGui,
        //string SLMauGui,
        //string TTMauGui,
        //string VTLayMauDayChuong,
        //string GioLayMauTuoi,
        public string KHMau { get; set; }
        public string Khac { get; set; }
        public bool PTNThucHien { get; set; }
        public string LoaiXN { get; set; }
        public string NgonNgu { get; set; }
        public string SendMail { get; set; }
        public bool DichTeDan { get; set; }
        public int CUSTCODE_ID { get; set; }
        public int EMPCode_ID { get; set; }
        ////////////// HOA DON - THANH TOAN /////////////////
        public bool DaXuatHoaDon { get; set; }
        public DateTime NgayXuatHoaDon { get; set; }
        public string SoHoaDon { get; set; }
        public bool DaThuTien { get; set; }
        public DateTime NgayThuTien { get; set; }
        public float SoTienHoaDon { get; set; }
        public bool TraTruoc { get; set; }
        public DateTime NgayTraTruoc { get; set; }
        public float SoTienTraTruoc { get; set; }
        public float SoTienDaThu { get; set; }
        public string NoiDungHoaDon { get; set; }
        public string NoiDungTraTruoc { get; set; }
        public int DonViXuatHoaDon_ID { get; set; }
        public DateTime NgayGiaoMau { get; set; }
        public string NguoiGiaoMau { get; set; }
        public bool GiaoMau { get; set; }
        public List<KHMau_LAB> KHMau_LABs { get; set; }

        public PXN_Header PXN_Header_GetMasterDetailData(DataRow PXN_Header_Row, DataTable KHMau_LAB_dt)
        {
            PXN_Header _pXN_Header = new PXN_Header();

            //MessageBox.Show("SoPXN : " + PXN_Header_Row["SoPXN"].ToString());
            _pXN_Header.ID = int.Parse(PXN_Header_Row["ID"].ToString());
            _pXN_Header.SoPXN = PXN_Header_Row["SoPXN"].ToString();
            _pXN_Header.PXNDescription = PXN_Header_Row["PXNDescription"].ToString();
            _pXN_Header.CoSoGuiMau = PXN_Header_Row["CoSoGuiMau"].ToString();
            _pXN_Header.MaCoSoGuiMau = PXN_Header_Row["MaCoSoGuiMau"].ToString();
            _pXN_Header.TenCoSoGuiMau = PXN_Header_Row["TenCoSoGuiMau"].ToString();
            _pXN_Header.DCCoSoGuiMau = PXN_Header_Row["DCCoSoGuiMau"].ToString();
            _pXN_Header.PhoneCoSoGuiMau = PXN_Header_Row["PhoneCoSoGuiMau"].ToString();
            _pXN_Header.FaxCoSoGuiMau = PXN_Header_Row["FaxCoSoGuiMau"].ToString();
            _pXN_Header.EmailCoSoGuiMau = PXN_Header_Row["EmailCoSoGuiMau"].ToString();
            _pXN_Header.MSTCoSoGuiMau = PXN_Header_Row["MSTCoSoGuiMau"].ToString();
            _pXN_Header.CoSoLayMau = PXN_Header_Row["CoSoLayMau"].ToString();
            _pXN_Header.MaCoSoLayMau = PXN_Header_Row["MaCoSoLayMau"].ToString();
            _pXN_Header.TenCoSoLayMau = PXN_Header_Row["TenCoSoLayMau"].ToString();
            _pXN_Header.DCCoSoLayMau = PXN_Header_Row["DCCoSoLayMau"].ToString();
            _pXN_Header.PhoneCoSoLayMau = PXN_Header_Row["PhoneCoSoLayMau"].ToString();
            _pXN_Header.FaxCoSoLayMau = PXN_Header_Row["FaxCoSoLayMau"].ToString();
            _pXN_Header.EmailCoSoLayMau = PXN_Header_Row["EmailCoSoLayMau"].ToString();
            _pXN_Header.CreatedDate = DateTime.Parse(PXN_Header_Row["CreatedDate"].ToString(), CultureInfo.CreateSpecificCulture("en-GB"));
            _pXN_Header.CreatedBy = PXN_Header_Row["CreatedBy"].ToString();
            _pXN_Header.Note = PXN_Header_Row["Note"].ToString();
            _pXN_Header.Locked = PXN_Header_Row["Locked"].ToString() == "True" ? true : false;
            if (_pXN_Header.NgayNhanMau == DateTime.MinValue)
                _pXN_Header.NgayNhanMau = DateTime.Parse("2019-01-01");
            else
                DateTime.Parse(PXN_Header_Row["NgayNhanMau"].ToString(), CultureInfo.CreateSpecificCulture("en-GB"));
            //_pXN_Header.NgayDuKienTra = DateTime.MinValue ? DateTime.Parse("2019-01-01") : DateTime.Parse(PXN_Header_Row["NgayDuKienTra"].ToString(), CultureInfo.CreateSpecificCulture("en-GB"));
            // _pXN_Header.NgayCoKetQua = DateTime.MinValue ? DateTime.Parse("2019-01-01") : DateTime.Parse(PXN_Header_Row["NgayCoKetQua"].ToString(), CultureInfo.CreateSpecificCulture("en-GB"));
            // _pXN_Header.NgayTraKetQua = DateTime.MinValue ? DateTime.Parse("2019-01-01") : DateTime.Parse(PXN_Header_Row["NgayTraKetQua"].ToString(), CultureInfo.CreateSpecificCulture("en-GB"));
            _pXN_Header.KHMau = PXN_Header_Row["KHMau"].ToString();
            //_pXN_Header.Khac = PXN_Header_Row["Khac"].ToString();
            _pXN_Header.PTNThucHien = PXN_Header_Row["PTNThucHien"].ToString() == "True" ? true : false;
            _pXN_Header.LoaiXN = PXN_Header_Row["LoaiXN"].ToString();
            _pXN_Header.NgonNgu = PXN_Header_Row["NgonNgu"].ToString();
            _pXN_Header.SendMail = PXN_Header_Row["SendMail"].ToString();
            _pXN_Header.DichTeDan = PXN_Header_Row["DichTeDan"].ToString() == "True" ? true : false;
            if (PXN_Header_Row["CUSTCODE_ID"].ToString() == string.Empty)
                _pXN_Header.CUSTCODE_ID = 0;
            else
                _pXN_Header.CUSTCODE_ID = int.Parse(PXN_Header_Row["CUSTCODE_ID"].ToString());

            if (PXN_Header_Row["EMPCode_ID"].ToString() == string.Empty)
                _pXN_Header.EMPCode_ID = 0;
            else
                _pXN_Header.EMPCode_ID = int.Parse(PXN_Header_Row["EMPCode_ID"].ToString());

            _pXN_Header.DaXuatHoaDon = PXN_Header_Row["DaXuatHoaDon"].ToString() == "True" ? true : false;

            if (string.IsNullOrEmpty(PXN_Header_Row["NgayXuatHoaDon"].ToString()))
                _pXN_Header.NgayXuatHoaDon = DateTime.Parse("2019-01-01");
            else
                _pXN_Header.NgayXuatHoaDon = DateTime.Parse(PXN_Header_Row["NgayXuatHoaDon"].ToString(), CultureInfo.CreateSpecificCulture("en-GB"));
            _pXN_Header.SoHoaDon = PXN_Header_Row["SoHoaDon"].ToString();
            _pXN_Header.DaThuTien = PXN_Header_Row["DaThuTien"].ToString() == "True" ? true : false;

            if (string.IsNullOrEmpty(PXN_Header_Row["NgayThuTien"].ToString()))
                _pXN_Header.NgayThuTien = DateTime.Parse("2019-01-01");
            else
                _pXN_Header.NgayThuTien = DateTime.Parse(PXN_Header_Row["NgayThuTien"].ToString(), CultureInfo.CreateSpecificCulture("en-GB"));
            if (PXN_Header_Row["SoTienHoaDon"].ToString() == string.Empty)
                _pXN_Header.SoTienHoaDon = 0;
            else
                _pXN_Header.SoTienHoaDon = float.Parse(PXN_Header_Row["SoTienHoaDon"].ToString());

            _pXN_Header.TraTruoc = PXN_Header_Row["TraTruoc"].ToString() == "True" ? true : false;

            if (string.IsNullOrEmpty(PXN_Header_Row["NgayTraTruoc"].ToString()))
                _pXN_Header.NgayTraTruoc = DateTime.Parse("2019-01-01");
            else
                _pXN_Header.NgayTraTruoc = DateTime.Parse(PXN_Header_Row["NgayTraTruoc"].ToString(), CultureInfo.CreateSpecificCulture("en-GB"));
            if (PXN_Header_Row["SoTienTraTruoc"].ToString() == string.Empty)
                _pXN_Header.SoTienTraTruoc = 0;
            else
                _pXN_Header.SoTienTraTruoc = float.Parse(PXN_Header_Row["SoTienTraTruoc"].ToString());

            if (PXN_Header_Row["SoTienDaThu"].ToString() == string.Empty)
                _pXN_Header.SoTienDaThu = 0;
            else
                _pXN_Header.SoTienDaThu = float.Parse(PXN_Header_Row["SoTienDaThu"].ToString());

            _pXN_Header.NoiDungHoaDon = PXN_Header_Row["NoiDungHoaDon"].ToString();
            _pXN_Header.NoiDungTraTruoc = PXN_Header_Row["NoiDungTraTruoc"].ToString();

            if (string.IsNullOrEmpty(PXN_Header_Row["DonViXuatHoaDon_ID"].ToString()))
                _pXN_Header.DonViXuatHoaDon_ID = 0;
            else
                _pXN_Header.DonViXuatHoaDon_ID = int.Parse(PXN_Header_Row["DonViXuatHoaDon_ID"].ToString());

            //_pXN_Header.NgayGiaoMau = DateTime.Parse(PXN_Header_Row["NgayGiaoMau"].ToString(), CultureInfo.CreateSpecificCulture("en-GB"));
            _pXN_Header.NguoiGiaoMau = PXN_Header_Row["NguoiGiaoMau"].ToString();
            _pXN_Header.GiaoMau = PXN_Header_Row["GiaoMau"].ToString() == "True" ? true : false;           


            List<KHMau_LAB> List_KHMau_LAB = new List<KHMau_LAB>();
            foreach ( DataRow KHMau_LAB_Row in KHMau_LAB_dt.Rows)
            {
                //MessageBox.Show("KHMau : " + KHMau_LAB_Row["KHMau"].ToString());
                List_KHMau_LAB.Add
                                (
                                new KHMau_LAB()
                                {
                                    //ID = int.Parse(KHMau_LAB_Row["ID"].ToString()),
                                    //SoPXN = KHMau_LAB_Row["SoPXN"].ToString(),                                    
                                    KHMau = KHMau_LAB_Row["KHMau"].ToString(),
                                    //KHMau_GiaoMau = KHMau_LAB_Row["KHMau_GiaoMau"].ToString(),
                                    //KHMau_KhachHang = KHMau_LAB_Row["KHMau_KhachHang"].ToString(),
                                    SoLuongKHMau = KHMau_LAB_Row["SoLuongKHMau"].ToString(),
                                    DonViKHMau = KHMau_LAB_Row["DonViKHMau"].ToString(),
                                    //PhuongPhapBaoQuan = KHMau_LAB_Row["PhuongPhapBaoQuan"].ToString(),
                                    //VitriLuuKHMau = KHMau_LAB_Row["VitriLuuKHMau"].ToString(),
                                    //NgayLuuKHMau = DateTime.Parse(KHMau_LAB_Row["NgayLuuKHMau"].ToString(), CultureInfo.CreateSpecificCulture("en-GB")),
                                    //NhanVienLuuKHMau = KHMau_LAB_Row["NhanVienLuuKHMau"].ToString(),
                                    //NgayHuyKHMau = DateTime.Parse(KHMau_LAB_Row["NgayHuyKHMau"].ToString(), CultureInfo.CreateSpecificCulture("en-GB")),
                                    //TaiLieuHuyKHMau = KHMau_LAB_Row["TaiLieuHuyKHMau"].ToString(),
                                    //NhanVienHuyKHMau = KHMau_LAB_Row["NhanVienHuyKHMau"].ToString(),
                                    //TrangThaiKHMau = KHMau_LAB_Row["TrangThaiKHMau"].ToString() == "True" ? true : false,
                                    //SoLuongHuyKHMau = KHMau_LAB_Row["SoLuongHuyKHMau"].ToString(),
                                    //CreatedDate = DateTime.Parse(KHMau_LAB_Row["CreatedDate"].ToString(), CultureInfo.CreateSpecificCulture("en-GB")),
                                    //CreatedBy = KHMau_LAB_Row["CreatedBy"].ToString(),
                                    //Note = KHMau_LAB_Row["Note"].ToString(),
                                    //Locked = KHMau_LAB_Row["Locked"].ToString() == "True" ? true : false,
                                    NgayLayMau = DateTime.Parse(KHMau_LAB_Row["NgayLayMau"].ToString(), CultureInfo.CreateSpecificCulture("en-GB")),
                                    LoaiDVMauNuoc = KHMau_LAB_Row["LoaiDVMauNuoc"].ToString(),
                                    LoaiMauGui = KHMau_LAB_Row["LoaiMauGui"].ToString(),
                                    TTMauGui = KHMau_LAB_Row["TTMauGui"].ToString(),
                                    VTLayMauDayChuong = KHMau_LAB_Row["VTLayMauDayChuong"].ToString(),
                                    GioLayMauTuoi = KHMau_LAB_Row["GioLayMauTuoi"].ToString(),
                                    Khac = KHMau_LAB_Row["Khac"].ToString(),
                                    SoLuongKHMauKhongDat = KHMau_LAB_Row["SoLuongKHMauKhongDat"].ToString(),
                                    LiDoKHMauKhongDat = KHMau_LAB_Row["LiDoKHMauKhongDat"].ToString(),
                                    MotaMau = KHMau_LAB_Row["MotaMau"].ToString(),
                                    //BanGiaoMauStatus = KHMau_LAB_Row["BanGiaoMauStatus"].ToString() == "True" ? true : false,
                                    //NguoiNhanBanGiaoMau = KHMau_LAB_Row["NguoiNhanBanGiaoMau"].ToString(),
                                    //NguoiGiaoBanGiaoMau = KHMau_LAB_Row["NguoiGiaoBanGiaoMau"].ToString(),
                                    //NgayBanGiaoMau = DateTime.Parse(KHMau_LAB_Row["NgayBanGiaoMau"].ToString(), CultureInfo.CreateSpecificCulture("en-GB")),
                                    //LuuMau = KHMau_LAB_Row["LuuMau"].ToString() == "True" ? true : false,
                                    //HuyMau = KHMau_LAB_Row["HuyMau"].ToString() == "True" ? true : false
                                }
                                );

            }
            _pXN_Header.KHMau_LABs = List_KHMau_LAB;


            return _pXN_Header;
        }

}
}