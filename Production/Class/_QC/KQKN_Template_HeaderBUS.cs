﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Globalization;
using DevExpress.XtraEditors;

namespace Production.Class
{
    public class KQKN_Template_HeaderBUS
    {
        KQKN_Template_HeaderDAO DAO = new KQKN_Template_HeaderDAO();

        public void KQKN_Template_Header_INSERT(KQKN_Template_Header OBJ)
        {
            DAO.KQKN_Template_Header_INSERT(OBJ);
        }

        public void KQKN_Template_Header_UPDATE(KQKN_Template_Header OBJ)
        {
            DAO.KQKN_Template_Header_UPDATE(OBJ);
        }

        public void KQKN_Template_Header_DELETE(KQKN_Template_Header OBJ)
        {
            DAO.KQKN_Template_Header_DELETE(OBJ);
        }

        public int MAX_KQKB_Template_ID()
        {
            return DAO.MAX_KQKB_Template_ID();

        }
    }

}


