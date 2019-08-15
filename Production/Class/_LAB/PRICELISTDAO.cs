using System;
using System.Data;

namespace Production.Class
{
    internal class PRICELISTDAO
    {
        public DataTable PRICELISTDAO_List()
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "Select ID , PL From [SYNC_NUTRICIEL].[dbo].tbl_PriceList_LAB", CommandType.Text);
            return dt;
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

        public void PRICELISTDAO_INSERT(PRICELIST OBJ)
        {
            //XtraMessageBox.Show("LOC.Locked : " + LOC.Locked.ToString());
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_PriceList_LAB] " +
           " ([PL] " +
           " ,[EffDate] " +
           " ,[ExpDate] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Locked]) " +
            " VALUES " +
           "(N'" + OBJ.PL +
           "',CONVERT(datetime,'" + OBJ.EffDate +
           "',103),CONVERT(datetime,'" + OBJ.ExpDate +
           "',103),CONVERT(datetime,'" + DateTime.Now +
           "',103),N'" + OBJ.CreatedBy +
           "',N'" + OBJ.Note +
           "','" + OBJ.Locked +
           "')", CommandType.Text);
        }

        public void PRICELISTDAO_UPDATE(PRICELIST OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_PriceList_LAB] SET " +
           " [PL] = N'" + OBJ.PL + "' " +
           ",[EffDate] = CONVERT(datetime,'" + OBJ.EffDate + "',103)" +
           ",[ExpDate] = CONVERT(datetime,'" + OBJ.ExpDate + "',103)" +
           ",[CreatedDate] = CONVERT(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy] = N'" + OBJ.CreatedBy + "' " +
           ",[Note] = N'" + OBJ.Note + "' " +
           ",[Locked] = '" + OBJ.Locked + "' " +
           " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }

        public void PRICELISTDAO_DELETE(PRICELIST OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_PriceList_LAB] " +
            " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }

        public int MAX_PRICELIST_ID()
        {
            DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT MAX(ID) as ID FROM [SYNC_NUTRICIEL].[dbo].[tbl_PriceList_LAB]", CommandType.Text);
            return int.Parse(dt.Rows[0]["ID"].ToString());
        }
    }
}