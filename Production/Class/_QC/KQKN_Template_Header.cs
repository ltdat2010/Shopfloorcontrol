using System;
using System.Collections.Generic;

namespace Production.Class
{
    //public class SUPPLIER
    public class KQKN_Template_Header
    {
        public KQKN_Template_Header(
            int ID,
            string KQKNTemplate,
            string SoMRA,
            DateTime CreatedDate,
            string CreatedBy,
            string Note,
            bool Locked
            )
        {
            this._ID = ID;
            this._KQKNTemplate = KQKNTemplate;
            this._SoMRA = SoMRA;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Note = Note;
            this._Locked = Locked;
        }

        public KQKN_Template_Header()
        {
        }

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _KQKNTemplate;

        public string KQKNTemplate
        {
            get { return _KQKNTemplate; }
            set { _KQKNTemplate = value; }
        }

        private string _SoMRA;

        public string SoMRA
        {
            get { return _SoMRA; }
            set { _SoMRA = value; }
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

        private List<KQKN_Template_Details_Row> Lst = new List<KQKN_Template_Details_Row>();
    }
}