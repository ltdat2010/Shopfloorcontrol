namespace Production.Class
{
    public class LOAIMAUBUS
    {
        private LOAIMAUDAO DAO = new LOAIMAUDAO();

        public void LOAIMAU_INSERT(LOAIMAU OBJ)
        {
            DAO.LOAIMAU_INSERT(OBJ);
        }

        public void LOAIMAU_UPDATE(LOAIMAU OBJ)
        {
            DAO.LOAIMAU_UPDATE(OBJ);
        }

        public void LOAIMAU_DELETE(LOAIMAU OBJ)
        {
            DAO.LOAIMAU_DELETE(OBJ);
        }

        public int MAX_MALOAIMAI()
        {
            return DAO.MAX_MALOAIMAI();
        }
    }
}