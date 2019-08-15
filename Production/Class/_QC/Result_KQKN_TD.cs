using System;

namespace Production.Class
{
    //public class SUPPLIER
    public class Result_KQKN_TD
    {
        public Result_KQKN_TD(
            int ID,
            string SoPKN,
            int KQKNTemplateID,
            string SoMRA,
            int Lan,
            string SoPNK,
            string QCDG,
            string UoM1,
            string UoM2,
            string SLNhan,
            string CreatedBy,
            string Solo,
            string TenNL,
            string Note,
            DateTime NgayNhan,
            DateTime NgaySX,
            DateTime HSD,
            DateTime NgayPT,
            DateTime CreatedDate,
            bool Locked
            )
        {
            this._ID = ID;

            this._SoPKN = SoPKN;
            this._KQKNTemplateID = KQKNTemplateID;
            this._SoMRA = SoMRA;
            this._Lan = Lan;
            this._SoPNK = SoPNK;
            this._QCDG = QCDG;
            this._UoM1 = UoM1;
            this._UoM2 = UoM2;
            this._SLNhan = SLNhan;
            this._Solo = Solo;
            this._TenNL = TenNL;
            this._NgayNhan = NgayNhan;
            this._NgaySX = NgaySX;
            this._HSD = HSD;
            this._NgayPT = NgayPT;

            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Note = Note;
            this._Locked = Locked;
        }

        public Result_KQKN_TD()
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

        private int _KQKNTemplateID;

        public int KQKNTemplateID
        {
            get { return _KQKNTemplateID; }
            set { _KQKNTemplateID = value; }
        }

        private string _SoMRA;

        public string SoMRA
        {
            get { return _SoMRA; }
            set { _SoMRA = value; }
        }

        private int _Lan;

        public int Lan
        {
            get { return _Lan; }
            set { _Lan = value; }
        }

        private string _SoPNK;

        public string SoPNK
        {
            get { return _SoPNK; }
            set { _SoPNK = value; }
        }

        private string _QCDG;

        public string QCDG
        {
            get { return _QCDG; }
            set { _QCDG = value; }
        }

        private string _UoM1;

        public string UoM1
        {
            get { return _UoM1; }
            set { _UoM1 = value; }
        }

        private string _UoM2;

        public string UoM2
        {
            get { return _UoM2; }
            set { _UoM2 = value; }
        }

        private string _SLNhan;

        public string SLNhan
        {
            get { return _SLNhan; }
            set { _SLNhan = value; }
        }

        private string _Solo;

        public string Solo
        {
            get { return _Solo; }
            set { _Solo = value; }
        }

        private string _TenNL;

        public string TenNL
        {
            get { return _TenNL; }
            set { _TenNL = value; }
        }

        private DateTime _NgayNhan;

        public DateTime NgayNhan
        {
            get { return _NgayNhan; }
            set { _NgayNhan = value; }
        }

        private DateTime _NgaySX;

        public DateTime NgaySX
        {
            get { return _NgaySX; }
            set { _NgaySX = value; }
        }

        private DateTime _HSD;

        public DateTime HSD
        {
            get { return _HSD; }
            set { _HSD = value; }
        }

        private DateTime _NgayPT;

        public DateTime NgayPT
        {
            get { return _NgayPT; }
            set { _NgayPT = value; }
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