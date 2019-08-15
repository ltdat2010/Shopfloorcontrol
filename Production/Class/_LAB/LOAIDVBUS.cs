namespace Production.Class
{
    public class LOAIDVBUS
    {
        private LOAIDVDAO DAO = new LOAIDVDAO();

        public void LOAIDV_INSERT(LOAIDV OBJ)
        {
            DAO.LOAIDV_INSERT(OBJ);
        }

        public void LOAIDV_UPDATE(LOAIDV OBJ)
        {
            DAO.LOAIDV_UPDATE(OBJ);
        }

        public void LOAIDV_DELETE(LOAIDV OBJ)
        {
            DAO.LOAIDV_DELETE(OBJ);
        }

        public int MAX_MALOAIDV()
        {
            return DAO.MAX_MALOAIDV();
        }
    }
}