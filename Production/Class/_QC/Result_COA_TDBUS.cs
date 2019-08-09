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
    public class Result_COA_TDBUS
    {
        Result_COA_TDDAO DAO = new Result_COA_TDDAO();

        public void Result_COA_TDBUS_INSERT(Result_COA_TD OBJ)
        {
            DAO.Result_COA_TDDAO_INSERT(OBJ);
        }

        public void Result_COA_TDBUS_UPDATE(Result_COA_TD OBJ)
        {
            DAO.Result_COA_TDDAO_UPDATE(OBJ);
        }

        public void Result_COA_TDBUS_DELETE(Result_COA_TD OBJ)
        {
            DAO.Result_COA_TDDAO_DELETE(OBJ);
        }

        public int MAX_Result_COA_TD_ID()
        {
            return DAO.MAX_Result_COA_TD_ID();

        }
        public int Result_COA_TD_SoCOA()
        {
            return DAO.Result_COA_TD_SoCOA();

        }
    }

}


