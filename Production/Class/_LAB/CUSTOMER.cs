using System;

namespace Production.Class
{
    //public class SUPPLIER
    public class CUSTOMER
    {
        public CUSTOMER(
            int Id,
            string CUSTNAME,
            string CUSTCODE,
            DateTime CreatedDate,
            string CreatedBy,
            bool Locked,
            string CUSTTYPECode,
            string LOCCode,
            string ProvinceName,
            string EMPCode,
            string ContactName,
            string ContactNumber,
            string CUSTADDRESS,
            string CUSTPHONE,
            string TaxCode,
            string ContactEmail,
            string Note,
            bool CUSTViphaLAB
            )
        {
            this._Id = Id;
            this._CUSTNAME = CUSTNAME;
            this._CUSTCODE = CUSTCODE;
            this._CreatedDate = CreatedDate;
            this._CreatedBy = CreatedBy;
            this._Locked = Locked;
            this._CUSTTYPECode = CUSTTYPECode;
            this._LOCCode = LOCCode;
            this._ProvinceName = ProvinceName;
            this._EMPCode = EMPCode;
            this._ContactName = ContactName;
            this._ContactNumber = ContactNumber;
            this._CUSTADDRESS = CUSTADDRESS;
            this._CUSTPHONE = CUSTPHONE;
            this._TaxCode = TaxCode;
            this._ContactEmail = ContactEmail;
            this._Note = Note;
            this._CUSTViphaLAB = CUSTViphaLAB;
        }

        public CUSTOMER()
        {
        }

        private int _Id;

        public int Id
        {
            get { return _Id; }
            set { _Id = value; }
        }

        private string _CUSTNAME;

        public string CUSTNAME
        {
            get { return _CUSTNAME; }
            set { _CUSTNAME = value; }
        }

        private string _CUSTCODE;

        public string CUSTCODE
        {
            get { return _CUSTCODE; }
            set { _CUSTCODE = value; }
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

        private string _CUSTTYPECode;

        public string CUSTTYPECode
        {
            get { return _CUSTTYPECode; }
            set { _CUSTTYPECode = value; }
        }

        private string _LOCCode;

        public string LOCCode
        {
            get { return _LOCCode; }
            set { _LOCCode = value; }
        }

        private string _ProvinceName;

        public string ProvinceName
        {
            get { return _ProvinceName; }
            set { _ProvinceName = value; }
        }

        private string _EMPCode;

        public string EMPCode
        {
            get { return _EMPCode; }
            set { _EMPCode = value; }
        }

        private string _Note;

        public string Note
        {
            get { return _Note; }
            set { _Note = value; }
        }

        private string _ContactName;

        public string ContactName
        {
            get { return _ContactName; }
            set { _ContactName = value; }
        }

        private string _ContactNumber;

        public string ContactNumber
        {
            get { return _ContactNumber; }
            set { _ContactNumber = value; }
        }

        private string _CUSTADDRESS;

        public string CUSTADDRESS
        {
            get { return _CUSTADDRESS; }
            set { _CUSTADDRESS = value; }
        }

        private string _CUSTPHONE;

        public string CUSTPHONE
        {
            get { return _CUSTPHONE; }
            set { _CUSTPHONE = value; }
        }

        private string _TaxCode;

        public string TaxCode
        {
            get { return _TaxCode; }
            set { _TaxCode = value; }
        }

        private string _ContactEmail;

        public string ContactEmail
        {
            get { return _ContactEmail; }
            set { _ContactEmail = value; }
        }

        private bool _CUSTViphaLAB;

        public bool CUSTViphaLAB
        {
            get { return _CUSTViphaLAB; }
            set { _CUSTViphaLAB = value; }
        }
    }
}