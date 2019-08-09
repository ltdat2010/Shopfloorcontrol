using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Globalization;
using DevExpress.XtraEditors;

namespace Production.Class
{
    public class KHMau_CTXN_RESULT_DETAILS_LABBUS
    {
        KHMau_CTXN_RESULT_DETAILS_LABDAO DAO = new KHMau_CTXN_RESULT_DETAILS_LABDAO();
        public void KHMau_CTXN_LABDAO_INSERT(KHMau_CTXN_RESULT_DETAILS_LAB OBJ)
        {

            DAO.KHMau_CTXN_LABDAO_INSERT(OBJ);
        }

        public void KHMau_CTXN_LABDAO_UPDATE(KHMau_CTXN_RESULT_DETAILS_LAB OBJ)
        {
            DAO.KHMau_CTXN_LABDAO_UPDATE(OBJ);
        }

        public void KHMau_CTXN_LABDAO_DELETE(int ID)
        {
            DAO.KHMau_CTXN_LABDAO_DELETE(ID);
        }

        public void KHMau_CTXN_LABDAO_DELETE_ByKHMau_CTXN_ID(int KHMau_CTXN_ID)
        {
            DAO.KHMau_CTXN_LABDAO_DELETE_ByKHMau_CTXN_ID(KHMau_CTXN_ID);
        }

        public void KHMau_CTXN_LABDAO_DELETE_ByKHMau(string KHMau)
        {
            DAO.KHMau_CTXN_LABDAO_DELETE_ByKHMau(KHMau);
        }

        public DataTable KHMau_CTXN_LABDAO_SELECT(string KHMau_CTXN_ID)
        {
            return DAO.KHMau_CTXN_LABDAO_SELECT(KHMau_CTXN_ID);
        }

        public int MAX_KHMau_CTXN_LABDAO_ID()
        {
            return DAO.MAX_KHMau_CTXN_LABDAO_ID();
        }        

    }

}


