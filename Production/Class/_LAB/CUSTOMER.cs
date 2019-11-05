using System;

namespace Production.Class
{
    //public class SUPPLIER
    public class CUSTOMER
    {
        public CUSTOMER()
        {
        }

        public int Id { get; set; }
        public string CUSTNAME { get; set; }
        public string CUSTCODE { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public bool Locked { get; set; }
        public string CUSTTYPECode { get; set; }
        public string LOCName { get; set; }
        public string ProvinceName { get; set; }
        public int ProvinceId { get; set; }
        public string EMPCode { get; set; }
        public string ContactName { get; set; }
        public string ContactNumber { get; set; }
        public string CUSTADDRESS { get; set; }
        public string CUSTPHONE { get; set; }
        public string TaxCode { get; set; }
        public string ContactEmail { get; set; }
        public string Note { get; set; }
        public bool CUSTViphaLAB { get; set; }

    }
}