using Production.Class._LAB.RESULT;
using System.Data;

namespace Production.Class
{
    public class IBD_RESULT_Lines_LABBUS
    {
        private IBD_RESULT_Lines_LABDAO DAO = new IBD_RESULT_Lines_LABDAO();

        public void IBD_RESULT_Lines_LABDAO_INSERT(IBD_RESULT_Lines_LAB OBJ)
        {
            DAO.IBD_RESULT_Lines_LABDAO_INSERT(OBJ);
        }

        public void IBD_RESULT_Lines_LABDAO_UPDATE(IBD_RESULT_Lines_LAB OBJ)
        {
            DAO.IBD_RESULT_Lines_LABDAO_UPDATE(OBJ);
        }

        public void IBD_RESULT_Lines_LABDAO_DELETE(IBD_RESULT_Lines_LAB OBJ)
        {
            DAO.IBD_RESULT_Lines_LABDAO_DELETE(OBJ);
        }

        public DataTable IBD_RESULT_Lines_LABDAO_SELECT(int ID)
        {
            return DAO.IBD_RESULT_Lines_LABDAO_SELECT(ID);
        }
    }
}