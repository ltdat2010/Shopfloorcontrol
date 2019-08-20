using System;
using System.Data;
using Production.Class._LAB.RESULT;

namespace Production.Class
{
    public class IBD_RESULT_Header_LABDAO
    {
        public int IBD_RESULT_Header_LABDAO_INSERT(IBD_RESULT_Header_LAB OBJ)
        {
            //if (Sql.ExecuteDataTable("SAP", "SELECT ID FROM [SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_Header_LAB] WHERE FilePath='" + OBJ.FilePath + "'", CommandType.Text).Rows[0]["ID"].ToString().Length == 0)
            //        return 0;
            //else
            //{
            Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_IBD_RESULT_Header_LAB] " +
               " ([FilePath] " +
               " ,[FileName] " +
               " ,[Date] " +
               " ,[Time] " +
               " ,[Case] " +
               " ,[Count] " +
               " ,[GMean] " +
               " ,[Mean] " +
               " ,[SD] " +
               " ,[CV] " +
               " ,[Min] " +
               " ,[Max] " +
               " ,[Tech] " +
               " ,[HUYETTHANHHOC_STD_VALUE_ID] " +
               " ,[CreatedDate] " +
               " ,[CreatedBy] " +
               " ,[Note] " +
               " ,[Locked]) " +
                " VALUES " +
               "(N'" + OBJ.FilePath +
               "',N'" + OBJ.FileName +
               "',Convert(datetime,'" + OBJ.Date +
               "',103),N'" + OBJ.Time +
               "',N'" + OBJ.Case +
               "'," + OBJ.Count +
               "," + OBJ.GMean +
               "," + OBJ.Mean +
               "," + OBJ.SD +
               "," + OBJ.CV +
               "," + OBJ.Min +
               "," + OBJ.Max +
               "," + OBJ.Tech +
               "," + OBJ.HUYETTHANHHOC_STD_VALUE_ID +
               ",Convert(datetime,N'" + DateTime.Now +
               "',103),N'" + OBJ.CreatedBy +
               "',N'" + OBJ.Note +
               "','" + OBJ.Locked +
               "')", CommandType.Text);

            DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT ID FROM [SYNC_NUTRICIEL].[dbo].[tbl_IBD_RESULT_Header_LAB] " +
                "WHERE FilePath='" + OBJ.FilePath + "'", CommandType.Text);
            return int.Parse(dt.Rows[0]["ID"].ToString());
            //}
        }

        public void IBD_RESULT_Header_LABDAO_UPDATE(IBD_RESULT_Header_LAB OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_IBD_RESULT_Header_LAB] SET" +
           "[FilePath]          = N'" + OBJ.FilePath + "'" +
           ",[FileName]          = N'" + OBJ.FileName + "'" +
           ",[Date]             = Convert(datetime,'" + OBJ.Date + "',103)" +
           ",[Time]              = N'" + OBJ.Time + "'" +
           ",[Case]      = N'" + OBJ.Case + "'" +
           ",[Count] = " + OBJ.Count +
           ",[GMean] = " + OBJ.GMean +
           ",[Mean] = " + OBJ.Mean +
           ",[SD] = " + OBJ.SD +
           ",[CV] = " + OBJ.CV +
           ",[Min] = " + OBJ.Min +
           ",[Max] = " + OBJ.Max +
           ",[Tech] = " + OBJ.Tech +
           ",[HUYETTHANHHOC_STD_VALUE_ID] = " + OBJ.HUYETTHANHHOC_STD_VALUE_ID +           
           ",[CreatedDate] = Convert(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy] = N'" + OBJ.CreatedBy + "' " +
           ",[Note] = N'" + OBJ.Note + "' " +
           ",[Locked] = '" + OBJ.Locked + "' " +
           " WHERE [ID]='" + OBJ.ID + "'", CommandType.Text);
        }

        public void IBD_RESULT_Header_LABDAO_DELETE(IBD_RESULT_Header_LAB OBJ)
        {
            Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_IBD_RESULT_Header_LAB] " +
            " WHERE [ID]='" + OBJ.ID + "'", CommandType.Text);
        }

        //public int MYCOTOXIN_RESULT_Header_ID(string FilePath)
        //{
        //    DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT ID FROM [SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_Header_LAB] " +
        //        "WHERE FilePath='" + FilePath + "'", CommandType.Text);
        //    return int.Parse(dt.Rows[0]["ID"].ToString());
        //}

        public DataTable IBD_RESULT_Header_LABDAO_SELECT(int ID)
        {
            return Sql.ExecuteDataTable("SAP", "SELECT * FROM [SYNC_NUTRICIEL].[dbo].[tbl_IBD_RESULT_Header_LAB] " +
                "WHERE ID=" + ID, CommandType.Text);
        }
    }
}