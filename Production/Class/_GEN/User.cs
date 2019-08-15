using System.Data;

namespace Production.Class
{
    public class User
    {
        public User(
            int ID,
            string Username,
            string Password,
            string FullName,
            string Name,
            int GroupID,
            int DeptID,
            string Language,
            string Email
            )
        {
            this._ID = ID;
            this._Username = Username;
            this._Password = Password;
            this._FullName = FullName;
            this._Name = Name;
            this._GroupID = GroupID;
            this._DeptID = DeptID;
            this._Language = Language;
            this._Email = Email;
        }

        public int _ID;

        public int ID
        {
            get { return _ID; }
            set { _ID = value; }
        }

        public string _Username;

        public string Username
        {
            get { return _Username; }
            set { _Username = value; }
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

        public string _FullName;

        public string FullName
        {
            get { return _FullName; }
            set { _FullName = value; }
        }

        public string _Name;

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
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

        public string _Email;

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
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

            dt = Sql.ExecuteDataTable("SAP", "Login", CommandType.StoredProcedure, "@user", usr, "@pass", pass);
            if (dt.Rows.Count > 0)
            {
                user._Username = dt.Rows[0]["Username"].ToString();
                user._GroupID = int.Parse(dt.Rows[0]["GroupID"].ToString());
                //user._GroupName = dt.Rows[0]["GroupName"].ToString();
                user._Language = dt.Rows[0]["Language"].ToString();
                user._DeptID = int.Parse(dt.Rows[0]["Dept_Code"].ToString());
                user.ID = int.Parse(dt.Rows[0]["ID"].ToString());
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
            dt = Sql.ExecuteDataTable("SAP", "CheckUser", CommandType.StoredProcedure, "@str1", str1, "@str2", str2);
            //XtraMessageBox.Show("dt"+ dt.Rows.Count.ToString());
            return dt.Rows.Count > 0 ? true : false;
        }

        public void UpdatePass(User user)
        {
            Sql.ExecuteNonQuery("SAP", "UpdatePass", CommandType.StoredProcedure, "@Password", user._Password, "@UserName", user._Username);
        }
    }
}