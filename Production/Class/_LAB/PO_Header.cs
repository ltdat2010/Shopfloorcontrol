using System;

namespace Production.Class
{
    //public class SUPPLIER
    public class PO_Header
    {
        public PO_Header(
            int ID,
            string SoPO,
            string VENDCode,
            string VENDName,
            DateTime NgayLapPO,
            DateTime NgayGiaoHang,
            string DiaChiGiaoHang,
            string PaymentTerm,
            DateTime CreatedDate,
            string CreatedBy,
            bool Locked,
            string Note,
            string Discount

            )
        {
            this._ID = ID;
            this._SoPO = SoPO;
            this._VENDCode = VENDCode;
            this._VENDName = VENDName;
            this._NgayLapPO = NgayLapPO;
            this._NgayGiaoHang = NgayGiaoHang;
            this._DiaChiGiaoHang = DiaChiGiaoHang;
            this._PaymentTerm = PaymentTerm;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Locked = Locked;
            this._Note = Note;
            this._Discount = Discount;
        }

        public PO_Header()
        {
        }

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _SoPO;

        public string SoPO
        {
            get { return _SoPO; }
            set { _SoPO = value; }
        }

        private string _VENDCode;

        public string VENDCode
        {
            get { return _VENDCode; }
            set { _VENDCode = value; }
        }

        private string _VENDName;

        public string VENDName
        {
            get { return _VENDName; }
            set { _VENDName = value; }
        }

        private DateTime _NgayLapPO;

        public DateTime NgayLapPO
        {
            get { return _NgayLapPO; }
            set { _NgayLapPO = value; }
        }

        private DateTime _NgayGiaoHang;

        public DateTime NgayGiaoHang
        {
            get { return _NgayGiaoHang; }
            set { _NgayGiaoHang = value; }
        }

        private string _DiaChiGiaoHang;

        public string DiaChiGiaoHang
        {
            get { return _DiaChiGiaoHang; }
            set { _DiaChiGiaoHang = value; }
        }

        private string _PaymentTerm;

        public string PaymentTerm
        {
            get { return _PaymentTerm; }
            set { _PaymentTerm = value; }
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

        private string _Discount;

        public string Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }
    }
}