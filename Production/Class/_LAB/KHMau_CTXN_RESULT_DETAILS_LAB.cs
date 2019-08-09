using System;

namespace Production.Class
{
    public class KHMau_CTXN_RESULT_DETAILS_LAB
    {
        public KHMau_CTXN_RESULT_DETAILS_LAB(
            int ID,
            int KHMau_CTXN_ID,
            DateTime CreatedDate,
            string CreatedBy,
            string Note,
            bool Locked,
            string MinVal,
            string MaxVal,
            string Custom1,
            string Custom2,
            string Custom3,
            string Custom4,
            string Custom5,
            int LineNo
            )
        {
            this._ID = ID;
            this._KHMau_CTXN_ID = KHMau_CTXN_ID;      
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Note = Note;
            this._MinVal = MinVal;
            this._MaxVal = MaxVal;
            this._Custom1 = Custom1;
            this._Custom2 = Custom2;
            this._Custom3 = Custom3;
            this._Custom4 = Custom4;
            this._Custom5 = Custom5;
            this._Locked = Locked;
            this._LineNo = LineNo;
        }
        public KHMau_CTXN_RESULT_DETAILS_LAB()
        {

        }
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }        

        private int _KHMau_CTXN_ID;

        public int KHMau_CTXN_ID
        {
            get { return _KHMau_CTXN_ID; }
            set { _KHMau_CTXN_ID = value; }
        }

        private int _LineNo;

        public int LineNo
        {
            get { return _LineNo; }
            set { _LineNo = value; }
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

        private string _MinVal;
        public string MinVal
        {
            get { return _MinVal; }
            set { _MinVal = value; }
        }

        private string _MaxVal;
        public string MaxVal
        {
            get { return _MaxVal; }
            set { _MaxVal = value; }
        }

        private string _Custom1;
        public string Custom1
        {
            get { return _Custom1; }
            set { _Custom1 = value; }
        }

        private string _Custom2;
        public string Custom2
        {
            get { return _Custom2; }
            set { _Custom2 = value; }
        }

        private string _Custom3;
        public string Custom3
        {
            get { return _Custom3; }
            set { _Custom3 = value; }
        }

        private string _Custom4;
        public string Custom4
        {
            get { return _Custom4; }
            set { _Custom4 = value; }
        }

        private string _Custom5;
        public string Custom5
        {
            get { return _Custom5; }
            set { _Custom5 = value; }
        }
    }
}
