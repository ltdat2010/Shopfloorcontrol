using System;

namespace Production.Class
{
    //public class SUPPLIER
    public class Result_KQKN_KL
    {
        public Result_KQKN_KL(
            int ID,
            string SoPKN,
            string KL,
            string CT,
            string NguoiKT,
            DateTime NgayKT,
            string TPKN,
            DateTime NgayPD,
            string PassFail,
            string CreatedBy,
            int Lan,
            string Note,
            DateTime CreatedDate,
            bool Locked
            )
        {
            this._ID = ID;
            this._SoPKN = SoPKN;
            this._KL = KL;
            this._CT = CT;
            this._NguoiKT = NguoiKT;
            this._NgayKT = NgayKT;
            this._TPKN = TPKN;
            this._NgayPD = NgayPD;
            this._PassFail = PassFail;
            this._Lan = Lan;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Note = Note;
            this._Locked = Locked;
        }

        public Result_KQKN_KL()
        {
        }

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _SoPKN;

        public string SoPKN
        {
            get { return _SoPKN; }
            set { _SoPKN = value; }
        }

        private int _Lan;

        public int Lan
        {
            get { return _Lan; }
            set { _Lan = value; }
        }

        private string _KL;

        public string KL
        {
            get { return _KL; }
            set { _KL = value; }
        }

        private string _TPKN;

        public string TPKN
        {
            get { return _TPKN; }
            set { _TPKN = value; }
        }

        private string _CT;

        public string CT
        {
            get { return _CT; }
            set { _CT = value; }
        }

        private string _NguoiKT;

        public string NguoiKT
        {
            get { return _NguoiKT; }
            set { _NguoiKT = value; }
        }

        private DateTime _NgayPD;

        public DateTime NgayPD
        {
            get { return _NgayPD; }
            set { _NgayPD = value; }
        }

        private DateTime _NgayKT;

        public DateTime NgayKT
        {
            get { return _NgayKT; }
            set { _NgayKT = value; }
        }

        private string _PassFail;

        public string PassFail
        {
            get { return _PassFail; }
            set { _PassFail = value; }
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

        //List<KQKN_Template_Details_Row> Lst = new List<KQKN_Template_Details_Row>();
    }
}