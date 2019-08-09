using System;

namespace Production.Class
{
    //public class SUPPLIER
    public class MYCOTOXIN_RESULT_StandardCurve
    {
        public MYCOTOXIN_RESULT_StandardCurve(
            int ID,
            int MYCOTOXIN_RESULT_Header_ID,
            DateTime CreatedDate,
            string CreatedBy, 
            bool Locked,            
            string Note,
            double a_SLOPE,
            double b_INTERCEPT,
            double R_SQUARE,
            string Acronym
            )
        {
            this._ID = ID;
            this._MYCOTOXIN_RESULT_Header_ID = MYCOTOXIN_RESULT_Header_ID;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Locked = Locked;            
            this._Note = Note;
            this._a_SLOPE = a_SLOPE;
            this._b_INTERCEPT = b_INTERCEPT;
            this._R_SQUARE = R_SQUARE;
            this._Acronym = Acronym;
        }
        public MYCOTOXIN_RESULT_StandardCurve()
        {

        }

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private int _MYCOTOXIN_RESULT_Header_ID;

        public int MYCOTOXIN_RESULT_Header_ID
        {
            get { return _MYCOTOXIN_RESULT_Header_ID; }
            set { _MYCOTOXIN_RESULT_Header_ID = value; }
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

        private double _a_SLOPE;
        public double a_SLOPE
        {
            get { return _a_SLOPE; }
            set { _a_SLOPE = value; }
        }

        private double _b_INTERCEPT;
        public double b_INTERCEPT
        {
            get { return _b_INTERCEPT; }
            set { _b_INTERCEPT = value; }
        }

        private double _R_SQUARE;
        public double R_SQUARE
        {
            get { return _R_SQUARE; }
            set { _R_SQUARE = value; }
        }

        private string _Acronym;
        public string Acronym
        {
            get { return _Acronym; }
            set { _Acronym = value; }
        }
    }
}
