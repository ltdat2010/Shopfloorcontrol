using System;
using System.Data;

namespace Production.Class
{
    public class MYCOTOXIN_RESULT_HeaderDAO
    {
        public int MYCOTOXIN_RESULT_Header_INSERT(MYCOTOXIN_RESULT_Header OBJ)
        {
            //if (Sql.ExecuteDataTable("SAP", "SELECT ID FROM [SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_Header_LAB] WHERE FilePath='" + OBJ.FilePath + "'", CommandType.Text).Rows[0]["ID"].ToString().Length == 0)
            //        return 0;
            //else
            //{
                        Sql.ExecuteNonQuery("SAP", "INSERT INTO [SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_Header_LAB] " +
                   " ([FilePath] " +
                   " ,[Date] " +
                   " ,[Time] " +
                   " ,[ReadingType] " +
                   " ,[ReaderType] " +
                   " ,[PlateType] " +
                   " ,[Read] " +
                   " ,[Wavelengths] " +
                   " ,[ReadSpeed] " +
                   " ,[SoftwareVersion] " +
                   " ,[PlateNumber] " +
                   " ,[a_SLOPE] " +
                   " ,[b_INTERCEPT] " +
                   " ,[R_SQUARE] " +
                   " ,[CreatedDate] " +
                   " ,[CreatedBy] " +
                   " ,[Note] " +
                   " ,[Name] " +
                   " ,[Locked]) " +
                    " VALUES " +
                   "(N'" + OBJ.FilePath +
                   "',Convert(datetime,'" + OBJ.Date +
                   "',103),Convert(datetime,'" + OBJ.Time +
                   "',103),N'" + OBJ.ReadingType +
                   "',N'" + OBJ.ReaderType +
                   "',N'" + OBJ.PlateType +
                   "',N'" + OBJ.Read +
                   "',N'" + OBJ.Wavelengths +
                   "',N'" + OBJ.ReadSpeed +
                   "',N'" + OBJ.SoftwareVersion +
                   "',N'" + OBJ.PlateNumber +
                   "'," + OBJ.a_SLOPE +
                   "," + OBJ.b_INTERCEPT +
                   "," + OBJ.R_SQUARE +
                   ",Convert(datetime,'" + DateTime.Now +
                   "',103),N'" + OBJ.CreatedBy +
                   "',N'" + OBJ.Note +
                   "',N'" + OBJ.Name +
                   "','" + OBJ.Locked +
                   "')", CommandType.Text);

                DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT ID FROM [SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_Header_LAB] " +
                    "WHERE FilePath='" + OBJ.FilePath + "'", CommandType.Text);
                return int.Parse(dt.Rows[0]["ID"].ToString());
            //}
            
            
        }

        public void MYCOTOXIN_RESULT_Header_UPDATE(MYCOTOXIN_RESULT_Header OBJ)
        {		            
            Sql.ExecuteNonQuery("SAP", "UPDATE [SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_Header_LAB] SET" +
           "[FilePath]          = N'" + OBJ.FilePath + "'" +
           ",[Date]             = N'" + OBJ.Date + "'" +
           ",[Time]              = N'" + OBJ.Time + "'" +
           ",[ReadingType]      = N'" + OBJ.ReadingType + "'" +
           ",[ReaderType] = N'" + OBJ.ReaderType + "'" +
           ",[PlateType] = N'" + OBJ.PlateType + "'" +
           ",[Read] = N'" + OBJ.Read + "'" +
           ",[Wavelengths] = N'" + OBJ.Wavelengths + "'" +
           ",[ReadSpeed] = N'" + OBJ.ReadSpeed + "'" +
           ",[SoftwareVersion] = N'" + OBJ.SoftwareVersion + "'" +
           ",[PlateNumber] = N'" + OBJ.PlateNumber + "'" +
           ",[a_SLOPE] = " + OBJ.a_SLOPE +
           ",[b_INTERCEPT] = " + OBJ.b_INTERCEPT +
           ",[R_SQUARE] = " + OBJ.R_SQUARE + 
           ",[CreatedDate] = Convert(datetime,'" + DateTime.Now + "',103)" +
           ",[CreatedBy] = N'" + OBJ.CreatedBy + "' " +
           ",[Note] = N'" + OBJ.Note + "' " +
           ",[Name] = N'" + OBJ.Name + "' " +
           ",[Locked] = '" + OBJ.Locked + "' " +
           " WHERE [ID]='" + OBJ.ID + "'", CommandType.Text);
        }

        public void MYCOTOXIN_RESULT_Header_DELETE(MYCOTOXIN_RESULT_Header OBJ)
        {
           Sql.ExecuteNonQuery("SAP", "DELETE FROM [SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_Header_LAB] " +
           " WHERE [ID]='" + OBJ.ID + "'", CommandType.Text);
        }

        public int MYCOTOXIN_RESULT_Header_ID(string FilePath)
        {
            DataTable dt = Sql.ExecuteDataTable("SAP", "SELECT ID FROM [SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_Header_LAB] " +
                "WHERE FilePath='"+ FilePath + "'", CommandType.Text);
            return int.Parse(dt.Rows[0]["ID"].ToString());

        }

        public DataTable MYCOTOXIN_RESULT_Header_SELECT(int ID)
        {
            return Sql.ExecuteDataTable("SAP", "SELECT * FROM [SYNC_NUTRICIEL].[dbo].[tbl_MYCOTOXIN_RESULT_Header_LAB] " +
                "WHERE ID=" + ID, CommandType.Text);
            

        }
    }

}


