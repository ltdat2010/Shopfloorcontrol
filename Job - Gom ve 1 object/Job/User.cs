using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using DevExpress.ClsSQL;

namespace DevExpress.ClsUser
{
    public class User
    {
        public int _ID;
        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }
        public string _UserName;
        public string Username
        {
            get { return _UserName; }
            set { _UserName = value; }
        }
        public string _Password;
        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }
        public int _GroupID;
        public int GroupID
        {
            get { return _GroupID; }
            set { _GroupID = value; }
        }
        public string _GroupName;
        public string GroupName
        {
            get { return _GroupName; }
            set { _GroupName = value; }
        }
        public float _Rules;
        public float Rules
        {
            get { return _Rules; }
            set { _Rules = value; }
        }
        public string _Language;
        public string Language
        {
            get { return _Language; }
            set { _Language = value; }
        }
        public int _DeptID;
        public int DeptID
        {
            get { return _DeptID; }
            set { _DeptID = value; }
        }
        //Contructor khong doi so
        public User()
        {

        }
    }
    public class User_
    {
        public User Login(string usr, string pass)
        {
            User user = new User();
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("Login", CommandType.StoredProcedure, "@user", usr, "@pass", pass);
            if (dt.Rows.Count > 0)
            {

                user._UserName                              = dt.Rows[0]["UserName"].ToString();
                user._GroupID                               = int.Parse(dt.Rows[0]["GroupID"].ToString());
                user._GroupName                             = dt.Rows[0]["GroupName"].ToString();
                user._Language                              = dt.Rows[0]["Language"].ToString();
                user._DeptID                                = int.Parse(dt.Rows[0]["Dept_Code"].ToString());
                user.ID                                     = int.Parse(dt.Rows[0]["ID"].ToString());
            }
            return user;
        }
        //public DataTable View()
        //{
        //    DataTable dt = new DataTable();
        //    dt = Sql.ExecuteDataTable("SELECT tbl_User.Name FROM tbl_User INNER JOIN tbl_Group ON tbl_User.GroupID = tbl_Group.ID  " +
        //           " WHERE tbl_User.DeptID = 2 and tbl_Group.ID <= 2");
        //    return dt;
        //}
        public bool CheckUser(string str1, string str2)
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("CheckUser", CommandType.StoredProcedure, "@str1", str1, "@str2", str2);
            //XtraMessageBox.Show("dt"+ dt.Rows.Count.ToString());
            return dt.Rows.Count > 0 ? true : false;
        }
        public void UpdatePass(User user)
        {
            Sql.ExecuteNonQuery("UpdatePass",CommandType.StoredProcedure,"@Password",user._Password,"@UserName",user._UserName);
        }
    }

}

