using System;

namespace Production.Class
{
    //public class SUPPLIER
    public class LOCATION
    {      

        public LOCATION()
        {

        }       

        public int Id { get; set; }
        public string LOCName { get; set; }
        public string LOCCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string Note { get; set; }
        public bool Locked { get; set; }       

    }
}