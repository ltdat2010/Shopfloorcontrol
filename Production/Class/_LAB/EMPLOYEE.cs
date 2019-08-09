using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Production.Class
{
    //public class SUPPLIER
    public class EMPLOYEE
    {
        public EMPLOYEE(
            int Id,
            string EMPName,
            string EMPCode,
            string EMPMobile,
            string EMPEmail,
            DateTime CreatedDate, 
            string CreatedBy,
            string Note,
            bool Locked          
            )
        {
            this._Id                = Id;
            this._EMPName           = EMPName;
            this._EMPCode           = EMPCode;
            this._EMPMobile         = EMPMobile;
            this._EMPEmail          = EMPEmail;
            this._CreatedDate       = CreatedDate;
            this._CreatedBy         = CreatedBy;
            this._Note = Note;
            this._Locked            = Locked;

        }
        public EMPLOYEE()
        {

        }
        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _EMPName;

        public string EMPName
        {
            get { return _EMPName; }
            set { _EMPName = value; }
        }

        private string _EMPCode;
        public string EMPCode
        {
            get { return _EMPCode; }
            set { _EMPCode = value; }
        }

        private string _EMPMobile;

        public string EMPMobile
        {
            get { return _EMPMobile; }
            set { _EMPMobile = value; }
        }

        private string _EMPEmail;

        public string EMPEmail
        {
            get { return _EMPEmail; }
            set { _EMPEmail = value; }
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
