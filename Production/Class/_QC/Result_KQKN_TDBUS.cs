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
    public class Result_KQKN_TDBUS
    {
        Result_KQKN_TDDAO DAO = new Result_KQKN_TDDAO();

        public void Result_KQKN_TD_INSERT(Result_KQKN_TD OBJ)
        {
            DAO.Result_KQKN_TD_INSERT(OBJ);
        }

        public void Result_KQKN_TD_UPDATE(Result_KQKN_TD OBJ)
        {
            DAO.Result_KQKN_TD_UPDATE(OBJ);
        }

        public void Result_KQKN_TD_DELETE(Result_KQKN_TD OBJ)
        {
            DAO.Result_KQKN_TD_DELETE(OBJ);
        }

        public int MAX_Result_KQKB_TD_ID()
        {
            return DAO.MAX_Result_KQKB_TD_ID();
        }

        public int Result_KQKB_TD_SoPNK(string pre)
        {
            return DAO.Result_KQKB_TD_SoPNK(pre);

        }

        //public Result_KQKN_TD Result_KQKN_TD_SELECT(Result_KQKN_TD OBJ)
        //{
            
        //    return DAO.Result_KQKN_TD_SELECT(OBJ);
        //}
    }

}


