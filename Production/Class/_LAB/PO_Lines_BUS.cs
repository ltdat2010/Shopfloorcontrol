using System.Data;

namespace Production.Class
{
    public class PO_Lines_BUS
    {
        private PO_Lines_DAO DAO = new PO_Lines_DAO();

        public void PO_Lines_INSERT(PO_Lines OBJ)
        {
            DAO.PO_Lines_INSERT(OBJ);
        }

        public void PO_Lines_UPDATE(PO_Lines OBJ)
        {
            DAO.PO_Lines_UPDATE(OBJ);
        }

        public void PO_Lines_DELETE(int ID)
        {
            DAO.PO_Lines_DELETE(ID);
        }

        public DataTable PO_Lines_SELECT(string SoPO)
        {
            return DAO.PO_Lines_SELECT(SoPO);
        }
    }
}