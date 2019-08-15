using System;

namespace Production.Class
{
    //public class SUPPLIER
    public class CUSTOMERTYPE
    {
        public CUSTOMERTYPE(
            int Id,
            string CUSTTYPEName,
            string CUSTTYPECode,
            DateTime CreatedDate,
            string CreatedBy,
            string Note,
            bool Locked
            )
        {
            this._Id = Id;
            this._CUSTTYPEName = CUSTTYPEName;
            this._CUSTTYPECode = CUSTTYPECode;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Note = Note;
            this._Locked = Locked;
        }

        public CUSTOMERTYPE()
        {
        }

        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _CUSTTYPEName;

        public string CUSTTYPEName
        {
            get { return _CUSTTYPEName; }
            set { _CUSTTYPEName = value; }
        }

        private string _CUSTTYPECode;

        public string CUSTTYPECode
        {
            get { return _CUSTTYPECode; }
            set { _CUSTTYPECode = value; }
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