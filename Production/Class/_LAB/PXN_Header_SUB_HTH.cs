using System;

namespace Production.Class
{
    public class PXN_Header_SUB_HTH
    {
        public PXN_Header_SUB_HTH(
            int ID,
            string MaSoPXN,
            DateTime NgayLayMau,
            string Tuoi,
            string LoaiDV,
            string DayChuong,
            string LoaiMau,
            string SLMau,
            string TTMau,
            string KHMau,    
            DateTime CreatedDate,
            string CreatedBy,
            string Note,
            bool Locked
            )
        {
            this._ID = ID;
            this._MaSoPXN = MaSoPXN;
            this._NgayLayMau = NgayLayMau;
            this._Tuoi = Tuoi;
            this._LoaiDV = LoaiDV;
            this._DayChuong = DayChuong;
            this._LoaiMau = LoaiMau;
            this._SLMau = SLMau;
            this._TTMau = TTMau;
            this._KHMau = KHMau;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Note = Note;
            this._Locked = Locked;

        }
        public PXN_Header_SUB_HTH()
        {

        }
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _MaSoPXN;

        public string MaSoPXN
        {
            get { return _MaSoPXN; }
            set { _MaSoPXN = value; }
        }
        private DateTime _NgayLayMau;

        public DateTime NgayLayMau
        {
            get { return _NgayLayMau; }
            set { _NgayLayMau = value; }
        }
        private string _Tuoi;

        public string Tuoi
        {
            get { return _Tuoi; }
            set { _Tuoi = value; }
        }

        private string _LoaiDV;

        public string LoaiDV
        {
            get { return _LoaiDV; }
            set { _LoaiDV = value; }
        }
        private string _DayChuong;

        public string DayChuong
        {
            get { return _DayChuong; }
            set { _DayChuong = value; }
        }
        private string _LoaiMau;

        public string LoaiMau
        {
            get { return _LoaiMau; }
            set { _LoaiMau = value; }
        }
        private string _SLMau;

        public string SLMau
        {
            get { return _SLMau; }
            set { _SLMau = value; }
        }
        private string _TTMau;

        public string TTMau
        {
            get { return _TTMau; }
            set { _TTMau = value; }
        }

        private string _KHMau;

        public string KHMau
        {
            get { return _KHMau; }
            set { _KHMau = value; }
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
    }
}
