using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Production.Class
{
    public class LabTesting
    {
        private int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        private string _Testing_Code;

        public string Testing_Code
        {
            get { return _Testing_Code; }
            set { _Testing_Code = value; }
        }

        private string _Customer_Code;

        public string Customer_Code
        {
            get { return _Customer_Code; }
            set { _Customer_Code = value; }
        }

        private string _Testing_Name;

        public string Testing_Name
        {
            get { return _Testing_Name; }
            set { _Testing_Name = value; }
        }

        public DateTime _Created_Date;

        public DateTime Created_Date
        {
            get { return _Created_Date; }
            set { _Created_Date = value; }
        }

        private string _Created_By;

        public string Created_By
        {
            get { return _Created_By; }
            set { _Created_By = value; }
        }

        private string _Testing_Period_Time;
        public string Testing_Period_Time
        {
            get { return _Testing_Period_Time; }
            set { _Testing_Period_Time = value; }
        }

        private string _Testing_Result_Receive_Time;
        public string Testing_Result_Receive_Time
        {
            get { return _Testing_Result_Receive_Time; }
            set { _Testing_Result_Receive_Time = value; }
        }

        
    }
}
