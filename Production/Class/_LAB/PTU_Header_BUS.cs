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
    public class PTU_Header_BUS
    {

        PTU_Header_DAO DAO = new PTU_Header_DAO();
        public void PTU_Header_INSERT(PTU_Header OBJ)
        {

            DAO.PTU_Header_INSERT(OBJ);
        }

        public void PTU_Header_UPDATE(PTU_Header OBJ)
        {
            DAO.PTU_Header_UPDATE(OBJ);
        }

        public void PTU_Header_DELETE(int ID)
        {
            DAO.PTU_Header_DELETE(ID);
        }

        public DataTable PTU_Header_SELECT(string SoPTU)
        {
            return DAO.PTU_Header_SELECT(SoPTU);
        }

        public string Issued_SoPTU()
        {
            return DAO.Issued_SoPTU();
        }

        //public void Update_SoPO(string SoPO)
        //{
        //    Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_Info] SET PONumber = '" + SoPO + "'", CommandType.Text);
        //}

    }

}


