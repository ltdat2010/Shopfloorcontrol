using System;

namespace Production.Class
{
    //public class SUPPLIER
    public class CHITIEUXETNGHIEM
    {
        public CHITIEUXETNGHIEM(
            int ID,
            string MaCTXN,
            string CTXN,
            string CTXNDG,
            string CTXNDGTA,
            int NCTXNID,
            int PPXNID,
            string MinValue,
            string MaxValue,            
            string UnitValue,
            DateTime CreatedDate, 
            string CreatedBy, 
            bool Locked,
            //bool MuaNgoai,
            string Note,
            string Days,
            string Acronym,
            string UoM
            )
        {
            this._ID = ID;
            this._CTXN = CTXN;
            this._MaCTXN = MaCTXN;
            this._CTXNDG= CTXNDG;
            this._CTXNDGTA = CTXNDGTA;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Locked = Locked;
            //this._MuaNgoai = MuaNgoai;
            this._NCTXNID = NCTXNID;
            this._PPXNID = PPXNID;
            this._MinValue = MinValue;
            this._MaxValue = MaxValue;
            this._UnitValue = UnitValue;
            this._Note = Note;
            this._Days = Days;
            this._Acronym = Acronym;
            this._UoM = UoM;
        }
        public CHITIEUXETNGHIEM()
        {

        }

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _MaCTXN;

        public string MaCTXN
        {
            get { return _MaCTXN; }
            set { _MaCTXN = value; }
        }

        private string _CTXN;

        public string CTXN
        {
            get { return _CTXN; }
            set { _CTXN = value; }
        }

        private string _CTXNDG;
        public string CTXNDG
        {
            get { return _CTXNDG; }
            set { _CTXNDG = value; }
        }

        private string _CTXNDGTA;
        public string CTXNDGTA
        {
            get { return _CTXNDGTA; }
            set { _CTXNDGTA = value; }
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

        //private bool _MuaNgoai;
        //public bool MuaNgoai
        //{
        //    get { return _MuaNgoai; }
        //    set { _MuaNgoai = value; }
        //}

        private int _NCTXNID;

        public int NCTXNID
        {
            get { return _NCTXNID; }
            set { _NCTXNID = value; }
        }

        private int _PPXNID;

        public int PPXNID
        {
            get { return _PPXNID; }
            set { _PPXNID = value; }
        }

        private string _MinValue;

        public string MinValue
        {
            get { return _MinValue; }
            set { _MinValue = value; }
        }

        private string _MaxValue;

        public string MaxValue
        {
            get { return _MaxValue; }
            set { _MaxValue = value; }
        }

        private string _UnitValue;

        public string UnitValue
        {
            get { return _UnitValue; }
            set { _UnitValue = value; }
        }

        private string _Note;

        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }

        private string _Days;

        public string Days
        {
            get { return _Days; }
            set { _Days = value; }
        }

        //Acronym
        private string _Acronym;

        public string Acronym
        {
            get { return _Acronym; }
            set { _Acronym = value; }
        }

        //UoM
        private string _UoM;

        public string UoM
        {
            get { return _UoM; }
            set { _UoM = value; }
        }


    }
}
