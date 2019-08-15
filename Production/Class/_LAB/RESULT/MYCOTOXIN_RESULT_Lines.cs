using System;

namespace Production.Class
{
    //public class SUPPLIER
    public class MYCOTOXIN_RESULT_Lines
    {
        public MYCOTOXIN_RESULT_Lines(
            //int ID,
            int MYCOTOCXIN_RESULT_Header_LAB_ID,
            double OD,
            string Acronym,
            string KHMau,
            double B_Bo,
            double LogitB_Bo,
            double LogConc,
            double HsoPhaLoang,
            string Row,
            double Col,
            DateTime CreatedDate,
            string CreatedBy,
            bool Locked,
            string Note,
            double Conc_ng_ml,
            double Conc_ng_g,
            int CTXN_ID

            )
        {
            //this._ID = ID;
            this._MYCOTOCXIN_RESULT_Header_LAB_ID = MYCOTOCXIN_RESULT_Header_LAB_ID;
            this._Acronym = Acronym;
            this._OD = OD;
            this._KHMau = KHMau;
            this._B_Bo = B_Bo;
            this._LogitB_Bo = LogitB_Bo;
            this._LogConc = LogConc;
            this._HsoPhaLoang = HsoPhaLoang;
            this._Row = Row;
            this._Col = Col;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Locked = Locked;
            this._Note = Note;
            this._Conc_ng_ml = Conc_ng_ml;
            this._Conc_ng_g = Conc_ng_g;
            this._CTXN_ID = CTXN_ID;
        }

        //GridViewRow

        //Contructor blank
        public MYCOTOXIN_RESULT_Lines()
        {
        }

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private int _MYCOTOCXIN_RESULT_Header_LAB_ID;

        public int MYCOTOCXIN_RESULT_Header_LAB_ID
        {
            get { return _MYCOTOCXIN_RESULT_Header_LAB_ID; }
            set { _MYCOTOCXIN_RESULT_Header_LAB_ID = value; }
        }

        private string _Acronym;

        public string Acronym
        {
            get { return _Acronym; }
            set { _Acronym = value; }
        }

        private double _OD;

        public double OD
        {
            get { return _OD; }
            set { _OD = value; }
        }

        private string _KHMau;

        public string KHMau
        {
            get { return _KHMau; }
            set { _KHMau = value; }
        }

        private double _B_Bo;

        public double B_Bo
        {
            get { return _B_Bo; }
            set { _B_Bo = value; }
        }

        private double _LogitB_Bo;

        public double LogitB_Bo
        {
            get { return _LogitB_Bo; }
            set { _LogitB_Bo = value; }
        }

        private double _LogConc;

        public double LogConc
        {
            get { return _LogConc; }
            set { _LogConc = value; }
        }

        private double _HsoPhaLoang;

        public double HsoPhaLoang
        {
            get { return _HsoPhaLoang; }
            set { _HsoPhaLoang = value; }
        }

        private string _Row;

        public string Row
        {
            get { return _Row; }
            set { _Row = value; }
        }

        private string _Read;

        public string Read
        {
            get { return _Read; }
            set { _Read = value; }
        }

        private double _Col;

        public double Col
        {
            get { return _Col; }
            set { _Col = value; }
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

        private double _Conc_ng_ml;

        public double Conc_ng_ml
        {
            get { return _Conc_ng_ml; }
            set { _Conc_ng_ml = value; }
        }

        private double _Conc_ng_g;

        public double Conc_ng_g
        {
            get { return _Conc_ng_g; }
            set { _Conc_ng_g = value; }
        }

        private int _CTXN_ID;

        public int CTXN_ID
        {
            get { return _CTXN_ID; }
            set { _CTXN_ID = value; }
        }
    }
}