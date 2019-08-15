using System;

namespace Production.Class
{
    //public class SUPPLIER
    public class ChiTieuPhanTich
    {
        public ChiTieuPhanTich(
            int ID,
            string CTPT,
            string CTPTDG,
            DateTime CreatedDate,
            string CreatedBy,
            string Note,
            bool Locked
            )
        {
            this._ID = ID;
            this._CTPT = CTPT;
            this._CTPTDG = CTPTDG;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Note = Note;
            this._Locked = Locked;
        }

        public ChiTieuPhanTich()
        {
        }

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _CTPT;

        public string CTPT
        {
            get { return _CTPT; }
            set { _CTPT = value; }
        }

        private string _CTPTDG;

        public string CTPTDG
        {
            get { return _CTPTDG; }
            set { _CTPTDG = value; }
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