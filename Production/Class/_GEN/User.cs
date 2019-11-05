using System.Data;

namespace Production.Class
{
    public class User
    {
        public User()
        {
        }
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string FullName { get; set; }
        public string Name { get; set; }
        public int GroupID { get; set; }
        public int DeptID { get; set; }
        public string Language { get; set; }
        public string Email { get; set; }

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
                user.Username = dt.Rows[0]["Username"].ToString();
                user.GroupID = int.Parse(dt.Rows[0]["GroupID"].ToString());
                //user._GroupName = dt.Rows[0]["GroupName"].ToString();
                user.Language = dt.Rows[0]["Language"].ToString();
                user.DeptID = int.Parse(dt.Rows[0]["Dept_Code"].ToString());
                user.ID = int.Parse(dt.Rows[0]["ID"].ToString());
                user.Email = dt.Rows[0]["Email"].ToString();
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
            Sql.ExecuteNonQuery("SAP", "UpdatePass", CommandType.StoredProcedure, "@Password", user.Password, "@UserName", user.Username);
        }
    }
}