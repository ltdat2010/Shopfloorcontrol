using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Production.Class
{
    //public class SUPPLIER
    public class LOCATION
    {
        public LOCATION(
            int Id,
            string LOCName,
            string LOCCode,
            DateTime CreatedDate, 
            string CreatedBy,
            string Note,
            bool Locked          
            )
        {
            this._Id = Id;
            this._LOCName = LOCName;
            this._LOCCode = LOCCode;
            
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Note = Note;
            this._Locked = Locked;

        }
        public LOCATION()
        {

        }

        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _LOCName;

        public string LOCName
        {
            get { return _LOCName; }
            set { _LOCName = value; }
        }        

        private string _LOCCode;
        public string LOCCode
        {
            get { return _LOCCode; }
            set { _LOCCode = value; }
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
