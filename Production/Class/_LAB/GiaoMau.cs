using System;

namespace Production.Class._LAB
{
    public class GiaoMau
    {
        public GiaoMau()
        {
        }

        public int ID { get; set; }
        public int KHMau_CTXN_LAB_ID { get; set; }
        public int SoLuongGiao { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Note { get; set; }
        public bool Locked { get; set; }
    }
}