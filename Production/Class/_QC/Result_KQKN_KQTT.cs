using System;

namespace Production.Class
{
    //public class SUPPLIER
    public class Result_KQKN_KQTT
    {
        public Result_KQKN_KQTT(
            int ID,
            string SoPKN,
            int KQKN_Detail_ID,
            string KQTT,
            string CreatedBy,
            int Lan,
            string Note,
            DateTime CreatedDate,
            bool Locked
            )
        {
            this._ID = ID;
            this._SoPKN = SoPKN;
            this._KQKN_Detail_ID = KQKN_Detail_ID;
            this._Lan = Lan;
            this._KQTT = KQTT;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Note = Note;
            this._Locked = Locked;
        }

        public Result_KQKN_KQTT()
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

        private int _KQKN_Detail_ID;

        public int KQKN_Detail_ID
        {
            get { return _KQKN_Detail_ID; }
            set { _KQKN_Detail_ID = value; }
        }

        private int _Lan;

        public int Lan
        {
            get { return _Lan; }
            set { _Lan = value; }
        }

        private string _KQTT;

        public string KQTT
        {
            get { return _KQTT; }
            set { _KQTT = value; }
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