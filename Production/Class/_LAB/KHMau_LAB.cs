using System;

namespace Production.Class
{
    public class KHMau_LAB
    {
        public KHMau_LAB()
        {
        }
        public int ID { set; get; }
        public string SoPXN { set; get; }
        public string KHMau { set; get; }
        public string KHMau_GiaoMau
        {
            set { }
            get { return KHMau.Substring(2, 1) + KHMau.Substring(KHMau.Length - 8, 8); }
        }
        public string KHMau_KhachHang { set; get; }
        public string SoLuongKHMau { set; get; }
        public string DonViKHMau { set; get; }
        public string PhuongPhapBaoQuan { set; get; }
        public string VitriLuuKHMau { set; get; }
        public DateTime NgayLuuKHMau { set; get; }
        public string NhanVienLuuKHMau { set; get; }
        public DateTime NgayHuyKHMau { set; get; }
        public string TaiLieuHuyKHMau { set; get; }
        public string NhanVienHuyKHMau { set; get; }
        public bool TrangThaiKHMau { set; get; }
        public string SoLuongHuyKHMau { set; get; }
        public DateTime CreatedDate { set; get; }
        public string CreatedBy { set; get; }
        public string Note { set; get; }
        public bool Locked { set; get; }
        public DateTime NgayLayMau { set; get; }
        public string LoaiDVMauNuoc { set; get; }
        public string LoaiMauGui { set; get; }
        public string TTMauGui { set; get; }
        public string VTLayMauDayChuong { set; get; }
        public string GioLayMauTuoi { set; get; }
        public string Khac { set; get; }
        public string SoLuongKHMauKhongDat { set; get; }
        public string LiDoKHMauKhongDat { set; get; }
        public string MotaMau { set; get; }
        public bool BanGiaoMauStatus { set; get; }
        public string NguoiNhanBanGiaoMau { set; get; }
        public string NguoiGiaoBanGiaoMau { set; get; }
        public DateTime NgayBanGiaoMau { set; get; }

    }
}