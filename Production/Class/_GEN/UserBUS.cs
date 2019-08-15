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
    }
}