using System;

namespace Production.Class
{
    //public class SUPPLIER
    public class MYCOTOXIN_RESULT_Header
    {
        public MYCOTOXIN_RESULT_Header(
            int ID,
            string FilePath,
            DateTime Date,
            string Time,
            string ReadingType,
            string ReaderType,
            string PlateType,
            string Read,
            string Wavelengths,
            string ReadSpeed,
            string SoftwareVersion,
            string PlateNumber,
            DateTime CreatedDate,
            string CreatedBy, 
            bool Locked,            
            string Note,
            int ReadTimes,
            double a_SLOPE,
            double b_INTERCEPT,
            double R_SQUARE,
            string Name
            )
        {
            this._ID = ID;
            this._FilePath = FilePath;
            this._Date = Date;
            this._Time = Time;
            this._ReadingType = ReadingType;
            this._ReaderType = ReaderType;
            this._PlateType = PlateType;
            this._Read = Read;
            this._Wavelengths = Wavelengths;
            this._ReadSpeed = ReadSpeed;
            this._SoftwareVersion = SoftwareVersion;
            this._PlateNumber = PlateNumber;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Locked = Locked;            
            this._Note = Note;
            this._ReadTimes = ReadTimes;
            this._a_SLOPE = a_SLOPE;
            this._b_INTERCEPT = b_INTERCEPT;
            this._R_SQUARE = R_SQUARE;
            this._Name = Name;
        }
        public MYCOTOXIN_RESULT_Header()
        {

        }

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _FilePath;

        public string FilePath
        {
            get { return _FilePath; }
            set { _FilePath = value; }
        }

        private DateTime _Date;

        public DateTime Date
        {
            get { return _Date; }
            set { _Date = value; }
        }

        private string _Time;

        public string Time
        {
            get { return _Time; }
            set { _Time = value; }
        }

        private string _ReadingType;

        public string ReadingType
        {
            get { return _ReadingType; }
            set { _ReadingType = value; }
        }
        private string _ReaderType;

        public string ReaderType
        {
            get { return _ReaderType; }
            set { _ReaderType = value; }
        }
        private string _PlateType;

        public string PlateType
        {
            get { return _PlateType; }
            set { _PlateType = value; }
        }
        private string _Read;

        public string Read
        {
            get { return _Read; }
            set { _Read = value; }
        }
        private string _Wavelengths;

        public string Wavelengths
        {
            get { return _Wavelengths; }
            set { _Wavelengths = value; }
        }
        private string _ReadSpeed;

        public string ReadSpeed
        {
            get { return _ReadSpeed; }
            set { _ReadSpeed = value; }
        }

        private string _SoftwareVersion;

        public string SoftwareVersion
        {
            get { return _SoftwareVersion; }
            set { _SoftwareVersion = value; }
        }

        private string _PlateNumber;

        public string PlateNumber
        {
            get { return _PlateNumber; }
            set { _PlateNumber = value; }
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

        private int _ReadTimes;
        public int ReadTimes
        {
            get { return _ReadTimes; }
            set { _ReadTimes = value; }
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

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
    }
}
