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
    public class KQKN_Template_HeaderDAO
    {
        public void KQKN_Template_Header_INSERT(KQKN_Template_Header OBJ)
        {
            //XtraMessageBox.Show("LOC.Locked : " + LOC.Locked.ToString());
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_KQKN_Template_Header] " +
           " ([KQKNTemplate] " +
           " ,[SoMRA] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Locked]) " +
     " VALUES " +
           "(N'" + OBJ.KQKNTemplate + 
           "',N'" + OBJ.SoMRA +          
           "',CONVERT(datetime,'" + DateTime.Now +
           "',103),N'" + OBJ.CreatedBy +
           "',N'" + OBJ.Note +
           "','" + OBJ.Locked +
           "')", CommandType.Text);
        }

        public void KQKN_Template_Header_UPDATE(KQKN_Template_Header OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_KQKN_Template_Header] SET" +
           "[KQKNTemplate] = N'" + OBJ.KQKNTemplate + "'" +
           ",[SoMRA] = N'" + OBJ.SoMRA + "'" +
           ",[CreatedDate] = CONVERT(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy] = N'" + OBJ.CreatedBy + "' " +
           ",[Note] = N'" + OBJ.Note + "' " +
           ",[Locked] = '" + OBJ.Locked + "' " +
           " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }

        public void KQKN_Template_Header_DELETE(KQKN_Template_Header OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_KQKN_Template_Header] " +
            " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }

        public int MAX_KQKB_Template_ID()
        {
            DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT MAX(ID) as ID FROM [SYNC_NUTRICIEL].[dbo].[tbl_KQKN_Template_Header]", CommandType.Text);
            return int.Parse(dt.Rows[0]["ID"].ToString());

        }
    }

}


