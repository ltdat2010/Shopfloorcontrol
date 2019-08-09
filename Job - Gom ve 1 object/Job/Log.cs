using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DevExpress.ClsSQL;

namespace DevExpress.ClsLog
{
    public class Log
    {
        public string _UserName;
        public string UserName
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        public string _Type;
        public string Type
        {
            get { return _Type; }
            set { _Type = value; }
        }
        public string _Content;
        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }
    }
    public class Log_
    {
        public void Insert(string s1,string s2, string s3)
        {
            //Sql.ExecuteNonQuery("INSERT INTO [200].[dbo].[Pro_UserLog]([Username],[Type],[Time],[Content]) VALUES('"+s1+"','"+s2+"',GETDATE(),'"+s3+"')");

        }
        
    }
}
