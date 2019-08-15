using System;

namespace Production.Class
{
    //public class SUPPLIER
    public class PhuongPhapBaoQuan
    {
        public PhuongPhapBaoQuan(
            int ID,
            string PPBQ,
            string PPBQDG,
            string PPBQDGTA,
            DateTime CreatedDate,
            string CreatedBy,
            bool Locked,
            string Note
            )
        {
            this._ID = ID;
            this._PPBQ = PPBQ;
            this._PPBQDG = PPBQDG;
            this._PPBQDGTA = PPBQDGTA;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Locked = Locked;
            this._Note = Note;
        }

        public PhuongPhapBaoQuan()
        {
        }

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _PPBQ;

        public string PPBQ
        {
            get { return _PPBQ; }
            set { _PPBQ = value; }
        }

        private string _PPBQDG;

        public string PPBQDG
        {
            get { return _PPBQDG; }
            set { _PPBQDG = value; }
        }

        private string _PPBQDGTA;

        public string PPBQDGTA
        {
            get { return _PPBQDGTA; }
            set { _PPBQDGTA = value; }
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