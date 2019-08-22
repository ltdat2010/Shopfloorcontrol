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
        public decimal GMean { get; set; }
        public decimal Mean { get; set; }
        public decimal SD { get; set; }
        public decimal CV {get; set; }
        public decimal Min { get; set; }
        public decimal Max { get; set; }
        public string Tech { get; set; }
        public int HUYETTHANHHOC_STD_VALUE_ID { get; set; }
        public string Note { get; set; }
        public string CreatedBy { get; set; }
        public bool Locked { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Neg { get; set; }
        public int Sus { get; set; }
        public int Pos { get; set; }




    }
}
