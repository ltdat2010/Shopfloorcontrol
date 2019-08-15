using System;

namespace Production.Class
{
    public class COA_Template_Header
    {
        public COA_Template_Header(
            int ID,
            string COATemplate,
            byte[] IMGCOA,
            string COADescription,
            DateTime CreatedDate,
            string CreatedBy,
            string Note,
            bool Locked
            )
        {
            this._ID = ID;
            this._COATemplate = COATemplate;
            this._IMGCOA = IMGCOA;
            this._COADescription = COADescription;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Note = Note;
            this._Locked = Locked;
        }

        public COA_Template_Header()
        {
        }

        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private byte[] _IMGCOA;

        public byte[] IMGCOA
        {
            get { return _IMGCOA; }
            set { _IMGCOA = value; }
        }

        private string _COATemplate;

        public string COATemplate
        {
            get { return _COATemplate; }
            set { _COATemplate = value; }
        }

        private string _COADescription;

        public string COADescription
        {
            get { return _COADescription; }
            set { _COADescription = value; }
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