using System;

namespace Production.Class
{
    //public class SUPPLIER
    public class LOAIDV
    {
        public LOAIDV(
            int ID,
            string MaLoaiDV,
            string TenLoaiDV,
            DateTime CreatedDate,
            string CreatedBy,
            bool Locked,
            string Note
            )
        {
            this._ID = ID;
            this._MaLoaiDV = MaLoaiDV;
            this._TenLoaiDV = TenLoaiDV;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Locked = Locked;
            this._Note = Note;
        }

        public LOAIDV()
        {
        }

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _MaLoaiDV;

        public string MaLoaiDV
        {
            get { return _MaLoaiDV; }
            set { _MaLoaiDV = value; }
        }

        private string _TenLoaiDV;

        public string TenLoaiDV
        {
            get { return _TenLoaiDV; }
            set { _TenLoaiDV = value; }
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