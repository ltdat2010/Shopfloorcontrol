using System;
using System.Data;

namespace Production.Class
{
    public class ChiTieuPhanTichDAO
    {
        public DataTable CTPT_List()
        {
            DataTable dt = new DataTable();
            dt = Sql.ExecuteDataTable("SAP", "Select ID , CTPT From [SYNC_NUTRICIEL].[dbo].tbl_ChiTieuPhanTich WHERE ID>1", CommandType.Text);
            return dt;
        }

        //public void CTPT_Update(DataRow dr)
        //{
        //    Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_ChiTieuPhanTich]" +
        //                                " SET [CTPT] ='" + dr["CTPT"].ToString() + "'" +
        //                                ",[CTPTDG] = '" + dr["CTPTDG"].ToString() + "' " +
        //                                "WHERE ID=" + int.Parse(dr["ID"].ToString()), CommandType.Text);
        //    //return dt;
        //}

        public void CTPT_INSERT(ChiTieuPhanTich CTPT)
        {
            //XtraMessageBox.Show("LOC.Locked : " + LOC.Locked.ToString());
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_ChiTieuPhanTich] " +
           " ([CTPT] " +
           " ,[CTPTDG] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Locked]) " +
     " VALUES " +
           "(N'" + CTPT.CTPT +
           "',N'" + CTPT.CTPTDG +
           "',CONVERT(datetime,'" + DateTime.Now +
           "',103),N'" + CTPT.CreatedBy +
           "',N'" + CTPT.Note +
           "','" + CTPT.Locked +
           "')", CommandType.Text);
        }

        public void CTPT_UPDATE(ChiTieuPhanTich CTPT)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_ChiTieuPhanTich] SET" +
           "[CTPT] = N'" + CTPT.CTPT + "'" +
           ",[CTPTDG] = N'" + CTPT.CTPTDG + "'" +
           ",[CreatedDate] = CONVERT(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy] = N'" + CTPT.CreatedBy + "' " +
           ",[Note] = N'" + CTPT.Note + "' " +
           ",[Locked] = '" + CTPT.Locked + "' " +
           " WHERE [ID]=" + CTPT.ID, CommandType.Text);
        }

        public void CTPT_DELETE(ChiTieuPhanTich CTPT)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_ChiTieuPhanTich] " +
            " WHERE [ID]=" + CTPT.ID, CommandType.Text);
        }
    }
}