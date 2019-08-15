using System;

namespace Production.Class
{
    public class KHMau_CTXN_LAB
    {
        public KHMau_CTXN_LAB(
            int ID,
            int KHMau_ID,
            string KHMau,
            int CTXNID,
            //int NCTXNID,
            DateTime CreatedDate,
            string CreatedBy,
            string Note,
            bool Locked,
            float DonGia,
            float DonGiaMuaNgoai,
            float ThanhTien,
            bool KetQua,
            string SoLuongDat,
            string SoLuongXN,
            float VAT,
            float Discount,
            string LoaiDiscount,
            float DonGiaSauDiscount,
            int PriceList_Details_LAB_Id,
            string NgayCoKetQua
            )
        {
            this._ID = ID;
            this._KHMau_ID = KHMau_ID;
            this._KHMau = KHMau;
            this._CTXNID = CTXNID;
            //this._NCTXNID = NCTXNID;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Note = Note;
            this._DonGia = DonGia;
            this._DonGiaMuaNgoai = DonGiaMuaNgoai;
            this._ThanhTien = ThanhTien;
            this._KetQua = KetQua;
            this._SoLuongDat = SoLuongDat;
            this._SoLuongXN = SoLuongXN;
            this._VAT = VAT;
            this._Locked = Locked;
            this._PriceList_Details_LAB_Id = PriceList_Details_LAB_Id;
            this._NgayCoKetQua = NgayCoKetQua;
        }

        public KHMau_CTXN_LAB()
        {
        }

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private int _KHMau_ID;

        public int KHMau_ID
        {
            get { return _KHMau_ID; }
            set { _KHMau_ID = value; }
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

        private int _CTXNID;

        public int CTXNID
        {
            get { return _CTXNID; }
            set { _CTXNID = value; }
        }

        //private int _NCTXNID;

        //public int NCTXNID
        //{
        // get { return _NCTXNID; }
        //set { _NCTXNID = value; }
        //}

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

        private float _DonGia;

        public float DonGia
        {
            get { return _DonGia; }
            set { _DonGia = value; }
        }

        private float _DonGiaMuaNgoai;

        public float DonGiaMuaNgoai
        {
            get { return _DonGiaMuaNgoai; }
            set { _DonGiaMuaNgoai = value; }
        }

        private float _ThanhTien;

        public float ThanhTien
        {
            get { return _ThanhTien; }
            set { _ThanhTien = value; }
        }

        private bool _KetQua;

        public bool KetQua
        {
            get { return _KetQua; }
            set { _KetQua = value; }
        }

        private string _SoLuongDat;

        public string SoLuongDat
        {
            get { return _SoLuongDat; }
            set { _SoLuongDat = value; }
        }

        private string _SoLuongXN;

        public string SoLuongXN
        {
            get { return _SoLuongXN; }
            set { _SoLuongXN = value; }
        }

        private float _VAT;

        public float VAT
        {
            get { return _VAT; }
            set { _VAT = value; }
        }

        //float Discount,
        //    string LoaiDiscount,
        //    float DonGiaSauDiscount

        private float _Discount;

        public float Discount
        {
            get { return _Discount; }
            set { _Discount = value; }
        }

        private string _LoaiDiscount;

        public string LoaiDiscount
        {
            get { return _LoaiDiscount; }
            set { _LoaiDiscount = value; }
        }

        private float _DonGiaSauDiscount;

        public float DonGiaSauDiscount
        {
            get { return _DonGiaSauDiscount; }
            set { _DonGiaSauDiscount = value; }
        }

        //PriceList_Details_LAB_Id
        private int _PriceList_Details_LAB_Id;

        public int PriceList_Details_LAB_Id
        {
            get { return _PriceList_Details_LAB_Id; }
            set { _PriceList_Details_LAB_Id = value; }
        }

        private string _NgayCoKetQua;

        public string NgayCoKetQua
        {
            get { return _NgayCoKetQua; }
            set { _NgayCoKetQua = value; }
        }
    }
}