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
    public class PXN_Header_SUB_H2ODAO
    {
        public void PXN_Header_SUB_H2ODAO_INSERT(PXN_Header_SUB_H2O OBJ)
        {
            
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Header_SUB_H2O] " +
           " ([MaSoPXN] " +           
           " ,[NgayLayMau] " +
           " ,[LoaiNuoc] " +
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
           "',103),N'" + OBJ.LoaiNuoc +
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

        public void PXN_Header_SUB_H2ODAO_UPDATE(PXN_Header_SUB_H2O OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Header_SUB_H2O] SET " +
           " [MaSoPXN] = N'" + OBJ.MaSoPXN + "'" +
           ",[NgayLayMau] = CONVERT(datetime,'" + OBJ.NgayLayMau + "',103)" +
           ",[LoaiNuoc] = N'" + OBJ.LoaiNuoc + "'" +
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

        public void PXN_Header_SUB_H2ODAO_DELETE(PXN_Header_SUB_H2O OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Header_SUB_H2O] " +
            " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }

        public int MAX_PXN_Header_SUB_H2ODAO_ID()
        {
            DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT MAX(ID) as ID FROM [SYNC_NUTRICIEL].[dbo].[tbl_PXN_Header_SUB_H2O]", CommandType.Text);
            return int.Parse(dt.Rows[0]["ID"].ToString());

        }
    }

}


