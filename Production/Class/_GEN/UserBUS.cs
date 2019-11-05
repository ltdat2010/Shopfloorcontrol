using System.Collections.Generic;

namespace Production.Class
{
    public class UserBUS
    {
        private UserDAO DAO = new UserDAO();

        public void User_INSERT(User USR)
        {
            DAO.User_INSERT(USR);
        }

        public void User_UPDATE(User USR)
        {
            DAO.User_UPDATE(USR);
        }

        public void User_DELETE(User USR)
        {
            DAO.User_DELETE(USR);
        }

        public List<User> User_SELECT_Email()
        {
            return DAO.User_SELECT_Email();
        }
    }
}