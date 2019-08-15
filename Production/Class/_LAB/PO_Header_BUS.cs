using System;
using System.Data;

namespace Production.Class
{
    public class PO_Header_BUS
    {
        private PO_Header_DAO DAO = new PO_Header_DAO();

        public void PO_Header_INSERT(PO_Header OBJ)
        {
            DAO.PO_Header_INSERT(OBJ);
        }

        public void PO_Header_UPDATE(PO_Header OBJ)
        {
            DAO.PO_Header_UPDATE(OBJ);
        }

        public void PO_Header_DELETE(int ID)
        {
            DAO.PO_Header_DELETE(ID);
        }

        public DataTable PO_Header_SELECT(string SoPO)
        {
            return DAO.PO_Header_SELECT(SoPO);
        }

        public string Issued_SoPO()
        {
            return DAO.Issued_SoPO();
        }

        public void Update_SoPO(string SoPO)
        {
            DAO.Update_SoPO(SoPO);
        }

        public DataTable PO_List_Report(DateTime Stardate, DateTime Enddate)
        {
            return DAO.PO_List_Report(Stardate, Enddate);
        }

        public DataTable PO_List_NotPaymented(DateTime Stardate, DateTime Enddate)
        {
            return DAO.PO_List_NotPaymented(Stardate, Enddate);
        }
    }
}