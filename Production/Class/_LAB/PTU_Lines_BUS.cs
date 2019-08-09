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
    public class PTU_Lines_BUS
    {

        PTU_Lines_DAO DAO = new PTU_Lines_DAO();
        public void PTU_Lines_INSERT(PTU_Lines OBJ)
        {
            DAO.PTU_Lines_INSERT(OBJ);
        }

        public void PTU_Lines_UPDATE(PTU_Lines OBJ)
        {
            DAO.PTU_Lines_UPDATE(OBJ);
        }

        public void PTU_Lines_DELETE(int ID)
        {
            DAO.PTU_Lines_DELETE(ID);
        }

        public DataTable PTU_Lines_SELECT(string SoPTU)
        {
            return DAO.PTU_Lines_SELECT(SoPTU);
        }
    }

}


