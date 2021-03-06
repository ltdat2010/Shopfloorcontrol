﻿using System;

namespace Production.Class
{
    //public class SUPPLIER
    public class LOAIMAU
    {
        public LOAIMAU(
            int ID,
            string MaLoaiMau,
            string TenLoaiMau,
            DateTime CreatedDate,
            string CreatedBy,
            bool Locked,
            string Note
            )
        {
            this._ID = ID;
            this._MaLoaiMau = MaLoaiMau;
            this._TenLoaiMau = TenLoaiMau;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Locked = Locked;
            this._Note = Note;
        }

        public LOAIMAU()
        {
        }

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _MaLoaiMau;

        public string MaLoaiMau
        {
            get { return _MaLoaiMau; }
            set { _MaLoaiMau = value; }
        }

        private string _TenLoaiMau;

        public string TenLoaiMau
        {
            get { return _TenLoaiMau; }
            set { _TenLoaiMau = value; }
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