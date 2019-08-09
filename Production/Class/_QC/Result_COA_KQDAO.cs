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
    public class Result_COA_KQDAO
    {
        public void Result_COA_KQDAO_INSERT(Result_COA_KQ OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_KQ] " +
           " ([SoCOA] " +
           " ,[COA_Template_Details_ID] " +
           " ,[Result] " +
           ",[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Locked]) " +
     " VALUES " +
           "(N'" + OBJ.SoCOA +
           "'," + OBJ.COA_Template_Details_ID +
           ",'" + OBJ.Result +
           "',Convert(datetime,'" + DateTime.Now +
           "',103),N'" + OBJ.CreatedBy +
           "',N'" + OBJ.Note +
           //"','" + OBJ.Locked +
           "','False" + 
           "')", CommandType.Text);
        }

        public void Result_COA_KQDAO_UPDATE(Result_COA_KQ OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_KQ] SET" +
           "[SoCOA]          = N'" + OBJ.SoCOA + "'" +
           ",[COA_Template_Details_ID] = " + OBJ.COA_Template_Details_ID +
           ",[Result]            = N'" + OBJ.Result + "'" +
           ",[CreatedDate]   = Convert(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy]     = N'" + OBJ.CreatedBy + "' " +
           ",[Note]          = N'" + OBJ.Note + "' " +
           //",[Locked]        = '" + OBJ.Locked + "' " +
           ",[Locked]        = 'False' " +
           " WHERE [ID]      =" + OBJ.ID, CommandType.Text);
        }

        public void Result_COA_KQDAO_UPDATE_VALUE(Result_COA_KQ OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_KQ] SET" +
           "[Result]            = N'" + OBJ.Result + "'" +
           ",[CreatedDate]   = Convert(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy]     = N'" + OBJ.CreatedBy + "' " +
           //",[Note]          = N'" + OBJ.Note + "' " +
           //",[Locked]        = '" + OBJ.Locked + "' " +
           ",[Locked]        = 'False' " +
           " WHERE [ID]      =" + OBJ.ID, CommandType.Text);
        }

        public void Result_COA_KQDAO_DELETE(Result_COA_TD OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_KQ] " +
            " WHERE [SoCOA]= '" + OBJ.SoCOA + "'", CommandType.Text);
        }

        public int MAX_Result_COA_TD_ID()
        {
            DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT MAX(ID) as ID FROM [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_KQ]", CommandType.Text);
            return int.Parse(dt.Rows[0]["ID"].ToString());

        }

        //public int Result_COA_TD_SoCOA()
        //{
        //    DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT ISNULL(MAX(RIGHT(SoPKN,4)),'0') as SoPKN FROM [SYNC_NUTRICIEL].[dbo].[tbl_Result_COA_TD]", CommandType.Text);
        //    return int.Parse(dt.Rows[0]["SoPKN"].ToString())+1;

        //}
    }

}


