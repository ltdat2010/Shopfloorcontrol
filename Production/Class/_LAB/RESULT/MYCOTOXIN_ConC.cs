using System;

namespace Production.Class
{
    //public class SUPPLIER
    public class MYCOTOXIN_ConC
    {
        public MYCOTOXIN_ConC(
            int ID,
            int CTXN_ID,
            double ConC,
            string KHMau,
            DateTime CreatedDate,
            string CreatedBy,
            bool Locked,
            string Note
            )
        {
            this._ID = ID;
            this._CTXN_ID = CTXN_ID;
            this._ConC = ConC;
            this._KHMau = KHMau;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Locked = Locked;
            this._Note = Note;
        }

        public MYCOTOXIN_ConC()
        {
        }

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private int _CTXN_ID;

        public int CTXN_ID
        {
            get { return _CTXN_ID; }
            set { _CTXN_ID = value; }
        }

        private double _ConC;

        public double ConC
        {
            get { return _ConC; }
            set { _ConC = value; }
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