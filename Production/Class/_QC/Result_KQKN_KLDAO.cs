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
    public class Result_KQKN_KLDAO
    {
        public void Result_KQKN_KLDAO_INSERT(Result_KQKN_KL OBJ)
        {
           //XtraMessageBox.Show("LOC.Locked : " + LOC.Locked.ToString());
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_KL] " +
           " ([SoPKN] " +
           " ,[KL] " +
           " ,[CT] " +
           " ,[NguoiKT] " +
           " ,[NgayKT] " +
           " ,[TPKN] " +
           " ,[NgayPD] " +
           " ,[PassFail] " +
           " ,[Lan] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Locked]) " +
     " VALUES " +
           "(N'" + OBJ.SoPKN +
           "',N'" + OBJ.KL +
           "',N'" + OBJ.CT +
           "',N'" + OBJ.NguoiKT +
           //"',CONVERT(datetime,'" + OBJ.NgayKT +
           "',CONVERT(datetime,'" + DateTime.Now +
           "',103),N'" + OBJ.TPKN +
            //"',CONVERT(datetime,'" + OBJ.NgayPD +
            "',CONVERT(datetime,'" + DateTime.Now +
            "',103),N'" + OBJ.PassFail +
           "'," + OBJ.Lan +
           ",CONVERT(datetime,'" + DateTime.Now +
           "',103),N'" + OBJ.CreatedBy +
           "',N'" + OBJ.Note +
           //"','" + OBJ.Locked +
           "',N'False" + 
           "')", CommandType.Text);
        }

        public void Result_KQKN_KLDAO_UPDATE(Result_KQKN_KL OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_KL] SET" +
           "[SoPKN] = N'" + OBJ.SoPKN + "'" +
           ",[KL] = N'" + OBJ.KL + "'" +
           ",[CT] = N'" + OBJ.CT + "'" +
           ",[NguoiKT] = N'" + OBJ.NguoiKT + "'" +
           //",[NgayKT] = CONVERT(datetime,'" + OBJ.NgayKT + "',103)" +
           ",[NgayKT] = CONVERT(datetime,'" + DateTime.Now + "',103)" +
           ",[TPKN] = N'" + OBJ.TPKN + "'" +
           //",[NgayPD] = CONVERT(datetime,'" + OBJ.NgayPD + "',103)" +
           ",[NgayPD] = CONVERT(datetime,'" + DateTime.Now + "',103)" +
           ",[PassFail] = N'" + OBJ.PassFail + "'" +
           ",[Lan] = " + OBJ.Lan +
           ",[CreatedDate] = CONVERT(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy] = N'" + OBJ.CreatedBy + "' " +
           ",[Note] = N'" + OBJ.Note + "' " +
           //",[Locked] = '" + OBJ.Locked + "' " +
           ",[Locked] = 'False' " +
           " WHERE [SoPKN]='" + OBJ.SoPKN +"'", CommandType.Text);
        }

        public void Result_KQKN_KLDAO_DELETE(Result_KQKN_TD OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_KL] " +
            " WHERE [SoPKN]='" + OBJ.SoPKN + "'", CommandType.Text);
        }

        public Result_KQKN_KL Result_KQKN_KLDAO_SELECT_SoPKN(Result_KQKN_TD OBJ)
        {
            Result_KQKN_KL OBJKL = new Result_KQKN_KL();
            DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT * FROM [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_KL] " +
            " WHERE [SoPKN]='" + OBJ.SoPKN + "'", CommandType.Text);
            OBJKL.KL = dt.Rows[0]["KL"].ToString();
            OBJKL.PassFail = dt.Rows[0]["PassFail"].ToString();
            OBJKL.SoPKN = dt.Rows[0]["SoPKN"].ToString();

            return OBJKL;

        }
    }

}


