using System.Collections.Generic;
using System.Data;

namespace Production.Class
{
    public class UserDAO
    {
        public void User_INSERT(User USR)
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO[SYNC_NUTRICIEL].[dbo].[tbl_User] " +
                                       " ([UserName] " +
                                       " ,[PassWord] " +
                                       " ,[FullName] " +
                                       " ,[Name] " +
                                       " ,[GroupID] " +
                                       " ,[DeptID] " +
                                       " ,[Language] " +
                                       " ,[Email]) " +
                                 " VALUES " +
                                       "('" + USR.Username +
                                       "',N'" + USR.Password +
                                       "',N'" + USR.FullName +
                                       "'," + USR.GroupID +
                                       "," + USR.DeptID +
                                       ",'" + USR.Language +
                                       "',N'" + USR.Email +
                                        "')", CommandType.Text);
        }

        public void User_UPDATE(User USR)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_User] SET" +
                                       " [Username] = N'" + USR.Username + "'" +
                                       ",[Password] = N'" + USR.Password + "'" +
                                       ",[FullName] = N'" + USR.FullName + "'" +
                                       ",[GroupID] = " + USR.GroupID +
                                       ",[DeptID] = " + USR.DeptID +
                                       ",[Language] = N'" + USR.Language + "' " +
                                       ",[Email] = N'" + USR.Email + "' " +
                                       " WHERE [Id]=" + USR.ID, CommandType.Text);
        }

        public void User_DELETE(User USR)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_User] " +
                                        " WHERE [ID]=" + USR.ID, CommandType.Text);
        }

        public List<User> User_SELECT_Email()
        {
            List<User> _emailList = new List<User>();
            DataTable dt = new DataTable(); 
            dt = Sql.ExecuteDataTable("SAP", "SELECT ID,Email FROM [SYNC_NUTRICIEL].[dbo].[tbl_User] where Email is not null ", CommandType.Text);
            foreach (DataRow dr in dt.Rows)            
                _emailList.Add(new User() { ID = int.Parse(dr["ID"].ToString()), Email = dr["Email"].ToString() });
                           
            return _emailList;
        }
    }
}