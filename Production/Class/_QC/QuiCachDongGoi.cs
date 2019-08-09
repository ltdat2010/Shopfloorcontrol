using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Production.Class
{
    public class QuiCachDongGoi
    {
        public QuiCachDongGoi(
            int ID,
            string QCDG,
            string QCDGDG,
            DateTime CreatedDate,
            string CreatedBy,
            string Note,
            bool Locked
            )
        {
            this._ID = ID;
            this._QCDG = QCDG;
            this._QCDGDG = QCDGDG;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Note = Note;
            this._Locked = Locked;

        }
        public QuiCachDongGoi()
        {

        }
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _QCDG;

        public string QCDG
        {
            get { return _QCDG; }
            set { _QCDG = value; }
        }
        private string _QCDGDG;

        public string QCDGDG
        {
            get { return _QCDGDG; }
            set { _QCDGDG = value; }
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
