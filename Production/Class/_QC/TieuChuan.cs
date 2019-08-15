using System;

namespace Production.Class
{
    public class TieuChuan
    {
        public TieuChuan(
            int ID,
            string TC,
            string TCDG,
            DateTime CreatedDate,
            string CreatedBy,
            string Note,
            bool Locked
            )
        {
            this._ID = ID;
            this._TC = TC;
            this._TCDG = TCDG;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Note = Note;
            this._Locked = Locked;
        }

        public TieuChuan()
        {
        }

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _TC;

        public string TC
        {
            get { return _TC; }
            set { _TC = value; }
        }

        private string _TCDG;

        public string TCDG
        {
            get { return _TCDG; }
            set { _TCDG = value; }
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