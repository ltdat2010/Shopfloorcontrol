﻿using System.Data;

namespace Production.Class
{
    public class KQKN_Template_Details_RowBUS
    {
        private KQKN_Template_Details_RowDAO DAO = new KQKN_Template_Details_RowDAO();

        public void KQKN_Template_Details_Row_INSERT(KQKN_Template_Details_Row OBJ)
        {
            DAO.KQKN_Template_Details_Row_INSERT(OBJ);
        }

        public void KQKN_Template_Details_Row_UPDATE(KQKN_Template_Details_Row OBJ)
        {
            DAO.KQKN_Template_Details_Row_UPDATE(OBJ);
        }

        public void KQKN_Template_Details_Row_DELETE(KQKN_Template_Details_Row OBJ)
        {
            DAO.KQKN_Template_Details_Row_DELETE(OBJ);
        }

        public DataTable KQKN_Template_Details_Row_SELECT(Result_KQKN_TD OBJ)
        {
            return DAO.KQKN_Template_Details_Row_SELECT(OBJ);
        }
    }
}