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
    public class COA_Template_HeaderBUS
    {
        COA_Template_HeaderDAO DAO = new COA_Template_HeaderDAO();

        public void COA_Template_HeaderDAO_INSERT(COA_Template_Header OBJ)
        {
            DAO.COA_Template_HeaderDAO_INSERT(OBJ);
        }

        public void COA_Template_HeaderDAO_UPDATE(COA_Template_Header OBJ)
        {
            DAO.COA_Template_HeaderDAO_UPDATE(OBJ);
        }

        public void COA_Template_HeaderDAO_DELETE(COA_Template_Header OBJ)
        {
            DAO.COA_Template_HeaderDAO_DELETE(OBJ);
        }

        public int MAX_COA_Template_ID()
        {
            return DAO.MAX_COA_Template_ID();

        }
    }

}


