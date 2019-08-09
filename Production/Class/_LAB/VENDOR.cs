using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Production.Class
{
    //public class SUPPLIER
    public class VENDOR
    {
        public VENDOR(
            int Id,
            string VENDNAME,
            string VENDCODE, 
            DateTime CreatedDate, 
            string CreatedBy, 
            bool Locked,            
            string Note
            )
        {
            this._Id = Id;
            this._VENDNAME = VENDNAME;
            this._VENDCODE = VENDCODE;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Locked = Locked;            
            this._Note = Note;
        }
        public VENDOR()
        {

        }

        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _VENDNAME;

        public string VENDNAME
        {
            get { return _VENDNAME; }
            set { _VENDNAME = value; }
        }

        private string _VENDCODE;
        public string VENDCODE
        {
            get { return _VENDCODE; }
            set { _VENDCODE = value; }
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
