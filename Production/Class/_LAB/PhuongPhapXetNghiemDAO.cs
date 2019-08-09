using System;
using System.Data;

namespace Production.Class
{
    public class PhuongPhapXetNghiemDAO
    {
        public DataTable PPXN_List()
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "Select ID , PPXN From [SYNC_NUTRICIEL].[dbo].tbl_PhuongPhapXetNghiem_LAB WHERE ID>1", CommandType.Text);
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

        public void PPXN_INSERT(PhuongPhapXetNghiem OBJ)
        {
            //XtraMessageBox.Show("LOC.Locked : " + LOC.Locked.ToString());
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_PhuongPhapXetNghiem_LAB] " +
           " ([PPXN] " +
           " ,[PPXNDG] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Locked]) " +
            " VALUES " +
           "(N'" + OBJ.PPXN +
           "',N'" + OBJ.PPXNDG +
           "',Convert(datetime,'" + DateTime.Now +
           "',103),N'" + OBJ.CreatedBy +
           "',N'" + OBJ.Note +
           "','" + OBJ.Locked +
           "')", CommandType.Text);
        }

        public void PPXN_UPDATE(PhuongPhapXetNghiem OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_PhuongPhapXetNghiem_LAB] SET" +
           "[PPXN] = N'" + OBJ.PPXN + "'" +
           ",[PPXNDG] = N'" + OBJ.PPXNDG + "'" +
           ",[CreatedDate] = Convert(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy] = N'" + OBJ.CreatedBy + "' " +
           ",[Note] = N'" + OBJ.Note + "' " +
           ",[Locked] = '" + OBJ.Locked + "' " +
           " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }

        public void PPXN_DELETE(PhuongPhapXetNghiem OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_PhuongPhapXetNghiem_LAB] " +
            " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }
    }

}


