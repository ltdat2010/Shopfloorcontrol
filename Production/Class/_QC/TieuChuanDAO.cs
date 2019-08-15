using System;
using System.Data;

namespace Production.Class
{
    public class TieuChuanDAO
    {
        public DataTable TC_List()
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "Select ID , TC From [SYNC_NUTRICIEL].[dbo].[tbl_TieuChuan] WHERE ID>1", CommandType.Text);
            return dt;
        }

        //public void TC_Update(DataRow dr)
        //{
        //    Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_TieuChuan]" +
        //                                " SET [TC] ='" + dr["TC"].ToString() + "'" +
        //                                ",[TCDG] = '" + dr["TCDG"].ToString() + "' " +
        //                                "WHERE ID=" + int.Parse(dr["ID"].ToString()), CommandType.Text);
        //    //return dt;
        //}
        public void TC_INSERT(TieuChuan TC)
        {
            //XtraMessageBox.Show("LOC.Locked : " + LOC.Locked.ToString());
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_TieuChuan] " +
           " ([TC] " +
           " ,[TCDG] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Locked]) " +
     " VALUES " +
           "(N'" + TC.TC +
           "',N'" + TC.TCDG +
           "',CONVERT(datetime,'" + DateTime.Now +
           "',103),N'" + TC.CreatedBy +
           "',N'" + TC.Note +
           "','" + TC.Locked +
           "')", CommandType.Text);
        }

        public void TC_UPDATE(TieuChuan TC)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_TieuChuan] SET" +
           "[TC] = N'" + TC.TC + "'" +
           ",[TCDG] = N'" + TC.TCDG + "'" +
           ",[CreatedDate] = CONVERT(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy] = N'" + TC.CreatedBy + "' " +
           ",[Note] = N'" + TC.Note + "' " +
           ",[Locked] = '" + TC.Locked + "' " +
           " WHERE [ID]=" + TC.ID, CommandType.Text);
        }

        public void TC_DELETE(TieuChuan TC)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_TieuChuan] " +
            " WHERE [ID]=" + TC.ID, CommandType.Text);
        }
    }
}