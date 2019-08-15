using System;

namespace Production.Class
{
    //public class SUPPLIER
    public class NHOMCHITIEUXETNGHIEM
    {
        public NHOMCHITIEUXETNGHIEM(
            int ID,
            string NCTXN,
            string NCTXNDG,
            DateTime CreatedDate,
            string CreatedBy,
            bool Locked,
            string Note,
            string NhomChung
            )
        {
            this._ID = ID;
            this._NCTXN = NCTXN;
            this._NCTXNDG = NCTXNDG;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Locked = Locked;
            this._Note = Note;
        }

        public NHOMCHITIEUXETNGHIEM()
        {
        }

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _NCTXN;

        public string NCTXN
        {
            get { return _NCTXN; }
            set { _NCTXN = value; }
        }

        private string _NCTXNDG;

        public string NCTXNDG
        {
            get { return _NCTXNDG; }
            set { _NCTXNDG = value; }
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

        private string _NhomChung;

        public string NhomChung
        {
            get { return _NhomChung; }
            set { _NhomChung = value; }
        }
    }
}