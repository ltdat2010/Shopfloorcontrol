using System.Data;

namespace Production.Class
{
    public class MYCOTOXIN_RESULT_HeaderBUS
    {
        private MYCOTOXIN_RESULT_HeaderDAO DAO = new MYCOTOXIN_RESULT_HeaderDAO();

        public int MYCOTOXIN_RESULT_Header_INSERT(MYCOTOXIN_RESULT_Header OBJ)
        {
            return DAO.MYCOTOXIN_RESULT_Header_INSERT(OBJ);
        }

        public void MYCOTOXIN_RESULT_Header_UPDATE(MYCOTOXIN_RESULT_Header OBJ)
        {
            DAO.MYCOTOXIN_RESULT_Header_UPDATE(OBJ);
        }

        public void MYCOTOXIN_RESULT_Header_DELETE(MYCOTOXIN_RESULT_Header OBJ)
        {
            DAO.MYCOTOXIN_RESULT_Header_DELETE(OBJ);
        }

        public int MYCOTOXIN_RESULT_Header_ID(string FilePath)
        {
            return DAO.MYCOTOXIN_RESULT_Header_ID(FilePath);
        }

        public DataTable MYCOTOXIN_RESULT_Header_SELECT(int ID)
        {
            return DAO.MYCOTOXIN_RESULT_Header_SELECT(ID);
        }
    }
}