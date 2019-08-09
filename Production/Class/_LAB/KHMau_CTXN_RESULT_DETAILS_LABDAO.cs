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
    public class KHMau_CTXN_RESULT_DETAILS_LABDAO
    {
        public void KHMau_CTXN_LABDAO_INSERT(KHMau_CTXN_RESULT_DETAILS_LAB OBJ)
        {
            
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_KHMau_CTXN_RESULT_DETAILS_LAB] " +
           " ([KHMau_CTXN_ID] " +
           " ,[LineNo] " +
           " ,[MinVal] " +
           " ,[MaxVal] " +
           " ,[Custom1] " +
           " ,[Custom2] " +
           " ,[Custom3] " +
           " ,[Custom4] " +
           " ,[Custom5] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +           
           " ,[Locked]) " +
     " VALUES " +
           "(" + OBJ.KHMau_CTXN_ID +
           "," + OBJ.LineNo +
           ",N'" + OBJ.MinVal +
           "',N'" + OBJ.MaxVal +
           "',N'" + OBJ.Custom1 +
           "',N'" + OBJ.Custom2 +
           "',N'" + OBJ.Custom3 +
           "',N'" + OBJ.Custom4 +
           "',N'" + OBJ.Custom5 +
           "',CONVERT(datetime,'" + DateTime.Now +
           "',103),N'" + OBJ.CreatedBy +
           "',N'" + OBJ.Note +           
           "','" + OBJ.Locked +
           "')", CommandType.Text);
        }

        public void KHMau_CTXN_LABDAO_UPDATE(KHMau_CTXN_RESULT_DETAILS_LAB OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_KHMau_CTXN_RESULT_DETAILS_LAB] SET " +
           //"[KHMau_CTXN_ID]                     = " + OBJ.KHMau_CTXN_ID +
           //",[LineNo]                           = " + OBJ.LineNo + 
           "[MinVal]                           = N'" + OBJ.MinVal + "'" +
           ",[MaxVal]                           = N'" + OBJ.MaxVal + "'" +
           ",[Custom1]                          = N'" + OBJ.Custom1 + "'"+
           ",[Custom2]                          = N'" + OBJ.Custom2 + "'" +
           ",[Custom3]                          = N'" + OBJ.Custom3 + "'" +
           ",[Custom4]                          = N'" + OBJ.Custom4 + "'" +
           ",[Custom5]                          = N'" + OBJ.Custom5 + "'" +
           ",[CreatedDate]                      = CONVERT(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy]                        = N'" + OBJ.CreatedBy + "' " +
           ",[Note]                             = N'" + OBJ.Note + "' " +           
           ",[Locked]                           = '" + OBJ.Locked + "' " +
           " WHERE [ID]                         =" + OBJ.ID, CommandType.Text);
        }

        public void KHMau_CTXN_LABDAO_DELETE(int ID)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_KHMau_CTXN_RESULT_DETAILS_LAB] " +
            " WHERE [ID]=" + ID , CommandType.Text);
        }

        public void KHMau_CTXN_LABDAO_DELETE_ByKHMau_CTXN_ID(int KHMau_CTXN_ID)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_KHMau_CTXN_RESULT_DETAILS_LAB] " +
            " WHERE [KHMau_CTXN_ID]=" + KHMau_CTXN_ID , CommandType.Text);
        }

        public void KHMau_CTXN_LABDAO_DELETE_ByKHMau(string KHMau)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_KHMau_CTXN_RESULT_DETAILS_LAB] " +
            " WHERE [KHMau]='" + KHMau + "'", CommandType.Text);
        }

        public DataTable KHMau_CTXN_LABDAO_SELECT(string KHMau_CTXN_ID)
        {
            return Sql.ExecuteDataTable("SAP", "SELECT * FROM [SYNC_NUTRICIEL].[dbo].[tbl_KHMau_CTXN_RESULT_DETAILS_LAB] " +
                                                " WHERE [KHMau_CTXN_ID]='" + KHMau_CTXN_ID + "'", CommandType.Text);
        }

        public int MAX_KHMau_CTXN_LABDAO_ID()
        {
            DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT MAX(ID) as ID FROM [SYNC_NUTRICIEL].[dbo].[tbl_KHMau_CTXN_LAB]", CommandType.Text);
            return int.Parse(dt.Rows[0]["ID"].ToString());
        }        

    }

}


