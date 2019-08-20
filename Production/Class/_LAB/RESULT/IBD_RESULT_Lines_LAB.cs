using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Production.Class._LAB.RESULT
{
    public class IBD_RESULT_Lines_LAB
    {
        public IBD_RESULT_Lines_LAB()
        {
            
        }
        public int ID { get; set; }
        public string Line_No { get; set; }
        public int IBD_RESULT_Header_LAB_ID { get; set; }
        public float OD { get; set; }
        public float SP { get; set; }
        public int Titer { get; set; }
        public int GroupTiter { get; set; }
        public string Well { get; set; }
        public string Result { get; set; }
        public string Note { get; set; }
        public string CreatedBy { get; set; }
        public bool Locked { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
