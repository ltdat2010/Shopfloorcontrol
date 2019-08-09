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
    public class PO_Lines_BUS
    {
        PO_Lines_DAO DAO = new PO_Lines_DAO();
        public void PO_Lines_INSERT(PO_Lines OBJ)
        {
            DAO.PO_Lines_INSERT(OBJ);
        }

        public void PO_Lines_UPDATE(PO_Lines OBJ)
        {
            DAO.PO_Lines_UPDATE(OBJ);
        }

        public void PO_Lines_DELETE(int ID)
        {
            DAO.PO_Lines_DELETE(ID);
        }

        public DataTable PO_Lines_SELECT(string SoPO)
        {
            return DAO.PO_Lines_SELECT(SoPO);
        }

    }

}


