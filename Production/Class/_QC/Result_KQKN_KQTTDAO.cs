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
    public class Result_KQKN_KQTTDAO
    {
        public void Result_KQKN_KQTTDAO_INSERT(Result_KQKN_KQTT OBJ)
        {
           //XtraMessageBox.Show("LOC.Locked : " + LOC.Locked.ToString());
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_KQTT] " +
           " ([SoPKN] " +
           " ,[KQKN_Detail_ID] " +
           " ,[KQTT] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Locked]) " +
     " VALUES " +
           "('" + OBJ.SoPKN +
           "'," + OBJ.KQKN_Detail_ID +
           ",'" + OBJ.KQTT +
           "',CONVERT(datetime,'" + DateTime.Now +
           "',103),N'" + OBJ.CreatedBy +
           "',N'" + OBJ.Note +
           //"','" + OBJ.Locked +
           "','False" +
           "')", CommandType.Text);
        }

        public void Result_KQKN_KQTTDAO_UPDATE(Result_KQKN_KQTT OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_KQTT] SET" +
           "[SoPKN] = '" + OBJ.SoPKN + "'" +
           ",[KQKN_Detail_ID] = " + OBJ.KQKN_Detail_ID +
           ",[KQTT] = N'" + OBJ.KQTT + "'" +
           ",[CreatedDate] = CONVERT(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy] = N'" + OBJ.CreatedBy + "' " +
           ",[Note] = N'" + OBJ.Note + "' " +
           ",[Locked] = 'False' " +
           " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }

        public void Result_KQKN_KQTTDAO_UPDATE_KQTT_VALUE(Result_KQKN_KQTT OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_KQTT] SET" +
           "[KQTT] = N'" + OBJ.KQTT + "'" +
           ",[CreatedDate] = CONVERT(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy] = N'" + OBJ.CreatedBy + "' " +
           ",[Note] = N'" + OBJ.Note + "' " +
           ",[Locked] = '" + OBJ.Locked + "' " +
           " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }

        public void Result_KQKN_KQTTDAO_DELETE(Result_KQKN_TD OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_KQTT] " +
            " WHERE [SoPKN]='" + OBJ.SoPKN+"'", CommandType.Text);
        }

        public void Result_KQKN_KQTTDAO_DELETE_ALL(Result_KQKN_TD OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_KQTT] " +
            " WHERE [SoPKN]='" + OBJ.SoPKN+"'", CommandType.Text);
        }

        
    }

}


