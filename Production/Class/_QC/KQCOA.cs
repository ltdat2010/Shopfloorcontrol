using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Production.Class
{
    public class KQCOA
    {
            public KQCOA(
            int ID,
            int SoCOA,
            int COATemplateID,
            string Result,
            DateTime CreatedDate,
            string CreatedBy,
            string Note,
            bool Locked
            )
        {
            this._ID = ID;
            this._SoCOA = SoCOA;
            this._COATemplateID = COATemplateID;
            this._Result = Result;            
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Note = Note;
            this._Locked = Locked;

        }
        public KQCOA()
        {

        }
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private int _SoCOA;

        public int SoCOA
        {
            get { return _SoCOA; }
            set { _SoCOA = value; }
        }

        private int _COATemplateID;

        public int COATemplateID
        {
            get { return _COATemplateID; }
            set { _COATemplateID = value; }
        }

        private string _Result;

        public string Result
        {
            get { return _Result; }
            set { _Result = value; }
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
