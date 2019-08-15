using System;

namespace Production.Class
{
    //public class SUPPLIER
    public class PRICELIST
    {
        public PRICELIST(
            int ID,
            string PL,
            DateTime CreatedDate,
            string CreatedBy,
            bool Locked,
            DateTime EffDate,
            DateTime ExpDate,
            string Note

            )
        {
            this._ID = ID;
            this._PL = PL;
            this._EffDate = EffDate;
            this._ExpDate = ExpDate;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Locked = Locked;
            this._Note = Note;
        }

        public PRICELIST()
        {
        }

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _CTXNID;

        public string CTXNID
        {
            get { return _CTXNID; }
            set { _CTXNID = value; }
        }

        private string _PL;

        public string PL
        {
            get { return _PL; }
            set { _PL = value; }
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

        private DateTime _EffDate;

        public DateTime EffDate
        {
            get { return _EffDate; }
            set { _EffDate = value; }
        }

        private DateTime _ExpDate;

        public DateTime ExpDate
        {
            get { return _ExpDate; }
            set { _ExpDate = value; }
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