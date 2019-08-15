using System;
using System.Data;

namespace Production.Class
{
    public class Result_COA_TDDAO
    {
        public void Result_COA_TDDAO_INSERT(Result_COA_TD OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_TD] " +
           " ([SoCOA] " +
           " ,[COATemplateID] " +
           " ,[WO] " +
           " ,[ManfBy] " +
           " ,[SmpDate] " +
           " ,[ExpDate] " +
           " ,[AnlDate] " +
           " ,[ManfDate] " +
           " ,[LB_MAT] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Locked]) " +
     " VALUES " +
           "(N'" + OBJ.SoCOA +
           "'," + OBJ.COATemplateID +
           ",N'" + OBJ.WO +
           "',N'" + OBJ.ManfBy +
           "',Convert(datetime,'" + OBJ.SmpDate +
           "',103),Convert(datetime,'" + OBJ.ExpDate +
           "',103),Convert(datetime,'" + OBJ.AnlDate +
           "',103),Convert(datetime,'" + OBJ.ManfDate +
           "',103),'" + OBJ.LB_MAT +
           "',Convert(datetime,'" + DateTime.Now +
           "',103),N'" + OBJ.CreatedBy +
           "',N'" + OBJ.Note +
           //"','" + OBJ.Locked +
           "','False" +
           "')", CommandType.Text);
        }

        public void Result_COA_TDDAO_UPDATE(Result_COA_TD OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_TD] SET" +
           "[SoCOA]          = N'" + OBJ.SoCOA + "'" +
           ",[COATemplateID] = " + OBJ.COATemplateID +
           ",[WO]            = N'" + OBJ.WO + "'" +
           ",[ManfBy]        = N'" + OBJ.ManfBy + "'" +
           ",[SmpDate]       = Convert(datetime,'" + OBJ.SmpDate + "',103)" +
           ",[ExpDate]       = Convert(datetime,'" + OBJ.ExpDate + "',103)" +
           ",[AnlDate]       = Convert(datetime,'" + OBJ.AnlDate + "',103)" +
           ",[ManfDate]      = Convert(datetime,'" + OBJ.ManfDate + "',103)" +
           ",[LB_MAT]        = '" + OBJ.LB_MAT + "'" +
           ",[CreatedDate]   = Convert(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy]     = N'" + OBJ.CreatedBy + "' " +
           ",[Note]          = N'" + OBJ.Note + "' " +
           //",[Locked]        = '" + OBJ.Locked + "' " +
           ",[Locked]        = 'False' " +
           " WHERE [ID]      =" + OBJ.ID, CommandType.Text);
        }

        public void Result_COA_TDDAO_DELETE(Result_COA_TD OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_TD] " +
            " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }

        public int MAX_Result_COA_TD_ID()
        {
            DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT MAX(ID) as ID FROM [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_TD]", CommandType.Text);
            return int.Parse(dt.Rows[0]["ID"].ToString());
        }

        public int Result_COA_TD_SoCOA()
        {
            DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT ISNULL(MAX(RIGHT(SoCOA,4)),'0') as SoCOA FROM [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_TD] WHERE RIGHT(LEFT(SoCOA,6),2) = RIGHT(YEAR(GETDATE()),2)", CommandType.Text);
            return int.Parse(dt.Rows[0]["SoCOA"].ToString()) + 1;
        }
    }
}