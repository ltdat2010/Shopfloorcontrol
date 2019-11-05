using System;

namespace Production.Class
{
    //public class SUPPLIER
    public class Province
    {
        public Province()
        {

        }
        public int Id { get; set; }
        public string ProvinceName { get; set; }
        public string ProvinceCode { get; set; }
        public int LOCId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string Note { get; set; }
        public bool Locked { get; set; }



    }
}