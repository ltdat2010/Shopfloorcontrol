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
    }
}