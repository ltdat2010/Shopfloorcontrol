using System;
using System.Data;

namespace Production.Class
{
    public class PXN_Header_SUB_GENDAO
    {
        public void PXN_Header_SUB_GENDAO_INSERT(PXN_Header_SUB_GEN OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Header_SUB_GEN] " +
           " ([MaSoPXN] " +
           " ,[NgayLayMau] " +
           " ,[LoaiMau] " +
           " ,[VitriLay] " +
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
           "',103),N'" + OBJ.LoaiMau +
           "',N'" + OBJ.VitriLay +
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

        public void PXN_Header_SUB_GENDAO_UPDATE(PXN_Header_SUB_GEN OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Header_SUB_GEN] SET " +
           " [MaSoPXN] = N'" + OBJ.MaSoPXN + "'" +
           ",[NgayLayMau] = CONVERT(datetime,'" + OBJ.NgayLayMau + "',103)" +
           ",[LoaiNuoc] = N'" + OBJ.LoaiMau + "'" +
           ",[VitriLay] = N'" + OBJ.VitriLay + "'" +
           ",[SLMau] = N'" + OBJ.SLMau + "'" +
           ",[TTMau] = N'" + OBJ.TTMau + "'" +
           ",[KHMau] = N'" + OBJ.KHMau + "'" +
           ",[CreatedDate] = CONVERT(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy] = N'" + OBJ.CreatedBy + "' " +
           ",[Note] = N'" + OBJ.Note + "' " +
           ",[Locked] = '" + OBJ.Locked + "' " +
           " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }

        public void PXN_Header_SUB_GENDAO_DELETE(PXN_Header_SUB_GEN OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Header_SUB_GEN] " +
            " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }

        public int MAX_PXN_Header_SUB_GENDAO_ID()
        {
            DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT MAX(ID) as ID FROM [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Header_SUB_GEN]", CommandType.Text);
            return int.Parse(dt.Rows[0]["ID"].ToString());
        }
    }
}