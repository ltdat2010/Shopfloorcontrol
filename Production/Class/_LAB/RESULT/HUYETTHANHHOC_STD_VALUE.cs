using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Production.Class._LAB.RESULT
{
    class HUYETTHANHHOC_STD_VALUE
    {
        public HUYETTHANHHOC_STD_VALUE()
        {

        }

        public int ID { get; set; }
        public int CTXN_ID { get; set; }
        public string TEST_SOFTWARE_SUP_NAME { get; set; }
        public string TEST_SOFTWARE_CTXN_NAME { get; set; }
        public string TEST_SOFTWARE_POS_INEQLT_SYM { get; set; }
        public float TEST_SOFTWARE_POS_VAL { get; set; }
        public string TEST_SOFTWARE_NEG_INEQLT_SYM { get; set; }
        public float TEST_SOFTWARE_NEG_VAL { get; set; }
        public bool TEST_SOFTWARE_SUSPICION { get; set; }
        public string TEST_SOFTWARE_CTXN_FEATURE { get; set; }
        public string Note { get; set; }
        public string CreatedBy { get; set; }
        public bool Locked { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
