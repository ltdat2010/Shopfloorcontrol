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
    public class PhuongPhapThuDAO
    {
        public DataTable PPT_List()
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "Select ID , PPT From [SYNC_NUTRICIEL].[dbo].tbl_PhuongPhapThu WHERE ID>1", CommandType.Text);
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

        public void PPT_INSERT(PhuongPhapThu PPT)
        {
            //XtraMessageBox.Show("LOC.Locked : " + LOC.Locked.ToString());
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_PhuongPhapThu] " +
           " ([PPT] " +
           " ,[PPTDG] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Locked]) " +
            " VALUES " +
           "(N'" + PPT.PPT +
           "',N'" + PPT.PPTDG +
           "',CONVERT(datetime,'" + DateTime.Now +
           "',103),N'" + PPT.CreatedBy +
           "',N'" + PPT.Note +
           "','" + PPT.Locked +
           "')", CommandType.Text);
        }

        public void PPT_UPDATE(PhuongPhapThu PPT)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_PhuongPhapThu] SET" +
           "[PPT] = N'" + PPT.PPT + "'" +
           ",[PPTDG] = N'" + PPT.PPTDG + "'" +
           ",[CreatedDate] = CONVERT(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy] = N'" + PPT.CreatedBy + "' " +
           ",[Note] = N'" + PPT.Note + "' " +
           ",[Locked] = '" + PPT.Locked + "' " +
           " WHERE [ID]=" + PPT.ID, CommandType.Text);
        }

        public void PPT_DELETE(PhuongPhapThu PPT)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_PhuongPhapThu] " +
            " WHERE [ID]=" + PPT.ID, CommandType.Text);
        }
    }

}


