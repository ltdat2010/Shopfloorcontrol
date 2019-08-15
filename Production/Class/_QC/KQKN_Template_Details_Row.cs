using System;

namespace Production.Class
{
    //public class SUPPLIER
    public class KQKN_Template_Details_Row
    {
        public KQKN_Template_Details_Row(
            int ID,
            int KQKNTemplateID,
            string STT,
            int TCID,
            int CTPTID,
            int PPTID,
            DateTime CreatedDate,
            string CreatedBy,
            string Note,
            bool Locked
            )
        {
            this._ID = ID;
            this._KQKNTemplateID = KQKNTemplateID;
            this._STT = STT;
            this._TCID = TCID;
            this._CTPTID = CTPTID;
            this._PPTID = PPTID;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Note = Note;
            this._Locked = Locked;
        }

        public KQKN_Template_Details_Row()
        {
        }

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private int _KQKNTemplateID;

        public int KQKNTemplateID
        {
            get { return _KQKNTemplateID; }
            set { _KQKNTemplateID = value; }
        }

        private string _STT;

        public string STT
        {
            get { return _STT; }
            set { _STT = value; }
        }

        private int _TCID;

        public int TCID
        {
            get { return _TCID; }
            set { _TCID = value; }
        }

        private int _CTPTID;

        public int CTPTID
        {
            get { return _CTPTID; }
            set { _CTPTID = value; }
        }

        private int _PPTID;

        public int PPTID
        {
            get { return _PPTID; }
            set { _PPTID = value; }
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