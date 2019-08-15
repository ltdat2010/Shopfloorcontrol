using System;

namespace Production.Class
{
    public class Result_COA_TD
    {
        public Result_COA_TD(
            int ID,
            string SoCOA,
            int COATemplateID,
            string WO,
            string ManfBy,
            DateTime SmpDate,
            DateTime ExpDate,
            DateTime AnlDate,
            DateTime ManfDate,
            string LB_MAT,
            DateTime CreatedDate,
            string CreatedBy,
            string Note,
            bool Locked
            )
        {
            this._ID = ID;
            this._SoCOA = SoCOA;
            this._COATemplateID = COATemplateID;
            this._WO = WO;
            this._ManfBy = ManfBy;
            this._SmpDate = SmpDate;
            this._ExpDate = ExpDate;
            this._AnlDate = AnlDate;
            this._ManfDate = ManfDate;
            this._LB_MAT = LB_MAT;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Note = Note;
            this._Locked = Locked;
        }

        public Result_COA_TD()
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

        private int _COATemplateID;

        public int COATemplateID
        {
            get { return _COATemplateID; }
            set { _COATemplateID = value; }
        }

        private string _WO;

        public string WO
        {
            get { return _WO; }
            set { _WO = value; }
        }

        private string _ManfBy;

        public string ManfBy
        {
            get { return _ManfBy; }
            set { _ManfBy = value; }
        }

        private DateTime _SmpDate;

        public DateTime SmpDate
        {
            get { return _SmpDate; }
            set { _SmpDate = value; }
        }

        private DateTime _ExpDate;

        public DateTime ExpDate
        {
            get { return _ExpDate; }
            set { _ExpDate = value; }
        }

        private DateTime _AnlDate;

        public DateTime AnlDate
        {
            get { return _AnlDate; }
            set { _AnlDate = value; }
        }

        private DateTime _ManfDate;

        public DateTime ManfDate
        {
            get { return _ManfDate; }
            set { _ManfDate = value; }
        }

        private string _LB_MAT;

        public string LB_MAT
        {
            get { return _LB_MAT; }
            set { _LB_MAT = value; }
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