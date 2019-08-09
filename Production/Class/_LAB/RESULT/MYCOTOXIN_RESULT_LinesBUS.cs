using System;
using System.Collections.Generic;
using System.Data;

namespace Production.Class
{
    public class MYCOTOXIN_RESULT_LinesBUS
    {
        MYCOTOXIN_RESULT_LinesDAO DAO = new MYCOTOXIN_RESULT_LinesDAO();
        public void MYCOTOXIN_RESULT_Lines_INSERT(MYCOTOXIN_RESULT_Lines OBJ)
        {
            DAO.MYCOTOXIN_RESULT_Lines_INSERT(OBJ);
        }

        public void MYCOTOXIN_RESULT_Lines_UPDATE(MYCOTOXIN_RESULT_Lines OBJ)
        {
            DAO.MYCOTOXIN_RESULT_Lines_UPDATE(OBJ);
        }

        public void MYCOTOXIN_RESULT_Lines_DELETE(MYCOTOXIN_RESULT_Lines OBJ)
        {
            DAO.MYCOTOXIN_RESULT_Lines_DELETE(OBJ);
        }

        public List<string> MYCOTOXIN_RESULT_Lines_List_Acronym(int ID)
        {
            return DAO.MYCOTOXIN_RESULT_Lines_List_Acronym(ID);
        }

        public DataTable MYCOTOXIN_RESULT_Lines_STD_SELECT(int ID, string acr)
        {
            return DAO.MYCOTOXIN_RESULT_Lines_STD_SELECT(ID, acr);
        }

        public DataTable MYCOTOXIN_RESULT_Lines_StandardCurve_Graph(int ID, string acr)
        {
            return DAO.MYCOTOXIN_RESULT_Lines_StandardCurve_Graph(ID, acr);
        }

        public DataTable MYCOTOXIN_RESULT_Lines_ACR_SELECT(int ID, string acr)
        {
            return DAO.MYCOTOXIN_RESULT_Lines_ACR_SELECT(ID, acr);
        }

        public DataTable MYCOTOXIN_RESULT_Lines_SELECT(int ID)
        {
            return DAO.MYCOTOXIN_RESULT_Lines_SELECT(ID);
        }

        public DataTable MYCOTOXIN_RESUTL_Lines_AnalysisReport(string SoPXN)
        {
            return DAO.MYCOTOXIN_RESUTL_Lines_AnalysisReport(SoPXN);
        }
    }

}


