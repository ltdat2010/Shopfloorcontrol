using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Production.Class._LAB.RESULT
{
    public class IBD_RESULT_Header_LAB
    {
        public IBD_RESULT_Header_LAB()
        {

        }
        public int ID { get; set; }

        public string FilePath { get; set; }

        public string FileName { get; set; }

        public DateTime Date { get; set; }

        public string Time { get; set; }

        public string Case { get; set; }

        public int Count { get; set; }

        public float GMean { get; set; }
        public float Mean { get; set; }
        public float SD { get; set; }

        public float CV {get; set; }

        public float Min { get; set; }

        public float Max { get; set; }

        public string Tech { get; set; }

        public int HUYETTHANHHOC_STD_VALUE_ID { get; set; }

        public string Note { get; set; }
        public string CreatedBy { get; set; }
        public bool Locked { get; set; }
        public DateTime CreatedDate { get; set; }




    }
}
