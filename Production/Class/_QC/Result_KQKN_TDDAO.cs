using System;
using System.Data;

namespace Production.Class
{
    public class Result_KQKN_TDDAO
    {
        public void Result_KQKN_TD_INSERT(Result_KQKN_TD OBJ)
        {
            //XtraMessageBox.Show("LOC.Locked : " + LOC.Locked.ToString());
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_TD] " +
           " ([SoPKN] " +
           " ,[KQKNTemplateID] " +
           " ,[SoPNK] " +
           " ,[QCDG] " +
           " ,[UoM1] " +
           " ,[UoM2] " +
           " ,[SLNhan] " +
           " ,[NgayNhan] " +
           " ,[Solo] " +
           " ,[NgaySX] " +
           " ,[HSD] " +
           " ,[NgayPT] " +
           " ,[TenNL] " +
           " ,[Lan] " +
           " ,[CreatedDate] " +
           " ,[CreatedBy] " +
           " ,[Note] " +
           " ,[Locked]) " +
     " VALUES " +
           "('" + OBJ.SoPKN +
           "'," + OBJ.KQKNTemplateID +
           ",'" + OBJ.SoPNK +
           "','" + OBJ.QCDG +
           "','" + OBJ.UoM1 +
           "','" + OBJ.UoM2 +
           "','" + OBJ.SLNhan +
           "',Convert(datetime,'" + OBJ.NgayNhan +
           "',103),'" + OBJ.Solo +
           "',Convert(datetime,'" + OBJ.NgaySX +
           "',103),Convert(datetime,'" + OBJ.HSD +
           "',103),Convert(datetime,'" + OBJ.NgayPT +
           "',103),'" + OBJ.TenNL +
           "'," + OBJ.Lan +
           ",Convert(datetime,'" + DateTime.Now +
           "',103),N'" + OBJ.CreatedBy +
           "',N'" + OBJ.Note +
           //"','" + OBJ.Locked +
           "','False" +
           "')", CommandType.Text);
        }

        public void Result_KQKN_TD_UPDATE(Result_KQKN_TD OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_TD] SET" +
           "[SoPKN] = '" + OBJ.SoPKN + "'" +
           ",[KQKNTemplateID] = " + OBJ.KQKNTemplateID +
           ",[SoPNK] = '" + OBJ.SoPNK + "'" +
           ",[QCDG] = '" + OBJ.QCDG + "'" +
           ",[UoM1] = '" + OBJ.UoM1 + "'" +
           ",[UoM2] = '" + OBJ.UoM2 + "'" +
           ",[SLNhan] = '" + OBJ.SLNhan + "'" +
           ",[NgayNhan] = Convert(datetime,''" + OBJ.NgayNhan + "',103)" +
           ",[Solo] = '" + OBJ.Solo + "'" +
           ",[NgaySX] = Convert(datetime,''" + OBJ.NgaySX + "',103)" +
           ",[HSD] = Convert(datetime,''" + OBJ.HSD + "',103)" +
           ",[NgayPT] = Convert(datetime,''" + OBJ.NgayPT + "'" +
           ",[TenNL] = '" + OBJ.TenNL + "'" +
           ",[Lan] = " + OBJ.Lan +
           ",[CreatedDate] = Convert(datetime,''" + DateTime.Now + "',103)" +
           ",[CreatedBy] = N'" + OBJ.CreatedBy + "' " +
           ",[Note] = N'" + OBJ.Note + "' " +
           //",[Locked] = '" + OBJ.Locked + "' " +
           ",[Locked] = 'False' " +
           " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }

        public void Result_KQKN_TD_DELETE(Result_KQKN_TD OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_TD] " +
            " WHERE [ID]=" + OBJ.ID, CommandType.Text);
        }

        public int MAX_Result_KQKB_TD_ID()
        {
            DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT MAX(ID) as ID FROM [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_TD]", CommandType.Text);
            return int.Parse(dt.Rows[0]["ID"].ToString());
        }

        public int Result_KQKB_TD_SoPNK(string pre)
        {
            DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT ISNULL(MAX(RIGHT(SoPKN,4)),'0') as SoPKN FROM [SYNC_NUTRICIEL].[dbo].[tbl_Result_KQKN_TD] WHERE SoPKN like '" + pre + "%' and RIGHT(LEFT(SoPKN,6),2) = RIGHT(YEAR(GETDATE()),2)", CommandType.Text);
            return int.Parse(dt.Rows[0]["SoPKN"].ToString()) + 1;
        }
    }
}