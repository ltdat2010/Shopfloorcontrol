using System;

namespace Production.Class
{
    public class PhuongPhapThu
    {
        public PhuongPhapThu(
            int ID,
            string PPT,
            string PPTDG,
            DateTime CreatedDate,
            string CreatedBy,
            string Note,
            bool Locked
            )
        {
            this._ID = ID;
            this._PPT = PPT;
            this._PPTDG = PPTDG;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Note = Note;
            this._Locked = Locked;
        }

        public PhuongPhapThu()
        {
        }

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _PPT;

        public string PPT
        {
            get { return _PPT; }
            set { _PPT = value; }
        }

        private string _PPTDG;

        public string PPTDG
        {
            get { return _PPTDG; }
            set { _PPTDG = value; }
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