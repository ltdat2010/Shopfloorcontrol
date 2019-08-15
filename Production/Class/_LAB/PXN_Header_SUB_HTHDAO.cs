using System;
using System.Data;

namespace Production.Class
{
    public class PXN_Header_SUB_HTHDAO
    {
        public void PXN_Header_SUB_HTHDAO_INSERT(PXN_Header_SUB_HTH OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Header_SUB_HTH] " +
           " ([MaSoPXN] " +
           " ,[NgayLayMau] " +
           " ,[Tuoi] " +
           " ,[LoaiDV] " +
           " ,[DayChuong] " +
           " ,[LoaiMau] " +
           " ,[SLMau] " +
           " ,[TTMau] " +
           " ,[KHMau] " +
           //" ,[IMGCOA] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Locked]) " +
     " VALUES " +
           "(N'" + OBJ.MaSoPXN +
           "',CONVERT(datetime,'" + OBJ.NgayLayMau +
           "',103),N'" + OBJ.Tuoi +
           "',N'" + OBJ.LoaiDV +
           "',N'" + OBJ.DayChuong +
           "',N'" + OBJ.LoaiMau +
           "',N'" + OBJ.SLMau +
           "',N'" + OBJ.TTMau +
           "',N'" + OBJ.KHMau +
           //"',N'" + OBJ.IMGCOA +
           "',CONVERT(datetime,'" + DateTime.Now +
           "',103),N'" + OBJ.CreatedBy +
           "',N'" + OBJ.Note +
           "','" + OBJ.Locked +
           "')", CommandType.Text);
        }

        public void PXN_Header_SUB_HTHDAO_UPDATE(PXN_Header_SUB_HTH OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Header_SUB_HTH] SET " +
           " [MaSoPXN] = N'" + OBJ.MaSoPXN + "'" +
           ",[NgayLayMau] = CONVERT(datetime,'" + OBJ.NgayLayMau + "',103)" +
           ",[Tuoi] = N'" + OBJ.Tuoi + "'" +
           ",[LoaiDV] = N'" + OBJ.LoaiDV + "'" +
           ",[DayChuong] = N'" + OBJ.DayChuong + "'" +
           ",[LoaiMau] = N'" + OBJ.LoaiMau + "'" +
           ",[SLMau] = N'" + OBJ.SLMau + "'" +
           ",[TTMau] = N'" + OBJ.TTMau + "'" +
           ",[KHMau] = N'" + OBJ.KHMau + "'" +
           ",[CreatedDate] = CONVERT(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy] = N'" + OBJ.CreatedBy + "' " +
           ",[Note] = N'" + OBJ.Note + "' " +
           ",[Locked] = '" + OBJ.Locked + "' " +
           " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }

        public void PXN_Header_SUB_HTHDAO_DELETE(PXN_Header_SUB_HTH OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Header_SUB_HTH] " +
            " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }

        public int MAX_PXN_Header_SUB_HTHDAO_ID()
        {
            DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT MAX(ID) as ID FROM [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Header_SUB_HTH]", CommandType.Text);
            return int.Parse(dt.Rows[0]["ID"].ToString());
        }
    }
}