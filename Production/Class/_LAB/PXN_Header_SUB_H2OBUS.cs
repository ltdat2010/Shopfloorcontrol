﻿namespace Production.Class
{
    public class PXN_Header_SUB_H2OBUS
    {
        private PXN_Header_SUB_H2ODAO DAO = new PXN_Header_SUB_H2ODAO();

        public void PXN_Header_SUB_H2ODAO_INSERT(PXN_Header_SUB_H2O OBJ)
        {
            PXN_Header_SUB_H2ODAO_INSERT(OBJ);
        }

        public void PXN_Header_SUB_H2ODAO_UPDATE(PXN_Header_SUB_H2O OBJ)
        {
            PXN_Header_SUB_H2ODAO_UPDATE(OBJ);
        }

        public void PXN_Header_SUB_H2ODAO_DELETE(PXN_Header_SUB_H2O OBJ)
        {
            PXN_Header_SUB_H2ODAO_DELETE(OBJ);
        }

        public int MAX_PXN_Header_SUB_H2ODAO_ID()
        {
            return DAO.MAX_PXN_Header_SUB_H2ODAO_ID();
        }
    }
}