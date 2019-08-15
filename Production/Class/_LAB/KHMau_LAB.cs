using System;

namespace Production.Class
{
    public class KHMau_LAB
    {
        public KHMau_LAB(
               int ID,
               string SoPXN,
               string KHMau,
               string KHMau_KhachHang,
               string SoLuongKHMau,
               string DonViKHMau,
               string PhuongPhapBaoQuan,
               string VitriLuuKHMau,
               DateTime NgayLuuKHMau,
               string NhanVienLuuKHMau,
               DateTime NgayHuyKHMau,
               string TaiLieuHuyKHMau,
               string NhanVienHuyKHMau,
               bool TrangThaiKHMau,
               string SoLuongHuyKHMau,
               DateTime CreatedDate,
               string CreatedBy,
               string Note,
               bool Locked,
               DateTime NgayLayMau,
               string LoaiDVMauNuoc,
               string LoaiMauGui,
               string TTMauGui,
               string VTLayMauDayChuong,
               string GioLayMauTuoi,
               string Khac,
               string SoLuongKHMauKhongDat,
               string LiDoKHMauKhongDat,
               string MotaMau,
               bool BanGiaoMauStatus,
               string NguoiNhanBanGiaoMau,
               string NguoiGiaoBanGiaoMau,
               DateTime NgayBanGiaoMau
            )
        {
            this._ID = ID;
            this._SoPXN = SoPXN;
            this._KHMau = KHMau;
            this._KHMau_KhachHang = KHMau_KhachHang;
            this._SoLuongKHMau = SoLuongKHMau;
            this._DonViKHMau = DonViKHMau;
            this._PhuongPhapBaoQuan = PhuongPhapBaoQuan;
            this._VitriLuuKHMau = VitriLuuKHMau;
            this._NgayLuuKHMau = NgayLuuKHMau;
            this._NhanVienLuuKHMau = NhanVienLuuKHMau;
            this._NgayHuyKHMau = NgayHuyKHMau;
            this._TaiLieuHuyKHMau = TaiLieuHuyKHMau;
            this._NhanVienHuyKHMau = NhanVienHuyKHMau;
            this._TrangThaiKHMau = TrangThaiKHMau;
            this._SoLuongHuyKHMau = SoLuongHuyKHMau;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Note = Note;
            this._Locked = Locked;
            this._LoaiDVMauNuoc = LoaiDVMauNuoc;
            this._NgayLayMau = NgayLayMau;
            this._LoaiMauGui = LoaiMauGui;
            this._TTMauGui = TTMauGui;
            this._VTLayMauDayChuong = VTLayMauDayChuong;
            this._GioLayMauTuoi = GioLayMauTuoi;
            this._Khac = Khac;
            this._SoLuongKHMauKhongDat = SoLuongKHMauKhongDat;
            this._LiDoKHMauKhongDat = LiDoKHMauKhongDat;
            this._MotaMau = MotaMau;
            this._BanGiaoMauStatus = BanGiaoMauStatus;
            this._NguoiNhanBanGiaoMau = NguoiNhanBanGiaoMau;
            this._NguoiGiaoBanGiaoMau = NguoiGiaoBanGiaoMau;
            this._NgayBanGiaoMau = NgayBanGiaoMau;
        }

        public KHMau_LAB()
        {
        }

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _SoPXN;

        public string SoPXN
        {
            get { return _SoPXN; }
            set { _SoPXN = value; }
        }

        private string _KHMau;

        public string KHMau
        {
            get { return _KHMau; }
            set { _KHMau = value; }
        }

        private string _KHMau_KhachHang;

        public string KHMau_KhachHang
        {
            get { return _KHMau_KhachHang; }
            set { _KHMau_KhachHang = value; }
        }

        private string _SoLuongKHMau;

        public string SoLuongKHMau
        {
            get { return _SoLuongKHMau; }
            set { _SoLuongKHMau = value; }
        }

        private string _DonViKHMau;

        public string DonViKHMau
        {
            get { return _DonViKHMau; }
            set { _DonViKHMau = value; }
        }

        private string _PhuongPhapBaoQuan;

        public string PhuongPhapBaoQuan
        {
            get { return _PhuongPhapBaoQuan; }
            set { _PhuongPhapBaoQuan = value; }
        }

        private string _VitriLuuKHMau;

        public string VitriLuuKHMau
        {
            get { return _VitriLuuKHMau; }
            set { _VitriLuuKHMau = value; }
        }

        private DateTime _NgayLuuKHMau;

        public DateTime NgayLuuKHMau
        {
            get { return _NgayLuuKHMau; }
            set { _NgayLuuKHMau = value; }
        }

        private string _NhanVienLuuKHMau;

        public string NhanVienLuuKHMau
        {
            get { return _NhanVienLuuKHMau; }
            set { _NhanVienLuuKHMau = value; }
        }

        private DateTime _NgayHuyKHMau;

        public DateTime NgayHuyKHMau
        {
            get { return _NgayHuyKHMau; }
            set { _NgayHuyKHMau = value; }
        }

        private string _TaiLieuHuyKHMau;

        public string TaiLieuHuyKHMau
        {
            get { return _TaiLieuHuyKHMau; }
            set { _TaiLieuHuyKHMau = value; }
        }

        private string _NhanVienHuyKHMau;

        public string NhanVienHuyKHMau
        {
            get { return _NhanVienHuyKHMau; }
            set { _NhanVienHuyKHMau = value; }
        }

        private bool _TrangThaiKHMau;

        public bool TrangThaiKHMau
        {
            get { return _TrangThaiKHMau; }
            set { _TrangThaiKHMau = value; }
        }

        private string _SoLuongHuyKHMau;

        public string SoLuongHuyKHMau
        {
            get { return _SoLuongHuyKHMau; }
            set { _SoLuongHuyKHMau = value; }
        }

        private DateTime _CreatedDate;

        public DateTime CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }

        private string _CreatedBy;

        public string CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }

        private bool _Locked;

        public bool Locked
        {
            get { return _Locked; }
            set { _Locked = value; }
        }

        private string _Note;

        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }

        private string _LoaiMauGui;

        public string LoaiMauGui
        {
            get { return _LoaiMauGui; }
            set { _LoaiMauGui = value; }
        }

        private string _LoaiDVMauNuoc;

        public string LoaiDVMauNuoc
        {
            get { return _LoaiDVMauNuoc; }
            set { _LoaiDVMauNuoc = value; }
        }

        private DateTime _NgayLayMau;

        public DateTime NgayLayMau
        {
            get { return _NgayLayMau; }
            set { _NgayLayMau = value; }
        }

        private string _TTMauGui;

        public string TTMauGui
        {
            get { return _TTMauGui; }
            set { _TTMauGui = value; }
        }

        private string _VTLayMauDayChuong;

        public string VTLayMauDayChuong
        {
            get { return _VTLayMauDayChuong; }
            set { _VTLayMauDayChuong = value; }
        }

        private string _GioLayMauTuoi;

        public string GioLayMauTuoi
        {
            get { return _GioLayMauTuoi; }
            set { _GioLayMauTuoi = value; }
        }

        private string _Khac;

        public string Khac
        {
            get { return _Khac; }
            set { _Khac = value; }
        }

        private string _SoLuongKHMauKhongDat;

        public string SoLuongKHMauKhongDat
        {
            get { return _SoLuongKHMauKhongDat; }
            set { _SoLuongKHMauKhongDat = value; }
        }

        private string _LiDoKHMauKhongDat;

        public string LiDoKHMauKhongDat
        {
            get { return _LiDoKHMauKhongDat; }
            set { _LiDoKHMauKhongDat = value; }
        }

        private string _MotaMau;

        public string MotaMau
        {
            get { return _MotaMau; }
            set { _MotaMau = value; }
        }

        private bool _BanGiaoMauStatus;

        public bool BanGiaoMauStatus
        {
            get { return _BanGiaoMauStatus; }
            set { _BanGiaoMauStatus = value; }
        }

        private string _NguoiNhanBanGiaoMau;

        public string NguoiNhanBanGiaoMau
        {
            get { return _NguoiNhanBanGiaoMau; }
            set { _NguoiNhanBanGiaoMau = value; }
        }

        private string _NguoiGiaoBanGiaoMau;

        public string NguoiGiaoBanGiaoMau
        {
            get { return _NguoiGiaoBanGiaoMau; }
            set { _NguoiGiaoBanGiaoMau = value; }
        }

        private DateTime _NgayBanGiaoMau;

        public DateTime NgayBanGiaoMau
        {
            get { return _NgayBanGiaoMau; }
            set { _NgayBanGiaoMau = value; }
        }
    }
}