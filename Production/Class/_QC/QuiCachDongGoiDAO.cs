using System;
using System.Data;

namespace Production.Class
{
    public class QuiCachDongGoiDAO
    {
        public DataTable QCDG_List()
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "Select * From [SYNC_NUTRICIEL].[dbo].tbl_QuiCachDongGoi", CommandType.Text);
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
        //public void QCDG_Update(DataRow dr)
        //{
        //    Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_QuiCachDongGoi]" +
        //                                " SET [QCDG] ='"+dr["QCDG"].ToString() + "'"+
        //                                ",[QCDGDG] = '" + dr["QCDGDG"].ToString() + "' " +
        //                                "WHERE ID=" + int.Parse(dr["ID"].ToString()), CommandType.Text);
        //    //return dt;
        //}

        public void QCDG_INSERT(QuiCachDongGoi OBJ)
        {
            //XtraMessageBox.Show("LOC.Locked : " + LOC.Locked.ToString());
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_QuiCachDongGoi] " +
           " ([QCDG] " +
           " ,[QCDGDG] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Locked]) " +
     " VALUES " +
           "(N'" + OBJ.QCDG +
           "',N'" + OBJ.QCDGDG +
           "',CONVERT(datetime,'" + DateTime.Now +
           "',103),N'" + OBJ.CreatedBy +
           "',N'" + OBJ.Note +
           "','" + OBJ.Locked +
           "')", CommandType.Text);
        }

        public void QCDG_UPDATE(QuiCachDongGoi OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_QuiCachDongGoi] SET" +
           "[QCDG] = N'" + OBJ.QCDG + "'" +
           ",[QCDGDG] = N'" + OBJ.QCDGDG + "'" +
           ",[CreatedDate] = CONVERT(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy] = N'" + OBJ.CreatedBy + "' " +
           ",[Note] = N'" + OBJ.Note + "' " +
           ",[Locked] = '" + OBJ.Locked + "' " +
           " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }

        public void QCDG_DELETE(QuiCachDongGoi OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_QuiCachDongGoi] " +
            " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }
    }
}