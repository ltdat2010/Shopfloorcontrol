using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Production.Class
{
    class PRICELISTBUS
    {
        PRICELISTDAO DAO = new PRICELISTDAO();

        public DataTable PRICELISTBUS_List()
        {
            return DAO.PRICELISTDAO_List();
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

        public void PRICELISTBUS_INSERT(PRICELIST OBJ)
        {
            DAO.PRICELISTDAO_INSERT(OBJ);
        }

        public void PRICELISTBUS_UPDATE(PRICELIST OBJ)
        {
            DAO.PRICELISTDAO_UPDATE(OBJ);
        }

        public void PRICELISTBUS_DELETE(PRICELIST OBJ)
        {
            DAO.PRICELISTDAO_DELETE(OBJ);
        }

        public int MAX_PRICELIST_ID()
        {
            return DAO.MAX_PRICELIST_ID();

        }

    }
}
