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
        public float AMean { get; set; }
        public float GMean { get; set; }
        public float SD { get; set; }
        public float CV { get; set; }
        public float Min { get; set; }
        public float Max { get; set; }
        public string Note { get; set; }
        public string CreatedBy { get; set; }
        public bool Locked { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
