using System;

namespace Production.Class
{
    public class PXN_Header
    {
        public PXN_Header(
            int ID,
            string SoPXN,
            string PXNDescription,
            string CoSoGuiMau,
            string MaCoSoGuiMau,
            string TenCoSoGuiMau,
            string DCCoSoGuiMau,
            string PhoneCoSoGuiMau,
            string FaxCoSoGuiMau,
            string EmailCoSoGuiMau,
            string MSTCoSoGuiMau,
            string CoSoLayMau,
            string MaCoSoLayMau,
            string TenCoSoLayMau,
            string DCCoSoLayMau,
            string PhoneCoSoLayMau,
            string FaxCoSoLayMau,
            string EmailCoSoLayMau,
            DateTime CreatedDate,
            string CreatedBy,
            string Note,
            bool Locked,
            DateTime NgayNhanMau,
            DateTime NgayDuKienTra,
            DateTime NgayCoKetQua,
            DateTime NgayTraKetQua,
            //DateTime NgayLayMau,
            //string LoaiDVMauNuoc,
            //string LoaiMauGui,
            //string SLMauGui,
            //string TTMauGui,
            //string VTLayMauDayChuong,
            //string GioLayMauTuoi,
            string KHMau,
            string Khac,
            bool PTNThucHien,
            string LoaiXN,
            string NgonNgu,
            string SendMail,
            bool DichTeDan,
            int CUSTCODE_ID,
            int EMPCode_ID,
            ////////////// HOA DON - THANH TOAN /////////////////
            bool DaXuatHoaDon,
            DateTime NgayXuatHoaDon,
            string SoHoaDon,
            bool DaThuTien,
            DateTime NgayThuTien,
            float SoTienHoaDon,
            bool TraTruoc,
            DateTime NgayTraTruoc,
            float SoTienTraTruoc,
            string NoiDungHoaDon,
            int DonViXuatHoaDon_ID

            )
        {
            this._ID = ID;
            this._SoPXN = SoPXN;
            this._PXNDescription = PXNDescription;
            this._CoSoGuiMau = CoSoGuiMau;
            this._MaCoSoGuiMau = MaCoSoGuiMau;
            this._TenCoSoGuiMau = TenCoSoGuiMau;
            this._DCCoSoGuiMau = DCCoSoGuiMau;
            this._PhoneCoSoGuiMau = PhoneCoSoGuiMau;
            this._FaxCoSoGuiMau = FaxCoSoGuiMau;
            this._EmailCoSoGuiMau = EmailCoSoGuiMau;
            this._MSTCoSoGuiMau = MSTCoSoGuiMau;
            this._CoSoLayMau = CoSoLayMau;
            this._MaCoSoLayMau = MaCoSoLayMau;
            this._TenCoSoLayMau = TenCoSoLayMau;
            this._DCCoSoLayMau = DCCoSoLayMau;
            this._PhoneCoSoLayMau = PhoneCoSoLayMau;
            this._FaxCoSoLayMau = FaxCoSoLayMau;
            this._EmailCoSoLayMau = EmailCoSoLayMau;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Note = Note;
            this._Locked = Locked;
            this._SendMail = SendMail;
            this._NgayNhanMau = NgayNhanMau;
            this._NgayDuKienTra = NgayDuKienTra;
            this._NgayCoKetQua = NgayCoKetQua;
            this._NgayTraKetQua = NgayTraKetQua;
            //this._LoaiDVMauNuoc = LoaiDVMauNuoc;
            //this._NgayLayMau = NgayLayMau;
            //this._LoaiMauGui = LoaiMauGui;
            //this._SLMauGui = SLMauGui;
            //this._TTMauGui = TTMauGui;
            //this._VTLayMauDayChuong = VTLayMauDayChuong;
            //this._GioLayMauTuoi = GioLayMauTuoi;
            this._KHMau = KHMau;
            this._Khac = Khac;
            this._PTNThucHien = PTNThucHien;
            this._LoaiXN = LoaiXN;
            this._NgonNgu = NgonNgu;
            this._DichTeDan = DichTeDan;
            this._CUSTCODE_ID = CUSTCODE_ID;
            this._EMPCode_ID = EMPCode_ID;
            ////////////// HOA DON - THANH TOAN /////////////////
            this._DaXuatHoaDon = DaXuatHoaDon;
            this._NgayXuatHoaDon = NgayXuatHoaDon;
            this._SoHoaDon = SoHoaDon;
            this._DaThuTien = DaThuTien;
            this._NgayThuTien = NgayThuTien;
            this._SoTienDaThu = SoTienDaThu;
            this._SoTienHoaDon = SoTienHoaDon;
            this._TraTruoc = TraTruoc;
            this._NgayTraTruoc = NgayTraTruoc;
            this._SoTienTraTruoc = SoTienTraTruoc;
            this._NoiDungHoaDon = NoiDungHoaDon;
            this._NoiDungTraTruoc = NoiDungTraTruoc;
            this._DonViXuatHoaDon_ID = DonViXuatHoaDon_ID;
        }

        public PXN_Header()
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

        private string _PXNDescription;

        public string PXNDescription
        {
            get { return _PXNDescription; }
            set { _PXNDescription = value; }
        }

        private string _CoSoGuiMau;

        public string CoSoGuiMau
        {
            get { return _CoSoGuiMau; }
            set { _CoSoGuiMau = value; }
        }

        private string _MaCoSoGuiMau;

        public string MaCoSoGuiMau
        {
            get { return _MaCoSoGuiMau; }
            set { _MaCoSoGuiMau = value; }
        }

        private string _TenCoSoGuiMau;

        public string TenCoSoGuiMau
        {
            get { return _TenCoSoGuiMau; }
            set { _TenCoSoGuiMau = value; }
        }

        private string _DCCoSoGuiMau;

        public string DCCoSoGuiMau
        {
            get { return _DCCoSoGuiMau; }
            set { _DCCoSoGuiMau = value; }
        }

        private string _PhoneCoSoGuiMau;

        public string PhoneCoSoGuiMau
        {
            get { return _PhoneCoSoGuiMau; }
            set { _PhoneCoSoGuiMau = value; }
        }

        private string _FaxCoSoGuiMau;

        public string FaxCoSoGuiMau
        {
            get { return _FaxCoSoGuiMau; }
            set { _FaxCoSoGuiMau = value; }
        }

        private string _EmailCoSoGuiMau;

        public string EmailCoSoGuiMau
        {
            get { return _EmailCoSoGuiMau; }
            set { _EmailCoSoGuiMau = value; }
        }

        private string _MSTCoSoGuiMau;

        public string MSTCoSoGuiMau
        {
            get { return _MSTCoSoGuiMau; }
            set { _MSTCoSoGuiMau = value; }
        }

        private string _CoSoLayMau;

        public string CoSoLayMau
        {
            get { return _CoSoLayMau; }
            set { _CoSoLayMau = value; }
        }

        private string _MaCoSoLayMau;

        public string MaCoSoLayMau
        {
            get { return _MaCoSoLayMau; }
            set { _MaCoSoLayMau = value; }
        }

        private string _TenCoSoLayMau;

        public string TenCoSoLayMau
        {
            get { return _TenCoSoLayMau; }
            set { _TenCoSoLayMau = value; }
        }

        private string _DCCoSoLayMau;

        public string DCCoSoLayMau
        {
            get { return _DCCoSoLayMau; }
            set { _DCCoSoLayMau = value; }
        }

        private string _PhoneCoSoLayMau;

        public string PhoneCoSoLayMau
        {
            get { return _PhoneCoSoLayMau; }
            set { _PhoneCoSoLayMau = value; }
        }

        private string _FaxCoSoLayMau;

        public string FaxCoSoLayMau
        {
            get { return _FaxCoSoLayMau; }
            set { _FaxCoSoLayMau = value; }
        }

        private string _EmailCoSoLayMau;

        public string EmailCoSoLayMau
        {
            get { return _EmailCoSoLayMau; }
            set { _EmailCoSoLayMau = value; }
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

        private DateTime _NgayNhanMau;

        public DateTime NgayNhanMau
        {
            get { return _NgayNhanMau; }
            set { _NgayNhanMau = value; }
        }

        private DateTime _NgayDuKienTra;

        public DateTime NgayDuKienTra
        {
            get { return _NgayDuKienTra; }
            set { _NgayDuKienTra = value; }
        }

        private DateTime _NgayCoKetQua;

        public DateTime NgayCoKetQua
        {
            get { return _NgayCoKetQua; }
            set { _NgayCoKetQua = value; }
        }

        private DateTime _NgayTraKetQua;

        public DateTime NgayTraKetQua
        {
            get { return _NgayTraKetQua; }
            set { _NgayTraKetQua = value; }
        }

        //private string _LoaiMauGui;
        //public string LoaiMauGui
        //{
        //    get { return _LoaiMauGui; }
        //    set { _LoaiMauGui = value; }
        //}
        //private string _LoaiDVMauNuoc;
        //public string LoaiDVMauNuoc
        //{
        //    get { return _LoaiDVMauNuoc; }
        //    set { _LoaiDVMauNuoc = value; }
        //}

        //private string _SLMauGui;
        //public string SLMauGui
        //{
        //    get { return _SLMauGui; }
        //    set { _SLMauGui = value; }
        //}

        //private DateTime _NgayLayMau;
        //public DateTime NgayLayMau
        //{
        //    get { return _NgayLayMau; }
        //    set { _NgayLayMau = value; }
        //}
        //private string _TTMauGui;
        //public string TTMauGui
        //{
        //    get { return _TTMauGui; }
        //    set { _TTMauGui = value; }
        //}

        //private string _VTLayMauDayChuong;
        //public string VTLayMauDayChuong
        //{
        //    get { return _VTLayMauDayChuong; }
        //    set { _VTLayMauDayChuong = value; }
        //}

        private string _SendMail;

        public string SendMail
        {
            get { return _SendMail; }
            set { _SendMail = value; }
        }

        private string _KHMau;

        public string KHMau
        {
            get { return _KHMau; }
            set { _KHMau = value; }
        }

        private string _Khac;

        public string Khac
        {
            get { return _Khac; }
            set { _Khac = value; }
        }

        private bool _PTNThucHien;

        public bool PTNThucHien
        {
            get { return _PTNThucHien; }
            set { _PTNThucHien = value; }
        }

        private string _LoaiXN;

        public string LoaiXN
        {
            get { return _LoaiXN; }
            set { _LoaiXN = value; }
        }

        private string _NgonNgu;

        public string NgonNgu
        {
            get { return _NgonNgu; }
            set { _NgonNgu = value; }
        }

        private bool _DichTeDan;

        public bool DichTeDan
        {
            get { return _DichTeDan; }
            set { _DichTeDan = value; }
        }

        private int _CUSTCODE_ID;

        public int CUSTCODE_ID
        {
            get { return _CUSTCODE_ID; }
            set { _CUSTCODE_ID = value; }
        }

        private int _EMPCode_ID;

        public int EMPCode_ID
        {
            get { return _EMPCode_ID; }
            set { _EMPCode_ID = value; }
        }

        ////////////// HOA DON - THANH TOAN /////////////////
        //this._DaXuatHoaDon = DaXuatHoaDon;
        //this._NgayXuatHoaDon = NgayXuatHoaDon;
        //this._SoHoaDon = SoHoaDon;
        //this._DaThuTien = DaThuTien;
        //this._NgayThuTien = NgayThuTien;
        //this._SoTienHoaDon = SoTienHoaDon;
        //this._TraTruoc = TraTruoc;
        //this._NgayTraTruoc = NgayTraTruoc;
        //this._SoTienTraTruoc = SoTienTraTruoc;
        //this._NoiDungHoaDon = NoiDungHoaDon;
        private bool _DaXuatHoaDon;

        public bool DaXuatHoaDon
        {
            get { return _DaXuatHoaDon; }
            set { _DaXuatHoaDon = value; }
        }

        private DateTime _NgayXuatHoaDon;

        public DateTime NgayXuatHoaDon
        {
            get { return _NgayXuatHoaDon; }
            set { _NgayXuatHoaDon = value; }
        }

        private string _SoHoaDon;

        public string SoHoaDon
        {
            get { return _SoHoaDon; }
            set { _SoHoaDon = value; }
        }

        private bool _DaThuTien;

        public bool DaThuTien
        {
            get { return _DaThuTien; }
            set { _DaThuTien = value; }
        }

        private DateTime _NgayThuTien;

        public DateTime NgayThuTien
        {
            get { return _NgayThuTien; }
            set { _NgayThuTien = value; }
        }

        private float _SoTienHoaDon;

        public float SoTienHoaDon
        {
            get { return _SoTienHoaDon; }
            set { _SoTienHoaDon = value; }
        }

        private bool _TraTruoc;

        public bool TraTruoc
        {
            get { return _TraTruoc; }
            set { _TraTruoc = value; }
        }

        private DateTime _NgayTraTruoc;

        public DateTime NgayTraTruoc
        {
            get { return _NgayTraTruoc; }
            set { _NgayTraTruoc = value; }
        }

        private float _SoTienDaThu;

        public float SoTienDaThu
        {
            get { return _SoTienDaThu; }
            set { _SoTienDaThu = value; }
        }

        private float _SoTienTraTruoc;

        public float SoTienTraTruoc
        {
            get { return _SoTienTraTruoc; }
            set { _SoTienTraTruoc = value; }
        }

        private string _NoiDungHoaDon;

        public string NoiDungHoaDon
        {
            get { return _NoiDungHoaDon; }
            set { _NoiDungHoaDon = value; }
        }

        private string _NoiDungTraTruoc;

        public string NoiDungTraTruoc
        {
            get { return _NoiDungTraTruoc; }
            set { _NoiDungTraTruoc = value; }
        }

        private int _DonViXuatHoaDon_ID;

        public int DonViXuatHoaDon_ID
        {
            get { return _DonViXuatHoaDon_ID; }
            set { _DonViXuatHoaDon_ID = value; }
        }
    }
}