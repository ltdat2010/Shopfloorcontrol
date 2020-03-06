using System;

namespace Production.Class._LAB
{
    public class PGM
    {
        public PGM()
        {

        }
        public int ID { get; set; }
        public string MaPGM { get; set; }        
        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Note { get; set; }
        public bool Locked { get; set; }
    }
}