using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Production.Class
{
    //public class SUPPLIER
    public class PRICELIST_Details
    {
        public PRICELIST_Details(
            int ID,
            int CTXNID,
            int PLID, 
            DateTime CreatedDate, 
            string CreatedBy, 
            bool Locked,
            string UoM,
            string DonGia,
            string DonGiaMuaNgoai,
            string SoLuong,
            string Giam,
            string UoMGiam,
            string Note,
            string VAT,
            string DVMuaNgoaiCode,
            string DVMuaNgoaiName,
            bool MuaNgoai
            )
        {
            this._ID = ID;
            this._CTXNID = CTXNID;
            this._PLID = PLID;
            this._UoM = UoM;
            this._DonGia = DonGia;
            this._DonGiaMuaNgoai = DonGiaMuaNgoai;
            this._SoLuong = SoLuong;
            this._Giam = Giam;
            this._UoMGiam = UoMGiam;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Locked = Locked;     
            this._Note = Note;
            this._VAT = VAT;
            this._DVMuaNgoaiCode = DVMuaNgoaiCode;
            this._DVMuaNgoaiName = DVMuaNgoaiName;
            this._MuaNgoai = MuaNgoai;
        }
        public PRICELIST_Details()
        {

        }

        private int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private int _CTXNID;
        public int CTXNID
        {
            get { return _CTXNID; }
            set { _CTXNID = value; }
        }

        private int _PLID;
        public int PLID
        {
            get { return _PLID; }
            set { _PLID = value; }
        }

        private string _UoM;
        public string UoM
        {
            get { return _UoM; }
            set { _UoM = value; }
        }

        private string _DonGia;
        public string DonGia
        {
            get { return _DonGia; }
            set { _DonGia = value; }
        }

        private string _DonGiaMuaNgoai;
        public string DonGiaMuaNgoai
        {
            get { return _DonGiaMuaNgoai; }
            set { _DonGiaMuaNgoai = value; }
        }

        private string _SoLuong;
        public string SoLuong
        {
            get { return _SoLuong; }
            set { _SoLuong = value; }
        }

        private string _Giam;
        public string Giam
        {
            get { return _Giam; }
            set { _Giam = value; }
        }

        private string _UoMGiam;
        public string UoMGiam
        {
            get { return _UoMGiam; }
            set { _UoMGiam = value; }
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

        private string _VAT;

        public string VAT
        {
            get { return _VAT; }
            set { _VAT = value; }
        }

        private string _DVMuaNgoaiCode;

        public string DVMuaNgoaiCode
        {
            get { return _DVMuaNgoaiCode; }
            set { _DVMuaNgoaiCode = value; }
        }

        private string _DVMuaNgoaiName;

        public string DVMuaNgoaiName
        {
            get { return _DVMuaNgoaiName; }
            set { _DVMuaNgoaiName = value; }
        }

        private bool _MuaNgoai;

        public bool MuaNgoai
        {
            get { return _MuaNgoai; }
            set { _MuaNgoai = value; }
        }


    }
}
