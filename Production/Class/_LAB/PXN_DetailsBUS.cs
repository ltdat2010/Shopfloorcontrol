using System.Data;

namespace Production.Class
{
    public class PXN_DetailsBUS
    {
        private PXN_DetailsDAO DAO = new PXN_DetailsDAO();

        public void PXN_DetailsBUS_INSERT(PXN_Details OBJ)
        {
            DAO.PXN_DetailsDAO_INSERT(OBJ);
        }

        public void PXN_DetailsBUS_UPDATE(PXN_Details OBJ)
        {
            DAO.PXN_DetailsDAO_UPDATE(OBJ);
        }

        public void PXN_DetailsBUS_DELETE(PXN_Details OBJ)
        {
            DAO.PXN_DetailsDAO_DELETE(OBJ);
        }

        public DataTable PXN_DetailsBUS_SELECT(string SoPXN)
        {
            return DAO.PXN_DetailsDAO_SELECT(SoPXN);
        }

        public int MAX_PXN_DetailsBUS_ID()
        {
            return DAO.MAX_PXN_DetailsDAO_ID();
        }

        public int PXN_DetailsDAO_SELECT_ID_BY_SoPXN_CTXNID(string SoPXN, int CTXNID)
        {
            return DAO.PXN_DetailsDAO_SELECT_ID_BY_SoPXN_CTXNID(SoPXN, CTXNID);
        }


    }
}