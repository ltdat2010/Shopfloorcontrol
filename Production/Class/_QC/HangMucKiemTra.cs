using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Production.Class
{
    //public class SUPPLIER
    public class HangMucKiemTra
    {
        public HangMucKiemTra(
            int ID,
            string HMKT,
            string HMKTEN,
            string Characteristic,
            DateTime CreatedDate, 
            string CreatedBy,
            string Note,
            bool Locked          
            )
        {
            this._ID = ID;
            this._HMKT = HMKT;
            this._HMKTEN = HMKTEN;
            this._Characteristic = Characteristic;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Note = Note;
            this._Locked = Locked;

        }
        public HangMucKiemTra()
        {

        }

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _HMKT;

        public string HMKT
        {
            get { return _HMKT; }
            set { _HMKT = value; }
        }

        private string _HMKTEN;
        public string HMKTEN
        {
            get { return _HMKTEN; }
            set { _HMKTEN = value; }
        }

        private string _Characteristic;
        public string Characteristic
        {
            get { return _Characteristic; }
            set { _Characteristic = value; }
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
