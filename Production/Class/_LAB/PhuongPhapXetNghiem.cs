using System;

namespace Production.Class
{
    public class PhuongPhapXetNghiem
    {
        public PhuongPhapXetNghiem(
            int ID,
            string PPXN,
            string PPXNDG,
            DateTime CreatedDate,
            string CreatedBy,
            string Note,
            bool Locked
            )
        {
            this._ID = ID;
            this._PPXN = PPXN;
            this._PPXNDG = PPXNDG;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Note = Note;
            this._Locked = Locked;
        }

        public PhuongPhapXetNghiem()
        {
        }

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _PPXN;

        public string PPXN
        {
            get { return _PPXN; }
            set { _PPXN = value; }
        }

        private string _PPXNDG;

        public string PPXNDG
        {
            get { return _PPXNDG; }
            set { _PPXNDG = value; }
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