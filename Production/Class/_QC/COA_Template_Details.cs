using System;

namespace Production.Class
{
    public class COA_Template_Details
    {
        public COA_Template_Details(
        int ID,
        int COATemplateID,
        int HMKTID,
        string Value,
        string Tolerance,
        string ValueVN,
        string ToleranceVN,
        DateTime CreatedDate,
        string CreatedBy,
        string Note,
        bool Locked
        )
        {
            this._ID = ID;
            this._COATemplateID = COATemplateID;
            this._Value = Value;
            this._Tolerance = Tolerance;
            this._ValueVN = ValueVN;
            this._ToleranceVN = ToleranceVN;
            this._HMKTID = HMKTID;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Note = Note;
            this._Locked = Locked;
        }

        public COA_Template_Details()
        {
        }

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private int _COATemplateID;

        public int COATemplateID
        {
            get { return _COATemplateID; }
            set { _COATemplateID = value; }
        }

        private int _HMKTID;

        public int HMKTID
        {
            get { return _HMKTID; }
            set { _HMKTID = value; }
        }

        private string _Value;

        public string Value
        {
            get { return _Value; }
            set { _Value = value; }
        }

        private string _Tolerance;

        public string Tolerance
        {
            get { return _Tolerance; }
            set { _Tolerance = value; }
        }

        private string _ValueVN;

        public string ValueVN
        {
            get { return _ValueVN; }
            set { _ValueVN = value; }
        }

        private string _ToleranceVN;

        public string ToleranceVN
        {
            get { return _ToleranceVN; }
            set { _ToleranceVN = value; }
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