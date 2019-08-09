using System;
using System.Data;

namespace Production.Class
{
    public class MYCOTOXIN_RESULT_StandardCurveBUS
    {
        MYCOTOXIN_RESULT_StandardCurveDA0 DAO = new MYCOTOXIN_RESULT_StandardCurveDA0();
        public void MYCOTOXIN_RESULT_StandardCurve_INSERT(MYCOTOXIN_RESULT_StandardCurve OBJ)
        {
            DAO.MYCOTOXIN_RESULT_StandardCurve_INSERT(OBJ);
        }

        public void MYCOTOXIN_RESULT_StandardCurve_UPDATE(MYCOTOXIN_RESULT_StandardCurve OBJ)
        {
            DAO.MYCOTOXIN_RESULT_StandardCurve_UPDATE(OBJ);
        }

        public void MYCOTOXIN_RESULT_StandardCurve_DELETE(MYCOTOXIN_RESULT_StandardCurve OBJ)
        {
            DAO.MYCOTOXIN_RESULT_StandardCurve_DELETE(OBJ);
        }
        public DataTable MYCOTOXIN_RESULT_StandardCurve_SELECT(int ID, string acr)
        {
            return DAO.MYCOTOXIN_RESULT_StandardCurve_SELECT(ID, acr);

        }

    }

}


