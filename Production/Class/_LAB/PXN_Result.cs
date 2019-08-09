using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Production.Class
{
    public class PXN_Result
    {
        public PXN_Result(
            int ID,
            int PXN_Details_ID,
            string SoPXN,
            string UnitTestCode,
            int CTXNID,
            string ResultLine,
            string ResultValue,
            string Positive,
            string ResultUoM,
            DateTime CreatedDate,
            string CreatedBy,
            string Note,
            bool Locked
            )
        {
            this._ID = ID;
            this._PXN_Details_ID = PXN_Details_ID;
            this._SoPXN = SoPXN;
            this._UnitTestCode = UnitTestCode;
            this._CTXNID = CTXNID;
            this._ResultLine = ResultLine;
            this._ResultValue = ResultValue;
            this._Positive = Positive;
            this._ResultUoM = ResultUoM;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Note = Note;
            this._Locked = Locked;

        }
        public PXN_Result()
        {

        }
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private int _PXN_Details_ID;

        public int PXN_Details_ID
        {
            get { return _PXN_Details_ID; }
            set { _PXN_Details_ID = value; }
        }

        private string _SoPXN;

        public string SoPXN
        {
            get { return _SoPXN; }
            set { _SoPXN = value; }
        }

        private string _UnitTestCode;

        public string UnitTestCode
        {
            get { return _UnitTestCode; }
            set { _UnitTestCode = value; }
        }

        private int _CTXNID;

        public int CTXNID
        {
            get { return _CTXNID; }
            set { _CTXNID = value; }
        }

        private string _ResultLine;

        public string ResultLine
        {
            get { return _ResultLine; }
            set { _ResultLine = value; }
        }

        private string _ResultValue;

        public string ResultValue
        {
            get { return _ResultValue; }
            set { _ResultValue = value; }
        }

        private string _Positive;

        public string Positive
        {
            get { return _Positive; }
            set { _Positive = value; }
        }

        private string _ResultUoM;

        public string ResultUoM
        {
            get { return _ResultUoM; }
            set { _ResultUoM = value; }
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
