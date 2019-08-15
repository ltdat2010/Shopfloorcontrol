using System;
using System.Data;

namespace Production.Class
{
    public class COA_Template_HeaderDAO
    {
        public void COA_Template_HeaderDAO_INSERT(COA_Template_Header OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_COA_Template_Header] " +
           " ([COATemplate] " +
           " ,[COADescription] " +
           //" ,[IMGCOA] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Locked]) " +
     " VALUES " +
           "(N'" + OBJ.COATemplate +
           "',N'" + OBJ.COADescription +
           //"',N'" + OBJ.IMGCOA +
           "',CONVERT(datetime,'" + DateTime.Now +
           "',103),N'" + OBJ.CreatedBy +
           "',N'" + OBJ.Note +
           "','" + OBJ.Locked +
           "')", CommandType.Text);
        }

        public void COA_Template_HeaderDAO_UPDATE(COA_Template_Header OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_COA_Template_Header] SET " +
           " [COATemplate] = N'" + OBJ.COATemplate + "'" +
           ",[COADescription] = N'" + OBJ.COADescription + "'" +
           //",[IMGCOA] = N'" + OBJ.IMGCOA + "'" +
           ",[CreatedDate] = CONVERT(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy] = N'" + OBJ.CreatedBy + "' " +
           ",[Note] = N'" + OBJ.Note + "' " +
           ",[Locked] = '" + OBJ.Locked + "' " +
           " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }

        public void COA_Template_HeaderDAO_DELETE(COA_Template_Header OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_COA_Template_Header] " +
            " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }

        public int MAX_COA_Template_ID()
        {
            DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT MAX(ID) as ID FROM [SYNC_NUTRICIEL].[dbo].[tbl_COA_Template_Header]", CommandType.Text);
            return int.Parse(dt.Rows[0]["ID"].ToString());
        }
    }
}