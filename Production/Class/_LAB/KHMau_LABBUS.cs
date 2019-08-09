using System.Data;

namespace Production.Class
{
    public class KHMau_LABBUS
    {
        KHMau_LABDAO DAO = new KHMau_LABDAO();

        public void KHMau_LABBUS_INSERT(KHMau_LAB OBJ)
        {
            DAO.KHMau_LABDAO_INSERT(OBJ);
        }

        public void KHMau_LABBUS_UPDATE(KHMau_LAB OBJ)
        {
            DAO.KHMau_LABDAO_UPDATE(OBJ);
        }

        public void KHMau_LABBUS_DELETE(string KHMau)
        {
            DAO.KHMau_LABDAO_DELETE(KHMau);
        }

        public void KHMau_LABBUS_DELETE_SoPXN(string SoPXN)
        {
            DAO.KHMau_LABDAO_DELETE_SoPXN(SoPXN);
        }

        public DataTable KHMau_LABBUS_SELECT(string SoPXN)
        {
            return DAO.KHMau_LABDAO_SELECT(SoPXN);
        }

        public int MAX_KHMau_LABBUS_ID()
        {
            return DAO.MAX_KHMau_LABDAO_ID();

        }

        public DataTable KHMau_LABDAO_REPORT_RECEIPT(string SoPXN)
        {
            return DAO.KHMau_LABDAO_REPORT_RECEIPT(SoPXN);
        }

        public DataTable KHMau_LABDAO_REPORT_DETAILS(string SoPXN)
        {
            return DAO.KHMau_LABDAO_REPORT_DETAILS(SoPXN);
        }

        public DataTable KHMau_LABDAO_REPORT_STORAGE(string SoPXN)
        {
            return DAO.KHMau_LABDAO_REPORT_STORAGE(SoPXN);
        }

        public DataTable KHMau_LABDAO_REPORT_DETROY(string SoPXN)
        {
            return DAO.KHMau_LABDAO_REPORT_DETROY(SoPXN);
        }

        public DataTable KHMau_LABDAO_REPORT_KHMAU(string SoPXN)
        {
            return DAO.KHMau_LABDAO_REPORT_DETAILS(SoPXN);
        }
    }

}


