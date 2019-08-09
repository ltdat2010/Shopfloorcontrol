using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Production.Class
{
    class NHOMCHITIEUXETNGHIEMBUS
    {
        NHOMCHITIEUXETNGHIEMDAO DAO = new NHOMCHITIEUXETNGHIEMDAO();
        public DataTable NPPXN_List()
        {
            return DAO.NCTXN_List();
        }
        //public void TC_Insert(TieuChuan tc)
        //{           
        //    Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_TieuChuan] " +
        //                                           "([TC] " +
        //                                           ",[TCDG]) " +
        //                                     "VALUES " +
        //                                           "('" + tc.TC + 
        //                                           "','" + tc.TCDG + "'", CommandType.Text);
        //    //return dt;
        //}
        //public void PPT_Update(DataRow dr)
        //{            
        //    Sql.ExecuteNonQuery("SAP",  "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_PhuongPhapThu]" +
        //                                " SET [PPT] ='"+dr["PPT"].ToString() + "'"+
        //                                ",[PPTDG] = '" + dr["PPTDG"].ToString() + "' " +
        //                                "WHERE ID=" + int.Parse(dr["ID"].ToString()), CommandType.Text);
        //    //return dt;
        //}

        public void NCTXN_INSERT(NHOMCHITIEUXETNGHIEM OBJ)
        {
            DAO.NCTXN_INSERT(OBJ);
        }

        public void NCTXN_UPDATE(NHOMCHITIEUXETNGHIEM OBJ)
        {
            DAO.NCTXN_UPDATE(OBJ);
        }

        public void NCTXN_DELETE(NHOMCHITIEUXETNGHIEM OBJ)
        {
            DAO.NCTXN_DELETE(OBJ);
        }
    }
}
