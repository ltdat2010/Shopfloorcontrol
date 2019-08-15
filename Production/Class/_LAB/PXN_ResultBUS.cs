using System.Data;

namespace Production.Class
{
    public class PXN_ResultBUS
    {
        private PXN_ResultDAO DAO = new PXN_ResultDAO();

        public void PXN_ResultBUS_INSERT(PXN_Result OBJ)
        {
            DAO.PXN_ResultDAO_INSERT(OBJ);
        }

        public void PXN_ResultBUS_UPDATE(PXN_Result OBJ)
        {
            DAO.PXN_ResultDAO_UPDATE(OBJ);
        }

        public void PXN_ResultBUS_DELETE(PXN_Result OBJ)
        {
            DAO.PXN_ResultDAO_DELETE(OBJ);
        }

        public DataTable PXN_ResultBUS_SELECT(string SoPXN)
        {
            return DAO.PXN_ResultDAO_SELECT(SoPXN);
        }

        public int MAX_PXN_ResultBUS_ID()
        {
            return DAO.MAX_PXN_ResultDAO_ID();
        }
    }
}