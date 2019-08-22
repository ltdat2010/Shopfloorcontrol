using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Production.Class._LAB.RESULT
{
    public class IBD_RESULT_Summary_LAB
    {
        public IBD_RESULT_Summary_LAB()
        {

        }
        public int ID { get; set; }
        public string Type { get; set; }
        public int IBD_RESULT_Header_LAB_ID { get; set; }
        public decimal AMean { get; set; }
        public decimal GMean { get; set; }
        public decimal SD { get; set; }
        public decimal CV { get; set; }
        public decimal Min { get; set; }
        public decimal Max { get; set; }
        public string Note { get; set; }
        public string CreatedBy { get; set; }
        public bool Locked { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
