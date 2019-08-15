using System;

namespace Production.Class
{
    public class Result_COA_KQ
    {
        public Result_COA_KQ(
        int ID,
        string SoCOA,
        int COA_Template_Details_ID,
        string Result,
        DateTime CreatedDate,
        string CreatedBy,
        string Note,
        bool Locked
        )
        {
            this._ID = ID;
            this._SoCOA = SoCOA;
            this._COA_Template_Details_ID = COA_Template_Details_ID;
            this._Result = Result;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Note = Note;
            this._Locked = Locked;
        }

        public Result_COA_KQ()
        {
        }

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _SoCOA;

        public string SoCOA
        {
            get { return _SoCOA; }
            set { _SoCOA = value; }
        }

        private int _COA_Template_Details_ID;

        public int COA_Template_Details_ID
        {
            get { return _COA_Template_Details_ID; }
            set { _COA_Template_Details_ID = value; }
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