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
    public class COA_Template_DetailsBUS
    {
        COA_Template_DetailsDAO DAO = new COA_Template_DetailsDAO();

        public void COA_Template_DetailsDAO_INSERT(COA_Template_Details OBJ)
        {
            DAO.COA_Template_DetailsDAO_INSERT(OBJ);
        }

        public void COA_Template_DetailsDAO_UPDATE(COA_Template_Details OBJ)
        {
            DAO.COA_Template_DetailsDAO_UPDATE(OBJ);
        }

        public void COA_Template_DetailsDAO_DELETE(COA_Template_Details OBJ)
        {
            DAO.COA_Template_DetailsDAO_DELETE(OBJ);
        }

        public DataTable COA_Template_Details_SELECT(Result_COA_TD OBJ)
        {
            return DAO.COA_Template_Details_SELECT(OBJ);
        }

    }

}


