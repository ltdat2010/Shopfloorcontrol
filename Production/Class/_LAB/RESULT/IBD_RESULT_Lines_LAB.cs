using System;

namespace Production.Class._LAB.RESULT
{
    public class IBD_RESULT_Lines_LAB
    {
        public IBD_RESULT_Lines_LAB()
        {
        }

        public int ID { get; set; }
        public int CTXN_ID { get; set; }
        public string KHMau_GiaoMau { get; set; }
        public string Line_No { get; set; }
        public int IBD_RESULT_Header_LAB_ID { get; set; }
        public decimal OD { get; set; }
        public decimal? SP { get; set; }
        public decimal? Titer { get; set; }
        public int? GroupTiter { get; set; }
        public string Row { get; set; }
        public string Col { get; set; }
        public string Result { get; set; }
        public string Note { get; set; }
        public string CreatedBy { get; set; }
        public bool Locked { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}