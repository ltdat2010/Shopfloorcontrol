using System;
using System.Data;

namespace Production.Class
{
    class NHOMCHITIEUXETNGHIEMDAO
    {

        public DataTable NCTXN_List()
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "Select ID , NCTXN From [SYNC_NUTRICIEL].[dbo].tbl_NhomChiTieuXetNghiem_LAB WHERE ID>1", CommandType.Text);
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

        public void NCTXN_INSERT(NHOMCHITIEUXETNGHIEM OBJ)
        {
           Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_NhomChiTieuXetNghiem_LAB] " +
           " ([NCTXN] " +
           " ,[NCTXNDG] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[NhomChung] " +
           " ,[Locked]) " +
            " VALUES " +
           "(N'" + OBJ.NCTXN +
           "',N'" + OBJ.NCTXNDG +
           "',Convert(datetime,'" + DateTime.Now +
           "',103),N'" + OBJ.CreatedBy +
           "',N'" + OBJ.Note +
           "',N'" + OBJ.NhomChung +
           "','" + OBJ.Locked +
           "')", CommandType.Text);
        }

        public void NCTXN_UPDATE(NHOMCHITIEUXETNGHIEM OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_NhomChiTieuXetNghiem_LAB] SET" +
           "[NCTXN] = N'" + OBJ.NCTXN + "'" +
           ",[NCTXNDG] = N'" + OBJ.NCTXNDG + "'" +
           ",[CreatedDate] = Convert(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy] = N'" + OBJ.CreatedBy + "' " +
           ",[Note] = N'" + OBJ.Note + "' " +
           ",[NhomChung] = N'" + OBJ.NhomChung + "' " +
           ",[Locked] = '" + OBJ.Locked + "' " +
           " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }

        public void NCTXN_DELETE(NHOMCHITIEUXETNGHIEM OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_NhomChiTieuXetNghiem_LAB] " +
            " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }

    }
}
