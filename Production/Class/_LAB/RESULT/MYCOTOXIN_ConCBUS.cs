using System;
using System.Data;

namespace Production.Class
{
    public class MYCOTOXIN_ConCBUS
    {
        MYCOTOXIN_ConCDAO DAO = new MYCOTOXIN_ConCDAO();

        public void MYCOTOXIN_ConC_INSERT(MYCOTOXIN_ConC OBJ)
        {
            DAO.MYCOTOXIN_ConC_INSERT(OBJ);
        }

        public void MYCOTOXIN_ConC_UPDATE(MYCOTOXIN_ConC OBJ)
        {
            DAO.MYCOTOXIN_ConC_UPDATE(OBJ);
        }

        public void MYCOTOXIN_ConC_DELETE(MYCOTOXIN_ConC OBJ)
        {
            DAO.MYCOTOXIN_ConC_DELETE(OBJ);
        }
        


    }

}


